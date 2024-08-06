<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenSalt
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenSalt))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        PictureBox1 = New PictureBox()
        GroupBox1 = New GroupBox()
        Label4 = New Label()
        ShakeyTXT = New Label()
        FINALKeyTXT = New Label()
        GroupBox2 = New GroupBox()
        Button1 = New Button()
        ProgressBar12 = New CustomProgressBar()
        MouseMoved = New Timer(components)
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(119, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(210, 25)
        Label1.TabIndex = 0
        Label1.Text = "Collecting random data"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(119, 37)
        Label2.Name = "Label2"
        Label2.Size = New Size(439, 40)
        Label2.TabIndex = 1
        Label2.Text = "IMPORTANT: move your mouses randomly as possible within this " & vbCrLf & "window this increases the strength of the encryption algorithm"
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Segoe UI", 6F)
        Label3.Location = New Point(6, 19)
        Label3.Name = "Label3"
        Label3.Size = New Size(331, 119)
        Label3.TabIndex = 4
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.Gakuseisean_Ivista_2_Alarm_Padlock_256
        PictureBox1.Location = New Point(12, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(101, 94)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Location = New Point(205, 90)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(343, 150)
        GroupBox1.TabIndex = 6
        GroupBox1.TabStop = False
        GroupBox1.Text = "Salt Data (partial)"
        ' 
        ' Label4
        ' 
        Label4.Location = New Point(12, 125)
        Label4.Name = "Label4"
        Label4.Size = New Size(174, 87)
        Label4.TabIndex = 7
        Label4.Text = "The longer you move your mouse the stronger the encryption will be. it is recommended to move your mouse for at least 30 seconds."
        ' 
        ' ShakeyTXT
        ' 
        ShakeyTXT.AutoSize = True
        ShakeyTXT.Location = New Point(6, 19)
        ShakeyTXT.Name = "ShakeyTXT"
        ShakeyTXT.Size = New Size(79, 15)
        ShakeyTXT.TabIndex = 8
        ShakeyTXT.Text = "SHA-256 KEY:"
        ' 
        ' FINALKeyTXT
        ' 
        FINALKeyTXT.AutoSize = True
        FINALKeyTXT.Location = New Point(6, 34)
        FINALKeyTXT.Name = "FINALKeyTXT"
        FINALKeyTXT.Size = New Size(65, 15)
        FINALKeyTXT.TabIndex = 10
        FINALKeyTXT.Text = "FINAL KEY:"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(ShakeyTXT)
        GroupBox2.Controls.Add(FINALKeyTXT)
        GroupBox2.Location = New Point(12, 246)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(536, 58)
        GroupBox2.TabIndex = 11
        GroupBox2.TabStop = False
        GroupBox2.Text = "Data"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(473, 319)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 12
        Button1.Text = "Next >"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ProgressBar12
        ' 
        ProgressBar12.Location = New Point(18, 319)
        ProgressBar12.Name = "ProgressBar12"
        ProgressBar12.ProgressBarColor = Color.OrangeRed
        ProgressBar12.Size = New Size(449, 23)
        ProgressBar12.TabIndex = 12
        ProgressBar12.Value = 8
        ' 
        ' MouseMoved
        ' 
        MouseMoved.Interval = 20
        ' 
        ' GenSalt
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(560, 353)
        Controls.Add(ProgressBar12)
        Controls.Add(Button1)
        Controls.Add(GroupBox2)
        Controls.Add(Label4)
        Controls.Add(GroupBox1)
        Controls.Add(PictureBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MaximumSize = New Size(576, 392)
        MinimizeBox = False
        MinimumSize = New Size(576, 392)
        Name = "GenSalt"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Collecting random data:"
        TopMost = True
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ShakeyTXT As Label
    Friend WithEvents FINALKeyTXT As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button1 As Button

    Friend WithEvents ProgressBar12 As CustomProgressBar
    Friend WithEvents MouseMoved As Timer
End Class
