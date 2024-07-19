using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chsj
{
    class PF
    {
       
        #region Load Data

        public static void LaodData_Setting1(string fileName)
        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[11]);


                        PV.Pattern_Result_Score_Min = Convert.ToDouble(stringArray[0]);
                        PV.Pattern_Result_Score_Max = Convert.ToDouble(stringArray[1]);
                        PV.Inner_Diameter_Min = Convert.ToDouble(stringArray[2]);
                        PV.Inner_Diameter_Max = Convert.ToDouble(stringArray[3]);
                        PV.Concentricity_Left_Distance_Min = Convert.ToDouble(stringArray[4]);
                        PV.Concentricity_Left_Distance_Max = Convert.ToDouble(stringArray[5]);
                        PV.Concentricity_Right_Distance_Min = Convert.ToDouble(stringArray[6]);
                        PV.Concentricity_Right_Distance_Max = Convert.ToDouble(stringArray[7]);
                        PV.Left_Angle_Min = Convert.ToDouble(stringArray[8]);
                        PV.Left_Angle_Max = Convert.ToDouble(stringArray[9]);
                        PV.Right_Angle_Min = Convert.ToDouble(stringArray[10]);
                        PV.Right_Angle_Max = Convert.ToDouble(stringArray[11]);


                    }
                }
            }
        }
        public static void LaodData_Bypass1(string fileName)
        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[5]);


                        PV.bPattern_Result_Score = Convert.ToBoolean(stringArray[0]);
                        PV.bInner_Diameter = Convert.ToBoolean(stringArray[1]);
                        PV.bConcentricity_Left_Distance = Convert.ToBoolean(stringArray[2]);
                        PV.bConcentricity_Right_Distance = Convert.ToBoolean(stringArray[3]);
                        PV.bLeft_Angle = Convert.ToBoolean(stringArray[4]);
                        PV.bRight_Angle = Convert.ToBoolean(stringArray[5]);


                    }
                }
            }
        }
        public static void LaodData_Offset1(string fileName)
        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[5]);


                        PV.Pattern_Result_Score_Offset = Double.Parse(stringArray[0]);
                        PV.Inner_Diameter_Offset = Double.Parse(stringArray[1]);
                        PV.Concentricity_Left_Distance_Offset = Double.Parse(stringArray[2]);
                        PV.Concentricity_Right_Distance_Offset = Double.Parse(stringArray[3]);
                        PV.Left_Angle_Offset = Double.Parse(stringArray[4]);
                        PV.Right_Angle_Offset = Double.Parse(stringArray[5]);


                    }
                }
            }
        }
        public static void LaodData_Calib1(string fileName)
        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[2]);


                        PV.Calib_Inner_Diameter = Double.Parse(stringArray[0]);
                        PV.Calib_Concentricity = Double.Parse(stringArray[1]);
                        PV.Calib_Angle = Double.Parse(stringArray[2]);


                    }
                }
            }
        }
        public static void LaodData_Setting2(string fileName)
        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[9]);


                        PV.Inner_Geometry_Min = Convert.ToDouble(stringArray[0]);
                        PV.Inner_Geometry_Max = Convert.ToDouble(stringArray[1]);
                        PV.Outer_Geometry_Min = Convert.ToDouble(stringArray[2]);
                        PV.Outer_Geometry_Max = Convert.ToDouble(stringArray[3]);
                        PV.GetBlobs_Area_Min = Convert.ToDouble(stringArray[4]);
                        PV.GetBlobs_Area_Max = Convert.ToDouble(stringArray[5]);
                        PV.Inner_Radius_Min = Convert.ToDouble(stringArray[6]);
                        PV.Inner_Radius_Max = Convert.ToDouble(stringArray[7]);
                        PV.Outer_Radius_Min = Convert.ToDouble(stringArray[8]);
                        PV.Outer_Radius_Max = Convert.ToDouble(stringArray[9]);


                    }
                }
            }
        }
        public static void LaodData_Bypass2(string fileName)
        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[4]);


                        PV.bInner_Geometry = Convert.ToBoolean(stringArray[0]);
                        PV.bOuter_Geometry = Convert.ToBoolean(stringArray[1]);
                        PV.bGetBlobs_Area = Convert.ToBoolean(stringArray[2]);
                        PV.bInner_Radius = Convert.ToBoolean(stringArray[3]);
                        PV.bOuter_Radius = Convert.ToBoolean(stringArray[4]);


                    }
                }
            }
        }
        public static void LaodData_Offset2(string fileName)
        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[4]);


                        PV.Inner_Geometry_Offset = Double.Parse(stringArray[0]);
                        PV.Outer_Geometry_Offset = Double.Parse(stringArray[1]);
                        PV.GetBlobs_Area_Offset = Double.Parse(stringArray[2]);
                        PV.Inner_Radius_Offset = Double.Parse(stringArray[3]);
                        PV.Outer_Radius_Offset = Double.Parse(stringArray[4]);

                    }
                }
            }
        }
        public static void LaodData_Calib2(string fileName)
        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[1]);


                        PV.Calib_Inner_Radius = Double.Parse(stringArray[0]);
                        PV.Calib_Outer_Radius = Double.Parse(stringArray[1]);


                    }
                }
            }
        }

        #endregion

        #region Log writer

        public static void LogWriter1(string Result, string Inner_Diameter, string Left_Angle, string Right_Angle, string Concentricity_Left_Distance, string Concentricity_Right_Distance, string Message)
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

                string Path = PV.LogFile1 + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = PV.lib.getTime("YYMMDD");

                

                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("날짜");
                    row.Add("위치");
                    row.Add("검사시간");
                    row.Add("결과");
                    //row.Add("외경");
                    row.Add("내경");
                    row.Add("각도 왼쪽");
                    row.Add("각도 오른쪽");
                    row.Add("동심도 왼쪽");
                    row.Add("동심도 오른쪽");
                    row.Add("Message");


                    row.Add("\r\n" + Logtime);
                    row.Add("측면");
                    row.Add(PV.lbl_CAM1TIME_Str);
                    row.Add(Result);
                    //row.Add(Outer_Diameter);               
                    row.Add(Inner_Diameter);
                    row.Add(Left_Angle);
                    row.Add(Right_Angle);
                    row.Add(Concentricity_Left_Distance);
                    row.Add(Concentricity_Right_Distance);
                    row.Add(Message);



                }
                else         // Path Exist
                {
                    row.Add(Logtime);
                    row.Add("측면");
                    row.Add(PV.lbl_CAM1TIME_Str);
                    row.Add(Result);
                    //row.Add(Outer_Diameter);
                    row.Add(Inner_Diameter);
                    row.Add(Left_Angle);
                    row.Add(Right_Angle);
                    row.Add(Concentricity_Left_Distance);
                    row.Add(Concentricity_Right_Distance);
                    row.Add(Message);
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                ExceptionWriter("LogWriter1", ex.Message);
            }
        }

        public static void LogWriter2(string Result, string Inner_Geomerty, string Outer_Geometry, string GetBlobs_Area, string Inner_Radius, string Outer_Radius, string Message)
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

                string Path = PV.LogFile2 + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);


                string Logtime = PV.lib.getTime("YYMMDD");
                


                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("날짜");
                    row.Add("위치");
                    row.Add("검사시간");
                    row.Add("결과");
                    row.Add("내경");
                    row.Add("외경");
                    row.Add("내형상");
                    row.Add("외형상");
                    row.Add("외형상함몰");
                    row.Add("Message");


                    row.Add("\r\n" + Logtime);
                    row.Add("정면");
                    row.Add(PV.lbl_CAM2TIME_Str);
                    row.Add(Result);
                    row.Add(Inner_Radius);
                    row.Add(Outer_Radius);
                    row.Add(Inner_Geomerty);
                    row.Add(Outer_Geometry);
                    row.Add(GetBlobs_Area);
                    row.Add(Message);



                }
                else         // Path Exist
                {
                    row.Add(Logtime);
                    row.Add("정면");
                    row.Add(PV.lbl_CAM2TIME_Str);
                    row.Add(Result);
                    row.Add(Inner_Radius);
                    row.Add(Outer_Radius);
                    row.Add(Inner_Geomerty);
                    row.Add(Outer_Geometry);
                    row.Add(GetBlobs_Area);
                    row.Add(Message);
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                ExceptionWriter("LogWriter2", ex.Message);
            }
        }

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


                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("ErrorTime");
                    row.Add("NGLocation");
                    row.Add("NGMessage");



                    row.Add("\r\n" + ErrorTime);
                    row.Add(ErrorLocation);
                    row.Add(ErrorMessage);


                }
                else
                {


                    row.Add("\r\n" + ErrorTime);
                    row.Add(ErrorLocation);
                    row.Add(ErrorMessage);
                }

                writer.WriteCSV(row, Path + CreateFileName);

            }
            catch (Exception ex)
            {
                ExceptionWriter("NGExceptionWriter", ex.Message);
            }
        }
        
        public static void SystemDataLogWriter(string Message)
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

                string Path = PV.SystemDataLogFile + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = PV.lib.getTime("YYMMDD");




                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("날짜");
                    row.Add("Message");


                    row.Add("\r\n" + Logtime);
                    row.Add(Message);



                }
                else         // Path Exist
                {
                    row.Add(Logtime);
                    row.Add(Message);
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                ExceptionWriter("SystemDataLogWriter", ex.Message);
            }
        }

        public static void SystemDataLogWriter2(string Message)
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

                string Path = PV.SystemDataLogFile2 + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = PV.lib.getTime("YYMMDD");




                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("날짜");
                    row.Add("Message");


                    row.Add("\r\n" + Logtime);
                    row.Add(Message);



                }
                else         // Path Exist
                {
                    row.Add(Logtime);
                    row.Add(Message);
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                ExceptionWriter("SystemDataLogWriter2", ex.Message);
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

        #endregion

        #region "etc"

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

        #endregion


        

    }
}
