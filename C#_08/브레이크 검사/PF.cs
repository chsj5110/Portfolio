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


        public static string ImageSave(string ImgResult)
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

            if (strHour.Length == 1)
                strHour = "0" + strHour;

            if (strMinute.Length == 1)
                strMinute = "0" + strMinute;

            if (strSecond.Length == 1)
                strSecond = "0" + strSecond;

            if (strMilSecond.Length == 0)
            {
                strMilSecond = "000";
            }
            else if (strMilSecond.Length == 1)
            {
                strMilSecond = "00" + strMilSecond;
            }
            else if (strMilSecond.Length == 2)
            {
                strMilSecond = "0" + strMilSecond;
            }

            StringBuilder sb = new StringBuilder();

            string CreateFolderName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
            string CreateFileName = strHour+"_"+strMinute+"_"+strSecond+"_"+strMilSecond;

            DirectoryInfo dir;

            if (ImgResult == "OK")
            {
                dir = new DirectoryInfo(PV.OKImageSavePath + CreateFolderName);
            }
            else
            {
                dir = new DirectoryInfo(PV.NGImageSavePath + CreateFolderName);
            }

            if (dir.Exists == false)
            {
                dir.Create();
            }

            string filePath;

            if (ImgResult == "OK")
            {
                filePath = PV.OKImageSavePath+CreateFolderName+CreateFileName+".jpg";
            }
            else
            {
                filePath = PV.NGImageSavePath+CreateFolderName+CreateFileName+".jpg";
            }

            return filePath;

        }


        // 카메라1 상-하한값, 바이패스, 오프셋 설정값 읽기
        public static void ReadModelData()
        {
            // Model Name
            using (TextReader tReader = new StreamReader(PV.DataPath + @"\ModelList.txt"))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\r\n", ";").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)
                {
                    if (stringLine != string.Empty)
                    {
                        PV.stringArray_Model = stringLine.Split(';');

                    }
                }

            }

            //Limit
            using (TextReader tReader = new StreamReader(PV.DataPath + @"\LimitList.txt"))
            {
                string[] stringLines1 = tReader.ReadToEnd().Replace("\r\n", ";").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines1)
                {
                    if (stringLine != string.Empty)
                    {
                        PV.stringArray_Limit = stringLine.Split(';');
                    }
                }
            }

            //Offset
            using (TextReader tReader = new StreamReader(PV.DataPath + @"\OffsetList.txt"))
            {
                string[] stringLines2 = tReader.ReadToEnd().Replace("\r\n", ";").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines2)
                {
                    if (stringLine != string.Empty)
                    {
                        PV.stringArray_Offset = stringLine.Split(';');
                    }
                }
            }

            //Score
            using (TextReader tReader = new StreamReader(PV.DataPath + @"\ScoreList.txt"))
            {
                string[] stringLines3 = tReader.ReadToEnd().Replace("\r\n", ";").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines3)
                {
                    if (stringLine != string.Empty)
                    {
                        PV.stringArray_Score = stringLine.Split(';');
                    }
                }
            }

            //Score1
            using (TextReader tReader = new StreamReader(PV.DataPath + @"\ScoreList1.txt"))
            {
                string[] stringLines3 = tReader.ReadToEnd().Replace("\r\n", ";").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines3)
                {
                    if (stringLine != string.Empty)
                    {
                        PV.stringArray_AngleScore = stringLine.Split(';');
                    }
                }
            }

        }

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
