Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports NPOI
Imports NPOI.HPSF
Imports NPOI.HSSF.UserModel
Imports NPOI.POIFS.FileSystem
Imports NPOI.SS.UserModel
Imports NPOI.XSSF.UserModel
Imports System.Threading
Imports System.ComponentModel

Public Class EX_Report
    ''----------------------抓config檔的ConnectionString
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()
    Dim Conn As SqlConnection = New SqlConnection(connectionString)
    Dim XLS_FilePath As String
    Dim SelectedIndex As Integer
    Dim Filename As String
    Dim File_1 As FileStream = Nothing
    Dim workbook As HSSFWorkbook = Nothing
    Dim sheet As HSSFSheet = Nothing
    Dim bad_tab(,) As String
    Dim X1, X2, X3, SearchDataSQL As String
    Private Sub EX_Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.WindowState = FormWindowState.Maximized '視窗最大化
        MainForm.export_ToolStripBut.Enabled = True

        '不良原因
        Dim SELECT_str As String = "SELECT bad, RTRIM(bad_N) AS bad_N FROM bad ORDER BY bad ASC"
        Dim myAdapter As New SqlDataAdapter(SELECT_str, Conn)
        Dim myDataSet As New DataSet()
        Dim Bad_DataTable As System.Data.DataTable '不良原因
        myAdapter.Fill(myDataSet, "bad")
        Bad_DataTable = myDataSet.Tables("bad")

        '不良原因
        Dim Bad_data_num As Integer = Bad_DataTable.Rows.Count - 1
        ReDim bad_tab(1, Bad_data_num - 1)  '重新設定陣列大小

        For i = 1 To Bad_data_num
            bad_tab(0, i - 1) = Bad_DataTable.Rows(i)("bad").ToString
            bad_tab(1, i - 1) = Bad_DataTable.Rows(i)("bad_N").ToString
        Next

        '操作員名字
        MainForm.Txt_User.Text = " 操作者: " & Login.ALL_UserN
    End Sub
    Sub SQLData(sender As String)
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

        Conn.Open()
        Try
            Dim myAdapter As New SqlDataAdapter(sender, Conn)
            Dim myDataSet As New DataSet()
            myAdapter.Fill(myDataSet, "Aging_D")

            Dim Init_DGV As Boolean
            If DataGridView1.RowCount < 1 Then
                Init_DGV = True
            End If

            DataGridView1.DataSource = myDataSet.Tables("Aging_D")

            '排序
            If oldColumn IsNot Nothing Then
                DataGridView1.Sort(DataGridView1.Columns(DGVSortedColumn), direction)
            End If

            '行首加入數字
            OrderByNum()

            If Init_DGV = True Then
                DataGridView_Init()
            End If

            'Aging 統計處理-------------------------------------------------------------------------------
            Dim ASQL_str As String = ""
            Dim BSQL_str As String = ""
            Dim CSQL_str As String = ""
            SearchDataSQL = SearchData.SQLStr

            If SearchDataSQL.IndexOf("ORDER BY") > -1 Then
                SearchDataSQL = SearchDataSQL.Remove(SearchDataSQL.IndexOf("ORDER BY"))
            End If

            ASQL_str = "SELECT SUM (Aging_X1) FROM Aging_H " & SearchDataSQL
            BSQL_str = "SELECT SUM (Aging_X2) FROM Aging_H " & SearchDataSQL
            CSQL_str = "SELECT SUM (Aging_X3) FROM Aging_H " & SearchDataSQL

            '投  入 :
            Dim SQL_Cmd As New SqlCommand(ASQL_str, Conn)
            Dim Reader As SqlDataReader
            Reader = SQL_Cmd.ExecuteReader()
            Reader.Read()
            X1 = "投 入 : " & Reader.Item(0)
            MainForm.Txt_X1.Text = X1
            Reader.Close()

            '產  出 :
            SQL_Cmd.CommandText = BSQL_str
            Reader = SQL_Cmd.ExecuteReader()
            Reader.Read()
            X2 = "產 出 : " & Reader.Item(0)
            MainForm.Txt_X2.Text = X2
            Reader.Close()

            '不  良 :
            'X3 = "不 良 : " & Mid(MainForm.Txt_X1.Text, 6) - Mid(MainForm.Txt_X2.Text, 6)
            SQL_Cmd.CommandText = CSQL_str
            Reader = SQL_Cmd.ExecuteReader()
            Reader.Read()
            X3 = "不 良 : " & Reader.Item(0)
            MainForm.Txt_X3.Text = X3
            Reader.Close()
        Catch ex As Exception
            MsgBox("讀取資料失敗!!" & vbCrLf & ex.Message)
        End Try
        Conn.Close()
    End Sub
    Sub DataGridView_Init()
        'DataGridView1.AllowUserToResizeColumns = False '禁止使用者更動欄位大小
        DataGridView1.Columns("工單號碼").Width = 100
        DataGridView1.Columns("建立人員").Width = 90
        DataGridView1.Columns("修改人員").Width = 90
        DataGridView1.Columns("建立日期").Width = 140
        DataGridView1.Columns("修改日期").Width = 140
        '數字欄位置中
        Dim String_Center() As String = {"工單號碼", "燈板號碼", "抽氣台車", "預注值", "平衡值", "位置", "線別", "圈數", "不良原因"}
        For i As Int32 = 0 To String_Center.GetLength(0) - 1
            DataGridView1.Columns(String_Center(i)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        DataGridViewColumn_Resize()
    End Sub
    Sub OrderByNum()
        '行首加入數字
        For i = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(i).HeaderCell.Value = String.Format("{0}", i + 1)
        Next
        '行首大小自動調整
        DataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)
    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        OrderByNum()
    End Sub
    Private Sub DataGridView_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.SizeChanged
        'FORM 大小變更DataGridView Column 跟著改變大小
        If DataGridView1.ColumnCount > 0 Then
            DataGridViewColumn_Resize()
        End If
    End Sub
    Sub DataGridViewColumn_Resize()
        For i = 0 To DataGridView1.ColumnCount - 1
            DataGridView1.Columns(i).Width = (DataGridView1.Width - DataGridView1.RowHeadersWidth) / DataGridView1.ColumnCount
        Next
    End Sub
    Sub ExPort_XLS()
        If bw.IsBusy Then
            MessageBox.Show("系統執行中")
        Else
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

            XLS_FilePath = OpenFileDialog1.FileName '選擇的完整路徑

            Filename = XLS_FilePath '選擇的完整路徑

            'Dim row As HSSFRow = sheet.CreateRow(0)
            Try
                File_1 = New FileStream(Filename, FileMode.Open) '準備開啟Excel檔
                workbook = New HSSFWorkbook(File_1) '先讓workbook 吃舊資料
                sheet = workbook.CreateSheet("工單") '建立工作頁
            Catch ex As IOException
                MessageBox.Show(ex.Message, "轉Excel 失敗!!")
                Exit Sub
            Catch ex As Exception
                MessageBox.Show(ex.Message, "轉Excel 失敗!!")
                Exit Sub
            End Try
            MainForm.ProgressBar.Visible = True
            MainForm.Progress_TXT.Visible = True
            MainForm.lblMsg.Visible = True
            MainForm.ProgressBar.Value = 0
            bw.RunWorkerAsync()  '起始背景執行的呼叫
        End If
    End Sub
    Sub ExPort_XLS(ByVal worker As System.ComponentModel.BackgroundWorker, ByVal e As DoWorkEventArgs)
        'Dim row As HSSFRow = sheet.CreateRow(0)

        sheet.CreateRow(0) '第一行為欄位名稱
        '獲取標題
        For Cols = 1 To DataGridView1.Columns.Count
            sheet.GetRow(0).CreateCell(Cols).SetCellValue(DataGridView1.Columns(Cols - 1).HeaderText.ToString())
        Next
        worker.ReportProgress(3)  ' 回報完成率

        '往excel表裡添加資料()
        For i = 0 To DataGridView1.RowCount - 1
            sheet.CreateRow(i + 1)
            For j = 0 To DataGridView1.ColumnCount - 1
                If Me.DataGridView1(j, i).Value Is System.DBNull.Value Then
                    sheet.GetRow(i + 1).CreateCell(j + 1).SetCellValue("")
                Else
                    Dim String_ As String = DataGridView1(j, i).Value.ToString
                    sheet.GetRow(i + 1).CreateCell(j + 1).SetCellValue(String_)
                End If
            Next j
        Next i
        'sheet.SetColumnWidth(1, 13 * 256) '設定欄寬
        'sheet.SetColumnWidth(2, 17 * 256) '設定欄寬
        'sheet.SetColumnWidth(4, 16 * 256) '設定欄寬
        'sheet.AutoSizeColumn(0) ' 调整第一列宽度 
        'sheet.AutoSizeColumn(1) ' 调整第二列宽度 
        'sheet.AutoSizeColumn(2) ' 调整第三列宽度 
        'sheet.AutoSizeColumn(3) ' 调整第四列宽度 
        'sheet.AutoSizeColumn(4) ' 调整第五列宽度 
        'sheet.AutoSizeColumn(12) ' 调整第六列宽度 
        For Cols = 1 To DataGridView1.Columns.Count
            sheet.AutoSizeColumn(Cols) ' 调整欄寬 
        Next
        worker.ReportProgress(12)  ' 回報完成率

        Dim Row_line As Integer = DataGridView1.RowCount + 1

        'Aging 統計處理-------------------------------------------------------------------------------
        sheet.CreateRow(Row_line)
        '投  入 :
        sheet.GetRow(Row_line).CreateCell(1).SetCellValue(X1)
        '產  出 :
        sheet.GetRow(Row_line).CreateCell(2).SetCellValue(X2)
        '不  良 :
        sheet.GetRow(Row_line).CreateCell(3).SetCellValue(X3)

        '抽氣不良統計
        'Dim iar(,) As String = {{"E01", "E02", "E03", "E04", "E05", "E06", "E07", "E08", "E09", "E10" _
        '    , "E11", "E12", "E13", "E14", "E15", "E16", "E17", "E18", "E19", "E20" _
        '    , "E21", "E22", "E23"},
        '    {"矯正斷管 ", "人為斷管", "人為裂板", "冷凝水過多", "冷卻水不足", "不當操作沖抽散", "連帶人為",
        '    "S不良(入爐)", "無汞", "氣瓶未開", "台車未啟動", "機故沖抽散", "機故裂板", "機故斷管", "連帶機故",
        '    "偏藍暗紫", "裂板", "抽散", "斷管", "第三爐警報", "密珠漏氣", "密珠裂板", "連帶製程"}}
        Dim value_string As String
        Row_line = Row_line + 2
        sheet.CreateRow(Row_line)

        Conn.Open()
        For i As Integer = 0 To bad_tab.GetLength(1) - 1
            Dim SQL_str As String = ""
            SQL_str = "SELECT COUNT(*) FROM Aging_D " & SearchDataSQL & " AND (Car_status='" & bad_tab(0, i) & "')"

            Dim SQL_Cmd As New SqlCommand(SQL_str, Conn)
            Dim Reader As SqlDataReader
            Reader = SQL_Cmd.ExecuteReader()
            Reader.Read()
            value_string = Reader.Item(0)
            'System.Console.WriteLine(BReader.Item(0))
            sheet.GetRow(Row_line + i).CreateCell(1).SetCellValue(bad_tab(0, i))    '不良原因代號
            sheet.GetRow(Row_line + i).CreateCell(2).SetCellValue(bad_tab(1, i))    '不良原因說明
            sheet.GetRow(Row_line + i).CreateCell(3).SetCellValue(value_string)    '不良原因統計
            sheet.CreateRow(Row_line + i + 1)
            Reader.Close()
        Next
        worker.ReportProgress(15)  ' 回報完成率
        'Dim numberToCompute As Integer = 75
        Dim Progress As Integer = 15

        Dim Line_Array() As String = {"A", "B"}
        Dim Turns_Num_Array() As String = {"01", "02", "03", "04"}
        For Each MBT_Line As String In Line_Array '線別
            For Each Turns_Num As String In Turns_Num_Array '圈數
                Progress = Progress + 9
                'numberToCompute = CInt((Progress / numberToCompute) * 75)
                worker.ReportProgress(Progress)  ' 回報完成率

                'Dim MBT_Line As String = "A"    '線別
                'Dim Turns_Num As String = "01"  '圈數
                Dim SQL_str As String = "Select RTRIM(Aging_No) As 工單號碼,Car_No As 抽氣台車,  RTRIM(Aging_No2) As 燈板號碼, "
                SQL_str &= "RTRIM(Car_No4) As 預注值, RTRIM(Car_No5) As 平衡值,RTRIM(Car_No6) As 線別, "
                SQL_str &= "Car_No3 As 圈數, RTRIM(Car_No2) As 位置,  RTRIM(Car_status) As 不良原因, RTRIM(remark) As 備註 "
                SQL_str &= "FROM Aging_D " & SearchDataSQL
                SQL_str &= " And Car_No6= '" & MBT_Line & "' And Car_No3='" & Turns_Num & "'"

                Dim myAdapter As New SqlDataAdapter(SQL_str, Conn)
                Dim myDataSet As New DataSet()
                myAdapter.Fill(myDataSet, "Aging_D")

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
                Dim rows As Integer = 4 '開始行數
                Dim Startrows As Integer = 4 '每頁開始行數
                Dim cells As Integer = 0 '開始列數
                Dim page As Integer = 1 '頁數
                Try
                    For i = 0 To num
                        '檢查是否為奇數
                        If (rows And 1) <> 1 Then
                            'rows = rows + 1
                        End If

                        If rows > ((Startrows - 2) + 20) Then  '最大22行，rows 每次加2
                            rows = rows - 20
                            cells = cells + 7
                            If cells > 27 Then  '超過第27列跳到下一頁
                                page += 1
                                cells = 0
                                rows = (Startrows + 20 + 11) * (page - 1)   '+20為本頁可寫入行數，+11為本頁最後一行到下一頁開頭行數
                                Startrows = rows
                            End If
                        End If

                        Dim Aging_Num As String = myDataSet.Tables("Aging_D").Rows(0).Item("工單號碼")
                        Dim Lamp_Num As String = myDataSet.Tables("Aging_D").Rows(0).Item("燈板號碼")
                        Dim Car_No As String = myDataSet.Tables("Aging_D").Rows(0).Item("抽氣台車")
                        Dim Car_No2 As String = RTrim(myDataSet.Tables("Aging_D").Rows(0).Item("位置"))
                        Dim Car_No3 As String = RTrim(myDataSet.Tables("Aging_D").Rows(0).Item("圈數"))
                        Dim Car_No6 As String = RTrim(myDataSet.Tables("Aging_D").Rows(0).Item("線別"))
                        Dim Lamp2_num As String = ""
                        Console.WriteLine("({4}{5}) 線別圈數 :({0},{1}) / {2}{3}", cells, rows, Car_No6, Car_No3, MBT_Line, Turns_Num)

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
                                'Dim status_TXT As String = TXT_ToolTip.GetToolTip(Car_status)    '擷取不良原因
                                'status_TXT = status_TXT.Substring(InStr(1, status_TXT, CarStatus) + 3)
                                'status_TXT = status_TXT.Substring(0, status_TXT.IndexOf(Chr(10)) - 1)
                                'CreateCell_Comment(sheet, addr_one, cells, status_TXT)
                                For z As Integer = 0 To bad_tab.GetLength(1) - 1
                                    If bad_tab(0, z) = CarStatus Then
                                        CreateCell_Comment(sheet, addr_one, cells, bad_tab(1, z))
                                        Exit For
                                    End If
                                Next
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
                                Aging_Num = dr(0).Item("工單號碼").ToString()
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
                                        'Dim status_TXT As String = TXT_ToolTip.GetToolTip(Car_status)    '擷取不良原因
                                        'status_TXT = status_TXT.Substring(InStr(1, status_TXT, CarStatus) + 3)
                                        'status_TXT = status_TXT.Substring(0, status_TXT.IndexOf(Chr(10)) - 1)
                                        'CreateCell_Comment(sheet, addr_two, cells, status_TXT)
                                        For z As Integer = 0 To bad_tab.GetLength(1) - 1
                                            If bad_tab(0, z) = CarStatus Then
                                                CreateCell_Comment(sheet, addr_two, cells, bad_tab(1, z))
                                                Exit For
                                            End If
                                        Next
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
                                Aging_Num = row_data("工單號碼").ToString()
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
                                        'Dim status_TXT As String = TXT_ToolTip.GetToolTip(Car_status)    '擷取不良原因
                                        'status_TXT = status_TXT.Substring(InStr(1, status_TXT, CarStatus) + 3)
                                        'status_TXT = status_TXT.Substring(0, status_TXT.IndexOf(Chr(10)) - 1)
                                        'CreateCell_Comment(sheet, addr_two, cells, status_TXT)
                                        For z As Integer = 0 To bad_tab.GetLength(1) - 1
                                            If bad_tab(0, z) = CarStatus Then
                                                CreateCell_Comment(sheet, addr_two, cells, bad_tab(1, z))
                                                Exit For
                                            End If
                                        Next
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
                    'UpdateFormlua(workbook, sheet, 33)  '重新計算公式結果
                    sheet.ForceFormulaRecalculation = True '強制計算公式
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
        Next
        Conn.Close()

        worker.ReportProgress(100)  ' 回報完成率
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
        comment.Author = MainForm.Txt_User.Text
        '将註解添加到单元格对象中
        comment.Row = addr
        comment.Column = cells + 6
    End Sub
    Private Sub UpdateFormlua(ByVal wb As IWorkbook, ByVal s As ISheet, ByVal LastCell As Integer)
        For j = 24 To 25
            Dim eval As New HSSFFormulaEvaluator(DirectCast(wb, HSSFWorkbook))
            eval.EvaluateFormulaCell(s.GetRow(j).GetCell(5))
        Next

        For j = 4 To s.LastRowNum
            Dim eval As New HSSFFormulaEvaluator(DirectCast(wb, HSSFWorkbook))
            eval.EvaluateFormulaCell(s.GetRow(j).GetCell(33))
        Next
    End Sub
    Private Sub bw_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw.DoWork
        Dim worker As System.ComponentModel.BackgroundWorker = CType(sender, System.ComponentModel.BackgroundWorker)
        ExPort_XLS(worker, e)
        'todo_work(worker, e)
    End Sub
    Private Sub todo_work(ByVal worker As System.ComponentModel.BackgroundWorker, ByVal e As DoWorkEventArgs)
        Dim numberToCompute As Integer = 100
        If worker.CancellationPending Then
            e.Cancel = True
        Else
            For k = 1 To numberToCompute
                Dim percentComplete = CInt((k / numberToCompute) * 100)
                worker.ReportProgress(percentComplete)  ' 回報完成率
            Next
        End If
    End Sub
    '處理進度
    Private Sub bw_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bw.ProgressChanged
        MainForm.ProgressBar.Value = e.ProgressPercentage
        MainForm.lblMsg.Text = e.ProgressPercentage.ToString() & " %"
    End Sub
    '執行完成
    Private Sub bw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted

        If (e.Cancelled = True) Then
            'Me.lblMsg.Text = "取消!"

        ElseIf Not (e.[Error] Is Nothing) Then
            'Me.lblMsg.Text = ("Error: " & e.[Error].Message)
            MessageBox.Show("Error: " & e.[Error].Message, "轉Excel 失敗!!")
        Else

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
                MessageBox.Show("已將資料匯出成Excel", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                File_1.Close()
                File_1.Dispose()
                workbook = Nothing
                sheet = Nothing
                MessageBox.Show(ex.Message, "轉Excel 失敗!!")
                Return
            End Try
            MainForm.ProgressBar.Visible = False
            MainForm.Progress_TXT.Visible = False
            MainForm.lblMsg.Visible = False
            MainForm.ProgressBar.Value = 0
        End If
    End Sub
    Private Sub btnFinish_Click(sender As Object, e As EventArgs)
        If bw.WorkerSupportsCancellation = True Then
            bw.CancelAsync()
        End If
    End Sub
End Class