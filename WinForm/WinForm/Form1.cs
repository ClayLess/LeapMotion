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
using LeapSql;
using Leap;
using MySql.Data.MySqlClient;

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
        public TcpClient connecter = new TcpClient();
        public string DBinfo = "server=localhost;User Id=root;password=123456;Database=test1";
        public MainForm()
        {
            InitializeComponent();
            Listening_FLag = false;
            pflag = false;
            Program.fhc.SetForm("MainForm", "Compare_Text","Eculid_Text", "DotMult_Text", "LeapStatus");
            //test
            p = new Process();
            string path = Path.GetFullPath(".\\") + "demo1.exe ";
            p.StartInfo.FileName = @path;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;//加上这句效果更好
            BeforeResize = this.Size;
            foreach(Control c in this.Controls)
            {
                Point p = new Point(c.Left, c.Top);
                BasicDic.Add(c.Name, p);
            }
            Point p_size = new Point(this.Exe_Panel.Size.Width, this.Exe_Panel.Size.Height);
            BasicDic.Add(this.Exe_Panel.Name + "Size", p_size);
            //\end test
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(!pflag&&this.Exe_Panel.Created)
            {
                p.Start();
                System.Threading.Thread.Sleep(10000);
                SetParent(p.MainWindowHandle, this.Exe_Panel.Handle);
                ShowWindow(p.MainWindowHandle, 3);//push unity program into container
                pflag = true;
                connecter.InitSocket();
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
            this.FingerList.Columns.Add("Finger Name");
            this.FingerList.Columns.Add("Tip Distance");
            //connecter.InitSocket();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Process[] ps = Process.GetProcessesByName("DEMO_f");
            Process[] ps = Process.GetProcessesByName("demo1");
            //if(ps.Length > 0)
            foreach (Process p in ps)
            {
                //ps[0].Kill();
                p.Kill();
                System.Threading.Thread.Sleep(10);
                //ps = Process.GetProcessesByName("DEMO_f");
            } 
            
            System.Environment.Exit(0);
        }

        
        private void MainForm_Resize(object sender, EventArgs e)
        {
            System.Drawing.Size EndResize = this.Size;
            float widthpara = (float)EndResize.Width / (float)BeforeResize.Width;
            float heightpara = (float)EndResize.Height / (float)BeforeResize.Height;
            foreach (Control c in this.Controls)
            {
                Point tmp;
                BasicDic.TryGetValue(c.Name,out tmp);
                c.Top = (int)(heightpara * (float)tmp.Y);
                c.Left = (int)(widthpara * (float)tmp.X);
            }
            Point p_size;
            BasicDic.TryGetValue(this.Exe_Panel.Name+"Size", out p_size);
            this.Exe_Panel.Width= (int)(widthpara * (float)p_size.X);
            this.Exe_Panel.Height = (int)(heightpara * (float)p_size.Y);
            if(pflag)
            {
                ShowWindow(p.MainWindowHandle, 9);
                ShowWindow(p.MainWindowHandle, 3);
            }
        }

        private System.Drawing.Size BeforeResize;
        private Dictionary<String, Point> BasicDic = new Dictionary<string, Point>();
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(int hWnd);
        private void 单手比较ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            connecter.SocketSend("1");
            //ShowWindow(p.Handle, 1);
        }

        private void 双手比较ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connecter.SocketSend("0");
        }

        private void 从LeapMotion读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hand hand = Program.fhc.ll.handspool[0];
            HandSql hs = new HandSql(new MySqlConnection(DBinfo));
            hs.hand = hand;
            hs.AddHand2DB();
        }

        private void 数据库连接信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB_Connecter subform = new DB_Connecter();
            subform.Owner = this;
            subform.Show();
        }
    }
}
