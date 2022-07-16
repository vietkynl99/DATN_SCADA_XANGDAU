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
            if (GlobalData.UserLevel == "ADMIN")
            {
                lbUserLevel.Text = "ADMIN";
                lbUserLevel.ForeColor = Color.FromArgb(233, 206, 133);
                picCrown.Visible = true;
            }
            else
            {
                lbUserLevel.Text = "OPERATOR";
                lbUserLevel.ForeColor = Color.WhiteSmoke;
                picCrown.Visible = false;
            }
            //lưu event
            GlobalFunction.InsertEventToSQL("Vận hành", "Tài khoản " + GlobalData.UserName + ": đăng nhập vào hệ thống với quyền " + GlobalData.UserLevel);
            //chạy timer
            DataTimer.Start();
            UpdateSystemStatus();
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
            Button[] menuButton = { MenuTrangchu, MenuLichsu, MenuSukien, MenuCaidat };
            for (int i = 0; i < 4; i++)
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
            if (GlobalData.FrmCaidat != null)
                GlobalData.FrmCaidat.Hide();
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
                case 4:
                    if (GlobalData.FrmCaidat == null)
                        GlobalData.FrmCaidat = new CaidatForm();
                    InsertForm(GlobalData.FrmCaidat);
                    break;
            }

            UpdateSystemStatus();
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
        private void MenuCaidat_Click(object sender, EventArgs e)
        {
            OpenForm(4);
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thoát ứng dụng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //ngat ket noi voi plc
                if (GlobalData.plcConnectd)
                {
                    if (GlobalData.plc.IsConnected)
                        GlobalData.plc.Close();
                }   
                //lưu Event
                GlobalFunction.InsertEventToSQL("Vận hành", "Tài khoản " + GlobalData.UserName+": đăng xuất khỏi hệ thống");
                if(GlobalData.SystemRunning)
                    GlobalFunction.InsertEventToSQL("Vận hành", "Hệ thống dừng lại");
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


        //kiểm tra trạng thái của hệ thống
        private void UpdateSystemStatus()
        {
            //được phép chạy
            if (GlobalData.SystemEnable)
            {
                // chưa kết nối
                if (!GlobalData.plcConnectd) 
                    GlobalData.SystemRunning = false;
                // đã kết nối
                else
                    GlobalData.SystemRunning = GlobalData.CheckData;
            }
            //ko cho phép chạy
            else
            {
                GlobalData.SystemRunning = false;
            }    
        }


        //sau mỗi khoảng thời gian đơn vị thì lấy giá trị từ cảm biến 1 lần
        private void DataTimer_Tick(object sender, EventArgs e)
        {
            if(GlobalData.plcConnectd)
            {
                //get data từ PLC
                try
                {
                    switch(GlobalData.TankIndex)
                    {
                        case 0: 
                        case 1:
                            GlobalData.Diezel.ReadData();
                            break;
                        case 2: 
                        case 3:
                            GlobalData.RON92.ReadData();
                            break;
                        case 4:
                        case 5:
                            GlobalData.RON95.ReadData();
                            break;
                        default:
                            GlobalData.E100.ReadData();
                            GlobalData.RON92.ReadData();
                            GlobalData.E5.ReadData();
                            break;

                    }    

                    GlobalData.CheckData = true;
                }
                catch
                {
                    //hiển thị thông báo trong lần đầu bị lỗi
                    if (GlobalData.CheckData)
                    {
                        GlobalFunction.InsertEventToSQL("Lỗi", "Lỗi đọc dữ liệu do mất kết nối PLC! Hệ thống tạm dừng");
                        GlobalData.CheckData = false;
                        GlobalData.plc.Close();
                        GlobalData.plcConnectd = false;
                        MessageBox.Show("Lỗi đọc dữ liệu từ PLC!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    GlobalData.CheckData = false;
                }               
            }

            UpdateSystemStatus();
        }


    }
}
