﻿using System;
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
        string PLCAddSetpoint = "DB3.DBD76";
        string PLCAddStart = "DB3.DBX80.0";
        string PLCAddEstop = "DB3.DBX80.1";

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
            if (GlobalData.TankIndex != 3)
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
                if (GlobalData.TankIndex != 3)
                {

                    lbLevel2.Text = String.Format("{0:0.0}m", obj.Level);
                    lbTemp2.Text = String.Format("{0:0.0}°C", obj.Temp);
                    lbValveOut2.Text = String.Format("{0:0}%", obj.BatchControlVal * 10);
                    lbFlowIn2.Text = String.Format("{0:0}l/s", obj.FlowIn);
                    lbFlowOut2.Text = String.Format("{0:0}l/s", obj.FlowOut);
                    UpdateLevel((int)(obj.Level * 100 / obj.TankHeight));

                    lbVout.Text = String.Format("{0:0.0}", obj.Vout);
                    //lbDongia.Text = ((int)obj.Price).ToString();
                    //lbThanhtien.Text = ((int)obj.PriceTotal).ToString();

                    txt1.Text = obj.TempSttMessage;
                    txt2.Text = obj.LevelSttMessage;
                    txt3.Text = obj.Enable ? "sẵn sàng" : "chưa hoạt động";
                    txt4.Text = obj.BatchRunning ? "đang chạy" : "chưa hoạt động";
                    txt5.Text = txt4.Text;

                    txt2.BackColor = obj.LevelStt == 0 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    txt1.BackColor = obj.TempStt == 0 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    txt3.BackColor = obj.Enable ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    lbTemp2.BackColor = txt1.BackColor;
                    lbLevel2.BackColor = txt2.BackColor;
                }
                else
                {

                    UpdateLevelRON92((int)(GlobalData.RON92.Level * 100 / GlobalData.RON92.TankHeight));
                    UpdateLevelE100((int)(GlobalData.E100.Level * 100 / GlobalData.E100.TankHeight));

                    lbE5RON92FlowIn.Text = String.Format("{0:0}l/s", GlobalData.RON92.FlowIn);
                    lbE5RON92Temp.Text = String.Format("{0:0.0}°C", GlobalData.RON92.Temp);
                    lbE5RON92Level.Text = String.Format("{0:0.0}m", GlobalData.RON92.Level);
                    lbE5RON92Valve.Text = String.Format("{0:0}%", GlobalData.E5.BatchValRON92 * 10);
                    lbE5RON92FlowOut.Text = String.Format("{0:0}l/s", GlobalData.E5.FlowOutRON92);

                    lbE5E100FlowIn.Text = String.Format("{0:0}l/s", GlobalData.E100.FlowIn);
                    lbE5E100Temp.Text = String.Format("{0:0.0}°C", GlobalData.E100.Temp);
                    lbE5E100Level.Text = String.Format("{0:0.0}m", GlobalData.E100.Level);
                    lbE5E100Valve.Text = String.Format("{0:0}%", GlobalData.E5.BatchValE100 * 10);
                    lbE5E100FlowOut.Text = String.Format("{0:0}l/s", GlobalData.E5.FlowOutE100);
                    lbE5Valve3.Text = GlobalData.E5.BatchRunning ? "100%" : "0%";

                    lbE5RON92Temp.BackColor = GlobalData.RON92.TempStt == 0 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    lbE5E100Temp.BackColor = GlobalData.E100.TempStt == 0 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    txt1.BackColor = obj.TempStt == 0 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    lbE5RON92Level.BackColor = GlobalData.RON92.LevelStt == 0 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    lbE5E100Level.BackColor = GlobalData.E100.LevelStt == 0 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);
                    txt2.BackColor = obj.LevelStt == 0 ? Color.WhiteSmoke : Color.FromArgb(255, 60, 60);

                    lbVout.Text = String.Format("{0:0.0}", obj.Vout);
                    //lbDongia.Text = ((int)obj.Price).ToString();
                    //lbThanhtien.Text = ((int)obj.PriceTotal).ToString();
                    txt3.Text = obj.Enable ? "sẵn sàng" : "chưa hoạt động";
                    txt4.Text = obj.BatchRunning ? "đang chạy" : "chưa hoạt động";
                    txt5.Text = txt4.Text;
                    txt6.Text = txt4.Text;
                    txt2.Text = obj.LevelSttMessage;
                    txt1.Text = obj.TempSttMessage;
                }
            }
            else
            {
                if (GlobalData.TankIndex != 3)
                {
                    lbLevel2.Text = "----";
                    lbTemp2.Text = "----";
                    lbValveOut2.Text = "----";
                    lbFlowIn2.Text = "----";
                    lbFlowOut2.Text = "----";
                    UpdateLevel(0);
                }
                else
                {
                    lbE5RON92FlowIn.Text = "----";
                    lbE5RON92Temp.Text = "----";
                    lbE5RON92Level.Text = "----";
                    lbE5RON92Valve.Text = "----";
                    lbE5RON92FlowOut.Text = "----";

                    lbE5E100FlowIn.Text = "----";
                    lbE5E100Temp.Text = "----";
                    lbE5E100Level.Text = "----";
                    lbE5E100Valve.Text = "----";
                    lbE5E100FlowOut.Text = "----";
                    lbE5Valve3.Text = "----";
                    UpdateLevelRON92(0);
                    UpdateLevelE100(0);
                }

                lbVout.Text = "----";
                //lbDongia.Text = "----";
                //lbThanhtien.Text = "----";
                txt3.Text = "----";
                txt4.Text = "----";
                txt5.Text = "----";
                txt6.Text = "----";
                txt2.Text = "----";
                txt1.Text = "----";

                txt2.BackColor = Color.WhiteSmoke;
                lbLevel2.BackColor = Color.WhiteSmoke;
                txt1.BackColor = Color.WhiteSmoke;
                lbTemp2.BackColor = Color.WhiteSmoke;
                txt3.BackColor = Color.WhiteSmoke;
            }

            btStart.Enabled = GlobalData.plcConnectd;
            btEstop.Enabled = GlobalData.plcConnectd;
            btStartnhap.Enabled = GlobalData.plcConnectd;
            btEstopnhap.Enabled = GlobalData.plcConnectd;
            //tbIDdonhang.Enabled = GlobalData.plcConnectd;
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
            if (GlobalData.TankIndex == 0)
                showData(GlobalData.Diezel);
            else if (GlobalData.TankIndex == 1)
                showData(GlobalData.RON95);
            else if (GlobalData.TankIndex == 2)
                showData(GlobalData.RON92);
            else
                showData(GlobalData.E5);
            UpdateSystemStatus();
            UpdateDateAndTime();

        }

        //dùng để kiểm tra trạng thái và cập nhật dữ liệu lên màn hình
        private void DataTimer_Tick(object sender, EventArgs e)
        {
            UpdateData();
        }

        
        private void getPLCAddress()
        {
            if (GlobalData.TankIndex != 3)
            {
                PLCAddSetpoint = "DB" + (GlobalData.TankIndex + 3).ToString() + ".DBD76";
                PLCAddStart = "DB" + (GlobalData.TankIndex + 3).ToString() + ".DBX80.0";
                PLCAddEstop = "DB" + (GlobalData.TankIndex + 3).ToString() + ".DBX80.1";
            }
            else
            {
                PLCAddSetpoint = "DB7.DBD24";
                PLCAddStart = "DB7.DBX28.0"; 
                PLCAddEstop = "DB7.DBX28.1";
            }

        }

        private void btStart_MouseDown(object sender, MouseEventArgs e)
        {
            getPLCAddress();
            //đọc giá trị setpoint
            double setpoint=0;
            try
            {
                setpoint = Convert.ToDouble(lbSetpoint.Text) / 10;
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
                GlobalData.plc.Write(PLCAddStart,1);
            }
            catch
            {
                MessageBox.Show("Lỗi đọc/ghi tới PLC!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btStart_MouseUp(object sender, MouseEventArgs e)
        {
            getPLCAddress();
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
            getPLCAddress();
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
            getPLCAddress();
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

        private void cbTankSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbTankSelect.SelectedIndex != 3)
            {
                lbTankName.Text = cbTankSelect.Text;
                lbTankName.Location = new Point(picTank.Location.X + picTank.Width / 2 - lbTankName.Width / 2, lbTankName.Location.Y);
            }
            panelSingleTank.Visible = cbTankSelect.SelectedIndex != 3;

            GlobalData.TankIndex = cbTankSelect.SelectedIndex;

            EditDataName();
        }


        //nhập mã đơn hàng xong và bấm Enter
        private void tbIDdonhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string[] product = { "Diezel", "RON 95", "RON 92", "E5" };
                    SqlDataReader data = GlobalFunction.ReadDataFromSQL("*", "DonHang", "WHERE MaDon = N'" + tbIDdonhang.Text + "' AND LoaiDon = N'Xuất' AND SanPham = N'" + product[GlobalData.TankIndex] + "'");
                    if (data != null)
                    {
                        lbSetpoint.Text = data[4].ToString();
                        lbDongia.Text = data[5].ToString();
                        lbThanhtien.Text = data[6].ToString();
                    }   
                    else
                    {
                        MessageBox.Show("Mã đơn không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbIDdonhang.Text = "";
                        lbSetpoint.Text = "0";
                        lbDongia.Text = "0";
                        lbThanhtien.Text = "0";
                    }    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối với SQL Server: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbIDdonhang.Text = "";
                }
            }
        }

        private void tbIDdonhangnhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string[] product = { "Diezel", "RON 95", "RON 92", "E5" };
                    SqlDataReader data = GlobalFunction.ReadDataFromSQL("*", "DonHang", "WHERE MaDon = N'" + tbIDdonhangnhap.Text + "' AND LoaiDon = N'Nhập' AND SanPham = N'" + product[GlobalData.TankIndex] + "'");
                    if (data != null)
                    {
                        lbSetpointnhap.Text = data[4].ToString();
                        lbDongianhap.Text = data[5].ToString();
                        lbThanhtiennhap.Text = data[6].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Mã đơn không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbIDdonhangnhap.Text = "";
                        lbSetpointnhap.Text = "0";
                        lbDongianhap.Text = "0";
                        lbThanhtiennhap.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối với SQL Server: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbIDdonhangnhap.Text = "";
                }
            }
        }
    }
}