Imports System.IO
Imports System.Security.Cryptography
Imports System.IO.Compression
Imports System.Drawing.Text
Imports System.Reflection.Metadata.Ecma335
Imports System.Text
Public Class Form1
    Dim VersionIdentifier = "v 2.3.1"
    Dim DisableOutput = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try 'Update Code
            My.Computer.Network.DownloadFile("https://lucky-paprenjak-2c728d.netlify.app/EzFileEncrypt/bin/Release/net8.0-windows/publish/win-x64/EzFileEncrypt.exe", Path.GetTempPath() & "\EzFileEncrypt_Update.tmp")

            Try

                If Not GetMD5HashFromFile(Application.ExecutablePath) = GetMD5HashFromFile(Path.GetTempPath() & "\EzFileEncrypt_Update.tmp") Then

                    Dim result As DialogResult = MessageBox.Show("An update is available would you like to update the program?", "Confirmation", MessageBoxButtons.YesNo)

                    Try
                        My.Computer.FileSystem.DeleteFile("updater.bat")
                    Catch ex As Exception

                    End Try

                    If result = DialogResult.Yes Then

                        DisableOutput = True
                        Dim batchCommands As String = "Echo off" & Environment.NewLine & "ECHO DO NOT CLOSE THIS WINDOW EZ FILE ENCRYPT IS UPDATING!!" & Environment.NewLine & "TIMEOUT 5 >NUL" & Environment.NewLine &
                                          "ren ""EzFileEncrypt_Update.tmp"" ""EzFileEncrypt.exe""" & Environment.NewLine & "START EzFileEncrypt.exe"

                        Using writer As StreamWriter = New StreamWriter("updater.bat")
                            writer.Write(batchCommands)
                        End Using

                        My.Computer.FileSystem.CopyFile(Path.GetTempPath() & "\EzFileEncrypt_Update.tmp", Application.StartupPath & "\EzFileEncrypt_Update.tmp")
                        Process.Start("cmd.exe", "/C choice /C Y /N /D Y /T 3 & Del " & Application.ExecutablePath)
                        Process.Start("updater.bat")
                        Application.[Exit]()

                    End If

                End If

            Catch ex As Exception
                MsgBox("An unknown error occurred while trying to update the program", 0 + 16, "ERROR")
            End Try
        Catch ex As Exception
            MsgBox("Failed to connect to the update server.", 0 + 16, "EzFileEncrypt")
        End Try



        PrintLog("Status: ready", False)
        MIT_license.ShowDialog()
        Label10.Text = VersionIdentifier
        Label12.Text = VersionIdentifier

        Try
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\CreateFrom0Directory.tmp")
        Catch ex As Exception
        End Try
        Try
            My.Computer.FileSystem.DeleteFile("decrypt0.tmp")
        Catch ex As Exception
        End Try

        Try
            My.Computer.FileSystem.DeleteFile(Path.GetTempPath() & "\EzFileEncrypt_Update.tmp")
        Catch ex As Exception

        End Try



    End Sub
    Function GetMD5HashFromFile(fileName As String) As String
        Dim md5 As MD5 = MD5.Create()
        Dim stream As FileStream = File.OpenRead(fileName)
        Dim hash As Byte() = md5.ComputeHash(stream)
        stream.Close()

        Dim sb As New StringBuilder()
        For i As Integer = 0 To hash.Length - 1
            sb.Append(hash(i).ToString("X2"))
        Next

        Return sb.ToString()
    End Function
    Sub PrintLog(Log As String, E1rror As Boolean)
        Me.Invoke(Sub() outputlog_list.Items.Add(Log))
        Me.Invoke(Sub() Status_lbr.Text = Log)

        If E1rror Then
            Status_lbr.ForeColor = Color.Red
        Else
            Status_lbr.ForeColor = Color.ForestGreen
        End If

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
        PrintLog("Status: Calling DecryptBackgoundWorker.RunWorkerAsync()", False)

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
            PrintLog("ERROR: A encryption key key is needed", True)
            MsgBox("A encryption key key is needed", 0 + 16, "EZ File Encrypt")

        Else


            Try

                Dim EncryptionKey = CreateEncryptionKey(TextBox3.Text)

                View_final_key.RichTextBox1.Text = EncryptionKey
                View_final_key.ShowDialog()

                PrintLog("OK: Currently creating: CreateFrom0Directory.tmp", False)



                Using archive As ZipArchive = ZipFile.Open(Application.StartupPath & "\CreateFrom0Directory.tmp", ZipArchiveMode.Create)
                    ' Get the files in the source directory
                    Dim files As String() = Directory.GetFiles(Inputfile_txt.Text)

                    ' Loop through each file
                    For Each file As String In files
                        '  outputlog_list.Items.Add("Processing: " & file)

                        PrintLog("OK: Processing: " & file, False)

                        archive.CreateEntryFromFile(file, Path.GetFileName(file))


                    Next
                End Using

                PrintLog("OK: encrypting: CreateFrom0Directory.tmp", False)

                EncryptDecryptFile.EncryptFile(Application.StartupPath & "\CreateFrom0Directory.tmp", Inputfile_txt.Text & ".EzFileEncrypt", EncryptionKey)

                PrintLog("OK: EzFileEncrypt: created", False)

                PrintLog("OK: beginning clean up operations", False)

                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\CreateFrom0Directory.tmp")
                PrintLog("OK: CreateFrom0Directory.tmp removed", False)

                My.Computer.FileSystem.DeleteDirectory(Inputfile_txt.Text, FileIO.DeleteDirectoryOption.DeleteAllContents)


                PrintLog("OK: main folder removed", False)
                PrintLog("OK: Done!", False)

                MsgBox("Done!", 0 + 64, "EzFileEncrypt")
            Catch ex As Exception
                PrintLog("ERROR: " & ex.Message, True)
                MsgBox(ex.Message, 0 + 16, "EzFileEncrypt")
            End Try
        End If
    End Sub


    Function CreateEncryptionKey(Input) 'if you change this function it will break compatibility with already existing .EzFileEncrypt files
        'and you will only be able to decrypt a legacy encryption files & new .EzFileEncrypt files you created with the new function


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
                MsgBox("A decryption key is needed", 0 + 16, "EzFileEncrypt")

                PrintLog("ERROR: A decryption key is needed", True)

            Else
                Try
                    PrintLog("OK: Decrypting: decrypt0.tmp", False)


                    If DecryptusinglegacyCHK.Checked Then
                        EncryptDecryptFile.DecryptFile(TextBox6.Text, "decrypt0.tmp", LegacyEncryptionKey)
                    Else
                        EncryptDecryptFile.DecryptFile(TextBox6.Text, "decrypt0.tmp", EncryptionKey)
                    End If

                Catch ex As Exception
                    MsgBox("EncryptDecryptFile.DecryptFile() function failure please check your decryption key.", 0 + 16, "EzFileEncrypt")

                    PrintLog("ERROR: Decrypting: EncryptDecryptFile.DecryptFile() function failure please check your decryption key.", True)

                End Try

                PrintLog("OK: Creating directory: " & Path.GetFileNameWithoutExtension(TextBox6.Text), False)

                My.Computer.FileSystem.CreateDirectory(Path.GetFileNameWithoutExtension(TextBox6.Text))
                Try
                    PrintLog("OK: Extracting files from unencrypted archive... ", False)


                    ZipFile.ExtractToDirectory("decrypt0.tmp", Path.GetDirectoryName(TextBox6.Text) & "\" & Path.GetFileNameWithoutExtension(TextBox6.Text))

                    PrintLog("OK: archive extraction successful", False)


                Catch ex As Exception
                    MsgBox("decrypt0.tmp seems to be corrupted | most likely cause: wrong decryption key, please ensure that you have entered your decryption key correctly.", 0 + 16)
                    My.Computer.FileSystem.DeleteFile("decrypt0.tmp")

                    PrintLog("ERROR: decrypt0.tmp seems to be corrupted | most likely cause: wrong decryption key, please ensure that you have entered your decryption key correctly.", True)
                End Try
                PrintLog("OK: deleting decrypt0.tmp", False)

                My.Computer.FileSystem.DeleteFile("decrypt0.tmp")
                PrintLog("OK: Done!", False)

                MsgBox("successfully decrypted files", 0 + 64, "EzFileEncrypt")
            End If


        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16, "EzFileEncrypt")
            PrintLog("OK: ERROR: " & ex.Message, True)

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

        PrintLog("OK: *** DO NOT CLOSE*** beginning clean up procedure do not kill this process because it may lead to unencrypted data exposed on your hard disk.", False)
        Try
            PrintLog("OK: Deleting: CreateFrom0Directory.tmp", False)

            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\CreateFrom0Directory.tmp")
        Catch ex As Exception

        End Try
        Try
            PrintLog("OK: Deleting: decrypt0.tmp", False)

            My.Computer.FileSystem.DeleteFile("decrypt0.tmp")
        Catch ex As Exception

        End Try
        PrintLog("OK: all unencrypted temporary files have been removed program is now exiting.", False)

        Try
            Dim randomStr As String = GenerateRandomString(15)
            Using writer As New StreamWriter(Path.GetTempPath() & randomStr & ".LOG")
                For Each item As Object In outputlog_list.Items
                    writer.WriteLine(item.ToString())
                Next
            End Using
            If DisableOutput = False Then
                Process.Start("C:\Windows\System32\notepad.exe", Path.GetTempPath() & randomStr & ".LOG")
            End If

        Catch ex As Exception
            PrintLog("ERRPR: Log File Save Fail", True)
            MsgBox("Log File Save Fail", 0 + 16, "EzFileEncrypt")
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
        Dim bytes As Byte() = Encoding.ASCII.GetBytes(input)
        Dim base64 As String = Convert.ToBase64String(bytes)
        Return base64
    End Function


    Public Function Base64ToString(ByVal base64 As String) As String
        Dim bytes As Byte() = Convert.FromBase64String(base64)
        Dim str As String = Encoding.ASCII.GetString(bytes)
        Return str
    End Function

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            Process.Start("C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", "https://github.com/zv8001/EzFileEncrypt")
        Catch ex As Exception
            MsgBox("Failed to open C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", 0 + 16, "EzFileEncrypt")
        End Try
    End Sub

    Private Sub Status_lbr_Click(sender As Object, e As EventArgs) Handles Status_lbr.Click

    End Sub

    Private Sub DecryptusinglegacyCHK_CheckedChanged(sender As Object, e As EventArgs) Handles DecryptusinglegacyCHK.CheckedChanged
        If DecryptusinglegacyCHK.Checked Then
            MsgBox("This option is only to decrypt files that have been encrypted with the older EzFileEncrypt v 2.0.0 and older. If you have files encrypted in the older versions it is recommended you re-encrypt them with the new versions.", 0 + 48, "EzFileEncrypt")
        End If
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