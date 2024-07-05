Imports System.IO
Imports System.Security.Cryptography
Imports System.IO.Compression
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
        Try
            ZipFile.CreateFromDirectory(Inputfile_txt.Text, Application.StartupPath & "\CreateFrom0Directory.tmp")

            EncryptDecryptFile.EncryptFile(Application.StartupPath & "\CreateFrom0Directory.tmp", Inputfile_txt.Text & ".EzFileEncrypt", TextBox3.Text)

            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\CreateFrom0Directory.tmp")
            My.Computer.FileSystem.DeleteDirectory(Inputfile_txt.Text, FileIO.DeleteDirectoryOption.DeleteAllContents)

        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16, "EzFileEncrypt")
        End Try




    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim openFileDialog1 As New OpenFileDialog()

        ' Set properties
        openFileDialog1.Title = "Select a File"
        openFileDialog1.InitialDirectory = "C:\\"
        openFileDialog1.Filter = "Ez File Encrypt|*.EzFileEncrypt"

        ' Show the dialog and get result
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog1.FileName
            TextBox6.Text = filePath
        End If
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If TextBox4.Text = "" Then
                MsgBox("A decryption key is needed", 0 + 16)
            Else
                EncryptDecryptFile.DecryptFile(TextBox6.Text, "decrypt0.tmp", TextBox4.Text)
                My.Computer.FileSystem.CreateDirectory(Path.GetFileNameWithoutExtension(TextBox6.Text))
                ZipFile.ExtractToDirectory("decrypt0.tmp", Path.GetDirectoryName(TextBox6.Text) & "\" & Path.GetFileNameWithoutExtension(TextBox6.Text))
                My.Computer.FileSystem.DeleteFile("decrypt0.tmp")
            End If


        Catch ex As Exception
            MsgBox(ex.Message, 0 + 16, "EzFileEncrypt")
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            Process.Start("https://github.com/zv8001/EzFileEncrypt")
        Catch ex As Exception
            MsgBox("Looks like you currently do not have a default browser set: https://github.com/zv8001/EzFileEncrypt", 0 + 16, "EzFileEncrypt")
        End Try

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

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