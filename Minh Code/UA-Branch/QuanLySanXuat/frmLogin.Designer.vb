<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblHeading = New System.Windows.Forms.Label()
        Me.MySqlConnection1 = New MySql.Data.MySqlClient.MySqlConnection()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbSelLanguage = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'txtUserName
        '
        resources.ApplyResources(Me.txtUserName, "txtUserName")
        Me.txtUserName.Name = "txtUserName"
        '
        'txtPassword
        '
        resources.ApplyResources(Me.txtPassword, "txtPassword")
        Me.txtPassword.Name = "txtPassword"
        '
        'btnLogin
        '
        resources.ApplyResources(Me.btnLogin, "btnLogin")
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.UseVisualStyleBackColor = true
        '
        'lblUserName
        '
        resources.ApplyResources(Me.lblUserName, "lblUserName")
        Me.lblUserName.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblUserName.Name = "lblUserName"
        '
        'lblPassword
        '
        resources.ApplyResources(Me.lblPassword, "lblPassword")
        Me.lblPassword.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblPassword.Name = "lblPassword"
        '
        'lblHeading
        '
        resources.ApplyResources(Me.lblHeading, "lblHeading")
        Me.lblHeading.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblHeading.Name = "lblHeading"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'cmbSelLanguage
        '
        resources.ApplyResources(Me.cmbSelLanguage, "cmbSelLanguage")
        Me.cmbSelLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSelLanguage.FormattingEnabled = true
        Me.cmbSelLanguage.Items.AddRange(New Object() {resources.GetString("cmbSelLanguage.Items"), resources.GetString("cmbSelLanguage.Items1")})
        Me.cmbSelLanguage.Name = "cmbSelLanguage"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Name = "Label2"
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnLogin
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.QuanLySanXuat.My.Resources.Resources.bg3
        Me.ControlBox = false
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbSelLanguage)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblHeading)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmLogin"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents txtUserName As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents lblUserName As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblHeading As Label
    Friend WithEvents MySqlConnection1 As MySql.Data.MySqlClient.MySqlConnection
    Friend WithEvents Button1 As Button
    Friend WithEvents cmbSelLanguage As ComboBox
    Friend WithEvents Label2 As Label
End Class
