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
    public partial class HongXuat7 : System.Web.UI.Page
    {
        

        PLC_Command PLC_Com = new PLC_Command();
        Plc plc = new Plc(CpuType.S71500, "192.168.0.3", 0, 0);

        protected void Page_Load(object sender, EventArgs e)
        {
            
            

            //Mở kết nối với PLC
            if (plc.Open() == ErrorCode.NoError)
            {
                lbl_KetNoi.Text = "Đã kết nối";
                lbl_KetNoi.ForeColor = System.Drawing.Color.Black;

                PLC_Com.ReadData(plc, "DB7");
            }
        }

        protected void Timer_Hong7_Tick(object sender, EventArgs e)
        {
            txt_MucE100.Text = PLC_Com.Level.ToString() + PLC_Com.unitLevel;
            txt_NhietDoE100.Text = PLC_Com.Temp.ToString() + PLC_Com.unitTemp;
            txt_VanXuatE100.Text = PLC_Com.BatchControlVal.ToString() + PLC_Com.unitOpenValve;
            txt_LuuLuongXuatE100.Text = PLC_Com.FlowOut.ToString() + PLC_Com.unitFlow;

            txt_MucRON92.Text = PLC_Com.Level.ToString() + PLC_Com.unitLevel;
            txt_NhietDoRON92.Text = PLC_Com.Temp.ToString() + PLC_Com.unitTemp;
            txt_VanXuatRON92.Text = PLC_Com.BatchControlVal.ToString() + PLC_Com.unitOpenValve;
            txt_LuuLuongXuatRON92.Text = PLC_Com.FlowOut.ToString() + PLC_Com.unitFlow;

            

            txt_TheTichDaXuat.Text = PLC_Com.Vout.ToString();

            pn_MucPer.Attributes["style"] = "width:" + PLC_Com.LevelPER + "";
            lbl_MucPer.Text = PLC_Com.LevelPER.ToString() + "%";
        }

        

    }
}