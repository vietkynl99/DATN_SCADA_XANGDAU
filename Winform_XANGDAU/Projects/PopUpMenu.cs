using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XANGDAU
{
    public partial class PopUpMenuForm : Form
    {
        public PopUpMenuForm()
        {
            InitializeComponent();

            GlobalData.FrmPopupmenu = this;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            //đóng form popup và main
            GlobalData.FrmPopupmenu.Close();
            GlobalData.FrmMain.Hide();
            //mở form đăng nhập
            GlobalData.FrmDangnhap = new DangnhapForm();
            GlobalData.FrmDangnhap.Show();
        }

        private void btChangePassword_Click(object sender, EventArgs e)
        {
            //đóng form popup và main
            GlobalData.FrmPopupmenu.Close();
            GlobalData.FrmMain.Hide();
            //mở form đổi mk
            GlobalData.FrmDoimatkhau = new DoimatkhauForm();
            GlobalData.FrmDoimatkhau.Show();
        }
    }
}
