using CdioCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chsj
{
    class PV
    {
        // 잡파일 경로
        public static string CAMERA1_1PATH = @"D:\\Vision Program\\JOB\\Cam1_1.vpp";
        public static string CAMERA2_1PATH = @"D:\\Vision Program\\JOB\\Cam2_1.vpp";

        public static string CAMERA1_2PATH = @"D:\\Vision Program\\JOB\\Cam1_2.vpp";
        public static string CAMERA2_2PATH = @"D:\\Vision Program\\JOB\\Cam2_2.vpp";

        public static string CAMERA1_3PATH = @"D:\\Vision Program\\JOB\\Cam1_3.vpp";
        public static string CAMERA2_3PATH = @"D:\\Vision Program\\JOB\\Cam2_3.vpp";

        public static string CAMERA1_4PATH = @"D:\\Vision Program\\JOB\\Cam1_4.vpp";
        public static string CAMERA2_4PATH = @"D:\\Vision Program\\JOB\\Cam2_4.vpp";

        public static string CAMERA1_5PATH = @"D:\\Vision Program\\JOB\\Cam1_5.vpp";
        public static string CAMERA2_5PATH = @"D:\\Vision Program\\JOB\\Cam2_5.vpp";

        // 로그 및 이미지 저장경로
        //public static string InIPath = Application.StartupPath + "D:\\VisionSoftware\\IVSSYSTEM\\Setting.ini";
        public static string NGImageSavePath = @"D:\\Image\NGImage\";                           //
        public static string OKImageSavePath = @"D:\\Image\OKImage\";
        public static string LogFile1 = @"D:\\Log\LogTxt1\";
        public static string LogFile2 = @"D:\\Log\LogTxt2\";   //
        public static string ExceptionLogFile = @"D:\\Log\ExceptionLogTxt\";
        public static string SystemDataLogFile = @"D:\\Log\SystemDataLogTxt\";
        public static string SystemDataLogFile2 = @"D:\\Log\SystemDataLogTxt2\";
        public static string DataFile = @"D:\Vision Program\Data\";

        public static Library lib = new Library();

        public static int nModel = 0;

        public static bool Run = false;

        public static bool bAlarmStop = false;
        public static bool bNG_Save = false;
        public static bool bALL_Save = false;
        public static bool bNgStop = false;

        public static bool bImage1Flag = false;
        public static bool bImage2Flag = false;

        public static int nGarbageCnt = 5;
        public static int nGarbageCnt2 = 5;

        public static string lbl_CAM1TIME_Str;
        public static string lbl_CAM2TIME_Str;

        public static int cnt = 0;

        public static int nCAM1TOTAL = 0;
        public static int nCAM1PASS = 0;
        public static double nCAM1PER = 0;
        public static int nCAM2TOTAL = 0;
        public static int nCAM2PASS = 0;
        public static double nCAM2PER = 0;

        public static bool CAMERA1BYPASS = false;
        public static bool CAMERA2BYPASS = false;

        public static bool bCAMERA1_State;
        public static bool bCAMERA2_State;

        public static int OKCnt = 0;
        public static int OKCnt2 = 0;

        public static int checkNG;
        public static int checkNG2;
        public static int checkOK;
        public static int checkOK2;

        public static bool CAM1Result = false;
        public static bool CAM2Result = false;
        public static bool CAM1ResultExist = false;
        public static bool CAM2ResultExist = false;


        //Cam1 - Form1
        public static double Pattern_Result_Score_Min;
        public static double Pattern_Result_Score_Max;
        public static double Inner_Diameter_Min;
        public static double Inner_Diameter_Max;
        public static double Concentricity_Left_Distance_Min;
        public static double Concentricity_Left_Distance_Max;
        public static double Concentricity_Right_Distance_Min;
        public static double Concentricity_Right_Distance_Max;
        public static double Left_Angle_Min;
        public static double Left_Angle_Max;
        public static double Right_Angle_Min;
        public static double Right_Angle_Max;

        public static bool bPattern_Result_Score;
        public static bool bInner_Diameter;
        public static bool bConcentricity_Left_Distance;
        public static bool bConcentricity_Right_Distance;
        public static bool bLeft_Angle;
        public static bool bRight_Angle;

        public static string Pattern_Result_Score;
        public static string Inner_Diameter;
        public static string Concentricity_Left_Distance;
        public static string Concentricity_Right_Distance;
        public static string Left_Angle;
        public static string Right_Angle;

        public static double Pattern_Result_Score_Offset;
        public static double Inner_Diameter_Offset;
        public static double Concentricity_Left_Distance_Offset;
        public static double Concentricity_Right_Distance_Offset;
        public static double Left_Angle_Offset;
        public static double Right_Angle_Offset;

        public static double Calib_Inner_Diameter;
        public static double Calib_Concentricity;
        public static double Calib_Angle;



        //Cam2 - Form2
        public static double Inner_Geometry_Min;
        public static double Inner_Geometry_Max;
        public static double Outer_Geometry_Min;
        public static double Outer_Geometry_Max;
        public static double GetBlobs_Area_Min;
        public static double GetBlobs_Area_Max;
        public static double Inner_Radius_Min;
        public static double Inner_Radius_Max;
        public static double Outer_Radius_Min;
        public static double Outer_Radius_Max;

        public static bool bInner_Geometry;
        public static bool bOuter_Geometry;
        public static bool bGetBlobs_Area;
        public static bool bInner_Radius;
        public static bool bOuter_Radius;

        public static string Inner_Geometry;
        public static string Outer_Geometry;
        public static string GetBlobs_Area;
        public static string Inner_Radius;
        public static string Outer_Radius;

        public static double Inner_Geometry_Offset;
        public static double Outer_Geometry_Offset;
        public static double GetBlobs_Area_Offset;
        public static double Inner_Radius_Offset;
        public static double Outer_Radius_Offset;

        public static double Calib_Inner_Radius;
        public static double Calib_Outer_Radius;

        #region IO 출력 변수

        public static short m_Id;
        public static Cdio dio = new Cdio();
        public static int[] m_UpCount = new int[8];
        public static int[] m_DownCount = new int[8];
        public static int CAMERA_NG_DelayTime = 0;
        public static byte InputData;

        public static bool bIOcheck = false;
        public static int InputCheck = 0 ;
        public static int InputCheck_Old = 0;

        #endregion

       
    }
}
