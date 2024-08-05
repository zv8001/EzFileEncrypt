<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class View_final_key
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(View_final_key))
        RichTextBox1 = New RichTextBox()
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Label3 = New Label()
        RichTextBox2 = New RichTextBox()
        Label4 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.Location = New Point(12, 89)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.ReadOnly = True
        RichTextBox1.Size = New Size(417, 20)
        RichTextBox1.TabIndex = 0
        RichTextBox1.Text = ""
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.icons8_warning_48
        PictureBox1.Location = New Point(12, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(48, 50)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Red
        Label1.Location = New Point(66, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(118, 20)
        Label1.TabIndex = 2
        Label1.Text = "DO-NOT-SHARE"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Red
        Label2.Location = New Point(66, 32)
        Label2.Name = "Label2"
        Label2.Size = New Size(335, 26)
        Label2.TabIndex = 3
        Label2.Text = "Giving this to someone will allow them to reverse engineer your" & vbCrLf & "encryption key never show the text in this window"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(9, 209)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 4
        Button1.Text = "Ok"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(90, 209)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 5
        Button2.Text = "Print"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 71)
        Label3.Name = "Label3"
        Label3.Size = New Size(104, 15)
        Label3.TabIndex = 6
        Label3.Text = "Raw SHA-256 data"
        ' 
        ' RichTextBox2
        ' 
        RichTextBox2.Location = New Point(12, 115)
        RichTextBox2.Name = "RichTextBox2"
        RichTextBox2.Size = New Size(417, 88)
        RichTextBox2.TabIndex = 7
        RichTextBox2.Text = ""
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(346, 206)
        Label4.Name = "Label4"
        Label4.Size = New Size(83, 15)
        Label4.TabIndex = 8
        Label4.Text = "Base 64 data ^"
        ' 
        ' View_final_key
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(441, 244)
        Controls.Add(Label4)
        Controls.Add(RichTextBox2)
        Controls.Add(Label3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Controls.Add(RichTextBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MaximumSize = New Size(457, 283)
        MinimizeBox = False
        MinimumSize = New Size(457, 283)
        Name = "View_final_key"
        StartPosition = FormStartPosition.CenterScreen
        Text = "View_final_key"
        TopMost = True
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents Label4 As Label
End Class
