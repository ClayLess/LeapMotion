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
    public partial class SendIdForm : Form
    {
        public SendIdForm()
        {
            InitializeComponent();
        }

        private void ComfirmButton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(HandId_textBox.Text);
            DialogResult dr = MessageBox.Show(this,"你希望发送的ID是"+HandId_textBox.Text,"Warning!",MessageBoxButtons.OKCancel);
            if (dr.Equals(DialogResult.OK))
            {
                MainForm father = (MainForm)this.Owner;
                father.connecter.SocketSend("1|"+ HandId_textBox.Text);
                //father.connecter.SocketSend(HandId_textBox.Text);
                father.handsql.GetHandFromDB(id);
                father.hb.hand = father.handsql.hand;
                father.hb.hand_id = id;
                this.Close();
            }
        }

        private void HandId_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(Char.IsNumber(e.KeyChar))&&e.KeyChar!=(char)8)
            {
                e.Handled = true;
                MessageBox.Show("请输入数字！！！");
            }
            else
            {
                //MessageBox.Show("请输入数字！！！");
            }
        }
    }
}
