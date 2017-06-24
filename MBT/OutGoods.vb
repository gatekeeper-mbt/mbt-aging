Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports NPOI
Imports NPOI.HPSF
Imports NPOI.HSSF.UserModel
Imports NPOI.POIFS.FileSystem
Public Class OutGoods
    ''----------------------抓config檔的ConnectionString
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()
    Dim Conn As SqlConnection = New SqlConnection(connectionString)
    Dim CurrentPageIndex As Integer = 1 '現在選取的分頁編號
    Dim TotalPage As Integer = 0 '總共多少分頁
    Dim PageSize As Integer = 100
    Dim PageSizeMem As Integer = 100
    Dim TxtMem, dateMem, dateMem2, X1 As String
    Private Sub OutGoods_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.WindowState = FormWindowState.Maximized '視窗最大化
        MainForm.export_ToolStripBut.Enabled = True
        DPGB.Visible = False
        DateTime1.Value = DateTime.Now.AddYears(-1) '取得前一年
        '操作員名字
        MainForm.Txt_User.Text = " 操作者: " & Login.ALL_UserN
        SQL_Cb.SelectedIndex = 0
        Txt_1.Focus()
    End Sub
    Private Sub SQL_Cb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SQL_Cb.SelectedIndexChanged
        If SQL_Cb.SelectedIndex = 0 Or SQL_Cb.SelectedIndex = 1 Then
            'Txt_1.Text = ""
            Txt_1.Focus()
            Txt_1.SelectAll()
            DPGB.Visible = False
            Txt_1.Visible = True
            'DPGB.Location = New System.Drawing.Point(213, 23)
            Me.TableLayoutPanel1.Controls.Add(Me.Txt_1, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.DPGB, 2, 1)
        ElseIf SQL_Cb.SelectedIndex = 2 Then
            'Txt_1.Text = ""
            Txt_1.Focus()
            Txt_1.SelectAll()
            DPGB.Visible = True
            Txt_1.Visible = False
            'DPGB.Location = New System.Drawing.Point(107, 23)
            Me.TableLayoutPanel1.Controls.Add(Me.Txt_1, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.DPGB, 1, 1)
        End If
        TxtMem = ""
        dateMem = ""
        dateMem2 = ""
    End Sub
    Private Sub Txt_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_1.KeyPress
        '檢查是否按下Enter
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            CurrentPageIndex = 1
            SQLRead()
        End If
    End Sub
    Private Sub Txt_1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_1.Leave
        'SQL_TXT()
    End Sub
    Private Sub DateTime2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTime2.KeyPress
        '檢查是否按下Enter
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            CurrentPageIndex = 1
            SQLRead()
        End If
    End Sub
    Private Sub DateTime2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTime2.Leave
        'SQL_DateTime()
    End Sub
    Private Sub SQL_TXT(ByVal page As Integer)
        '加RTRIM 消除字串後空白
        Dim SQL_str As String = "Select TOP " & PageSize & " RTRIM(Aging_No) As 工單號碼, RTRIM(LAMPS_NO) As 成燈碼, RTRIM(Aging_No2) As 燈板號碼, "
        SQL_str &= "RTRIM(Ballast_NO) as 安定器號碼, RTRIM(ampere3) as 實際功率值, Aging_D_Date As 日期, "
        SQL_str &= "Car_No As 抽氣台車, RTRIM(Car_No4) As 預注值, RTRIM(Car_No5) As 平衡值, RTRIM(Car_No2) As 位置, "
        SQL_str &= "RTRIM(Car_No6) As 線別, Car_No3 As 圈數, RTRIM(Car_status) As 不良原因, frame_No As 框架編號, Inv_No As Inv編號, "
        SQL_str &= "determine As Aging判定, watt As 功率Watt, lv As 判定等級, RTRIM(remark) As 備註, "
        SQL_str &= "SYS_Date As 系統日期, SYS_UID As 系統操作者,ID FROM (Select TOP (SELECT COUNT(*) FROM Aging_D "

        Dim ASQL_str As String = ""
        Dim PreviousPageOffSet As Integer = (page - 1) * PageSize

        Select Case SQL_Cb.SelectedIndex
            Case 0
                If Txt_1.Text = "" Then Exit Sub
                SQL_str &= "WHERE Aging_No LIKE '" & Txt_1.Text & "%') * FROM Aging_D "
                SQL_str &= "WHERE Aging_No LIKE '" & Txt_1.Text & "%' ORDER BY Aging_No ASC) tmp "
                SQL_str &= "WHERE ID Not In (Select TOP " & PreviousPageOffSet & " ID FROM Aging_D "
                SQL_str &= "WHERE Aging_No Like '" & Txt_1.Text & "%' ORDER BY Aging_No ASC)"

                ASQL_str = "SELECT COUNT(*) FROM Aging_D WHERE Aging_No LIKE '" & Txt_1.Text & "% '"
            Case 1
                If Txt_1.Text = "" Then Exit Sub
                SQL_str &= "WHERE LAMPS_NO LIKE '" & Txt_1.Text & "%') * FROM Aging_D "
                SQL_str &= "WHERE LAMPS_NO LIKE '" & Txt_1.Text & "%' ORDER BY LAMPS_NO ASC) tmp "
                SQL_str &= "WHERE ID Not IN (Select TOP " & PreviousPageOffSet & " ID FROM Aging_D "
                SQL_str &= "WHERE LAMPS_NO LIKE '" & Txt_1.Text & "%' ORDER BY LAMPS_NO ASC)"

                ASQL_str = "SELECT COUNT(*) FROM Aging_D WHERE LAMPS_NO LIKE '" & Txt_1.Text & "% '"
            Case 2
                SQL_str &= "WHERE Aging_D_Date BETWEEN '" & DateTime1.Text & "%' And '" & DateTime2.Text & "%') * FROM Aging_D "
                SQL_str &= "WHERE Aging_D_Date BETWEEN '" & DateTime1.Text & "%' And '" & DateTime2.Text & "%' ORDER BY ID ASC) tmp "
                SQL_str &= "WHERE ID Not IN (Select TOP " & PreviousPageOffSet & " ID FROM Aging_D "
                SQL_str &= "WHERE Aging_D_Date BETWEEN '" & DateTime1.Text & "%' And '" & DateTime2.Text & "%' ORDER BY ID ASC)"

                ASQL_str = "SELECT COUNT(*) FROM Aging_D WHERE Aging_D_Date BETWEEN '" & DateTime1.Text & "%' And '" & DateTime2.Text & "% '"
        End Select

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
            Dim ASQL_Cmd As New SqlCommand(ASQL_str, Conn)
            Dim AReader As SqlDataReader
            AReader = ASQL_Cmd.ExecuteReader()
            If AReader.Read() Then     '判斷檔尾 有資料帶入單頭資料
                'Aging 統計處理-------------------------------------------------------------------------------
                '投  入 :
                Dim RowCount As Integer = AReader.Item(0)
                X1 = "總 數 : " & RowCount
                MainForm.Txt_X1.Text = X1
                AReader.Close()

                Dim myAdapter As New SqlDataAdapter(SQL_str, Conn)
                Dim myDataSet As New DataSet()
                myAdapter.Fill(myDataSet, "Aging_D")

                CalculateTotalPages(RowCount) '計算分頁數
                lbTotalPage.Text = "共 " & TotalPage & " 頁"
                lbCurrentPage.Text = "第 " & CurrentPageIndex & " 頁"

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
            Else
                DataGridView1.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox("畫面更新失敗!!" & vbCrLf & ex.Message)
        End Try
        Conn.Close()
    End Sub
    Sub SQLRead()
        If Txt_1.Text <> TxtMem Or (DateTime1.Text <> dateMem OrElse DateTime2.Text <> dateMem2) Then
            SQL_TXT(CurrentPageIndex)
            TxtMem = Txt_1.Text
            dateMem = DateTime1.Text
            dateMem2 = DateTime2.Text
        End If
    End Sub
    Sub DataGridView_Init()
        DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells) '欄位自動調整大小 

        DataGridView1.Columns("燈板號碼").Width = 60
        DataGridView1.Columns("抽氣台車").Width = 60
        DataGridView1.Columns("不良原因").Width = 60
        DataGridView1.Columns("框架編號").Width = 60
        DataGridView1.Columns("預注值").Width = 60
        DataGridView1.Columns("平衡值").Width = 60
        DataGridView1.Columns("位置").Width = 40
        DataGridView1.Columns("線別").Width = 40
        DataGridView1.Columns("圈數").Width = 40
        DataGridView1.Columns("Inv編號").Width = 55
        DataGridView1.Columns("Aging判定").Width = 45
        DataGridView1.Columns("功率Watt").Width = 50
        DataGridView1.Columns("判定等級").Width = 60
        DataGridView1.AllowUserToResizeColumns = False '禁止使用者更動欄位大小

        '數字欄位置中
        Dim String_Center() As String = {"工單號碼", "成燈碼", "燈板號碼", "抽氣台車", "預注值", "平衡值", "位置",
                                          "圈數", "框架編號", "Inv編號", "功率Watt", "系統操作者", "實際功率值"}
        For i As Int32 = 0 To String_Center.GetLength(0) - 1
            DataGridView1.Columns(String_Center(i)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        OrderByNum()
    End Sub
    Sub OrderByNum()
        '行首加入數字
        Dim RowIndex As Integer
        If CurrentPageIndex > 1 Then
            RowIndex = (CurrentPageIndex - 1) * PageSize + 1
        Else
            RowIndex = 1
        End If
        For i = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(i).HeaderCell.Value = String.Format("{0}", i + RowIndex)
        Next
        '行首大小自動調整
        DataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)
    End Sub
    Sub ExPort_XLS()
        If DataGridView1.RowCount < 1 Then
            MessageBox.Show("無資料可匯出成Excel", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        With SaveFileDialog1
            .Filter = "Excel file(*.xls)|*.xls"
            .Title = "請選擇Excel檔"
        End With

        '開啟對話框
        If (SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.Cancel) Then
            ' 使用者沒有選檔案
            Return
        End If
        Dim workbook As HSSFWorkbook = Nothing
        Dim sheet As HSSFSheet = Nothing
        'Dim row As HSSFRow = sheet.CreateRow(0)
        Dim sheetName As String = ""
        Try
            workbook = New HSSFWorkbook() '

            If SQL_Cb.SelectedIndex = 0 Or SQL_Cb.SelectedIndex = 1 Then
                sheetName = Txt_1.Text '建立工作頁
            ElseIf SQL_Cb.SelectedIndex = 2 Then
                sheetName = DateTime1.Text & " ~ " & DateTime2.Text '建立工作頁
            End If
            sheet = workbook.CreateSheet(sheetName) '建立工作頁

        Catch ex As IOException
            MessageBox.Show(ex.Message, "轉Excel 失敗!!")
            Exit Sub
        Catch ex As ArgumentException
            '已有相同工作頁
            Dim response As DialogResult
            response = (MessageBox.Show(
                        "該工作頁: [" & sheetName & " ] 已存在, " & vbCrLf &
                        "如要覆蓋請按 是 覆蓋資料!!" & vbCrLf &
                        "如要放棄新增資料請按 否!!",
                        "工作頁重複?", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2))

            If (response = DialogResult.No) Then
                Return
            End If
            sheet = workbook.GetSheet(Txt_1.Text) '取得工作頁
            Exit Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "轉Excel 失敗!!")
            Exit Sub
        End Try
        Dim SQL_str As String = "Select RTRIM(Aging_No) As 工單號碼, RTRIM(LAMPS_NO) As 成燈碼, RTRIM(Aging_No2) As 燈板號碼, "
        SQL_str &= "RTRIM(Ballast_NO) as 安定器號碼, RTRIM(ampere3) as 實際功率值, Aging_D_Date As 日期, "
        SQL_str &= "Car_No As 抽氣台車, RTRIM(Car_No4) As 預注值, RTRIM(Car_No5) As 平衡值, RTRIM(Car_No2) As 位置, "
        SQL_str &= "RTRIM(Car_No6) As 線別, Car_No3 As 圈數, RTRIM(Car_status) As 不良原因, frame_No As 框架編號, "
        SQL_str &= "Inv_No As Inv編號, determine As Aging判定, watt As 功率Watt, lv As 判定等級, RTRIM(remark) As 備註, "
        SQL_str &= "SYS_Date As 系統日期, SYS_UID As 系統操作者 FROM Aging_D "

        Select Case SQL_Cb.SelectedIndex
            Case 0
                SQL_str &= "WHERE Aging_No LIKE '" & Txt_1.Text & "%' ORDER BY 工單號碼 ASC"
            Case 1
                SQL_str &= "WHERE LAMPS_NO Like '" & Txt_1.Text & "%' ORDER BY 成燈碼 ASC"
            Case 2
                SQL_str &= "WHERE Aging_D_Date BETWEEN '" & DateTime1.Text & "%' And '" & DateTime2.Text & "%' ORDER BY 日期 ASC"
        End Select

        Dim myAdapter As New SqlDataAdapter(SQL_str, Conn)
        Dim myDataSet As New DataSet()
        Dim ColumnsCount As Integer
        Dim RowsCount As Integer

        Try
            Conn.Open()
            myAdapter.Fill(myDataSet, "Aging_D")
            ColumnsCount = myDataSet.Tables("Aging_D").Columns.Count
            RowsCount = myDataSet.Tables("Aging_D").Rows.Count
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "轉Excel 失敗!!")
            Return
        End Try

        '獲取標題
        sheet.CreateRow(0) '第一行為欄位名稱
        For Cols = 1 To ColumnsCount
            'row.CreateCell(Cols).SetCellValue(DataGridView1.Columns(Cols - 1).HeaderText.ToString)
            sheet.GetRow(0).CreateCell(Cols).SetCellValue(myDataSet.Tables("Aging_D").Columns(Cols - 1).ColumnName.ToString())
        Next
        MainForm.Progress_TXT.Visible = True
        MainForm.ProgressBar.Visible = True

        My.Application.DoEvents()
        '往excel表裡添加資料()
        For i = 0 To RowsCount - 1
            sheet.CreateRow(i + 1)
            For j = 0 To ColumnsCount - 1
                'If myDataSet.Tables("Aging_D").Rows(i).Item(j).ToString Is System.DBNull.Value Then
                'sheet.GetRow(i + 1).CreateCell(j + 1).SetCellValue("")
                'Else
                'Dim String_ As String = DataGridView1(j, i).Value.ToString
                Dim String_ As String = myDataSet.Tables("Aging_D").Rows(i).Item(j).ToString()
                sheet.GetRow(i + 1).CreateCell(j + 1).SetCellValue(String_)
                'End If
            Next j
            MainForm.ProgressBar.Value = CInt((i / (RowsCount - 1)) * 100)
            My.Application.DoEvents()
        Next i

        MainForm.ProgressBar.Value = 100
        'sheet.SetColumnWidth(1, 13 * 256) '設定欄寬
        sheet.SetColumnWidth(2, 17 * 256) '設定欄寬
        'sheet.SetColumnWidth(4, 16 * 256) '設定欄寬
        'sheet.AutoSizeColumn(0) ' 调整第一列宽度 
        sheet.AutoSizeColumn(1) ' 调整第二列宽度 
        'sheet.AutoSizeColumn(2) ' 调整第三列宽度 
        sheet.AutoSizeColumn(4) ' 调整第五列宽度 
        sheet.AutoSizeColumn(6) ' 调整第七列宽度 
        sheet.AutoSizeColumn(20) ' 调整第21列宽度 

        'Aging 統計處理-------------------------------------------------------------------------------
        '投  入 :
        sheet.CreateRow(RowsCount + 1).CreateCell(1).SetCellValue(X1)
        Dim File_1 As FileStream = Nothing

        Try
            Dim Filename As String = SaveFileDialog1.FileName '選擇的完整路徑
            'Dim SearchChar As Integer = InStr(1, Filename, ".xls", 1)
            File_1 = New FileStream(Filename, FileMode.Create) '準備開啟Excel檔
            'Filename = Mid(Filename, 1, SearchChar - 1)
            'Dim File_2 As FileStream = New FileStream(Filename & "_" & DateString & ".XLS", FileMode.Create)
            workbook.Write(File_1) '將workbook 更新之後的資料寫至File_2 [與File_1同樣路徑]，覆蓋掉File_1 
            File_1.Close()
            File_1.Dispose()
            'File_2.Close()
            'File_2.Dispose()
            workbook = Nothing
            sheet = Nothing
            'row = Nothing
            MessageBox.Show("已將資料匯出成Excel", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MainForm.ProgressBar.Visible = False
            MainForm.Progress_TXT.Visible = False
            MainForm.ProgressBar.Value = 0
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
    Private Sub Btn_Enter_Click(sender As Object, e As EventArgs) Handles Btn_Enter.Click
        CurrentPageIndex = 1
        SQLRead()
    End Sub
    Private Sub btnPrvPage_Click(sender As Object, e As EventArgs) Handles btnPrvPage.Click
        If CurrentPageIndex > 1 Then
            CurrentPageIndex -= 1
            SQL_TXT(CurrentPageIndex)
        End If
    End Sub
    Private Sub btnNxtPage_Click(sender As Object, e As EventArgs) Handles btnNxtPage.Click
        If CurrentPageIndex < TotalPage Then
            CurrentPageIndex += 1
            SQL_TXT(CurrentPageIndex)
        End If
    End Sub
    Private Sub btnFirstPage_Click(sender As Object, e As EventArgs) Handles btnFirstPage.Click
        If CurrentPageIndex > 1 Then
            CurrentPageIndex = 1
            SQL_TXT(CurrentPageIndex)
        End If
    End Sub

    Private Sub btnLastPage_Click(sender As Object, e As EventArgs) Handles btnLastPage.Click
        If TotalPage > 0 And CurrentPageIndex <> TotalPage Then
            CurrentPageIndex = TotalPage
            SQL_TXT(CurrentPageIndex)
        End If
    End Sub
    Private Sub SetPageSize_Click(sender As Object, e As EventArgs) Handles SetPageSize.Click
        If PageSizeMem <> NumUpDown.Value Then
            PageSize = NumUpDown.Value
            CurrentPageIndex = 1
            SQL_TXT(CurrentPageIndex)
            PageSizeMem = PageSize
        End If
    End Sub
    '計算頁數
    Sub CalculateTotalPages(ByRef dt As Integer)
        Dim rowCount As Integer = dt
        TotalPage = CInt(Int(rowCount / PageSize))

        '不足一個分頁行數的還是算一頁
        If (rowCount Mod PageSize > 0) Then
            TotalPage += 1
        End If
    End Sub
End Class