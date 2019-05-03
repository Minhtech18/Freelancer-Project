Imports MySql.Data.MySqlClient
Public Class frmLogWork

    Dim curr_rowIndex As Integer
    Dim FromLoad As Boolean
    Private Sub frmLogWork_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim fishdt As New DataTable
            Dim searchFishdt As New DataTable
            Dim fishdtadpt As New DataSet1TableAdapters.tblfishTableAdapter
            fishdt = fishdtadpt.GetDataByActiveRecords()
            searchFishdt = fishdtadpt.GetDataByActiveRecords()
            cmbFishType.DataSource = fishdt
            cmbFishType.DisplayMember = "FishName"
            cmbFishType.ValueMember = "ID"

            cmbsearchFish.DataSource = searchFishdt
            cmbsearchFish.DisplayMember = "FishName"
            cmbsearchFish.ValueMember = "ID"
            cmbsearchFish.SelectedIndex = -1


            Dim jobdt As New DataTable
            Dim searchJobdt As New DataTable
            Dim jobdtadpt As New DataSet1TableAdapters.tbljobTableAdapter
            jobdt = jobdtadpt.GetDataByActiveREcords()
            searchJobdt = jobdtadpt.GetDataByActiveREcords()
            cmbJobType.DataSource = jobdt
            cmbJobType.DisplayMember = "JobName"
            cmbJobType.ValueMember = "ID"

            cmbsearchJob.DataSource = searchJobdt
            cmbsearchJob.DisplayMember = "JobName"
            cmbsearchJob.ValueMember = "ID"
            cmbsearchJob.SelectedIndex = -1

            Dim employeedt As New DataTable
            Dim searchempdt As New DataTable
            Dim KCSdt As New DataTable
            Dim employeeadpt As New DataSet1TableAdapters.tblemployeeTableAdapter
            employeedt = employeeadpt.GetDataByActiveREcords()
            searchempdt = employeeadpt.GetDataByActiveREcords()
            KCSdt = employeeadpt.GetDataByActiveREcords()
            cmbEmployee.DataSource = employeedt
            cmbEmployee.DisplayMember = "empName"
            cmbEmployee.ValueMember = "ID"


            cmbsearchEmp.DataSource = searchempdt
            cmbsearchEmp.DisplayMember = "empName"
            cmbsearchEmp.ValueMember = "ID"
            cmbsearchEmp.SelectedIndex = -1


            cmbKCS.DataSource = KCSdt
            cmbKCS.DisplayMember = "empName"
            cmbKCS.ValueMember = "ID"
            grdLogWork.AutoGenerateColumns = False

            rbAllFilters_Click(rbCurrentMonth, New EventArgs)

            dtFromDate.Value = Now.Year & "-" & Now.Month & "-01"
            dtToDate.Value = Now.Year & "-" & Now.Month & "-" & Date.DaysInMonth(Now.Year, Now.Month)

            FromLoad = True 'We need to switch the form state to new mode when no record exists while loading. But if in case of search no record is found then message should appear and default view should be rendered
            GetAlldata()
            FromLoad = False

            txtQuantity.Tag = ""
            If grdLogWork.Rows.Count > 0 Then

                EditMode(False)
            Else
                EditMode(True)
            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Public Sub GetAlldata()

        Try


            Dim localcon As New MySqlConnection(g_connStr)
            Dim tbladpt As New DataSet4TableAdapters.tblLogWorkAllDataTableAdapter
            Dim dt As New DataTable
            If rbCurrentMonth.Checked Then
                dt = tbladpt.GetDataByDateRange(dtFromDate.Value, dtToDate.Value)
            ElseIf rbShowAll.Checked Then
                dt = tbladpt.GetData()
            ElseIf rbAllFilters.Checked Then

                Dim localda As MySqlDataAdapter
                Dim strCommand As String = ""
                Dim strWhere As String = ""



                strWhere = " WHERE 1=1 "
                If cmbsearchEmp.SelectedIndex <> -1 Then
                    strWhere += " AND tbllogwork.Employee = " & cmbsearchEmp.SelectedValue
                End If
                If cmbsearchFish.SelectedIndex <> -1 Then
                    strWhere += " AND tbllogwork.FishType = " & cmbsearchFish.SelectedValue
                End If

                If cmbsearchJob.SelectedIndex <> -1 Then
                    strWhere += " AND tbllogwork.JobType = " & cmbsearchJob.SelectedValue
                End If

                strWhere += " AND tbllogwork.TDate >= '" & Format(dtFromDate.Value, "yyyy/MM/dd") & "' AND tbllogwork.TDate <= '" & Format(dtToDate.Value, "yyyy/MM/dd") & "' "

                strCommand = "SELECT tbllogwork.ID, tbllogwork.TDate, tbllogwork.Employee, tbllogwork.FishType, " & vbCrLf
                strCommand += "tbllogwork.JobType, tbllogwork.Quantity, tbllogwork.TotalWeight, tbllogwork.FishPartition, " & vbCrLf
                strCommand += "tbllogwork.RatePerPack, tbllogwork.TotalAmount, " & vbCrLf
                strCommand += "tbllogwork.Note, tblemployee.empName, tblfish.FishName, tbljob.JobName, tbllogwork.KCS AS KCSID, " & vbCrLf
                strCommand += "tblKCS.empName AS KCS " & vbCrLf
                strCommand += "FROM tbllogwork INNER JOIN " & vbCrLf
                strCommand += "tblemployee ON tbllogwork.Employee = tblemployee.ID INNER JOIN " & vbCrLf
                strCommand += "tblfish ON tbllogwork.FishType = tblfish.id INNER JOIN " & vbCrLf
                strCommand += "tbljob ON tbllogwork.JobType = tbljob.ID LEFT OUTER JOIN " & vbCrLf
                strCommand += "tblemployee tblKCS ON tbllogwork.KCS = tblKCS.ID " & strWhere & vbCrLf
                strCommand += "ORDER BY tbllogwork.ID DESC"

                localda = New MySqlDataAdapter(strCommand, localcon)

                localda.Fill(dt)
            End If
            grdLogWork.DataSource = dt
            If grdLogWork.Rows.Count > 0 Then

                EditMode(False)
            ElseIf FromLoad = True Then
                EditMode(True)
                ClearAll()
            Else
                If DefaultLanguage = "English" Then
                    MessageBox.Show(Me, "No record found for the selected filters", "No Record Found")
                Else
                    MessageBox.Show(Me, "Không tìm thấy bản ghi cho các bộ lọc đã chọn", "Không tìm thấy hồ sơ")
                End If
                rbCurrentMonth.Checked = True
                rbAllFilters_Click(rbCurrentMonth, New EventArgs)
            End If
            txtQuantity.Tag = ""

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Public Sub ClearAll()

        Try

            txtQuantity.Text = ""
            txtRateperPack.Text = ""
            txtRemaining.Text = ""
            txtTotalAmount.Text = ""
            txtTotalWeight.Text = ""
            txtFishPartition.Text = ""
            cmbEmployee.SelectedValue = -1
            cmbKCS.SelectedValue = -1
            cmbFishType.SelectedIndex = -1
            cmbJobType.SelectedIndex = -1
            grdPartitionFish.Rows.Clear()
            DateTimePicker1.Value = DateTime.Now
            txtNote.Text = ""

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try

            txtQuantity.Tag = ""
            EditMode(True)
            curr_rowIndex = grdLogWork.CurrentRow.Index
            ClearAll()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditMode(IsEditable As Boolean)

        Try


            If IsEditable = True Then
                txtQuantity.ReadOnly = False
                txtRateperPack.ReadOnly = True
                txtRemaining.ReadOnly = True
                txtTotalAmount.ReadOnly = True
                txtTotalWeight.ReadOnly = True
                ' txtFishPartition.ReadOnly = False
                txtNote.ReadOnly = False
                cmbFishType.Enabled = True
                cmbEmployee.Enabled = True
                cmbKCS.Enabled = True
                cmbJobType.Enabled = True
                btnSave.Visible = True
                btnNew.Visible = False
                btnCancel.Visible = True
                DateTimePicker1.Enabled = True
                txtFishPartitionNew.ReadOnly = False
                btnAdd.Visible = True
                grpSearch.Visible = False
                txtRemaining.Visible = True
                lblRemaining.Visible = True
            Else

                btnNew.Visible = True
                btnCancel.Visible = False
                btnSave.Visible = False
                txtQuantity.ReadOnly = True
                txtRateperPack.ReadOnly = True
                txtRemaining.ReadOnly = True
                txtTotalAmount.ReadOnly = True
                txtTotalWeight.ReadOnly = True
                '  txtFishPartition.ReadOnly = True
                txtNote.ReadOnly = True
                cmbFishType.Enabled = False
                cmbEmployee.Enabled = False
                cmbKCS.Enabled = False
                cmbJobType.Enabled = False
                DateTimePicker1.Enabled = False
                txtFishPartitionNew.ReadOnly = True
                btnAdd.Visible = False
                grpSearch.Visible = True
                txtRemaining.Visible = False
                lblRemaining.Visible = False

                grdLogWork.CurrentCell = grdLogWork(1, IIf(grdLogWork.Rows.Count = curr_rowIndex, curr_rowIndex - 1, curr_rowIndex))
                grdLogWork.Rows(IIf(grdLogWork.Rows.Count = curr_rowIndex, curr_rowIndex - 1, curr_rowIndex)).Selected = True
            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Try


            txtQuantity.Tag = ""
            If grdLogWork.Rows.Count = 0 Then
                Exit Sub
            End If
            EditMode(False)


            grdLogWork_SelectionChanged(sender, e)
        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub grdLogWork_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdLogWork.CellClick
        Try

            If btnCancel.Visible = True Then
                Exit Sub
            End If

            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
                Exit Sub
            End If
            txtQuantity.Text = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("Quantity").Value
            txtRateperPack.Text = Val(grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("Rateperpack").Value).ToString("N0")
            txtTotalAmount.Text = Val(grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("TotalAmount").Value).ToString("N0")
            txtTotalWeight.Text = Val(grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("TotalWeight").Value).ToString("N2")
            txtFishPartition.Text = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("FishPartition").Value
            txtNote.Text = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("Note").Value
            cmbEmployee.SelectedValue = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("Employee").Value
            cmbKCS.SelectedValue = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("KCSID").Value
            cmbFishType.SelectedValue = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("FishType").Value
            cmbJobType.SelectedValue = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("JobType").Value
            DateTimePicker1.Value = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("TDate").Value
            GetFishPartitionbyLogWork(grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("ID").Value)
            If grdLogWork.Columns(e.ColumnIndex).Name = "Edit" Then
                txtQuantity.Tag = grdLogWork.Rows(e.RowIndex).Cells("ID").Value
                curr_rowIndex = grdLogWork.CurrentRow.Index
                EditMode(True)
                If cmbJobType.Text = "PHOI_CA" Then
                    GetTotalQtybyFishType()
                End If
            End If
            If grdLogWork.Columns(e.ColumnIndex).Name = "Delete" Then
                Dim msgboxres
                If DefaultLanguage = "English" Then
                    msgboxres = MessageBox.Show(Me, "Are you sure to delete?", "Confirm Delete", MessageBoxButtons.YesNo)
                Else
                    msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn xóa không?", "xác nhận xóa", MessageBoxButtons.YesNo)
                End If
                If msgboxres = DialogResult.Yes Then
                    curr_rowIndex = grdLogWork.CurrentRow.Index
                    If isAlowedtoEditorDelete("tbllogwork", grdLogWork.Rows(e.RowIndex).Cells("ID").Value) = True Then
                        Dim tbladpt As New DataSet3TableAdapters.tbllogworkTableAdapter
                        tbladpt.DeleteQuery(grdLogWork.Rows(e.RowIndex).Cells("ID").Value)
                        GetAlldata()
                    Else
                        If DefaultLanguage = "English" Then
                            MessageBox.Show("You are not allowed to perform any action for the past record.")
                        Else
                            MessageBox.Show("Bạn không được phép thực hiện bất kỳ hành động nào cho hồ sơ trong quá khứ.")
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub
    Dim lastinsertedid As Integer = 0
    Private Sub AddNewRecord()
        Try
            Dim qry As String = "Insert into tbllogwork (TDate, Employee, FishType, JobType, KCS, Quantity, TotalWeight, FishPartition, RatePerPack, TotalAmount, Note, CreatedDate, UpdatedDate, CreatedBy, UpdatedBy) Values ('" & Format(DateTimePicker1.Value, "yyyy/MM/dd") & "'," & cmbEmployee.SelectedValue & "," & cmbFishType.SelectedValue & "," & cmbJobType.SelectedValue & "," & IIf(cmbKCS.SelectedValue = Nothing, "NULL", cmbKCS.SelectedValue) & ", " & GetFloatValue(txtQuantity.Text) & "," & txtTotalWeight.Text.Replace(",", "") & "," & IIf(txtFishPartition.Text = "", 0, txtFishPartition.Text.Replace(",", "")) & "," & txtRateperPack.Text.Replace(",", "") & "," & txtTotalAmount.Text.Replace(",", "").Replace(".", "") & ",'" & txtNote.Text + "','" & DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") & "','" & DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") & "'," & usersDt.Rows(0)("ID") & "," & usersDt.Rows(0)("ID") & ")"
            Dim con As New MySql.Data.MySqlClient.MySqlConnection(g_connStr)
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand(qry, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            lastinsertedid = cmd.LastInsertedId

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub UpdateRecord()

        Try

            Dim tbladpt As New DataSet3TableAdapters.tbllogworkTableAdapter
            tbladpt.UpdateQuery(DateTimePicker1.Value, cmbEmployee.SelectedValue, cmbFishType.SelectedValue, cmbJobType.SelectedValue, IIf(cmbKCS.SelectedValue = Nothing, "NULL", cmbKCS.SelectedValue), GetFloatValue(txtQuantity.Text), txtTotalWeight.Text, txtFishPartition.Text, txtRateperPack.Text, txtTotalAmount.Text, txtNote.Text, DateTime.Now, usersDt.Rows(0)("ID"), txtQuantity.Tag)
            'GetAlldata()
            btnNew.Enabled = True

        Catch ex As Exception

        End Try

    End Sub
    Public Function AddFishPartitionRecord(ByVal logworkref As Integer) As Boolean
        Try


            Dim dadpt As New DataSet5TableAdapters.tblfishpartitionTableAdapter
            dadpt.DeleteQuery(logworkref)
            Dim dgrowscount = grdPartitionFish.Rows.Count
            For Each dgvRow As DataGridViewRow In grdPartitionFish.Rows
                dadpt.InsertQuery(logworkref, Val(dgvRow.Cells("fishpart").Value))
            Next
            Return True
        Catch ex As Exception
            g_ShowError(ex)
        Finally

        End Try
        Return False
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try

            If DataValidated() = False Then
                Exit Sub
            End If

            Dim msgboxres

            If txtQuantity.Tag.ToString() = "" Then

                If DefaultLanguage = "English" Then
                    msgboxres = MessageBox.Show(Me, "Do you want to save this record?", "Confirm Save", MessageBoxButtons.YesNo)
                Else
                    msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn lưu?", "Xác nhận", MessageBoxButtons.YesNo)
                End If
                If msgboxres = DialogResult.Yes Then
                    AddNewRecord()
                    If cmbJobType.Text = "PHOI_CA" Then
                        AddFishPartitionRecord(lastinsertedid)

                    End If

                    GetAlldata()
                    txtRemaining.Text = ""
                Else
                    txtQuantity.Text = ""

                End If


            Else
                If isAlowedtoEditorDelete("tbllogwork", txtQuantity.Tag) = True Then

                    If DefaultLanguage = "English" Then
                        msgboxres = MessageBox.Show(Me, "Do you want to update this record?", "Confirm Update", MessageBoxButtons.YesNo)
                    Else
                        msgboxres = MessageBox.Show(Me, "bạn có muốn cập thông tin?", "Xác nhận cập nhật", MessageBoxButtons.YesNo)
                    End If
                    If msgboxres = DialogResult.Yes Then
                        UpdateRecord()
                        AddFishPartitionRecord(txtQuantity.Tag)
                        GetAlldata()
                        txtRemaining.Text = ""
                    Else



                    End If

                    txtQuantity.Tag = ""
                Else
                    If DefaultLanguage = "English" Then
                        MessageBox.Show("You are not allowed to perform any action for the past record.")
                    Else
                        MessageBox.Show("Bạn không được phép thực hiện bất kỳ hành động nào cho hồ sơ trong quá khứ.")
                    End If
                End If

            End If

            EditMode(False)

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Function DataValidated() As Boolean

        Try

            If cmbEmployee.SelectedIndex = -1 Then
                If DefaultLanguage = "English" Then
                    MessageBox.Show(Me, "Employee cannot be empty.", "Required Filed Validation")
                Else
                    MessageBox.Show(Me, "Xin vui lòng chọn nhân viên", "Trường bắt buộc")
                End If
                Return False
            End If
            If cmbFishType.SelectedIndex = -1 Then
                If DefaultLanguage = "English" Then
                    MessageBox.Show(Me, "Fish Type cannot be empty.", "Required Filed Validation")
                Else
                    MessageBox.Show(Me, "Xin vui lòng chọn loại cá", "Trường bắt buộc")
                End If
                Return False
            End If
            If cmbJobType.SelectedIndex = -1 Then
                If DefaultLanguage = "English" Then
                    MessageBox.Show(Me, "Job Name cannot be empty.", "Required Filed Validation")
                Else
                    MessageBox.Show(Me, "Xin vui lòng chọn loại công việc", "Trường bắt buộc")
                End If
                Return False
            End If

            If txtQuantity.Text.Length = 0 Then
                If DefaultLanguage = "English" Then
                    MessageBox.Show(Me, "Quantity cannot be empty.", "Required Filed Validation")
                Else
                    MessageBox.Show(Me, "Xin vui lòng nhập số lượng", "Trường bắt buộc")
                End If
                Return False
            End If
            If txtRateperPack.Text.Length = 0 Then
                If DefaultLanguage = "English" Then
                    MessageBox.Show(Me, "Rate Per Pack cannot be empty.", "Required Filed Validation")
                Else
                    MessageBox.Show(Me, "Xin vui lòng nhập giá", "Trường bắt buộc")
                End If
                Return False
            End If
            If txtTotalAmount.Text.Length = 0 Then
                If DefaultLanguage = "English" Then
                    MessageBox.Show(Me, "Total Amount cannot be empty.", "Required Filed Validation")
                Else
                    MessageBox.Show(Me, "Tổng tiền chưa được tính", "Trường bắt buộc")
                End If
                Return False
            End If
            If txtTotalWeight.Text.Length = 0 Then
                If DefaultLanguage = "English" Then
                    MessageBox.Show(Me, "Total Weight cannot be empty.", "Required Filed Validation")
                Else
                    MessageBox.Show(Me, "Tổng lượng chưa được tính.", "Trường bắt buộc")
                End If
                Return False
            End If


            If cmbJobType.Text = "PHOI_CA" Then

                If txtRemaining.Text.Contains("-") Then
                    If DefaultLanguage = "English" Then
                        MessageBox.Show("Remaining fish cannot be negative.")
                    Else
                        MessageBox.Show("Cá còn lại không thể âm tính.")
                    End If
                    Return False
                End If
            End If

            If CheckStandardJobTypes() = True AndAlso Val(txtTotalAmount.Text) <= 0 Then
                If DefaultLanguage = "English" Then
                    MessageBox.Show("Total Amount cannot be negative or zero.")
                Else
                    MessageBox.Show("Tổng số tiền không thể âm hoặc bằng không.")
                End If
                Return False
            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

        Return True

    End Function

    Private Sub grdLogWork_SelectionChanged(sender As Object, e As EventArgs) Handles grdLogWork.SelectionChanged
        Try
            If btnCancel.Visible = True Then
                Exit Sub
            End If
            txtQuantity.Text = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("Quantity").Value
            cmbEmployee.SelectedValue = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("Employee").Value
            cmbKCS.SelectedValue = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("KCSID").Value
            cmbFishType.SelectedValue = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("FishType").Value
            cmbJobType.SelectedValue = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("JobType").Value
            DateTimePicker1.Value = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("TDate").Value
            txtRateperPack.Text = Val(grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("Rateperpack").Value).ToString("N0")
            txtTotalAmount.Text = Val(grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("TotalAmount").Value).ToString("N0")
            txtTotalWeight.Text = Val(grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("TotalWeight").Value).ToString("N2")
            txtNote.Text = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("Note").Value
            txtFishPartition.Text = grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("FishPartition").Value
            GetFishPartitionbyLogWork(grdLogWork.Rows(grdLogWork.CurrentCell.RowIndex).Cells("ID").Value)
        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub
    Public Sub GetFishPartitionbyLogWork(ByVal LogWorkRef As Integer)

        Try


            grdPartitionFish.Rows.Clear()
            Dim dt As New DataTable
            Dim dtadpt As New DataSet5TableAdapters.tblfishpartitionTableAdapter
            dt = dtadpt.GetDataByLogworkID(LogWorkRef)
            For i = 0 To dt.Rows.Count - 1
                grdPartitionFish.Rows.Add()
                grdPartitionFish.Rows(grdPartitionFish.Rows.Count - 1).Cells("fishpart").Value = dt.Rows(i)("PartitionValue")
            Next
            CalcualteFishPartitionaverage()

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Public Sub CalcualteFishPartitionaverage()

        Try


            Dim totfishpart As Double = 0
            For Each dgvrow As DataGridViewRow In grdPartitionFish.Rows
                totfishpart += Val(dgvrow.Cells(0).Value)
            Next
            txtFishPartition.Text = totfishpart.ToString("0.00")

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If btnSave.Visible = False Then
                Exit Sub
            End If
            If txtFishPartitionNew.Text.Length = 0 Then
                Exit Sub
            End If
            grdPartitionFish.Rows.Add()
            grdPartitionFish.Rows(grdPartitionFish.Rows.Count - 1).Cells("fishpart").Value = txtFishPartitionNew.Text
            CalcualteFishPartitionaverage()
            txtFishPartitionNew.Text = ""
            CalculateTotalWeight()
            GetTotalQtybyFishType()
        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub

    Private Sub grdPartitionFish_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPartitionFish.CellClick
        Try
            If btnCancel.Visible = False Then
                Exit Sub
            End If
            If e.ColumnIndex = 1 Then
                grdPartitionFish.Rows.RemoveAt(e.RowIndex)
                CalcualteFishPartitionaverage()
                CalculateTotalWeight()
                GetTotalQtybyFishType()
            End If
        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub

    Private Sub txtTotalAmount_TextChanged(sender As Object, e As EventArgs) Handles txtTotalAmount.Leave
        txtTotalAmount.Text = Val(txtTotalAmount.Text).ToString("N0")
    End Sub
    Public Sub GetRatePerPAckbyJobTypeandFishType()
        Try
            If cmbFishType.ValueMember <> "" AndAlso cmbFishType.SelectedIndex > -1 AndAlso cmbJobType.ValueMember <> "" AndAlso cmbJobType.SelectedIndex > -1 Then
                Dim tbladpt As New DataSet2TableAdapters.tbljobratesTableAdapter
                Dim dt As New DataTable
                dt = tbladpt.GetDataByFishandJobForRate(cmbFishType.SelectedValue, cmbJobType.SelectedValue)
                If dt.Rows.Count > 0 Then
                    txtRateperPack.Text = Val(dt.Rows(0)("Rate")).ToString("N0")
                    txtRateperPack.Tag = dt.Rows(0)("PackingStyle")
                    lblPackingStyle.Text = dt.Rows(0)("PackingStyle")
                    lblMUnit.Text = dt.Rows(0)("PUnit")
                Else
                    txtRateperPack.Text = "0.00"
                    txtRateperPack.Tag = "0"
                    lblPackingStyle.Text = "0"
                    lblMUnit.Text = ""
                End If
            End If
        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub
    Public Sub CalculateTotalWeight()
        Try

            txtTotalWeight.Text = Math.Round(((ValNewF(txtQuantity.Text) * txtRateperPack.Tag) + ValNewF(ValNewF(iif(txtFishPartition.Text="", 0, txtFishPartition.Text)))), 2)
            txtTotalAmount.Text = (txtTotalWeight.Text * ValNewF(txtRateperPack.Text)).ToString("N0")

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub cmbFishType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFishType.SelectedIndexChanged, cmbJobType.SelectedIndexChanged

        Try


            
                If cmbJobType.Text = "PHOI_CA" Then
                    ShowHideFishPartitionSection(True)
                Else
                    ShowHideFishPartitionSection(False)
                End If
            


            GetRatePerPAckbyJobTypeandFishType()
            CalculateTotalWeight()
            If txtQuantity.Text = "" Then
                txtRemaining.Text = ""
            Else
                GetTotalQtybyFishType()
            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub ShowHideFishPartitionSection(Visibility As Boolean)
        lblFishPartition.Visible = Visibility
        txtFishPartitionNew.Visible = Visibility
        btnAdd.Visible = Visibility
        grdPartitionFish.DataSource = Nothing
        grdPartitionFish.Visible = Visibility
        lblTotalPartition.Visible = Visibility
        txtFishPartition.Visible = Visibility
    End Sub

    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        Try
            CalculateTotalWeight()
        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub

    Private Sub txtQuantity_KeyDown(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        Try


            If CheckStandardJobTypes() = True AndAlso e.KeyChar = "-" Then
                If DefaultLanguage = "English" Then
                    MessageBox.Show("Quantity cannot be negative for the job type: " & cmbJobType.Text)
                Else
                    MessageBox.Show("Số lượng không thể âm cho loại công việc: " & cmbJobType.Text)
                End If
                e.Handled = True
                Exit Sub
            End If
            If e.KeyChar <> "-" AndAlso Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not e.KeyChar = "," Then
                e.Handled = True
            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Function CheckStandardJobTypes() As Boolean
        Try


            If cmbJobType.Text = "LAM_CA" OrElse cmbJobType.Text = "PHOI_CA" OrElse cmbJobType.Text = "GO_VY" OrElse cmbJobType.Text = "LAM_SACH" OrElse cmbJobType.Text = "DONG_GOI" OrElse cmbJobType.Text = "THEO_GIO" Then
                Return True
            End If
            Return False

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Function

    Private Sub txtNumericControls_KeyDown(sender As Object, e As KeyPressEventArgs) Handles txtFishPartitionNew.KeyPress, txtRateperPack.KeyPress, txtTotalAmount.KeyPress, txtTotalWeight.KeyPress, txtFishPartitionNew.KeyPress

        Try


            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not e.KeyChar = "," Then
                e.Handled = True
            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Public Sub GetTotalQtybyFishType()

        Try


            If cmbJobType.Text = "PHOI_CA" Then
                Dim qry As String = "SELECT  (SELECT IFNULL(SUM(Quantity), 0) FROM tblmarinatedfish WHERE fishtype=" & cmbFishType.SelectedValue & " AND DATE(TDate)<=DATE('" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "') )-(SELECT ROUND(IFNULL(SUM(TotalWeight), 0), 2) FROM tbllogwork WHERE fishtype=" & cmbFishType.SelectedValue & " AND DATE(TDate)<=Date('" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "')" & IIf((Not txtQuantity.Tag Is Nothing) AndAlso txtQuantity.Tag.ToString <> "", " AND ID <> " & txtQuantity.Tag, "") & " AND jobtype=(SELECT `ID` FROM `quanlysanxuat`.`tbljob` WHERE  `tbljob`.`JobName`='PHOI_CA')) AS QtyRemaining"
                Dim con As New MySql.Data.MySqlClient.MySqlConnection(g_connStr)
                Dim dtadpt As New MySql.Data.MySqlClient.MySqlDataAdapter(qry, con)
                Dim dt As New DataTable
                dtadpt.Fill(dt)
                If dt.Rows.Count > 0 Then
                    txtRemaining.Text = IIf(IsDBNull(dt.Rows(0)("QtyRemaining")), 0, dt.Rows(0)("QtyRemaining")) - IIf(txtTotalWeight.Text = "", 0, txtTotalWeight.Text)
                Else
                    txtRemaining.Text = -1 * IIf(txtTotalWeight.Text = "", 0, txtTotalWeight.Text)
                End If
            Else
                txtRemaining.Text = ""
            End If

        Catch ex As Exception

            g_ShowError(ex)

        End Try

    End Sub

    Private Sub txtQuantity_Leave(sender As Object, e As EventArgs) Handles txtQuantity.Leave

        Try


            GetTotalQtybyFishType()

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub cmbEmployee_Leave(sender As Object, e As EventArgs) Handles cmbJobType.Leave, cmbFishType.Leave, cmbEmployee.Leave, cmbKCS.Leave

        Try


            Dim cmb As ComboBox = TryCast(sender, ComboBox)
            Dim index As Integer = cmb.FindString(cmb.Text)

            If index < 0 Then
                cmb.SelectedIndex = 0
                cmb.Focus()
                Return
            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub cmbFishType_DropDown(sender As Object, e As EventArgs) Handles cmbFishType.DropDown, cmbEmployee.DropDown, cmbJobType.DropDown, cmbKCS.DropDown

        Try


            Dim cbo As ComboBox = CType(sender, ComboBox)
            AddHandler cbo.PreviewKeyDown, AddressOf comboBox_PreviewKeyDown

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Private Sub comboBox_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)

        Try


            Dim cbo As ComboBox = CType(sender, ComboBox)
            RemoveHandler cbo.PreviewKeyDown, AddressOf comboBox_PreviewKeyDown
            If cbo.DroppedDown Then cbo.Focus()

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub btnRestoreDefaults_Click(sender As Object, e As EventArgs) Handles btnRestoreDefaults.Click

        Try

            rbCurrentMonth.Checked = True
            dtFromDate.Value = Now.Year & "-" & Now.Month & "-01"
            dtToDate.Value = Now.Year & "-" & Now.Month & "-" & Date.DaysInMonth(Now.Year, Now.Month)
            cmbsearchEmp.SelectedIndex = -1
            cmbsearchFish.SelectedIndex = -1
            cmbsearchJob.SelectedIndex = -1
            dtFromDate.Enabled = False
            dtToDate.Enabled = False
            cmbsearchEmp.Enabled = False
            cmbsearchFish.Enabled = False
            cmbsearchJob.Enabled = False
            btnApplyFilters.Enabled = False
            GetAlldata()

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub rbAllFilters_Click(sender As Object, e As EventArgs) Handles rbAllFilters.Click, rbCurrentMonth.Click, rbShowAll.Click

        Try

            If sender.Name = "rbCurrentMonth" OrElse sender.Name = "rbShowAll" Then
                dtFromDate.Value = Now.Year & "-" & Now.Month & "-01"
                dtToDate.Value = Now.Year & "-" & Now.Month & "-" & Date.DaysInMonth(Now.Year, Now.Month)
                cmbsearchEmp.SelectedIndex = -1
                cmbsearchFish.SelectedIndex = -1
                cmbsearchJob.SelectedIndex = -1
                dtFromDate.Enabled = False
                dtToDate.Enabled = False
                cmbsearchEmp.Enabled = False
                cmbsearchFish.Enabled = False
                cmbsearchJob.Enabled = False
                btnApplyFilters.Enabled = False
            Else
                dtFromDate.Enabled = True
                dtToDate.Enabled = True
                cmbsearchEmp.Enabled = True
                cmbsearchFish.Enabled = True
                cmbsearchJob.Enabled = True
                btnApplyFilters.Enabled = True
            End If
            GetAlldata()

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub btnApplyFilters_Click(sender As Object, e As EventArgs) Handles btnApplyFilters.Click
        GetAlldata()
    End Sub


End Class