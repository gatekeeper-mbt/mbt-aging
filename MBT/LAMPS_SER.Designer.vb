<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LAMPS_SER
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LAMPS_SER))
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Txt_ampere3 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Txt_Ballast_NO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_LAMPS_NO = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Txt_D_Date = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Txt_ampere2 = New System.Windows.Forms.TextBox()
        Me.Txt_voltage2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_determine = New System.Windows.Forms.ComboBox()
        Me.Txt_remark = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Cmb_lv = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Txt_watt = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Txt_pre4 = New System.Windows.Forms.TextBox()
        Me.Txt_pre3 = New System.Windows.Forms.TextBox()
        Me.Txt_pre2 = New System.Windows.Forms.TextBox()
        Me.Txt_pre1 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Cmb_Inv_No = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Cmb_frame_No = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Txt_ampere = New System.Windows.Forms.TextBox()
        Me.Txt_voltage = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Cmb_Car = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Txt_No2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Cmb_Car6 = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Car_balance = New System.Windows.Forms.TextBox()
        Me.Car_Pre_injection = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Cmb_Car3 = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Cmb_Car2 = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Car_status = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(838, 352)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 34
        Me.Cancel.Text = "取消(&C)"
        '
        'Txt_ampere3
        '
        Me.Txt_ampere3.Location = New System.Drawing.Point(310, 37)
        Me.Txt_ampere3.MaxLength = 6
        Me.Txt_ampere3.Name = "Txt_ampere3"
        Me.Txt_ampere3.ReadOnly = True
        Me.Txt_ampere3.Size = New System.Drawing.Size(48, 22)
        Me.Txt_ampere3.TabIndex = 2
        Me.Txt_ampere3.Text = "000.00"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(304, 22)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(65, 12)
        Me.Label28.TabIndex = 40
        Me.Label28.Text = "實際功率值"
        '
        'Txt_Ballast_NO
        '
        Me.Txt_Ballast_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Ballast_NO.Location = New System.Drawing.Point(144, 38)
        Me.Txt_Ballast_NO.MaxLength = 20
        Me.Txt_Ballast_NO.Name = "Txt_Ballast_NO"
        Me.Txt_Ballast_NO.ReadOnly = True
        Me.Txt_Ballast_NO.Size = New System.Drawing.Size(153, 22)
        Me.Txt_Ballast_NO.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(196, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "安定器號碼"
        '
        'Txt_LAMPS_NO
        '
        Me.Txt_LAMPS_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_LAMPS_NO.Location = New System.Drawing.Point(19, 38)
        Me.Txt_LAMPS_NO.MaxLength = 15
        Me.Txt_LAMPS_NO.Name = "Txt_LAMPS_NO"
        Me.Txt_LAMPS_NO.Size = New System.Drawing.Size(118, 22)
        Me.Txt_LAMPS_NO.TabIndex = 0
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(56, 22)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(41, 12)
        Me.Label32.TabIndex = 38
        Me.Label32.Text = "成燈碼"
        '
        'Txt_D_Date
        '
        Me.Txt_D_Date.Location = New System.Drawing.Point(450, 95)
        Me.Txt_D_Date.MaxLength = 10
        Me.Txt_D_Date.Name = "Txt_D_Date"
        Me.Txt_D_Date.ReadOnly = True
        Me.Txt_D_Date.Size = New System.Drawing.Size(100, 22)
        Me.Txt_D_Date.TabIndex = 75
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(452, 78)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(35, 12)
        Me.Label31.TabIndex = 108
        Me.Label31.Text = "日  期"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(319, 437)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(8, 12)
        Me.Label27.TabIndex = 105
        Me.Label27.Text = "/"
        '
        'Txt_ampere2
        '
        Me.Txt_ampere2.Location = New System.Drawing.Point(329, 432)
        Me.Txt_ampere2.MaxLength = 4
        Me.Txt_ampere2.Name = "Txt_ampere2"
        Me.Txt_ampere2.ReadOnly = True
        Me.Txt_ampere2.Size = New System.Drawing.Size(28, 22)
        Me.Txt_ampere2.TabIndex = 89
        '
        'Txt_voltage2
        '
        Me.Txt_voltage2.Location = New System.Drawing.Point(285, 432)
        Me.Txt_voltage2.MaxLength = 5
        Me.Txt_voltage2.Name = "Txt_voltage2"
        Me.Txt_voltage2.ReadOnly = True
        Me.Txt_voltage2.Size = New System.Drawing.Size(32, 22)
        Me.Txt_voltage2.TabIndex = 88
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(286, 418)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 12)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "管電壓/電流"
        '
        'Txt_determine
        '
        Me.Txt_determine.Enabled = False
        Me.Txt_determine.FormattingEnabled = True
        Me.Txt_determine.Location = New System.Drawing.Point(725, 95)
        Me.Txt_determine.Name = "Txt_determine"
        Me.Txt_determine.Size = New System.Drawing.Size(80, 20)
        Me.Txt_determine.TabIndex = 82
        '
        'Txt_remark
        '
        Me.Txt_remark.Location = New System.Drawing.Point(373, 37)
        Me.Txt_remark.MaxLength = 50
        Me.Txt_remark.Name = "Txt_remark"
        Me.Txt_remark.ReadOnly = True
        Me.Txt_remark.Size = New System.Drawing.Size(558, 22)
        Me.Txt_remark.TabIndex = 91
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(625, 22)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(29, 12)
        Me.Label23.TabIndex = 102
        Me.Label23.Text = "備註"
        '
        'Cmb_lv
        '
        Me.Cmb_lv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.Cmb_lv.Enabled = False
        Me.Cmb_lv.FormatString = "99"
        Me.Cmb_lv.FormattingEnabled = True
        Me.Cmb_lv.Items.AddRange(New Object() {"A", "B", "C", "N"})
        Me.Cmb_lv.Location = New System.Drawing.Point(881, 95)
        Me.Cmb_lv.MaxLength = 1
        Me.Cmb_lv.Name = "Cmb_lv"
        Me.Cmb_lv.Size = New System.Drawing.Size(50, 20)
        Me.Cmb_lv.Sorted = True
        Me.Cmb_lv.TabIndex = 90
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(879, 78)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 12)
        Me.Label22.TabIndex = 101
        Me.Label22.Text = "判定等級"
        '
        'Txt_watt
        '
        Me.Txt_watt.Location = New System.Drawing.Point(818, 95)
        Me.Txt_watt.MaxLength = 3
        Me.Txt_watt.Name = "Txt_watt"
        Me.Txt_watt.ReadOnly = True
        Me.Txt_watt.Size = New System.Drawing.Size(50, 22)
        Me.Txt_watt.TabIndex = 87
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(816, 78)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(51, 12)
        Me.Label21.TabIndex = 100
        Me.Label21.Text = "功率Watt"
        '
        'Txt_pre4
        '
        Me.Txt_pre4.Location = New System.Drawing.Point(228, 433)
        Me.Txt_pre4.MaxLength = 5
        Me.Txt_pre4.Name = "Txt_pre4"
        Me.Txt_pre4.ReadOnly = True
        Me.Txt_pre4.Size = New System.Drawing.Size(40, 22)
        Me.Txt_pre4.TabIndex = 86
        '
        'Txt_pre3
        '
        Me.Txt_pre3.Location = New System.Drawing.Point(188, 433)
        Me.Txt_pre3.MaxLength = 5
        Me.Txt_pre3.Name = "Txt_pre3"
        Me.Txt_pre3.ReadOnly = True
        Me.Txt_pre3.Size = New System.Drawing.Size(40, 22)
        Me.Txt_pre3.TabIndex = 85
        '
        'Txt_pre2
        '
        Me.Txt_pre2.Location = New System.Drawing.Point(148, 433)
        Me.Txt_pre2.MaxLength = 5
        Me.Txt_pre2.Name = "Txt_pre2"
        Me.Txt_pre2.ReadOnly = True
        Me.Txt_pre2.Size = New System.Drawing.Size(40, 22)
        Me.Txt_pre2.TabIndex = 84
        '
        'Txt_pre1
        '
        Me.Txt_pre1.Location = New System.Drawing.Point(108, 433)
        Me.Txt_pre1.MaxLength = 5
        Me.Txt_pre1.Name = "Txt_pre1"
        Me.Txt_pre1.ReadOnly = True
        Me.Txt_pre1.Size = New System.Drawing.Size(40, 22)
        Me.Txt_pre1.TabIndex = 83
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(128, 418)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(121, 12)
        Me.Label20.TabIndex = 99
        Me.Label20.Text = "pre-Aging後電阻值(Ω)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(49, 437)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(8, 12)
        Me.Label18.TabIndex = 103
        Me.Label18.Text = "/"
        '
        'Cmb_Inv_No
        '
        Me.Cmb_Inv_No.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.Cmb_Inv_No.Enabled = False
        Me.Cmb_Inv_No.FormatString = "99"
        Me.Cmb_Inv_No.FormattingEnabled = True
        Me.Cmb_Inv_No.Items.AddRange(New Object() {"01", "02", "03", "04"})
        Me.Cmb_Inv_No.Location = New System.Drawing.Point(662, 95)
        Me.Cmb_Inv_No.MaxLength = 2
        Me.Cmb_Inv_No.Name = "Cmb_Inv_No"
        Me.Cmb_Inv_No.Size = New System.Drawing.Size(50, 20)
        Me.Cmb_Inv_No.Sorted = True
        Me.Cmb_Inv_No.TabIndex = 81
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(660, 78)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 12)
        Me.Label17.TabIndex = 97
        Me.Label17.Text = "Inv編號"
        '
        'Cmb_frame_No
        '
        Me.Cmb_frame_No.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.Cmb_frame_No.Enabled = False
        Me.Cmb_frame_No.FormatString = "99"
        Me.Cmb_frame_No.FormattingEnabled = True
        Me.Cmb_frame_No.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73"})
        Me.Cmb_frame_No.Location = New System.Drawing.Point(602, 95)
        Me.Cmb_frame_No.MaxLength = 2
        Me.Cmb_frame_No.Name = "Cmb_frame_No"
        Me.Cmb_frame_No.Size = New System.Drawing.Size(50, 20)
        Me.Cmb_frame_No.Sorted = True
        Me.Cmb_frame_No.TabIndex = 80
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(600, 78)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 12)
        Me.Label16.TabIndex = 96
        Me.Label16.Text = "框架編號"
        '
        'Txt_ampere
        '
        Me.Txt_ampere.Location = New System.Drawing.Point(18, 432)
        Me.Txt_ampere.MaxLength = 4
        Me.Txt_ampere.Name = "Txt_ampere"
        Me.Txt_ampere.ReadOnly = True
        Me.Txt_ampere.Size = New System.Drawing.Size(28, 22)
        Me.Txt_ampere.TabIndex = 78
        '
        'Txt_voltage
        '
        Me.Txt_voltage.Location = New System.Drawing.Point(60, 432)
        Me.Txt_voltage.MaxLength = 3
        Me.Txt_voltage.Name = "Txt_voltage"
        Me.Txt_voltage.ReadOnly = True
        Me.Txt_voltage.Size = New System.Drawing.Size(32, 22)
        Me.Txt_voltage.TabIndex = 79
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(723, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 12)
        Me.Label15.TabIndex = 98
        Me.Label15.Text = "Aging判定"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 418)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 12)
        Me.Label14.TabIndex = 95
        Me.Label14.Text = "點亮電流/電壓"
        '
        'Cmb_Car
        '
        Me.Cmb_Car.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.Cmb_Car.Enabled = False
        Me.Cmb_Car.FormatString = "99"
        Me.Cmb_Car.FormattingEnabled = True
        Me.Cmb_Car.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68"})
        Me.Cmb_Car.Location = New System.Drawing.Point(76, 95)
        Me.Cmb_Car.MaxLength = 2
        Me.Cmb_Car.Name = "Cmb_Car"
        Me.Cmb_Car.Size = New System.Drawing.Size(40, 20)
        Me.Cmb_Car.Sorted = True
        Me.Cmb_Car.TabIndex = 74
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(74, 78)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 94
        Me.Label13.Text = "抽氣台車"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 12)
        Me.Label12.TabIndex = 93
        Me.Label12.Text = "燈板號碼"
        '
        'Txt_No2
        '
        Me.Txt_No2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_No2.Location = New System.Drawing.Point(19, 95)
        Me.Txt_No2.MaxLength = 4
        Me.Txt_No2.Name = "Txt_No2"
        Me.Txt_No2.ReadOnly = True
        Me.Txt_No2.Size = New System.Drawing.Size(45, 22)
        Me.Txt_No2.TabIndex = 73
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 12)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "不良分析單號NO :"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(19, 148)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(178, 227)
        Me.DataGridView1.TabIndex = 110
        '
        'Cmb_Car6
        '
        Me.Cmb_Car6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.Cmb_Car6.Enabled = False
        Me.Cmb_Car6.FormatString = "99"
        Me.Cmb_Car6.FormattingEnabled = True
        Me.Cmb_Car6.Items.AddRange(New Object() {"A", "B", "MR"})
        Me.Cmb_Car6.Location = New System.Drawing.Point(180, 95)
        Me.Cmb_Car6.MaxLength = 1
        Me.Cmb_Car6.Name = "Cmb_Car6"
        Me.Cmb_Car6.Size = New System.Drawing.Size(40, 20)
        Me.Cmb_Car6.Sorted = True
        Me.Cmb_Car6.TabIndex = 120
        Me.Cmb_Car6.Text = "A"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(178, 78)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(29, 12)
        Me.Label35.TabIndex = 121
        Me.Label35.Text = "線別"
        '
        'Car_balance
        '
        Me.Car_balance.Location = New System.Drawing.Point(335, 95)
        Me.Car_balance.Name = "Car_balance"
        Me.Car_balance.ReadOnly = True
        Me.Car_balance.Size = New System.Drawing.Size(45, 22)
        Me.Car_balance.TabIndex = 119
        '
        'Car_Pre_injection
        '
        Me.Car_Pre_injection.Location = New System.Drawing.Point(280, 95)
        Me.Car_Pre_injection.Name = "Car_Pre_injection"
        Me.Car_Pre_injection.ReadOnly = True
        Me.Car_Pre_injection.Size = New System.Drawing.Size(45, 22)
        Me.Car_Pre_injection.TabIndex = 118
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(333, 78)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(41, 12)
        Me.Label33.TabIndex = 117
        Me.Label33.Text = "平衡值"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(278, 78)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(41, 12)
        Me.Label34.TabIndex = 116
        Me.Label34.Text = "預注值"
        '
        'Cmb_Car3
        '
        Me.Cmb_Car3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.Cmb_Car3.Enabled = False
        Me.Cmb_Car3.FormatString = "99"
        Me.Cmb_Car3.FormattingEnabled = True
        Me.Cmb_Car3.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10"})
        Me.Cmb_Car3.Location = New System.Drawing.Point(230, 95)
        Me.Cmb_Car3.MaxLength = 2
        Me.Cmb_Car3.Name = "Cmb_Car3"
        Me.Cmb_Car3.Size = New System.Drawing.Size(40, 20)
        Me.Cmb_Car3.Sorted = True
        Me.Cmb_Car3.TabIndex = 112
        Me.Cmb_Car3.Text = "01"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(228, 78)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(29, 12)
        Me.Label30.TabIndex = 115
        Me.Label30.Text = "圈數"
        '
        'Cmb_Car2
        '
        Me.Cmb_Car2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.Cmb_Car2.Enabled = False
        Me.Cmb_Car2.FormatString = "99"
        Me.Cmb_Car2.FormattingEnabled = True
        Me.Cmb_Car2.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10"})
        Me.Cmb_Car2.Location = New System.Drawing.Point(130, 95)
        Me.Cmb_Car2.MaxLength = 2
        Me.Cmb_Car2.Name = "Cmb_Car2"
        Me.Cmb_Car2.Size = New System.Drawing.Size(40, 20)
        Me.Cmb_Car2.Sorted = True
        Me.Cmb_Car2.TabIndex = 111
        Me.Cmb_Car2.Text = "01"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(128, 78)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(29, 12)
        Me.Label29.TabIndex = 114
        Me.Label29.Text = "位置"
        '
        'Car_status
        '
        Me.Car_status.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Car_status.Location = New System.Drawing.Point(390, 95)
        Me.Car_status.Name = "Car_status"
        Me.Car_status.ReadOnly = True
        Me.Car_status.Size = New System.Drawing.Size(45, 22)
        Me.Car_status.TabIndex = 123
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(388, 78)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(53, 12)
        Me.Label36.TabIndex = 122
        Me.Label36.Text = "不良原因"
        '
        'LAMPS_SER
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 472)
        Me.Controls.Add(Me.Car_status)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Cmb_Car6)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Car_balance)
        Me.Controls.Add(Me.Car_Pre_injection)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Cmb_Car3)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Cmb_Car2)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_D_Date)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Txt_ampere2)
        Me.Controls.Add(Me.Txt_voltage2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_determine)
        Me.Controls.Add(Me.Txt_remark)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Cmb_lv)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Txt_watt)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Txt_pre4)
        Me.Controls.Add(Me.Txt_pre3)
        Me.Controls.Add(Me.Txt_pre2)
        Me.Controls.Add(Me.Txt_pre1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Cmb_Inv_No)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Cmb_frame_No)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Txt_ampere)
        Me.Controls.Add(Me.Txt_voltage)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Cmb_Car)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Txt_No2)
        Me.Controls.Add(Me.Txt_ampere3)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Txt_Ballast_NO)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_LAMPS_NO)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Cancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LAMPS_SER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "成燈查詢系統"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Txt_ampere3 As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Txt_Ballast_NO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_LAMPS_NO As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Txt_D_Date As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Txt_ampere2 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_voltage2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_determine As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_remark As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Cmb_lv As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Txt_watt As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Txt_pre4 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_pre3 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_pre2 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_pre1 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Inv_No As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Cmb_frame_No As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Txt_ampere As System.Windows.Forms.TextBox
    Friend WithEvents Txt_voltage As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Car As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Txt_No2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Cmb_Car6 As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Car_balance As System.Windows.Forms.TextBox
    Friend WithEvents Car_Pre_injection As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Car3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Car2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Car_status As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
End Class
