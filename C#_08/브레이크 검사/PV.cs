using CdioCs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chsj
{
    class PV
    {
        #region Jobfile Path
        public static string CAMERA_PATH1 = @"D:\VisionProgram\JOB\Cam1.vpp";
        public static string CAMERA_PATH2 = @"D:\VisionProgram\JOB\Cam2.vpp";
        public static string CAMERA_PATH3 = @"D:\VisionProgram\JOB\Cam3.vpp";
        public static string CAMERA_PATH4 = @"D:\VisionProgram\JOB\Cam4.vpp";
        public static string CAMERA_PATH5 = @"D:\VisionProgram\JOB\Cam5.vpp";
        public static string CAMERA_PATH6 = @"D:\VisionProgram\JOB\Cam6.vpp";
        public static string CAMERA_PATH7 = @"D:\VisionProgram\JOB\Cam7.vpp";
        public static string CAMERA_PATH8 = @"D:\VisionProgram\JOB\Cam8.vpp";
        public static string CAMERA_PATH9 = @"D:\VisionProgram\JOB\Cam9.vpp";
        public static string CAMERA_PATH10 = @"D:\VisionProgram\JOB\Cam10.vpp";
        public static string CAMERA_PATH11 = @"D:\VisionProgram\JOB\Cam11.vpp";
        public static string CAMERA_PATH12 = @"D:\VisionProgram\JOB\Cam12.vpp";
        public static string CAMERA_PATH13 = @"D:\VisionProgram\JOB\Cam13.vpp";
        public static string CAMERA_PATH14 = @"D:\VisionProgram\JOB\Cam14.vpp";
        public static string CAMERA_PATH15 = @"D:\VisionProgram\JOB\Cam15.vpp";
        public static string CAMERA_PATH16 = @"D:\VisionProgram\JOB\Cam16.vpp";
        public static string CAMERA_PATH17 = @"D:\VisionProgram\JOB\Cam17.vpp";
        public static string CAMERA_PATH18 = @"D:\VisionProgram\JOB\Cam18.vpp";
        public static string CAMERA_PATH19 = @"D:\VisionProgram\JOB\Cam19.vpp";
        public static string CAMERA_PATH20 = @"D:\VisionProgram\JOB\Cam20.vpp";
        public static string CAMERA_PATH21 = @"D:\VisionProgram\JOB\Cam21.vpp";
        public static string CAMERA_PATH22 = @"D:\VisionProgram\JOB\Cam22.vpp";
        public static string CAMERA_PATH23 = @"D:\VisionProgram\JOB\Cam23.vpp";
        public static string CAMERA_PATH24 = @"D:\VisionProgram\JOB\Cam24.vpp";
        public static string CAMERA_PATH25 = @"D:\VisionProgram\JOB\Cam25.vpp";
        public static string CAMERA_PATH26 = @"D:\VisionProgram\JOB\Cam26.vpp";
        public static string CAMERA_PATH27 = @"D:\VisionProgram\JOB\Cam27.vpp";
        public static string CAMERA_PATH28 = @"D:\VisionProgram\JOB\Cam28.vpp";
        public static string CAMERA_PATH29 = @"D:\VisionProgram\JOB\Cam29.vpp";
        public static string CAMERA_PATH30 = @"D:\VisionProgram\JOB\Cam30.vpp";

        public static string CAMERA_PATH31 = @"D:\VisionProgram\JOB\Cam31.vpp";
        public static string CAMERA_PATH32 = @"D:\VisionProgram\JOB\Cam32.vpp";
        public static string CAMERA_PATH33 = @"D:\VisionProgram\JOB\Cam33.vpp";
        public static string CAMERA_PATH34 = @"D:\VisionProgram\JOB\Cam34.vpp";
        public static string CAMERA_PATH35 = @"D:\VisionProgram\JOB\Cam35.vpp";
        public static string CAMERA_PATH36 = @"D:\VisionProgram\JOB\Cam36.vpp";
        public static string CAMERA_PATH37 = @"D:\VisionProgram\JOB\Cam37.vpp";
        public static string CAMERA_PATH38 = @"D:\VisionProgram\JOB\Cam38.vpp";
        public static string CAMERA_PATH39 = @"D:\VisionProgram\JOB\Cam39.vpp";
        public static string CAMERA_PATH40 = @"D:\VisionProgram\JOB\Cam40.vpp";
        public static string CAMERA_PATH41 = @"D:\VisionProgram\JOB\Cam41.vpp";
        public static string CAMERA_PATH42 = @"D:\VisionProgram\JOB\Cam42.vpp";
        public static string CAMERA_PATH43 = @"D:\VisionProgram\JOB\Cam43.vpp";
        public static string CAMERA_PATH44 = @"D:\VisionProgram\JOB\Cam44.vpp";
        public static string CAMERA_PATH45 = @"D:\VisionProgram\JOB\Cam45.vpp";
        public static string CAMERA_PATH46 = @"D:\VisionProgram\JOB\Cam46.vpp";
        public static string CAMERA_PATH47 = @"D:\VisionProgram\JOB\Cam47.vpp";
        public static string CAMERA_PATH48 = @"D:\VisionProgram\JOB\Cam48.vpp";
        public static string CAMERA_PATH49 = @"D:\VisionProgram\JOB\Cam49.vpp";
        public static string CAMERA_PATH50 = @"D:\VisionProgram\JOB\Cam50.vpp";
        public static string CAMERA_PATH51 = @"D:\VisionProgram\JOB\Cam51.vpp";
        public static string CAMERA_PATH52 = @"D:\VisionProgram\JOB\Cam52.vpp";
        public static string CAMERA_PATH53 = @"D:\VisionProgram\JOB\Cam53.vpp";
        public static string CAMERA_PATH54 = @"D:\VisionProgram\JOB\Cam54.vpp";
        public static string CAMERA_PATH55 = @"D:\VisionProgram\JOB\Cam55.vpp";
        public static string CAMERA_PATH56 = @"D:\VisionProgram\JOB\Cam56.vpp";
        public static string CAMERA_PATH57 = @"D:\VisionProgram\JOB\Cam57.vpp";
        public static string CAMERA_PATH58 = @"D:\VisionProgram\JOB\Cam58.vpp";
        public static string CAMERA_PATH59 = @"D:\VisionProgram\JOB\Cam59.vpp";
        public static string CAMERA_PATH60 = @"D:\VisionProgram\JOB\Cam60.vpp";

        public static string CAMERA_PATH61 = @"D:\VisionProgram\JOB\Cam61.vpp";
        public static string CAMERA_PATH62 = @"D:\VisionProgram\JOB\Cam62.vpp";
        public static string CAMERA_PATH63 = @"D:\VisionProgram\JOB\Cam63.vpp";
        public static string CAMERA_PATH64 = @"D:\VisionProgram\JOB\Cam64.vpp";
        public static string CAMERA_PATH65 = @"D:\VisionProgram\JOB\Cam65.vpp";
        public static string CAMERA_PATH66 = @"D:\VisionProgram\JOB\Cam66.vpp";
        public static string CAMERA_PATH67 = @"D:\VisionProgram\JOB\Cam67.vpp";
        public static string CAMERA_PATH68 = @"D:\VisionProgram\JOB\Cam68.vpp";
        public static string CAMERA_PATH69 = @"D:\VisionProgram\JOB\Cam69.vpp";
        public static string CAMERA_PATH70 = @"D:\VisionProgram\JOB\Cam70.vpp";
        public static string CAMERA_PATH71 = @"D:\VisionProgram\JOB\Cam71.vpp";
        public static string CAMERA_PATH72 = @"D:\VisionProgram\JOB\Cam72.vpp";
        public static string CAMERA_PATH73 = @"D:\VisionProgram\JOB\Cam73.vpp";
        public static string CAMERA_PATH74 = @"D:\VisionProgram\JOB\Cam74.vpp";
        public static string CAMERA_PATH75 = @"D:\VisionProgram\JOB\Cam75.vpp";
        public static string CAMERA_PATH76 = @"D:\VisionProgram\JOB\Cam76.vpp";
        public static string CAMERA_PATH77 = @"D:\VisionProgram\JOB\Cam77.vpp";
        public static string CAMERA_PATH78 = @"D:\VisionProgram\JOB\Cam78.vpp";
        public static string CAMERA_PATH79 = @"D:\VisionProgram\JOB\Cam79.vpp";
        public static string CAMERA_PATH80 = @"D:\VisionProgram\JOB\Cam80.vpp";
        public static string CAMERA_PATH81 = @"D:\VisionProgram\JOB\Cam81.vpp";
        public static string CAMERA_PATH82 = @"D:\VisionProgram\JOB\Cam82.vpp";
        public static string CAMERA_PATH83 = @"D:\VisionProgram\JOB\Cam83.vpp";
        public static string CAMERA_PATH84 = @"D:\VisionProgram\JOB\Cam84.vpp";
        public static string CAMERA_PATH85 = @"D:\VisionProgram\JOB\Cam85.vpp";
        public static string CAMERA_PATH86 = @"D:\VisionProgram\JOB\Cam86.vpp";
        public static string CAMERA_PATH87 = @"D:\VisionProgram\JOB\Cam87.vpp";
        public static string CAMERA_PATH88 = @"D:\VisionProgram\JOB\Cam88.vpp";
        public static string CAMERA_PATH89 = @"D:\VisionProgram\JOB\Cam89.vpp";
        public static string CAMERA_PATH90 = @"D:\VisionProgram\JOB\Cam90.vpp";

        public static string CAMERA_PATH91 = @"D:\VisionProgram\JOB\Cam91.vpp";
        public static string CAMERA_PATH92 = @"D:\VisionProgram\JOB\Cam92.vpp";
        public static string CAMERA_PATH93 = @"D:\VisionProgram\JOB\Cam93.vpp";
        public static string CAMERA_PATH94 = @"D:\VisionProgram\JOB\Cam94.vpp";
        public static string CAMERA_PATH95 = @"D:\VisionProgram\JOB\Cam95.vpp";
        public static string CAMERA_PATH96 = @"D:\VisionProgram\JOB\Cam96.vpp";
        public static string CAMERA_PATH97 = @"D:\VisionProgram\JOB\Cam97.vpp";
        public static string CAMERA_PATH98 = @"D:\VisionProgram\JOB\Cam98.vpp";
        public static string CAMERA_PATH99 = @"D:\VisionProgram\JOB\Cam99.vpp";
        public static string CAMERA_PATH100 = @"D:\VisionProgram\JOB\Cam100.vpp";
        public static string CAMERA_PATH101 = @"D:\VisionProgram\JOB\Cam101.vpp";
        public static string CAMERA_PATH102 = @"D:\VisionProgram\JOB\Cam102.vpp";
        public static string CAMERA_PATH103 = @"D:\VisionProgram\JOB\Cam103.vpp";
        public static string CAMERA_PATH104 = @"D:\VisionProgram\JOB\Cam104.vpp";
        public static string CAMERA_PATH105 = @"D:\VisionProgram\JOB\Cam105.vpp";
        public static string CAMERA_PATH106 = @"D:\VisionProgram\JOB\Cam106.vpp";
        public static string CAMERA_PATH107 = @"D:\VisionProgram\JOB\Cam107.vpp";
        public static string CAMERA_PATH108 = @"D:\VisionProgram\JOB\Cam108.vpp";
        public static string CAMERA_PATH109 = @"D:\VisionProgram\JOB\Cam109.vpp";
        public static string CAMERA_PATH110 = @"D:\VisionProgram\JOB\Cam110.vpp";
        public static string CAMERA_PATH111 = @"D:\VisionProgram\JOB\Cam111.vpp";
        public static string CAMERA_PATH112 = @"D:\VisionProgram\JOB\Cam112.vpp";
        public static string CAMERA_PATH113 = @"D:\VisionProgram\JOB\Cam113.vpp";
        public static string CAMERA_PATH114 = @"D:\VisionProgram\JOB\Cam114.vpp";
        public static string CAMERA_PATH115 = @"D:\VisionProgram\JOB\Cam115.vpp";
        public static string CAMERA_PATH116 = @"D:\VisionProgram\JOB\Cam116.vpp";
        public static string CAMERA_PATH117 = @"D:\VisionProgram\JOB\Cam117.vpp";
        public static string CAMERA_PATH118 = @"D:\VisionProgram\JOB\Cam118.vpp";
        public static string CAMERA_PATH119 = @"D:\VisionProgram\JOB\Cam119.vpp";
        public static string CAMERA_PATH120 = @"D:\VisionProgram\JOB\Cam120.vpp";
        public static string CAMERA_PATH121 = @"D:\VisionProgram\JOB\Cam121.vpp";
        public static string CAMERA_PATH122 = @"D:\VisionProgram\JOB\Cam122.vpp";
        public static string CAMERA_PATH123 = @"D:\VisionProgram\JOB\Cam123.vpp";
        public static string CAMERA_PATH124 = @"D:\VisionProgram\JOB\Cam124.vpp";
        public static string CAMERA_PATH125 = @"D:\VisionProgram\JOB\Cam125.vpp";
        public static string CAMERA_PATH126 = @"D:\VisionProgram\JOB\Cam126.vpp";
        public static string CAMERA_PATH127 = @"D:\VisionProgram\JOB\Cam127.vpp";
        public static string CAMERA_PATH128 = @"D:\VisionProgram\JOB\Cam128.vpp";

        #endregion

        public static string LogFile = @"D:\VisionProgram\Log\LogTxt1\";
        public static string ExceptionLogFile = @"D:\VisionProgram\Log\ExceptionLogTxt\";
        public static string OKImageSavePath = @"D:\VisionProgram\Image\OKImage\";
        public static string NGImageSavePath = @"D:\VisionProgram\Image\NGImage\";
        public static string DataPath = @"D:\VisionProgram\Data\";

        public static string Model = "";
        public static bool bNGSave = false;
        public static bool bAllSave = false;

        public static int nTotalCount = 0;
        public static int nPassCount = 0;
        public static int nFailCount = 0;

        public static bool bResult1 = false;
        public static double dResult1 = 0;
        public static string sResult2_1 = "";
        public static string sResult2_2 = "";

        public static double dScore = 0;
        public static double dScore1 = 0;

        public static int iModelNum = 0;
        public static string bModelNum = "";

        public static int iModelNum_Old = 0;

        public static int Result1LowerLimit = 0;
        public static int Result1UpperLimit = 0;
        public static string[] stringArray_Model;
        public static string[] stringArray_Limit;
        public static string[] stringArray_Offset;
        public static string[] stringArray_Score;
        public static string[] stringArray_AngleScore;


        public static string sInput1 = "0";
        public static string sInput2 = "0";
        public static string sInput3 = "0";
        public static string sInput4 = "0";
        public static string sInput5 = "0";
        public static string sInput6 = "0";
        public static string sInput7 = "0";
        public static string sInput8 = "0";


        public static int OutputDelay = 200;
        public static bool bIOCheck = false;
        public static int InputCheck1 = 0;
        public static int InputCheck_Old1 = 0;
        public static int InputCheck2 = 0;
        public static int InputCheck_Old2 = 0;

        public static Library lib = new Library();

        public static Stopwatch CAM1Stopwatch = new Stopwatch();

        #region IO 출력 변수

        public static short m_Id;
        public static Cdio dio = new Cdio();
        public static int[] m_UpCount = new int[8];
        public static int[] m_DownCount = new int[8];
        public static int CAMERA_NG_DelayTime = 0;

        #endregion


    }
}
