<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PRCS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PRCS))
        Me.Txt_No = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmb_PRCS_KD = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Cmb_Status = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_QA_EXPL2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_QA_EXPL1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cmb_PRQA_PRI = New System.Windows.Forms.ComboBox()
        Me.Txt_Date = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmb_PRQA_TYPE = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cmb_PRQA_KD = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Cmb_PRCS_User_ID = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Btn_Ddel = New System.Windows.Forms.Button()
        Me.Btn_Dadd = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Txt_LAMPS_NO = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_D_PRQA_NO = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Btn_del = New System.Windows.Forms.Button()
        Me.Btn_update = New System.Windows.Forms.Button()
        Me.Btn_add = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_D2_PRQA_NO = New System.Windows.Forms.TextBox()
        Me.Btn_Ddel2 = New System.Windows.Forms.Button()
        Me.Btn_Dadd2 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_Ballast_NO = New System.Windows.Forms.TextBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Txt_No
        '
        Me.Txt_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_No.Location = New System.Drawing.Point(429, 21)
        Me.Txt_No.MaxLength = 10
        Me.Txt_No.Name = "Txt_No"
        Me.Txt_No.Size = New System.Drawing.Size(100, 22)
        Me.Txt_No.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(313, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 12)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "客訴/品質異常單號 :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(9, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(132, 13)
        Me.Label19.TabIndex = 68
        Me.Label19.Text = "＊請用Tab鍵 切換欄位"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 12)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "來源種類 :(A:客訴處理單;B:品質異常處理單)"
        '
        'Cmb_PRCS_KD
        '
        Me.Cmb_PRCS_KD.FormattingEnabled = True
        Me.Cmb_PRCS_KD.Items.AddRange(New Object() {"A", "B"})
        Me.Cmb_PRCS_KD.Location = New System.Drawing.Point(261, 21)
        Me.Cmb_PRCS_KD.Name = "Cmb_PRCS_KD"
        Me.Cmb_PRCS_KD.Size = New System.Drawing.Size(46, 20)
        Me.Cmb_PRCS_KD.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(524, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(201, 12)
        Me.Label12.TabIndex = 82
        Me.Label12.Text = "狀態 :(O:Open;A:Active;F:Fixed;C:Close)"
        '
        'Cmb_Status
        '
        Me.Cmb_Status.FormattingEnabled = True
        Me.Cmb_Status.Items.AddRange(New Object() {"O", "A", "F", "C"})
        Me.Cmb_Status.Location = New System.Drawing.Point(731, 54)
        Me.Cmb_Status.MaxLength = 1
        Me.Cmb_Status.Name = "Cmb_Status"
        Me.Cmb_Status.Size = New System.Drawing.Size(46, 20)
        Me.Cmb_Status.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 159)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 12)
        Me.Label9.TabIndex = 81
        Me.Label9.Text = "原因分析 :"
        '
        'Txt_QA_EXPL2
        '
        Me.Txt_QA_EXPL2.Location = New System.Drawing.Point(8, 174)
        Me.Txt_QA_EXPL2.MaxLength = 100
        Me.Txt_QA_EXPL2.Multiline = True
        Me.Txt_QA_EXPL2.Name = "Txt_QA_EXPL2"
        Me.Txt_QA_EXPL2.Size = New System.Drawing.Size(772, 44)
        Me.Txt_QA_EXPL2.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 12)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "異常現象 :"
        '
        'Txt_QA_EXPL1
        '
        Me.Txt_QA_EXPL1.Location = New System.Drawing.Point(8, 102)
        Me.Txt_QA_EXPL1.MaxLength = 100
        Me.Txt_QA_EXPL1.Multiline = True
        Me.Txt_QA_EXPL1.Name = "Txt_QA_EXPL1"
        Me.Txt_QA_EXPL1.Size = New System.Drawing.Size(772, 44)
        Me.Txt_QA_EXPL1.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(547, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(178, 12)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "重要性 :(H:High;M:Medium;L:Low)"
        '
        'Cmb_PRQA_PRI
        '
        Me.Cmb_PRQA_PRI.FormattingEnabled = True
        Me.Cmb_PRQA_PRI.Items.AddRange(New Object() {"H", "M", "L"})
        Me.Cmb_PRQA_PRI.Location = New System.Drawing.Point(731, 23)
        Me.Cmb_PRQA_PRI.MaxLength = 1
        Me.Cmb_PRQA_PRI.Name = "Cmb_PRQA_PRI"
        Me.Cmb_PRQA_PRI.Size = New System.Drawing.Size(46, 20)
        Me.Cmb_PRQA_PRI.TabIndex = 2
        '
        'Txt_Date
        '
        Me.Txt_Date.Location = New System.Drawing.Point(66, 52)
        Me.Txt_Date.MaxLength = 10
        Me.Txt_Date.Name = "Txt_Date"
        Me.Txt_Date.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Date.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 78
        Me.Label6.Text = "日  期 :"
        '
        'Cmb_PRQA_TYPE
        '
        Me.Cmb_PRQA_TYPE.FormattingEnabled = True
        Me.Cmb_PRQA_TYPE.Location = New System.Drawing.Point(429, 54)
        Me.Cmb_PRQA_TYPE.MaxLength = 1
        Me.Cmb_PRQA_TYPE.Name = "Cmb_PRQA_TYPE"
        Me.Cmb_PRQA_TYPE.Size = New System.Drawing.Size(83, 20)
        Me.Cmb_PRQA_TYPE.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(364, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "異常分類 :"
        '
        'Cmb_PRQA_KD
        '
        Me.Cmb_PRQA_KD.FormattingEnabled = True
        Me.Cmb_PRQA_KD.Location = New System.Drawing.Point(261, 54)
        Me.Cmb_PRQA_KD.MaxLength = 2
        Me.Cmb_PRQA_KD.Name = "Cmb_PRQA_KD"
        Me.Cmb_PRQA_KD.Size = New System.Drawing.Size(83, 20)
        Me.Cmb_PRQA_KD.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(196, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "異常物件 :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 254)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(773, 12)
        Me.Label14.TabIndex = 83
        Me.Label14.Text = "---------------------------------------------------------------------------------" &
    "--------------------------------------------------------------------------------" &
    "-------------------------------"
        '
        'Cmb_PRCS_User_ID
        '
        Me.Cmb_PRCS_User_ID.FormattingEnabled = True
        Me.Cmb_PRCS_User_ID.Location = New System.Drawing.Point(77, 231)
        Me.Cmb_PRCS_User_ID.Name = "Cmb_PRCS_User_ID"
        Me.Cmb_PRCS_User_ID.Size = New System.Drawing.Size(182, 20)
        Me.Cmb_PRCS_User_ID.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 234)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 12)
        Me.Label13.TabIndex = 85
        Me.Label13.Text = "處理人員 :"
        '
        'Btn_Ddel
        '
        Me.Btn_Ddel.Location = New System.Drawing.Point(277, 220)
        Me.Btn_Ddel.Name = "Btn_Ddel"
        Me.Btn_Ddel.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Ddel.TabIndex = 4
        Me.Btn_Ddel.Text = "刪除"
        Me.Btn_Ddel.UseVisualStyleBackColor = True
        '
        'Btn_Dadd
        '
        Me.Btn_Dadd.Location = New System.Drawing.Point(201, 219)
        Me.Btn_Dadd.Name = "Btn_Dadd"
        Me.Btn_Dadd.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Dadd.TabIndex = 3
        Me.Btn_Dadd.Text = "儲存"
        Me.Btn_Dadd.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 194)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 12)
        Me.Label15.TabIndex = 67
        Me.Label15.Text = "成燈碼:"
        '
        'Txt_LAMPS_NO
        '
        Me.Txt_LAMPS_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_LAMPS_NO.Location = New System.Drawing.Point(95, 190)
        Me.Txt_LAMPS_NO.MaxLength = 15
        Me.Txt_LAMPS_NO.Name = "Txt_LAMPS_NO"
        Me.Txt_LAMPS_NO.Size = New System.Drawing.Size(100, 22)
        Me.Txt_LAMPS_NO.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Txt_D_PRQA_NO)
        Me.GroupBox1.Controls.Add(Me.Btn_Ddel)
        Me.GroupBox1.Controls.Add(Me.Btn_Dadd)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Txt_LAMPS_NO)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 269)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(358, 255)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "成燈碼"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 12)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "不良分析單號:"
        '
        'Txt_D_PRQA_NO
        '
        Me.Txt_D_PRQA_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_D_PRQA_NO.Location = New System.Drawing.Point(95, 219)
        Me.Txt_D_PRQA_NO.MaxLength = 10
        Me.Txt_D_PRQA_NO.Name = "Txt_D_PRQA_NO"
        Me.Txt_D_PRQA_NO.Size = New System.Drawing.Size(100, 22)
        Me.Txt_D_PRQA_NO.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(8, 20)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(344, 163)
        Me.DataGridView1.TabIndex = 0
        '
        'Btn_del
        '
        Me.Btn_del.Location = New System.Drawing.Point(702, 231)
        Me.Btn_del.Name = "Btn_del"
        Me.Btn_del.Size = New System.Drawing.Size(75, 23)
        Me.Btn_del.TabIndex = 12
        Me.Btn_del.Text = "刪除"
        Me.Btn_del.UseVisualStyleBackColor = True
        '
        'Btn_update
        '
        Me.Btn_update.Location = New System.Drawing.Point(621, 231)
        Me.Btn_update.Name = "Btn_update"
        Me.Btn_update.Size = New System.Drawing.Size(75, 23)
        Me.Btn_update.TabIndex = 11
        Me.Btn_update.Text = "修改"
        Me.Btn_update.UseVisualStyleBackColor = True
        '
        'Btn_add
        '
        Me.Btn_add.Location = New System.Drawing.Point(538, 231)
        Me.Btn_add.Name = "Btn_add"
        Me.Btn_add.Size = New System.Drawing.Size(75, 23)
        Me.Btn_add.TabIndex = 10
        Me.Btn_add.Text = "新增"
        Me.Btn_add.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(676, 531)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 15
        Me.Cancel.Text = "取消(&C)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Txt_D2_PRQA_NO)
        Me.GroupBox2.Controls.Add(Me.Btn_Ddel2)
        Me.GroupBox2.Controls.Add(Me.Btn_Dadd2)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Txt_Ballast_NO)
        Me.GroupBox2.Controls.Add(Me.DataGridView2)
        Me.GroupBox2.Location = New System.Drawing.Point(419, 269)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(358, 255)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "安定器"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 224)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 12)
        Me.Label10.TabIndex = 92
        Me.Label10.Text = "不良分析單號:"
        '
        'Txt_D2_PRQA_NO
        '
        Me.Txt_D2_PRQA_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_D2_PRQA_NO.Location = New System.Drawing.Point(95, 219)
        Me.Txt_D2_PRQA_NO.MaxLength = 10
        Me.Txt_D2_PRQA_NO.Name = "Txt_D2_PRQA_NO"
        Me.Txt_D2_PRQA_NO.Size = New System.Drawing.Size(100, 22)
        Me.Txt_D2_PRQA_NO.TabIndex = 2
        '
        'Btn_Ddel2
        '
        Me.Btn_Ddel2.Location = New System.Drawing.Point(277, 220)
        Me.Btn_Ddel2.Name = "Btn_Ddel2"
        Me.Btn_Ddel2.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Ddel2.TabIndex = 4
        Me.Btn_Ddel2.Text = "刪除"
        Me.Btn_Ddel2.UseVisualStyleBackColor = True
        '
        'Btn_Dadd2
        '
        Me.Btn_Dadd2.Location = New System.Drawing.Point(201, 219)
        Me.Btn_Dadd2.Name = "Btn_Dadd2"
        Me.Btn_Dadd2.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Dadd2.TabIndex = 3
        Me.Btn_Dadd2.Text = "儲存"
        Me.Btn_Dadd2.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 194)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 12)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "安定器碼:"
        '
        'Txt_Ballast_NO
        '
        Me.Txt_Ballast_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Ballast_NO.Location = New System.Drawing.Point(95, 190)
        Me.Txt_Ballast_NO.MaxLength = 20
        Me.Txt_Ballast_NO.Name = "Txt_Ballast_NO"
        Me.Txt_Ballast_NO.Size = New System.Drawing.Size(170, 22)
        Me.Txt_Ballast_NO.TabIndex = 1
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(8, 20)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(344, 163)
        Me.DataGridView2.TabIndex = 0
        '
        'PRCS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Btn_del)
        Me.Controls.Add(Me.Btn_update)
        Me.Controls.Add(Me.Btn_add)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Cmb_PRCS_User_ID)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Cmb_Status)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Txt_QA_EXPL2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Txt_QA_EXPL1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Cmb_PRQA_PRI)
        Me.Controls.Add(Me.Txt_Date)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cmb_PRQA_TYPE)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Cmb_PRQA_KD)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cmb_PRCS_KD)
        Me.Controls.Add(Me.Txt_No)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PRCS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "MBT-客訴/品質異常處理維護"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Txt_No As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cmb_PRCS_KD As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Status As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_QA_EXPL2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_QA_EXPL1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cmb_PRQA_PRI As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_Date As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cmb_PRQA_TYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cmb_PRQA_KD As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cmb_PRCS_User_ID As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Btn_Ddel As System.Windows.Forms.Button
    Friend WithEvents Btn_Dadd As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Txt_LAMPS_NO As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_del As System.Windows.Forms.Button
    Friend WithEvents Btn_update As System.Windows.Forms.Button
    Friend WithEvents Btn_add As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_D_PRQA_NO As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txt_D2_PRQA_NO As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Ddel2 As System.Windows.Forms.Button
    Friend WithEvents Btn_Dadd2 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_Ballast_NO As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
End Class
