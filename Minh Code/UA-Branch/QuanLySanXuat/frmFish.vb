Public Class frmFish

    Dim curr_rowIndex As Integer

    Private Sub frmFish_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        grdFish.AutoGenerateColumns = False
        GetAlldata()

        txtFish.Tag = ""
        If grdFish.Rows.Count > 0 Then

            EditMode(False)
        Else
            EditMode(True)
        End If


    End Sub
    Public Sub GetAlldata()

        Try

            Dim tbladpt As New DataSet1TableAdapters.tblfishTableAdapter
            Dim dt As New DataTable
            dt = tbladpt.GetData()
            grdFish.DataSource = dt

            If dt.Rows.Count > 0 Then
                txtFish.Text = dt.Rows(0)("FishName")
            Else
                EditMode(True)
                txtFish.Text = ""
            End If
            Dim autoSourceCollection As AutoCompleteStringCollection = New AutoCompleteStringCollection()

            For Each row As DataRow In dt.Rows
                autoSourceCollection.Add(row("FishName"))
            Next
            txtFish.AutoCompleteCustomSource = autoSourceCollection
            If grdFish.Rows.Count > 0 Then

                EditMode(False)
            Else
                EditMode(True)
            End If
            txtFish.Tag = ""

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try

            EditMode(True)
            curr_rowIndex = grdFish.CurrentRow.Index
            txtFish.Text = ""

        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub

    Private Sub EditMode(IsEditable As Boolean)
        If IsEditable = True Then
            txtFish.ReadOnly = False
            btnSave.Visible = True
            btnNew.Visible = False
            btnCancel.Visible = True
            chkIsActive.Enabled = True
        Else

            btnNew.Visible = True
            btnCancel.Visible = False
            btnSave.Visible = False
            txtFish.ReadOnly = True
            chkIsActive.Enabled = False
            grdFish.CurrentCell = grdFish(1, IIf(grdFish.Rows.Count = curr_rowIndex, curr_rowIndex - 1, curr_rowIndex))
                grdFish.Rows(IIf(grdFish.Rows.Count = curr_rowIndex, curr_rowIndex - 1, curr_rowIndex)).Selected = True

        End If

    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtFish.Tag = ""
        If grdFish.Rows.Count = 0 Then
            Exit Sub
        End If
        EditMode(False)
        Try

            grdFish_SelectionChanged(sender, e)
        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub grdFish_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdFish.CellClick
        Try
            If btnCancel.Visible = True Then
                Exit Sub
            End If


            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
                Exit Sub
            End If
            txtFish.Text = grdFish.Rows(grdFish.CurrentCell.RowIndex).Cells("FishName").Value
            If grdFish.Columns(e.ColumnIndex).Name = "Edit" Then

                txtFish.Text = grdFish.Rows(grdFish.CurrentCell.RowIndex).Cells("FishName").Value
                txtFish.Tag = grdFish.Rows(e.RowIndex).Cells("id").Value
                chkIsActive.Checked = grdFish.Rows(e.RowIndex).Cells("isActive").Value
                curr_rowIndex = grdFish.CurrentRow.Index
                EditMode(True)

            End If
            If grdFish.Columns(e.ColumnIndex).Name = "Delete" Then

                Dim dt As New DataTable
                Dim logworkdadpt As New DataSet3TableAdapters.tbllogworkTableAdapter
                dt = logworkdadpt.GetDataByFishType(grdFish.Rows(e.RowIndex).Cells("id").Value)
                If dt.Rows.Count > 0 Then
                    If DefaultLanguage = "English" Then 
                        MessageBox.Show(Me, "You cannot delete this Fish Type as it is in use.", "Action Denied", MessageBoxButtons.OK)
                        Else
                        MessageBox.Show(Me, "Bạn không thể xóa Loại cá này khi nó đang được sử dụng.", "hành động bị từ chối", MessageBoxButtons.OK)
                    End If
                    Exit Sub
                End If

                If DefaultLanguage <> "English" Then
                    Dim msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn xóa không?", "xác nhận xóa", MessageBoxButtons.YesNo)
                    If msgboxres = DialogResult.Yes Then
                        curr_rowIndex = grdFish.CurrentRow.Index
                        Dim tbladpt As New DataSet1TableAdapters.tblfishTableAdapter
                        tbladpt.DeleteQuery(grdFish.Rows(e.RowIndex).Cells("id").Value)
                        GetAlldata()
                    End If
                Else
                    Dim msgboxres = MessageBox.Show(Me, "Are you sure to delete?", "Confirm Delete", MessageBoxButtons.YesNo)
                    If msgboxres = DialogResult.Yes Then
                        curr_rowIndex = grdFish.CurrentRow.Index
                        Dim tbladpt As New DataSet1TableAdapters.tblfishTableAdapter
                        tbladpt.DeleteQuery(grdFish.Rows(e.RowIndex).Cells("id").Value)
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
            If txtFish.Text.Length = 0 Then

                Exit Sub
            End If

            Dim tbladpt As New DataSet1TableAdapters.tblfishTableAdapter
            tbladpt.InsertQuery(txtFish.Text, DateTime.Now, DateTime.Now, usersDt.Rows(0)("ID"), usersDt.Rows(0)("ID"), GetIsActiveValue(chkIsActive.Checked))
            GetAlldata()
        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub
    'Private Function AlreadyExists() As Boolean
    '    Dim tbladpt As New DataSet1TableAdapters.tblfishTableAdapter
    '    Dim dt As New DataTable
    '    dt = tbladpt.GetDataByFishname(txtFish.Text)
    '    If (dt.Rows.Count > 0) Then
    '        If txtFish.Tag.ToString() = "" Then
    '            If (dt.Rows(0)(0).ToString().ToLower() = txtFish.Text.ToLower()) Then
    '                Return True
    '            End If
    '        Else
    '            If (dt.Rows(0)(0).ToString().ToLower() = txtFish.Text.ToLower() And Not dt.Rows(0)(1).ToString() = txtFish.Tag) Then
    '                Return True
    '            End If
    '        End If
    '        Return False
    '    End If
    '    Return False
    'End Function

    Private Function AlreadyExists() As Boolean
        Dim tbladpt As New DataSet1TableAdapters.tblfishTableAdapter
        Dim dt As New DataTable
        dt = tbladpt.GetDataByFishname(txtFish.Text)
        If (dt.Rows.Count > 0) Then
            If txtFish.Tag.ToString() = "" Then
                Return True
            Else
                If (dt.Rows(0)("FishName").ToString().ToLower() = txtFish.Text.ToLower() And dt.Rows(0)("ID").ToString() <> txtFish.Tag) Then
                    Return True
                End If
            End If
            Return False
        End If
        Return False
    End Function
    Private Sub UpdateRecord()

        Try
            If txtFish.Text.Length = 0 Then

                Exit Sub
            End If
            Dim tbladpt As New DataSet1TableAdapters.tblfishTableAdapter
            tbladpt.UpdateQuery(txtFish.Text, DateTime.Now, usersDt.Rows(0)("ID"), GetIsActiveValue(chkIsActive.Checked), txtFish.Tag)
            GetAlldata()
            btnNew.Enabled = True

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If DataValidated() = False Then
            Exit Sub
        End If

        Dim aexis = AlreadyExists()
        If aexis = True Then
            If DefaultLanguage = "English" Then
                MessageBox.Show(Me, "Record already exists.", "Already Exists", MessageBoxButtons.OK)
            Else
                MessageBox.Show(Me, "Thông tin đã được lưu", "Đã tồn tại", MessageBoxButtons.OK)
            End If
            Exit Sub
        End If
        If txtFish.Tag.ToString() = "" Then
            If DefaultLanguage <> "English" Then
                Dim msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn lưu?", "Xác nhận", MessageBoxButtons.YesNo)
                If msgboxres = DialogResult.Yes Then
                    AddNewRecord()
                Else
                    txtFish.Text = ""
                End If
            Else
                Dim msgboxres = MessageBox.Show(Me, "Do you want to save this record?", "Confirm Save", MessageBoxButtons.YesNo)
                If msgboxres = DialogResult.Yes Then
                    AddNewRecord()
                Else
                    txtFish.Text = ""
                End If
            End If



        Else
            If DefaultLanguage <> "English" Then
                Dim msgboxres = MessageBox.Show(Me, "bạn có muốn cập thông tin?", "Xác nhận cập nhật", MessageBoxButtons.YesNo)
                If msgboxres = DialogResult.Yes Then
                    UpdateRecord()
                Else
                    txtFish.Text = grdFish.Rows(grdFish.CurrentCell.RowIndex).Cells("FishName").Value
                End If

                txtFish.Tag = ""
            Else
                Dim msgboxres = MessageBox.Show(Me, "Do you want to update this record?", "Confirm Update", MessageBoxButtons.YesNo)
                If msgboxres = DialogResult.Yes Then
                    UpdateRecord()
                Else
                    txtFish.Text = grdFish.Rows(grdFish.CurrentCell.RowIndex).Cells("FishName").Value
                End If

                txtFish.Tag = ""
            End If

        End If
        EditMode(False)

    End Sub

    Private Function DataValidated() As Boolean
        If txtFish.Text.Length = 0 Then
            If DefaultLanguage <> "English" Then

                MessageBox.Show(Me, "Xin vui lòng nhập tên cá.", "Trường bắt buộc")

            Else
                MessageBox.Show(Me, "Fish Name cannot be empty.", "Required Filed Validation")
            End If

            Return False
        End If

        Return True
    End Function

    Private Sub grdFish_SelectionChanged(sender As Object, e As EventArgs) Handles grdFish.SelectionChanged
        Try
            If btnCancel.Visible = True Then
                Exit Sub
            End If
            txtFish.Text = grdFish.Rows(grdFish.CurrentCell.RowIndex).Cells("FishName").Value
            chkIsActive.Checked = grdFish.Rows(grdFish.CurrentCell.RowIndex).Cells("isActive").Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblFishName_Click(sender As Object, e As EventArgs) Handles lblFishName.Click

    End Sub
End Class
