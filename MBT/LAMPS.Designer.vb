<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LAMPS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LAMPS))
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Txt_LAMPS_NO = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Txt_Ballast_NO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_ampere3 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Btn_save = New System.Windows.Forms.Button()
        Me.Txt_D_Date = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Txt_No2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(12, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(368, 19)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "＊舊工單No.請勿輸入   請用Tab鍵 切換欄位"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(434, 148)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 4
        Me.Cancel.Text = "取消(&C)"
        '
        'Txt_LAMPS_NO
        '
        Me.Txt_LAMPS_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_LAMPS_NO.Location = New System.Drawing.Point(32, 62)
        Me.Txt_LAMPS_NO.MaxLength = 15
        Me.Txt_LAMPS_NO.Name = "Txt_LAMPS_NO"
        Me.Txt_LAMPS_NO.Size = New System.Drawing.Size(209, 22)
        Me.Txt_LAMPS_NO.TabIndex = 0
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(109, 46)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(41, 12)
        Me.Label32.TabIndex = 6
        Me.Label32.Text = "成燈碼"
        '
        'Txt_Ballast_NO
        '
        Me.Txt_Ballast_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Ballast_NO.Location = New System.Drawing.Point(250, 62)
        Me.Txt_Ballast_NO.MaxLength = 20
        Me.Txt_Ballast_NO.Name = "Txt_Ballast_NO"
        Me.Txt_Ballast_NO.Size = New System.Drawing.Size(209, 22)
        Me.Txt_Ballast_NO.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(327, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "安定器號碼"
        '
        'Txt_ampere3
        '
        Me.Txt_ampere3.Location = New System.Drawing.Point(471, 61)
        Me.Txt_ampere3.MaxLength = 6
        Me.Txt_ampere3.Name = "Txt_ampere3"
        Me.Txt_ampere3.Size = New System.Drawing.Size(48, 22)
        Me.Txt_ampere3.TabIndex = 2
        Me.Txt_ampere3.Text = "000.00"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(465, 46)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(65, 12)
        Me.Label28.TabIndex = 8
        Me.Label28.Text = "實際功率值"
        '
        'Btn_save
        '
        Me.Btn_save.Location = New System.Drawing.Point(286, 148)
        Me.Btn_save.Name = "Btn_save"
        Me.Btn_save.Size = New System.Drawing.Size(128, 23)
        Me.Btn_save.TabIndex = 3
        Me.Btn_save.Text = "存檔"
        Me.Btn_save.UseVisualStyleBackColor = True
        '
        'Txt_D_Date
        '
        Me.Txt_D_Date.Location = New System.Drawing.Point(89, 117)
        Me.Txt_D_Date.MaxLength = 10
        Me.Txt_D_Date.Name = "Txt_D_Date"
        Me.Txt_D_Date.ReadOnly = True
        Me.Txt_D_Date.Size = New System.Drawing.Size(100, 22)
        Me.Txt_D_Date.TabIndex = 110
        Me.Txt_D_Date.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(119, 103)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(35, 12)
        Me.Label31.TabIndex = 112
        Me.Label31.Text = "日  期"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(30, 103)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 12)
        Me.Label12.TabIndex = 111
        Me.Label12.Text = "燈板號碼"
        '
        'Txt_No2
        '
        Me.Txt_No2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_No2.Location = New System.Drawing.Point(32, 117)
        Me.Txt_No2.MaxLength = 4
        Me.Txt_No2.Name = "Txt_No2"
        Me.Txt_No2.ReadOnly = True
        Me.Txt_No2.Size = New System.Drawing.Size(46, 22)
        Me.Txt_No2.TabIndex = 109
        Me.Txt_No2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "請輸入成燈碼"
        Me.Label2.Visible = False
        '
        'LAMPS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 185)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_D_Date)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Txt_No2)
        Me.Controls.Add(Me.Btn_save)
        Me.Controls.Add(Me.Txt_ampere3)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Txt_Ballast_NO)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_LAMPS_NO)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Label19)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LAMPS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "組裝輸入"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Txt_LAMPS_NO As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Txt_Ballast_NO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_ampere3 As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Btn_save As System.Windows.Forms.Button
    Friend WithEvents Txt_D_Date As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Txt_No2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
