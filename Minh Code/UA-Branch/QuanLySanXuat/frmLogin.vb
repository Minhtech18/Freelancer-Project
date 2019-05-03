Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbSelLanguage.SelectedIndex = 0
        Dim connStr As String = g_connStr
        Dim conn As New MySqlConnection(connStr)
        Try
            frmWelcomeScreen.Visible = True
            System.Threading.Thread.Sleep(2000)
            If frmWelcomeScreen.Visible = True Then
                frmWelcomeScreen.Visible = False
            End If


        Catch ex As Exception
            Console.WriteLine(ex.ToString())

        End Try

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Try


            DefaultLanguage = cmbSelLanguage.Text
            If DefaultLanguage <> "English" Then
                Thread.CurrentThread.CurrentUICulture = New CultureInfo("vi-VN")
                Thread.CurrentThread.CurrentCulture = New CultureInfo("vi-VN")
                MessageBoxManager.Unregister()
                MessageBoxManager.Yes = "Vâng"
                MessageBoxManager.No = "Không"
                MessageBoxManager.Cancel = "hủy bỏ"
                MessageBoxManager.OK = "được"
                MessageBoxManager.Register()
            Else
                Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-US")
                Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
                MessageBoxManager.Unregister()
                MessageBoxManager.Yes = "Yes"
                MessageBoxManager.No = "No"
                MessageBoxManager.Cancel = "Cancel"
                MessageBoxManager.OK = "OK"
                MessageBoxManager.Register()
            End If
            If (txtUserName.Text.Length = 0 Or txtPassword.Text.Length = 0) And DefaultLanguage = "English" Then
                MessageBox.Show("Enter username and password.")
                Exit Sub
            Else
                If (txtUserName.Text.Length = 0 Or txtPassword.Text.Length = 0) And DefaultLanguage <> "English" Then
                    MessageBox.Show("nhập tên người dùng và mật khẩu.")
                    Exit Sub
                End If
            End If
            Dim tbladpt As New DataSet1TableAdapters.tblusersTableAdapter
            Dim dt As New DataTable
            dt = tbladpt.GetDataByUsernameandpassword(txtUserName.Text, txtPassword.Text)
            If dt.Rows.Count > 0 Then
                usersDt = dt
                Me.Hide()
                'frmMDI.ShowDialog()
                Dim objform As New frmMDI   'New instance is required to load form in new culture if changed after logout. Without new instance it would load the form in same old culture
                objform.ShowDialog()
            Else
                If DefaultLanguage = "English" Then
                    MessageBox.Show("Invalid username and password.")
                Else
                    MessageBox.Show("Tên người dùng và mật khẩu không hợp lệ.")
                End If

            End If
        Catch ex As Exception
            If DefaultLanguage = "English" Then
                MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK)
            Else
                MessageBox.Show(Me, ex.Message, "lỗi", MessageBoxButtons.OK)
            End If
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Application.Exit()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbSelLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSelLanguage.SelectedIndexChanged

        DefaultLanguage = cmbSelLanguage.Text
        If DefaultLanguage <> "English" Then
            Thread.CurrentThread.CurrentUICulture = New CultureInfo("vi-VN")
        End If
    End Sub
End Class