Public Class Manual_Override

    Public day As String
    Public month As String
    Public year As String
    Public lastday As String
    Public lastmonth As String


    Private Sub Error_Handler(ByVal ex As Exception, Optional ByVal identifier_msg As String = "")
        Try
            If ex.Message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message()

                Display_Message1.Message_Textbox.Text = "The Application encountered the following problem: " & vbCrLf & identifier_msg & ":" & ex.ToString

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
            MsgBox("An error occurred in Folder Listing With Size Report's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub


    Private Sub Manual_Override_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception
            Error_Handler(ex, "Manual Override Load")
        End Try
    End Sub

    

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Select Case ComboBox1.SelectedIndex
                Case 0
                    TextBox1.Text = day.Split(":")(0)
                    TextBox2.Text = day.Split(":")(1)
                    TextBox3.Text = day.Split(":")(2)
                Case 1
                    TextBox1.Text = month.Split(":")(0)
                    TextBox2.Text = month.Split(":")(1)
                    TextBox3.Text = month.Split(":")(2)
                Case 2
                    TextBox1.Text = year.Split(":")(0)
                    TextBox2.Text = year.Split(":")(1)
                    TextBox3.Text = year.Split(":")(2)
                Case 3
                    TextBox1.Text = lastday.Split(":")(0)
                    TextBox2.Text = lastday.Split(":")(1)
                    TextBox3.Text = lastday.Split(":")(2)
                Case 4
                    TextBox1.Text = lastmonth.Split(":")(0)
                    TextBox2.Text = lastmonth.Split(":")(1)
                    TextBox3.Text = lastmonth.Split(":")(2)
                Case Else
                    TextBox1.Text = "00"
                    TextBox2.Text = "00"
                    TextBox3.Text = "00"
            End Select


        Catch ex As Exception
            Error_Handler(ex, "ComboBox1_SelectedIndexChanged")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If IsNumeric(TextBox1.Text) = False Or IsNumeric(TextBox2.Text) = False Or IsNumeric(TextBox3.Text) = False Then
            MsgBox("Error detected in your inputs. The values have reverted to their original state", MsgBoxStyle.Information, "Input Error")
            Select Case ComboBox1.SelectedIndex
                Case 0
                    TextBox1.Text = day.Split(":")(0)
                    TextBox2.Text = day.Split(":")(1)
                    TextBox3.Text = day.Split(":")(2)
                Case 1
                    TextBox1.Text = month.Split(":")(0)
                    TextBox2.Text = month.Split(":")(1)
                    TextBox3.Text = month.Split(":")(2)
                Case 2
                    TextBox1.Text = year.Split(":")(0)
                    TextBox2.Text = year.Split(":")(1)
                    TextBox3.Text = year.Split(":")(2)
                Case 3
                    TextBox1.Text = lastday.Split(":")(0)
                    TextBox2.Text = lastday.Split(":")(1)
                    TextBox3.Text = lastday.Split(":")(2)
                Case 4
                    TextBox1.Text = lastmonth.Split(":")(0)
                    TextBox2.Text = lastmonth.Split(":")(1)
                    TextBox3.Text = lastmonth.Split(":")(2)
                Case Else
                    TextBox1.Text = "00"
                    TextBox2.Text = "00"
                    TextBox3.Text = "00"
            End Select
        Else

            While TextBox1.Text.Length <= 2
                TextBox1.Text = "0" & TextBox1.Text
            End While
            If TextBox2.Text.Length > 2 Or TextBox3.Text.Length > 2 Then
                MsgBox("Error detected in your inputs. The values have reverted to their original state", MsgBoxStyle.Information, "Input Error")
                Select Case ComboBox1.SelectedIndex
                    Case 0
                        TextBox1.Text = day.Split(":")(0)
                        TextBox2.Text = day.Split(":")(1)
                        TextBox3.Text = day.Split(":")(2)
                    Case 1
                        TextBox1.Text = month.Split(":")(0)
                        TextBox2.Text = month.Split(":")(1)
                        TextBox3.Text = month.Split(":")(2)
                    Case 2
                        TextBox1.Text = year.Split(":")(0)
                        TextBox2.Text = year.Split(":")(1)
                        TextBox3.Text = year.Split(":")(2)
                    Case 3
                        TextBox1.Text = lastday.Split(":")(0)
                        TextBox2.Text = lastday.Split(":")(1)
                        TextBox3.Text = lastday.Split(":")(2)
                    Case 4
                        TextBox1.Text = lastmonth.Split(":")(0)
                        TextBox2.Text = lastmonth.Split(":")(1)
                        TextBox3.Text = lastmonth.Split(":")(2)
                    Case Else
                        TextBox1.Text = "00"
                        TextBox2.Text = "00"
                        TextBox3.Text = "00"
                End Select
            End If
        End If

    End Sub
End Class