<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin
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
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.User_ID = New System.Windows.Forms.TextBox()
        Me.User_Name = New System.Windows.Forms.TextBox()
        Me.User_pass = New System.Windows.Forms.TextBox()
        Me.Aging = New System.Windows.Forms.ComboBox()
        Me.Aging_Del = New System.Windows.Forms.ComboBox()
        Me.PRQA = New System.Windows.Forms.ComboBox()
        Me.PRQA_CF = New System.Windows.Forms.ComboBox()
        Me.PRCS = New System.Windows.Forms.ComboBox()
        Me.Aging_LD = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.management = New System.Windows.Forms.ComboBox()
        Me.LD_Name = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LD = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(30, 29)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(100, 20)
        Me.ComboBox1.TabIndex = 18
        '
        'User_ID
        '
        Me.User_ID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.User_ID.Enabled = False
        Me.User_ID.Location = New System.Drawing.Point(163, 27)
        Me.User_ID.MaxLength = 4
        Me.User_ID.Name = "User_ID"
        Me.User_ID.Size = New System.Drawing.Size(104, 22)
        Me.User_ID.TabIndex = 19
        '
        'User_Name
        '
        Me.User_Name.Dock = System.Windows.Forms.DockStyle.Fill
        Me.User_Name.Enabled = False
        Me.User_Name.Location = New System.Drawing.Point(273, 27)
        Me.User_Name.Name = "User_Name"
        Me.User_Name.Size = New System.Drawing.Size(104, 22)
        Me.User_Name.TabIndex = 20
        '
        'User_pass
        '
        Me.User_pass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.User_pass.Enabled = False
        Me.User_pass.Location = New System.Drawing.Point(383, 27)
        Me.User_pass.Name = "User_pass"
        Me.User_pass.Size = New System.Drawing.Size(104, 22)
        Me.User_pass.TabIndex = 21
        '
        'Aging
        '
        Me.Aging.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Aging.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Aging.Enabled = False
        Me.Aging.FormattingEnabled = True
        Me.Aging.Items.AddRange(New Object() {"否", "是"})
        Me.Aging.Location = New System.Drawing.Point(84, 30)
        Me.Aging.Name = "Aging"
        Me.Aging.Size = New System.Drawing.Size(75, 20)
        Me.Aging.TabIndex = 22
        '
        'Aging_Del
        '
        Me.Aging_Del.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Aging_Del.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Aging_Del.Enabled = False
        Me.Aging_Del.FormattingEnabled = True
        Me.Aging_Del.Items.AddRange(New Object() {"否", "是"})
        Me.Aging_Del.Location = New System.Drawing.Point(165, 30)
        Me.Aging_Del.Name = "Aging_Del"
        Me.Aging_Del.Size = New System.Drawing.Size(74, 20)
        Me.Aging_Del.TabIndex = 23
        '
        'PRQA
        '
        Me.PRQA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PRQA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PRQA.Enabled = False
        Me.PRQA.FormattingEnabled = True
        Me.PRQA.Items.AddRange(New Object() {"否", "是"})
        Me.PRQA.Location = New System.Drawing.Point(84, 27)
        Me.PRQA.Name = "PRQA"
        Me.PRQA.Size = New System.Drawing.Size(75, 20)
        Me.PRQA.TabIndex = 24
        '
        'PRQA_CF
        '
        Me.PRQA_CF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PRQA_CF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PRQA_CF.Enabled = False
        Me.PRQA_CF.FormattingEnabled = True
        Me.PRQA_CF.Items.AddRange(New Object() {"否", "是"})
        Me.PRQA_CF.Location = New System.Drawing.Point(3, 27)
        Me.PRQA_CF.Name = "PRQA_CF"
        Me.PRQA_CF.Size = New System.Drawing.Size(75, 20)
        Me.PRQA_CF.TabIndex = 25
        '
        'PRCS
        '
        Me.PRCS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PRCS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PRCS.Enabled = False
        Me.PRCS.FormattingEnabled = True
        Me.PRCS.Items.AddRange(New Object() {"否", "是"})
        Me.PRCS.Location = New System.Drawing.Point(165, 27)
        Me.PRCS.Name = "PRCS"
        Me.PRCS.Size = New System.Drawing.Size(75, 20)
        Me.PRCS.TabIndex = 26
        '
        'Aging_LD
        '
        Me.Aging_LD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Aging_LD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Aging_LD.Enabled = False
        Me.Aging_LD.FormattingEnabled = True
        Me.Aging_LD.Items.AddRange(New Object() {"否", "是"})
        Me.Aging_LD.Location = New System.Drawing.Point(3, 30)
        Me.Aging_LD.Name = "Aging_LD"
        Me.Aging_LD.Size = New System.Drawing.Size(75, 20)
        Me.Aging_LD.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(194, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 20)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "工號"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(304, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 20)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "姓名"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(414, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 20)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "密碼"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(84, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 20)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "生產人員"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label5, 2)
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(165, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(177, 20)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "刪除權限(AGING 資料)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(84, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 20)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "品保人員"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 20)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "品保主管"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(165, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 20)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "客服人員"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label9.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 20)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "生產主管"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(153, 20)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "選擇所要查詢的員工"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(494, 4)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 20)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "帳號管理"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'management
        '
        Me.management.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.management.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.management.Enabled = False
        Me.management.FormattingEnabled = True
        Me.management.Items.AddRange(New Object() {"否", "是"})
        Me.management.Location = New System.Drawing.Point(493, 29)
        Me.management.Name = "management"
        Me.management.Size = New System.Drawing.Size(75, 20)
        Me.management.TabIndex = 44
        '
        'LD_Name
        '
        Me.LD_Name.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LD_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LD_Name.Enabled = False
        Me.LD_Name.FormattingEnabled = True
        Me.LD_Name.Items.AddRange(New Object() {"否", "是"})
        Me.LD_Name.Location = New System.Drawing.Point(659, 29)
        Me.LD_Name.Name = "LD_Name"
        Me.LD_Name.Size = New System.Drawing.Size(100, 20)
        Me.LD_Name.TabIndex = 47
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(672, 4)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 20)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "上級主管"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LD, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LD_Name, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.User_pass, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.User_Name, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.User_ID, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.management, 4, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.15385!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.84615!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(766, 54)
        Me.TableLayoutPanel1.TabIndex = 49
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(591, 4)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 20)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "主管"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LD
        '
        Me.LD.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LD.Enabled = False
        Me.LD.FormattingEnabled = True
        Me.LD.Items.AddRange(New Object() {"否", "是"})
        Me.LD.Location = New System.Drawing.Point(574, 29)
        Me.LD.Name = "LD"
        Me.LD.Size = New System.Drawing.Size(75, 20)
        Me.LD.TabIndex = 53
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Aging_LD, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Aging, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Aging_Del, 2, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 63)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(345, 54)
        Me.TableLayoutPanel2.TabIndex = 50
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.PRQA_CF, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label6, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.PRQA, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label8, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.PRCS, 2, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 123)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.52941!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.47059!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(243, 51)
        Me.TableLayoutPanel3.TabIndex = 51
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.DataGridView1, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(886, 565)
        Me.TableLayoutPanel4.TabIndex = 52
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 183)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(880, 379)
        Me.DataGridView1.TabIndex = 18
        '
        'Admin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(886, 565)
        Me.Controls.Add(Me.TableLayoutPanel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Admin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "人員管理系統"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents User_ID As System.Windows.Forms.TextBox
    Friend WithEvents User_Name As System.Windows.Forms.TextBox
    Friend WithEvents User_pass As System.Windows.Forms.TextBox
    Friend WithEvents Aging As System.Windows.Forms.ComboBox
    Friend WithEvents Aging_Del As System.Windows.Forms.ComboBox
    Friend WithEvents PRQA As System.Windows.Forms.ComboBox
    Friend WithEvents PRQA_CF As System.Windows.Forms.ComboBox
    Friend WithEvents PRCS As System.Windows.Forms.ComboBox
    Friend WithEvents Aging_LD As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As Label
    Friend WithEvents management As ComboBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents LD_Name As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label13 As Label
    Friend WithEvents LD As ComboBox
    Friend WithEvents BindingSource1 As BindingSource
End Class
