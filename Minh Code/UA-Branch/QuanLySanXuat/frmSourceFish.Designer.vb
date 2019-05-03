<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSourceFish
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSourceFish))
        Me.lblSourceName = New System.Windows.Forms.Label()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.grdSourceFish = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SourceName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.isActive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        CType(Me.grdSourceFish,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'lblSourceName
        '
        resources.ApplyResources(Me.lblSourceName, "lblSourceName")
        Me.lblSourceName.Name = "lblSourceName"
        '
        'txtSource
        '
        Me.txtSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        resources.ApplyResources(Me.txtSource, "txtSource")
        Me.txtSource.Name = "txtSource"
        Me.txtSource.ReadOnly = true
        '
        'grdSourceFish
        '
        Me.grdSourceFish.AllowUserToAddRows = false
        Me.grdSourceFish.AllowUserToDeleteRows = false
        resources.ApplyResources(Me.grdSourceFish, "grdSourceFish")
        Me.grdSourceFish.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdSourceFish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSourceFish.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.SourceName, Me.isActive, Me.Edit, Me.Delete})
        Me.grdSourceFish.Name = "grdSourceFish"
        Me.grdSourceFish.ReadOnly = true
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        resources.ApplyResources(Me.ID, "ID")
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = true
        '
        'SourceName
        '
        Me.SourceName.DataPropertyName = "SourceName"
        Me.SourceName.FillWeight = 284.7716!
        resources.ApplyResources(Me.SourceName, "SourceName")
        Me.SourceName.Name = "SourceName"
        Me.SourceName.ReadOnly = true
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
        Me.Edit.FillWeight = 7.614212!
        resources.ApplyResources(Me.Edit, "Edit")
        Me.Edit.Image = Global.QuanLySanXuat.My.Resources.Resources.pen_paper_2_5121
        Me.Edit.Name = "Edit"
        Me.Edit.ReadOnly = true
        Me.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Delete
        '
        Me.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Delete.FillWeight = 7.614212!
        resources.ApplyResources(Me.Delete, "Delete")
        Me.Delete.Image = Global.QuanLySanXuat.My.Resources.Resources.del
        Me.Delete.Name = "Delete"
        Me.Delete.ReadOnly = true
        Me.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
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
        'chkIsActive
        '
        resources.ApplyResources(Me.chkIsActive, "chkIsActive")
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.UseVisualStyleBackColor = true
        '
        'frmSourceFish
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkIsActive)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblSourceName)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.grdSourceFish)
        Me.Name = "frmSourceFish"
        CType(Me.grdSourceFish,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents lblSourceName As Label
    Friend WithEvents txtSource As TextBox
    Friend WithEvents grdSourceFish As DataGridView
    Friend WithEvents btnNew As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents chkIsActive As CheckBox
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents SourceName As DataGridViewTextBoxColumn
    Friend WithEvents isActive As DataGridViewCheckBoxColumn
    Friend WithEvents Edit As DataGridViewImageColumn
    Friend WithEvents Delete As DataGridViewImageColumn
End Class
