''MBT程式
''          20100601 by ice 謝禎皓

Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports NPOI
Imports NPOI.HPSF
Imports NPOI.HSSF.UserModel
Imports NPOI.POIFS.FileSystem
Public Class Aging
    'Inherits Admin '繼承Admin
    ''----------------------抓config檔的ConnectionString
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()
    Dim Conn As SqlConnection = New SqlConnection(connectionString)
    ''Dim Conn As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=S:\Aging.mdb;")
    Dim Bad_DataTable As System.Data.DataTable '不良原因
    Dim DetermineTable As System.Data.DataTable 'Aging判定
    Dim X1, X2, X3 As String
    Dim Lock, SizeChangedLock As Boolean
    Dim dataGridView1SizeChanged, dataGridView2SizeChanged, dataGridView3SizeChanged, DatagridViewX As Integer

    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Console.WriteLine(Date.Now & "-----> 6.Form1_Shown")
        Lock = True
        'SizeChangedLock = False
    End Sub

    Private Sub Aging_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Size = New System.Drawing.Size(1000, 655) '重新定義視窗大小
        Me.ControlBox = False
        Me.WindowState = FormWindowState.Maximized '視窗最大化
        Me.TabControl1.Controls.Remove(TabPage3) '<-移除用

        DataGridView2.DataSource = BindingSource2
        DataGridView1.DataSource = BindingSource1
        DataGridView3.DataSource = BindingSource1
        MainForm.BindingNavigator1.BindingSource = BindingSource2

        'DataGridView2.ScrollBars = ScrollableControl.ScrollStateAutoScrolling

        SplitContainer1.SplitterDistance = 153 '分隔器位置
        SplitContainer1.SplitterWidth = 5 '分隔器大小
        'TableLayoutPanel3.MaximumSize = New System.Drawing.Size(0, 469)


        '不顯示捲軸
        DataGridView1.ScrollBars = ScrollBars.None
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.RowTemplate.Height = 20
        DataGridView2.ScrollBars = ScrollBars.None
        DataGridView2.AllowUserToAddRows = False
        DataGridView2.RowTemplate.Height = 20
        DataGridView3.ScrollBars = ScrollBars.None
        DataGridView3.AllowUserToAddRows = False
        DataGridView3.RowTemplate.Height = 20

        'VScrollBar1.LargeChange = 5

        '顯示增加資料列
        DataGridView1.AllowUserToAddRows = True
        DataGridView2.AllowUserToAddRows = True
        DataGridView3.AllowUserToAddRows = True
        '變更背景色
        DataGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridView2.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridView3.BackgroundColor = System.Drawing.SystemColors.Window
        '禁止變更列大小(高度)
        DataGridView1.AllowUserToResizeRows = False
        DataGridView2.AllowUserToResizeRows = False
        DataGridView3.AllowUserToResizeRows = False
        '禁止變更行首大小(寬度)
        DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridView2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridView3.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        '禁止選擇多行
        DataGridView1.MultiSelect = False
        DataGridView2.MultiSelect = False
        DataGridView3.MultiSelect = False
        '禁止編輯儲存格
        DataGridView1.ReadOnly = True
        DataGridView2.ReadOnly = True
        DataGridView3.ReadOnly = True

        DataGridView1.Columns.Add("LAMPS_NO", "成燈碼")
        DataGridView1.Columns.Add("Aging_No2", "燈板號碼")
        DataGridView1.Columns.Add("Car_No", "抽氣台車")
        DataGridView1.Columns.Add("Car_PreInject", "預注值")
        DataGridView1.Columns.Add("Car_Balance", "平衡值")
        DataGridView1.Columns.Add("Car_Seat", "位置")
        DataGridView1.Columns.Add("Car_Line", "線別")
        DataGridView1.Columns.Add("Car_Loop", "圈數")
        DataGridView1.Columns.Add("Car_status", "不良原因")
        DataGridView1.Columns.Add("frame_No", "框架編號")
        DataGridView1.Columns.Add("Inv_No", "Inv編號")
        DataGridView1.Columns.Add("determine", "Aging判定")
        DataGridView1.Columns.Add("watt", "功率Watt")
        DataGridView1.Columns.Add("lv", "判定等級")
        DataGridView1.Columns.Add("remark", "備註")
        DataGridView1.Columns.Add("EXT_build", "建立人員")
        DataGridView1.Columns.Add("SYS_UID", "修改人員")
        DataGridView1.Columns.Add("Aging_D_Date", "建立日期")
        DataGridView1.Columns.Add("SYS_Date", "修改日期")
        DataGridView1.Columns.Add("ID", "ID")

        DataGridView2.Columns.Add("Aging_No", "工單號碼")
        DataGridView2.Columns.Add("Aging_Type", "機種")
        DataGridView2.Columns.Add("Aging_X1", "投入")
        DataGridView2.Columns.Add("Aging_X2", "產出")
        DataGridView2.Columns.Add("Aging_X3", "不良")
        DataGridView2.Columns.Add("User_Name", "建立人員")
        DataGridView2.Columns.Add("SYS_UID", "修改人員")
        DataGridView2.Columns.Add("Aging_Date", "建立日期")
        DataGridView2.Columns("Aging_Date").Width = 160
        DataGridView2.Columns.Add("SYS_Date", "修改日期")
        DataGridView2.Columns("SYS_Date").Width = 160

        DataGridView3.Columns.Add("LAMPS_NO", "成燈碼")
        DataGridView3.Columns.Add("Aging_No2", "燈板號碼")
        DataGridView3.Columns.Add("Car_No", "抽氣台車")
        DataGridView3.Columns.Add("Car_PreInject", "預注值")
        DataGridView3.Columns.Add("Car_Balance", "平衡值")
        DataGridView3.Columns.Add("Car_Seat", "位置")
        DataGridView3.Columns.Add("Car_Line", "線別")
        DataGridView3.Columns.Add("Car_Loop", "圈數")
        DataGridView3.Columns.Add("Car_status", "不良原因")
        DataGridView3.Columns.Add("frame_No", "框架編號")
        DataGridView3.Columns.Add("Inv_No", "Inv編號")
        DataGridView3.Columns.Add("determine", "Aging判定")
        DataGridView3.Columns.Add("watt", "功率Watt")
        DataGridView3.Columns.Add("lv", "判定等級")
        DataGridView3.Columns.Add("remark", "備註")
        DataGridView3.Columns.Add("EXT_build", "建立人員")
        DataGridView3.Columns.Add("SYS_UID", "修改人員")
        DataGridView3.Columns.Add("Aging_D_Date", "建立日期")
        DataGridView3.Columns.Add("SYS_Date", "修改日期")
        DataGridView3.Columns.Add("ID", "ID")

        Try
            '使用者檔帶入組長名字
            Dim i As Integer
            Dim SELECT_str As String = "SELECT RTRIM(User_Name) As User_Name FROM Users WHERE Aging_LD ='是'"
            Dim myAdapter As New SqlDataAdapter(SELECT_str, Conn)
            Dim myDataSet As New DataSet()
            myAdapter.Fill(myDataSet, "Users1")
            Dim myDataTable As System.Data.DataTable = myDataSet.Tables("Users1")
            For i = 0 To myDataTable.Rows.Count - 1
                Txt_SUser.Items.Add(myDataTable.Rows(i).Item("User_Name").ToString)
            Next

            '使用者檔帶入操作員名字
            'SELECT_str = "SELECT User_Name FROM Users WHERE User_Type ='2'"
            SELECT_str = "SELECT RTRIM(User_Name) As User_Name FROM Users WHERE Aging_LD ='否'"
            'myAdapter = New SqlDataAdapter(SELECT_str, Conn)
            myAdapter.SelectCommand.CommandText = SELECT_str
            myAdapter.Fill(myDataSet, "Users2")
            myDataTable = myDataSet.Tables("Users2")
            For i = 0 To myDataTable.Rows.Count - 1
                Txt_User.Items.Add(myDataTable.Rows(i).Item("User_Name").ToString)
            Next

            '機  種
            SELECT_str = "SELECT RTRIM(Aging_Type) AS Aging_Type, RTRIM(Aging_Type) + '-' + RTRIM(Type_Name) As Rname FROM Aging_Type"
            myAdapter.SelectCommand.CommandText = SELECT_str
            myAdapter.Fill(myDataSet, "Aging_Type")
            Txt_Type.DataSource = myDataSet.Tables("Aging_Type")
            Txt_Type.DisplayMember = "Rname"
            Txt_Type.ValueMember = "Aging_Type"

            'Aging判定
            SELECT_str = "SELECT determine, RTRIM(determine) + '  ' + RTRIM(determine_N) As Rname FROM determine ORDER BY determine ASC"
            myAdapter.SelectCommand.CommandText = SELECT_str
            myAdapter.Fill(myDataSet, "determine")
            DetermineTable = myDataSet.Tables("determine")
            Txt_determine.DataSource = myDataSet.Tables("determine")
            Txt_determine.DisplayMember = "Rname"   'DisplayMember屬性是設定要在ComboBox項目上顯示的欄位
            Txt_determine.ValueMember = "determine" 'ValueMember屬性是設定要抓取值的欄位

            '設定Aging 判定提示
            Dim determine_data As String = ""
            For i = 1 To (DetermineTable.Rows.Count - 1)
                determine_data &= DetermineTable.Rows(i)("Rname").ToString & vbCrLf
            Next
            TXT_ToolTip.SetToolTip(Me.Txt_determine, determine_data)

            '不良原因
            SELECT_str = "SELECT bad, RTRIM(bad_N) AS bad_N FROM bad ORDER BY bad ASC"
            myAdapter.SelectCommand.CommandText = SELECT_str
            myAdapter.Fill(myDataSet, "bad")
            Bad_DataTable = myDataSet.Tables("bad")
            '設定不良原因提示
            Dim Bad_data As String = ""
            For i = 1 To (Bad_DataTable.Rows.Count - 1)
                Bad_data &= Bad_DataTable.Rows(i)("bad").ToString & " " & Bad_DataTable.Rows(i)("bad_N").ToString & vbCrLf
            Next
            TXT_ToolTip.SetToolTip(Me.Car_status, Bad_data)

        Catch ex As Exception
            MsgBox("錯誤!! " & vbCrLf & ex.Message)
        End Try

        '刪除權限控制
        If MainForm.Aging_Chk_D = "1" Then
            Btn_Hdel.Enabled = True
        Else
            Btn_Hdel.Enabled = False
        End If

        '組長權限控制
        If MainForm.Aging_Chk_O = "1" Then
            CB_LampNo_change.Enabled = True
        Else
            CB_LampNo_change.Enabled = False
        End If

        Txt_SUser.Enabled = False
        Txt_User.Enabled = False

        '使用者檔帶入組長名字
        Txt_SUser.Text = Login.ALL_UserLD
        '使用者檔帶入操作員名字
        Txt_User.Text = Login.ALL_UserN

        Select Case MainForm.Aging_Chk
            Case 1 '權限畫面控制 前段
                Btn_Hsave.Enabled = False
                Btn_Hdel.Enabled = False
                Btn_add.Enabled = False
                Btn_update.Enabled = False
                Btn_del.Enabled = False
                Btn_XLS.Enabled = False
                CB_LampNo_change.Visible = False
                Cmb_Car.Enabled = False
                Txt_D_Date.Enabled = False
                Car_Pre_injection.Enabled = False
                Car_balance.Enabled = False
                Cmb_Car6.Enabled = False
                Cmb_Car2.Enabled = False
                Cmb_Car3.Enabled = False
                Car_status.Enabled = False
                Txt_watt.Enabled = False
                Cmb_lv.Enabled = False
                Txt_LAMP_NO.Enabled = False
                Txt_No2_1.Visible = False
                Cmb_Car2_1.Visible = False
                Car_status_1.Visible = False
                Txt_remark_1.Visible = False
                'Txt_remark.Size = New System.Drawing.Size(800, 22)
                'LAMP_NO_Panel.Location = New System.Drawing.Point(5, 495)
                'LAMP_NO_Panel.BringToFront()
                'LAMPS_Panel.Location = New System.Drawing.Point(5, 639)
                'Btn_save.Location = New System.Drawing.Point(411, 76)
            Case 2 '權限畫面控制 後段
                Btn_Hsave.Enabled = False
                Btn_Hdel.Enabled = False
                Btn_add.Enabled = False
                Btn_update.Enabled = False
                Btn_del.Enabled = False
                Btn_XLS.Enabled = False
                CB_LampNo_change.Visible = False
                Cmb_Car.Enabled = False
                Txt_D_Date.Enabled = False
                Car_Pre_injection.Enabled = False
                Car_balance.Enabled = False
                Cmb_Car6.Enabled = False
                Cmb_Car2.Enabled = False
                Cmb_Car3.Enabled = False
                Car_status.Enabled = False
                Cmb_Car.Enabled = False
                Txt_voltage.Enabled = False
                Txt_ampere.Enabled = False
                Cmb_frame_No.Enabled = False
                Cmb_Inv_No.Enabled = False
                Txt_No2_1.Visible = False
                Cmb_Car2_1.Visible = False
                Car_status_1.Visible = False
                Txt_remark_1.Visible = False
                'Txt_remark.Size = New System.Drawing.Size(800, 22)
                'LAMP_NO_Panel.Location = New System.Drawing.Point(5, 495)
                'LAMP_NO_Panel.BringToFront()
                'LAMPS_Panel.Location = New System.Drawing.Point(5, 639)
                'Btn_save.Location = New System.Drawing.Point(411, 76)
            Case 3 '權限畫面控制 抽氣
                Btn_Hsave.Enabled = False
                Btn_Hdel.Enabled = False
                Btn_add.Enabled = False
                Btn_update.Enabled = False
                Btn_del.Enabled = False
                Btn_XLS.Enabled = False
                Panel_Box.Visible = False
                Txt_determine.Enabled = False
                Txt_voltage2.Enabled = False
                Txt_ampere2.Enabled = False
                Txt_pre1.Enabled = False
                Txt_pre2.Enabled = False
                Txt_pre3.Enabled = False
                Txt_pre4.Enabled = False
                Txt_watt.Enabled = False
                Cmb_lv.Enabled = False
                Txt_LAMP_NO.Enabled = False
                Txt_voltage.Enabled = False
                Txt_ampere.Enabled = False
                Cmb_frame_No.Enabled = False
                Cmb_Inv_No.Enabled = False
                Txt_No2_1.Visible = False
                Cmb_Car2_1.Visible = False
                Car_status_1.Visible = False
                Txt_remark_1.Visible = False
                'Txt_remark.Size = New System.Drawing.Size(800, 22)
                'LAMP_NO_Panel.BringToFront()
                'LAMPS_Panel.Location = New System.Drawing.Point(5, 639)
                'Btn_save.Location = New System.Drawing.Point(411, 76)
            Case 4 '權限畫面控制 抽氣
                'Btn_Hsave.Enabled = False
                'Btn_Hdel.Enabled = False
                'Btn_add.Enabled = False
                'Btn_update.Enabled = False
                'Btn_del.Enabled = False
                'Btn_XLS.Enabled = False
                'Btn_save.Enabled = False
                'Txt_remark.Size = New System.Drawing.Size(800, 22)
                'Panel_Box.Visible = False
                'EXT_Panel.Visible = False
                'Aging_Panel.Visible = False
                'LAMP_NO_Panel.Visible = False
                'Other_Panel.Visible = False
                'LAMPS_Panel.Location = New System.Drawing.Point(5, 449)
                'Btn_save.Location = New System.Drawing.Point(877, 528)
                'Assembly_Btn_del.Location = New System.Drawing.Point(877, 556)
        End Select

        '工單NO. 取得焦點
        Txt_No.Focus()
    End Sub
    Private Sub Txt_No_Refresh()

        '解決當機造成資料庫開啟狀態
        If Conn.State = 1 Then
            Conn.Close()
        End If

        '資料搜尋帶入
        Conn.Open()

        '單頭資料搜尋Aging.Aging_H
        Dim SQL_str As String = "SELECT RTRIM(Aging_Type) As 機種,RTRIM(Aging_X1) As 投入, RTrim(Aging_X2) As 產出," _
            & " RTrim(Aging_X3) As 不良 FROM Aging_H WHERE Aging_No ='" & Txt_No.Text & "'"

        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        Dim Reader As SqlDataReader
        Reader = SQL_Cmd.ExecuteReader()

        If Reader.Read() Then     '判斷檔尾 有資料帶入單頭資料
            Txt_Type.Text = RTrim(Reader.Item("機種"))

            Txt_X1.Text = Reader.Item("投入")
            MainForm.Txt_X1.Text = "投 入 : " & Txt_X1.Text
            Txt_X2.Text = Reader.Item("產出")
            MainForm.Txt_X2.Text = "產 出 : " & Txt_X2.Text
            Txt_X3.Text = Reader.Item("不良")
            MainForm.Txt_X3.Text = "不 良 : " & Txt_X3.Text

            Conn.Close()

            '連到明細資料處理
            Load_SQL()

            Txt_Date.Enabled = False

            Select Case MainForm.Aging_Chk
                Case 1, 2
                    Btn_add.Enabled = False
                    Btn_update.Enabled = True
                    Btn_del.Enabled = True
                Case 3
                    Btn_add.Enabled = True
                    Btn_update.Enabled = True
                    Btn_del.Enabled = True
            End Select
        End If
    End Sub
    Sub Load_AgingNO()
        Dim SQL_Str As String = SearchData.SQL_Str
        If SQL_Str = "" Then
            SQL_Str = "Select RTRIM(Aging_No) As 工單號碼, RTrim(Aging_Type) As 機種, "
            SQL_Str &= "RTRIM(Aging_X1) As 投入, RTrim(Aging_X2) As 產出, RTrim(Aging_X3) As 不良, "
            SQL_Str &= "RTrim(User_Name) As 建立人員, RTrim(SYS_UID) As 修改人員, Aging_Date As 建立日期, "
            SQL_Str &= "SYS_Date As 修改日期 FROM Aging_H WHERE Aging_No LIKE '%" & Txt_No.Text.Substring(3, 4) & "%'"
        End If

        Load_AgingNO(SQL_Str)
    End Sub
    Sub Load_AgingNO(ByVal SQL_Str As String)

        Conn.Open()
        Dim myAdapter As New SqlDataAdapter(SQL_Str, Conn)
        Dim myDataSet As New DataSet()
        myAdapter.Fill(myDataSet, "Aging_D")
        Conn.Close()

        Dim OrdBy As Boolean
        If DataGridView2.RowCount < 1 Then
            OrdBy = True
        End If
        Dim vScrollbar As Integer = VScrollBar2.Value
        BindingSource2.DataSource = myDataSet.Tables("Aging_D")

        If OrdBy = True Then
            DataGridView2_Init()
        End If

        OrderByNum(DataGridView2)

        VScrollBar2.Maximum = DataGridView2.RowCount
        If vScrollbar > VScrollBar2.Maximum Then
            VScrollBar2.Value = VScrollBar2.Maximum
        Else
            VScrollBar2.Value = vScrollbar
        End If
    End Sub

    Private Sub Load_SQL()
        Dim SELECT_str As String = ""
        Select Case MainForm.Aging_Chk
            Case 1, 2  'Aging 前段/後段
                '(Ω)明細檔
                '加RTRIM 消除字串後空白
                SELECT_str = "Select RTRIM(LAMPS_NO) As 成燈碼, RTRIM(Aging_No2) As 燈板號碼, Car_No As 抽氣台車,"
                SELECT_str &= "RTRIM(Car_No4) As 預注值, RTRIM(Car_No5) As 平衡值, RTRIM(Car_No2) As 位置, RTRIM(Car_No6) As 線別, Car_No3 As 圈數, "
                SELECT_str &= "RTRIM(Car_status) As 不良原因, frame_No As 框架編號, Inv_No As Inv編號, determine As Aging判定, watt As 功率Watt, "
                SELECT_str &= "lv As 判定等級, RTRIM(remark) As 備註, Aging_build As 建立人員, Aging_modify As 修改人員, Aging_build_date As 建立日期, Aging_modify_date As 修改日期 ,ID As ID "
                SELECT_str &= "FROM Aging_D WHERE Aging_No ='" & Txt_No.Text & "'"
            Case 3  '抽氣
                '(Ω)明細檔
                '加RTRIM 消除字串後空白
                SELECT_str = "Select RTRIM(LAMPS_NO) As 成燈碼, RTRIM(Aging_No2) As 燈板號碼, Car_No As 抽氣台車,"
                SELECT_str &= "RTRIM(Car_No4) As 預注值, RTRIM(Car_No5) As 平衡值, RTRIM(Car_No2) As 位置, RTRIM(Car_No6) As 線別, Car_No3 As 圈數, "
                SELECT_str &= "RTRIM(Car_status) As 不良原因, frame_No As 框架編號, Inv_No As Inv編號, determine As Aging判定, watt As 功率Watt, "
                SELECT_str &= "lv As 判定等級, RTRIM(remark) As 備註, EXT_build As 建立人員, SYS_UID As 修改人員, Aging_D_Date As 建立日期, SYS_Date As 修改日期 ,ID As ID "
                SELECT_str &= "FROM Aging_D WHERE Aging_No ='" & Txt_No.Text & "'"
            Case 4  '組裝
                SELECT_str = "Select RTRIM(LAMPS_NO) As 成燈碼, RTRIM(Aging_No2) As 燈板號碼, "
                SELECT_str &= "RTRIM(Ballast_NO) As 安定器號碼, RTRIM(ampere3) As 實際功率, lv As 等級, "
                SELECT_str &= "RTRIM(Aging_No) As Aging工單號碼, Assembly_build As 建立人員, Assembly_modify As 修改人員, Assembly_build_date As 建立日期, Assembly_modify_date As 修改日期 ,ID As ID "
                SELECT_str &= "FROM Aging_D WHERE Assembly_No ='" & Txt_No.Text & "'"
        End Select

        Conn.Open()
        Dim myAdapter As New SqlDataAdapter(SELECT_str, Conn)
        Dim myDataSet As New DataSet()
        myAdapter.Fill(myDataSet, "Aging_D")
        Conn.Close()

        Dim OrdBy As Boolean
        If DataGridView1.Columns.Count = 0 Then
            OrdBy = True
        End If

        BindingSource1.DataSource = myDataSet.Tables("Aging_D")
        'DataGridView3.DataSource = DataGridView1.DataSource
        'DataGridView3.Columns(0).Frozen = True                  '凍結欄位1
        'DataGridView3.Columns(0).DividerWidth = 2               '設定分隔線寬
        'DataGridView3.AutoResizeColumns()                       '欄位自動調整大小

        If OrdBy = True Then
            DataGridView_Init(DataGridView1)
            DataGridView_Init(DataGridView3)
        End If

        If DataGridView1.RowCount > 0 Then
            '行首加入數字
            OrderByNum(DataGridView1)
            OrderByNum(DataGridView3)
            DataGridView1.AllowUserToAddRows = False
            DataGridView3.AllowUserToAddRows = False
        Else
            DataGridView1.AllowUserToAddRows = True
            DataGridView3.AllowUserToAddRows = True
        End If

        If MainForm.Aging_Chk <> 4 Then
            Txt_No2.Text = ""
            Txt_D_Date.Text = DateString & " " & Format(Now, "HH:mm")
            Cmb_Car.Text = "01"
            Cmb_Car2.Text = "01"
            Cmb_Car3.Text = "01"
            Cmb_Car6.Text = "A"
            Car_Pre_injection.Text = "0.0"
            Car_balance.Text = "0.0"
            Car_status.Text = ""
            Txt_voltage.Text = "0.000"
            Txt_ampere.Text = "1.0"
            Cmb_frame_No.Text = "01"
            Cmb_Inv_No.Text = "01"
            Txt_determine.Text = "00"
            Txt_pre1.Text = "0.000"
            Txt_pre2.Text = "0.000"
            Txt_pre3.Text = "0.000"
            Txt_pre4.Text = "0.000"
            Txt_watt.Text = "0.0"
            Txt_voltage2.Text = "0.000"
            Txt_ampere2.Text = "1.0"
            Cmb_lv.Text = "N"
            Txt_remark.Text = ""
            Txt_LAMP_NO.Text = ""
        End If
    End Sub
    Sub DataGridView_Init(ByVal DataGridView As DataGridView)
        '不顯示增加資料列
        DataGridView.AllowUserToAddRows = False

        DataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells) '欄位自動調整大小
        DataGridView.AllowUserToResizeColumns = False '禁止使用者更動欄位大小
        '設定標題文字置中 
        DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DataGridView.Columns("成燈碼").Width = 100
        DataGridView.Columns("燈板號碼").Width = 60
        DataGridView.Columns("建立人員").Width = 90
        DataGridView.Columns("修改人員").Width = 90
        DataGridView.Columns("建立日期").Width = 140
        DataGridView.Columns("修改日期").Width = 140

        Dim String_Center() As String = {}

        If MainForm.Aging_Chk <> 4 Then
            DataGridView.Columns("抽氣台車").Width = 60
            DataGridView.Columns("不良原因").Width = 60
            DataGridView.Columns("框架編號").Width = 60
            DataGridView.Columns("預注值").Width = 60
            DataGridView.Columns("平衡值").Width = 60
            DataGridView.Columns("位置").Width = 40
            DataGridView.Columns("線別").Width = 40
            DataGridView.Columns("圈數").Width = 40
            DataGridView.Columns("Inv編號").Width = 55
            DataGridView.Columns("Aging判定").Width = 45
            DataGridView.Columns("功率Watt").Width = 50
            DataGridView.Columns("判定等級").Width = 60
            DataGridView.Columns("ID").Width = 60

            '數字欄位置中
            String_Center = {"成燈碼", "燈板號碼", "抽氣台車", "預注值", "平衡值", "位置", "圈數",
                                             "框架編號", "Inv編號", "功率Watt"}
        ElseIf MainForm.Aging_Chk = 4 Then
            DataGridView.Columns("成燈碼").Width = 150
            DataGridView.Columns("安定器號碼").Width = 80
            DataGridView.Columns("實際功率").Width = 70
            DataGridView.Columns("等級").Width = 70
            DataGridView.Columns("Aging工單號碼").Width = 125

            '數字欄位置中
            String_Center = {"成燈碼", "燈板號碼", "安定器號碼", "實際功率", "等級", "Aging工單號碼"}
        End If

        For i As Int32 = 0 To String_Center.GetLength(0) - 1
            DataGridView.Columns(String_Center(i)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

    End Sub
    Sub DataGridView2_Init()
        '不顯示增加資料列
        DataGridView2.AllowUserToAddRows = False

        DataGridView2.Columns("建立日期").Width = 160
        DataGridView2.Columns("修改日期").Width = 160
        DataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells) '欄位自動調整大小

        '先設定標題文字置中 
        DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '數字欄位置中
        Dim String_Center() As String = {"投入", "產出", "不良"}
        For i As Int32 = 0 To String_Center.GetLength(0) - 1
            DataGridView2.Columns(String_Center(i)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
    End Sub
    Sub Add_TxTNo()
        If Txt_No.Text = "" Then
            MsgBox(" 工單NO 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If

        '單頭資料處理Aging.Aging_H 新增時要依照順序 勿變動
        '工單NO Aging_No
        '日期   Aging_Date
        '機種   Aging_Type
        'Aging 統計 Aging_X
        'Aging 統計投入 Aging_X1
        'Aging 統計產出 Aging_X2
        'Aging 統計不良 Aging_X3
        '靜置測試統計   Aging_Y
        '靜置測試統計投入   Aging_Y1
        '靜置測試統計產出   Aging_Y2
        '靜置測試統計不良   Aging_Y3
        '組長   Supervisor_Name
        '操作者 User_Name
        '系統時間 SYS_Date
        '測試電壓 TEST_voltage
        '測試電流 TEST_ampere
        '系統使用者ID SYS_UID
        Conn.Open()
        Dim ErrorMessage As String = "錯誤!!!"
        Try
            Dim SQL_str As String = "SELECT * FROM Aging_H WHERE Aging_No ='" & Txt_No.Text & "'"
            Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
            Dim Reader As SqlDataReader
            Dim Data_Time_String As String = DateString & " " & Format(Now, "HH:mm")
            Reader = SQL_Cmd.ExecuteReader()

            If Reader.Read() Then
                Reader.Close()
                Conn.Close()
                ErrorMessage = "新增單頭資料失敗!! " & vbCrLf & "請確認是否已有相同工單號碼"
                MsgBox(ErrorMessage)
                Exit Sub
            Else
                Reader.Close()
                ErrorMessage = "新增單頭資料失敗!! "

                SQL_str = "INSERT INTO Aging_H VALUES ('" & Txt_No.Text & "','" _
                    & Data_Time_String & "','" _
                    & Txt_Type.Text & "','" _
                    & 0 & "'," _
                    & 0 & "," _
                    & 0 & "," _
                    & 0 & ",'" _
                    & 0 & "'," _
                    & 0 & "," _
                    & 0 & "," _
                    & 0 & ",'" _
                    & Txt_SUser.Text & "','" _
                    & Txt_User.Text & "','" _
                    & Data_Time_String & "'," _
                    & 0 & "," _
                    & 0 & "," _
                    & 0 & ",'" _
                    & Txt_User.Text & "')"
                SQL_Cmd.CommandText = SQL_str
                SQL_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
            End If
            Conn.Close()

            SQL_str = "Select RTRIM(Aging_No) As 工單號碼, RTrim(Aging_Type) As 機種, "
            SQL_str &= "RTRIM(Aging_X1) As 投入, RTrim(Aging_X2) As 產出, RTrim(Aging_X3) As 不良, "
            SQL_str &= "RTrim(User_Name) As 建立人員, RTrim(SYS_UID) As 修改人員, Aging_Date As 建立日期, "
            SQL_str &= "SYS_Date As 修改日期 FROM Aging_H WHERE Aging_No LIKE '%" & Txt_No.Text.Substring(3, 4) & "%'"

            DataGridView2.Columns.Clear()
            Load_AgingNO(SQL_str)
            DataGridView2.CurrentCell = Me.DataGridView2(0, DataGridView2.Rows.Count - 1)    '移動到最後一行

            If VScrollBar2.Maximum < DataGridView2.Rows.Count Then
                VScrollBar2.Maximum = DataGridView2.Rows.Count
            End If
            VScrollBar2.Value = DataGridView2.Rows.Count

            '連到明細資料處理
            Load_SQL()

        Catch ex As Exception
            MsgBox(ErrorMessage & vbCrLf & ex.Message)
            SaveLog(ex.Message)
        End Try
    End Sub
    Sub Edit_TXTNo()
        If Txt_No.Text = "" Then
            MsgBox(" 工單NO 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If

        '單頭資料處理Aging.Aging_H 新增時要依照順序 勿變動
        '工單NO Aging_No
        '日期   Aging_Date
        '機種   Aging_Type
        'Aging 統計 Aging_X
        'Aging 統計投入 Aging_X1
        'Aging 統計產出 Aging_X2
        'Aging 統計不良 Aging_X3
        '靜置測試統計   Aging_Y
        '靜置測試統計投入   Aging_Y1
        '靜置測試統計產出   Aging_Y2
        '靜置測試統計不良   Aging_Y3
        '組長   Supervisor_Name
        '操作者 User_Name
        '系統時間 SYS_Date
        '測試電壓 TEST_voltage
        '測試電流 TEST_ampere
        '系統使用者ID SYS_UID
        Conn.Open()
        Dim ErrorMessage As String = "錯誤!!!"
        Try
            Dim SQL_str As String = "SELECT * FROM Aging_H WHERE Aging_No ='" & Txt_No.Text & "'"
            Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
            Dim Reader As SqlDataReader
            Dim Data_Time_String As String = DateString & " " & Format(Now, "HH:mm")
            Reader = SQL_Cmd.ExecuteReader()

            If Reader.Read() Then     '判斷檔尾 有資料 修改單頭資料
                ErrorMessage = "修改單頭資料失敗!!"

                SQL_str = "UPDATE Aging_H SET Aging_Type ='" & Txt_Type.Text & "'," _
                & " SYS_Date = '" & Data_Time_String & "'," _
                & " SYS_UID ='" & Txt_User.Text & "'" _
                & " WHERE Aging_No ='" & Txt_No.Text & "'"

                Reader.Close()
                SQL_Cmd.CommandText = SQL_str
                SQL_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
            Else
                Reader.Close()
                Conn.Close()
                ErrorMessage = "修改單頭資料失敗!!" & vbCrLf & "請確認是否已有該筆工單號碼存在"
                MsgBox(ErrorMessage)
                Exit Sub
            End If
            Conn.Close()

            Dim vScrollMEM As Integer = VScrollBar2.Value
            Load_AgingNO()
            VScrollBar2.Value = vScrollMEM

        Catch ex As Exception
            MsgBox(ErrorMessage & vbCrLf & ex.Message)
            SaveLog(ex.Message)
        End Try
    End Sub
    Sub del_TXTNo()
        If Txt_No.Text = "" Then
            MsgBox(" 工單NO 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If

        ' 顯示確認刪除的訊息對話方塊
        Dim ret As Integer ' MsgBox的傳回值
        ret = MsgBox("是否真的要刪除工單: [" & Txt_No.Text & " ]", vbYesNo, "確認刪除")
        If ret <> vbYes Then
            Txt_No.Focus()
            Return
        End If

        ' 再次確認
        ret = MsgBox("再次確認是否真的要刪除工單: [" & Txt_No.Text & " ]", vbYesNo, "確認刪除")
        If ret <> vbYes Then
            Txt_No.Focus()
            Return
        End If

        Conn.Open()

        '單頭資料處理Aging.Aging_H
        Try
            Dim SQL_str As String = "SELECT * FROM Aging_H WHERE Aging_No = '" & Txt_No.Text & "'"
            Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
            Dim Reader As SqlDataReader
            Reader = SQL_Cmd.ExecuteReader()
            If Reader.Read() Then     '判斷檔尾 有資料 修改單頭資料
                Reader.Close()
                SQL_str = "Delete FROM Aging_H WHERE Aging_No = '" & Txt_No.Text & "'"
                SQL_Cmd.CommandText = SQL_str
                SQL_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
            End If
        Catch ex As Exception
            MsgBox("刪除單頭資料失敗!!" & vbCrLf & ex.Message)
            SaveLog(ex.Message)
        End Try

        Conn.Close()

        Dim vScrollMEM As Integer = VScrollBar2.Value
        Dim IndeID As Integer = DataGridView2.CurrentRow.Index  '取得目前滑鼠所在行數

        Load_AgingNO()

        If vScrollMEM <> 0 Then
            VScrollBar2.Value = vScrollMEM - 1
        End If

        If DataGridView2.RowCount > 0 Then
            If IndeID < 0 Then
                IndeID = IndeID + 1
            ElseIf IndeID > DataGridView2.Rows.Count - 1 Then
                IndeID = IndeID - 1
            End If
            Me.DataGridView2.FirstDisplayedScrollingRowIndex = IndeID
            DataGridView2.CurrentCell = DataGridView2.Rows(IndeID).Cells(0)    '移動到上次選取行數
        End If

        '連到明細資料處理
        Load_SQL()

    End Sub
    Private Sub Txt_No_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_No.GotFocus
        If Txt_No.Text <> "" And Txt_No.SelectionLength = 0 Then
            Txt_No.SelectAll()
        End If
    End Sub
    Private Sub Cmb_Car_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Car.Leave
        If Cmb_Car.Text <> "" Then
            If Cmb_Car.Text > 0 And Cmb_Car.Text <= 68 Then
                '數字補0
                If Cmb_Car.Text < 10 Then
                    Cmb_Car.Text = Format(Val(Cmb_Car.Text), "00")
                End If
                Return
            End If
        End If
        Cmb_Car.Focus()
    End Sub
    Private Sub Cmb_frame_No_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_frame_No.Leave
        If Cmb_frame_No.Text <> "" Then
            If Cmb_frame_No.Text > 0 And Cmb_frame_No.Text <= 73 Then
                If Cmb_frame_No.Text < 10 Then
                    Cmb_frame_No.Text = String.Format("{0:00}", Val(Cmb_frame_No.Text)) '不足2位補0
                End If
                Return
            End If
        End If
        Cmb_frame_No.Focus()
    End Sub
    Private Sub Cmb_Inv_No_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Inv_No.Leave
        If Cmb_Inv_No.Text <> "" Then
            If Cmb_Inv_No.Text > 0 And Cmb_Inv_No.Text <= 4 Then
                If Cmb_Inv_No.Text < 10 Then
                    Cmb_Inv_No.Text = String.Format("{0:00}", Val(Cmb_Inv_No.Text)) '不足2位補0
                End If
                Return
            End If
        End If
        Cmb_Inv_No.Focus()
    End Sub

    Private Sub Btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_add.Click
        If Txt_No.Text = "" Then
            MsgBox(" 工單NO 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If
        If Txt_No2.Text = "" Then
            MsgBox(" 燈板號碼 不能為空值!!" & vbCrLf)
            Txt_No2.Focus()
            Return
        End If
        If Cmb_Car.Text = "" Then
            MsgBox(" 抽氣台車 不能為空值!!" & vbCrLf)
            Cmb_Car.Focus()
            Return
        End If
        If Cmb_frame_No.Text = "" And MainForm.Aging_Chk <> "3" Then
            MsgBox(" 框架編號 不能為空值!!" & vbCrLf)
            Cmb_frame_No.Focus()
            Return
        End If
        If Cmb_Inv_No.Text = "" And MainForm.Aging_Chk <> "3" Then
            MsgBox(" Inv編號 不能為空值!!" & vbCrLf)
            Cmb_Inv_No.Focus()
            Return
        End If

        Conn.Open()

        '單頭資料判斷Aging.Aging_H 
        Dim SQL_str As String = "SELECT * FROM Aging_H WHERE Aging_No ='" & Txt_No.Text & "'"
        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        Dim Reader As SqlDataReader

        Reader = SQL_Cmd.ExecuteReader()
        If Not Reader.Read() Then     '判斷檔尾 無單頭資料資料
            MsgBox("無該工單: [" & Txt_No.Text & " ] 單頭資料,請先按存檔儲存資料!!" & vbCrLf)
            Conn.Close()
            Return
        End If

        Reader.Close()

        '明細資料判斷Aging.Aging_D 
        Dim WorkOrder_No As String = ""
        Dim Lamp_No As String = ""
        Dim WorkOrder_No_1 As String = ""
        Dim Lamp_No_1 As String = ""

        If Txt_No2.Text.IndexOf("-") <> -1 Then
            WorkOrder_No = Mid(Txt_No.Text, 1, 7) & Mid(Txt_No2.Text, 1, Txt_No2.Text.IndexOf("-"))
            Lamp_No = Mid(Txt_No2.Text, Txt_No2.Text.IndexOf("-") + 2)
            Console.WriteLine("工單號碼 : {0}", WorkOrder_No)
            Console.WriteLine("燈板號碼 : {0}", Lamp_No)

            If SQL_Check(WorkOrder_No, Lamp_No) = False Then
                Exit Sub
            End If
        ElseIf SQL_Check(Txt_No.Text, Txt_No2.Text) = False Then
            Exit Sub
        End If

        If (Txt_No2_1.Visible = True And Txt_No2_1.Text <> "") Then
            If Txt_No2_1.Text.IndexOf("-") <> -1 Then
                WorkOrder_No_1 = Mid(Txt_No.Text, 1, 7) & Mid(Txt_No2_1.Text, 1, Txt_No2_1.Text.IndexOf("-"))
                Lamp_No_1 = Mid(Txt_No2_1.Text, Txt_No2_1.Text.IndexOf("-") + 2)
                Console.WriteLine("工單號碼 : {0}", WorkOrder_No_1)
                Console.WriteLine("燈板號碼 : {0}", Lamp_No_1)

                If SQL_Check(WorkOrder_No_1, Lamp_No_1) = False Then
                    Exit Sub
                End If
            ElseIf SQL_Check(Txt_No.Text, Txt_No2_1.Text) = False Then
                Exit Sub
            End If
        End If

        If Txt_No2.Text.IndexOf("-") <> -1 Then
            SQL_Write(WorkOrder_No, Lamp_No, Cmb_Car2, Car_status, Txt_remark)        '新增明細資料
            SQL_Count(WorkOrder_No, False)          'Aging 統計處理
        Else
            SQL_Write(Txt_No.Text, Txt_No2.Text, Cmb_Car2, Car_status, Txt_remark)    '新增明細資料
            SQL_Count(Txt_No.Text, True)            'Aging 統計處理
        End If

        If (Txt_No2_1.Visible = True And Txt_No2_1.Text <> "") Then
            If Txt_No2_1.Text.IndexOf("-") <> -1 Then
                SQL_Write(WorkOrder_No_1, Lamp_No_1, Cmb_Car2_1, Car_status_1, Txt_remark_1)   '新增明細資料
                SQL_Count(WorkOrder_No_1, False)        'Aging 統計處理
            Else
                SQL_Write(Txt_No.Text, Txt_No2_1.Text, Cmb_Car2_1, Car_status_1, Txt_remark_1) '新增明細資料
                SQL_Count(Txt_No.Text, True)            'Aging 統計處理
            End If
        End If

        Conn.Close()

        Load_AgingNO()
        If DataGridView2.Rows.Count > 0 Then
            DataGridView2.CurrentCell = Me.DataGridView2(0, DataGridView2.Rows.Count - 1)    '移動到最後一行
        End If
        VScrollBar2.Value = DataGridView2.Rows.Count
        TabControl1.SelectedTab = TabControl1.TabPages(0)   '切換到資料欄位頁

        Dim Txt_No2_mem As String = Txt_No2.Text

        If Txt_No2_1.Visible = True Then
            Txt_No2_1.Visible = False
            Txt_No2_1.Text = ""
            Cmb_Car2_1.Visible = False
            Car_status_1.Visible = False
            Car_status_1.Text = ""
            Txt_remark_1.Visible = False
            Txt_remark_1.Text = ""
            Txt_remark.Size = New System.Drawing.Size(800, 22)
        End If

        DataGVOrderBy()
        Txt_No2.Focus()
        For i = 0 To DataGridView1.RowCount - 1
            If (DataGridView1.Rows(i).Cells("燈板號碼").Value.ToString() = Txt_No2_mem) Then
                Me.DataGridView1.FirstDisplayedScrollingRowIndex = i
                DataGridView1.CurrentCell = Me.DataGridView1.Rows(i).Cells(0) '移動到新增行
                Exit For
            End If
        Next
    End Sub
    Function SQL_Check(ByVal DSQL_TXT_NO As String, ByVal DSQL_TXT_NO2 As String) As Boolean
        Dim DSQL_str As String = "SELECT COUNT(*) FROM Aging_D WHERE Aging_No = '" & DSQL_TXT_NO & "' And Aging_No2= '" & DSQL_TXT_NO2 & "'"
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader

        DReader = DSQL_Cmd.ExecuteReader()
        DReader.Read()
        Dim DataCount As Integer = DReader.Item(0)
        If DataCount <> 0 Then     '判斷檔尾 有重複資料
            Dim response As DialogResult
            response = (MessageBox.Show(
                        "該燈板號碼: [" & DSQL_TXT_NO & "-" & DSQL_TXT_NO2 & " ] 有" & DataCount & "筆重複資料, " & vbCrLf &
                        "是否再次新增該燈板號碼: [" & DSQL_TXT_NO & "-" & DSQL_TXT_NO2 & " ]?" & vbCrLf &
                        "如要新增資料請按 是 儲存資料!!" & vbCrLf &
                        "如要放棄新增資料請按 否!!",
                        "燈板號碼重複?", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2))

            If (response = DialogResult.No) Then
                Conn.Close()
                Return False
            End If
        End If
        DReader.Close()
        Return True
    End Function
    Private Sub SQL_Write(ByVal DSQL_TXT_NO As String, ByVal DSQL_TXT_NO2 As String,
                           ByVal CmbCar2 As Control, ByVal CarStatus As Control, ByVal TxTRemark As Control)
        Dim Data_Time_String As String = DateString & " " & Format(Now, "HH:mm")
        '新增明細資料
        Try
            If CarStatus.Text = "" Then
                CarStatus.Text = "N"
            End If

            Dim Inser_str As String = "INSERT INTO Aging_D (Aging_No,Aging_No2,Aging_D_Date,Car_No,"
            Inser_str &= " Car_No2,Car_No3,Car_No4,Car_No5,Car_No6,Car_status,LAMPS_NO,"
            Inser_str &= " voltage,ampere,frame_No,Inv_No,determine,"
            Inser_str &= " pre1,pre2,pre3,pre4,watt,"
            Inser_str &= " voltage2,ampere2,lv,remark,SYS_Date,SYS_UID,EXT_build) VALUES "
            Inser_str &= " ('" & DSQL_TXT_NO & "','" & DSQL_TXT_NO2 & "','" & Txt_D_Date.Text & "','" & Cmb_Car.Text & "','"
            Inser_str &= CmbCar2.Text & "','" & Cmb_Car3.Text & "','" & Car_Pre_injection.Text & "','" & Car_balance.Text & "','"
            Inser_str &= Cmb_Car6.Text & "','" & CarStatus.Text & "','" & Txt_LAMP_NO.Text & "'," & Txt_voltage.Text & ","
            Inser_str &= Txt_ampere.Text & ",'" & Cmb_frame_No.Text & "','" & Cmb_Inv_No.Text & "','" & Txt_determine.Text & "',"
            Inser_str &= Txt_pre1.Text & "," & Txt_pre2.Text & "," & Txt_pre3.Text & "," & Txt_pre4.Text & "," & Txt_watt.Text & ","
            Inser_str &= Txt_voltage2.Text & "," & Txt_ampere2.Text & ",'" & Cmb_lv.Text & "','" & TxTRemark.Text & "','"
            Inser_str &= Data_Time_String & "','" & Txt_User.Text & "','" & Txt_User.Text & "')"

            Dim Inser_Cmd As New SqlCommand(Inser_str, Conn)
            Inser_Cmd.ExecuteNonQuery()        '執行Sqlcommand

        Catch ex As Exception
            MsgBox("新增明細資料失敗!!" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SQL_Count(ByVal DSQL_TXT_NO As String, ByVal display As Boolean)

        'Aging 統計處理-------------------------------------------------------------------------------
        '投  入 :
        Dim SQL_str As String
        If MainForm.Aging_Chk = 4 Then
            SQL_str = "SELECT COUNT(*) FROM Aging_D WHERE Assembly_No = '" & DSQL_TXT_NO & "'"
        Else
            SQL_str = "SELECT COUNT(*) FROM Aging_D WHERE Aging_No = '" & DSQL_TXT_NO & "'"
        End If

        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        Dim Reader As SqlDataReader
        Reader = SQL_Cmd.ExecuteReader()
        Reader.Read()
        Dim X1 As String = Reader.Item(0)
        Reader.Close()

        '產  出 :
        If MainForm.Aging_Chk = 4 Then
            SQL_str = "SELECT COUNT(*) FROM Aging_D WHERE Assembly_No = '" & DSQL_TXT_NO & "' AND (lv='A' OR lv='B')"
        Else
            SQL_str = "SELECT COUNT(*) FROM Aging_D WHERE Aging_No = '" & DSQL_TXT_NO & "' AND (lv='A' OR lv='B')"
        End If

        SQL_Cmd.CommandText = SQL_str
        Reader = SQL_Cmd.ExecuteReader()
        Reader.Read()
        Dim X2 As String = Reader.Item(0)
        Reader.Close()

        '不  良 :
        Dim X3 As String = X1 - X2

        If display = True Then
            Txt_X1.Text = X1
            Txt_X2.Text = X2
            Txt_X3.Text = X3
            MainForm.Txt_X1.Text = "投 入 : " & X1
            MainForm.Txt_X2.Text = "產 出 : " & X2
            MainForm.Txt_X3.Text = "不 良 : " & X3

        End If

        Dim Data_Time_String As String = DateString & " " & Format(Now, "HH:mm")
        '修改Aging統計資料
        Try
            SQL_str = "UPDATE Aging_H SET Aging_X1 =" & X1 & "," _
            & " Aging_X2 =" & X2 & "," _
            & " Aging_X3 =" & X3 & "," _
            & " SYS_Date ='" & Data_Time_String & "'," _
            & " SYS_UID ='" & Txt_User.Text & "'" _
            & " WHERE Aging_No = '" & DSQL_TXT_NO & "'"

            SQL_Cmd.CommandText = SQL_str
            SQL_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
        Catch ex As Exception
            MsgBox("新增明細資料失敗!!" & vbCrLf & ex.Message)
        End Try
        'Aging 統計處理---------------------------END----------------------------------------------------

    End Sub

    Private Sub Btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_update.Click
        If Txt_No.Text = "" Then
            MsgBox(" 工單NO 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If
        If Txt_No2.Text = "" Then
            MsgBox(" 燈板號碼 不能為空值!!" & vbCrLf)
            Txt_No2.Focus()
            Return
        End If
        If Cmb_Car.Text = "" Then
            MsgBox(" 抽氣台車 不能為空值!!" & vbCrLf)
            Cmb_Car.Focus()
            Return
        End If
        If Cmb_frame_No.Text = "" And MainForm.Aging_Chk <> "3" Then
            MsgBox(" 框架編號 不能為空值!!" & vbCrLf)
            Cmb_frame_No.Focus()
            Return
        End If
        If Cmb_Inv_No.Text = "" And MainForm.Aging_Chk <> "3" Then
            MsgBox(" Inv編號 不能為空值!!" & vbCrLf)
            Cmb_Inv_No.Focus()
            Return
        End If

        Conn.Open()

        '單頭資料判斷Aging.Aging_H 
        Dim SQL_str As String = "SELECT * FROM Aging_H WHERE Aging_No ='" & Txt_No.Text & "'"
        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        Dim Reader As SqlDataReader
        Reader = SQL_Cmd.ExecuteReader()
        If Not Reader.Read() Then     '判斷檔尾 無單頭資料資料
            MsgBox("無該工單: [" & Txt_No.Text & " ] 單頭資料,請先按存檔儲存資料!!" & vbCrLf)
            Conn.Close()
            Return
        End If

        Reader.Close()

        If CB_LampNo_change.Checked = False Then
            '明細資料處理
            '明細資料判斷Aging.Aging_D 
            SQL_str = "SELECT * FROM Aging_D WHERE Aging_No = '" & Txt_No.Text & "' And Aging_No2= '" & Txt_No2.Text & "'"
            SQL_Cmd.CommandText = SQL_str
            Reader = SQL_Cmd.ExecuteReader()
            If Not Reader.Read() Then     '判斷檔尾 無重複資料
                Select Case MainForm.Aging_Chk
                    Case 1, 2
                        MsgBox("該燈板號碼: [" & Txt_No.Text & "-" & Txt_No2.Text & " ] 尚未建立資料，" & vbCrLf &
       "如要新增資料請返回抽氣頁面新增資料!!" & vbCrLf)
                    Case 3
                        MsgBox("該燈板號碼: [" & Txt_No.Text & "-" & Txt_No2.Text & " ] 尚未建立資料，" & vbCrLf &
       "如要新增請按新增儲存資料!!" & vbCrLf)
                End Select
                Conn.Close()
                Return
            End If
            Reader.Close()
        End If

        Dim Data_Time_String As String = DateString & " " & Format(Now, "HH:mm")
        '修改明細資料
        Try
            If CB_LampNo_change.Checked <> True Then
                SQL_str = "UPDATE Aging_D SET " _
                & " Car_No ='" & Cmb_Car.Text & "'," _
                & " Car_No2 ='" & Cmb_Car2.Text & "'," _
                & " Car_No3 ='" & Cmb_Car3.Text & "'," _
                & " voltage =" & Txt_voltage.Text & "," _
                & " ampere =" & Txt_ampere.Text & "," _
                & " frame_No ='" & Cmb_frame_No.Text & "'," _
                & " Inv_No ='" & Cmb_Inv_No.Text & "'," _
                & " determine ='" & Txt_determine.Text & "'," _
                & " pre1 =" & Txt_pre1.Text & "," _
                & " pre2 =" & Txt_pre2.Text & "," _
                & " pre3 =" & Txt_pre3.Text & "," _
                & " pre4 =" & Txt_pre4.Text & "," _
                & " watt =" & Txt_watt.Text & "," _
                & " voltage2 =" & Txt_voltage2.Text & "," _
                & " ampere2 =" & Txt_ampere2.Text & "," _
                & " lv ='" & Cmb_lv.Text & "'," _
                & " LAMPS_NO ='" & Txt_LAMP_NO.Text & "'," _
                & " remark ='" & Txt_remark.Text & "',"

                Select Case MainForm.Aging_Chk
                    Case 1, 2
                        SQL_str &= " Aging_modify_date ='" & Data_Time_String & "'," _
                                & " Aging_modify ='" & Txt_User.Text & "',"
                    Case 3
                        SQL_str &= " SYS_Date ='" & Data_Time_String & "'," _
                                & " SYS_UID ='" & Txt_User.Text & "',"
                End Select

                SQL_str &= " Car_No4 ='" & Car_Pre_injection.Text & "'," _
                & " Car_No5 ='" & Car_balance.Text & "'," _
                & " Car_status ='" & Car_status.Text & "'," _
                & " Car_No6 ='" & Cmb_Car6.Text & "'" _
                & " WHERE Aging_No = '" & Txt_No.Text & "' And Aging_No2= '" & Txt_No2.Text & "' And ID= '" & TXT_ID.Text & "'"
            Else
                SQL_str = "UPDATE TOP(1) Aging_D SET Aging_No2= '" & Txt_No2.Text & "'," _
                & " SYS_Date ='" & Data_Time_String & "'," _
                & " SYS_UID ='" & Txt_User.Text & "'" _
                & " WHERE Aging_No = '" & Txt_No.Text & "'" _
                & " And Car_No= '" & Cmb_Car.Text & "'" _
                & " And Car_No2 ='" & Cmb_Car2.Text & "'" _
                & " And Car_No3 ='" & Cmb_Car3.Text & "'" _
                & " And Car_No4 ='" & Car_Pre_injection.Text & "'" _
                & " And Car_No5 ='" & Car_balance.Text & "'" _
                & " And Car_No6 ='" & Cmb_Car6.Text & "'" _
                & " And Car_status ='" & Car_status.Text & "'" _
                & " And Aging_D_Date ='" & Txt_D_Date.Text & "'" _
                & " And ID ='" & TXT_ID.Text & "'"
                CB_LampNo_change.Checked = False
            End If
            SQL_Cmd.CommandText = SQL_str
            SQL_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
        Catch ex As Exception
            MsgBox("修改明細資料失敗!!" & vbCrLf & ex.Message)
        End Try

        SQL_Count(Txt_No.Text, True)            'Aging 統計處理

        Conn.Close()

        Dim Indexid As Integer = DataGridView1.CurrentCell.RowIndex  '取得目前滑鼠所在行數
        DataGVOrderBy()

        Me.DataGridView1.FirstDisplayedScrollingRowIndex = Indexid
        DataGridView1.CurrentCell = DataGridView1.Rows(Indexid).Cells(0)    '移動到上次選取行數
    End Sub

    Private Sub Btn_del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_del.Click

        If Txt_No.Text = "" Then
            MsgBox(" 工單NO 不能為空值!!" & vbCrLf)
            Txt_No.Focus()
            Return
        End If
        If Txt_No2.Text = "" Then
            MsgBox(" 燈板號碼 不能為空值!!" & vbCrLf)
            Txt_No2.Focus()
            Return
        End If

        ' 顯示確認刪除的訊息對話方塊
        Dim ret As Integer ' MsgBox的傳回值
        ret = MsgBox("是否真的要刪除該燈板號碼: [" & Txt_No.Text & "-" & Txt_No2.Text & " ] 資料!!", vbYesNo, "確認刪除")
        If ret <> vbYes Then
            Txt_No2.Focus()
            Return
        End If

        Conn.Open()

        '單頭資料判斷Aging.Aging_H 
        Dim SQL_str As String = "SELECT * FROM Aging_H WHERE Aging_No ='" & Txt_No.Text & "'"
        Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
        Dim Reader As SqlDataReader
        Reader = SQL_Cmd.ExecuteReader()
        If Not Reader.Read() Then     '判斷檔尾 無單頭資料資料
            MsgBox("無該工單: [" & Txt_No.Text & " ] 單頭資料,請確認刪除資料是否正確!!" & vbCrLf)
            Conn.Close()
            Return
        End If
        Reader.Close()

        ''明細資料處理
        '明細資料判斷Aging.Aging_D
        SQL_str = "SELECT * FROM Aging_D WHERE Aging_No = '" & Txt_No.Text & "' And Aging_No2= '" & Txt_No2.Text & "'"
        SQL_Cmd.CommandText = SQL_str
        Reader = SQL_Cmd.ExecuteReader()
        If Not Reader.Read() Then     '判斷檔尾 無重複資料
            MsgBox("該燈板號碼: [" & Txt_No.Text & "-" & Txt_No2.Text & " ] 沒資料,請確認刪除資料是否正確!!" & vbCrLf)
            Conn.Close()
            Return
        End If
        Reader.Close()

        '刪除明細資料
        Try
            SQL_str = "Delete FROM Aging_D WHERE Aging_No = '" & Txt_No.Text & "'" _
                & " And Aging_No2= '" & Txt_No2.Text & "'" _
                & " And Car_No= '" & Cmb_Car.Text & "'" _
                & " And Car_No2 ='" & Cmb_Car2.Text & "'" _
                & " And Car_No3 ='" & Cmb_Car3.Text & "'" _
                & " And Car_No4 ='" & Car_Pre_injection.Text & "'" _
                & " And Car_No5 ='" & Car_balance.Text & "'" _
                & " And Car_No6 ='" & Cmb_Car6.Text & "'" _
                & " And Aging_D_Date ='" & Txt_D_Date.Text & "'" _
                & " And determine ='" & Txt_determine.Text & "'" _
                & " And ID ='" & TXT_ID.Text & "'" _
                & " And lv ='" & Cmb_lv.Text & "'"
            SQL_Cmd.CommandText = SQL_str
            SQL_Cmd.ExecuteNonQuery()        '執行Sqlcommand	
        Catch ex As Exception
            MsgBox("刪除明細資料失敗!!" & vbCrLf & ex.Message)
        End Try

        SQL_Count(Txt_No.Text, True)            'Aging 統計處理

        Conn.Close()

        Dim IndeID As Integer = DataGridView2.CurrentRow.Index  '取得目前滑鼠所在行數

        Load_AgingNO()
        If DataGridView2.RowCount > 0 Then
            If IndeID < 0 Then
                IndeID = IndeID + 1
            ElseIf IndeID > DataGridView2.Rows.Count - 1 Then
                IndeID = IndeID - 1
            End If
            Me.DataGridView2.FirstDisplayedScrollingRowIndex = IndeID
            DataGridView2.CurrentCell = DataGridView2.Rows(IndeID).Cells(0)    '移動到上次選取行數
        End If

        TabControl1.SelectedTab = TabControl1.TabPages(0)   '切換到資料欄位頁

        IndeID = DataGridView1.CurrentRow.Index  '取得目前滑鼠所在行數

        DataGVOrderBy()

        If DataGridView1.RowCount > 0 Then
            If IndeID < 0 Then
                IndeID = IndeID + 1
            ElseIf IndeID > DataGridView1.Rows.Count - 1 Then
                IndeID = IndeID - 1
            End If
            Me.DataGridView1.FirstDisplayedScrollingRowIndex = IndeID
            DataGridView1.CurrentCell = DataGridView1.Rows(IndeID).Cells(0)    '移動到上次選取行數
        End If
    End Sub
    Sub DataGVOrderBy()
        '排序
        Dim DGVSortedColumn As Integer
        Dim direction As ComponentModel.ListSortDirection
        Dim oldColumn As DataGridViewColumn = Nothing

        If DataGridView1.SortedColumn IsNot Nothing Then
            oldColumn = DataGridView1.SortedColumn '取得舊排序
            DGVSortedColumn = DataGridView1.SortedColumn.Index
            If DataGridView1.SortOrder.ToString <> "Ascending" Then
                direction = ComponentModel.ListSortDirection.Descending
            Else
                direction = ComponentModel.ListSortDirection.Ascending
            End If

        End If

        '畫面處理()
        '連到明細資料處理
        Load_SQL()

        '排序
        If oldColumn IsNot Nothing Then
            DataGridView1.Sort(DataGridView1.Columns(DGVSortedColumn), direction)
        End If

        '行首加入數字
        'OrderByNum(DataGridView1)
        Me.DataGridView1.Refresh()  '更新DataGridView1 畫面
        DataGridView1.Size = New System.Drawing.Size(DataGridView1.Size.Width + 1, DataGridView1.Size.Height + 1) '重新定義視窗大小
        DataGridView1.Size = New System.Drawing.Size(DataGridView1.Size.Width - 1, DataGridView1.Size.Height - 1) '重新定義視窗大小
    End Sub
    Private Sub Txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles Txt_X1.KeyPress, Txt_X2.KeyPress, Txt_X3.KeyPress, Txt_Y1.KeyPress, Txt_Y2.KeyPress, Txt_Y3.KeyPress,
        Cmb_Car.KeyPress, Cmb_frame_No.KeyPress, Cmb_Inv_No.KeyPress, Txt_voltage.KeyPress, Txt_ampere.KeyPress,
        Txt_pre1.KeyPress, Txt_pre2.KeyPress, Txt_pre3.KeyPress, Txt_pre4.KeyPress, Txt_watt.KeyPress,
        Txt_TEST_voltage.KeyPress, Txt_TEST_ampere.KeyPress, Txt_voltage2.KeyPress, Txt_ampere2.KeyPress,
        Cmb_Car3.KeyPress, Assembly_Txt_ampere3.KeyPress

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
    Private Sub Txt_determine_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_determine.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper '轉換為大寫
        '限制TextBox只能輸入數字
        If (ChrW(Asc("0")) <= e.KeyChar And e.KeyChar <= ChrW(Asc("9"))) _
            Or (ChrW(Asc("A")) <= e.KeyChar And e.KeyChar <= ChrW(Asc("Z"))) Then '只準0~9和A~Z
            Exit Sub
        ElseIf e.KeyChar = ChrW(8) Then '如果想要能用 backspace 鍵
            Exit Sub
        End If

        e.KeyChar = Nothing
        ''------------------------------------------------------------------
    End Sub
    Private Sub Txt_determine_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_determine.GotFocus
        If Enter_Error.Visible = True Then
            Enter_Error.Visible = False
            Enter_Error.Location = New System.Drawing.Point(360, 526)
        End If
    End Sub


    Dim determine_mem(2) As String
    Private Sub Txt_determine_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_determine.Leave
        Txt_DetermineRemark()
        Enter_Error.Visible = True
        Enter_Error.ForeColor = Color.Red
        Enter_Error.Location = New System.Drawing.Point(703, 495)
    End Sub
    Sub Txt_DetermineRemark()
        '"00"為正常 跳離判斷
        If RTrim(Txt_determine.Text) = "00" Then
            Dim SInStr As Integer = InStr(1, Txt_remark.Text, determine_mem(1))
            If SInStr > 0 Then
                Dim mem As String = Txt_remark.Text.Substring(0, SInStr - 1)
                mem &= Txt_remark.Text.Substring(Txt_remark.Text.IndexOf(determine_mem(1)) + determine_mem(1).Length)
                Txt_remark.Text = mem
            End If
            Return
        ElseIf Txt_No2.Text = "" Then
            Return
        ElseIf Txt_determine.Text = "" Then
            Txt_determine.Focus()
            Return
        End If

        '將說明文字放入備註(KeyPress 鍵盤輸入)
        Dim TEXT_ As String = TXT_ToolTip.GetToolTip(Txt_determine)
        If TEXT_.IndexOf(Txt_determine.Text) <> -1 Then
            Dim TxTRemark As Integer = -1
            If Not determine_mem(1) = Nothing Then
                TxTRemark = Txt_remark.Text.IndexOf(determine_mem(1)) '檢查備註內是否已有不良原因
            End If
            If determine_mem(0) <> Trim(Txt_determine.Text.Substring(0, 2)) Or TxTRemark < 0 Then
                TEXT_ = TEXT_.Substring(InStr(1, TEXT_, Txt_determine.Text) + 2)
                TEXT_ = TEXT_.Substring(0, TEXT_.IndexOf(Chr(10)) - 1)
                Console.WriteLine("Car_status : {0}", TEXT_)

                If Txt_determine.SelectedIndex > 0 Then
                    '修正要存入data的值 會與畫面看到的有點不太一樣
                    'Txt_determine.SelectedValue 抓取ValueMember指定的欄位裡的值!!! 
                    Txt_determine.Text = Txt_determine.SelectedValue.ToString()
                    'Exit Sub
                End If

                If Txt_remark.Text = "" Then
                    Txt_remark.Text = TEXT_
                Else
                    '如果修改判定就將原本的判定改為修改後的判定
                    Dim SInStr As Integer = InStr(1, Txt_remark.Text, determine_mem(1)) '檢查備註內是否已有不良原因位置
                    If SInStr <> 0 And determine_mem(0) <> Nothing And determine_mem(0) <> Txt_determine.Text Then
                        Dim mem As String = Txt_remark.Text.Substring(0, SInStr - 1)
                        mem &= TEXT_
                        mem &= Txt_remark.Text.Substring(TxTRemark + determine_mem(1).Length)
                        Console.WriteLine("mem : {0}", mem)
                        Txt_remark.Text = mem
                    ElseIf determine_mem(0) <> Txt_determine.Text.Substring(0, 2) Or TxTRemark = -1 Then
                        Txt_remark.Text = Trim(Txt_remark.Text) & " " & TEXT_
                    End If
                End If
                determine_mem(0) = Txt_determine.Text
                determine_mem(1) = TEXT_
            End If
            Exit Sub
        End If
    End Sub
    Private Sub Txt_Type_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Type.Leave
        '修正要存入data的值 會與畫面看到的有點不太一樣
        If Txt_Type.SelectedValue IsNot Nothing Then
            Txt_Type.Text = Txt_Type.SelectedValue.ToString()
        End If
    End Sub
    Private Sub Txt_No2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles Txt_No2.KeyPress, Txt_No2_1.KeyPress

        If sender.Text.IndexOf("-") <> -1 Then
            sender.MaxLength = 8
            Dim S1 As String = Mid(sender.Text, 1, sender.Text.IndexOf("-"))
            Dim S2 As String = Mid(sender.Text, sender.Text.IndexOf("-") + 2)
            If sender.SelectionLength < 1 And S1.Length > 2 And S2.Length > 3 And e.KeyChar <> ChrW(8) Then
                e.KeyChar = Nothing
            End If
        Else
            sender.MaxLength = 4
        End If

        '限制TextBox只能輸入數字
        If (ChrW(Asc("0")) <= e.KeyChar And e.KeyChar <= ChrW(Asc("9"))) _
            Or e.KeyChar = ChrW(Asc("-")) _
            Or e.KeyChar = ChrW(Asc("A")) _
            Or e.KeyChar = ChrW(Asc("B")) _
            Or e.KeyChar = ChrW(Asc("C")) _
            Or e.KeyChar = ChrW(Asc("D")) _
            Or e.KeyChar = ChrW(Asc("E")) _
            Or e.KeyChar = ChrW(Asc("a")) _
            Or e.KeyChar = ChrW(Asc("b")) _
            Or e.KeyChar = ChrW(Asc("c")) _
            Or e.KeyChar = ChrW(Asc("d")) _
            Or e.KeyChar = ChrW(Asc("e")) Then '只準0~9
            Exit Sub
        End If

        If e.KeyChar = ChrW(8) Then '如果想要能用 backspace 鍵
            If sender.name = "Txt_No2" And Txt_No2_1.Visible = True Then
                Txt_No2_1.Visible = False
                Cmb_Car2_1.Visible = False
                Car_status_1.Visible = False
                Txt_remark_1.Visible = False
                Txt_remark.Size = New System.Drawing.Size(800, 22)
            End If
            Exit Sub
        End If
        e.KeyChar = Nothing
        ''------------------------------------------------------------------
    End Sub

    Declare Function GetKeyboardState Lib "user32" (ByVal pbKeyState As Byte()) As Short
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim MyKeys(255) As Byte
        GetKeyboardState(MyKeys)
        'Ctrl + Tab 出現第二片輸入TextBox
        If CType(msg.WParam, Keys) = Keys.Tab And TypeOf Control.FromHandle(msg.HWnd) Is TextBox And MyKeys(17) > 1 _
            And MainForm.Aging_Chk = "3" Then
            'AndAlso Control.FromHandle(msg.HWnd).Name = "Txt_No2"

            Txt_No2_1.Visible = True
            Cmb_Car2_1.Visible = True
            Car_status_1.Visible = True
            Txt_remark_1.Visible = True
            Txt_remark.Size = New System.Drawing.Size(400, 22)
            SelectNextControl(Control.FromHandle(msg.HWnd), True, True, True, False)
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub Txt_No2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_No2.GotFocus
        Txt_No2.SelectAll()
    End Sub
    Dim Txt_No2_IndexOf As Boolean
    Private Sub Txt_No2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_No2.Leave
        If Txt_No2.Text = "" Or CB_LampNo_change.Checked = True Then
            Txt_No2_1.Visible = False
            Cmb_Car2_1.Visible = False
            Car_status_1.Visible = False
            Txt_remark_1.Visible = False
            Txt_remark.Size = New System.Drawing.Size(800, 22)
            If (Txt_No2.Text.Length < 4 And Txt_No2.Text <> "") Then
                Txt_No2.Text = String.Format("{0:0000}", Val(Txt_No2.Text)) '不足四位補0
            End If
            Exit Sub
        End If

        Dim index As Integer, count As Integer
        Dim strA As String
        strA = Txt_No2.Text
        count = 0
        Do While strA.IndexOf("-", 1) <> -1
            index = strA.IndexOf("-", 1)
            If (index) > 0 Then
                strA = strA.Remove(index, 1)
                count = count + 1
            End If
        Loop

        Dim DSQL_str As String = ""
        Dim DSQL_str_To As String = ""
        Dim AgingNo_ As String = ""
        Dim S1 As String = ""
        Dim S2 As String = ""
        If count > 0 Then
            AgingNo_ = Mid(Txt_No.Text, 1, 7)

            S1 = Mid(Txt_No2.Text, 1, Txt_No2.Text.IndexOf("-"))  '工單流水號
            S2 = Mid(Txt_No2.Text, Txt_No2.Text.IndexOf("-") + 2) '燈板號碼
            If S1.Length < 3 Then
                S1 = String.Format("{0:000}", Val(S1)) '不足三位補0
            End If
            DSQL_str_To = "SELECT * FROM Aging_D WHERE Aging_No = '" & AgingNo_ & S1 & "' And Aging_No2= '" & S2 & "'"
        End If

        Select Case count
            Case 1
                If S2.Length < 4 Then
                    S2 = String.Format("{0:0000}", Val(S2)) '不足四位補0
                End If
                DSQL_str = "SELECT * FROM Aging_D WHERE Aging_No = '" & AgingNo_ & S1 & "' And Aging_No2= '" & S2 & "'"

                Console.WriteLine("工單號碼 : {0}", S1)
                Console.WriteLine("燈板號碼 : {0}", S2)
                Txt_No2.Text = S1 & "-" & S2
                Txt_No2_IndexOf = True

            Case 2
                Dim S3 As String = Mid(S2, 1, S2.IndexOf("-"))
                Dim S4 As String = Mid(S2, S2.IndexOf("-") + 2)

                S3 = String.Format("{0:000}", Val(S3)) '不足3位補0
                If Not ContainsChtString(S4) Then
                    S4 = String.Format("{0:00}", Val(S4)) '不足2位補0
                End If

                DSQL_str = "SELECT * FROM Aging_D WHERE Aging_No = '" & AgingNo_ & S1 & "' And Aging_No2= '" & S3 & "-" & S4 & "'"

                Console.WriteLine("工單號碼 : {0}", S1)
                Console.WriteLine("燈板號碼 : {0}", S3 & "-" & S4)
                Txt_No2.Text = S1 & "-" & S3 & "-" & S4
                Txt_No2_IndexOf = True
            Case Else
                DSQL_str_To = "SELECT * FROM Aging_D WHERE Aging_No = '" & Txt_No.Text & "' And Aging_No2= '" & Txt_No2.Text & "'"
                If (Txt_No2.Text.Length < 4 And Txt_No2.Text <> "") Then
                    Txt_No2.Text = String.Format("{0:0000}", Val(Txt_No2.Text)) '不足四位補0
                End If
                '四位數
                DSQL_str = "SELECT * FROM Aging_D WHERE Aging_No = '" & Txt_No.Text & "' And Aging_No2= '" & Txt_No2.Text & "'"
                Txt_No2_IndexOf = False

        End Select

        Txt_D_Date.Enabled = False

        If Txt_No2_SQL(DSQL_str) <> True And Txt_No2_SQL(DSQL_str_To) <> True Then     '搜尋燈板號碼資料

            '放入預設值

            If MainForm.Aging_Chk = 3 Then
                Txt_D_Date.Enabled = True
            End If

            Txt_D_Date.Text = DateString & " " & Format(Now, "HH:mm")
            Cmb_Car.Text = "01"
            Cmb_Car2.Text = "01"
            Cmb_Car3.Text = "01"
            Cmb_Car6.Text = "A"
            Car_Pre_injection.Text = "0.0"
            Car_balance.Text = "0.0"
            Car_status.Text = ""
            Cmb_frame_No.Text = "01"
            Cmb_Inv_No.Text = "01"
            Txt_determine.Text = "00"
            Txt_watt.Text = "0.0"
            Cmb_lv.Text = "N"
            Txt_remark.Text = ""
            Txt_LAMP_NO.Text = ""
        End If

    End Sub
    Function ContainsChtString(str) '判斷是否為英文
        Dim x, tmp, ascNum
        tmp = False
        For x = 1 To Len(str)
            ascNum = Asc(Mid(str, x, 1))
            If ascNum >= 61 And ascNum <= 122 Then
                tmp = True
                Exit For
            End If
        Next
        ContainsChtString = tmp
    End Function

    Private Sub Txt_No2_1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_No2_1.Leave
        If sender.text <> "" Then
            Dim index As Integer, count As Integer
            Dim strA As String
            strA = Txt_No2_1.Text
            count = 0
            Do While strA.IndexOf("-", 1) <> -1
                index = strA.IndexOf("-", 1)
                If (index) > 0 Then
                    strA = strA.Remove(index, 1)
                    count = count + 1
                End If
            Loop

            Dim S1 As String = ""
            Dim S2 As String = ""
            If count > 0 Then
                S1 = Mid(Txt_No2_1.Text, 1, Txt_No2_1.Text.IndexOf("-"))  '工單流水號
                S2 = Mid(Txt_No2_1.Text, Txt_No2_1.Text.IndexOf("-") + 2) '燈板號碼
                If S1.Length < 3 Then
                    S1 = String.Format("{0:000}", Val(S1)) '不足三位補0
                End If
            End If

            Select Case count
                Case 1
                    If S2.Length < 4 Then
                        S2 = String.Format("{0:0000}", Val(S2)) '不足四位補0
                    End If
                    Console.WriteLine("工單號碼 : {0}", S1)
                    Console.WriteLine("燈板號碼 : {0}", S2)
                    Txt_No2_1.Text = S1 & "-" & S2

                Case 2
                    Dim S3 As String = Mid(S2, 1, S2.IndexOf("-"))
                    Dim S4 As String = Mid(S2, S2.IndexOf("-") + 2)

                    S3 = String.Format("{0:000}", Val(S3)) '不足3位補0
                    If Not ContainsChtString(S4) Then
                        S4 = String.Format("{0:00}", Val(S4)) '不足2位補0
                    End If

                    Console.WriteLine("工單號碼 : {0}", S1)
                    Console.WriteLine("燈板號碼 : {0}", S3 & "-" & S4)
                    Txt_No2_1.Text = S1 & "-" & S3 & "-" & S4

                Case Else
                    If (Txt_No2_1.Text.Length < 4 And Txt_No2_1.Text <> "") Then
                        Txt_No2_1.Text = String.Format("{0:0000}", Val(Txt_No2_1.Text)) '不足四位補0
                    End If
            End Select

            If Txt_No2_1.Text = Txt_No2.Text Then
                Enter_Error.Visible = True
                Enter_Error.Text = "燈板號碼相同"
                Enter_Error.ForeColor = Color.Red
                Enter_Error.Location = New System.Drawing.Point(59, 510)
                Txt_No2_1.Focus()
            End If
        End If
    End Sub
    Function Txt_No2_SQL(ByVal DSQL_str As String) As Boolean
        Try
            '資料搜尋帶入
            Conn.Open()

            '單身資料搜尋Aging.Aging_D
            Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
            Dim DReader As SqlDataReader
            Dim D_Boolen As Boolean
            DReader = DSQL_Cmd.ExecuteReader()
            If DReader.Read() Then     '判斷檔尾 有資料
                Txt_No2.Text = RTrim(DReader.Item("Aging_No2"))
                Txt_D_Date.Text = RTrim(DReader.Item("Aging_D_Date"))
                Cmb_Car.Text = RTrim(DReader.Item("Car_No"))    '抽氣台車
                Cmb_Car2.Text = RTrim(DReader.Item("Car_No2"))  '位置
                Cmb_Car3.Text = RTrim(DReader.Item("Car_No3"))  '圈數
                '1041210 Aging_D 增加新欄位Car_4、Car_5、Car_6、Car_status
                '避免讀取舊資料出現DBNull
                If Not IsDBNull(DReader.Item("Car_No6")) Then ' 如果變數內容不是Null就顯示在TextBox
                    Cmb_Car6.Text = RTrim(DReader.Item("Car_No6"))  '線別
                Else
                    Cmb_Car6.Text = ""
                End If
                If Not IsDBNull(DReader.Item("Car_No4")) Then ' 如果變數內容不是Null就顯示在TextBox
                    Car_Pre_injection.Text = RTrim(DReader.Item("Car_No4")) '預注值
                Else
                    Car_Pre_injection.Text = ""
                End If
                If Not IsDBNull(DReader.Item("Car_No5")) Then ' 如果變數內容不是Null就顯示在TextBox
                    Car_balance.Text = RTrim(DReader.Item("Car_No5"))   '平衡值
                Else
                    Car_balance.Text = ""
                End If
                If Not IsDBNull(DReader.Item("Car_status")) Then ' 如果變數內容不是Null就顯示在TextBox
                    Car_status.Text = RTrim(DReader.Item("Car_status")) '不良原因
                Else
                    Car_status.Text = ""
                End If

                Cmb_frame_No.Text = RTrim(DReader.Item("frame_No"))
                Cmb_Inv_No.Text = RTrim(DReader.Item("Inv_No"))
                Txt_determine.Text = RTrim(DReader.Item("determine"))
                Txt_watt.Text = RTrim(DReader.Item("watt"))
                Cmb_lv.Text = RTrim(DReader.Item("lv"))
                Txt_remark.Text = RTrim(DReader.Item("remark"))
                Txt_LAMP_NO.Text = RTrim(DReader.Item("LAMPS_NO"))

                '未出現"-" 或是流水號相同移動到那一行
                If Mid(DSQL_str, 48, 3) = Mid(Txt_No.Text, 8, 3) Or Txt_No2_IndexOf = False Then
                    For i = 0 To DataGridView1.RowCount - 1
                        If (DataGridView1.Rows(i).Cells("燈板號碼").Value.ToString() = Txt_No2.Text) Then
                            DataGridView1.CurrentCell = Me.DataGridView1.Rows(i).Cells(0)  '移動到當行
                            Exit For
                        End If
                    Next
                Else
                    Txt_No2.Text = Mid(RTrim(DReader.Item("Aging_No")), 8, 3) & "-" & Txt_No2.Text
                End If

                D_Boolen = True
            Else
                D_Boolen = False
            End If
            Conn.Close()
            Return D_Boolen

        Catch ex As Exception
            MsgBox(ex.Message)
            SaveLog(ex.Message)
        End Try
    End Function

    Private Sub Txt_preOM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_preOM.KeyPress
        '限制TextBox只能輸入數字
        If (ChrW(Asc("0")) <= e.KeyChar And e.KeyChar <= ChrW(Asc("9"))) Or e.KeyChar = ChrW(Asc(".")) Or e.KeyChar = ChrW(Asc("-")) Then '只準0~9和小數點和"-"
            Exit Sub
        End If
        If e.KeyChar = ChrW(8) Then '如果想要能用 backspace 鍵
            Exit Sub
        End If
        e.KeyChar = Nothing
        ''------------------------------------------------------------------
    End Sub

    Private Sub Cmb_Car2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles Cmb_Car2.KeyPress, Cmb_Car2_1.KeyPress
        If Enter_Error.Visible = True Then
            Enter_Error.Visible = False
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper '轉換為大寫

        '限制TextBox只能輸入數字
        If (ChrW(Asc("0")) <= e.KeyChar And e.KeyChar <= ChrW(Asc("9"))) _
         Or e.KeyChar = ChrW(Asc("L")) Or e.KeyChar = ChrW(Asc("R")) Then '只準0~9
            Exit Sub
        End If

        If e.KeyChar = ChrW(8) Then '如果想要能用 backspace 鍵
            Exit Sub
        End If

        e.KeyChar = Nothing
        ''------------------------------------------------------------------
    End Sub

    Private Sub Cmb_Car2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Car2.Leave, Cmb_Car2_1.Leave
        If sender.Text <> "" Then
            If sender.Text <> "L" And sender.Text <> "R" Then
                If sender.Text > 0 And sender.Text <= 10 Then
                    If Cmb_Car6.Text = "MR" Then
                        '數字補0
                        sender.Text = Format(Val(sender.Text), "00")
                    Else
                        If sender.Text = "01" Or sender.Text = "1" Then
                            sender.Text = "L"
                        ElseIf sender.Text = "02" Or sender.Text = "2" Then
                            sender.Text = "R"
                        End If
                    End If
                    Return
                End If
            Else
                Return
            End If
        End If

        If sender.name = "Cmb_Car2" Then
            Cmb_Car2.Focus()
        Else
            Cmb_Car2_1.Focus()
        End If
        Enter_Error.Visible = True
        Enter_Error.Location = New System.Drawing.Point(429, 87)
    End Sub
    Private Sub Cmb_Car3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Car3.Leave
        If Cmb_Car3.Text <> "" Then
            If Cmb_Car3.Text > 0 And Cmb_Car3.Text <= 10 Then
                '數字補0
                Cmb_Car3.Text = Format(Val(Cmb_Car3.Text), "00")
                Return
            End If
        End If
        Cmb_Car3.Focus()
    End Sub

    Private Sub Cmb_Car6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cmb_Car6.KeyPress
        '限制TextBox只能輸入數字
        If e.KeyChar = ChrW(Asc("a")) Or e.KeyChar = ChrW(Asc("A")) _
            Or e.KeyChar = ChrW(Asc("b")) Or e.KeyChar = ChrW(Asc("B")) _
            Or e.KeyChar = ChrW(Asc("m")) Or e.KeyChar = ChrW(Asc("M")) _
            Or e.KeyChar = ChrW(Asc("r")) Or e.KeyChar = ChrW(Asc("R")) Then
            Enter_Error.Visible = False
            Exit Sub
        End If
        If e.KeyChar = ChrW(8) Then '如果想要能用 backspace 鍵
            Enter_Error.Visible = False
            Exit Sub
        End If
        e.KeyChar = Nothing
        ''------------------------------------------------------------------
    End Sub
    Private Sub Cmb_Car6_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Car6.Leave
        Cmb_Car6.Text = Cmb_Car6.Text.ToUpper()

        If Cmb_Car6.Text <> "A" And Cmb_Car6.Text <> "B" And Cmb_Car6.Text <> "MR" Then
            Enter_Error.Visible = True
            Enter_Error.Location = New System.Drawing.Point(262, 495)
            Cmb_Car6.Focus()
            Return
        End If

        Cmb_Car6_SelectedIndexChanged()
    End Sub
    Private Sub Cmb_Car6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Car6.SelectedIndexChanged
        Cmb_Car6_SelectedIndexChanged()
    End Sub
    Sub Cmb_Car6_SelectedIndexChanged()
        If Cmb_Car6.Text = "MR" Then
            If Cmb_Car2.Text = "L" Then
                Cmb_Car2.Text = "01"
            ElseIf Cmb_Car2.Text = "R" Then
                Cmb_Car2.Text = "02"
            End If
            If Cmb_Car2_1.Text = "L" Then
                Cmb_Car2_1.Text = "01"
            ElseIf Cmb_Car2_1.Text = "R" Then
                Cmb_Car2_1.Text = "02"
            End If
        ElseIf Cmb_Car6.Text <> "MR" Then
            If Cmb_Car2.Text = "01" Then
                Cmb_Car2.Text = "L"
            ElseIf Cmb_Car2.Text = "02" Then
                Cmb_Car2.Text = "R"
            End If
            If Cmb_Car2_1.Text = "01" Then
                Cmb_Car2_1.Text = "L"
            ElseIf Cmb_Car2_1.Text = "02" Then
                Cmb_Car2_1.Text = "R"
            End If
        End If
    End Sub
    Private Sub Txt_D_Date_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_D_Date.GotFocus
        Txt_D_Date.Text = DateString & " " & Format(Now, "HH:mm")
    End Sub
    Private Sub Car_status_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Car_status.GotFocus, Car_status_1.GotFocus
        If Enter_Error.Visible = True Then
            Enter_Error.Visible = False
        End If
    End Sub

    Private Sub Car_status_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles Car_status.KeyPress, Car_status_1.KeyPress
        If Enter_Error.Visible = True Then
            Enter_Error.Visible = False
        End If

        '限制TextBox 第一位只能輸入E 或 N
        If (sender.Text.Length < 1 And (e.KeyChar = ChrW(Asc("E")) Or e.KeyChar = ChrW(Asc("e")) _
                                       Or e.KeyChar = ChrW(Asc("n")) Or e.KeyChar = ChrW(Asc("N")))) Then
            Exit Sub
        End If

        '如果第一位為N 可以改為E
        If (sender.Text.Length >= 1 AndAlso (sender.Text.Substring(0, 1) = "N" Or sender.Text.Substring(0, 1) = "E") _
            And (e.KeyChar = ChrW(Asc("E")) Or e.KeyChar = ChrW(Asc("e")) _
                 Or e.KeyChar = ChrW(Asc("n")) Or e.KeyChar = ChrW(Asc("N")))) Then '只準0~9
            Exit Sub
        End If

        '限制TextBox 第二位開始只能輸入數字
        If (sender.Text.Length >= 1 And (ChrW(Asc("0")) <= e.KeyChar And e.KeyChar <= ChrW(Asc("9")))) Then '只準0~9
            Exit Sub
        End If

        If e.KeyChar = ChrW(8) Then '如果想要能用 backspace 鍵
            Exit Sub
        End If
        e.KeyChar = Nothing
        ''------------------------------------------------------------------
    End Sub

    Dim Car_status_mem(4) As String
    Private Sub Car_status_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Car_status.Leave, Car_status_1.Leave
        If sender.Text.Length < 1 Or sender.Text.Length > 3 Then
            sender.Text = "N"
            'Car_status.Focus()
            Return
        End If

        '第一位數只能為E and N
        If (sender.Text.Substring(0, 1) <> "E") And (sender.Text.Substring(0, 1) <> "N") Then
            sender.Text = ""
            Enter_Error.Visible = True
            Enter_Error.ForeColor = Color.Red
            Enter_Error.Location = New System.Drawing.Point(360, 526)
            'Car_status.Focus()
            Return
        End If

        '第一位數為N 長度大於2 改為N
        If sender.Text.Substring(0, 1) = "N" Then
            If sender.Text.Length >= 1 Then
                If sender.name = "Car_status" Then
                    Dim SInStr As Integer = InStr(1, Txt_remark.Text, Car_status_mem(1))
                    If SInStr > 0 Then
                        Dim mem As String = Txt_remark.Text.Substring(0, SInStr - 1)
                        mem &= Txt_remark.Text.Substring(Txt_remark.Text.IndexOf(Car_status_mem(1)) + Car_status_mem(1).Length)
                        Txt_remark.Text = mem
                    End If
                Else
                    Dim SInStr As Integer = InStr(1, Txt_remark_1.Text, Car_status_mem(3))
                    If SInStr > 0 Then
                        Dim mem As String = Txt_remark_1.Text.Substring(0, SInStr - 1)
                        mem &= Txt_remark_1.Text.Substring(Txt_remark_1.Text.IndexOf(Car_status_mem(3)) + Car_status_mem(3).Length)
                        Txt_remark_1.Text = mem
                    End If
                End If
                sender.Text = "N"
                Return
            End If
        End If

        '第一位數為E 長度需大於2
        If sender.Text.Substring(0, 1) = "E" Then
            If sender.Text.Length < 2 Then
                sender.Focus()
                Return
            End If
        End If

        '第二位數補0
        If sender.Text.Length < 3 Then
            sender.Text = sender.Text.Substring(0, 1) & "0" & sender.Text.Substring(1)
        End If

        If sender.name = "Car_status" Then
            Car_StatusRemark_1()
        Else
            Car_StatusRemark_2()
        End If

        Enter_Error.Visible = True
        Enter_Error.ForeColor = Color.Red
        If Txt_No2_1.Visible = True Then
            Enter_Error.Location = New System.Drawing.Point(370, 530)
        Else
            Enter_Error.Location = New System.Drawing.Point(370, 500)
        End If
    End Sub
    Sub Car_StatusRemark_1()
        '不良原因加到備註
        Dim TEXT_ As String = TXT_ToolTip.GetToolTip(Car_status)
        If Val(Car_status.Text.Substring(1)) < Bad_DataTable.Rows.Count Then
            Dim TxTRemark As Integer = -1
            If Not Car_status_mem(1) = Nothing Then
                TxTRemark = Txt_remark.Text.IndexOf(Car_status_mem(1)) '檢查備註內是否已有不良原因
            End If

            If Car_status_mem(0) <> Car_status.Text Or TxTRemark < 0 Then
                TEXT_ = TEXT_.Substring(InStr(1, TEXT_, Car_status.Text) + 3)
                TEXT_ = TEXT_.Substring(0, TEXT_.IndexOf(Chr(10)) - 1)
                Console.WriteLine("Car_status : {0}", TEXT_)

                If Txt_remark.Text = "" Then
                    Txt_remark.Text = TEXT_
                Else
                    '如果修改不良原因就將原本的原因改為修改後的原因
                    Dim SInStr As Integer = InStr(1, Txt_remark.Text, Car_status_mem(1)) '檢查備註內是否已有不良原因位置
                    If SInStr <> 0 And Car_status_mem(0) <> Nothing And Car_status_mem(0) <> Car_status.Text Then
                        Dim mem As String = Txt_remark.Text.Substring(0, SInStr - 1)
                        mem &= TEXT_
                        mem &= Txt_remark.Text.Substring(TxTRemark + Car_status_mem(1).Length)
                        Console.WriteLine("mem : {0}", mem)
                        Txt_remark.Text = mem
                    ElseIf Car_status_mem(0) <> Car_status.Text Or TxTRemark = -1 Then
                        Txt_remark.Text = Trim(Txt_remark.Text) & " " & TEXT_
                    End If
                End If
                Car_status_mem(0) = Car_status.Text
                Car_status_mem(1) = TEXT_
            End If
            Exit Sub
        End If
    End Sub
    Sub Car_StatusRemark_2()
        '不良原因加到備註
        Dim TEXT_ As String = TXT_ToolTip.GetToolTip(Car_status)
        If Val(Car_status_1.Text.Substring(1)) < Bad_DataTable.Rows.Count Then
            Dim TxTRemark As Integer = -1
            If Not Car_status_mem(3) = Nothing Then
                TxTRemark = Txt_remark_1.Text.IndexOf(Car_status_mem(3)) '檢查備註內是否已有不良原因
            End If

            If Car_status_mem(2) <> Car_status_1.Text Or TxTRemark < 0 Then
                TEXT_ = TEXT_.Substring(InStr(1, TEXT_, Car_status_1.Text) + 3)
                TEXT_ = TEXT_.Substring(0, TEXT_.IndexOf(Chr(10)) - 1)
                Console.WriteLine("Car_status_1 : {0}", TEXT_)

                If Txt_remark_1.Text = "" Then
                    Txt_remark_1.Text = TEXT_
                Else
                    '如果修改不良原因就將原本的原因改為修改後的原因
                    Dim SInStr As Integer = InStr(1, Txt_remark_1.Text, Car_status_mem(3)) '檢查備註內是否已有不良原因
                    If SInStr <> 0 And Car_status_mem(2) <> Nothing And Car_status_mem(2) <> Car_status_1.Text Then
                        Dim mem As String = Txt_remark_1.Text.Substring(0, SInStr - 1)
                        mem &= TEXT_
                        mem &= Txt_remark_1.Text.Substring(TxTRemark + Car_status_mem(3).Length)
                        Console.WriteLine("mem : {0}", mem)
                        Txt_remark_1.Text = mem
                    ElseIf Car_status_mem(2) <> Car_status_1.Text Or TxTRemark = -1 Then
                        Txt_remark_1.Text = Trim(Txt_remark_1.Text) & " " & TEXT_
                    End If
                End If
                Car_status_mem(2) = Car_status_1.Text
                Car_status_mem(3) = TEXT_
            End If
            Exit Sub
        End If
    End Sub

    Private Sub Txt_LAMPS_NO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '自動產生成燈碼
        If Txt_LAMP_NO.Text = "" And Txt_No.Text <> "" And Txt_No2.Text <> "" Then
            Txt_LAMP_NO.Text = Txt_No.Text & "-" & Txt_No2.Text
        End If
    End Sub

    Private Sub CB_LampNo_change_CheckedChanged(sender As Object, e As EventArgs) Handles CB_LampNo_change.CheckedChanged
        If CB_LampNo_change.Checked = True Then
            'Txt_No.Enabled = False
            Txt_No2_1.Enabled = False
            Cmb_Car.Enabled = False
            Cmb_Car2.Enabled = False
            Cmb_Car2_1.Enabled = False
            Cmb_Car3.Enabled = False
            Car_Pre_injection.Enabled = False
            Car_balance.Enabled = False
            Car_status.Enabled = False
            Car_status_1.Enabled = False
            Txt_D_Date.Enabled = False
            Txt_remark.Enabled = False
            Txt_remark_1.Enabled = False
            Cmb_Car6.Enabled = False
            Btn_add.Enabled = False
            Btn_del.Enabled = False
        Else
            'Txt_No.Enabled = True
            Txt_No2_1.Enabled = True
            Cmb_Car.Enabled = True
            Cmb_Car2.Enabled = True
            Cmb_Car2_1.Enabled = True
            Cmb_Car3.Enabled = True
            Car_Pre_injection.Enabled = True
            Car_balance.Enabled = True
            Car_status.Enabled = True
            Car_status_1.Enabled = True
            Txt_D_Date.Enabled = True
            Txt_remark.Enabled = True
            Txt_remark_1.Enabled = True
            Cmb_Car6.Enabled = True
            Btn_add.Enabled = True
            Btn_del.Enabled = True
        End If
    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        OrderByNum(DataGridView1)
    End Sub
    Private Sub DataGridView2_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView2.ColumnHeaderMouseClick
        OrderByNum(DataGridView2)
        DataGridView2.HorizontalScrollingOffset = HScrollBar2AddressMem
    End Sub
    Private Sub DataGridView3_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView3.ColumnHeaderMouseClick
        OrderByNum(DataGridView3)
        DataGridView3.HorizontalScrollingOffset = HScrollBar3AddressMem
    End Sub
    Sub OrderByNum(ByVal DataGridView As DataGridView)
        '行首加入數字
        For i = 0 To DataGridView.Rows.Count - 1
            DataGridView.Rows(i).HeaderCell.Value = String.Format("{0}", i + 1)
        Next
        '行首大小自動調整
        DataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)
    End Sub
    Private Sub Assembly_Txt_LAMP_NO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Assembly_Txt_LAMP_NO.GotFocus
        If Label38.Visible = True Then
            Label38.Visible = False
        End If
    End Sub
    Private Sub Txt_LAMPS_NO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Assembly_Txt_LAMP_NO.KeyPress
        If Label38.Visible = True Then
            Label38.Visible = False
        End If
    End Sub

    Private Sub Assembly_Txt_LAMP_NOChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Assembly_Txt_LAMP_NO.TextChanged
        If Label38.Visible = True Then
            Label38.Visible = False
        End If
    End Sub

    Private Sub Txt_LAMPS_NO_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Assembly_Txt_LAMP_NO.Leave

        If Assembly_Txt_LAMP_NO.Text = "" Then
            Label38.Visible = True
            Label38.ForeColor = Color.Red
            Exit Sub
        End If

        '資料搜尋帶入
        Conn.Open()

        '單身資料搜尋Aging.Aging_D
        Dim DSQL_str As String = "SELECT * FROM Aging_D WHERE LAMPS_NO = '" & Assembly_Txt_LAMP_NO.Text & "'"
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader
        DReader = DSQL_Cmd.ExecuteReader()
        If DReader.Read() Then     '判斷檔尾 有資料
            '補資料的資料時 以下會無資料出現bug

            If Not IsDBNull(DReader.Item("Ballast_NO")) Then
                Assembly_Txt_Ballast_NO.Text = RTrim(DReader.Item("Ballast_NO"))
            End If
            If Not IsDBNull(DReader.Item("ampere3")) Then
                Assembly_Txt_ampere3.Text = RTrim(DReader.Item("ampere3"))
            End If

            If Not IsDBNull(DReader.Item("Aging_no2")) Then
                Assembly_Txt_No2.Text = RTrim(DReader.Item("Aging_no2"))
            End If
            If Not IsDBNull(DReader.Item("Aging_D_Date")) Then
                Assembly_Txt_D_Date.Text = RTrim(DReader.Item("Aging_D_Date"))
            End If
        End If

        DReader.Close()

        Conn.Close()
    End Sub
    Private Sub Btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_save.Click
        If Assembly_Txt_LAMP_NO.Text = "" Then
            MsgBox(" 成燈碼 不能為空值!!" & vbCrLf)
            Assembly_Txt_LAMP_NO.Focus()
            Return
        End If

        Assembly_SQL("Update")
        '畫面處理()
        ScreenRefresh()
    End Sub
    Private Sub Assembly_Btn_del_Click(sender As Object, e As EventArgs) Handles Assembly_Btn_del.Click
        If Assembly_Txt_LAMP_NO.Text = "" Then
            MsgBox("請選擇要刪除的燈板!!!" & vbCrLf)
            Assembly_Txt_LAMP_NO.Focus()
            Return
        End If
        ' 顯示確認刪除的訊息對話方塊
        Dim ret As Integer ' MsgBox的傳回值
        ret = MsgBox("是否要將成燈碼: [" & Assembly_Txt_LAMP_NO.Text & " ] 之燈板由 [" & Txt_No.Text & " ] 組裝工單中刪除!!",
                     vbYesNo, "確認刪除")
        If ret <> vbYes Then
            Assembly_Txt_LAMP_NO.Focus()
            Return
        End If
        Assembly_SQL("Del")
        '畫面處理()
        ScreenRefresh()
    End Sub

    Sub ScreenRefresh()
        '畫面處理()
        Assembly_Txt_LAMP_NO.Text = ""
        Assembly_Txt_Ballast_NO.Text = ""
        Assembly_Txt_ampere3.Text = 0.0
        Assembly_Txt_No2.Text = ""
        Assembly_Txt_D_Date.Text = ""
        Assembly_Txt_LAMP_NO.Focus()
    End Sub
    Sub Assembly_SQL(ByVal sender As String)
        Conn.Open()
        Try
            Dim SQL_str As String
            '單頭資料判斷Aging.Aging_H 
            SQL_str = "SELECT * FROM Aging_H WHERE Aging_No ='" & Txt_No.Text & "'"
            Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
            Dim Reader As SqlDataReader
            Reader = SQL_Cmd.ExecuteReader()
            If Not Reader.Read() Then     '判斷檔尾 無單頭資料資料
                MsgBox("無該工單: [" & Txt_No.Text & " ] 單頭資料,請先按存檔儲存資料!!" & vbCrLf)
                Conn.Close()
                Return
            End If
            Reader.Close()

            '明細資料判斷Aging.Aging_D 
            SQL_str = "SELECT * FROM Aging_D WHERE LAMPS_NO = '" & Assembly_Txt_LAMP_NO.Text & "'"
            SQL_Cmd.CommandText = SQL_str
            Reader = SQL_Cmd.ExecuteReader()

            Dim Data_Time_String As String = DateString & " " & Format(Now, "HH:mm")

            If Reader.Read() Then     '判斷檔尾 有重複資料
                '修改明細資料
                If sender = "Update" Then '更新資料
                    SQL_str = "UPDATE Aging_D SET Ballast_NO ='" & Assembly_Txt_Ballast_NO.Text & "',"
                    SQL_str &= " ampere3 =" & Assembly_Txt_ampere3.Text & ","
                    If Reader.Item("Assembly_build_date").ToString = "" Then
                        SQL_str &= " Assembly_build_date ='" & Data_Time_String & "',"
                        SQL_str &= " Assembly_build ='" & Txt_User.Text & "',"
                    End If
                    SQL_str &= " Assembly_modify_date ='" & Data_Time_String & "',"
                    SQL_str &= " Assembly_modify ='" & Txt_User.Text & "',"
                    SQL_str &= " Assembly_No ='" & Txt_No.Text & "'"
                    SQL_str &= " WHERE LAMPS_NO = '" & Assembly_Txt_LAMP_NO.Text & "' And ID = " & Reader.Item("ID")
                ElseIf sender = "Del" Then '刪除資料
                    SQL_str = "UPDATE Aging_D SET Ballast_NO = Null,"
                    SQL_str &= " ampere3 = Null,"
                    SQL_str &= " Assembly_build_date = Null,"
                    SQL_str &= " Assembly_modify_date = Null,"
                    SQL_str &= " Assembly_modify = Null,"
                    SQL_str &= " Assembly_No = Null"
                    SQL_str &= " WHERE LAMPS_NO = '" & Assembly_Txt_LAMP_NO.Text & "' And ID = " & Reader.Item("ID")
                End If
            Else
                MsgBox("請確認相關燈板資料是否已建立!!!", MsgBoxStyle.OkOnly, "查無資料")
                Reader.Close()
                Conn.Close()
                Exit Sub
            End If
            Reader.Close()
            SQL_Cmd.CommandText = SQL_str
            SQL_Cmd.ExecuteNonQuery()        '執行Sqlcommand
            'Aging 統計處理-------------------------------------------------------------------------------
            '投  入 :
            SQL_str = "SELECT COUNT(*) FROM Aging_D WHERE Assembly_No = '" & Txt_No.Text & "'"
            SQL_Cmd.CommandText = SQL_str
            Reader = SQL_Cmd.ExecuteReader()
            Reader.Read()
            Dim X1 As String = Reader.Item(0)
            'MainForm.Txt_X1.Text = X1
            Reader.Close()

            '修改Aging統計資料
            SQL_str = "UPDATE Aging_H SET Aging_X1 =" & X1 & "," _
                & " SYS_Date ='" & Data_Time_String & "'," _
                & " SYS_UID ='" & Login.ALL_UserID & "'" _
                & " WHERE Aging_No = '" & Txt_No.Text & "'"

            SQL_Cmd.CommandText = SQL_str
            SQL_Cmd.ExecuteNonQuery()        '執行Sqlcommand

            SQL_Count(Txt_No.Text, True)            'Aging 統計處理

            'Aging 統計處理---------------------------END----------------------------------------------------
            Conn.Close()

            Dim Indexid As Integer
            If DataGridView1.CurrentCell IsNot Nothing Then
                Indexid = DataGridView1.CurrentCell.RowIndex  '取得目前滑鼠所在行數
            End If
            Load_AgingNO()
            '畫面處理()
            '連到明細資料處理
            'Load_SQL()
            DataGVOrderBy()

            If DataGridView1.RowCount > 0 Then
                DataGridView1.CurrentCell = Me.DataGridView1.Rows(Indexid).Cells(0)    '移動到上次選取行數
                '行首加入數字
                'OrderByNum(DataGridView1)
            End If

        Catch ex As Exception
            MsgBox("修改明細資料失敗!!" & vbCrLf & ex.Message)
        End Try
        Conn.Close()
    End Sub

    Private Sub Btn_XLS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_XLS.Click
        If DataGridView1.RowCount < 1 Then
            MessageBox.Show("無資料可匯出成Excel", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        With OpenFileDialog1
            .Filter = "Excel file(*.xls)|*.xls"
            .Title = "請選擇Excel檔"
        End With

        '開啟對話框
        If (OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.Cancel) Then
            ' 使用者沒有選檔案
            Return
        End If

        Dim Filename As String = OpenFileDialog1.FileName '選擇的完整路徑
        Dim File_1 As FileStream = Nothing
        Dim workbook As HSSFWorkbook = Nothing
        Dim sheet As HSSFSheet = Nothing
        'Dim row As HSSFRow = sheet.CreateRow(0)
        Try
            File_1 = New FileStream(Filename, FileMode.Open) '準備開啟Excel檔
            workbook = New HSSFWorkbook(File_1) '先讓workbook 吃舊資料
            sheet = workbook.CreateSheet(Txt_No.Text) '建立工作頁
        Catch ex As IOException
            MessageBox.Show(ex.Message, "轉Excel 失敗!!")
            Exit Sub
        Catch ex As ArgumentException
            '已有相同工作頁
            Dim response As DialogResult
            response = (MessageBox.Show(
                        "該工作頁: [" & Txt_No.Text & " ] 已存在, " & vbCrLf &
                        "如要覆蓋請按 是 覆蓋資料!!" & vbCrLf &
                        "如要放棄新增資料請按 否!!",
                        "工作頁重複?", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2))

            If (response = DialogResult.No) Then
                Return
            End If
            sheet = workbook.GetSheet(Txt_No.Text) '取得工作頁
            Exit Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "轉Excel 失敗!!")
            Exit Sub
        End Try

        '獲取標題
        sheet.CreateRow(0) '第一行為欄位名稱
        For Cols = 1 To DataGridView1.Columns.Count
            'row.CreateCell(Cols).SetCellValue(DataGridView1.Columns(Cols - 1).HeaderText.ToString)
            sheet.GetRow(0).CreateCell(Cols).SetCellValue(DataGridView1.Columns(Cols - 1).HeaderText.ToString())
        Next

        '往excel表裡添加資料()
        For i = 0 To DataGridView1.RowCount - 1
            sheet.CreateRow(i + 1)
            For j = 0 To DataGridView1.ColumnCount - 1
                If Me.DataGridView1.Rows(i).Cells(j).Value Is System.DBNull.Value Then
                    sheet.GetRow(i + 1).CreateCell(j + 1).SetCellValue("")
                Else
                    Dim String_ As String = DataGridView1.Rows(i).Cells(j).Value.ToString
                    sheet.GetRow(i + 1).CreateCell(j + 1).SetCellValue(String_)
                End If
            Next j
        Next i

        sheet.CreateRow(DataGridView1.RowCount)
        'Aging 統計處理
        '投  入 :
        sheet.GetRow(DataGridView1.RowCount).CreateCell(1).SetCellValue("投入")
        sheet.GetRow(DataGridView1.RowCount).CreateCell(2).SetCellValue(Txt_X1.Text)
        '產  出 :
        sheet.GetRow(DataGridView1.RowCount).CreateCell(3).SetCellValue("產出")
        sheet.GetRow(DataGridView1.RowCount).CreateCell(4).SetCellValue(Txt_X2.Text)
        '不  良 :
        sheet.GetRow(DataGridView1.RowCount).CreateCell(5).SetCellValue("不良")
        sheet.GetRow(DataGridView1.RowCount).CreateCell(6).SetCellValue(Txt_X1.Text - Txt_X2.Text)

        '抽氣不良統計
        Dim iar(,) As String = {{"E01", "E02", "E03", "E04", "E05", "E06", "E07", "E08", "E09", "E10" _
            , "E11", "E12", "E13", "E14", "E15", "E16", "E17", "E18", "E19", "E20" _
            , "E21", "E22", "E23", "E24", "E25", "E26", "E27", "E28", "E29", "E30"},
            {"玻璃管未貼附預型座", "投板斷管", "爐內斷管", "投板位置錯誤", "矯正歪管", "觸碰斷管", "冷凝水過多斷管",
            "冷卻水不足斷管", "不當操作", "觸碰裂板", "密珠漏氣", "密珠裂板", "連帶人為", "S不良(入爐)", "無汞",
            "平浪未封合", "爐內裂板", "機故沖散", "機故裂板", "連帶機故", "偏藍暗紫", "裂板", "抽散", "出爐後斷管",
            "回沖後轉投其他台車", "回沖未轉投", "", "", "氣瓶未開", "台車未啟動"}}
        Dim value_string As String
        Dim Row_line As Integer = DataGridView1.RowCount + 2
        sheet.CreateRow(Row_line)

        Conn.Open()
        For i As Integer = 0 To iar.GetLength(1) - 1
            Dim BSQL_str As String = "SELECT COUNT(*) FROM Aging_D WHERE Aging_No = '" & Txt_No.Text &
                "' AND (Car_status='" & iar(0, i) & "')"
            Dim BSQL_Cmd As New SqlCommand(BSQL_str, Conn)
            Dim BReader As SqlDataReader
            BReader = BSQL_Cmd.ExecuteReader()
            BReader.Read()
            value_string = BReader.Item(0)
            'System.Console.WriteLine(BReader.Item(0))
            sheet.GetRow(Row_line + i).CreateCell(1).SetCellValue(iar(0, i))    '不良原因代號
            sheet.GetRow(Row_line + i).CreateCell(2).SetCellValue(iar(1, i))    '不良原因說明
            sheet.GetRow(Row_line + i).CreateCell(3).SetCellValue(value_string)    '不良原因統計
            sheet.CreateRow(Row_line + i + 1)
            BReader.Close()
        Next

        Dim Line_Array() As String = {"A", "B"}
        Dim Turns_Num_Array() As String = {"01", "02", "03", "04"}
        Dim Aging_no As String = Mid(Txt_No.Text, 1, 7)
        For Each MBT_Line As String In Line_Array '線別
            For Each Turns_Num As String In Turns_Num_Array '圈數

                '(Ω)明細檔
                'Dim MBT_Line As String = "A"    '線別
                'Dim Turns_Num As String = "01"  '圈數
                Dim SELECT_str As String = "Select Aging_No As 工單號, Car_No As 抽氣台車, Aging_No2 As 燈板號碼, "
                SELECT_str &= "Car_No4 As 預注值, Car_No5 As 平衡值, Car_No6 As 線別, Car_No3 As 圈數, "
                SELECT_str &= " Car_No2 As 位置, Car_status As 不良原因, remark As 備註 "
                SELECT_str &= " FROM Aging_D WHERE Aging_No LIKE '" & Aging_no & "%' And Car_No6= '" & MBT_Line
                SELECT_str &= "' And Car_No3='" & Turns_Num & "'"

                Dim myAdapter As New SqlDataAdapter(SELECT_str, Conn)
                Dim myDataSet As New DataSet()
                myAdapter.Fill(myDataSet, "Aging_D")
                'Dim SQLDataTable As New DataTable '
                'SQLDataTable = myDataSet.Tables("Aging_D")

                Dim num As Integer = myDataSet.Tables("Aging_D").Rows.Count - 1
                If num < 0 Then
                    Continue For
                End If
                Dim Primary_Key As Boolean = True
                Try
                    '設定Primary Key
                    myDataSet.Tables("Aging_D").PrimaryKey = New DataColumn() {
                            myDataSet.Tables("Aging_D").Columns("抽氣台車"),
                            myDataSet.Tables("Aging_D").Columns("位置"),
                            myDataSet.Tables("Aging_D").Columns("圈數"),
                            myDataSet.Tables("Aging_D").Columns("預注值"),
                            myDataSet.Tables("Aging_D").Columns("平衡值"),
                            myDataSet.Tables("Aging_D").Columns("線別")}
                Catch ex As Exception
                    Primary_Key = False
                    Exit Try
                End Try

                sheet = workbook.GetSheet(MBT_Line & Mid(Turns_Num, 2)) '取得工作頁
                sheet.GetRow(2).GetCell(22).SetCellValue(DateString)    '日期
                Dim rows As Integer = 4
                Dim cells As Integer = 0
                For i = 0 To num
                    '檢查是否為奇數
                    If (rows And 1) <> 1 Then
                        'rows = rows + 1
                    End If

                    If rows > 22 Then
                        rows = rows - 20
                        cells = cells + 7
                    End If

                    Dim Aging_Num As String = myDataSet.Tables("Aging_D").Rows(0).Item("工單號")
                    Dim Lamp_Num As String = myDataSet.Tables("Aging_D").Rows(0).Item("燈板號碼")
                    Dim Car_No As String = myDataSet.Tables("Aging_D").Rows(0).Item("抽氣台車")
                    Dim Car_No2 As String = RTrim(myDataSet.Tables("Aging_D").Rows(0).Item("位置"))
                    Dim Car_No3 As String = RTrim(myDataSet.Tables("Aging_D").Rows(0).Item("圈數"))
                    Dim Car_No6 As String = RTrim(myDataSet.Tables("Aging_D").Rows(0).Item("線別"))
                    Dim Lamp2_num As String = ""

                    Dim addr, addr_one, addr_two As Integer
                    addr = rows
                    If Car_No6 <> "MR" Then
                        If Car_No2 = "L" Then
                            Car_No2 = "R"
                            addr_one = rows
                            addr_two = rows + 1
                        ElseIf Car_No2 = "R" Then
                            Car_No2 = "L"
                            addr_one = rows + 1
                            addr_two = rows
                        ElseIf Car_No2 = "01" Then
                            Car_No2 = "02"
                            addr_one = rows
                            addr_two = rows + 1
                        Else
                            Car_No2 = "01"
                            addr_one = rows + 1
                            addr_two = rows
                        End If
                    End If

                    sheet.GetRow(addr).GetCell(cells + 0).SetCellValue(Car_No)  '抽氣台車
                    sheet.GetRow(addr_one).GetCell(cells + 1).SetCellValue(Aging_Num) '工單號碼
                    sheet.GetRow(addr_one).GetCell(cells + 2).SetCellValue(Lamp_Num)    '燈板號碼

                    If Not IsDBNull(myDataSet.Tables("Aging_D").Rows(0).Item("不良原因")) Then ' 如果變數內容不是Null就顯示在TextBox
                        Dim CarStatus As String = RTrim(myDataSet.Tables("Aging_D").Rows(0).Item("不良原因"))
                        Dim Remark As String = RTrim(myDataSet.Tables("Aging_D").Rows(0).Item("備註"))
                        If CarStatus = "N" Then
                            sheet.GetRow(addr_one).GetCell(cells + 3).SetCellValue("OK")
                            If Remark <> "" Then
                                CreateCell_Comment(sheet, addr_one, cells, Remark)
                            End If
                        Else
                            sheet.GetRow(addr_one).GetCell(cells + 3).SetCellValue("NG")
                            sheet.GetRow(addr_one).GetCell(cells + 6).SetCellValue(CarStatus)
                            '输入註解信息
                            Dim status_TXT As String = TXT_ToolTip.GetToolTip(Car_status)    '擷取不良原因
                            status_TXT = status_TXT.Substring(InStr(1, status_TXT, CarStatus) + 3)
                            status_TXT = status_TXT.Substring(0, status_TXT.IndexOf(Chr(10)) - 1)

                            CreateCell_Comment(sheet, addr_one, cells, status_TXT)
                        End If
                    End If

                    Dim Car_No4 As String = ""
                    If Not IsDBNull(myDataSet.Tables("Aging_D").Rows(0).Item("預注值")) Then ' 如果變數內容不是Null就顯示在TextBox
                        Car_No4 = RTrim(myDataSet.Tables("Aging_D").Rows(0).Item("預注值"))
                        sheet.GetRow(addr).GetCell(cells + 4).SetCellValue(Car_No4)
                    End If

                    Dim Car_No5 As String = ""
                    If Not IsDBNull(myDataSet.Tables("Aging_D").Rows(0).Item("平衡值")) Then ' 如果變數內容不是Null就顯示在TextBox
                        Car_No5 = RTrim(myDataSet.Tables("Aging_D").Rows(0).Item("平衡值"))
                        sheet.GetRow(addr).GetCell(cells + 5).SetCellValue(Car_No5)
                    End If

                    '刪除
                    myDataSet.Tables("Aging_D").Rows.RemoveAt(0)

                    'Dim DSQL_str As String = "SELECT * FROM Aging_D WHERE Aging_No = '" & Txt_No.Text _
                    '    & "' And Car_No= '" & Car_No & "' And Car_No2='" & Car_No2 _
                    '    & "' And Car_No4='" & Car_No4 & "'" & " And Car_No5='" & Car_No5 _
                    '    & "' And Car_No6= '" & Car_No6 & "' And Car_No3='" & Car_No3 & "'"
                    'Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
                    'Dim DReader As SqlDataReader
                    'DReader = DSQL_Cmd.ExecuteReader()
                    'If (DReader.Read()) Then
                    '   Cmb_Car.Text = RTrim(DReader.Item("Car_No")) '抽氣台車
                    '工單號碼
                    '   sheet.GetRow(addr_two).GetCell(cells + 1).SetCellValue(Txt_No.Text)

                    '燈板號碼
                    '   Lamp2_num = DReader.Item("Aging_No2").ToString
                    '   sheet.GetRow(addr_two).GetCell(cells + 2).SetCellValue(Lamp2_num)

                    '不良原因
                    '       If Not IsDBNull(DReader.Item("Car_status")) Then ' 如果變數內容不是Null就顯示在TextBox
                    '           Dim Car_status As String = RTrim(DReader.Item("Car_status"))
                    '           If Car_status = "N" Then
                    '               sheet.GetRow(addr_two).GetCell(cells + 3).SetCellValue("OK")
                    '            Else
                    '               sheet.GetRow(addr_two).GetCell(cells + 3).SetCellValue("NG")
                    '               sheet.GetRow(addr_two).GetCell(cells + 4).SetCellValue(Car_status)
                    '           End If
                    '       End If
                    'End If
                    'DReader.Close()
                    If Primary_Key <> True Then
                        '找出要修改的資料
                        Dim dr() As DataRow = myDataSet.Tables("Aging_D").Select("抽氣台車='" & Car_No _
                                              & "' and 位置='" & Car_No2 & "' and 圈數='" & Car_No3 _
                                              & "' and 預注值='" & Car_No4 & "' and 平衡值='" & Car_No5 _
                                              & "' and 線別='" & Car_No6 & "'")
                        If dr.Length <> 0 Then
                            '工單號碼
                            Aging_Num = dr(0).Item("工單號").ToString()
                            sheet.GetRow(addr_two).GetCell(cells + 1).SetCellValue(Aging_Num)

                            '燈板號碼
                            Lamp2_num = dr(0).Item("燈板號碼").ToString()
                            sheet.GetRow(addr_two).GetCell(cells + 2).SetCellValue(Lamp2_num)

                            '不良原因
                            If Not IsDBNull(dr(0).Item("不良原因").ToString()) Then ' 如果變數內容不是Null就顯示在TextBox
                                Dim CarStatus As String = RTrim(dr(0).Item("不良原因").ToString())
                                Dim Remark As String = RTrim(dr(0).Item("備註").ToString())
                                If CarStatus = "N" Then
                                    sheet.GetRow(addr_two).GetCell(cells + 3).SetCellValue("OK")
                                    If Remark <> "" Then
                                        CreateCell_Comment(sheet, addr_two, cells, Remark)
                                    End If
                                Else
                                    sheet.GetRow(addr_two).GetCell(cells + 3).SetCellValue("NG")
                                    sheet.GetRow(addr_two).GetCell(cells + 6).SetCellValue(CarStatus)
                                    '输入註解信息
                                    Dim status_TXT As String = TXT_ToolTip.GetToolTip(Car_status)    '擷取不良原因
                                    status_TXT = status_TXT.Substring(InStr(1, status_TXT, CarStatus) + 3)
                                    status_TXT = status_TXT.Substring(0, status_TXT.IndexOf(Chr(10)) - 1)

                                    CreateCell_Comment(sheet, addr_two, cells, status_TXT)

                                End If
                            End If
                            '取得要修改的指標
                            Dim Index As Integer = myDataSet.Tables("Aging_D").Rows.IndexOf(dr(0))
                            '刪除
                            myDataSet.Tables("Aging_D").Rows.RemoveAt(Index)
                        End If

                    Else

                        '找出要修改的資料
                        Dim findTheseVals() As Object = {Car_No, Car_No2, Car_No3, Car_No4, Car_No5, Car_No6}
                        Dim row_data As DataRow = myDataSet.Tables("Aging_D").Rows.Find(findTheseVals)
                        If Not (row_data Is Nothing) Then
                            '工單號碼
                            Aging_Num = row_data("工單號").ToString()
                            sheet.GetRow(addr_two).GetCell(cells + 1).SetCellValue(Aging_Num)

                            '燈板號碼
                            Lamp2_num = row_data("燈板號碼").ToString()
                            sheet.GetRow(addr_two).GetCell(cells + 2).SetCellValue(Lamp2_num)

                            '不良原因
                            If Not IsDBNull(row_data("不良原因").ToString()) Then ' 如果變數內容不是Null就顯示在TextBox
                                Dim CarStatus As String = RTrim(row_data("不良原因").ToString())
                                Dim Remark As String = RTrim(row_data("備註").ToString())
                                If CarStatus = "N" Then
                                    sheet.GetRow(addr_two).GetCell(cells + 3).SetCellValue("OK")
                                    If Remark <> "" Then
                                        CreateCell_Comment(sheet, addr_two, cells, Remark)
                                    End If
                                Else
                                    sheet.GetRow(addr_two).GetCell(cells + 3).SetCellValue("NG")
                                    sheet.GetRow(addr_two).GetCell(cells + 6).SetCellValue(CarStatus)
                                    '输入註解信息
                                    Dim status_TXT As String = TXT_ToolTip.GetToolTip(Car_status)    '擷取不良原因
                                    status_TXT = status_TXT.Substring(InStr(1, status_TXT, CarStatus) + 3)
                                    status_TXT = status_TXT.Substring(0, status_TXT.IndexOf(Chr(10)) - 1)

                                    CreateCell_Comment(sheet, addr_two, cells, status_TXT)

                                End If
                            End If
                            '取得要修改的指標
                            'Dim Index_ As Integer = myDataSet.Tables("Aging_D").Rows.IndexOf(row)
                            '刪除
                            myDataSet.Tables("Aging_D").Rows.Remove(row_data)

                        End If
                    End If

                    'Console.WriteLine(row("燈板號碼").ToString())
                    'Console.WriteLine("First Name is : {0}", row("燈板號碼").ToString)
                    'Console.WriteLine("Next Name is : {0}", row("抽氣台車"))

                    'i = -1  '永遠只跑i=0 (第一筆)
                    rows = rows + 2
                    num = myDataSet.Tables("Aging_D").Rows.Count
                    If num > 0 Then
                        num = num - 1
                        'Continue For '進入下一迴圈
                    Else
                        Exit For
                    End If
                Next

                Conn.Close()
            Next
        Next

        'DataTable = DataGridView1

        'row.CreateCell(0).SetCellValue("Hello")
        'row = sheet.CreateRow(1)
        'row.CreateCell(0).SetCellValue("World!!")

        Try
            Dim SearchChar As Integer = InStr(1, Filename, ".xls", 1)
            Filename = Mid(Filename, 1, SearchChar - 1)
            Dim File_2 As FileStream = New FileStream(Filename & "_" & DateString & ".XLS", FileMode.Create)
            workbook.Write(File_2) '將workbook 更新之後的資料寫至File_2 [與File_1同樣路徑]，覆蓋掉File_1 
            File_1.Close()
            File_1.Dispose()
            File_2.Close()
            File_2.Dispose()
            workbook = Nothing
            sheet = Nothing
            'row = Nothing
            MessageBox.Show("已將資料匯出成Excel", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            'MsgBox("新增資料失敗!!" & vbCrLf & ex.Message)
            File_1.Close()
            File_1.Dispose()
            workbook = Nothing
            sheet = Nothing
            MessageBox.Show(ex.Message, "轉Excel 失敗!!")
            Return
        End Try

    End Sub
    Private Sub CreateCell_Comment(ByVal sheet As HSSFSheet, ByVal addr As Integer, ByVal cells As Integer, ByVal comment_TXT As String)
        '加入註解
        '创建绘图对象  
        Dim patriarch As HSSFPatriarch = DirectCast(sheet.DrawingPatriarch, HSSFPatriarch)
        Dim comment As HSSFComment = Nothing
        If sheet.GetRow(addr).GetCell(cells + 6).CellComment Is Nothing Then
            '前四个参数是坐标点,后四个参数是编辑和显示批注时的大小.  
            comment = patriarch.CreateCellComment(New HSSFClientAnchor(928, 0, 0, 26, 1, 2, 6, 3))
        Else
            For z = 0 To patriarch.Children.Count - 1
                Dim o As [Object] = patriarch.Children(z)
                If o.[GetType]() Is GetType(HSSFComment) Then
                    If o.Column = cells + 6 Then
                        'comment = TryCast(patriarch.Children(i + 1), HSSFComment)
                        comment = patriarch.Children(z)
                        Exit For
                    End If
                End If
            Next
        End If

        '输入註解信息
        comment.String = New HSSFRichTextString(comment_TXT)
        '添加作者, 选中B5单元格, 看状态栏  
        comment.Author = Txt_User.Text
        '将註解添加到单元格对象中
        comment.Row = addr
        comment.Column = cells + 6
    End Sub
    Private Sub TabControl1_CheckedChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If Me.TabControl1.SelectedIndex = 0 Then
            MainForm.BindingNavigator1.BindingSource = BindingSource1
        ElseIf Me.TabControl1.SelectedIndex = 1 Then
            MainForm.BindingNavigator1.BindingSource = BindingSource2
        End If
    End Sub





    Sub DataGridViewColumn_Resize(ByVal DataGridView As DataGridView)
        Try
            System.Console.WriteLine("DataGridViewColumn_Resize")
            Dim DataGridViewRowWidth As Integer = 0
            For i = 0 To DataGridView.ColumnCount - 1
                ' DataGridView.Columns(i).Width = (DataGridView.Width - DataGridView.RowHeadersWidth) / DataGridView.ColumnCount
                DataGridViewRowWidth += DataGridView.Columns(i).Width
            Next

            DataGridViewRowWidth += DataGridView.RowHeadersWidth + 2

            If DataGridView.Width < DataGridViewRowWidth And HScrollBar2.Dock = DockStyle.None Then
                'HScrollBar1.Visible = True
                Me.TableLayoutPanel3.SetRowSpan(Me.DataGridView2, 1)
                Me.TableLayoutPanel3.SetRowSpan(Me.VScrollBar2, 1)
                Me.TableLayoutPanel3.Controls.Add(Me.HScrollBar2, 0, 1)
                HScrollBar2.Maximum = DataGridView2.ColumnCount
                HScrollBar2.Dock = DockStyle.Fill
                HScrollBar2.Width = DataGridView2.Width + 6
            ElseIf DataGridView.Width > DataGridViewRowWidth And HScrollBar2.Dock = DockStyle.Fill Then
                'HScrollBar1.Visible = False
                Me.TableLayoutPanel3.SetRowSpan(Me.DataGridView2, 2)
                Me.TableLayoutPanel3.SetRowSpan(Me.VScrollBar2, 2)
                Me.TabPage3.Controls.Add(Me.HScrollBar2)
                HScrollBar2.Dock = DockStyle.None
            End If
            'System.Console.WriteLine()
            DataGridView2.Height = DataGridView.DisplayedRowCount(False) * DataGridView2.Rows(0).Height + 22

            If DataGridView.RowCount > 0 Then
                VScrollBar2.LargeChange = Fix((DataGridView2.Height - DataGridView2.ColumnHeadersHeight) / (DataGridView2.Rows(0).Height))
                If DataGridView.DisplayedColumnCount(False) > 0 Then
                    HScrollBar2.LargeChange = DataGridView.DisplayedColumnCount(False) - 1
                End If
            End If
        Catch ex As Exception
            SaveLog(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.SizeChanged
        Try
            If sender.ColumnCount > 0 And sender.RowCount > 0 And DataGridView1.AllowUserToAddRows = False Then
                If DataGridView1.DisplayedColumnCount(False) >= DataGridView1.ColumnCount Then
                    TableLayoutPanel5.MinimumSize = New System.Drawing.Size(0, 40)
                    HScrollBar1.Visible = False
                    Me.TableLayoutPanel5.SetRowSpan(Me.VScrollBar1, 2)
                    Me.TableLayoutPanel5.SetRowSpan(Me.DataGridView1, 2)
                Else
                    TableLayoutPanel5.MinimumSize = New System.Drawing.Size(0, 60)
                    Me.TableLayoutPanel5.SetRowSpan(Me.VScrollBar1, 1)
                    Me.TableLayoutPanel5.SetRowSpan(Me.DataGridView1, 1)
                    HScrollBar1.Visible = True
                End If

                Dim DataGridViewDisplayedRowCount As Integer = DataGridView1.DisplayedRowCount(False)
                DataGridView1.Height = DataGridViewDisplayedRowCount * 20 + DataGridView1.ColumnHeadersHeight + 2
            End If
        Catch ex As Exception
            SaveLog(ex.Message)
        End Try

    End Sub
    Sub D1SizeChanged()
        Try
            If (HScrollBar1.Value <> 0 And HScrollBar1.Value <> HScrollBar1.Maximum) Or Key_LR = True Then
                Dim DataGridViewRowWidth As Integer = 0
                Dim DisplayedColumnCount As Integer = DataGridView1.DisplayedColumnCount(False)
                Dim FirstDisplayedCell_ColumnIndex As Integer = 0
                Dim FirstDisplayedScrollingColumnHiddenWidth As Integer = DataGridView1.FirstDisplayedScrollingColumnHiddenWidth
                Dim H As Integer = 0

                If DataGridView1.FirstDisplayedCell IsNot Nothing Then
                    FirstDisplayedCell_ColumnIndex = DataGridView1.FirstDisplayedCell.ColumnIndex
                End If

                If FirstDisplayedCell_ColumnIndex = 0 And Key_LR = True Then
                    HScrollBar1.Value = 0
                    Exit Sub
                ElseIf DataGridView1.CurrentCell IsNot Nothing Then
                    If (DataGridView1.CurrentCell.ColumnIndex = (DataGridView1.ColumnCount - 2)) And Key_LR = True Then
                        HScrollBar1.Value = HScrollBar1.Maximum
                        Exit Sub
                    End If
                End If

                If FirstDisplayedCell_ColumnIndex <> 0 Then
                    For i = (DataGridView1.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView1.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView1.Width - DataGridView1.RowHeadersWidth) Then
                            H = (HScrollBar1.Maximum / (i + 1)) ' * (DisplayedColumnCount - 1)
                            HScrollBar1.Value = H * FirstDisplayedCell_ColumnIndex
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            SaveLog(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView2_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView2.SizeChanged
        Try
            If sender.ColumnCount > 0 And sender.RowCount > 0 And DataGridView2.AllowUserToAddRows = False Then
                If DataGridView2.DisplayedColumnCount(False) >= DataGridView2.ColumnCount Then
                    TableLayoutPanel3.MinimumSize = New System.Drawing.Size(0, 40)
                    HScrollBar2.Visible = False
                    Me.TableLayoutPanel3.SetRowSpan(Me.VScrollBar2, 2)
                    Me.TableLayoutPanel3.SetRowSpan(Me.DataGridView2, 2)
                Else
                    TableLayoutPanel3.MinimumSize = New System.Drawing.Size(0, 60)
                    Me.TableLayoutPanel3.SetRowSpan(Me.VScrollBar2, 1)
                    Me.TableLayoutPanel3.SetRowSpan(Me.DataGridView2, 1)
                    HScrollBar2.Visible = True
                End If

                Dim DataGridViewDisplayedRowCount As Integer = DataGridView2.DisplayedRowCount(False)
                If SizeChangedLock = False Then
                    SizeChangedLock = True
                    If DataGridView2.Height <> dataGridView2SizeChanged Then
                        If (DataGridView2.Height - dataGridView2SizeChanged) < 0 Then
                            DataGridView2.Height = DataGridViewDisplayedRowCount * 20 + DataGridView2.ColumnHeadersHeight + 2
                        Else
                            DataGridView2.Height = (DataGridViewDisplayedRowCount + 1) * 20 + DataGridView2.ColumnHeadersHeight + 2
                        End If
                    End If

                    VScrollBar2.Height = DataGridView2.Height + 6
                    If HScrollBar2.Visible = True Then
                        TableLayoutPanel3.Height = VScrollBar2.Height + HScrollBar2.Height
                    Else
                        TableLayoutPanel3.Height = VScrollBar2.Height
                    End If

                    If Lock = True Then
                        SplitContainer1.SplitterDistance = TableLayoutPanel3.Height
                    End If

                    dataGridView2SizeChanged = DataGridView2.Height
                    HScrollBar2.Location = New System.Drawing.Point(0, VScrollBar2.Height)
                End If
                'FORM 大小變更DataGridView Column 跟著改變大小
                'DataGridViewColumn_Resize(sender)
                D2SizeChanged()
            Else
                SplitContainer1.SplitterDistance = 153
            End If
            DataGridView2.HorizontalScrollingOffset = HScrollBar2AddressMem

        Catch ex As Exception
            SaveLog(ex.Message)
        End Try
    End Sub
    Sub D2SizeChanged()
        Try
            If (HScrollBar2.Value <> 0 And HScrollBar2.Value <> HScrollBar2.Maximum) Or Key_LR = True Then
                Dim DataGridViewRowWidth As Integer = 0
                Dim DisplayedColumnCount As Integer = DataGridView2.DisplayedColumnCount(False)
                Dim FirstDisplayedCell_ColumnIndex As Integer = 0
                Dim FirstDisplayedScrollingColumnHiddenWidth As Integer = DataGridView2.FirstDisplayedScrollingColumnHiddenWidth
                Dim H As Integer = 0

                If DataGridView2.FirstDisplayedCell IsNot Nothing Then
                    FirstDisplayedCell_ColumnIndex = DataGridView2.FirstDisplayedCell.ColumnIndex
                End If

                If FirstDisplayedCell_ColumnIndex = 0 And Key_LR = True Then
                    HScrollBar2.Value = 0
                    Exit Sub
                ElseIf DataGridView2.CurrentCell IsNot Nothing Then
                    If (DataGridView2.CurrentCell.ColumnIndex = (DataGridView2.ColumnCount - 2)) And Key_LR = True Then
                        HScrollBar2.Value = HScrollBar2.Maximum
                        Exit Sub
                    End If
                End If
                If FirstDisplayedCell_ColumnIndex <> 0 Then
                    For i = (DataGridView2.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView2.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView2.Width - DataGridView2.RowHeadersWidth) Then
                            H = (HScrollBar2.Maximum / (i + 1)) ' * (DisplayedColumnCount - 1)
                            HScrollBar2.Value = H * FirstDisplayedCell_ColumnIndex
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            SaveLog(ex.Message)
        End Try
    End Sub
    Private Sub dataGridView3_SizeChanged(sender As Object, e As EventArgs) Handles DataGridView3.SizeChanged
        Try
            'Console.WriteLine(Date.Now & "-----> dataGridView3_SizeChanged")
            'Console.WriteLine(DataGridView3.DisplayedRowCount(False) & "-----> dataGridView3_SizeChanged")
            If sender.ColumnCount > 0 And sender.RowCount > 0 And DataGridView3.AllowUserToAddRows = False Then
                If DataGridView3.DisplayedColumnCount(False) >= DataGridView3.ColumnCount Then
                    HScrollBar3.Visible = False
                    Me.TableLayoutPanel4.SetRowSpan(Me.VScrollBar3, 2)
                    Me.TableLayoutPanel4.SetRowSpan(Me.DataGridView3, 2)

                ElseIf TableLayoutPanel4.Height < 41 Or DataGridView3.Height < 26 Then
                    Me.TableLayoutPanel4.SetRowSpan(Me.DataGridView3, 2)
                    Me.TableLayoutPanel4.SetColumnSpan(Me.DataGridView3, 2)
                    Me.TableLayoutPanel3.Height = SplitContainer1.SplitterDistance
                    VScrollBar3.Visible = False
                    HScrollBar3.Visible = False
                    DataGridView3.Height = 25

                Else
                    If TableLayoutPanel4.Height < 73 Or DataGridView3.Height < 46 Then
                        DataGridView3.Height = 25
                    End If
                    Me.TableLayoutPanel4.SetRowSpan(Me.DataGridView3, 1)
                    Me.TableLayoutPanel4.SetColumnSpan(Me.DataGridView3, 1)
                    Me.TableLayoutPanel4.SetRowSpan(Me.VScrollBar3, 1)
                    VScrollBar3.Visible = True
                    HScrollBar3.Visible = True
                End If

                Dim DataGridViewDisplayedRowCount As Integer = DataGridView3.DisplayedRowCount(False)
                If DataGridViewDisplayedRowCount > 0 And TableLayoutPanel4.Height > 61 Then
                    DataGridView3.Height = DataGridViewDisplayedRowCount * 20 + DataGridView3.ColumnHeadersHeight + 2
                End If
                D3SizeChanged()
            End If
            DataGridView3.HorizontalScrollingOffset = HScrollBar3AddressMem
        Catch ex As Exception
            SaveLog(ex.Message)
        End Try
    End Sub
    Sub D3SizeChanged()
        Try
            If (HScrollBar3.Value <> 0 And HScrollBar3.Value <> HScrollBar3.Maximum) Or Key_LR = True Then
                Dim DataGridViewRowWidth As Integer = 0
                Dim DisplayedColumnCount As Integer = DataGridView3.DisplayedColumnCount(False)
                Dim FirstDisplayedCell_ColumnIndex As Integer = 0
                Dim FirstDisplayedScrollingColumnHiddenWidth As Integer = DataGridView3.FirstDisplayedScrollingColumnHiddenWidth
                Dim H As Integer = 0

                If DataGridView3.FirstDisplayedCell IsNot Nothing Then
                    FirstDisplayedCell_ColumnIndex = DataGridView3.FirstDisplayedCell.ColumnIndex
                End If

                If FirstDisplayedCell_ColumnIndex = 0 And Key_LR = True Then
                    HScrollBar3.Value = 0
                    Exit Sub
                ElseIf DataGridView3.CurrentCell IsNot Nothing Then
                    If (DataGridView3.CurrentCell.ColumnIndex = (DataGridView3.ColumnCount - 2)) And Key_LR = True Then
                        HScrollBar3.Value = HScrollBar3.Maximum
                        Exit Sub
                    End If
                End If

                If FirstDisplayedCell_ColumnIndex <> 0 Then
                    For i = (DataGridView3.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView3.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView3.Width - DataGridView3.RowHeadersWidth) Then
                            H = (HScrollBar3.Maximum / (i + 1)) ' * (DisplayedColumnCount - 1)
                            HScrollBar3.Value = H * FirstDisplayedCell_ColumnIndex
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            SaveLog(ex.Message)
        End Try
    End Sub
    Private Sub dataGridView1_ColumnDividerWidthChanged(sender As Object, e As EventArgs) Handles DataGridView1.ColumnWidthChanged
        DataGridView1_SizeChanged(sender, e)
    End Sub
    Private Sub dataGridView2_ColumnDividerWidthChanged(sender As Object, e As EventArgs) Handles DataGridView2.ColumnWidthChanged
        DataGridView2_SizeChanged(sender, e)
    End Sub
    Private Sub dataGridView3_ColumnDividerWidthChanged(sender As Object, e As EventArgs) Handles DataGridView3.ColumnWidthChanged
        dataGridView3_SizeChanged(sender, e)
    End Sub
    Private Sub tableLayoutPanel3_SizeChanged(sender As Object, e As EventArgs) Handles TableLayoutPanel3.SizeChanged
        tableLayoutPanel_SizeChanged(DataGridView2, VScrollBar2, e)
    End Sub
    Private Sub tableLayoutPanel4_SizeChanged(sender As Object, e As EventArgs) Handles TableLayoutPanel4.SizeChanged
    End Sub
    Private Sub TableLayoutPanel4_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel4.Paint
        'Console.WriteLine(DataGridView3.DisplayedRowCount(False) & "-----> TableLayoutPanel3_Paint")
        If HScrollBar3.Visible = True And (HScrollBar3.Location.Y <> (TableLayoutPanel4.Height - 20)) Then
            HScrollBar3.Location = New System.Drawing.Point(0, TableLayoutPanel4.Height - 20)
            If DataGridView3.Width > (TableLayoutPanel4.Width - VScrollBar3.Width) Then
                DataGridView3.Width = HScrollBar3.Width
            End If
        End If
    End Sub
    Sub tableLayoutPanel_SizeChanged(DataGridView As Object, VScrollBar As Object, e As EventArgs)
        Dim dataGridViewDisplayedColumnCount As Integer = DataGridView.DisplayedColumnCount(False)
        If dataGridViewDisplayedColumnCount >= DataGridView.ColumnCount And ((VScrollBar.Height - DataGridView.Height) >= 6) _
            Or dataGridViewDisplayedColumnCount <= DataGridView.ColumnCount And ((VScrollBar.Height - DataGridView.Height) <= 6) _
            Or Lock = True And dataGridViewDisplayedColumnCount <= DataGridView.ColumnCount And ((DataGridView.Height - VScrollBar.Height) <= 6) Then
            DataGridView2_SizeChanged(DataGridView, e)
        End If
    End Sub
    Private Sub splitContainer1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        SizeChangedLock = False
        VScrollBar2.Height = DataGridView2.Height + 6
        HScrollBar2.Width = DataGridView2.Width + 6
        HScrollBar2.Location = New System.Drawing.Point(0, VScrollBar2.Height)
    End Sub
    Private Sub splitContainer1_SplitterMoving(sender As Object, e As SplitterCancelEventArgs) Handles SplitContainer1.SplitterMoving
        SizeChangedLock = False
    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If DataGridView2.Rows.Count > 0 And DataGridView3.AllowUserToAddRows = False Then
            VScrollBar2.Value = DataGridView2.CurrentCell.RowIndex
            'DataGridView2.FirstDisplayedCell = Me.DataGridView2(FirstDisplayedCell.ColumnIndex, DataGridView2.FirstDisplayedCell.RowIndex)
        End If
    End Sub
    Private Sub DataGridView2_DoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        If DataGridView2.Rows.Count > 0 Then
            TabControl1.SelectedTab = TabControl1.TabPages(0)   '切換到詳細欄位頁
        End If
    End Sub
    Dim MouseWhell As Boolean = False
    Dim Key_LR, Point As Boolean
    Dim FirstDisplayedCell As DataGridViewCell
    Private Sub vScrollBar1_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseWheel
        ' Display the new value in the label.
        Dim Scroll As New ScrollEventArgs(ScrollEventType.EndScroll, VScrollBar1.Value)
        If e.Delta = 120 AndAlso VScrollBar1.Value > 0 Then
            VScrollBar1.Value -= 1
            Scroll.NewValue = VScrollBar1.Value
        ElseIf e.Delta = -120 AndAlso VScrollBar1.Value < DataGridView1.RowCount - 1 Then
            VScrollBar1.Value += 1
            Scroll.NewValue = VScrollBar1.Value
        End If
        'System.Console.WriteLine("VScrollBar Type:(OnMouseWheed Event) " & VScrollBar2.Value)
        MouseWhell = True
        vScrollBar1_Scroll(sender, Scroll)
    End Sub
    Private Sub vScrollBar2_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseWheel
        ' Display the new value in the label.
        Dim Scroll As New ScrollEventArgs(ScrollEventType.EndScroll, VScrollBar2.Value)
        If e.Delta = 120 AndAlso VScrollBar2.Value > 0 Then
            VScrollBar2.Value -= 1
            Scroll.NewValue = VScrollBar2.Value
        ElseIf e.Delta = -120 AndAlso VScrollBar2.Value < DataGridView2.RowCount - 1 Then
            VScrollBar2.Value += 1
            Scroll.NewValue = VScrollBar2.Value
        End If
        'System.Console.WriteLine("VScrollBar Type:(OnMouseWheed Event) " & VScrollBar2.Value)
        MouseWhell = True
        vScrollBar2_Scroll(sender, Scroll)
    End Sub
    Private Sub vScrollBar3_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView3.MouseWheel
        ' Display the new value in the label.
        Dim Scroll As New ScrollEventArgs(ScrollEventType.EndScroll, VScrollBar3.Value, VScrollBar3.Value, ScrollOrientation.VerticalScroll)
        If e.Delta = 120 AndAlso VScrollBar3.Value > 0 Then
            VScrollBar3.Value -= 1
            Scroll.NewValue = VScrollBar3.Value
        ElseIf e.Delta = -120 AndAlso VScrollBar3.Value < DataGridView3.RowCount - 1 Then
            VScrollBar3.Value += 1
            Scroll.NewValue = VScrollBar3.Value
        End If
        'System.Console.WriteLine("VScrollBar Type:(OnMouseWheed Event) " & VScrollBar3.Value)
        MouseWhell = True
        vScrollBar3_Scroll(sender, Scroll)
    End Sub
    Private Sub vScrollBar2_ValueChanged(sender As Object, e As EventArgs) Handles VScrollBar2.ValueChanged
        ' Display the new value in the label.
    End Sub
    Private Sub vScrollBar3_ValueChanged(sender As Object, e As EventArgs) Handles VScrollBar3.ValueChanged
        ' Display the new value in the label.
        'System.Console.WriteLine("VScrollBar Type:(OnScroll Event) " & VScrollBar3.Value)
    End Sub
    Dim HScrollBar1AddressMem, HScrollBar2AddressMem, HScrollBar3AddressMem As Integer
    ' Create the Scroll event handler.
    Private Sub vScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll
        If e.Type = ScrollEventType.EndScroll And DataGridView1.Rows.Count > 0 Then
            If e.NewValue < DataGridView1.RowCount Then
                HScrollBar1AddressMem = DataGridView1.HorizontalScrollingOffset
                DataGridView1.CurrentCell = Me.DataGridView1(DataGridView1.CurrentCell.ColumnIndex, e.NewValue)
                DataGridView1.HorizontalScrollingOffset = HScrollBar1AddressMem
            Else
                e.NewValue = DataGridView1.RowCount - 1
            End If
        End If
    End Sub
    Private Sub vScrollBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar2.Scroll
        'System.Console.WriteLine("VScrollBar Type:(OnScroll Event) " & e.Type.ToString)
        ' Display the new value in the label.
        'Label1.Text = "VScrollBar Value:(OnScroll Event) " & e.NewValue.ToString()
        If e.Type = ScrollEventType.EndScroll And DataGridView2.Rows.Count > 0 Then
            If e.NewValue < DataGridView2.RowCount Then
                HScrollBar2AddressMem = DataGridView2.HorizontalScrollingOffset
                DataGridView2.CurrentCell = Me.DataGridView2(DataGridView2.CurrentCell.ColumnIndex, e.NewValue)
                DataGridView2.HorizontalScrollingOffset = HScrollBar2AddressMem
            Else
                e.NewValue = DataGridView2.RowCount - 1
            End If
            Dim ee As DataGridViewCellEventArgs = Nothing
            dataGridView2_RowLeave(sender, ee)
            'System.Console.WriteLine("VScrollBar Type:(OnScroll Event) " & VScrollBar1.Value)
        End If
    End Sub
    Private Sub vScrollBar3_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar3.Scroll
        If e.Type = ScrollEventType.EndScroll And DataGridView3.Rows.Count > 0 Then
            If e.NewValue < DataGridView3.RowCount Then
                HScrollBar3AddressMem = DataGridView3.HorizontalScrollingOffset
                DataGridView3.CurrentCell = Me.DataGridView3(DataGridView3.CurrentCell.ColumnIndex, e.NewValue)
                DataGridView3.HorizontalScrollingOffset = HScrollBar3AddressMem
            Else
                e.NewValue = DataGridView3.RowCount - 1
            End If
        End If
    End Sub
    Private Sub hScrollBar1_ValueChanged(sender As Object, e As EventArgs) Handles HScrollBar2.ValueChanged

    End Sub
    Dim Next_Cell As Integer = 0
    Dim HscrollBarType As ScrollEventType
    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        If e.Type = ScrollEventType.EndScroll Then
            Dim DataGridViewRowWidth As Integer = 0
            Dim DisplayedColumnCount As Integer = DataGridView1.DisplayedColumnCount(False)
            Dim FirstDisplayedCell_ColumnIndex As Integer = 0
            Dim FirstDisplayedScrollingColumnHiddenWidth As Integer = DataGridView1.FirstDisplayedScrollingColumnHiddenWidth

            If DataGridView1.FirstDisplayedCell IsNot Nothing Then
                FirstDisplayedCell_ColumnIndex = DataGridView1.FirstDisplayedCell.ColumnIndex
            End If

            If HscrollBarType = ScrollEventType.LargeIncrement Then
                If e.NewValue < HScrollBar1.Maximum Then
                    For i = (DataGridView1.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView1.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView1.Width - DataGridView1.RowHeadersWidth) Then
                            e.NewValue += (HScrollBar1.Maximum / (i + 1)) * (DisplayedColumnCount - 1)
                            Next_Cell = FirstDisplayedCell_ColumnIndex + DisplayedColumnCount - 1
                            Exit For
                        End If
                    Next
                End If
            ElseIf HscrollBarType = ScrollEventType.LargeDecrement Then
                If e.NewValue > 0 Then
                    For i = (DataGridView1.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView1.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView1.Width - DataGridView1.RowHeadersWidth) Then
                            e.NewValue -= (HScrollBar1.Maximum / (i + 1)) * (DisplayedColumnCount - 1)
                            If FirstDisplayedCell_ColumnIndex > 0 Then
                                If FirstDisplayedScrollingColumnHiddenWidth <> 0 Then
                                    Next_Cell = (FirstDisplayedCell_ColumnIndex + 2) - DisplayedColumnCount
                                Else
                                    Next_Cell = (FirstDisplayedCell_ColumnIndex + 1) - DisplayedColumnCount
                                End If
                            End If
                            Exit For
                        End If
                    Next
                End If
            ElseIf HscrollBarType = ScrollEventType.SmallIncrement Then
                If e.NewValue < HScrollBar1.Maximum Then
                    For i = (DataGridView1.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView1.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView1.Width - DataGridView1.RowHeadersWidth) Then
                            'e.NewValue += DataGridView1.FirstDisplayedCell.Size.Width
                            e.NewValue += HScrollBar1.Maximum / (i + 1)
                            Next_Cell = DataGridView1.FirstDisplayedCell.ColumnIndex + 1
                            Exit For
                        End If
                    Next
                End If
            ElseIf HscrollBarType = ScrollEventType.SmallDecrement Then
                If e.NewValue > 0 Then
                    For i = (DataGridView1.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView1.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView1.Width - DataGridView1.RowHeadersWidth) Then
                            'e.NewValue -= DataGridView1.FirstDisplayedCell.Size.Width
                            e.NewValue -= HScrollBar1.Maximum / (i + 1)
                            If FirstDisplayedCell_ColumnIndex > 0 Then
                                If FirstDisplayedScrollingColumnHiddenWidth <> 0 Then
                                    Next_Cell = DataGridView1.FirstDisplayedCell.ColumnIndex - 1
                                    DataGridView1.FirstDisplayedCell = Me.DataGridView1(Next_Cell, DataGridView1.FirstDisplayedCell.RowIndex)
                                    Next_Cell = DataGridView1.FirstDisplayedCell.ColumnIndex + 1
                                Else
                                    Next_Cell = DataGridView1.FirstDisplayedCell.ColumnIndex - 1
                                End If
                            End If
                            Exit For
                        End If
                    Next
                End If
            ElseIf HscrollBarType = ScrollEventType.ThumbPosition Then
                For i = (DataGridView1.ColumnCount - 1) To 0 Step -1
                    DataGridViewRowWidth += DataGridView1.Columns(i).Width
                    If DataGridViewRowWidth >= (DataGridView1.Width - DataGridView1.RowHeadersWidth) Then
                        Dim num As Integer = HScrollBar1.Maximum / (i + 1)
                        Next_Cell = e.NewValue / num
                        e.NewValue = Next_Cell * num
                        Exit For
                    End If
                Next
            End If

            If e.NewValue < 0 Then
                e.NewValue = 0
                Next_Cell = 0
            ElseIf e.NewValue > HScrollBar1.Maximum Then
                e.NewValue = HScrollBar1.Maximum
            ElseIf Next_Cell < 0 Then
                Next_Cell = 0
            End If

            If Key_LR = False And DataGridView1.FirstDisplayedCell IsNot Nothing Then
                DataGridView1.FirstDisplayedCell = Me.DataGridView1(Next_Cell, DataGridView1.FirstDisplayedCell.RowIndex)
            End If
            FirstDisplayedCell = DataGridView1.FirstDisplayedCell
            Key_LR = False

        Else
            HscrollBarType = e.Type
        End If
        HScrollBar1AddressMem = DataGridView1.HorizontalScrollingOffset
    End Sub
    Private Sub hScrollBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar2.Scroll
        If e.Type = ScrollEventType.EndScroll Then
            Dim DataGridViewRowWidth As Integer = 0
            Dim DisplayedColumnCount As Integer = DataGridView2.DisplayedColumnCount(False)
            Dim FirstDisplayedCell_ColumnIndex As Integer = 0
            Dim FirstDisplayedScrollingColumnHiddenWidth As Integer = DataGridView2.FirstDisplayedScrollingColumnHiddenWidth

            If DataGridView2.FirstDisplayedCell IsNot Nothing Then
                FirstDisplayedCell_ColumnIndex = DataGridView2.FirstDisplayedCell.ColumnIndex
            End If

            If HscrollBarType = ScrollEventType.LargeIncrement Then
                If e.NewValue < HScrollBar2.Maximum Then
                    For i = (DataGridView2.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView2.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView2.Width - DataGridView2.RowHeadersWidth) Then
                            e.NewValue += (HScrollBar2.Maximum / (i + 1)) * (DisplayedColumnCount - 1)
                            Next_Cell = FirstDisplayedCell_ColumnIndex + DisplayedColumnCount - 1
                            Exit For
                        End If
                    Next
                End If
            ElseIf HscrollBarType = ScrollEventType.LargeDecrement Then
                If e.NewValue > 0 Then
                    For i = (DataGridView2.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView2.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView2.Width - DataGridView2.RowHeadersWidth) Then
                            e.NewValue -= (HScrollBar2.Maximum / (i + 1)) * (DisplayedColumnCount - 1)
                            If FirstDisplayedCell_ColumnIndex > 0 Then
                                If FirstDisplayedScrollingColumnHiddenWidth <> 0 Then
                                    Next_Cell = (FirstDisplayedCell_ColumnIndex + 2) - DisplayedColumnCount
                                Else
                                    Next_Cell = (FirstDisplayedCell_ColumnIndex + 1) - DisplayedColumnCount
                                End If
                            End If
                            Exit For
                        End If
                    Next
                End If
            ElseIf HscrollBarType = ScrollEventType.SmallIncrement Then
                If e.NewValue < HScrollBar2.Maximum Then
                    For i = (DataGridView2.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView2.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView2.Width - DataGridView2.RowHeadersWidth) Then
                            'e.NewValue += DataGridView2.FirstDisplayedCell.Size.Width
                            e.NewValue += HScrollBar2.Maximum / (i + 1)
                            Next_Cell = DataGridView2.FirstDisplayedCell.ColumnIndex + 1
                            Exit For
                        End If
                    Next
                End If
            ElseIf HscrollBarType = ScrollEventType.SmallDecrement Then
                If e.NewValue > 0 Then
                    For i = (DataGridView2.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView2.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView2.Width - DataGridView2.RowHeadersWidth) Then
                            'e.NewValue -= DataGridView2.FirstDisplayedCell.Size.Width
                            e.NewValue -= HScrollBar2.Maximum / (i + 1)
                            If FirstDisplayedCell_ColumnIndex > 0 Then
                                If FirstDisplayedScrollingColumnHiddenWidth <> 0 Then
                                    Next_Cell = DataGridView2.FirstDisplayedCell.ColumnIndex - 1
                                    DataGridView2.FirstDisplayedCell = Me.DataGridView2(Next_Cell, DataGridView2.FirstDisplayedCell.RowIndex)
                                    Next_Cell = DataGridView2.FirstDisplayedCell.ColumnIndex + 1
                                Else
                                    Next_Cell = DataGridView2.FirstDisplayedCell.ColumnIndex - 1
                                End If
                            End If
                            Exit For
                        End If
                    Next
                End If
            ElseIf HscrollBarType = ScrollEventType.ThumbPosition Then
                For i = (DataGridView2.ColumnCount - 1) To 0 Step -1
                    DataGridViewRowWidth += DataGridView2.Columns(i).Width
                    If DataGridViewRowWidth >= (DataGridView2.Width - DataGridView2.RowHeadersWidth) Then
                        Dim num As Integer = HScrollBar2.Maximum / (i + 1)
                        Next_Cell = e.NewValue / num
                        e.NewValue = Next_Cell * num
                        Exit For
                    End If
                Next
            End If

            If e.NewValue < 0 Then
                e.NewValue = 0
                Next_Cell = 0
            ElseIf e.NewValue > HScrollBar2.Maximum Then
                e.NewValue = HScrollBar2.Maximum
            ElseIf Next_Cell < 0 Then
                Next_Cell = 0
            End If

            If Key_LR = False And DataGridView2.FirstDisplayedCell IsNot Nothing Then
                DataGridView2.FirstDisplayedCell = Me.DataGridView2(Next_Cell, DataGridView2.FirstDisplayedCell.RowIndex)
            End If
            FirstDisplayedCell = DataGridView2.FirstDisplayedCell
            Key_LR = False

        Else
            HscrollBarType = e.Type
        End If
        HScrollBar2AddressMem = DataGridView2.HorizontalScrollingOffset
    End Sub
    Private Sub hScrollBar3_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar3.Scroll
        If e.Type = ScrollEventType.EndScroll Then

            Dim DataGridViewRowWidth As Integer = 0
            Dim DisplayedColumnCount As Integer = DataGridView3.DisplayedColumnCount(False)
            Dim FirstDisplayedCell_ColumnIndex As Integer = 0
            Dim FirstDisplayedScrollingColumnHiddenWidth As Integer = DataGridView3.FirstDisplayedScrollingColumnHiddenWidth

            If DataGridView3.FirstDisplayedCell IsNot Nothing Then
                FirstDisplayedCell_ColumnIndex = DataGridView3.FirstDisplayedCell.ColumnIndex
            End If

            If HscrollBarType = ScrollEventType.LargeIncrement Then
                If e.NewValue < HScrollBar3.Maximum Then
                    For i = (DataGridView3.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView3.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView3.Width - DataGridView3.RowHeadersWidth) Then
                            e.NewValue += (HScrollBar3.Maximum / (i + 1)) * (DisplayedColumnCount - 1)
                            Next_Cell = FirstDisplayedCell_ColumnIndex + DisplayedColumnCount - 1
                            Exit For
                        End If
                    Next
                End If
            ElseIf HscrollBarType = ScrollEventType.LargeDecrement Then
                If e.NewValue > 0 Then
                    For i = (DataGridView3.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView3.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView3.Width - DataGridView3.RowHeadersWidth) Then
                            e.NewValue -= (HScrollBar3.Maximum / (i + 1)) * (DisplayedColumnCount - 1)
                            If FirstDisplayedCell_ColumnIndex > 0 Then
                                If FirstDisplayedScrollingColumnHiddenWidth <> 0 Then
                                    Next_Cell = (FirstDisplayedCell_ColumnIndex + 2) - DisplayedColumnCount
                                Else
                                    Next_Cell = (FirstDisplayedCell_ColumnIndex + 1) - DisplayedColumnCount
                                End If
                            End If
                            Exit For
                        End If
                    Next
                End If
            ElseIf HscrollBarType = ScrollEventType.SmallIncrement Then
                If e.NewValue < HScrollBar3.Maximum Then
                    For i = (DataGridView3.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView3.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView3.Width - DataGridView3.RowHeadersWidth) Then
                            'e.NewValue += DataGridView3.FirstDisplayedCell.Size.Width
                            e.NewValue += HScrollBar3.Maximum / (i + 1)
                            Next_Cell = DataGridView3.FirstDisplayedCell.ColumnIndex + 1
                            Dim Scroll As New ScrollEventArgs(e.Type, 0, e.OldValue, e.ScrollOrientation)
                            For s = 0 To DataGridView3.FirstDisplayedCell.ColumnIndex
                                Scroll.NewValue += DataGridView3.Columns(s).Width
                            Next
                            'DataGridView3_Scroll(sender, Scroll)
                            Exit For
                        End If
                    Next
                End If
            ElseIf HscrollBarType = ScrollEventType.SmallDecrement Then
                If e.NewValue > 0 Then
                    For i = (DataGridView3.ColumnCount - 1) To 0 Step -1
                        DataGridViewRowWidth += DataGridView3.Columns(i).Width
                        If DataGridViewRowWidth >= (DataGridView3.Width - DataGridView3.RowHeadersWidth) Then
                            'e.NewValue -= DataGridView3.FirstDisplayedCell.Size.Width
                            e.NewValue -= HScrollBar3.Maximum / (i + 1)
                            If FirstDisplayedCell_ColumnIndex > 0 Then
                                If FirstDisplayedScrollingColumnHiddenWidth <> 0 Then
                                    Next_Cell = DataGridView3.FirstDisplayedCell.ColumnIndex - 1
                                    DataGridView3.FirstDisplayedCell = Me.DataGridView3(Next_Cell, DataGridView3.FirstDisplayedCell.RowIndex)
                                    Next_Cell = DataGridView3.FirstDisplayedCell.ColumnIndex + 1
                                Else
                                    Next_Cell = DataGridView3.FirstDisplayedCell.ColumnIndex - 1
                                End If
                            End If
                            Exit For
                        End If
                    Next
                End If
            ElseIf HscrollBarType = ScrollEventType.ThumbPosition Then
                For i = (DataGridView3.ColumnCount - 1) To 0 Step -1
                    DataGridViewRowWidth += DataGridView3.Columns(i).Width
                    If DataGridViewRowWidth >= (DataGridView3.Width - DataGridView3.RowHeadersWidth) Then
                        Dim num As Integer = HScrollBar3.Maximum / (i + 1)
                        Next_Cell = e.NewValue / num
                        e.NewValue = Next_Cell * num
                        Exit For
                    End If
                Next
            End If

            If e.NewValue < 0 Then
                e.NewValue = 0
                Next_Cell = 0
            ElseIf e.NewValue > HScrollBar3.Maximum Then
                e.NewValue = HScrollBar3.Maximum
            ElseIf Next_Cell < 0 Then
                Next_Cell = 0
            End If

            If Key_LR = False And DataGridView3.FirstDisplayedCell IsNot Nothing Then
                DataGridView3.FirstDisplayedCell = Me.DataGridView3(Next_Cell, DataGridView3.FirstDisplayedCell.RowIndex)
            End If
            'FirstDisplayedCell = DataGridView2.FirstDisplayedCell
            Key_LR = False

        Else
            HscrollBarType = e.Type
        End If
        HScrollBar3AddressMem = DataGridView3.HorizontalScrollingOffset
    End Sub
    Private Sub dataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.CurrentRow Is Nothing Then
            Return
        End If

        If VScrollBar1.Maximum < DataGridView1.CurrentCell.RowIndex Then
            VScrollBar1.Maximum = DataGridView1.RowCount
        End If
        VScrollBar1.Value = DataGridView1.CurrentCell.RowIndex
    End Sub
    Dim Point1 As Boolean
    Private Sub dataGridView1_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.RowLeave
        Console.WriteLine(DataGridView1.DisplayedRowCount(False) & "-----> dataGridView1_RowLeave")
        If DataGridView1.CurrentRow Is Nothing Then
            Return
        End If
        Point1 = True
    End Sub
    Private Sub dataGridView1_Leave(sender As Object, e As EventArgs) Handles DataGridView1.Leave
        Console.WriteLine(DataGridView3.DisplayedRowCount(False) & "-----> dataGridView1_Leave")
        Point1 = False
    End Sub
    Private Sub dataGridView2_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.RowLeave
        Console.WriteLine(DataGridView2.DisplayedRowCount(False) & "-----> dataGridView2_RowLeave")
        If DataGridView2.CurrentRow Is Nothing Then
            Return
        End If
        'TextBox1.Text = DataGridView2.Rows(DataGridView2.CurrentCell.RowIndex).Cells(0).Value.ToString()
        '//////////这里是每一行的某一列对应着你的控件的显示///////////
        '如：textbox1.Text=dataGridView1.CurrentRow.Cell[0].Value.ToString();
        VScrollBar2.Value = DataGridView2.CurrentCell.RowIndex
        FirstDisplayedCell = DataGridView2.FirstDisplayedCell
        Point = True
    End Sub
    Private Sub dataGridView2_Leave(sender As Object, e As EventArgs) Handles DataGridView2.Leave
        Console.WriteLine(DataGridView2.DisplayedRowCount(False) & "-----> dataGridView2_Leave")
        Point = False
    End Sub
    Private Sub dataGridView3_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.RowLeave
        Console.WriteLine(DataGridView3.DisplayedRowCount(False) & "-----> dataGridView3_RowLeave")
        If DataGridView3.CurrentRow Is Nothing Then
            Return
        End If
        'VScrollBar2.Value = DataGridView3.CurrentCell.RowIndex
    End Sub
    Private Sub dataGridView3_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView3.SelectionChanged
        If DataGridView3.CurrentRow Is Nothing Then
            Return
        End If
        VScrollBar3.Value = DataGridView3.CurrentCell.RowIndex
    End Sub
    Private Sub dataGridView1_Paint(sender As Object, e As PaintEventArgs) Handles DataGridView1.Paint
        Console.WriteLine(Date.Now & "-----> DataGridView1.Paint")
        If Point1 = True And (DataGridView2.Rows.Count > 0 And DataGridView1.FirstDisplayedCell IsNot Nothing) Then
            MouseClick_Data()
            Point1 = False
        End If
        Dim DisplayedColumnCount As Integer = DataGridView1.DisplayedColumnCount(False)
        If DataGridView1.Rows.Count > 0 Then
            VScrollBar1.LargeChange = DisplayedColumnCount
            VScrollBar1.Maximum = DataGridView1.RowCount + VScrollBar1.LargeChange - 2

            If DataGridView1.AllowUserToAddRows = False Then
                If VScrollBar1.Value <> DataGridView1.CurrentCell.RowIndex Then
                    VScrollBar1.Value = DataGridView1.CurrentCell.RowIndex
                End If
            End If

            Dim DataGridViewRowWidth As Integer = 0
            For i = 0 To DataGridView1.ColumnCount - 1
                DataGridViewRowWidth += DataGridView1.Columns(i).Width
            Next
            HScrollBar1.Maximum = DataGridViewRowWidth
        End If
    End Sub
    Private Sub dataGridView2_Paint(sender As Object, e As PaintEventArgs) Handles DataGridView2.Paint
        Console.WriteLine(Date.Now & "-----> DataGridView2.Paint")
        If Point = True And (DataGridView2.Rows.Count > 0 And DataGridView2.FirstDisplayedCell IsNot Nothing) Then
            'DataGridView2.FirstDisplayedCell = Me.DataGridView2(HScrollBar1.Value, DataGridView2.FirstDisplayedCell.RowIndex)
            Txt_No.Text = DataGridView2.Rows(DataGridView2.CurrentCell.RowIndex).Cells("工單號碼").Value.ToString()
            Txt_No_Refresh()
            DataGridView1_SizeChanged(DataGridView1, e)
            dataGridView3_SizeChanged(DataGridView3, e)
            Point = False
        End If

        Dim DisplayedColumnCount As Integer = DataGridView2.DisplayedColumnCount(False)
        If DataGridView2.Rows.Count > 0 Then
            VScrollBar2.LargeChange = DisplayedColumnCount
            VScrollBar2.Maximum = DataGridView2.RowCount + VScrollBar2.LargeChange - 2

            Dim DataGridViewRowWidth As Integer = 0
            For i = 0 To DataGridView2.ColumnCount - 1
                DataGridViewRowWidth += DataGridView2.Columns(i).Width
            Next
            HScrollBar2.Maximum = DataGridViewRowWidth
        End If
    End Sub
    Private Sub dataGridView3_Paint(sender As Object, e As PaintEventArgs) Handles DataGridView3.Paint
        Dim DisplayedColumnCount As Integer = DataGridView3.DisplayedColumnCount(False)
        If DataGridView3.Rows.Count > 0 Then
            VScrollBar3.LargeChange = DisplayedColumnCount
            VScrollBar3.Maximum = DataGridView3.RowCount + VScrollBar3.LargeChange - 2

            If DataGridView3.AllowUserToAddRows = False Then
                If VScrollBar3.Value <> DataGridView3.CurrentCell.RowIndex Then
                    VScrollBar3.Value = DataGridView3.CurrentCell.RowIndex
                End If
            End If

            Dim DataGridViewRowWidth As Integer = 0
            For i = 0 To DataGridView3.ColumnCount - 1
                DataGridViewRowWidth += DataGridView3.Columns(i).Width
            Next
            HScrollBar3.Maximum = DataGridViewRowWidth
            'HScrollBar2.Maximum = DataGridView3.ColumnCount - DisplayedColumnCount + HScrollBar2.LargeChange
        End If
    End Sub
    Private Sub DataGridView1_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles DataGridView1.Scroll
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll And e.NewValue < DataGridView1.RowCount Then
            If MouseWhell = False Then
                'VScrollBar3.Value = e.NewValue + VScrollBar2.LargeChange - 1
                If e.NewValue = 0 Then
                    'VScrollBar3.Value = 0
                End If
            End If
            MouseWhell = False
        End If
        D1SizeChanged()
    End Sub
    Private Sub DataGridView2_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles DataGridView2.Scroll
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll And e.NewValue < DataGridView2.RowCount Then
            If MouseWhell = False Then
                'VScrollBar2.Value = e.NewValue + VScrollBar2.LargeChange - 1
                If e.NewValue = 0 Then
                    'VScrollBar2.Value = 0
                End If
                'System.Console.WriteLine("ScrollBar NewValue:(OnScroll Event) " & e.NewValue)
                'System.Console.WriteLine("ScrollBar Value:(OnScroll Event) " & VScrollBar1.Value)
                Dim ee As DataGridViewCellEventArgs = Nothing
                dataGridView2_RowLeave(sender, ee)
            End If
            MouseWhell = False
        End If
        D2SizeChanged()
    End Sub
    Private Sub DataGridView3_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles DataGridView3.Scroll
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll And e.NewValue < DataGridView3.RowCount Then
            If MouseWhell = False Then
                'VScrollBar3.Value = e.NewValue + VScrollBar2.LargeChange - 1
                If e.NewValue = 0 Then
                    'VScrollBar3.Value = 0
                End If
            End If
            MouseWhell = False
        End If
        D3SizeChanged()
    End Sub


    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
            Key_LR = True
        End If

        If e.KeyCode = Keys.Home Then
            HScrollBar1.Value = 0
        End If
        If e.KeyCode = Keys.End Then
            HScrollBar1.Value = HScrollBar1.Maximum
            DataGridView1.FirstDisplayedCell = Me.DataGridView1(DataGridView1.ColumnCount - 1, DataGridView1.FirstDisplayedCell.RowIndex)
        End If
        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.End Then
            If DataGridView1.CurrentCell.ColumnIndex + 1 = DataGridView1.ColumnCount - 1 Then
                Dim DataGridViewRowWidth As Integer = 0
                For i = (DataGridView1.ColumnCount - 1) To 0 Step -1
                    DataGridViewRowWidth += DataGridView1.Columns(i).Width
                    If DataGridViewRowWidth >= (DataGridView1.Width - DataGridView1.RowHeadersWidth) Then
                        DataGridView1.FirstDisplayedCell = Me.DataGridView1(i + 1, DataGridView1.FirstDisplayedCell.RowIndex)
                        HScrollBar1.Value = HScrollBar1.Maximum
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DataGridView1.KeyUp
        Key_LR = False
    End Sub
    Private Sub DataGridView2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DataGridView2.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
            Key_LR = True
        End If

        If e.KeyCode = Keys.Home Then
            HScrollBar2.Value = 0
        End If
        If e.KeyCode = Keys.End Then
            HScrollBar2.Value = HScrollBar2.Maximum
            DataGridView2.FirstDisplayedCell = Me.DataGridView2(DataGridView2.ColumnCount - 1, DataGridView2.FirstDisplayedCell.RowIndex)
        End If
        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.End Then
            If DataGridView2.CurrentCell.ColumnIndex + 1 = DataGridView2.ColumnCount - 1 Then
                Dim DataGridViewRowWidth As Integer = 0
                For i = (DataGridView2.ColumnCount - 1) To 0 Step -1
                    DataGridViewRowWidth += DataGridView2.Columns(i).Width
                    If DataGridViewRowWidth >= (DataGridView2.Width - DataGridView2.RowHeadersWidth) Then
                        DataGridView2.FirstDisplayedCell = Me.DataGridView2(i + 1, DataGridView2.FirstDisplayedCell.RowIndex)
                        HScrollBar2.Value = HScrollBar2.Maximum
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub DataGridView2_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DataGridView2.KeyUp
        Key_LR = False
    End Sub
    Private Sub DataGridView3_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DataGridView3.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
            Key_LR = True
        End If

        If e.KeyCode = Keys.Home Then
            HScrollBar3.Value = 0
        End If
        If e.KeyCode = Keys.End Then
            HScrollBar3.Value = HScrollBar3.Maximum
            DataGridView3.FirstDisplayedCell = Me.DataGridView3(DataGridView3.ColumnCount - 1, DataGridView3.FirstDisplayedCell.RowIndex)
        End If
        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.End Then
            If DataGridView3.CurrentCell.ColumnIndex + 1 = DataGridView3.ColumnCount - 1 Then
                Dim DataGridViewRowWidth As Integer = 0
                For i = (DataGridView3.ColumnCount - 1) To 0 Step -1
                    DataGridViewRowWidth += DataGridView3.Columns(i).Width
                    If DataGridViewRowWidth >= (DataGridView3.Width - DataGridView3.RowHeadersWidth) Then
                        DataGridView3.FirstDisplayedCell = Me.DataGridView3(i + 1, DataGridView3.FirstDisplayedCell.RowIndex)
                        HScrollBar3.Value = HScrollBar3.Maximum
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub DataGridView3_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DataGridView3.KeyUp
        Key_LR = False
    End Sub
    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        MouseClick_Data()
    End Sub
    Sub MouseClick_Data()
        If DataGridView1.AllowUserToAddRows = False And DataGridView3.AllowUserToAddRows = False Then
            '點選欄位成燈碼為空白時填入相關位置
            Dim Index As Integer = DataGridView1.CurrentCell.RowIndex
            If DataGridView1.Rows(Index).Cells("燈板號碼").Value.ToString() <> "" Then
                Select Case MainForm.Aging_Chk
                    Case 1, 2, 3
                        Txt_LAMP_NO.Text = DataGridView1.Rows(Index).Cells("成燈碼").Value.ToString()
                        Txt_No2.Text = DataGridView1.Rows(Index).Cells("燈板號碼").Value.ToString()
                        Txt_D_Date.Text = DataGridView1.Rows(Index).Cells("建立日期").Value.ToString()
                        Cmb_Car.Text = DataGridView1.Rows(Index).Cells("抽氣台車").Value.ToString()
                        Car_Pre_injection.Text = DataGridView1.Rows(Index).Cells("預注值").Value.ToString()
                        Car_balance.Text = DataGridView1.Rows(Index).Cells("平衡值").Value.ToString()
                        Cmb_Car6.Text = DataGridView1.Rows(Index).Cells("線別").Value.ToString()
                        Cmb_Car2.Text = DataGridView1.Rows(Index).Cells("位置").Value.ToString()
                        Cmb_Car3.Text = DataGridView1.Rows(Index).Cells("圈數").Value.ToString()
                        Car_status.Text = DataGridView1.Rows(Index).Cells("不良原因").Value.ToString()
                        Cmb_frame_No.Text = DataGridView1.Rows(Index).Cells("框架編號").Value.ToString()
                        Cmb_Inv_No.Text = DataGridView1.Rows(Index).Cells("Inv編號").Value.ToString()
                        Txt_determine.Text = DataGridView1.Rows(Index).Cells("Aging判定").Value.ToString()
                        Cmb_lv.Text = DataGridView1.Rows(Index).Cells("判定等級").Value.ToString()
                        Txt_remark.Text = DataGridView1.Rows(Index).Cells("備註").Value.ToString()
                        If DataGridView1.Rows(Index).Cells("ID").Value IsNot Nothing Then
                            TXT_ID.Text = DataGridView1.Rows(Index).Cells("ID").Value.ToString()
                        End If

                        Dim Control_Array() As Control = {Car_status, Txt_determine}
                        Dim mem_Array As Object = {Car_status_mem, determine_mem}

                        Dim i As Integer = 0
                        '記憶燈板不良原因及判斷，當修改不良原因或判斷時可以將備註的文字立即修正
                        For Each TXT_Control As Control In Control_Array
                            Dim TEXT_ As String = TXT_ToolTip.GetToolTip(TXT_Control)
                            TEXT_ = TEXT_.Substring(InStr(1, TEXT_, TXT_Control.Text) + 3)
                            TEXT_ = TEXT_.Substring(0, TEXT_.IndexOf(Chr(10)) - 1)

                            mem_Array(i)(0) = TXT_Control.Text
                            mem_Array(i)(1) = TEXT_
                            i = i + 1
                        Next
                        Txt_D_Date.Enabled = False
                    Case 4
                        Assembly_Txt_LAMP_NO.Text = DataGridView1.Rows(Index).Cells("成燈碼").Value.ToString()
                        Assembly_Txt_No2.Text = DataGridView1.Rows(Index).Cells("燈板號碼").Value.ToString()
                        Assembly_Txt_Ballast_NO.Text = DataGridView1.Rows(Index).Cells("安定器號碼").Value.ToString()
                        Assembly_Txt_ampere3.Text = DataGridView1.Rows(Index).Cells("實際功率").Value.ToString()
                End Select
            End If
        End If
    End Sub
    Private Sub DataGridView1_RowStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DataGridView1.RowStateChanged
        Dim NotUse As Boolean = True    '不使用了
        If DataGridView1.AllowUserToAddRows = False And NotUse = False Then
            '點選欄位燈板號碼為不是空白時填入相關位置
            If e.Row.Cells.Count > 1 Then
                If Not (e.Row.Cells.Item(1).Value Is Nothing) Then
                    Select Case MainForm.Aging_Chk
                        Case 1, 2, 3
                            Txt_LAMP_NO.Text = e.Row.Cells.Item("成燈碼").Value.ToString()    '成燈碼
                            Txt_No2.Text = e.Row.Cells.Item("燈板號碼").Value.ToString() '燈板號碼
                            Txt_D_Date.Text = e.Row.Cells.Item("建立日期").Value.ToString() '日期
                            Cmb_Car.Text = e.Row.Cells.Item("抽氣台車").Value.ToString() '抽氣台車
                            Car_Pre_injection.Text = e.Row.Cells.Item("平衡值").Value.ToString() '平衡值
                            Car_balance.Text = e.Row.Cells.Item("平衡值").Value.ToString() '平衡值
                            Cmb_Car2.Text = e.Row.Cells.Item("位置").Value.ToString() ' 位置
                            Cmb_Car6.Text = e.Row.Cells.Item("線別").Value.ToString() '線別
                            Cmb_Car3.Text = e.Row.Cells.Item("圈數").Value.ToString() '圈數
                            Car_status.Text = e.Row.Cells.Item("不良原因").Value.ToString() '不良原因
                            Cmb_frame_No.Text = e.Row.Cells.Item("框架編號").Value.ToString() '框架編號
                            Cmb_Inv_No.Text = e.Row.Cells.Item("Inv編號").Value.ToString() 'Inv編號
                            Txt_determine.Text = e.Row.Cells.Item("Aging判定").Value.ToString() 'Aging判定
                            Txt_watt.Text = e.Row.Cells.Item("功率Watt").Value.ToString() '功率Watt
                            Cmb_lv.Text = e.Row.Cells.Item("判定等級").Value.ToString() '判定等級
                            Txt_remark.Text = e.Row.Cells.Item("備註").Value.ToString() '備註
                            TXT_ID.Text = e.Row.Cells.Item("ID").Value.ToString() 'ID
                            Txt_D_Date.Enabled = False
                        Case 4
                            Assembly_Txt_LAMP_NO.Text = e.Row.Cells.Item("成燈碼").Value.ToString()    '成燈碼
                            Assembly_Txt_No2.Text = e.Row.Cells.Item("燈板號碼").Value.ToString() '燈板號碼
                            Assembly_Txt_Ballast_NO.Text = e.Row.Cells.Item("安定器號碼").Value.ToString() '安定器號碼
                            Assembly_Txt_ampere3.Text = e.Row.Cells.Item("實際功率").Value.ToString() '實際功率
                            'e.Row.Cells.Item(5).Value.ToString() '等級
                            'e.Row.Cells.Item(6).Value.ToString() 'Aging 工單號碼
                    End Select
                End If
            End If
        End If
    End Sub
End Class
