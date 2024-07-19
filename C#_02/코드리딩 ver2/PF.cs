using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chsj
{
    class PF
    {
        public static void IOReset()
        {
            IOOutPutMessage("0", "0");
            IOOutPutMessage("1", "0");
            IOOutPutMessage("2", "0");
            IOOutPutMessage("3", "0");
            IOOutPutMessage("4", "0");
            IOOutPutMessage("5", "0");
            IOOutPutMessage("6", "0");
            IOOutPutMessage("7", "0");
            IOOutPutMessage("8", "0");
            IOOutPutMessage("9", "0");
            IOOutPutMessage("10", "0");
            IOOutPutMessage("11", "0");
            IOOutPutMessage("12", "0");
            IOOutPutMessage("13", "0");
            IOOutPutMessage("14", "0");
            IOOutPutMessage("15", "0");
            IOOutPutMessage("16", "0");
           
        }
        public static void LoadData_LOT(string fileName)

        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[0]);


                        PV.sLOT = stringArray[0].ToString();
                        


                    }
                }
            }
        }
        public static void LoadData_Type(string fileName)

        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[0]);

                        
                        PV.strs_SType = stringArray[0].ToString();

                        
                    }
                }
            }
        }

        
        public static void LoadData_Worker(string fileName)

        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[0]);

                        
                        PV.strs_SWorker = stringArray[0].ToString();

                        
                    }
                }
            }
        }
        public static void LoadData_Order(string fileName)

        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[0]);

                        PV.strs_Order = new string[6];
                        PV.strs_Order[1] = stringArray[0].ToString();
                        PV.strs_Order[2] = stringArray[1].ToString();
                        PV.strs_Order[3] = stringArray[2].ToString();
                        PV.strs_Order[4] = stringArray[3].ToString();
                        PV.strs_Order[5] = stringArray[4].ToString();

                        
                    }
                }
            }
        }
        public static void SaveData_SelectedWorker(string fileName, string UserName)

        {  // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))
            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(UserName);
            }
        }
  
        public static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

        #region 로그
        public static void ScanLogWriter(string CodeV, string Weight, string CodeP, string CodeS, string CodeE, string CodeT, string CodeC, string PnP, string Barcode, string Message)
        {
            try
            {
                string strMonth = DateTime.Now.Month.ToString();
                string strDay = DateTime.Now.Day.ToString();
                string strHour = DateTime.Now.Hour.ToString();
                string strMinute = DateTime.Now.Minute.ToString();
                string strSecond = DateTime.Now.Second.ToString();
                string strMilSecond = DateTime.Now.Millisecond.ToString();

                if (strMonth.Length == 1)
                    strMonth = "0" + strMonth;

                if (strDay.Length == 1)
                    strDay = "0" + strDay;

                string Time = DateTime.Now.Year + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMinute + ":" + strSecond + "-" + strMilSecond;

                string Path = PV.CsvScanLogFile + PV.FileNameCsv + "\\";
                string CreateFileName = PV.FileNameCsv + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("\r\n" + Time);
                    row.Add(CodeV);
                    row.Add(Weight);
                    row.Add(CodeP);
                    row.Add(CodeS);
                    row.Add(CodeE);
                    row.Add(CodeT);
                    row.Add(CodeC);
                    row.Add(PnP);
                    row.Add(Barcode);
                    row.Add(Message);
                }
                else
                {
                    row.Add(Time);
                    row.Add(CodeV);
                    row.Add(Weight);
                    row.Add(CodeP);
                    row.Add(CodeS);
                    row.Add(CodeE);
                    row.Add(CodeT);
                    row.Add(CodeC);
                    row.Add(PnP);
                    row.Add(Barcode);
                    row.Add(Message);
                }

                writer.WriteCSV(row, Path + CreateFileName);


            }
            catch (Exception ex)
            {
                PF.LogWriter("ScanLogWriter", ex.Message);
            }
        }

        public static void LogWriter(string LogLocation, string LogMessage)
        {
            try
            {
                string strMonth = DateTime.Now.Month.ToString();
                string strDay = DateTime.Now.Day.ToString();
                string strHour = DateTime.Now.Hour.ToString();
                string strMinute = DateTime.Now.Minute.ToString();
                string strSecond = DateTime.Now.Second.ToString();
                string strMilSecond = DateTime.Now.Millisecond.ToString();

                if (strMonth.Length == 1)
                    strMonth = "0" + strMonth;

                if (strDay.Length == 1)
                    strDay = "0" + strDay;

                string Time = DateTime.Now.Year + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMinute + ":" + strSecond + "-" + strMilSecond;

                string Path = PV.CsvLogFile + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("Time");
                    row.Add("LogLocation");
                    row.Add("Message");

                    row.Add("\r\n" + Time);
                    row.Add(LogLocation);
                    row.Add(LogMessage);
                }
                else
                {
                    row.Add(Time);
                    row.Add(LogLocation);
                    row.Add(LogMessage);
                }

                writer.WriteCSV(row, Path + CreateFileName);



            }
            catch (Exception ex)
            {
                LogWriter("LogWriter", ex.Message);
            }
        }
        #endregion

        #region "IO 출력"

        public static void DioInit()
        {
            // Initialization handling
            int Ret;
            Ret = PV.dio.Init("DIO000", out PV.m_Id);

            string ErrorString;
            PV.dio.GetErrorString(Ret, out ErrorString);
            if (Ret != (int)CdioConst.DIO_ERR_SUCCESS)
            {
                return;
            }
        }


        public static string IOCheck(string Bit)
        {
            int Ret;
            short InpBitNo;
            byte InputData;
            //-----------------------------
            // Get port No. from screen
            //-----------------------------
            try
            {
                InpBitNo = System.Convert.ToInt16(Bit);
            }
            catch
            {
                InpBitNo = 0;
            }

            Ret = PV.dio.InpBit(PV.m_Id, InpBitNo, out InputData);


            return InputData.ToString();
        }

        public static void IOOutPutMessage(string LogicBitNo, string OutPutData)
        {

            int Ret;
            short OutBitNo;
            byte OutBitData;
            //-----------------------------
            // Get bit No. and output data from screen
            //-----------------------------
            try
            {
                OutBitNo = System.Convert.ToInt16(LogicBitNo);
                OutBitData = System.Convert.ToByte(OutPutData, 16);
            }
            catch
            {
                OutBitNo = 0;
                OutBitData = 0;
            }
            //-----------------------------
            // Port input
            //-----------------------------
            Ret = PV.dio.OutBit(PV.m_Id, OutBitNo, OutBitData);

            //-----------------------------
            // Error process
            //-----------------------------
            string ErrorString;
            PV.dio.GetErrorString(Ret, out ErrorString);

            //MessageBox.Show(ErrorString);

            if (Ret != (int)CdioConst.DIO_ERR_SUCCESS)
            {
                return;
            }


        }
        public static void ProcessKill(string processName)
        {
            Process[] process = Process.GetProcessesByName(processName);

            Process CurrentProcess = Process.GetCurrentProcess();

            foreach (Process p in process)
            {
                if (p.ProcessName == CurrentProcess.ProcessName)
                    p.Kill();
            }
        }

        #endregion


    }
}
