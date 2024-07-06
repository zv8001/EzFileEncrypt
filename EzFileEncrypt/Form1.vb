Imports System.IO
Imports System.Security.Cryptography
Imports System.IO.Compression
Imports System.Drawing.Text
Imports System.Reflection.Metadata.Ecma335
Imports System.Text
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MIT_license.ShowDialog()
        Try
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\CreateFrom0Directory.tmp")
        Catch ex As Exception

        End Try
        Try
            My.Computer.FileSystem.DeleteFile("decrypt0.tmp")
        Catch ex As Exception

        End Try
    End Sub


    Private Sub SelInputFileBtn_Click(sender As Object, e As EventArgs) Handles SelInputFileBtn.Click


        Dim folderBrowserDialog1 As New FolderBrowserDialog()

        folderBrowserDialog1.Description = "Select a Folder"
        folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop


        If folderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Dim folderPath As String = folderBrowserDialog1.SelectedPath
            Inputfile_txt.Text = folderPath
        End If

    End Sub

    Private Sub Encryptbtn_Click(sender As Object, e As EventArgs) Handles Encryptbtn.Click
        outputlog_list.Items.Add("Calling EncryptBackgoundWorker.RunWorkerAsync()")
        Try
            EncryptBackgoundWorker.RunWorkerAsync()

        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16)
        End Try

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Title = "Select a File"
        openFileDialog1.InitialDirectory = "C:\\"
        openFileDialog1.Filter = "Ez File Encrypt|*.EzFileEncrypt"

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog1.FileName
            TextBox6.Text = filePath
        End If
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        outputlog_list.Items.Add("Calling DecryptBackgoundWorker.RunWorkerAsync()")
        Try
            DecryptBackgoundWorker.RunWorkerAsync()
        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16)
        End Try


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            Process.Start("C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", "https://github.com/zv8001/EzFileEncrypt")
        Catch ex As Exception
            MsgBox("Failed to open C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", 0 + 16, "EzFileEncrypt")
        End Try

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub EncryptBackgoundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles EncryptBackgoundWorker.DoWork


        If TextBox3.Text = "" Then
            MsgBox("A encryption key key is needed")
        Else


            Try

                Dim EncryptionKey = CreateEncryptionKey(TextBox3.Text)


                Me.Invoke(Sub() outputlog_list.Items.Add("Currently creating: CreateFrom0Directory.tmp"))

                ZipFile.CreateFromDirectory(Inputfile_txt.Text, Application.StartupPath & "\CreateFrom0Directory.tmp")



                Me.Invoke(Sub() outputlog_list.Items.Add("encrypting: CreateFrom0Directory.tmp"))
                EncryptDecryptFile.EncryptFile(Application.StartupPath & "\CreateFrom0Directory.tmp", Inputfile_txt.Text & ".EzFileEncrypt", EncryptionKey)

                Me.Invoke(Sub() outputlog_list.Items.Add("EzFileEncrypt: created"))

                Me.Invoke(Sub() outputlog_list.Items.Add("beginning clean up operations"))
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\CreateFrom0Directory.tmp")
                Me.Invoke(Sub() outputlog_list.Items.Add("CreateFrom0Directory.tmp removed"))
                My.Computer.FileSystem.DeleteDirectory(Inputfile_txt.Text, FileIO.DeleteDirectoryOption.DeleteAllContents)
                Me.Invoke(Sub() outputlog_list.Items.Add("main folder removed"))
                Me.Invoke(Sub() outputlog_list.Items.Add("Done!"))
                MsgBox("Done!", 0 + 64)
            Catch ex As Exception
                MsgBox(ex.Message, 0 + 16, "EzFileEncrypt")
            End Try
        End If
    End Sub


    Function CreateEncryptionKey(Input)
        Dim a1 As String = StringToBase64(Input)
        Dim a2 As String = StringToBase64(a1)
        Dim a3 As String = StringToBase64(a2)
        Dim a4 As String = StringToBase64(a3)
        Dim a5 As String = StringToBase64(a4)
        Dim a6 As String = StringToBase64(a5)
        Dim a7 As String = StringToBase64(a6)
        Dim a8 As String = StringToBase64(a7)

        Dim a9 As String = StringToBase64(a8)
        Dim a10 As String = StringToBase64(a9)
        Dim a11 As String = StringToBase64(a10)
        Dim a12 As String = StringToBase64(a11)
        Dim a13 As String = StringToBase64(a12)
        Dim a14 As String = StringToBase64(a13)
        Dim a15 As String = StringToBase64(a14)
        Dim a16 As String = StringToBase64(a15)
        Return a16
    End Function



    Private Sub DecryptBackgoundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles DecryptBackgoundWorker.DoWork

        Try

            Dim EncryptionKey = CreateEncryptionKey(TextBox4.Text)
            Dim LegacyEncryptionKey = TextBox4.Text

            If TextBox4.Text = "" Then
                MsgBox("A decryption key is needed", 0 + 16)
                Me.Invoke(Sub() outputlog_list.Items.Add("FAILURE: A decryption key is needed"))
            Else
                Try
                    Me.Invoke(Sub() outputlog_list.Items.Add("Decrypting: decrypt0.tmp"))

                    If DecryptusinglegacyCHK.Checked Then
                        EncryptDecryptFile.DecryptFile(TextBox6.Text, "decrypt0.tmp", LegacyEncryptionKey)
                    Else
                        EncryptDecryptFile.DecryptFile(TextBox6.Text, "decrypt0.tmp", EncryptionKey)
                    End If

                Catch ex As Exception
                    MsgBox("EncryptDecryptFile.DecryptFile() function failure please check your decryption key.", 0 + 16)

                    Me.Invoke(Sub() outputlog_list.Items.Add("FAILURE: EncryptDecryptFile.DecryptFile() function failure please check your decryption key."))
                    Me.Invoke(Sub() outputlog_list.Items.Add("FAILURE: EncryptDecryptFile.DecryptFile() function failure please check your decryption key."))
                End Try

                Me.Invoke(Sub() outputlog_list.Items.Add("Creating directory: " & Path.GetFileNameWithoutExtension(TextBox6.Text)))
                My.Computer.FileSystem.CreateDirectory(Path.GetFileNameWithoutExtension(TextBox6.Text))
                Try
                    Me.Invoke(Sub() outputlog_list.Items.Add("Extracting files from unencrypted archive..."))
                    ZipFile.ExtractToDirectory("decrypt0.tmp", Path.GetDirectoryName(TextBox6.Text) & "\" & Path.GetFileNameWithoutExtension(TextBox6.Text))
                    Me.Invoke(Sub() outputlog_list.Items.Add("archive extraction successful"))
                Catch ex As Exception
                    MsgBox("decrypt0.tmp seems to be corrupted | most likely cause: wrong decryption key, please ensure that you have entered your decryption key correctly.", 0 + 16)
                    My.Computer.FileSystem.DeleteFile("decrypt0.tmp")
                    Me.Invoke(Sub() outputlog_list.Items.Add("FAILURE: decrypt0.tmp seems to be corrupted | most likely cause: wrong decryption key, please ensure that you have entered your decryption key correctly."))

                End Try
                Me.Invoke(Sub() outputlog_list.Items.Add("deleting decrypt0.tmp"))
                My.Computer.FileSystem.DeleteFile("decrypt0.tmp")
                Me.Invoke(Sub() outputlog_list.Items.Add("Done!"))
                MsgBox("successfully decrypted files")
            End If


        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16, "EzFileEncrypt")

            Me.Invoke(Sub() outputlog_list.Items.Add("ERROR: " & ex.Message))
        End Try

    End Sub

    Private Sub outputlog_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles outputlog_list.SelectedIndexChanged

    End Sub

    Private Sub MoveListBox_Tick(sender As Object, e As EventArgs) Handles MoveListBox.Tick
        Try
            outputlog_list.TopIndex = outputlog_list.Items.Count - 1

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveLogBtn_Click(sender As Object, e As EventArgs) Handles SaveLogBtn.Click
        Dim saveFileDialog1 As New SaveFileDialog()


        saveFileDialog1.Title = "Save ListBox to File"
        saveFileDialog1.Filter = "Text Files|*.txt"


        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Using writer As New StreamWriter(saveFileDialog1.FileName)
                For Each item As Object In outputlog_list.Items
                    writer.WriteLine(item.ToString())
                Next
            End Using
        End If
    End Sub
    Public Function GenerateRandomString(ByVal len As Integer) As String
        Dim rand As New Random()
        Dim allowableChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim final As String = String.Empty

        For i As Integer = 0 To len - 1
            final += allowableChars(rand.Next(allowableChars.Length))
        Next

        Return final
    End Function
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        outputlog_list.Items.Add("*** DO NOT CLOSE*** beginning clean up procedure do not kill this process because it may lead to unencrypted data exposed on your hard disk.")

        Try
            outputlog_list.Items.Add("Deleting: CreateFrom0Directory.tmp")
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\CreateFrom0Directory.tmp")
        Catch ex As Exception

        End Try
        Try
            outputlog_list.Items.Add("Deleting: decrypt0.tmp")
            My.Computer.FileSystem.DeleteFile("decrypt0.tmp")
        Catch ex As Exception

        End Try

        outputlog_list.Items.Add("all unencrypted temporary files have been removed program is now exiting.")
        Try
            Dim randomStr As String = GenerateRandomString(15)
            Using writer As New StreamWriter(Path.GetTempPath() & randomStr & ".LOG")
                For Each item As Object In outputlog_list.Items
                    writer.WriteLine(item.ToString())
                Next
            End Using
            MsgBox(Path.GetTempPath() & randomStr & ".LOG")
            Process.Start("C:\Windows\System32\notepad.exe", Path.GetTempPath() & randomStr & ".LOG")
        Catch ex As Exception
            MsgBox("Log File Save Fail", 0 + 16)
        End Try

    End Sub

    Private Sub CheckIfEncryptIsBusy_Tick(sender As Object, e As EventArgs) Handles CheckIfEncryptIsBusy.Tick
        If EncryptBackgoundWorker.IsBusy Then
            Encryptbtn.Enabled = False
        Else
            Encryptbtn.Enabled = True
        End If

        If DecryptBackgoundWorker.IsBusy Then
            Button4.Enabled = False
        Else
            Button4.Enabled = True
        End If


    End Sub

    Public Function StringToBase64(ByVal input As String) As String
        ' Convert the string to a byte array
        Dim bytes As Byte() = Encoding.ASCII.GetBytes(input)

        ' Convert the byte array to a Base64 string
        Dim base64 As String = Convert.ToBase64String(bytes)

        Return base64
    End Function


    Public Function Base64ToString(ByVal base64 As String) As String
        ' Convert the Base64 string to a byte array
        Dim bytes As Byte() = Convert.FromBase64String(base64)

        ' Convert the byte array to a string
        Dim str As String = Encoding.ASCII.GetString(bytes)

        Return str
    End Function

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class




Public Class EncryptDecryptFile
    Private Shared Function CreateAes(ByVal password As String, ByVal salt As Byte()) As Aes

        Dim hashAlgorithm As HashAlgorithmName = HashAlgorithmName.SHA256
        Dim iterations As Integer = 10000

        Dim pdb As New Rfc2898DeriveBytes(password, salt, iterations, hashAlgorithm)
        Dim aes As Aes = Aes.Create()
        aes.Key = pdb.GetBytes(32)
        aes.IV = pdb.GetBytes(16)
        Return aes
    End Function

    Public Shared Sub EncryptFile(ByVal inputFile As String, ByVal outputFile As String, ByVal password As String)
        Dim aes As Aes = CreateAes(password, New Byte() {1, 2, 3, 4, 5, 6, 7, 8})
        Using aes
            Using inStream As New FileStream(inputFile, FileMode.Open, FileAccess.Read)
                Using outStream As New FileStream(outputFile, FileMode.OpenOrCreate, FileAccess.Write)
                    Dim transformer As ICryptoTransform = aes.CreateEncryptor()
                    Using cryptStream As New CryptoStream(outStream, transformer, CryptoStreamMode.Write)
                        inStream.CopyTo(cryptStream)
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Public Shared Sub DecryptFile(ByVal inputFile As String, ByVal outputFile As String, ByVal password As String)
        Dim aes As Aes = CreateAes(password, New Byte() {1, 2, 3, 4, 5, 6, 7, 8})
        Using aes
            Using inStream As New FileStream(inputFile, FileMode.Open, FileAccess.Read)
                Using outStream As New FileStream(outputFile, FileMode.OpenOrCreate, FileAccess.Write)
                    Dim transformer As ICryptoTransform = aes.CreateDecryptor()
                    Using cryptStream As New CryptoStream(inStream, transformer, CryptoStreamMode.Read)
                        cryptStream.CopyTo(outStream)
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Class