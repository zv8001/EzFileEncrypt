Imports System.Drawing
Imports System.Windows.Forms
Public Class CustomProgressBar
    Inherits ProgressBar

    Private _progressBarColor As Color = Color.Blue

    Public Property ProgressBarColor As Color
        Get
            Return _progressBarColor
        End Get
        Set(value As Color)
            _progressBarColor = value
            Me.Invalidate() ' Redraw the control
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim rect As Rectangle = Me.ClientRectangle

        ' Draw the background of the progress bar
        Using backgroundBrush As New SolidBrush(Color.LightGray)
            g.FillRectangle(backgroundBrush, rect)
        End Using

        ' Draw the progress bar
        Dim progressWidth As Integer = CInt((Me.Value / Me.Maximum) * Me.Width)
        Dim progressRect As New Rectangle(0, 0, progressWidth, Me.Height)

        Using progressBrush As New SolidBrush(_progressBarColor)
            g.FillRectangle(progressBrush, progressRect)
        End Using

        ' Draw the border (optional)
        Using borderPen As New Pen(Color.Black)
            g.DrawRectangle(borderPen, 0, 0, Me.Width - 1, Me.Height - 1)
        End Using
    End Sub
End Class
