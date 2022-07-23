using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Web_XANGDAU
{
    public class GlobalFunction
    {
        string chuoiketnoi = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;

        //Thông số cài đặt Tank
        public double LevelHH;
        public double LevelH;
        public double LevelL;
        public double LevelLL;

        public double TempHH;
        public double TempH;

        public double Height;
        public double BaseArea;

        //Thông tin đơn hàng
        public bool checkDonHang;
        public string MaDonHang;
        public string SanPham;
        public string HongXuat;
        public string TheTichYeuCau;
        public string DonGia;
        public string ThanhTien;
        public string TrangThaiDon;

        //Biến kiểm tra trạng thái họng xuất
        public bool checkHongXuat;


        //Load thông số cài đặt tank
        public void LoadTank(string tank)
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            if (ketnoi.State != ConnectionState.Open)
                ketnoi.Open();

            sql = @"Select *From ThongSoTank Where Tank = N'"+tank+"'";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if (docdulieu.Read())
            {
                LevelHH = double.Parse(docdulieu["MucQuaCao"].ToString());
                LevelH = double.Parse(docdulieu["MucCao"].ToString());
                LevelL = double.Parse(docdulieu["MucThap"].ToString());
                LevelLL = double.Parse(docdulieu["MucQuaThap"].ToString());

                TempHH = double.Parse(docdulieu["NhietQuaCao"].ToString());
                TempH = double.Parse(docdulieu["NhietCao"].ToString());

                Height = double.Parse(docdulieu["ChieuCao"].ToString());
                BaseArea = double.Parse(docdulieu["DienTichDay"].ToString());
            }

            ketnoi.Close();
        }

        //Load thông tin đơn hàng với mã đơn tương ứng
        public void LoadThongTinDon(string MaDon)
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            if (ketnoi.State != ConnectionState.Open)
                ketnoi.Open();

            sql = @"Select *from DonHang Where MaDon = N'"+MaDon+"'";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            if (docdulieu.Read())
            {
                checkDonHang = true;

                MaDonHang = docdulieu["MaDon"].ToString();
                SanPham = docdulieu["SanPham"].ToString();
                HongXuat = docdulieu["HongXuat"].ToString();
                TheTichYeuCau = docdulieu["TheTich"].ToString();
                DonGia = docdulieu["DonGia"].ToString();
                ThanhTien = docdulieu["ThanhTien"].ToString();
                TrangThaiDon = docdulieu["TrangThai"].ToString();
            }
            else checkDonHang = false;

            ketnoi.Close();
        }

        //Kiểm tra họng xuất có đang bận không
        public void KiemTraHongXuat(string Hong)
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            if (ketnoi.State != ConnectionState.Open)
                ketnoi.Open();

            SqlCommand CommandText = new SqlCommand(@"Select HongXuat = N'" + Hong + "' From DonHang Where TrangThai = N'Đang thực hiện'", ketnoi);
            SqlDataReader ReadData = CommandText.ExecuteReader();

            if (ReadData.Read())
            {
                checkHongXuat = true;       //Họng xuất bận
            }
            else checkHongXuat = false;     //Họng xuất không bận

            ketnoi.Close();
        }

        //Cập nhật trạng thái đơn hàng
        public void UpdateTrangThaiDon(string TrangThai, string MaDon)
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            if (ketnoi.State != ConnectionState.Open)
                ketnoi.Open();

            sql = @"Update DonHang Set TrangThai = N'"+TrangThai+"' Where MaDon = '" + MaDon + "'";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();

            ketnoi.Close();
        }
    }
}