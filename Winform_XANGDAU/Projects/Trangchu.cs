using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using S7.Net;

namespace XANGDAU
{
    public partial class TrangchuForm : Form
    {
        string PLCAddSetpoint = "";
        string PLCAddStart = "";
        string PLCAddEstop = "";

        public TrangchuForm()
        {
            InitializeComponent();

        }


        private void TrangchuForm_Load(object sender, EventArgs e)
        {

            DataTimer.Start();
            UpdateData();
            cbTankSelect.SelectedIndex = 0;
            GlobalData.TankIndex = cbTankSelect.SelectedIndex;
            EditDataName();

            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();
            //Application.Exit();
        }

        private void showSystemStatus(int warninglevel, string status)     //warninglevel: 0:kocoloi     1:canhbao   2:loi
        {
            /*
            if (warninglevel == 0) 
            {
                lbSystemStatus.BackColor = Color.Transparent;
                picSystemStatus.Image = Properties.Resources.infomation_100;
            }
            else if(warninglevel == 1)
            {
                lbSystemStatus.BackColor = Color.Transparent;
                picSystemStatus.Image = Properties.Resources.warning;
            }
            else 
            {
                lbSystemStatus.BackColor = Color.Red;
                picSystemStatus.Image = Properties.Resources.warning;
            }
            lbSystemStatus.Text = status;
            */
        }


        //thay đổi trạng thái hệ thống
        private void UpdateSystemStatus()
        {
            //được phép chạy
            if (GlobalData.SystemEnable)
            {
                // chưa kết nối
                if (!GlobalData.plcConnectd)
                {
                    GlobalData.SystemRunning = false;
                    showSystemStatus(1, "Chưa kết nối với PLC! Dữ liệu mới không thể cập nhật!");
                }
                // đã kết nối 1 trong 2
                else
                {
                    GlobalData.SystemRunning = true;

                    //đọc dữ liệu thành công
                    if (GlobalData.CheckData)
                    {
                        //check xem có cảm biến nào lỗi ko
                    }
                    else
                    {
                        GlobalData.SystemRunning = false;
                        showSystemStatus(2, "Lỗi đọc dữ liệu từ PLC!");
                    }
                }
            }
            //ko cho phép chạy
            else
            {
                GlobalData.SystemRunning = false;
                //  lbSystemStatus.Text = "Hệ thống đang tắt! Dữ liệu mới không thể cập nhật!";
                //  picSystemStatus.Image = Properties.Resources.warning;
            }
        }

        int old_level = -1;
        private void UpdateLevel(int level)  //0->100
        {
            if (level < 0)
                level = 0;
            else if (level > 100)
                level = 100;
            if (level != old_level)
            {
                old_level = level;
                muclevel.Size = new Size(muclevel2.Size.Width, (int)(muclevel2.Size.Height * level / 100.0));
                muclevel.Location = new Point(muclevel2.Location.X, muclevel2.Location.Y + muclevel2.Size.Height - muclevel.Size.Height);
            }
        }
        int old_levelRON92 = -1;
        private void UpdateLevelRON92(int level)  //0->100
        {
            if (level < 0)
                level = 0;
            else if (level > 100)
                level = 100;
            if (level != old_levelRON92)
            {
                old_levelRON92 = level;
                E5RON92muclevel.Size = new Size(E5RON92muclevel2.Size.Width, (int)(E5RON92muclevel2.Size.Height * level / 100.0));
                E5RON92muclevel.Location = new Point(E5RON92muclevel2.Location.X, E5RON92muclevel2.Location.Y + E5RON92muclevel2.Size.Height - E5RON92muclevel.Size.Height);
            }
        }
        int old_levelE100 = -1;
        private void UpdateLevelE100(int level)  //0->100
        {
            if (level < 0)
                level = 0;
            else if (level > 100)
                level = 100;
            if (level != old_levelE100)
            {
                old_levelE100 = level;
                E5E100muclevel.Size = new Size(E5E100muclevel2.Size.Width, (int)(E5E100muclevel2.Size.Height * level / 100.0));
                E5E100muclevel.Location = new Point(E5E100muclevel2.Location.X, E5E100muclevel2.Location.Y + E5E100muclevel2.Size.Height - E5E100muclevel.Size.Height);
            }
        }


        private void EditDataName()
        {
            if (GlobalData.TankIndex < 6)
            {
                lb4.Text = "Máy bơm:";
                lb5.Text = "Trạng thái:";
                lb6.Visible = false;
                txt6.Visible = false;
                groupBox1.Height = 180;
            }
            else
            {
                lb4.Text = "Máy bơm 1:";
                lb5.Text = "Máy bơm 2:";
                lb6.Visible = true;
                txt6.Visible = true;
                groupBox1.Height = 220;
            }
        }

        //update lại data toàn bộ màn hình
        private void showData(TankData obj)
        {
            if (GlobalData.plcConnectd)
            {
                EditDataName();
                if (GlobalData.TankIndex < 6)
                {
                    TankData.throat_t throat = GlobalData.TankIndex % 2 == 0 ? obj.throat1 : obj.throat2;

                    lbLevel2.Text = String.Format("{0:0.0}m", obj.Level);
                    lbTemp2.Text = String.Format("{0:0.0}°C", obj.Temp);
                    lbValveOut2.Text = String.Format("{0:0}%", throat.Ctrlvalue);
                    lbFlowOut2.Text = String.Format("{0:0.0}m3/h", throat.Flow);
                    UpdateLevel((int)(obj.Level * 100 / obj.TankHeight));

                    lbVout.Text = String.Format("{0:0}", throat.Vout*1000);

                    txt1.Text = obj.TempSttMessage;
                    txt2.Text = obj.LevelSttMessage;
                    txt3.Text = throat.Enable != 0 ? "sẵn sàng" : "chưa hoạt động";
                    txt4.Text = throat.Running != 0 ? "đang chạy" : "chưa hoạt động";
                    txt5.Text = txt4.Text;

                    txt2.BackColor = obj.LevelStt == 2 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    txt1.BackColor = obj.TempStt == 2 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    txt3.BackColor = throat.Enable != 0 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    lbTemp2.BackColor = txt1.BackColor;
                    lbLevel2.BackColor = txt2.BackColor;
                }
                else   //E5
                {

                    UpdateLevelRON92((int)(GlobalData.RON92.Level * 100 / GlobalData.RON92.TankHeight));
                    UpdateLevelE100((int)(GlobalData.E100.Level * 100 / GlobalData.E100.TankHeight));

                    lbE5RON92Temp.Text = String.Format("{0:0.0}°C", GlobalData.RON92.Temp);
                    lbE5RON92Level.Text = String.Format("{0:0.0}m", GlobalData.RON92.Level);
                    lbE5RON92Valve.Text = String.Format("{0:0}%", GlobalData.E5.BatchValRON92 * 10);
                    lbE5RON92FlowOut.Text = String.Format("{0:0}l/s", GlobalData.E5.FlowOutRON92);

                    lbE5E100Temp.Text = String.Format("{0:0.0}°C", GlobalData.E100.Temp);
                    lbE5E100Level.Text = String.Format("{0:0.0}m", GlobalData.E100.Level);
                    lbE5E100Valve.Text = String.Format("{0:0}%", GlobalData.E5.BatchValE100 * 10);
                    lbE5E100FlowOut.Text = String.Format("{0:0}l/s", GlobalData.E5.FlowOutE100);
                    //lbE5Valve3.Text = GlobalData.E5.BatchRunning ? "100%" : "0%";

                    lbE5RON92Temp.BackColor = GlobalData.RON92.TempStt == 2 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    lbE5E100Temp.BackColor = GlobalData.E100.TempStt == 2 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    txt1.BackColor = obj.TempStt == 0 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    lbE5RON92Level.BackColor = GlobalData.RON92.LevelStt == 2 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    lbE5E100Level.BackColor = GlobalData.E100.LevelStt == 2 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    txt2.BackColor = obj.LevelStt == 0 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);

                    //lbVout.Text = String.Format("{0:0.0}", obj.Vout);
                    //lbDongia.Text = ((int)obj.Price).ToString();
                    //lbThanhtien.Text = ((int)obj.PriceTotal).ToString();
                    //txt3.Text = obj.Enable ? "sẵn sàng" : "chưa hoạt động";
                    //txt4.Text = obj.BatchRunning ? "đang chạy" : "chưa hoạt động";
                    txt5.Text = txt4.Text;
                    txt6.Text = txt4.Text;
                    txt2.Text = obj.LevelSttMessage;
                    txt1.Text = obj.TempSttMessage;
                }
            }
            else
            {
                if (GlobalData.TankIndex < 6)
                {
                    lbLevel2.Text = "----";
                    lbTemp2.Text = "----";
                    lbValveOut2.Text = "----";
                    lbFlowOut2.Text = "----";
                    UpdateLevel(0);
                }
                else
                {
                    lbE5RON92Temp.Text = "----";
                    lbE5RON92Level.Text = "----";
                    lbE5RON92Valve.Text = "----";
                    lbE5RON92FlowOut.Text = "----";

                    lbE5E100Temp.Text = "----";
                    lbE5E100Level.Text = "----";
                    lbE5E100Valve.Text = "----";
                    lbE5E100FlowOut.Text = "----";
                    lbE5Valve3.Text = "----";
                    UpdateLevelRON92(0);
                    UpdateLevelE100(0);
                }

                //lbVout.Text = "----";
                //txt3.Text = "----";
                //txt4.Text = "----";
                //txt5.Text = "----";
                //txt6.Text = "----";
                //txt2.Text = "----";
                //txt1.Text = "----";

                txt2.BackColor = Color.WhiteSmoke;
                lbLevel2.BackColor = Color.WhiteSmoke;
                txt1.BackColor = Color.WhiteSmoke;
                lbTemp2.BackColor = Color.WhiteSmoke;
                txt3.BackColor = Color.WhiteSmoke;
            }

            btStart.Enabled = GlobalData.plcConnectd;
            btEstop.Enabled = GlobalData.plcConnectd;
        }

        private void UpdateDateAndTime()
        {
            string[] ThutrongTuan = { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };
            lbDate.Text = ThutrongTuan[(int)DateTime.Now.DayOfWeek] + ", " + DateTime.Now.ToString("dd/MM/yyyy");
            lbTime.Text = DateTime.Now.ToShortTimeString();
        }


        //dùng để kiểm tra trạng thái và cập nhật dữ liệu lên màn hình
        private void UpdateData()
        {
            TankData[] obj_arr = { GlobalData.Diezel, GlobalData.RON92, GlobalData.RON95, GlobalData.E5 };
            showData(obj_arr[GlobalData.TankIndex / 2]);
            UpdateSystemStatus();
            UpdateDateAndTime();

        }

        //dùng để kiểm tra trạng thái và cập nhật dữ liệu lên màn hình
        private void DataTimer_Tick(object sender, EventArgs e)
        {
            UpdateData();
        }


        private void getPLCAddress(TankData obj)
        {
            if (GlobalData.TankIndex % 2 == 0)  //throat1
            {
                PLCAddSetpoint = obj.throat1.DB_send + ".DBD4";
                PLCAddStart = obj.throat1.DB_send + ".DBX0.0";
                PLCAddEstop = obj.throat1.DB_send + ".DBX0.1";
            }
            else  //throat2
            {
                PLCAddSetpoint = obj.throat2.DB_send + ".DBD4";
                PLCAddStart = obj.throat2.DB_send + ".DBX0.0";
                PLCAddEstop = obj.throat2.DB_send + ".DBX0.1";
            }
        }

        private void btStart_MouseDown(object sender, MouseEventArgs e)
        {
            TankData[] obj_arr = { GlobalData.Diezel, GlobalData.RON92, GlobalData.RON95, GlobalData.E5 };
            getPLCAddress(obj_arr[GlobalData.TankIndex / 2]);
            //đọc giá trị setpoint
            double setpoint = 0;
            try
            {
                setpoint = Convert.ToDouble(lbSetpoint.Text)/1000;
            }
            catch
            {
                MessageBox.Show("Giá trị nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbSetpoint.Text = "0.0";
                return;
            }
            if (setpoint == 0)
            {
                MessageBox.Show("Giá trị xuất không thể bằng 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //ghi giá trị vào plc
            try
            {
                GlobalData.plc.Write(PLCAddSetpoint, setpoint);
                GlobalData.plc.Write(PLCAddStart, 1);
            }
            catch
            {
                MessageBox.Show("Lỗi đọc/ghi tới PLC!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btStart_MouseUp(object sender, MouseEventArgs e)
        {
            TankData[] obj_arr = { GlobalData.Diezel, GlobalData.RON92, GlobalData.RON95, GlobalData.E5 };
            getPLCAddress(obj_arr[GlobalData.TankIndex / 2]);
            //check kết nối
            if (!GlobalData.plcConnectd)
            {
                MessageBox.Show("Chưa kết nối với PLC!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //ghi giá trị vào plc
            try
            {
                GlobalData.plc.Write(PLCAddStart, 0);
            }
            catch
            {
                MessageBox.Show("Lỗi đọc/ghi tới PLC!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btEstop_MouseDown(object sender, MouseEventArgs e)
        {
            TankData[] obj_arr = { GlobalData.Diezel, GlobalData.RON92, GlobalData.RON95, GlobalData.E5 };
            getPLCAddress(obj_arr[GlobalData.TankIndex / 2]);
            //ghi giá trị vào plc
            try
            {
                GlobalData.plc.Write(PLCAddEstop, 1);
            }
            catch
            {
                MessageBox.Show("Lỗi đọc/ghi tới PLC!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btEstop_MouseUp(object sender, MouseEventArgs e)
        {
            TankData[] obj_arr = { GlobalData.Diezel, GlobalData.RON92, GlobalData.RON95, GlobalData.E5 };
            getPLCAddress(obj_arr[GlobalData.TankIndex / 2]);
            //check kết nối
            if (!GlobalData.plcConnectd)
            {
                MessageBox.Show("Chưa kết nối với PLC!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //ghi giá trị vào plc
            try
            {
                GlobalData.plc.Write(PLCAddEstop, 0);
            }
            catch
            {
                MessageBox.Show("Lỗi đọc/ghi tới PLC!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectThroatTank(int index)
        {
            cbTankSelect.SelectedIndex = index;
            panelSingleTank.Visible = cbTankSelect.SelectedIndex != 6 && cbTankSelect.SelectedIndex != 7;
            if (panelSingleTank.Visible)
            {
                lbTankName.Text = cbTankSelect.Text.Split(' ')[2];
                lbTankName.Location = new Point(picTank.Location.X + picTank.Width / 2 - lbTankName.Width / 2, lbTankName.Location.Y);
            }

            GlobalData.TankIndex = cbTankSelect.SelectedIndex;

            EditDataName();
        }
        private void cbTankSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectThroatTank(cbTankSelect.SelectedIndex);
            tbIDdonhang.Text = "";
            lbSetpoint.Text = "0";
            lbDongia.Text = "0";
            lbThanhtien.Text = "0";
            lbTrangthai.Text = "----";
            lbThoigian.Text = "----";
        }


        //nhập mã đơn hàng xong và bấm Enter
        private void tbIDdonhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SqlDataReader data = GlobalFunction.ReadDataFromSQL("*", "DonHang", "WHERE MaDon = N'" + tbIDdonhang.Text + "'");
                    if (data != null)
                    {
                        lbSetpoint.Text = data[4].ToString();
                        lbDongia.Text = data[5].ToString();
                        lbThanhtien.Text = data[6].ToString();
                        lbTrangthai.Text = data[7].ToString();
                        lbThoigian.Text = data[8].ToString();
                        int throat = Convert.ToInt32(data[3].ToString().Split(' ')[1]);
                        SelectThroatTank(throat - 1);
                    }
                    else
                    {
                        MessageBox.Show("Mã đơn không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbIDdonhang.Text = "";
                        lbSetpoint.Text = "0";
                        lbDongia.Text = "0";
                        lbThanhtien.Text = "0";
                        lbTrangthai.Text = "----";
                        lbThoigian.Text = "----";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối với SQL Server: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbIDdonhang.Text = "";
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Image image = Properties.Resources.Logo_png;

                e.Graphics.DrawImage(image, 700, 40, 90, 90);
                int yPos = 40;
                e.Graphics.DrawString("CÔNG TY XĂNG DẦU B12 HẢI DƯƠNG", new Font("Arial", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(30, yPos));
                e.Graphics.DrawString("Địa chỉ: Nguyễn Lương Bằng, Thành phố Hải Dương", new Font("Arial", 12, FontStyle.Regular), Brushes.DarkBlue, new Point(30, yPos += 30));
                e.Graphics.DrawString("Website: xangdaub12haiduong.com", new Font("Arial", 12, FontStyle.Regular), Brushes.DarkBlue, new Point(30, yPos += 20));
                e.Graphics.DrawString("Hotline: 0123456789", new Font("Arial", 12, FontStyle.Regular), Brushes.DarkBlue, new Point(30, yPos += 20));

                e.Graphics.DrawString("HÓA ĐƠN", new Font("Arial", 36, FontStyle.Bold), Brushes.Black, new Point(310, yPos += 70));

                e.Graphics.DrawString("Họ và tên khách hàng: .........................................................................................................................", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos += 90));
                e.Graphics.DrawString("Địa chỉ: .................................................................................................................................................", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos += 25));
                e.Graphics.DrawString("Số điện thoại: .......................................................................................................................................", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos += 25));

                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos += 50));
                int xPos = 30;
                e.Graphics.DrawString("STT", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos, yPos += 20));
                e.Graphics.DrawString("Mã đơn", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 50, yPos));
                e.Graphics.DrawString("Sản phẩm", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 90, yPos));
                e.Graphics.DrawString("Họng xuất", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 100, yPos));
                e.Graphics.DrawString("Thể tích(lit)", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 100, yPos));
                e.Graphics.DrawString("Đơn giá(VND/lit)", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 120, yPos));
                e.Graphics.DrawString("Thành tiền(VND)", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 140, yPos));
                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos += 20));
                xPos = 30;
                e.Graphics.DrawString("1", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos, yPos += 20));
                e.Graphics.DrawString(tbIDdonhang.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 50, yPos));
                e.Graphics.DrawString(lbTankName.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 90, yPos));
                e.Graphics.DrawString("Họng " + (cbTankSelect.SelectedIndex + 1).ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 100, yPos));
                e.Graphics.DrawString(lbSetpoint.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 100, yPos));
                e.Graphics.DrawString(lbDongia.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 120, yPos));
                e.Graphics.DrawString(lbThanhtien.Text + "000", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 140, yPos));

                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos += 30));

                e.Graphics.DrawString("Thành tiền:    " + lbThanhtien.Text + "000 VND", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, yPos += 50));
                e.Graphics.DrawString("Chiết khấu:    0 VND", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, yPos += 20));
                e.Graphics.DrawString("Tổng:             " + lbThanhtien.Text + "000 VND", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, yPos += 20));


                e.Graphics.DrawString("Ngày " + DateTime.Now.Day.ToString() + ", Tháng " + DateTime.Now.Month.ToString() + ", Năm " + DateTime.Now.Year.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(530, yPos += 50));
                xPos = 60;
                e.Graphics.DrawString("Người mua hàng", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(xPos, yPos += 20));
                e.Graphics.DrawString("Người bán hàng", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(xPos + 520, yPos));
                e.Graphics.DrawString("(Ký, ghi rõ họ tên)", new Font("Arial", 9, FontStyle.Italic), Brushes.Black, new Point(xPos + 20, yPos += 20));
                e.Graphics.DrawString("(Ký, ghi rõ họ tên)", new Font("Arial", 9, FontStyle.Italic), Brushes.Black, new Point(xPos + 540, yPos));

                MessageBox.Show("Xuất hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi trong quá trình xuất hóa đơn. Hãy thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lbSetpoint.Text == "0")
            {
                MessageBox.Show("Bạn chưa nhập mã đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lbTrangthai.Text != "Đã hoàn thành")
            {
                MessageBox.Show("Đơn hàng chưa hoàn thành, không thể xuất hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            printDocument1.Print();
        }
    }
}
