using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H_R
{
    public partial class Select_Server : Form
    {
        public Select_Server()
        {
            InitializeComponent();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (txt_me.Text.Trim() == "28807211300")
            {
                pnl_login.Visible = false;
                //txt_users.Visible = true;
                //btn_insert.Visible = true;
                //msg2.Visible = true;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server_Name = txt_ServerName.Text.Trim();
            Properties.Settings.Default.DataBaseName = txt_DataBaseName.Text.Trim();
            Properties.Settings.Default.UserName = txt_UserName.Text.Trim();
            Properties.Settings.Default.Password = txt_Paswword.Text.Trim();
            //Properties.Settings.Default.PRINTER = txt_Printer.Text.Trim();
            Properties.Settings.Default.Save();
            msg.Text = "تم الحفظ بنجاح";
        }

        private void Select_Server_Load(object sender, EventArgs e)
        {
            txt_ServerName.Text = Properties.Settings.Default.Server_Name;
            txt_DataBaseName.Text = Properties.Settings.Default.DataBaseName;
            txt_UserName.Text = Properties.Settings.Default.UserName;
            txt_Paswword.Text = Properties.Settings.Default.Password;
            //txt_Printer.Text = Properties.Settings.Default.PRINTER;
            //txt_users.Text = Properties.Settings.Default.login;
        }
    }
}
