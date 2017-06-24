Imports System.Configuration
Imports System
Imports System.IO
Imports System.Data
Imports System.IO.Ports
Imports System.Threading
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data.SqlClient
Public Class MainForm
    ' 宣告 全域變數 Aging前後段,Aging刪除權限控制
    Public Aging_Chk, Aging_Chk_D, Aging_Chk_O, management_Chk, Mode As String

    Private Sub Aging_Before_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Aging_Before_ToolStripMenuItem.Click
        If Aging_Chk = 1 Then
            Exit Sub
        End If

        If Aging.Created = True And Aging_Chk <> 4 Then '判斷FORM 是否開啟
            Aging.Btn_add.Enabled = False
            Aging.Btn_update.Enabled = True
            Aging.Btn_del.Enabled = True
            Aging.Btn_XLS.Enabled = False
            Aging.CB_LampNo_change.Visible = False
            Aging.Cmb_Car.Enabled = False
            Aging.Txt_D_Date.Enabled = False
            Aging.Car_Pre_injection.Enabled = False
            Aging.Car_balance.Enabled = False
            Aging.Cmb_Car6.Enabled = False
            Aging.Cmb_Car2.Enabled = False
            Aging.Cmb_Car3.Enabled = False
            Aging.Car_status.Enabled = False
            Aging.Cmb_Car.Enabled = False
            Aging.Txt_voltage.Enabled = False
            Aging.Txt_ampere.Enabled = False
            Aging.Cmb_frame_No.Enabled = True
            Aging.Cmb_Inv_No.Enabled = True
            Aging.Txt_determine.Enabled = True
            Aging.Cmb_lv.Enabled = False
            Aging.Txt_watt.Enabled = False
            Aging.Txt_No2_1.Visible = False
            Aging.Cmb_Car2_1.Visible = False
            Aging.Car_status_1.Visible = False
            Aging.Txt_remark_1.Visible = False
            'Aging.Txt_remark.Size = New System.Drawing.Size(800, 22)
            Aging.Txt_LAMP_NO.Enabled = False
            'Aging.Panel_Box.Visible = True
            'Aging.EXT_Panel.Visible = True
            'Aging.Aging_Panel.Visible = True
            'Aging.LAMP_NO_Panel.Visible = True
            'Aging.Other_Panel.Visible = True
            'Aging.LAMP_NO_Panel.Location = New System.Drawing.Point(5, 495)
            'Aging.LAMP_NO_Panel.BringToFront()
            'Aging.LAMPS_Panel.Location = New System.Drawing.Point(5, 639)
            'Aging.Btn_save.Location = New System.Drawing.Point(526, 720)
            '權限畫面控制 前段
            Aging_Chk = "1"
        Else
            Show_Check()
            add_ToolStripBut.Enabled = True
            search_ToolStripBut.Enabled = True
            '權限畫面控制 前段
            Aging_Chk = "1"
            Aging.TopLevel = False
            Aging.MdiParent = Me
            Aging.Show()
        End If
        Aging.TabPage3.Controls.Add(Aging.LAMPS_Panel)
        Aging.TabPage3.Controls.Add(Aging.EXT_Panel)
        Aging.Aging_Panel.Controls.Add(Aging.Btn_Panel)
        Aging.Aging_Panel.Controls.Add(Aging.Txt_No2)
        Aging.Aging_Panel.Controls.Add(Aging.Txt_remark)
        Aging.TableLayoutPanel2.Controls.Add(Aging.Aging_Panel, 0, 0)

        Aging.Text = "Aging 工作記錄表 - 前段"
        Me.Size = New System.Drawing.Size(1020, 730) '重新定義視窗大小
    End Sub

    Private Sub Aging_After_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Aging_After_ToolStripMenuItem.Click
        If Aging_Chk = 2 Then
            Exit Sub
        End If

        If Aging.Created = True And Aging_Chk <> 4 Then '判斷FORM 是否開啟
            Aging.Btn_add.Enabled = False
            Aging.Btn_update.Enabled = True
            Aging.Btn_del.Enabled = True
            Aging.Btn_XLS.Enabled = False
            Aging.CB_LampNo_change.Visible = False
            Aging.Cmb_Car.Enabled = False
            Aging.Txt_D_Date.Enabled = False
            Aging.Car_Pre_injection.Enabled = False
            Aging.Car_balance.Enabled = False
            Aging.Cmb_Car6.Enabled = False
            Aging.Cmb_Car2.Enabled = False
            Aging.Cmb_Car3.Enabled = False
            Aging.Car_status.Enabled = False
            Aging.Cmb_Car.Enabled = False
            Aging.Txt_voltage.Enabled = False
            Aging.Txt_ampere.Enabled = False
            Aging.Cmb_frame_No.Enabled = False
            Aging.Cmb_Inv_No.Enabled = False
            Aging.Txt_determine.Enabled = True
            Aging.Cmb_lv.Enabled = True
            Aging.Txt_watt.Enabled = True
            Aging.Txt_No2_1.Visible = False
            Aging.Cmb_Car2_1.Visible = False
            Aging.Car_status_1.Visible = False
            Aging.Txt_remark_1.Visible = False
            'Aging.Txt_remark.Size = New System.Drawing.Size(800, 22)
            Aging.Txt_LAMP_NO.Enabled = True
            'Aging.Panel_Box.Visible = True
            'Aging.EXT_Panel.Visible = True
            'Aging.Aging_Panel.Visible = True
            'Aging.LAMP_NO_Panel.Visible = True
            'Aging.Other_Panel.Visible = True
            'Aging.LAMP_NO_Panel.Location = New System.Drawing.Point(5, 495)
            'Aging.LAMP_NO_Panel.BringToFront()
            'Aging.LAMPS_Panel.Location = New System.Drawing.Point(5, 639)
            'Aging.Btn_save.Location = New System.Drawing.Point(526, 720)
            '權限畫面控制 後段
            Aging_Chk = "2"

        Else
            Show_Check()
            add_ToolStripBut.Enabled = True
            search_ToolStripBut.Enabled = True
            '權限畫面控制 後段
            Aging_Chk = "2"
            Aging.TopLevel = False
            Aging.MdiParent = Me
            Aging.Show()
        End If
        Aging.TabPage3.Controls.Add(Aging.LAMPS_Panel)
        Aging.TabPage3.Controls.Add(Aging.EXT_Panel)
        Aging.Aging_Panel.Controls.Add(Aging.Btn_Panel)
        Aging.Aging_Panel.Controls.Add(Aging.Txt_No2)
        Aging.Aging_Panel.Controls.Add(Aging.Txt_remark)
        Aging.TableLayoutPanel2.Controls.Add(Aging.Aging_Panel, 0, 0)

        Aging.Text = "Aging 工作記錄表 - 後段"
        Me.Size = New System.Drawing.Size(1020, 730) '重新定義視窗大小

    End Sub
    Private Sub EX_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EX_ToolStripMenuItem.Click
        If Aging_Chk = 3 Then
            Exit Sub
        End If

        If Aging.Created = True And Aging_Chk <> 4 Then '判斷FORM 是否開啟
            Aging.Btn_add.Enabled = True
            Aging.Btn_update.Enabled = True
            Aging.Btn_del.Enabled = True
            Aging.Btn_XLS.Enabled = False
            Aging.CB_LampNo_change.Visible = True
            Aging.Cmb_Car.Enabled = True
            Aging.Txt_D_Date.Enabled = True
            Aging.Car_Pre_injection.Enabled = True
            Aging.Car_balance.Enabled = True
            Aging.Cmb_Car6.Enabled = True
            Aging.Cmb_Car2.Enabled = True
            Aging.Cmb_Car3.Enabled = True
            Aging.Car_status.Enabled = True
            Aging.Cmb_Car.Enabled = True
            Aging.Txt_voltage.Enabled = False
            Aging.Txt_ampere.Enabled = False
            Aging.Cmb_frame_No.Enabled = False
            Aging.Cmb_Inv_No.Enabled = False
            Aging.Txt_determine.Enabled = False
            Aging.Cmb_lv.Enabled = False
            Aging.Txt_watt.Enabled = False
            Aging.Txt_No2_1.Visible = False
            Aging.Cmb_Car2_1.Visible = False
            Aging.Car_status_1.Visible = False
            Aging.Txt_remark_1.Visible = False
            'Aging.Txt_remark.Size = New System.Drawing.Size(800, 22)
            Aging.Txt_LAMP_NO.Enabled = False
            'Aging.Panel_Box.Visible = False
            'Aging.EXT_Panel.Visible = True
            'Aging.Aging_Panel.Visible = True
            'Aging.LAMP_NO_Panel.Visible = True
            'Aging.Other_Panel.Visible = True
            'Aging.LAMP_NO_Panel.Location = New System.Drawing.Point(577, 495)
            'Aging.LAMP_NO_Panel.BringToFront()
            'Aging.LAMPS_Panel.Location = New System.Drawing.Point(5, 639)
            'Aging.Btn_save.Location = New System.Drawing.Point(526, 720)
            '權限畫面控制 抽氣
            Aging_Chk = "3"

        Else
            Show_Check()
            add_ToolStripBut.Enabled = True
            search_ToolStripBut.Enabled = True
            '權限畫面控制 抽氣
            Aging_Chk = "3"
            Aging.TopLevel = False
            Aging.MdiParent = Me
            Aging.Show()
        End If
        Aging.TabPage3.Controls.Add(Aging.LAMPS_Panel)
        Aging.TabPage3.Controls.Add(Aging.Aging_Panel)
        Aging.EXT_Panel.Controls.Add(Aging.Btn_Panel)
        Aging.EXT_Panel.Controls.Add(Aging.Txt_No2)
        Aging.EXT_Panel.Controls.Add(Aging.Txt_remark)
        Aging.TableLayoutPanel2.Controls.Add(Aging.EXT_Panel, 0, 0)

        Aging.Text = "抽氣工作記錄表"
        Me.Size = New System.Drawing.Size(1020, 730) '重新定義視窗大小
    End Sub
    Private Sub LAMPS_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LAMPS_ToolStripMenuItem.Click
        'If LAMPS.Created = True Then
        'Exit Sub
        'End If
        'Show_Check()

        'LAMPS.TopLevel = False
        'LAMPS.MdiParent = Me
        'LAMPS.Show()
        'Me.Size = New System.Drawing.Size(1020, 690) '重新定義視窗大小
        'LAMPS.ShowDialog(Me) '視窗最上層
        If Aging_Chk = 4 Then
            Exit Sub
        End If

        '權限畫面控制 抽氣
        'If Aging.Created = True Then '判斷FORM 是否開啟
        'Aging.Panel_Box.Visible = False
        'Aging.Btn_add.Enabled = True
        'Aging.Btn_update.Enabled = True
        'Aging.Btn_del.Enabled = True
        'Aging.Btn_XLS.Enabled = False
        'Aging.Txt_remark.Size = New System.Drawing.Size(800, 22)
        'Aging.EX_Panel.Visible = False
        'Aging.Aging_Panel.Visible = False
        'Aging.LAMP_NO_Panel.Visible = False
        'Aging.Other_Panel.Visible = False
        'Aging.LAMPS_Panel.Location = New System.Drawing.Point(5, 449)
        'Aging.Btn_save.Location = New System.Drawing.Point(877, 556)
        'Else
        Show_Check()
        add_ToolStripBut.Enabled = True
        search_ToolStripBut.Enabled = True
        Aging_Chk = "4"
        Aging.TopLevel = False
        Aging.MdiParent = Me
        Aging.Show()
        'End If
        Aging.Text = "組裝輸入工作記錄表"

        Aging.TabPage3.Controls.Add(Aging.EXT_Panel)
        Aging.TabPage3.Controls.Add(Aging.Aging_Panel)
        'Aging.LAMPS_Panel.Controls.Add(Aging.Btn_Panel)
        Aging.LAMPS_Panel.Controls.Add(Aging.Txt_remark)
        Aging.TableLayoutPanel2.Controls.Add(Aging.LAMPS_Panel, 0, 0)
        Me.Size = New System.Drawing.Size(1020, 730) '重新定義視窗大小
    End Sub

    Private Sub LAMPS_SER_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LAMPS_SER_ToolStripMenuItem.Click
        'If LAMPS_SER.Created = True Then
        'Exit Sub
        'End If
        'Show_Check()

        'LAMPS_SER.TopLevel = False
        'LAMPS_SER.MdiParent = Me
        'LAMPS_SER.Show()
        'Me.Size = New System.Drawing.Size(1020, 690) '重新定義視窗大小
        LAMPS_SER.ShowDialog(Me) '視窗最上層

        LAMPS_SER.Txt_LAMPS_NO.Text = ""
    End Sub

    Private Sub EX_Report_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EX_Report_ToolStripMenuItem.Click
        If EX_Report.Created = True Then
            Exit Sub
        End If
        Show_Check()

        search_ToolStripBut.Enabled = True
        EX_Report.TopLevel = False
        EX_Report.MdiParent = Me
        EX_Report.Text = "抽氣工作記錄表輸出"
        EX_Report.Show()
        Me.Size = New System.Drawing.Size(1020, 730) '重新定義視窗大小
    End Sub

    Private Sub OutGoods_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutGoods_ToolStripMenuItem.Click
        If OutGoods.Created = True Then
            Exit Sub
        End If
        Show_Check()

        search_ToolStripBut.Enabled = True
        OutGoods.TopLevel = False
        OutGoods.MdiParent = Me
        OutGoods.Text = "資料查詢"
        OutGoods.Show()
        Me.Size = New System.Drawing.Size(1020, 730) '重新定義視窗大小
    End Sub

    Private Sub PRCS_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRCS_ToolStripMenuItem.Click
        If PRCS.Created = True Then
            Exit Sub
        End If
        Show_Check()

        PRCS.TopLevel = False
        PRCS.MdiParent = Me
        PRCS.Show()
        Me.Size = New System.Drawing.Size(830, 630) '重新定義視窗大小
    End Sub

    Private Sub PRQA_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRQA_ToolStripMenuItem.Click
        If PRQA.Created = True Then
            Exit Sub
        End If
        Show_Check()

        PRQA.TopLevel = False
        PRQA.MdiParent = Me
        PRQA.Show()
        Me.Size = New System.Drawing.Size(830, 630) '重新定義視窗大小
    End Sub

    Private Sub PRQA_SER_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRQA_SER_ToolStripMenuItem.Click
        If PRQA_SER.Created = True Then
            Exit Sub
        End If
        Show_Check()

        PRQA_SER.TopLevel = False
        PRQA_SER.MdiParent = Me
        PRQA_SER.Show()
        Me.Size = New System.Drawing.Size(830, 630) '重新定義視窗大小
    End Sub

    Private Sub Admin_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Admin_ToolStripMenuItem.Click
        If Admin.Created = True Then
            Exit Sub
        End If
        Show_Check()

        add_ToolStripBut.Enabled = True
        edit_ToolStripBut.Enabled = True
        del_ToolStripBut.Enabled = True

        Admin.TopLevel = False
        Admin.MdiParent = Me
        Admin.Show()
        Me.Size = New System.Drawing.Size(1020, 690) '重新定義視窗大小
        Admin.Load_SQL()    '載入人員資料
        Admin.OrderByNum()  '行首數字
        Admin.DataGridView_center() '置中
        Admin.Data_Bindings() '資料繫結
        Admin.DataGridViewColumn_Resize()   '變更格子大小
        Admin.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter '行首置中
    End Sub

    Private Sub Type_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Type_ToolStripMenuItem.Click
        If management_Chk = 1 Then
            Exit Sub
        End If
        management_Shows(1)
    End Sub

    Private Sub determine_ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles determine_ToolStripMenuItem1.Click
        If management_Chk = 2 Then
            Exit Sub
        End If
        management_Shows(2)
    End Sub

    Private Sub Bad_ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles Bad_ToolStripMenuItem1.Click
        If management_Chk = 3 Then
            Exit Sub
        End If
        management_Shows(3)
    End Sub

    Private Sub Item_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Item_ToolStripMenuItem.Click
        If management_Chk = 4 Then
            Exit Sub
        End If
        management_Shows(4)
    End Sub

    Private Sub Sort_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Sort_ToolStripMenuItem.Click
        If management_Chk = 5 Then
            Exit Sub
        End If
        management_Shows(5)
    End Sub
    Private Sub management_Shows(ByVal Num As String)
        management_Chk = Num

        If management.Created = True Then '判斷FORM 是否開啟
            Select Case management_Chk
                Case 1
                    management.Label1.Text = "機種:"
                    management.Label2.Text = "型號"
                    management.Label3.Text = "名稱"
                    management.TXT_Type.MaxLength = 20
                Case 2
                    management.Label1.Text = "判定:"
                    management.Label2.Text = "代碼"
                    management.Label3.Text = "說明"
                    management.TXT_Type.MaxLength = 2
                Case 3
                    management.Label1.Text = "原因:"
                    management.Label2.Text = "代碼"
                    management.Label3.Text = "說明"
                    management.TXT_Type.MaxLength = 3
                Case 4
                    management.Label1.Text = "物件:"
                    management.Label2.Text = "代碼"
                    management.Label3.Text = "說明"
                    management.TXT_Type.MaxLength = 2
                Case 5
                    management.Label1.Text = "分類:"
                    management.Label2.Text = "項次"
                    management.Label3.Text = "說明"
                    management.TXT_Type.MaxLength = 1
            End Select

            management.Load_SQL()
        Else
            Show_Check()

            add_ToolStripBut.Enabled = True
            edit_ToolStripBut.Enabled = True
            del_ToolStripBut.Enabled = True

            management.Load_SQL()
            management.TopLevel = False
            management.MdiParent = Me
            management.Show()
            Me.Size = New System.Drawing.Size(830, 690) '重新定義視窗大小
        End If

    End Sub
    Private Sub Show_Check()
        Tools_Enabled()

        If Aging.Created = True Then
            Aging.Close()
            Aging_Chk = 0
        ElseIf LAMPS.Created = True Then
            LAMPS.Dispose()
        ElseIf LAMPS_SER.Created = True Then
            LAMPS_SER.Dispose()
        ElseIf PRCS.Created = True Then
            PRCS.Dispose()
        ElseIf PRQA.Created = True Then
            PRQA.Dispose()
        ElseIf PRQA_SER.Created = True Then
            PRQA_SER.Dispose()
        ElseIf Admin.Created = True Then
            Admin.Dispose()
        ElseIf EX_Report.Created = True Then
            EX_Report.Dispose()
        ElseIf OutGoods.Created = True Then
            OutGoods.Dispose()
        ElseIf management.Created = True Then
            management.Dispose()
            management_Chk = "0"
        End If
        Txt_X1.Text = ""
        Txt_X2.Text = ""
        Txt_X3.Text = ""
    End Sub
    Dim Login_Out As Boolean
    Private Sub 登出ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 登出ToolStripMenuItem.Click
        Login_Out = True '避免關掉主視窗Form
        Me.Close()
        Login.Show()
        Login_Out = False
    End Sub
    Private Sub 離開ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 離開ToolStripMenuItem1.Click
        Me.Dispose()
        End
    End Sub
    Private Sub TestToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        Aging_new.TopLevel = False
        Aging_new.MdiParent = Me
        Aging_new.Show()

    End Sub
    Private Sub close_ToolStripBut_Click(sender As Object, e As EventArgs) Handles close_ToolStripBut.Click
        BindingNavigator1.BindingSource = Nothing
        Show_Check()
        Tools_Enabled()
    End Sub
    Private Sub add_ToolStripBut_Click(sender As Object, e As EventArgs) Handles add_ToolStripBut.Click
        If Aging.Created = True Then
            Aging.TabControl1.SelectedTab = Aging.TabControl1.TabPages(1)   '切換到資料欄位頁
            Mode = "ADD"
            Add_Mode()
            Aging.Txt_No.Focus()
        ElseIf LAMPS.Created = True Then
            LAMPS.Dispose()
        ElseIf LAMPS_SER.Created = True Then
            LAMPS_SER.Dispose()
        ElseIf PRCS.Created = True Then
            PRCS.Dispose()
        ElseIf PRQA.Created = True Then
            PRQA.Dispose()
        ElseIf PRQA_SER.Created = True Then
            PRQA_SER.Dispose()
        ElseIf Admin.Created = True Then
            Admin.SQL_add()
        ElseIf EX_Report.Created = True Then
            EX_Report.Dispose()
        ElseIf OutGoods.Created = True Then
            OutGoods.Dispose()
        ElseIf management.Created = True Then
            management.SQL_Add()
        End If
    End Sub
    Private Sub search_ToolStripBut_Click(sender As Object, e As EventArgs) Handles search_ToolStripBut.Click
        If Aging.Created = True Or EX_Report.Created = True Or OutGoods.Created = True Then
            SearchData.ShowDialog(Me) '視窗最上層
        End If
    End Sub

    Private Sub edit_ToolStripBut_Click(sender As Object, e As EventArgs) Handles edit_ToolStripBut.Click
        If Aging.Created = True Then
            Aging.TabControl1.SelectedTab = Aging.TabControl1.TabPages(1)   '切換到資料欄位頁
            Mode = "EDIT"
            Edit_Mode()
            Aging.Txt_Type.Focus()
        ElseIf LAMPS.Created = True Then
            LAMPS.Dispose()
        ElseIf LAMPS_SER.Created = True Then
            LAMPS_SER.Dispose()
        ElseIf PRCS.Created = True Then
            PRCS.Dispose()
        ElseIf PRQA.Created = True Then
            PRQA.Dispose()
        ElseIf PRQA_SER.Created = True Then
            PRQA_SER.Dispose()
        ElseIf Admin.Created = True Then
            Admin.SQL_edit()
        ElseIf EX_Report.Created = True Then
            EX_Report.Dispose()
        ElseIf OutGoods.Created = True Then
            OutGoods.Dispose()
        ElseIf management.Created = True Then
            management.SQL_Update()
        End If
    End Sub
    Private Sub del_ToolStripBut_Click(sender As Object, e As EventArgs) Handles del_ToolStripBut.Click
        If Aging.Created = True Then
            Aging.del_TXTNo()
        ElseIf LAMPS.Created = True Then
            LAMPS.Dispose()
        ElseIf LAMPS_SER.Created = True Then
            LAMPS_SER.Dispose()
        ElseIf PRCS.Created = True Then
            PRCS.Dispose()
        ElseIf PRQA.Created = True Then
            PRQA.Dispose()
        ElseIf PRQA_SER.Created = True Then
            PRQA_SER.Dispose()
        ElseIf Admin.Created = True Then
            Admin.SQL_del()
        ElseIf EX_Report.Created = True Then
            EX_Report.Dispose()
        ElseIf OutGoods.Created = True Then
            OutGoods.Dispose()
        ElseIf management.Created = True Then
            management.SQL_Del()
        End If
    End Sub
    Private Sub save_ToolStripBut_Click(sender As Object, e As EventArgs) Handles save_ToolStripBut.Click
        If Aging.Created = True Then
            If Mode = "ADD" Then
                Aging.Add_TxTNo()
            ElseIf Mode = "EDIT" Then
                Aging.Edit_TXTNo()
            End If
            Read_Mode()
        ElseIf LAMPS.Created = True Then
            LAMPS.Dispose()
        ElseIf LAMPS_SER.Created = True Then
            LAMPS_SER.Dispose()
        ElseIf PRCS.Created = True Then
            PRCS.Dispose()
        ElseIf PRQA.Created = True Then
            PRQA.Dispose()
        ElseIf PRQA_SER.Created = True Then
            PRQA_SER.Dispose()
        ElseIf Admin.Created = True Then
            Admin.SQL_update()
        ElseIf EX_Report.Created = True Then
            EX_Report.Dispose()
        ElseIf OutGoods.Created = True Then
            OutGoods.Dispose()
        ElseIf management.Created = True Then
            management.Dispose()
            management_Chk = "0"
        End If
    End Sub

    Private Sub cancel_ToolStripBut_Click(sender As Object, e As EventArgs) Handles cancel_ToolStripBut.Click
        If Aging.Created = True Then
            Read_Mode()
        ElseIf LAMPS.Created = True Then

        ElseIf LAMPS_SER.Created = True Then

        ElseIf PRCS.Created = True Then

        ElseIf PRQA.Created = True Then

        ElseIf PRQA_SER.Created = True Then

        ElseIf Admin.Created = True Then
            Admin.cancel()
        ElseIf EX_Report.Created = True Then

        ElseIf OutGoods.Created = True Then

        ElseIf management.Created = True Then
            management.cancel()
        End If

    End Sub
    Private Sub export_ToolStripBut_Click(sender As Object, e As EventArgs) Handles export_ToolStripBut.Click
        If Aging.Created = True Then

        ElseIf LAMPS.Created = True Then

        ElseIf LAMPS_SER.Created = True Then

        ElseIf PRCS.Created = True Then

        ElseIf PRQA.Created = True Then

        ElseIf PRQA_SER.Created = True Then

        ElseIf Admin.Created = True Then

        ElseIf EX_Report.Created = True Then
            EX_Report.ExPort_XLS()
        ElseIf OutGoods.Created = True Then
            OutGoods.ExPort_XLS()
        ElseIf management.Created = True Then

        End If
    End Sub
    Sub Tools_Enabled()
        add_ToolStripBut.Enabled = False
        search_ToolStripBut.Enabled = False
        edit_ToolStripBut.Enabled = False
        del_ToolStripBut.Enabled = False
        save_ToolStripBut.Enabled = False
        export_ToolStripBut.Enabled = False
        save_ToolStripBut.Enabled = False
    End Sub
    Sub Add_Mode()
        Aging.Txt_No.Enabled = True
        Aging.Txt_Type.Enabled = True
        AddEditEnabled()
    End Sub
    Sub Edit_Mode()
        Aging.Txt_Type.Enabled = True
        AddEditEnabled()
    End Sub
    Sub AddEditEnabled()
        add_ToolStripBut.Enabled = False
        search_ToolStripBut.Enabled = False
        edit_ToolStripBut.Enabled = False
        del_ToolStripBut.Enabled = False
        save_ToolStripBut.Enabled = True
        cancel_ToolStripBut.Enabled = True
    End Sub
    Sub Read_Mode()
        Aging.Txt_No.Enabled = False
        Aging.Txt_Type.Enabled = False
        add_ToolStripBut.Enabled = True
        search_ToolStripBut.Enabled = True
        edit_ToolStripBut.Enabled = True
        del_ToolStripBut.Enabled = True
        save_ToolStripBut.Enabled = False
        cancel_ToolStripBut.Enabled = False
    End Sub
    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TestToolStripMenuItem.Visible = False   '隱藏

        '找出字體大小,並算出比例
        Dim dpiX, dpiY As Single
        Dim Graphics As Graphics = Me.CreateGraphics
        dpiX = Graphics.DpiX
        dpiY = Graphics.DpiY
        Dim intPercent As Integer = If((dpiX = 96), 100, If((dpiX = 120), 125, 150))
        '針對字體變更Form的大小
        Me.Height = Me.Height * intPercent / 100

        add_ToolStripBut.Enabled = False
        search_ToolStripBut.Enabled = False
        edit_ToolStripBut.Enabled = False
        del_ToolStripBut.Enabled = False
        print_ToolStripBut.Enabled = False
        export_ToolStripBut.Enabled = False
        save_ToolStripBut.Enabled = False
        cancel_ToolStripBut.Enabled = False

        '權限畫面控制
        'administrator
        If Login.ALL_UserID = "Admin" Or Login.ALL_Admin = "是" Then
            '權限檢查-Angin刪除權限
            Aging_Chk_D = "1"
            '權限檢查-組長權限
            Aging_Chk_O = "1"

        Else
            Admin_ToolStripMenu.Enabled = False '人員資料管理
            ''----------------------抓config檔的ConnectionString
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString()

            Dim queryString As String =
                "SELECT * FROM dbo.Users WHERE User_ID ='" & Login.ALL_UserID & "';"

            Using connection As New SqlConnection(connectionString)
                Dim command As New SqlCommand(queryString, connection)
                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader()

                If reader.Read() Then     '判斷檔尾 有資料
                    Dim String_ As String = Trim(reader.Item("Aging")) & Trim(reader.Item("PRCS")) & Trim(reader.Item("PRQA"))
                    '檢查權限重新定義視窗
                    Select Case String_
                        Case "是是是"  '111
                            Aging_ToolStripeMenu.Enabled = True
                            PRCS_ToolStripeMenu.Enabled = True
                            PRQA_ToolStripeMenu.Enabled = True

                        Case "是否是"  '101
                            Aging_ToolStripeMenu.Enabled = True
                            PRCS_ToolStripeMenu.Enabled = False
                            PRQA_ToolStripeMenu.Enabled = True

                        Case "是是否"  '110
                            Aging_ToolStripeMenu.Enabled = True
                            PRCS_ToolStripeMenu.Enabled = True
                            PRQA_ToolStripeMenu.Enabled = False

                        Case "是否否"  '100
                            Aging_ToolStripeMenu.Enabled = True
                            PRCS_ToolStripeMenu.Enabled = False
                            PRQA_ToolStripeMenu.Enabled = False

                        Case "否是否"  '010
                            Aging_ToolStripeMenu.Enabled = False
                            PRCS_ToolStripeMenu.Enabled = True
                            PRQA_ToolStripeMenu.Enabled = False

                        Case "否是是"  '011
                            Aging_ToolStripeMenu.Enabled = False
                            PRCS_ToolStripeMenu.Enabled = True
                            PRQA_ToolStripeMenu.Enabled = True

                        Case "否否是"  '001
                            Aging_ToolStripeMenu.Enabled = False
                            PRCS_ToolStripeMenu.Enabled = False
                            PRQA_ToolStripeMenu.Enabled = True
                    End Select

                    '權限檢查-Angin刪除權限
                    If Trim(reader.Item("Aging_Del")) = "是" Then
                        Aging_Chk_D = "1"
                    End If

                    '權限檢查-組長權限
                    If Trim(reader.Item("Aging_LD")) = "是" Then
                        Aging_Chk_O = "1"
                    End If

                    '權限檢查-人員資料管理權限
                    If Trim(reader.Item("Admin")) = "是" Then
                        Admin_ToolStripMenu.Enabled = True '人員資料管理
                    End If

                End If

                reader.Close()
                connection.Close()
            End Using
        End If
    End Sub
    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'MessageBox.Show("確定關閉視窗?", "警告", MessageBoxButtons.YesNo) = MsgBoxResult.No
        If Login_Out <> True AndAlso MsgBox("關閉視窗?", MsgBoxStyle.OkCancel, "警告") = MsgBoxResult.Cancel Then
            'Me.Close()
            e.Cancel = True
            Exit Sub
        ElseIf Login_Out = True Then
            Exit Sub
        End If
        Shutdown()
    End Sub
    Protected Sub Shutdown()
        '離開並關閉執行緒
        Environment.Exit(Environment.ExitCode)
        Application.Exit()
    End Sub
End Class