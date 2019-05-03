
Public Class frmLeaves
    Dim curr_rowIndex As Integer

    Private Sub frmLeaves_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim employeedt As New DataTable
        Dim employeeadpt As New DataSet1TableAdapters.tblemployeeTableAdapter
        employeedt = employeeadpt.GetDataByActiveREcords()
        cmbEmployee.DataSource = employeedt
        cmbEmployee.DisplayMember = "empName"
        cmbEmployee.ValueMember = "ID"
        grdLeaves.AutoGenerateColumns = False
        GetAlldata()

        txtReason.Tag = ""
        If grdLeaves.Rows.Count > 0 Then

            EditMode(False)
        Else
            EditMode(True)
        End If



    End Sub
    Public Sub GetAlldata()

        Dim tbladpt As New DataSet5TableAdapters.tblemployeeLeavesAlldataDataAdapter
        Dim dt As New DataTable

        Try


            If chkAll.Checked = True Then
                dt = tbladpt.GetDataBy()
            Else
                dt = tbladpt.GetData()
            End If

            grdLeaves.DataSource = dt
            If dt.Rows.Count > 0 Then

            Else
                EditMode(True)
                txtReason.Text = ""
            End If

            txtReason.Tag = ""

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            txtReason.Tag = ""
            EditMode(True)
            curr_rowIndex = grdLeaves.CurrentRow.Index
            txtReason.Text = ""

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditMode(IsEditable As Boolean)
        If IsEditable = True Then
            txtReason.ReadOnly = False
            cmbEmployee.Enabled = True
            DateTimePicker1.Enabled = True
            btnSave.Visible = True
            btnNew.Visible = False
            btnCancel.Visible = True
            chkAdvancenotice.Enabled = True
            chkAll.Visible = False 
        Else
            DateTimePicker1.Enabled = False
            cmbEmployee.Enabled = False
            btnNew.Visible = True
            btnCancel.Visible = False
            btnSave.Visible = False
            txtReason.ReadOnly = True
            chkAdvancenotice.Enabled = False
            chkAll.Visible = True

            grdLeaves.CurrentCell = grdLeaves(1, IIf(grdLeaves.Rows.Count = curr_rowIndex, curr_rowIndex - 1, curr_rowIndex))
                grdLeaves.Rows(IIf(grdLeaves.Rows.Count = curr_rowIndex, curr_rowIndex - 1, curr_rowIndex)).Selected = True
        End If

    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtReason.Tag = ""
        If grdLeaves.Rows.Count = 0 Then
            Exit Sub
        End If
        EditMode(False)
        Try

            grdLeaves_SelectionChanged(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdLeaves_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdLeaves.CellClick
        Try
            If btnCancel.Visible = True Then
                Exit Sub
            End If


            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
                Exit Sub
            End If
            txtReason.Text = grdLeaves.Rows(grdLeaves.CurrentCell.RowIndex).Cells("Reason").Value
            If grdLeaves.Columns(e.ColumnIndex).Name = "Edit" Then

                txtReason.Text = grdLeaves.Rows(grdLeaves.CurrentCell.RowIndex).Cells("Reason").Value
                txtReason.Tag = grdLeaves.Rows(e.RowIndex).Cells("id").Value
                cmbEmployee.SelectedValue = grdLeaves.Rows(e.RowIndex).Cells("Employee").Value
                DateTimePicker1.Value = grdLeaves.Rows(e.RowIndex).Cells("LeaveDate").Value
                chkAdvancenotice.Checked = grdLeaves.Rows(e.RowIndex).Cells("advNotify").Value
                curr_rowIndex = grdLeaves.CurrentRow.Index
                EditMode(True)

            End If
            If grdLeaves.Columns(e.ColumnIndex).Name = "Delete" Then
                Dim msgboxres
                If DefaultLanguage = "English" Then
                    msgboxres = MessageBox.Show(Me, "Are you sure to delete?", "Confirm Delete", MessageBoxButtons.YesNo)
                Else
                    msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn xóa không?", "xác nhận xóa", MessageBoxButtons.YesNo)
                End If
                If msgboxres = DialogResult.Yes Then
                    curr_rowIndex = grdLeaves.CurrentRow.Index
                    Dim tbladpt As New DataSet4TableAdapters.tblemployeeleaveTableAdapter
                    tbladpt.DeleteQuery(grdLeaves.Rows(e.RowIndex).Cells("id").Value)
                    GetAlldata()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddNewRecord()
        Try

            Dim tbladpt As New DataSet4TableAdapters.tblemployeeleaveTableAdapter
            tbladpt.InsertQuery(cmbEmployee.SelectedValue, DateTimePicker1.Value, txtReason.Text, DateTime.Now, DateTime.Now, usersDt.Rows(0)("ID"), usersDt.Rows(0)("ID"), chkAdvancenotice.Checked)
            GetAlldata()
        Catch ex As Exception

        End Try
    End Sub
    Private Function AlreadyExists() As Boolean
        Dim tbladpt As New DataSet4TableAdapters.tblemployeeleaveTableAdapter
        Dim dt As New DataTable
        dt = tbladpt.GetDataByEmployeeandDate(DateTimePicker1.Value, cmbEmployee.SelectedValue)
        If (dt.Rows.Count > 0) Then
            If txtReason.Tag.ToString() = "" Then

                Return True

            Else
                If (dt.Rows(0)("ID").ToString() <> txtReason.Tag) Then
                    Return True
                End If
            End If
            Return False
        End If
        Return False
    End Function

    'Private Function AlreadyExists() As Boolean

    '    Return False
    'End Function
    Private Sub UpdateRecord()

        Try

            Dim tbladpt As New DataSet4TableAdapters.tblemployeeleaveTableAdapter
            tbladpt.UpdateQuery(cmbEmployee.SelectedValue, DateTimePicker1.Value, txtReason.Text, DateTime.Now, usersDt.Rows(0)("ID"), chkAdvancenotice.Checked, txtReason.Tag)
            GetAlldata()
            btnNew.Enabled = True

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If DataValidated() = False Then
            Exit Sub
        End If

        Dim msgboxres
        Dim aexis = AlreadyExists()
        If aexis = True Then
            If DefaultLanguage = "English" Then
                MessageBox.Show(Me, "This employee has already leave on specified date.", "Already Exists", MessageBoxButtons.OK)
            Else
                MessageBox.Show(Me, "Thông tin đã được lưu", "Đã tồn tại", MessageBoxButtons.OK)
            End If
            Exit Sub
        End If
        If txtReason.Tag.ToString() = "" Then


            If DefaultLanguage = "English" Then
                msgboxres = MessageBox.Show(Me, "Do you want to save this record?", "Confirm Save", MessageBoxButtons.YesNo)
            Else
                msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn lưu?", "Xác nhận", MessageBoxButtons.YesNo)
            End If
            If msgboxres = DialogResult.Yes Then
                AddNewRecord()
            Else
                txtReason.Text = ""
            End If


        Else

            If DefaultLanguage = "English" Then
                msgboxres = MessageBox.Show(Me, "Do you want to update this record?", "Confirm Update", MessageBoxButtons.YesNo)
            Else
                msgboxres = MessageBox.Show(Me, "bạn có muốn cập thông tin?", "Xác nhận cập nhật", MessageBoxButtons.YesNo)
            End If
            If msgboxres = DialogResult.Yes Then
                UpdateRecord()
            Else
                txtReason.Text = grdLeaves.Rows(grdLeaves.CurrentCell.RowIndex).Cells("Reason").Value
                cmbEmployee.SelectedValue = grdLeaves.Rows(grdLeaves.CurrentCell.RowIndex).Cells("Employee").Value
                DateTimePicker1.Value = grdLeaves.Rows(grdLeaves.CurrentCell.RowIndex).Cells("LeaveDate").Value
            End If

            txtReason.Tag = ""
        End If
        EditMode(False)

    End Sub

    Private Function DataValidated() As Boolean


        Return True
    End Function

    Private Sub grdLeaves_SelectionChanged(sender As Object, e As EventArgs) Handles grdLeaves.SelectionChanged
        Try
            If btnCancel.Visible = True Then
                Exit Sub
            End If
            txtReason.Text = grdLeaves.Rows(grdLeaves.CurrentCell.RowIndex).Cells("Reason").Value
            cmbEmployee.SelectedValue = grdLeaves.Rows(grdLeaves.CurrentCell.RowIndex).Cells("Employee").Value
            DateTimePicker1.Value = grdLeaves.Rows(grdLeaves.CurrentCell.RowIndex).Cells("LeaveDate").Value
            chkAdvancenotice.Checked = grdLeaves.Rows(grdLeaves.CurrentCell.RowIndex).Cells("advNotify").Value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        GetAlldata()
    End Sub

    Private Sub cmbEmployee_Leave(sender As Object, e As EventArgs) Handles cmbEmployee.Leave
        Dim cmb As ComboBox = TryCast(sender, ComboBox)
        Dim index As Integer = cmb.FindString(cmb.Text)

        If index < 0 Then
            cmb.SelectedIndex = 0
            cmb.Focus()
            Return
        End If
    End Sub
    Private Sub cmbFishType_DropDown(sender As Object, e As EventArgs) Handles cmbEmployee.DropDown
        Dim cbo As ComboBox = CType(sender, ComboBox)
        AddHandler cbo.PreviewKeyDown, AddressOf comboBox_PreviewKeyDown
    End Sub
    Private Sub comboBox_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        Dim cbo As ComboBox = CType(sender, ComboBox)
        RemoveHandler cbo.PreviewKeyDown, AddressOf comboBox_PreviewKeyDown
        If cbo.DroppedDown Then cbo.Focus()
    End Sub


End Class