using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using QRCoder;

namespace XANGDAU
{
    public partial class TrangchuForm : Form
    {
        public TrangchuForm()
        {
            InitializeComponent();
        }

        private void TrangchuForm_Load(object sender, EventArgs e)
        {
            DateTimeTimer.Start();
            UpdateDateAndTime();
            renderQRCode("");
        }

        private void UpdateDateAndTime()
        {
            string[] ThutrongTuan = { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };
            lbDate.Text = ThutrongTuan[(int)DateTime.Now.DayOfWeek] + ", " + DateTime.Now.ToString("dd/MM/yyyy");
            lbTime.Text = DateTime.Now.ToShortTimeString();
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
                        lbTankName.Text = data[2].ToString();
                        lbThroat.Text = data[3].ToString();
                        lbSetpoint.Text = data[4].ToString();
                        lbDongia.Text = data[5].ToString();
                        lbThanhtien.Text = data[6].ToString();
                        lbTrangthai.Text = data[7].ToString();
                        lbThoigian.Text = ((DateTime)data[8]).ToString("dd/MM/yyyy hh:mm tt");
                        lbTrangthai.ForeColor = lbTrangthai.Text == "Đã hoàn thành" ? Color.Green : Color.Red;
                        //render QR
                        renderQRCode("XangDauB12HaiDuong|" + tbIDdonhang.Text + "|" + lbTankName.Text + "|" + lbThroat.Text + "|" + lbSetpoint.Text + "|" + lbDongia.Text + "|" + lbThanhtien.Text + "|" + lbTrangthai.Text + "|" + lbThoigian.Text);
                    }
                    else
                    {
                        MessageBox.Show("Mã đơn không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbIDdonhang.Text = "";
                        lbTankName.Text = "----";
                        lbThroat.Text = "----";
                        lbSetpoint.Text = "----";
                        lbDongia.Text = "----";
                        lbThanhtien.Text = "----";
                        lbTrangthai.Text = "----";
                        lbThoigian.Text = "----";
                        lbTrangthai.ForeColor = Color.Black;
                        //render QR
                        renderQRCode("");
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
                Image image = Properties.Resources.Hust;

                e.Graphics.DrawImage(image, 700, 40, 61, 90);
                int yPos = 40;
                e.Graphics.DrawString("CÔNG TY XĂNG DẦU B12 HẢI DƯƠNG", new Font("Arial", 18, FontStyle.Bold), Brushes.DarkBlue, new Point(30, yPos));
                e.Graphics.DrawString("Địa chỉ: Nguyễn Lương Bằng, Thành phố Hải Dương", new Font("Arial", 12, FontStyle.Regular), Brushes.DarkBlue, new Point(30, yPos += 30));
                e.Graphics.DrawString("Website: xangdaub12haiduong.com", new Font("Arial", 12, FontStyle.Regular), Brushes.DarkBlue, new Point(30, yPos += 20));
                e.Graphics.DrawString("Hotline: 0123456789", new Font("Arial", 12, FontStyle.Regular), Brushes.DarkBlue, new Point(30, yPos += 20));

                e.Graphics.DrawString("HÓA ĐƠN", new Font("Arial", 36, FontStyle.Bold), Brushes.Black, new Point(310, yPos += 70));

                e.Graphics.DrawString("Họ và tên: " + tbCustomerName.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos += 90));
                e.Graphics.DrawString("Địa chỉ: " + tbCustomerAddr.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos += 25));
                e.Graphics.DrawString("Số điện thoại: " + tbCustomerPhone.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos += 25));

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
                e.Graphics.DrawString(tbIDdonhang.Text.ToUpper(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 50, yPos));
                e.Graphics.DrawString(lbTankName.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 90, yPos));
                e.Graphics.DrawString(lbThroat.Text.ToUpper(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(xPos += 100, yPos));
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
            if (lbSetpoint.Text == "----")
            {
                MessageBox.Show("Bạn chưa nhập mã đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (lbTrangthai.Text != "Đã hoàn thành")
            {
                MessageBox.Show("Đơn hàng chưa hoàn thành, không thể xuất hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (tbCustomerName.Text == "" || tbCustomerAddr.Text == "" || tbCustomerPhone.Text == "")
            {
                MessageBox.Show("Thông tin khách hàng không thể bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            printDocument1.Print();
        }

        private void DateTimeTimer_Tick(object sender, EventArgs e)
        {
            UpdateDateAndTime();
        }

        private void renderQRCode(string QRCode)
        {
            QRCodeGenerator.ECCLevel eccLevel = QRCodeGenerator.ECCLevel.H;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRCode, eccLevel);
            QRCode qrCode = new QRCode(qrCodeData);

            int iconSize = 15;
            int cellSize = 20;
            int padding = 2;

            pictureBoxQRCode.BackgroundImage = qrCode.GetGraphic(cellSize, Color.Black, Color.White, null, iconSize, padding);

        }

    }
}
