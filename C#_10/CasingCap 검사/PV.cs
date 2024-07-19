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


        public static string CAMERA_PATH1_1 = @"D:\VisionProgram\JOB\Cam1_1.vpp";
        public static string CAMERA_PATH1_2 = @"D:\VisionProgram\JOB\Cam1_2.vpp";
        public static string CAMERA_PATH1_3 = @"D:\VisionProgram\JOB\Cam1_3.vpp";
        public static string CAMERA_PATH1_4 = @"D:\VisionProgram\JOB\Cam1_4.vpp";
        public static string CAMERA_PATH1_5 = @"D:\VisionProgram\JOB\Cam1_5.vpp";


        public static string CAMERA_PATH2_1 = @"D:\VisionProgram\JOB\Cam2_1.vpp";
        public static string CAMERA_PATH2_2 = @"D:\VisionProgram\JOB\Cam2_2.vpp";
        public static string CAMERA_PATH2_3 = @"D:\VisionProgram\JOB\Cam2_3.vpp";
        public static string CAMERA_PATH2_4 = @"D:\VisionProgram\JOB\Cam2_4.vpp";
        public static string CAMERA_PATH2_5 = @"D:\VisionProgram\JOB\Cam2_5.vpp";

        public static string CAMERA_PATH3_1 = @"D:\VisionProgram\JOB\Cam3_1.vpp";
        public static string CAMERA_PATH3_2 = @"D:\VisionProgram\JOB\Cam3_2.vpp";
        public static string CAMERA_PATH3_3 = @"D:\VisionProgram\JOB\Cam3_3.vpp";
        public static string CAMERA_PATH3_4 = @"D:\VisionProgram\JOB\Cam3_4.vpp";
        public static string CAMERA_PATH3_5 = @"D:\VisionProgram\JOB\Cam3_5.vpp";

        public static string CAMERA_PATH4_1 = @"D:\VisionProgram\JOB\Cam4_1.vpp";
        public static string CAMERA_PATH4_2 = @"D:\VisionProgram\JOB\Cam4_2.vpp";
        public static string CAMERA_PATH4_3 = @"D:\VisionProgram\JOB\Cam4_3.vpp";
        public static string CAMERA_PATH4_4 = @"D:\VisionProgram\JOB\Cam4_4.vpp";
        public static string CAMERA_PATH4_5 = @"D:\VisionProgram\JOB\Cam4_5.vpp";

        public static string CAMERA_PATH5_1 = @"D:\VisionProgram\JOB\Cam5_1.vpp";
        public static string CAMERA_PATH5_2 = @"D:\VisionProgram\JOB\Cam5_2.vpp";
        public static string CAMERA_PATH5_3 = @"D:\VisionProgram\JOB\Cam5_3.vpp";
        public static string CAMERA_PATH5_4 = @"D:\VisionProgram\JOB\Cam5_4.vpp";
        public static string CAMERA_PATH5_5 = @"D:\VisionProgram\JOB\Cam5_5.vpp";

        #endregion

        public static string LogFile1 = @"D:\VisionProgram\Log\LogTxt1\";
        public static string LogFile2 = @"D:\VisionProgram\Log\LogTxt2\";
        public static string LogFile3 = @"D:\VisionProgram\Log\LogTxt3\";
        public static string LogFile4 = @"D:\VisionProgram\Log\LogTxt4\";
        public static string ExceptionLogFile = @"D:\VisionProgram\Log\ExceptionLogTxt\";
        public static string OKImageSavePath = @"D:\VisionProgram\Image\OKImage\";
        public static string NGImageSavePath = @"D:\VisionProgram\Image\NGImage\";
        public static string DataPath = @"D:\VisionProgram\LimitData\";
        public static string InspectionDataPath = @"D:\VisionProgram\Data\";

        public static string Model = "";
        public static bool bNGSave = false;
        public static bool bAllSave = false;
        public static int nModel = 0;
        public static int nLModel = 0;

        
        public static string sResult1 = "";
        public static string sResult2 = "";
        public static string sResult3 = "";
        public static string sResult4 = "";

        public static int nTotalCount1 = 0;
        public static int nPassCount1 = 0;
        public static int nFailCount1 = 0;

        public static int nTotalCount2 = 0;
        public static int nPassCount2 = 0;
        public static int nFailCount2 = 0;

        public static int nTotalCount3 = 0;
        public static int nPassCount3 = 0;
        public static int nFailCount3 = 0;

        public static int nTotalCount4 = 0;
        public static int nPassCount4 = 0;
        public static int nFailCount4 = 0;

        public static bool bBypass1 = false;
        public static bool bBypass2 = false;
        public static bool bBypass3 = false;
        public static bool bBypass4 = false;

        // 기준 데이터
        public static string[] stringArray_Limit1;
        public static string[] stringArray_Limit2;
        public static string[] stringArray_Limit3;
        public static string[] stringArray_Limit4;
        public static string[] stringArray_Limit5;

        public static bool bIOCheck = false;
        public static int InputCheck1 = 0;
        public static int InputCheck_Old1 = 0;
        public static int InputCheck2 = 0;
        public static int InputCheck_Old2 = 0;
        public static int InputCheck3 = 0;
        public static int InputCheck_Old3 = 0;
        public static int InputCheck4 = 0;
        public static int InputCheck_Old4 = 0;


        // 검사 결과
        public static double Cam1_Results_Item_0_Score = 0;
        public static double Cam1_Results_GetBlobs_Count = 0;
        public static double Cam1_Results_GetBlobs_Item_0_Area = 0;
        public static double Cam1_Results_GetBlobs_Count1 = 0;
        public static double Cam1_Results_GetBlobs_Item_0_Area1 = 0;
        public static double Cam1_Results_GetBlobs_Count2 = 0;
        public static double Cam1_Results_GetBlobs_Item_0_Area2 = 0;
        public static double Cam1_Result_Mean = 0;
        public static double Cam1_Result_StandardDeviation = 0;
        public static double Cam1_Result_Mean1 = 0;
        public static double Cam1_Result_StandardDeviation1 = 0;

        public static double Cam2_Results_Item_0_Score = 0;
        public static double Cam2_Results_GetBlobs_Count = 0;
        public static double Cam2_Results_GetBlobs_Item_0_Area = 0;
        public static double Cam2_Results_GetBlobs_Count1 = 0;
        public static double Cam2_Results_GetBlobs_Item_0_Area1 = 0;
        public static double Cam2_Results_GetBlobs_Count2 = 0;
        public static double Cam2_Results_GetBlobs_Item_0_Area2 = 0;
        public static double Cam2_Result_Mean = 0;
        public static double Cam2_Result_StandardDeviation = 0;
        public static double Cam2_Result_Mean1 = 0;
        public static double Cam2_Result_StandardDeviation1 = 0;

        public static double Cam3_Results_Item_0_Score = 0;
        public static double Cam3_Results_GetBlobs_Count = 0;
        public static double Cam3_Results_GetBlobs_Item_0_Area = 0;
        public static double Cam3_Results_GetBlobs_Count1 = 0;
        public static double Cam3_Results_GetBlobs_Item_0_Area1 = 0;
        public static double Cam3_Results_GetBlobs_Count2 = 0;
        public static double Cam3_Results_GetBlobs_Item_0_Area2 = 0;
        public static double Cam3_Result_Mean = 0;
        public static double Cam3_Result_StandardDeviation = 0;
        public static double Cam3_Result_Mean1 = 0;
        public static double Cam3_Result_StandardDeviation1 = 0;

        public static double Cam4_Results_Item_0_Score = 0;
        public static double Cam4_Results_GetBlobs_Count = 0;
        public static double Cam4_Results_GetBlobs_Item_0_Area = 0;
        public static double Cam4_Results_GetBlobs_Count1 = 0;
        public static double Cam4_Results_GetBlobs_Item_0_Area1 = 0;
        public static double Cam4_Results_GetBlobs_Count2 = 0;
        public static double Cam4_Results_GetBlobs_Item_0_Area2 = 0;
        public static double Cam4_Result_Mean = 0;
        public static double Cam4_Result_StandardDeviation = 0;
        public static double Cam4_Result_Mean1 = 0;
        public static double Cam4_Result_StandardDeviation1 = 0;



        public static Library lib = new Library();

        public static Stopwatch CAM1Stopwatch = new Stopwatch();
        public static Stopwatch CAM2Stopwatch = new Stopwatch();
        public static Stopwatch CAM3Stopwatch = new Stopwatch();
        public static Stopwatch CAM4Stopwatch = new Stopwatch();

        public static TimeSpan ts1;
        public static TimeSpan ts2;
        public static TimeSpan ts3;
        public static TimeSpan ts4;

        #region IO 출력 변수

        public static short m_Id;
        public static Cdio dio = new Cdio();
        public static int[] m_UpCount = new int[8];
        public static int[] m_DownCount = new int[8];
        public static int CAMERA_NG_DelayTime = 0;

        #endregion


    }
}
