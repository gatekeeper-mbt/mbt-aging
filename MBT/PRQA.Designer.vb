<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PRQA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PRQA))
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Txt_No = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_del = New System.Windows.Forms.Button()
        Me.Btn_update = New System.Windows.Forms.Button()
        Me.Btn_add = New System.Windows.Forms.Button()
        Me.Cmb_SOURCE_KD = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_SOURCE_NO = New System.Windows.Forms.TextBox()
        Me.Btn_SOURCE = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cmb_PRQA_KD = New System.Windows.Forms.ComboBox()
        Me.Cmb_PRQA_TYPE = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_Date = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cmb_PRQA_PRI = New System.Windows.Forms.ComboBox()
        Me.Txt_QA_EXPL1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_QA_EXPL2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_QA_EXPL3 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_QA_EXPL4 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Cmb_Status = New System.Windows.Forms.ComboBox()
        Me.Cmb_PRQA_User_ID = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Txt_LAMPS_NO = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Btn_Ddel = New System.Windows.Forms.Button()
        Me.Btn_Dadd = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(676, 531)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 18
        Me.Cancel.Text = "取消(&C)"
        '
        'Txt_No
        '
        Me.Txt_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_No.Location = New System.Drawing.Point(126, 57)
        Me.Txt_No.MaxLength = 10
        Me.Txt_No.Name = "Txt_No"
        Me.Txt_No.Size = New System.Drawing.Size(100, 22)
        Me.Txt_No.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 12)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "不良分析單號NO :"
        '
        'Btn_del
        '
        Me.Btn_del.Location = New System.Drawing.Point(580, 531)
        Me.Btn_del.Name = "Btn_del"
        Me.Btn_del.Size = New System.Drawing.Size(75, 23)
        Me.Btn_del.TabIndex = 17
        Me.Btn_del.Text = "刪除"
        Me.Btn_del.UseVisualStyleBackColor = True
        '
        'Btn_update
        '
        Me.Btn_update.Location = New System.Drawing.Point(499, 531)
        Me.Btn_update.Name = "Btn_update"
        Me.Btn_update.Size = New System.Drawing.Size(75, 23)
        Me.Btn_update.TabIndex = 15
        Me.Btn_update.Text = "修改"
        Me.Btn_update.UseVisualStyleBackColor = True
        '
        'Btn_add
        '
        Me.Btn_add.Location = New System.Drawing.Point(416, 531)
        Me.Btn_add.Name = "Btn_add"
        Me.Btn_add.Size = New System.Drawing.Size(75, 23)
        Me.Btn_add.TabIndex = 14
        Me.Btn_add.Text = "新增"
        Me.Btn_add.UseVisualStyleBackColor = True
        '
        'Cmb_SOURCE_KD
        '
        Me.Cmb_SOURCE_KD.FormattingEnabled = True
        Me.Cmb_SOURCE_KD.Items.AddRange(New Object() {"A", "B"})
        Me.Cmb_SOURCE_KD.Location = New System.Drawing.Point(265, 25)
        Me.Cmb_SOURCE_KD.Name = "Cmb_SOURCE_KD"
        Me.Cmb_SOURCE_KD.Size = New System.Drawing.Size(46, 20)
        Me.Cmb_SOURCE_KD.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 12)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "來源種類 :(A:客訴處理單;B:品質異常處理單)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(323, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 12)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "來源單號NO :"
        '
        'Txt_SOURCE_NO
        '
        Me.Txt_SOURCE_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_SOURCE_NO.Location = New System.Drawing.Point(401, 24)
        Me.Txt_SOURCE_NO.MaxLength = 10
        Me.Txt_SOURCE_NO.Name = "Txt_SOURCE_NO"
        Me.Txt_SOURCE_NO.Size = New System.Drawing.Size(124, 22)
        Me.Txt_SOURCE_NO.TabIndex = 1
        '
        'Btn_SOURCE
        '
        Me.Btn_SOURCE.Location = New System.Drawing.Point(540, 24)
        Me.Btn_SOURCE.Name = "Btn_SOURCE"
        Me.Btn_SOURCE.Size = New System.Drawing.Size(75, 23)
        Me.Btn_SOURCE.TabIndex = 2
        Me.Btn_SOURCE.Text = "來源轉入"
        Me.Btn_SOURCE.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(426, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "異常物件 :"
        '
        'Cmb_PRQA_KD
        '
        Me.Cmb_PRQA_KD.FormattingEnabled = True
        Me.Cmb_PRQA_KD.Location = New System.Drawing.Point(491, 57)
        Me.Cmb_PRQA_KD.MaxLength = 2
        Me.Cmb_PRQA_KD.Name = "Cmb_PRQA_KD"
        Me.Cmb_PRQA_KD.Size = New System.Drawing.Size(83, 20)
        Me.Cmb_PRQA_KD.TabIndex = 5
        '
        'Cmb_PRQA_TYPE
        '
        Me.Cmb_PRQA_TYPE.FormattingEnabled = True
        Me.Cmb_PRQA_TYPE.Location = New System.Drawing.Point(660, 57)
        Me.Cmb_PRQA_TYPE.MaxLength = 1
        Me.Cmb_PRQA_TYPE.Name = "Cmb_PRQA_TYPE"
        Me.Cmb_PRQA_TYPE.Size = New System.Drawing.Size(83, 20)
        Me.Cmb_PRQA_TYPE.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(595, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "異常分類 :"
        '
        'Txt_Date
        '
        Me.Txt_Date.Location = New System.Drawing.Point(298, 57)
        Me.Txt_Date.MaxLength = 10
        Me.Txt_Date.Name = "Txt_Date"
        Me.Txt_Date.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Date.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(251, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "日  期 :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(178, 12)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "重要性 :(H:High;M:Medium;L:Low)"
        '
        'Cmb_PRQA_PRI
        '
        Me.Cmb_PRQA_PRI.FormattingEnabled = True
        Me.Cmb_PRQA_PRI.Items.AddRange(New Object() {"H", "M", "L"})
        Me.Cmb_PRQA_PRI.Location = New System.Drawing.Point(207, 83)
        Me.Cmb_PRQA_PRI.MaxLength = 1
        Me.Cmb_PRQA_PRI.Name = "Cmb_PRQA_PRI"
        Me.Cmb_PRQA_PRI.Size = New System.Drawing.Size(46, 20)
        Me.Cmb_PRQA_PRI.TabIndex = 7
        '
        'Txt_QA_EXPL1
        '
        Me.Txt_QA_EXPL1.Location = New System.Drawing.Point(12, 134)
        Me.Txt_QA_EXPL1.MaxLength = 100
        Me.Txt_QA_EXPL1.Multiline = True
        Me.Txt_QA_EXPL1.Name = "Txt_QA_EXPL1"
        Me.Txt_QA_EXPL1.Size = New System.Drawing.Size(571, 66)
        Me.Txt_QA_EXPL1.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 12)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "異常現象 :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 219)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 12)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "原因分析 :"
        '
        'Txt_QA_EXPL2
        '
        Me.Txt_QA_EXPL2.Location = New System.Drawing.Point(12, 234)
        Me.Txt_QA_EXPL2.MaxLength = 100
        Me.Txt_QA_EXPL2.Multiline = True
        Me.Txt_QA_EXPL2.Name = "Txt_QA_EXPL2"
        Me.Txt_QA_EXPL2.Size = New System.Drawing.Size(571, 66)
        Me.Txt_QA_EXPL2.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 320)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(146, 12)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "改善對策與實施/矯正措施 :"
        '
        'Txt_QA_EXPL3
        '
        Me.Txt_QA_EXPL3.Location = New System.Drawing.Point(12, 335)
        Me.Txt_QA_EXPL3.MaxLength = 100
        Me.Txt_QA_EXPL3.Multiline = True
        Me.Txt_QA_EXPL3.Name = "Txt_QA_EXPL3"
        Me.Txt_QA_EXPL3.Size = New System.Drawing.Size(571, 66)
        Me.Txt_QA_EXPL3.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(23, 418)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 12)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "效果確認/預防措施 :"
        '
        'Txt_QA_EXPL4
        '
        Me.Txt_QA_EXPL4.Location = New System.Drawing.Point(12, 433)
        Me.Txt_QA_EXPL4.MaxLength = 100
        Me.Txt_QA_EXPL4.Multiline = True
        Me.Txt_QA_EXPL4.Name = "Txt_QA_EXPL4"
        Me.Txt_QA_EXPL4.Size = New System.Drawing.Size(571, 66)
        Me.Txt_QA_EXPL4.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(490, 86)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(201, 12)
        Me.Label12.TabIndex = 61
        Me.Label12.Text = "狀態 :(O:Open;A:Active;F:Fixed;C:Close)"
        '
        'Cmb_Status
        '
        Me.Cmb_Status.FormattingEnabled = True
        Me.Cmb_Status.Items.AddRange(New Object() {"O", "A", "F", "C"})
        Me.Cmb_Status.Location = New System.Drawing.Point(697, 83)
        Me.Cmb_Status.MaxLength = 1
        Me.Cmb_Status.Name = "Cmb_Status"
        Me.Cmb_Status.Size = New System.Drawing.Size(46, 20)
        Me.Cmb_Status.TabIndex = 8
        '
        'Cmb_PRQA_User_ID
        '
        Me.Cmb_PRQA_User_ID.FormattingEnabled = True
        Me.Cmb_PRQA_User_ID.Location = New System.Drawing.Point(77, 533)
        Me.Cmb_PRQA_User_ID.Name = "Cmb_PRQA_User_ID"
        Me.Cmb_PRQA_User_ID.Size = New System.Drawing.Size(182, 20)
        Me.Cmb_PRQA_User_ID.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 536)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 12)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "處理人員 :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 44)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(773, 12)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "---------------------------------------------------------------------------------" &
    "--------------------------------------------------------------------------------" &
    "-------------------------------"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(9, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(132, 13)
        Me.Label19.TabIndex = 65
        Me.Label19.Text = "＊請用Tab鍵 切換欄位"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(7, 14)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(178, 313)
        Me.DataGridView1.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 338)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 12)
        Me.Label15.TabIndex = 67
        Me.Label15.Text = "成燈碼:"
        '
        'Txt_LAMPS_NO
        '
        Me.Txt_LAMPS_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_LAMPS_NO.Location = New System.Drawing.Point(80, 333)
        Me.Txt_LAMPS_NO.MaxLength = 15
        Me.Txt_LAMPS_NO.Name = "Txt_LAMPS_NO"
        Me.Txt_LAMPS_NO.Size = New System.Drawing.Size(100, 22)
        Me.Txt_LAMPS_NO.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Btn_Ddel)
        Me.GroupBox1.Controls.Add(Me.Btn_Dadd)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Txt_LAMPS_NO)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(590, 120)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(189, 405)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "成燈碼"
        '
        'Btn_Ddel
        '
        Me.Btn_Ddel.Location = New System.Drawing.Point(98, 361)
        Me.Btn_Ddel.Name = "Btn_Ddel"
        Me.Btn_Ddel.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Ddel.TabIndex = 4
        Me.Btn_Ddel.Text = "刪除"
        Me.Btn_Ddel.UseVisualStyleBackColor = True
        '
        'Btn_Dadd
        '
        Me.Btn_Dadd.Location = New System.Drawing.Point(17, 361)
        Me.Btn_Dadd.Name = "Btn_Dadd"
        Me.Btn_Dadd.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Dadd.TabIndex = 3
        Me.Btn_Dadd.Text = "儲存"
        Me.Btn_Dadd.UseVisualStyleBackColor = True
        '
        'PRQA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Cmb_PRQA_User_ID)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Cmb_Status)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Txt_QA_EXPL4)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Txt_QA_EXPL3)
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
        Me.Controls.Add(Me.Btn_SOURCE)
        Me.Controls.Add(Me.Txt_SOURCE_NO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cmb_SOURCE_KD)
        Me.Controls.Add(Me.Btn_del)
        Me.Controls.Add(Me.Btn_update)
        Me.Controls.Add(Me.Btn_add)
        Me.Controls.Add(Me.Txt_No)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PRQA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "MBT-不良分析"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Txt_No As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Btn_del As System.Windows.Forms.Button
    Friend WithEvents Btn_update As System.Windows.Forms.Button
    Friend WithEvents Btn_add As System.Windows.Forms.Button
    Friend WithEvents Cmb_SOURCE_KD As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_SOURCE_NO As System.Windows.Forms.TextBox
    Friend WithEvents Btn_SOURCE As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cmb_PRQA_KD As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_PRQA_TYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_Date As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cmb_PRQA_PRI As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_QA_EXPL1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_QA_EXPL2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txt_QA_EXPL3 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_QA_EXPL4 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Status As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_PRQA_User_ID As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Txt_LAMPS_NO As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Ddel As System.Windows.Forms.Button
    Friend WithEvents Btn_Dadd As System.Windows.Forms.Button
End Class
