<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMDI
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMDI))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFish = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEmployee = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSourceFish = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLeaves = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuJobRates = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMarinatedFish = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogWork = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalary = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGenerateSalary = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTool = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCloseAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ttUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ttLastLoginTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ttDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip.SuspendLayout
        Me.StatusStrip.SuspendLayout
        Me.SuspendLayout
        '
        'MenuStrip
        '
        resources.ApplyResources(Me.MenuStrip, "MenuStrip")
        Me.MenuStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(203,Byte),Integer), CType(CType(209,Byte),Integer), CType(CType(221,Byte),Integer))
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.WorkToolStripMenuItem, Me.mnuSalary, Me.mnuTool})
        Me.MenuStrip.Name = "MenuStrip"
        Me.ToolTip.SetToolTip(Me.MenuStrip, resources.GetString("MenuStrip.ToolTip"))
        '
        'FileMenu
        '
        resources.ApplyResources(Me.FileMenu, "FileMenu")
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLogin, Me.ToolStripSeparator1, Me.mnuFish, Me.mnuEmployee, Me.mnuJob, Me.mnuSourceFish, Me.ToolStripSeparator3, Me.mnuUser, Me.ToolStripSeparator2, Me.mnuLogout})
        Me.FileMenu.Name = "FileMenu"
        '
        'mnuLogin
        '
        resources.ApplyResources(Me.mnuLogin, "mnuLogin")
        Me.mnuLogin.Name = "mnuLogin"
        '
        'ToolStripSeparator1
        '
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        '
        'mnuFish
        '
        resources.ApplyResources(Me.mnuFish, "mnuFish")
        Me.mnuFish.Name = "mnuFish"
        '
        'mnuEmployee
        '
        resources.ApplyResources(Me.mnuEmployee, "mnuEmployee")
        Me.mnuEmployee.Name = "mnuEmployee"
        '
        'mnuJob
        '
        resources.ApplyResources(Me.mnuJob, "mnuJob")
        Me.mnuJob.Name = "mnuJob"
        '
        'mnuSourceFish
        '
        resources.ApplyResources(Me.mnuSourceFish, "mnuSourceFish")
        Me.mnuSourceFish.Name = "mnuSourceFish"
        '
        'ToolStripSeparator3
        '
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        '
        'mnuUser
        '
        resources.ApplyResources(Me.mnuUser, "mnuUser")
        Me.mnuUser.Name = "mnuUser"
        '
        'ToolStripSeparator2
        '
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        '
        'mnuLogout
        '
        resources.ApplyResources(Me.mnuLogout, "mnuLogout")
        Me.mnuLogout.Name = "mnuLogout"
        '
        'WorkToolStripMenuItem
        '
        resources.ApplyResources(Me.WorkToolStripMenuItem, "WorkToolStripMenuItem")
        Me.WorkToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLeaves, Me.mnuJobRates, Me.mnuMarinatedFish, Me.mnuLogWork})
        Me.WorkToolStripMenuItem.Name = "WorkToolStripMenuItem"
        '
        'mnuLeaves
        '
        resources.ApplyResources(Me.mnuLeaves, "mnuLeaves")
        Me.mnuLeaves.Name = "mnuLeaves"
        '
        'mnuJobRates
        '
        resources.ApplyResources(Me.mnuJobRates, "mnuJobRates")
        Me.mnuJobRates.Name = "mnuJobRates"
        '
        'mnuMarinatedFish
        '
        resources.ApplyResources(Me.mnuMarinatedFish, "mnuMarinatedFish")
        Me.mnuMarinatedFish.Name = "mnuMarinatedFish"
        '
        'mnuLogWork
        '
        resources.ApplyResources(Me.mnuLogWork, "mnuLogWork")
        Me.mnuLogWork.Name = "mnuLogWork"
        '
        'mnuSalary
        '
        resources.ApplyResources(Me.mnuSalary, "mnuSalary")
        Me.mnuSalary.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGenerateSalary})
        Me.mnuSalary.Name = "mnuSalary"
        '
        'mnuGenerateSalary
        '
        resources.ApplyResources(Me.mnuGenerateSalary, "mnuGenerateSalary")
        Me.mnuGenerateSalary.Name = "mnuGenerateSalary"
        '
        'mnuTool
        '
        resources.ApplyResources(Me.mnuTool, "mnuTool")
        Me.mnuTool.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCloseAll, Me.mnuExit})
        Me.mnuTool.Name = "mnuTool"
        '
        'mnuCloseAll
        '
        resources.ApplyResources(Me.mnuCloseAll, "mnuCloseAll")
        Me.mnuCloseAll.Name = "mnuCloseAll"
        '
        'mnuExit
        '
        resources.ApplyResources(Me.mnuExit, "mnuExit")
        Me.mnuExit.Name = "mnuExit"
        '
        'StatusStrip
        '
        resources.ApplyResources(Me.StatusStrip, "StatusStrip")
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ttUser, Me.ttLastLoginTime, Me.ttDate})
        Me.StatusStrip.Name = "StatusStrip"
        Me.ToolTip.SetToolTip(Me.StatusStrip, resources.GetString("StatusStrip.ToolTip"))
        '
        'ttUser
        '
        resources.ApplyResources(Me.ttUser, "ttUser")
        Me.ttUser.Name = "ttUser"
        Me.ttUser.Padding = New System.Windows.Forms.Padding(5)
        '
        'ttLastLoginTime
        '
        resources.ApplyResources(Me.ttLastLoginTime, "ttLastLoginTime")
        Me.ttLastLoginTime.Name = "ttLastLoginTime"
        Me.ttLastLoginTime.Padding = New System.Windows.Forms.Padding(5)
        '
        'ttDate
        '
        resources.ApplyResources(Me.ttDate, "ttDate")
        Me.ttDate.Name = "ttDate"
        Me.ttDate.Padding = New System.Windows.Forms.Padding(5)
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerSupportsCancellation = true
        '
        'frmMDI
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.QuanLySanXuat.My.Resources.Resources.bg3
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = true
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmMDI"
        Me.ToolTip.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(false)
        Me.MenuStrip.PerformLayout
        Me.StatusStrip.ResumeLayout(false)
        Me.StatusStrip.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFish As ToolStripMenuItem
    Friend WithEvents mnuEmployee As ToolStripMenuItem
    Friend WithEvents mnuJob As ToolStripMenuItem
    Friend WithEvents mnuSourceFish As ToolStripMenuItem
    Friend WithEvents WorkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuMarinatedFish As ToolStripMenuItem
    Friend WithEvents mnuLogWork As ToolStripMenuItem
    Friend WithEvents mnuSalary As ToolStripMenuItem
    Friend WithEvents mnuGenerateSalary As ToolStripMenuItem
    Friend WithEvents mnuLogin As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents mnuUser As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents mnuLogout As ToolStripMenuItem
    Friend WithEvents mnuTool As ToolStripMenuItem
    Friend WithEvents mnuCloseAll As ToolStripMenuItem
    Friend WithEvents mnuJobRates As ToolStripMenuItem
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents ttUser As ToolStripStatusLabel
    Friend WithEvents ttDate As ToolStripStatusLabel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ttLastLoginTime As ToolStripStatusLabel
    Friend WithEvents mnuLeaves As ToolStripMenuItem
End Class
