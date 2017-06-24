''MBT程式
''          20100601 by ice 謝禎皓

Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class PRQA
    ''----------------------抓config檔的ConnectionString
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()
    Dim Conn As SqlConnection = New SqlConnection(connectionString)


    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub Txt_No_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_No.Leave
        '解決當機造成資料庫開啟狀態
        If Conn.State = 1 Then
            Conn.Close()
        End If


        '資料搜尋帶入

        Conn.Open()

        '單頭資料搜尋PRQA_H

        Dim SQL_str As String = "SELECT * FROM PRQA_H WHERE PRQA_NO ='" & Txt_No.Text & "'"
        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        Dim Reader As SqlDataReader
        Reader = SQL_Cmd.ExecuteReader()
        If Reader.Read() Then     '判斷檔尾 有資料帶入單頭資料
            Cmb_SOURCE_KD.Text = Reader.Item("SOURCE_KD")
            Txt_SOURCE_NO.Text = Reader.Item("SOURCE_NO")

            Txt_Date.Text = Reader.Item("PRQA_DATE")
            Cmb_PRQA_KD.Text = Reader.Item("PRQA_KD_NO")
            Cmb_PRQA_TYPE.Text = Reader.Item("PRQA_TYPE_NO")

            Cmb_PRQA_PRI.Text = Reader.Item("PRQA_PRI")
            Cmb_Status.Text = Reader.Item("Status")

            Txt_QA_EXPL1.Text = Reader.Item("QA_EXPL1")
            Txt_QA_EXPL2.Text = Reader.Item("QA_EXPL2")
            Txt_QA_EXPL3.Text = Reader.Item("QA_EXPL3")
            Txt_QA_EXPL4.Text = Reader.Item("QA_EXPL4")

            Cmb_PRQA_User_ID.Text = Reader.Item("PRQA_User_ID")

            Reader.Close()

            '畫面控制
            Btn_SOURCE.Enabled = False
            Btn_add.Enabled = False
            Btn_update.Enabled = True
            Btn_del.Enabled = True

            Dim select_str As String = "SELECT LAMPS_NO FROM PRQA_D WHERE PRQA_NO ='" & Txt_No.Text & "'"
            Dim myadapter As New SqlDataAdapter(select_str, Conn)
            Dim mydataset As New DataSet()
            myadapter.Fill(mydataset, "PRQA_D")

            DataGridView1.DataSource = mydataset.Tables("PRQA_D")



        Else    '無資料  放入預設值

            'Cmb_SOURCE_KD.Text = ""
            'Txt_SOURCE_NO.Text = ""

            Txt_Date.Text = DateString
            Cmb_PRQA_KD.Text = ""
            Cmb_PRQA_TYPE.Text = ""

            Cmb_PRQA_PRI.Text = "M"
            Cmb_Status.Text = "O"

            Txt_QA_EXPL1.Text = ""
            Txt_QA_EXPL2.Text = ""
            Txt_QA_EXPL3.Text = ""
            Txt_QA_EXPL4.Text = ""

            Cmb_PRQA_User_ID.Text = Login.ALL_UserID

            Reader.Close()

            '畫面控制
            Btn_SOURCE.Enabled = True
            Btn_add.Enabled = True
            Btn_update.Enabled = False
            Btn_del.Enabled = False

            DataGridView1.DataSource = Nothing


        End If

        Conn.Close()
    End Sub

    Private Sub Btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_add.Click
        If Txt_No.Text = "" Then
            MsgBox(" 不良分析單號NO 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If
        If Cmb_PRQA_KD.Text = "" Then
            MsgBox(" 異常物件 不能為空值!!" & vbCrLf)
            Cmb_PRQA_KD.Focus()
            Return
        End If
        If Cmb_PRQA_TYPE.Text = "" Then
            MsgBox(" 異常分類 不能為空值!!" & vbCrLf)
            Cmb_PRQA_TYPE.Focus()
            Return
        End If


        Conn.Open()

        '資料判斷PRQA_H 
        Dim SQL_str As String = "SELECT * FROM PRQA_H WHERE PRQA_NO ='" & Txt_No.Text & "'"
        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        Dim Reader As SqlDataReader
        Reader = SQL_Cmd.ExecuteReader()
        If Reader.Read() Then     '判斷檔尾 有重複資料
            MsgBox("該不良分析單號NO: [" & Txt_No.Text & " ] 有重複資料,如要修改請按 修改 儲存資料!!" & vbCrLf)
            Conn.Close()
            Return
        End If
        Reader.Close()

        '新增明細資料
        Try
            Dim Inser_str As String = "INSERT INTO PRQA_H (PRQA_NO,SOURCE_KD,SOURCE_NO,PRQA_DATE,"
            Inser_str &= " PRQA_KD_NO,PRQA_TYPE_NO,"
            Inser_str &= " PRQA_PRI,Status,"
            Inser_str &= " QA_EXPL1,QA_EXPL2,QA_EXPL3,QA_EXPL4,PRQA_User_ID,"
            Inser_str &= " SYS_USER,SYS_DATE) VALUES "
            Inser_str &= " ('" & Txt_No.Text & "','" & Cmb_SOURCE_KD.Text & "','" & Txt_SOURCE_NO.Text & "','" & Txt_Date.Text & "','"
            Inser_str &= Cmb_PRQA_KD.Text & "','" & Cmb_PRQA_TYPE.Text & "','"
            Inser_str &= Cmb_PRQA_PRI.Text & "','" & Cmb_Status.Text & "','"
            Inser_str &= Txt_QA_EXPL1.Text & "','" & Txt_QA_EXPL2.Text & "','" & Txt_QA_EXPL3.Text & "','" & Txt_QA_EXPL4.Text & "','" & Cmb_PRQA_User_ID.Text & "','"
            Inser_str &= Login.ALL_UserID & "','" & DateString & "')"

            Dim Inser_Cmd As New SqlCommand(Inser_str, Conn)
            Inser_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
        Catch ex As Exception
            MsgBox("新增明細資料失敗!!" & vbCrLf & ex.Message)
        End Try


        ''畫面處理()
        Txt_No.Focus()

        Conn.Close()
    End Sub

    Private Sub Btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_update.Click
        If Txt_No.Text = "" Then
            MsgBox(" 不良分析單號NO 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If
        If Cmb_PRQA_KD.Text = "" Then
            MsgBox(" 異常物件 不能為空值!!" & vbCrLf)
            Cmb_PRQA_KD.Focus()
            Return
        End If
        If Cmb_PRQA_TYPE.Text = "" Then
            MsgBox(" 異常分類 不能為空值!!" & vbCrLf)
            Cmb_PRQA_TYPE.Focus()
            Return
        End If

        Conn.Open()

        ' ''資料處理

        ''資料判斷PRQA_H
        Dim DSQL_str As String = "SELECT * FROM PRQA_H WHERE PRQA_NO ='" & Txt_No.Text & "'"
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader
        DReader = DSQL_Cmd.ExecuteReader()
        If Not DReader.Read() Then     '判斷檔尾 無資料
            MsgBox("該不良分析單號NO: [" & Txt_No.Text & " ] 沒資料,如要新增請按新增儲存資料!!" & vbCrLf)
            Conn.Close()
            Return
        End If
        DReader.Close()

        '修改明細資料
        Try

            Dim Update_str As String = "UPDATE PRQA_H SET SOURCE_KD ='" & Cmb_SOURCE_KD.Text & "'," _
            & " SOURCE_NO ='" & Txt_SOURCE_NO.Text & "'," _
            & " PRQA_DATE ='" & Txt_Date.Text & "'," _
            & " PRQA_KD_NO ='" & Cmb_PRQA_KD.Text & "'," _
            & " PRQA_TYPE_NO ='" & Cmb_PRQA_TYPE.Text & "'," _
            & " PRQA_PRI ='" & Cmb_PRQA_PRI.Text & "'," _
            & " Status ='" & Cmb_Status.Text & "'," _
            & " QA_EXPL1 ='" & Txt_QA_EXPL1.Text & "'," _
            & " QA_EXPL2 ='" & Txt_QA_EXPL2.Text & "'," _
            & " QA_EXPL3 ='" & Txt_QA_EXPL3.Text & "'," _
            & " QA_EXPL4 ='" & Txt_QA_EXPL4.Text & "'," _
            & " PRQA_User_ID ='" & Cmb_PRQA_User_ID.Text & "'," _
            & " SYS_USER ='" & Login.ALL_UserID & "'," _
            & " SYS_DATE ='" & DateString & "'" _
            & " WHERE PRQA_NO = '" & Txt_No.Text & "'"

            Dim Update_Cmd As New SqlCommand(Update_str, Conn)
            Update_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
        Catch ex As Exception
            MsgBox("修改明細資料失敗!!" & vbCrLf & ex.Message)
        End Try


        '畫面處理()
        Txt_No.Focus()

        Conn.Close()
    End Sub

    Private Sub Btn_del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_del.Click
        If Txt_No.Text = "" Then
            MsgBox(" 不良分析單號NO 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If

        ' 顯示確認刪除的訊息對話方塊
        Dim ret As Integer ' MsgBox的傳回值
        ret = MsgBox("是否真的要刪除該不良分析單號NO: [" & Txt_No.Text & " ] 資料!!", vbYesNo, "確認刪除")
        If ret <> vbYes Then
            Txt_No.Focus()
            Return
        End If

        Conn.Open()

        '資料判斷PRQA_H
        Dim DSQL_str As String = "SELECT * FROM PRQA_H WHERE PRQA_NO = '" & Txt_No.Text & "'"
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader
        DReader = DSQL_Cmd.ExecuteReader()
        If Not DReader.Read() Then     '判斷檔尾 無重複資料
            MsgBox("該不良分析單號NO: [" & Txt_No.Text & " ] 沒資料,請確認刪除資料是否正確!!" & vbCrLf)
            Conn.Close()
            Return
        End If
        DReader.Close()

        '刪除資料
        Try
            Dim del_str As String = "Delete FROM PRQA_H WHERE PRQA_NO = '" & Txt_No.Text & "'"

            Dim del_Cmd As New SqlCommand(del_str, Conn)
            del_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
        Catch ex As Exception
            MsgBox("刪除資料失敗!!" & vbCrLf & ex.Message)
        End Try


        '畫面處理()
        Txt_No.Focus()

        Conn.Close()
    End Sub

    Private Sub PRQA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.WindowState = FormWindowState.Maximized '視窗最大化

        Conn.Open()

        '異常物件檔帶入異常物件
        Dim SELECT_str As String = "SELECT PRQA_KD_NO,PRQA_KD_NO+'-'+PRQA_KD_ITEM As Rname FROM PRQA_KD"

        Dim myAdapter As New SqlDataAdapter(SELECT_str, Conn)
        Dim myDataSet As New DataSet()
        myAdapter.Fill(myDataSet, "PRQA_KD")
        Cmb_PRQA_KD.DataSource = myDataSet.Tables("PRQA_KD")
        Cmb_PRQA_KD.DisplayMember = "Rname"
        Cmb_PRQA_KD.ValueMember = "PRQA_KD_NO"

        '異常分類
        SELECT_str = "SELECT PRQA_TYPE_NO,PRQA_TYPE_NO+'-'+PRQA_TYPE_ITEM As Rname FROM PRQA_TYPE"
        myAdapter = New SqlDataAdapter(SELECT_str, Conn)
        myAdapter.Fill(myDataSet, "PRQA_TYPE")
        Cmb_PRQA_TYPE.DataSource = myDataSet.Tables("PRQA_TYPE")
        Cmb_PRQA_TYPE.DisplayMember = "Rname"
        Cmb_PRQA_TYPE.ValueMember = "PRQA_TYPE_NO"

        '處理人員
        'SELECT_str = "SELECT User_ID,User_ID+'-'+User_Name As Rname FROM Users WHERE Aging_LD ='0'"
        SELECT_str = "SELECT User_ID,User_ID+'-'+User_Name As Rname FROM Users"
        myAdapter = New SqlDataAdapter(SELECT_str, Conn)
        myAdapter.Fill(myDataSet, "Users")
        Cmb_PRQA_User_ID.DataSource = myDataSet.Tables("Users")
        Cmb_PRQA_User_ID.DisplayMember = "Rname"
        Cmb_PRQA_User_ID.ValueMember = "User_ID"

        Conn.Close()

        ''使用者檔帶入操作員名字
        'Dim i As Integer

        ''SELECT_str = "SELECT User_Name FROM Users WHERE User_Type ='2'"
        'SELECT_str = "SELECT User_Name FROM Users"
        'myAdapter = New OleDbDataAdapter(SELECT_str, Conn)
        'myAdapter.Fill(myDataSet, "Users2")
        'myDataTable = myDataSet.Tables("Users2")
        'For i = 0 To myDataTable.Rows.Count - 1
        '    Txt_User.Items.Add(myDataTable.Rows(i).Item("User_Name"))
        'Next

        ''權限畫面控制 前段
        'If LoginForm1.ALL_UserT = "1" Then
        '    Btn_Hdel.Enabled = True
        'Else
        '    Btn_Hdel.Enabled = False
        'End If



    End Sub

    Private Sub Btn_SOURCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_SOURCE.Click

    End Sub

    Private Sub Cmb_SOURCE_KD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_SOURCE_KD.Leave
        '修正要存入data的值 會與畫面看到的有點不太一樣
        'If Cmb_SOURCE_KD.Text <> "" Then
        '    Cmb_SOURCE_KD.Text = Cmb_SOURCE_KD.SelectedValue.ToString()
        'End If
    End Sub

    Private Sub Cmb_PRQA_KD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_PRQA_KD.Leave
        '修正要存入data的值 會與畫面看到的有點不太一樣
        If Cmb_PRQA_KD.Text <> "" Then
            Cmb_PRQA_KD.Text = Cmb_PRQA_KD.SelectedValue.ToString()
        End If
    End Sub

    Private Sub Cmb_PRQA_TYPE_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_PRQA_TYPE.Leave
        '修正要存入data的值 會與畫面看到的有點不太一樣
        If Cmb_PRQA_TYPE.Text <> "" Then
            Cmb_PRQA_TYPE.Text = Cmb_PRQA_TYPE.SelectedValue.ToString()
        End If
    End Sub

    Private Sub Cmb_PRQA_PRI_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_PRQA_PRI.Leave
        '修正要存入data的值 會與畫面看到的有點不太一樣
        'If Cmb_PRQA_PRI.Text <> "" Then
        '    Cmb_PRQA_PRI.Text = Cmb_PRQA_PRI.SelectedValue.ToString()
        'End If
    End Sub

    Private Sub Cmb_Status_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Status.Leave
        '修正要存入data的值 會與畫面看到的有點不太一樣
        'If Cmb_Status.Text <> "" Then
        '    Cmb_Status.Text = Cmb_Status.SelectedValue.ToString()
        'End If
    End Sub

    Private Sub Cmb_PRQA_User_ID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_PRQA_User_ID.Leave
        '修正要存入data的值 會與畫面看到的有點不太一樣
        If Cmb_PRQA_User_ID.Text <> "" Then
            Cmb_PRQA_User_ID.Text = Cmb_PRQA_User_ID.SelectedValue.ToString()
        End If
    End Sub


    Private Sub Btn_Dadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Dadd.Click
        If Txt_No.Text = "" Then
            MsgBox(" 不良分析單號NO 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If
        If Txt_LAMPS_NO.Text = "" Then
            MsgBox(" 成燈碼 不能為空值!!" & vbCrLf)
            Txt_LAMPS_NO.Focus()
            Return
        End If

        Conn.Open()

        '資料判斷PRQA_H 
        Dim SQL_str As String = "SELECT * FROM PRQA_H WHERE PRQA_NO ='" & Txt_No.Text & "'"
        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        Dim Reader As SqlDataReader
        Reader = SQL_Cmd.ExecuteReader()
        If Not Reader.Read() Then     '判斷檔尾 無資料
            MsgBox("該不良分析單號NO: [" & Txt_No.Text & " ] 無資料或未存檔,請先按 新增 儲存資料!!" & vbCrLf)
            Conn.Close()
            Return
        End If
        Reader.Close()

        '資料判斷PRQA_D 
        Dim DSQL_str As String = "SELECT * FROM PRQA_D WHERE PRQA_NO ='" & Txt_No.Text & "' AND LAMPS_NO ='" & Txt_LAMPS_NO.Text & "'"
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader
        DReader = DSQL_Cmd.ExecuteReader()
        If DReader.Read() Then     '判斷檔尾 有重複資料
            MsgBox("該成燈碼: [" & Txt_LAMPS_NO.Text & " ] 有重複資料!!" & vbCrLf)
            Conn.Close()
            Return
        End If
        DReader.Close()

        '新增明細資料
        Try
            Dim Inser_str As String = "INSERT INTO PRQA_D (PRQA_NO,LAMPS_NO,SYS_USER,SYS_DATE) VALUES "
            Inser_str &= " ('" & Txt_No.Text & "','" & Txt_LAMPS_NO.Text & "','" & Login.ALL_UserID & "','" & DateString & "')"

            Dim Inser_Cmd As New SqlCommand(Inser_str, Conn)
            Inser_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
        Catch ex As Exception
            MsgBox("新增明細資料失敗!!" & vbCrLf & ex.Message)
        End Try


        ''畫面處理()
        Dim select_str As String = "SELECT LAMPS_NO FROM PRQA_D WHERE PRQA_NO ='" & Txt_No.Text & "'"
        Dim myadapter As New SqlDataAdapter(select_str, Conn)
        Dim mydataset As New DataSet()
        myadapter.Fill(mydataset, "PRQA_D")

        DataGridView1.DataSource = mydataset.Tables("PRQA_D")

        Txt_LAMPS_NO.Text = ""
        Txt_LAMPS_NO.Focus()

        Conn.Close()
    End Sub

    Private Sub Btn_Ddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ddel.Click
        If Txt_No.Text = "" Then
            MsgBox(" 不良分析單號NO 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If
        If Txt_LAMPS_NO.Text = "" Then
            MsgBox(" 成燈碼 不能為空值!!" & vbCrLf)
            Txt_LAMPS_NO.Focus()
            Return
        End If

        ' 顯示確認刪除的訊息對話方塊
        Dim ret As Integer ' MsgBox的傳回值
        ret = MsgBox("是否真的要刪除該成燈碼: [" & Txt_LAMPS_NO.Text & " ] 資料!!", vbYesNo, "確認刪除")
        If ret <> vbYes Then
            Txt_No.Focus()
            Return
        End If

        Conn.Open()

        '資料判斷PRQA_D 
        Dim DSQL_str As String = "SELECT * FROM PRQA_D WHERE PRQA_NO ='" & Txt_No.Text & "' AND LAMPS_NO ='" & Txt_LAMPS_NO.Text & "'"
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader
        DReader = DSQL_Cmd.ExecuteReader()
        If Not DReader.Read() Then     '判斷檔尾 無重複資料
            MsgBox("該成燈碼: [" & Txt_LAMPS_NO.Text & " ] 沒資料,請確認刪除資料是否正確!!" & vbCrLf)
            Conn.Close()
            Return
        End If
        DReader.Close()

        '刪除資料
        Try
            Dim del_str As String = "Delete FROM PRQA_D WHERE PRQA_NO ='" & Txt_No.Text & "' AND LAMPS_NO ='" & Txt_LAMPS_NO.Text & "'"

            Dim del_Cmd As New SqlCommand(del_str, Conn)
            del_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
        Catch ex As Exception
            MsgBox("刪除資料失敗!!" & vbCrLf & ex.Message)
        End Try


        ''畫面處理()
        Dim select_str As String = "SELECT LAMPS_NO FROM PRQA_D WHERE PRQA_NO ='" & Txt_No.Text & "'"
        Dim myadapter As New SqlDataAdapter(select_str, Conn)
        Dim mydataset As New DataSet()
        myadapter.Fill(mydataset, "PRQA_D")

        DataGridView1.DataSource = mydataset.Tables("PRQA_D")

        Txt_LAMPS_NO.Text = ""
        Txt_LAMPS_NO.Focus()

        Conn.Close()
    End Sub

    Private Sub DataGridView1_RowStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DataGridView1.RowStateChanged
        If e.Row.Cells.Item(0).Value <> Nothing Then
            Txt_LAMPS_NO.Text = e.Row.Cells.Item(0).Value.ToString()
            'Txt_D_Date.Text = e.Row.Cells.Item(1).Value.ToString()
            'Cmb_Car.Text = e.Row.Cells.Item(2).Value.ToString()
        End If
    End Sub
End Class