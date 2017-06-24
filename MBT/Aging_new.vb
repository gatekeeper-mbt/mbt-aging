Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports NPOI
Imports NPOI.HPSF
Imports NPOI.HSSF.UserModel
Imports NPOI.POIFS.FileSystem
Public Class Aging_new
    ''----------------------抓config檔的ConnectionString
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()
    Dim Conn As SqlConnection = New SqlConnection(connectionString)

    Private SavePages As New ArrayList
    Private Sub Admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.WindowState = FormWindowState.Maximized '視窗最大化
        DataGridView3.Columns.Add("LAMPS_NO", "成燈碼")
        DataGridView3.Columns.Add("Aging_No2", "燈板號碼")
        DataGridView3.Columns.Add("Aging_D_Date", "日期")
        DataGridView3.Columns.Add("Car_No", "抽氣台車")
        DataGridView3.Columns.Add("Car_No4", "預注值")
        DataGridView3.Columns.Add("Car_No5", "平衡值")
        DataGridView3.Columns.Add("Car_No2", "位置")
        DataGridView3.Columns.Add("Car_No6", "線別")
        DataGridView3.Columns.Add("Car_No3", "圈數")
        DataGridView3.Columns.Add("Car_status", "不良原因")
        DataGridView3.Columns.Add("frame_No", "框架編號")
        DataGridView3.Columns.Add("Inv_No", "Inv編號")
        DataGridView3.Columns.Add("determine", "Aging判定")
        DataGridView3.Columns.Add("watt", "功率Watt")
        DataGridView3.Columns.Add("lv", "判定等級")
        DataGridView3.Columns.Add("remark", "備註")
        DataGridView3.Columns.Add("SYS_Date", "系統日期")
        DataGridView3.Columns.Add("SYS_UID", "系統操作者")
        DataGridView3.Columns.Add("ID", "ID")

        Dim SELECT_str As String = "Select RTRIM(LAMPS_NO) As 成燈碼, RTRIM(Aging_No2) As 燈板號碼, Aging_D_Date As 日期, Car_No As 抽氣台車,"
        SELECT_str &= "RTRIM(Car_No4) As 預注值, RTRIM(Car_No5) As 平衡值, RTRIM(Car_No2) As 位置, RTRIM(Car_No6) As 線別, Car_No3 As 圈數, "
        SELECT_str &= "RTRIM(Car_status) As 不良原因, frame_No As 框架編號, Inv_No As Inv編號, determine As Aging判定, watt As 功率Watt, "
        SELECT_str &= "lv As 判定等級, RTRIM(remark) As 備註, SYS_Date As 系統日期, SYS_UID As 系統操作者 ,ID As ID "
        SELECT_str &= "FROM Aging_D WHERE Aging_No LIKE'E2216%'"
        Conn.Open()
        Dim myAdapter As New SqlDataAdapter(SELECT_str, Conn)
        Dim myDataSet As New DataSet()
        myAdapter.Fill(myDataSet, "Aging_D")
        Conn.Close()

        DataGridView1.DataSource = myDataSet.Tables("Aging_D")
        'Me.TabControl1.Controls.Add(要加入的tabpage) '<-加入用
        'Me.TabControl1.Controls.Remove(TabPage3) '<-移除用
        ' 保存

        ' 在 form.load
        For i As Integer = 0 To TabControl1.TabPages.Count - 1
            SavePages.Add(TabControl1.TabPages(i))
        Next

        '移除（最好用名稱，不要用數字，這裡只是方便舉例）
        TabControl1.TabPages.Remove(TabPage3)

        '還原
        TabControl1.TabPages.Clear()
        For i As Integer = 0 To SavePages.Count - 1
            TabControl1.TabPages.Add(DirectCast(SavePages(i), TabPage))
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel1.Controls.Add(Me.Btn_Hsave)
        Me.Panel1.Controls.Add(Me.HScrollBar1)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.TabPage3.Controls.Add(Me.Btn_Hsave)
        Me.TableLayoutPanel3.Controls.Add(Me.HScrollBar1, 0, 1)
    End Sub
End Class