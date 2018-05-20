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
        string p_name = "demo1";
        private bool Listening_FLag;
        public Process p;
        public bool pflag;
        public TcpClient connecter = new TcpClient();
        public string DBinfo = "server=localhost;User Id=root;password=123456;Database=test1";
        private TextBox Hand_Description;
        public Hand_Buffer hb = new Hand_Buffer();
        public HandSql handsql = new HandSql();

        //存放手信息
        public  class Hand_Buffer
        {
            public Hand hand;
            public string hand_name;
            public int hand_id;
            public void ShowHand(bool new_flag)
            {
                Program.fhc.ll.vhand_flag = new_flag;
            }
            public void SetHand()
            {
                Program.fhc.ll.vhand = this.hand;
            }
        }
        
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
            Hand_Description = new TextBox();
            Hand_Description.Location = new Point(430,500);
            Hand_Description.Size = new Size(200, 100);
            Hand_Description.ReadOnly = false;
            
            this.Controls.Add(Hand_Description);
            
        }
        /*
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
        */
        private void MainForm_Load(object sender, EventArgs e)
        {
            Clear_Unity();
            this.FingerList.Columns.Add("Finger Name");
            this.FingerList.Columns.Add("Tip Distance");
            handsql.mscon = new MySqlConnection(DBinfo);
            Show_Mode2();
            //connecter.InitSocket();
        }
        private void Clear_Unity()
        {
            //Process[] ps = Process.GetProcessesByName("DEMO_f");
            Process[] ps = Process.GetProcessesByName(p_name);
            //if(ps.Length > 0)
            foreach (Process p in ps)
            {
                //ps[0].Kill();
                p.Kill();
                System.Threading.Thread.Sleep(10);
                //ps = Process.GetProcessesByName("DEMO_f");
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            Clear_Unity();
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
            SendIdForm sif = new SendIdForm();
            sif.Owner = this;
            sif.Show();
            /*
            hb.ShowHand(true);
            hb.SetHand();
            */
            Show_Mode1();
        }

        private void 双手比较ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connecter.SocketSend("2");
            Show_Mode2();
            hb.ShowHand(false);
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

        private void 启动场景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pflag && this.Exe_Panel.Created)
            {
                p.Start();
                while(Process.GetProcessesByName(p_name).Count()==0)
                {
                    System.Threading.Thread.Sleep(1000);
                }
                System.Threading.Thread.Sleep(10000);
                SetParent(p.MainWindowHandle, this.Exe_Panel.Handle);
                ShowWindow(p.MainWindowHandle, 3);//push unity program into container
                //System.Threading.Thread.Sleep(5000);
                pflag = true;
                connecter.InitSocket();
                System.Threading.Thread.Sleep(100);
                connecter.SocketSend("0|"+DBinfo);
                System.Threading.Thread.Sleep(100);
                connecter.SocketSend("2");
                //connecter.SocketSend(DBinfo);
            }

            if (Listening_FLag)
            {
                StartSene.Text = "继续场景";
                Listening_FLag = !Listening_FLag;
                Program.fhc.StopListen();
            }
            else
            {
                StartSene.Text = "暂停场景";
                Listening_FLag = !Listening_FLag;
                Program.fhc.StartListen();
            }
        }

        private void 新建条目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hb.ShowHand(false);
            Show_Mode3();//进入上传模式
        }
        private void Show_Mode1()//单手比较模式
        {
            //
            Compare_Label.Show();
            Compare_Text.Show();
            Eculid_Label.Show();
            Eculid_Text.Show();
            DotMult_Lable.Show();
            DotMult_Text.Show();
            FingerList.Show();
            LeapStatus.Show();
            VHand_name_Label.Show();
            VHand_Name_TextBox.Show();
            VHand_Name_TextBox.Text = hb.hand_name;
            VHand_Name_TextBox.ReadOnly = true;
            Hand_Description.Hide();
            UpLoad_Button.Hide();
        }
        private void Show_Mode2()//双手比较模式
        {
            //
            Compare_Label.Show();
            Compare_Text.Show();
            Eculid_Label.Show();
            Eculid_Text.Show();
            DotMult_Lable.Show();
            DotMult_Text.Show();
            FingerList.Show();
            LeapStatus.Show();
            VHand_name_Label.Hide();
            VHand_Name_TextBox.Hide();
            Hand_Description.Hide();
            UpLoad_Button.Hide();
        }
        private void Show_Mode3()//存储模式
        {
            Compare_Label.Hide();
            Compare_Text.Hide();
            Eculid_Label.Hide();
            Eculid_Text.Hide();
            DotMult_Lable.Hide();
            DotMult_Text.Hide();
            FingerList.Hide();
            VHand_name_Label.Show();
            VHand_Name_TextBox.Show();
            VHand_Name_TextBox.Text = "";
            VHand_Name_TextBox.ReadOnly = false;
            Hand_Description.Show();
            Hand_Description.ReadOnly = false;
            UpLoad_Button.Show();
        }

        private void UpLoad_Button_Click(object sender, EventArgs e)
        {
            Hand tmp = Program.fhc.ll.handspool[0];
            DialogResult dr = MessageBox.Show(this,"Do you want to Upload this hand "+VHand_Name_TextBox +" as ID:"+ handsql.FindNextId(),"Upload Comfirm",MessageBoxButtons.OKCancel);
            if(dr.Equals(DialogResult.OK))
            {
                hb.hand = tmp;
                handsql.hand = hb.hand;
                hb.hand_id = handsql.AddHand2DB();
            }
        }

        private void 调试qidongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connecter.InitSocket();
            System.Threading.Thread.Sleep(100);
            connecter.SocketSend("0|"+DBinfo);
            //connecter.SocketSend(DBinfo);
        }

        private void 数据库管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBManager dbm = new DBManager();
            dbm.Show();
        }
    }
}
