using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdioCs;

namespace chsj
{
    class PV
    {
        // 잡파일 경로
        public static string CAMERA1_PATH = @"D:\IVS\JOB\Cam1.vpp";
        public static string CAMERA2_PATH = @"D:\IVS\JOB\Cam2.vpp";
        public static string CAMERA3_PATH = @"D:\IVS\JOB\Cam3.vpp";
        public static string CAMERA4_PATH = @"D:\IVS\JOB\Cam4.vpp";

        // 로딩 데이터 경로 (e.g. Setting, Bypass, Offset...)
        public static string SettingDataPath = @"D:\IVS\SettingData";

        // 이미지 저장 경로
        public static string DirImage = @"D:\IVS_Image";
        // 로그 저장 경로
        public static string DirData = @"D:\IVS_Data";
        // 시스템 데이터 로그 저장 경로
        public static string DirSysLog = @"D:\IVS_SysLog";
 
        // IO Link 변수
        public static short m_Id;
        public static Cdio dio = new Cdio();
        public static int[] m_UpCount = new int[8];
        public static int[] m_DownCount = new int[8];
        public static byte InputData;

        // Inspection 변수

        public static bool bAlarmStop = false;
        public static bool bNG_Save = false;
        public static bool bALL_Save = false;
        public static bool bNgStop = false;


        public static int nCAM1TOTAL = 0;
        public static int nCAM1FAIL = 0;
        public static double nCAM1PER = 0;

        public static int nCAM2TOTAL = 0;
        public static int nCAM2FAIL = 0;
        public static double nCAM2PER = 0;

        public static int nCAM3TOTAL = 0;
        public static int nCAM3FAIL = 0;
        public static double nCAM3PER = 0;

        public static int nCAM4TOTAL = 0;
        public static int nCAM4FAIL = 0;
        public static double nCAM4PER = 0;


        public static bool bCAMERA1_State;
        public static bool bCAMERA2_State;
        public static bool bCAMERA3_State;
        public static bool bCAMERA4_State;

        public static int checkNG;
        public static int checkNG2;
        public static int checkNG3;
        public static int checkNG4;

        public static int checkOK;
        public static int checkOK2;
        public static int checkOK3;
        public static int checkOK4;

        //Cam1 - Form1
        //// 주름관
        // 상하한값
        public static double Pattern_Result_Score_11_Min;
        public static double Pattern_Result_Score_11_Max;
        public static double GetBlobs_Area_11_Min;
        public static double GetBlobs_Area_11_Max;
        public static double CogHistogramTool_Result_Mean_11_Min;
        public static double CogHistogramTool_Result_Mean_11_Max;

        // 바이패스
        public static bool bBypass_11;

        //결과
        public static string Pattern_Result_Score_11;
        public static string GetBlobs_Area_11;
        public static string CogHistogramTool_Result_Mean_11;

        // 오프셋
        public static double Pattern_Result_Score_11_Offset;
        public static double GetBlobs_Area_11_Offset;
        public static double CogHistogramTool_Result_Mean_11_Offset;



        ////// 민자관
        //// 상하한값
        //public static double Pattern_Result_Score_12_Min;
        //public static double Pattern_Result_Score_12_Max;
        //public static double GetBlobs_Area_12_Min;
        //public static double GetBlobs_Area_12_Max;
        //public static double CogHistogramTool_Result_Mean_12_Min;
        //public static double CogHistogramTool_Result_Mean_12_Max;

        //// 바이패스
        //public static bool bBypass_12;

        ////결과
        //public static string Pattern_Result_Score_12;
        //public static string GetBlobs_Area_12;
        //public static string CogHistogramTool_Result_Mean_12;

        //// 오프셋
        //public static double Pattern_Result_Score_12_Offset;
        //public static double GetBlobs_Area_12_Offset;
        //public static double CogHistogramTool_Result_Mean_12_Offset;


        //Cam2 - Form2
        //// 주름관
        // 상하한값
        public static double Pattern_Result_Score_21_Min;
        public static double Pattern_Result_Score_21_Max;
        public static double GetBlobs_Area_21_Min;
        public static double GetBlobs_Area_21_Max;
        public static double CogHistogramTool_Result_Mean_21_Min;
        public static double CogHistogramTool_Result_Mean_21_Max;

        // 바이패스
        public static bool bBypass_21;

        //결과
        public static string Pattern_Result_Score_21;
        public static string GetBlobs_Area_21;
        public static string CogHistogramTool_Result_Mean_21;

        // 오프셋
        public static double Pattern_Result_Score_21_Offset;
        public static double GetBlobs_Area_21_Offset;
        public static double CogHistogramTool_Result_Mean_21_Offset;

        ////// 민자관
        //// 상하한값
        //public static double Pattern_Result_Score_22_Min;
        //public static double Pattern_Result_Score_22_Max;
        //public static double GetBlobs_Area_22_Min;
        //public static double GetBlobs_Area_22_Max;
        //public static double CogHistogramTool_Result_Mean_22_Min;
        //public static double CogHistogramTool_Result_Mean_22_Max;

        //// 바이패스
        //public static bool bBypass_22;

        ////결과
        //public static string Pattern_Result_Score_22;
        //public static string GetBlobs_Area_22;
        //public static string CogHistogramTool_Result_Mean_22;

        //// 오프셋
        //public static double Pattern_Result_Score_22_Offset;
        //public static double GetBlobs_Area_22_Offset;
        //public static double CogHistogramTool_Result_Mean_22_Offset;


        //Cam3 - Form3
        //// 주름관
        // 상하한값
        public static double Pattern_Result_Score_31_Min;
        public static double Pattern_Result_Score_31_Max;
        public static double GetBlobs_Area_31_Min;
        public static double GetBlobs_Area_31_Max;
        public static double CogHistogramTool_Result_Mean_31_Min;
        public static double CogHistogramTool_Result_Mean_31_Max;

        // 바이패스
        public static bool bBypass_31;

        //결과
        public static string Pattern_Result_Score_31;
        public static string GetBlobs_Area_31;
        public static string CogHistogramTool_Result_Mean_31;

        // 오프셋
        public static double Pattern_Result_Score_31_Offset;
        public static double GetBlobs_Area_31_Offset;
        public static double CogHistogramTool_Result_Mean_31_Offset;

        ////// 민자관
        //// 상하한값
        //public static double Pattern_Result_Score_32_Min;
        //public static double Pattern_Result_Score_32_Max;
        //public static double GetBlobs_Area_32_Min;
        //public static double GetBlobs_Area_32_Max;
        //public static double CogHistogramTool_Result_Mean_32_Min;
        //public static double CogHistogramTool_Result_Mean_32_Max;

        //// 바이패스
        //public static bool bBypass_32;

        ////결과
        //public static string Pattern_Result_Score_32;
        //public static string GetBlobs_Area_32;
        //public static string CogHistogramTool_Result_Mean_32;

        //// 오프셋
        //public static double Pattern_Result_Score_32_Offset;
        //public static double GetBlobs_Area_32_Offset;
        //public static double CogHistogramTool_Result_Mean_32_Offset;


        //Cam4 - Form4
        //// 주름관
        // 상하한값
        public static double Pattern_Result_Score_41_Min;
        public static double Pattern_Result_Score_41_Max;
        public static double GetBlobs_Area_41_Min;
        public static double GetBlobs_Area_41_Max;
        public static double CogHistogramTool_Result_Mean_41_Min;
        public static double CogHistogramTool_Result_Mean_41_Max;

        // 바이패스
        public static bool bBypass_41;

        //결과
        public static string Pattern_Result_Score_41;
        public static string GetBlobs_Area_41;
        public static string CogHistogramTool_Result_Mean_41;

        // 오프셋
        public static double Pattern_Result_Score_41_Offset;
        public static double GetBlobs_Area_41_Offset;
        public static double CogHistogramTool_Result_Mean_41_Offset;

        ////// 민자관
        //// 상하한값
        //public static double Pattern_Result_Score_42_Min;
        //public static double Pattern_Result_Score_42_Max;
        //public static double GetBlobs_Area_42_Min;
        //public static double GetBlobs_Area_42_Max;
        //public static double CogHistogramTool_Result_Mean_42_Min;
        //public static double CogHistogramTool_Result_Mean_42_Max;

        //// 바이패스
        //public static bool bBypass_42;

        ////결과
        //public static string Pattern_Result_Score_42;
        //public static string GetBlobs_Area_42;
        //public static string CogHistogramTool_Result_Mean_42;

        //// 오프셋
        //public static double Pattern_Result_Score_42_Offset;
        //public static double GetBlobs_Area_42_Offset;
        //public static double CogHistogramTool_Result_Mean_42_Offset;

    }
}
