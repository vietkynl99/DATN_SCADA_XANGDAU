using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using S7.Net;


namespace XANGDAU
{
    public partial class MainForm : Form
    {
        Color OldColor;
        Color NewColor = Color.FromArgb(106, 134, 179);
        bool popupmenuState = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GlobalData.FrmMain = this;
            //hiển thị thông tin người sử dụng
            lbFullName.Text = GlobalData.FullName;
            //lưu event
            GlobalFunction.InsertEventToSQL("Vận hành", "Tài khoản " + GlobalData.UserName + ": đăng nhập vào hệ thống với quyền " + GlobalData.UserLevel);
            //lưu lại giá trị màu cũ
            OldColor = MenuTrangchu.BackColor;
            //mở form cài đặt để tự động kết nối với PLC
            OpenForm(5);
            //mở form trang chủ
            OpenForm(1);

            toolTip.SetToolTip(picUser, "Tài khoản");
            toolTip.SetToolTip(buttonMinimize, "Thu nhỏ");
            toolTip.SetToolTip(buttonMaximize, "Phóng to / Thu nhỏ");
            toolTip.SetToolTip(buttonClose, "Thoát ứng dụng");
        }


        //form nào được mở thì nút đó sẽ sáng (index:1->5)
        private void UpdateSelectFormButton(int index)  
        {
            Button[] menuButton = { MenuTrangchu, MenuLichsu, MenuSukien };
            for (int i = 0; i < 3; i++)
            {
                if (i == index - 1)
                    menuButton[i].BackColor = NewColor;
                else
                    menuButton[i].BackColor = OldColor;
            }    
        }
        //các hàm dùng để điều khiển form được mở
        private void InsertForm(Form f)    //chen form con vao trong MainForm
        {
            f.TopLevel = false;
            f.AutoScroll = true;
            f.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(f);
            f.Show();
        }
        //mở form: đóng form khác và mở form mới + update lại cài đặt (index:1->4)
        private void OpenForm(int index)
        {
            UpdateSelectFormButton(index);

            //ẩn các form khác
            //nếu đã được khởi tạo rồi (khác null) thì ẩn
            if (GlobalData.FrmTrangchu != null)
                GlobalData.FrmTrangchu.Hide();
            if (GlobalData.FrmLichsu != null)
                GlobalData.FrmLichsu.Hide();
            if (GlobalData.FrmSukien != null)
                GlobalData.FrmSukien.Hide();
            //mở form cần mở
            //nếu chưa được khởi tạo (đang = null) thì khởi tạo mới
            switch(index)
            {
                case 1:
                    if (GlobalData.FrmTrangchu == null)
                        GlobalData.FrmTrangchu = new TrangchuForm();
                    InsertForm(GlobalData.FrmTrangchu);
                    break;
                case 2:
                    if (GlobalData.FrmLichsu == null)
                        GlobalData.FrmLichsu = new LichsuForm();
                    InsertForm(GlobalData.FrmLichsu);
                    break;
                case 3:
                    if (GlobalData.FrmSukien == null)
                        GlobalData.FrmSukien = new SukienForm();
                    InsertForm(GlobalData.FrmSukien);
                    break;
            }
        }


        private void MenuTrangchu_Click(object sender, EventArgs e)
        {
            OpenForm(1);
        }
        private void MenuBaocao_Click(object sender, EventArgs e)
        {
            OpenForm(2);
        }
        private void MenuMophong_Click(object sender, EventArgs e)
        {
            OpenForm(3);
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thoát ứng dụng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //exit
                Application.Exit();
            }
        }
        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
            //refresh lại trang để tránh lỗi hiển thị
            Refresh();
        }
        private void buttonMinimize_Click(object sender, EventArgs e)
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
        private void panelUserInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        //điều khiển form popup
        private void picUser_Click(object sender, EventArgs e)
        {
            if (!popupmenuState)
            {
                //mở form popup
                GlobalData.FrmPopupmenu = new PopUpMenuForm();
                GlobalData.FrmPopupmenu.Show();
                GlobalData.FrmPopupmenu.Location = new Point(this.Location.X + picUser.Location.X + picUser.Width, this.Location.Y + picUser.Location.Y + picUser.Height);
                popupmenuState = true;
            }
            else
            {
                //đóng form popup
                GlobalData.FrmPopupmenu.Close();
                popupmenuState = false;
            }
        }
        //đóng form popup
        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (popupmenuState)
            {
                GlobalData.FrmPopupmenu.Close();
                popupmenuState = false;
            }
        }


 

    }
}
