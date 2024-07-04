<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        TextBox3 = New TextBox()
        Button3 = New Button()
        Label4 = New Label()
        TextBox2 = New TextBox()
        Button2 = New Button()
        Label3 = New Label()
        TextBox1 = New TextBox()
        Button1 = New Button()
        Label2 = New Label()
        TabPage2 = New TabPage()
        TextBox4 = New TextBox()
        Button4 = New Button()
        Label5 = New Label()
        Label6 = New Label()
        TextBox6 = New TextBox()
        Button6 = New Button()
        Label7 = New Label()
        Label1 = New Label()
        OpenFileDialog1 = New OpenFileDialog()
        SaveFileDialog1 = New SaveFileDialog()
        SaveFileDialog2 = New SaveFileDialog()
        OpenFileDialog2 = New OpenFileDialog()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Location = New Point(12, 65)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(351, 270)
        TabControl1.TabIndex = 0
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(TextBox3)
        TabPage1.Controls.Add(Button3)
        TabPage1.Controls.Add(Label4)
        TabPage1.Controls.Add(TextBox2)
        TabPage1.Controls.Add(Button2)
        TabPage1.Controls.Add(Label3)
        TabPage1.Controls.Add(TextBox1)
        TabPage1.Controls.Add(Button1)
        TabPage1.Controls.Add(Label2)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(343, 242)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Encrypt"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(6, 178)
        TextBox3.Name = "TextBox3"
        TextBox3.PlaceholderText = "Put encryption key here"
        TextBox3.Size = New Size(331, 23)
        TextBox3.TabIndex = 10
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(6, 207)
        Button3.Name = "Button3"
        Button3.Size = New Size(331, 23)
        Button3.TabIndex = 9
        Button3.Text = "Encrypt"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("VHS Mono Caps", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(6, 114)
        Label4.Name = "Label4"
        Label4.Size = New Size(133, 16)
        Label4.TabIndex = 8
        Label4.Text = "select output file"
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(6, 133)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(243, 23)
        TextBox2.TabIndex = 7
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(255, 133)
        Button2.Name = "Button2"
        Button2.Size = New Size(82, 23)
        Button2.TabIndex = 6
        Button2.Text = "..."
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("VHS Mono Caps", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(6, 66)
        Label3.Name = "Label3"
        Label3.Size = New Size(126, 16)
        Label3.TabIndex = 5
        Label3.Text = "select input file"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(6, 85)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(243, 23)
        TextBox1.TabIndex = 4
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(255, 85)
        Button1.Name = "Button1"
        Button1.Size = New Size(82, 23)
        Button1.TabIndex = 3
        Button1.Text = "..."
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("VHS Mono Caps", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(6, 15)
        Label2.Name = "Label2"
        Label2.Size = New Size(119, 32)
        Label2.TabIndex = 2
        Label2.Text = "Encrypt"
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(TextBox4)
        TabPage2.Controls.Add(Button4)
        TabPage2.Controls.Add(Label5)
        TabPage2.Controls.Add(Label6)
        TabPage2.Controls.Add(TextBox6)
        TabPage2.Controls.Add(Button6)
        TabPage2.Controls.Add(Label7)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(343, 242)
        TabPage2.TabIndex = 1
        TabPage2.Text = "TabPage2"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(6, 180)
        TextBox4.Name = "TextBox4"
        TextBox4.PlaceholderText = "Put encryption key here"
        TextBox4.Size = New Size(331, 23)
        TextBox4.TabIndex = 19
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(6, 209)
        Button4.Name = "Button4"
        Button4.Size = New Size(331, 23)
        Button4.TabIndex = 18
        Button4.Text = "Decrypt"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("VHS Mono Caps", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(6, 116)
        Label5.Name = "Label5"
        Label5.Size = New Size(133, 16)
        Label5.TabIndex = 17
        Label5.Text = "select output file"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("VHS Mono Caps", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(6, 68)
        Label6.Name = "Label6"
        Label6.Size = New Size(126, 16)
        Label6.TabIndex = 14
        Label6.Text = "select input file"
        ' 
        ' TextBox6
        ' 
        TextBox6.Location = New Point(6, 87)
        TextBox6.Name = "TextBox6"
        TextBox6.Size = New Size(243, 23)
        TextBox6.TabIndex = 13
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(255, 87)
        Button6.Name = "Button6"
        Button6.Size = New Size(82, 23)
        Button6.TabIndex = 12
        Button6.Text = "..."
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("VHS Mono Caps", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(6, 17)
        Label7.Name = "Label7"
        Label7.Size = New Size(119, 32)
        Label7.TabIndex = 11
        Label7.Text = "DECRYPT"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("PMingLiU-ExtB", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(221, 32)
        Label1.TabIndex = 1
        Label1.Text = "EZ File Encrypt"
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' OpenFileDialog2
        ' 
        OpenFileDialog2.FileName = "OpenFileDialog2"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(375, 343)
        Controls.Add(Label1)
        Controls.Add(TabControl1)
        Name = "Form1"
        Text = "Form1"
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents SaveFileDialog2 As SaveFileDialog
    Friend WithEvents OpenFileDialog2 As OpenFileDialog

End Class
