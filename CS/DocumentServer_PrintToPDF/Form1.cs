using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;

namespace DocumentServerExample
{
    public partial class Form1 : Form
    {
        List<string> fileList = new List<string>();
        RichEditDocumentServer server;
        PerformanceCounter counter;

        public Form1()
        {
            InitializeComponent();
            server = new RichEditDocumentServer();
           
            textBox1.Text = Application.StartupPath;
            timer1.Tick += new EventHandler(timer1_Tick);

            string procName = Process.GetCurrentProcess().ProcessName;
            counter = new PerformanceCounter("Process", "Working Set - Private", procName);
            ShowMemoryUsage();
        }

        private void PrintToPDF(string filePath)
        {
            string displayText;

            try {
                server.LoadDocument(filePath);
            }
            catch (Exception ex) {
                server.CreateNewDocument();
                displayText = String.Format("{0:T} Error:{1} -> {2}", DateTime.Now, ex.Message, filePath) + Environment.NewLine;
                textBox2.Text += displayText;
                return;
            }
            string outFileName = Path.ChangeExtension(filePath, "pdf");
            FileStream fsOut = File.Open(outFileName, FileMode.Create);
            server.ExportToPdf(fsOut);
            fsOut.Close();
            displayText = String.Format("{0:T} Done-> {1}",DateTime.Now, outFileName) + Environment.NewLine;
            textBox2.Text += displayText;
        }

        private void UpdateFileList(string path)
        {
            if (Directory.Exists(path)) {
                string[] files = System.IO.Directory.GetFiles(path, "*.doc?", System.IO.SearchOption.AllDirectories);

                foreach (string file in files) {
                    if (!fileList.Contains(file)) {
                        fileList.Add(file);
                        PrintToPDF(file);
                    }
                }
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled) {
                timer1.Stop();
                btnConvert.Text = "Start!";
                textBox1.ReadOnly = false;
            }
            else {
                timer1.Start();
                btnConvert.Text = "Stop!";
                textBox1.ReadOnly = true;
            }
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            UpdateFileList(textBox1.Text);
            ShowMemoryUsage();
        }
        private void ShowMemoryUsage()
        {
            label1.Text = String.Format("Memory usage: {0:N0} K", counter.RawValue/1024);
        }
    }
}