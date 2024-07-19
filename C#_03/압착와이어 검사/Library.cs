using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace chsj
{
    class Library
    {
        private string errLogPath = @"D:\InspectionErrorLog\";


        /*
         * File or Directory
         */
        public void saveErrLog(string _errMSG)
        {
            string fileName = getDate("YYYYMMDD", "") + ".csv";

            makeFolder(errLogPath);


            CsvFileReadWrite writer = new CsvFileReadWrite();
            CsvRow row = new CsvRow();

            row.Add(getTime("HHMMSS"));
            row.Add(_errMSG);

            writer.WriteCSV(row, errLogPath + fileName);

        }

        public bool makeFolder(string _path)
        {
            DirectoryInfo dir = new DirectoryInfo(_path);

            if (dir.Exists)
            {

                return true;
            }
            else
            {
                dir.Create();
                return false;
            }
        }
        public bool fileCheck(string _path)
        {
            FileInfo file = new FileInfo(_path);
            if (file.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /*
         * Date, Time
         */
        public string getDate(string _dateType, string _word)
        {
            string reDate = "";
            string yyyy, mm, dd;

            yyyy = DateTime.Now.Year.ToString();
            mm = DateTime.Now.Month.ToString();
            dd = DateTime.Now.Day.ToString();

            if (_dateType == "YYMMDD")
            {
                yyyy = yyyy.Substring(2, 2);
            }

            if (mm.Length == 1)
            {
                mm = "0" + mm;
            }

            if (dd.Length == 1)
            {
                dd = "0" + dd;
            }


            reDate = yyyy + "" + mm + "" + dd;

            return reDate;
        }
        public string getTime(string datatype)
        {
            string strYear = DateTime.Now.Year.ToString();
            string strMonth = DateTime.Now.Month.ToString();
            string strDay = DateTime.Now.Day.ToString();
            string strHour = DateTime.Now.Hour.ToString();
            string strMinute = DateTime.Now.Minute.ToString();
            string strSecond = DateTime.Now.Second.ToString();
            string strMilSecond = DateTime.Now.Millisecond.ToString();
            string Time = "";
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
            if (datatype == "YYMMDD")
                Time = strYear + "_" + strMonth + strDay + "_" + strHour + strMinute + strSecond + "_" + strMilSecond;
            if (datatype == "MMDD")
                Time = strMonth + "/" + strDay + "_" + strHour + ":" + strMinute + ":" + strSecond + "_" + strMilSecond;
            if (datatype == "TTMM")
                Time = strHour + strMinute + strSecond + "-" + strMilSecond;


            return Time;
        }

        //public string getTime(string _timeType, string _word)
        //{
        //    string reTime = "";
        //    string hh, mm, ss, ms;

        //    hh = DateTime.Now.Hour.ToString();
        //    mm = DateTime.Now.Minute.ToString();
        //    ss = DateTime.Now.Second.ToString();
        //    ms = DateTime.Now.Millisecond.ToString();

        //    if (hh.Length == 1)
        //    {
        //        hh = "0" + hh;
        //    }
        //    if (mm.Length == 1)
        //    {
        //        mm = "0" + mm;
        //    }
        //    if (ss.Length == 1)
        //    {
        //        ss = "0" + ss;
        //    }

        //    if (ms.Length == 1)
        //    {
        //        ms = "00" + ms;
        //    }
        //    else if (ms.Length == 2)
        //    {
        //        ms = "0" + ms;
        //    }


        //    if (_timeType == "HHMMSS")
        //    {
        //        reTime = hh + _word + mm + _word + ss;
        //    }
        //    else if (_timeType == "HHMMSSMS")
        //    {
        //        reTime = hh + _word + mm + _word + ss + _word + ms;
        //    }

        //    return reTime;

        //}
        public string LoggetTime(string datatype)
        {
            string strYear = DateTime.Now.Year.ToString();
            string strMonth = DateTime.Now.Month.ToString();
            string strDay = DateTime.Now.Day.ToString();
            string strHour = DateTime.Now.Hour.ToString();
            string strMinute = DateTime.Now.Minute.ToString();
            string strSecond = DateTime.Now.Second.ToString();
            string strMilSecond = DateTime.Now.Millisecond.ToString();
            string Time = "";
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
            if (datatype == "YYMMDD")
                Time = strYear + "_" + strMonth + strDay + "_" + strHour + strMinute + strSecond + "_" + strMilSecond;
            if (datatype == "MMDD")
                Time = strHour + ":" + strMinute + ":" + strSecond + ":" + strMilSecond;
            if (datatype == "TTMM")
                Time = strHour + strMinute + strSecond + "-" + strMilSecond;


            return Time;
        }




        //for INI file read write

        // ini Read 함수
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(String section, String key, String def, StringBuilder retVal, int size, String filePath);

        // ini Write 함수
        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(String section, String key, String val, String filePath);

        /// ini Write
        public void G_IniWriteValue(String Section, String Key, String Value, string avsPath)
        {
            WritePrivateProfileString(Section, Key, Value, avsPath);
        }



        /// ini File Read
        public String G_IniReadValue(String Section, String Key, string avsPath)
        {

            StringBuilder temp = new StringBuilder(2000);
            int i = GetPrivateProfileString(Section, Key, "", temp, 2000, avsPath);
            return temp.ToString();
        }
    }
}
