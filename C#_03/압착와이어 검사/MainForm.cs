using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cognex.VisionPro;
using Cognex.VisionPro.QuickBuild;
using Cognex.VisionPro.ToolGroup;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.Blob;
using System.Runtime.Serialization.Formatters.Binary;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.ImageProcessing;

using System.IO;
using Cognex.VisionPro.Display;

using CdioCs;
using System.Diagnostics;

namespace chsj
{

    public partial class MainForm : Form
    {
        #region Job Setting 변수

        private CogJobManager CAMERA1_JobManager = null;
        private CogJob CAMERA1_Job = null;
        private CogJobIndependent CAMERA1_JobIndependent = null;
        /*
        private string CAMERA1_1PATH = "C:\\Users\\Administrator\\Desktop\\Cam1_1.vpp";
        private string CAMERA1_2PATH = "C:\\Users\\Administrator\\Desktop\\Cam1_2.vpp";
        */
        private string CAMERA1_1PATH = "D:\\JOB\\Cam1_1.vpp";
        private string CAMERA1_2PATH = "D:\\JOB\\Cam1_2.vpp";
        private string CAMERA1_3PATH = "D:\\JOB\\Cam1_3.vpp";
        private string CAMERA1_4PATH = "D:\\JOB\\Cam1_4.vpp";
        private string CAMERA1_5PATH = "D:\\JOB\\Cam1_5.vpp";
        //private string CAMERA1_PATH = Application.StartupPath + "\\JOB\\Cam1.vpp";
        delegate void CAMERA1_Delegate(Object sender, CogJobManagerActionEventArgs e);

        private CogJobManager CAMERA2_JobManager = null;
        private CogJob CAMERA2_Job = null;
        private CogJobIndependent CAMERA2_JobIndependent = null;
        /*
        private string CAMERA2_1PATH = "C:\\Users\\Administrator\\Desktop\\Cam2_1.vpp";
        private string CAMERA2_2PATH = "C:\\Users\\Administrator\\Desktop\\Cam2_2.vpp";
        */
        private string CAMERA2_1PATH = "D:\\JOB\\Cam2_1.vpp";
        private string CAMERA2_2PATH = "D:\\JOB\\Cam2_2.vpp";
        private string CAMERA2_3PATH = "D:\\JOB\\Cam2_3.vpp";
        private string CAMERA2_4PATH = "D:\\JOB\\Cam2_4.vpp";
        private string CAMERA2_5PATH = "D:\\JOB\\Cam2_5.vpp";
        //private string CAMERA2_PATH = Application.StartupPath + "\\JOB\\Cam2.vpp";
        delegate void CAMERA2_Delegate(Object sender, CogJobManagerActionEventArgs e);

        #endregion

        #region Inspection Result Setting 변수

        CogToolGroup II_ToolGroup = null;
        CogToolBlock II_ToolBlock = null;
        CogHistogramTool II_HistogramTool = null;
        CogGraphicLabel II_GraphicLabelTool = null;
        CogFixtureTool CogFixtureTool1 = null;

        Library lib = new Library();


        #endregion

        #region Inspection Setting 변수

        CogPolygon CAMERA1_Region = new CogPolygon();
        CogPolygon CAMERA2_Region = new CogPolygon();

        CogImageFileTool ImageFileTool = new CogImageFileTool();

        CogImage8Grey TestImage = null;

        ICogRecord tmpRecord = null;
        ICogRecord topRecord = null;

        #endregion

        #region Inpsection System 변수


        string InIPath = Application.StartupPath + "D:\\VisionSoftware\\IVSSYSTEM\\Setting.ini";
        string NGImageSavePath = @"D:\NGImage\";
        string OKImageSavePath = @"D:\OKImage\";
        string LogFile1 = @"D:\LogTxt1\";
        string LogFile2 = @"D:\LogTxt2\";
        string ExceptionLogFile = @"D:\ExceptionLogTxt\";
        string SystemDataLogFile = @"D:\SystemDataLogTxt\";                       
        //string NGImageSavePath = @"C:\Users\son30\OneDrive\Desktop\NGImage\";
        //string OKImageSavePath = @"C:\Users\son30\OneDrive\Desktop\OKImage\";
        //string LogFile1 = @"C:\Users\son30\OneDrive\Desktop\LogTxt1\";
        //string LogFile2 = @"C:\Users\son30\OneDrive\Desktop\LogTxt2\";
        //string ExceptionLogFile = @"C:\Users\son30\OneDrive\Desktop\ExceptionLogTxt\";


        SettingInfo SettingIngInfo = new SettingInfo();

        CogCompositeShape CompositeShape = new CogCompositeShape();

        private string Model="";

        bool bNG_Save = false;
        bool bALL_Save = false;
        bool bNgStop = false;

        bool bImage1Flag = false;
        bool bImage2Flag = false;

        int nGarbageCnt = 5;
        int nGarbageCnt2 = 5;

        int cnt = 0;

        Stopwatch CAM1Stopwatch = new Stopwatch();
        Stopwatch CAM2Stopwatch = new Stopwatch();

        TimeSpan ts1;
        TimeSpan ts2;

        private int nCAM1TOTAL = 0;
        private int nCAM1FAIL = 0;
        private int nCAM2TOTAL = 0;
        private int nCAM2FAIL = 0;

        private bool CAMERA1BYPASS = false;
        private bool CAMERA2BYPASS = false;

        bool bCAMERA1_State;
        bool bCAMERA2_State;

        int OKCnt = 0;
        int OKCnt2 = 0;

        int NGCnt = 0;
        int NGCnt2 = 0;


        #endregion

        #region IO 출력 변수

        public short m_Id;
        Cdio dio = new Cdio();
        public int[] m_UpCount = new int[8];
        public int[] m_DownCount = new int[8];
        int CAMERA_NG_DelayTime = 0;

        #endregion

        #region Factory Info

        string Camera1_Hole_Threshold1 = "";
        string Camera1_Hole_Pixel1 = "";
        string Camera1_Black_Threshold2 = "";
        string Camera1_Black_Pixel2 = "";
        string Camera1_Twice_Threshold3 = "";
        string Camera1_Twice_Pixel3 = "";

        string Camera2_Hole_Threshold1 = "";
        string Camera2_Hole_Pixel1 = "";
        string Camera2_Black_Threshold2 = "";
        string Camera2_Black_Pixel2 = "";
        string Camera2_Twice_Threshold3 = "";
        string Camera2_Twice_Pixel3 = "";

        string Threshold_Offset_Value = "";
        string Pixel_Offset_Value = "";

        #endregion

        #region threshold pixel값 저장

        int Global_Offset_Threshold = 0;
        int Global_Offset_Pixel = 0;

        //camera1
        int Global_Camera1_Hole_Threshold;
        int Global_Camera1_Hole_Pixel;

        int Global_Camera1_Black_Threshold;
        int Global_Camera1_Black_Pixel;

        int Global_Camera1_Twice_Threshold;
        int Global_Camera1_Twice_Pixel;

        //camera2
        int Global_Camera2_Hole_Threshold;
        int Global_Camera2_Hole_Pixel;

        int Global_Camera2_Black_Threshold;
        int Global_Camera2_Black_Pixel;

        int Global_Camera2_Twice_Threshold;
        int Global_Camera2_Twice_Pixel;



        string Results_GetBlobs_Count;
        string RunParams_ConnectivityMinPixels;
        string Result_Mean;
        string RunStatus_TotalTime;
        string Results_GetBlobs_Item_0_Area;
        string RunParams_SegmentationParams;
        string Results_Item_0_Width;

        string Result = null;

        #endregion

        #region 시스템 이벤트

        public MainForm()
        {

            InitializeComponent();
            AdminSettingDisable();
            //CAMERA_JobInitialize();
            DioInit();
            IOTriggerStart();

            
            nCAM1TOTAL = 0;
            nCAM1FAIL = 0;
            nCAM2TOTAL = 0;
            nCAM2FAIL = 0;

            pic_CAM1_CONNECT_ON.Visible = false;
            pic_CAM1_CONNECT_OFF.Visible = true;

            pic_CAM2_CONNECT_ON.Visible = false;
            pic_CAM2_CONNECT_OFF.Visible = true;

            pic_CAM1BYPASS_ON.Visible = false;
            pic_CAM1BYPASS_OFF.Visible = true;

            pic_CAM2BYPASS_ON.Visible = false;
            pic_CAM2BYPASS_OFF.Visible = true;

            bCAMERA1_State = false;
            bCAMERA2_State = false;

            lbl_CAM1TotalCount.Text = nCAM1TOTAL.ToString();
            lbl_CAM1FailCount.Text = nCAM1FAIL.ToString();
            lbl_CAM2TotalCount.Text = nCAM2TOTAL.ToString();
            lbl_CAM2FailCount.Text = nCAM2FAIL.ToString();

            SystemDataLogWriter("Program Open");

        }

        private void btnRunningExecute_Click(object sender, EventArgs e)
        {

            if (Model == "")
            {
                MessageBox.Show("모델을 선택하세요");
                return;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
            }

           

            dio.Init("DIO001", out m_Id);

            
            try
            {
                IOOutPutMessage("2", "1");      //Program Start
                Delay(500);
                IOOutPutMessage("2", "0");      //Program Start

                IOOutPutMessage("3", "0");      // Yello Light(NG) Off
                IOOutPutMessage("4", "0");      // Green Light(Run) ON
                IOOutPutMessage("5", "0");      // Red Light(Stop) OFF
                IOOutPutMessage("6", "0");      // Buzzer(NG) OFF

                CAM1Stopwatch.Start();
                CAM2Stopwatch.Start();
                

                btnRunningExecute.BackColor = Color.Yellow;
                btnRunningExecute.Enabled = false;
                btnRunningStop.Enabled = true;
                btnReset.Enabled = false;

                btnCam1Apply.Enabled = false;
                btnCam2Apply.Enabled = false;

                bCAMERA1_State = true;
                bCAMERA2_State = true;

                


                bCAMERA1_State_Changed(sender, e);
                bCAMERA2_State_Changed(sender, e);
                

                SystemDataLogWriter("Program Start");
            }
            catch (Exception ex)
            {
                ExceptionWriter("btnRunningExecute_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRunningStop_Click(object sender, EventArgs e)
        {
            
            btnRunningExecute.BackColor = Color.Black;
            btnRunningExecute.Enabled = true;
            btnRunningStop.Enabled = false;
            btnReset.Enabled = true;

            btnCam1Apply.Enabled = true;
            btnCam2Apply.Enabled = true;

            bCAMERA1_State = false;
            bCAMERA2_State = false;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            

            bCAMERA1_State_Changed(sender, e);
            bCAMERA2_State_Changed(sender, e);

            

            if (CAM1Stopwatch.IsRunning)
            {
                CAM1Stopwatch.Stop();
            }
            if (CAM2Stopwatch.IsRunning)
            {
                CAM2Stopwatch.Stop();
            }

            SystemDataLogWriter("Program Stop");

            dio.Init("DIO001", out m_Id);
            Delay(500);
            IOOutPutMessage("0", "0");      // NG off
            IOOutPutMessage("1", "0");      // OK off
            IOOutPutMessage("2", "0");      // Program Start off

            IOOutPutMessage("3", "0");      // Yellow Light(NG) off
            IOOutPutMessage("4", "0");      // Green Light(Run) off
            IOOutPutMessage("5", "1");      // Red Light(Stop) Off

            IOOutPutMessage("6", "0");      // NG buzzer off
            IOOutPutMessage("7", "0");      // OK off
            

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            dio.Init("DIO001", out m_Id);
            IOOutPutMessage("0", "0");      // NG off
            IOOutPutMessage("1", "0");      // OK off
            IOOutPutMessage("2", "0");      // Program Start off

            IOOutPutMessage("3", "0");      // Yellow Light(NG) off
            IOOutPutMessage("4", "0");      // Green Light(Run) off
            IOOutPutMessage("5", "0");      // Red Light(Stop) ON

            IOOutPutMessage("6", "0");      // NG off
            IOOutPutMessage("7", "0");      // OK off


            dio.Exit(0);
            try
            {

                ProcessKill("IVSSYSTEM");

                this.Close();



            }
            catch (Exception ex)
            {
                ExceptionWriter("btnExit_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void pic_CAM1BYPASS_ON_Click(object sender, EventArgs e)
        {
            pic_CAM1BYPASS_OFF.Visible = true;
            pic_CAM1BYPASS_ON.Visible = false;
            CAMERA1BYPASS = false;

            SystemDataLogWriter("CAM1 Bypass : " + CAMERA1BYPASS);
        }

        private void pic_CAM1BYPASS_OFF_Click(object sender, EventArgs e)
        {
            pic_CAM1BYPASS_OFF.Visible = false;
            pic_CAM1BYPASS_ON.Visible = true;
            CAMERA1BYPASS = true;

            SystemDataLogWriter("CAM1 Bypass : " + CAMERA1BYPASS);

            f_invoke(IMG_Result1, global::chsj.Properties.Resources.PASS);

        }

        private void pic_CAM2BYPASS_ON_Click(object sender, EventArgs e)
        {
            pic_CAM2BYPASS_OFF.Visible = true;
            pic_CAM2BYPASS_ON.Visible = false;
            CAMERA2BYPASS = false;

            SystemDataLogWriter("CAM2 Bypass : " + CAMERA2BYPASS);
        }

        private void pic_CAM2BYPASS_OFF_Click(object sender, EventArgs e)
        {
            pic_CAM2BYPASS_OFF.Visible = false;
            pic_CAM2BYPASS_ON.Visible = true;
            CAMERA2BYPASS = true;

            SystemDataLogWriter("CAM2 Bypass : " + CAMERA2BYPASS);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ts1 = CAM1Stopwatch.Elapsed;
            string temp1 = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", ts1.Hours, ts1.Minutes, ts1.Seconds, ts1.Milliseconds);

            lbl_CAM1TIME.Text = temp1;

            ts2 = CAM2Stopwatch.Elapsed;
            string temp2 = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", ts2.Hours, ts2.Minutes, ts2.Seconds, ts2.Milliseconds);

            lbl_CAM2TIME.Text = temp2;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            lbl_CAM1TotalCount.Text = nCAM1TOTAL.ToString();
            lbl_CAM1FailCount.Text = nCAM1FAIL.ToString();
            lbl_CAM2TotalCount.Text = nCAM2TOTAL.ToString();
            lbl_CAM2FailCount.Text = nCAM2FAIL.ToString();

        }


        private void btn_BuzzOff_Click(object sender, EventArgs e)
        {
            try
            {
                IOOutPutMessage("6", "0");      // NG Buzzer OFF
            }
            catch (Exception ex)
            {
                ExceptionWriter("btn_BuzzOff_Click", ex.Message);
            }
        }

        private void bCAMERA1_State_Changed(object sender, EventArgs e)
        {

            try
            {
                if (bCAMERA1_State == true)
                {
                    CAMERA1_Job.RunContinuous();
                    btnCam1Apply.Enabled = false;

                    pic_CAM1_CONNECT_ON.Visible = true;
                    pic_CAM1_CONNECT_OFF.Visible = false;
                }
                else
                {
                    CAMERA1_Job.Stop();
                    btnCam1Apply.Enabled = true;

                    pic_CAM1_CONNECT_ON.Visible = false;
                    pic_CAM1_CONNECT_OFF.Visible = true;

                }
                //CAMERAStatus();
            }
            catch (Exception ex)
            {
                ExceptionWriter("bCAMERA1_State_CheckedChanged", ex.Message);
                btnRunningStop_Click(sender, e);
            }
        }

        private void bCAMERA2_State_Changed(object sender, EventArgs e)
        {
            try
            {
                if (bCAMERA2_State == true)
                {
                    btnCam2Apply.Enabled = false;
                    CAMERA2_Job.RunContinuous();

                    pic_CAM2_CONNECT_ON.Visible = true;
                    pic_CAM2_CONNECT_OFF.Visible = false;

                }
                else
                {
                    CAMERA2_Job.Stop();
                    btnCam2Apply.Enabled = true;

                    pic_CAM2_CONNECT_ON.Visible = false;
                    pic_CAM2_CONNECT_OFF.Visible = true;

                }
            }
            catch (Exception ex)
            {
                ExceptionWriter("bCAMERA2_State_CheckedChanged", ex.Message);
                btnRunningStop_Click(sender, e);
            }
        }

        private void btn_DelayTime_Click(object sender, EventArgs e)
        {
            try
            {
                string DelayTime = num_DelayTime.Value.ToString();
                SettingIngInfo.SettingWriteValue("SETTINGINFO", "DelayTime", DelayTime, InIPath);
                num_DelayTime.Value = CAMERA_NG_DelayTime = Convert.ToInt32(SettingIngInfo.SettingReadValue("SETTINGINFO", "DelayTime", InIPath));
                MessageBox.Show("적용되었습니다");
            }
            catch (Exception ex)
            {
                ExceptionWriter("btn_DelayTime_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void cbNG_Save_CheckedChanged(object sender, EventArgs e)
        {
            bNG_Save = cbNG_Save.Checked;
            SystemDataLogWriter("NG IMG Save : " + cbNG_Save.Checked);
        }
        

        private void cbALL_Save_CheckedChanged(object sender, EventArgs e)
        {
            bALL_Save = cbALL_Save.Checked;
            SystemDataLogWriter("NG IMG Save : " + cbALL_Save.Checked);
        }

        private void cbNgStop_CheckedChanged(object sender, EventArgs e)
        {
            bNgStop = cbNgStop.Checked;
            SystemDataLogWriter("NG Stop : " + cbNgStop.Checked);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            dio.Init("DIO001", out m_Id);
            IOOutPutMessage("0", "0");      // NG off
            IOOutPutMessage("1", "0");      // OK off
            IOOutPutMessage("2", "0");      // Program Start off

            IOOutPutMessage("3", "0");      // Yellow Light(NG) off
            IOOutPutMessage("4", "0");      // Green Light(Run) off
            IOOutPutMessage("5", "0");      // Red Light(Stop) ON

            IOOutPutMessage("6", "0");      // NG off
            IOOutPutMessage("7", "0");      // OK off


            dio.Exit(0);

            ProcessKill("IVSSYSTEM");

            
        }

        #endregion

        #region 시스템 메소드

        private void CAMERAStatus()
        {
            if (bCAMERA1_State || bCAMERA2_State)
            {
                btnRunningExecute.BackColor = Color.Yellow;
                btnRunningExecute.Enabled = false;
                btnRunningStop.Enabled = true;
            }
            else if (!bCAMERA1_State && !bCAMERA2_State)
            {
                btnRunningExecute.BackColor = Color.Black;
                btnRunningExecute.Enabled = true;
                btnRunningStop.Enabled = false;
            }
        }

        public void AdminSettingEnable()
        {
            btn_DelayTime.Enabled = true;
            num_DelayTime.Enabled = true;
        }

        private void AdminSettingDisable()
        {
            btn_DelayTime.Enabled = false;
            num_DelayTime.Enabled = false;
        }

        private void CAMERA_JobInitialize()
        {
            try
            {
                if (Model == "3mm")
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(CAMERA1_1PATH) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(CAMERA2_1PATH) as CogJobManager;
                }
                else if (Model == "4mm")
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(CAMERA1_2PATH) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(CAMERA2_2PATH) as CogJobManager;
                }
                else if (Model == "5mm")
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(CAMERA1_3PATH) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(CAMERA2_3PATH) as CogJobManager;
                }
                else if (Model == "6mm")
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(CAMERA1_4PATH) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(CAMERA2_4PATH) as CogJobManager;
                }
                else if (Model == "7mm")
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(CAMERA1_5PATH) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(CAMERA2_5PATH) as CogJobManager;
                }



                CAMERA1_Job = CAMERA1_JobManager.Job(0);
                CAMERA1_JobIndependent = CAMERA1_Job.OwnedIndependent;
                CAMERA1_JobManager.UserQueueFlush();
                CAMERA1_JobManager.FailureQueueFlush();
                CAMERA1_Job.ImageQueueFlush();
                CAMERA1_JobIndependent.RealTimeQueueFlush();
                CAMERA1_JobManager.UserResultAvailable += new CogJobManager.CogUserResultAvailableEventHandler(CAMERA1_UserResultAvailable);


                
                CAMERA2_Job = CAMERA2_JobManager.Job(0);
                CAMERA2_JobIndependent = CAMERA2_Job.OwnedIndependent;
                CAMERA2_JobManager.UserQueueFlush();
                CAMERA2_JobManager.FailureQueueFlush();
                CAMERA2_Job.ImageQueueFlush();
                CAMERA2_JobIndependent.RealTimeQueueFlush();
                CAMERA2_JobManager.UserResultAvailable += new CogJobManager.CogUserResultAvailableEventHandler(CAMERA2_UserResultAvailable);

                II_ToolGroup = CAMERA1_Job.VisionTool as CogToolGroup;
                num_CAMERA1_threshold.Value = ((CogBlobTool)II_ToolGroup.Tools["CogBlobTool1"]).RunParams.SegmentationParams.HardFixedThreshold;
                num_CAMERA1_pixel.Value = ((CogBlobTool)II_ToolGroup.Tools["CogBlobTool1"]).RunParams.ConnectivityMinPixels;
                // 40-10
                II_ToolGroup = CAMERA2_Job.VisionTool as CogToolGroup;
                num_CAMERA2_threshold.Value = ((CogBlobTool)II_ToolGroup.Tools["CogBlobTool1"]).RunParams.SegmentationParams.HardFixedThreshold;
                num_CAMERA2_pixel.Value = ((CogBlobTool)II_ToolGroup.Tools["CogBlobTool1"]).RunParams.ConnectivityMinPixels;
                // 128-10
            }
            catch (Exception ex)
            {
                ExceptionWriter("CAMERA_JobInitialize", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }



        public void LogWriter1(string Results_GetBlobs_Count, string RunParams_ConnectivityMinPixels, string Result_Mean, string RunStatus_TotalTime, string Results_GetBlobs_Item_0_Area, string RunParams_SegmentationParams, string Results_Item_0_Width)
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

                string Path = LogFile1 + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = lib.getTime("YYMMDD");


                if (Results_GetBlobs_Count == "0")
                {
                    Result = "OK";
                }
                else
                {
                    Result = "NG";
                }


                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("날짜");
                    row.Add("검사시간");
                    row.Add("Result");
                    row.Add("Results_GetBlobs_Count");
                    row.Add("RunParams_ConnectivityMinPixels");
                    row.Add("Result_Mean");
                    row.Add("RunStatus_TotalTime");
                    row.Add("Results_GetBlobs_Item_0_Area");
                    row.Add("RunParams_SegmentationParams_HardFixedThreshold");
                    row.Add("Results_Item_0_Width");


                    row.Add("\r\n" + Logtime);
                    row.Add(lbl_CAM1TIME.Text);
                    row.Add(Result);
                    row.Add(Results_GetBlobs_Count);
                    row.Add(RunParams_ConnectivityMinPixels);
                    row.Add(Result_Mean);
                    row.Add(RunStatus_TotalTime);
                    row.Add(Results_GetBlobs_Item_0_Area);
                    row.Add(RunParams_SegmentationParams);
                    row.Add(Results_Item_0_Width);



                }
                else         // Path Exist
                {
                    row.Add(Logtime);
                    row.Add(lbl_CAM1TIME.Text);
                    row.Add(Result);
                    row.Add(Results_GetBlobs_Count);
                    row.Add(RunParams_ConnectivityMinPixels);
                    row.Add(Result_Mean);
                    row.Add(RunStatus_TotalTime);
                    row.Add(Results_GetBlobs_Item_0_Area);
                    row.Add(RunParams_SegmentationParams);
                    row.Add(Results_Item_0_Width);
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                ExceptionWriter("LogWriter1", ex.Message);
            }
        }

        public void LogWriter2(string Results_GetBlobs_Count, string RunParams_ConnectivityMinPixels, string Result_Mean, string RunStatus_TotalTime, string Results_GetBlobs_Item_0_Area, string RunParams_SegmentationParams, string Results_Item_0_Width)
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

                string Path = LogFile2 + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = lib.getTime("YYMMDD");


                if (Results_GetBlobs_Count == "0")
                {
                    Result = "OK";
                }
                else
                {
                    Result = "NG";
                }


                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("날짜");
                    row.Add("검사시간");
                    row.Add("Result");
                    row.Add("Results_GetBlobs_Count");
                    row.Add("RunParams_ConnectivityMinPixels");
                    row.Add("Result_Mean");
                    row.Add("RunStatus_TotalTime");
                    row.Add("Results_GetBlobs_Item_0_Area");
                    row.Add("RunParams_SegmentationParams_HardFixedThreshold");
                    row.Add("Results_Item_0_Width");


                    row.Add("\r\n" + Logtime);
                    row.Add(lbl_CAM2TIME.Text);
                    row.Add(Result);
                    row.Add(Results_GetBlobs_Count);
                    row.Add(RunParams_ConnectivityMinPixels);
                    row.Add(Result_Mean);
                    row.Add(RunStatus_TotalTime);
                    row.Add(Results_GetBlobs_Item_0_Area);
                    row.Add(RunParams_SegmentationParams);
                    row.Add(Results_Item_0_Width);



                }
                else         // Path Exist
                {
                    row.Add(Logtime);
                    row.Add(lbl_CAM2TIME.Text);
                    row.Add(Result);
                    row.Add(Results_GetBlobs_Count);
                    row.Add(RunParams_ConnectivityMinPixels);
                    row.Add(Result_Mean);
                    row.Add(RunStatus_TotalTime);
                    row.Add(Results_GetBlobs_Item_0_Area);
                    row.Add(RunParams_SegmentationParams);
                    row.Add(Results_Item_0_Width);
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                ExceptionWriter("LogWriter2", ex.Message);
            }
        }

        

        public void SystemDataLogWriter(string Message)
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

                string Path = SystemDataLogFile + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = lib.getTime("YYMMDD");




                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("날짜");
                    row.Add("Message");


                    row.Add("\r\n" + Logtime);
                    row.Add(Message);



                }
                else         // Path Exist
                {
                    row.Add(Logtime);
                    row.Add(Message);
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                ExceptionWriter("SystemDataLogWriter", ex.Message);
            }
        }


        private void ExceptionWriter(string ErrorLocation, string ErrorMessage)
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

                string Path = ExceptionLogFile + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);


                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("ErrorTime");
                    row.Add("NGLocation");
                    row.Add("NGMessage");



                    row.Add("\r\n" + ErrorTime);
                    row.Add(ErrorLocation);
                    row.Add(ErrorMessage);


                }
                else
                {


                    row.Add("\r\n" + ErrorTime);
                    row.Add(ErrorLocation);
                    row.Add(ErrorMessage);
                }

                writer.WriteCSV(row, Path + CreateFileName);

            }
            catch (Exception ex)
            {
                ExceptionWriter("NGExceptionWriter", ex.Message);
            }
        }


        private string NGImageSave(string ErrorMessage, int CameraNumber, string NgName)
        {
            string strMonth = DateTime.Now.Month.ToString();
            string strDay = DateTime.Now.Day.ToString();
            string strHour = DateTime.Now.Hour.ToString();
            string strMinute = DateTime.Now.Minute.ToString();
            string strSecond = DateTime.Now.Second.ToString();
            string strMilSecond = DateTime.Now.Millisecond.ToString();

            string strCamera_Number;
            string tempStr = NgName;

            if (CameraNumber == 1)
            {
                strCamera_Number = "카메라1";
            }
            else if (CameraNumber == 2)
            {
                strCamera_Number = "카메라2";
            }
            else if (CameraNumber == 3)
            {
                strCamera_Number = "카메라3";
            }
            else
            {
                strCamera_Number = "카메라4";
            }

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

            string CreateFolderName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\" + txt_LotNo.Text + "\\" + strCamera_Number + "\\";
            string CreateFileName = strHour + "_" + strMinute + "_" + strSecond + "_" + strMilSecond + "_" + strCamera_Number + NgName;

            DirectoryInfo dir = new DirectoryInfo(NGImageSavePath + CreateFolderName);

            if (dir.Exists == false)
            {
                dir.Create();
            }

            string filePath = NGImageSavePath + CreateFolderName + CreateFileName + ".jpg";
            return filePath;

        }

        private string OKImageSave(int CameraNumber, string NgName)
        {
            string strMonth = DateTime.Now.Month.ToString();
            string strDay = DateTime.Now.Day.ToString();
            string strHour = DateTime.Now.Hour.ToString();
            string strMinute = DateTime.Now.Minute.ToString();
            string strSecond = DateTime.Now.Second.ToString();
            string strMilSecond = DateTime.Now.Millisecond.ToString();

            string strCamera_Number;
            string tempStr = NgName;

            if (CameraNumber == 1)
            {
                strCamera_Number = "카메라1";
            }
            else if (CameraNumber == 2)
            {
                strCamera_Number = "카메라2";
            }
            else if (CameraNumber == 3)
            {
                strCamera_Number = "카메라3";
            }
            else
            {
                strCamera_Number = "카메라4";
            }

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

            string CreateFolderName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\" + txt_LotNo.Text + "\\" + strCamera_Number + "\\";
            string CreateFileName = strHour + "_" + strMinute + "_" + strSecond + "_" + strMilSecond + "_" + strCamera_Number + tempStr;

            DirectoryInfo dir = new DirectoryInfo(OKImageSavePath + CreateFolderName);

            if (dir.Exists == false)
            {
                dir.Create();
            }

            string filePath = OKImageSavePath + CreateFolderName + CreateFileName + ".jpg";
            return filePath;

        }


        private static void ProcessKill(string processName)
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

        #region 검사 이벤트
        
    void CAMERA1_UserResultAvailable(object sender, CogJobManagerActionEventArgs e)
        {


            if (InvokeRequired)
            {
                Invoke(new CAMERA1_Delegate(CAMERA1_UserResultAvailable), new object[] { sender, e });
                return;
            }

            try
            {

                if (bImage1Flag == false)
                    bImage1Flag = true;
                else
                    bImage1Flag = false;

                II_ToolGroup = CAMERA1_Job.VisionTool as CogToolGroup;
                II_ToolBlock = II_ToolGroup.Tools["CogToolBlock1"] as CogToolBlock;
                CogFixtureTool CogFixtureTool1 = II_ToolGroup.Tools["CogFixtureTool1"] as CogFixtureTool;


                int value1;
                string ToolName = "";
                string FileName = "0";

                CogFindLineTool CogFindLineTool1 = II_ToolGroup.Tools["CogFindLineTool1"] as CogFindLineTool;

                bool GetLine = false;
                string sGetLine = Convert.ToString(II_ToolBlock.Outputs["Results_GetLine_Y"].Value);
                double returnGetLine = 0;

                bool bGetLine = double.TryParse(Convert.ToString(II_ToolBlock.Outputs["Results_GetLine_Y"].Value), out returnGetLine);


                if (bGetLine)
                {
                    GetLine = true;
                }


                if (GetLine == false)                                           // 와이어없음
                {
                    if (bImage1Flag == true)
                    {
                        Cam1_Run();
                    }
                    CAMERA1_NG();
                    timer1_Tick(sender, e);
                    LogWriter1("와이어 없음", "", "", "", "", "","");

                    // 와이어 없음은 사진 저장x

                }
                else                                                          // 와이어있음
                {



                    Cam1_Run();
                    LogWriter1(Results_GetBlobs_Count, RunParams_ConnectivityMinPixels, Result_Mean, RunStatus_TotalTime, Results_GetBlobs_Item_0_Area, RunParams_SegmentationParams, Results_Item_0_Width);

                    if (Results_GetBlobs_Count == "0")                                               // OK
                    {
                        //OKCnt++;

                        //int ChkOkCnt = OKCnt % 10;
                        //if (ChkOkCnt == 0)                                // fail count
                        //{
                        if (bALL_Save)
                        {
                            FileName = OKImageSave(1, ToolName);
                            ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                            ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                            ImageFileTool.Run();
                            ImageFileTool.Operator.Close();
                        }


                        CAMERA1_OK();
                        timer3_Tick(sender, e);
                        timer1_Tick(sender, e);

                       

                        //}
                    }
                    else                                                                              // NG
                    {

                        if (CAMERA1BYPASS == true)                                                   // NG but Bypass
                        {

                            //OKCnt++;
                            //int ChkOkCnt = OKCnt % 10;
                            //if (ChkOkCnt == 0)
                            //{
                            if (bImage1Flag == true)
                            {
                            }

                            if (bALL_Save == true)
                            {
                                FileName = OKImageSave(1, ToolName);
                                ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                                ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                                ImageFileTool.Run();
                                ImageFileTool.Operator.Close();

                            }

                            if (bNG_Save)
                            { }

                            CAMERA1_OK();
                            timer3_Tick(sender, e);
                            timer1_Tick(sender, e);
                            //}

                        }

                        else                                                                                // totally NG

                        {
                            ToolName = "NG";

                            CAMERA1_NG();
                            timer3_Tick(sender, e);


                            if (bNG_Save == true)
                            {

                                FileName = NGImageSave("NG", 1, ToolName);

                                ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                                ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                                ImageFileTool.Run();
                                ImageFileTool.Operator.Close();
                            }

                            if (bALL_Save == true)
                            {
                                FileName = NGImageSave("NG", 1, ToolName);
                                ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                                ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                                ImageFileTool.Run();
                                ImageFileTool.Operator.Close();

                            }
                            timer1_Tick(sender, e);

                            
                            
                        }


                    }
                }
                    
            }
            catch (Exception ex)
            {
                ExceptionWriter("CAMERA1_UserResultAvailable", ex.Message);
                MessageBox.Show(ex.Message);
            }




        }
        void Cam1_Run()
        {

            ICogRecord topRecord = null;
            topRecord = CAMERA1_JobManager.UserResult();
            ICogRecord tmpRecord = null;
            tmpRecord = topRecord.SubRecords["ShowLastRunRecordForUserQueue"];
            tmpRecord = tmpRecord.SubRecords["LastRun"];
            tmpRecord = tmpRecord.SubRecords["Image Source.OutputImage"];

            cogRecordDisplay_CAMERA1.Record = tmpRecord;
            cogRecordDisplay_CAMERA1.AutoFit = true;
            cogRecordDisplay_CAMERA1.Zoom = 1.33;



            Results_GetBlobs_Count = Convert.ToString(II_ToolBlock.Outputs["Results_GetBlobs_Count"].Value);
            RunParams_ConnectivityMinPixels = Convert.ToString(II_ToolBlock.Outputs["RunParams_ConnectivityMinPixels"].Value);
            Result_Mean = Convert.ToString(II_ToolBlock.Outputs["Result_Mean"].Value);
            RunStatus_TotalTime = Convert.ToString(II_ToolBlock.Outputs["RunStatus_TotalTime"].Value);
            Results_GetBlobs_Item_0_Area = Convert.ToString(II_ToolBlock.Outputs["Results_GetBlobs_Item_0_Area"].Value);
            RunParams_SegmentationParams = Convert.ToString(II_ToolBlock.Outputs["RunParams_SegmentationParams_HardFixedThreshold"].Value);
            Results_Item_0_Width = Convert.ToString(II_ToolBlock.Outputs["Results_Item_0_Width"].Value);





        }


        void CAMERA2_UserResultAvailable(object sender, CogJobManagerActionEventArgs e)
        {


            if (InvokeRequired)
            {
                Invoke(new CAMERA2_Delegate(CAMERA2_UserResultAvailable), new object[] { sender, e });
                return;
            }

            try
            {

                if (bImage2Flag == false)
                    bImage2Flag = true;
                else
                    bImage2Flag = false;

                II_ToolGroup = CAMERA2_Job.VisionTool as CogToolGroup;
                II_ToolBlock = II_ToolGroup.Tools["CogToolBlock1"] as CogToolBlock;
                CogFixtureTool CogFixtureTool1 = II_ToolGroup.Tools["CogFixtureTool1"] as CogFixtureTool;

                
                string ToolName = "";
                string FileName = "0";

                CogFindLineTool CogFindLineTool1 = II_ToolGroup.Tools["CogFindLineTool1"] as CogFindLineTool;
                
                bool GetLine = false;
                string sGetLine = Convert.ToString(II_ToolBlock.Outputs["Results_GetLine_Y"].Value);
                double returnGetLine = 0;

                bool bGetLine = double.TryParse(Convert.ToString(II_ToolBlock.Outputs["Results_GetLine_Y"].Value), out returnGetLine);

                if (bGetLine)
                {
                    GetLine = true;
                }


                if (GetLine == false)                                           // 와이어없음
                {
                    if (bImage2Flag == true)
                    {
                        Cam2_Run();
                    }
                    CAMERA2_NG();
                    timer1_Tick(sender, e);
                    LogWriter2("와이어 없음", "", "", "", "", "","");

                    // 와이어 없음은 사진 저장x

                }
                else                                                          // 와이어있음
                {

                    Cam2_Run();
                    LogWriter2(Results_GetBlobs_Count, RunParams_ConnectivityMinPixels, Result_Mean, RunStatus_TotalTime, Results_GetBlobs_Item_0_Area, RunParams_SegmentationParams, Results_Item_0_Width);
                    if (Results_GetBlobs_Count == "0")                                               // OK
                    {
                        //OKCnt++;

                        //int ChkOkCnt = OKCnt % 10;
                        //if (ChkOkCnt == 0)
                        //{
                        if (bALL_Save)
                        {
                            FileName = OKImageSave(2, ToolName);
                            ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                            ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                            ImageFileTool.Run();
                            ImageFileTool.Operator.Close();
                        }


                        CAMERA2_OK();
                        timer3_Tick(sender, e);
                        timer1_Tick(sender, e);

                        //}
                    }
                    else                                                                              // NG
                    {

                        if (CAMERA2BYPASS == true)                                                   // NG but Bypass
                        {

                            //OKCnt++;
                            //int ChkOkCnt = OKCnt % 10;
                            //if (ChkOkCnt == 0)
                            //{
                            if (bImage2Flag == true)
                            {
                            }

                            if (bALL_Save == true)
                            {
                                FileName = OKImageSave(2, ToolName);
                                ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                                ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                                ImageFileTool.Run();
                                ImageFileTool.Operator.Close();

                            }

                            if (bNG_Save)
                            { }

                            CAMERA2_OK();
                            timer3_Tick(sender, e);
                            timer1_Tick(sender, e);
                            //}

                        }

                        else                                                                                // totally NG

                        {
                            ToolName = "NG";

                            CAMERA2_NG();
                            timer3_Tick(sender, e);


                            if (bNG_Save == true)
                            {

                                FileName = NGImageSave("NG", 2, ToolName);

                                ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                                ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                                ImageFileTool.Run();
                                ImageFileTool.Operator.Close();
                            }

                            if (bALL_Save == true)
                            {
                                FileName = NGImageSave("NG", 2, ToolName);
                                ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                                ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                                ImageFileTool.Run();
                                ImageFileTool.Operator.Close();

                            }
                            timer1_Tick(sender, e);

                            
                            
                        }


                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionWriter("CAMERA2_UserResultAvailable", ex.Message);
                MessageBox.Show(ex.Message);
            }




        }
        void Cam2_Run()
        {

            ICogRecord topRecord = null;
            topRecord = CAMERA2_JobManager.UserResult();
            ICogRecord tmpRecord = null;
            tmpRecord = topRecord.SubRecords["ShowLastRunRecordForUserQueue"];
            tmpRecord = tmpRecord.SubRecords["LastRun"];
            tmpRecord = tmpRecord.SubRecords["Image Source.OutputImage"];

            cogRecordDisplay_CAMERA2.Record = tmpRecord;
            cogRecordDisplay_CAMERA2.AutoFit = true;
            cogRecordDisplay_CAMERA2.Zoom = 1.33;



            Results_GetBlobs_Count = Convert.ToString(II_ToolBlock.Outputs["Results_GetBlobs_Count"].Value);
            RunParams_ConnectivityMinPixels = Convert.ToString(II_ToolBlock.Outputs["RunParams_ConnectivityMinPixels"].Value);
            Result_Mean = Convert.ToString(II_ToolBlock.Outputs["Result_Mean"].Value);
            RunStatus_TotalTime = Convert.ToString(II_ToolBlock.Outputs["RunStatus_TotalTime"].Value);
            Results_GetBlobs_Item_0_Area = Convert.ToString(II_ToolBlock.Outputs["Results_GetBlobs_Item_0_Area"].Value);
            RunParams_SegmentationParams = Convert.ToString(II_ToolBlock.Outputs["RunParams_SegmentationParams_HardFixedThreshold"].Value);
            Results_Item_0_Width = Convert.ToString(II_ToolBlock.Outputs["Results_Item_0_Width"].Value);




        }

        #endregion
        

        #region "IO 출력"

        private void DioInit()
        {
            // Initialization handling
            int Ret;
            Ret = dio.Init("DIO001", out m_Id);

            string ErrorString;
            dio.GetErrorString(Ret, out ErrorString);
            if (Ret != (int)CdioConst.DIO_ERR_SUCCESS)
            {
                return;
            }
        }

        private void IOTriggerStart()
        {
            int Ret = 0;
            short TrgBit;
            short TrgKind;
            int Tim;
            //-----------------------------
            // Parameters initialization
            //-----------------------------
            for (TrgBit = 0; TrgBit < 8; TrgBit++)
            {
                m_UpCount[TrgBit] = 0;		// Up counter
                m_DownCount[TrgBit] = 0;	// Down counter
            }
            //-----------------------------
            // Witch check
            //-----------------------------
            Tim = 100;																// Observe in cycle 100ms
            TrgKind = (short)CdioConst.DIO_TRG_RISE | (short)CdioConst.DIO_TRG_FALL;	// Observe both of Up/Down
            for (TrgBit = 0; TrgBit < 1; TrgBit++)
            {
                //-----------------------------
                // Trigger start
                //-----------------------------
                if (true)
                {
                    Ret = dio.NotifyTrg(m_Id, TrgBit, TrgKind, Tim, this.Handle.ToInt32());
                    if (Ret != (int)CdioConst.DIO_ERR_SUCCESS)
                    {
                        break;
                    }
                }
                //-----------------------------
                // Tigger stop
                //-----------------------------
                //else
                //{
                //    Ret = dio.StopNotifyTrg(m_Id, TrgBit);
                //    if (Ret != (int)CdioConst.DIO_ERR_SUCCESS)
                //    {
                //        break;
                //    }
                //}
            }
            //-----------------------------
            // Error process
            //-----------------------------
            string ErrorString;
            dio.GetErrorString(Ret, out ErrorString);
            //textBox_ReturnCode.Text = "Ret = " + System.Convert.ToString(Ret) + " : " + ErrorString;
        }

        private void IOOutPutMessage(string LogicBitNo, string OutPutData)
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
            Ret = dio.OutBit(m_Id, OutBitNo, OutBitData);

            //-----------------------------
            // Error process
            //-----------------------------
            string ErrorString;
            dio.GetErrorString(Ret, out ErrorString);

            //MessageBox.Show(ErrorString);

            if (Ret != (int)CdioConst.DIO_ERR_SUCCESS)
            {
                return;
            }


        }

        private void CAMERA1_NG()
        {
            nCAM1FAIL++;
            nCAM1TOTAL++;

            IOOutPutMessage("1", "0");  //OK off
            IOOutPutMessage("0", "1");  //NG on

            IOOutPutMessage("4", "0");      // Green Light(Run) off
            IOOutPutMessage("3", "1");      // Yellow Light(NG) on
            IOOutPutMessage("7", "0");      //OK off

            if (bNgStop == true)
            {
                IOOutPutMessage("6", "1");      //NG Buzzer on
                IOOutPutMessage("5", "1");      // Red Light(stop) on

                if (CAM1Stopwatch.IsRunning)
                {
                    CAM1Stopwatch.Stop();
                }
                if (CAM2Stopwatch.IsRunning)
                {
                    CAM2Stopwatch.Stop();
                }

                CAMERA1_Job.Stop();
                CAMERA2_Job.Stop();

            }

            timer2.Enabled = true;

            IMG_Result1.Image = Properties.Resources.fail;


        }

        private void CAMERA1_OK()
        {

            IOOutPutMessage("0", "0");  //NG off
            IOOutPutMessage("1", "1");  //OK on

            IOOutPutMessage("3", "0");   // Yellow Light(NG) off
            IOOutPutMessage("5", "0");   // Red Light(Stop) off
            IOOutPutMessage("4", "1");   // Green Light(OK) on

            IOOutPutMessage("7", "1");  //OK on
            IOOutPutMessage("6", "0");  //Buzzer off

            timer2.Enabled = true;

            IMG_Result1.Image = Properties.Resources.PASS;
            nCAM1TOTAL++;

        }


        private void CAMERA2_NG()
        {
            nCAM2FAIL++;
            nCAM2TOTAL++;

            IOOutPutMessage("1", "0");  //OK off
            IOOutPutMessage("0", "1");  //NG on

            IOOutPutMessage("4", "0");      // Green Light(Run) off
            IOOutPutMessage("3", "1");      // Yellow Light(NG) on
            IOOutPutMessage("7", "0");      //OK off


            if (bNgStop == true)
            {
                IOOutPutMessage("6", "1");      //NG Buzzer on
                IOOutPutMessage("5", "1");      // Red Light(stop) on

                if (CAM1Stopwatch.IsRunning)
                {
                    CAM1Stopwatch.Stop();
                }
                if (CAM2Stopwatch.IsRunning)
                {
                    CAM2Stopwatch.Stop();
                }

                CAMERA1_Job.Stop();
                CAMERA2_Job.Stop();

            }


            timer2.Enabled = true;

            IMG_Result2.Image = Properties.Resources.fail;

        }


        private void CAMERA2_OK()
        {

            IOOutPutMessage("0", "0");  //NG off
            IOOutPutMessage("1", "1");  //OK on

            IOOutPutMessage("3", "0");   // Yellow Light(NG) off
            IOOutPutMessage("5", "0");   // Red Light(Stop) off
            IOOutPutMessage("4", "1");   // Green Light(OK) on

            IOOutPutMessage("7", "1");  //OK on
            IOOutPutMessage("6", "0");  //Buzzer off

            timer2.Enabled = true;

            IMG_Result2.Image = Properties.Resources.PASS;
            nCAM2TOTAL++;
        }

        #endregion

        #region "etc"

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control)
                {
                    if (e.Alt)
                    {
                        if (e.KeyCode == Keys.A)
                        {
                            //FactoryReset dlg = new FactoryReset();
                            //dlg.StartPosition = FormStartPosition.CenterParent;
                            //dlg.Owner = this;
                            //dlg.ShowDialog();
                            // dlg.Dispose();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionWriter("MainFrame_KeyDown catch!!!!!!!!!!!", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        //camera1
        void Get_Camera1_Black_Value()
        {
            II_ToolGroup = CAMERA1_Job.VisionTool as CogToolGroup;

            //Global_Camera1_Black_Threshold = ((CogBlobTool)II_ToolGroup.Tools["CogBlobTool2"]).RunParams.SegmentationParams.HardFixedThreshold;
            //Global_Camera1_Black_Pixel = ((CogBlobTool)II_ToolGroup.Tools["CogBlobTool2"]).RunParams.ConnectivityMinPixels;
        }
        //camera2
        void Get_Camera2_Black_Value()
        {
            II_ToolGroup = CAMERA2_Job.VisionTool as CogToolGroup;

            //Global_Camera2_Black_Threshold = ((CogBlobTool)II_ToolGroup.Tools["CogBlobTool2"]).RunParams.SegmentationParams.HardFixedThreshold;
            //Global_Camera2_Black_Pixel = ((CogBlobTool)II_ToolGroup.Tools["CogBlobTool2"]).RunParams.ConnectivityMinPixels;
        }


        void Get_Total_Value()
        {
            //camera1
            Get_Camera1_Black_Value();

            //camera2
            Get_Camera2_Black_Value();

        }

        private void btnCam1Apply_Click(object sender, EventArgs e)
        {
            II_ToolGroup = CAMERA1_Job.VisionTool as CogToolGroup;


            ((CogBlobTool)II_ToolGroup.Tools["CogBlobTool1"]).RunParams.SegmentationParams.HardFixedThreshold = Convert.ToInt32(num_CAMERA1_threshold.Value);
            ((CogBlobTool)II_ToolGroup.Tools["CogBlobTool1"]).RunParams.ConnectivityMinPixels = Convert.ToInt32(num_CAMERA1_pixel.Value);

            if(Model == "3mm")
            {
                CogSerializer.SaveObjectToFile(CAMERA1_JobManager, CAMERA1_1PATH, typeof(BinaryFormatter), CogSerializationOptionsConstants.All);
            }
            else if (Model == "4mm")
            {
                CogSerializer.SaveObjectToFile(CAMERA1_JobManager, CAMERA1_2PATH, typeof(BinaryFormatter), CogSerializationOptionsConstants.All);
            }
            else if (Model == "5mm")
            {
                CogSerializer.SaveObjectToFile(CAMERA1_JobManager, CAMERA1_3PATH, typeof(BinaryFormatter), CogSerializationOptionsConstants.All);
            }
            else if (Model == "6mm")
            {
                CogSerializer.SaveObjectToFile(CAMERA1_JobManager, CAMERA1_4PATH, typeof(BinaryFormatter), CogSerializationOptionsConstants.All);
            }
            else if (Model == "7mm")
            {
                CogSerializer.SaveObjectToFile(CAMERA1_JobManager, CAMERA1_5PATH, typeof(BinaryFormatter), CogSerializationOptionsConstants.All);
            }


        }

        private void btnCam2Apply_Click(object sender, EventArgs e)
        {
            II_ToolGroup = CAMERA2_Job.VisionTool as CogToolGroup;

            ((CogBlobTool)II_ToolGroup.Tools["CogBlobTool1"]).RunParams.SegmentationParams.HardFixedThreshold = Convert.ToInt32(num_CAMERA2_threshold.Value);
            ((CogBlobTool)II_ToolGroup.Tools["CogBlobTool1"]).RunParams.ConnectivityMinPixels = Convert.ToInt32(num_CAMERA2_pixel.Value);


            if (Model == "3mm")
            {
                CogSerializer.SaveObjectToFile(CAMERA2_JobManager, CAMERA2_1PATH, typeof(BinaryFormatter), CogSerializationOptionsConstants.All);
            }
            else if(Model == "4mm")
            {
                CogSerializer.SaveObjectToFile(CAMERA2_JobManager, CAMERA2_2PATH, typeof(BinaryFormatter), CogSerializationOptionsConstants.All);
            }
            else if (Model == "5mm")
            {
                CogSerializer.SaveObjectToFile(CAMERA2_JobManager, CAMERA2_3PATH, typeof(BinaryFormatter), CogSerializationOptionsConstants.All);
            }
            else if (Model == "6mm")
            {
                CogSerializer.SaveObjectToFile(CAMERA2_JobManager, CAMERA2_4PATH, typeof(BinaryFormatter), CogSerializationOptionsConstants.All);
            }
            else if (Model == "7mm")
            {
                CogSerializer.SaveObjectToFile(CAMERA2_JobManager, CAMERA2_5PATH, typeof(BinaryFormatter), CogSerializationOptionsConstants.All);
            }
        }



        #endregion

        void f_invoke(object obj, Bitmap blamp)
        {
            PictureBox pic_obj = obj as PictureBox;


            if (this.InvokeRequired)
            {
                this.Invoke(new Action(delegate ()
                {
                    pic_obj.Image = (Image)blamp;
                }));
            }

        }

        void f_invoke_Label(object obj, string str_text)
        {
            Label pic_obj = obj as Label;

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(delegate ()
                {
                    pic_obj.Text = str_text;
                }));
            }


        }

        private static DateTime Delay(int MS)
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
        
       

        private void btnReset_Click(object sender, EventArgs e)
        {
            CAM1Stopwatch.Reset();
            CAM2Stopwatch.Reset();
            nCAM1TOTAL = 0;
            nCAM1FAIL = 0;
            nCAM2TOTAL = 0;
            nCAM2FAIL = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CAMERA1_Job != null && CAMERA1_JobManager != null)
                {
                    CAMERA1_Job.Reset();
                    CAMERA1_JobManager.Reset();
                }
                if (CAMERA2_Job != null && CAMERA2_JobManager != null)
                {
                    CAMERA2_Job.Reset();
                    CAMERA2_JobManager.Reset();
                }

                Model = "3mm";
                SystemDataLogWriter("Model Select : " + Model);

                button1.BackColor = Color.White;
                button1.ForeColor = Color.Black;

                button2.BackColor = Color.Black;
                button2.ForeColor = Color.White;
                button3.BackColor = Color.Black;
                button3.ForeColor = Color.White;
                button4.BackColor = Color.Black;
                button4.ForeColor = Color.White;
                button5.BackColor = Color.Black;
                button5.ForeColor = Color.White;



                CAMERA_JobInitialize();
            }
            catch(Exception ex)
            {
                ExceptionWriter("3mm_button_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (CAMERA1_Job != null && CAMERA1_JobManager != null)
                {
                    CAMERA1_Job.Reset();
                    CAMERA1_JobManager.Reset();
                }
                if (CAMERA2_Job != null && CAMERA2_JobManager != null)
                {
                    CAMERA2_Job.Reset();
                    CAMERA2_JobManager.Reset();
                }

                Model = "4mm";
                SystemDataLogWriter("Model Select : " + Model);

                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;

                button2.BackColor = Color.White;
                button2.ForeColor = Color.Black;

                button3.BackColor = Color.Black;
                button3.ForeColor = Color.White;
                button4.BackColor = Color.Black;
                button4.ForeColor = Color.White;
                button5.BackColor = Color.Black;
                button5.ForeColor = Color.White;

                CAMERA_JobInitialize();
            }
            catch (Exception ex)
            {
                ExceptionWriter("4mm_button_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (CAMERA1_Job != null && CAMERA1_JobManager != null)
                {
                    CAMERA1_Job.Reset();
                    CAMERA1_JobManager.Reset();
                }
                if (CAMERA2_Job != null && CAMERA2_JobManager != null)
                {
                    CAMERA2_Job.Reset();
                    CAMERA2_JobManager.Reset();
                }

                Model = "5mm";
                SystemDataLogWriter("Model Select : " + Model);

                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                button2.BackColor = Color.Black;
                button2.ForeColor = Color.White;

                button3.BackColor = Color.White;
                button3.ForeColor = Color.Black;

                button4.BackColor = Color.Black;
                button4.ForeColor = Color.White;
                button5.BackColor = Color.Black;
                button5.ForeColor = Color.White;

                CAMERA_JobInitialize();
            }
            catch (Exception ex)
            {
                ExceptionWriter("5mm_button_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (CAMERA1_Job != null && CAMERA1_JobManager != null)
                {
                    CAMERA1_Job.Reset();
                    CAMERA1_JobManager.Reset();
                }
                if (CAMERA2_Job != null && CAMERA2_JobManager != null)
                {
                    CAMERA2_Job.Reset();
                    CAMERA2_JobManager.Reset();
                }

                Model = "6mm";
                SystemDataLogWriter("Model Select : " + Model);

                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                button2.BackColor = Color.Black;
                button2.ForeColor = Color.White;
                button3.BackColor = Color.Black;
                button3.ForeColor = Color.White;

                button4.BackColor = Color.White;
                button4.ForeColor = Color.Black;

                button5.BackColor = Color.Black;
                button5.ForeColor = Color.White;

                CAMERA_JobInitialize();
            }
            catch (Exception ex)
            {
                ExceptionWriter("6mm_button_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (CAMERA1_Job != null && CAMERA1_JobManager != null)
                {
                    CAMERA1_Job.Reset();
                    CAMERA1_JobManager.Reset();
                }
                if (CAMERA2_Job != null && CAMERA2_JobManager != null)
                {
                    CAMERA2_Job.Reset();
                    CAMERA2_JobManager.Reset();
                }

                Model = "7mm";
                SystemDataLogWriter("Model Select : " + Model);

                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                button2.BackColor = Color.Black;
                button2.ForeColor = Color.White;
                button3.BackColor = Color.Black;
                button3.ForeColor = Color.White;
                button4.BackColor = Color.Black;
                button4.ForeColor = Color.White;

                button5.BackColor = Color.White;
                button5.ForeColor = Color.Black;

                CAMERA_JobInitialize();
            }
            catch (Exception ex)
            {
                ExceptionWriter("7mm_button_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
