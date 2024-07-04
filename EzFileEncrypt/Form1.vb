Imports System.IO
Imports System.Security.Cryptography

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openFileDialog1 As New OpenFileDialog

        openFileDialog1.Title = "Select a File"
        openFileDialog1.InitialDirectory = "C:\"
        openFileDialog1.Filter = "All Files|*.*"


        If openFileDialog1.ShowDialog = DialogResult.OK Then
            Dim filePath = openFileDialog1.FileName
            TextBox1.Text = filePath
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim saveFileDialog1 As New SaveFileDialog

        ' Set properties
        saveFileDialog1.Title = "Save a File"
        saveFileDialog1.InitialDirectory = "C:\"
        saveFileDialog1.Filter = "All Files|*.*"

        ' Show the dialog and get result
        If saveFileDialog1.ShowDialog = DialogResult.OK Then
            Dim filePath = saveFileDialog1.FileName
            TextBox2.Text = filePath
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox3.Text = "" Then
            MsgBox("No encryption key", 0 + 16)
        Else
            Try

                EncryptDecryptFile.EncryptFile(TextBox1.Text, TextBox2.Text, TextBox3.Text)
                My.Computer.FileSystem.DeleteFile(TextBox1.Text)


            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim openFileDialog1 As New OpenFileDialog

        openFileDialog1.Title = "Select a File"
        openFileDialog1.InitialDirectory = "C:\"
        openFileDialog1.Filter = "All Files|*.*"


        If openFileDialog1.ShowDialog = DialogResult.OK Then
            Dim filePath = openFileDialog1.FileName
            TextBox6.Text = filePath
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox4.Text = "" Then
            MsgBox("No encryption key", 0 + 16)
        Else
            Try
                EncryptDecryptFile.DecryptFile(TextBox6.Text, "", TextBox3.Text)
                My.Computer.FileSystem.DeleteFile(TextBox6.Text)
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class



Public Class EncryptDecryptFile
    Private Shared Function CreateRijndael(ByVal password As String, ByVal salt As Byte()) As Rijndael
        Dim pdb As New Rfc2898DeriveBytes(password, salt)
        Dim rijndael As New RijndaelManaged()
        rijndael.Key = pdb.GetBytes(32)
        rijndael.IV = pdb.GetBytes(16)
        Return rijndael
    End Function

    Public Shared Sub EncryptFile(ByVal inputFile As String, ByVal outputFile As String, ByVal password As String)
        Dim rijndael As Rijndael = CreateRijndael(password, New Byte() {1, 2, 3, 4, 5, 6, 7, 8})
        Using rijndael
            Using inStream As New FileStream(inputFile, FileMode.Open, FileAccess.Read)
                Using outStream As New FileStream(outputFile, FileMode.OpenOrCreate, FileAccess.Write)
                    Dim transformer As ICryptoTransform = rijndael.CreateEncryptor()
                    Using cryptStream As New CryptoStream(outStream, transformer, CryptoStreamMode.Write)
                        inStream.CopyTo(cryptStream)
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Public Shared Sub DecryptFile(ByVal inputFile As String, ByVal outputFile As String, ByVal password As String)
        Dim rijndael As Rijndael = CreateRijndael(password, New Byte() {1, 2, 3, 4, 5, 6, 7, 8})
        Using rijndael
            Using inStream As New FileStream(inputFile, FileMode.Open, FileAccess.Read)
                Using outStream As New FileStream(outputFile, FileMode.OpenOrCreate, FileAccess.Write)
                    Dim transformer As ICryptoTransform = rijndael.CreateDecryptor()
                    Using cryptStream As New CryptoStream(inStream, transformer, CryptoStreamMode.Read)
                        cryptStream.CopyTo(outStream)
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Class