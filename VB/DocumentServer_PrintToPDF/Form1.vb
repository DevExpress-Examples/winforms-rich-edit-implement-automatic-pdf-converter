Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit

Namespace DocumentServerExample

    Public Partial Class Form1
        Inherits Form

        Private fileList As List(Of String) = New List(Of String)()

        Private server As RichEditDocumentServer

        Private counter As PerformanceCounter

        Public Sub New()
            InitializeComponent()
            server = New RichEditDocumentServer()
            textBox1.Text = Application.StartupPath
            AddHandler timer1.Tick, New EventHandler(AddressOf timer1_Tick)
            Dim procName As String = Process.GetCurrentProcess().ProcessName
            counter = New PerformanceCounter("Process", "Working Set - Private", procName)
            ShowMemoryUsage()
        End Sub

        Private Sub PrintToPDF(ByVal filePath As String)
            Dim displayText As String
            Try
                server.LoadDocument(filePath)
            Catch ex As Exception
                server.CreateNewDocument()
                displayText = String.Format("{0:T} Error:{1} -> {2}", Date.Now, ex.Message, filePath) & Environment.NewLine
                textBox2.Text += displayText
                Return
            End Try

            Dim outFileName As String = Path.ChangeExtension(filePath, "pdf")
            Dim fsOut As FileStream = File.Open(outFileName, FileMode.Create)
            server.ExportToPdf(fsOut)
            fsOut.Close()
            displayText = String.Format("{0:T} Done-> {1}", Date.Now, outFileName) & Environment.NewLine
            textBox2.Text += displayText
        End Sub

        Private Sub UpdateFileList(ByVal path As String)
            If Directory.Exists(path) Then
                Dim files As String() = Directory.GetFiles(path, "*.doc?", SearchOption.AllDirectories)
                For Each file As String In files
                    If Not fileList.Contains(file) Then
                        fileList.Add(file)
                        PrintToPDF(file)
                    End If
                Next
            End If
        End Sub

        Private Sub btnConvert_Click(ByVal sender As Object, ByVal e As EventArgs)
            If timer1.Enabled Then
                timer1.Stop()
                btnConvert.Text = "Start!"
                textBox1.ReadOnly = False
            Else
                timer1.Start()
                btnConvert.Text = "Stop!"
                textBox1.ReadOnly = True
            End If
        End Sub

        Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs)
            UpdateFileList(textBox1.Text)
            ShowMemoryUsage()
        End Sub

        Private Sub ShowMemoryUsage()
            label1.Text = String.Format("Memory usage: {0:N0} K", counter.RawValue / 1024)
        End Sub
    End Class
End Namespace
