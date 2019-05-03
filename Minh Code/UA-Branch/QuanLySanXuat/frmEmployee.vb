Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Globalization
Imports System.Resources

Public Class frmEmployee

    Dim curr_rowIndex As Integer
    Private Sub frmEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            For Each c As Control In grdEmployee.Controls
                Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(frmEmployee))
                Dim typeofctrl = c.GetType
                resources.ApplyResources(c, c.Name, New CultureInfo("vi-VN"))
            Next c

            grdEmployee.AutoGenerateColumns = False
            GetAlldata()

            txtEmpName.Tag = ""
            If grdEmployee.Rows.Count > 0 Then

                EditMode(False)
            Else
                EditMode(True)
            End If
            dtEndDate.Enabled = False

            Dim employeeadpt As New DataSet1TableAdapters.tblemployeeTableAdapter
            Dim searchempdt As New DataTable
            searchempdt = employeeadpt.GetDataByActiveREcords()
            cmbsearchEmp.DataSource = searchempdt
            cmbsearchEmp.DisplayMember = "empName"
            cmbsearchEmp.ValueMember = "ID"
            cmbsearchEmp.SelectedIndex = -1

            btnRestoreDefaults_Click(sender, e)

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Public Sub GetAlldata()

        Try
            Dim localcon As New MySqlConnection(g_connStr)
            Dim tbladpt As New DataSet1TableAdapters.tblemployeeTableAdapter
            Dim dt As New DataTable


            If rbShowAll.Checked Then
                dt = tbladpt.GetData()
            ElseIf rbAllFilters.Checked Then

                Dim localda As MySqlDataAdapter
                Dim strCommand As String = ""
                Dim strWhere As String = ""

                strWhere = " WHERE 1=1 "
                If cmbsearchEmp.SelectedIndex <> -1 Then
                    strWhere += " AND tblemployee.ID = " & cmbsearchEmp.SelectedValue
                End If
                If cmbsearchEmpType.SelectedIndex <> -1 Then
                    If cmbsearchEmpType.Text = "Permanent" OrElse cmbsearchEmpType.Text = "Lương căn bản" Then
                        strWhere += " AND (tblemployee.empType = 'Permanent' OR tblemployee.empType = 'Lương căn bản')"
                    Else
                        strWhere += " AND (tblemployee.empType = 'Daily Basis' OR tblemployee.empType = 'Lương sản phẩm')"
                    End If

                End If

                strCommand = "SELECT ID, empName, empType, DOB, BasicSalary, PhoneAllowance, FerryAllowance, MealAllowance, " & vbCrLf
                strCommand += "ResponsibilityAllowance, OtherAllowance, OtherAllowanceReason, PersistanceandHardworkAllowance, HireDate, CreatedDate, " & vbCrLf
                strCommand += "UpdatedDate, CreatedBy, UpdatedBy, isActive, EndDate FROM tblemployee " & strWhere & " ORDER BY ID DESC"

                localda = New MySqlDataAdapter(strCommand, localcon)

                localda.Fill(dt)

                If dt.Rows.Count <= 0 Then
                    If DefaultLanguage = "English" Then
                        MessageBox.Show("No record match this filter criteria", "Filter")
                    Else
                        MessageBox.Show("Không có hồ sơ phù hợp với tiêu chí bộ lọc này", "Bộ lọc")
                    End If
                    dt = tbladpt.GetData()
                End If

            End If

            grdEmployee.DataSource = dt
            If dt.Rows.Count > 0 Then
                'txtEmpName.Text = dt.Rows(0)("empName")
                'grdEmployee.Rows(0).Selected = True
            Else
                EditMode(True)
                txtEmpName.Text = ""

                cmbEmpType.SelectedIndex = 0
                dtpDOH.Value = DateTime.Now
                dtpDOB.Value = DateTime.Now
                chkIsActive.Enabled = True
                ClearAll()
            End If
            Dim autoSourceCollection As AutoCompleteStringCollection = New AutoCompleteStringCollection()

            For Each row As DataRow In dt.Rows
                autoSourceCollection.Add(row("empName"))
            Next
            txtEmpName.AutoCompleteCustomSource = autoSourceCollection

            txtEmpName.Tag = ""

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            txtEmpName.Tag = ""
            EditMode(True)
            txtMealAllownce.Text = Convert.ToDouble(10000).ToString("N0")
            curr_rowIndex = grdEmployee.CurrentRow.Index


            ClearAll()

        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub
    Public Sub ClearAll()

        Try

            txtBasicSalary.Text = "0"
            txtEmpName.Text = ""
            txtFerryAllownce.Text = "0"
            txtHardwork.Text = "0"
            txtMealAllownce.Text = Convert.ToDouble(10000).ToString("N0")
            txtOTherAllownce.Text = 0
            txtOtherAllownceReason.Text = ""
            txtPhoneAllownce.Text = "0"
            txtResponsibilityAllownce.Text = 0

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Private Sub EditMode(IsEditable As Boolean)

        Try

            If IsEditable = True Then
                txtEmpName.ReadOnly = False
                cmbEmpType.Enabled = True
                dtpDOH.Enabled = True
                dtpDOB.Enabled = True
                chkIsActive.Enabled = True
                For Each ctrl As Control In GroupBox1.Controls

                    If TypeOf ctrl Is TextBox Then
                        TryCast(ctrl, TextBox).ReadOnly = False
                    End If

                Next
                btnSave.Visible = True
                btnNew.Visible = False
                btnCancel.Visible = True
                grpSearch.Visible = False

                If txtEmpName.Tag.ToString() = "" Then
                    chkIsActive.Checked = True
                    dtEndDate.Visible = False
                    chkIsActive.Visible = False
                    lblEndDate.Visible = False
                Else
                    dtEndDate.Visible = True
                    chkIsActive.Visible = True
                    lblEndDate.Visible = True
                    If chkIsActive.CheckState = CheckState.Unchecked Then
                        dtEndDate.Enabled = True
                        dtEndDate.Format = DateTimePickerFormat.Short
                    Else
                        dtEndDate.Enabled = False
                        dtEndDate.Format = DateTimePickerFormat.Custom
                        dtEndDate.CustomFormat = " "
                    End If
                End If


            Else

                btnNew.Visible = True
                btnCancel.Visible = False
                btnSave.Visible = False
                txtEmpName.ReadOnly = True
                cmbEmpType.Enabled = False
                dtpDOH.Enabled = False
                dtpDOB.Enabled = False
                chkIsActive.Enabled = False
                For Each ctrl As Control In GroupBox1.Controls
                    If TypeOf ctrl Is TextBox Then
                        TryCast(ctrl, TextBox).ReadOnly = True
                    End If

                Next
                grpSearch.Visible = True

                dtEndDate.Enabled = False
                chkIsActive.Enabled = False
                dtEndDate.Visible = True
                chkIsActive.Visible = True
                lblEndDate.Visible = True

                
                grdEmployee.CurrentCell = grdEmployee(1, IIf(grdEmployee.Rows.Count = curr_rowIndex, curr_rowIndex - 1, curr_rowIndex))
                grdEmployee.Rows(IIf(grdEmployee.Rows.Count = curr_rowIndex, curr_rowIndex - 1, curr_rowIndex)).Selected = True
                


            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtEmpName.Tag = ""
        If grdEmployee.Rows.Count = 0 Then
            Exit Sub
        End If
        EditMode(False)
        Try

            grdEmployee_SelectionChanged(sender, e)
        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub grdEmployee_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdEmployee.CellClick
        Try
            If btnCancel.Visible = True Then
                Exit Sub
            End If


            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
                Exit Sub
            End If
            txtEmpName.Tag = ""
            txtEmpName.Text = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("empName").Value
            cmbEmpType.Text = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("empType").Value
            dtpDOH.Value = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("HireDate").Value
            dtpDOB.Value = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("DOB").Value
            If Not grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("EndDate").Value Is Nothing Then
                dtEndDate.Value = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("EndDate").Value
            End If


            txtBasicSalary.Text = Val(grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("BasicSalary").Value).ToString("N0")
            txtPhoneAllownce.Text = Val(grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("PhoneAllowance").Value).ToString("N0")
            txtFerryAllownce.Text = Val(grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("FerryAllowance").Value).ToString("N0")
            txtMealAllownce.Text = Val(grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("MealAllowance").Value).ToString("N0")
            txtResponsibilityAllownce.Text = Val(grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("ResponsibilityAllowance").Value).ToString("N0")
            txtOTherAllownce.Text = Val(grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("OtherAllowance").Value).ToString("N0")
            'txtOtherAllownceReason.Text = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("OtherAllowanceReason").Value
            txtHardwork.Text = Val(grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("PersistanceandHardworkAllowance").Value).ToString("N0")
            txtOtherAllownceReason.Text = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("OtherAllowanceReason").Value
            chkIsActive.Checked = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("isActive").Value

            CalculateTotalSalary()

            If grdEmployee.Columns(e.ColumnIndex).Name = "Edit" Then

                txtEmpName.Text = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("empName").Value
                txtEmpName.Tag = grdEmployee.Rows(e.RowIndex).Cells("id").Value
                curr_rowIndex = grdEmployee.CurrentRow.Index
                EditMode(True)

            End If
            If grdEmployee.Columns(e.ColumnIndex).Name = "Delete" Then
                Dim dt As New DataTable
                Dim dtadptemplyeeleaves As New DataSet4TableAdapters.tblemployeeleaveTableAdapter
                dt = dtadptemplyeeleaves.GetDataByEmployee(grdEmployee.Rows(e.RowIndex).Cells("id").Value)
                If dt.Rows.Count > 0 Then
                    If DefaultLanguage = "English" Then
                        MessageBox.Show("You cannot delete this employee as he is in use.", "Action Denied")
                    Else
                        MessageBox.Show("Bạn không thể xóa nhân viên này khi anh ta đang sử dụng.", "hành động bị từ chối")
                    End If
                    Exit Sub
                End If

                Dim dtadptlogwork As New DataSet3TableAdapters.tbllogworkTableAdapter
                dt = dtadptlogwork.GetDataBy3(grdEmployee.Rows(e.RowIndex).Cells("id").Value)
                If dt.Rows.Count > 0 Then
                    If DefaultLanguage = "English" Then
                        MessageBox.Show("You cannot delete this employee as he is in use.", "Action Denied")
                    Else
                        MessageBox.Show("Bạn không thể xóa nhân viên này khi anh ta đang sử dụng.", "hành động bị từ chối")
                    End If
                    Exit Sub
                End If
                If DefaultLanguage <> "English" Then
                    Dim msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn xóa không?", "xác nhận xóa", MessageBoxButtons.YesNo)
                    If msgboxres = DialogResult.Yes Then
                        curr_rowIndex = grdEmployee.CurrentRow.Index
                        Dim tbladpt As New DataSet1TableAdapters.tblemployeeTableAdapter
                        tbladpt.DeleteQuery(grdEmployee.Rows(e.RowIndex).Cells("id").Value)
                        GetAlldata()
                    End If
                Else
                    Dim msgboxres = MessageBox.Show(Me, "Are you sure to delete?", "Confirm Delete", MessageBoxButtons.YesNo)
                    If msgboxres = DialogResult.Yes Then
                        curr_rowIndex = grdEmployee.CurrentRow.Index
                        Dim tbladpt As New DataSet1TableAdapters.tblemployeeTableAdapter
                        tbladpt.DeleteQuery(grdEmployee.Rows(e.RowIndex).Cells("id").Value)
                        GetAlldata()
                    End If
                End If


            End If
        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub

    Private Sub AddNewRecord()
        Try
            If txtEmpName.Text.Length = 0 Then

                Exit Sub
            End If

            Dim tbladpt As New DataSet1TableAdapters.tblemployeeTableAdapter
            tbladpt.InsertQuery(txtEmpName.Text, cmbEmpType.Text, dtpDOB.Value, txtBasicSalary.Text, txtPhoneAllownce.Text, txtFerryAllownce.Text, txtMealAllownce.Text, txtResponsibilityAllownce.Text, txtHardwork.Text, txtOTherAllownce.Text, txtOtherAllownceReason.Text, dtpDOH.Value, DateTime.Now, DateTime.Now, usersDt.Rows(0)("ID"), usersDt.Rows(0)("ID"), GetIsActiveValue(chkIsActive.Checked), dtEndDate.Value)
            GetAlldata()
        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub
    Private Function AlreadyExists() As Boolean

        Try


            Dim tbladpt As New DataSet1TableAdapters.tblemployeeTableAdapter
            Dim dt As New DataTable
            dt = tbladpt.GetDataByEmpName(txtEmpName.Text)
            If (dt.Rows.Count > 0) Then
                If txtEmpName.Tag.ToString() = "" Then
                    If (dt.Rows(0)("empName").ToString().ToLower() = txtEmpName.Text.ToLower()) Then
                        Return True
                    End If
                Else
                    If (dt.Rows(0)("empName").ToString().ToLower() = txtEmpName.Text.ToLower() And Not dt.Rows(0)("ID").ToString() = txtEmpName.Tag) Then
                        Return True
                    End If
                End If
                Return False
            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

        Return False

    End Function
    Private Sub UpdateRecord()

        Try
            If txtEmpName.Text.Length = 0 Then

                Exit Sub
            End If
            Dim tbladpt As New DataSet1TableAdapters.tblemployeeTableAdapter
            tbladpt.UpdateQuery(txtEmpName.Text, cmbEmpType.Text, dtpDOB.Value, txtBasicSalary.Text, txtPhoneAllownce.Text, txtFerryAllownce.Text, txtMealAllownce.Text, txtResponsibilityAllownce.Text, txtHardwork.Text, txtOTherAllownce.Text, txtOtherAllownceReason.Text, dtpDOH.Value, DateTime.Now, usersDt.Rows(0)("ID"), GetIsActiveValue(chkIsActive.Checked), dtEndDate.Value, txtEmpName.Tag)

            GetAlldata()
            btnNew.Enabled = True

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try

            If DataValidated() = False Then
                Exit Sub
            End If

            If txtEmpName.Tag.ToString() = "" Then
                If DefaultLanguage <> "English" Then
                    Dim msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn lưu?", "Xác nhận", MessageBoxButtons.YesNo)
                    If msgboxres = DialogResult.Yes Then
                        AddNewRecord()
                    Else
                        txtEmpName.Text = ""
                    End If
                Else
                    Dim msgboxres = MessageBox.Show(Me, "Do you want to save this record?", "Confirm Save", MessageBoxButtons.YesNo)
                    If msgboxres = DialogResult.Yes Then
                        AddNewRecord()
                    Else
                        txtEmpName.Text = ""
                    End If
                End If



            Else
                If DefaultLanguage <> "English" Then
                    Dim msgboxres = MessageBox.Show(Me, "bạn có muốn cập thông tin?", "Xác nhận cập nhật", MessageBoxButtons.YesNo)
                    If msgboxres = DialogResult.Yes Then
                        UpdateRecord()
                    Else
                        txtEmpName.Text = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("empName").Value
                    End If

                    txtEmpName.Tag = ""
                Else
                    Dim msgboxres = MessageBox.Show(Me, "Do you want to update this record?", "Confirm Update", MessageBoxButtons.YesNo)
                    If msgboxres = DialogResult.Yes Then
                        UpdateRecord()
                    Else
                        txtEmpName.Text = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("empName").Value
                    End If

                    txtEmpName.Tag = ""
                End If

            End If
            EditMode(False)

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Function DataValidated() As Boolean

        Try
            If txtEmpName.Text.Length = 0 Then
                If DefaultLanguage <> "English" Then
                    MessageBox.Show(Me, "Xin vui lòng chọn nhân viên.", "Trường bắt buộc")
                    Return False
                Else
                    MessageBox.Show(Me, "Employee Name cannot be empty.", "Required Filed Validation")
                    Return False
                End If
            End If
            If dtEndDate.Value < dtpDOB.Value Then
                If DefaultLanguage <> "English" Then
                    MessageBox.Show(Me, "End Date cannot be less than joing date", "Validation")
                Else
                    MessageBox.Show(Me, "End Date cannot be less than joing date", "Validation")
                End If
                Return False
            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

        Return True

    End Function

    Private Sub grdEmployee_SelectionChanged(sender As Object, e As EventArgs) Handles grdEmployee.SelectionChanged
        Try
            If btnCancel.Visible = True Then
                Exit Sub
            End If
            txtEmpName.Text = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("empName").Value
            cmbEmpType.Text = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("empType").Value
            dtpDOH.Value = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("HireDate").Value
            dtpDOB.Value = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("DOB").Value
            If grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("EndDate").Value <> Nothing Then
                dtEndDate.Value = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("EndDate").Value
            End If
            txtBasicSalary.Text = Val(grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("BasicSalary").Value).ToString("N0")
            txtPhoneAllownce.Text = Val(grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("PhoneAllowance").Value).ToString("N0")
            txtFerryAllownce.Text = Val(grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("FerryAllowance").Value).ToString("N0")
            txtMealAllownce.Text = Val(grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("MealAllowance").Value).ToString("N0")
            txtResponsibilityAllownce.Text = Val(grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("ResponsibilityAllowance").Value).ToString("N0")
            txtOTherAllownce.Text = Val(grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("OtherAllowance").Value).ToString("N0")
            txtHardwork.Text = Val(grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("PersistanceandHardworkAllowance").Value).ToString("N0")
            chkIsActive.Checked = grdEmployee.Rows(grdEmployee.CurrentCell.RowIndex).Cells("isActive").Value
            CalculateTotalSalary()


        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub

    Public Sub CalculateTotalSalary()
        Try
            Dim totalval As Double = ValNewF(txtBasicSalary.Text) + ValNewF(txtPhoneAllownce.Text) + (ValNewF(txtFerryAllownce.Text)*30) + (ValNewF(txtMealAllownce.Text)*30) + ValNewF(txtResponsibilityAllownce.Text) + ValNewF(txtOTherAllownce.Text) + ValNewF(txtHardwork.Text)
            lblTotalSalary.Text = totalval.ToString("N0")
        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub

    Private Sub txtBasicSalary_TextChanged(sender As Object, e As EventArgs) Handles txtBasicSalary.TextChanged, txtPhoneAllownce.TextChanged, txtFerryAllownce.TextChanged, txtMealAllownce.TextChanged, txtResponsibilityAllownce.TextChanged, txtOTherAllownce.TextChanged, txtHardwork.TextChanged
        Try

            If TryCast(sender, TextBox).Text.Length > 0 Then
                TryCast(sender, TextBox).Text = Convert.ToDouble(TryCast(sender, TextBox).Text).ToString("N0")
                Dim txtbox = TryCast(sender, TextBox)
                txtbox.SelectionStart = txtbox.Text.Length
                txtbox.SelectionLength = 0
                CalculateTotalSalary()
            Else
                TryCast(sender, TextBox).Text = 0
            End If


        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub txtMealAllownce_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMealAllownce.KeyPress, txtBasicSalary.KeyPress, txtPhoneAllownce.KeyPress, txtFerryAllownce.KeyPress, txtResponsibilityAllownce.KeyPress, txtOTherAllownce.KeyPress, txtHardwork.KeyPress

        Try
            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not e.KeyChar = "," Then
                e.Handled = True
            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub

    Private Sub cmbEmpType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpType.SelectedIndexChanged

        Try

            If cmbEmpType.Text = "Daily Basis" OrElse cmbEmpType.Text = "Lương sản phẩm" Then
                txtBasicSalary.ReadOnly = True
                txtResponsibilityAllownce.ReadOnly = True
                txtBasicSalary.Text = 0
                txtResponsibilityAllownce.Text = 0
            Else
                If btnCancel.Visible = True Then
                    txtBasicSalary.ReadOnly = False
                    txtResponsibilityAllownce.ReadOnly = False
                Else
                    txtBasicSalary.ReadOnly = True
                    txtResponsibilityAllownce.ReadOnly = True
                End If


            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub cmbEmpType_Leave(sender As Object, e As EventArgs) Handles cmbEmpType.Leave
        Dim index As Integer = cmbEmpType.FindString(cmbEmpType.Text)

        Try

            If index < 0 Then
                cmbEmpType.SelectedIndex = 0
                cmbEmpType.Focus()
                Return
            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Private Sub cmbFishType_DropDown(sender As Object, e As EventArgs) Handles cmbEmpType.DropDown
        Dim cbo As ComboBox = CType(sender, ComboBox)
        AddHandler cbo.PreviewKeyDown, AddressOf comboBox_PreviewKeyDown
    End Sub
    Private Sub comboBox_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        Dim cbo As ComboBox = CType(sender, ComboBox)
        RemoveHandler cbo.PreviewKeyDown, AddressOf comboBox_PreviewKeyDown
        If cbo.DroppedDown Then cbo.Focus()
    End Sub

    Private Sub chkIsActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsActive.CheckedChanged
        Try


            If chkIsActive.CheckState = CheckState.Unchecked Then
                If btnNew.Visible = True Then
                    dtEndDate.Enabled = False
                Else
                    dtEndDate.Enabled = True
                End If

                dtEndDate.Format = DateTimePickerFormat.Short
            Else
                dtEndDate.Enabled = False
                dtEndDate.Format = DateTimePickerFormat.Custom
                dtEndDate.CustomFormat = " "
            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub btnApplyFilters_Click(sender As Object, e As EventArgs) Handles btnApplyFilters.Click
        GetAlldata()
    End Sub

    Private Sub btnRestoreDefaults_Click(sender As Object, e As EventArgs) Handles btnRestoreDefaults.Click

        Try

            rbShowAll.Checked = True
            cmbsearchEmp.SelectedIndex = -1
            cmbsearchEmpType.SelectedIndex = -1


            cmbsearchEmp.Enabled = False
            cmbsearchEmpType.Enabled = False

            btnApplyFilters.Enabled = False
            GetAlldata()

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub rbAllFilters_Click(sender As Object, e As EventArgs) Handles rbAllFilters.Click, rbShowAll.Click

        Try

            If sender.Name = "rbShowAll" Then
                cmbsearchEmp.SelectedIndex = -1
                cmbsearchEmpType.SelectedIndex = -1
                cmbsearchEmp.Enabled = False
                cmbsearchEmpType.Enabled = False
                btnApplyFilters.Enabled = False
            Else
                cmbsearchEmp.Enabled = True
                cmbsearchEmpType.Enabled = True
                btnApplyFilters.Enabled = True
            End If
            GetAlldata()

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub


End Class