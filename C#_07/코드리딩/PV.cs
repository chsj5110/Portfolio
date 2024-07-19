using System;
using CdioCs;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chsj
{
    class PV
    {
        public static SerialPort mySerialPort1 = new SerialPort("COM1");

        public static string CAMERA1_PATH = @"C:\Users\son30\OneDrive\Desktop\JAVEZ_IVS\JOB\Cam1.vpp";
        public static string CAMERA2_PATH = @"C:\Users\son30\OneDrive\Desktop\JAVEZ_IVS\JOB\Cam2.vpp";

        public static string LogFile = @"C:\Users\son30\OneDrive\Desktop\JAVEZ_IVS\Log\LogTxt\";
        public static string ExceptionLogFile = @"C:\Users\son30\OneDrive\Desktop\JAVEZ_IVS\Log\ExceptionLogTxt\";

        public static int OutputDelay = 1000;
        public static bool bIOCheck;
        public static int InputCheck1 = 0;
        public static int InputCheck_Old1 = 0;
        public static int InputCheck2 = 0;
        public static int InputCheck_Old2 = 0;
        
        public static string str_Data1_1;
        public static string str_Data1_2;
        public static string str_Data2_1;
        public static string str_Data2_2;
        

        public static Stopwatch CAM1Stopwatch = new Stopwatch();

        #region IO 출력 변수

        public static short m_Id;
        public static Cdio dio = new Cdio();
        public static int[] m_UpCount = new int[8];
        public static int[] m_DownCount = new int[8];
        public static int CAMERA_NG_DelayTime = 0;

        #endregion

        public static Library lib = new Library();
    }
}
