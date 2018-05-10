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
    public partial class DB_Connecter : Form
    {
        public DB_Connecter()
        {
            InitializeComponent();
        }

        private void Comfirm_button_Click(object sender, EventArgs e)
        {
            string DB_info = "server="+ip_text.Text+";Port="+port_text.Text+";User Id="+username_text.Text+";password="+password_text.Text+";Database="+DB_name_text.Text;
            MainForm father = (MainForm)this.Owner;
            father.DBinfo = DB_info;
            father.connecter.SocketSend("0");
            father.connecter.SocketSend(DB_info);
            father.handsql.mscon  = new MySql.Data.MySqlClient.MySqlConnection(DB_info);
            this.Close();
        }
    }
}
