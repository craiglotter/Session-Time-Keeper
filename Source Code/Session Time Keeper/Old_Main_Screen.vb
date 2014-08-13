Imports System
Imports System.IO
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms


Public Class Old_Main_Screen


    Private lastinputline As String = ""
    Private inputlines As Long = 0
    Private statusmessage As String = ""
    Private highestPercentageReached As Integer = 0
    Private inputlinesprecount As Long = 0
    Private datelaunched As Date = Now()
    Private pretestdone As Boolean = False





    Private Sub Error_Handler(ByVal ex As Exception, Optional ByVal identifier_msg As String = "")
        Try
            If File_Exists((Application.StartupPath & "\Sounds\UHOH.WAV").Replace("\\", "\")) = True Then
                My.Computer.Audio.Play((Application.StartupPath & "\Sounds\UHOH.WAV").Replace("\\", "\"), AudioPlayMode.Background)
            End If
            If ex.Message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message()
                If FullErrors_Checkbox.Checked = True Then
                    Display_Message1.Message_Textbox.Text = "The Application encountered the following problem: " & vbCrLf & identifier_msg & ":" & ex.ToString
                Else
                    Display_Message1.Message_Textbox.Text = "The Application encountered the following problem: " & vbCrLf & identifier_msg & ":" & ex.Message.ToString
                End If
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
            filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & Message)
            filewriter.Flush()
            filewriter.Close()
            filewriter = Nothing
        Catch ex As Exception
            Error_Handler(ex, "Activity_Logger")
        End Try
    End Sub

    Private Sub Status_Handler(ByVal Message As String)
        Try
            Status_Textbox.Text = Message.ToUpper
            Status_Textbox.Select(0, 0)
        Catch ex As Exception
            Error_Handler(ex, "Status_Handler")
        End Try
    End Sub


    Private Sub InputFolder_Textbox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles InputSource_Textbox.DragEnter, InputDestination_Textbox.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.All
            End If
        Catch ex As Exception
            Error_Handler(ex, "InputFolder_Textbox_DragEnter")
        End Try
    End Sub

    Private Sub InputFolder_Textbox_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles InputSource_Textbox.DragDrop, InputDestination_Textbox.DragDrop
        Try

            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim MyFiles() As String
                ' Assign the files to an array.
                MyFiles = e.Data.GetData(DataFormats.FileDrop)
                ' Loop through the array and add the files to the list.
                'For i = 0 To MyFiles.Length - 1
                If MyFiles.Length > 0 Then
                    Dim dinfo As DirectoryInfo = New DirectoryInfo(MyFiles(0))
                    If dinfo.Exists = True Then

                        If sender.Equals(InputDestination_Textbox) = True Then
                            InputDestination_Textbox.Text = (MyFiles(0))
                        End If
                        If sender.Equals(InputSource_Textbox) = True Then
                            InputSource_Textbox.Text = (MyFiles(0))
                        End If
                    End If
                    dinfo = Nothing
                End If
                'Next
            End If
        Catch ex As Exception
            Error_Handler(ex, "InputFolder_Textbox DragDrop")
        End Try
    End Sub


    Private Sub Browse1_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse1_Button.Click
        Status_Handler("Selecting Source Folder")
        Try
            FolderBrowserDialog1.Description = "Select the source folder from which the files and folders will be copied from."
            If Directory_Exists(InputSource_Textbox.Text) = True Then
                FolderBrowserDialog1.SelectedPath = InputSource_Textbox.Text
            End If
            Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                InputSource_Textbox.Text = FolderBrowserDialog1.SelectedPath
            End If

        Catch ex As Exception
            Error_Handler(ex, "Browse1_Button")
        End Try
        Status_Handler("Source Folder Selected")
    End Sub

    Private Sub Browse2_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse2_Button.Click
        Status_Handler("Selecting Destination Folder")
        Try
            FolderBrowserDialog1.Description = "Select the destination folder to which the files and folders will be copied to."
            If Directory_Exists(InputDestination_Textbox.Text) = True Then
                FolderBrowserDialog1.SelectedPath = InputDestination_Textbox.Text
            End If
            Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                InputDestination_Textbox.Text = FolderBrowserDialog1.SelectedPath
            End If

        Catch ex As Exception
            Error_Handler(ex, "Browse2_Button")
        End Try
        Status_Handler("Destination Folder Selected")
    End Sub

    Private Function File_Exists(ByVal file_path As String) As Boolean
        Dim result As Boolean = False
        Try
            If Not file_path = "" And Not file_path Is Nothing Then
                Dim dinfo As FileInfo = New FileInfo(file_path)
                If dinfo.Exists = False Then
                    result = False
                Else
                    result = True
                End If
                dinfo = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex, "File_Exists")
        End Try
        Return result
    End Function

    Private Function Directory_Exists(ByVal directory_path As String) As Boolean
        Dim result As Boolean = False
        Try
            If Not directory_path = "" And Not directory_path Is Nothing Then
                Dim dinfo As DirectoryInfo = New DirectoryInfo(directory_path)
                If dinfo.Exists = False Then
                    result = False
                Else
                    result = True
                End If
                dinfo = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex, "Directory_Exists")
        End Try
        Return result
    End Function


    Private Sub Load_Settings()
        Try
            If Not My.Settings.InputSource_Textbox = "" And Not My.Settings.InputSource_Textbox Is Nothing Then
                Dim folderexists As Boolean
                folderexists = My.Computer.FileSystem.DirectoryExists(My.Settings.InputSource_Textbox)
                If folderexists = True Then
                    InputSource_Textbox.Text = My.Settings.InputSource_Textbox
                End If
            End If

            If Not My.Settings.InputDestination_Textbox = "" And Not My.Settings.InputDestination_Textbox Is Nothing Then
                Dim folderexists As Boolean
                folderexists = My.Computer.FileSystem.DirectoryExists(My.Settings.InputDestination_Textbox)
                If folderexists = True Then
                    InputDestination_Textbox.Text = My.Settings.InputDestination_Textbox
                End If
            End If

            Select Case My.Settings.FullErrors_Checkbox
                Case True
                    FullErrors_Checkbox.Checked = True
                    Exit Select
                Case False
                    FullErrors_Checkbox.Checked = False
                    Exit Select
                Case Else
                    FullErrors_Checkbox.Checked = False
                    Exit Select
            End Select

            Status_Handler("Loaded Program Saved Values")
        Catch ex As Exception
            Error_Handler(ex, "Load Settings")
        End Try
    End Sub

    Private Sub Save_Settings()
        Try
            My.Settings.Reset()
            My.Settings.InputDestination_Textbox = InputDestination_Textbox.Text
            My.Settings.InputSource_Textbox = InputSource_Textbox.Text

            Select Case FullErrors_Checkbox.Checked
                Case True
                    My.Settings.FullErrors_Checkbox = True
                    Exit Select
                Case False
                    My.Settings.FullErrors_Checkbox = False
                    Exit Select
                Case Else
                    My.Settings.FullErrors_Checkbox = False
                    Exit Select
            End Select


            My.Settings.Save()
            Status_Handler("Saved Program Saved Values")
        Catch ex As Exception
            Error_Handler(ex, "Save Settings")
        End Try
    End Sub


    Private Sub Main_Screen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Load_Settings()
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

    Private Sub InputSource_Textbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputSource_Textbox.TextChanged
        Status_Handler("Input Folder Selected")
    End Sub
    Private Sub InputDestination_Textbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputDestination_Textbox.TextChanged
        Status_Handler("Destination Folder Selected")
    End Sub




    Private Sub startAsyncButton_Click(ByVal sender As System.Object, _
     ByVal e As System.EventArgs) _
     Handles startAsyncButton.Click

        Try
            statusmessage = "Initializing Application for Operation Launch"
            Status_Handler(statusmessage)

            ' Reset the text in the result label.

            inputlines_label.Text = [String].Empty
            lastinputline_label.Text = [String].Empty
            datelaunched_label.Text = [String].Empty


            inputlines = 0
            lastinputline = ""
            statusmessage = ""
            highestPercentageReached = 0
            inputlinesprecount = 0
            datelaunched = Now()
            pretestdone = False


            Controls_Enabler("run")


            ' Start the asynchronous operation.
            Me.LinkLabel1.Visible = True
            Me.LinkLabel2.Visible = True
            BackgroundWorker1.RunWorkerAsync(InputDestination_Textbox.Text)

        Catch ex As Exception
            Error_Handler(ex, "startAsyncButton_Click")
        End Try
    End Sub 'startAsyncButton_Click


    Private Sub cancelAsyncButton_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles cancelAsyncButton.Click

        ' Cancel the asynchronous operation.
        Me.backgroundWorker1.CancelAsync()

        ' Disable the Cancel button.
        cancelAsyncButton.Enabled = False

    End Sub 'cancelAsyncButton_Click

    ' This event handler is where the actual work is done.
    Private Sub backgroundWorker1_DoWork( _
    ByVal sender As Object, _
    ByVal e As DoWorkEventArgs) _
    Handles BackgroundWorker1.DoWork

        ' Get the BackgroundWorker object that raised this event.
        Dim worker As BackgroundWorker = _
            CType(sender, BackgroundWorker)

        ' Assign the result of the computation
        ' to the Result property of the DoWorkEventArgs
        ' object. This is will be available to the 
        ' RunWorkerCompleted eventhandler.
        e.Result = MainWorkerFunction(e.Argument, worker, e)
    End Sub 'backgroundWorker1_DoWork

    ' This event handler deals with the results of the
    ' background operation.
    Private Sub backgroundWorker1_RunWorkerCompleted( _
    ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
    Handles BackgroundWorker1.RunWorkerCompleted

        ' First, handle the case where an exception was thrown.
        If Not (e.Error Is Nothing) Then
            Error_Handler(e.Error, "backgroundWorker1_RunWorkerCompleted")
        ElseIf e.Cancelled Then
            ' Next, handle the case where the user canceled the 
            ' operation.
            ' Note that due to a race condition in 
            ' the DoWork event handler, the Cancelled
            ' flag may not have been set, even though
            ' CancelAsync was called.
            Me.ProgressBar1.Value = 0
            inputlines_label.Text = "Cancelled (" & inputlines & " of " & inputlinesprecount & ")"
            lastinputline_label.Text = "Cancelled"
            datelaunched_label.Text = "Cancelled"
            If File_Exists((Application.StartupPath & "\Sounds\HEEY.WAV").Replace("\\", "\")) = True Then
                My.Computer.Audio.Play((Application.StartupPath & "\Sounds\HEEY.WAV").Replace("\\", "\"), AudioPlayMode.Background)
            End If
            statusmessage = "Operation Cancelled"
        Else
            ' Finally, handle the case where the operation succeeded.

            Status_Handler(e.Result)

            Me.ProgressBar1.Value = 100
            Me.inputlines_label.Text = inputlines & " of " & inputlinesprecount
            Me.lastinputline_label.Text = lastinputline
            Me.datelaunched_label.Text = Format(datelaunched, "yyyy/MM/dd HH:mm:ss") & " - " & Format(Now, "yyyy/MM/dd HH:mm:ss") & " (" & Now.Subtract(Me.datelaunched).TotalSeconds() & " s)"
            Me.LinkLabel1.Visible = True
            Me.LinkLabel2.Visible = True
            If File_Exists((Application.StartupPath & "\Sounds\VICTORY.WAV").Replace("\\", "\")) = True Then
                My.Computer.Audio.Play((Application.StartupPath & "\Sounds\VICTORY.WAV").Replace("\\", "\"), AudioPlayMode.Background)
            End If
            statusmessage = "Operation Completed"
        End If

        Status_Handler(statusmessage)
        Controls_Enabler("stop")

    End Sub 'backgroundWorker1_RunWorkerCompleted

    Private Sub Controls_Enabler(ByVal action As String)
        Select Case action.ToLower
            Case "run"
                Me.InputSource_Textbox.Enabled = False
                Me.InputDestination_Textbox.Enabled = False
                Me.Browse1_Button.Enabled = False
                Me.Browse2_Button.Enabled = False

                Me.startAsyncButton.Enabled = False
                Me.LinkLabel1.Enabled = False
                Me.LinkLabel2.Enabled = False
                ' Disable the Cancel button.
                Me.cancelAsyncButton.Enabled = True
                Exit Select
            Case "stop"
                Me.InputSource_Textbox.Enabled = True
                Me.InputDestination_Textbox.Enabled = True
                Me.Browse1_Button.Enabled = True
                Me.Browse2_Button.Enabled = True

                Me.startAsyncButton.Enabled = True
                Me.LinkLabel1.Enabled = True
                Me.LinkLabel2.Enabled = True
                ' Disable the Cancel button.
                Me.cancelAsyncButton.Enabled = False
                Exit Select
            Case Else
                Me.InputSource_Textbox.Enabled = False
                Me.InputDestination_Textbox.Enabled = False
                Me.Browse1_Button.Enabled = False
                Me.Browse2_Button.Enabled = False

                Me.startAsyncButton.Enabled = False
                Me.LinkLabel1.Enabled = False
                Me.LinkLabel2.Enabled = False
                ' Disable the Cancel button.
                Me.cancelAsyncButton.Enabled = True
                Exit Select
        End Select


    End Sub

    ' This event handler updates the progress bar.
    Private Sub backgroundWorker1_ProgressChanged( _
    ByVal sender As Object, ByVal e As ProgressChangedEventArgs) _
    Handles BackgroundWorker1.ProgressChanged

        Me.ProgressBar1.Value = e.ProgressPercentage
        inputlines_label.Text = inputlines & " of " & inputlinesprecount
        lastinputline_label.Text = lastinputline

        datelaunched_label.Text = Format(datelaunched, "yyyy/MM/dd HH:mm:ss") & " - " & Format(Now, "yyyy/MM/dd HH:mm:ss") & " (" & Now.Subtract(Me.datelaunched).TotalSeconds() & " s)"
        Status_Handler(statusmessage)
    End Sub

    ' This is the method that does the actual work. 
    Function MainWorkerFunction( _
        ByVal input As String, _
        ByVal worker As BackgroundWorker, _
        ByVal e As DoWorkEventArgs) As String


        Dim result As String = ""

        ' Abort the operation if the user has canceled.
        ' Note that a call to CancelAsync may have set 
        ' CancellationPending to true just after the
        ' last invocation of this method exits, so this 
        ' code will not have the opportunity to set the 
        ' DoWorkEventArgs.Cancel flag to true. This means
        ' that RunWorkerCompletedEventArgs.Cancelled will
        ' not be set to true in your RunWorkerCompleted
        ' event handler. This is a race condition.
        If worker.CancellationPending Then
            e.Cancel = True
        Else
            Try

                If Me.pretestdone = False Then
                    worker.ReportProgress(0)
                    PreCount_Function()
                    Me.pretestdone = True

                End If

                statusmessage = "Scanning Source Folder"
                Activity_Handler("Source: " & (InputSource_Textbox.Text & "\").Replace("\\", "\"))
                Activity_Handler("Destination: " & (InputDestination_Textbox.Text & "\").Replace("\\", "\"))
                Activity_Handler(vbCrLf)
                FileCopier((InputSource_Textbox.Text & "\").Replace("\\", "\"), (InputDestination_Textbox.Text & "\").Replace("\\", "\"), (InputSource_Textbox.Text & "\").Replace("\\", "\"), worker, e)

            Catch ex As Exception
                Error_Handler(ex, "MainWorkerFunction")
            End Try
        End If

        Return result

    End Function

    Private Sub FileCopier(ByVal homepath As String, ByVal destinationpath As String, ByVal currenthomepath As String, ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs)
        Try
            Dim currentdestpath As String = currenthomepath
            currentdestpath = (currentdestpath.Replace(homepath, destinationpath)).Replace("\\", "\")
            Dim hdinfo As DirectoryInfo = New DirectoryInfo(currenthomepath)
            Dim dinfo As DirectoryInfo = New DirectoryInfo(currentdestpath)
            'MsgBox(hdinfo.FullName & vbCrLf & dinfo.FullName)
            Dim d2info As DirectoryInfo
            Dim finfo As FileInfo
            If dinfo.Exists = False Then
                dinfo.Create()
            End If
            'If dinfo.Exists = True Then
            For Each finfo In hdinfo.GetFiles()
                Try
                    If worker.CancellationPending Then
                        e.Cancel = True
                        Exit For
                    Else
                        'MsgBox(finfo.FullName & vbCrLf & (finfo.FullName.Replace(homepath, destinationpath)).Replace("\\", "\"))
                        'Activity_Handler("Source: " & finfo.FullName)
                        'Activity_Handler("Destination: " & (finfo.FullName.Replace(homepath, destinationpath)).Replace("\\", "\"))
                        finfo.CopyTo((finfo.FullName.Replace(homepath, destinationpath)).Replace("\\", "\"), True)
                        'Activity_Handler("Copy Successful")
                        inputlines = inputlines + 1
                        lastinputline = finfo.Name
                        ' Report progress as a percentage of the total task.

                        Dim percentComplete As Integer = 0
                        If inputlinesprecount > 0 Then
                            percentComplete = CSng(inputlines) / CSng(inputlinesprecount) * 100
                        Else
                            percentComplete = 100
                        End If

                        If percentComplete > highestPercentageReached Then
                            highestPercentageReached = percentComplete
                            worker.ReportProgress(percentComplete)
                        End If

                        finfo = Nothing
                    End If
                Catch ex As Exception
                    Activity_Handler("Copy Failed")
                    Error_Handler(ex)
                End Try
            Next
            For Each d2info In hdinfo.GetDirectories()
                Try
                    If worker.CancellationPending Then
                        e.Cancel = True
                        Exit For
                    Else
                        FileCopier(homepath, destinationpath, d2info.FullName, worker, e)
                        d2info = Nothing
                    End If
                Catch ex As Exception
                    Error_Handler(ex)
                End Try
            Next
            'End If
            hdinfo = Nothing
            d2info = Nothing
            dinfo = Nothing
            finfo = Nothing
        Catch ex As Exception
            Error_Handler(ex, "FileCopier")
        End Try
    End Sub

    Private Sub PreCount_Function()
        Try
            If Directory_Exists(InputSource_Textbox.Text) = True Then
                FileDepthTester(InputSource_Textbox.Text)
            End If
        Catch ex As Exception
            Error_Handler(ex, "PreCount_Function")
        End Try
    End Sub

    Private Sub FileDepthTester(ByVal currenthomepath As String)
        Try
            Dim hdinfo As DirectoryInfo = New DirectoryInfo(currenthomepath)
            Dim d2info As DirectoryInfo
            Dim finfo As FileInfo
            For Each finfo In hdinfo.GetFiles()
                Try
                    inputlinesprecount = inputlinesprecount + 1
                    finfo = Nothing
                Catch ex As Exception
                    Error_Handler(ex)
                End Try
            Next
            For Each d2info In hdinfo.GetDirectories()
                Try
                    FileDepthTester(d2info.FullName)
                    d2info = Nothing
                Catch ex As Exception
                    Error_Handler(ex)
                End Try
            Next
            'End If
            hdinfo = Nothing
            d2info = Nothing
            finfo = Nothing
        Catch ex As Exception
            Error_Handler(ex, "FileDepthTester")
        End Try
    End Sub


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            If File_Exists((Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs\" & Format(Now(), "yyyyMMdd") & "_Activity_Log.txt") = True Then
                Dim systemDirectory As String
                systemDirectory = System.Environment.SystemDirectory
                Dim finfo As FileInfo = New FileInfo((systemDirectory & "\notepad.exe").Replace("\\", "\"))
                If finfo.Exists = True Then
                    Dim apptorun As String
                    apptorun = """" & (systemDirectory & "\notepad.exe").Replace("\\", "\") & """ """ & (Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs\" & Format(Now(), "yyyyMMdd") & "_Activity_Log.txt" & """"
                    Dim procID As Integer = Shell(apptorun, AppWinStyle.NormalFocus, False)
                End If
                finfo = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex, "LinkLabel1_LinkClicked")
        End Try
    End Sub


    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            If File_Exists((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt") = True Then
                Dim systemDirectory As String
                systemDirectory = System.Environment.SystemDirectory
                Dim finfo As FileInfo = New FileInfo((systemDirectory & "\notepad.exe").Replace("\\", "\"))
                If finfo.Exists = True Then
                    Dim apptorun As String
                    apptorun = """" & (systemDirectory & "\notepad.exe").Replace("\\", "\") & """ """ & (Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt" & """"
                    Dim procID As Integer = Shell(apptorun, AppWinStyle.NormalFocus, False)
                End If
                finfo = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex, "LinkLabel1_LinkClicked")
        End Try
    End Sub
End Class
