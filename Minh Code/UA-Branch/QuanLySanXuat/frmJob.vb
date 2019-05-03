
Public Class frmJob

    Dim curr_rowIndex As Integer
    Private Sub frmFish_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        grdJobs.AutoGenerateColumns = False
        GetAlldata()

        txtJob.Tag = ""
        If grdJobs.Rows.Count > 0 Then

            EditMode(False)
        Else
            EditMode(True)
        End If
    End Sub
    Public Sub GetAlldata()

        Try

            Dim tbladpt As New DataSet1TableAdapters.tbljobTableAdapter
            Dim dt As New DataTable
            dt = tbladpt.GetData()
            grdJobs.DataSource = dt
            If dt.Rows.Count > 0 Then
                txtJob.Text = dt.Rows(0)("JobName")
            Else
                EditMode(True)
                txtJob.Text = ""
            End If
            Dim autoSourceCollection As AutoCompleteStringCollection = New AutoCompleteStringCollection()

            For Each row As DataRow In dt.Rows
                autoSourceCollection.Add(row("JobName"))
            Next
            txtJob.AutoCompleteCustomSource = autoSourceCollection
            txtJob.Text = ""

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            txtJob.Tag = ""
            EditMode(True)
            curr_rowIndex = grdJobs.CurrentRow.Index
            txtJob.Text = ""

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditMode(IsEditable As Boolean)
        If IsEditable = True Then
            txtJob.ReadOnly = False
            btnSave.Visible = True
            btnNew.Visible = False
            btnCancel.Visible = True
            chkIsActive.Enabled = True
        Else

            btnNew.Visible = True
            btnCancel.Visible = False
            btnSave.Visible = False
            txtJob.ReadOnly = True
            chkIsActive.Enabled = False

            grdJobs.CurrentCell = grdJobs(1, IIf(grdJobs.Rows.Count = curr_rowIndex, curr_rowIndex - 1, curr_rowIndex))
                grdJobs.Rows(IIf(grdJobs.Rows.Count = curr_rowIndex, curr_rowIndex - 1, curr_rowIndex)).Selected = True

        End If

    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtJob.Tag = ""
        If grdJobs.Rows.Count = 0 Then
            Exit Sub
        End If
        EditMode(False)
        Try

            grdJobs_SelectionChanged(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdJobs_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdJobs.CellClick
        Try
            
            If btnCancel.Visible = True Then
                Exit Sub
            End If
            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
                Exit Sub
            End If
            txtJob.Text = grdJobs.Rows(grdJobs.CurrentCell.RowIndex).Cells("jobName").Value

            If grdJobs.Columns(e.ColumnIndex).Name = "Edit" Then
                If txtJob.Text = "LAM_CA" OrElse txtJob.Text = "PHOI_CA" OrElse txtJob.Text = "GO_VY" OrElse txtJob.Text = "LAM_SACH" OrElse txtJob.Text = "DONG_GOI" OrElse txtJob.Text = "THEO_GIO" Then 
                    If DefaultLanguage = "English" Then 
                        MessageBox.Show(Me, "You cannot edit this job type", "Action Restricted")
                        Else
                        MessageBox.Show(Me, "Bạn không thể chỉnh sửa loại công việc này", "Hành động bị hạn chế")
                    End If
                    Exit Sub
                End If
                txtJob.Text = grdJobs.Rows(grdJobs.CurrentCell.RowIndex).Cells("jobName").Value
                txtJob.Tag = grdJobs.Rows(e.RowIndex).Cells("id").Value
                chkIsActive.Checked = grdJobs.Rows(grdJobs.CurrentCell.RowIndex).Cells("isActive").Value
                curr_rowIndex = grdJobs.CurrentRow.Index
                EditMode(True)

            End If
            If grdJobs.Columns(e.ColumnIndex).Name = "Delete" Then

                If txtJob.Text = "LAM_CA" OrElse txtJob.Text = "PHOI_CA" OrElse txtJob.Text = "GO_VY" OrElse txtJob.Text = "LAM_SACH" OrElse txtJob.Text = "DONG_GOI" OrElse txtJob.Text = "THEO_GIO" Then 
                    If DefaultLanguage = "English" Then 
                        MessageBox.Show(Me, "You cannot delete this job type", "Action Restricted")
                        Else
                        MessageBox.Show(Me, "Bạn không thể xóa loại công việc này", "Hành động bị hạn chế")
                    End If
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim jobratesadpt As New DataSet2TableAdapters.tbljobratesTableAdapter
                dt = jobratesadpt.GetDataByJobType(grdJobs.Rows(e.RowIndex).Cells("id").Value)
                If dt.Rows.Count > 0 Then
                    If DefaultLanguage = "English" Then
                        MessageBox.Show(Me, "You cannot delete this Job Type as it is in use.", "Action Denied", MessageBoxButtons.OK)
                    Else
                        MessageBox.Show(Me, "Bạn không thể xóa Loại công việc này khi nó đang được sử dụng.", "hành động bị từ chối", MessageBoxButtons.OK)
                    End If
                    Exit Sub
                End If

                Dim logworkdadpt As New DataSet3TableAdapters.tbllogworkTableAdapter
                dt = logworkdadpt.GetDataByJobType(grdJobs.Rows(e.RowIndex).Cells("id").Value)
                If dt.Rows.Count > 0 Then
                    If DefaultLanguage = "English" Then
                        MessageBox.Show(Me, "You cannot delete this Job Type as it is in use.", "Action Denied", MessageBoxButtons.OK)
                    Else
                        MessageBox.Show(Me, "Bạn không thể xóa Loại công việc này khi nó đang được sử dụng.", "hành động bị từ chối", MessageBoxButtons.OK)
                    End If
                    Exit Sub
                End If

                If DefaultLanguage <> "English" Then
                    Dim msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn xóa không?", "xác nhận xóa", MessageBoxButtons.YesNo)
                    If msgboxres = DialogResult.Yes Then

                        Dim tbladpt As New DataSet1TableAdapters.tbljobTableAdapter
                        tbladpt.DeleteQuery(grdJobs.Rows(e.RowIndex).Cells("id").Value)
                        GetAlldata()
                    End If
                Else
                    Dim msgboxres = MessageBox.Show(Me, "Are you sure to delete?", "Confirm Delete", MessageBoxButtons.YesNo)
                    If msgboxres = DialogResult.Yes Then


                        Dim tbladpt As New DataSet1TableAdapters.tbljobTableAdapter
                        tbladpt.DeleteQuery(grdJobs.Rows(e.RowIndex).Cells("id").Value)
                        GetAlldata()
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
    '    Try
    '        Try
    '            If txtFish.Text.Length = 0 Then

    '                Exit Sub
    '            End If
    '            Dim tbladpt As New DataSet1TableAdapters.tbljobTableAdapter
    '            Dim dt As New DataTable
    '            tbladpt.UpdateQuery(txtFish.Text, txtFish.Tag)
    '            GetAlldata()
    '              btnAdd.Enabled = True
    '    btnUpdate.Enabled = False
    '        Catch ex As Exception

    '        End Try
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub AddNewRecord()
        Try
            If txtJob.Text.Length = 0 Then

                Exit Sub
            End If
            Dim tbladpt As New DataSet1TableAdapters.tbljobTableAdapter
            tbladpt.InsertQuery(txtJob.Text, DateTime.Now, DateTime.Now, usersDt.Rows(0)("ID"), usersDt.Rows(0)("ID"), GetIsActiveValue(chkIsActive.Checked))
            GetAlldata()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UpdateRecord()

        Try
            If txtJob.Text.Length = 0 Then

                Exit Sub
            End If

            Dim tbladpt As New DataSet1TableAdapters.tbljobTableAdapter
            Dim dt As New DataTable
            tbladpt.UpdateQuery(txtJob.Text, DateTime.Now, usersDt.Rows(0)("ID"), GetIsActiveValue(chkIsActive.Checked), txtJob.Tag)
            GetAlldata()
            btnNew.Enabled = True

        Catch ex As Exception

        End Try

    End Sub
    'Private Function AlreadyExists() As Boolean
    '    Dim tbladpt As New DataSet1TableAdapters.tbljobTableAdapter
    '    Dim dt As New DataTable
    '    dt = tbladpt.GetDataByjobname(txtJob.Text)
    '    If (dt.Rows.Count > 0) Then
    '        If txtJob.Tag.ToString() = "" Then
    '            If (dt.Rows(0)(0).ToString().ToLower() = txtJob.Text.ToLower()) Then
    '                Return True
    '            End If
    '        Else
    '            If (dt.Rows(0)(0).ToString().ToLower() = txtJob.Text.ToLower() And Not dt.Rows(0)(1).ToString() = txtJob.Tag) Then
    '                Return True
    '            End If
    '        End If
    '        Return False
    '    End If
    '    Return False
    'End Function

    Private Function AlreadyExists() As Boolean
        Dim tbladpt As New DataSet1TableAdapters.tbljobTableAdapter
        Dim dt As New DataTable
        dt = tbladpt.GetDataByjobname(txtJob.Text)
        If (dt.Rows.Count > 0) Then
            If txtJob.Tag.ToString() = "" Then
                Return True
            Else
                If (dt.Rows(0)("JobName").ToString().ToLower() = txtJob.Text.ToLower() And dt.Rows(0)("ID").ToString() <> txtJob.Tag) Then
                    Return True
                End If
            End If
            Return False
        End If
        Return False
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If DataValidated() = False Then
            Exit Sub
        End If

        Dim aexis = AlreadyExists()
        If aexis = True Then
            If DefaultLanguage <> "English" Then

                MessageBox.Show(Me, "Thông tin đã được lưu.", "Đã tồn tại", MessageBoxButtons.OK)
                Exit Sub
            Else
                MessageBox.Show(Me, "Record already exists.", "Exists", MessageBoxButtons.OK)
                Exit Sub
            End If

        End If
        If txtJob.Tag.ToString() = "" Then
            If DefaultLanguage <> "English" Then
                Dim msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn lưu?", "Xác nhận", MessageBoxButtons.YesNo)
                If msgboxres = DialogResult.Yes Then
                    AddNewRecord()
                Else
                    txtJob.Text = ""
                End If
            Else
                Dim msgboxres = MessageBox.Show(Me, "Do you want to save this record?", "Confirm Save", MessageBoxButtons.YesNo)
                If msgboxres = DialogResult.Yes Then
                    AddNewRecord()
                Else
                    txtJob.Text = ""
                End If
            End If



        Else
            If DefaultLanguage <> "English" Then
                Dim msgboxres = MessageBox.Show(Me, "bạn có muốn cập thông tin?", "Xác nhận cập nhật", MessageBoxButtons.YesNo)
                If msgboxres = DialogResult.Yes Then
                    UpdateRecord()
                Else
                    txtJob.Text = grdJobs.Rows(grdJobs.CurrentCell.RowIndex).Cells("jobName").Value
                End If

                txtJob.Tag = ""
            Else
                Dim msgboxres = MessageBox.Show(Me, "Do you want to update this record?", "Confirm Update", MessageBoxButtons.YesNo)
                If msgboxres = DialogResult.Yes Then
                    UpdateRecord()
                Else
                    txtJob.Text = grdJobs.Rows(grdJobs.CurrentCell.RowIndex).Cells("jobName").Value
                End If

                txtJob.Tag = ""
            End If

        End If
        EditMode(False)

    End Sub

    Private Function DataValidated() As Boolean
        If txtJob.Text.Length = 0 Then
            If DefaultLanguage <> "English" Then

                MessageBox.Show(Me, " Xin vui lòng chọn loại công việc.", "Trường bắt buộc")
                Return False

            Else
                MessageBox.Show(Me, "Job Name cannot be empty.", "Required Filed Validation")
                Return False
            End If

        End If

        Return True
    End Function

    Private Sub grdJobs_SelectionChanged(sender As Object, e As EventArgs) Handles grdJobs.SelectionChanged
        Try
            If btnCancel.Visible = True Then
                Exit Sub
            End If
            txtJob.Text = grdJobs.Rows(grdJobs.CurrentCell.RowIndex).Cells("jobName").Value
            chkIsActive.Checked = grdJobs.Rows(grdJobs.CurrentCell.RowIndex).Cells("isActive").Value




        Catch ex As Exception

        End Try
    End Sub
End Class
