<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Screen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_Screen))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.lblCurrentTime = New System.Windows.Forms.Label
        Me._Button = New System.Windows.Forms.Label
        Me.lblSessionRecord = New System.Windows.Forms.Label
        Me.XButton = New System.Windows.Forms.Label
        Me.lblDayRecord = New System.Windows.Forms.Label
        Me.lblLastDayRecord = New System.Windows.Forms.Label
        Me.lblMonthRecord = New System.Windows.Forms.Label
        Me.lblYearRecord = New System.Windows.Forms.Label
        Me.lblLastMonthRecord = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblResize = New System.Windows.Forms.Label
        Me.lblClearSession = New System.Windows.Forms.Label
        Me.lblAllSession = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Session Time Keeper 20060802.2"
        Me.NotifyIcon1.Visible = True
        '
        'lblCurrentTime
        '
        Me.lblCurrentTime.AutoSize = True
        Me.lblCurrentTime.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrentTime.ForeColor = System.Drawing.Color.LightBlue
        Me.lblCurrentTime.Location = New System.Drawing.Point(37, 17)
        Me.lblCurrentTime.Name = "lblCurrentTime"
        Me.lblCurrentTime.Size = New System.Drawing.Size(74, 13)
        Me.lblCurrentTime.TabIndex = 11
        Me.lblCurrentTime.Text = "lblCurrentTime"
        Me.ToolTip1.SetToolTip(Me.lblCurrentTime, "Current System Time")
        '
        '_Button
        '
        Me._Button.AutoSize = True
        Me._Button.BackColor = System.Drawing.Color.Transparent
        Me._Button.ForeColor = System.Drawing.Color.LightBlue
        Me._Button.Location = New System.Drawing.Point(228, 87)
        Me._Button.Name = "_Button"
        Me._Button.Size = New System.Drawing.Size(13, 13)
        Me._Button.TabIndex = 20
        Me._Button.Text = "_"
        Me.ToolTip1.SetToolTip(Me._Button, "Minimise Window ")
        '
        'lblSessionRecord
        '
        Me.lblSessionRecord.AutoSize = True
        Me.lblSessionRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblSessionRecord.Font = New System.Drawing.Font("Arial Black", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSessionRecord.ForeColor = System.Drawing.Color.LightBlue
        Me.lblSessionRecord.Location = New System.Drawing.Point(34, 30)
        Me.lblSessionRecord.Name = "lblSessionRecord"
        Me.lblSessionRecord.Size = New System.Drawing.Size(275, 38)
        Me.lblSessionRecord.TabIndex = 12
        Me.lblSessionRecord.Text = "lblSessionRecord"
        Me.ToolTip1.SetToolTip(Me.lblSessionRecord, "Session Time Recorded")
        '
        'XButton
        '
        Me.XButton.AutoSize = True
        Me.XButton.BackColor = System.Drawing.Color.Transparent
        Me.XButton.ForeColor = System.Drawing.Color.LightBlue
        Me.XButton.Location = New System.Drawing.Point(246, 87)
        Me.XButton.Name = "XButton"
        Me.XButton.Size = New System.Drawing.Size(14, 13)
        Me.XButton.TabIndex = 19
        Me.XButton.Text = "X"
        Me.ToolTip1.SetToolTip(Me.XButton, "Close Application")
        '
        'lblDayRecord
        '
        Me.lblDayRecord.AutoSize = True
        Me.lblDayRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblDayRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDayRecord.ForeColor = System.Drawing.Color.LightBlue
        Me.lblDayRecord.Location = New System.Drawing.Point(70, 65)
        Me.lblDayRecord.Name = "lblDayRecord"
        Me.lblDayRecord.Size = New System.Drawing.Size(92, 16)
        Me.lblDayRecord.TabIndex = 13
        Me.lblDayRecord.Text = "lblDayRecord"
        Me.ToolTip1.SetToolTip(Me.lblDayRecord, "Day Time Recorded")
        '
        'lblLastDayRecord
        '
        Me.lblLastDayRecord.AutoSize = True
        Me.lblLastDayRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblLastDayRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastDayRecord.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.lblLastDayRecord.Location = New System.Drawing.Point(213, 55)
        Me.lblLastDayRecord.Name = "lblLastDayRecord"
        Me.lblLastDayRecord.Size = New System.Drawing.Size(89, 13)
        Me.lblLastDayRecord.TabIndex = 18
        Me.lblLastDayRecord.Text = "lblLastDayRecord"
        Me.ToolTip1.SetToolTip(Me.lblLastDayRecord, "Yesterday Time Recorded")
        '
        'lblMonthRecord
        '
        Me.lblMonthRecord.AutoSize = True
        Me.lblMonthRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblMonthRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthRecord.ForeColor = System.Drawing.Color.SkyBlue
        Me.lblMonthRecord.Location = New System.Drawing.Point(213, 30)
        Me.lblMonthRecord.Name = "lblMonthRecord"
        Me.lblMonthRecord.Size = New System.Drawing.Size(80, 13)
        Me.lblMonthRecord.TabIndex = 14
        Me.lblMonthRecord.Text = "lblMonthRecord"
        Me.ToolTip1.SetToolTip(Me.lblMonthRecord, "Month Time Recorded")
        '
        'lblYearRecord
        '
        Me.lblYearRecord.AutoSize = True
        Me.lblYearRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblYearRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearRecord.ForeColor = System.Drawing.Color.SkyBlue
        Me.lblYearRecord.Location = New System.Drawing.Point(213, 43)
        Me.lblYearRecord.Name = "lblYearRecord"
        Me.lblYearRecord.Size = New System.Drawing.Size(72, 13)
        Me.lblYearRecord.TabIndex = 15
        Me.lblYearRecord.Text = "lblYearRecord"
        Me.ToolTip1.SetToolTip(Me.lblYearRecord, "Year Time Recorded")
        '
        'lblLastMonthRecord
        '
        Me.lblLastMonthRecord.AutoSize = True
        Me.lblLastMonthRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblLastMonthRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastMonthRecord.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.lblLastMonthRecord.Location = New System.Drawing.Point(213, 68)
        Me.lblLastMonthRecord.Name = "lblLastMonthRecord"
        Me.lblLastMonthRecord.Size = New System.Drawing.Size(100, 13)
        Me.lblLastMonthRecord.TabIndex = 16
        Me.lblLastMonthRecord.Text = "lblLastMonthRecord"
        Me.ToolTip1.SetToolTip(Me.lblLastMonthRecord, "Last Month Time Recorded")
        '
        'Button1
        '
        Me.Button1.AutoSize = True
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.Location = New System.Drawing.Point(39, 87)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(46, 12)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "RECORD"
        Me.ToolTip1.SetToolTip(Me.Button1, "Start Recording Session")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SkyBlue
        Me.Label1.Location = New System.Drawing.Point(200, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "M"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SkyBlue
        Me.Label2.Location = New System.Drawing.Point(200, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Y"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.Label3.Location = New System.Drawing.Point(195, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "LD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.LightSteelBlue
        Me.Label4.Location = New System.Drawing.Point(194, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "LM"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.LightBlue
        Me.Label5.Location = New System.Drawing.Point(57, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 16)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "D"
        '
        'lblResize
        '
        Me.lblResize.AutoSize = True
        Me.lblResize.BackColor = System.Drawing.Color.Transparent
        Me.lblResize.ForeColor = System.Drawing.Color.Silver
        Me.lblResize.Location = New System.Drawing.Point(11, 29)
        Me.lblResize.Name = "lblResize"
        Me.lblResize.Size = New System.Drawing.Size(15, 13)
        Me.lblResize.TabIndex = 27
        Me.lblResize.Text = "R"
        Me.ToolTip1.SetToolTip(Me.lblResize, "Resize Timer Window")
        '
        'lblClearSession
        '
        Me.lblClearSession.AutoSize = True
        Me.lblClearSession.BackColor = System.Drawing.Color.Transparent
        Me.lblClearSession.ForeColor = System.Drawing.Color.DarkGray
        Me.lblClearSession.Location = New System.Drawing.Point(12, 42)
        Me.lblClearSession.Name = "lblClearSession"
        Me.lblClearSession.Size = New System.Drawing.Size(14, 13)
        Me.lblClearSession.TabIndex = 28
        Me.lblClearSession.Text = "C"
        Me.ToolTip1.SetToolTip(Me.lblClearSession, "Clear Session Timer")
        '
        'lblAllSession
        '
        Me.lblAllSession.AutoSize = True
        Me.lblAllSession.BackColor = System.Drawing.Color.Transparent
        Me.lblAllSession.ForeColor = System.Drawing.Color.DarkGray
        Me.lblAllSession.Location = New System.Drawing.Point(12, 55)
        Me.lblAllSession.Name = "lblAllSession"
        Me.lblAllSession.Size = New System.Drawing.Size(14, 13)
        Me.lblAllSession.TabIndex = 29
        Me.lblAllSession.Text = "A"
        Me.ToolTip1.SetToolTip(Me.lblAllSession, "Clear All Timers")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.DarkGray
        Me.Label6.Location = New System.Drawing.Point(12, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "T"
        Me.ToolTip1.SetToolTip(Me.Label6, "Toggle 'Always on Top'")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Silver
        Me.Label7.Location = New System.Drawing.Point(12, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "V"
        Me.ToolTip1.SetToolTip(Me.Label7, "Manually Override Values")
        '
        'Main_Screen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(297, 117)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblAllSession)
        Me.Controls.Add(Me.lblClearSession)
        Me.Controls.Add(Me.lblResize)
        Me.Controls.Add(Me.lblDayRecord)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblCurrentTime)
        Me.Controls.Add(Me._Button)
        Me.Controls.Add(Me.XButton)
        Me.Controls.Add(Me.lblLastDayRecord)
        Me.Controls.Add(Me.lblMonthRecord)
        Me.Controls.Add(Me.lblYearRecord)
        Me.Controls.Add(Me.lblLastMonthRecord)
        Me.Controls.Add(Me.lblSessionRecord)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(297, 117)
        Me.MinimizeBox = False
        Me.Name = "Main_Screen"
        Me.ShowInTaskbar = False
        Me.Text = "Session Time Keeper"
        Me.TransparencyKey = System.Drawing.Color.White
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents lblCurrentTime As System.Windows.Forms.Label
    Friend WithEvents _Button As System.Windows.Forms.Label
    Friend WithEvents lblSessionRecord As System.Windows.Forms.Label
    Friend WithEvents XButton As System.Windows.Forms.Label
    Friend WithEvents lblDayRecord As System.Windows.Forms.Label
    Friend WithEvents lblLastDayRecord As System.Windows.Forms.Label
    Friend WithEvents lblMonthRecord As System.Windows.Forms.Label
    Friend WithEvents lblYearRecord As System.Windows.Forms.Label
    Friend WithEvents lblLastMonthRecord As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblResize As System.Windows.Forms.Label
    Friend WithEvents lblClearSession As System.Windows.Forms.Label
    Friend WithEvents lblAllSession As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
