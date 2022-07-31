using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace XANGDAU
{
    public static class GlobalFunction
    {
        public static SqlConnection sqlCon = null;

        //1 số hàm truy vấn tới SQL cần dùng ở nhiều form
        //câu lệnh truy vấn tới SQL
        public static int SQLCommand(string sqlCmd)
        {
            int result = -1;
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
                    SqlCommand cmd = new SqlCommand(@sqlCmd, sqlCon);
                    //đọc data
                    result = cmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                if (result < 0)
                    result = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối với SQL Server: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return result;
        }
        //đọc data từ SQL
        public static SqlDataReader ReadDataFromSQL(string dataname, string tablename, string option = "")
        {
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
                    string sqlCmd = "Select " + dataname + " FROM " + tablename + " " + option;
                    SqlCommand cmd = new SqlCommand(@sqlCmd, sqlCon);
                    //đọc data
                    SqlDataReader data = cmd.ExecuteReader();
                    if (data.Read())
                        return data;
                    sqlCon.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối với SQL Server: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return null;
        }


        public static int ReadLastIDSQL(string tablename)
        {
            SqlDataReader data = ReadDataFromSQL("Id", tablename, "ORDER BY Id DESC");
            return (int)data[0];
        }

        //chèn thêm dữ liệu vào bảng
        public static int InsertDataToSQL(string tablename, string data)
        {
            return SQLCommand("INSERT INTO " + tablename + " VALUES ( " + data + " )");
        }

        //chèn thêm vào bảng event
        public static void InsertEventToSQL(string strType, string strEvent)
        {
            int _id = ReadLastIDSQL("LichsuHD") + 1;
            InsertDataToSQL("LichsuHD", _id.ToString() + " ,  N'" + strType + "' , N'" + strEvent + "' ," + " GETDATE() ");
        }

        //update dữ liệu vào bảng
        public static int UpdateDataToSQL(string tablename, string data)
        {
            return SQLCommand("UPDATE " + tablename + " SET " + data);
        }

    }
}
