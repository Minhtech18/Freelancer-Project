Imports System.Windows.Forms

Public Class frmMDI

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Application.Exit
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub



    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub mnuCloseAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuCloseAll.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer
    Public sub CloseFormifOpen(ByRef frmopened as Form)
       Dim fc As FormCollection = Application.OpenForms

    For Each frm As Form In fc
            if frm.Name=frmopened.Name
                frm.Close
                Exit Sub
            End If

    Next
    End sub
    Private Sub mnuFish_Click(sender As Object, e As EventArgs) Handles mnuFish.Click
        Cursor = Cursors.WaitCursor
        CloseFormifOpen(frmFish)
        Dim objform As New frmFish
        objform.MdiParent = Me
        objform.StartPosition = FormStartPosition.CenterScreen
        objform.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuUser_Click(sender As Object, e As EventArgs) Handles mnuUser.Click
        Cursor = Cursors.WaitCursor
         CloseFormifOpen(frmUser)
        Dim objform As New frmUser
        objform.MdiParent = Me
        objform.StartPosition = FormStartPosition.CenterScreen
        objform.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub GenerateSalaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuGenerateSalary.Click
         CloseFormifOpen(frmGenerateSalary)
        Dim objform As New frmGenerateSalary
        objform.MdiParent = Me
        objform.StartPosition = FormStartPosition.CenterScreen
        objform.Show()
    End Sub

    Private Sub mnuLogin_Click(sender As Object, e As EventArgs) Handles mnuLogin.Click

        frmLogin.Show()
    End Sub

    Private Sub mnuEmployee_Click(sender As Object, e As EventArgs) Handles mnuEmployee.Click
        Cursor = Cursors.WaitCursor
         CloseFormifOpen(frmEmployee)
        Dim objform As New frmEmployee
        objform.MdiParent = Me
        objform.StartPosition = FormStartPosition.CenterScreen
        objform.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuJob_Click(sender As Object, e As EventArgs) Handles mnuJob.Click
        Cursor = Cursors.WaitCursor
         CloseFormifOpen(frmJob)
        Dim objform As New frmJob
        objform.MdiParent = Me
        objform.StartPosition = FormStartPosition.CenterScreen
        objform.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuSourceFish_Click(sender As Object, e As EventArgs) Handles mnuSourceFish.Click
        Cursor = Cursors.WaitCursor
         CloseFormifOpen(frmSourceFish)
        Dim objform As New frmSourceFish
        objform.MdiParent = Me
        objform.StartPosition = FormStartPosition.CenterScreen
        objform.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuLogout_Click(sender As Object, e As EventArgs) Handles mnuLogout.Click

        Dim msgboxres
        Try
            If DefaultLanguage = "English" Then
                msgboxres = MessageBox.Show(Me, "Are you sure to logout?", "Confirm Logout", MessageBoxButtons.YesNo)
            Else
                msgboxres = MessageBox.Show(Me, "Bạn có chắc muốn thoát", "Xác nhận", MessageBoxButtons.YesNo)
            End If
            If msgboxres = DialogResult.Yes Then

                For Each ChildForm As Form In Me.MdiChildren
                    ChildForm.Close()
                Next

                'Dim objform As New frmChangeUser
                'objform.MdiParent = Me
                'objform.StartPosition = FormStartPosition.CenterParent
                'frmChangeUser.ShowDialog()


                BackgroundWorker1.CancelAsync()
                BackgroundWorker1.Dispose()
                frmLogin.Show()
                'me.Dispose()
                Me.Close()
                
            End If
        Catch ex As Exception
            If DefaultLanguage = "English" Then
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK)
            Else
                MessageBox.Show(Me, ex.Message, "lỗi", MessageBoxButtons.OK)
            End If
        End Try



    End Sub

    Private Sub mnuMarinatedFish_Click(sender As Object, e As EventArgs) Handles mnuMarinatedFish.Click
        Cursor = Cursors.WaitCursor
         CloseFormifOpen(frmMarinatedFish)
        Dim objform As New frmMarinatedFish
        objform.MdiParent = Me
        objform.StartPosition = FormStartPosition.CenterScreen
        objform.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuLogWork_Click(sender As Object, e As EventArgs) Handles mnuLogWork.Click
        Cursor = Cursors.WaitCursor
         CloseFormifOpen(frmLogWork)
        Dim objform As New frmLogWork
        objform.MdiParent = Me
        objform.StartPosition = FormStartPosition.CenterScreen
        objform.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuJobRates_Click(sender As Object, e As EventArgs) Handles mnuJobRates.Click
        Cursor = Cursors.WaitCursor
         CloseFormifOpen(frmJobRates)
        Dim objform As New frmJobRates
        objform.MdiParent = Me
        objform.StartPosition = FormStartPosition.CenterScreen
        objform.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub frmMDI_Load(sender As Object, e As EventArgs) Handles Me.Load
        If DefaultLanguage = "English" Then
            ttUser.Text = "User: " & usersDt.Rows(0)("UserName")
            ttDate.Text = "Current Time: " & DateTime.Now.ToShortDateString
            ttLastLoginTime.Text = "Logged in Since: " & DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt")
        Else
            ttUser.Text = "Tên Đăng Nhập: " & usersDt.Rows(0)("UserName")
            ttDate.Text = "Thời điểm hiện tại: " & DateTime.Now.ToShortDateString
            ttLastLoginTime.Text = "Đăng nhập từ: " & DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt")
        End If

        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        System.Threading.Thread.Sleep(1000)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If DefaultLanguage = "English" Then
            ttDate.Text = "Current Time: " & DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt")
        Else
            ttDate.Text = "Thời điểm hiện tại: " & DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt")
        End If

        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub mnuLeaves_Click(sender As Object, e As EventArgs) Handles mnuLeaves.Click
        Cursor = Cursors.WaitCursor
         CloseFormifOpen(frmLeaves)
        Dim objform As New frmLeaves
        objform.MdiParent = Me
        objform.StartPosition = FormStartPosition.CenterScreen
        objform.Show()
        Cursor = Cursors.Default
    End Sub
End Class
