﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using S7.Net;

namespace XANGDAU
{
    public class TankData
    {
        //variable
        public string DB;
        public double TankHeight;
        public double TankBaseArea;
        public double TankInitialLevel;
        public double LevelPER;
        public double Level;
        public double LevelMin;
        public double LevelMax;
        public double Temp;
        public double TempMin;
        public double TempMax;
        public double FlowInPER;
        public double FlowIn;
        public double FlowInMax;
        public double FlowOutPER;
        public double FlowOut;
        public double FlowOutMax;
        public double VCurr;
        public double Vout;
        public double BatchControlVal;
        public double SetpointOut;
        public bool Enable;
        public bool BatchReady;
        public bool BatchRunning;
        public double Price;
        public double PriceTotal;
        public int LevelStt;            //0: normal     1:low      2:high
        public string LevelSttMessage;
        public int TempStt;             //0: normal     1:low      2:high
        public string TempSttMessage;

        //E5 variable
        public double FlowOutRON92;
        public double FlowOutE100;
        public double BatchValRON92;
        public double BatchValE100;


        //function
        public TankData(string DB_name)
        {
            DB = DB_name;
        }

        public void ReadData()
        {
            if (GlobalData.plcConnectd)
            {
                try
                {
                    TankHeight = ((uint)GlobalData.plc.Read(DB + ".DBD0")).ConvertToDouble();
                    TankBaseArea = ((uint)GlobalData.plc.Read(DB + ".DBD4")).ConvertToDouble();
                    Level = ((uint)GlobalData.plc.Read(DB + ".DBD16")).ConvertToDouble();
                    LevelMin = ((uint)GlobalData.plc.Read(DB + ".DBD20")).ConvertToDouble();
                    LevelMax = ((uint)GlobalData.plc.Read(DB + ".DBD24")).ConvertToDouble();
                    Temp = ((uint)GlobalData.plc.Read(DB + ".DBD28")).ConvertToDouble();
                    TempMin = ((uint)GlobalData.plc.Read(DB + ".DBD32")).ConvertToDouble();
                    TempMax = ((uint)GlobalData.plc.Read(DB + ".DBD36")).ConvertToDouble();
                    FlowIn = ((uint)GlobalData.plc.Read(DB + ".DBD44")).ConvertToDouble();
                    FlowOut = ((uint)GlobalData.plc.Read(DB + ".DBD56")).ConvertToDouble();
                    VCurr = ((uint)GlobalData.plc.Read(DB + ".DBD64")).ConvertToDouble();
                    Vout = ((uint)GlobalData.plc.Read(DB + ".DBD68")).ConvertToDouble();
                    BatchControlVal = ((uint)GlobalData.plc.Read(DB + ".DBD72")).ConvertToDouble();
                    SetpointOut = ((uint)GlobalData.plc.Read(DB + ".DBD76")).ConvertToDouble();
                    Enable = (bool)GlobalData.plc.Read(DB + ".DBX80.2");
                    BatchReady = (bool)GlobalData.plc.Read(DB + ".DBX80.3");
                    BatchRunning = (bool)GlobalData.plc.Read(DB + ".DBX80.4");
                    Price = ((uint)GlobalData.plc.Read(DB + ".DBD82")).ConvertToDouble();

                    GlobalData.CheckData = true;
                }
                catch(Exception ex)
                {
                    //hiển thị thông báo trong lần đầu bị lỗi
                    if (GlobalData.CheckData)
                    {
                        GlobalData.CheckData = false;
                        MessageBox.Show("Lỗi đọc dữ liệu từ PLC: " +ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    GlobalData.CheckData = false;
                }
            }
            
        }

        public void ProcessData()
        {
            PriceTotal = Price * SetpointOut;
            //level
            if (Level < LevelMin)
            {
                LevelStt = 1;
                LevelSttMessage = "thấp";
            }
            else if (Level > LevelMax)
            {
                LevelStt = 2;
                LevelSttMessage = "cao";
            }
            else
            {
                LevelStt = 0;
                LevelSttMessage = "bình thường";
            }
            //temp
            if (Temp < TempMin)
            {
                TempStt = 1;
                TempSttMessage = "thấp";
            }
            else if (Temp > TempMax)
            {
                TempStt = 2;
                TempSttMessage = "cao";
            }
            else
            {
                TempStt = 0;
                TempSttMessage = "bình thường";
            }
        }

        public void ReadDataE5()
        {
            if (GlobalData.plcConnectd)
            {
                try
                {
                    FlowOutRON92 = ((uint)GlobalData.plc.Read(DB + ".DBD0")).ConvertToDouble();
                    FlowOutE100 = ((uint)GlobalData.plc.Read(DB + ".DBD4")).ConvertToDouble();
                    VCurr = ((uint)GlobalData.plc.Read(DB + ".DBD8")).ConvertToDouble();
                    Vout = ((uint)GlobalData.plc.Read(DB + ".DBD12")).ConvertToDouble();
                    BatchValRON92 = ((uint)GlobalData.plc.Read(DB + ".DBD16")).ConvertToDouble();
                    BatchValE100 = ((uint)GlobalData.plc.Read(DB + ".DBD20")).ConvertToDouble();
                    SetpointOut = ((uint)GlobalData.plc.Read(DB + ".DBD24")).ConvertToDouble();
                    Enable = (bool)GlobalData.plc.Read(DB + ".DBX28.2");
                    BatchReady = (bool)GlobalData.plc.Read(DB + ".DBX28.3");
                    BatchRunning = (bool)GlobalData.plc.Read(DB + ".DBX28.4");
                    Price = ((uint)GlobalData.plc.Read(DB + ".DBD30")).ConvertToDouble();

                    GlobalData.CheckData = true;
                }
                catch (Exception ex)
                {
                    //hiển thị thông báo trong lần đầu bị lỗi
                    if (GlobalData.CheckData)
                    {
                        GlobalData.CheckData = false;
                        MessageBox.Show("Lỗi đọc dữ liệu từ PLC: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    GlobalData.CheckData = false;
                }
            }

        }

        public void ProcessDataE5()
        {
            if (GlobalData.RON92.LevelStt == 0)
            {
                LevelStt = GlobalData.E100.LevelStt;
                LevelSttMessage = GlobalData.E100.LevelSttMessage;
            }
            else if (GlobalData.E100.LevelStt == 0)
            {
                LevelStt = GlobalData.RON92.LevelStt;
                LevelSttMessage = GlobalData.RON92.LevelSttMessage;
            }
            else
            {
                LevelStt = 2;
                LevelSttMessage = "RON92 " + GlobalData.RON92.LevelSttMessage + ", E100 " + GlobalData.E100.LevelSttMessage;
            }


            if (GlobalData.RON92.TempStt == 0)
            {
                TempStt = GlobalData.E100.TempStt;
                TempSttMessage = GlobalData.E100.TempSttMessage;
            }
            else if (GlobalData.E100.TempStt == 0)
            {
                TempStt = GlobalData.RON92.TempStt;
                TempSttMessage = GlobalData.RON92.TempSttMessage;
            }
            else
            {
                TempStt = 2;
                TempSttMessage = "RON92 " + GlobalData.RON92.TempSttMessage + ", E100 " + GlobalData.E100.TempSttMessage;
            }
        }
    }
}
