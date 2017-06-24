''MBT程式
''          20100601 by ice 謝禎皓

Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class MainForm_old
    ' 宣告 全域變數 Aging前後段,Aging刪除權限控制
    Public Aging_Chk, Aging_Chk_D, Aging_Chk_O As String

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '權限畫面控制
        'administrator
        If Login.ALL_UserID = "Admin" Or Login.ALL_Admin = "1" Then

            '權限檢查-Angin刪除權限
            Aging_Chk_D = "1"
            '權限檢查-組長權限
            Aging_Chk_O = "1"

        Else
            User_M.Visible = False '人員資料管理
            Aging_GroupBox.Visible = False
            PRCS_GroupBox.Visible = False
            PRQA_GroupBox.Visible = False

            ''----------------------抓config檔的ConnectionString
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()

            Dim queryString As String =
                "SELECT * FROM dbo.Users WHERE User_ID ='" & Login.ALL_UserID & "';"

            Using connection As New SqlConnection(connectionString)
                Dim command As New SqlCommand(queryString, connection)
                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader()

                If reader.Read() Then     '判斷檔尾 有資料
                    Dim String_ As String = Trim(reader.Item("Aging")) & Trim(reader.Item("PRCS")) & Trim(reader.Item("PRQA"))
                    '檢查權限重新定義視窗
                    If (String_ = "111") Then
                        Aging_GroupBox.Visible = True
                        PRCS_GroupBox.Visible = True
                        PRQA_GroupBox.Visible = True

                    ElseIf (String_ = "101") Then
                        Aging_GroupBox.Visible = True
                        PRCS_GroupBox.Visible = False
                        PRQA_GroupBox.Visible = True

                        Aging_GroupBox.Location = New System.Drawing.Point(25, 12)
                        PRQA_GroupBox.Location = New System.Drawing.Point(215, 12)
                        Out_Btn.Location = New System.Drawing.Point(165, 337)
                        Cancel.Location = New System.Drawing.Point(270, 337)
                        Me.Size = New System.Drawing.Size(410, 400) '重新定義視窗大小

                    ElseIf (String_ = "110") Then
                        Aging_GroupBox.Visible = True
                        PRCS_GroupBox.Visible = True
                        PRQA_GroupBox.Visible = False

                        Aging_GroupBox.Location = New System.Drawing.Point(25, 12)
                        PRCS_GroupBox.Location = New System.Drawing.Point(215, 12)
                        Out_Btn.Location = New System.Drawing.Point(165, 337)
                        Cancel.Location = New System.Drawing.Point(270, 337)
                        Me.Size = New System.Drawing.Size(410, 400) '重新定義視窗大小

                    ElseIf (String_ = "100") Then
                        Aging_GroupBox.Visible = True
                        PRCS_GroupBox.Visible = False
                        PRQA_GroupBox.Visible = False

                        Out_Btn.Location = New System.Drawing.Point(5, 337)
                        Cancel.Location = New System.Drawing.Point(110, 337)
                        Me.Size = New System.Drawing.Size(225, 400) '重新定義視窗大小

                    ElseIf (String_ = "010") Then
                        Aging_GroupBox.Visible = False
                        PRCS_GroupBox.Visible = True
                        PRQA_GroupBox.Visible = False

                        PRCS_GroupBox.Location = New System.Drawing.Point(25, 12)
                        Out_Btn.Location = New System.Drawing.Point(5, 337)
                        Cancel.Location = New System.Drawing.Point(110, 337)
                        Me.Size = New System.Drawing.Size(225, 400) '重新定義視窗大小

                    ElseIf (String_ = "011") Then
                        Aging_GroupBox.Visible = False
                        PRCS_GroupBox.Visible = True
                        PRQA_GroupBox.Visible = True

                        PRCS_GroupBox.Location = New System.Drawing.Point(25, 12)
                        PRQA_GroupBox.Location = New System.Drawing.Point(215, 12)
                        Out_Btn.Location = New System.Drawing.Point(165, 337)
                        Cancel.Location = New System.Drawing.Point(270, 337)
                        Me.Size = New System.Drawing.Size(410, 400) '重新定義視窗大小

                    ElseIf (String_ = "001") Then
                        Aging_GroupBox.Visible = False
                        PRCS_GroupBox.Visible = False
                        PRQA_GroupBox.Visible = True

                        PRQA_GroupBox.Location = New System.Drawing.Point(25, 12)
                        Out_Btn.Location = New System.Drawing.Point(5, 337)
                        Cancel.Location = New System.Drawing.Point(110, 337)
                        Me.Size = New System.Drawing.Size(225, 400) '重新定義視窗大小

                    End If

                    '權限檢查-Angin刪除權限
                    If Trim(reader.Item("Aging_Del")) = "1" Then
                        Aging_Chk_D = "1"
                    End If

                    '權限檢查-組長權限
                    If Trim(reader.Item("Out")) = "1" Then
                        Aging_Chk_O = "1"
                    End If

                    '權限檢查-人員資料管理權限
                    If Trim(reader.Item("Admin")) = "1" Then
                        User_M.Visible = True '人員資料管理
                    End If

                End If

                reader.Close()
                connection.Close()
            End Using

        End If
    End Sub

    Private Sub PRQA_Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PRQA.Click
        PRQA.Show()
        'Me.Hide()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        End
    End Sub

    Private Sub Btn_PRQA_SER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PRQA_SER.Click
        PRQA_SER.Show()
    End Sub

    Private Sub MainForm_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave

    End Sub

    Private Sub Btn_Aging_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aging_1.Click
        '權限畫面控制 前段
        Aging_Chk = "1"
        Aging.Show()
    End Sub

    Private Sub Btn_Aging_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aging_2.Click
        '權限畫面控制 後段
        Aging_Chk = "2"
        Aging.Show()
    End Sub

    Private Sub Btn_LAMPS_SER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_LAMPS_SER.Click
        LAMPS_SER.Show()
    End Sub

    Private Sub Btn_LAMPS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_LAMPS.Click
        LAMPS.Show()
    End Sub

    Private Sub Btn_PRCS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PRCS.Click
        PRCS.Show()
        'Me.Hide()
    End Sub

    Private Sub User_M_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles User_M.Click
        Admin.Show()
    End Sub

    Private Sub Ex_Btn_Click(sender As Object, e As EventArgs) Handles Ex_Btn.Click
        '權限畫面控制 前段
        Aging_Chk = "3"
        Aging.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim f As New Form
        Aging.TopLevel = False
        Aging.Parent = Me
        Aging.Show()
    End Sub

    Private Sub Out_Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Out_Btn.Click

        Me.Close()
        Login.Show()
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        '右上角關閉
        If m.Msg = 161 And m.WParam = 20 Then
            If MessageBox.Show("確定關閉視窗?", "警告", MessageBoxButtons.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            Me.Close()
            End
        Else
            MyBase.WndProc(m)
        End If
    End Sub
End Class