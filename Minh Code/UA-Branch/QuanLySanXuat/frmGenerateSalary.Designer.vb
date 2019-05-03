<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerateSalary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerateSalary))
        Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.dtToDate = New System.Windows.Forms.DateTimePicker()
        Me.lblToDate = New System.Windows.Forms.Label()
        Me.lblEmployee = New System.Windows.Forms.Label()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.grdSalary = New System.Windows.Forms.DataGridView()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbEmpType = New System.Windows.Forms.ComboBox()
        Me.grdEmployee = New System.Windows.Forms.DataGridView()
        Me.chkSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.empName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Responsibilty = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Deduction = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.chkSelectAll = New System.Windows.Forms.CheckBox()
        CType(Me.grdSalary,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.grdEmployee,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'dtFromDate
        '
        Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        resources.ApplyResources(Me.dtFromDate, "dtFromDate")
        Me.dtFromDate.Name = "dtFromDate"
        '
        'lblFromDate
        '
        resources.ApplyResources(Me.lblFromDate, "lblFromDate")
        Me.lblFromDate.Name = "lblFromDate"
        '
        'dtToDate
        '
        Me.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        resources.ApplyResources(Me.dtToDate, "dtToDate")
        Me.dtToDate.Name = "dtToDate"
        '
        'lblToDate
        '
        resources.ApplyResources(Me.lblToDate, "lblToDate")
        Me.lblToDate.Name = "lblToDate"
        '
        'lblEmployee
        '
        resources.ApplyResources(Me.lblEmployee, "lblEmployee")
        Me.lblEmployee.Name = "lblEmployee"
        '
        'btnGenerate
        '
        resources.ApplyResources(Me.btnGenerate, "btnGenerate")
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.UseVisualStyleBackColor = true
        '
        'grdSalary
        '
        Me.grdSalary.AllowUserToAddRows = false
        Me.grdSalary.AllowUserToDeleteRows = false
        Me.grdSalary.AllowUserToResizeRows = false
        resources.ApplyResources(Me.grdSalary, "grdSalary")
        Me.grdSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSalary.Name = "grdSalary"
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.Name = "btnExport"
        Me.btnExport.UseVisualStyleBackColor = true
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cmbEmpType
        '
        Me.cmbEmpType.FormattingEnabled = true
        Me.cmbEmpType.Items.AddRange(New Object() {resources.GetString("cmbEmpType.Items"), resources.GetString("cmbEmpType.Items1")})
        resources.ApplyResources(Me.cmbEmpType, "cmbEmpType")
        Me.cmbEmpType.Name = "cmbEmpType"
        '
        'grdEmployee
        '
        Me.grdEmployee.AllowUserToAddRows = false
        Me.grdEmployee.AllowUserToDeleteRows = false
        Me.grdEmployee.AllowUserToResizeRows = false
        Me.grdEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdEmployee.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkSelected, Me.ID, Me.empName, Me.Responsibilty, Me.Deduction})
        resources.ApplyResources(Me.grdEmployee, "grdEmployee")
        Me.grdEmployee.Name = "grdEmployee"
        Me.grdEmployee.RowHeadersVisible = false
        '
        'chkSelected
        '
        Me.chkSelected.DataPropertyName = "ischecked"
        resources.ApplyResources(Me.chkSelected, "chkSelected")
        Me.chkSelected.Name = "chkSelected"
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        resources.ApplyResources(Me.ID, "ID")
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = true
        Me.ID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'empName
        '
        Me.empName.DataPropertyName = "empName"
        resources.ApplyResources(Me.empName, "empName")
        Me.empName.Name = "empName"
        Me.empName.ReadOnly = true
        '
        'Responsibilty
        '
        Me.Responsibilty.DataPropertyName = "Responsibilty"
        resources.ApplyResources(Me.Responsibilty, "Responsibilty")
        Me.Responsibilty.Name = "Responsibilty"
        Me.Responsibilty.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Responsibilty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Deduction
        '
        Me.Deduction.DataPropertyName = "Deduction"
        resources.ApplyResources(Me.Deduction, "Deduction")
        Me.Deduction.Name = "Deduction"
        Me.Deduction.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Deduction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'chkSelectAll
        '
        resources.ApplyResources(Me.chkSelectAll, "chkSelectAll")
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.UseVisualStyleBackColor = true
        '
        'frmGenerateSalary
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkSelectAll)
        Me.Controls.Add(Me.grdEmployee)
        Me.Controls.Add(Me.cmbEmpType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.grdSalary)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.lblEmployee)
        Me.Controls.Add(Me.dtToDate)
        Me.Controls.Add(Me.lblToDate)
        Me.Controls.Add(Me.dtFromDate)
        Me.Controls.Add(Me.lblFromDate)
        Me.Name = "frmGenerateSalary"
        CType(Me.grdSalary,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grdEmployee,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents dtFromDate As DateTimePicker
    Friend WithEvents lblFromDate As Label
    Friend WithEvents dtToDate As DateTimePicker
    Friend WithEvents lblToDate As Label
    Friend WithEvents lblEmployee As Label
    Friend WithEvents btnGenerate As Button
    Friend WithEvents grdSalary As DataGridView
    Friend WithEvents btnExport As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbEmpType As ComboBox
    Friend WithEvents grdEmployee As DataGridView
    Friend WithEvents chkSelectAll As CheckBox
    Friend WithEvents chkSelected As DataGridViewCheckBoxColumn
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents empName As DataGridViewTextBoxColumn
    Friend WithEvents Responsibilty As DataGridViewCheckBoxColumn
    Friend WithEvents Deduction As DataGridViewComboBoxColumn
End Class
