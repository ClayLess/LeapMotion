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

        private void search_button_Click(object sender, EventArgs e)
        {
            MainForm father = (MainForm)this.Owner;
            string id = ID_textBox.Text;
            string name = Name_textBox.Text;
            string intro = Intro_textBox.Text;
            string limit = "";
            if (id!="")
            {
                limit = "where hand_id = " + id;
            }
            else if(name!=""||intro!="")
            {
                if(name!="")
                {
                    name = "`name` like" + "\"%" + name + "%\"";
                }
                if(intro != "")
                {
                    intro = "`intro` like" + "\"%" + intro + "%\"";
                }
                if(name!=""&&intro!="")
                {
                    limit = "where " + name + " and " + intro;
                }
                else
                {
                    limit = "where " + name + intro;
                }
            }
            string[] result = father.handsql.FindHand(limit);
            Hand_Info_View.Clear();
            Hand_Info_View.Columns.Add("ID");
            Hand_Info_View.Columns.Add("名字");
            Hand_Info_View.Columns.Add("介绍");
            Hand_Info_View.GridLines = true;
            foreach (string s in result)
            {
                if (s != "")
                {
                    string[] ss = s.Split('|');
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = ss[0];
                    lvi.SubItems.Add(ss[1]);
                    lvi.SubItems.Add(ss[2]);
                    Hand_Info_View.Items.Add(lvi);
                }
            }
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            ID_textBox.Clear();
            Intro_textBox.Clear();
            Name_textBox.Clear();
            Hand_Info_View.Clear();
            Hand_Info_View.GridLines = false;
        }

        private void select_button_Click(object sender, EventArgs e)
        {
            MainForm father = (MainForm)this.Owner;
            if (Hand_Info_View.SelectedItems!=null)
            {
                ListViewItem lvi = Hand_Info_View.SelectedItems[0];
                int id = Convert.ToInt32(lvi.Text);
                //发送ID
                DialogResult dr = MessageBox.Show(this, "你希望发送的ID是" + id, "Warning!", MessageBoxButtons.OKCancel);
                if (dr.Equals(DialogResult.OK))
                {
                    
                    //father.connecter.SocketSend(HandId_textBox.Text);
                    father.handsql.GetHandFromDB(id);
                    //father.hb.hand = father.handsql.hand;
                    father.hb.hand_id = id;
                    father.hb.hand_name = father.handsql.FindHandName(id);
                    father.Change_Vhand_Name(father.hb.hand_name);
                    MessageBox.Show("编号为"+id+"的手已加载");
                    father.hb.ShowHand(false);
                }
            }
            else
            {
                MessageBox.Show("请先选中加载对象");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm father = (MainForm)this.Owner;
            if (Hand_Info_View.SelectedItems != null)
            {
                father.handsql.DeleteHand(Convert.ToInt32(Hand_Info_View.SelectedItems[0].Text));
                MessageBox.Show("删除成功");
                search_button_Click(null, null);
            }
            else
            {
                MessageBox.Show("请先选中删除对象");
            }
        }
    }
}
