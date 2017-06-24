Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class management
    Dim queryString, editmode As String
    ''----------------------抓config檔的ConnectionString
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()
    Dim Conn As SqlConnection = New SqlConnection(connectionString)
    Private Sub Admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.WindowState = FormWindowState.Maximized '視窗最大化
        Type.Text = ""
        'TXT_Type.Enabled = False
        'TXT_Name.Enabled = False

        'DataGridView1.AutoResizeColumns()
        'DataGridView1.AllowUserToAddRows = False
        'DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1   '使用滑鼠右鍵功能
        'Me.Size = New System.Drawing.Size(715, 190) '重新定義視窗大小
        Select Case MainForm.management_Chk
            Case 1
                Label1.Text = "機種:"
                Label2.Text = "型號"
                Label3.Text = "名稱"
                TXT_Type.MaxLength = 20
            Case 2
                Label1.Text = "判定:"
                Label2.Text = "代碼"
                Label3.Text = "說明"
                TXT_Type.MaxLength = 2
            Case 3
                Label1.Text = "原因:"
                Label2.Text = "代碼"
                Label3.Text = "說明"
                TXT_Type.MaxLength = 3
            Case 4
                Label1.Text = "物件:"
                Label2.Text = "代碼"
                Label3.Text = "說明"
                TXT_Type.MaxLength = 2
            Case 5
                Label1.Text = "分類:"
                Label2.Text = "項次"
                Label3.Text = "說明"
                TXT_Type.MaxLength = 1
        End Select

        Load_SQL()
    End Sub
    Sub SQL_Add()
        If TXT_Type.Text = "" Then
            Exit Sub
        End If

        Dim Inser_str As String = ""
        Dim DSQL_str As String = ""
        Select Case MainForm.management_Chk
            Case 1
                Inser_str = "INSERT INTO Aging_Type (Aging_Type, Type_Name) VALUES "
                Inser_str &= "('" & TXT_Type.Text & "', '" & TXT_Name.Text & "')"
                DSQL_str = "SELECT * FROM Aging_Type WHERE Aging_Type = '" & TXT_Type.Text & "'"
            Case 2
                Inser_str = "INSERT INTO determine (determine, determine_N) VALUES "
                Inser_str &= "('" & TXT_Type.Text & "', '" & TXT_Name.Text & "')"
                DSQL_str = "SELECT * FROM determine WHERE determine = '" & TXT_Type.Text & "'"
            Case 3
                Inser_str = "INSERT INTO bad (bad, bad_N) VALUES "
                Inser_str &= "('" & TXT_Type.Text & "', '" & TXT_Name.Text & "')"
                DSQL_str = "SELECT * FROM bad WHERE bad = '" & TXT_Type.Text & "'"
            Case 4
                Inser_str = "INSERT INTO PRQA_KD (PRQA_KD_NO, PRQA_KD_ITEM) VALUES "
                Inser_str &= "('" & TXT_Type.Text & "', '" & TXT_Name.Text & "')"
                DSQL_str = "SELECT * FROM PRQA_KD WHERE PRQA_KD_NO = '" & TXT_Type.Text & "'"
            Case 5
                Inser_str = "INSERT INTO PRQA_TYPE (PRQA_TYPE_NO, PRQA_TYPE_ITEM) VALUES "
                Inser_str &= "('" & TXT_Type.Text & "', '" & TXT_Name.Text & "')"
                DSQL_str = "SELECT * FROM PRQA_TYPE WHERE PRQA_TYPE_NO = '" & TXT_Type.Text & "'"
        End Select

        Conn.Open()
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader
        DReader = DSQL_Cmd.ExecuteReader()
        If DReader.Read() Then     '判斷檔尾 有重複資料
            MsgBox(Label2.Text & " " & TXT_Type.Text & " 資料重複，新增資料失敗!!")
            DReader.Close()
        Else
            DReader.Close()
            Try
                Dim Inser_Cmd As New SqlCommand(Inser_str, Conn)
                Inser_Cmd.ExecuteNonQuery()        '執行Sqlcommand

            Catch ex As Exception
                MsgBox("新增資料失敗!!" & vbCrLf & ex.Message)
            End Try
        End If
        Conn.Close()

        Load_SQL()
    End Sub
    Sub SQL_Del()
        If TXT_Type.Text = "" Then
            Exit Sub
        End If

        Dim del_str As String = ""
        Select Case MainForm.management_Chk
            Case 1
                del_str = "Delete FROM Aging_Type WHERE Aging_Type = '" & TXT_Type.Text
                del_str &= "' And Type_Name = '" & TXT_Name.Text & "'"
            Case 2
                del_str = "Delete FROM determine WHERE determine = '" & TXT_Type.Text
                del_str &= "' And determine_N = '" & TXT_Name.Text & "'"
            Case 3
                del_str = "Delete FROM bad WHERE bad = '" & TXT_Type.Text
                del_str &= "' And bad_N = '" & TXT_Name.Text & "'"
            Case 4
                del_str = "Delete FROM PRQA_KD WHERE PRQA_KD_NO = '" & TXT_Type.Text
                del_str &= "' And PRQA_KD_ITEM = '" & TXT_Name.Text & "'"
            Case 5
                del_str = "Delete FROM PRQA_TYPE WHERE PRQA_TYPE_NO = '" & TXT_Type.Text
                del_str &= "' And PRQA_TYPE_ITEM = '" & TXT_Name.Text & "'"
        End Select

        Conn.Open()
        Try
            Dim del_Cmd As New SqlCommand(del_str, Conn)
            del_Cmd.ExecuteNonQuery()        '執行Sqlcommand

        Catch ex As Exception
            MsgBox("刪除資料失敗!!" & vbCrLf & ex.Message)
        End Try
        Conn.Close()

        Load_SQL()

    End Sub
    Sub SQL_Update()
        If TXT_Type.Text = "" Then
            Exit Sub
        End If

        Dim S1 As String = Mid(Type.Text, 1, Type.Text.IndexOf("-"))
        Dim S2 As String = Mid(Type.Text, Type.Text.IndexOf("-") + 3)
        Console.WriteLine("型號 : {0}", S1)
        Console.WriteLine("名稱 : {0}", S2)
        Dim Update_str As String = ""
        Select Case MainForm.management_Chk
            Case 1
                Update_str = "UPDATE Aging_Type SET Aging_Type = '" & TXT_Type.Text & "', Type_Name = '" & TXT_Name.Text & "'"
                Update_str &= " WHERE Aging_Type = '" & S1 & "' And Type_Name = '" & S2 & "'"
            Case 2
                Update_str = "UPDATE determine SET determine = '" & TXT_Type.Text & "', determine_N = '" & TXT_Name.Text & "'"
                Update_str &= " WHERE determine = '" & S1 & "' And determine_N = '" & S2 & "'"
            Case 3
                Update_str = "UPDATE bad SET bad = '" & TXT_Type.Text & "', bad_N = '" & TXT_Name.Text & "'"
                Update_str &= " WHERE bad = '" & S1 & "' And bad_N = '" & S2 & "'"
            Case 4
                Update_str = "UPDATE PRQA_KD SET PRQA_KD_NO = '" & TXT_Type.Text & "', PRQA_KD_ITEM = '" & TXT_Name.Text & "'"
                Update_str &= " WHERE PRQA_KD_NO = '" & S1 & "' And PRQA_KD_ITEM = '" & S2 & "'"
            Case 5
                Update_str = "UPDATE PRQA_TYPE SET PRQA_TYPE_NO = '" & TXT_Type.Text & "', PRQA_TYPE_ITEM = '" & TXT_Name.Text & "'"
                Update_str &= " WHERE PRQA_TYPE_NO = '" & S1 & "' And PRQA_TYPE_ITEM = '" & S2 & "'"
        End Select
        Conn.Open()
        Try
            Dim Update_Cmd As New SqlCommand(Update_str, Conn)
            Update_Cmd.ExecuteNonQuery()        '執行Sqlcommand

        Catch ex As Exception
            MsgBox("更新資料失敗!!" & vbCrLf & ex.Message)
        End Try
        Conn.Close()

        Load_SQL()

    End Sub
    Sub Load_SQL()
        Conn.Open()
        Dim SELECT_str As String = ""
        Dim ASQL_str As String = ""
        Select Case MainForm.management_Chk
            Case 1
                SELECT_str = "SELECT Aging_Type As 型號, Type_Name As 名稱 FROM Aging_Type ORDER BY 型號 ASC"
                ASQL_str = "SELECT COUNT(*) FROM Aging_Type"
            Case 2
                SELECT_str = "SELECT determine As 代碼, determine_N As 說明 FROM determine ORDER BY 代碼 ASC"
                ASQL_str = "SELECT COUNT(*) FROM determine "
            Case 3
                SELECT_str = "SELECT bad As 代碼, bad_N As 說明 FROM bad ORDER BY 代碼 ASC"
                ASQL_str = "SELECT COUNT(*) FROM bad"
            Case 4
                SELECT_str = "SELECT PRQA_KD_NO As 代碼, PRQA_KD_ITEM As 說明 FROM PRQA_KD ORDER BY 代碼 ASC"
                ASQL_str = "SELECT COUNT(*) FROM PRQA_KD "
            Case 5
                SELECT_str = "SELECT PRQA_TYPE_NO As 項次, PRQA_TYPE_ITEM As 說明 FROM PRQA_TYPE ORDER BY 項次 ASC"
                ASQL_str = "SELECT COUNT(*) FROM PRQA_TYPE"
        End Select

        Dim myAdapter As New SqlDataAdapter(SELECT_str, Conn)
        Dim myDataSet As New DataSet()
        myAdapter.Fill(myDataSet, "DATA_Table")
        DataGridView1.DataSource = myDataSet.Tables("DATA_Table")
        DataGridView1.AutoResizeColumns() '欄位自動調整大小 

        '總數 :
        Dim ASQL_Cmd As New SqlCommand(ASQL_str, Conn)
        Dim AReader As SqlDataReader
        AReader = ASQL_Cmd.ExecuteReader()
        AReader.Read()
        'Total.Text = "總共" & AReader.Item(0) & " 筆記錄"
        AReader.Close()

        Conn.Close()

        'DataGridView1.CurrentCell = Me.DataGridView1(0, DataGridView1.RowCount - 1)    '移動到最後一行

        TXT_Type.Text = ""
        TXT_Name.Text = ""
        Type.Text = ""
    End Sub
    Private Sub DataGridView1_RowStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DataGridView1.RowStateChanged
        If MainForm.management_Chk = 1 Then
            'TXT_Type.Text = RTrim(e.Row.Cells.Item(0).Value)
            'TXT_Name.Text = RTrim(e.Row.Cells.Item(1).Value)
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) _
 Handles DataGridView1.CellMouseClick
        '點選欄位成燈碼為空白時填入相關位置
        Dim Index As Integer = DataGridView1.CurrentCell.RowIndex
        If MainForm.management_Chk = 1 Then
            TXT_Type.Text = RTrim(DataGridView1.Rows(Index).Cells("型號").Value.ToString())
            TXT_Name.Text = RTrim(DataGridView1.Rows(Index).Cells("名稱").Value.ToString())
        ElseIf MainForm.management_Chk = 2 Or MainForm.management_Chk = 3 Or MainForm.management_Chk = 4 Then
            TXT_Type.Text = RTrim(DataGridView1.Rows(Index).Cells("代碼").Value.ToString())
            TXT_Name.Text = RTrim(DataGridView1.Rows(Index).Cells("說明").Value.ToString())
        ElseIf MainForm.management_Chk = 5 Then
            TXT_Type.Text = RTrim(DataGridView1.Rows(Index).Cells("項次").Value.ToString())
            TXT_Name.Text = RTrim(DataGridView1.Rows(Index).Cells("說明").Value.ToString())
        End If
        Type.Text = TXT_Type.Text & " - " & TXT_Name.Text
    End Sub
    Sub cancel()
        Me.Close()
    End Sub
End Class