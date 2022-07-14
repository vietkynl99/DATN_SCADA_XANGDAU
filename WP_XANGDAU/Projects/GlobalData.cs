using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;
using System.IO;
using System.IO.Ports;

namespace XANGDAU
{
    //các biến toàn cục
    class GlobalData
    {

        static public TankData Diezel = new TankData("DB3");
        static public TankData RON95 = new TankData("DB4");
        static public TankData RON92 = new TankData("DB5");
        static public TankData E100 = new TankData("DB6");
        static public TankData E5 = new TankData("DB7");
        static public int TankIndex = 0;    //diezel

        //biến để kiểm soát form được mở
        static public DangnhapForm FrmDangnhap = null;
        static public DoimatkhauForm FrmDoimatkhau = null;
        static public MainForm FrmMain = null;
        static public TrangchuForm FrmTrangchu = null;
        static public LichsuForm FrmLichsu = null;
        static public SukienForm FrmSukien = null;
        static public CaidatForm FrmCaidat = null;
        static public PopUpMenuForm FrmPopupmenu = null;

        //biến kết nối với plc
        static public Plc plc;
        static public bool plcConnectd = false;
        static public string plcIP = "";

        //kết nối với SQL server và thông tin tài khoản
        static public string databaseName = "DATABASE_XANGDAU";
        static public string connectionString = @"Data Source=ANONYMOUS\SQLEXPRESS;Initial Catalog=DATABASE_XANGDAU;Integrated Security=True";
        //static public string connectionString = @"Data Source=HVN_VIETDH\SQLEXPRESS;Initial Catalog=DATABASE_XANGDAU;Integrated Security=True";
        static public string UserID = "1";
        static public string UserEmail = "abc@gmail.com";
        static public string UserMobile = "0123456789";
        static public string UserName = "vietkynl99";             // tên đăng nhập
        static public string Password = "123456";             // mật khẩu
        static public string FullName = "Đỗ Hoàng Việt";             // tên người sử dụng
        static public string UserLevel = "ADMIN";            // phân quyền quản trị

        //trạng thái hệ thống
        static public bool CheckData = false;           //dùng để kiểm tra kết nối, nếu quá 3 lần thời gian đơn vị mà ko nhận được dữ liệu thì sẽ coi là lỗi (false)
        static public bool SystemEnable = false;        // cho phép chạy
        static public bool SystemRunning = false;       // trạng thái thực tế (chỉ ON khi SystemEnable=true & đã kết nối với plc & checkdata=true)
    }
}
