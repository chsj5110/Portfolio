using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chsj
{
    class Library
    {
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
    }
}
