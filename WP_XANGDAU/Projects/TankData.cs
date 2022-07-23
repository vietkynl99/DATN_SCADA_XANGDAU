using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using S7.Net;
using System.Data.SqlClient;
using System.Data;

namespace XANGDAU
{

    public class TankData
    {
        public struct throat_t
        {
            public string DB_send;
            public string DB_recv;
            public double Start;
            public double Stop;
            public double Enable;
            public double PS;
            public double Setpoint;
            public double Ready;
            public double Running;
            public double Vout;
            public double Ctrlvalue;
            public double Flow;
        }
        //variable
        public string TankName;
        public string DB;
        public double TankHeight;
        public double TankBaseArea;
        public double InitialLevel;
        public double Level;
        public double LevelLow;
        public double LevelVeryLow;
        public double LevelHigh;
        public double LevelVeryHigh;
        public double Temp;
        public double TempLow;
        public double TempVeryLow;
        public double TempHigh;
        public double TempVeryHigh;
        public double VCurr;
        public double Price;
        public double PriceTotal;
        public int LevelStt;            //     0:verylow   1:low   2: normal    3:high    4:veryhigh
        public string LevelSttMessage;
        public int TempStt;             //    0:verylow   1:low   2: normal   3:high    4:veryhigh
        public string TempSttMessage;
        public throat_t throat1, throat2;

        //E5 variable
        public double FlowOutRON92;
        public double FlowOutE100;
        public double BatchValRON92;
        public double BatchValE100;

        public double ReadDataFromPLC(string _DB, string _addr)
        {
            if (!GlobalData.plcConnectd)
                return -1;
            try
            {
                if (_addr[2] == 'X')    //bool var
                    return Convert.ToDouble(GlobalData.plc.Read(_DB + "." + _addr));
                else   //real var
                    return ((uint)GlobalData.plc.Read(_DB + "." + _addr)).ConvertToDouble();

                //GlobalData.CheckData = true;
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
                //GlobalData.plc.Close();
                //GlobalData.plcConnectd = false;
                return -1;
            }
        }

        //function
        public TankData(string _tank_name, string DB_name, string DB_name_throat1_send, string DB_name_throat1_recv, string DB_name_throat2_send, string DB_name_throat2_recv)
        {
            TankName = _tank_name;
            DB = DB_name;
            throat1.DB_send = DB_name_throat1_send;
            throat1.DB_recv = DB_name_throat1_recv;
            throat2.DB_send = DB_name_throat2_send;
            throat2.DB_recv = DB_name_throat2_recv;
        }

        public void ReadData()
        {
            Temp = ReadDataFromPLC(DB, "DBD0");
            Level = ReadDataFromPLC(DB, "DBD4");
            InitialLevel = ReadDataFromPLC(DB, "DBD8");
            TankBaseArea = ReadDataFromPLC(DB, "DBD12");
            VCurr = ReadDataFromPLC(DB, "DBD16");
            throat1.Flow = ReadDataFromPLC(DB, "DBD24");
            throat2.Flow = ReadDataFromPLC(DB, "DBD28");
            throat1.Enable = ReadDataFromPLC(throat1.DB_send, "DBX0.2");
            throat2.Enable = ReadDataFromPLC(throat2.DB_send, "DBX0.2");
            throat1.Ready = ReadDataFromPLC(throat1.DB_recv, "DBX0.0");
            throat1.Running = ReadDataFromPLC(throat1.DB_recv, "DBX0.1");
            throat1.Vout = ReadDataFromPLC(throat1.DB_recv, "DBD4");
            throat1.Ctrlvalue = ReadDataFromPLC(throat1.DB_recv, "DBD8");
            throat2.Ready = ReadDataFromPLC(throat2.DB_recv, "DBX0.0");
            throat2.Running = ReadDataFromPLC(throat2.DB_recv, "DBX0.1");
            throat2.Vout = ReadDataFromPLC(throat2.DB_recv, "DBD4");
            throat2.Ctrlvalue = ReadDataFromPLC(throat2.DB_recv, "DBD8");
            ReadDataFromSQL();
            ProcessData();
        }
        private void ReadDataFromSQL()
        {
            SqlDataReader data = GlobalFunction.ReadDataFromSQL("*", "ThongSoTank", "WHERE Tank = N'" + TankName + "'");
            if (data != null)
            {
                TempHigh = Convert.ToDouble(data[2]);
                TempVeryHigh = Convert.ToDouble(data[3]);
                TempLow = 0;
                TempVeryLow = 0;
                LevelHigh = Convert.ToDouble(data[4]);
                LevelVeryHigh = Convert.ToDouble(data[5]);
                LevelLow = Convert.ToDouble(data[6]);
                LevelVeryLow = Convert.ToDouble(data[7]);
                TankHeight = Convert.ToDouble(data[8]);
                TankBaseArea = Convert.ToDouble(data[9]);
            }
            else
            {
                //create exception
                throw new Exception("Lỗi đọc dữ liệu từ SQL: Table: ThongSoTank, Tank: " + TankName);
            }
        }
        private void ProcessData()
        {
            double[] levelScale = { LevelVeryLow, LevelLow, LevelHigh, LevelVeryHigh };
            double[] tempScale = { TempVeryLow, TempLow, TempHigh, TempVeryHigh };
            string[] StrScale = { "rất thấp", "thấp", "bình thường", "cao", "rất cao" };
            for (int i = 0; i < 4; i++)
            {
                if (Level < levelScale[i])
                {
                    LevelStt = i;
                    LevelSttMessage = StrScale[i];
                    break;
                }
                LevelStt = 4;
                LevelSttMessage = StrScale[4];
            }
            for (int i = 0; i < 4; i++)
            {
                if (Temp < tempScale[i])
                {
                    TempStt = i;
                    TempSttMessage = StrScale[i];
                    break;
                }
                TempStt = 4;
                TempSttMessage = StrScale[4];
            }
            //luu lai canh bao hoac loi trong SQL
            switch (LevelStt)
            {
                case 1:
                case 3:
                    GlobalFunction.InsertEventToSQL("Cảnh báo", "Mức bể " + TankName + " đang ở mức " + LevelSttMessage + " (" + Level.ToString() + "m)");
                    break;
                case 0:
                case 4:
                    GlobalFunction.InsertEventToSQL("Lỗi", "Mức bể " + TankName + " đang ở mức " + LevelSttMessage + " (" + Level.ToString() + "m)");
                    break;
            }
            switch (TempStt)
            {
                case 1:
                case 3:
                    GlobalFunction.InsertEventToSQL("Cảnh báo", "Nhiệt độ bể " + TankName + " đang ở mức " + TempSttMessage + " (" + Temp.ToString() + "°C)");
                    break;
                case 0:
                case 4:
                    GlobalFunction.InsertEventToSQL("Lỗi", "Nhiệt độ bể " + TankName + " đang ở mức " + TempSttMessage + " (" + Temp.ToString() + "°C)");
                    break;
            }
        }

        public void ReadDataE5()
        {
            //if (GlobalData.plcConnectd)
            //{
            //    try
            //    {
            //        FlowOutRON92 = ((uint)GlobalData.plc.Read(DB + ".DBD0")).ConvertToDouble();
            //        FlowOutE100 = ((uint)GlobalData.plc.Read(DB + ".DBD4")).ConvertToDouble();
            //        VCurr = ((uint)GlobalData.plc.Read(DB + ".DBD8")).ConvertToDouble();
            //        BatchValRON92 = ((uint)GlobalData.plc.Read(DB + ".DBD16")).ConvertToDouble();
            //        BatchValE100 = ((uint)GlobalData.plc.Read(DB + ".DBD20")).ConvertToDouble();
            //        Price = ((uint)GlobalData.plc.Read(DB + ".DBD30")).ConvertToDouble();

            //        GlobalData.CheckData = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        //hiển thị thông báo trong lần đầu bị lỗi
            //        if (GlobalData.CheckData)
            //        {
            //            GlobalData.CheckData = false;
            //            MessageBox.Show("Lỗi đọc dữ liệu từ PLC: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //        GlobalData.CheckData = false;
            //    }
            //}

        }

        public void ProcessDataE5()
        {
            //    if (GlobalData.RON92.LevelStt == 0)
            //    {
            //        LevelStt = GlobalData.E100.LevelStt;
            //        LevelSttMessage = GlobalData.E100.LevelSttMessage;
            //    }
            //    else if (GlobalData.E100.LevelStt == 0)
            //    {
            //        LevelStt = GlobalData.RON92.LevelStt;
            //        LevelSttMessage = GlobalData.RON92.LevelSttMessage;
            //    }
            //    else
            //    {
            //        LevelStt = 2;
            //        LevelSttMessage = "RON92 " + GlobalData.RON92.LevelSttMessage + ", E100 " + GlobalData.E100.LevelSttMessage;
            //    }


            //    if (GlobalData.RON92.TempStt == 0)
            //    {
            //        TempStt = GlobalData.E100.TempStt;
            //        TempSttMessage = GlobalData.E100.TempSttMessage;
            //    }
            //    else if (GlobalData.E100.TempStt == 0)
            //    {
            //        TempStt = GlobalData.RON92.TempStt;
            //        TempSttMessage = GlobalData.RON92.TempSttMessage;
            //    }
            //    else
            //    {
            //        TempStt = 2;
            //        TempSttMessage = "RON92 " + GlobalData.RON92.TempSttMessage + ", E100 " + GlobalData.E100.TempSttMessage;
            //    }
        }


    }
}
