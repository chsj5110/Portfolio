using CdioCs;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chsj
{
    class PV
    {
        public static string DataPath = @"D:\VisionProgram\Data";
        public static string CsvLogFile = @"D:\VisionProgram\InspectionLogPath\";
        public static string CsvScanLogFile = @"D:\VisionProgram\CsvScanLogPath\";
        public static bool b_PassWord;
        public static int nnScanned = 0;                //스캔 된 수량
        public static double dWeight = 0;               // rs-232 통신으로 받은 중량
        public static bool bIOCheck = false;
        public static bool bCamCheck = false;
        public static bool bLPCheck = false;

        public static string sLOT;
        public static string strs_SType;
        public static string strs_SWorker;
        public static string[] strs_Order;
        public static string[] List_Type;
        public static string[] List_Order;

        public static int InputCheck1 = 0;              // 비전검사 
        public static int InputCheck_Old1 = 0;
        public static int InputCheck2 = 0;              //
        public static int InputCheck_Old2 = 0;

        public static SerialPort mySerialPort = new SerialPort("COM4");

        //변수 선언
        public static string StrCode1 = "";
        public static string StrCode2 = "";
        public static string StrCode3 = "";
        public static string StrCode4 = "";
        public static string StrCode5 = "";
        public static string StrCode6 = "";
        public static string StrCode7 = "";
        public static string StrCode8 = "";




        public static int nScanned;            ////스캔 된 수량
        public static int nEA = 0;                    // 포장 단위
        public static int nOrdered = 0;               // 발주 수량
        public static int nCheckBox = 0;
        public static int nBox;
        public static bool WorkStart = false;

        public static int Tick = 0;

        //Timer time1r = new System.Windows.Forms.Timer();

        public static string strLT1 = "";                 //차종
        public static string strLT2 = "";                 //품번
        public static string strLT3 = "";                 //품명
        public static string strLT4 = "";                 //업체코드
        public static string strLT5 = "";                 //ALC 코드
        public static string strLT6 = "";                 //EO 넘버
        public static string strLT7 = "";                 //LOT 넘버
        public static string strLT8 = "";                 //포장단위
        public static double strLT9 = 0;                    // 중량 하한
        public static double strLT10 = 0;                   // 중량 상한

        public static string strLO1 = "";
        public static string strLO2 = "";
        public static string strLO3 = "";
        public static string strLO4 = "";
        public static string strLO5 = "";
        public static string strLO6 = "";
        public static string strL07 = "";
        public static string strL08 = "";


        public static string GetCode;

        public static int Length1 = 0;
        public static int Length2 = 0;
        public static int Length3 = 0;
        public static int Length4 = 0;
        public static int Length5 = 0;
        public static int Length6 = 0;
        public static int Length7 = 0;
        public static int Length8 = 0;


        public static string FileNameCsv;
        public static string LOT;
        public static string Worker;


        #region IO 출력 변수

        public static short m_Id;
        public static Cdio dio = new Cdio();
        public static int[] m_UpCount = new int[8];
        public static int[] m_DownCount = new int[8];
        public static int CAMERA_NG_DelayTime = 0;
        public static int DelayTime = 1000;
        #endregion
    }
}
