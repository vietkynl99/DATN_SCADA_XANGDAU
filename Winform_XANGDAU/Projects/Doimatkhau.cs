using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace XANGDAU
{
    public partial class DoimatkhauForm : Form
    {
        bool hideState1 = true, hideState2 = true, hideState3 = true;
        SqlConnection sqlCon = null;

        public DoimatkhauForm()
        {
            InitializeComponent();

            GlobalData.FrmDoimatkhau = this;
            //update tên tài khoản
            tbFullName.Text = GlobalData.FullName;
            tbUsername.Text = GlobalData.UserName;
        }

        //old password
        private void tbOldPassword_Enter(object sender, EventArgs e)
        {
            if (tbOldPassword.ForeColor == Color.DimGray)
            {
                tbOldPassword.Text = "";
                tbOldPassword.ForeColor = Color.White;
                tbOldPassword.UseSystemPasswordChar = hideState1;
            }
        }
        private void tbOldPassword_Leave(object sender, EventArgs e)
        {
            if (tbOldPassword.Text == "")
            {
                tbOldPassword.Text = "Password";
                tbOldPassword.ForeColor = Color.DimGray;
                tbOldPassword.UseSystemPasswordChar = false;
            }
        }

        //new password
        private void tbNewPassword_Enter(object sender, EventArgs e)
        {
            if (tbNewPassword.ForeColor == Color.DimGray)
            {
                tbNewPassword.Text = "";
                tbNewPassword.ForeColor = Color.White;
                tbNewPassword.UseSystemPasswordChar = hideState1;
            }
        }
        private void tbNewPassword_Leave(object sender, EventArgs e)
        {
            if (tbNewPassword.Text == "")
            {
                tbNewPassword.Text = "Password";
                tbNewPassword.ForeColor = Color.DimGray;
                tbNewPassword.UseSystemPasswordChar = false;
            }
        }

        //repeat password
        private void tbRepeatPassword_Enter(object sender, EventArgs e)
        {
            if (tbRepeatPassword.ForeColor == Color.DimGray)
            {
                tbRepeatPassword.Text = "";
                tbRepeatPassword.ForeColor = Color.White;
                tbRepeatPassword.UseSystemPasswordChar = hideState2;
            }
        }
        private void tbRepeatPassword_Leave(object sender, EventArgs e)
        {
            if (tbRepeatPassword.Text == "")
            {
                tbRepeatPassword.Text = "Password";
                tbRepeatPassword.ForeColor = Color.DimGray;
                tbRepeatPassword.UseSystemPasswordChar = false;
            }
        }



        //3 nút ẩn / hiện mật khâu
        private void buttonHidePassword1_Click(object sender, EventArgs e)
        {
            hideState1 = !hideState1;
            if (hideState1)
            {
                buttonHidePassword1.Image = Properties.Resources.eye2_w30_off;
                if (tbOldPassword.ForeColor == Color.White)
                    tbOldPassword.UseSystemPasswordChar = true;
            }
            else
            {
                buttonHidePassword1.Image = Properties.Resources.eye2_w30_on;
                if (tbOldPassword.ForeColor == Color.White)
                    tbOldPassword.UseSystemPasswordChar = false;
            }
        }
        private void buttonHidePassword2_Click(object sender, EventArgs e)
        {
            hideState2 = !hideState2;
            if (hideState2)
            {
                buttonHidePassword1.Image = Properties.Resources.eye2_w30_off;
                if (tbNewPassword.ForeColor == Color.White)
                    tbNewPassword.UseSystemPasswordChar = true;
            }
            else
            {
                buttonHidePassword1.Image = Properties.Resources.eye2_w30_on;
                if (tbNewPassword.ForeColor == Color.White)
                    tbNewPassword.UseSystemPasswordChar = false;
            }
        }
        private void buttonHidePassword3_Click(object sender, EventArgs e)
        {
            hideState3 = !hideState3;
            if (hideState3)
            {
                buttonHidePassword1.Image = Properties.Resources.eye2_w30_off;
                if (tbRepeatPassword.ForeColor == Color.White)
                    tbRepeatPassword.UseSystemPasswordChar = true;
            }
            else
            {
                buttonHidePassword1.Image = Properties.Resources.eye2_w30_on;
                if (tbRepeatPassword.ForeColor == Color.White)
                    tbRepeatPassword.UseSystemPasswordChar = false;
            }
        }

       

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            //đóng kết nối với sql
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
            //đóng chương trình
            Application.Exit();
        }


        //code giúp có thể dùng chuột kéo form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panelMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        

        private void Doimatkhau()
        {
            if (tbOldPassword.ForeColor == Color.DimGray)
                MessageBox.Show("Bạn chưa điền mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbNewPassword.ForeColor == Color.DimGray)
                MessageBox.Show("Bạn chưa điền mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbRepeatPassword.ForeColor == Color.DimGray)
                MessageBox.Show("Bạn chưa nhâp lại mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbNewPassword.Text != tbRepeatPassword.Text)
                MessageBox.Show("Nhập lại mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbOldPassword.Text == tbNewPassword.Text)
                MessageBox.Show("Nhập khẩu mới không được trùng với mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbOldPassword.Text != GlobalData.Password)
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbUsername.Text.Length < 6)
                MessageBox.Show("Tên đăng nhập phải dài ít nhất 6 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbNewPassword.Text.Length < 6)
                MessageBox.Show("Mật khẩu phải dài ít nhất 6 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //kết nối với SQL server
                try
                {
                    if (GlobalFunction.UpdateDataToSQL("Login", "MatKhau = N'" + tbNewPassword.Text + "' WHERE TaiKhoan = N'" + GlobalData.UserName + "'") > 0)
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Lỗi kết nối với SQL Server.Hãy đảm bảo ConnectionString chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            //reset lại các text về mặc định
            tbOldPassword.Text = "Password";
            tbOldPassword.ForeColor = Color.DimGray;
            tbNewPassword.Text = "Password";
            tbNewPassword.ForeColor = Color.DimGray;
            tbRepeatPassword.Text = "Password";
            tbRepeatPassword.ForeColor = Color.DimGray;
            hideState1 = true;
            hideState2 = true;
            hideState3 = true;
            buttonHidePassword1.Image = Properties.Resources.eye2_w30_off;
            buttonHidePassword2.Image = Properties.Resources.eye2_w30_off;
            buttonHidePassword3.Image = Properties.Resources.eye2_w30_off;
            tbOldPassword.UseSystemPasswordChar = false;
            tbNewPassword.UseSystemPasswordChar = false;
            tbRepeatPassword.UseSystemPasswordChar = false;
        }

        private void lbLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //mở form đăng nhập
            GlobalData.FrmDangnhap = new DangnhapForm();
            GlobalData.FrmDangnhap.Show();
            this.Close();
        }

        //nhấn enter cũng có thể đổi mk
        private void tbRepeatPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Doimatkhau();
        }
        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            Doimatkhau();
        }
    }
}
