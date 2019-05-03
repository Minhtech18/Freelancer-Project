Imports System.Globalization
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployee
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployee))
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblEmployeeName = New System.Windows.Forms.Label()
        Me.txtEmpName = New System.Windows.Forms.TextBox()
        Me.lblemployeeTypeS = New System.Windows.Forms.Label()
        Me.cmbEmpType = New System.Windows.Forms.ComboBox()
        Me.lblAllowence = New System.Windows.Forms.Label()
        Me.txtOTherAllownce = New System.Windows.Forms.TextBox()
        Me.lblDOB = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBasicSalary = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPhoneAllownce = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFerryAllownce = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMealAllownce = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtResponsibilityAllownce = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOtherAllownceReason = New System.Windows.Forms.TextBox()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grdEmployee = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.empName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.empType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HireDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BasicSalary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PhoneAllowance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FerryAllowance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MealAllowance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ResponsibilityAllowance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PersistanceandHardworkAllowance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtherAllowance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtherAllowanceReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.isActive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.dtpDOB = New System.Windows.Forms.DateTimePicker()
        Me.dtpDOH = New System.Windows.Forms.DateTimePicker()
        Me.lblHiringDate = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtHardwork = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTotalSalary = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.dtEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.btnApplyFilters = New System.Windows.Forms.Button()
        Me.btnRestoreDefaults = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbShowAll = New System.Windows.Forms.RadioButton()
        Me.rbAllFilters = New System.Windows.Forms.RadioButton()
        Me.cmbsearchEmpType = New System.Windows.Forms.ComboBox()
        Me.cmbsearchEmp = New System.Windows.Forms.ComboBox()
        Me.lblEmployeeS = New System.Windows.Forms.Label()
        Me.lblEmpType = New System.Windows.Forms.Label()
        CType(Me.grdEmployee,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox1.SuspendLayout
        Me.grpSearch.SuspendLayout
        Me.Panel1.SuspendLayout
        Me.SuspendLayout
        '
        'lblEmployeeName
        '
        resources.ApplyResources(Me.lblEmployeeName, "lblEmployeeName")
        Me.lblEmployeeName.Name = "lblEmployeeName"
        '
        'txtEmpName
        '
        resources.ApplyResources(Me.txtEmpName, "txtEmpName")
        Me.txtEmpName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtEmpName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtEmpName.Name = "txtEmpName"
        '
        'lblemployeeTypeS
        '
        resources.ApplyResources(Me.lblemployeeTypeS, "lblemployeeTypeS")
        Me.lblemployeeTypeS.ForeColor = System.Drawing.Color.Black
        Me.lblemployeeTypeS.Name = "lblemployeeTypeS"
        '
        'cmbEmpType
        '
        resources.ApplyResources(Me.cmbEmpType, "cmbEmpType")
        Me.cmbEmpType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEmpType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEmpType.FormattingEnabled = true
        Me.cmbEmpType.Items.AddRange(New Object() {resources.GetString("cmbEmpType.Items"), resources.GetString("cmbEmpType.Items1")})
        Me.cmbEmpType.Name = "cmbEmpType"
        '
        'lblAllowence
        '
        resources.ApplyResources(Me.lblAllowence, "lblAllowence")
        Me.lblAllowence.Name = "lblAllowence"
        '
        'txtOTherAllownce
        '
        resources.ApplyResources(Me.txtOTherAllownce, "txtOTherAllownce")
        Me.txtOTherAllownce.Name = "txtOTherAllownce"
        '
        'lblDOB
        '
        resources.ApplyResources(Me.lblDOB, "lblDOB")
        Me.lblDOB.Name = "lblDOB"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'txtBasicSalary
        '
        resources.ApplyResources(Me.txtBasicSalary, "txtBasicSalary")
        Me.txtBasicSalary.Name = "txtBasicSalary"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtPhoneAllownce
        '
        resources.ApplyResources(Me.txtPhoneAllownce, "txtPhoneAllownce")
        Me.txtPhoneAllownce.Name = "txtPhoneAllownce"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'txtFerryAllownce
        '
        resources.ApplyResources(Me.txtFerryAllownce, "txtFerryAllownce")
        Me.txtFerryAllownce.Name = "txtFerryAllownce"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'txtMealAllownce
        '
        resources.ApplyResources(Me.txtMealAllownce, "txtMealAllownce")
        Me.txtMealAllownce.Name = "txtMealAllownce"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'txtResponsibilityAllownce
        '
        resources.ApplyResources(Me.txtResponsibilityAllownce, "txtResponsibilityAllownce")
        Me.txtResponsibilityAllownce.Name = "txtResponsibilityAllownce"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'txtOtherAllownceReason
        '
        resources.ApplyResources(Me.txtOtherAllownceReason, "txtOtherAllownceReason")
        Me.txtOtherAllownceReason.Name = "txtOtherAllownceReason"
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
        'grdEmployee
        '
        resources.ApplyResources(Me.grdEmployee, "grdEmployee")
        Me.grdEmployee.AllowUserToAddRows = false
        Me.grdEmployee.AllowUserToDeleteRows = false
        Me.grdEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdEmployee.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.grdEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdEmployee.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.empName, Me.empType, Me.HireDate, Me.DOB, Me.EndDate, Me.BasicSalary, Me.PhoneAllowance, Me.FerryAllowance, Me.MealAllowance, Me.ResponsibilityAllowance, Me.PersistanceandHardworkAllowance, Me.OtherAllowance, Me.OtherAllowanceReason, Me.isActive, Me.Edit, Me.Delete})
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdEmployee.DefaultCellStyle = DataGridViewCellStyle25
        Me.grdEmployee.Name = "grdEmployee"
        Me.grdEmployee.ReadOnly = true
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdEmployee.RowHeadersDefaultCellStyle = DataGridViewCellStyle26
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
        Me.empName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.empName.DataPropertyName = "empName"
        Me.empName.FillWeight = 557.4423!
        resources.ApplyResources(Me.empName, "empName")
        Me.empName.Name = "empName"
        Me.empName.ReadOnly = true
        '
        'empType
        '
        Me.empType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.empType.DataPropertyName = "empType"
        Me.empType.FillWeight = 17.49452!
        resources.ApplyResources(Me.empType, "empType")
        Me.empType.Name = "empType"
        Me.empType.ReadOnly = true
        '
        'HireDate
        '
        Me.HireDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.HireDate.DataPropertyName = "HireDate"
        DataGridViewCellStyle15.Format = "dd-MM-yyyy"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.HireDate.DefaultCellStyle = DataGridViewCellStyle15
        Me.HireDate.FillWeight = 342.4458!
        resources.ApplyResources(Me.HireDate, "HireDate")
        Me.HireDate.Name = "HireDate"
        Me.HireDate.ReadOnly = true
        '
        'DOB
        '
        Me.DOB.DataPropertyName = "DOB"
        DataGridViewCellStyle16.Format = "dd-MM-yyyy"
        Me.DOB.DefaultCellStyle = DataGridViewCellStyle16
        resources.ApplyResources(Me.DOB, "DOB")
        Me.DOB.Name = "DOB"
        Me.DOB.ReadOnly = true
        '
        'EndDate
        '
        Me.EndDate.DataPropertyName = "EndDate"
        DataGridViewCellStyle17.Format = "dd-MM-yyyy"
        Me.EndDate.DefaultCellStyle = DataGridViewCellStyle17
        resources.ApplyResources(Me.EndDate, "EndDate")
        Me.EndDate.Name = "EndDate"
        Me.EndDate.ReadOnly = true
        '
        'BasicSalary
        '
        Me.BasicSalary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.BasicSalary.DataPropertyName = "BasicSalary"
        DataGridViewCellStyle18.Format = "N0"
        DataGridViewCellStyle18.NullValue = Nothing
        Me.BasicSalary.DefaultCellStyle = DataGridViewCellStyle18
        Me.BasicSalary.FillWeight = 17.49452!
        resources.ApplyResources(Me.BasicSalary, "BasicSalary")
        Me.BasicSalary.Name = "BasicSalary"
        Me.BasicSalary.ReadOnly = true
        '
        'PhoneAllowance
        '
        Me.PhoneAllowance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PhoneAllowance.DataPropertyName = "PhoneAllowance"
        DataGridViewCellStyle19.Format = "N0"
        DataGridViewCellStyle19.NullValue = Nothing
        Me.PhoneAllowance.DefaultCellStyle = DataGridViewCellStyle19
        Me.PhoneAllowance.FillWeight = 17.49452!
        resources.ApplyResources(Me.PhoneAllowance, "PhoneAllowance")
        Me.PhoneAllowance.Name = "PhoneAllowance"
        Me.PhoneAllowance.ReadOnly = true
        '
        'FerryAllowance
        '
        Me.FerryAllowance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.FerryAllowance.DataPropertyName = "FerryAllowance"
        DataGridViewCellStyle20.Format = "N0"
        DataGridViewCellStyle20.NullValue = Nothing
        Me.FerryAllowance.DefaultCellStyle = DataGridViewCellStyle20
        Me.FerryAllowance.FillWeight = 17.49452!
        resources.ApplyResources(Me.FerryAllowance, "FerryAllowance")
        Me.FerryAllowance.Name = "FerryAllowance"
        Me.FerryAllowance.ReadOnly = true
        '
        'MealAllowance
        '
        Me.MealAllowance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.MealAllowance.DataPropertyName = "MealAllowance"
        DataGridViewCellStyle21.Format = "N0"
        Me.MealAllowance.DefaultCellStyle = DataGridViewCellStyle21
        Me.MealAllowance.FillWeight = 17.49452!
        resources.ApplyResources(Me.MealAllowance, "MealAllowance")
        Me.MealAllowance.Name = "MealAllowance"
        Me.MealAllowance.ReadOnly = true
        '
        'ResponsibilityAllowance
        '
        Me.ResponsibilityAllowance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ResponsibilityAllowance.DataPropertyName = "ResponsibilityAllowance"
        DataGridViewCellStyle22.Format = "N0"
        Me.ResponsibilityAllowance.DefaultCellStyle = DataGridViewCellStyle22
        Me.ResponsibilityAllowance.FillWeight = 17.49452!
        resources.ApplyResources(Me.ResponsibilityAllowance, "ResponsibilityAllowance")
        Me.ResponsibilityAllowance.Name = "ResponsibilityAllowance"
        Me.ResponsibilityAllowance.ReadOnly = true
        '
        'PersistanceandHardworkAllowance
        '
        Me.PersistanceandHardworkAllowance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PersistanceandHardworkAllowance.DataPropertyName = "PersistanceandHardworkAllowance"
        DataGridViewCellStyle23.Format = "N0"
        Me.PersistanceandHardworkAllowance.DefaultCellStyle = DataGridViewCellStyle23
        resources.ApplyResources(Me.PersistanceandHardworkAllowance, "PersistanceandHardworkAllowance")
        Me.PersistanceandHardworkAllowance.Name = "PersistanceandHardworkAllowance"
        Me.PersistanceandHardworkAllowance.ReadOnly = true
        '
        'OtherAllowance
        '
        Me.OtherAllowance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.OtherAllowance.DataPropertyName = "OtherAllowance"
        DataGridViewCellStyle24.Format = "N0"
        Me.OtherAllowance.DefaultCellStyle = DataGridViewCellStyle24
        Me.OtherAllowance.FillWeight = 17.49452!
        resources.ApplyResources(Me.OtherAllowance, "OtherAllowance")
        Me.OtherAllowance.Name = "OtherAllowance"
        Me.OtherAllowance.ReadOnly = true
        '
        'OtherAllowanceReason
        '
        Me.OtherAllowanceReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.OtherAllowanceReason.DataPropertyName = "OtherAllowanceReason"
        Me.OtherAllowanceReason.FillWeight = 17.49452!
        resources.ApplyResources(Me.OtherAllowanceReason, "OtherAllowanceReason")
        Me.OtherAllowanceReason.Name = "OtherAllowanceReason"
        Me.OtherAllowanceReason.ReadOnly = true
        '
        'isActive
        '
        Me.isActive.DataPropertyName = "isActive"
        resources.ApplyResources(Me.isActive, "isActive")
        Me.isActive.Name = "isActive"
        Me.isActive.ReadOnly = true
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
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        '
        'dtpDOB
        '
        resources.ApplyResources(Me.dtpDOB, "dtpDOB")
        Me.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDOB.Name = "dtpDOB"
        '
        'dtpDOH
        '
        resources.ApplyResources(Me.dtpDOH, "dtpDOH")
        Me.dtpDOH.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDOH.Name = "dtpDOH"
        '
        'lblHiringDate
        '
        resources.ApplyResources(Me.lblHiringDate, "lblHiringDate")
        Me.lblHiringDate.Name = "lblHiringDate"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.txtHardwork)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.lblTotalSalary)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtFerryAllownce)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtResponsibilityAllownce)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtPhoneAllownce)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtMealAllownce)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtOTherAllownce)
        Me.GroupBox1.Controls.Add(Me.txtOtherAllownceReason)
        Me.GroupBox1.Controls.Add(Me.txtBasicSalary)
        Me.GroupBox1.Controls.Add(Me.lblAllowence)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = false
        '
        'txtHardwork
        '
        resources.ApplyResources(Me.txtHardwork, "txtHardwork")
        Me.txtHardwork.Name = "txtHardwork"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'lblTotalSalary
        '
        resources.ApplyResources(Me.lblTotalSalary, "lblTotalSalary")
        Me.lblTotalSalary.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblTotalSalary.Name = "lblTotalSalary"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'chkIsActive
        '
        resources.ApplyResources(Me.chkIsActive, "chkIsActive")
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.UseVisualStyleBackColor = true
        '
        'dtEndDate
        '
        resources.ApplyResources(Me.dtEndDate, "dtEndDate")
        Me.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEndDate.Name = "dtEndDate"
        '
        'lblEndDate
        '
        resources.ApplyResources(Me.lblEndDate, "lblEndDate")
        Me.lblEndDate.Name = "lblEndDate"
        '
        'grpSearch
        '
        resources.ApplyResources(Me.grpSearch, "grpSearch")
        Me.grpSearch.Controls.Add(Me.btnApplyFilters)
        Me.grpSearch.Controls.Add(Me.btnRestoreDefaults)
        Me.grpSearch.Controls.Add(Me.Panel1)
        Me.grpSearch.Controls.Add(Me.cmbsearchEmpType)
        Me.grpSearch.Controls.Add(Me.cmbsearchEmp)
        Me.grpSearch.Controls.Add(Me.lblEmployeeS)
        Me.grpSearch.Controls.Add(Me.lblemployeeTypeS)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.TabStop = false
        '
        'btnApplyFilters
        '
        resources.ApplyResources(Me.btnApplyFilters, "btnApplyFilters")
        Me.btnApplyFilters.Name = "btnApplyFilters"
        Me.btnApplyFilters.UseVisualStyleBackColor = true
        '
        'btnRestoreDefaults
        '
        resources.ApplyResources(Me.btnRestoreDefaults, "btnRestoreDefaults")
        Me.btnRestoreDefaults.Name = "btnRestoreDefaults"
        Me.btnRestoreDefaults.UseVisualStyleBackColor = true
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Controls.Add(Me.rbShowAll)
        Me.Panel1.Controls.Add(Me.rbAllFilters)
        Me.Panel1.Name = "Panel1"
        '
        'rbShowAll
        '
        resources.ApplyResources(Me.rbShowAll, "rbShowAll")
        Me.rbShowAll.Checked = true
        Me.rbShowAll.Name = "rbShowAll"
        Me.rbShowAll.TabStop = true
        Me.rbShowAll.UseVisualStyleBackColor = true
        '
        'rbAllFilters
        '
        resources.ApplyResources(Me.rbAllFilters, "rbAllFilters")
        Me.rbAllFilters.Name = "rbAllFilters"
        Me.rbAllFilters.UseVisualStyleBackColor = true
        '
        'cmbsearchEmpType
        '
        resources.ApplyResources(Me.cmbsearchEmpType, "cmbsearchEmpType")
        Me.cmbsearchEmpType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbsearchEmpType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbsearchEmpType.FormattingEnabled = true
        Me.cmbsearchEmpType.Items.AddRange(New Object() {resources.GetString("cmbsearchEmpType.Items"), resources.GetString("cmbsearchEmpType.Items1")})
        Me.cmbsearchEmpType.Name = "cmbsearchEmpType"
        '
        'cmbsearchEmp
        '
        resources.ApplyResources(Me.cmbsearchEmp, "cmbsearchEmp")
        Me.cmbsearchEmp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbsearchEmp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbsearchEmp.FormattingEnabled = true
        Me.cmbsearchEmp.Name = "cmbsearchEmp"
        '
        'lblEmployeeS
        '
        resources.ApplyResources(Me.lblEmployeeS, "lblEmployeeS")
        Me.lblEmployeeS.ForeColor = System.Drawing.Color.Black
        Me.lblEmployeeS.Name = "lblEmployeeS"
        '
        'lblEmpType
        '
        resources.ApplyResources(Me.lblEmpType, "lblEmpType")
        Me.lblEmpType.Name = "lblEmpType"
        '
        'frmEmployee
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblEmpType)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.dtEndDate)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.chkIsActive)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtpDOH)
        Me.Controls.Add(Me.lblHiringDate)
        Me.Controls.Add(Me.dtpDOB)
        Me.Controls.Add(Me.grdEmployee)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblDOB)
        Me.Controls.Add(Me.cmbEmpType)
        Me.Controls.Add(Me.lblEmployeeName)
        Me.Controls.Add(Me.txtEmpName)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmEmployee"
        CType(Me.grdEmployee,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.grpSearch.ResumeLayout(false)
        Me.grpSearch.PerformLayout
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents lblEmployeeName As Label
    Friend WithEvents txtEmpName As TextBox
    Friend WithEvents lblemployeeTypeS As Label
    Friend WithEvents cmbEmpType As ComboBox
    Friend WithEvents lblAllowence As Label
    Friend WithEvents txtOTherAllownce As TextBox
    Friend WithEvents lblDOB As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBasicSalary As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPhoneAllownce As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtFerryAllownce As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtMealAllownce As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtResponsibilityAllownce As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtOtherAllownceReason As TextBox
    Friend WithEvents btnNew As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents grdEmployee As DataGridView
    Friend WithEvents btnCancel As Button
    Friend WithEvents dtpDOB As DateTimePicker
    Friend WithEvents dtpDOH As DateTimePicker
    Friend WithEvents lblHiringDate As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents lblTotalSalary As Label
    Friend WithEvents txtHardwork As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents chkIsActive As CheckBox
    Friend WithEvents dtEndDate As DateTimePicker
    Friend WithEvents lblEndDate As Label
    Friend WithEvents grpSearch As GroupBox
    Friend WithEvents btnApplyFilters As Button
    Friend WithEvents btnRestoreDefaults As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbAllFilters As RadioButton
    Friend WithEvents cmbsearchEmpType As ComboBox
    Friend WithEvents cmbsearchEmp As ComboBox
    Friend WithEvents lblEmployeeS As Label
    Friend WithEvents rbShowAll As RadioButton
    Friend WithEvents lblEmpType As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents empName As DataGridViewTextBoxColumn
    Friend WithEvents empType As DataGridViewTextBoxColumn
    Friend WithEvents HireDate As DataGridViewTextBoxColumn
    Friend WithEvents DOB As DataGridViewTextBoxColumn
    Friend WithEvents EndDate As DataGridViewTextBoxColumn
    Friend WithEvents BasicSalary As DataGridViewTextBoxColumn
    Friend WithEvents PhoneAllowance As DataGridViewTextBoxColumn
    Friend WithEvents FerryAllowance As DataGridViewTextBoxColumn
    Friend WithEvents MealAllowance As DataGridViewTextBoxColumn
    Friend WithEvents ResponsibilityAllowance As DataGridViewTextBoxColumn
    Friend WithEvents PersistanceandHardworkAllowance As DataGridViewTextBoxColumn
    Friend WithEvents OtherAllowance As DataGridViewTextBoxColumn
    Friend WithEvents OtherAllowanceReason As DataGridViewTextBoxColumn
    Friend WithEvents isActive As DataGridViewCheckBoxColumn
    Friend WithEvents Edit As DataGridViewImageColumn
    Friend WithEvents Delete As DataGridViewImageColumn
End Class
