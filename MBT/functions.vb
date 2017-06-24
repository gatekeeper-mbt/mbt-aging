Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports NPOI.HSSF.UserModel
Imports NPOI.HPSF
Imports NPOI
Imports NPOI.SS.UserModel
Module functions

    Public Sub SaveLog(ByVal Message As String)
        Dim path As String = Application.StartupPath + "\Log" '指定Log資料夾的路徑與應用程式的路徑相同

        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If
        With My.Application.Log.DefaultFileLogWriter
            .BaseFileName = "Log" '設log的檔名開頭
            .CustomLocation = path    '自訂Log檔的存放路徑
            .AutoFlush = True       'Log檔寫完後自動清除緩衝
            .IncludeHostName = True
            .LogFileCreationSchedule = Logging.LogFileCreationScheduleOption.Daily '設定一天一個檔
            'MsgBox(My.Application.Log.DefaultFileLogWriter.FullLogFileName) 'c:\cwwT-2009-09-25.log

            'My.Application.Log.WriteEntry("TestInfor", TraceEventType.Information, 10) '不會記錄
            'My.Application.Log.WriteEntry("TestError", TraceEventType.Error, 20)
            My.Application.Log.WriteEntry(String.Format("{0} {1}",
                                            Message,      '排程描述
                                            Format(Now, "yyyy-MM-dd HH:mm:ss")
                                            ), TraceEventType.Error, EventLogEntryType.Error)
            'SchStartTime, '開始執行時間
            'SchEndTime    '結束執行時間
        End With

    End Sub

    '範例一，簡單產生Excel檔案的方法
    Private Sub CreateExcelFile()

        '建立Excel 2003檔案
        Dim workbook = New HSSFWorkbook()
        Dim sheet As HSSFSheet = workbook.CreateSheet("Class")
        'Dim row As HSSFRow = sheet.CreateRow(0)

        '建立Excel 2007檔案
        'IWorkbook wb = new XSSFWorkbook();
        'ISheet ws = wb.CreateSheet("Class");

        sheet.CreateRow(0) '第一行為欄位名稱
        sheet.GetRow(0).CreateCell(0).SetCellValue("name")
        sheet.GetRow(0).CreateCell(1).SetCellValue("score")
        sheet.CreateRow(1) '第二行之後為資料
        sheet.GetRow(1).CreateCell(0).SetCellValue("abey")
        sheet.GetRow(1).CreateCell(1).SetCellValue(85)
        sheet.CreateRow(2)
        sheet.GetRow(2).CreateCell(0).SetCellValue("tina")
        sheet.GetRow(2).CreateCell(1).SetCellValue(82)
        sheet.CreateRow(3)
        sheet.GetRow(3).CreateCell(0).SetCellValue("boi")
        sheet.GetRow(3).CreateCell(1).SetCellValue(84)
        sheet.CreateRow(4)
        sheet.GetRow(4).CreateCell(0).SetCellValue("hebe")
        sheet.GetRow(4).CreateCell(1).SetCellValue(86)
        sheet.CreateRow(5)
        sheet.GetRow(5).CreateCell(0).SetCellValue("paul")
        sheet.GetRow(5).CreateCell(1).SetCellValue(82)
        Dim File = New FileStream("test.xls", FileMode.Open) '準備建立一個Excel檔
        workbook.Write(File)
        File.Close()
    End Sub


    '範例二，DataTable轉成Excel檔案的方法
    Private Sub DataTableToExcelFile(ByVal DataGridView)

        '建立Excel 2003檔案
        Dim workbook = New HSSFWorkbook()
        Dim sheet As HSSFSheet

        '建立Excel 2007檔案
        'IWorkbook wb = new XSSFWorkbook();
        'ISheet ws;

        If (DataGridView.TableName <> String.Empty) Then
            sheet = workbook.CreateSheet(DataGridView.TableName)
        Else
            sheet = workbook.CreateSheet("Sheet1")
        End If

        sheet.CreateRow(0) '第一行為欄位名稱
        For i = 0 To (DataGridView.Columns.Count)
            'sheet.GetRow(0).CreateCell(i).SetCellValue(DataTable.Columns(i - 1).HeaderText)
            sheet.GetRow(0).CreateCell(i).SetCellValue(DataGridView.Columns(i).ColumnName.ToString())
        Next

        For i = 0 To (DataGridView.Rows.Count)
            sheet.CreateRow(i + 1)
            For j = 0 To (DataGridView.Columns.Count)
                sheet.GetRow(i + 1).CreateCell(j).SetCellValue(DataGridView.Rows(i, j).ToString())
            Next j
        Next i

        Dim File = New FileStream("test.xls", FileMode.Create) '產生檔案
        workbook.Write(File)
        File.Close()
    End Sub
    Private Sub buttonTest_Click(sender As Object, e As EventArgs)  '利用NPOI在同一个Excel文件中创建多个sheet
        Dim workBook As New HSSFWorkbook()
        'ISheet sheetA = workBook.CreateSheet("sheetA");
        'ISheet sheetB = workBook.CreateSheet("sheetB");

        createSheet(workBook, "SheetA")
        createSheet(workBook, "SheetB")
        createSheet(workBook, "SheetC")

        Dim path As String = Application.StartupPath + "\test.xls"
        If File.Exists(path) Then
            File.Delete(path)
        End If
        Using file__1 As New FileStream(path, FileMode.Create)
            workBook.Write(file__1)
            '创建Excel文件。
            file__1.Close()
        End Using
        MessageBox.Show("OK")
    End Sub

    Private Function createSheet(workBook As HSSFWorkbook, sheetName As String) As HSSFSheet
        Dim sheet As HSSFSheet = workBook.CreateSheet(sheetName)
        Dim RowHead As HSSFRow = sheet.CreateRow(0)

        For iColumnIndex As Integer = 0 To 9
            RowHead.CreateCell(iColumnIndex).SetCellValue(System.Guid.NewGuid().ToString())
        Next

        For iRowIndex As Integer = 0 To 19
            Dim RowBody As HSSFRow = sheet.CreateRow(iRowIndex + 1)
            For iColumnIndex As Integer = 0 To 9
                RowBody.CreateCell(iColumnIndex).SetCellValue(DateTime.Now.Millisecond)
                sheet.AutoSizeColumn(iColumnIndex)
            Next
        Next
        Return sheet
    End Function
    Private Sub Button1_Click()
        '建立路徑
        Dim dir1 As String = Directory.GetCurrentDirectory '取得程式所在之路徑
        Dim nodes() As String = Split(dir1, "\") '拆解原始字串
        Dim dir2 As String = ""
        For i As Integer = 0 To nodes.Count - 4 '重組成新字串
            dir2 += nodes(i) & "\"
        Next
        'Label1.Text = dir2

        '依[yyyy-MM-dd]產生檔名
        Dim yyyy, MM, dd As String
        Dim sheetname, filename, filepath, imagename, imagepath As String
        yyyy = String.Format(Today.Year, "0000")
        MM = String.Format(Today.Month, "00")
        dd = String.Format(Today.Day, "00")
        filename = yyyy & "-" & MM & "-" & dd
        filepath = dir2 & Trim(MM) & "月.xls"
        'Label2.Text = filepath
        imagename = filename & "_ChartImage"
        imagepath = dir2 & imagename & ".png"
        sheetname = MM & dd

        If File.Exists(filepath) Then
            '如果檔案已存在
            Dim fs1 As FileStream = New FileStream(filepath, FileMode.Open)
            Dim book1 As HSSFWorkbook = New HSSFWorkbook(fs1) '先讓book1吃舊資料 
            Try
                book1.CreateSheet(sheetname) ' book1內再添加一筆新sheet
            Catch ex As Exception
                Exit Try
            End Try

            Dim fs2 As FileStream = New FileStream(filepath, FileMode.Open)
            book1.Write(fs2) '將book1更新之後的資料寫至fs2[與fs1同樣路徑]，覆蓋掉fs1
            book1 = Nothing
            fs1.Close()
            fs1.Dispose()
            fs2.Close()
            fs2.Dispose()
        Else
            '如果檔案未建立，則創建新的工作表
            Dim fs3 As FileStream = New FileStream(filepath, FileMode.Create)
            Dim book3 As HSSFWorkbook = New HSSFWorkbook()
            book3.CreateSheet("sheet1")
            book3.CreateSheet("sheet2")
            book3.CreateSheet("sheet3")
            book3.Write(fs3)
            book3 = Nothing
            fs3.Close()
            fs3.Dispose()
        End If
    End Sub
    Private Sub Button2_Click()


        'Region載入模板文件到工作簿對象中
        '創建工作簿對象
        Dim workbook As HSSFWorkbook = New HSSFWorkbook() '先讓workbook 吃舊資料

        '打開模板文件到文件流中
        Using FileStreamfile = New FileStream(Directory.GetCurrentDirectory + "template/book1.xls", FileMode.Open, FileAccess.Read)
            '將文件流中模板載入到工作簿對象中
            workbook = New HSSFWorkbook(FileStreamfile)
        End Using
        'End Region
        'Region根據模板設置工作表的內容
        '建立一個名為Sheet1的工作表
        Dim sheet1 As HSSFSheet = workbook.GetSheet("Sheet1")
        '將數據添加到表中對應的單元格中，因為行已經創建，不需要重新創建行
        sheet1.GetRow(1).GetCell(1).SetCellValue(200200)
        sheet1.GetRow(2).GetCell(1).SetCellValue(300)
        sheet1.GetRow(3).GetCell(1).SetCellValue(500050)
        sheet1.GetRow(4).GetCell(1).SetCellValue(8000)
        sheet1.GetRow(5).GetCell(1).SetCellValue(110)
        sheet1.GetRow(6).GetCell(1).SetCellValue(100)
        sheet1.GetRow(7).GetCell(1).SetCellValue(200)
        sheet1.GetRow(8).GetCell(1).SetCellValue(210)
        sheet1.GetRow(9).GetCell(1).SetCellValue(2300)
        sheet1.GetRow(10).GetCell(1).SetCellValue(240)
        sheet1.GetRow(11).GetCell(1).SetCellValue(180123)
        sheet1.GetRow(12).GetCell(1).SetCellValue(150)
        '強制Excel重新計算表中所有的公式
        sheet1.ForceFormulaRecalculation = True
        'End Region
    End Sub
    Function MyMax(ParamArray s()) As Integer '最大值
        Dim i As Integer
        MyMax = s(0)
        For i = 0 To UBound(s)
            If IsNumeric(s(i)) Then MyMax = IIf(s(i) > MyMax, s(i), MyMax)
        Next
    End Function
    Function MyMin(ParamArray s()) As Integer '最小值
        Dim i As Integer
        MyMin = s(0)
        For i = 0 To UBound(s)
            If IsNumeric(s(i)) Then MyMin = IIf(s(i) < MyMin, s(i), MyMin)
        Next
    End Function
    Private Sub UpdateFormlua(ByVal wb As IWorkbook, ByVal s As ISheet, ByVal LastCell As Integer)
        '重新計算公式結果
        For j = 4 To s.LastRowNum
            Dim r As IRow = s.GetRow(j)
            Dim c As ICell
            Dim eval As HSSFFormulaEvaluator
            eval = New HSSFFormulaEvaluator(wb)
            For i = r.FirstCellNum To LastCell
                c = r.GetCell(i)
                If Not (c Is Nothing) Then
                    If c.CellType = CellType.Formula Then
                        eval.EvaluateFormulaCell(c)
                    End If
                End If
            Next
        Next
    End Sub
    Private Sub updateFormula(wb As IWorkbook, s As ISheet, row As Integer)
        ' Dim eval As New HSSFFormulaEvaluator(DirectCast(wb, HSSFWorkbook))
        Dim r As IRow = s.GetRow(row)
        Dim c As ICell = Nothing
        Dim eval As HSSFFormulaEvaluator = Nothing

        eval = New HSSFFormulaEvaluator(DirectCast(wb, HSSFWorkbook))

        For i As Integer = r.FirstCellNum() To r.LastCellNum() - 1
            c = r.GetCell(i)
            If c.CellType() = CellType.Formula Then
                eval.EvaluateFormulaCell(c)
            End If
        Next
    End Sub

End Module
