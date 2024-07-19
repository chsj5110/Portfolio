using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CdioCs;
using System.Windows.Forms;
using System.Diagnostics;

namespace chsj
{
    class PF
    {

        // 필수 폴더 생성
        public static void CreateFolder()
        {
            // 이미지
            if (!Directory.Exists(PV.DirImage))
            { Directory.CreateDirectory(PV.DirImage); }

            // 데이터
            if (!Directory.Exists(PV.DirData))
            { Directory.CreateDirectory(PV.DirData);}

            if (!Directory.Exists(PV.DirData + @"\카메라1\"))
            {Directory.CreateDirectory(PV.DirData + @"\카메라1\");}

            if (!Directory.Exists(PV.DirData + @"\카메라2\"))
            { Directory.CreateDirectory(PV.DirData + @"\카메라2\"); }

            if (!Directory.Exists(PV.DirData + @"\카메라3\"))
            { Directory.CreateDirectory(PV.DirData + @"\카메라3\"); }

            if (!Directory.Exists(PV.DirData + @"\카메라4\"))
            { Directory.CreateDirectory(PV.DirData + @"\카메라4\"); }                  //211025 추가

            // 시스템 로그
            if (!Directory.Exists(PV.DirSysLog))
            { Directory.CreateDirectory(PV.DirSysLog); }
        }

        #region 데이터 쓰기

        // 카메라1 검사 데이터 쓰기
        public static void WriteDataCam1(string Result, string Type, string Pattern_Result_Score, string GetBlobs_Area, string CogHistogramTool_Result_Mean, string Message)
        {
            StreamWriter sw;
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss.fff");
            string FileName = PV.DirData + @"\카메라1\" + date + ".csv";

            if (!File.Exists(FileName))
            {
                sw = new StreamWriter(FileName, true, Encoding.Default);
                sw.WriteLine("시간, 위치, 결과, 타입, 패턴, 블랍, 표면밝기, Message");
            }
            else
            { sw = new StreamWriter(FileName, true, Encoding.Default); }

            sw.WriteLine(date + "_" + time + "," + "카메라1" + "," + Result + ","  + Type + "," + Pattern_Result_Score + "," + GetBlobs_Area + "," + CogHistogramTool_Result_Mean + "," + Message);
            sw.Close();
        }

        // 카메라2 검사 데이터 쓰기
        public static void WriteDataCam2(string Result, string Type, string Pattern_Result_Score, string GetBlobs_Area, string CogHistogramTool_Result_Mean, string Message)
        {
            StreamWriter sw;
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss.fff");
            string FileName = PV.DirData + @"\카메라2\" + date + ".csv";

            if (!File.Exists(FileName))
            {
                sw = new StreamWriter(FileName, true, Encoding.Default);
                sw.WriteLine("시간, 위치, 결과, 타입, 패턴, 블랍, 표면밝기, Message");
            }
            else
            { sw = new StreamWriter(FileName, true, Encoding.Default); }

            sw.WriteLine(date + "_" + time + "," + "카메라2" + "," + Result + "," + Type + "," + Pattern_Result_Score + "," + GetBlobs_Area + "," + CogHistogramTool_Result_Mean + "," + Message);
            sw.Close();
        }

        // 카메라3 검사 데이터 쓰기
        public static void WriteDataCam3(string Result, string Type, string Pattern_Result_Score, string GetBlobs_Area, string CogHistogramTool_Result_Mean, string Message)
        {
            StreamWriter sw;
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss.fff");
            string FileName = PV.DirData + @"\카메라3\" + date + ".csv";

            if (!File.Exists(FileName))
            {
                sw = new StreamWriter(FileName, true, Encoding.Default);
                sw.WriteLine("시간, 위치, 결과, 타입, 패턴, 블랍, 표면밝기, Message");
            }
            else
            { sw = new StreamWriter(FileName, true, Encoding.Default); }

            sw.WriteLine(date + "_" + time + "," + "카메라3" + "," + Result + "," + Type + "," + Pattern_Result_Score + "," + GetBlobs_Area + "," + CogHistogramTool_Result_Mean + "," + Message);
            sw.Close();
        }

        // 카메라4 검사 데이터 쓰기
        public static void WriteDataCam4(string Result, string Type, string Pattern_Result_Score, string GetBlobs_Area, string CogHistogramTool_Result_Mean, string Message)
        {
            StreamWriter sw;
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss.fff");
            string FileName = PV.DirData + @"\카메라4\" + date + ".csv";

            if (!File.Exists(FileName))
            {
                sw = new StreamWriter(FileName, true, Encoding.Default);
                sw.WriteLine("시간, 위치, 결과, 타입, 패턴, 블랍, 표면밝기, Message");
            }
            else
            { sw = new StreamWriter(FileName, true, Encoding.Default); }

            sw.WriteLine(date + "_" + time + "," + "카메라4" + "," + Result + "," + Type + "," + Pattern_Result_Score + "," + GetBlobs_Area + "," + CogHistogramTool_Result_Mean + "," + Message);
            sw.Close();
        }
        
        // 시스템 로그 쓰기
        public static void WriteSysLog(string Location, string Message)
        {
            StreamWriter sw;
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss.fff");
            string FileName = PV.DirSysLog + @"\" + date + ".csv";

            if (!File.Exists(FileName))
            {
                sw = new StreamWriter(FileName, true, Encoding.Default);
                sw.WriteLine("시간, Location, Message");
            }
            else
            { sw = new StreamWriter(FileName, true, Encoding.Default); }

            sw.WriteLine(date + "_" + time + "," + Location + "," + Message);
            sw.Close();
        }

        // 이미지 파일 이름 만들기 Result : NG 또는 OK, CameraNumber : 카메라1, 카메라2, 카메라3, 카메라4
        public static string GetImgFileName(string Result, string CameraNumber)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HHmmssfff");

            string FilePath = PV.DirImage + @"\" + date + @"\" + CameraNumber + @"\" + Result;

            if (!Directory.Exists(FilePath))
            { Directory.CreateDirectory(FilePath); }

            string FileName = FilePath + @"\" + time + ".jpg";


            return FileName;

        }

        #endregion

        #region 데이터 읽기

        // 카메라1 상-하한값, 바이패스, 오프셋 설정값 읽기
        public static void ReadSettingDataCam1()
        {
            // Cam1 - Setting
            using (TextReader tReader = new StreamReader(PV.SettingDataPath + @"\Setting1.txt"))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)
                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[5]);

                        PV.Pattern_Result_Score_11_Min = Convert.ToDouble(stringArray[0]);
                        PV.Pattern_Result_Score_11_Max = Convert.ToDouble(stringArray[1]);
                        PV.GetBlobs_Area_11_Min = Convert.ToDouble(stringArray[2]);
                        PV.GetBlobs_Area_11_Max = Convert.ToDouble(stringArray[3]);
                        PV.CogHistogramTool_Result_Mean_11_Min = Convert.ToDouble(stringArray[4]);
                        PV.CogHistogramTool_Result_Mean_11_Max = Convert.ToDouble(stringArray[5]);

                    }
                }
            }

            // Cam1 - Bypass
            using (TextReader tReader = new StreamReader(PV.SettingDataPath + @"\Bypass1.txt"))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)
                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[0]);

                        PV.bBypass_11 = Convert.ToBoolean(stringArray[0]);
                    }
                }
            }

            // Cam1 - Offset
            using (TextReader tReader = new StreamReader(PV.SettingDataPath + @"\Offset1.txt"))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[2]);

                        PV.Pattern_Result_Score_11_Offset = Double.Parse(stringArray[0]);
                        PV.GetBlobs_Area_11_Offset = Double.Parse(stringArray[1]);
                        PV.CogHistogramTool_Result_Mean_11_Offset = Double.Parse(stringArray[2]);
                    }
                }
            }
        }

        // 카메라2 상-하한값, 바이패스, 오프셋 설정값 읽기
        public static void ReadSettingDataCam2()
        {
            // Cam2 - Setting
            using (TextReader tReader = new StreamReader(PV.SettingDataPath + @"\Setting2.txt"))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)
                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[5]);

                        PV.Pattern_Result_Score_21_Min = Convert.ToDouble(stringArray[0]);
                        PV.Pattern_Result_Score_21_Max = Convert.ToDouble(stringArray[1]);
                        PV.GetBlobs_Area_21_Min = Convert.ToDouble(stringArray[2]);
                        PV.GetBlobs_Area_21_Max = Convert.ToDouble(stringArray[3]);
                        PV.CogHistogramTool_Result_Mean_21_Min = Convert.ToDouble(stringArray[4]);
                        PV.CogHistogramTool_Result_Mean_21_Max = Convert.ToDouble(stringArray[5]);

                    }
                }
            }

            // Cam2 - Bypass
            using (TextReader tReader = new StreamReader(PV.SettingDataPath + @"\Bypass2.txt"))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)
                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[0]);

                        PV.bBypass_21 = Convert.ToBoolean(stringArray[0]);
                    }
                }
            }

            // Cam2 - Offset
            using (TextReader tReader = new StreamReader(PV.SettingDataPath + @"\Offset2.txt"))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[2]);

                        PV.Pattern_Result_Score_21_Offset = Double.Parse(stringArray[0]);
                        PV.GetBlobs_Area_21_Offset = Double.Parse(stringArray[1]);
                        PV.CogHistogramTool_Result_Mean_21_Offset = Double.Parse(stringArray[2]);
                    }
                }
            }
        }

        // 카메라3 상-하한값, 바이패스, 오프셋 설정값 읽기
        public static void ReadSettingDataCam3()
        {
            // Cam3 - Setting
            using (TextReader tReader = new StreamReader(PV.SettingDataPath + @"\Setting3.txt"))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)
                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[5]);

                        PV.Pattern_Result_Score_31_Min = Convert.ToDouble(stringArray[0]);
                        PV.Pattern_Result_Score_31_Max = Convert.ToDouble(stringArray[1]);
                        PV.GetBlobs_Area_31_Min = Convert.ToDouble(stringArray[2]);
                        PV.GetBlobs_Area_31_Max = Convert.ToDouble(stringArray[3]);
                        PV.CogHistogramTool_Result_Mean_31_Min = Convert.ToDouble(stringArray[4]);
                        PV.CogHistogramTool_Result_Mean_31_Max = Convert.ToDouble(stringArray[5]);

                    }
                }
            }

            // Cam3 - Bypass
            using (TextReader tReader = new StreamReader(PV.SettingDataPath + @"\Bypass3.txt"))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)
                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[0]);

                        PV.bBypass_31 = Convert.ToBoolean(stringArray[0]);
                    }
                }
            }

            // Cam3 - Offset
            using (TextReader tReader = new StreamReader(PV.SettingDataPath + @"\Offset3.txt"))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[2]);

                        PV.Pattern_Result_Score_31_Offset = Double.Parse(stringArray[0]);
                        PV.GetBlobs_Area_31_Offset = Double.Parse(stringArray[1]);
                        PV.CogHistogramTool_Result_Mean_31_Offset = Double.Parse(stringArray[2]);
                    }
                }
            }
        }

        // 카메라4 상-하한값, 바이패스, 오프셋 설정값 읽기
        public static void ReadSettingDataCam4()
        {
            // Cam4 - Setting
            using (TextReader tReader = new StreamReader(PV.SettingDataPath + @"\Setting4.txt"))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)
                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[5]);

                        PV.Pattern_Result_Score_41_Min = Convert.ToDouble(stringArray[0]);
                        PV.Pattern_Result_Score_41_Max = Convert.ToDouble(stringArray[1]);
                        PV.GetBlobs_Area_41_Min = Convert.ToDouble(stringArray[2]);
                        PV.GetBlobs_Area_41_Max = Convert.ToDouble(stringArray[3]);
                        PV.CogHistogramTool_Result_Mean_41_Min = Convert.ToDouble(stringArray[4]);
                        PV.CogHistogramTool_Result_Mean_41_Max = Convert.ToDouble(stringArray[5]);



                    }
                }
            }

            // Cam4 - Bypass
            using (TextReader tReader = new StreamReader(PV.SettingDataPath + @"\Bypass4.txt"))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)
                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[0]);

                        PV.bBypass_41 = Convert.ToBoolean(stringArray[0]);
                    }
                }
            }

            // Cam4 - Offset
            using (TextReader tReader = new StreamReader(PV.SettingDataPath + @"\Offset4.txt"))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[2]);

                        PV.Pattern_Result_Score_41_Offset = Double.Parse(stringArray[0]);
                        PV.GetBlobs_Area_41_Offset = Double.Parse(stringArray[1]);
                        PV.CogHistogramTool_Result_Mean_41_Offset = Double.Parse(stringArray[2]);
                    }
                }
            }
        }

        #endregion

        #region 기타
        // 딜레이
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
        
        // IO
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

        // IO - Input
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
        
        // IO - Output
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
