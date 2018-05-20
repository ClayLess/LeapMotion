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
    public partial class DBManager : Form
    {
        public DBManager()
        {
            InitializeComponent();
        }

        private void DBManager_SizeChanged(object sender, EventArgs e)
        {
            Hand_Info_View.Size = new Size(Hand_Info_View.Size.Width, (this.Size.Height- Hand_Info_View.Height > Hand_Info_View.Height)? (this.Size.Height - Hand_Info_View.Height - 300): Hand_Info_View.Height+100);
        }

        private void DBManager_Resize(object sender, EventArgs e)
        {
        }

        private void Hand_Info_View_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
