Imports MySql.Data.MySqlClient
Public Class frmMarinatedFish
    Dim curr_rowIndex As Integer
    Private Sub frmMarinatedFish_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fishdt As New DataTable
        Dim fishdtadpt As New DataSet1TableAdapters.tblfishTableAdapter
        fishdt = fishdtadpt.GetDataByActiveRecords()
        cmbFishType.DataSource = fishdt
        cmbFishType.DisplayMember = "FishName"
        cmbFishType.ValueMember = "ID"

        Dim sourcedt As New DataTable
        Dim sourceadpt As New DataSet1TableAdapters.tblsourcefishTableAdapter
        sourcedt = sourceadpt.GetDataByActiveRecords()
        cmbSourceFish.DataSource = sourcedt
        cmbSourceFish.DisplayMember = "SourceName"
        cmbSourceFish.ValueMember = "ID"

        Dim employeedt As New DataTable
        Dim employeeadpt As New DataSet1TableAdapters.tblemployeeTableAdapter
        employeedt = employeeadpt.GetDataByActiveREcords()
        cmbEmployee.DataSource = employeedt
        cmbEmployee.DisplayMember = "empName"
        cmbEmployee.ValueMember = "ID"


        grdMarinatedFish.AutoGenerateColumns = False
        GetAlldata()

        txtQuantity.Tag = ""


    End Sub
    Public Sub GetDistinctPUnits()

        Try

            Dim qry As String = "SELECT Distinct PUnit FROM tblmarinatedfish"
            Dim con As New MySqlConnection(g_connStr)
            Dim dtadpt As New MySqlDataAdapter(qry, con)
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
        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Public Sub GetAlldata()

        Try
            Dim tbladpt As New DataSet5TableAdapters.DataTable1TableAdapter
            Dim dt As New DataTable
            dt = tbladpt.GetData()
            grdMarinatedFish.DataSource = dt
            If grdMarinatedFish.Rows.Count > 0 Then

                EditMode(False)
            Else
                EditMode(True)
            End If
            GetDistinctPUnits()
            txtQuantity.Tag = ""

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try

            txtQuantity.Tag = ""
            EditMode(True)
            curr_rowIndex = grdMarinatedFish.CurrentRow.Index
            txtQuantity.Text = ""
            cmbEmployee.SelectedValue = 0
            cmbFishType.SelectedIndex = 0
            cmbSourceFish.SelectedIndex = 0
            DateTimePicker1.Value = DateTime.Now
            GroupBox1.Visible = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditMode(IsEditable As Boolean)
        If IsEditable = True Then
            txtQuantity.ReadOnly = False

            cmbFishType.Enabled = True
            cmbEmployee.Enabled = True
            cmbSourceFish.Enabled = True
            btnSave.Visible = True
            btnNew.Visible = False
            btnCancel.Visible = True
            cmbUnits.Enabled = True
        Else

            btnNew.Visible = True
            btnCancel.Visible = False
            btnSave.Visible = False
            txtQuantity.ReadOnly = True

            cmbFishType.Enabled = False
            cmbEmployee.Enabled = False
            cmbSourceFish.Enabled = False
            cmbUnits.Enabled = False

            grdMarinatedFish.CurrentCell = grdMarinatedFish(1, IIf(grdMarinatedFish.Rows.Count = curr_rowIndex, curr_rowIndex - 1, curr_rowIndex))
                grdMarinatedFish.Rows(IIf(grdMarinatedFish.Rows.Count = curr_rowIndex, curr_rowIndex - 1, curr_rowIndex)).Selected = True
        End If

    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtQuantity.Tag = ""
        If grdMarinatedFish.Rows.Count = 0 Then
            Exit Sub
        End If
        EditMode(False)
        Try

            grdMarinatedFish_SelectionChanged(sender, e)
        Catch ex As Exception

        End Try
        GroupBox1.Visible = True
    End Sub

    Private Sub grdMarinatedFish_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdMarinatedFish.CellClick
        Try

            If btnCancel.Visible = True Then
                Exit Sub
            End If
            Dim msgboxres
            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
                Exit Sub
            End If
            txtQuantity.Text = grdMarinatedFish.Rows(grdMarinatedFish.CurrentCell.RowIndex).Cells("Quantity").Value
            cmbEmployee.SelectedValue = grdMarinatedFish.Rows(grdMarinatedFish.CurrentCell.RowIndex).Cells("Employee").Value
            cmbFishType.SelectedValue = grdMarinatedFish.Rows(grdMarinatedFish.CurrentCell.RowIndex).Cells("FishType").Value
            cmbSourceFish.SelectedValue = grdMarinatedFish.Rows(grdMarinatedFish.CurrentCell.RowIndex).Cells("FishSource").Value
            DateTimePicker1.Value = grdMarinatedFish.Rows(grdMarinatedFish.CurrentCell.RowIndex).Cells("TDate").Value
            cmbUnits.SelectedValue = grdMarinatedFish.Rows(grdMarinatedFish.CurrentCell.RowIndex).Cells("PUnit").Value
            If grdMarinatedFish.Columns(e.ColumnIndex).Name = "Edit" Then
                txtQuantity.Tag = grdMarinatedFish.Rows(e.RowIndex).Cells("ID").Value
                curr_rowIndex = grdMarinatedFish.CurrentRow.Index
                EditMode(True)

            End If
            If grdMarinatedFish.Columns(e.ColumnIndex).Name = "Delete" Then
                If DefaultLanguage = "English" Then
                    msgboxres = MessageBox.Show(Me, "Are you sure to delete?", "Confirm Delete", MessageBoxButtons.YesNo)
                Else
                    msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn xóa không?", "xác nhận xóa", MessageBoxButtons.YesNo)
                End If
                If msgboxres = DialogResult.Yes Then
                    curr_rowIndex = grdMarinatedFish.CurrentRow.Index
                    Dim tbladpt As New DataSet2TableAdapters.tblmarinatedfishTableAdapter
                    tbladpt.DeleteQuery(grdMarinatedFish.Rows(e.RowIndex).Cells("ID").Value)
                    GetAlldata()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddNewRecord()
        Try

            Dim tbladpt As New DataSet2TableAdapters.tblmarinatedfishTableAdapter
            tbladpt.InsertQuery(DateTimePicker1.Value, cmbFishType.SelectedValue, cmbEmployee.SelectedValue, cmbSourceFish.SelectedValue, GetFloatValue(txtQuantity.Text), DateTime.Now, DateTime.Now, usersDt.Rows(0)("ID"), usersDt.Rows(0)("ID"), cmbUnits.Text)
            GetAlldata()
        Catch ex As Exception

        End Try
    End Sub


    Private Function AlreadyExists() As Boolean
        Return False
    End Function
    Private Sub UpdateRecord()

        Try

            Dim tbladpt As New DataSet2TableAdapters.tblmarinatedfishTableAdapter
            tbladpt.UpdateQuery(DateTimePicker1.Value, cmbFishType.SelectedValue, cmbEmployee.SelectedValue, cmbSourceFish.SelectedValue, GetFloatValue(txtQuantity.Text), DateTime.Now, usersDt.Rows(0)("ID"), cmbUnits.Text, txtQuantity.Tag)
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
                MessageBox.Show(Me, "Record already exists.", "Exists", MessageBoxButtons.OK)
            Else
                MessageBox.Show(Me, "Thông tin đã được lưu", "Đã tồn tại", MessageBoxButtons.OK)
            End If
            Exit Sub
        End If
        If txtQuantity.Tag.ToString() = "" Then

            If DefaultLanguage = "English" Then
                msgboxres = MessageBox.Show(Me, "Do you want to save this record?", "Confirm Save", MessageBoxButtons.YesNo)
            Else
                msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn lưu?", "Xác nhận", MessageBoxButtons.YesNo)
            End If
            If msgboxres = DialogResult.Yes Then
                AddNewRecord()
            Else
                txtQuantity.Text = ""

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



            End If

            txtQuantity.Tag = ""
        End If
        EditMode(False)
        GroupBox1.Visible = True
    End Sub

    Private Function DataValidated() As Boolean
        If txtQuantity.Text.Length = 0 Then
            If DefaultLanguage = "English" Then
                MessageBox.Show(Me, "Quantity cannot be empty.", "Required Filed Validation")
            Else
                MessageBox.Show(Me, "Xin vui lòng nhập số lượng", "Trường bắt buộc")
            End If
            Return False
        End If
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
        If cmbSourceFish.SelectedIndex = -1 Then
            If DefaultLanguage = "English" Then
                MessageBox.Show(Me, "Fish Source cannot be empty.", "Required Filed Validation")
            Else
                MessageBox.Show(Me, "Xin vui lòng chọn nguồn cá", "Trường bắt buộc")
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
        Return True
    End Function

    Private Sub grdMarinatedFish_SelectionChanged(sender As Object, e As EventArgs) Handles grdMarinatedFish.SelectionChanged
        Try
            If btnCancel.Visible = True Then
                Exit Sub
            End If
            txtQuantity.Text = grdMarinatedFish.Rows(grdMarinatedFish.CurrentCell.RowIndex).Cells("Quantity").Value
            cmbEmployee.SelectedValue = grdMarinatedFish.Rows(grdMarinatedFish.CurrentCell.RowIndex).Cells("Employee").Value
            cmbFishType.SelectedValue = grdMarinatedFish.Rows(grdMarinatedFish.CurrentCell.RowIndex).Cells("FishType").Value
            cmbSourceFish.SelectedValue = grdMarinatedFish.Rows(grdMarinatedFish.CurrentCell.RowIndex).Cells("FishSource").Value
            DateTimePicker1.Value = grdMarinatedFish.Rows(grdMarinatedFish.CurrentCell.RowIndex).Cells("TDate").Value
            cmbUnits.SelectedValue = grdMarinatedFish.Rows(grdMarinatedFish.CurrentCell.RowIndex).Cells("PUnit").Value
            GetTotalQtybyFishType()
        Catch ex As Exception
            g_ShowError(ex)
        End Try
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not e.KeyChar = "," Then
            e.Handled = True
        End If
    End Sub
    Public Sub GetTotalQtybyFishType()

        Try

            Dim qry As String = "SELECT  (SELECT ROUND(IFNULL(SUM(Quantity), 0), 2) FROM tblmarinatedfish WHERE fishtype=" & cmbFishType.SelectedValue & " AND Date(TDate)<=Date('" & dpHistory.Value.ToString("yyyy-MM-dd") & "') )-(SELECT ROUND(IFNULL(SUM(TotalWeight), 0), 2) FROM tbllogwork WHERE fishtype=" & cmbFishType.SelectedValue & " AND Date(TDate)<=Date('" & dpHistory.Value.ToString("yyyy-MM-dd") & "') AND jobtype=(SELECT ID FROM tblJob WHERE  Jobname='PHOI_CA')) AS QtyRemaining"
            Dim con As New MySql.Data.MySqlClient.MySqlConnection(g_connStr)
            Dim dtadpt As New MySql.Data.MySqlClient.MySqlDataAdapter(qry, con)
            Dim dt As New DataTable
            dtadpt.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtRemainingQty.Text = dt.Rows(0)("QtyRemaining")
            Else
                txtRemainingQty.Text = ""
            End If

        Catch ex As Exception
            g_ShowError(ex)
        End Try

    End Sub

    Private Sub dpHistory_ValueChanged(sender As Object, e As EventArgs) Handles dpHistory.ValueChanged
        Try
            If cmbFishType.SelectedIndex > -1 Then
                GetTotalQtybyFishType()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbEmployee_Leave(sender As Object, e As EventArgs) Handles cmbSourceFish.Leave, cmbFishType.Leave, cmbEmployee.Leave
        Dim cmb As ComboBox = TryCast(sender, ComboBox)
        Dim index As Integer = cmb.FindString(cmb.Text)

        If index < 0 Then
            cmb.SelectedIndex = 0
            cmb.Focus()
            Return
        End If
    End Sub
    Private Sub cmbFishType_DropDown(sender As Object, e As EventArgs) Handles cmbFishType.DropDown, cmbEmployee.DropDown, cmbSourceFish.DropDown, cmbUnits.DropDown
        Dim cbo As ComboBox = CType(sender, ComboBox)
        AddHandler cbo.PreviewKeyDown, AddressOf comboBox_PreviewKeyDown
    End Sub
    Private Sub comboBox_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        Dim cbo As ComboBox = CType(sender, ComboBox)
        RemoveHandler cbo.PreviewKeyDown, AddressOf comboBox_PreviewKeyDown
        If cbo.DroppedDown Then cbo.Focus()
    End Sub

End Class