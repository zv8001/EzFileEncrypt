Imports System.IO
Imports System.Security.Cryptography
Imports System.IO.Compression
Imports System.Drawing.Text
Imports System.Reflection.Metadata.Ecma335
Imports System.Text
Imports Microsoft.VisualBasic.Logging


'Copyright 2024 ZV800

'Permission Is hereby granted, free Of charge, to any person obtaining a copy of this software And associated documentation files
'(the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish,
'distribute, sublicense, And/Or sell copies of the Software, And to permit persons to whom the Software Is furnished to do so, subject to the
'following conditions:

'The above copyright notice And this permission notice shall be included In all copies Or substantial portions Of the Software.

'THE SOFTWARE Is PROVIDED “AS IS”, WITHOUT WARRANTY Of ANY KIND, EXPRESS Or IMPLIED, INCLUDING BUT Not LIMITED To THE WARRANTIES Of
'MERCHANTABILITY, FITNESS For A PARTICULAR PURPOSE And NONINFRINGEMENT. In NO Event SHALL THE AUTHORS Or COPYRIGHT HOLDERS BE LIABLE For ANY
'CLAIM, DAMAGES Or OTHER LIABILITY, WHETHER In AN ACTION Of CONTRACT, TORT Or OTHERWISE, ARISING FROM, OUT Of Or In CONNECTION With THE
'SOFTWARE Or THE USE Or OTHER DEALINGS In THE SOFTWARE.


Public Class Form1
    Dim VersionIdentifier = "v 3.0.2"
    Dim DisableOutput = False
    Dim Base64Key = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedItem = "EZFileEncrypt encryption method v3 (Latest)"
        PrintLog("Status: ready", False)
        MIT_license.ShowDialog()
        Label10.Text = VersionIdentifier
        Label12.Text = VersionIdentifier
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
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

    Function PrintFailSafeWarn()

    End Function
    Private Sub Encryptbtn_Click(sender As Object, e As EventArgs) Handles Encryptbtn.Click


        If Inputfile_txt.Text.StartsWith("C:\Windows") Or Inputfile_txt.Text = "C:\" Or Inputfile_txt.Text.StartsWith("C:\Program Files") Or Inputfile_txt.Text.StartsWith("C:\Program Files (x86)") Or Inputfile_txt.Text.StartsWith("C:\$WINDOWS.~BT") Then
            MsgBox("FAIL SAFE: USING THIS PATH MAY CAUSE CRITICAL DAMAGE TO WINDOWS THEREFORE YOUR REQUEST HAS NOT GONE THROUGH PLEASE CHOOSE A DIFFERENT PATH", 0 + 16, "FAIL-SAFE WARNING")
        Else
            outputlog_list.Items.Add("Calling EncryptBackgoundWorker.RunWorkerAsync()")
            Try
                EncryptBackgoundWorker.RunWorkerAsync()

            Catch ex As Exception
                MsgBox(ex.Message, 0 + 16)
            End Try
        End If
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


    Private Sub EncryptBackgoundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles EncryptBackgoundWorker.DoWork


        If TextBox3.Text = "" Then
            PrintLog("ERROR: A encryption key key is needed", True)
            MsgBox("A encryption key key is needed", 0 + 16, "EZ File Encrypt")

        Else


            Try

                Dim EncryptionKey = CreateEncryptionKey(TextBox3.Text, False)

                View_final_key.RichTextBox1.Text = EncryptionKey
                View_final_key.ShowDialog()

                PrintLog("OK: Currently creating: CreateFrom0Directory.tmp", False)


                'this stupid code has been broken for a while without my knowledge so I fixed it in v 2.4.1
                'added search option all directories to fix this stupid bit of code -zv800
                Using archive As ZipArchive = ZipFile.Open(Application.StartupPath & "\CreateFrom0Directory.tmp", ZipArchiveMode.Create)
                    Dim files As String() = Directory.GetFileSystemEntries(Inputfile_txt.Text, "*", SearchOption.AllDirectories)

                    Me.Invoke(Sub() Status_ProgressBar.Maximum = files.Length)

                    Me.Invoke(Sub() Status_ProgressBar.Value = 0)




                    For Each file As String In files
                        Try
                            PrintLog("OK: Processing: " & file, False)
                            Dim entryName As String = file.Replace(Inputfile_txt.Text & "\", "")
                            archive.CreateEntryFromFile(file, entryName)

                            Me.Invoke(Sub() Status_ProgressBar.Value += 1)
                        Catch ex As Exception
                            PrintLog("ERROR: unexpected error when processing: " & file, False)
                        End Try
                    Next
                End Using
                Me.Invoke(Sub() Status_ProgressBar.Maximum = 100)

                Me.Invoke(Sub() Status_ProgressBar.Value = 50)
                PrintLog("OK: encrypting: CreateFrom0Directory.tmp", False)

                EncryptDecryptFile.EncryptFile(Application.StartupPath & "\CreateFrom0Directory.tmp", Inputfile_txt.Text & ".EzFileEncrypt", EncryptionKey)

                Me.Invoke(Sub() Status_ProgressBar.Value = 87)
                PrintLog("OK: EzFileEncrypt: created", False)

                PrintLog("OK: beginning clean up operations", False)

                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\CreateFrom0Directory.tmp")
                PrintLog("OK: CreateFrom0Directory.tmp removed", False)
                Me.Invoke(Sub() Status_ProgressBar.Value = 90)
                My.Computer.FileSystem.DeleteDirectory(Inputfile_txt.Text, FileIO.DeleteDirectoryOption.DeleteAllContents)
                Me.Invoke(Sub() Status_ProgressBar.Value = 100)

                PrintLog("OK: main folder removed", False)
                PrintLog("OK: Done!", False)

                MsgBox("Done!", 0 + 64, "EzFileEncrypt")
                Me.Invoke(Sub() Status_ProgressBar.Value = 0)
            Catch ex As Exception
                PrintLog("ERROR: " & ex.Message, True)
                MsgBox(ex.Message, 0 + 16, "EzFileEncrypt")
            End Try
        End If
    End Sub

    Private Function ComputeSha256Hash(rawData As String) As String
        Using sha256Hash As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function


    'This runs all the encryption code to create the unique identifiers which are the decryption keys
    Function CreateEncryptionKey(Input As String, OLD As Boolean) 'if you change this function it will break compatibility with already existing .EzFileEncrypt files
        'and you will only be able to decrypt a legacy encryption files & new .EzFileEncrypt files you created with the new function

        Dim SHA256 As String = ComputeSha256Hash(Input)

        If OLD = True Then
            SHA256 = Input
        End If

        Dim a1 As String = StringToBase64(SHA256)
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

        Dim SHA256_Final As String = ComputeSha256Hash(a16)

        If OLD = True Then
            SHA256_Final = a16
        End If
        Base64Key = a16
        View_final_key.RichTextBox2.Text = a16

        Return SHA256_Final

    End Function



    Private Sub DecryptBackgoundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles DecryptBackgoundWorker.DoWork

        Try

            Dim EncryptionKey = CreateEncryptionKey(TextBox4.Text, False)
            Dim LegacyEncryptionKey = TextBox4.Text
            Dim LegacyEncryptionKeyv2 = CreateEncryptionKey(TextBox4.Text, True)


            If TextBox4.Text = "" Then
                MsgBox("A decryption key is needed", 0 + 16, "EzFileEncrypt")

                PrintLog("ERROR: A decryption key is needed", True)

            Else
                Try
                    PrintLog("OK: Decrypting: decrypt0.tmp", False)
                    Me.Invoke(Sub() Status_ProgressBar.Value = 20)
                    Dim selectedItem As String = String.Empty

                    Me.Invoke(New Action(Sub() selectedItem = ComboBox1.SelectedItem.ToString()))


                    If selectedItem = "EZFileEncrypt encryption method v1 (Legacy)" Then
                        EncryptDecryptFile.DecryptFile(TextBox6.Text, "decrypt0.tmp", LegacyEncryptionKey)

                    ElseIf selectedItem = "EZFileEncrypt encryption method v3 (Latest)" Then

                        EncryptDecryptFile.DecryptFile(TextBox6.Text, "decrypt0.tmp", EncryptionKey)


                    ElseIf selectedItem = "EZFileEncrypt encryption method v2 (Legacy)" Then
                        EncryptDecryptFile.DecryptFile(TextBox6.Text, "decrypt0.tmp", LegacyEncryptionKeyv2)
                    End If



                Catch ex As Exception
                    MsgBox("EncryptDecryptFile.DecryptFile() function failure please check your decryption key. FULL ERROR: " & ex.Message, 0 + 16, "EzFileEncrypt")

                    PrintLog("ERROR: Decrypting: EncryptDecryptFile.DecryptFile() function failure please check your decryption key.", True)

                End Try

                PrintLog("OK: Creating directory: " & Path.GetFileNameWithoutExtension(TextBox6.Text), False)
                Me.Invoke(Sub() Status_ProgressBar.Value = 25)
                My.Computer.FileSystem.CreateDirectory(Path.GetFileNameWithoutExtension(TextBox6.Text))
                Try
                    PrintLog("OK: Extracting files from unencrypted archive... ", False)


                    ZipFile.ExtractToDirectory("decrypt0.tmp", Path.GetDirectoryName(TextBox6.Text) & "\" & Path.GetFileNameWithoutExtension(TextBox6.Text))
                    Me.Invoke(Sub() Status_ProgressBar.Value = 80)
                    PrintLog("OK: archive extraction successful", False)


                Catch ex As Exception
                    MsgBox("decrypt0.tmp seems to be corrupted | most likely cause: wrong decryption key, please ensure that you have entered your decryption key correctly. | FULL ERROR: " & Environment.NewLine & Environment.NewLine & ex.Message, 0 + 16)
                    My.Computer.FileSystem.DeleteFile("decrypt0.tmp")

                    PrintLog("ERROR: decrypt0.tmp seems to be corrupted | most likely cause: wrong decryption key, please ensure that you have entered your decryption key correctly.", True)
                End Try
                PrintLog("OK: deleting decrypt0.tmp", False)

                My.Computer.FileSystem.DeleteFile("decrypt0.tmp")
                Me.Invoke(Sub() Status_ProgressBar.Value = 100)
                PrintLog("OK: Done!", False)

                MsgBox("successfully decrypted files", 0 + 64, "EzFileEncrypt")
            End If


        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16, "EzFileEncrypt")
            PrintLog("OK: ERROR: " & ex.Message, True)

        End Try
        Me.Invoke(Sub() Status_ProgressBar.Value = 0)
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



    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Inputfile_txt_TextChanged(sender As Object, e As EventArgs) Handles Inputfile_txt.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' ComboBox1.DropDownStyle =
        If ComboBox1.SelectedItem = "EZFileEncrypt encryption method v1 (Legacy)" Then
            MsgBox("This is a legacy format and will only work for files encrypted with earlier versions of the software (v2.0.0 and earlier) ", 0 + 48, "Warning")
        ElseIf ComboBox1.SelectedItem = "EZFileEncrypt encryption method v2 (Legacy)" Then
            MsgBox("This is a legacy format and will only work for files encrypted with earlier versions of the software (between versions: v2.1.0 - 2.4.6) ", 0 + 48, "Warning")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim Key = CreateEncryptionKey(TextBox1.Text, False)
        TextBox2.Text = Key
        RichTextBox3.Text = Base64Key
    End Sub

    Private Sub TabPage4_Click(sender As Object, e As EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

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