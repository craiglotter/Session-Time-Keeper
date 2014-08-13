Imports System.IO

Public Class Main_Screen

    Private recordStatus As Boolean = False

    Private Const WM_NCHITTEST As Integer = &H84
    Private Const HTCLIENT As Integer = &H1
    Private Const HTCAPTION As Integer = &H2

    Dim currentdate As String

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_NCHITTEST
                MyBase.WndProc(m)
                If (m.Result.ToInt32 = HTCLIENT) Then
                    m.Result = IntPtr.op_Explicit(HTCAPTION)
                End If
                Exit Sub
        End Select

        MyBase.WndProc(m)
    End Sub

    Private Sub Error_Handler(ByVal ex As Exception, Optional ByVal identifier_msg As String = "")
        Try
            If My.Computer.FileSystem.FileExists((Application.StartupPath & "\Sounds\UHOH.WAV").Replace("\\", "\")) = True Then
                My.Computer.Audio.Play((Application.StartupPath & "\Sounds\UHOH.WAV").Replace("\\", "\"), AudioPlayMode.Background)
            End If
            If ex.Message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message()
                Display_Message1.Message_Textbox.Text = "The Application encountered the following problem: " & vbCrLf & identifier_msg & ":" & ex.Message.ToString
                Display_Message1.Timer1.Interval = 1000
                Display_Message1.ShowDialog()
                Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs")
                If dir.Exists = False Then
                    dir.Create()
                End If
                dir = Nothing
                Dim filewriter As System.IO.StreamWriter = New System.IO.StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt", True)
                filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & identifier_msg & ":" & ex.ToString)
                filewriter.Flush()
                filewriter.Close()
                filewriter = Nothing
            End If
        Catch exc As Exception
            MsgBox("An error occurred in the application's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub


    Private Sub Activity_Handler(ByVal Message As String)
        Try
            Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs")
            If dir.Exists = False Then
                dir.Create()
            End If
            dir = Nothing
            Dim filewriter As System.IO.StreamWriter = New System.IO.StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs\" & Format(Now(), "yyyyMMdd") & "_Activity_Log.txt", True)
            filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy HH:mm:ss") & " - " & Message)
            filewriter.Flush()
            filewriter.Close()
            filewriter = Nothing
        Catch ex As Exception
            Error_Handler(ex, "Activity_Logger")
        End Try
    End Sub

    Private Sub SessionTimeUpdate(ByVal input As Label)
        Try

        
            Dim seconds As String = "00"
            Dim minutes As String = "00"
            Dim hours As String = "00"
            Dim myarray() As String = input.Text.Split(":")
            If myarray.Length = 3 Then
                seconds = myarray(2)
                minutes = myarray(1)
                hours = myarray(0)
            End If

            seconds = CInt(seconds) + 1

            If CInt(seconds) > 59 Then
                seconds = 0
                minutes = CInt(minutes) + 1
                If CInt(minutes) > 59 Then
                    minutes = 0
                    hours = CInt(hours) + 1
                End If
            End If
            While seconds.Length < 2
                seconds = "0" & seconds
            End While
            While minutes.Length < 2
                minutes = "0" & minutes
            End While
            While hours.Length < 2
                hours = "0" & hours
            End While
            myarray = Nothing
            input.Text = hours & ":" & minutes & ":" & seconds
        Catch ex As Exception
            Error_Handler(ex, "SessionTimeUpdate")
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            If Not currentdate = Format(Now(), "yyyyMMdd") Then
                HandleDateChange()
                currentdate = Format(Now(), "yyyyMMdd")
            End If
            lblCurrentTime.Text = Format(Now(), "dd/MM/yyyy HH:mm:ss")
            If recordStatus = True Then
                SessionTimeUpdate(lblSessionRecord)
                SessionTimeUpdate(lblDayRecord)
                SessionTimeUpdate(lblMonthRecord)
                SessionTimeUpdate(lblYearRecord)
            End If
        Catch ex As Exception
            Error_Handler(ex, "Timer Tick")
        End Try
    End Sub

    Private Sub RecordSwitch()
        Try
            If recordStatus = False Then
                Button1.Text = "PAUSE"
                recordStatus = True
                lblSessionRecord.ForeColor = Color.MediumAquamarine
            Else
                Button1.Text = "RECORD"
                recordStatus = False
                lblSessionRecord.ForeColor = Color.LightBlue
            End If
        Catch ex As Exception
            Error_Handler(ex, "Record Button Press")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RecordSwitch()
    End Sub

    Private Sub KeyPressed(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Enter) Or (e.KeyCode = Keys.Space) Then
            RecordSwitch()
        End If
    End Sub

    Private Sub Load_Settings()
        Try
            If Not My.Settings.DayRecord = "" And Not My.Settings.DayRecord Is Nothing Then
                lblDayRecord.Text = My.Settings.DayRecord
            Else
                lblDayRecord.Text = "00:00:00"
            End If

            If Not My.Settings.MonthRecord = "" And Not My.Settings.MonthRecord Is Nothing Then
                lblMonthRecord.Text = My.Settings.MonthRecord
            Else
                lblMonthRecord.Text = "00:00:00"
            End If

            If Not My.Settings.LastMonthRecord = "" And Not My.Settings.LastMonthRecord Is Nothing Then
                lblLastMonthRecord.Text = My.Settings.LastMonthRecord
            Else
                lblLastMonthRecord.Text = "00:00:00"
            End If

            If Not My.Settings.LastDayRecord = "" And Not My.Settings.LastDayRecord Is Nothing Then
                lblLastDayRecord.Text = My.Settings.LastDayRecord
            Else
                lblLastDayRecord.Text = "00:00:00"
            End If

            If Not My.Settings.YearRecord = "" And Not My.Settings.YearRecord Is Nothing Then
                lblYearRecord.Text = My.Settings.YearRecord
            Else
                lblYearRecord.Text = "00:00:00"
            End If
        Catch ex As Exception
            Error_Handler(ex, "Load Settings")
        End Try
    End Sub

    Private Sub Save_Settings()
        Try
            My.Settings.Reset()
            My.Settings.DayRecord = lblDayRecord.Text
            My.Settings.MonthRecord = lblMonthRecord.Text
            My.Settings.LastMonthRecord = lblLastMonthRecord.Text
            My.Settings.LastDayRecord = lblLastDayRecord.Text
            My.Settings.YearRecord = lblYearRecord.Text

            My.Settings.Save()

        Catch ex As Exception
            Error_Handler(ex, "Save Settings")
        End Try
    End Sub

  


    Private Sub Main_Screen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            currentdate = Format(Now().AddDays(-1), "yyyyMMdd")
            WindowShow()

            lblCurrentTime.Text = Format(Now(), "dd/MM/yyyy HH:mm:ss")
            lblSessionRecord.Text = "00:00:00"
            Load_Settings()







            Dim logfile As String
            logfile = (Application.StartupPath & "\").Replace("\\", "\") & "Time_Records.tme"

            If My.Computer.FileSystem.FileExists(logfile) = True Then
                Dim filereader As StreamReader = New StreamReader(logfile)
                Dim lineread As String = ""
                While filereader.Peek <> -1
                    lineread = filereader.ReadLine()
                End While
                filereader.Close()
                filereader = Nothing
                Dim lastdaywritten As String

                lastdaywritten = lineread.Substring(0, 8)

                If Not lastdaywritten.Substring(0, 4) = (currentdate).Substring(0, 4) Then
                    lblYearRecord.Text = "00:00:00"
                End If
                If Not lastdaywritten.Substring(4, 2) = (currentdate).Substring(4, 2) Then
                    lblLastMonthRecord.Text = lblMonthRecord.Text
                    lblMonthRecord.Text = "00:00:00"
                End If

            End If


            If Not currentdate = Format(Now(), "yyyyMMdd") Then
                HandleDateChange()
                currentdate = Format(Now(), "yyyyMMdd")
            End If


            Me.Focus()
        Catch ex As Exception
            Error_Handler(ex, "Main_Screen_Load")
        End Try
    End Sub

    Private Sub Main_Screen_Close(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Save_Settings()
        Catch ex As Exception
            Error_Handler(ex, "Main_Screen_Close")
        End Try

    End Sub


    Private Sub XButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XButton.Click
        Try
            Me.Close()
        Catch ex As Exception
            Error_Handler(ex, "X Button")
        End Try
    End Sub


    Private Sub WindowHide()
        Me.Visible = False
        Me.Opacity = 0
        Me.WindowState = FormWindowState.Minimized
        Me.NotifyIcon1.Visible = True
        Me.Focus()
    End Sub

    Private Sub WindowShow()
        Me.Visible = True
        Me.Opacity = 100
        Me.WindowState = FormWindowState.Normal
        Me.NotifyIcon1.Visible = False
        Me.Focus()
    End Sub

    Private Sub _Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _Button.Click
        Try
            WindowHide()
        Catch ex As Exception
            Error_Handler(ex, "_ Button")
        End Try
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Try
            WindowShow()
        Catch ex As Exception
            Error_Handler(ex, "NotifyIcon1_MouseDoubleClick")
        End Try

    End Sub

    Private Sub HandleDateChange()
        Try
            If Not currentdate.Substring(0, 4) = (Format(Now(), "yyyyMMdd")).Substring(0, 4) Then
                lblYearRecord.Text = "00:00:00"
            End If
            If Not currentdate.Substring(4, 2) = (Format(Now(), "yyyyMMdd")).Substring(4, 2) Then
                lblLastMonthRecord.Text = lblMonthRecord.Text
                lblMonthRecord.Text = "00:00:00"
            End If


            Dim logfile As String
            logfile = (Application.StartupPath & "\").Replace("\\", "\") & "Time_Records.tme"

            Dim writefilecheck As Boolean = False
            If My.Computer.FileSystem.FileExists(logfile) = True Then
                Dim filereader As StreamReader = New StreamReader(logfile)
                Dim lineread As String = ""
                While filereader.Peek <> -1
                    lineread = filereader.ReadLine()
                End While
                filereader.Close()
                filereader = Nothing
                Dim lastdaywritten As String

                lastdaywritten = lineread.Substring(0, 8)

                If Not lastdaywritten = Format(Now().AddDays(-1), "yyyyMMdd") Then
                    writefilecheck = True
                    lblLastDayRecord.Text = lblDayRecord.Text
                    lblDayRecord.Text = "00:00:00"
                End If
            Else
                writefilecheck = True
                lblLastDayRecord.Text = lblDayRecord.Text
                lblDayRecord.Text = "00:00:00"
            End If
            If writefilecheck = True Then
                Dim filewriter As StreamWriter = New StreamWriter(logfile, True)
                filewriter.WriteLine(Format(Now().AddDays(-1), "yyyyMMdd") & " " & lblLastDayRecord.Text)
                filewriter.Close()
                filewriter = Nothing
            End If


        Catch ex As Exception
            Error_Handler(ex, "HandleDateChange")
        End Try
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblResize.Click
        Try

       
            If Me.Width = 297 Then
                Me.Width = 215
                Me.Height = 44
                Me.lblSessionRecord.Left = 42
                Me.lblSessionRecord.Top = 9
                Me.lblCurrentTime.Visible = False
                Me.Label1.Visible = False
            Else
                Me.Width = 297
                Me.Height = 117
                Me.lblSessionRecord.Left = 34
                Me.lblSessionRecord.Top = 30
                Me.lblCurrentTime.Visible = True
                Me.Label1.Visible = True
            End If

            Me.Refresh()
        Catch ex As Exception
            Error_Handler(ex, "Label6_Click")
        End Try
    End Sub

    Private Sub lblClearSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClearSession.Click
        Try
            lblSessionRecord.Text = "00:00:00"

        Catch ex As Exception
            Error_Handler(ex, "lblClearSession_Click")
        End Try
     
    End Sub

    Private Sub lblAllSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAllSession.Click
        Try
            lblSessionRecord.Text = "00:00:00"
            lblDayRecord.Text = "00:00:00"
            lblMonthRecord.Text = "00:00:00"
            lblYearRecord.Text = "00:00:00"

            My.Settings.Reset()
            My.Settings.DayRecord = lblDayRecord.Text
            My.Settings.MonthRecord = lblMonthRecord.Text
            My.Settings.YearRecord = lblYearRecord.Text

            My.Settings.Save()
        Catch ex As Exception
            Error_Handler(ex, "lblClearSession_Click")
        End Try
    End Sub

    Private Sub Label6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Try
            If Me.TopMost = True Then
                Me.TopMost = False
            Else
                Me.TopMost = True
            End If
        Catch ex As Exception
            Error_Handler(ex, "'Always on Top' Toggle")
        End Try
    End Sub



    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Try
            Dim result As DialogResult
            Dim override As Manual_Override = New Manual_Override()
            override.day = lblDayRecord.Text
            override.month = lblMonthRecord.Text
            override.year = lblYearRecord.Text
            override.lastday = lblLastDayRecord.Text
            override.lastmonth = lblLastMonthRecord.Text


            result = override.ShowDialog
            If result = Windows.Forms.DialogResult.OK Then
                Select Case override.ComboBox1.SelectedIndex
                    Case 0
                        lblDayRecord.Text = override.TextBox1.Text & ":" & override.TextBox2.Text & ":" & override.TextBox3.Text
                    Case 1
                        lblMonthRecord.Text = override.TextBox1.Text & ":" & override.TextBox2.Text & ":" & override.TextBox3.Text
                    Case 2
                        lblYearRecord.Text = override.TextBox1.Text & ":" & override.TextBox2.Text & ":" & override.TextBox3.Text
                    Case 3
                        lblLastDayRecord.Text = override.TextBox1.Text & ":" & override.TextBox2.Text & ":" & override.TextBox3.Text
                    Case 4
                        lblLastMonthRecord.Text = override.TextBox1.Text & ":" & override.TextBox2.Text & ":" & override.TextBox3.Text
                    Case Else
                        MsgBox("No changes were made due to an error in your inputs", MsgBoxStyle.Information, "Input Error")
                End Select
            End If
            override.Close()
            override.Dispose()
            override = Nothing
        Catch ex As Exception
            Error_Handler(ex, "Manual Override")
        End Try
    End Sub
End Class