Public Class SearchData
    Public Shared SQL_Str As Object '此即為可在應用程式定義域中可共用的類別變數
    Dim ActiveObj As String '主視窗目前的工作表

    Private Sub SearchData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyBase.CancelButton = cancel_Button '使用ECS 鍵關閉視窗
        MyBase.AcceptButton = OK_Button '使用ENTER 鍵確認

        Me.TabControl1.Controls.Remove(TabPage3) '<-移除用
        'Me.TabControl1.Controls.Item(1).Enabled = False '將進階選項設為不使用
        Dim name()
        If EX_Report.Created = True Then
            DataNum_limit.SelectedIndex = 11
            name = {"工單號碼", "燈板號碼", "抽氣台車", "預注值", "平衡值", "位置", "線別", "圈數",
                          "不良原因", "備註", "建立人員", "修改人員", "建立日期", "修改日期"}
        Else
            name = {"工單號碼", "機種", "建立人員", "修改人員", "建立日期", "修改日期", "投入",
                          "產出", "不良"}
        End If

        If ActiveObj <> MainForm.Text Then
            ListBox1.Items.Clear()
            ComboBox3.Items.Clear()
            If ListBox2.Items.Count <> 0 Then
                ListBox2.Items.Clear()
            End If
            For i As Integer = 0 To name.Length - 1
                ListBox1.Items.Add(name(i))
                ComboBox3.Items.Add(name(i))
            Next
        End If
        ActiveObj = MainForm.Text

        CheckBox1.Enabled = False
        If EX_Report.Created = True Then
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Me.TabControl1.Controls.Add(TabPage3) '<-加入用
            TabControl1.SelectedTab = TabControl1.TabPages(2)   '移到單身設定
        Else
            Me.TabControl1.Controls.Remove(TabPage3) '<-移除用
        End If
    End Sub

    Private Sub ADD_Button1_Click(sender As Object, e As EventArgs) Handles ADD_Button1.Click
        If TextBox3.Text = "" Then
            MessageBox.Show("希望您能夠先輸入您要找的資料" & vbCrLf, "設定查詢條件", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If
        If GroupBox1.Enabled = False Then
            TextBox4.Text = TextBox4.Text & "(" & ComboBox3.Text & " "
            Select Case ComboBox4.SelectedIndex
                Case 0, 1, 2, 3, 4
                    TextBox4.Text &= ComboBox4.Text & " '" & TextBox3.Text
                Case 5
                    TextBox4.Text &= " LIKE '%" & TextBox3.Text & "%"
                Case 6
                    TextBox4.Text &= " LIKE '" & TextBox3.Text & "%"
                Case 7
                    TextBox4.Text &= " LIKE '%" & TextBox3.Text
            End Select
            TextBox4.Text &= "')" & vbCrLf
            GroupBox1.Enabled = True
        Else
            TextBox4.Text = TextBox4.Text & "   "
            If AND_RadioButton1.Checked = True Then
                TextBox4.Text &= AND_RadioButton1.Text
            Else
                TextBox4.Text &= OR_RadioButton1.Text
            End If

            TextBox4.Text &= "  (" & ComboBox3.Text & " "
            Select Case ComboBox4.SelectedIndex
                Case 0, 1, 2, 3, 4
                    TextBox4.Text &= ComboBox4.Text & " '" & TextBox3.Text
                Case 5
                    TextBox4.Text &= " LIKE '%" & TextBox3.Text & "%"
                Case 6
                    TextBox4.Text &= " LIKE '" & TextBox3.Text & "%"
                Case 7
                    TextBox4.Text &= " LIKE '%" & TextBox3.Text
            End Select
            TextBox4.Text &= "')" & vbCrLf
        End If
    End Sub

    Private Sub ADD_Button2_Click(sender As Object, e As EventArgs) Handles ADD_Button2.Click
        If TextBox5.Text = "" Then
            MessageBox.Show("希望您能夠先輸入您要找的資料" & vbCrLf, "設定查詢條件", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If
        If GroupBox2.Enabled = False Then
            TextBox6.Text = TextBox6.Text & "(" & ComboBox5.Text & " "
            Select Case ComboBox6.SelectedIndex
                Case 0, 1, 2, 3, 4
                    TextBox6.Text &= ComboBox6.Text & " '" & TextBox5.Text
                Case 5
                    TextBox6.Text &= "LIKE '%" & TextBox5.Text & "%"
                Case 6
                    TextBox6.Text &= "LIKE '" & TextBox5.Text & "%"
                Case 7
                    TextBox6.Text &= "LIKE '%" & TextBox5.Text
            End Select
            TextBox6.Text &= "')" & vbCrLf
            GroupBox2.Enabled = True
        Else
            TextBox6.Text = TextBox6.Text & "   "
            If AND_RadioButton2.Checked = True Then
                TextBox6.Text &= AND_RadioButton2.Text
            Else
                TextBox6.Text &= OR_RadioButton2.Text
            End If

            TextBox6.Text &= "  (" & ComboBox5.Text & " "
            Select Case ComboBox6.SelectedIndex
                Case 0, 1, 2, 3, 4
                    TextBox6.Text &= ComboBox6.Text & " '" & TextBox5.Text
                Case 5
                    TextBox6.Text &= "LIKE '%" & TextBox5.Text & "%"
                Case 6
                    TextBox6.Text &= "LIKE '" & TextBox5.Text & "%"
                Case 7
                    TextBox6.Text &= "LIKE '%" & TextBox5.Text
            End Select
            TextBox6.Text &= "')" & vbCrLf
        End If
    End Sub
    Sub ListBox2Add()
        If ListBox2.Items.Count <> 0 Then
            For i = 0 To ListBox2.Items.Count - 1
                Dim aa = Mid(ListBox2.Items.Item(i).ToString, 2, Len(ListBox2.Items.Item(i).ToString))
                If aa = ListBox1.SelectedItem Then
                    Exit Sub
                End If
            Next
        End If
        If Not IsNothing(ListBox1.SelectedItem) Then
            Dim aa = "↓" + ListBox1.SelectedItem
            ListBox2.Items.Add(aa)
        End If
    End Sub
    Sub ListBox2Remove()
        If ListBox2.SelectedIndex <> -1 Then
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
        End If
    End Sub
    Sub ListBox2change()
        Dim tmp As Object = ""
        If ListBox2.SelectedItem.indexOf("↓") > -1 Then
            tmp = "↑" + Mid(ListBox2.SelectedItem, 2, Len(ListBox2.SelectedItem))
        Else
            tmp = "↓" + Mid(ListBox2.SelectedItem, 2, Len(ListBox2.SelectedItem))
        End If

        Dim selectindex = ListBox2.SelectedIndex
        ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
        ListBox2.Items.Insert(selectindex, tmp)
        ListBox2.SelectedIndex = selectindex
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Search_mode()
        CheckBox1.Checked = False
    End Sub
    Sub Search_mode()
        '清空字串
        SQL_Str = ""
        If Aging.Created = True Then
            SQL_Str = "Select TOP(" & DataNum_limit.Text & ") RTRIM(Aging_No) As 工單號碼, RTrim(Aging_Type) As 機種, "
            SQL_Str &= "RTRIM(Aging_X1) As 投入, RTrim(Aging_X2) As 產出, RTrim(Aging_X3) As 不良, "
            SQL_Str &= "RTrim(User_Name) As 建立人員, RTrim(SYS_UID) As 修改人員, Aging_Date As 建立日期, "
            SQL_Str &= "SYS_Date As 修改日期 FROM Aging_H "
        ElseIf EX_Report.Created = True Then
            SQL_Str = "Select TOP(" & DataNum_limit.Text & ") RTRIM(Aging_No) As 工單號碼, RTRIM(Aging_No2) As 燈板號碼, "
            SQL_Str &= "Car_No As 抽氣台車, RTRIM(Car_No4) As 預注值, RTRIM(Car_No5) As 平衡值, RTRIM(Car_No2) As 位置, "
            SQL_Str &= "RTRIM(Car_No6) As 線別, Car_No3 As 圈數, RTRIM(Car_status) As 不良原因, RTRIM(remark) As 備註, "
            SQL_Str &= "EXT_build As 建立人員, SYS_UID As 修改人員, Aging_D_Date As 建立日期, SYS_Date As 修改日期 "
            SQL_Str &= "FROM Aging_D "
        End If

        Dim Sqlstr_ = SQLStr()
        If Sqlstr_ IsNot "" Then
            SQL_Str = SQL_Str & Sqlstr_
        Else
            MessageBox.Show("希望您能夠先輸入您要找的資料" & vbCrLf, "設定查詢條件", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If

        If Aging.Created = True Then
            Aging.DataGridView1.Columns.Clear()
            Aging.DataGridView2.Columns.Clear()
            Aging.DataGridView3.Columns.Clear()

            Aging.TabControl1.SelectedTab = Aging.TabControl1.TabPages(1)   '切換到資料欄位頁
            Aging.Load_AgingNO(SQL_Str)

            MainForm.edit_ToolStripBut.Enabled = True

            '刪除權限控制
            If MainForm.Aging_Chk_D = "1" Then
                MainForm.del_ToolStripBut.Enabled = True
            Else
                MainForm.del_ToolStripBut.Enabled = False
            End If
        ElseIf EX_Report.Created = True Then
            If SQL_Str.IndexOf("ORDER BY") = -1 Then
                SQL_Str &= " ORDER BY 工單號碼 ASC"
            End If
            EX_Report.SQLData(SQL_Str)
        End If

            Me.Close()
    End Sub
    Function SQLStr() As String
        Dim SQL_str_ As String = ""
        If (Me.TabControl1.SelectedTab.Text = "進階選項" And TextBox4.Text IsNot "") _
            Or (Me.TabControl1.SelectedTab.Text = "單身設定" And TextBox6.Text IsNot "" And CheckBox1.Checked = True) Then
            'Me.TabControl1.SelectedIndex    '取得目前在第幾個Page(Type:Integer) 
            'Me.TabControl1.SelectedTab      '取得目前選取的Page(Type:TabPage) 
            'MsgBox(Me.TabControl1.SelectedTab.Text)
            'MsgBox(SQL_Str + TextBox4.Text)
            'TextBox4.Text = SQL_Str + TextBox4.Text
            Dim txt
            Dim name() = {"Aging_No", "Aging_Type", "User_Name", "SYS_UID", "Aging_Date", "SYS_Date",
                          "Aging_X1", "Aging_X2", "Aging_X3"}
            Dim AsName() = {"工單號碼", "機種", "建立人員", "修改人員", "建立日期", "修改日期",
                          "投入", "產出", "不良"}
            txt = TextBox4.Text.Replace(vbCr, " ")
            txt = txt.Replace(vbLf, "-")

            Console.WriteLine("txt : {0}", txt)
            Dim strResult()
            strResult = txt.Trim().Split("-")
            SQL_str_ = "WHERE ("
            ' === 顯示 ===
            For i As Integer = 0 To strResult.Length - 2
                'Me.TextBox4.Text += strResult(i) + Environment.NewLine
                For j As Integer = 0 To name.Length - 1
                    If strResult(i).indexOf(AsName(j)) > -1 Then
                        strResult(i) = strResult(i).Replace(AsName(j), name(j))
                        Exit For
                    End If
                Next
                SQL_str_ += strResult(i)
                Console.WriteLine("工單號碼 : {0}", strResult(i))
                Console.WriteLine("SQL_str_ : {0}", SQL_str_)
            Next

            If CheckBox1.Checked = True Then
                SQL_str_ += " AND ("
                txt = TextBox6.Text.Replace(vbCr, " ")
                txt = txt.Replace(vbLf, "-")
                strResult = txt.Trim().Split("-")
                For i As Integer = 0 To strResult.Length - 2
                    SQL_str_ += strResult(i)
                Next

                SQL_str_ += ")"

            End If

            SQL_str_ += ")"

            If ListBox2.Text <> "" Then
                SQL_str_ += " ORDER BY "
                Dim tmp
                For i = 0 To ListBox2.Items.Count - 1
                    If ListBox2.Items.Item(i).indexOf("↓") > -1 Then
                        tmp = Mid(ListBox2.Items.Item(i).ToString, 2, Len(ListBox2.Items.Item(i).ToString)) + " DESC"
                    Else
                        tmp = Mid(ListBox2.Items.Item(i).ToString, 2, Len(ListBox2.Items.Item(i).ToString)) + " ASC"
                    End If

                    SQL_str_ += tmp
                    If i <> ListBox2.Items.Count - 1 Then
                        SQL_str_ += ", "
                    End If
                Next

            End If
        Else


            If NO_TextBox.Text <> "" Then
                SQL_str_ &= "WHERE Aging_No "
                Select Case NO_ComboBox.SelectedIndex
                    Case 0, 1, 2, 3, 4
                        SQL_str_ &= NO_ComboBox.Text & " '" & NO_TextBox.Text & "'"
                    Case 5, 7              '[EL]=> E:實驗單 / L:正常單 ;因為資料庫Aging_No 字數關係，後面會多空格，所以當查詢%LIKE 時會查詢不到，故改為%LIKE%
                        If MainForm.Aging_Chk = 1 Or MainForm.Aging_Chk = 2 Or MainForm.Aging_Chk = 3 Or EX_Report.Created = True Then
                            If NO_TextBox.Text.IndexOf("E") > -1 Or NO_TextBox.Text.IndexOf("L") > -1 Then
                                SQL_str_ &= "LIKE '%" & NO_TextBox.Text & "%'"
                            Else
                                SQL_str_ &= "LIKE '[EL]%" & NO_TextBox.Text & "%'"
                            End If
                        ElseIf MainForm.Aging_Chk = 4 Then
                            If NO_TextBox.Text.IndexOf("H") > -1 Then
                                SQL_str_ &= "LIKE '%" & NO_TextBox.Text & "%'"
                            Else
                                SQL_str_ &= "LIKE '[H]%" & NO_TextBox.Text & "%'"
                            End If
                        End If
                    Case 6
                        If MainForm.Aging_Chk = 1 Or MainForm.Aging_Chk = 2 Or MainForm.Aging_Chk = 3 Or EX_Report.Created = True Then
                            If NO_TextBox.Text.IndexOf("E") > -1 Or NO_TextBox.Text.IndexOf("L") > -1 Then
                                SQL_str_ &= "LIKE '" & NO_TextBox.Text & "%'"
                            Else
                                SQL_str_ &= "LIKE '[EL]" & NO_TextBox.Text & "%'"
                            End If
                        ElseIf MainForm.Aging_Chk = 4 Then
                            If NO_TextBox.Text.IndexOf("H") > -1 Then
                                SQL_str_ &= "LIKE '" & NO_TextBox.Text & "%'"
                            Else
                                SQL_str_ &= "LIKE '[H]" & NO_TextBox.Text & "%'"
                            End If
                        End If
                End Select
            End If

            If Type_TextBox.Text <> "" Then
                If NO_TextBox.Text = "" Then
                    SQL_str_ &= "WHERE Aging_Type "
                Else
                    SQL_str_ &= "AND Aging_Type "
                End If

                Select Case Type_ComboBox.SelectedIndex
                    Case 0, 1, 2, 3, 4
                        SQL_str_ &= Type_ComboBox.Text & " '" & Type_TextBox.Text & "'"
                    Case 5, 7              '[EL]=> E:實驗單 / L:正常單 ;因為資料庫Aging_No 字數關係，後面會多空格，所以當查詢%LIKE 時會查詢不到，故改為%LIKE%
                        If MainForm.Aging_Chk = 1 Or MainForm.Aging_Chk = 2 Or MainForm.Aging_Chk = 3 Or EX_Report.Created = True Then
                            If Type_TextBox.Text.IndexOf("E") > -1 Or Type_TextBox.Text.IndexOf("L") > -1 Then
                                SQL_str_ &= "LIKE '%" & Type_TextBox.Text & "%'"
                            Else
                                SQL_str_ &= "LIKE '[EL]%" & Type_TextBox.Text & "%'"
                            End If
                        ElseIf MainForm.Aging_Chk = 4 Then
                            If Type_TextBox.Text.IndexOf("H") > -1 Then
                                SQL_str_ &= "LIKE '%" & Type_TextBox.Text & "%'"
                            Else
                                SQL_str_ &= "LIKE '[H]%" & Type_TextBox.Text & "%'"
                            End If
                        End If
                    Case 6
                        If MainForm.Aging_Chk = 1 Or MainForm.Aging_Chk = 2 Or MainForm.Aging_Chk = 3 Or EX_Report.Created = True Then
                            If Type_TextBox.Text.IndexOf("E") > -1 Or Type_TextBox.Text.IndexOf("L") > -1 Then
                                SQL_str_ &= "LIKE '" & Type_TextBox.Text & "%'"
                            Else
                                SQL_str_ &= "LIKE '[EL]" & Type_TextBox.Text & "%'"
                            End If
                        ElseIf MainForm.Aging_Chk = 4 Then
                            If Type_TextBox.Text.IndexOf("H") > -1 Then
                                SQL_str_ &= "LIKE '" & Type_TextBox.Text & "%'"
                            Else
                                SQL_str_ &= "LIKE '[H]" & Type_TextBox.Text & "%'"
                            End If
                        End If
                End Select
            End If
        End If
        Return SQL_str_
    End Function
    Private Sub Txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles NO_ComboBox.KeyPress, Type_ComboBox.KeyPress, ComboBox3.KeyPress, ComboBox4.KeyPress, ComboBox5.KeyPress,
        ComboBox6.KeyPress
        '限制TextBox 不能能輸入文字
        e.KeyChar = Nothing
        ''------------------------------------------------------------------
    End Sub
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        '自動捲到最後一行
        TextBox4.SelectionStart = TextBox4.TextLength
        'Scrolls the contents of the control to the current caret position.
        TextBox4.ScrollToCaret()
    End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        '自動捲到最後一行
        TextBox4.SelectionStart = TextBox4.TextLength
        'Scrolls the contents of the control to the current caret position.
        TextBox4.ScrollToCaret()
    End Sub
    Private Sub Clean_Button1_Click(sender As Object, e As EventArgs) Handles Clean_Button1.Click
        TextBox4.Text = ""
        GroupBox1.Enabled = False
    End Sub
    Private Sub Clean_Button2_Click(sender As Object, e As EventArgs) Handles Clean_Button2.Click
        TextBox6.Text = ""
        GroupBox2.Enabled = False
    End Sub
    Private Sub cancel_Button_Click(sender As Object, e As EventArgs) Handles cancel_Button.Click
        Me.Close()
    End Sub
    Private Sub Right_Button_Click(sender As Object, e As EventArgs) Handles Right_Button.Click
        ListBox2Add()
    End Sub
    Private Sub Left_Button_Click(sender As Object, e As EventArgs) Handles Left_Button.Click
        ListBox2Remove()
    End Sub
    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.MouseDoubleClick
        ListBox2Add()
    End Sub
    Private Sub ListBox2_DoubleClick(sender As Object, e As EventArgs) Handles ListBox2.MouseDoubleClick
        ListBox2Remove()
    End Sub
    Private Sub ListBox2_Click(sender As Object, e As EventArgs) Handles ListBox2.MouseClick
        ListBox2change()
    End Sub

End Class