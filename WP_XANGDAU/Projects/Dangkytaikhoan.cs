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
    public partial class DangkytaikhoanForm : Form
    {
        bool hideState1 = true, hideState2 = true;
        SqlConnection sqlCon = null;


        public DangkytaikhoanForm()
        {
            InitializeComponent();
        }


        //fullname
        private void tbFullName_Enter(object sender, EventArgs e)
        {
            if (tbFullName.ForeColor == Color.DimGray)
            {
                tbFullName.Text = "";
                tbFullName.ForeColor = Color.White;
            }
        }
        private void tbFullName_Leave(object sender, EventArgs e)
        {
            if (tbFullName.Text == "")
            {
                tbFullName.Text = "Nguyễn Văn A";
                tbFullName.ForeColor = Color.DimGray;
            }
        }

        //username
        private void tbUsername_Enter(object sender, EventArgs e)
        {
            if (tbUsername.ForeColor == Color.DimGray)
            {
                tbUsername.Text = "";
                tbUsername.ForeColor = Color.White;
            }
        }
        private void tbUsername_Leave(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                tbUsername.Text = "Username";
                tbUsername.ForeColor = Color.DimGray;
            }
        }

        //password
        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.ForeColor == Color.DimGray)
            {
                tbPassword.Text = "";
                tbPassword.ForeColor = Color.White;
                tbPassword.UseSystemPasswordChar = hideState1;
            }
        }
        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text == "")
            {
                tbPassword.Text = "Password";
                tbPassword.ForeColor = Color.DimGray;
                tbPassword.UseSystemPasswordChar = false;
            }
        }

        //repeatpassword
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

        //email
        private void tbEmail_Enter(object sender, EventArgs e)
        {
            if (tbEmail.ForeColor == Color.DimGray)
            {
                tbEmail.Text = "";
                tbEmail.ForeColor = Color.White;
            }
        }
        private void tbEmail_Leave(object sender, EventArgs e)
        {
            if (tbEmail.Text == "")
            {
                tbEmail.Text = "nguyenvana@gmail.com";
                tbEmail.ForeColor = Color.DimGray;
            }
        }

        //phone
        private void tbPhone_Enter(object sender, EventArgs e)
        {
            if (tbPhone.ForeColor == Color.DimGray)
            {
                tbPhone.Text = "";
                tbPhone.ForeColor = Color.White;
            }
        }
        private void tbPhone_Leave(object sender, EventArgs e)
        {
            if (tbPhone.Text == "")
            {
                tbPhone.Text = "0123456789";
                tbPhone.ForeColor = Color.DimGray;
            }
        }


        // 2 nút ẩn / hiện mật khẩu
        private void buttonHidePassword1_Click(object sender, EventArgs e)
        {
            hideState1 = !hideState1;
            if (hideState1)
            {
                buttonHidePassword1.Image = Properties.Resources.eye2_w30_off;
                if (tbPassword.ForeColor == Color.White)
                    tbPassword.UseSystemPasswordChar = true;
            }
            else
            {
                buttonHidePassword1.Image = Properties.Resources.eye2_w30_on;
                if (tbPassword.ForeColor == Color.White)
                    tbPassword.UseSystemPasswordChar = false;
            }
        }
        private void buttonHidePassword2_Click(object sender, EventArgs e)
        {
            hideState2 = !hideState2;
            if (hideState2)
            {
                buttonHidePassword2.Image = Properties.Resources.eye2_w30_off;
                if (tbPassword.ForeColor == Color.White)
                    tbRepeatPassword.UseSystemPasswordChar = true;
            }
            else
            {
                buttonHidePassword2.Image = Properties.Resources.eye2_w30_on;
                if (tbPassword.ForeColor == Color.White)
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



        private void Dangkytaikhoan()
        {
            if (tbFullName.ForeColor == Color.DimGray)
                MessageBox.Show("Bạn chưa điền tên của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbUsername.ForeColor == Color.DimGray)
                MessageBox.Show("Bạn chưa điền tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbPassword.ForeColor == Color.DimGray)
                MessageBox.Show("Bạn chưa điền mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbRepeatPassword.ForeColor == Color.DimGray)
                MessageBox.Show("Bạn chưa nhập lại mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbPassword.Text != tbRepeatPassword.Text)
                MessageBox.Show("Nhập lại mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbPassword.Text.Length < 6)
                MessageBox.Show("Mật khẩu phải dài ít nhất 6 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbEmail.ForeColor == Color.DimGray)
                MessageBox.Show("Bạn chưa nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbPhone.ForeColor == Color.DimGray)
                MessageBox.Show("Bạn chưa nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //kết nối với SQL server
                int _id = GlobalFunction.ReadLastIDSQL("Login") + 1;
                if (GlobalFunction.InsertDataToSQL("Login", _id.ToString() + " , N'" + tbUsername.Text + "' , N'" + tbFullName.Text + "' , N'" + tbEmail.Text + "' , N'" + tbPhone.Text + "' , N'" + tbPassword.Text + "' , 'Operator' ") > 0)
                    MessageBox.Show("Đăng ký tài khoản thành công với tư cách là Operator. Liên hệ với Admin nếu muốn đăng ký tài khoản có quyền quản trị cao hơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Tài khoản đã được đăng ký. Hãy thử tên khác! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //reset lại các text về mặc định
            tbFullName.Text = "Nguyễn Văn A";
            tbFullName.ForeColor = Color.DimGray;
            tbUsername.Text = "UserName";
            tbUsername.ForeColor = Color.DimGray;
            tbPassword.Text = "Password";
            tbPassword.ForeColor = Color.DimGray;
            tbRepeatPassword.Text = "Password";
            tbRepeatPassword.ForeColor = Color.DimGray;
            tbEmail.Text = "nguyenvana@gmail.com";
            tbEmail.ForeColor = Color.DimGray;
            tbPhone.Text = "0123456789";
            tbPhone.ForeColor = Color.DimGray;
            hideState1 = true;
            hideState2 = true;
            buttonHidePassword1.Image = Properties.Resources.eye2_w30_off;
            buttonHidePassword2.Image = Properties.Resources.eye2_w30_off;
            tbPassword.UseSystemPasswordChar = false;
            tbRepeatPassword.UseSystemPasswordChar = false;
        }

        //nhấn nút đăng ký
        private void buttonDangky_Click(object sender, EventArgs e)
        {
            Dangkytaikhoan();
        }

        private void lbLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //mở form đăng nhập
            GlobalData.FrmDangnhap = new DangnhapForm();
            GlobalData.FrmDangnhap.Show();
            this.Close();
        }


        //nhấn enter cũng có thể đăng ký
        private void tbRepeatPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Dangkytaikhoan();
        }

    }
}
