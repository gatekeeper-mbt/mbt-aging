<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class management
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Type = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXT_Name = New System.Windows.Forms.TextBox()
        Me.TXT_Type = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 92)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(328, 448)
        Me.DataGridView1.TabIndex = 18
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Type)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TXT_Name)
        Me.Panel1.Controls.Add(Me.TXT_Type)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(328, 81)
        Me.Panel1.TabIndex = 19
        '
        'Type
        '
        Me.Type.AutoSize = True
        Me.Type.Location = New System.Drawing.Point(42, 3)
        Me.Type.Name = "Type"
        Me.Type.Size = New System.Drawing.Size(29, 12)
        Me.Type.TabIndex = 6
        Me.Type.Text = "Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(191, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "名稱"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "型號"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(178, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(9, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "-"
        '
        'TXT_Name
        '
        Me.TXT_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_Name.Location = New System.Drawing.Point(193, 41)
        Me.TXT_Name.Name = "TXT_Name"
        Me.TXT_Name.Size = New System.Drawing.Size(126, 22)
        Me.TXT_Name.TabIndex = 2
        '
        'TXT_Type
        '
        Me.TXT_Type.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_Type.Location = New System.Drawing.Point(44, 41)
        Me.TXT_Type.Name = "TXT_Type"
        Me.TXT_Type.Size = New System.Drawing.Size(126, 22)
        Me.TXT_Type.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "機種:"
        '
        'management
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 565)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "management"
        Me.Text = "management"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TXT_Type As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TXT_Name As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Type As Label
End Class
