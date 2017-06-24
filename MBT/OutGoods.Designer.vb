<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OutGoods
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Txt_1 = New System.Windows.Forms.TextBox()
        Me.SQL_Cb = New System.Windows.Forms.ComboBox()
        Me.DateTime1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTime2 = New System.Windows.Forms.DateTimePicker()
        Me.DPGB = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Btn_Enter = New System.Windows.Forms.Button()
        Me.lbTotalPage = New System.Windows.Forms.Label()
        Me.lbCurrentPage = New System.Windows.Forms.Label()
        Me.btnFirstPage = New System.Windows.Forms.Label()
        Me.btnLastPage = New System.Windows.Forms.Label()
        Me.btnPrvPage = New System.Windows.Forms.Label()
        Me.btnNxtPage = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SetPageSize = New System.Windows.Forms.Button()
        Me.NumUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DPGB.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label19, 2)
        Me.Label19.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(3, 5)
        Me.Label19.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(132, 13)
        Me.Label19.TabIndex = 192
        Me.Label19.Text = "＊請用Tab鍵 切換欄位"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridView1, 4)
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 118)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(978, 571)
        Me.DataGridView1.TabIndex = 191
        Me.DataGridView1.TabStop = False
        '
        'Txt_1
        '
        Me.Txt_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_1.Location = New System.Drawing.Point(88, 28)
        Me.Txt_1.Margin = New System.Windows.Forms.Padding(3, 8, 3, 3)
        Me.Txt_1.MaxLength = 16
        Me.Txt_1.Name = "Txt_1"
        Me.Txt_1.Size = New System.Drawing.Size(100, 22)
        Me.Txt_1.TabIndex = 2
        '
        'SQL_Cb
        '
        Me.SQL_Cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SQL_Cb.FormattingEnabled = True
        Me.SQL_Cb.Items.AddRange(New Object() {"工單號碼", "成燈碼", "日期"})
        Me.SQL_Cb.Location = New System.Drawing.Point(3, 28)
        Me.SQL_Cb.Margin = New System.Windows.Forms.Padding(3, 8, 3, 3)
        Me.SQL_Cb.Name = "SQL_Cb"
        Me.SQL_Cb.Size = New System.Drawing.Size(75, 20)
        Me.SQL_Cb.TabIndex = 206
        '
        'DateTime1
        '
        Me.DateTime1.CustomFormat = "yyyy-MM-dd"
        Me.DateTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTime1.Location = New System.Drawing.Point(3, 4)
        Me.DateTime1.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.DateTime1.Name = "DateTime1"
        Me.DateTime1.Size = New System.Drawing.Size(95, 22)
        Me.DateTime1.TabIndex = 30
        Me.DateTime1.Value = New Date(2016, 1, 1, 0, 0, 0, 0)
        '
        'DateTime2
        '
        Me.DateTime2.CustomFormat = "yyyy-MM-dd"
        Me.DateTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTime2.Location = New System.Drawing.Point(117, 4)
        Me.DateTime2.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.DateTime2.Name = "DateTime2"
        Me.DateTime2.Size = New System.Drawing.Size(95, 22)
        Me.DateTime2.TabIndex = 31
        '
        'DPGB
        '
        Me.DPGB.Controls.Add(Me.Label3)
        Me.DPGB.Controls.Add(Me.DateTime2)
        Me.DPGB.Controls.Add(Me.DateTime1)
        Me.DPGB.Location = New System.Drawing.Point(322, 23)
        Me.DPGB.Name = "DPGB"
        Me.DPGB.Size = New System.Drawing.Size(219, 29)
        Me.DPGB.TabIndex = 210
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(102, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "~"
        '
        'Btn_Enter
        '
        Me.Btn_Enter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Enter.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_Enter.Location = New System.Drawing.Point(904, 26)
        Me.Btn_Enter.Margin = New System.Windows.Forms.Padding(3, 6, 10, 3)
        Me.Btn_Enter.Name = "Btn_Enter"
        Me.Btn_Enter.Size = New System.Drawing.Size(70, 23)
        Me.Btn_Enter.TabIndex = 50
        Me.Btn_Enter.Text = "確定"
        Me.Btn_Enter.UseVisualStyleBackColor = True
        '
        'lbTotalPage
        '
        Me.lbTotalPage.AutoSize = True
        Me.lbTotalPage.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbTotalPage.Location = New System.Drawing.Point(486, 1)
        Me.lbTotalPage.Name = "lbTotalPage"
        Me.lbTotalPage.Size = New System.Drawing.Size(57, 20)
        Me.lbTotalPage.TabIndex = 213
        Me.lbTotalPage.Text = "共    頁"
        '
        'lbCurrentPage
        '
        Me.lbCurrentPage.AutoSize = True
        Me.lbCurrentPage.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbCurrentPage.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbCurrentPage.Location = New System.Drawing.Point(208, 1)
        Me.lbCurrentPage.Name = "lbCurrentPage"
        Me.lbCurrentPage.Size = New System.Drawing.Size(57, 20)
        Me.lbCurrentPage.TabIndex = 214
        Me.lbCurrentPage.Text = "第    頁"
        '
        'btnFirstPage
        '
        Me.btnFirstPage.AutoSize = True
        Me.btnFirstPage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFirstPage.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnFirstPage.ForeColor = System.Drawing.SystemColors.Highlight
        Me.btnFirstPage.Location = New System.Drawing.Point(44, 1)
        Me.btnFirstPage.Name = "btnFirstPage"
        Me.btnFirstPage.Size = New System.Drawing.Size(57, 20)
        Me.btnFirstPage.TabIndex = 215
        Me.btnFirstPage.Text = "第一頁"
        '
        'btnLastPage
        '
        Me.btnLastPage.AutoSize = True
        Me.btnLastPage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLastPage.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnLastPage.ForeColor = System.Drawing.SystemColors.Highlight
        Me.btnLastPage.Location = New System.Drawing.Point(372, 1)
        Me.btnLastPage.Name = "btnLastPage"
        Me.btnLastPage.Size = New System.Drawing.Size(57, 20)
        Me.btnLastPage.TabIndex = 216
        Me.btnLastPage.Text = "最後頁"
        '
        'btnPrvPage
        '
        Me.btnPrvPage.AutoSize = True
        Me.btnPrvPage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrvPage.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnPrvPage.ForeColor = System.Drawing.SystemColors.Highlight
        Me.btnPrvPage.Location = New System.Drawing.Point(114, 1)
        Me.btnPrvPage.Name = "btnPrvPage"
        Me.btnPrvPage.Size = New System.Drawing.Size(81, 20)
        Me.btnPrvPage.TabIndex = 217
        Me.btnPrvPage.Text = "<<上一頁"
        '
        'btnNxtPage
        '
        Me.btnNxtPage.AutoSize = True
        Me.btnNxtPage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNxtPage.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnNxtPage.ForeColor = System.Drawing.SystemColors.Highlight
        Me.btnNxtPage.Location = New System.Drawing.Point(278, 1)
        Me.btnNxtPage.Name = "btnNxtPage"
        Me.btnNxtPage.Size = New System.Drawing.Size(81, 20)
        Me.btnNxtPage.TabIndex = 218
        Me.btnNxtPage.Text = "下一頁>>"
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.btnNxtPage)
        Me.Panel1.Controls.Add(Me.btnPrvPage)
        Me.Panel1.Controls.Add(Me.btnLastPage)
        Me.Panel1.Controls.Add(Me.btnFirstPage)
        Me.Panel1.Controls.Add(Me.lbCurrentPage)
        Me.Panel1.Controls.Add(Me.lbTotalPage)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(322, 88)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(659, 24)
        Me.Panel1.TabIndex = 219
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox1, 2)
        Me.GroupBox1.Controls.Add(Me.SetPageSize)
        Me.GroupBox1.Controls.Add(Me.NumUpDown)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(217, 54)
        Me.GroupBox1.TabIndex = 220
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "設定分頁"
        '
        'SetPageSize
        '
        Me.SetPageSize.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SetPageSize.Location = New System.Drawing.Point(140, 23)
        Me.SetPageSize.Name = "SetPageSize"
        Me.SetPageSize.Size = New System.Drawing.Size(70, 23)
        Me.SetPageSize.TabIndex = 221
        Me.SetPageSize.Text = "設定"
        Me.SetPageSize.UseVisualStyleBackColor = True
        '
        'NumUpDown
        '
        Me.NumUpDown.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.NumUpDown.Location = New System.Drawing.Point(46, 21)
        Me.NumUpDown.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumUpDown.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.NumUpDown.Name = "NumUpDown"
        Me.NumUpDown.ReadOnly = True
        Me.NumUpDown.Size = New System.Drawing.Size(61, 29)
        Me.NumUpDown.TabIndex = 223
        Me.NumUpDown.TabStop = False
        Me.NumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumUpDown.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(108, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 20)
        Me.Label4.TabIndex = 222
        Me.Label4.Text = "列"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 20)
        Me.Label1.TabIndex = 221
        Me.Label1.Text = "每頁"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.06359!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.23122!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.70519!))
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label19, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.SQL_Cb, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Enter, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DPGB, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(984, 692)
        Me.TableLayoutPanel1.TabIndex = 221
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.CreatePrompt = True
        Me.SaveFileDialog1.DefaultExt = "xls"
        '
        'OutGoods
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 692)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "OutGoods"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OutGoods"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DPGB.ResumeLayout(False)
        Me.DPGB.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label19 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Txt_1 As TextBox
    Friend WithEvents SQL_Cb As ComboBox
    Friend WithEvents DateTime1 As DateTimePicker
    Friend WithEvents DateTime2 As DateTimePicker
    Friend WithEvents DPGB As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Btn_Enter As Button
    Friend WithEvents lbTotalPage As Label
    Friend WithEvents lbCurrentPage As Label
    Friend WithEvents btnFirstPage As Label
    Friend WithEvents btnLastPage As Label
    Friend WithEvents btnPrvPage As Label
    Friend WithEvents btnNxtPage As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SetPageSize As Button
    Friend WithEvents NumUpDown As NumericUpDown
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
