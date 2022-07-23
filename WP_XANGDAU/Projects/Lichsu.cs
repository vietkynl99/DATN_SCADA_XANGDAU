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
    public partial class LichsuForm : Form
    {
        DateTime startDateTime, endDateTime;
        string timeSort = "ASC";   //mặc đinh là tăng dần
        SqlConnection sqlCon = null;

        public LichsuForm()
        {
            InitializeComponent();
        }

        private void LichsuForm_Load(object sender, EventArgs e)
        {

            //chỉnh các lựa chọn về mặc định
            cbSelectData.SelectedIndex = 4;
            cbSapxepthoigian.SelectedIndex = 0;
            cbSelectDateTime.SelectedIndex = 1;
            dateTimePickerStart.Value = DateTime.Today;
            dateTimePickerEnd.Value = DateTime.Today;

            EditListView();

            //chạy timer
            AutoRefreshTimer.Start();
        }

        //tạo listview 
        private void EditListView()
        {
            //xóa toàn bộ bảng
            listView1.Clear();
            //thêm các cột
            listView1.Columns.Add("STT", 40);
            listView1.Columns.Add("Ngày", 85);
            listView1.Columns.Add("Thời gian", 100);
            listView1.Columns.Add("Mã đơn", 80);
            listView1.Columns.Add("Sản phẩm", 80);
            listView1.Columns.Add("Họng xuất", 80);
            listView1.Columns.Add("Thể tích(l)", 80);
            listView1.Columns.Add("Đơn giá(VND/l)", 110);
            listView1.Columns.Add("Thành tiền(VND)", 120);
            listView1.Columns.Add("Trạng thái", 130);
        }

        //upload bảng theo dữ liệu & thời gian lựa chọn
        private int UploadDataToListView(string tableName, string condition, DateTime startDateTime, DateTime endDateTime)
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
                    string sqlCmd;
                    if (condition == "")
                        sqlCmd = "SELECT * FROM " + tableName
                        + " WHERE ThoiGian >= '" + startDateTime.ToString() + "' AND ThoiGian <= '" + endDateTime.ToString()
                        + "' ORDER BY ThoiGian " + timeSort;
                    else
                        sqlCmd = "SELECT * FROM " + tableName
                        + " WHERE " + condition + " AND ThoiGian >= '" + startDateTime.ToString() + "' AND ThoiGian <= '" + endDateTime.ToString()
                        + "' ORDER BY ThoiGian " + timeSort;

                    SqlCommand cmd = new SqlCommand(@sqlCmd, sqlCon);
                    SqlDataReader data = cmd.ExecuteReader();
                    //đọc thành công
                    listView1.Items.Clear();
                    while (data.Read())
                    {
                        //cột 1 STT
                        listView1.Items.Add((i + 1).ToString());

                        //lấy ra thời gian từ SQL data[8]
                        DateTime thoigian = (DateTime)data[8];
                        //cột 2 ngày tháng
                        listView1.Items[i].SubItems.Add(thoigian.ToString("dd/MM/yyyy"));
                        //cột 3 thời gian
                        listView1.Items[i].SubItems.Add(thoigian.ToString("hh:mm:ss tt"));

                        //các dữ liệu còn lại data[1]->data[7]
                        for (int k = 1; k <= 7; k++)
                        {
                            if (k == 6)
                                listView1.Items[i].SubItems.Add(data[k].ToString() + "000");
                            else
                                listView1.Items[i].SubItems.Add(data[k].ToString());
                        }

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
            //check condition
            string condition = "";
            if (cbSelectData.Text == "Toàn bộ")
                condition = "";
            else
                condition = "SanPham = N'" + cbSelectData.Text + "'";

            int n = UploadDataToListView("DonHang", condition, startDateTime, endDateTime);
            lbSoluongketqua.Text = n.ToString() + " dữ liệu được tìm thấy";
            if (n == 0)
                MessageBox.Show("Không có dữ liệu được tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cbSelectDateTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            //hiện tùy chọn thời gian
            panelDateTimePicker.Visible = cbSelectDateTime.Text == "Tùy chọn";
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            UploadToListView();
        }

        private void ExportToExcel(string fileName)
        {
            //tạo các đối tượng để tương tác với excel
            _Application app = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = app.Workbooks.Add(Type.Missing);
            _Worksheet worksheet = null;
            worksheet = workbook.Sheets[1];
            worksheet = workbook.ActiveSheet;

            //chỉnh lề toàn bộ ô căn trái
            worksheet.Columns.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;

            worksheet.Cells[1, 1] = "BÁO CÁO LỊCH SỬ ĐƠN HÀNG XĂNG DẦU";
            worksheet.Cells[2, 1] = "Báo cáo từ " + startDateTime.ToString("dd/MM/yyyy hh:mm:ss tt") + " đến " + endDateTime.ToString("dd/MM/yyyy hh:mm:ss tt");
            worksheet.Cells[3, 1] = "Thời gian xuất báo cáo: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            worksheet.get_Range("A1", "I1").Merge();    //Gộp ô
            worksheet.get_Range("A1", "I1").Font.Bold = true;
            worksheet.get_Range("A1", "I1").Font.Size = 15;
            worksheet.get_Range("A1", "I1").Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;     //Căn chỉnh lề
            worksheet.get_Range("A2", "I2").Merge();    //Gộp ô
            worksheet.get_Range("A2", "I2").Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;     //Căn chỉnh lề
            worksheet.get_Range("A3", "I3").Merge();    //Gộp ô
            worksheet.get_Range("A3", "I3").Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;     //Căn chỉnh lề
            worksheet.get_Range("A4", "I4").Merge();    //Gộp ô


            int offset = 5;     //hàng mà bắt đầu ghi dữ liệu của excel
            //hàng 1: STT, thời gian, tên các biến
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                worksheet.Cells[offset, i + 1] = listView1.Columns[i].Text;
            }
            //các hàng còn lại là các dữ liệu
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                for (int j = 0; j < listView1.Columns.Count; j++)
                    worksheet.Cells[i + offset + 1, j + 1] = listView1.Items[i].SubItems[j].Text;
            }

            //chỉnh lại chiều rộng các cột cho vừa
            worksheet.Columns.AutoFit();
            worksheet.get_Range("A1").ColumnWidth = worksheet.get_Range("A1").ColumnWidth * 1.2;
            worksheet.get_Range("B1").ColumnWidth = worksheet.get_Range("B1").ColumnWidth * 1.2;
            worksheet.get_Range("C1").ColumnWidth = worksheet.get_Range("C1").ColumnWidth * 1.2;
            worksheet.get_Range("D1").ColumnWidth = worksheet.get_Range("D1").ColumnWidth * 1.2;
            worksheet.get_Range("E1").ColumnWidth = worksheet.get_Range("E1").ColumnWidth * 1.2;
            worksheet.get_Range("F1").ColumnWidth = worksheet.get_Range("F1").ColumnWidth * 1.2;
            worksheet.get_Range("G1").ColumnWidth = worksheet.get_Range("G1").ColumnWidth * 1.2;
            worksheet.get_Range("H1").ColumnWidth = worksheet.get_Range("H1").ColumnWidth * 1.2;
            worksheet.get_Range("I1").ColumnWidth = worksheet.get_Range("I1").ColumnWidth * 1.2;
            worksheet.get_Range("J1").ColumnWidth = worksheet.get_Range("J1").ColumnWidth * 1.2;

            //save file
            workbook.SaveCopyAs(fileName);
            workbook.Saved = true;
            // Exit from the application  
            app.Quit();
        }

        private void btExportToExcel_Click(object sender, EventArgs e)
        {
            //kiểm tra đã có dữ liệu chưa
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu trong bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    // dùng dialog để ng dùng lựa chọn thư mục lưu
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Title = "Lưu báo cáo";
                    dialog.DefaultExt = "xlsx";
                    dialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        ExportToExcel(dialog.FileName);
                        Cursor = Cursors.Default;
                        MessageBox.Show("Xuất báo cáo thành công! Đường dẫn tới file: " + dialog.FileName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalFunction.InsertEventToSQL("Vận hành", "Tài khoản " + GlobalData.UserName + ": xuất báo cáo từ " + startDateTime.ToString("dd/MM/yyyy hh:mm:ss tt") + " đến " + endDateTime.ToString("dd/MM/yyyy hh:mm:ss tt"));
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi trong quá trình xuất file. Hãy thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
