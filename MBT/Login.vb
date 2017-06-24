''MBT程式
''          20100601 by ice 謝禎皓
Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class Login
    ' 宣告 全域變數 使用者ID,姓名
    Public ALL_UserID, ALL_UserN, ALL_Admin, ALL_UserLD As String
    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyBase.CancelButton = Cancel '使用ECS 鍵關閉視窗
        MyBase.AcceptButton = OK '使用ENTER 鍵確認
    End Sub
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Login_Go()
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Dispose()
    End Sub
    Private Sub UsernameTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UsernameTextBox.KeyPress
        '檢查是否按下Enter
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            PasswordTextBox.Focus()
        End If
    End Sub
    Private Sub UsernameTextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UsernameTextBox.Leave
        '檢查是否輸入帳號
        If UsernameTextBox.Text = "" Then
            Label2.Visible = True
            Label2.ForeColor = Color.Red
            Exit Sub
        End If
    End Sub
    Private Sub UsernameTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles UsernameTextBox.GotFocus
        If Label2.Visible = True Then
            Label2.Visible = False
        End If
        If UsernameTextBox.Text <> "" Then
            UsernameTextBox.SelectAll()
        End If
    End Sub
    Private Sub PasswordTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PasswordTextBox.KeyPress
        '檢查是否按下Enter
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            '檢查是否輸入密碼
            If PasswordTextBox.Text = "" Then
                Label3.Visible = True
                Label3.ForeColor = Color.Red
            End If
            Login_Go()
        End If
    End Sub
    Private Sub PasswordTextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PasswordTextBox.Leave
        '檢查是否輸入密碼
        If PasswordTextBox.Text = "" Then
            Label3.Visible = True
            Label3.ForeColor = Color.Red
            Exit Sub
        End If
    End Sub
    Private Sub PasswordTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PasswordTextBox.GotFocus
        If Label3.Visible = True Then
            Label3.Visible = False
        End If
        If Login.IsKeyLocked(Keys.CapsLock) = True Then
            'MsgBox("The Caps Lock key is ON")
        End If
    End Sub
    Sub Login_Go()
        If UsernameTextBox.Text = "" Then
            MsgBox("請輸入帳號!!" & vbCrLf)
            UsernameTextBox.Focus()
            Exit Sub
        End If

        If PasswordTextBox.Text = "" Then
            MsgBox("請輸入密碼!!" & vbCrLf)
            PasswordTextBox.Focus()
            Exit Sub
        End If

        ''----------------------抓config檔的ConnectionString
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()
        ''帳號資料搜尋
        'administrator
        If UsernameTextBox.Text = "Admin" And PasswordTextBox.Text = "Admin" Then
            ALL_UserID = "Admin"
            ALL_UserN = "Admin"
            PasswordTextBox.Text = ""

            MainForm.Show()
            Me.Hide()
            Return
        End If

        '現在版本version
        Dim NOW_version As String = "1.0"

        '版本檢查version
        Dim CHK_ver_String As String =
            "SELECT version FROM SYS_MBT;"
        Try

            Using CHK_ver_conn As New SqlConnection(connectionString)
                Dim command As New SqlCommand(CHK_ver_String, CHK_ver_conn)
                CHK_ver_conn.Open()

                Dim CHK_ver_reader As SqlDataReader = command.ExecuteReader()

                If CHK_ver_reader.Read() Then     '判斷檔尾 有資料

                    '版本檢查不同
                    If NOW_version <> Trim(CHK_ver_reader.Item("version")) Then

                        MsgBox("系統版本不同 請執行 'MBT更新.bat' 更新系統!!" & vbCrLf)

                        CHK_ver_reader.Close()
                        CHK_ver_conn.Close()

                        Me.Close()
                        Return
                    End If

                End If

                CHK_ver_reader.Close()
                CHK_ver_conn.Close()
            End Using

            Dim queryString As String =
                    "SELECT User_ID, User_pass, User_Name, LD_Name, Admin FROM dbo.Users WHERE User_ID ='" & UsernameTextBox.Text & "';"

            Using connection As New SqlConnection(connectionString)
                Dim command As New SqlCommand(queryString, connection)
                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader()

                If reader.Read() Then     '判斷檔尾 有資料

                    '密碼檢查
                    If PasswordTextBox.Text = Trim(reader.Item("User_pass")) Then
                        ALL_UserID = UsernameTextBox.Text
                        ALL_UserN = Trim(reader.Item("User_Name"))
                        ALL_Admin = Trim(reader.Item("Admin"))
                        ALL_UserLD = Trim(reader.Item("LD_Name"))

                        reader.Close()
                        connection.Close()

                        PasswordTextBox.Text = ""
                        MainForm.Show()
                        Me.Hide()
                        Return
                    Else
                        MsgBox("密碼輸入錯誤!!" & vbCrLf)
                        PasswordTextBox.Text = ""
                        PasswordTextBox.Focus()
                    End If
                Else
                    MsgBox("帳號輸入錯誤!!" & vbCrLf)
                    PasswordTextBox.Text = ""
                    UsernameTextBox.Focus()
                    UsernameTextBox.SelectAll()
                End If

                reader.Close()
                connection.Close()
            End Using

        Catch ex As Exception
            MsgBox("連線失敗!!" & vbCrLf & ex.Message)
        End Try
    End Sub
End Class
