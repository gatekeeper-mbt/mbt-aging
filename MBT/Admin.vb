Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class Admin
    'Dim table1 As DataTable = New DataTable
    Dim editmode, Name_mem, ID_mem As String
    ''----------------------抓config檔的ConnectionString
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()
    Private Sub Admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.WindowState = FormWindowState.Maximized '視窗最大化
        DataGridView1.DataSource = BindingSource1
        ComboBox1.DataSource = BindingSource1
        MainForm.BindingNavigator1.BindingSource = BindingSource1.DataSource
        MainForm.Txt_X2.Text = "/"

        'TODO: 這行程式碼會將資料載入 'MBTDataSet.Users' 資料表。您可以視需要進行移動或移除。
        'Me.UsersTableAdapter.Fill(Me.MBTDataSet.Users)
        'myDBInit()

        'DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1   '使用滑鼠右鍵功能
        'Me.Size = New System.Drawing.Size(715, 190) '重新定義視窗大小
        'DataGridView1.Visible = False
    End Sub
    Private Sub LD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LD.SelectedIndexChanged
        If editmode = "add" Or editmode = "Update" Then
            If LD.Text = "否" Then
                PRQA_CF.Enabled = False
                Aging_LD.Enabled = False
            Else
                PRQA_CF.Enabled = True
                Aging_LD.Enabled = True
            End If
        End If
    End Sub
    Sub Load_SQL()
        Dim myDataSet As DataSet = New DataSet
        Dim myAdapter As SqlDataAdapter

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            '加RTRIM 消除字串後空白
            Dim SELECT_str As String = "select RTRIM(User_ID) As 工號, RTRIM(User_Name) As 姓名, RTRIM(User_pass) As 密碼, "
            SELECT_str &= "LD As 主管, RTRIM(LD_Name) As 上級主管, "
            SELECT_str &= "Aging_LD As 生產主管, Aging As 生產, Aging_Del As 刪除權限, "
            SELECT_str &= "PRQA_CF As 品保主管, PRQA As 品保, PRCS As 客服, "
            SELECT_str &= "Admin As 帳號管理 from Users ORDER BY 工號"

            'Select Case 
            myAdapter = New SqlDataAdapter(SELECT_str, connection)

            '將查詢結果放到記憶體set1上的"Users "表格內
            myAdapter.Fill(myDataSet, "Users")
            'User_ID.DataBindings.Add("Text", set1, "Users.User_ID")    '顯示單一欄位值的資料繫結
            '將記憶體的資料集合存放到視窗畫面上的DataGrid上
            'table1 = myDataSet.Tables("Users")

            BindingSource1.DataSource = myDataSet.Tables("Users")
            ComboBox1.DisplayMember = "姓名"

            '主管姓名
            SELECT_str = "SELECT RTRIM(User_Name) As User_Name FROM Users WHERE LD ='是'"
            myAdapter = New SqlDataAdapter(SELECT_str, connection)
            myAdapter.Fill(myDataSet, "LD_Name")

            LD_Name.DataSource = myDataSet.Tables("LD_Name")
            LD_Name.DisplayMember = "User_Name"

            '總數 :
            Dim ASQL_str As String = "SELECT COUNT(*) FROM Users"
            Dim ASQL_Cmd As New SqlCommand(ASQL_str, connection)
            Dim AReader As SqlDataReader
            AReader = ASQL_Cmd.ExecuteReader()
            AReader.Read()
            MainForm.Txt_X1.Text = "總共" & AReader.Item(0) & " 筆資料"
            AReader.Close()

            '關閉資料庫的連結
            connection.Close()
        End Using
    End Sub

    Function myDBData_Changed(ByVal queryString As String) As Boolean
        Try
            Dim set1 As DataSet = New DataSet
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim cmd As SqlCommand = New SqlCommand(queryString, connection)
                cmd.ExecuteNonQuery()
                '關閉資料庫的連結
                connection.Close()
            End Using
            DataGVOrderBy()
            Return True
        Catch ex As Exception
            MsgBox("修改資料失敗!!" & vbCrLf & ex.Message)
            Return False
        End Try
    End Function
    Private Sub User_ID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles User_ID.KeyPress
        '限制TextBox只能輸入數字
        If (e.KeyChar < "0" Or e.KeyChar > "9") And (e.KeyChar <> vbBack) Then
            e.Handled = True
        End If
        If e.KeyChar = ChrW(8) Then '如果想要能用 backspace 鍵
            Exit Sub
        End If
        ''------------------------------------------------------------------
    End Sub
    Private Sub User_ID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles User_ID.Leave
        If User_ID.Text.Length > 0 And User_ID.Text.Length < 4 Then
            User_ID.Text = String.Format("{0:0000}", Val(User_ID.Text)) '不足四位補0
        End If
    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        OrderByNum()
    End Sub
    Private Sub DataGridView1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        '增加顯示選擇筆數
        If DataGridView1.SelectedRows.Count > 1 Then
            MainForm.Txt_X3.Text = "目前選擇 " & DataGridView1.SelectedRows.Count & " 筆資料"
        Else
            MainForm.Txt_X3.Text = "目前選擇 1 筆資料"
        End If
    End Sub
    Private Sub DataGridView_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.SizeChanged
        'FORM 大小變更DataGridView Column 跟著改變大小
        If DataGridView1.ColumnCount > 0 Then
            DataGridViewColumn_Resize()
        End If
    End Sub
    Sub SQL_add()
        editmode = "add"
        ComboBox1.Text = ""
        User_ID.DataBindings.Clear()
        User_Name.DataBindings.Clear()
        User_pass.DataBindings.Clear()
        Aging.DataBindings.Clear()
        Aging_Del.DataBindings.Clear()
        PRQA.DataBindings.Clear()
        PRQA_CF.DataBindings.Clear()
        PRCS.DataBindings.Clear()
        LD.DataBindings.Clear()
        LD_Name.DataBindings.Clear()
        Aging_LD.DataBindings.Clear()
        management.DataBindings.Clear()

        DataGridView1.ClearSelection()
        DataGridView1.Enabled = False
        ComboBox1.Enabled = False
        tool_Enabled_Init()
        User_ID.Text = ""
        User_Name.Text = ""
        User_pass.Text = ""
        Aging.SelectedIndex = 0
        Aging_Del.SelectedIndex = 0
        PRQA.SelectedIndex = 0
        PRQA_CF.SelectedIndex = 0
        PRCS.SelectedIndex = 0
        Aging_LD.SelectedIndex = 0
        LD_Name.SelectedIndex = 0
        LD.SelectedIndex = 0
        management.SelectedIndex = 0
        User_ID.Focus()
    End Sub
    Sub SQL_edit()
        editmode = "Update"
        DataGridView1.Enabled = False
        ComboBox1.Enabled = False
        tool_Enabled_Init()
        User_Name.Focus()
    End Sub
    Sub SQL_del()
        ID_mem = User_ID.Text
        Name_mem = User_Name.Text
        Dim response As DialogResult
        response = (MessageBox.Show(
                "確定刪除 " & vbCrLf &
                "工號:" & ID_mem & vbCrLf &
                "姓名" & Name_mem & vbCrLf &
                "的帳號?", "Delete row?", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))

        If (response = DialogResult.Yes) Then
            '刪除資料庫內的記錄
            '設定刪除記錄的 SQL語法及資料庫執行指令SqlCommand
            Dim queryString As String = "delete from Users where User_ID= '" & User_ID.Text & "' And User_Name= '" & ComboBox1.Text & "'"
            If myDBData_Changed(queryString) Then
                '顯示成功刪除記錄的訊息()
                MessageBox.Show(
                    "已成功刪除 " & vbCrLf &
                    "工號: " & ID_mem & vbCrLf &
                    "姓名: " & Name_mem & vbCrLf &
                    "的帳號", "成功刪除", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Function IDCheck(ByVal ID As String) As Boolean
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                '單頭資料搜尋Aging.Aging_H
                Dim SQL_str As String = "SELECT * FROM Users WHERE User_ID ='" & ID & "'"
                Dim SQL_Cmd As New SqlCommand(SQL_str, connection)
                Dim Reader As SqlDataReader
                Reader = SQL_Cmd.ExecuteReader()

                If Reader.Read() Then     '判斷檔尾 有資料帶入單頭資料
                    Return True
                Else
                    Return False
                End If
                '關閉資料庫的連結
                connection.Close()
            End Using

        Catch ex As Exception
            MsgBox(vbCrLf & ex.Message)
            Return True
        End Try
    End Function
    Sub SQL_update()
        ID_mem = User_ID.Text
        Name_mem = User_Name.Text
        Dim LD_Name_mem As Integer = LD_Name.SelectedIndex

        If User_Name.Text = "" Then
            MessageBox.Show("姓名不可為空白!!!", "姓名空白", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf User_pass.Text = "" Then
            MessageBox.Show("密碼不可為空白!!!", "密碼空白", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Select Case editmode
            Case "add"   '新增
                If User_ID.Text = "" Then
                    MessageBox.Show("工號不可為空白!!!", "工號空白", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If IDCheck(User_ID.Text) Then
                    MessageBox.Show(
                                    "工號:" & ID_mem & " 重複" & vbCrLf &
                                    "請修改工號", "工號重複", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                '新增記錄到資料庫內
                '設定新增記錄的 SQL語法及資料庫執行指令SqlCommand
                Dim queryString As String = "Insert Into Users(User_ID, User_Name, User_pass, Aging, Aging_Del, PRQA," _
                & "PRQA_CF, PRCS, Aging_LD, Admin, LD, LD_Name)"
                queryString &= "Values('" & User_ID.Text & "','" & User_Name.Text & "','" & User_pass.Text _
                & "','" & Aging.Text & "','" & Aging_Del.Text & "','" & PRQA.Text _
                & "','" & PRQA_CF.Text & "','" & PRCS.Text & "','" & Aging_LD.Text & "','" _
                & management.Text & "','" & _LD.Text & "','" & LD_Name.Text & "')"

                If myDBData_Changed(queryString) Then
                    For i = 0 To (DataGridView1.Rows.Count - 1)
                        If ID_mem = RTrim(DataGridView1.Rows(i).Cells("工號").Value.ToString) Then
                            DataGridView1.CurrentCell = Me.DataGridView1(0, i)      '移動到最後一行
                            Exit For
                        End If
                    Next
                    LD_Name.SelectedIndex = LD_Name_mem
                    '顯示成功新增記錄的訊息()
                    MessageBox.Show(
                        "已成功新增 " & vbCrLf &
                        "工號: " & ID_mem & vbCrLf &
                        "姓名: " & Name_mem & vbCrLf &
                        "的帳號", "成功新增", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Data_Bindings()
            Case "Update"   '更新
                Dim CurrentCell As Integer = DataGridView1.CurrentCell.RowIndex  '取得目前滑鼠所在行數

                '修改資料庫內的記錄
                '設定修改記錄的  SQL語法及資料庫執行指令SqlCommand
                Dim queryString As String =
                    "Update Users set User_ID = '" & User_ID.Text & "', User_Name = '" & User_Name.Text _
                    & "', User_pass = '" & User_pass.Text & "' ,Aging ='" & Aging.Text _
                    & "', Aging_Del ='" & Aging_Del.Text & "', PRQA ='" & PRQA.Text _
                    & "', PRQA_CF ='" & PRQA_CF.Text & "', PRCS ='" & PRCS.Text _
                    & "', Aging_LD ='" & Aging_LD.Text & "', Admin ='" & management.Text _
                    & "', LD ='" & LD.Text & "', LD_Name ='" & LD_Name.Text _
                    & "' where User_ID = '" & User_ID.Text & "'"

                If myDBData_Changed(queryString) Then
                    DataGridView1.CurrentCell = Me.DataGridView1(0, CurrentCell)    '移動到上次選取行數
                    '顯示成功修改記錄的訊息()
                    LD_Name.SelectedIndex = LD_Name_mem
                    MessageBox.Show(
                        "已成功修改 " & vbCrLf &
                        "工號: " & ID_mem & vbCrLf &
                        "姓名: " & Name_mem & vbCrLf &
                        "的帳號", "成功修改", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
        End Select
        editmode = ""
        tool_Enabled_Init()
    End Sub
    Sub cancel()
        If editmode = "add" Then
            Data_Bindings()
        End If
        editmode = ""
        tool_Enabled_Init()
    End Sub
    Sub tool_Enabled_Init()
        Select Case editmode
            Case "add", "Update"
                MainForm.add_ToolStripBut.Enabled = False
                MainForm.edit_ToolStripBut.Enabled = False
                MainForm.del_ToolStripBut.Enabled = False
                MainForm.save_ToolStripBut.Enabled = True
                MainForm.cancel_ToolStripBut.Enabled = True
                User_Name.Enabled = True
                User_pass.Enabled = True
                Aging.Enabled = True
                Aging_Del.Enabled = True
                PRQA.Enabled = True
                PRCS.Enabled = True
                LD_Name.Enabled = True
                LD.Enabled = True
                management.Enabled = True

                If editmode = "add" Then
                    User_ID.Enabled = True
                End If
                If LD.Text = "否" Then
                    PRQA_CF.Enabled = False
                    Aging_LD.Enabled = False
                Else
                    PRQA_CF.Enabled = True
                    Aging_LD.Enabled = True
                End If
                'MainForm.BindingNavigator1.BindingSource = Nothing
                MainForm.BindingNavigatorMoveFirstItem.Enabled = False
                MainForm.BindingNavigatorMovePreviousItem.Enabled = False
                MainForm.BindingNavigatorPositionItem.Enabled = False
                MainForm.BindingNavigatorMoveNextItem.Enabled = False
                MainForm.BindingNavigatorMoveLastItem.Enabled = False

            Case Else
                MainForm.add_ToolStripBut.Enabled = True
                MainForm.edit_ToolStripBut.Enabled = True
                MainForm.del_ToolStripBut.Enabled = True
                MainForm.save_ToolStripBut.Enabled = False
                MainForm.cancel_ToolStripBut.Enabled = False
                User_ID.Enabled = False
                User_Name.Enabled = False
                User_pass.Enabled = False
                Aging.Enabled = False
                Aging_Del.Enabled = False
                PRQA.Enabled = False
                PRQA_CF.Enabled = False
                PRCS.Enabled = False
                Aging_LD.Enabled = False
                LD_Name.Enabled = False
                LD.Enabled = False
                management.Enabled = False
                DataGridView1.Enabled = True
                ComboBox1.Enabled = True
                'MainForm.BindingNavigator1.BindingSource = BindingSource1
                MainForm.BindingNavigatorMoveFirstItem.Enabled = True
                MainForm.BindingNavigatorMovePreviousItem.Enabled = True
                MainForm.BindingNavigatorPositionItem.Enabled = True
                MainForm.BindingNavigatorMoveNextItem.Enabled = True
                MainForm.BindingNavigatorMoveLastItem.Enabled = True
        End Select
    End Sub
    Sub OrderByNum()
        '行首加入數字
        For i = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(i).HeaderCell.Value = String.Format("{0}", i + 1)
        Next
        '行首大小自動調整
        DataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)
    End Sub
    Sub DataGridView_center()
        '欄位置中
        Dim String_Center() As String = {"工號", "姓名", "密碼", "生產", "生產主管", "刪除權限", "品保",
                                         "品保主管", "客服", "帳號管理", "上級主管", "主管"}

        For i As Int32 = 0 To String_Center.GetLength(0) - 1
            DataGridView1.Columns(String_Center(i).ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
    End Sub
    Sub Data_Bindings()
        User_ID.DataBindings.Add("Text", BindingSource1, "工號")
        User_Name.DataBindings.Add("Text", BindingSource1, "姓名")
        User_pass.DataBindings.Add("Text", BindingSource1, "密碼")
        Aging.DataBindings.Add("Text", BindingSource1, "生產")
        Aging_Del.DataBindings.Add("Text", BindingSource1, "刪除權限")
        PRQA.DataBindings.Add("Text", BindingSource1, "品保")
        PRQA_CF.DataBindings.Add("Text", BindingSource1, "品保主管")
        PRCS.DataBindings.Add("Text", BindingSource1, "客服")
        LD.DataBindings.Add("Text", BindingSource1, "主管")
        LD_Name.DataBindings.Add("Text", BindingSource1, "上級主管")
        Aging_LD.DataBindings.Add("Text", BindingSource1, "生產主管")
        management.DataBindings.Add("Text", BindingSource1, "帳號管理")
    End Sub
    Sub DataGridViewColumn_Resize()
        For i = 0 To DataGridView1.ColumnCount - 1
            DataGridView1.Columns(i).Width = (DataGridView1.Width - DataGridView1.RowHeadersWidth) / DataGridView1.ColumnCount
        Next
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
        OrderByNum()
    End Sub
End Class
