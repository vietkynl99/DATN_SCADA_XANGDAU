using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using S7.Net;   //Thư viện kết nối với PLC
using S7.Net.Types;
using Web_XANGDAU;  //Thư mục chứa PLC_Command

namespace Web_XANGDAU.WebForms
{
    public partial class HongXuat8 : System.Web.UI.Page
    {
        PLC_Command PLC_Com = new PLC_Command();
        Plc plc = new Plc(CpuType.S71500, "192.168.0.3", 0, 0);

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //protected void Timer_Diezel_Tick(object sender, EventArgs e)
        //{
        //    txt_VanNhapDiezel.Text = PLC_Com.BatchControlVal.ToString() + PLC_Com.unitOpenValve;
        //    txt_LuuLuongNhapDiezel.Text = PLC_Com.FlowIn.ToString() + PLC_Com.unitFlow;
        //    txt_MucDiezel.Text = PLC_Com.Level.ToString() + PLC_Com.unitLevel;
        //    txt_NhietDoDiezel.Text = PLC_Com.TempMax.ToString() + PLC_Com.unitTemp;
        //    txt_VanXuatDiezel.Text = PLC_Com.BatchControlVal.ToString() + PLC_Com.unitOpenValve;
        //    txt_LuuLuongXuatDiezel.Text = PLC_Com.FlowOut.ToString() + PLC_Com.unitFlow;

        //    StatusSymbolDiezel();

        //}

        
    }
}