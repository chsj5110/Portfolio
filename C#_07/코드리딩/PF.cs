using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chsj
{
    class PF
    {
        #region Log Writer
        
        /*public static void LogWriter(string Result, string Data1, string Data2_1, string Data2_2, string Message)
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

                string ErrorTime = DateTime.Now.Year + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMinute + ":" + strSecond + "-" + strMilSecond;

                string Path = PV.LogFile + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = PV.lib.getTime("YYMMDD");



                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("날짜");
                    row.Add("검사시간");
                    row.Add("결과");
                    row.Add("레이저 마킹");
                    row.Add("잉크젯 마킹- DataMatrix");
                    row.Add("잉크젯 마킹- Text Data");
                    row.Add("Message");


                    row.Add("\r\n" + ErrorTime);
                    row.Add(PV.str_InspectionTIme);
                    row.Add(Result);
                    row.Add(PV.str_Data1);
                    row.Add(PV.str_Data2_1);
                    row.Add(Message);



                }
                else         // Path Exist
                {
                    row.Add(ErrorTime);
                    row.Add(PV.str_InspectionTIme);
                    row.Add(Result);
                    row.Add(PV.str_Data1);
                    row.Add(PV.str_Data2);
                    row.Add(Message);

                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                ExceptionWriter("LogWriter", ex.Message);
            }
        }
        */
        #endregion
        #region 공통 Log writer
        public static void ExceptionWriter(string ErrorLocation, string ErrorMessage)
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

                string ErrorTime = DateTime.Now.Year + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMinute + ":" + strSecond + "-" + strMilSecond;

                string Path = PV.ExceptionLogFile + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);
                string Logtime = PV.lib.getTime("YYMMDD");


                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("ErrorTime");
                    row.Add("NGLocation");
                    row.Add("NGMessage");



                    row.Add("\r\n" + Logtime);
                    row.Add(ErrorLocation);
                    row.Add(ErrorMessage);


                }
                else
                {


                    row.Add("\r\n" + Logtime);
                    row.Add(ErrorLocation);
                    row.Add(ErrorMessage);
                }

                writer.WriteCSV(row, Path + CreateFileName);

            }
            catch (Exception ex)
            {
                ExceptionWriter("ExceptionWriter", ex.Message);
            }
        }


        #endregion

        public static DateTime Delay(int MS)
        {
            // Thread 와 Timer보다 효율 적으로 사용할 수 있음.
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
