<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchData
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchData))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.DataNum_limit = New System.Windows.Forms.ToolStripComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Type_ComboBox = New System.Windows.Forms.ComboBox()
        Me.NO_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Type_TextBox = New System.Windows.Forms.TextBox()
        Me.NO_TextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Left_Button = New System.Windows.Forms.Button()
        Me.Right_Button = New System.Windows.Forms.Button()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.ADD_Button1 = New System.Windows.Forms.Button()
        Me.Clean_Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.OR_RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.AND_RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.ADD_Button2 = New System.Windows.Forms.Button()
        Me.Clean_Button2 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.OR_RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.AND_RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1, Me.DataNum_limit})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(422, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.ReadOnly = True
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(95, 24)
        Me.ToolStripTextBox1.Text = "總資料筆數限制"
        '
        'DataNum_limit
        '
        Me.DataNum_limit.Items.AddRange(New Object() {"30", "60", "90", "120", "150", "200", "250", "300", "350", "400", "450", "500"})
        Me.DataNum_limit.Name = "DataNum_limit"
        Me.DataNum_limit.Size = New System.Drawing.Size(75, 24)
        Me.DataNum_limit.Text = "30"
        '
        'TabControl1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TabControl1, 2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(416, 399)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Type_ComboBox)
        Me.TabPage1.Controls.Add(Me.NO_ComboBox)
        Me.TabPage1.Controls.Add(Me.Type_TextBox)
        Me.TabPage1.Controls.Add(Me.NO_TextBox)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(408, 366)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "一般選項"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Type_ComboBox
        '
        Me.Type_ComboBox.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Type_ComboBox.FormattingEnabled = True
        Me.Type_ComboBox.Items.AddRange(New Object() {"<", "<=", "=", ">=", ">", "%like%", "like%", "%like"})
        Me.Type_ComboBox.Location = New System.Drawing.Point(111, 60)
        Me.Type_ComboBox.Name = "Type_ComboBox"
        Me.Type_ComboBox.Size = New System.Drawing.Size(77, 27)
        Me.Type_ComboBox.TabIndex = 11
        Me.Type_ComboBox.Text = "="
        '
        'NO_ComboBox
        '
        Me.NO_ComboBox.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.NO_ComboBox.FormattingEnabled = True
        Me.NO_ComboBox.Items.AddRange(New Object() {"<", "<=", "=", ">=", ">", "%like%", "like%", "%like"})
        Me.NO_ComboBox.Location = New System.Drawing.Point(111, 23)
        Me.NO_ComboBox.Name = "NO_ComboBox"
        Me.NO_ComboBox.Size = New System.Drawing.Size(77, 27)
        Me.NO_ComboBox.TabIndex = 10
        Me.NO_ComboBox.Text = "="
        '
        'Type_TextBox
        '
        Me.Type_TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Type_TextBox.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Type_TextBox.Location = New System.Drawing.Point(204, 60)
        Me.Type_TextBox.Name = "Type_TextBox"
        Me.Type_TextBox.Size = New System.Drawing.Size(198, 27)
        Me.Type_TextBox.TabIndex = 9
        '
        'NO_TextBox
        '
        Me.NO_TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.NO_TextBox.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.NO_TextBox.Location = New System.Drawing.Point(204, 23)
        Me.NO_TextBox.Name = "NO_TextBox"
        Me.NO_TextBox.Size = New System.Drawing.Size(198, 27)
        Me.NO_TextBox.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(64, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "機種"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "工單號碼"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Left_Button)
        Me.TabPage2.Controls.Add(Me.Right_Button)
        Me.TabPage2.Controls.Add(Me.ListBox2)
        Me.TabPage2.Controls.Add(Me.ListBox1)
        Me.TabPage2.Controls.Add(Me.CheckBox1)
        Me.TabPage2.Controls.Add(Me.TextBox4)
        Me.TabPage2.Controls.Add(Me.ADD_Button1)
        Me.TabPage2.Controls.Add(Me.Clean_Button1)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.TextBox3)
        Me.TabPage2.Controls.Add(Me.ComboBox4)
        Me.TabPage2.Controls.Add(Me.ComboBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(408, 366)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "進階選項"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 236)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "設定排序欄位"
        '
        'Left_Button
        '
        Me.Left_Button.Image = CType(resources.GetObject("Left_Button.Image"), System.Drawing.Image)
        Me.Left_Button.Location = New System.Drawing.Point(191, 311)
        Me.Left_Button.Name = "Left_Button"
        Me.Left_Button.Size = New System.Drawing.Size(25, 32)
        Me.Left_Button.TabIndex = 11
        Me.Left_Button.UseVisualStyleBackColor = True
        '
        'Right_Button
        '
        Me.Right_Button.Image = CType(resources.GetObject("Right_Button.Image"), System.Drawing.Image)
        Me.Right_Button.Location = New System.Drawing.Point(192, 269)
        Me.Right_Button.Name = "Right_Button"
        Me.Right_Button.Size = New System.Drawing.Size(25, 32)
        Me.Right_Button.TabIndex = 10
        Me.Right_Button.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 17
        Me.ListBox2.Location = New System.Drawing.Point(222, 255)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(180, 106)
        Me.ListBox2.TabIndex = 9
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 17
        Me.ListBox1.Items.AddRange(New Object() {"工單號碼", "建立日期", "機種", "建立人員", "修改人員", "建立日期", "修改日期", "投入", "產出", "不良"})
        Me.ListBox1.Location = New System.Drawing.Point(6, 255)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(180, 106)
        Me.ListBox1.TabIndex = 8
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(6, 199)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(118, 21)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "含單身篩選條件"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(6, 89)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox4.Size = New System.Drawing.Size(396, 104)
        Me.TextBox4.TabIndex = 6
        '
        'ADD_Button1
        '
        Me.ADD_Button1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ADD_Button1.Location = New System.Drawing.Point(297, 53)
        Me.ADD_Button1.Name = "ADD_Button1"
        Me.ADD_Button1.Size = New System.Drawing.Size(84, 30)
        Me.ADD_Button1.TabIndex = 5
        Me.ADD_Button1.Text = "加入"
        Me.ADD_Button1.UseVisualStyleBackColor = True
        '
        'Clean_Button1
        '
        Me.Clean_Button1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Clean_Button1.Location = New System.Drawing.Point(199, 53)
        Me.Clean_Button1.Name = "Clean_Button1"
        Me.Clean_Button1.Size = New System.Drawing.Size(84, 30)
        Me.Clean_Button1.TabIndex = 4
        Me.Clean_Button1.Text = "清除"
        Me.Clean_Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OR_RadioButton1)
        Me.GroupBox1.Controls.Add(Me.AND_RadioButton1)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 44)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "條件關係"
        '
        'OR_RadioButton1
        '
        Me.OR_RadioButton1.AutoSize = True
        Me.OR_RadioButton1.Location = New System.Drawing.Point(74, 17)
        Me.OR_RadioButton1.Name = "OR_RadioButton1"
        Me.OR_RadioButton1.Size = New System.Drawing.Size(49, 23)
        Me.OR_RadioButton1.TabIndex = 5
        Me.OR_RadioButton1.Text = "OR"
        Me.OR_RadioButton1.UseVisualStyleBackColor = True
        '
        'AND_RadioButton1
        '
        Me.AND_RadioButton1.AutoSize = True
        Me.AND_RadioButton1.Checked = True
        Me.AND_RadioButton1.Location = New System.Drawing.Point(8, 17)
        Me.AND_RadioButton1.Name = "AND_RadioButton1"
        Me.AND_RadioButton1.Size = New System.Drawing.Size(60, 23)
        Me.AND_RadioButton1.TabIndex = 4
        Me.AND_RadioButton1.TabStop = True
        Me.AND_RadioButton1.Text = "AND"
        Me.AND_RadioButton1.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox3.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(253, 7)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(149, 25)
        Me.TextBox3.TabIndex = 2
        '
        'ComboBox4
        '
        Me.ComboBox4.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"=", ">=", "<=", ">", "<", "%like%", "like%", "%like"})
        Me.ComboBox4.Location = New System.Drawing.Point(183, 7)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(64, 25)
        Me.ComboBox4.TabIndex = 1
        Me.ComboBox4.Text = "="
        '
        'ComboBox3
        '
        Me.ComboBox3.DisplayMember = "1213"
        Me.ComboBox3.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"工單號碼", "建立日期", "機種", "建立人員", "修改人員", "建立日期", "修改日期", "投入", "產出", "不良"})
        Me.ComboBox3.Location = New System.Drawing.Point(6, 6)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(171, 25)
        Me.ComboBox3.TabIndex = 0
        Me.ComboBox3.Text = "工單號碼"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TextBox5)
        Me.TabPage3.Controls.Add(Me.ComboBox6)
        Me.TabPage3.Controls.Add(Me.ComboBox5)
        Me.TabPage3.Controls.Add(Me.TextBox6)
        Me.TabPage3.Controls.Add(Me.ADD_Button2)
        Me.TabPage3.Controls.Add(Me.Clean_Button2)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(408, 366)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "單身設定"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox5.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(253, 7)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(149, 25)
        Me.TextBox5.TabIndex = 9
        '
        'ComboBox6
        '
        Me.ComboBox6.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Items.AddRange(New Object() {"=", ">=", "<=", ">", "<", "%like%", "like%", "%like"})
        Me.ComboBox6.Location = New System.Drawing.Point(183, 7)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(64, 25)
        Me.ComboBox6.TabIndex = 8
        Me.ComboBox6.Text = "="
        '
        'ComboBox5
        '
        Me.ComboBox5.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Items.AddRange(New Object() {"成燈碼", "燈板號碼", "日期", "抽氣台車", "預注值", "平衡值", "位置", "線別", "圈數", "不良原因", "框架編號", "Inv編號", "Aging判定", "功率Watt", "判定等級", "備註", "修改者"})
        Me.ComboBox5.Location = New System.Drawing.Point(6, 6)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(171, 25)
        Me.ComboBox5.TabIndex = 7
        Me.ComboBox5.Text = "成燈碼"
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(6, 89)
        Me.TextBox6.Multiline = True
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox6.Size = New System.Drawing.Size(396, 268)
        Me.TextBox6.TabIndex = 13
        '
        'ADD_Button2
        '
        Me.ADD_Button2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ADD_Button2.Location = New System.Drawing.Point(297, 53)
        Me.ADD_Button2.Name = "ADD_Button2"
        Me.ADD_Button2.Size = New System.Drawing.Size(84, 30)
        Me.ADD_Button2.TabIndex = 12
        Me.ADD_Button2.Text = "加入"
        Me.ADD_Button2.UseVisualStyleBackColor = True
        '
        'Clean_Button2
        '
        Me.Clean_Button2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Clean_Button2.Location = New System.Drawing.Point(199, 53)
        Me.Clean_Button2.Name = "Clean_Button2"
        Me.Clean_Button2.Size = New System.Drawing.Size(84, 30)
        Me.Clean_Button2.TabIndex = 11
        Me.Clean_Button2.Text = "清除"
        Me.Clean_Button2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.OR_RadioButton2)
        Me.GroupBox2.Controls.Add(Me.AND_RadioButton2)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(15, 37)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(152, 44)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "條件關係"
        '
        'OR_RadioButton2
        '
        Me.OR_RadioButton2.AutoSize = True
        Me.OR_RadioButton2.Location = New System.Drawing.Point(74, 17)
        Me.OR_RadioButton2.Name = "OR_RadioButton2"
        Me.OR_RadioButton2.Size = New System.Drawing.Size(49, 23)
        Me.OR_RadioButton2.TabIndex = 5
        Me.OR_RadioButton2.Text = "OR"
        Me.OR_RadioButton2.UseVisualStyleBackColor = True
        '
        'AND_RadioButton2
        '
        Me.AND_RadioButton2.AutoSize = True
        Me.AND_RadioButton2.Checked = True
        Me.AND_RadioButton2.Location = New System.Drawing.Point(8, 17)
        Me.AND_RadioButton2.Name = "AND_RadioButton2"
        Me.AND_RadioButton2.Size = New System.Drawing.Size(60, 23)
        Me.AND_RadioButton2.TabIndex = 4
        Me.AND_RadioButton2.TabStop = True
        Me.AND_RadioButton2.Text = "AND"
        Me.AND_RadioButton2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cancel_Button, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 28)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(422, 455)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'cancel_Button
        '
        Me.cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cancel_Button.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cancel_Button.Image = CType(resources.GetObject("cancel_Button.Image"), System.Drawing.Image)
        Me.cancel_Button.Location = New System.Drawing.Point(279, 411)
        Me.cancel_Button.Name = "cancel_Button"
        Me.cancel_Button.Size = New System.Drawing.Size(75, 37)
        Me.cancel_Button.TabIndex = 3
        Me.cancel_Button.Text = "取消"
        Me.cancel_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cancel_Button.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.OK_Button.Image = CType(resources.GetObject("OK_Button.Image"), System.Drawing.Image)
        Me.OK_Button.Location = New System.Drawing.Point(68, 411)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(75, 37)
        Me.OK_Button.TabIndex = 2
        Me.OK_Button.Text = "確定"
        Me.OK_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'SearchData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 483)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SearchData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "設定查詢條件"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents DataNum_limit As ToolStripComboBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents cancel_Button As Button
    Friend WithEvents OK_Button As Button
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Type_ComboBox As ComboBox
    Friend WithEvents NO_ComboBox As ComboBox
    Friend WithEvents Type_TextBox As TextBox
    Friend WithEvents NO_TextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label3 As Label
    Friend WithEvents Left_Button As Button
    Friend WithEvents Right_Button As Button
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents ADD_Button1 As Button
    Friend WithEvents Clean_Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents OR_RadioButton1 As RadioButton
    Friend WithEvents AND_RadioButton1 As RadioButton
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents ComboBox6 As ComboBox
    Friend WithEvents ComboBox5 As ComboBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents ADD_Button2 As Button
    Friend WithEvents Clean_Button2 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents OR_RadioButton2 As RadioButton
    Friend WithEvents AND_RadioButton2 As RadioButton
End Class
