using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace XANGDAU
{
    public partial class SukienForm : Form
    {
        DateTime startDateTime, endDateTime;
        string timeSort = "ASC";   //mặc đinh là tăng dần
        SqlConnection sqlCon = null;


        public SukienForm()
        {
            InitializeComponent();

        }

        private void SukienForm_Load(object sender, EventArgs e)
        {

            //chỉnh các lựa chọn về mặc định
            cbSelectData.SelectedIndex = 3;
            cbSapxepthoigian.SelectedIndex = 0;
            cbSelectDateTime.SelectedIndex = 1;
            dateTimePickerStart.Value = DateTime.Today;
            dateTimePickerEnd.Value = DateTime.Today;

            EditListView();

            //chạy timer
            AutoRefreshTimer.Start();
        }

        //tạo listview theo dữ liệu cần xem (4 cột)
        private void EditListView()
        {
            //xóa toàn bộ bảng
            listView1.Clear();
            //thêm các cột
            listView1.Columns.Add("STT", 50);
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Ngày", 100);
            listView1.Columns.Add("Thời gian", 90);
            listView1.Columns.Add("Phân loại", 100);
            listView1.Columns.Add("Sự kiện", 600);
        }

        //upload bảng dữ liệu theo thời gian lựa chọn: vận hành / lỗi / toàn bộ
        private int UploadEventToListView(string tableName, string condition, DateTime startDateTime, DateTime endDateTime)
        {
            int i = 0;
            try
            {
                //tạo kết nỗi
                sqlCon = new SqlConnection(GlobalData.connectionString);
                //nếu đang đóng thì mở kết nối
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                //nếu đã mở kết nối thì đọc dữ liệu
                if (sqlCon.State == ConnectionState.Open)
                {
                    string sqlCmd = "SELECT * FROM " + tableName
                        + " WHERE " + condition + " Thoigian >= '" + startDateTime.ToString() + "' AND Thoigian <= '" + endDateTime.ToString()
                        + "' ORDER BY Thoigian " + timeSort;
                    SqlCommand cmd = new SqlCommand(@sqlCmd, sqlCon);
                    SqlDataReader data = cmd.ExecuteReader();
                    //đọc thành công
                    listView1.Items.Clear();
                    while (data.Read())
                    {
                        //cột 1 STT
                        listView1.Items.Add((i + 1).ToString());
                        //cột 2 ID
                        listView1.Items[i].SubItems.Add(data[0].ToString());

                        //lấy ra thời gian từ SQL (data[3])
                        DateTime thoigian = (DateTime)data[3];
                        //cột 3 ngày tháng
                        listView1.Items[i].SubItems.Add(thoigian.ToString("dd/MM/yyyy"));
                        //cột 4 thời gian
                        listView1.Items[i].SubItems.Add(thoigian.ToString("hh:mm:ss tt"));

                        //cột 5 data[1]
                        listView1.Items[i].SubItems.Add(data[1].ToString());
                        //cột 6 data[2]
                        listView1.Items[i].SubItems.Add(data[2].ToString());


                        i++;
                    }
                    //đóng kết nối
                    sqlCon.Close();

                }
            }
            catch (Exception ex)
            {
                GlobalData.SystemEnable = false;
                MessageBox.Show("Lỗi kết nối với SQL Server: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //trả lại số lượng kết quả
            return i;
        }


        //lựa chọn thời gian xem
        private void GetSeclectDateTime()
        {
            if (cbSelectDateTime.Text == "Tùy chọn")
            {
                //hiển thị thanh lựa chọn thời gian nếu ở chế độ tùy chọn
                panelDateTimePicker.Visible = true;

                //tính ra giá trị thời gian bắt đầu và kết thúc cần xem
                startDateTime = dateTimePickerStart.Value;
                endDateTime = dateTimePickerEnd.Value;
            }
            else
            {
                //tắt thanh lựa chọn thời gian nếu ở chế độ khác
                panelDateTimePicker.Visible = false;

                //tính ra giá trị thời gian bắt đầu và kết thúc cần xem
                //thòi gian bắt đầu
                switch (cbSelectDateTime.Text)
                {
                    case "1 phút vừa qua":
                        startDateTime = DateTime.Now.AddMinutes(-1);
                        break;
                    case "30 phút vừa qua":
                        startDateTime = DateTime.Now.AddMinutes(-30);
                        break;
                    case "1 giờ vừa qua":
                        startDateTime = DateTime.Now.AddHours(-1);
                        break;
                    case "12 giờ vừa qua":
                        startDateTime = DateTime.Now.AddHours(-12);
                        break;
                    case "24 giờ vừa qua":
                        startDateTime = DateTime.Now.AddHours(-24);
                        break;
                }
                //thòi gian kết thúc (hiện tại)
                endDateTime = DateTime.Now;
            }
        }


        //upload
        private void UploadToListView()
        {
            //lấy ra thời gian cần xem
            GetSeclectDateTime();

            int n;
            if(cbSelectData.Text=="Toàn bộ")
                n = UploadEventToListView("LichsuHD", "", startDateTime, endDateTime);
            else
                n = UploadEventToListView("LichsuHD", " Sukien = N'" + cbSelectData.Text + "' AND ", startDateTime, endDateTime);
            lbSoluongketqua.Text = n.ToString() + " dữ liệu được tìm thấy";
            if (n == 0)
                MessageBox.Show("Không có dữ liệu được tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //xóa dữ liệu bảng theo mốc thời gian trở về trước
        private int DeleteDataSQL(string tableName, string dateTimeDelete)
        {
            int n = 0;
            try
            {
                //tạo kết nỗi
                sqlCon = new SqlConnection(GlobalData.connectionString);
                //nếu đang đóng thì mở kết nối
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                //nếu đã mở kết nối thì đọc dữ liệu
                if (sqlCon.State == ConnectionState.Open)
                {
                    string sqlCmd = "DELETE FROM " + tableName + " WHERE Thoigian <= '" + dateTimeDelete + "'";
                    SqlCommand cmd = new SqlCommand(@sqlCmd, sqlCon);
                    //ghi data
                    n = cmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            catch (Exception ex)
            {
                GlobalData.SystemEnable = false;
                MessageBox.Show("Lỗi kết nối với SQL Server: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //trả về số kết quả đã xóa
            return n;
        }


        //tự động làm mới dữ liệu sau 5 lần thời gian đơn vị
        private void AutoRefreshTimer_Tick(object sender, EventArgs e)
        {
            if (GlobalData.SystemRunning && cbAutoRefresh.Checked)
                UploadToListView();
        }


        private void cbSapxepthoigian_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSapxepthoigian.SelectedIndex == 0)
                timeSort = "ASC";   //sắp xếp tăng dần
            else
                timeSort = "DESC";  //sáp xếp giảm dần
        }

        private void btDeleteData_Click(object sender, EventArgs e)
        {
            //check quyền quản trị
            if (GlobalData.UserLevel != "ADMIN")
            {
                MessageBox.Show("Bạn không đủ quyền để thực hiện chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string DateTimeDelete = DateTime.Now.AddYears(-2).ToString();
                DialogResult result = MessageBox.Show("Dữ liệu sẽ không thể phục hồi. Bạn có chắc chắn muốn xóa 2 năm về trước không?", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int n = DeleteDataSQL("LichsuHD", DateTimeDelete);
                    GlobalFunction.InsertEventToSQL("Vận hành", "Tài khoản " + GlobalData.UserName + ": đã xóa " + n.ToString() + " dữ liệu từ " + DateTimeDelete + " trở về trước");
                    MessageBox.Show("Đã xóa " + n.ToString() + " dữ liệu!", "Xóa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void cbSelectDateTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            //hiện tùy chọn thời gian
            panelDateTimePicker.Visible = cbSelectDateTime.Text == "Tùy chọn";
        }


        private void btSearch_Click(object sender, EventArgs e)
        {
            UploadToListView();
        }
       

    }
}
