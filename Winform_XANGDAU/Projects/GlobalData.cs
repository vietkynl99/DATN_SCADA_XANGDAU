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

        //biến để kiểm soát form được mở
        static public DangnhapForm FrmDangnhap = null;
        static public DoimatkhauForm FrmDoimatkhau = null;
        static public MainForm FrmMain = null;
        static public TrangchuForm FrmTrangchu = null;
        static public LichsuForm FrmLichsu = null;
        static public SukienForm FrmSukien = null;
        static public PopUpMenuForm FrmPopupmenu = null;

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
    }
}
