''MBT程式
''          20100721 by ice 謝禎皓

Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
'Imports CrystalDecisions.Shared


Public Class PRQA_SER
    ''----------------------抓config檔的ConnectionString
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()
    Dim Conn As SqlConnection = New SqlConnection(connectionString)

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub PRQA_SER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        '初始值
        Cmb_PRQA_KD.Text = ""

        '異常分類
        SELECT_str = "SELECT PRQA_TYPE_NO,PRQA_TYPE_NO+'-'+PRQA_TYPE_ITEM As Rname FROM PRQA_TYPE"
        myAdapter = New SqlDataAdapter(SELECT_str, Conn)
        myAdapter.Fill(myDataSet, "PRQA_TYPE")
        Cmb_PRQA_TYPE.DataSource = myDataSet.Tables("PRQA_TYPE")
        Cmb_PRQA_TYPE.DisplayMember = "Rname"
        Cmb_PRQA_TYPE.ValueMember = "PRQA_TYPE_NO"
        '初始值
        Cmb_PRQA_TYPE.Text = ""

        '處理人員
        SELECT_str = "SELECT User_ID,User_ID+'-'+User_Name As Rname FROM Users"
        myAdapter = New SqlDataAdapter(SELECT_str, Conn)
        myAdapter.Fill(myDataSet, "Users")
        Cmb_PRQA_User_ID.DataSource = myDataSet.Tables("Users")
        Cmb_PRQA_User_ID.DisplayMember = "Rname"
        Cmb_PRQA_User_ID.ValueMember = "User_ID"
        '初始值
        Cmb_PRQA_User_ID.Text = ""

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

    Private Sub Cmb_PRQA_User_ID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_PRQA_User_ID.Leave
        '修正要存入data的值 會與畫面看到的有點不太一樣
        If Cmb_PRQA_User_ID.Text <> "" Then
            Cmb_PRQA_User_ID.Text = Cmb_PRQA_User_ID.SelectedValue.ToString()
        End If
    End Sub

    Private Sub Btn_SER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_SER.Click
        '資料搜尋帶入
        Conn.Open()


        '單頭資料搜尋PRQA_H
        'Dim SQL_str As String = "SELECT * FROM PRQA_H "

        Dim SQL_str As String = "SELECT PRQA_NO As 不良分析單號,PRQA_DATE As 日期,PRQA_KD_NO As 異常物件,"
        SQL_str &= "PRQA_TYPE_NO As 異常分類,PRQA_PRI As 重要性,Status As 狀態,"
        SQL_str &= "QA_EXPL1 As 異常現象,QA_EXPL2 As 原因分析,QA_EXPL3 As 改善對策與實施矯正措施,QA_EXPL4 As 效果確認預防措施,"
        SQL_str &= "PRQA_User_ID As 處理人員"
        SQL_str &= " FROM PRQA_H "



        '範圍SQL字串組合--------------------------------------------------------------------
        Dim SQL_WHEREstr As String = ""

        '不良分析單號NO區間 :
        If Txt_No1.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_NO >='" & Txt_No1.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_NO >='" & Txt_No1.Text & "' "
            End If
        End If
        If Txt_No2.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_NO <='" & Txt_No2.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_NO <='" & Txt_No2.Text & "' "
            End If
        End If

        '日期區間 :
        If Txt_Date1.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_DATE >='" & Txt_Date1.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_DATE >='" & Txt_Date1.Text & "' "
            End If
        End If
        If Txt_Date2.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_DATE <='" & Txt_Date2.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_DATE <='" & Txt_Date2.Text & "' "
            End If
        End If

        '異常物件 :
        If Cmb_PRQA_KD.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_KD_NO ='" & Cmb_PRQA_KD.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_KD_NO ='" & Cmb_PRQA_KD.Text & "' "
            End If
        End If

        '異常分類 :
        If Cmb_PRQA_TYPE.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_TYPE_NO ='" & Cmb_PRQA_TYPE.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_TYPE_NO ='" & Cmb_PRQA_TYPE.Text & "' "
            End If
        End If


        '處理人員 :
        If Cmb_PRQA_User_ID.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_User_ID ='" & Cmb_PRQA_User_ID.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_User_ID ='" & Cmb_PRQA_User_ID.Text & "' "
            End If
        End If

        '重要性 :
        If Cmb_PRQA_PRI.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_PRI ='" & Cmb_PRQA_PRI.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_PRI ='" & Cmb_PRQA_PRI.Text & "' "
            End If
        End If

        '狀態 :
        If Cmb_Status.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE Status ='" & Cmb_Status.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND Status ='" & Cmb_Status.Text & "' "
            End If
        End If

        '搜尋字串組合
        SQL_str = SQL_str + SQL_WHEREstr

        ''--------------------------------------------------------------------------------------

        '畫面控制
        Dim myadapter As New SqlDataAdapter(SQL_str, Conn)
        Dim mydataset As New DataSet()
        myadapter.Fill(mydataset, "PRQA_H")

        DataGridView1.DataSource = mydataset.Tables("PRQA_H")

        Conn.Close()

    End Sub

    Private Sub Btn_Printer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Printer.Click
        '資料搜尋帶入
        Conn.Open()


        '單頭資料搜尋PRQA_H
        Dim SQL_str As String = "SELECT * FROM PRQA_H "

        'Dim SQL_str As String = "SELECT PRQA_NO As 不良分析單號,PRQA_DATE As 日期,PRQA_KD_NO As 異常物件,"
        'SQL_str &= "PRQA_TYPE_NO As 異常分類,PRQA_PRI As 重要性,Status As 狀態,"
        'SQL_str &= "QA_EXPL1 As 異常現象,QA_EXPL2 As 原因分析,QA_EXPL3 As 改善對策與實施矯正措施,QA_EXPL4 As 效果確認預防措施,"
        'SQL_str &= "PRQA_User_ID As 處理人員"
        'SQL_str &= " FROM PRQA_H "



        '範圍SQL字串組合--------------------------------------------------------------------
        Dim SQL_WHEREstr As String = ""

        '不良分析單號NO區間 :
        If Txt_No1.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_NO >='" & Txt_No1.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_NO >='" & Txt_No1.Text & "' "
            End If
        End If
        If Txt_No2.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_NO <='" & Txt_No2.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_NO <='" & Txt_No2.Text & "' "
            End If
        End If

        '日期區間 :
        If Txt_Date1.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_DATE >='" & Txt_Date1.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_DATE >='" & Txt_Date1.Text & "' "
            End If
        End If
        If Txt_Date2.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_DATE <='" & Txt_Date2.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_DATE <='" & Txt_Date2.Text & "' "
            End If
        End If

        '異常物件 :
        If Cmb_PRQA_KD.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_KD_NO ='" & Cmb_PRQA_KD.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_KD_NO ='" & Cmb_PRQA_KD.Text & "' "
            End If
        End If

        '異常分類 :
        If Cmb_PRQA_TYPE.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_TYPE_NO ='" & Cmb_PRQA_TYPE.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_TYPE_NO ='" & Cmb_PRQA_TYPE.Text & "' "
            End If
        End If


        '處理人員 :
        If Cmb_PRQA_User_ID.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_User_ID ='" & Cmb_PRQA_User_ID.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_User_ID ='" & Cmb_PRQA_User_ID.Text & "' "
            End If
        End If

        '重要性 :
        If Cmb_PRQA_PRI.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE PRQA_PRI ='" & Cmb_PRQA_PRI.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND PRQA_PRI ='" & Cmb_PRQA_PRI.Text & "' "
            End If
        End If

        '狀態 :
        If Cmb_Status.Text <> "" Then
            If Microsoft.VisualBasic.Left(SQL_WHEREstr, 5) <> "WHERE" Then
                SQL_WHEREstr = "WHERE Status ='" & Cmb_Status.Text & "' "
            Else
                SQL_WHEREstr = SQL_WHEREstr + "AND Status ='" & Cmb_Status.Text & "' "
            End If
        End If

        '搜尋字串組合
        SQL_str = SQL_str + SQL_WHEREstr

        ''--------------------------------------------------------------------------------------

        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        Dim Reader As SqlDataReader
        Reader = SQL_Cmd.ExecuteReader()
        If Not Reader.Read() Then    '判斷檔尾 無資料 
            MsgBox(" 無資料!!" & vbCrLf)
            Txt_No1.Focus()

            Reader.Close()
            Conn.Close()
            Return

        End If

        Reader.Close()

        ''===Crystal Report有使用限制  不使用=========
        ''傳送報表參數值用
        ''Private Const PARAMETER_FIELD_NAME As String = "S_Aging_No"

        '' 宣告將參數傳遞給檢視器控制項所需要的變數。
        'Dim paramFields As New ParameterFields()
        'Dim paramField As New ParameterField()
        'Dim discreteVal As New ParameterDiscreteValue()
        ''Dim rangeVal As New ParameterRangeValue()

        '' 第一個參數是具有多重數值的離散參數。

        '' 設定參數欄位的名稱，該名稱必須與報表中的參數相符。
        'paramField.ParameterFieldName = "Rep_No1" '不良分析單號NO區間 :

        '' 設定第一個離散值並將它傳遞給參數。
        'discreteVal.Value = Txt_No1.Text
        'paramField.CurrentValues.Add(discreteVal)

        '' 設定第二個離散值並將它傳遞給參數。
        '' 將 discreteVal 變數設定為新變數，如此便不會覆寫之前的設定值。
        ''discreteVal = New ParameterDiscreteValue()
        ''discreteVal.Value = "Aruba Sport"
        ''paramField.CurrentValues.Add(discreteVal)

        '' 加入參數至參數欄位集合。
        'paramFields.Add(paramField)

        '' 第二個參數是範圍值。將 paramField 變數設定為新變數，如此便不會覆寫之前的設定值。
        ''paramField = New ParameterField()

        '' 設定參數欄位的名稱，該名稱必須與報表中的參數相符。
        ''paramField.ParameterFieldName = "Rep_No2" '不良分析單號NO區間 :


        '' 設定範圍的起始值和結束值並傳遞至參數。
        ''rangeVal.StartValue = 42
        ''rangeVal.EndValue = 72
        ''paramField.CurrentValues.Add(rangeVal)

        '' 加入第二個參數至參數欄位集合。
        ''paramFields.Add(paramField)


        ''------非範例  自加部份
        'Dim CR_Rep_No2 As New ParameterField()
        'Dim CR_Rep_No2_Val As New ParameterDiscreteValue()

        'CR_Rep_No2.ParameterFieldName = "Rep_No2" '不良分析單號NO區間 :

        '' 設定第一個離散值並將它傳遞給參數。
        'CR_Rep_No2_Val.Value = Txt_No2.Text
        'CR_Rep_No2.CurrentValues.Add(CR_Rep_No2_Val)

        '' 加入參數至參數欄位集合。
        'paramFields.Add(CR_Rep_No2)

        ''日期區間 :
        'Dim CR_Rep_Date1 As New ParameterField()
        'Dim CR_Rep_Date2 As New ParameterField()
        'Dim CR_Rep_Date1_Val As New ParameterDiscreteValue()
        'Dim CR_Rep_Date2_Val As New ParameterDiscreteValue()

        'CR_Rep_Date1.ParameterFieldName = "Rep_Date1"

        '' 設定第一個離散值並將它傳遞給參數。
        'CR_Rep_Date1_Val.Value = Txt_Date1.Text
        'CR_Rep_Date1.CurrentValues.Add(CR_Rep_Date1_Val)

        '' 加入參數至參數欄位集合。
        'paramFields.Add(CR_Rep_Date1)

        'CR_Rep_Date2.ParameterFieldName = "Rep_Date2"

        '' 設定第一個離散值並將它傳遞給參數。
        'CR_Rep_Date2_Val.Value = Txt_Date2.Text
        'CR_Rep_Date2.CurrentValues.Add(CR_Rep_Date2_Val)

        '' 加入參數至參數欄位集合。
        'paramFields.Add(CR_Rep_Date2)


        ''異常物件 :
        'Dim CR_Rep_KD As New ParameterField()
        'Dim CR_Rep_KD_Val As New ParameterDiscreteValue()

        'CR_Rep_KD.ParameterFieldName = "Rep_KD"

        '' 設定第一個離散值並將它傳遞給參數。
        'CR_Rep_KD_Val.Value = Cmb_PRQA_KD.Text
        'CR_Rep_KD.CurrentValues.Add(CR_Rep_KD_Val)

        '' 加入參數至參數欄位集合。
        'paramFields.Add(CR_Rep_KD)


        ''異常分類 :
        'Dim CR_Rep_TYPE As New ParameterField()
        'Dim CR_Rep_TYPE_Val As New ParameterDiscreteValue()

        'CR_Rep_TYPE.ParameterFieldName = "Rep_TYPE"

        '' 設定第一個離散值並將它傳遞給參數。
        'CR_Rep_TYPE_Val.Value = Cmb_PRQA_TYPE.Text
        'CR_Rep_TYPE.CurrentValues.Add(CR_Rep_TYPE_Val)

        '' 加入參數至參數欄位集合。
        'paramFields.Add(CR_Rep_TYPE)


        ''處理人員 :
        'Dim CR_Rep_User As New ParameterField()
        'Dim CR_Rep_User_Val As New ParameterDiscreteValue()

        'CR_Rep_User.ParameterFieldName = "Rep_User"

        '' 設定第一個離散值並將它傳遞給參數。
        'CR_Rep_User_Val.Value = Cmb_PRQA_User_ID.Text
        'CR_Rep_User.CurrentValues.Add(CR_Rep_User_Val)

        '' 加入參數至參數欄位集合。
        'paramFields.Add(CR_Rep_User)


        ''重要性 :
        'Dim CR_Rep_PRI As New ParameterField()
        'Dim CR_Rep_PRI_Val As New ParameterDiscreteValue()

        'CR_Rep_PRI.ParameterFieldName = "Rep_PRI"

        '' 設定第一個離散值並將它傳遞給參數。
        'CR_Rep_PRI_Val.Value = Cmb_PRQA_PRI.Text
        'CR_Rep_PRI.CurrentValues.Add(CR_Rep_PRI_Val)

        '' 加入參數至參數欄位集合。
        'paramFields.Add(CR_Rep_PRI)

        ''狀態 :
        'Dim CR_Rep_Status As New ParameterField()
        'Dim CR_Rep_Status_Val As New ParameterDiscreteValue()

        'CR_Rep_Status.ParameterFieldName = "Rep_Status"

        '' 設定第一個離散值並將它傳遞給參數。
        'CR_Rep_Status_Val.Value = Cmb_Status.Text
        'CR_Rep_Status.CurrentValues.Add(CR_Rep_Status_Val)

        '' 加入參數至參數欄位集合。
        'paramFields.Add(CR_Rep_Status)
        ''-------------------------------------------------


        '' 設定參數欄位集合至檢視器控制項。
        'Report.CrystalReportViewer1.ParameterFieldInfo = paramFields
        ''PRQA_ReportA.CrystalReportViewer1.ReportSource = "PRQA_ReportA1.rpt" 
        ' ''rpt報表名字不能跟form相同 會沖到


        'Dim PRQA_ReportA1DS As New DataSet()
        'Dim myadapter As New SqlDataAdapter(SQL_str, Conn)
        'Dim Report1 As New PRQA_ReportA1

        'PRQA_ReportA1DS.Clear()

        'myadapter.Fill(PRQA_ReportA1DS, "PRQA_H")
        'Conn.Close()

        'Report1.SetDataSource(PRQA_ReportA1DS.Tables("PRQA_H"))

        'Report.CrystalReportViewer1.ReportSource = Report1




        ''列印
        'Report.Text = "不良分析紀表"

        'Report.Show()

    End Sub
End Class