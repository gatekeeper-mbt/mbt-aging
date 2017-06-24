<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PRQA_SER
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PRQA_SER))
        Me.Txt_Date2 = New System.Windows.Forms.TextBox()
        Me.Txt_Date1 = New System.Windows.Forms.TextBox()
        Me.Txt_No2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_No1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_SER = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_PRQA_User_ID = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Cmb_Status = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cmb_PRQA_PRI = New System.Windows.Forms.ComboBox()
        Me.Cmb_PRQA_TYPE = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cmb_PRQA_KD = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Btn_Printer = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Txt_Date2
        '
        Me.Txt_Date2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Date2.Location = New System.Drawing.Point(298, 41)
        Me.Txt_Date2.MaxLength = 10
        Me.Txt_Date2.Name = "Txt_Date2"
        Me.Txt_Date2.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Date2.TabIndex = 3
        '
        'Txt_Date1
        '
        Me.Txt_Date1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Date1.Location = New System.Drawing.Point(175, 41)
        Me.Txt_Date1.MaxLength = 10
        Me.Txt_Date1.Name = "Txt_Date1"
        Me.Txt_Date1.Size = New System.Drawing.Size(100, 22)
        Me.Txt_Date1.TabIndex = 2
        '
        'Txt_No2
        '
        Me.Txt_No2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_No2.Location = New System.Drawing.Point(298, 12)
        Me.Txt_No2.MaxLength = 10
        Me.Txt_No2.Name = "Txt_No2"
        Me.Txt_No2.Size = New System.Drawing.Size(100, 22)
        Me.Txt_No2.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(42, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 12)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "日期區間 :(2010-12-31)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(281, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 12)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "~"
        '
        'Txt_No1
        '
        Me.Txt_No1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_No1.Location = New System.Drawing.Point(175, 12)
        Me.Txt_No1.MaxLength = 10
        Me.Txt_No1.Name = "Txt_No1"
        Me.Txt_No1.Size = New System.Drawing.Size(100, 22)
        Me.Txt_No1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 12)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "不良分析單號NO區間 :"
        '
        'Btn_SER
        '
        Me.Btn_SER.Location = New System.Drawing.Point(655, 71)
        Me.Btn_SER.Name = "Btn_SER"
        Me.Btn_SER.Size = New System.Drawing.Size(111, 23)
        Me.Btn_SER.TabIndex = 9
        Me.Btn_SER.Text = "不良分析紀查詢"
        Me.Btn_SER.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(676, 531)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 12
        Me.Cancel.Text = "取消(&C)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(281, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 12)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "~"
        '
        'Cmb_PRQA_User_ID
        '
        Me.Cmb_PRQA_User_ID.FormattingEnabled = True
        Me.Cmb_PRQA_User_ID.Location = New System.Drawing.Point(493, 41)
        Me.Cmb_PRQA_User_ID.Name = "Cmb_PRQA_User_ID"
        Me.Cmb_PRQA_User_ID.Size = New System.Drawing.Size(182, 20)
        Me.Cmb_PRQA_User_ID.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(428, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 12)
        Me.Label13.TabIndex = 72
        Me.Label13.Text = "處理人員 :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(286, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(201, 12)
        Me.Label12.TabIndex = 71
        Me.Label12.Text = "狀態 :(O:Open;A:Active;F:Fixed;C:Close)"
        '
        'Cmb_Status
        '
        Me.Cmb_Status.FormattingEnabled = True
        Me.Cmb_Status.Items.AddRange(New Object() {"O", "A", "F", "C"})
        Me.Cmb_Status.Location = New System.Drawing.Point(493, 74)
        Me.Cmb_Status.Name = "Cmb_Status"
        Me.Cmb_Status.Size = New System.Drawing.Size(46, 20)
        Me.Cmb_Status.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(42, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(178, 12)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "重要性 :(H:High;M:Medium;L:Low)"
        '
        'Cmb_PRQA_PRI
        '
        Me.Cmb_PRQA_PRI.FormattingEnabled = True
        Me.Cmb_PRQA_PRI.Items.AddRange(New Object() {"H", "M", "L"})
        Me.Cmb_PRQA_PRI.Location = New System.Drawing.Point(226, 74)
        Me.Cmb_PRQA_PRI.Name = "Cmb_PRQA_PRI"
        Me.Cmb_PRQA_PRI.Size = New System.Drawing.Size(46, 20)
        Me.Cmb_PRQA_PRI.TabIndex = 7
        '
        'Cmb_PRQA_TYPE
        '
        Me.Cmb_PRQA_TYPE.FormattingEnabled = True
        Me.Cmb_PRQA_TYPE.Location = New System.Drawing.Point(662, 15)
        Me.Cmb_PRQA_TYPE.Name = "Cmb_PRQA_TYPE"
        Me.Cmb_PRQA_TYPE.Size = New System.Drawing.Size(83, 20)
        Me.Cmb_PRQA_TYPE.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(597, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "異常分類 :"
        '
        'Cmb_PRQA_KD
        '
        Me.Cmb_PRQA_KD.FormattingEnabled = True
        Me.Cmb_PRQA_KD.Location = New System.Drawing.Point(493, 15)
        Me.Cmb_PRQA_KD.Name = "Cmb_PRQA_KD"
        Me.Cmb_PRQA_KD.Size = New System.Drawing.Size(83, 20)
        Me.Cmb_PRQA_KD.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(428, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "異常物件 :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 97)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(773, 12)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "---------------------------------------------------------------------------------" &
    "--------------------------------------------------------------------------------" &
    "-------------------------------"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(8, 112)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(771, 403)
        Me.DataGridView1.TabIndex = 10
        '
        'Btn_Printer
        '
        Me.Btn_Printer.Location = New System.Drawing.Point(546, 531)
        Me.Btn_Printer.Name = "Btn_Printer"
        Me.Btn_Printer.Size = New System.Drawing.Size(111, 23)
        Me.Btn_Printer.TabIndex = 11
        Me.Btn_Printer.Text = "不良分析紀表"
        Me.Btn_Printer.UseVisualStyleBackColor = True
        '
        'PRQA_SER
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.Btn_Printer)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Cmb_PRQA_User_ID)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Cmb_Status)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Cmb_PRQA_PRI)
        Me.Controls.Add(Me.Cmb_PRQA_TYPE)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Cmb_PRQA_KD)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_Date2)
        Me.Controls.Add(Me.Txt_Date1)
        Me.Controls.Add(Me.Txt_No2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_No1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Btn_SER)
        Me.Controls.Add(Me.Cancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PRQA_SER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "不良分析查詢"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Txt_Date2 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Date1 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_No2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_No1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Btn_SER As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cmb_PRQA_User_ID As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Status As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cmb_PRQA_PRI As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_PRQA_TYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cmb_PRQA_KD As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_Printer As System.Windows.Forms.Button
End Class
