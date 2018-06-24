using System.Windows.Forms;
using Zeus.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System;

namespace TestContainer
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hwnd, uint Msg, IntPtr wParam, IntPtr lParam);
        Process mapwindow;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //axWebBrowser1.Navigate("file://"+Path.Combine(Application.StartupPath,"consola.swf"));
            axShockwaveFlash1.LoadMovie(0,"consola.swf");
            axShockwaveFlash1.Play();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //FileInfo fi = new FileInfo(@"D:\Trabajo\Zeus\Bin\MapWindow\mapwindow.exe");
            string file = @"D:\Trabajo\Zeus\MapWindow\Bin\mapwindow.exe";
            string dir = @"D:\Trabajo\Zeus\MapWindow\Bin";
            //ProcessStartInfo pi = new ProcessStartInfo(fi.FullName, fi.DirectoryName + @"\Mapa.mwprj");
            ProcessStartInfo pi = new ProcessStartInfo(file);
            pi.WorkingDirectory = dir;
            mapwindow = Process.Start(pi);
            //f2 = new Form2();
            //timer1.Start();
            //f2.ShowDialog();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            //mapwindow.CloseMainWindow();
            SendMessage(mapwindow.MainWindowHandle, 41251, IntPtr.Zero, IntPtr.Zero);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            timer1.Stop();
            Application.Exit();
        }
    }
}