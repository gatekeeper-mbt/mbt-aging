''MBT程式
''          20101006 by ice 謝禎皓

Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class LAMPS_SER
    ''----------------------抓config檔的ConnectionString
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()
    Dim Conn As SqlConnection = New SqlConnection(connectionString)

    Private Sub LAMPS_SER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New System.Drawing.Size(960, 430) '重新定義視窗大小
        'Me.ControlBox = False
        'Me.WindowState = FormWindowState.Maximized '視窗最大化

        Txt_LAMPS_NO.Focus()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Dispose()
        'Me.Close()
        'Me.DialogResult = DialogResult.OK
    End Sub
    Private Sub LAMPS_SER_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub
    Private Sub Txt_LAMPS_NO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_LAMPS_NO.KeyPress
        '檢查是否按下Enter
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            LAMPS_NO_Refresh()
        End If
    End Sub
    Private Sub Txt_LAMPS_NO_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_LAMPS_NO.Leave
        If Txt_LAMPS_NO.Text = "" Then
            Exit Sub
        End If

        LAMPS_NO_Refresh()
    End Sub

    Sub LAMPS_NO_Refresh()
        '資料搜尋帶入
        Conn.Open()

        '單身資料搜尋Aging.Aging_D
        Dim DSQL_str As String = "SELECT * FROM Aging_D WHERE LAMPS_NO = '" & Txt_LAMPS_NO.Text & "'"
        Dim DSQL_Cmd As New SqlCommand(DSQL_str, Conn)
        Dim DReader As SqlDataReader
        DReader = DSQL_Cmd.ExecuteReader()
        If DReader.Read() Then     '判斷檔尾 有資料
            '補資料的資料時 以下會無資料出現bug
            If Not IsDBNull(DReader.Item("Ballast_NO")) Then
                Txt_Ballast_NO.Text = DReader.Item("Ballast_NO")
            End If
            If Not IsDBNull(DReader.Item("ampere3")) Then
                Txt_ampere3.Text = DReader.Item("ampere3")
            End If

            If Not IsDBNull(DReader.Item("Aging_no2")) Then
                Txt_No2.Text = DReader.Item("Aging_no2")
            End If
            If Not IsDBNull(DReader.Item("Aging_D_Date")) Then
                Txt_D_Date.Text = DReader.Item("Aging_D_Date")
            End If
            If Not IsDBNull(DReader.Item("Car_No")) Then
                Cmb_Car.Text = DReader.Item("Car_No")
            End If
            If Not IsDBNull(DReader.Item("Car_No2")) Then
                Cmb_Car2.Text = DReader.Item("Car_No2")
            End If
            If Not IsDBNull(DReader.Item("Car_No3")) Then
                Cmb_Car3.Text = DReader.Item("Car_No3")
            End If
            If Not IsDBNull(DReader.Item("Car_No6")) Then
                Cmb_Car6.Text = DReader.Item("Car_No6")
            End If
            If Not IsDBNull(DReader.Item("Car_No4")) Then
                Car_Pre_injection.Text = DReader.Item("Car_No4")
            End If
            If Not IsDBNull(DReader.Item("Car_No5")) Then
                Car_balance.Text = DReader.Item("Car_No5")
            End If
            If Not IsDBNull(DReader.Item("Car_status")) Then
                Car_status.Text = DReader.Item("Car_status")
            End If
            If Not IsDBNull(DReader.Item("voltage")) Then
                Txt_voltage.Text = DReader.Item("voltage")
            End If
            If Not IsDBNull(DReader.Item("ampere")) Then
                Txt_ampere.Text = DReader.Item("ampere")
            End If
            If Not IsDBNull(DReader.Item("frame_No")) Then
                Cmb_frame_No.Text = DReader.Item("frame_No")
            End If
            If Not IsDBNull(DReader.Item("Inv_No")) Then
                Cmb_Inv_No.Text = DReader.Item("Inv_No")
            End If
            If Not IsDBNull(DReader.Item("determine")) Then
                Txt_determine.Text = DReader.Item("determine")
            End If

            If Not IsDBNull(DReader.Item("pre1")) Then
                Txt_pre1.Text = DReader.Item("pre1")
            End If
            If Not IsDBNull(DReader.Item("pre2")) Then
                Txt_pre2.Text = DReader.Item("pre2")
            End If
            If Not IsDBNull(DReader.Item("pre3")) Then
                Txt_pre3.Text = DReader.Item("pre3")
            End If
            If Not IsDBNull(DReader.Item("pre4")) Then
                Txt_pre4.Text = DReader.Item("pre4")
            End If
            If Not IsDBNull(DReader.Item("watt")) Then
                Txt_watt.Text = DReader.Item("watt")
            End If
            If Not IsDBNull(DReader.Item("voltage2")) Then
                Txt_voltage2.Text = DReader.Item("voltage2")
            End If
            If Not IsDBNull(DReader.Item("ampere2")) Then
                Txt_ampere2.Text = DReader.Item("ampere2")
            End If
            If Not IsDBNull(DReader.Item("lv")) Then
                Cmb_lv.Text = DReader.Item("lv")
            End If
            If Not IsDBNull(DReader.Item("remark")) Then
                Txt_remark.Text = DReader.Item("remark")
            End If

        End If
        DReader.Close()

        '不良分析單號
        Dim select_str As String = "SELECT PRQA_NO FROM PRQA_D WHERE LAMPS_NO = '" & Txt_LAMPS_NO.Text & "'"
        Dim myadapter As New SqlDataAdapter(select_str, Conn)
        Dim mydataset As New DataSet()
        myadapter.Fill(mydataset, "PRQA_D")

        DataGridView1.DataSource = mydataset.Tables("PRQA_D")

        Conn.Close()
    End Sub
End Class