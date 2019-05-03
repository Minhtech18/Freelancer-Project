Public Class frmJobRates
    Dim curr_rowIndex As Integer
    Private Sub frmJobRates_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.tblfish' table. You can move, or remove it, as needed.
        Dim fishdt As New DataTable
        Dim fishdtadpt As New DataSet1TableAdapters.tblfishTableAdapter
        fishdt = fishdtadpt.GetDataByActiveRecords()
        cmbFishType.DataSource = fishdt
        cmbFishType.DisplayMember = "FishName"
        cmbFishType.ValueMember = "ID"

        Dim jobdt As New DataTable
        Dim jobdtadpt As New DataSet1TableAdapters.tbljobTableAdapter
        jobdt = jobdtadpt.GetDataByActiveREcords()
        cmbJobType.DataSource = jobdt
        cmbJobType.DisplayMember = "JobName"
        cmbJobType.ValueMember = "ID"

        grdJobRates.AutoGenerateColumns = False
        GetAlldata()

        txtPackingStyle.Tag = ""
        If grdJobRates.Rows.Count > 0 Then

            EditMode(False)
        Else
            EditMode(True)
        End If

    End Sub
    Public Sub GetDistinctPUnits()
        Dim qry As String = "Select Distinct PUnit from tbljobrates"
        Dim con As New MySql.Data.MySqlClient.MySqlConnection(g_connStr)
        Dim dtadpt As New MySql.Data.MySqlClient.MySqlDataAdapter(qry, con)
        Dim dt As New DataTable
        dtadpt.Fill(dt)
        If dt.Rows.Count > 0 Then
            Dim itemfound = False
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i)(0) = "Kg" Then
                    itemfound = True
                    Exit For
                End If
            Next
            If itemfound = False Then
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1)(0) = "Kg"

            End If
        Else
            dt.Rows.Add()
            dt.Rows(dt.Rows.Count - 1)(0) = "Kg"
        End If
        cmbUnits.DataSource = dt
        cmbUnits.DisplayMember = "PUnit"
        cmbUnits.ValueMember = "PUnit"

    End Sub
    Public Sub GetAlldata()

        Try

            Dim tbladpt As New DataSet2TableAdapters.tbljobratesAllDataTableAdapter
            Dim dt As New DataTable
            dt = tbladpt.GetData()
            grdJobRates.DataSource = dt
            If grdJobRates.Rows.Count > 0 Then

                EditMode(False)
            Else
                EditMode(True)
                ClearAll()
            End If
            GetDistinctPUnits()
            txtPackingStyle.Tag = ""

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Public Sub ClearAll()
        txtPackingStyle.Text = ""
        txtRate.Text = ""
        cmbFishType.SelectedIndex = 0
        cmbJobType.SelectedIndex = 0
    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try

            txtPackingStyle.Tag = ""
            EditMode(True)
            curr_rowIndex = grdJobRates.CurrentRow.Index
            txtPackingStyle.Text = ""
            txtRate.Text = ""
            cmbFishType.SelectedIndex = 0
            cmbJobType.SelectedIndex = 0

        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub

    Private Sub EditMode(IsEditable As Boolean)
        If IsEditable = True Then
            txtPackingStyle.ReadOnly = False
            txtRate.ReadOnly = False
            cmbFishType.Enabled = True
            cmbJobType.Enabled = True
            cmbUnits.Enabled = True
            btnSave.Visible = True
            btnNew.Visible = False
            btnCancel.Visible = True
        Else

            btnNew.Visible = True
            btnCancel.Visible = False
            btnSave.Visible = False
            txtPackingStyle.ReadOnly = True
            txtRate.ReadOnly = True
            cmbFishType.Enabled = False
            cmbJobType.Enabled = False
            cmbUnits.Enabled = False

            grdJobRates.CurrentCell = grdJobRates(1, IIf(grdJobRates.Rows.Count = curr_rowIndex, curr_rowIndex - 1, curr_rowIndex))
                grdJobRates.Rows(IIf(grdJobRates.Rows.Count = curr_rowIndex, curr_rowIndex - 1, curr_rowIndex)).Selected = True
        End If

    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtPackingStyle.Tag = ""
        If grdJobRates.Rows.Count = 0 Then
            Exit Sub
        End If
        EditMode(False)
        Try

            grdJobRates_SelectionChanged(sender, e)
        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub

    Private Sub grdJobRates_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdJobRates.CellClick
        Try
            If btnCancel.Visible = True Then
                Exit Sub
            End If


            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
                Exit Sub
            End If
            txtPackingStyle.Text = grdJobRates.Rows(grdJobRates.CurrentCell.RowIndex).Cells("PackingStyle").Value
            txtRate.Text = Val(grdJobRates.Rows(grdJobRates.CurrentCell.RowIndex).Cells("Rate").Value).ToString("N0")
            cmbFishType.SelectedValue = grdJobRates.Rows(grdJobRates.CurrentCell.RowIndex).Cells("FishType").Value
            cmbJobType.SelectedValue = grdJobRates.Rows(grdJobRates.CurrentCell.RowIndex).Cells("JobType").Value
            cmbUnits.SelectedValue = grdJobRates.Rows(grdJobRates.CurrentCell.RowIndex).Cells("PUnit").Value
            If grdJobRates.Columns(e.ColumnIndex).Name = "Edit" Then


                txtPackingStyle.Tag = grdJobRates.Rows(e.RowIndex).Cells("id").Value
                curr_rowIndex = grdJobRates.CurrentRow.Index
                EditMode(True)

            End If
            If grdJobRates.Columns(e.ColumnIndex).Name = "Delete" Then
                If DefaultLanguage <> "English" Then
                    Dim msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn xóa không?", "xác nhận xóa", MessageBoxButtons.YesNo)
                    If msgboxres = DialogResult.Yes Then
                        curr_rowIndex = grdJobRates.CurrentRow.Index
                        Dim tbladpt As New DataSet2TableAdapters.tbljobratesTableAdapter
                        tbladpt.DeleteQuery(grdJobRates.Rows(e.RowIndex).Cells("id").Value)
                        GetAlldata()
                    End If
                Else
                    Dim msgboxres = MessageBox.Show(Me, "Are you sure to delete?", "Confirm Delete", MessageBoxButtons.YesNo)
                    If msgboxres = DialogResult.Yes Then
                        curr_rowIndex = grdJobRates.CurrentRow.Index
                        Dim tbladpt As New DataSet2TableAdapters.tbljobratesTableAdapter
                        tbladpt.DeleteQuery(grdJobRates.Rows(e.RowIndex).Cells("id").Value)
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

            Dim tbladpt As New DataSet2TableAdapters.tbljobratesTableAdapter
            tbladpt.InsertQuery(cmbFishType.SelectedValue, GetFloatValue(txtPackingStyle.Text), cmbJobType.SelectedValue, txtRate.Text, DateTime.Now, DateTime.Now, usersDt.Rows(0)("ID"), usersDt.Rows(0)("ID"), cmbUnits.Text)
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
        Dim tbladpt As New DataSet2TableAdapters.tbljobratesTableAdapter
        Dim dt As New DataTable
        dt = tbladpt.GetDataByFishTypeandJobType(cmbFishType.SelectedValue, cmbJobType.SelectedValue, Val(txtPackingStyle.Text))
        If (dt.Rows.Count > 0) Then
            If txtPackingStyle.Tag.ToString() = "" Then
                Return True
            Else
                If (dt.Rows(0)("FishType").ToString() = cmbFishType.SelectedValue.ToString() And dt.Rows(0)("JobType").ToString() = cmbJobType.SelectedValue.ToString() And dt.Rows(0)("PackingStyle").ToString() = txtPackingStyle.ToString() And dt.Rows(0)("ID").ToString() <> txtPackingStyle.Tag) Then
                    Return True
                End If
            End If
            Return False
        End If
        Return False
    End Function
    Private Sub UpdateRecord()

        Try

            Dim tbladpt As New DataSet2TableAdapters.tbljobratesTableAdapter
            tbladpt.UpdateQuery(cmbFishType.SelectedValue, GetFloatValue(txtPackingStyle.Text), cmbJobType.SelectedValue, txtRate.Text, DateTime.Now, usersDt.Rows(0)("ID"), cmbUnits.Text, txtPackingStyle.Tag)
            GetAlldata()
            btnNew.Enabled = True

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

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
        If txtPackingStyle.Tag.ToString() = "" Then
            If DefaultLanguage <> "English" Then
                Dim msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn lưu?", "Xác nhận", MessageBoxButtons.YesNo)
                If msgboxres = DialogResult.Yes Then
                    AddNewRecord()
                Else
                    txtPackingStyle.Text = ""
                    txtRate.Text = ""
                End If
            Else
                Dim msgboxres = MessageBox.Show(Me, "Do you want to save this record?", "Confirm Save", MessageBoxButtons.YesNo)
                If msgboxres = DialogResult.Yes Then
                    AddNewRecord()
                Else
                    txtPackingStyle.Text = ""
                    txtRate.Text = ""
                End If
            End If



        Else
            If DefaultLanguage <> "English" Then
                Dim msgboxres = MessageBox.Show(Me, "bạn có muốn cập thông tin?", "Xác nhận cập nhật", MessageBoxButtons.YesNo)
                If msgboxres = DialogResult.Yes Then
                    UpdateRecord()
                Else

                    txtRate.Text = Val(grdJobRates.Rows(grdJobRates.CurrentCell.RowIndex).Cells("Rate").Value).ToString("N0")
                    txtPackingStyle.Text = grdJobRates.Rows(grdJobRates.CurrentCell.RowIndex).Cells("PackingStyle").Value

                End If

                txtPackingStyle.Tag = ""
            Else
                Dim msgboxres = MessageBox.Show(Me, "Do you want to update this record?", "Confirm Update", MessageBoxButtons.YesNo)
                If msgboxres = DialogResult.Yes Then
                    UpdateRecord()
                Else

                    txtRate.Text = Val(grdJobRates.Rows(grdJobRates.CurrentCell.RowIndex).Cells("Rate").Value).ToString("N0")
                    txtPackingStyle.Text = grdJobRates.Rows(grdJobRates.CurrentCell.RowIndex).Cells("PackingStyle").Value

                End If

                txtPackingStyle.Tag = ""
            End If

        End If
        EditMode(False)

    End Sub

    Private Function DataValidated() As Boolean
        If txtPackingStyle.Text.Length = 0 Then
            If DefaultLanguage = "English" Then
                MessageBox.Show(Me, "PackingStyle cannot be empty.", "Required Filed Validation")
            Else
                MessageBox.Show(Me, "Xin vui lòng chọn quy cách", "Trường bắt buộc")
            End If
            Return False
        End If
        If txtRate.Text.Length = 0 Then
            If DefaultLanguage = "English" Then
                MessageBox.Show(Me, "Rate cannot be empty.", "Required Filed Validation")
            Else
                MessageBox.Show(Me, "Xin vui lòng chọn đơn giá", "Trường bắt buộc")
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
                MessageBox.Show(Me, "Job Type cannot be empty.", "Required Filed Validation")
            Else
                MessageBox.Show(Me, "Xin vui lòng chọn loại công việc", "Trường bắt buộc")
            End If
            Return False
        End If
        If cmbUnits.Text.Trim = "" Then
            If DefaultLanguage = "English" Then
                MessageBox.Show(Me, "Unit cannot be empty.", "Required Filed Validation")
            Else
                MessageBox.Show(Me, "Đơn vị không thể để trống.", "Trường bắt buộc")
            End If
            Return False
        End If
        If Val(txtPackingStyle.Text) <= 0 Or Val(txtRate.Text) <= 0 Then
            If DefaultLanguage = "English" Then
                MessageBox.Show(Me, "Rate or Packing style cannot be less than zero", "Required Filed Validation")
            Else
                MessageBox.Show(Me, "Tỷ lệ hoặc kiểu đóng gói không thể nhỏ hơn 0", "Trường bắt buộc")
            End If
            Return False
        End If
        Return True
    End Function

    Private Sub grdJobRates_SelectionChanged(sender As Object, e As EventArgs) Handles grdJobRates.SelectionChanged
        Try
            If btnCancel.Visible = True Then
                Exit Sub
            End If
            txtPackingStyle.Text = grdJobRates.Rows(grdJobRates.CurrentCell.RowIndex).Cells("PackingStyle").Value
            txtRate.Text = Val(grdJobRates.Rows(grdJobRates.CurrentCell.RowIndex).Cells("Rate").Value).ToString("N0")
            cmbFishType.SelectedValue = grdJobRates.Rows(grdJobRates.CurrentCell.RowIndex).Cells("FishType").Value
            cmbJobType.SelectedValue = grdJobRates.Rows(grdJobRates.CurrentCell.RowIndex).Cells("JobType").Value
            cmbUnits.SelectedValue = grdJobRates.Rows(grdJobRates.CurrentCell.RowIndex).Cells("PUnit").Value

        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub

    Private Sub txtRate_TextChanged(sender As Object, e As EventArgs) Handles txtRate.TextChanged

        Try

           Try

            If TryCast(sender, TextBox).Text.Length > 0 Then
                TryCast(sender, TextBox).Text = Convert.ToDouble(TryCast(sender, TextBox).Text).ToString("N0")
                Dim txtbox = TryCast(sender, TextBox)
                txtbox.SelectionStart = txtbox.Text.Length
                txtbox.SelectionLength = 0
            Else
                TryCast(sender, TextBox).Text = 0
            End If


        Catch ex As Exception
            g_ShowError(ex)
        End Try
            
        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub txtPackingStyle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPackingStyle.KeyPress, txtRate.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not e.KeyChar = "," Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmbFishType_Leave(sender As Object, e As EventArgs) Handles cmbJobType.Leave, cmbFishType.Leave
        Dim cmb As ComboBox = TryCast(sender, ComboBox)
        Dim index As Integer = cmb.FindString(cmb.Text)

        If index < 0 Then
            cmb.SelectedIndex = 0
            cmb.Focus()
            Return
        End If
    End Sub
    Private Sub cmbFishType_DropDown(sender As Object, e As EventArgs) Handles cmbFishType.DropDown, cmbUnits.DropDown, cmbJobType.DropDown
        Dim cbo As ComboBox = CType(sender, ComboBox)
        AddHandler cbo.PreviewKeyDown, AddressOf comboBox_PreviewKeyDown
    End Sub
    Private Sub comboBox_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        Dim cbo As ComboBox = CType(sender, ComboBox)
        RemoveHandler cbo.PreviewKeyDown, AddressOf comboBox_PreviewKeyDown
        If cbo.DroppedDown Then cbo.Focus()
    End Sub

End Class