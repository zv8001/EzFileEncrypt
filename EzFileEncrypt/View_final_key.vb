Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class View_final_key
    Private WithEvents printDoc As New PrintDocument
    Private printText As String
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub



    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub



    Private Sub View_final_key_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class