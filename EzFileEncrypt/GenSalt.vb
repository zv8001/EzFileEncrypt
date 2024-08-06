Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

'A secure random number generator using a Cryptographically secure pseudorandom number generator along with hashing Mouse input

' This is basically the same as bringing a fucking AK-47 to a water gun fight *just a bit more complex than it needs to be* fml
'Because I like doing things in the most complex and stupidest way possible (also I was fucking bored give me a break)

'Recommendation do anybody who takes the source code of this program recommend changing it just to a damn Cryptographic random number generator.

' > THIS PROGRAM IS UNDER THE MIT LICENSE COPYRIGHT (c) ZV800 2024

'https://github.com/zv8001/EzFileEncrypt/


'rip support for earlier versions literally everything is different now

Public Class GenSalt
    Dim mouseData As New StringBuilder()
    Dim randomString1 As String = "."
    'Private progressBar As New ProgressBar()
    Dim lastX As Integer = -1
    Dim lastY As Integer = -1

    Public Salt1
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Public Function ComputeSHA256Hash(input As String) As String
        Using sha256 As SHA256 = SHA256.Create()

            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(input))

            Dim sb As New StringBuilder()
            For Each b As Byte In bytes
                sb.Append(b.ToString("x2"))
            Next

            Return sb.ToString()
        End Using
    End Function

    Public Function CSPRNGR_RAN(extra_random_input)


        Dim randomNumber(800) As Byte


        Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()

            rng.GetBytes(randomNumber)
        End Using

        Dim randomString As String = Convert.ToBase64String(randomNumber)

        randomString1 = randomString1 & Form1.StringToBase64(extra_random_input & randomString)
        '    MsgBox(randomString1)
        Dim SHAOUTPUT = ComputeSHA256Hash(randomString1)
        Return randomString1
    End Function




    Private Sub GenerateSalt()

        Dim CSPRNGoutput As String = CSPRNGR_RAN(mouseData.ToString())

        Dim sha256 As SHA256 = SHA256.Create()
        Dim hashBytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(CSPRNGoutput))
        Dim salt As Byte() = New Byte(31) {}

        Array.Copy(hashBytes, salt, salt.Length)
        ' TextBox1.Text = BitConverter.ToString(salt).Replace("-", "")
        FINALKeyTXT.Text = "FINAL KEY: " & BitConverter.ToString(salt).Replace("-", "")

        Dim hashString As String = BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
        ShakeyTXT.Text = "SHA-256 KEY:" & hashString
        Form1.salt = salt
        '  MessageBox.Show("Generated Salt: " & BitConverter.ToString(salt).Replace("-", "")) ""))
    End Sub

    Private Sub GenSalt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar12.Maximum = 3000
        ProgressBar12.Minimum = 0
        ProgressBar12.Value = 0
        FINALKeyTXT.Text = ""
        ShakeyTXT.Text = ""
        Label3.Text = ""
        randomString1 = "."
        MouseMoved.Start()
        lastX = -1
        lastY = -1
        mouseData.Clear()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub


    Private Sub MouseMoved_Tick(sender As Object, e As EventArgs) Handles MouseMoved.Tick
        Dim currentX As Integer = Cursor.Position.X
        Dim currentY As Integer = Cursor.Position.Y

        If currentX <> lastX OrElse currentY <> lastY Then
            mouseData.Append(currentX.ToString() & "," & currentY.ToString() & ";")

            If mouseData.Length < 3000 Then
                ProgressBar12.Value = mouseData.Length
            Else
                ProgressBar12.Value = 3000
            End If

            If ProgressBar12.Value < 1400 Then
                SendMessage(ProgressBar12.Handle, 1040, 2, 0)
            ElseIf ProgressBar12.Value < 3000 Then
                SendMessage(ProgressBar12.Handle, 1040, 3, 0)
            Else
                SendMessage(ProgressBar12.Handle, 1040, 1, 0)
            End If

            Label3.Text = "Pool Count: " & mouseData.ToString()

            lastX = currentX
            lastY = currentY
            GenerateSalt()
        End If
    End Sub

    Private Sub GenSalt_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MouseMoved.Stop()
    End Sub
End Class