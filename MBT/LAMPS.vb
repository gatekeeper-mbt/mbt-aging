''MBT程式
''          20101006 by ice 謝禎皓

Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient


Public Class LAMPS
    ''----------------------抓config檔的ConnectionString
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()
    Dim Conn As SqlConnection = New SqlConnection(connectionString)
    Private Sub LAMPS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.ControlBox = False
        'Me.WindowState = FormWindowState.Maximized '視窗最大化
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub Txt_LAMPS_NO_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_LAMPS_NO.Leave

        If Txt_LAMPS_NO.Text = "" Then
            Label2.Visible = True
            Label2.ForeColor = Color.Red
            Exit Sub
        End If

        '資料搜尋帶入
        Conn.Open()

        '單身資料搜尋Aging.Aging_D
        Dim DSQL_str As String = "SELECT * FROM Aging_D WHERE LAMPS_NO = '" & Txt_LAMPS_NO.Text & "'"
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader
        DReader = DSQL_Cmd.ExecuteReader()
        If DReader.Read() Then     '判斷檔尾 有資料
            '補資料的資料時 以下會無資料出現bug

            If Not IsDBNull(DReader.Item("Ballast_NO")) Then
                Txt_Ballast_NO.Text = DReader.Item("Ballast_NO")
            End If
            If Not IsDBNull(DReader.Item("ampere3")) Then
                Txt_ampere3.Text = DReader.Item("ampere3")
            End If

            If Not IsDBNull(DReader.Item("Aging_no2")) Then
                Txt_No2.Text = DReader.Item("Aging_no2")
            End If
            If Not IsDBNull(DReader.Item("Aging_D_Date")) Then
                Txt_D_Date.Text = DReader.Item("Aging_D_Date")
            End If
        End If

        DReader.Close()

        Conn.Close()
    End Sub
    Private Sub Txt_LAMPS_NO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_LAMPS_NO.KeyPress
        If Label2.Visible = True Then
            Label2.Visible = False
        End If
    End Sub

    Private Sub Txt_ampere3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ampere3.KeyPress
        '限制TextBox只能輸入數字
        If (ChrW(Asc("0")) <= e.KeyChar And e.KeyChar <= ChrW(Asc("9"))) Or e.KeyChar = ChrW(Asc(".")) Then '只準0~9和小數點
            Exit Sub
        End If
        If e.KeyChar = ChrW(8) Then '如果想要能用 backspace 鍵
            Exit Sub
        End If
        e.KeyChar = Nothing
        ''------------------------------------------------------------------
    End Sub

    Private Sub Btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_save.Click
        If Txt_LAMPS_NO.Text = "" Then
            MsgBox(" 成燈碼 不能為空值!!" & vbCrLf)
            Txt_LAMPS_NO.Focus()
            Return
        End If

        Conn.Open()

        '明細資料判斷Aging.Aging_D 
        Dim DSQL_str As String = "SELECT * FROM Aging_D WHERE LAMPS_NO = '" & Txt_LAMPS_NO.Text & "'"
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader
        DReader = DSQL_Cmd.ExecuteReader()
        If DReader.Read() Then     '判斷檔尾 有重複資料
            DReader.Close()
            '修改明細資料
            Try
                Dim Update_str As String = "UPDATE Aging_D SET Ballast_NO ='" & Txt_Ballast_NO.Text & "'," _
                & " ampere3 =" & Txt_ampere3.Text & "," _
                & " SYS_Date ='" & DateString & "'," _
                & " SYS_UID ='" & Login.ALL_UserID & "'" _
                & " WHERE LAMPS_NO = '" & Txt_LAMPS_NO.Text & "'"

                Dim Update_Cmd As New SqlCommand(Update_str, Conn)
                Update_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
            Catch ex As Exception
                MsgBox("修改明細資料失敗!!" & vbCrLf & ex.Message)
            End Try

        Else
            DReader.Close()
            '新增明細資料

            '新增工單No.
            Dim Aging_No_str As String = Mid(Trim(Txt_LAMPS_NO.Text), 1, 9)

            Try
                Dim Inser_str As String = "INSERT INTO aging_D (Aging_No,LAMPS_NO,Ballast_NO,ampere3,"
                Inser_str &= " SYS_Date,SYS_UID) VALUES "
                Inser_str &= " ('" & Aging_No_str & "','" & Txt_LAMPS_NO.Text & "','" & Txt_Ballast_NO.Text & "'," & Txt_ampere3.Text & ",'"
                Inser_str &= DateString & "','" & Login.ALL_UserID & "')"

                Dim Inser_Cmd As New SqlCommand(Inser_str, Conn)
                Inser_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
            Catch ex As Exception
                MsgBox("新增明細資料失敗!!" & vbCrLf & ex.Message)
            End Try

        End If

        '畫面處理()

        Txt_LAMPS_NO.Text = ""
        Txt_Ballast_NO.Text = ""

        Txt_ampere3.Text = 0.0


        Txt_LAMPS_NO.Focus()

        Conn.Close()
    End Sub
End Class