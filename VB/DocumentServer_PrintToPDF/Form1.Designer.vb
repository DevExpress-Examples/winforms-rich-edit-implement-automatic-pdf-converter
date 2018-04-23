Imports Microsoft.VisualBasic
Imports System
Namespace DocumentServerExample
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.btnConvert = New System.Windows.Forms.Button()
			Me.timer1 = New System.Windows.Forms.Timer(Me.components)
			Me.textBox1 = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.textBox2 = New System.Windows.Forms.TextBox()
			Me.SuspendLayout()
			' 
			' btnConvert
			' 
			Me.btnConvert.Location = New System.Drawing.Point(15, 244)
			Me.btnConvert.Name = "btnConvert"
			Me.btnConvert.Size = New System.Drawing.Size(75, 23)
			Me.btnConvert.TabIndex = 0
			Me.btnConvert.Text = "Start!"
			Me.btnConvert.UseVisualStyleBackColor = True
'			Me.btnConvert.Click += New System.EventHandler(Me.btnConvert_Click);
			' 
			' timer1
			' 
			Me.timer1.Interval = 5000
			' 
			' textBox1
			' 
			Me.textBox1.Location = New System.Drawing.Point(12, 29)
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(448, 20)
			Me.textBox1.TabIndex = 1
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(147, 249)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(0, 13)
			Me.label1.TabIndex = 2
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 9)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(84, 13)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Document Path:"
			' 
			' textBox2
			' 
			Me.textBox2.AcceptsReturn = True
			Me.textBox2.Location = New System.Drawing.Point(15, 62)
			Me.textBox2.Multiline = True
			Me.textBox2.Name = "textBox2"
			Me.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me.textBox2.Size = New System.Drawing.Size(445, 156)
			Me.textBox2.TabIndex = 4
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(569, 279)
			Me.Controls.Add(Me.textBox2)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.textBox1)
			Me.Controls.Add(Me.btnConvert)
			Me.Name = "Form1"
			Me.Text = "Automatic Document to PDF Converter"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btnConvert As System.Windows.Forms.Button
		Private timer1 As System.Windows.Forms.Timer
		Private textBox1 As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private textBox2 As System.Windows.Forms.TextBox
	End Class
End Namespace

