using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class MainForm : Form
    {
        private bool Listening_FLag; 
        public MainForm()
        {
            InitializeComponent();
            Listening_FLag = false;
            Program.fhc.SetForm("MainForm", "Compare_Text","Eculid_Text", "DotMult_Text", "LeapStatus");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Listening_FLag)
            {
                button1.Text = "Start";
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

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
