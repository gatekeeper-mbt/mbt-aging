<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm_old
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
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm_old))
        Me.Btn_PRQA = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.PRQA_GroupBox = New System.Windows.Forms.GroupBox()
        Me.Btn_PRQA_SER = New System.Windows.Forms.Button()
        Me.Aging_GroupBox = New System.Windows.Forms.GroupBox()
        Me.Ex_Btn = New System.Windows.Forms.Button()
        Me.Btn_LAMPS = New System.Windows.Forms.Button()
        Me.Btn_Aging_2 = New System.Windows.Forms.Button()
        Me.Btn_Aging_REP = New System.Windows.Forms.Button()
        Me.Btn_LAMPS_SER = New System.Windows.Forms.Button()
        Me.Btn_Aging_1 = New System.Windows.Forms.Button()
        Me.PRCS_GroupBox = New System.Windows.Forms.GroupBox()
        Me.Btn_PRCS_REP = New System.Windows.Forms.Button()
        Me.Btn_PRCS_SER = New System.Windows.Forms.Button()
        Me.Btn_PRCS = New System.Windows.Forms.Button()
        Me.User_M = New System.Windows.Forms.Button()
        Me.Out_Btn = New System.Windows.Forms.Button()
        Me.PRQA_GroupBox.SuspendLayout()
        Me.Aging_GroupBox.SuspendLayout()
        Me.PRCS_GroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_PRQA
        '
        Me.Btn_PRQA.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_PRQA.Location = New System.Drawing.Point(16, 26)
        Me.Btn_PRQA.Name = "Btn_PRQA"
        Me.Btn_PRQA.Size = New System.Drawing.Size(129, 23)
        Me.Btn_PRQA.TabIndex = 1
        Me.Btn_PRQA.Text = "不良分析"
        Me.Btn_PRQA.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(449, 337)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(95, 25)
        Me.Cancel.TabIndex = 15
        Me.Cancel.Text = "結束"
        '
        'PRQA_GroupBox
        '
        Me.PRQA_GroupBox.Controls.Add(Me.Btn_PRQA_SER)
        Me.PRQA_GroupBox.Controls.Add(Me.Btn_PRQA)
        Me.PRQA_GroupBox.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.PRQA_GroupBox.Location = New System.Drawing.Point(392, 12)
        Me.PRQA_GroupBox.Name = "PRQA_GroupBox"
        Me.PRQA_GroupBox.Size = New System.Drawing.Size(151, 319)
        Me.PRQA_GroupBox.TabIndex = 16
        Me.PRQA_GroupBox.TabStop = False
        Me.PRQA_GroupBox.Text = "品保"
        '
        'Btn_PRQA_SER
        '
        Me.Btn_PRQA_SER.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_PRQA_SER.Location = New System.Drawing.Point(16, 76)
        Me.Btn_PRQA_SER.Name = "Btn_PRQA_SER"
        Me.Btn_PRQA_SER.Size = New System.Drawing.Size(129, 23)
        Me.Btn_PRQA_SER.TabIndex = 2
        Me.Btn_PRQA_SER.Text = "不良分析查詢"
        Me.Btn_PRQA_SER.UseVisualStyleBackColor = True
        '
        'Aging_GroupBox
        '
        Me.Aging_GroupBox.Controls.Add(Me.Ex_Btn)
        Me.Aging_GroupBox.Controls.Add(Me.Btn_LAMPS)
        Me.Aging_GroupBox.Controls.Add(Me.Btn_Aging_2)
        Me.Aging_GroupBox.Controls.Add(Me.Btn_Aging_REP)
        Me.Aging_GroupBox.Controls.Add(Me.Btn_LAMPS_SER)
        Me.Aging_GroupBox.Controls.Add(Me.Btn_Aging_1)
        Me.Aging_GroupBox.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Aging_GroupBox.Location = New System.Drawing.Point(25, 12)
        Me.Aging_GroupBox.Name = "Aging_GroupBox"
        Me.Aging_GroupBox.Size = New System.Drawing.Size(163, 319)
        Me.Aging_GroupBox.TabIndex = 17
        Me.Aging_GroupBox.TabStop = False
        Me.Aging_GroupBox.Text = "生產"
        '
        'Ex_Btn
        '
        Me.Ex_Btn.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Ex_Btn.Location = New System.Drawing.Point(16, 26)
        Me.Ex_Btn.Name = "Ex_Btn"
        Me.Ex_Btn.Size = New System.Drawing.Size(129, 23)
        Me.Ex_Btn.TabIndex = 6
        Me.Ex_Btn.Text = "抽氣"
        Me.Ex_Btn.UseVisualStyleBackColor = True
        '
        'Btn_LAMPS
        '
        Me.Btn_LAMPS.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_LAMPS.Location = New System.Drawing.Point(16, 183)
        Me.Btn_LAMPS.Name = "Btn_LAMPS"
        Me.Btn_LAMPS.Size = New System.Drawing.Size(129, 23)
        Me.Btn_LAMPS.TabIndex = 5
        Me.Btn_LAMPS.Text = "組裝輸入"
        Me.Btn_LAMPS.UseVisualStyleBackColor = True
        '
        'Btn_Aging_2
        '
        Me.Btn_Aging_2.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_Aging_2.Location = New System.Drawing.Point(16, 130)
        Me.Btn_Aging_2.Name = "Btn_Aging_2"
        Me.Btn_Aging_2.Size = New System.Drawing.Size(129, 23)
        Me.Btn_Aging_2.TabIndex = 4
        Me.Btn_Aging_2.Text = "Aging後段"
        Me.Btn_Aging_2.UseVisualStyleBackColor = True
        '
        'Btn_Aging_REP
        '
        Me.Btn_Aging_REP.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_Aging_REP.Location = New System.Drawing.Point(16, 285)
        Me.Btn_Aging_REP.Name = "Btn_Aging_REP"
        Me.Btn_Aging_REP.Size = New System.Drawing.Size(129, 23)
        Me.Btn_Aging_REP.TabIndex = 3
        Me.Btn_Aging_REP.Text = "Aging報表"
        Me.Btn_Aging_REP.UseVisualStyleBackColor = True
        '
        'Btn_LAMPS_SER
        '
        Me.Btn_LAMPS_SER.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_LAMPS_SER.Location = New System.Drawing.Point(16, 232)
        Me.Btn_LAMPS_SER.Name = "Btn_LAMPS_SER"
        Me.Btn_LAMPS_SER.Size = New System.Drawing.Size(129, 23)
        Me.Btn_LAMPS_SER.TabIndex = 2
        Me.Btn_LAMPS_SER.Text = "成燈查詢"
        Me.Btn_LAMPS_SER.UseVisualStyleBackColor = True
        '
        'Btn_Aging_1
        '
        Me.Btn_Aging_1.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_Aging_1.Location = New System.Drawing.Point(16, 76)
        Me.Btn_Aging_1.Name = "Btn_Aging_1"
        Me.Btn_Aging_1.Size = New System.Drawing.Size(129, 23)
        Me.Btn_Aging_1.TabIndex = 1
        Me.Btn_Aging_1.Text = "Aging前段"
        Me.Btn_Aging_1.UseVisualStyleBackColor = True
        '
        'PRCS_GroupBox
        '
        Me.PRCS_GroupBox.Controls.Add(Me.Btn_PRCS_REP)
        Me.PRCS_GroupBox.Controls.Add(Me.Btn_PRCS_SER)
        Me.PRCS_GroupBox.Controls.Add(Me.Btn_PRCS)
        Me.PRCS_GroupBox.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.PRCS_GroupBox.Location = New System.Drawing.Point(215, 12)
        Me.PRCS_GroupBox.Name = "PRCS_GroupBox"
        Me.PRCS_GroupBox.Size = New System.Drawing.Size(151, 319)
        Me.PRCS_GroupBox.TabIndex = 18
        Me.PRCS_GroupBox.TabStop = False
        Me.PRCS_GroupBox.Text = "客訴/品質異常"
        '
        'Btn_PRCS_REP
        '
        Me.Btn_PRCS_REP.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_PRCS_REP.Location = New System.Drawing.Point(16, 134)
        Me.Btn_PRCS_REP.Name = "Btn_PRCS_REP"
        Me.Btn_PRCS_REP.Size = New System.Drawing.Size(129, 46)
        Me.Btn_PRCS_REP.TabIndex = 3
        Me.Btn_PRCS_REP.Text = "客訴/品質異常處理維護報表"
        Me.Btn_PRCS_REP.UseVisualStyleBackColor = True
        '
        'Btn_PRCS_SER
        '
        Me.Btn_PRCS_SER.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_PRCS_SER.Location = New System.Drawing.Point(16, 81)
        Me.Btn_PRCS_SER.Name = "Btn_PRCS_SER"
        Me.Btn_PRCS_SER.Size = New System.Drawing.Size(129, 46)
        Me.Btn_PRCS_SER.TabIndex = 2
        Me.Btn_PRCS_SER.Text = "客訴/品質異常處理查詢"
        Me.Btn_PRCS_SER.UseVisualStyleBackColor = True
        '
        'Btn_PRCS
        '
        Me.Btn_PRCS.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_PRCS.Location = New System.Drawing.Point(16, 26)
        Me.Btn_PRCS.Name = "Btn_PRCS"
        Me.Btn_PRCS.Size = New System.Drawing.Size(129, 46)
        Me.Btn_PRCS.TabIndex = 1
        Me.Btn_PRCS.Text = "客訴/品質異常處理維護"
        Me.Btn_PRCS.UseVisualStyleBackColor = True
        '
        'User_M
        '
        Me.User_M.Location = New System.Drawing.Point(239, 337)
        Me.User_M.Name = "User_M"
        Me.User_M.Size = New System.Drawing.Size(95, 25)
        Me.User_M.TabIndex = 19
        Me.User_M.Text = "使用者管理(&U)"
        '
        'Out_Btn
        '
        Me.Out_Btn.Location = New System.Drawing.Point(344, 337)
        Me.Out_Btn.Name = "Out_Btn"
        Me.Out_Btn.Size = New System.Drawing.Size(95, 25)
        Me.Out_Btn.TabIndex = 20
        Me.Out_Btn.Text = "登出"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(574, 362)
        Me.Controls.Add(Me.Out_Btn)
        Me.Controls.Add(Me.User_M)
        Me.Controls.Add(Me.PRCS_GroupBox)
        Me.Controls.Add(Me.Aging_GroupBox)
        Me.Controls.Add(Me.PRQA_GroupBox)
        Me.Controls.Add(Me.Cancel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MBT System"
        Me.PRQA_GroupBox.ResumeLayout(False)
        Me.Aging_GroupBox.ResumeLayout(False)
        Me.PRCS_GroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_PRQA As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents PRQA_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_PRQA_SER As System.Windows.Forms.Button
    Friend WithEvents Aging_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_LAMPS_SER As System.Windows.Forms.Button
    Friend WithEvents Btn_Aging_1 As System.Windows.Forms.Button
    Friend WithEvents PRCS_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_PRCS_REP As System.Windows.Forms.Button
    Friend WithEvents Btn_PRCS_SER As System.Windows.Forms.Button
    Friend WithEvents Btn_PRCS As System.Windows.Forms.Button
    Friend WithEvents Btn_Aging_REP As System.Windows.Forms.Button
    Friend WithEvents Btn_Aging_2 As System.Windows.Forms.Button
    Friend WithEvents Btn_LAMPS As System.Windows.Forms.Button
    Friend WithEvents User_M As System.Windows.Forms.Button
    Friend WithEvents Out_Btn As System.Windows.Forms.Button
    Friend WithEvents Ex_Btn As Button
End Class
