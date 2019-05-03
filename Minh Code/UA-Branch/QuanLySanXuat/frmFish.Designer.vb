<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFish
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFish))
        Me.grdFish = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FishName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.isActive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtFish = New System.Windows.Forms.TextBox()
        Me.lblFishName = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        CType(Me.grdFish,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'grdFish
        '
        resources.ApplyResources(Me.grdFish, "grdFish")
        Me.grdFish.AllowUserToAddRows = false
        Me.grdFish.AllowUserToDeleteRows = false
        Me.grdFish.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdFish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFish.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.FishName, Me.isActive, Me.Edit, Me.Delete})
        Me.grdFish.Name = "grdFish"
        Me.grdFish.ReadOnly = true
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        resources.ApplyResources(Me.id, "id")
        Me.id.Name = "id"
        Me.id.ReadOnly = true
        '
        'FishName
        '
        Me.FishName.DataPropertyName = "fishname"
        Me.FishName.FillWeight = 139.8443!
        resources.ApplyResources(Me.FishName, "FishName")
        Me.FishName.Name = "FishName"
        Me.FishName.ReadOnly = true
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
        'txtFish
        '
        resources.ApplyResources(Me.txtFish, "txtFish")
        Me.txtFish.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtFish.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtFish.Name = "txtFish"
        Me.txtFish.ReadOnly = true
        '
        'lblFishName
        '
        resources.ApplyResources(Me.lblFishName, "lblFishName")
        Me.lblFishName.Name = "lblFishName"
        '
        'btnNew
        '
        resources.ApplyResources(Me.btnNew, "btnNew")
        Me.btnNew.Name = "btnNew"
        Me.btnNew.UseVisualStyleBackColor = true
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        '
        'btnSave
        '
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.Name = "btnSave"
        Me.btnSave.UseVisualStyleBackColor = true
        '
        'chkIsActive
        '
        resources.ApplyResources(Me.chkIsActive, "chkIsActive")
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.UseVisualStyleBackColor = true
        '
        'frmFish
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkIsActive)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblFishName)
        Me.Controls.Add(Me.txtFish)
        Me.Controls.Add(Me.grdFish)
        Me.Name = "frmFish"
        CType(Me.grdFish,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents grdFish As DataGridView
    Friend WithEvents txtFish As TextBox
    Friend WithEvents lblFishName As Label
    Friend WithEvents btnNew As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents chkIsActive As CheckBox
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents FishName As DataGridViewTextBoxColumn
    Friend WithEvents isActive As DataGridViewCheckBoxColumn
    Friend WithEvents Edit As DataGridViewImageColumn
    Friend WithEvents Delete As DataGridViewImageColumn
End Class
