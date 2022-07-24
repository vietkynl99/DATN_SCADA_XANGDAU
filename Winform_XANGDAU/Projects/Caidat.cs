using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;
using System.IO;
using System.IO.Ports;

namespace XANGDAU
{
    public partial class CaidatForm : Form
    {

        public CaidatForm()
        {
            InitializeComponent();

        }

        private void CaidatForm_Load(object sender, EventArgs e)
        {
            //chỉ hiện cài đặt khi là ADMIN
            groupBox4.Enabled = GlobalData.UserLevel == "ADMIN";

            //mặc định cputype s7 1500
            cbCPUType.SelectedIndex = 1;
            

            //enable system
            GlobalData.SystemEnable = true;

            //tự động kết nối với plc
            //connect_to_PLC();

            GlobalData.SystemEnable = true;
        }

        private void connect_to_PLC()
        {
            //nếu đã kết nối thì ngắt kết nối đi
            if (GlobalData.plcConnectd)
            {
                GlobalData.plc.Close();
                BtPlcConnect.Text = "Kết nối";
                PLCStatus.Text = "Chưa kết nối";
                PLCStatus.ForeColor = Color.Red;
                TextboxIP.Enabled = true;
                GlobalData.plcConnectd = false;
                GlobalData.SystemRunning = false;
            }
            //nếu chưa thì sẽ kết nối
            else
            {
                Cursor = Cursors.WaitCursor;    //cho con trỏ loading
                //kiểm tra đã điền ip
                if (TextboxIP.Text == "")
                {
                    MessageBox.Show("Địa chỉ IP không thể bỏ trống! Không thể kết nối với PLC!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //kết nối tới plc
                switch (cbCPUType.SelectedIndex)
                {
                    case 0:
                        GlobalData.plc = new Plc(CpuType.S71200, TextboxIP.Text, 0, 0);
                        break;
                    case 1:
                        GlobalData.plc = new Plc(CpuType.S71500, TextboxIP.Text, 0, 0);
                        break;
                    case 2:
                        GlobalData.plc = new Plc(CpuType.S7200, TextboxIP.Text, 0, 0);
                        break;
                    case 3:
                        GlobalData.plc = new Plc(CpuType.S7300, TextboxIP.Text, 0, 0);
                        break;
                    case 4:
                        GlobalData.plc = new Plc(CpuType.S7400, TextboxIP.Text, 0, 0);
                        break;
                }
                if (GlobalData.plc.Open() == ErrorCode.NoError)
                {
                    Cursor = Cursors.Default;   //cho con trỏ về lại bình thường
                    BtPlcConnect.Text = "Ngắt kết nối";
                    PLCStatus.Text = "Đã kết nối";
                    PLCStatus.ForeColor = Color.Green;
                    TextboxIP.Enabled = false;
                    GlobalData.plcConnectd = true;
                    GlobalData.SystemRunning = true;

                    notifyIcon1.ShowBalloonTip(3000, "Thông báo", "Đã kết nối với PLC!", ToolTipIcon.Info);
                    GlobalData.plcIP = TextboxIP.Text;  //lưu lại IP
                    GlobalFunction.InsertEventToSQL("Vận hành", "Kết nối thành công với PLC");
                }
                else
                {
                    Cursor = Cursors.Default;   //cho con trỏ về lại bình thường
                    MessageBox.Show("Không thể kết nối tới PLC! Kiểm tra lại kết nối giữa máy tính với PLC và địa chỉ IP!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GlobalData.plcConnectd = false;
                    GlobalData.SystemRunning = false;
                }
            }
        }
        
        //kết nối với plc
        private void BtPlcConnect_Click(object sender, EventArgs e)
        {
            connect_to_PLC();
        }
     
        private void btsaoluudulieu_Click(object sender, EventArgs e)
        {
            try
            {
                //hỏi lại cho chắc
                DialogResult rsl = MessageBox.Show("Bạn có chắc chắn muốn sao lưu dữ liệu không?", "Sao lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rsl == DialogResult.No)
                    return;
                // dùng dialog để ng dùng lựa chọn thư mục lưu
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Sao lưu dữ liệu";
                dialog.DefaultExt = "bak";
                dialog.Filter = "Backup files (*.bak)|*.bak";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;
                if (GlobalFunction.SQLCommand("BACKUP DATABASE " + GlobalData.databaseName + " TO DISK = '" + dialog.FileName + "'") != -1)
                {
                    MessageBox.Show("Sao lưu dữ liệu thành công! Đường dẫn tới file: \n" + dialog.FileName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GlobalFunction.InsertEventToSQL("Vận hành", "Tài khoản " + GlobalData.UserName + ": sao lưu dữ liệu thành công");
                }
                else
                    MessageBox.Show("Lỗi trong quá trình xuất file. Hãy thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Lỗi trong quá trình xuất file. Hãy thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btphuchoidulieu_Click(object sender, EventArgs e)
        {
            try
            {
                //hỏi lại cho chắc
                DialogResult rsl = MessageBox.Show("Dữ liệu cũ sẽ bị ghi đè. Bạn có chắc chắn muốn phục hồi dữ liệu không?", "Phục hồi dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rsl == DialogResult.No)
                    return;
                // dùng dialog để ng dùng lựa chọn thư mục lưu
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Phục hồi dữ liệu";
                dialog.DefaultExt = "bak";
                dialog.Filter = "Backup files (*.bak)|*.bak";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;
                if (GlobalFunction.SQLCommand("RESTORE DATABASE " + GlobalData.databaseName + " TO DISK = '" + dialog.FileName + "' WITH REPLACE") != -1)
                {
                    MessageBox.Show("Phục hồi dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GlobalFunction.InsertEventToSQL("Vận hành", "Tài khoản " + GlobalData.UserName + ": phục hồi dữ liệu thành công");
                }
                else
                    MessageBox.Show("Lỗi trong quá trình đọc file. Hãy thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Lỗi trong quá trình đọc file. Hãy thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
