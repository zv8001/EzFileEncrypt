Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class View_final_key
    Private WithEvents printDoc As New PrintDocument
    Private printText As String
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        printText = RichTextBox1.Text

        ' Create a new PrintDialog
        Dim printDialog1 As New PrintDialog()
        printDialog1.Document = printDoc

        ' Show the PrintDialog and print the text if the user clicks OK
        If printDialog1.ShowDialog() = DialogResult.OK Then
            printDoc.Print()
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub View_final_key_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class