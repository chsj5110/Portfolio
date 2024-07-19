using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chsj
{
    class PV
    {
        public static string CAMERA1_PATH = @"D:\VisionProgram\JOB\Cam1.vpp";
        public static string CAMERA2_PATH = @"D:\VisionProgram\JOB\Cam2.vpp";


        public static double dLLower = 0;
        public static double dLUpper = 0;
        public static double dCameraD = 0;              // 카메라 센터 거리
        public static double dDistanceL = 0;            // 왼쪽 검사 결과
        public static double dDistanceR = 0;            // 오른쪽 검사 결과
        public static double dResult = 0;               // 검사 후 거리 결과


    }
}
