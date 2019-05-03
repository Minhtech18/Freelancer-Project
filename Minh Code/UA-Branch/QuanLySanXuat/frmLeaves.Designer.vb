<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeaves
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLeaves))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grdLeaves = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.empName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeaveDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Employee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.advNotify = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cmbEmployee = New System.Windows.Forms.ComboBox()
        Me.lblEmployee = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.chkAdvancenotice = New System.Windows.Forms.CheckBox()
        CType(Me.grdLeaves,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'grdLeaves
        '
        resources.ApplyResources(Me.grdLeaves, "grdLeaves")
        Me.grdLeaves.AllowUserToAddRows = false
        Me.grdLeaves.AllowUserToDeleteRows = false
        Me.grdLeaves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdLeaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdLeaves.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.empName, Me.LeaveDate, Me.Employee, Me.Reason, Me.advNotify, Me.Edit, Me.Delete})
        Me.grdLeaves.Name = "grdLeaves"
        Me.grdLeaves.ReadOnly = true
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        resources.ApplyResources(Me.id, "id")
        Me.id.Name = "id"
        Me.id.ReadOnly = true
        '
        'empName
        '
        Me.empName.DataPropertyName = "empName"
        Me.empName.FillWeight = 139.8443!
        resources.ApplyResources(Me.empName, "empName")
        Me.empName.Name = "empName"
        Me.empName.ReadOnly = true
        '
        'LeaveDate
        '
        Me.LeaveDate.DataPropertyName = "LeaveDate"
        DataGridViewCellStyle1.Format = "dd-MM-yyyy"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.LeaveDate.DefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.LeaveDate, "LeaveDate")
        Me.LeaveDate.Name = "LeaveDate"
        Me.LeaveDate.ReadOnly = true
        '
        'Employee
        '
        Me.Employee.DataPropertyName = "Employee"
        resources.ApplyResources(Me.Employee, "Employee")
        Me.Employee.Name = "Employee"
        Me.Employee.ReadOnly = true
        '
        'Reason
        '
        Me.Reason.DataPropertyName = "Reason"
        resources.ApplyResources(Me.Reason, "Reason")
        Me.Reason.Name = "Reason"
        Me.Reason.ReadOnly = true
        '
        'advNotify
        '
        Me.advNotify.DataPropertyName = "advNotify"
        resources.ApplyResources(Me.advNotify, "advNotify")
        Me.advNotify.Name = "advNotify"
        Me.advNotify.ReadOnly = true
        '
        'Edit
        '
        Me.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        resources.ApplyResources(Me.Edit, "Edit")
        Me.Edit.Image = Global.QuanLySanXuat.My.Resources.Resources.pen_paper_2_5121
        Me.Edit.Name = "Edit"
        Me.Edit.ReadOnly = true
        Me.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Delete
        '
        Me.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        resources.ApplyResources(Me.Delete, "Delete")
        Me.Delete.Image = Global.QuanLySanXuat.My.Resources.Resources.del
        Me.Delete.Name = "Delete"
        Me.Delete.ReadOnly = true
        Me.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
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
        'cmbEmployee
        '
        resources.ApplyResources(Me.cmbEmployee, "cmbEmployee")
        Me.cmbEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEmployee.FormattingEnabled = true
        Me.cmbEmployee.Name = "cmbEmployee"
        '
        'lblEmployee
        '
        resources.ApplyResources(Me.lblEmployee, "lblEmployee")
        Me.lblEmployee.Name = "lblEmployee"
        '
        'DateTimePicker1
        '
        resources.ApplyResources(Me.DateTimePicker1, "DateTimePicker1")
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Name = "DateTimePicker1"
        '
        'lblDate
        '
        resources.ApplyResources(Me.lblDate, "lblDate")
        Me.lblDate.Name = "lblDate"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtReason
        '
        resources.ApplyResources(Me.txtReason, "txtReason")
        Me.txtReason.Name = "txtReason"
        '
        'chkAll
        '
        resources.ApplyResources(Me.chkAll, "chkAll")
        Me.chkAll.Name = "chkAll"
        Me.chkAll.UseVisualStyleBackColor = true
        '
        'chkAdvancenotice
        '
        resources.ApplyResources(Me.chkAdvancenotice, "chkAdvancenotice")
        Me.chkAdvancenotice.Name = "chkAdvancenotice"
        Me.chkAdvancenotice.UseVisualStyleBackColor = true
        '
        'frmLeaves
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkAdvancenotice)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbEmployee)
        Me.Controls.Add(Me.lblEmployee)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.grdLeaves)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmLeaves"
        CType(Me.grdLeaves,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents grdLeaves As DataGridView
    Friend WithEvents btnNew As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents cmbEmployee As ComboBox
    Friend WithEvents lblEmployee As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents lblDate As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtReason As TextBox
    Friend WithEvents chkAll As CheckBox
    Friend WithEvents chkAdvancenotice As CheckBox
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents empName As DataGridViewTextBoxColumn
    Friend WithEvents LeaveDate As DataGridViewTextBoxColumn
    Friend WithEvents Employee As DataGridViewTextBoxColumn
    Friend WithEvents Reason As DataGridViewTextBoxColumn
    Friend WithEvents advNotify As DataGridViewCheckBoxColumn
    Friend WithEvents Edit As DataGridViewImageColumn
    Friend WithEvents Delete As DataGridViewImageColumn
End Class
