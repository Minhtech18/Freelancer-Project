<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogWork
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogWork))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.cmbEmployee = New System.Windows.Forms.ComboBox()
        Me.lblEmployee = New System.Windows.Forms.Label()
        Me.lblJobType = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.txtTotalWeight = New System.Windows.Forms.TextBox()
        Me.lblTotalWeight = New System.Windows.Forms.Label()
        Me.lblMUnit = New System.Windows.Forms.Label()
        Me.cmbFishType = New System.Windows.Forms.ComboBox()
        Me.lblFishType = New System.Windows.Forms.Label()
        Me.txtRateperPack = New System.Windows.Forms.TextBox()
        Me.lblRateperPack = New System.Windows.Forms.Label()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.grdLogWork = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Employee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.empName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FishType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FishName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KCSID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KCS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FishPartition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rateperpack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Note = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtRemaining = New System.Windows.Forms.TextBox()
        Me.lblRemaining = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFishPartition = New System.Windows.Forms.TextBox()
        Me.lblTotalPartition = New System.Windows.Forms.Label()
        Me.grdPartitionFish = New System.Windows.Forms.DataGridView()
        Me.fishpart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtFishPartitionNew = New System.Windows.Forms.TextBox()
        Me.lblFishPartition = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblPackingStyle = New System.Windows.Forms.Label()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dtToDate = New System.Windows.Forms.DateTimePicker()
        Me.lblToDate = New System.Windows.Forms.Label()
        Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.lblFishName = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnRestoreDefaults = New System.Windows.Forms.Button()
        Me.cmbsearchEmp = New System.Windows.Forms.ComboBox()
        Me.cmbsearchFish = New System.Windows.Forms.ComboBox()
        Me.cmbsearchJob = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbCurrentMonth = New System.Windows.Forms.RadioButton()
        Me.rbShowAll = New System.Windows.Forms.RadioButton()
        Me.rbAllFilters = New System.Windows.Forms.RadioButton()
        Me.cmbKCS = New System.Windows.Forms.ComboBox()
        Me.lblKCS = New System.Windows.Forms.Label()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.btnApplyFilters = New System.Windows.Forms.Button()
        Me.cmbJobType = New System.Windows.Forms.ComboBox()
        CType(Me.grdLogWork,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.grdPartitionFish,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel1.SuspendLayout
        Me.grpSearch.SuspendLayout
        Me.SuspendLayout
        '
        'lblDate
        '
        resources.ApplyResources(Me.lblDate, "lblDate")
        Me.lblDate.Name = "lblDate"
        '
        'DateTimePicker1
        '
        resources.ApplyResources(Me.DateTimePicker1, "DateTimePicker1")
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Name = "DateTimePicker1"
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
        'lblJobType
        '
        resources.ApplyResources(Me.lblJobType, "lblJobType")
        Me.lblJobType.Name = "lblJobType"
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
        'txtTotalWeight
        '
        resources.ApplyResources(Me.txtTotalWeight, "txtTotalWeight")
        Me.txtTotalWeight.Name = "txtTotalWeight"
        Me.txtTotalWeight.ReadOnly = true
        '
        'lblTotalWeight
        '
        resources.ApplyResources(Me.lblTotalWeight, "lblTotalWeight")
        Me.lblTotalWeight.Name = "lblTotalWeight"
        '
        'lblMUnit
        '
        resources.ApplyResources(Me.lblMUnit, "lblMUnit")
        Me.lblMUnit.Name = "lblMUnit"
        '
        'cmbFishType
        '
        resources.ApplyResources(Me.cmbFishType, "cmbFishType")
        Me.cmbFishType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFishType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFishType.FormattingEnabled = true
        Me.cmbFishType.Name = "cmbFishType"
        '
        'lblFishType
        '
        resources.ApplyResources(Me.lblFishType, "lblFishType")
        Me.lblFishType.Name = "lblFishType"
        '
        'txtRateperPack
        '
        resources.ApplyResources(Me.txtRateperPack, "txtRateperPack")
        Me.txtRateperPack.Name = "txtRateperPack"
        Me.txtRateperPack.ReadOnly = true
        '
        'lblRateperPack
        '
        resources.ApplyResources(Me.lblRateperPack, "lblRateperPack")
        Me.lblRateperPack.Name = "lblRateperPack"
        '
        'txtTotalAmount
        '
        resources.ApplyResources(Me.txtTotalAmount, "txtTotalAmount")
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = true
        '
        'lblTotalAmount
        '
        resources.ApplyResources(Me.lblTotalAmount, "lblTotalAmount")
        Me.lblTotalAmount.Name = "lblTotalAmount"
        '
        'grdLogWork
        '
        resources.ApplyResources(Me.grdLogWork, "grdLogWork")
        Me.grdLogWork.AllowUserToAddRows = false
        Me.grdLogWork.AllowUserToDeleteRows = false
        Me.grdLogWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdLogWork.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.TDate, Me.Employee, Me.empName, Me.JobName, Me.JobType, Me.FishType, Me.FishName, Me.KCSID, Me.KCS, Me.Quantity, Me.FishPartition, Me.TotalWeight, Me.Rateperpack, Me.TotalAmount, Me.Note, Me.Edit, Me.Delete})
        Me.grdLogWork.Name = "grdLogWork"
        Me.grdLogWork.ReadOnly = true
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
        DataGridViewCellStyle6.Format = "dd-MM-yyyy"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.TDate.DefaultCellStyle = DataGridViewCellStyle6
        resources.ApplyResources(Me.TDate, "TDate")
        Me.TDate.Name = "TDate"
        Me.TDate.ReadOnly = true
        '
        'Employee
        '
        Me.Employee.DataPropertyName = "Employee"
        resources.ApplyResources(Me.Employee, "Employee")
        Me.Employee.Name = "Employee"
        Me.Employee.ReadOnly = true
        '
        'empName
        '
        Me.empName.DataPropertyName = "empName"
        resources.ApplyResources(Me.empName, "empName")
        Me.empName.Name = "empName"
        Me.empName.ReadOnly = true
        '
        'JobName
        '
        Me.JobName.DataPropertyName = "JobName"
        resources.ApplyResources(Me.JobName, "JobName")
        Me.JobName.Name = "JobName"
        Me.JobName.ReadOnly = true
        '
        'JobType
        '
        Me.JobType.DataPropertyName = "JobType"
        resources.ApplyResources(Me.JobType, "JobType")
        Me.JobType.Name = "JobType"
        Me.JobType.ReadOnly = true
        '
        'FishType
        '
        Me.FishType.DataPropertyName = "FishType"
        resources.ApplyResources(Me.FishType, "FishType")
        Me.FishType.Name = "FishType"
        Me.FishType.ReadOnly = true
        '
        'FishName
        '
        Me.FishName.DataPropertyName = "FishName"
        resources.ApplyResources(Me.FishName, "FishName")
        Me.FishName.Name = "FishName"
        Me.FishName.ReadOnly = true
        '
        'KCSID
        '
        Me.KCSID.DataPropertyName = "KCSID"
        resources.ApplyResources(Me.KCSID, "KCSID")
        Me.KCSID.Name = "KCSID"
        Me.KCSID.ReadOnly = true
        '
        'KCS
        '
        Me.KCS.DataPropertyName = "KCS"
        resources.ApplyResources(Me.KCS, "KCS")
        Me.KCS.Name = "KCS"
        Me.KCS.ReadOnly = true
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "Quantity"
        resources.ApplyResources(Me.Quantity, "Quantity")
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = true
        '
        'FishPartition
        '
        Me.FishPartition.DataPropertyName = "FishPartition"
        DataGridViewCellStyle7.Format = "N2"
        Me.FishPartition.DefaultCellStyle = DataGridViewCellStyle7
        resources.ApplyResources(Me.FishPartition, "FishPartition")
        Me.FishPartition.Name = "FishPartition"
        Me.FishPartition.ReadOnly = true
        '
        'TotalWeight
        '
        Me.TotalWeight.DataPropertyName = "TotalWeight"
        DataGridViewCellStyle8.Format = "N2"
        Me.TotalWeight.DefaultCellStyle = DataGridViewCellStyle8
        resources.ApplyResources(Me.TotalWeight, "TotalWeight")
        Me.TotalWeight.Name = "TotalWeight"
        Me.TotalWeight.ReadOnly = true
        '
        'Rateperpack
        '
        Me.Rateperpack.DataPropertyName = "RatePerPack"
        DataGridViewCellStyle9.Format = "N0"
        Me.Rateperpack.DefaultCellStyle = DataGridViewCellStyle9
        resources.ApplyResources(Me.Rateperpack, "Rateperpack")
        Me.Rateperpack.Name = "Rateperpack"
        Me.Rateperpack.ReadOnly = true
        '
        'TotalAmount
        '
        Me.TotalAmount.DataPropertyName = "TotalAmount"
        DataGridViewCellStyle10.Format = "N0"
        Me.TotalAmount.DefaultCellStyle = DataGridViewCellStyle10
        resources.ApplyResources(Me.TotalAmount, "TotalAmount")
        Me.TotalAmount.Name = "TotalAmount"
        Me.TotalAmount.ReadOnly = true
        '
        'Note
        '
        Me.Note.DataPropertyName = "Note"
        resources.ApplyResources(Me.Note, "Note")
        Me.Note.Name = "Note"
        Me.Note.ReadOnly = true
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
        'txtRemaining
        '
        resources.ApplyResources(Me.txtRemaining, "txtRemaining")
        Me.txtRemaining.Name = "txtRemaining"
        Me.txtRemaining.ReadOnly = true
        '
        'lblRemaining
        '
        resources.ApplyResources(Me.lblRemaining, "lblRemaining")
        Me.lblRemaining.Name = "lblRemaining"
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
        'txtNote
        '
        resources.ApplyResources(Me.txtNote, "txtNote")
        Me.txtNote.Name = "txtNote"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtFishPartition
        '
        resources.ApplyResources(Me.txtFishPartition, "txtFishPartition")
        Me.txtFishPartition.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFishPartition.ForeColor = System.Drawing.Color.Green
        Me.txtFishPartition.Name = "txtFishPartition"
        Me.txtFishPartition.ReadOnly = true
        '
        'lblTotalPartition
        '
        resources.ApplyResources(Me.lblTotalPartition, "lblTotalPartition")
        Me.lblTotalPartition.Name = "lblTotalPartition"
        '
        'grdPartitionFish
        '
        resources.ApplyResources(Me.grdPartitionFish, "grdPartitionFish")
        Me.grdPartitionFish.AllowUserToAddRows = false
        Me.grdPartitionFish.AllowUserToDeleteRows = false
        Me.grdPartitionFish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPartitionFish.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fishpart, Me.btnDelete})
        Me.grdPartitionFish.Name = "grdPartitionFish"
        Me.grdPartitionFish.ReadOnly = true
        Me.grdPartitionFish.RowHeadersVisible = false
        '
        'fishpart
        '
        resources.ApplyResources(Me.fishpart, "fishpart")
        Me.fishpart.Name = "fishpart"
        Me.fishpart.ReadOnly = true
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Image = Global.QuanLySanXuat.My.Resources.Resources.del
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.ReadOnly = true
        Me.btnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'txtFishPartitionNew
        '
        resources.ApplyResources(Me.txtFishPartitionNew, "txtFishPartitionNew")
        Me.txtFishPartitionNew.Name = "txtFishPartitionNew"
        '
        'lblFishPartition
        '
        resources.ApplyResources(Me.lblFishPartition, "lblFishPartition")
        Me.lblFishPartition.Name = "lblFishPartition"
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.UseVisualStyleBackColor = true
        '
        'lblPackingStyle
        '
        resources.ApplyResources(Me.lblPackingStyle, "lblPackingStyle")
        Me.lblPackingStyle.Name = "lblPackingStyle"
        '
        'DataGridViewImageColumn1
        '
        resources.ApplyResources(Me.DataGridViewImageColumn1, "DataGridViewImageColumn1")
        Me.DataGridViewImageColumn1.Image = Global.QuanLySanXuat.My.Resources.Resources.pen_paper_2_5121
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'DataGridViewImageColumn2
        '
        resources.ApplyResources(Me.DataGridViewImageColumn2, "DataGridViewImageColumn2")
        Me.DataGridViewImageColumn2.Image = Global.QuanLySanXuat.My.Resources.Resources.del
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'dtToDate
        '
        resources.ApplyResources(Me.dtToDate, "dtToDate")
        Me.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtToDate.Name = "dtToDate"
        '
        'lblToDate
        '
        resources.ApplyResources(Me.lblToDate, "lblToDate")
        Me.lblToDate.Name = "lblToDate"
        '
        'dtFromDate
        '
        resources.ApplyResources(Me.dtFromDate, "dtFromDate")
        Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFromDate.Name = "dtFromDate"
        '
        'lblFromDate
        '
        resources.ApplyResources(Me.lblFromDate, "lblFromDate")
        Me.lblFromDate.Name = "lblFromDate"
        '
        'lblFishName
        '
        resources.ApplyResources(Me.lblFishName, "lblFishName")
        Me.lblFishName.Name = "lblFishName"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'btnRestoreDefaults
        '
        resources.ApplyResources(Me.btnRestoreDefaults, "btnRestoreDefaults")
        Me.btnRestoreDefaults.Name = "btnRestoreDefaults"
        Me.btnRestoreDefaults.UseVisualStyleBackColor = true
        '
        'cmbsearchEmp
        '
        resources.ApplyResources(Me.cmbsearchEmp, "cmbsearchEmp")
        Me.cmbsearchEmp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbsearchEmp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbsearchEmp.FormattingEnabled = true
        Me.cmbsearchEmp.Name = "cmbsearchEmp"
        '
        'cmbsearchFish
        '
        resources.ApplyResources(Me.cmbsearchFish, "cmbsearchFish")
        Me.cmbsearchFish.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbsearchFish.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbsearchFish.FormattingEnabled = true
        Me.cmbsearchFish.Name = "cmbsearchFish"
        '
        'cmbsearchJob
        '
        resources.ApplyResources(Me.cmbsearchJob, "cmbsearchJob")
        Me.cmbsearchJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbsearchJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbsearchJob.FormattingEnabled = true
        Me.cmbsearchJob.Name = "cmbsearchJob"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Controls.Add(Me.rbCurrentMonth)
        Me.Panel1.Controls.Add(Me.rbShowAll)
        Me.Panel1.Controls.Add(Me.rbAllFilters)
        Me.Panel1.Name = "Panel1"
        '
        'rbCurrentMonth
        '
        resources.ApplyResources(Me.rbCurrentMonth, "rbCurrentMonth")
        Me.rbCurrentMonth.Checked = true
        Me.rbCurrentMonth.Name = "rbCurrentMonth"
        Me.rbCurrentMonth.TabStop = true
        Me.rbCurrentMonth.UseVisualStyleBackColor = true
        '
        'rbShowAll
        '
        resources.ApplyResources(Me.rbShowAll, "rbShowAll")
        Me.rbShowAll.Name = "rbShowAll"
        Me.rbShowAll.UseVisualStyleBackColor = true
        '
        'rbAllFilters
        '
        resources.ApplyResources(Me.rbAllFilters, "rbAllFilters")
        Me.rbAllFilters.Name = "rbAllFilters"
        Me.rbAllFilters.UseVisualStyleBackColor = true
        '
        'cmbKCS
        '
        resources.ApplyResources(Me.cmbKCS, "cmbKCS")
        Me.cmbKCS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbKCS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbKCS.FormattingEnabled = true
        Me.cmbKCS.Name = "cmbKCS"
        '
        'lblKCS
        '
        resources.ApplyResources(Me.lblKCS, "lblKCS")
        Me.lblKCS.Name = "lblKCS"
        '
        'grpSearch
        '
        resources.ApplyResources(Me.grpSearch, "grpSearch")
        Me.grpSearch.Controls.Add(Me.btnApplyFilters)
        Me.grpSearch.Controls.Add(Me.btnRestoreDefaults)
        Me.grpSearch.Controls.Add(Me.cmbsearchJob)
        Me.grpSearch.Controls.Add(Me.Label4)
        Me.grpSearch.Controls.Add(Me.Panel1)
        Me.grpSearch.Controls.Add(Me.dtFromDate)
        Me.grpSearch.Controls.Add(Me.cmbsearchFish)
        Me.grpSearch.Controls.Add(Me.lblFishName)
        Me.grpSearch.Controls.Add(Me.cmbsearchEmp)
        Me.grpSearch.Controls.Add(Me.Label5)
        Me.grpSearch.Controls.Add(Me.lblFromDate)
        Me.grpSearch.Controls.Add(Me.dtToDate)
        Me.grpSearch.Controls.Add(Me.lblToDate)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.TabStop = false
        '
        'btnApplyFilters
        '
        resources.ApplyResources(Me.btnApplyFilters, "btnApplyFilters")
        Me.btnApplyFilters.Name = "btnApplyFilters"
        Me.btnApplyFilters.UseVisualStyleBackColor = true
        '
        'cmbJobType
        '
        resources.ApplyResources(Me.cmbJobType, "cmbJobType")
        Me.cmbJobType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbJobType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbJobType.FormattingEnabled = true
        Me.cmbJobType.Name = "cmbJobType"
        '
        'frmLogWork
        '
        Me.AcceptButton = Me.btnAdd
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmbJobType)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.cmbKCS)
        Me.Controls.Add(Me.lblKCS)
        Me.Controls.Add(Me.lblPackingStyle)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtFishPartitionNew)
        Me.Controls.Add(Me.lblFishPartition)
        Me.Controls.Add(Me.grdPartitionFish)
        Me.Controls.Add(Me.txtFishPartition)
        Me.Controls.Add(Me.lblTotalPartition)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtRemaining)
        Me.Controls.Add(Me.lblRemaining)
        Me.Controls.Add(Me.grdLogWork)
        Me.Controls.Add(Me.txtTotalAmount)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.txtRateperPack)
        Me.Controls.Add(Me.lblRateperPack)
        Me.Controls.Add(Me.cmbFishType)
        Me.Controls.Add(Me.lblFishType)
        Me.Controls.Add(Me.lblMUnit)
        Me.Controls.Add(Me.txtTotalWeight)
        Me.Controls.Add(Me.lblTotalWeight)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.lblJobType)
        Me.Controls.Add(Me.cmbEmployee)
        Me.Controls.Add(Me.lblEmployee)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.lblDate)
        Me.Name = "frmLogWork"
        CType(Me.grdLogWork,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grdPartitionFish,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.grpSearch.ResumeLayout(false)
        Me.grpSearch.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents lblDate As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents cmbEmployee As ComboBox
    Friend WithEvents lblEmployee As Label
    Friend WithEvents lblJobType As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents lblQuantity As Label
    Friend WithEvents txtTotalWeight As TextBox
    Friend WithEvents lblTotalWeight As Label
    Friend WithEvents lblMUnit As Label
    Friend WithEvents cmbFishType As ComboBox
    Friend WithEvents lblFishType As Label
    Friend WithEvents txtRateperPack As TextBox
    Friend WithEvents lblRateperPack As Label
    Friend WithEvents txtTotalAmount As TextBox
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents grdLogWork As DataGridView
    Friend WithEvents txtRemaining As TextBox
    Friend WithEvents lblRemaining As Label
    Friend WithEvents btnNew As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtNote As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFishPartition As TextBox
    Friend WithEvents lblTotalPartition As Label
    Friend WithEvents grdPartitionFish As DataGridView
    Friend WithEvents txtFishPartitionNew As TextBox
    Friend WithEvents lblFishPartition As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents lblPackingStyle As Label
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Friend WithEvents fishpart As DataGridViewTextBoxColumn
    Friend WithEvents btnDelete As DataGridViewImageColumn
    Friend WithEvents dtToDate As DateTimePicker
    Friend WithEvents lblToDate As Label
    Friend WithEvents dtFromDate As DateTimePicker
    Friend WithEvents lblFromDate As Label
    Friend WithEvents lblFishName As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnRestoreDefaults As Button
    Friend WithEvents cmbsearchEmp As ComboBox
    Friend WithEvents cmbsearchFish As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbCurrentMonth As RadioButton
    Friend WithEvents rbShowAll As RadioButton
    Friend WithEvents rbAllFilters As RadioButton
    Friend WithEvents cmbsearchJob As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbKCS As ComboBox
    Friend WithEvents lblKCS As Label
    Friend WithEvents grpSearch As GroupBox
    Friend WithEvents cmbJobType As ComboBox
    Friend WithEvents btnApplyFilters As Button
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents TDate As DataGridViewTextBoxColumn
    Friend WithEvents Employee As DataGridViewTextBoxColumn
    Friend WithEvents empName As DataGridViewTextBoxColumn
    Friend WithEvents JobName As DataGridViewTextBoxColumn
    Friend WithEvents JobType As DataGridViewTextBoxColumn
    Friend WithEvents FishType As DataGridViewTextBoxColumn
    Friend WithEvents FishName As DataGridViewTextBoxColumn
    Friend WithEvents KCSID As DataGridViewTextBoxColumn
    Friend WithEvents KCS As DataGridViewTextBoxColumn
    Friend WithEvents Quantity As DataGridViewTextBoxColumn
    Friend WithEvents FishPartition As DataGridViewTextBoxColumn
    Friend WithEvents TotalWeight As DataGridViewTextBoxColumn
    Friend WithEvents Rateperpack As DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As DataGridViewTextBoxColumn
    Friend WithEvents Note As DataGridViewTextBoxColumn
    Friend WithEvents Edit As DataGridViewImageColumn
    Friend WithEvents Delete As DataGridViewImageColumn
End Class
