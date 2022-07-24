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
    public partial class DangnhapForm : Form
    {
        bool hideState = true;
        SqlConnection sqlCon = null;


        public DangnhapForm()
        {
            InitializeComponent();
            GlobalData.FrmDangnhap = this;
        }

        private void buttonHidePassword_Click(object sender, EventArgs e)
        {
            hideState = !hideState;
            if(hideState)
            {
                buttonHidePassword.Image = Properties.Resources.eye2_w30_off;
                if (tbPassword.ForeColor == Color.White)
                    tbPassword.UseSystemPasswordChar = true;
            }   
            else
            {
                buttonHidePassword.Image = Properties.Resources.eye2_w30_on;
                if (tbPassword.ForeColor == Color.White)
                    tbPassword.UseSystemPasswordChar = false;
            }
        }


        //username
        private void tbUsername_Enter(object sender, EventArgs e)
        {
            if(tbUsername.ForeColor == Color.DimGray)
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
            if(tbPassword.ForeColor == Color.DimGray)
            {
                tbPassword.Text = "";
                tbPassword.ForeColor = Color.White;
                tbPassword.UseSystemPasswordChar = hideState;
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


        private void Dangnhap()
        {
            if (tbUsername.ForeColor == Color.DimGray)
                MessageBox.Show("Bạn chưa điền tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbPassword.ForeColor == Color.DimGray)
                MessageBox.Show("Bạn chưa điền mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //kết nối với SQL server
                try
                {
                    SqlDataReader data = GlobalFunction.ReadDataFromSQL("*", "Login", "WHERE Taikhoan = N'" + tbUsername.Text + "' and Matkhau = N'" + tbPassword.Text + "'");
                    //đăng nhập thành công
                    if (data != null)
                    {
                        //ghi lại thông tin người sử dụng
                        GlobalData.UserID = data[0].ToString();
                        GlobalData.UserName = data[1].ToString();
                        GlobalData.FullName = data[2].ToString();
                        GlobalData.UserEmail = data[3].ToString();
                        GlobalData.UserMobile = data[4].ToString();
                        GlobalData.Password = data[5].ToString();
                        GlobalData.UserLevel = data[6].ToString().ToUpper();
                        //mở form chính MainForm
                        GlobalData.FrmMain = new MainForm();
                        GlobalData.FrmMain.Show();
                        //ẩn form đăng nhập
                        GlobalData.FrmDangnhap.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu chưa chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
                }
                catch
                {
                    MessageBox.Show("Lỗi kết nối với SQL Server. Hãy đảm bảo ConnectionString chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        //ấn nút đăng nhập
        private void buttonDangnhap_Click(object sender, EventArgs e)
        {
            Dangnhap();
        }
        //nhấn enter cũng có thể đăng nhập
        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Dangnhap();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            //đóng kết nối với sql
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
            //đóng chương trình
            Application.Exit();
        }

        private void buttonMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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



        private void lbCreateNewAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangkytaikhoanForm f = new DangkytaikhoanForm();
            f.Show();
            this.Hide();
        }
    }
}
