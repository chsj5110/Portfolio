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

        public static void LogWriter1(string Result, int Model)
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
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + "_Model" + Model + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = PV.lib.getTime("YYMMDD");



                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("날짜");
                    row.Add("Results_Item_0_Score");
                    row.Add("Results_GetBlobs_Count");
                    row.Add("Results_GetBlobs_Item_0_Area");
                    row.Add("Results_GetBlobs_Count1");
                    row.Add("Results_GetBlobs_Item_0_Area1");
                    row.Add("Results_GetBlobs_Count2");
                    row.Add("Results_GetBlobs_Item_0_Area2");
                    row.Add("Result_Mean");
                    row.Add("Result_StandardDeviation");
                    row.Add("Result_Mean1");
                    row.Add("Result_StandardDeviation1");
                    row.Add("결과");


                    row.Add("\r\n" + Logtime);
                    row.Add(PV.Cam1_Results_Item_0_Score.ToString());
                    row.Add(PV.Cam1_Results_GetBlobs_Count.ToString());
                    row.Add(PV.Cam1_Results_GetBlobs_Item_0_Area.ToString());
                    row.Add(PV.Cam1_Results_GetBlobs_Count1.ToString());
                    row.Add(PV.Cam1_Results_GetBlobs_Item_0_Area1.ToString());
                    row.Add(PV.Cam1_Results_GetBlobs_Count2.ToString());
                    row.Add(PV.Cam1_Results_GetBlobs_Item_0_Area2.ToString());
                    row.Add(PV.Cam1_Result_Mean.ToString());
                    row.Add(PV.Cam1_Result_StandardDeviation.ToString());
                    row.Add(PV.Cam1_Result_Mean1.ToString());
                    row.Add(PV.Cam1_Result_StandardDeviation1.ToString());
                    row.Add(Result);



                }
                else         // Path Exist
                {
                    row.Add(Logtime);
                    row.Add(PV.Cam1_Results_Item_0_Score.ToString());
                    row.Add(PV.Cam1_Results_GetBlobs_Count.ToString());
                    row.Add(PV.Cam1_Results_GetBlobs_Item_0_Area.ToString());
                    row.Add(PV.Cam1_Results_GetBlobs_Count1.ToString());
                    row.Add(PV.Cam1_Results_GetBlobs_Item_0_Area1.ToString());
                    row.Add(PV.Cam1_Results_GetBlobs_Count2.ToString());
                    row.Add(PV.Cam1_Results_GetBlobs_Item_0_Area2.ToString());
                    row.Add(PV.Cam1_Result_Mean.ToString());
                    row.Add(PV.Cam1_Result_StandardDeviation.ToString());
                    row.Add(PV.Cam1_Result_Mean1.ToString());
                    row.Add(PV.Cam1_Result_StandardDeviation1.ToString());
                    row.Add(Result);
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                ExceptionWriter("LogWriter1", ex.Message);
            }
        }
        public static void LogWriter2(string Result, int Model)
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
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + "_Model" + Model + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = PV.lib.getTime("YYMMDD");



                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("날짜");
                    row.Add("Results_Item_0_Score");
                    row.Add("Results_GetBlobs_Count");
                    row.Add("Results_GetBlobs_Item_0_Area");
                    row.Add("Results_GetBlobs_Count1");
                    row.Add("Results_GetBlobs_Item_0_Area1");
                    row.Add("Results_GetBlobs_Count2");
                    row.Add("Results_GetBlobs_Item_0_Area2");
                    row.Add("Result_Mean");
                    row.Add("Result_StandardDeviation");
                    row.Add("Result_Mean1");
                    row.Add("Result_StandardDeviation1");
                    row.Add("결과");


                    row.Add("\r\n" + Logtime);
                    row.Add(PV.Cam2_Results_Item_0_Score.ToString());
                    row.Add(PV.Cam2_Results_GetBlobs_Count.ToString());
                    row.Add(PV.Cam2_Results_GetBlobs_Item_0_Area.ToString());
                    row.Add(PV.Cam2_Results_GetBlobs_Count1.ToString());
                    row.Add(PV.Cam2_Results_GetBlobs_Item_0_Area1.ToString());
                    row.Add(PV.Cam2_Results_GetBlobs_Count2.ToString());
                    row.Add(PV.Cam2_Results_GetBlobs_Item_0_Area2.ToString());
                    row.Add(PV.Cam2_Result_Mean.ToString());
                    row.Add(PV.Cam2_Result_StandardDeviation.ToString());
                    row.Add(PV.Cam2_Result_Mean1.ToString());
                    row.Add(PV.Cam2_Result_StandardDeviation1.ToString());
                    row.Add(Result);



                }
                else         // Path Exist
                {
                    row.Add(Logtime);
                    row.Add(PV.Cam2_Results_Item_0_Score.ToString());
                    row.Add(PV.Cam2_Results_GetBlobs_Count.ToString());
                    row.Add(PV.Cam2_Results_GetBlobs_Item_0_Area.ToString());
                    row.Add(PV.Cam2_Results_GetBlobs_Count1.ToString());
                    row.Add(PV.Cam2_Results_GetBlobs_Item_0_Area1.ToString());
                    row.Add(PV.Cam2_Results_GetBlobs_Count2.ToString());
                    row.Add(PV.Cam2_Results_GetBlobs_Item_0_Area2.ToString());
                    row.Add(PV.Cam2_Result_Mean.ToString());
                    row.Add(PV.Cam2_Result_StandardDeviation.ToString());
                    row.Add(PV.Cam2_Result_Mean1.ToString());
                    row.Add(PV.Cam2_Result_StandardDeviation1.ToString());
                    row.Add(Result);
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                ExceptionWriter("LogWriter2", ex.Message);
            }
        }
        public static void LogWriter3(string Result, int Model)
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

                string Path = PV.LogFile3 + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + "_Model" + Model + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = PV.lib.getTime("YYMMDD");



                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("날짜");
                    row.Add("Results_Item_0_Score");
                    row.Add("Results_GetBlobs_Count");
                    row.Add("Results_GetBlobs_Item_0_Area");
                    row.Add("Results_GetBlobs_Count1");
                    row.Add("Results_GetBlobs_Item_0_Area1");
                    row.Add("Results_GetBlobs_Count2");
                    row.Add("Results_GetBlobs_Item_0_Area2");
                    row.Add("Result_Mean");
                    row.Add("Result_StandardDeviation");
                    row.Add("Result_Mean1");
                    row.Add("Result_StandardDeviation1");
                    row.Add("결과");


                    row.Add("\r\n" + Logtime);
                    row.Add(PV.Cam3_Results_Item_0_Score.ToString());
                    row.Add(PV.Cam3_Results_GetBlobs_Count.ToString());
                    row.Add(PV.Cam3_Results_GetBlobs_Item_0_Area.ToString());
                    row.Add(PV.Cam3_Results_GetBlobs_Count1.ToString());
                    row.Add(PV.Cam3_Results_GetBlobs_Item_0_Area1.ToString());
                    row.Add(PV.Cam3_Results_GetBlobs_Count2.ToString());
                    row.Add(PV.Cam3_Results_GetBlobs_Item_0_Area2.ToString());
                    row.Add(PV.Cam3_Result_Mean.ToString());
                    row.Add(PV.Cam3_Result_StandardDeviation.ToString());
                    row.Add(PV.Cam3_Result_Mean1.ToString());
                    row.Add(PV.Cam3_Result_StandardDeviation1.ToString());
                    row.Add(Result);



                }
                else         // Path Exist
                {
                    row.Add(Logtime);
                    row.Add(PV.Cam3_Results_Item_0_Score.ToString());
                    row.Add(PV.Cam3_Results_GetBlobs_Count.ToString());
                    row.Add(PV.Cam3_Results_GetBlobs_Item_0_Area.ToString());
                    row.Add(PV.Cam3_Results_GetBlobs_Count1.ToString());
                    row.Add(PV.Cam3_Results_GetBlobs_Item_0_Area1.ToString());
                    row.Add(PV.Cam3_Results_GetBlobs_Count2.ToString());
                    row.Add(PV.Cam3_Results_GetBlobs_Item_0_Area2.ToString());
                    row.Add(PV.Cam3_Result_Mean.ToString());
                    row.Add(PV.Cam3_Result_StandardDeviation.ToString());
                    row.Add(PV.Cam3_Result_Mean1.ToString());
                    row.Add(PV.Cam3_Result_StandardDeviation1.ToString());
                    row.Add(Result);
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                ExceptionWriter("LogWriter3", ex.Message);
            }
        }
        public static void LogWriter4(string Result, int Model)
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
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + "_Model" + Model + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = PV.lib.getTime("YYMMDD");



                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("날짜");
                    row.Add("Results_Item_0_Score");
                    row.Add("Results_GetBlobs_Count");
                    row.Add("Results_GetBlobs_Item_0_Area");
                    row.Add("Results_GetBlobs_Count1");
                    row.Add("Results_GetBlobs_Item_0_Area1");
                    row.Add("Results_GetBlobs_Count2");
                    row.Add("Results_GetBlobs_Item_0_Area2");
                    row.Add("Result_Mean");
                    row.Add("Result_StandardDeviation");
                    row.Add("Result_Mean1");
                    row.Add("Result_StandardDeviation1");
                    row.Add("결과");


                    row.Add("\r\n" + Logtime);
                    row.Add(PV.Cam4_Results_Item_0_Score.ToString());
                    row.Add(PV.Cam4_Results_GetBlobs_Count.ToString());
                    row.Add(PV.Cam4_Results_GetBlobs_Item_0_Area.ToString());
                    row.Add(PV.Cam4_Results_GetBlobs_Count1.ToString());
                    row.Add(PV.Cam4_Results_GetBlobs_Item_0_Area1.ToString());
                    row.Add(PV.Cam4_Results_GetBlobs_Count2.ToString());
                    row.Add(PV.Cam4_Results_GetBlobs_Item_0_Area2.ToString());
                    row.Add(PV.Cam4_Result_Mean.ToString());
                    row.Add(PV.Cam4_Result_StandardDeviation.ToString());
                    row.Add(PV.Cam4_Result_Mean1.ToString());
                    row.Add(PV.Cam4_Result_StandardDeviation1.ToString());
                    row.Add(Result);



                }
                else         // Path Exist
                {
                    row.Add(Logtime);
                    row.Add(PV.Cam4_Results_Item_0_Score.ToString());
                    row.Add(PV.Cam4_Results_GetBlobs_Count.ToString());
                    row.Add(PV.Cam4_Results_GetBlobs_Item_0_Area.ToString());
                    row.Add(PV.Cam4_Results_GetBlobs_Count1.ToString());
                    row.Add(PV.Cam4_Results_GetBlobs_Item_0_Area1.ToString());
                    row.Add(PV.Cam4_Results_GetBlobs_Count2.ToString());
                    row.Add(PV.Cam4_Results_GetBlobs_Item_0_Area2.ToString());
                    row.Add(PV.Cam4_Result_Mean.ToString());
                    row.Add(PV.Cam4_Result_StandardDeviation.ToString());
                    row.Add(PV.Cam4_Result_Mean1.ToString());
                    row.Add(PV.Cam4_Result_StandardDeviation1.ToString());
                    row.Add(Result);
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                ExceptionWriter("LogWriter4", ex.Message);
            }
        }

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


        public static void DataLog(int Model)
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

                string Path = PV.InspectionDataPath;
                string CreateFileName = "\\Model_" + Model.ToString() + "_공차.csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                if (dir.Exists == false)
                {
                    dir.Create();
                }
                else         // Path Exist
                {
                }

                // 검사 기준 데이터 입력
                File.Delete(Path + CreateFileName);

                #region
                if (Model == 1)
                {
                    row.Add("카메라 1");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit1[0]);
                    row.Add(PV.stringArray_Limit1[1]);
                    row.Add(PV.stringArray_Limit1[2]);
                    row.Add(PV.stringArray_Limit1[3]);
                    row.Add(PV.stringArray_Limit1[4]);
                    row.Add(PV.stringArray_Limit1[5]);
                    row.Add(PV.stringArray_Limit1[6]);
                    row.Add(PV.stringArray_Limit1[7]);
                    row.Add(PV.stringArray_Limit1[8]);
                    row.Add(PV.stringArray_Limit1[9]);
                    row.Add(PV.stringArray_Limit1[10]);
                    row.Add(PV.stringArray_Limit1[11]);
                    row.Add(PV.stringArray_Limit1[12]);
                    row.Add(PV.stringArray_Limit1[13]);
                    row.Add(PV.stringArray_Limit1[14]);


                    row.Add("\r\n" + "카메라 2");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit1[15]);
                    row.Add(PV.stringArray_Limit1[16]);
                    row.Add(PV.stringArray_Limit1[17]);
                    row.Add(PV.stringArray_Limit1[18]);
                    row.Add(PV.stringArray_Limit1[19]);
                    row.Add(PV.stringArray_Limit1[20]);
                    row.Add(PV.stringArray_Limit1[21]);
                    row.Add(PV.stringArray_Limit1[22]);
                    row.Add(PV.stringArray_Limit1[23]);
                    row.Add(PV.stringArray_Limit1[24]);
                    row.Add(PV.stringArray_Limit1[25]);
                    row.Add(PV.stringArray_Limit1[26]);
                    row.Add(PV.stringArray_Limit1[27]);
                    row.Add(PV.stringArray_Limit1[28]);
                    row.Add(PV.stringArray_Limit1[29]);

                    row.Add("\r\n" + "카메라 3");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit1[30]);
                    row.Add(PV.stringArray_Limit1[31]);
                    row.Add(PV.stringArray_Limit1[32]);
                    row.Add(PV.stringArray_Limit1[33]);
                    row.Add(PV.stringArray_Limit1[34]);
                    row.Add(PV.stringArray_Limit1[35]);
                    row.Add(PV.stringArray_Limit1[36]);
                    row.Add(PV.stringArray_Limit1[37]);
                    row.Add(PV.stringArray_Limit1[38]);
                    row.Add(PV.stringArray_Limit1[39]);
                    row.Add(PV.stringArray_Limit1[40]);
                    row.Add(PV.stringArray_Limit1[41]);
                    row.Add(PV.stringArray_Limit1[42]);
                    row.Add(PV.stringArray_Limit1[43]);
                    row.Add(PV.stringArray_Limit1[44]);

                    row.Add("\r\n" + "카메라 4");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit1[45]);
                    row.Add(PV.stringArray_Limit1[46]);
                    row.Add(PV.stringArray_Limit1[47]);
                    row.Add(PV.stringArray_Limit1[48]);
                    row.Add(PV.stringArray_Limit1[49]);
                    row.Add(PV.stringArray_Limit1[50]);
                    row.Add(PV.stringArray_Limit1[51]);
                    row.Add(PV.stringArray_Limit1[52]);
                    row.Add(PV.stringArray_Limit1[53]);
                    row.Add(PV.stringArray_Limit1[54]);
                    row.Add(PV.stringArray_Limit1[55]);
                    row.Add(PV.stringArray_Limit1[56]);
                    row.Add(PV.stringArray_Limit1[57]);
                    row.Add(PV.stringArray_Limit1[58]);
                    row.Add(PV.stringArray_Limit1[59]);
                }
                else if (Model == 2)
                {
                    row.Add("카메라 1");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit2[0]);
                    row.Add(PV.stringArray_Limit2[1]);
                    row.Add(PV.stringArray_Limit2[2]);
                    row.Add(PV.stringArray_Limit2[3]);
                    row.Add(PV.stringArray_Limit2[4]);
                    row.Add(PV.stringArray_Limit2[5]);
                    row.Add(PV.stringArray_Limit2[6]);
                    row.Add(PV.stringArray_Limit2[7]);
                    row.Add(PV.stringArray_Limit2[8]);
                    row.Add(PV.stringArray_Limit2[9]);
                    row.Add(PV.stringArray_Limit2[10]);
                    row.Add(PV.stringArray_Limit2[11]);
                    row.Add(PV.stringArray_Limit2[12]);
                    row.Add(PV.stringArray_Limit2[13]);
                    row.Add(PV.stringArray_Limit2[14]);


                    row.Add("\r\n" + "카메라 2");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit2[15]);
                    row.Add(PV.stringArray_Limit2[16]);
                    row.Add(PV.stringArray_Limit2[17]);
                    row.Add(PV.stringArray_Limit2[18]);
                    row.Add(PV.stringArray_Limit2[19]);
                    row.Add(PV.stringArray_Limit2[20]);
                    row.Add(PV.stringArray_Limit2[21]);
                    row.Add(PV.stringArray_Limit2[22]);
                    row.Add(PV.stringArray_Limit2[23]);
                    row.Add(PV.stringArray_Limit2[24]);
                    row.Add(PV.stringArray_Limit2[25]);
                    row.Add(PV.stringArray_Limit2[26]);
                    row.Add(PV.stringArray_Limit2[27]);
                    row.Add(PV.stringArray_Limit2[28]);
                    row.Add(PV.stringArray_Limit2[29]);

                    row.Add("\r\n" + "카메라 3");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit2[30]);
                    row.Add(PV.stringArray_Limit2[31]);
                    row.Add(PV.stringArray_Limit2[32]);
                    row.Add(PV.stringArray_Limit2[33]);
                    row.Add(PV.stringArray_Limit2[34]);
                    row.Add(PV.stringArray_Limit2[35]);
                    row.Add(PV.stringArray_Limit2[36]);
                    row.Add(PV.stringArray_Limit2[37]);
                    row.Add(PV.stringArray_Limit2[38]);
                    row.Add(PV.stringArray_Limit2[39]);
                    row.Add(PV.stringArray_Limit2[40]);
                    row.Add(PV.stringArray_Limit2[41]);
                    row.Add(PV.stringArray_Limit2[42]);
                    row.Add(PV.stringArray_Limit2[43]);
                    row.Add(PV.stringArray_Limit2[44]);

                    row.Add("\r\n" + "카메라 4");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit2[45]);
                    row.Add(PV.stringArray_Limit2[46]);
                    row.Add(PV.stringArray_Limit2[47]);
                    row.Add(PV.stringArray_Limit2[48]);
                    row.Add(PV.stringArray_Limit2[49]);
                    row.Add(PV.stringArray_Limit2[50]);
                    row.Add(PV.stringArray_Limit2[51]);
                    row.Add(PV.stringArray_Limit2[52]);
                    row.Add(PV.stringArray_Limit2[53]);
                    row.Add(PV.stringArray_Limit2[54]);
                    row.Add(PV.stringArray_Limit2[55]);
                    row.Add(PV.stringArray_Limit2[56]);
                    row.Add(PV.stringArray_Limit2[57]);
                    row.Add(PV.stringArray_Limit2[58]);
                    row.Add(PV.stringArray_Limit2[59]);
                }
                else if (Model == 3)
                {
                    row.Add("카메라 1");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit3[0]);
                    row.Add(PV.stringArray_Limit3[1]);
                    row.Add(PV.stringArray_Limit3[2]);
                    row.Add(PV.stringArray_Limit3[3]);
                    row.Add(PV.stringArray_Limit3[4]);
                    row.Add(PV.stringArray_Limit3[5]);
                    row.Add(PV.stringArray_Limit3[6]);
                    row.Add(PV.stringArray_Limit3[7]);
                    row.Add(PV.stringArray_Limit3[8]);
                    row.Add(PV.stringArray_Limit3[9]);
                    row.Add(PV.stringArray_Limit3[10]);
                    row.Add(PV.stringArray_Limit3[11]);
                    row.Add(PV.stringArray_Limit3[12]);
                    row.Add(PV.stringArray_Limit3[13]);
                    row.Add(PV.stringArray_Limit3[14]);


                    row.Add("\r\n" + "카메라 2");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit3[15]);
                    row.Add(PV.stringArray_Limit3[16]);
                    row.Add(PV.stringArray_Limit3[17]);
                    row.Add(PV.stringArray_Limit3[18]);
                    row.Add(PV.stringArray_Limit3[19]);
                    row.Add(PV.stringArray_Limit3[20]);
                    row.Add(PV.stringArray_Limit3[21]);
                    row.Add(PV.stringArray_Limit3[22]);
                    row.Add(PV.stringArray_Limit3[23]);
                    row.Add(PV.stringArray_Limit3[24]);
                    row.Add(PV.stringArray_Limit3[25]);
                    row.Add(PV.stringArray_Limit3[26]);
                    row.Add(PV.stringArray_Limit3[27]);
                    row.Add(PV.stringArray_Limit3[28]);
                    row.Add(PV.stringArray_Limit3[29]);

                    row.Add("\r\n" + "카메라 3");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit3[30]);
                    row.Add(PV.stringArray_Limit3[31]);
                    row.Add(PV.stringArray_Limit3[32]);
                    row.Add(PV.stringArray_Limit3[33]);
                    row.Add(PV.stringArray_Limit3[34]);
                    row.Add(PV.stringArray_Limit3[35]);
                    row.Add(PV.stringArray_Limit3[36]);
                    row.Add(PV.stringArray_Limit3[37]);
                    row.Add(PV.stringArray_Limit3[38]);
                    row.Add(PV.stringArray_Limit3[39]);
                    row.Add(PV.stringArray_Limit3[40]);
                    row.Add(PV.stringArray_Limit3[41]);
                    row.Add(PV.stringArray_Limit3[42]);
                    row.Add(PV.stringArray_Limit3[43]);
                    row.Add(PV.stringArray_Limit3[44]);

                    row.Add("\r\n" + "카메라 4");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit3[45]);
                    row.Add(PV.stringArray_Limit3[46]);
                    row.Add(PV.stringArray_Limit3[47]);
                    row.Add(PV.stringArray_Limit3[48]);
                    row.Add(PV.stringArray_Limit3[49]);
                    row.Add(PV.stringArray_Limit3[50]);
                    row.Add(PV.stringArray_Limit3[51]);
                    row.Add(PV.stringArray_Limit3[52]);
                    row.Add(PV.stringArray_Limit3[53]);
                    row.Add(PV.stringArray_Limit3[54]);
                    row.Add(PV.stringArray_Limit3[55]);
                    row.Add(PV.stringArray_Limit3[56]);
                    row.Add(PV.stringArray_Limit3[57]);
                    row.Add(PV.stringArray_Limit3[58]);
                    row.Add(PV.stringArray_Limit3[59]);
                }
                else if (Model == 4)
                {
                    row.Add("카메라 1");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit4[0]);
                    row.Add(PV.stringArray_Limit4[1]);
                    row.Add(PV.stringArray_Limit4[2]);
                    row.Add(PV.stringArray_Limit4[3]);
                    row.Add(PV.stringArray_Limit4[4]);
                    row.Add(PV.stringArray_Limit4[5]);
                    row.Add(PV.stringArray_Limit4[6]);
                    row.Add(PV.stringArray_Limit4[7]);
                    row.Add(PV.stringArray_Limit4[8]);
                    row.Add(PV.stringArray_Limit4[9]);
                    row.Add(PV.stringArray_Limit4[10]);
                    row.Add(PV.stringArray_Limit4[11]);
                    row.Add(PV.stringArray_Limit4[12]);
                    row.Add(PV.stringArray_Limit4[13]);
                    row.Add(PV.stringArray_Limit4[14]);


                    row.Add("\r\n" + "카메라 2");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit4[15]);
                    row.Add(PV.stringArray_Limit4[16]);
                    row.Add(PV.stringArray_Limit4[17]);
                    row.Add(PV.stringArray_Limit4[18]);
                    row.Add(PV.stringArray_Limit4[19]);
                    row.Add(PV.stringArray_Limit4[20]);
                    row.Add(PV.stringArray_Limit4[21]);
                    row.Add(PV.stringArray_Limit4[22]);
                    row.Add(PV.stringArray_Limit4[23]);
                    row.Add(PV.stringArray_Limit4[24]);
                    row.Add(PV.stringArray_Limit4[25]);
                    row.Add(PV.stringArray_Limit4[26]);
                    row.Add(PV.stringArray_Limit4[27]);
                    row.Add(PV.stringArray_Limit4[28]);
                    row.Add(PV.stringArray_Limit4[29]);

                    row.Add("\r\n" + "카메라 3");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit4[30]);
                    row.Add(PV.stringArray_Limit4[31]);
                    row.Add(PV.stringArray_Limit4[32]);
                    row.Add(PV.stringArray_Limit4[33]);
                    row.Add(PV.stringArray_Limit4[34]);
                    row.Add(PV.stringArray_Limit4[35]);
                    row.Add(PV.stringArray_Limit4[36]);
                    row.Add(PV.stringArray_Limit4[37]);
                    row.Add(PV.stringArray_Limit4[38]);
                    row.Add(PV.stringArray_Limit4[39]);
                    row.Add(PV.stringArray_Limit4[40]);
                    row.Add(PV.stringArray_Limit4[41]);
                    row.Add(PV.stringArray_Limit4[42]);
                    row.Add(PV.stringArray_Limit4[43]);
                    row.Add(PV.stringArray_Limit4[44]);

                    row.Add("\r\n" + "카메라 4");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit4[45]);
                    row.Add(PV.stringArray_Limit4[46]);
                    row.Add(PV.stringArray_Limit4[47]);
                    row.Add(PV.stringArray_Limit4[48]);
                    row.Add(PV.stringArray_Limit4[49]);
                    row.Add(PV.stringArray_Limit4[50]);
                    row.Add(PV.stringArray_Limit4[51]);
                    row.Add(PV.stringArray_Limit4[52]);
                    row.Add(PV.stringArray_Limit4[53]);
                    row.Add(PV.stringArray_Limit4[54]);
                    row.Add(PV.stringArray_Limit4[55]);
                    row.Add(PV.stringArray_Limit4[56]);
                    row.Add(PV.stringArray_Limit4[57]);
                    row.Add(PV.stringArray_Limit4[58]);
                    row.Add(PV.stringArray_Limit4[59]);
                }
                else if (Model == 5)
                {
                    row.Add("카메라 1");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit5[0]);
                    row.Add(PV.stringArray_Limit5[1]);
                    row.Add(PV.stringArray_Limit5[2]);
                    row.Add(PV.stringArray_Limit5[3]);
                    row.Add(PV.stringArray_Limit5[4]);
                    row.Add(PV.stringArray_Limit5[5]);
                    row.Add(PV.stringArray_Limit5[6]);
                    row.Add(PV.stringArray_Limit5[7]);
                    row.Add(PV.stringArray_Limit5[8]);
                    row.Add(PV.stringArray_Limit5[9]);
                    row.Add(PV.stringArray_Limit5[10]);
                    row.Add(PV.stringArray_Limit5[11]);
                    row.Add(PV.stringArray_Limit5[12]);
                    row.Add(PV.stringArray_Limit5[13]);
                    row.Add(PV.stringArray_Limit5[14]);


                    row.Add("\r\n" + "카메라 2");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit5[15]);
                    row.Add(PV.stringArray_Limit5[16]);
                    row.Add(PV.stringArray_Limit5[17]);
                    row.Add(PV.stringArray_Limit5[18]);
                    row.Add(PV.stringArray_Limit5[19]);
                    row.Add(PV.stringArray_Limit5[20]);
                    row.Add(PV.stringArray_Limit5[21]);
                    row.Add(PV.stringArray_Limit5[22]);
                    row.Add(PV.stringArray_Limit5[23]);
                    row.Add(PV.stringArray_Limit5[24]);
                    row.Add(PV.stringArray_Limit5[25]);
                    row.Add(PV.stringArray_Limit5[26]);
                    row.Add(PV.stringArray_Limit5[27]);
                    row.Add(PV.stringArray_Limit5[28]);
                    row.Add(PV.stringArray_Limit5[29]);

                    row.Add("\r\n" + "카메라 3");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit5[30]);
                    row.Add(PV.stringArray_Limit5[31]);
                    row.Add(PV.stringArray_Limit5[32]);
                    row.Add(PV.stringArray_Limit5[33]);
                    row.Add(PV.stringArray_Limit5[34]);
                    row.Add(PV.stringArray_Limit5[35]);
                    row.Add(PV.stringArray_Limit5[36]);
                    row.Add(PV.stringArray_Limit5[37]);
                    row.Add(PV.stringArray_Limit5[38]);
                    row.Add(PV.stringArray_Limit5[39]);
                    row.Add(PV.stringArray_Limit5[40]);
                    row.Add(PV.stringArray_Limit5[41]);
                    row.Add(PV.stringArray_Limit5[42]);
                    row.Add(PV.stringArray_Limit5[43]);
                    row.Add(PV.stringArray_Limit5[44]);

                    row.Add("\r\n" + "카메라 4");
                    row.Add("Results_Item_0_Score 하한");
                    row.Add("Results_GetBlobs_Count 하한");
                    row.Add("Results_GetBlobs_Item_0_Area 하한");
                    row.Add("Results_GetBlobs_Count1 하한");
                    row.Add("Results_GetBlobs_Item_0_Area1 하한");
                    row.Add("Results_GetBlobs_Count2 하한");
                    row.Add("Results_GetBlobs_Item_0_Area2 하한");
                    row.Add("Result_Mean 하한");
                    row.Add("Result_Mean 상한");
                    row.Add("Result_StandardDeviation 하한");
                    row.Add("Result_StandardDeviation 상한");
                    row.Add("Result_Mean1 하한");
                    row.Add("Result_Mean1 상한");
                    row.Add("Result_StandardDeviation1 하한");
                    row.Add("Result_StandardDeviation1 상한");

                    row.Add("\r\n" + "");
                    row.Add(PV.stringArray_Limit5[45]);
                    row.Add(PV.stringArray_Limit5[46]);
                    row.Add(PV.stringArray_Limit5[47]);
                    row.Add(PV.stringArray_Limit5[48]);
                    row.Add(PV.stringArray_Limit5[49]);
                    row.Add(PV.stringArray_Limit5[50]);
                    row.Add(PV.stringArray_Limit5[51]);
                    row.Add(PV.stringArray_Limit5[52]);
                    row.Add(PV.stringArray_Limit5[53]);
                    row.Add(PV.stringArray_Limit5[54]);
                    row.Add(PV.stringArray_Limit5[55]);
                    row.Add(PV.stringArray_Limit5[56]);
                    row.Add(PV.stringArray_Limit5[57]);
                    row.Add(PV.stringArray_Limit5[58]);
                    row.Add(PV.stringArray_Limit5[59]);
                }

                writer.WriteCSV(row, Path + CreateFileName);

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ExceptionWriter("DataLogWriter", ex.Message);
            }
        }
        #endregion


        public static string ImageSave(string ImgResult, string CamNum)
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

            // 2022
            string CreateFolderName = DateTime.Now.Year + "\\" + strMonth + "\\" + strDay;
            string CreateFileName = strHour + strMinute + strSecond + "." + strMilSecond + "_" + CamNum;

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
                filePath = PV.OKImageSavePath + CreateFolderName + "\\" + DateTime.Now.Year + strMonth + strDay + "_" + CreateFileName + ".jpg";
            }
            else
            {
                filePath = PV.NGImageSavePath + CreateFolderName + "\\" + DateTime.Now.Year + strMonth + strDay  + "_" + CreateFileName + ".jpg";
            }

            return filePath;

        }


        // 카메라 상-하한값 설정값 읽기
        public static void ReadModelData()
        {
            //Limit
            using (TextReader tReader = new StreamReader(PV.DataPath + @"\LimitList1.txt"))
            {
                string[] stringLines1 = tReader.ReadToEnd().Replace("\r\n", ";").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines1)
                {
                    if (stringLine != string.Empty)
                    {
                        PV.stringArray_Limit1 = stringLine.Split(';');
                    }
                }
            }

            using (TextReader tReader = new StreamReader(PV.DataPath + @"\LimitList2.txt"))
            {
                string[] stringLines2 = tReader.ReadToEnd().Replace("\r\n", ";").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines2)
                {
                    if (stringLine != string.Empty)
                    {
                        PV.stringArray_Limit2 = stringLine.Split(';');
                    }
                }
            }

            using (TextReader tReader = new StreamReader(PV.DataPath + @"\LimitList3.txt"))
            {
                string[] stringLines3 = tReader.ReadToEnd().Replace("\r\n", ";").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines3)
                {
                    if (stringLine != string.Empty)
                    {
                        PV.stringArray_Limit3 = stringLine.Split(';');
                    }
                }
            }
            using (TextReader tReader = new StreamReader(PV.DataPath + @"\LimitList4.txt"))
            {
                string[] stringLines4 = tReader.ReadToEnd().Replace("\r\n", ";").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines4)
                {
                    if (stringLine != string.Empty)
                    {
                        PV.stringArray_Limit4 = stringLine.Split(';');
                    }
                }
            }

            using (TextReader tReader = new StreamReader(PV.DataPath + @"\LimitList5.txt"))
            {
                string[] stringLines5 = tReader.ReadToEnd().Replace("\r\n", ";").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines5)
                {
                    if (stringLine != string.Empty)
                    {
                        PV.stringArray_Limit5 = stringLine.Split(';');
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
