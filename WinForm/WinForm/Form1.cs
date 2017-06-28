using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;


namespace WinForm
{
    
    public partial class MainForm : Form
    {
        [DllImport("User32.dll ", EntryPoint = "SetParent")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll ", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        private bool Listening_FLag;
        public Process p;
        public bool pflag;
        public MainForm()
        {
            InitializeComponent();
            Listening_FLag = false;
            pflag = false;
            Program.fhc.SetForm("MainForm", "Compare_Text","Eculid_Text", "DotMult_Text", "LeapStatus");
            //test
            p = new Process();
            string path = Path.GetFullPath(".\\") + "DEMO.exe ";
            p.StartInfo.FileName = @path;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;//加上这句效果更好
            //\end test
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!pflag&&this.Exe_Panel.Created)
            {
                p.Start();
                System.Threading.Thread.Sleep(10000);
                SetParent(p.MainWindowHandle, this.Exe_Panel.Handle);
                ShowWindow(p.MainWindowHandle, 3);
                pflag = true;
            }
            if(Listening_FLag)
            {
                button1.Text = "Resume";
                Listening_FLag = !Listening_FLag;
                Program.fhc.StopListen();
            }
            else
            {
                button1.Text = "Stop";
                Listening_FLag = !Listening_FLag;
                Program.fhc.StartListen();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*
            p.Start();
            SetParent(p.MainWindowHandle, this.Exe_Panel.Handle);
            ShowWindow(p.MainWindowHandle, 3);
            */
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pflag)
            {
                p.Dispose();
                p.Close();
                p.Kill();
            }
            System.Environment.Exit(0);
        }
    }
}
