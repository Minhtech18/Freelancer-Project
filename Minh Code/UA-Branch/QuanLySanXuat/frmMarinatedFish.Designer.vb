<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarinatedFish
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMarinatedFish))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblFishType = New System.Windows.Forms.Label()
        Me.cmbFishType = New System.Windows.Forms.ComboBox()
        Me.lblSourceFish = New System.Windows.Forms.Label()
        Me.cmbSourceFish = New System.Windows.Forms.ComboBox()
        Me.grdMarinatedFish = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.empName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FishName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SourceName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FishSource = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FishType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Employee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.cmbEmployee = New System.Windows.Forms.ComboBox()
        Me.lblEmployee = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtRemainingQty = New System.Windows.Forms.TextBox()
        Me.dpHistory = New System.Windows.Forms.DateTimePicker()
        Me.cmbUnits = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.grdMarinatedFish,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'lblFishType
        '
        resources.ApplyResources(Me.lblFishType, "lblFishType")
        Me.lblFishType.Name = "lblFishType"
        '
        'cmbFishType
        '
        Me.cmbFishType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFishType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFishType.FormattingEnabled = true
        resources.ApplyResources(Me.cmbFishType, "cmbFishType")
        Me.cmbFishType.Name = "cmbFishType"
        '
        'lblSourceFish
        '
        resources.ApplyResources(Me.lblSourceFish, "lblSourceFish")
        Me.lblSourceFish.Name = "lblSourceFish"
        '
        'cmbSourceFish
        '
        Me.cmbSourceFish.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSourceFish.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSourceFish.FormattingEnabled = true
        resources.ApplyResources(Me.cmbSourceFish, "cmbSourceFish")
        Me.cmbSourceFish.Name = "cmbSourceFish"
        '
        'grdMarinatedFish
        '
        Me.grdMarinatedFish.AllowUserToAddRows = false
        Me.grdMarinatedFish.AllowUserToDeleteRows = false
        resources.ApplyResources(Me.grdMarinatedFish, "grdMarinatedFish")
        Me.grdMarinatedFish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdMarinatedFish.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.TDate, Me.empName, Me.FishName, Me.SourceName, Me.Quantity, Me.PUnit, Me.FishSource, Me.FishType, Me.Employee, Me.Edit, Me.Delete})
        Me.grdMarinatedFish.Name = "grdMarinatedFish"
        Me.grdMarinatedFish.ReadOnly = true
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        resources.ApplyResources(Me.ID, "ID")
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = true
        '
        'TDate
        '
        Me.TDate.DataPropertyName = "TDate"
        DataGridViewCellStyle1.Format = "dd-MM-yyyy"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.TDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.TDate.FillWeight = 66.97935!
        resources.ApplyResources(Me.TDate, "TDate")
        Me.TDate.Name = "TDate"
        Me.TDate.ReadOnly = true
        '
        'empName
        '
        Me.empName.DataPropertyName = "empName"
        Me.empName.FillWeight = 66.97935!
        resources.ApplyResources(Me.empName, "empName")
        Me.empName.Name = "empName"
        Me.empName.ReadOnly = true
        '
        'FishName
        '
        Me.FishName.DataPropertyName = "FishName"
        Me.FishName.FillWeight = 66.97935!
        resources.ApplyResources(Me.FishName, "FishName")
        Me.FishName.Name = "FishName"
        Me.FishName.ReadOnly = true
        '
        'SourceName
        '
        Me.SourceName.DataPropertyName = "SourceName"
        Me.SourceName.FillWeight = 66.97935!
        resources.ApplyResources(Me.SourceName, "SourceName")
        Me.SourceName.Name = "SourceName"
        Me.SourceName.ReadOnly = true
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "Quantity"
        Me.Quantity.FillWeight = 66.97935!
        resources.ApplyResources(Me.Quantity, "Quantity")
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = true
        '
        'PUnit
        '
        Me.PUnit.DataPropertyName = "PUnit"
        resources.ApplyResources(Me.PUnit, "PUnit")
        Me.PUnit.Name = "PUnit"
        Me.PUnit.ReadOnly = true
        '
        'FishSource
        '
        Me.FishSource.DataPropertyName = "FishSource"
        resources.ApplyResources(Me.FishSource, "FishSource")
        Me.FishSource.Name = "FishSource"
        Me.FishSource.ReadOnly = true
        '
        'FishType
        '
        Me.FishType.DataPropertyName = "FishType"
        resources.ApplyResources(Me.FishType, "FishType")
        Me.FishType.Name = "FishType"
        Me.FishType.ReadOnly = true
        '
        'Employee
        '
        Me.Employee.DataPropertyName = "Employee"
        resources.ApplyResources(Me.Employee, "Employee")
        Me.Employee.Name = "Employee"
        Me.Employee.ReadOnly = true
        '
        'Edit
        '
        resources.ApplyResources(Me.Edit, "Edit")
        Me.Edit.Image = Global.QuanLySanXuat.My.Resources.Resources.pen_paper_2_5121
        Me.Edit.Name = "Edit"
        Me.Edit.ReadOnly = true
        Me.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Delete
        '
        resources.ApplyResources(Me.Delete, "Delete")
        Me.Delete.Image = Global.QuanLySanXuat.My.Resources.Resources.del
        Me.Delete.Name = "Delete"
        Me.Delete.ReadOnly = true
        Me.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'lblDate
        '
        resources.ApplyResources(Me.lblDate, "lblDate")
        Me.lblDate.Name = "lblDate"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        resources.ApplyResources(Me.DateTimePicker1, "DateTimePicker1")
        Me.DateTimePicker1.Name = "DateTimePicker1"
        '
        'cmbEmployee
        '
        Me.cmbEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEmployee.FormattingEnabled = true
        resources.ApplyResources(Me.cmbEmployee, "cmbEmployee")
        Me.cmbEmployee.Name = "cmbEmployee"
        '
        'lblEmployee
        '
        resources.ApplyResources(Me.lblEmployee, "lblEmployee")
        Me.lblEmployee.Name = "lblEmployee"
        '
        'txtQuantity
        '
        resources.ApplyResources(Me.txtQuantity, "txtQuantity")
        Me.txtQuantity.Name = "txtQuantity"
        '
        'lblQuantity
        '
        resources.ApplyResources(Me.lblQuantity, "lblQuantity")
        Me.lblQuantity.Name = "lblQuantity"
        '
        'btnNew
        '
        resources.ApplyResources(Me.btnNew, "btnNew")
        Me.btnNew.Name = "btnNew"
        Me.btnNew.UseVisualStyleBackColor = true
        '
        'btnSave
        '
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.Name = "btnSave"
        Me.btnSave.UseVisualStyleBackColor = true
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtRemainingQty)
        Me.GroupBox1.Controls.Add(Me.dpHistory)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = false
        '
        'txtRemainingQty
        '
        resources.ApplyResources(Me.txtRemainingQty, "txtRemainingQty")
        Me.txtRemainingQty.Name = "txtRemainingQty"
        '
        'dpHistory
        '
        Me.dpHistory.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        resources.ApplyResources(Me.dpHistory, "dpHistory")
        Me.dpHistory.Name = "dpHistory"
        '
        'cmbUnits
        '
        Me.cmbUnits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbUnits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUnits.FormattingEnabled = true
        resources.ApplyResources(Me.cmbUnits, "cmbUnits")
        Me.cmbUnits.Name = "cmbUnits"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'frmMarinatedFish
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmbUnits)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.cmbEmployee)
        Me.Controls.Add(Me.lblEmployee)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.grdMarinatedFish)
        Me.Controls.Add(Me.cmbSourceFish)
        Me.Controls.Add(Me.lblSourceFish)
        Me.Controls.Add(Me.cmbFishType)
        Me.Controls.Add(Me.lblFishType)
        Me.Name = "frmMarinatedFish"
        CType(Me.grdMarinatedFish,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents lblFishType As Label
    Friend WithEvents cmbFishType As ComboBox
    Friend WithEvents lblSourceFish As Label
    Friend WithEvents cmbSourceFish As ComboBox
    Friend WithEvents grdMarinatedFish As DataGridView
    Friend WithEvents lblDate As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents cmbEmployee As ComboBox
    Friend WithEvents lblEmployee As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents lblQuantity As Label
    Friend WithEvents btnNew As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtRemainingQty As TextBox
    Friend WithEvents dpHistory As DateTimePicker
    Friend WithEvents cmbUnits As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents TDate As DataGridViewTextBoxColumn
    Friend WithEvents empName As DataGridViewTextBoxColumn
    Friend WithEvents FishName As DataGridViewTextBoxColumn
    Friend WithEvents SourceName As DataGridViewTextBoxColumn
    Friend WithEvents Quantity As DataGridViewTextBoxColumn
    Friend WithEvents PUnit As DataGridViewTextBoxColumn
    Friend WithEvents FishSource As DataGridViewTextBoxColumn
    Friend WithEvents FishType As DataGridViewTextBoxColumn
    Friend WithEvents Employee As DataGridViewTextBoxColumn
    Friend WithEvents Edit As DataGridViewImageColumn
    Friend WithEvents Delete As DataGridViewImageColumn
End Class
