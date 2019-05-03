Imports MySql.Data.MySqlClient
Imports Microsoft.Office.Interop
Imports System.Linq
Imports System.ComponentModel

Public Class frmGenerateSalary

    Dim ds As New DataSet
    Dim dt As New DataTable

    Dim strEmpIds As String = ""
    Dim emp_rYesdFixed As String
    Dim emp_rNodFixed As String
    Dim emp_rYesdCalc As String
    Dim emp_rNodCalc As String

    Dim DailyBasisSalaryQuery As String
    Dim PermanentSalaryQuery As String
    Private Sub frmGenerateSalary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdSalary.AutoGenerateColumns = False
        grdEmployee.AutoGenerateColumns = False
    End Sub

    Private Sub cmbEmpType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpType.SelectedIndexChanged
        Try
            Dim qry As String = "SELECT ID,empName," & True & " AS Responsibilty," & True & " AS ischecked,'Fixed' Deduction FROM tblemployee"
            If cmbEmpType.Text = "Permanent" Or cmbEmpType.Text = "Lương căn bản" Then
                qry += " WHERE emptype = 'Permanent' OR emptype = 'Lương căn bản'"
                grdEmployee.Columns(3).Visible = True
                grdEmployee.Columns(4).Visible = True
            ElseIf cmbEmpType.Text = "Daily Basis" Or cmbEmpType.Text = "Lương sản phẩm" Then
                qry += " WHERE emptype = 'Daily Basis' OR emptype = 'Lương sản phẩm'"
                grdEmployee.Columns(3).Visible = False
                grdEmployee.Columns(4).Visible = False
            End If

            Dim con As New MySqlConnection(g_connStr)
            Dim dtadpt As New MySqlDataAdapter(qry, con)
            Dim dt As New DataTable
            chkSelectAll.Checked = True

            dtadpt.Fill(dt)
            If dt.Rows.Count > 0 Then
                grdEmployee.DataSource = dt

                Dim dgvcc As DataGridViewComboBoxCell


                For Each row As DataGridViewRow In grdEmployee.Rows
                    dgvcc = row.Cells(4)
                    If DefaultLanguage = "English" Then
                        dgvcc.Items.Add("Fixed")
                        dgvcc.Items.Add("Calculated")
                    Else
                        dgvcc.Items.Add("đã sửa")
                        dgvcc.Items.Add("Tính")
                    End If
                Next



            End If

            ClearSalaryGrid()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        If chkSelectAll.Checked = True Then

            For Each dgvRow As DataGridViewRow In grdEmployee.Rows
                dgvRow.Cells(0).Value = True
            Next
        Else
            For Each dgvRow As DataGridViewRow In grdEmployee.Rows
                dgvRow.Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub ClearSalaryGrid()

        Try

            If Not IsNothing(grdSalary.Columns("btnDetail")) Then grdSalary.Columns.Remove("btnDetail")
            grdSalary.DataSource = Nothing
            ds.Tables.Clear()

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click

        If IsNothing(grdEmployee.DataSource) OrElse grdEmployee.Rows.Count = 0 OrElse SelectedEmployeesCount() = 0 Then
            If DefaultLanguage = "English" Then
                MessageBox.Show("No employees selected to generate salary", "Generate Salary")
            Else
                MessageBox.Show("Không có nhân viên nào được chọn để tạo bảng lương", "Tạo Bảng Lương")
            End If
            Exit Sub
        End If

        ClearSalaryGrid()

        If cmbEmpType.Text = "Daily Basis" OrElse cmbEmpType.Text = "Lương sản phẩm" Then
            strEmpIds = ""
            For Each row As DataGridViewRow In grdEmployee.Rows
                If Not IsDBNull(row.Cells("chkSelected").Value) AndAlso CBool(row.Cells("chkSelected").Value) = True Then
                    strEmpIds = strEmpIds + row.Cells("ID").Value.ToString() + ", "
                End If
            Next
            If strEmpIds <> "" Then strEmpIds = strEmpIds.Substring(0, strEmpIds.Length - 2)

            CompileDailyBasisSalaryQuery()
            GenerateDailyBasesEmployeeSalary()

            dt = ds.Tables("tblDailyBasesSalary")

            grdSalary.AutoGenerateColumns = True
            grdSalary.DataSource = dt

            DailyBasesGridViewSettings()

            strEmpIds = ""

        Else
            For Each row As DataGridViewRow In grdEmployee.Rows

                If Not IsDBNull(row.Cells("chkSelected").Value) AndAlso CBool(row.Cells("chkSelected").Value) = True Then
                    If (Not IsDBNull(row.Cells("Responsibilty").Value)) AndAlso CBool(row.Cells("Responsibilty").Value) = True AndAlso (row.Cells("Deduction").Value = "Fixed" OrElse row.Cells("Deduction").Value = "đã sửa") Then
                        emp_rYesdFixed = emp_rYesdFixed + row.Cells("ID").Value.ToString() + ", "
                    ElseIf (IsDBNull(row.Cells("Responsibilty").Value) OrElse CBool(row.Cells("Responsibilty").Value) = False) AndAlso (row.Cells("Deduction").Value = "Fixed" OrElse row.Cells("Deduction").Value = "đã sửa") Then
                        emp_rNodFixed = emp_rNodFixed + row.Cells("ID").Value.ToString() + ", "
                    ElseIf (Not IsDBNull(row.Cells("Responsibilty").Value)) AndAlso CBool(row.Cells("Responsibilty").Value) = True AndAlso (row.Cells("Deduction").Value = "Calculated" OrElse row.Cells("Deduction").Value = "Tính") Then
                        emp_rYesdCalc = emp_rYesdCalc + row.Cells("ID").Value.ToString() + ", "
                    ElseIf (IsDBNull(row.Cells("Responsibilty").Value) OrElse CBool(row.Cells("Responsibilty").Value) = False) AndAlso (row.Cells("Deduction").Value = "Calculated" OrElse row.Cells("Deduction").Value = "Tính") Then
                        emp_rNodCalc = emp_rNodCalc + row.Cells("ID").Value.ToString() + ", "
                    End If
                End If

            Next

            If emp_rYesdFixed <> "" Then
                emp_rYesdFixed = emp_rYesdFixed.Substring(0, emp_rYesdFixed.Length - 2)
                CompilePermanentSalaryQuery(True, "Fixed")
                GeneratePermanentEmployeesSalary(emp_rYesdFixed)
            End If
            If emp_rNodFixed <> "" Then
                emp_rNodFixed = emp_rNodFixed.Substring(0, emp_rNodFixed.Length - 2)
                CompilePermanentSalaryQuery(False, "Fixed")
                GeneratePermanentEmployeesSalary(emp_rNodFixed)
            End If
            If emp_rYesdCalc <> "" Then
                emp_rYesdCalc = emp_rYesdCalc.Substring(0, emp_rYesdCalc.Length - 2)
                CompilePermanentSalaryQuery(True, "Calculated")
                GeneratePermanentEmployeesSalary(emp_rYesdCalc)
            End If
            If emp_rNodCalc <> "" Then
                emp_rNodCalc = emp_rNodCalc.Substring(0, emp_rNodCalc.Length - 2)
                CompilePermanentSalaryQuery(False, "Calculated")
                GeneratePermanentEmployeesSalary(emp_rNodCalc)
            End If

            dt = ds.Tables("tblPermanentEmployeesSalary")

            grdSalary.AutoGenerateColumns = True
            grdSalary.DataSource = dt

            PermanentGridViewSettings()

            emp_rYesdFixed = ""
            emp_rNodFixed = ""
            emp_rYesdCalc = ""
            emp_rNodCalc = ""

        End If

        Dim buttonCol = New DataGridViewImageColumn()
        buttonCol.Name = "btnDetail"
        If DefaultLanguage = "English" Then
            buttonCol.HeaderText = "Detail"
        Else
            buttonCol.HeaderText = "Chi tiết"
        End If
        buttonCol.Width = 50
        buttonCol.Image = QuanLySanXuat.My.Resources.Resources.DetailView
        buttonCol.ReadOnly = False
        grdSalary.Columns.Add(buttonCol)

    End Sub

    Private Function SelectedEmployeesCount() As Integer

        Try

            SelectedEmployeesCount = 0
            For Each row As DataGridViewRow In grdEmployee.Rows
                If (Not IsDBNull(row.Cells("chkSelected").Value)) AndAlso CBool(row.Cells("chkSelected").Value) = True Then
                    SelectedEmployeesCount = SelectedEmployeesCount + 1
                End If
            Next

            Return SelectedEmployeesCount

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Function

    Private Sub DailyBasesGridViewSettings()
        Try

            grdSalary.Columns("ID").HeaderText = IIf(DefaultLanguage = "English", "Employee ID", "ID")
            grdSalary.Columns("ID").MinimumWidth = 100
            grdSalary.Columns("ID").ReadOnly = True
            grdSalary.Columns("ID").Frozen = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("Employee").HeaderText = IIf(DefaultLanguage = "English", "Employee Name", "Tên Nhân Viên")
            grdSalary.Columns("Employee").MinimumWidth = 150
            grdSalary.Columns("Employee").ReadOnly = True
            grdSalary.Columns("Employee").Frozen = True

            grdSalary.Columns("WorkingDays").HeaderText = IIf(DefaultLanguage = "English", "Working Days", "Những ngày đi làm")
            grdSalary.Columns("WorkingDays").MinimumWidth = 100
            grdSalary.Columns("WorkingDays").ReadOnly = True
            grdSalary.Columns("WorkingDays").Frozen = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("JobsPayment").HeaderText = IIf(DefaultLanguage = "English", "Jobs Payment", "Jobs Payment")
            grdSalary.Columns("JobsPayment").MinimumWidth = 100
            grdSalary.Columns("JobsPayment").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("JobsPayment").ReadOnly = True

            grdSalary.Columns("FerryAllowance").HeaderText = IIf(DefaultLanguage = "English", "Ferry", "Phụ Cấp Đò")
            grdSalary.Columns("FerryAllowance").MinimumWidth = 100
            grdSalary.Columns("FerryAllowance").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("FerryAllowance").ReadOnly = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("MealAllowance").HeaderText = IIf(DefaultLanguage = "English", "Meal", "Phụ cấp cơm")
            grdSalary.Columns("MealAllowance").MinimumWidth = 100
            grdSalary.Columns("MealAllowance").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("MealAllowance").ReadOnly = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("Hardwork").HeaderText = IIf(DefaultLanguage = "English", "Hardwork", "Chuyên cần")
            grdSalary.Columns("Hardwork").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("Hardwork").MinimumWidth = 100
            grdSalary.Columns("Hardwork").ReadOnly = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("PhoneAllowance").HeaderText = IIf(DefaultLanguage = "English", "Phone", "Phụ Cấp Điện Thoại")
            grdSalary.Columns("PhoneAllowance").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("PhoneAllowance").MinimumWidth = 100
            grdSalary.Columns("PhoneAllowance").ReadOnly = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("OtherAllowance").HeaderText = IIf(DefaultLanguage = "English", "Other", "Khác")
            grdSalary.Columns("OtherAllowance").MinimumWidth = 100
            grdSalary.Columns("OtherAllowance").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("OtherAllowance").ReadOnly = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("TotalSalary").HeaderText = IIf(DefaultLanguage = "English", "Total Salary", "Tổng lương")
            grdSalary.Columns("TotalSalary").MinimumWidth = 100
            grdSalary.Columns("TotalSalary").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("TotalSalary").ReadOnly = True

            grdSalary.Columns("NoticedLeaves").HeaderText = IIf(DefaultLanguage = "English", "Noticed Leaves", "Nghỉ có phép")
            grdSalary.Columns("NoticedLeaves").Visible = False



        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub
    Private Sub PermanentGridViewSettings()

        Try
            grdSalary.Columns("ID").HeaderText = IIf(DefaultLanguage = "English", "Employee ID", "ID")
            grdSalary.Columns("ID").MinimumWidth = 100
            grdSalary.Columns("ID").ReadOnly = True
            grdSalary.Columns("ID").Frozen = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("Employee").HeaderText = IIf(DefaultLanguage = "English", "Employee Name", "Tên Nhân Viên")
            grdSalary.Columns("Employee").MinimumWidth = 150
            grdSalary.Columns("Employee").ReadOnly = True
            grdSalary.Columns("Employee").Frozen = True

            grdSalary.Columns("WorkingDays").HeaderText = IIf(DefaultLanguage = "English", "Working Days", "Những ngày đi làm")
            grdSalary.Columns("WorkingDays").MinimumWidth = 100
            grdSalary.Columns("WorkingDays").ReadOnly = True
            grdSalary.Columns("WorkingDays").Frozen = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("JobsPayment").HeaderText = IIf(DefaultLanguage = "English", "Jobs Payment", "Jobs Payment")
            grdSalary.Columns("JobsPayment").MinimumWidth = 100
            grdSalary.Columns("JobsPayment").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("JobsPayment").ReadOnly = True

            grdSalary.Columns("BasicSalary").HeaderText = IIf(DefaultLanguage = "English", "Basic Salary", "Lương căn bản")
            grdSalary.Columns("BasicSalary").MinimumWidth = 100
            grdSalary.Columns("BasicSalary").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("BasicSalary").ReadOnly = True

            grdSalary.Columns("FerryAllowance").HeaderText = IIf(DefaultLanguage = "English", "Ferry", "Phụ Cấp Đò")
            grdSalary.Columns("FerryAllowance").MinimumWidth = 100
            grdSalary.Columns("FerryAllowance").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("FerryAllowance").ReadOnly = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("MealAllowance").HeaderText = IIf(DefaultLanguage = "English", "Meal", "Phụ cấp cơm")
            grdSalary.Columns("MealAllowance").MinimumWidth = 100
            grdSalary.Columns("MealAllowance").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("MealAllowance").ReadOnly = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("Hardwork").HeaderText = IIf(DefaultLanguage = "English", "Hardwork", "Chuyên cần")
            grdSalary.Columns("Hardwork").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("Hardwork").MinimumWidth = 100
            grdSalary.Columns("Hardwork").ReadOnly = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("PhoneAllowance").HeaderText = IIf(DefaultLanguage = "English", "Phone", "Phụ Cấp Điện Thoại")
            grdSalary.Columns("PhoneAllowance").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("PhoneAllowance").MinimumWidth = 100
            grdSalary.Columns("PhoneAllowance").ReadOnly = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("ResponsibilityAllowance").HeaderText = IIf(DefaultLanguage = "English", "Responsibility", "Tiền trách nhiệm")
            grdSalary.Columns("ResponsibilityAllowance").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("ResponsibilityAllowance").MinimumWidth = 100
            grdSalary.Columns("ResponsibilityAllowance").ReadOnly = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("OtherAllowance").HeaderText = IIf(DefaultLanguage = "English", "Other", "Khác")
            grdSalary.Columns("OtherAllowance").MinimumWidth = 100
            grdSalary.Columns("OtherAllowance").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("OtherAllowance").ReadOnly = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("Deduction").HeaderText = IIf(DefaultLanguage = "English", "Deduction", "Khấu Trừ")
            grdSalary.Columns("Deduction").MinimumWidth = 100
            grdSalary.Columns("Deduction").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("Deduction").ReadOnly = True
            grdSalary.Columns("ID").Width = 70

            grdSalary.Columns("TotalSalary").HeaderText = IIf(DefaultLanguage = "English", "Total Salary", "Tổng lương")
            grdSalary.Columns("TotalSalary").MinimumWidth = 100
            grdSalary.Columns("TotalSalary").DefaultCellStyle.Format = "N0"
            grdSalary.Columns("TotalSalary").ReadOnly = True

            grdSalary.Columns("NoticedLeaves").HeaderText = IIf(DefaultLanguage = "English", "Noticed Leaves", "Nghỉ có phép")
            grdSalary.Columns("NoticedLeaves").Visible = False

        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub

    Public Sub GenerateDailyBasesEmployeeSalary()

        Dim cmd As New MySqlCommand
        Dim con As New MySqlConnection(g_connStr)

        Try

            cmd.CommandText += DailyBasisSalaryQuery & "WHERE ID IN (" & strEmpIds & ")"
            Dim tbladpt As New MySqlDataAdapter(cmd.CommandText, con)
            tbladpt.Fill(ds, "tblDailyBasesSalary")

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub CompileDailyBasisSalaryQuery()

        Try
            DailyBasisSalaryQuery = ""
            DailyBasisSalaryQuery = "SELECT ID, Employee, WorkingDays, IFNULL(JobsPayment, 0) AS JobsPayment, IFNULL(FerryAllowance, 0) AS FerryAllowance, IFNULL(MealAllowance, 0) AS MealAllowance, IFNULL(Hardwork, 0) AS Hardwork, IFNULL(OtherAllowance, 0) AS OtherAllowance, IFNULL(PhoneAllowance, 0) AS PhoneAllowance, " & vbCrLf
            DailyBasisSalaryQuery += "(IFNULL(JobsPayment, 0) + IFNULL(FerryAllowance, 0) + IFNULL(MealAllowance, 0) + IFNULL(Hardwork, 0) + IFNULL(OtherAllowance, 0) + IFNULL(PhoneAllowance, 0)) AS TotalSalary, NoticedLeaves FROM " & vbCrLf
            DailyBasisSalaryQuery += "( " & vbCrLf
            DailyBasisSalaryQuery += "SELECT ID, Employee, WorkingDays, JobsPayment, " & vbCrLf
            DailyBasisSalaryQuery += "CASE WHEN WorkingDays<25 THEN 0 ELSE FerryAllowance * WorkingDays END AS FerryAllowance, " & vbCrLf
            DailyBasisSalaryQuery += "CASE WHEN WorkingDays<25 THEN 0 ELSE MealAllowance * WorkingDays END AS MealAllowance, " & vbCrLf
            DailyBasisSalaryQuery += "CASE WHEN WorkingDays<((DATEDIFF('" & Format(dtToDate.Value, "yyyy/MM/dd") & "', '" & Format(dtFromDate.Value, "yyyy/MM/dd") & "') + 1) - 2) THEN 0 ELSE PersistanceandHardworkAllowance END AS Hardwork, " & vbCrLf
            DailyBasisSalaryQuery += "OtherAllowance, PhoneAllowance, NoticedLeaves " & vbCrLf
            DailyBasisSalaryQuery += "FROM " & vbCrLf
            DailyBasisSalaryQuery += "( " & vbCrLf
            DailyBasisSalaryQuery += "SELECT ID, empName AS Employee, " & vbCrLf
            DailyBasisSalaryQuery += "(SELECT COUNT(*) FROM tbllogwork WHERE tbllogwork.Employee = tblemployee.ID AND tbllogwork.TDate >= '" & Format(dtFromDate.Value, "yyyy/MM/dd") & "' AND tbllogwork.TDate <= '" & Format(dtToDate.Value, "yyyy/MM/dd") & "') AS WorkingDays, " & vbCrLf
            DailyBasisSalaryQuery += "(SELECT COUNT(*) FROM tblemployeeleave WHERE Employee = tblemployee.ID AND LeaveDate >= '" & Format(dtFromDate.Value, "yyyy/MM/dd") & "' AND LeaveDate <= '" & Format(dtToDate.Value, "yyyy/MM/dd") & "' AND advNotify = 1) AS NoticedLeaves," & vbCrLf
            DailyBasisSalaryQuery += "(SELECT SUM(TotalAmount) FROM tbllogwork WHERE tbllogwork.Employee = tblemployee.ID AND tbllogwork.TDate >= '" & Format(dtFromDate.Value, "yyyy/MM/dd") & "' AND tbllogwork.TDate <= '" & Format(dtToDate.Value, "yyyy/MM/dd") & "') AS JobsPayment, " & vbCrLf
            DailyBasisSalaryQuery += "FerryAllowance, MealAllowance, PersistanceandHardworkAllowance, OtherAllowance, PhoneAllowance " & vbCrLf
            DailyBasisSalaryQuery += "FROM tblemployee " & vbCrLf
            If cmbEmpType.Text = "Permanent" Or cmbEmpType.Text = "Lương căn bản" Then
                DailyBasisSalaryQuery += " WHERE emptype = 'Permanent' OR emptype = 'Lương căn bản'" & vbCrLf
            ElseIf cmbEmpType.Text = "Daily Basis" Or cmbEmpType.Text = "Lương sản phẩm" Then
                DailyBasisSalaryQuery += " WHERE emptype = 'Daily Basis' OR emptype = 'Lương sản phẩm'" & vbCrLf
            End If

            DailyBasisSalaryQuery += ") AS tblSalary" & vbCrLf
            DailyBasisSalaryQuery += ") AS tblSalaryOuter "

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub CompilePermanentSalaryQuery(Responsibility As Boolean, DeductionMethod As String)

        Try

            PermanentSalaryQuery = ""
            PermanentSalaryQuery += "SELECT ID, Employee, WorkingDays, IFNULL(JobsPayment, 0) AS JobsPayment, " & vbCrLf
            PermanentSalaryQuery += "IFNULL(BasicSalary, 0) AS BasicSalary, IFNULL(FerryAllowance, 0) AS FerryAllowance, IFNULL(MealAllowance,  0) AS MealAllowance, IFNULL(Hardwork, 0) AS Hardwork, IFNULL(PhoneAllowance, 0) AS PhoneAllowance, IFNULL(ResponsibilityAllowance, 0) AS ResponsibilityAllowance, IFNULL(OtherAllowance, 0) AS OtherAllowance, -1*IFNULL(Deduction, 0) AS Deduction, " & vbCrLf
            PermanentSalaryQuery += "(IFNULL(JobsPayment, 0) + IFNULL(BasicSalary, 0) + IFNULL(FerryAllowance, 0) + IFNULL(MealAllowance,  0) + IFNULL(Hardwork, 0) + IFNULL(PhoneAllowance, 0) + IFNULL(ResponsibilityAllowance, 0) + IFNULL(OtherAllowance, 0) - IFNULL(Deduction, 0)) AS TotalSalary, NoticedLeaves FROM " & vbCrLf
            PermanentSalaryQuery += "( " & vbCrLf
            PermanentSalaryQuery += "Select ID, Employee, WorkingDays, NoticedLeaves, " & vbCrLf
            PermanentSalaryQuery += "JobsPayment," & vbCrLf
            PermanentSalaryQuery += "CASE WHEN WorkingDays >= ExpectedWorkDays THEN BasicSalary ELSE BasicSalary - ((ExpectedWorkDays - WorkingDays) * " & IIf(DeductionMethod = "Fixed", "200000", "(BasicSalary/TotalMonthDays)") & " ) END AS BasicSalary," & vbCrLf
            PermanentSalaryQuery += "CASE WHEN WorkingDays<25 THEN 0 ELSE FerryAllowance * WorkingDays END AS FerryAllowance, " & vbCrLf
            PermanentSalaryQuery += "CASE WHEN WorkingDays<25 THEN 0 ELSE MealAllowance * WorkingDays END AS MealAllowance, " & vbCrLf
            PermanentSalaryQuery += "Case WHEN WorkingDays > ExpectedWorkDays THEN (WorkingDays - ExpectedWorkDays)*200000 ELSE 0 END AS Hardwork," & vbCrLf
            PermanentSalaryQuery += "Case WHEN (TotalMonthDays-WorkingDays) = LeavesWN THEN 0 ELSE ((TotalMonthDays-WorkingDays) - LeavesWN) * 17000 END AS Deduction," & vbCrLf
            PermanentSalaryQuery += "PhoneAllowance," & vbCrLf
            PermanentSalaryQuery += IIf(Responsibility = True, "ResponsibilityAllowance", "0") & " As ResponsibilityAllowance," & vbCrLf
            PermanentSalaryQuery += "OtherAllowance" & vbCrLf
            PermanentSalaryQuery += "FROM" & vbCrLf
            PermanentSalaryQuery += "( " & vbCrLf
            PermanentSalaryQuery += "Select ID, empName As Employee, ((DATEDIFF('" & Format(dtToDate.Value, "yyyy/MM/dd") & "', '" & Format(dtFromDate.Value, "yyyy/MM/dd") & "') + 1) - 2) AS ExpectedWorkDays, (DATEDIFF('" & Format(dtToDate.Value, "yyyy/MM/dd") & "', '" & Format(dtFromDate.Value, "yyyy/MM/dd") & "') + 1) AS TotalMonthDays," & vbCrLf
            PermanentSalaryQuery += "(SELECT COUNT(*) FROM tbllogwork WHERE tbllogwork.Employee = tblemployee.ID And tbllogwork.TDate >= '" & Format(dtFromDate.Value, "yyyy/MM/dd") & "' AND tbllogwork.TDate <= '" & Format(dtToDate.Value, "yyyy/MM/dd") & "') AS WorkingDays, " & vbCrLf
            PermanentSalaryQuery += "(SELECT COUNT(*) FROM tblemployeeleave WHERE Employee = tblemployee.ID AND LeaveDate >= '" & Format(dtFromDate.Value, "yyyy/MM/dd") & "' AND LeaveDate <= '" & Format(dtToDate.Value, "yyyy/MM/dd") & "' AND advNotify = 1) AS NoticedLeaves," & vbCrLf
            PermanentSalaryQuery += "(SELECT SUM(TotalAmount) FROM tbllogwork WHERE tbllogwork.Employee = tblemployee.ID And tbllogwork.TDate >= '" & Format(dtFromDate.Value, "yyyy/MM/dd") & "' AND tbllogwork.TDate <= '" & Format(dtToDate.Value, "yyyy/MM/dd") & "') AS JobsPayment," & vbCrLf
            PermanentSalaryQuery += "(SELECT COUNT(*) FROM tblemployeeleave WHERE LeaveDate >= '" & Format(dtFromDate.Value, "yyyy/MM/dd") & "' AND LeaveDate <= '" & Format(dtToDate.Value, "yyyy/MM/dd") & "') AS LeavesWN," & vbCrLf
            PermanentSalaryQuery += "BasicSalary, PhoneAllowance," & vbCrLf
            PermanentSalaryQuery += "FerryAllowance, MealAllowance, ResponsibilityAllowance, PersistanceandHardworkAllowance, OtherAllowance " & vbCrLf
            PermanentSalaryQuery += "FROM tblemployee " & vbCrLf
            If cmbEmpType.Text = "Permanent" Or cmbEmpType.Text = "Lương căn bản" Then
                PermanentSalaryQuery += " WHERE emptype = 'Permanent' OR emptype = 'Lương căn bản'" & vbCrLf
            ElseIf cmbEmpType.Text = "Daily Basis" Or cmbEmpType.Text = "Lương sản phẩm" Then
                PermanentSalaryQuery += " WHERE emptype = 'Daily Basis' OR emptype = 'Lương sản phẩm'" & vbCrLf
            End If
            PermanentSalaryQuery += ") AS tblSalary" & vbCrLf
            PermanentSalaryQuery += ") AS tblSalaryOuter "


        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub GeneratePermanentEmployeesSalary(empList As String)

        Dim cmd As New MySqlCommand
        Dim con As New MySqlConnection(g_connStr)

        Try

            cmd.CommandText = ""
            cmd.CommandText += PermanentSalaryQuery & " WHERE ID IN (" & empList & ")"

            Dim tbladpt As New MySqlDataAdapter(cmd.CommandText, con)
            tbladpt.Fill(ds, "tblPermanentEmployeesSalary")
            tbladpt.Dispose()

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub


    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        If IsNothing(grdSalary.DataSource) OrElse grdSalary.Rows.Count = 0 Then
            If DefaultLanguage = "English" Then
                MessageBox.Show("No data exists to export", "Export")
            Else
                MessageBox.Show("Không có dữ liệu để xuất", "Xuất")
            End If
            Exit Sub
        End If

        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application

        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)

            rowsTotal = grdSalary.RowCount - 1
            colsTotal = grdSalary.Columns.Count - 1


            Dim style As Excel.Style = xlApp.Application.ActiveWorkbook.Styles.Add("NewStyle")
            style.Font.Bold = True
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gold)

            Cursor = Cursors.WaitCursor



            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal - 2 '-2 is to eliminate last two columns in the grid. One for NoticedLeaves and other for detail button
                    .Cells(1, iC + 1).Value = grdSalary.Columns(iC).HeaderText
                    .Cells(1, iC + 1).Style = "NewStyle"
                Next


                For I = 0 To rowsTotal
                    For j = 0 To colsTotal - 2  '-2 is to eliminate last two columns in the grid. One for NoticedLeaves and other for detail button
                        If j > 2 Then
                            '.Cells(I + 2, j + 1).value = String.Format("{0:#,##0.00}", grdSalary.Rows(I).Cells(j).Value)
                            .Cells(I + 2, j + 1).value = Val(grdSalary.Rows(I).Cells(j).Value).ToString("N0")
                        Else
                            .Cells(I + 2, j + 1).value = grdSalary.Rows(I).Cells(j).Value
                        End If

                    Next j
                Next I

                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 10
                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
            Cursor = Cursors.Default
            xlApp.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try

    End Sub

    Private Sub Cell_Click(sender As Object, e As DataGridViewCellEventArgs) Handles grdSalary.CellClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        Try

            If e.ColumnIndex >= 0 AndAlso TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewImageColumn AndAlso
       e.RowIndex >= 0 Then
                SalaryDetail.txtID.Text = senderGrid.Rows(e.RowIndex).Cells("ID").Value
                SalaryDetail.txtName.Text = senderGrid.Rows(e.RowIndex).Cells("Employee").Value
                SalaryDetail.txtType.Text = cmbEmpType.Text
                SalaryDetail.txtFrom.Text = dtFromDate.Value.Date
                SalaryDetail.txtTo.Text = dtToDate.Value.Date
                SalaryDetail.txtMonthDays.Text = DateDiff(DateInterval.Day, dtFromDate.Value, dtToDate.Value) + 1
                SalaryDetail.txtDaysWorked.Text = senderGrid.Rows(e.RowIndex).Cells("WorkingDays").Value
                SalaryDetail.txtNoticedLeaves.Text = senderGrid.Rows(e.RowIndex).Cells("NoticedLeaves").Value
                SalaryDetail.txtUnnoticedLeaves.Text = DateDiff(DateInterval.Day, dtFromDate.Value, dtToDate.Value) + 1 - senderGrid.Rows(e.RowIndex).Cells("WorkingDays").Value - senderGrid.Rows(e.RowIndex).Cells("NoticedLeaves").Value
                SalaryDetail.txtTotalAmount.Text = Val(senderGrid.Rows(e.RowIndex).Cells("TotalSalary").Value).ToString("N0")

                If cmbEmpType.Text = "Permanent" OrElse cmbEmpType.Text = "Lương căn bản" Then
                    FillPermanentEmployeeSalaryDetail(senderGrid.Rows(e.RowIndex).Cells(0).Value)
                    SalaryDetail.DataGridView1.DataSource = ds.Tables("tblPermanentEmployeesSalaryDetail")
                Else
                    FillDailyBasesEmployeeSalaryDetail(senderGrid.Rows(e.RowIndex).Cells(0).Value)
                    SalaryDetail.DataGridView1.DataSource = ds.Tables("tblDailyBasisEmployeesSalaryDetail")
                End If


                SalaryDetail.DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 9.75F, FontStyle.Bold)
                SalaryDetail.DataGridView1.Columns("Title").HeaderText = IIf(DefaultLanguage = "English", "Title", "Chức vụ")
                SalaryDetail.DataGridView1.Columns("Title").Width = 154

                SalaryDetail.DataGridView1.Columns("Value").HeaderText = IIf(DefaultLanguage = "English", "Value", "Giá trị")
                SalaryDetail.DataGridView1.Columns("Value").Width = 150
                SalaryDetail.DataGridView1.Columns("Value").DefaultCellStyle.Format = "N0"


                SalaryDetail.txtTotalAmount.BackColor = Color.Gold
                SalaryDetail.txtTotalAmount.ForeColor = Color.Green
                SalaryDetail.txtTotalAmount.ReadOnly = True


                SalaryDetail.ShowDialog()

            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub FillDailyBasesEmployeeSalaryDetail(empID As Integer)

        Dim cmd As New MySqlCommand
        Dim con As New MySqlConnection(g_connStr)

        Try

            cmd.CommandText = "DROP TABLE IF EXISTS `tmpsalary`;CREATE TABLE tmpsalary "
            cmd.CommandText += DailyBasisSalaryQuery & " WHERE ID = " & empID

            cmd.Connection = con
            If con.State <> ConnectionState.Open Then con.Open()
            cmd.ExecuteNonQuery()

            cmd.CommandText = ""
            cmd.CommandText += "SELECT (SELECT JobName FROM tbljob WHERE tbljob.ID = tbllogwork.JobType) AS Title, " & vbCrLf
            cmd.CommandText += "SUM(TotalAmount) AS Value FROM tbllogwork WHERE Employee = " & empID & " AND tbllogwork.TDate >= '" & Format(dtFromDate.Value, "yyyy/MM/dd") & "' AND tbllogwork.TDate <= '" & Format(dtToDate.Value, "yyyy/MM/dd") & "' GROUP BY JobType " & vbCrLf
            cmd.CommandText += "UNION " & vbCrLf
            cmd.CommandText += "SELECT '" & IIf(DefaultLanguage = "English", "Phone Allowance", "Phụ Cấp Điện Thoại") & "' AS Title, PhoneAllowance AS Value FROM tmpsalary " & vbCrLf
            cmd.CommandText += "UNION " & vbCrLf
            cmd.CommandText += "SELECT '" & IIf(DefaultLanguage = "English", "Ferry Allowance", "Phụ Cấp Đò") & "' AS Title, FerryAllowance AS Value FROM tmpsalary " & vbCrLf
            cmd.CommandText += "UNION " & vbCrLf
            cmd.CommandText += "SELECT '" & IIf(DefaultLanguage = "English", "Meal Allowance", "Phụ cấp cơm") & "' AS Title, MealAllowance AS Value FROM tmpsalary " & vbCrLf
            cmd.CommandText += "UNION " & vbCrLf
            cmd.CommandText += "SELECT '" & IIf(DefaultLanguage = "English", "Hardwork Allowance", "Chuyên cần") & "' AS Title, Hardwork AS Value FROM tmpsalary  " & vbCrLf
            cmd.CommandText += "UNION " & vbCrLf
            cmd.CommandText += "SELECT '" & IIf(DefaultLanguage = "English", "Other Allowance", "Khác") & "' AS Title, OtherAllowance AS Value FROM tmpsalary " & vbCrLf

            Dim tbladpt As New MySqlDataAdapter(cmd.CommandText, con)
            If Not IsNothing(ds.Tables("tblDailyBasisEmployeesSalaryDetail")) Then ds.Tables("tblDailyBasisEmployeesSalaryDetail").Clear()
            tbladpt.Fill(ds, "tblDailyBasisEmployeesSalaryDetail")
            tbladpt.Dispose()

            cmd.CommandText = ""
            cmd.CommandText = "DROP TABLE tmpsalary"
            cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then con.Close()

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub FillPermanentEmployeeSalaryDetail(empID As Integer)

        Dim cmd As New MySqlCommand
        Dim con As New MySqlConnection(g_connStr)

        Try

            cmd.CommandText = ""
            cmd.CommandText = "DROP TABLE IF EXISTS `tmpsalary`;CREATE TABLE tmpsalary "
            cmd.CommandText += PermanentSalaryQuery & " WHERE ID = " & empID


            cmd.Connection = con
            If con.State <> ConnectionState.Open Then con.Open()
            cmd.ExecuteNonQuery()


            cmd.CommandText = ""
            cmd.CommandText += "SELECT '" & IIf(DefaultLanguage = "English", "Basic Salary", "Lương căn bản") & "' AS Title, BasicSalary AS Value FROM tmpsalary " & vbCrLf
            cmd.CommandText += "UNION " & vbCrLf
            cmd.CommandText += "SELECT (SELECT JobName FROM tbljob WHERE tbljob.ID = tbllogwork.JobType) AS Title, " & vbCrLf
            cmd.CommandText += "SUM(TotalAmount) AS Value FROM tbllogwork WHERE Employee = " & empID & " AND tbllogwork.TDate >= '" & Format(dtFromDate.Value, "yyyy/MM/dd") & "' AND tbllogwork.TDate <= '" & Format(dtToDate.Value, "yyyy/MM/dd") & "' GROUP BY JobType " & vbCrLf
            cmd.CommandText += "UNION " & vbCrLf
            cmd.CommandText += "SELECT '" & IIf(DefaultLanguage = "English", "Phone Allowance", "Phụ Cấp Điện Thoại") & "' AS Title, PhoneAllowance AS Value FROM tmpsalary " & vbCrLf
            cmd.CommandText += "UNION " & vbCrLf
            cmd.CommandText += "SELECT '" & IIf(DefaultLanguage = "English", "Ferry Allowance", "Phụ Cấp Đò") & "' AS Title, FerryAllowance AS Value FROM tmpsalary " & vbCrLf
            cmd.CommandText += "UNION " & vbCrLf
            cmd.CommandText += "SELECT '" & IIf(DefaultLanguage = "English", "Meal Allowance", "Phụ cấp cơm") & "' AS Title, MealAllowance AS Value FROM tmpsalary " & vbCrLf
            cmd.CommandText += "UNION " & vbCrLf
            cmd.CommandText += "SELECT '" & IIf(DefaultLanguage = "English", "Responsibility Allowance", "Tiền trách nhiệm") & "' AS Title, ResponsibilityAllowance AS Value FROM tmpsalary " & vbCrLf
            cmd.CommandText += "UNION " & vbCrLf
            cmd.CommandText += "SELECT '" & IIf(DefaultLanguage = "English", "Hardwork Allowance", "Chuyên cần") & "' AS Title, Hardwork AS Value FROM tmpsalary  " & vbCrLf
            cmd.CommandText += "UNION " & vbCrLf
            cmd.CommandText += "SELECT '" & IIf(DefaultLanguage = "English", "Other Allowance", "Khác") & "' AS Title, OtherAllowance AS Value FROM tmpsalary " & vbCrLf
            cmd.CommandText += "UNION " & vbCrLf
            cmd.CommandText += "SELECT '" & IIf(DefaultLanguage = "English", "Deduction", "Khấu Trừ") & "' AS Title, Deduction AS Value FROM tmpsalary " & vbCrLf

            Dim tbladpt As New MySqlDataAdapter(cmd.CommandText, con)
            If Not IsNothing(ds.Tables("tblPermanentEmployeesSalaryDetail")) Then ds.Tables("tblPermanentEmployeesSalaryDetail").Clear()
            tbladpt.Fill(ds, "tblPermanentEmployeesSalaryDetail")
            tbladpt.Dispose()

            cmd.CommandText = ""
            cmd.CommandText = "DROP TABLE tmpsalary"
            cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then con.Close()


        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Function GetResponsibilityVal(empID As Integer) As Boolean

        Try

            For Each dgvRow As DataGridViewRow In grdEmployee.Rows
                If dgvRow.Cells("ID").Value = empID Then
                    Return IIf(IsDBNull(dgvRow.Cells("Responsibilty").Value), False, CBool(dgvRow.Cells("Responsibilty").Value))
                End If

            Next

        Catch ex As Exception
            g_ShowError(ex)
        End Try

        Return False

    End Function

    Private Function GetDeductionVal(empID As Integer) As String

        Try

            For Each dgvRow As DataGridViewRow In grdEmployee.Rows
                If dgvRow.Cells("ID").Value = empID Then
                    Return dgvRow.Cells("Deduction").Value.ToString()
                End If
            Next

        Catch ex As Exception
            g_ShowError(ex)
        End Try

        Return False

    End Function

    Private Sub dtFromDate_TextChanged(sender As Object, e As EventArgs) Handles dtFromDate.TextChanged, dtToDate.TextChanged
        ClearSalaryGrid()
    End Sub

    Private Sub grdSalary_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles grdEmployee.CurrentCellDirtyStateChanged

        Try

            If grdEmployee.IsCurrentCellDirty Then
            ClearSalaryGrid()
        End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    'Dont delete this event as its neccary to manage exception caused by Vietnamese language text in GridView2 Deduction dropdown
    Private Sub grdSalary_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles grdEmployee.DataError

    End Sub

End Class