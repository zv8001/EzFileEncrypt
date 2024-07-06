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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        Label8 = New Label()
        TextBox3 = New TextBox()
        Encryptbtn = New Button()
        Label3 = New Label()
        Inputfile_txt = New TextBox()
        SelInputFileBtn = New Button()
        Label2 = New Label()
        TabPage2 = New TabPage()
        DecryptusinglegacyCHK = New CheckBox()
        Label9 = New Label()
        TextBox4 = New TextBox()
        Button4 = New Button()
        Label6 = New Label()
        TextBox6 = New TextBox()
        Button6 = New Button()
        Label7 = New Label()
        TabPage3 = New TabPage()
        RichTextBox2 = New RichTextBox()
        LinkLabel1 = New LinkLabel()
        Label13 = New Label()
        RichTextBox1 = New RichTextBox()
        Label12 = New Label()
        Label11 = New Label()
        Label1 = New Label()
        OpenFileDialog1 = New OpenFileDialog()
        SaveFileDialog1 = New SaveFileDialog()
        SaveFileDialog2 = New SaveFileDialog()
        OpenFileDialog2 = New OpenFileDialog()
        PictureBox1 = New PictureBox()
        Label4 = New Label()
        Label5 = New Label()
        PictureBox2 = New PictureBox()
        EncryptBackgoundWorker = New ComponentModel.BackgroundWorker()
        outputlog_list = New ListBox()
        DecryptBackgoundWorker = New ComponentModel.BackgroundWorker()
        MoveListBox = New Timer(components)
        SaveLogBtn = New Button()
        CheckIfEncryptIsBusy = New Timer(components)
        Label10 = New Label()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        TabPage3.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Location = New Point(12, 65)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(351, 270)
        TabControl1.TabIndex = 0
        ' 
        ' TabPage1
        ' 
        TabPage1.BorderStyle = BorderStyle.Fixed3D
        TabPage1.Controls.Add(Label8)
        TabPage1.Controls.Add(TextBox3)
        TabPage1.Controls.Add(Encryptbtn)
        TabPage1.Controls.Add(Label3)
        TabPage1.Controls.Add(Inputfile_txt)
        TabPage1.Controls.Add(SelInputFileBtn)
        TabPage1.Controls.Add(Label2)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(343, 242)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Encrypt"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(3, 120)
        Label8.Name = "Label8"
        Label8.Size = New Size(334, 45)
        Label8.TabIndex = 11
        Label8.Text = "Using ultra secure AES encryption technology so not even the " & vbCrLf & "government can see your files guided you have a strong " & vbCrLf & "enough password." & vbCrLf
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(6, 178)
        TextBox3.Name = "TextBox3"
        TextBox3.PlaceholderText = "Put encryption key here"
        TextBox3.Size = New Size(331, 23)
        TextBox3.TabIndex = 10
        ' 
        ' Encryptbtn
        ' 
        Encryptbtn.Location = New Point(6, 207)
        Encryptbtn.Name = "Encryptbtn"
        Encryptbtn.Size = New Size(331, 23)
        Encryptbtn.TabIndex = 9
        Encryptbtn.Text = "Encrypt"
        Encryptbtn.UseVisualStyleBackColor = True
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
        ' Inputfile_txt
        ' 
        Inputfile_txt.Location = New Point(6, 85)
        Inputfile_txt.Name = "Inputfile_txt"
        Inputfile_txt.Size = New Size(243, 23)
        Inputfile_txt.TabIndex = 4
        ' 
        ' SelInputFileBtn
        ' 
        SelInputFileBtn.Location = New Point(255, 85)
        SelInputFileBtn.Name = "SelInputFileBtn"
        SelInputFileBtn.Size = New Size(82, 23)
        SelInputFileBtn.TabIndex = 3
        SelInputFileBtn.Text = "..."
        SelInputFileBtn.UseVisualStyleBackColor = True
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
        TabPage2.BorderStyle = BorderStyle.Fixed3D
        TabPage2.Controls.Add(DecryptusinglegacyCHK)
        TabPage2.Controls.Add(Label9)
        TabPage2.Controls.Add(TextBox4)
        TabPage2.Controls.Add(Button4)
        TabPage2.Controls.Add(Label6)
        TabPage2.Controls.Add(TextBox6)
        TabPage2.Controls.Add(Button6)
        TabPage2.Controls.Add(Label7)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(343, 242)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Decrypt"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' DecryptusinglegacyCHK
        ' 
        DecryptusinglegacyCHK.AutoSize = True
        DecryptusinglegacyCHK.Location = New Point(6, 116)
        DecryptusinglegacyCHK.Name = "DecryptusinglegacyCHK"
        DecryptusinglegacyCHK.Size = New Size(254, 19)
        DecryptusinglegacyCHK.TabIndex = 22
        DecryptusinglegacyCHK.Text = "Decrypt using legacy .EZFileEncrypt Format"
        DecryptusinglegacyCHK.UseVisualStyleBackColor = True
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(6, 138)
        Label9.Name = "Label9"
        Label9.Size = New Size(314, 39)
        Label9.TabIndex = 20
        Label9.Text = "If you encrypted your files in EZ File Encrypt v2.0.0 or earlier " & vbCrLf & "select this checkbox. because the internal decryption key " & vbCrLf & "will be different."
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
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("VHS Mono Caps", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(6, 68)
        Label6.Name = "Label6"
        Label6.Size = New Size(182, 16)
        Label6.TabIndex = 14
        Label6.Text = "select EzFileEncrypt file"
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
        ' TabPage3
        ' 
        TabPage3.BorderStyle = BorderStyle.Fixed3D
        TabPage3.Controls.Add(RichTextBox2)
        TabPage3.Controls.Add(LinkLabel1)
        TabPage3.Controls.Add(Label13)
        TabPage3.Controls.Add(RichTextBox1)
        TabPage3.Controls.Add(Label12)
        TabPage3.Controls.Add(Label11)
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Size = New Size(343, 242)
        TabPage3.TabIndex = 2
        TabPage3.Text = "About"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' RichTextBox2
        ' 
        RichTextBox2.Location = New Point(3, 157)
        RichTextBox2.Name = "RichTextBox2"
        RichTextBox2.Size = New Size(337, 58)
        RichTextBox2.TabIndex = 28
        RichTextBox2.Text = resources.GetString("RichTextBox2.Text")
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.Location = New Point(103, 218)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(228, 15)
        LinkLabel1.TabIndex = 27
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "https://github.com/zv8001/EzFileEncrypt/"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(3, 220)
        Label13.Name = "Label13"
        Label13.Size = New Size(79, 13)
        Label13.TabIndex = 26
        Label13.Text = "(c) ZV800 2024"
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.Location = New Point(3, 58)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(337, 95)
        RichTextBox1.TabIndex = 25
        RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(18, 42)
        Label12.Name = "Label12"
        Label12.Size = New Size(39, 13)
        Label12.TabIndex = 24
        Label12.Text = "v 2.1.0"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("MS Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(12, 12)
        Label11.Name = "Label11"
        Label11.Size = New Size(270, 33)
        Label11.TabIndex = 24
        Label11.Text = "EZ File Encrypt"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("MS Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(270, 33)
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
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(16, 442)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(36, 36)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(63, 443)
        Label4.Name = "Label4"
        Label4.Size = New Size(85, 15)
        Label4.TabIndex = 3
        Label4.Text = "Made by zv800"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(63, 459)
        Label5.Name = "Label5"
        Label5.Size = New Size(166, 15)
        Label5.TabIndex = 4
        Label5.Text = "licensed under the MIT license"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.Gakuseisean_Ivista_2_Alarm_Padlock_256
        PictureBox2.Location = New Point(299, 19)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(60, 50)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 5
        PictureBox2.TabStop = False
        ' 
        ' EncryptBackgoundWorker
        ' 
        EncryptBackgoundWorker.WorkerSupportsCancellation = True
        ' 
        ' outputlog_list
        ' 
        outputlog_list.FormattingEnabled = True
        outputlog_list.ItemHeight = 15
        outputlog_list.Location = New Point(16, 341)
        outputlog_list.Name = "outputlog_list"
        outputlog_list.Size = New Size(343, 94)
        outputlog_list.TabIndex = 6
        ' 
        ' DecryptBackgoundWorker
        ' 
        DecryptBackgoundWorker.WorkerSupportsCancellation = True
        ' 
        ' MoveListBox
        ' 
        MoveListBox.Enabled = True
        MoveListBox.Interval = 1
        ' 
        ' SaveLogBtn
        ' 
        SaveLogBtn.Location = New Point(271, 441)
        SaveLogBtn.Name = "SaveLogBtn"
        SaveLogBtn.Size = New Size(88, 33)
        SaveLogBtn.TabIndex = 7
        SaveLogBtn.Text = "Save Log"
        SaveLogBtn.UseVisualStyleBackColor = True
        ' 
        ' CheckIfEncryptIsBusy
        ' 
        CheckIfEncryptIsBusy.Enabled = True
        CheckIfEncryptIsBusy.Interval = 1
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(16, 49)
        Label10.Name = "Label10"
        Label10.Size = New Size(39, 13)
        Label10.TabIndex = 23
        Label10.Text = "v 2.1.0"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(375, 486)
        Controls.Add(Label10)
        Controls.Add(SaveLogBtn)
        Controls.Add(outputlog_list)
        Controls.Add(PictureBox2)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(PictureBox1)
        Controls.Add(Label1)
        Controls.Add(TabControl1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MaximumSize = New Size(391, 525)
        MinimizeBox = False
        MinimumSize = New Size(391, 525)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Ez File Encrypt | https://github.com/zv8001/EzFileEncrypt"
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Inputfile_txt As TextBox
    Friend WithEvents SelInputFileBtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents Encryptbtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents SaveFileDialog2 As SaveFileDialog
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents EncryptBackgoundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents outputlog_list As ListBox
    Friend WithEvents DecryptBackgoundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents MoveListBox As Timer
    Friend WithEvents SaveLogBtn As Button
    Friend WithEvents CheckIfEncryptIsBusy As Timer
    Friend WithEvents DecryptusinglegacyCHK As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label13 As Label
    Friend WithEvents RichTextBox2 As RichTextBox

End Class
