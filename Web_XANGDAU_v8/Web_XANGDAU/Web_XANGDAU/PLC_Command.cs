using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using S7.Net;
using S7.Net.Types;

namespace Web_XANGDAU
{
    public class PLC_Command
    {
        //Biến tank Diezel, RON92, RON95, E100
        public double TankHeight;                       //Chiều cao bể
        public double TankBaseArea;                     //Diện tích đáy bể
        public double TankInitialLevel;                 //
        public double LevelPER;                         //
        public double Level;                            //
        public double LevelMin;                         //Mức thấp nhất
        public double LevelMax;                         //Mức cao nhất
        public double Temp;                             //Nhiệt độ bể
        public double TempMin;                          //Nhiệt độ thấp nhất
        public double TempMax;                          //Nhiệt độ cao nhất
        public double FlowInPER;                        //Lưu lượng nhập theo %
        public double FlowIn;                           //Lưu lượng nhập
        public double FlowInMax;                        //Lưu lượng nhập lớn nhất
        public double FlowOutPER;                       //Lưu lượng xuất theo %
        public double FlowOut;                          //Lưu lượng xuất
        public double FlowOutMax;                       //Lưu lượng xuất lớn nhất
        public double VCurr;                            //Thể tích hiện tại
        public double Vout;                             //Thể tích đã xuất
        public double BatchControlVal;                  //Độ mở van xuất
        public double SetpointOut;                      //Thể tích cần xuất
        public bool Enable;                             //Xuất liệu
        public bool BatchReady;                         //Sẵn sàng xuất liệu
        public bool BatchRunning;                       //Đang xuất liệu
        public double Price;                            //Đơn giá
        public double PriceTotal;                       //Tổng tiền
        public int LevelStt;            //0: normal     1:low      2:high
        public string LevelSttMessage;
        public int TempStt;             //0: normal     1:low      2:high
        public string TempSttMessage;

        //Biến tank E5
        public double FlowOutRON92;                     //Lưu lượng xuất RON92
        public double FlowOutE100;                      //Lưu lượng xuất E100
        public double BatchValRON92;                    //Độ mở van xuất RON92
        public double BatchValE100;                     //Dộ mở van xuất E100               

        //Đơn vị của dữ liệu
        public string unitOpenValve = " (%)";       //Độ mở van
        public string unitFlow = " (m3/h)";         //Lưu lượng
        public string unitLevel = " (m)";           //Mức
        public string unitTemp = " (°C)";           //Nhiệt độ

        //Hàm đọc dữ liệu Diezel, RON92, RON95, E100
        public void ReadData(Plc plc,string DB)
        {
            TankHeight = ((uint)plc.Read(DB + ".DBD0")).ConvertToDouble();
            TankBaseArea = ((uint)plc.Read(DB + ".DBD4")).ConvertToDouble();
            Level = ((uint)plc.Read(DB + ".DBD16")).ConvertToDouble();
            LevelMin = ((uint)plc.Read(DB + ".DBD20")).ConvertToDouble();
            LevelMax = ((uint)plc.Read(DB + ".DBD24")).ConvertToDouble();
            Temp = ((uint)plc.Read(DB + ".DBD28")).ConvertToDouble();
            TempMin = ((uint)plc.Read(DB + ".DBD32")).ConvertToDouble();
            TempMax = ((uint)plc.Read(DB + ".DBD36")).ConvertToDouble();
            FlowIn = ((uint)plc.Read(DB + ".DBD44")).ConvertToDouble();
            FlowOut = ((uint)plc.Read(DB + ".DBD56")).ConvertToDouble();
            VCurr = ((uint)plc.Read(DB + ".DBD64")).ConvertToDouble();
            Vout = ((uint)plc.Read(DB + ".DBD68")).ConvertToDouble();
            BatchControlVal = ((uint)plc.Read(DB + ".DBD72")).ConvertToDouble();
            SetpointOut = ((uint)plc.Read(DB + ".DBD76")).ConvertToDouble();
            Enable = (bool)plc.Read(DB + ".DBX80.2");
            BatchReady = (bool)plc.Read(DB + ".DBX80.3");
            BatchRunning = (bool)plc.Read(DB + ".DBX80.4");
            Price = ((uint)plc.Read(DB + ".DBD82")).ConvertToDouble();
        }

        //Hàm đọc dữ liệu E5
        public void ReadDataE5(Plc plc)
        {
            FlowOutRON92 = ((uint)plc.Read("DB7.DBD0")).ConvertToDouble();
            FlowOutE100 = ((uint)plc.Read("DB7.DBD4")).ConvertToDouble();
            VCurr = ((uint)plc.Read("DB7.DBD8")).ConvertToDouble();
            Vout = ((uint)plc.Read("DB7.DBD12")).ConvertToDouble();
            BatchValRON92 = ((uint)plc.Read("DB7.DBD16")).ConvertToDouble();
            BatchValE100 = ((uint)plc.Read("DB7.DBD20")).ConvertToDouble();
            SetpointOut = ((uint)plc.Read("DB7.DBD24")).ConvertToDouble();
            Enable = (bool)plc.Read("DB7.DBX28.2");
            BatchReady = (bool)plc.Read("DB7.DBX28.3");
            BatchRunning = (bool)plc.Read("DB7.DBX28.4");
            Price = ((uint)plc.Read("DB7.DBD30")).ConvertToDouble();
        }
    }
}