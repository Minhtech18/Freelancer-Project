<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJobRates
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJobRates))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblSourceName = New System.Windows.Forms.Label()
        Me.cmbFishType = New System.Windows.Forms.ComboBox()
        Me.lblPackingStyle = New System.Windows.Forms.Label()
        Me.txtPackingStyle = New System.Windows.Forms.TextBox()
        Me.lblJobType = New System.Windows.Forms.Label()
        Me.cmbJobType = New System.Windows.Forms.ComboBox()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.lblRate = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.grdJobRates = New System.Windows.Forms.DataGridView()
        Me.DataSet1 = New QuanLySanXuat.DataSet1()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbUnits = New System.Windows.Forms.ComboBox()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FishName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.packingstyle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.fishtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grdJobRates,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataSet1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'lblSourceName
        '
        resources.ApplyResources(Me.lblSourceName, "lblSourceName")
        Me.lblSourceName.Name = "lblSourceName"
        '
        'cmbFishType
        '
        resources.ApplyResources(Me.cmbFishType, "cmbFishType")
        Me.cmbFishType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFishType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFishType.FormattingEnabled = true
        Me.cmbFishType.Name = "cmbFishType"
        '
        'lblPackingStyle
        '
        resources.ApplyResources(Me.lblPackingStyle, "lblPackingStyle")
        Me.lblPackingStyle.Name = "lblPackingStyle"
        '
        'txtPackingStyle
        '
        resources.ApplyResources(Me.txtPackingStyle, "txtPackingStyle")
        Me.txtPackingStyle.Name = "txtPackingStyle"
        '
        'lblJobType
        '
        resources.ApplyResources(Me.lblJobType, "lblJobType")
        Me.lblJobType.Name = "lblJobType"
        '
        'cmbJobType
        '
        resources.ApplyResources(Me.cmbJobType, "cmbJobType")
        Me.cmbJobType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbJobType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbJobType.FormattingEnabled = true
        Me.cmbJobType.Name = "cmbJobType"
        '
        'txtRate
        '
        resources.ApplyResources(Me.txtRate, "txtRate")
        Me.txtRate.Name = "txtRate"
        '
        'lblRate
        '
        resources.ApplyResources(Me.lblRate, "lblRate")
        Me.lblRate.Name = "lblRate"
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
        'grdJobRates
        '
        resources.ApplyResources(Me.grdJobRates, "grdJobRates")
        Me.grdJobRates.AllowUserToAddRows = false
        Me.grdJobRates.AllowUserToDeleteRows = false
        Me.grdJobRates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdJobRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdJobRates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.FishName, Me.packingstyle, Me.PUnit, Me.JobName, Me.Rate, Me.Edit, Me.Delete, Me.fishtype, Me.JobType})
        Me.grdJobRates.Name = "grdJobRates"
        Me.grdJobRates.ReadOnly = true
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cmbUnits
        '
        resources.ApplyResources(Me.cmbUnits, "cmbUnits")
        Me.cmbUnits.FormattingEnabled = true
        Me.cmbUnits.Name = "cmbUnits"
        '
        'id
        '
        Me.id.DataPropertyName = "ID"
        resources.ApplyResources(Me.id, "id")
        Me.id.Name = "id"
        Me.id.ReadOnly = true
        '
        'FishName
        '
        Me.FishName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.FishName.DataPropertyName = "FishName"
        Me.FishName.FillWeight = 557.4423!
        resources.ApplyResources(Me.FishName, "FishName")
        Me.FishName.Name = "FishName"
        Me.FishName.ReadOnly = true
        '
        'packingstyle
        '
        Me.packingstyle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.packingstyle.DataPropertyName = "PackingStyle"
        Me.packingstyle.FillWeight = 342.4458!
        resources.ApplyResources(Me.packingstyle, "packingstyle")
        Me.packingstyle.Name = "packingstyle"
        Me.packingstyle.ReadOnly = true
        '
        'PUnit
        '
        Me.PUnit.DataPropertyName = "PUnit"
        resources.ApplyResources(Me.PUnit, "PUnit")
        Me.PUnit.Name = "PUnit"
        Me.PUnit.ReadOnly = true
        '
        'JobName
        '
        Me.JobName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.JobName.DataPropertyName = "JobName"
        resources.ApplyResources(Me.JobName, "JobName")
        Me.JobName.Name = "JobName"
        Me.JobName.ReadOnly = true
        '
        'Rate
        '
        Me.Rate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Rate.DataPropertyName = "Rate"
        DataGridViewCellStyle2.Format = "N0"
        Me.Rate.DefaultCellStyle = DataGridViewCellStyle2
        Me.Rate.FillWeight = 17.49452!
        resources.ApplyResources(Me.Rate, "Rate")
        Me.Rate.Name = "Rate"
        Me.Rate.ReadOnly = true
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
        'fishtype
        '
        Me.fishtype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.fishtype.DataPropertyName = "FishType"
        Me.fishtype.FillWeight = 17.49452!
        resources.ApplyResources(Me.fishtype, "fishtype")
        Me.fishtype.Name = "fishtype"
        Me.fishtype.ReadOnly = true
        '
        'JobType
        '
        Me.JobType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.JobType.DataPropertyName = "JobType"
        Me.JobType.FillWeight = 17.49452!
        resources.ApplyResources(Me.JobType, "JobType")
        Me.JobType.Name = "JobType"
        Me.JobType.ReadOnly = true
        '
        'frmJobRates
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmbUnits)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdJobRates)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtRate)
        Me.Controls.Add(Me.lblRate)
        Me.Controls.Add(Me.cmbJobType)
        Me.Controls.Add(Me.lblJobType)
        Me.Controls.Add(Me.txtPackingStyle)
        Me.Controls.Add(Me.lblPackingStyle)
        Me.Controls.Add(Me.cmbFishType)
        Me.Controls.Add(Me.lblSourceName)
        Me.Name = "frmJobRates"
        CType(Me.grdJobRates,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataSet1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents lblSourceName As Label
    Friend WithEvents cmbFishType As ComboBox
    Friend WithEvents lblPackingStyle As Label
    Friend WithEvents txtPackingStyle As TextBox
    Friend WithEvents lblJobType As Label
    Friend WithEvents cmbJobType As ComboBox
    Friend WithEvents txtRate As TextBox
    Friend WithEvents lblRate As Label
    Friend WithEvents btnNew As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents grdJobRates As DataGridView
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbUnits As ComboBox
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents FishName As DataGridViewTextBoxColumn
    Friend WithEvents packingstyle As DataGridViewTextBoxColumn
    Friend WithEvents PUnit As DataGridViewTextBoxColumn
    Friend WithEvents JobName As DataGridViewTextBoxColumn
    Friend WithEvents Rate As DataGridViewTextBoxColumn
    Friend WithEvents Edit As DataGridViewImageColumn
    Friend WithEvents Delete As DataGridViewImageColumn
    Friend WithEvents fishtype As DataGridViewTextBoxColumn
    Friend WithEvents JobType As DataGridViewTextBoxColumn
End Class
