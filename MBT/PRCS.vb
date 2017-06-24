''MBT程式
''          20101201 by ice 謝禎皓

Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient



Public Class PRCS
    ''----------------------抓config檔的ConnectionString
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()
    Dim Conn As SqlConnection = New SqlConnection(connectionString)


    Private Sub PRCS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Cmb_PRCS_User_ID.DataSource = myDataSet.Tables("Users")
        Cmb_PRCS_User_ID.DisplayMember = "Rname"
        Cmb_PRCS_User_ID.ValueMember = "User_ID"

        Conn.Close()
    End Sub

    Private Sub Cmb_SOURCE_KD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_PRCS_KD.Leave
        '修正要存入data的值 會與畫面看到的有點不太一樣
        'If Cmb_SOURCE_KD.Text <> "" Then
        '    Cmb_SOURCE_KD.Text = Cmb_SOURCE_KD.SelectedValue.ToString()
        'End If
    End Sub

    Private Sub Txt_No_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_No.Leave
        '解決當機造成資料庫開啟狀態
        If Conn.State = 1 Then
            Conn.Close()
        End If


        '資料搜尋帶入

        Conn.Open()

        '單頭資料搜尋PRCS_H

        Dim SQL_str As String = "SELECT * FROM PRCS_H WHERE PRCS_NO ='" & Txt_No.Text & "'"
        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        Dim Reader As SqlDataReader
        Reader = SQL_Cmd.ExecuteReader()
        If Reader.Read() Then     '判斷檔尾 有資料帶入單頭資料
            Cmb_PRCS_KD.Text = Reader.Item("PRCS_KD")

            Txt_Date.Text = Reader.Item("PRCS_DATE")
            Cmb_PRQA_KD.Text = Reader.Item("PRQA_KD_NO")
            Cmb_PRQA_TYPE.Text = Reader.Item("PRQA_TYPE_NO")

            Cmb_PRQA_PRI.Text = Reader.Item("PRQA_PRI")
            Cmb_Status.Text = Reader.Item("Status")

            Txt_QA_EXPL1.Text = Reader.Item("QA_EXPL1")
            Txt_QA_EXPL2.Text = Reader.Item("QA_EXPL2")

            Cmb_PRCS_User_ID.Text = Reader.Item("PRCS_User_ID")

            Reader.Close()

            '畫面控制
            Btn_add.Enabled = False
            Btn_update.Enabled = True
            Btn_del.Enabled = True


            '(Ω)
            Dim select_str As String = "SELECT LAMPS_NO As 成燈碼,PRQA_NO As 不良分析單號 FROM PRCS_D WHERE PRCS_NO ='" & Txt_No.Text & "'"
            Dim myadapter As New SqlDataAdapter(select_str, Conn)
            Dim mydataset As New DataSet()
            myadapter.Fill(mydataset, "PRCS_D")

            DataGridView1.DataSource = mydataset.Tables("PRCS_D")

            Dim select_str2 As String = "SELECT Ballast_NO As 安定器碼,PRQA_NO As 不良分析單號 FROM PRCS_D2 WHERE PRCS_NO ='" & Txt_No.Text & "'"
            Dim myadapter2 As New SqlDataAdapter(select_str2, Conn)
            Dim mydataset2 As New DataSet()
            myadapter2.Fill(mydataset2, "PRCS_D2")

            DataGridView2.DataSource = mydataset2.Tables("PRCS_D2")

        Else    '無資料  放入預設值

            Txt_Date.Text = DateString
            Cmb_PRQA_KD.Text = ""
            Cmb_PRQA_TYPE.Text = ""

            Cmb_PRQA_PRI.Text = "M"
            Cmb_Status.Text = "O"

            Txt_QA_EXPL1.Text = ""
            Txt_QA_EXPL2.Text = ""


            Cmb_PRCS_User_ID.Text = Login.ALL_UserID

            Reader.Close()

            '畫面控制
            Btn_add.Enabled = True
            Btn_update.Enabled = False
            Btn_del.Enabled = False

            DataGridView1.DataSource = Nothing
            DataGridView2.DataSource = Nothing

        End If

        Conn.Close()
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


    Private Sub Btn_Dadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Dadd.Click
        If Txt_No.Text = "" Then
            MsgBox(" 客訴/品質異常單號 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If
        If Txt_LAMPS_NO.Text = "" Then
            MsgBox(" 成燈碼 不能為空值!!" & vbCrLf)
            Txt_LAMPS_NO.Focus()
            Return
        End If

        Conn.Open()

        '資料判斷PRCS_H 
        Dim SQL_str As String = "SELECT * FROM PRCS_H WHERE PRCS_NO ='" & Txt_No.Text & "'"
        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        Dim Reader As SqlDataReader
        Reader = SQL_Cmd.ExecuteReader()
        If Not Reader.Read() Then     '判斷檔尾 無資料
            MsgBox("該客訴/品質異常單號 [" & Txt_No.Text & " ] 無資料或未存檔,請先按 新增 儲存資料!!" & vbCrLf)
            Conn.Close()
            Return
        End If
        Reader.Close()

        '資料判斷PRCS_D 
        Dim DSQL_str As String = "SELECT * FROM PRCS_D WHERE PRCS_NO ='" & Txt_No.Text & "' AND LAMPS_NO ='" & Txt_LAMPS_NO.Text & "'"
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader
        DReader = DSQL_Cmd.ExecuteReader()
        If DReader.Read() Then     '判斷檔尾 有重複資料
            'MsgBox("該成燈碼: [" & Txt_LAMPS_NO.Text & " ] 有重複資料!!" & vbCrLf)
            'Conn.Close()
            'Return

            DReader.Close()
            '修改明細資料
            Try

                Dim Update_str As String = "UPDATE PRCS_D SET PRQA_NO ='" & Txt_D_PRQA_NO.Text & "'," _
                & " SYS_USER ='" & Login.ALL_UserID & "'," _
                & " SYS_DATE ='" & DateString & "'" _
                & " WHERE PRCS_NO ='" & Txt_No.Text & "' AND LAMPS_NO ='" & Txt_LAMPS_NO.Text & "'"

                Dim Update_Cmd As New SqlCommand(Update_str, Conn)
                Update_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
            Catch ex As Exception
                MsgBox("修改明細資料失敗!!" & vbCrLf & ex.Message)
            End Try


        Else
            DReader.Close()

            '新增明細資料
            Try
                Dim Inser_str As String = "INSERT INTO PRCS_D (PRCS_NO,LAMPS_NO,PRQA_NO,SYS_USER,SYS_DATE) VALUES "
                Inser_str &= " ('" & Txt_No.Text & "','" & Txt_LAMPS_NO.Text & "','" & Txt_D_PRQA_NO.Text & "','" & Login.ALL_UserID & "','" & DateString & "')"

                Dim Inser_Cmd As New SqlCommand(Inser_str, Conn)
                Inser_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
            Catch ex As Exception
                MsgBox("新增明細資料失敗!!" & vbCrLf & ex.Message)
            End Try



        End If

        ''畫面處理()
        '(Ω)
        Dim select_str As String = "SELECT LAMPS_NO As 成燈碼,PRQA_NO As 不良分析單號 FROM PRCS_D WHERE PRCS_NO ='" & Txt_No.Text & "'"
        Dim myadapter As New SqlDataAdapter(select_str, Conn)
        Dim mydataset As New DataSet()
        myadapter.Fill(mydataset, "PRCS_D")

        DataGridView1.DataSource = mydataset.Tables("PRCS_D")

        Txt_LAMPS_NO.Text = ""
        Txt_D_PRQA_NO.Text = ""

        Txt_LAMPS_NO.Focus()

        Conn.Close()
    End Sub

    Private Sub Btn_Ddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ddel.Click
        If Txt_No.Text = "" Then
            MsgBox(" 客訴/品質異常單號 不能為空值!!" & vbCrLf)
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

        '資料判斷PRCS_D 
        Dim DSQL_str As String = "SELECT * FROM PRCS_D WHERE PRCS_NO ='" & Txt_No.Text & "' AND LAMPS_NO ='" & Txt_LAMPS_NO.Text & "'"
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
            Dim del_str As String = "Delete FROM PRCS_D WHERE PRCS_NO ='" & Txt_No.Text & "' AND LAMPS_NO ='" & Txt_LAMPS_NO.Text & "'"

            Dim del_Cmd As New SqlCommand(del_str, Conn)
            del_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
        Catch ex As Exception
            MsgBox("刪除資料失敗!!" & vbCrLf & ex.Message)
        End Try


        ''畫面處理()
        '(Ω)
        Dim select_str As String = "SELECT LAMPS_NO As 成燈碼,PRQA_NO As 不良分析單號 FROM PRCS_D WHERE PRCS_NO ='" & Txt_No.Text & "'"
        Dim myadapter As New SqlDataAdapter(select_str, Conn)
        Dim mydataset As New DataSet()
        myadapter.Fill(mydataset, "PRCS_D")

        DataGridView1.DataSource = mydataset.Tables("PRCS_D")

        Txt_LAMPS_NO.Text = ""
        Txt_D_PRQA_NO.Text = ""

        Txt_LAMPS_NO.Focus()

        Conn.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub Btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_add.Click
        If Txt_No.Text = "" Then
            MsgBox(" 客訴/品質異常單號 不能為空值!!" & vbCrLf)
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

        '資料判斷PRCS_H 
        Dim SQL_str As String = "SELECT * FROM PRCS_H WHERE PRCS_NO ='" & Txt_No.Text & "'"
        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        Dim Reader As SqlDataReader
        Reader = SQL_Cmd.ExecuteReader()
        If Reader.Read() Then     '判斷檔尾 有重複資料
            MsgBox("該客訴/品質異常單號: [" & Txt_No.Text & " ] 有重複資料,如要修改請按 修改 儲存資料!!" & vbCrLf)
            Conn.Close()
            Return
        End If
        Reader.Close()

        '新增明細資料
        Try
            Dim Inser_str As String = "INSERT INTO PRCS_H (PRCS_NO,PRCS_KD,PRCS_DATE,"
            Inser_str &= " PRQA_KD_NO,PRQA_TYPE_NO,"
            Inser_str &= " PRQA_PRI,Status,"
            Inser_str &= " QA_EXPL1,QA_EXPL2,PRCS_User_ID,"
            Inser_str &= " SYS_USER,SYS_DATE) VALUES "
            Inser_str &= " ('" & Txt_No.Text & "','" & Cmb_PRCS_KD.Text & "','" & Txt_Date.Text & "','"
            Inser_str &= Cmb_PRQA_KD.Text & "','" & Cmb_PRQA_TYPE.Text & "','"
            Inser_str &= Cmb_PRQA_PRI.Text & "','" & Cmb_Status.Text & "','"
            Inser_str &= Txt_QA_EXPL1.Text & "','" & Txt_QA_EXPL2.Text & "','" & Cmb_PRCS_User_ID.Text & "','"
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
            MsgBox(" 客訴/品質異常單號 不能為空值!!" & vbCrLf)
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

        ''資料判斷PRCS_H
        Dim DSQL_str As String = "SELECT * FROM PRCS_H WHERE PRCS_NO ='" & Txt_No.Text & "'"
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader
        DReader = DSQL_Cmd.ExecuteReader()
        If Not DReader.Read() Then     '判斷檔尾 無資料
            MsgBox("該客訴/品質異常單號: [" & Txt_No.Text & " ] 沒資料,如要新增請按新增儲存資料!!" & vbCrLf)
            Conn.Close()
            Return
        End If
        DReader.Close()

        '修改明細資料
        Try

            Dim Update_str As String = "UPDATE PRCS_H SET PRCS_KD ='" & Cmb_PRCS_KD.Text & "'," _
            & " PRCS_DATE ='" & Txt_Date.Text & "'," _
            & " PRQA_KD_NO ='" & Cmb_PRQA_KD.Text & "'," _
            & " PRQA_TYPE_NO ='" & Cmb_PRQA_TYPE.Text & "'," _
            & " PRQA_PRI ='" & Cmb_PRQA_PRI.Text & "'," _
            & " Status ='" & Cmb_Status.Text & "'," _
            & " QA_EXPL1 ='" & Txt_QA_EXPL1.Text & "'," _
            & " QA_EXPL2 ='" & Txt_QA_EXPL2.Text & "'," _
            & " PRCS_User_ID ='" & Cmb_PRCS_User_ID.Text & "'," _
            & " SYS_USER ='" & Login.ALL_UserID & "'," _
            & " SYS_DATE ='" & DateString & "'" _
            & " WHERE PRCS_NO = '" & Txt_No.Text & "'"

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
            MsgBox(" 客訴/品質異常單號 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If

        ' 顯示確認刪除的訊息對話方塊
        Dim ret As Integer ' MsgBox的傳回值
        ret = MsgBox("是否真的要刪除該客訴/品質異常單號: [" & Txt_No.Text & " ] 資料!!", vbYesNo, "確認刪除")
        If ret <> vbYes Then
            Txt_No.Focus()
            Return
        End If

        Conn.Open()

        '資料判斷PRCS_H
        Dim DSQL_str As String = "SELECT * FROM PRCS_H WHERE PRCS_NO = '" & Txt_No.Text & "'"
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader
        DReader = DSQL_Cmd.ExecuteReader()
        If Not DReader.Read() Then     '判斷檔尾 無重複資料
            MsgBox("該客訴/品質異常單號: [" & Txt_No.Text & " ] 沒資料,請確認刪除資料是否正確!!" & vbCrLf)
            Conn.Close()
            Return
        End If
        DReader.Close()

        '刪除資料
        Try
            Dim del_str As String = "Delete FROM PRCS_H WHERE PRCS_NO = '" & Txt_No.Text & "'"

            Dim del_Cmd As New SqlCommand(del_str, Conn)
            del_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
        Catch ex As Exception
            MsgBox("刪除資料失敗!!" & vbCrLf & ex.Message)
        End Try


        '畫面處理()
        Txt_No.Focus()

        Conn.Close()
    End Sub

    Private Sub DataGridView1_RowStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DataGridView1.RowStateChanged
        If e.Row.Cells.Item(0).Value <> Nothing Then
            Txt_LAMPS_NO.Text = e.Row.Cells.Item(0).Value.ToString()
            Txt_D_PRQA_NO.Text = e.Row.Cells.Item(1).Value.ToString()
            'Cmb_Car.Text = e.Row.Cells.Item(2).Value.ToString()
        End If
    End Sub

    Private Sub Btn_Dadd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Dadd2.Click
        If Txt_No.Text = "" Then
            MsgBox(" 客訴/品質異常單號 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If
        If Txt_Ballast_NO.Text = "" Then
            MsgBox(" 安定器碼 不能為空值!!" & vbCrLf)
            Txt_Ballast_NO.Focus()
            Return
        End If

        Conn.Open()

        '資料判斷PRCS_H 
        Dim SQL_str As String = "SELECT * FROM PRCS_H WHERE PRCS_NO ='" & Txt_No.Text & "'"
        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        Dim Reader As SqlDataReader
        Reader = SQL_Cmd.ExecuteReader()
        If Not Reader.Read() Then     '判斷檔尾 無資料
            MsgBox("該客訴/品質異常單號 [" & Txt_No.Text & " ] 無資料或未存檔,請先按 新增 儲存資料!!" & vbCrLf)
            Conn.Close()
            Return
        End If
        Reader.Close()

        '資料判斷PRCS_D2 
        Dim DSQL_str As String = "SELECT * FROM PRCS_D2 WHERE PRCS_NO ='" & Txt_No.Text & "' AND Ballast_NO ='" & Txt_Ballast_NO.Text & "'"
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader
        DReader = DSQL_Cmd.ExecuteReader()
        If DReader.Read() Then     '判斷檔尾 有重複資料
            DReader.Close()
            '修改明細資料
            Try

                Dim Update_str As String = "UPDATE PRCS_D2 SET PRQA_NO ='" & Txt_D2_PRQA_NO.Text & "'," _
                & " SYS_USER ='" & Login.ALL_UserID & "'," _
                & " SYS_DATE ='" & DateString & "'" _
                & " WHERE PRCS_NO ='" & Txt_No.Text & "' AND Ballast_NO ='" & Txt_Ballast_NO.Text & "'"

                Dim Update_Cmd As New SqlCommand(Update_str, Conn)
                Update_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
            Catch ex As Exception
                MsgBox("修改明細資料失敗!!" & vbCrLf & ex.Message)
            End Try


        Else
            DReader.Close()

            '新增明細資料
            Try
                Dim Inser_str As String = "INSERT INTO PRCS_D2 (PRCS_NO,Ballast_NO,PRQA_NO,SYS_USER,SYS_DATE) VALUES "
                Inser_str &= " ('" & Txt_No.Text & "','" & Txt_Ballast_NO.Text & "','" & Txt_D2_PRQA_NO.Text & "','" & Login.ALL_UserID & "','" & DateString & "')"

                Dim Inser_Cmd As New SqlCommand(Inser_str, Conn)
                Inser_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
            Catch ex As Exception
                MsgBox("新增明細資料失敗!!" & vbCrLf & ex.Message)
            End Try



        End If

        ''畫面處理()
        '(Ω)
        Dim select_str As String = "SELECT Ballast_NO As 安定器碼,PRQA_NO As 不良分析單號 FROM PRCS_D2 WHERE PRCS_NO ='" & Txt_No.Text & "'"
        Dim myadapter As New SqlDataAdapter(select_str, Conn)
        Dim mydataset As New DataSet()
        myadapter.Fill(mydataset, "PRCS_D2")

        DataGridView2.DataSource = mydataset.Tables("PRCS_D2")

        Txt_Ballast_NO.Text = ""
        Txt_D2_PRQA_NO.Text = ""

        Txt_Ballast_NO.Focus()

        Conn.Close()
    End Sub

    Private Sub Btn_Ddel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ddel2.Click
        If Txt_No.Text = "" Then
            MsgBox(" 客訴/品質異常單號 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If
        If Txt_Ballast_NO.Text = "" Then
            MsgBox(" 安定器碼 不能為空值!!" & vbCrLf)
            Txt_Ballast_NO.Focus()
            Return
        End If

        ' 顯示確認刪除的訊息對話方塊
        Dim ret As Integer ' MsgBox的傳回值
        ret = MsgBox("是否真的要刪除該安定器碼: [" & Txt_Ballast_NO.Text & " ] 資料!!", vbYesNo, "確認刪除")
        If ret <> vbYes Then
            Txt_No.Focus()
            Return
        End If

        Conn.Open()

        '資料判斷PRCS_D2 
        Dim DSQL_str As String = "SELECT * FROM PRCS_D2 WHERE PRCS_NO ='" & Txt_No.Text & "' AND Ballast_NO ='" & Txt_Ballast_NO.Text & "'"
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader
        DReader = DSQL_Cmd.ExecuteReader()
        If Not DReader.Read() Then     '判斷檔尾 無重複資料
            MsgBox("該安定器碼: [" & Txt_Ballast_NO.Text & " ] 沒資料,請確認刪除資料是否正確!!" & vbCrLf)
            Conn.Close()
            Return
        End If
        DReader.Close()

        '刪除資料
        Try
            Dim del_str As String = "Delete FROM PRCS_D2 WHERE PRCS_NO ='" & Txt_No.Text & "' AND Ballast_NO ='" & Txt_Ballast_NO.Text & "'"

            Dim del_Cmd As New SqlCommand(del_str, Conn)
            del_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
        Catch ex As Exception
            MsgBox("刪除資料失敗!!" & vbCrLf & ex.Message)
        End Try


        ''畫面處理()
        '(Ω)
        Dim select_str As String = "SELECT Ballast_NO As 安定器碼,PRQA_NO As 不良分析單號 FROM PRCS_D2 WHERE PRCS_NO ='" & Txt_No.Text & "'"
        Dim myadapter As New SqlDataAdapter(select_str, Conn)
        Dim mydataset As New DataSet()
        myadapter.Fill(mydataset, "PRCS_D2")

        DataGridView2.DataSource = mydataset.Tables("PRCS_D2")

        Txt_Ballast_NO.Text = ""
        Txt_D2_PRQA_NO.Text = ""

        Txt_Ballast_NO.Focus()

        Conn.Close()
    End Sub

    Private Sub DataGridView2_RowStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DataGridView2.RowStateChanged
        If e.Row.Cells.Item(0).Value <> Nothing Then
            Txt_Ballast_NO.Text = e.Row.Cells.Item(0).Value.ToString()
            Txt_D2_PRQA_NO.Text = e.Row.Cells.Item(1).Value.ToString()
            'Cmb_Car.Text = e.Row.Cells.Item(2).Value.ToString()
        End If
    End Sub
End Class