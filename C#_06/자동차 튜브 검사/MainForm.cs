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
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.Exceptions;

using System.IO;
using Cognex.VisionPro.Display;

using CdioCs;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace chsj
{

    public partial class MainForm : Form
    {
        #region Job Setting 변수

        public static CogJobManager CAMERA1_JobManager = null;
        public static CogJob CAMERA1_Job = null;
        public static CogJobIndependent CAMERA1_JobIndependent = null;
        delegate void CAMERA1_Delegate(Object sender, CogJobManagerActionEventArgs e);

        public static CogJobManager CAMERA2_JobManager = null;
        public static CogJob CAMERA2_Job = null;
        public static CogJobIndependent CAMERA2_JobIndependent = null;
        delegate void CAMERA2_Delegate(Object sender, CogJobManagerActionEventArgs e);
         
       

        #endregion

        #region 새창
        Form1 form1 = new Form1();
        Form2 form2 = new Form2();
        Form3 form3 = null;

        #endregion

        Library lib = new Library();

        #region Inspection Result Setting 변수

        CogToolGroup II_ToolGroup = null;
        CogToolBlock II_ToolBlock = null;

        #endregion

        #region Inspection Setting 변수

        CogPolygon CAMERA1_Region = new CogPolygon();
        CogPolygon CAMERA2_Region = new CogPolygon();

        CogImageFileTool ImageFileTool = new CogImageFileTool();
        

        public ICogRecord tmpRecord = null;
        public ICogRecord topRecord = null;



        #endregion

        #region Inpsection System 변수

        SettingInfo SettingIngInfo = new SettingInfo();

        CogCompositeShape CompositeShape = new CogCompositeShape();
        
        Stopwatch CAM1Stopwatch = new Stopwatch();
        Stopwatch CAM2Stopwatch = new Stopwatch();

        TimeSpan ts1;
        TimeSpan ts2;

        
        
        #endregion




        #region 시스템 이벤트

        public MainForm()
        {
            PF.SystemDataLogWriter("OPEN PROGRAM ");

            InitializeComponent();

            //CAMERA_JobInitialize();

            IOTriggerStart();

            

            PV.nCAM1TOTAL = 0;
            PV.nCAM1PASS = 0;
            PV.nCAM1PER = 0;
            PV.nCAM2TOTAL = 0;
            PV.nCAM2PASS = 0;
            PV.nCAM2PER = 0;

            pic_CAM1_CONNECT_ON.Visible = false;
            pic_CAM1_CONNECT_OFF.Visible = true;

            pic_CAM2_CONNECT_ON.Visible = false;
            pic_CAM2_CONNECT_OFF.Visible = true;


            PV.bCAMERA1_State = false;
            PV.bCAMERA2_State = false;

            lbl_CAM1TotalCount.Text = PV.nCAM1TOTAL.ToString();
            lbl_CAM1PassCount.Text = PV.nCAM1PASS.ToString();
            lbl_CAM1PassPercent.Text = PV.nCAM1PER.ToString();

            lbl_CAM2TotalCount.Text = PV.nCAM2TOTAL.ToString();
            lbl_CAM2PassCount.Text = PV.nCAM2PASS.ToString();
            lbl_CAM2PassPercent.Text = PV.nCAM2PER.ToString();

            //timer5.Enabled = true;


        }
        
        private void btnRunningExecute_Click(object sender, EventArgs e)
        {
            

            if (PV.nModel == 0)
            {
                MessageBox.Show("모델을 선택하세요");
                return;
            }
            else
            {
                CAMERA_JobInitialize();
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
            }



            PV.dio.Init("DIO001", out PV.m_Id);


            try
            {

                
                PV.Run = true;
                PV.bIOcheck = true;


                PF.IOOutPutMessage("0", "1");      // program start
                PF.Delay(1000);
                PF.IOOutPutMessage("0", "0");
                PF.IOOutPutMessage("1", "0");      //  NG
                PF.IOOutPutMessage("2", "0");      //  OK
                PF.IOOutPutMessage("5", "0");      // buzzer


                CAM1Stopwatch.Start();
                CAM2Stopwatch.Start();

                //CAMERA1_Job.RunContinuous(); 
                //CAMERA2_Job.RunContinuous();
                
                btnRunningExecute.Enabled = false;
                //btnRunningExecute.BackgroundImage = global::IVSSYSTEM.Properties.Resources._null;
                btnRunningExecute.Visible = false;
                btnRunningStop.Enabled = true;
                //btnRunningStop.BackgroundImage = global::IVSSYSTEM.Properties.Resources.KakaoTalk_20210629_172802482;
                btnRunningStop.Visible = true;
                btnReset.Enabled = false;
                btnReset.BackgroundImage = global::chsj.Properties.Resources._null;
                btnExit.Enabled = false;


                bt_SetCam1.Enabled = false;
                bt_SetCam2.Enabled = false;
                bt_SetInsp1.Enabled = false;
                bt_SetInsp2.Enabled = false;
                //btn_BuzzOff.Enabled = false;

                

                cbALL_Save.Enabled = false;
                cbALL_Save.ForeColor = System.Drawing.Color.Gray;
                cbNgStop.Enabled = false;
                cbNgStop.ForeColor = System.Drawing.Color.Gray;
                cbNG_Save.Enabled = false;
                cbNG_Save.ForeColor = System.Drawing.Color.Gray;


                PV.bCAMERA1_State = true;
                PV.bCAMERA2_State = true;
                //timer4.Enabled = true;
                Task task = new Task(Task_RunJob);
                task.Start();//검사 task

                bCAMERA1_State_Changed(sender, e);
               bCAMERA2_State_Changed(sender, e);

                string Logtime = lib.getTime("YYMMDD");
                listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "START ");
                PF.SystemDataLogWriter("START");

            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("btnRunningExecute_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRunningStop_Click(object sender, EventArgs e)
        {
            PV.Run = false;
            PV.bIOcheck = false;

            PV.dio.Init("DIO000", out PV.m_Id);

            PF.IOOutPutMessage("0", "0");
            PF.IOOutPutMessage("1", "0");      //  NG
            PF.IOOutPutMessage("2", "0");      //  OK
            PF.IOOutPutMessage("5", "0");      // buzzer

            PV.dio.Exit(0);

            btnRunningExecute.Enabled = true;
            //btnRunningExecute.BackgroundImage = global::IVSSYSTEM.Properties.Resources._null;
            btnRunningExecute.Visible = true;
            btnRunningStop.Enabled = false;
            //btnRunningStop.BackgroundImage = global::IVSSYSTEM.Properties.Resources.KakaoTalk_20210629_172802482;
            btnRunningStop.Visible = false;
            btnReset.Enabled = true;
            btnReset.BackgroundImage = global::chsj.Properties.Resources.KakaoTalk_20210629_172802482;
            btnExit.Enabled = true;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;

            bt_SetCam1.Enabled = true;
            bt_SetCam2.Enabled = true;
            bt_SetInsp1.Enabled = true;
            bt_SetInsp2.Enabled = true;

            cbALL_Save.Enabled = true;
            cbNgStop.Enabled = true;
            cbNG_Save.Enabled = true;


            PV.bCAMERA1_State = false;
            PV.bCAMERA2_State = false;
            timer4.Enabled = false;

           bCAMERA1_State_Changed(sender, e);
           bCAMERA2_State_Changed(sender, e);

            /*
            CAMERA1_Job.Stop();
            CAMERA1_Job.Reset();
            CAMERA1_JobManager.Reset();
            CAMERA2_Job.Stop();
            CAMERA2_Job.Reset();
            CAMERA2_JobManager.Reset();
            */

            string Logtime = lib.getTime("YYMMDD");
            listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "STOP ");
            PF.SystemDataLogWriter("STOP");


            if (CAM1Stopwatch.IsRunning)
            {
                CAM1Stopwatch.Stop();
            }
            if (CAM2Stopwatch.IsRunning)
            {
                CAM2Stopwatch.Stop();
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            PV.dio.Init("DIO000", out PV.m_Id);

            PF.IOOutPutMessage("0", "0");
            PF.IOOutPutMessage("1", "0");      //  NG
            PF.IOOutPutMessage("2", "0");      //  OK
            PF.IOOutPutMessage("5", "0");      // buzzer

            PV.dio.Exit(0);
            PF.SystemDataLogWriter("EXIT");
            try
            {

                PF.ProcessKill("IVSSYSTEM");

                this.Close();



            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("btnExit_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            CAM1Stopwatch.Reset();
            CAM2Stopwatch.Reset();

            pic_CAM1_Result.Image = null;
            pic_CAM2_Result.Image = null;

            PV.nCAM1TOTAL = 0;
            PV.nCAM1PASS = 0;
            PV.nCAM1PER = 0;
            PV.nCAM2TOTAL = 0;
            PV.nCAM2PASS = 0;
            PV.nCAM2PER = 0;

            cogRecordDisplay_CAMERA1.Record = null;
            cogRecordDisplay_CAMERA1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            cogRecordDisplay_CAMERA2.Record = null;
            cogRecordDisplay_CAMERA2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ts1 = CAM1Stopwatch.Elapsed;
            string temp1 = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", ts1.Hours, ts1.Minutes, ts1.Seconds, ts1.Milliseconds);

            lbl_CAM1TIME.Text = temp1;
            PV.lbl_CAM1TIME_Str = lbl_CAM1TIME.Text;

            ts2 = CAM2Stopwatch.Elapsed;
            string temp2 = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", ts2.Hours, ts2.Minutes, ts2.Seconds, ts2.Milliseconds);

            lbl_CAM2TIME.Text = temp2;
            PV.lbl_CAM2TIME_Str = lbl_CAM2TIME.Text;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            lbl_CAM1TotalCount.Text = PV.nCAM1TOTAL.ToString();
            lbl_CAM1PassCount.Text = PV.nCAM1PASS.ToString();
            lbl_CAM1PassPercent.Text = PV.nCAM1PER.ToString();

            lbl_CAM2TotalCount.Text = PV.nCAM2TOTAL.ToString();
            lbl_CAM2PassCount.Text = PV.nCAM2PASS.ToString();
            lbl_CAM2PassPercent.Text = PV.nCAM2PER.ToString();

        }

        
        private void btn_BuzzOff_Click(object sender, EventArgs e)
        {
            try
            {
                PF.IOOutPutMessage("5", "0");      // NG Buzzer OFF

                string Logtime = lib.getTime("YYMMDD");
                listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "BUZZER OFF ");
                PF.SystemDataLogWriter("BUZZER OFF");
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("btn_BuzzOff_Click", ex.Message);
            }
        }

        private void bCAMERA1_State_Changed(object sender, EventArgs e)
        {

            try
            {
                if (PV.bCAMERA1_State == true)
                {
                    //CAMERA1_Job.Run();

                    pic_CAM1_CONNECT_ON.Visible = true;
                    pic_CAM1_CONNECT_OFF.Visible = false;
                }
                else
                {
                    //CAMERA1_Job.Stop();

                    pic_CAM1_CONNECT_ON.Visible = false;
                    pic_CAM1_CONNECT_OFF.Visible = true;

                }
                CAMERAStatus();
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("bCAMERA1_State_CheckedChanged", ex.Message);
                btnRunningStop_Click(sender, e);
            }
        }

        private void bCAMERA2_State_Changed(object sender, EventArgs e)
        {
            try
            {
                if (PV.bCAMERA2_State == true)
                {
                    //CAMERA2_Job.Run();

                    pic_CAM2_CONNECT_ON.Visible = true;
                    pic_CAM2_CONNECT_OFF.Visible = false;

                }
                else
                {
                    //CAMERA2_Job.Stop();

                    pic_CAM2_CONNECT_ON.Visible = false;
                    pic_CAM2_CONNECT_OFF.Visible = true;

                }
                CAMERAStatus();
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("bCAMERA2_State_CheckedChanged", ex.Message);
                btnRunningStop_Click(sender, e);
            }
        }

      

        private void cbNG_Save_CheckedChanged(object sender, EventArgs e)
        {
            PV.bNG_Save = cbNG_Save.Checked;

            string Logtime = lib.getTime("YYMMDD");
            listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "NG IMG SAVE : " + cbNG_Save.Checked);
            PF.SystemDataLogWriter("NG IMG SAVE : " + cbNG_Save.Checked);
        }
        

        private void cbALL_Save_CheckedChanged(object sender, EventArgs e)
        {
            PV.bALL_Save = cbALL_Save.Checked;

            string Logtime = lib.getTime("YYMMDD");
            listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "ALL IMG SAVE : " + cbALL_Save.Checked);
            PF.SystemDataLogWriter("ALL IMG SAVE : " + cbALL_Save.Checked);
        }

        private void cbNgStop_CheckedChanged(object sender, EventArgs e)
        {
            PV.bNgStop = cbNgStop.Checked;

            string Logtime = lib.getTime("YYMMDD");
            listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "NG STOP : " + cbNgStop.Checked);
            PF.SystemDataLogWriter("NG STOP : " + cbNgStop.Checked);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PF.ProcessKill("IVSSYSTEM");
            PV.dio.Init("DIO000", out PV.m_Id);

            PF.IOOutPutMessage("0", "0");
            PF.IOOutPutMessage("1", "0");      //  NG
            PF.IOOutPutMessage("2", "0");      // OK
            PF.IOOutPutMessage("5", "0");      // buzzer

            PV.dio.Exit(0);
            string Logtime = lib.getTime("YYMMDD");
            listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "MAINFORM CLOSE ");
            PF.SystemDataLogWriter("MAINFORM CLOSE ");
        }

        #endregion

        #region 시스템 메소드

        private void CAMERAStatus()
        {
            if (PV.bCAMERA1_State || PV.bCAMERA2_State)
            {
                btnRunningExecute.BackColor = Color.Yellow;
                btnRunningExecute.Enabled = false;
                btnRunningStop.Enabled = true;

                bt_SetCam1.Enabled = false;
                bt_SetCam2.Enabled = false;
                bt_SetInsp1.Enabled = false;
                bt_SetInsp2.Enabled = false;
            }
            else if (!PV.bCAMERA1_State && !PV.bCAMERA2_State)
            {
                btnRunningExecute.BackColor = Color.Black;
                btnRunningExecute.Enabled = true;
                btnRunningStop.Enabled = false;

                bt_SetCam1.Enabled = true;
                bt_SetCam2.Enabled = true;
                bt_SetInsp1.Enabled = true;
                bt_SetInsp2.Enabled = true;
            }
        }
        public void CAMERA_JobInitialize()
        {
            try
            {
                if (PV.nModel == 1)
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA1_1PATH) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA2_1PATH) as CogJobManager;
                }
                else if (PV.nModel == 2)
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA1_2PATH) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA2_2PATH) as CogJobManager;
                }
                else if (PV.nModel == 3)
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA1_3PATH) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA2_3PATH) as CogJobManager;
                }
                else if (PV.nModel == 4)
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA1_4PATH) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA2_4PATH) as CogJobManager;
                }
                else if (PV.nModel == 5)
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA1_5PATH) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA2_5PATH) as CogJobManager;
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

                //II_ToolGroup = CAMERA1_Job.VisionTool as CogToolGroup;
                //II_ToolGroup = CAMERA2_Job.VisionTool as CogToolGroup;
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("CAMERA_JobInitialize", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }


        #region listbox2에 로그 쓰기
        // listbox2에 로그 쓰기
        public void listbox2_CAM1()
        {
            string Logtime = PV.lib.getTime("YYMMDD");
            listBox2.Items.Insert(0, "[Time] : " + Logtime + " [위치] : " + "측면 "
                + " [패턴결과-스코어 하한] : " + PV.Pattern_Result_Score_Min + " [패턴결과-스코어 상한] : " + PV.Pattern_Result_Score_Max);

            listBox2.Items.Insert(1, "                                                                 " + "[내경 하한] : " + PV.Inner_Diameter_Min + " [내경 상한] : " + PV.Inner_Diameter_Max
                + " [동심도 왼쪽 하한] : " + PV.Concentricity_Left_Distance_Min + " [동심도 왼쪽 상한] : " + PV.Concentricity_Left_Distance_Max
                + " [동심도 오른쪽 하한] : " + PV.Concentricity_Right_Distance_Min
                );

            listBox2.Items.Insert(2, "                                                                 " + "[동심도 오른쪽 상한] : " + PV.Concentricity_Right_Distance_Max
               + " [각도 왼쪽 하한] : " + PV.Left_Angle_Min + " [각도 왼쪽 상한] : " + PV.Left_Angle_Max
                + " [각도 오른쪽 하한] : " + PV.Right_Angle_Min);
            listBox2.Items.Insert(3, "                                                                 " + "[각도 오른쪽 상한] : " + PV.Right_Angle_Max);

            listBox2.Items.Insert(4, "                                                                 " + " [패턴결과-스코어 오프셋] : " + PV.Pattern_Result_Score_Offset + " [내경 오프셋] : " + PV.Inner_Diameter_Offset);
            listBox2.Items.Insert(5, "                                                                 " + "[동심도 왼쪽 오프셋] : " + PV.Concentricity_Left_Distance_Offset + " [동심도 오른쪽 오프셋] : " + PV.Concentricity_Right_Distance_Offset);
            listBox2.Items.Insert(6, "                                                                 " + "[각도 왼쪽 오프셋 : " + PV.Left_Angle_Offset + " [각도 오른쪽 오프셋] : " + PV.Right_Angle_Offset);

        }

        public void listbox2_CAM2()
        {
            string Logtime = PV.lib.getTime("YYMMDD");
            listBox2.Items.Insert(0, "[Time] : " + Logtime + " [위치] : " + "정면 " + " [내형상 하한] : " + PV.Inner_Geometry_Min + " [내형상 상한] : " + PV.Inner_Geometry_Max
                + " [외형상 하한] : " + PV.Outer_Geometry_Min + " [외형상 상한] : " + PV.Outer_Geometry_Max + " [내형 하한] : " + PV.Inner_Radius_Min + " [내형 상한] : " + PV.Inner_Radius_Max + " [외형 하한] : " + PV.Outer_Radius_Min + " [외형 상한] : " + PV.Outer_Radius_Max);
            listBox2.Items.Insert(1, "                                                                 " + "[외형상함몰 하한] : " + PV.GetBlobs_Area_Min + " [외형상함몰 상한] : " + PV.GetBlobs_Area_Max);
            listBox2.Items.Insert(2, "                                                                 " + "[내형상 오프셋] : " + PV.Inner_Geometry_Offset + " [외형상 오프셋] : " + PV.Outer_Geometry_Offset
                                                                                                         + " [외형상함몰 오프셋] : " + PV.GetBlobs_Area_Offset);
            listBox2.Items.Insert(3, "                                                                 " + "[내형 오프셋] : " + PV.Inner_Radius_Offset + "[외형 오프셋] : " + PV.Outer_Radius_Offset);

        }

        #endregion




        private string NGImageSave(int CameraNumber)
        {
            string strMonth = DateTime.Now.Month.ToString();
            string strDay = DateTime.Now.Day.ToString();
            string strHour = DateTime.Now.Hour.ToString();
            string strMinute = DateTime.Now.Minute.ToString();
            string strSecond = DateTime.Now.Second.ToString();
            string strMilSecond = DateTime.Now.Millisecond.ToString();

            string strCamera_Number;

            if (CameraNumber == 1)
            {
                strCamera_Number = "카메라1";
            }
            else
            {
                strCamera_Number = "카메라2";
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
            string CreateFileName = strHour + "_" + strMinute + "_" + strSecond + "_" + strMilSecond + "_" + strCamera_Number ;

            DirectoryInfo dir = new DirectoryInfo(PV.NGImageSavePath + CreateFolderName);

            if (dir.Exists == false)
            {
                dir.Create();
            }

            string filePath = PV.NGImageSavePath + CreateFolderName + CreateFileName + ".jpg";
            return filePath;

        }

        private string OKImageSave(int CameraNumber)
        {
            string strMonth = DateTime.Now.Month.ToString();
            string strDay = DateTime.Now.Day.ToString();
            string strHour = DateTime.Now.Hour.ToString();
            string strMinute = DateTime.Now.Minute.ToString();
            string strSecond = DateTime.Now.Second.ToString();
            string strMilSecond = DateTime.Now.Millisecond.ToString();

            string strCamera_Number;

            if (CameraNumber == 1)
            {
                strCamera_Number = "카메라1";
            }
            else
            {
                strCamera_Number = "카메라2";
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
            string CreateFileName = strHour + "_" + strMinute + "_" + strSecond + "_" + strMilSecond + "_" + strCamera_Number;

            DirectoryInfo dir = new DirectoryInfo(PV.OKImageSavePath + CreateFolderName);

            if (dir.Exists == false)
            {
                dir.Create();
            }

            string filePath = PV.OKImageSavePath + CreateFolderName + CreateFileName + ".jpg";
            return filePath;

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

                II_ToolGroup = CAMERA1_Job.VisionTool as CogToolGroup;
                II_ToolBlock = II_ToolGroup.Tools["Results"] as CogToolBlock;
                CogPMAlignTool CogPMAlignTool1 = II_ToolGroup.Tools["원점찾기"] as CogPMAlignTool;


                        Cam1_Run();
                        
                        double dPattern_Result_Score = Convert.ToDouble(PV.Pattern_Result_Score);
                        double dInner_Diameter = Convert.ToDouble(PV.Inner_Diameter);
                        double dConcentricity_Left_Distance = Convert.ToDouble(PV.Concentricity_Left_Distance);
                        double dConcentricity_Right_Distance = Convert.ToDouble(PV.Concentricity_Right_Distance);
                        double dLeft_Angle = Convert.ToDouble(PV.Left_Angle);
                        double dRight_Angle = Convert.ToDouble(PV.Right_Angle);

                        if ((PV.Pattern_Result_Score_Min <= dPattern_Result_Score && dPattern_Result_Score <= PV.Pattern_Result_Score_Max)
                            && (PV.Inner_Diameter_Min <= dInner_Diameter && dInner_Diameter <= PV.Inner_Diameter_Max)
                            && (PV.Concentricity_Left_Distance_Min <= dConcentricity_Left_Distance && dConcentricity_Left_Distance <= PV.Concentricity_Left_Distance_Max)
                            && (PV.Concentricity_Right_Distance_Min <= dConcentricity_Right_Distance && dConcentricity_Right_Distance <= PV.Concentricity_Right_Distance_Max)
                            && (PV.Left_Angle_Min <= dLeft_Angle && dLeft_Angle <= PV.Left_Angle_Max)
                            && (PV.Right_Angle_Min <= dRight_Angle && dRight_Angle <= PV.Right_Angle_Max))
                        {
                            CAMERA1_OK();
                    PF.LogWriter1("OK", PV.Inner_Diameter, PV.Left_Angle, PV.Right_Angle, PV.Concentricity_Left_Distance, PV.Concentricity_Right_Distance, "");

                            if (PV.bALL_Save)
                            {
                                string FileName = "";
                                FileName = OKImageSave(1);

                                ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                                ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                                ImageFileTool.Run();
                                ImageFileTool.Operator.Close();
                            }


                        }
                        else
                        {
                            PV.checkNG = 0;
                            PV.checkOK = 0;

                            CheckBypass1();

                            if (PV.checkOK != 0 && PV.bALL_Save)
                            {
                                string FileName = "";
                                FileName = OKImageSave(1);

                                ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                                ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                                ImageFileTool.Run();
                                ImageFileTool.Operator.Close();
                            }

                            if (PV.checkNG != 0)                                     //ng
                            {
                                if (PV.bNG_Save || PV.bALL_Save)
                                {
                                    string FileName = "";
                                    FileName = NGImageSave(1);

                                    ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                                    ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                                    ImageFileTool.Run();
                                    ImageFileTool.Operator.Close();
                                }

                                if (PV.bNgStop)
                                {
                                    bCAMERA1_State_Changed(sender, e);
                                    bCAMERA2_State_Changed(sender, e);

                                    btnRunningExecute.BackColor = Color.Black;
                                    btnRunningExecute.Enabled = true;
                                    btnRunningStop.Enabled = false;

                                    string Logtime = lib.getTime("YYMMDD");
                                    listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "STOP ");
                                }
                            }
                        }
                        
                        
                    
                //Delay(100);

            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("CAMERA1_UserResultAvailable", ex.Message);
                MessageBox.Show(ex.Message);
                timer4.Enabled = true;
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


            // Outer_Diameter
            /*
            double outer_di = Convert.ToDouble(II_ToolBlock.Outputs["Outer_Diameter"].Value) + 5;               // 반복성 5
            double outer_di2 = outer_di * 0.0065359;
            string outer_di3 = string.Format("{0:0.00#}", outer_di2 + Outer_Diameter_Offset);
            Outer_Diameter = outer_di3;
            */

            // Pattern_Result_Score
            double pattern_s = Convert.ToDouble(II_ToolBlock.Outputs["Pattern_Results_Score"].Value);               
            double pattern_s2 = pattern_s;
            string pattern_s3 = string.Format("{0:0.00#}", pattern_s2 + PV.Pattern_Result_Score_Offset);
            PV.Pattern_Result_Score = pattern_s3;



            // Inner_Diameter
            double inner_di = Convert.ToDouble(II_ToolBlock.Outputs["Inner_Diameter"].Value);
            double inner_di2 = inner_di * PV.Calib_Inner_Diameter;
            string inner_di3 = string.Format("{0:0.00#}", inner_di2 + PV.Inner_Diameter_Offset);
            PV.Inner_Diameter = inner_di3;


            // Concentricity_Left_Distance
            double left_di = Convert.ToDouble(II_ToolBlock.Outputs["Concentricity_Left_Distance"].Value);
            double left_di2 = left_di * PV.Calib_Concentricity;
            string left_di3 = string.Format("{0:0.00#}", left_di2 + PV.Concentricity_Left_Distance_Offset);
            PV.Concentricity_Left_Distance = left_di3;


            // Concentricity_Right_Distance
            double right_di = Convert.ToDouble(II_ToolBlock.Outputs["Concentricity_Right_Distance"].Value);
            double right_di2 = right_di * PV.Calib_Concentricity;
            string right_di3 = string.Format("{0:0.00#}", right_di2 + PV.Concentricity_Right_Distance_Offset);
            PV.Concentricity_Right_Distance = right_di3;



            // Left_Angle
            double left_an = Convert.ToDouble(II_ToolBlock.Outputs["Left_Angle"].Value) ;               
            double left_an2 = left_an / PV.Calib_Angle;                                                          // radian -> degree 변환시 radian값 / 0.017453
            string left_an3 = string.Format("{0:0.000#}", left_an2 + PV.Left_Angle_Offset);
            PV.Left_Angle = left_an3;


            // Right_Angle
            double right_an = Convert.ToDouble(II_ToolBlock.Outputs["Right_Angle"].Value);  
            double right_an2 = right_an / PV.Calib_Angle;
            string right_an3 = string.Format("{0:0.00#}", right_an2 + PV.Right_Angle_Offset);
            PV.Right_Angle = right_an3;




            string Logtime = lib.getTime("YYMMDD");
            listBox1.Items.Insert(0, "[Time] : " + Logtime + " [내경] : " + PV.Inner_Diameter + " [각도 왼쪽] : " + PV.Left_Angle + " [각도 오른쪽] : " + PV.Right_Angle + " [동심도 왼쪽] : " + PV.Concentricity_Left_Distance + " [동심도 오른쪽] : " + PV.Concentricity_Right_Distance);


        }

        void CheckBypass1()
        {
            double dPattern_Result_Score = Convert.ToDouble(PV.Pattern_Result_Score);
            double dInner_Diameter = Convert.ToDouble(PV.Inner_Diameter);
            double dConcentricity_Left_Distance = Convert.ToDouble(PV.Concentricity_Left_Distance);
            double dConcentricity_Right_Distance = Convert.ToDouble(PV.Concentricity_Right_Distance);
            double dLeft_Angle = Convert.ToDouble(PV.Left_Angle);
            double dRight_Angle = Convert.ToDouble(PV.Right_Angle);

          
            if ((PV.Pattern_Result_Score_Min > dPattern_Result_Score || dPattern_Result_Score > PV.Pattern_Result_Score_Max))
            {
                if (!PV.bPattern_Result_Score)
                {
                    CAMERA1_NG();
                    PF.LogWriter1("NG", PV.Inner_Diameter, PV.Left_Angle, PV.Right_Angle, PV.Concentricity_Left_Distance, PV.Concentricity_Right_Distance, "");
                    PV.checkNG++;
                    return;
                }
                else
                {
                }
            }
            if ((PV.Inner_Diameter_Min > dInner_Diameter || dInner_Diameter > PV.Inner_Diameter_Max))
            {
                
                if (!PV.bInner_Diameter)
                {
                    CAMERA1_NG();
                    PF.LogWriter1("NG", PV.Inner_Diameter, PV.Left_Angle, PV.Right_Angle, PV.Concentricity_Left_Distance, PV.Concentricity_Right_Distance, "");
                    PV.checkNG++;
                    return;
                }
                else
                {
                }
            }
            if ((PV.Concentricity_Left_Distance_Min > dConcentricity_Left_Distance || dConcentricity_Left_Distance > PV.Concentricity_Left_Distance_Max))
            {
                if (!PV.bConcentricity_Left_Distance)
                {
                    CAMERA1_NG();
                    PF.LogWriter1("NG", PV.Inner_Diameter, PV.Left_Angle, PV.Right_Angle, PV.Concentricity_Left_Distance, PV.Concentricity_Right_Distance, "");
                    PV.checkNG++;
                    return;
                }
                else
                {
                }
            }
            if ((PV.Concentricity_Right_Distance_Min > dConcentricity_Right_Distance || dConcentricity_Right_Distance > PV.Concentricity_Right_Distance_Max))
            {
                if (!PV.bConcentricity_Right_Distance)
                {
                    CAMERA1_NG();
                    PF.LogWriter1("NG", PV.Inner_Diameter, PV.Left_Angle, PV.Right_Angle, PV.Concentricity_Left_Distance, PV.Concentricity_Right_Distance, "");
                    PV.checkNG++;
                    return;
                }
                else
                {
                }
            }

            if ((PV.Left_Angle_Min > dLeft_Angle || dLeft_Angle > PV.Left_Angle_Max))
            {
                if (!PV.bLeft_Angle)
                {
                    CAMERA1_NG();
                    PF.LogWriter1("NG", PV.Inner_Diameter, PV.Left_Angle, PV.Right_Angle, PV.Concentricity_Left_Distance, PV.Concentricity_Right_Distance, "");
                    PV.checkNG++;
                    return;
                }
                else
                {
                }
            }
            if ((PV.Right_Angle_Min > dRight_Angle || dRight_Angle > PV.Right_Angle_Max))
            {
                
                if (!PV.bRight_Angle)
                {
                    CAMERA1_NG();
                    PF.LogWriter1("NG", PV.Inner_Diameter, PV.Left_Angle, PV.Right_Angle, PV.Concentricity_Left_Distance, PV.Concentricity_Right_Distance, "");
                    PV.checkNG++;
                    return;
                }
                else
                {
                }
            }
            CAMERA1_OK();
            PF.LogWriter1("OK", PV.Inner_Diameter, PV.Left_Angle, PV.Right_Angle, PV.Concentricity_Left_Distance, PV.Concentricity_Right_Distance, "");
            PV.checkOK++;

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
                II_ToolGroup = CAMERA2_Job.VisionTool as CogToolGroup;
                II_ToolBlock = II_ToolGroup.Tools["Results"] as CogToolBlock;
                CogPMAlignTool CogPMAlignTool1 = II_ToolGroup.Tools["CogPMAlignTool1"] as CogPMAlignTool;



                Cam2_Run();

                double dInner_Geometry = Convert.ToDouble(PV.Inner_Geometry);
                double dOuter_Geometry = Convert.ToDouble(PV.Outer_Geometry);
                double dGetBlobs_Area = Convert.ToDouble(PV.GetBlobs_Area);
                double dInner_Radius = Convert.ToDouble(PV.Inner_Radius);
                double dOuter_Radius = Convert.ToDouble(PV.Outer_Radius);


                if ((PV.Inner_Geometry_Min <= dInner_Geometry && dInner_Geometry <= PV.Inner_Geometry_Max)   
                    && (PV.Outer_Geometry_Min <= dOuter_Geometry && dOuter_Geometry <= PV.Outer_Geometry_Max)
                    && (PV.GetBlobs_Area_Min <= dGetBlobs_Area && dGetBlobs_Area <= PV.GetBlobs_Area_Max)
                    && (PV.Inner_Radius_Min <= dInner_Radius && dInner_Radius <= PV.Inner_Radius_Max)
                    && (PV.Outer_Radius_Min <= dOuter_Radius && dOuter_Radius <= PV.Outer_Radius_Max))

                {
                    CAMERA2_OK();
                    PF.LogWriter2("OK", PV.Inner_Geometry, PV.Outer_Geometry, PV.GetBlobs_Area, PV.Inner_Radius, PV.Outer_Radius, "");
                    
                    if (PV.bALL_Save)
                    {
                        string FileName = "";
                        FileName = OKImageSave(2);

                        ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                        ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                        ImageFileTool.Run();
                        ImageFileTool.Operator.Close();
                    }
                    
                }

                else
                {
                    PV.checkNG2 = 0;
                    PV.checkOK2 = 0;
                    CheckBypass2();

                    if (PV.checkOK2 != 0 && PV.bALL_Save)
                    {
                        string FileName = "";
                        FileName = OKImageSave(2);

                        ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                        ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                        ImageFileTool.Run();
                        ImageFileTool.Operator.Close();
                    }

                    if (PV.checkNG2 != 0)                                     //ng
                    {
                        if (PV.bNG_Save || PV.bALL_Save)
                        {
                            string FileName = "";
                            FileName = NGImageSave(2);
                            
                            ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                            ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                            ImageFileTool.Run();
                            ImageFileTool.Operator.Close();
                        }

                        if (PV.bNgStop)
                        {
                            bCAMERA1_State_Changed(sender, e);
                            bCAMERA2_State_Changed(sender, e);

                            btnRunningExecute.BackColor = Color.Black;
                            btnRunningExecute.Enabled = true;
                            btnRunningStop.Enabled = false;

                            string Logtime = lib.getTime("YYMMDD");
                            listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "STOP ");
                        }
                    }
                }

                PF.Delay(100);
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("CAMERA2_UserResultAvailable", ex.Message);
                MessageBox.Show(ex.Message);
                timer4.Enabled = true;
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
            

            // Inner_Geometry
            double inner_geo = Convert.ToDouble(II_ToolBlock.Outputs["Inner_Geometry"].Value);
            double inner_geo2 = inner_geo;
            string inner_geo3 = string.Format("{0:0.00#}", inner_geo2 + PV.Inner_Geometry_Offset);
            PV.Inner_Geometry = inner_geo3; 

            // Outer_Geometry
            double outer_geo = Convert.ToDouble(II_ToolBlock.Outputs["Outer_Geometry"].Value);             
            double outer_geo2 = outer_geo;
            string outer_geo3 = string.Format("{0:0.00#}", outer_geo2 + PV.Outer_Geometry_Offset);
            PV.Outer_Geometry = outer_geo3;

            // GetBlobs_Area
            double getblob_area = Convert.ToDouble(II_ToolBlock.Outputs["GetBlobs_Area"].Value);             
            double getblob_area2 = getblob_area;
            string getblob_area3 = string.Format("{0:0.00#}", getblob_area2 + PV.GetBlobs_Area_Offset);
            PV.GetBlobs_Area = getblob_area3;

            //
            double inner_radius = Convert.ToDouble(II_ToolBlock.Outputs["Inner_Radius"].Value);
            double inner_radius2 = inner_radius * PV.Calib_Inner_Radius;
            string inner_radius3 = string.Format("{0:0.00#}", inner_radius2 + PV.Inner_Radius_Offset);
            PV.Inner_Radius = inner_radius3;


            //Results_GetCircle_Radius	System.Double
            double outer_radius = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetCircle_Radius"].Value);
            double outer_radius2 = outer_radius * PV.Calib_Outer_Radius;
            string outer_radius3 = string.Format("{0:0.00#}", outer_radius2 + PV.Outer_Radius_Offset);
            PV.Outer_Radius = outer_radius3;


            string Logtime = lib.getTime("YYMMDD");
            listBox1.Items.Insert(0, "[Time] : " + Logtime + " [내형상] : " + PV.Inner_Geometry + " [외형상] : " + PV.Outer_Geometry + " [외형상함몰] : " + PV.GetBlobs_Area + " [내경] : " + PV.Inner_Radius + " [외경] : " + PV.Outer_Radius);
            
        }

        void CheckBypass2()
        {
            double dInner_Geometry = Convert.ToDouble(PV.Inner_Geometry);
            double dOuter_Geometry = Convert.ToDouble(PV.Outer_Geometry);
            double dGetBlobs_Area = Convert.ToDouble(PV.GetBlobs_Area);
            double dInner_Radius = Convert.ToDouble(PV.Inner_Radius);
            double dOuter_Radius = Convert.ToDouble(PV.Outer_Radius);

            if ((PV.Inner_Geometry_Min > dInner_Geometry || dInner_Geometry > PV.Inner_Geometry_Max))
            {
                if (!PV.bInner_Geometry)
                {
                    CAMERA2_NG();
                    PF.LogWriter2("NG", PV.Inner_Geometry, PV.Outer_Geometry, PV.GetBlobs_Area, PV.Inner_Radius, PV.Outer_Radius, "");
                    PV.checkNG2++;
                    return;
                }
                else
                {
                }
            }
            if ((PV.Outer_Geometry_Min > dOuter_Geometry || dOuter_Geometry > PV.Outer_Geometry_Max))
            {
                if (!PV.bOuter_Geometry)
                {
                    CAMERA2_NG();
                    PF.LogWriter2("NG", PV.Inner_Geometry, PV.Outer_Geometry, PV.GetBlobs_Area, PV.Inner_Radius, PV.Outer_Radius, "");
                    PV.checkNG2++;
                    return;
                }
                else
                {
                }
            }
            if ((PV.GetBlobs_Area_Min > dGetBlobs_Area || dGetBlobs_Area > PV.GetBlobs_Area_Max))
            {
                if (!PV.bGetBlobs_Area)
                {
                    CAMERA2_NG();
                    PF.LogWriter2("NG", PV.Inner_Geometry, PV.Outer_Geometry, PV.GetBlobs_Area, PV.Inner_Radius, PV.Outer_Radius, "");
                    PV.checkNG2++;
                    return;
                }
                else
                {
                
                }
            }
            if ((PV.Inner_Radius_Min > dInner_Radius || dInner_Radius > PV.Inner_Radius_Max))
            {
                if (!PV.bInner_Radius)
                {
                    CAMERA2_NG();
                    PF.LogWriter2("NG", PV.Inner_Geometry, PV.Outer_Geometry, PV.GetBlobs_Area, PV.Inner_Radius, PV.Outer_Radius, "");
                    PV.checkNG2++;
                    return;
                }
                else
                {

                }
            }
            if ((PV.Outer_Radius_Min > dOuter_Radius || dOuter_Radius > PV.Outer_Radius_Max))
            {
                if (!PV.bOuter_Radius)
                {
                    CAMERA2_NG();
                    PF.LogWriter2("NG", PV.Inner_Geometry, PV.Outer_Geometry, PV.GetBlobs_Area, PV.Inner_Radius, PV.Outer_Radius, "");
                    PV.checkNG2++;
                    return;
                }
                else
                {

                }
            }
            CAMERA2_OK();
            PF.LogWriter2("OK", PV.Inner_Geometry, PV.Outer_Geometry, PV.GetBlobs_Area, PV.Inner_Radius, PV.Outer_Radius, "");
            PV.checkOK2++;
           

        }

        #endregion



        #region NG_OK

        private void CAMERA1_NG()
        {
            try
            {
                pic_CAM1_Result.Image = global::chsj.Properties.Resources.fail;
                PV.nCAM1TOTAL++;
                int pass = PV.nCAM1PASS * 100;
                PV.nCAM1PER = (pass / PV.nCAM1TOTAL);
                PV.CAM1Result = false;
                PV.CAM1ResultExist = true;
                
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("CAMERA1_NG", ex.Message);
                MessageBox.Show(ex.Message);
            }
           


        }

        private void CAMERA1_OK()
        {
            try
            {
                pic_CAM1_Result.Image = global::chsj.Properties.Resources.PASS;
                PV.nCAM1PASS++;
                PV.nCAM1TOTAL++;
                int pass = PV.nCAM1PASS * 100;
                PV.nCAM1PER = (pass / PV.nCAM1TOTAL);
                PV.CAM1Result = true;
                PV.CAM1ResultExist = true;
            }
            catch(Exception ex)
            {
                PF.ExceptionWriter("CAMERA1_OK", ex.Message);
                MessageBox.Show(ex.Message);
            }
           
        }


        private void CAMERA2_NG()
        {
            try
            {
                pic_CAM2_Result.Image = global::chsj.Properties.Resources.fail;
                PV.nCAM2TOTAL++;
                int pass = PV.nCAM2PASS * 100;
                PV.nCAM2PER = (pass / PV.nCAM2TOTAL);
                PV.CAM2Result = false;
                PV.CAM2ResultExist = true;

                //ResultOut();


                if (PV.bAlarmStop == false)
                {

                    PF.SystemDataLogWriter2("ResultOut() - NG");
                    PF.IOOutPutMessage("1", "1");      // NG
                    PF.Delay(1000);
                    PF.IOOutPutMessage("1", "0");

                    if (PV.bNgStop == true)
                    {
                        CAMERA1_Job.Stop();
                        CAMERA2_Job.Stop();
                    }

                    timer2.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                PF.ExceptionWriter("CAMERA2_NG", ex.Message);
                MessageBox.Show(ex.Message);
            }
            

        }


        private void CAMERA2_OK()
        {
            try
            {
                pic_CAM2_Result.Image = global::chsj.Properties.Resources.PASS;
                PV.nCAM2PASS++;
                PV.nCAM2TOTAL++;
                int pass = PV.nCAM2PASS * 100;
                PV.nCAM2PER = (pass / PV.nCAM2TOTAL);
                PV.CAM2Result = true;
                PV.CAM2ResultExist = true;

                //ResultOut();

                if (PV.bAlarmStop == false)
                {
                    if (PV.checkNG==0)
                    {
                        PF.SystemDataLogWriter2("ResultOut() - OK1");
                        PF.IOOutPutMessage("2", "1");      // OK
                        PF.Delay(1000);
                        PF.IOOutPutMessage("2", "0");      // OK
                        PF.SystemDataLogWriter2("ResultOut() - OK2");
                    }
                    else
                    {
                        PF.SystemDataLogWriter2("ResultOut() - NG");
                        PF.IOOutPutMessage("1", "1");      // cam1 ng
                        PF.Delay(1000);
                        PF.IOOutPutMessage("1", "0");

                        if (PV.bNgStop == true)
                        {
                            CAMERA1_Job.Stop();
                            CAMERA2_Job.Stop();
                        }

                    }
                    timer2.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                PF.ExceptionWriter("CAMERA2_OK", ex.Message);
                MessageBox.Show(ex.Message);
            }
            


        }

        #endregion


        #region 세팅버튼클릭

        private void bt_SetInsp1_Click(object sender, EventArgs e)
        {
            if (PV.nModel == 0)
            {
                MessageBox.Show("모델을 선택하세요");
                return;
            }
            else
            {
                listbox2_CAM1();

                Form1 newform = new Form1();
                newform.MainForm = this;
                newform.ShowDialog();
            }
            
        }

        private void bt_SetInsp2_Click(object sender, EventArgs e)
        {
            if(PV.nModel == 0)
            {
                MessageBox.Show("모델을 선택하세요");
                return;
            }
            else
            {
                listbox2_CAM2();
                Form2 newform = new Form2();
                newform.MainForm = this;
                newform.ShowDialog();
            }
            
        }

        private void bt_SetCam1_Click(object sender, EventArgs e)
        {

            string Logtime = lib.getTime("YYMMDD");
            listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "CAM1 JOB SETTING ");
            PF.SystemDataLogWriter("CAM1 JOB SETTING ");
            if (PV.Run == false)
            {
                if (form3 == null || form3.Text == "Setting")
                {
                    if(PV.nModel == 0)
                    {
                        MessageBox.Show("모델을 선택하세요");
                        return;
                    }
                    else if(PV.nModel == 1)
                    {
                        form3 = new Form3(PV.CAMERA1_1PATH);
                        form3.ShowDialog();
                    }
                    else if (PV.nModel == 2)
                    {
                        form3 = new Form3(PV.CAMERA1_2PATH);
                        form3.ShowDialog();
                    }
                    else if (PV.nModel == 3)
                    {
                        form3 = new Form3(PV.CAMERA1_3PATH);
                        form3.ShowDialog();
                    }
                    else if (PV.nModel == 4)
                    {
                        form3 = new Form3(PV.CAMERA1_4PATH);
                        form3.ShowDialog();
                    }
                    else if (PV.nModel == 5)
                    {
                        form3 = new Form3(PV.CAMERA1_5PATH);
                        form3.ShowDialog();
                    }

                }
                else
                {
                    form3.Activate();
                }
            }

        }


        private void bt_SetCam2_Click(object sender, EventArgs e)
        {
            string Logtime = lib.getTime("YYMMDD");
            listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "CAM2 JOB SETTING ");
            PF.SystemDataLogWriter("CAM2 JOB SETTING ");

            if (PV.Run == false)
            {
                if (form3 == null || form3.Text == "Setting")
                {
                    if (PV.nModel == 0)
                    {
                        MessageBox.Show("모델을 선택하세요");
                        return;
                    }
                    else if (PV.nModel == 1)
                    {
                        form3 = new Form3(PV.CAMERA2_1PATH);
                        form3.ShowDialog();
                    }
                    else if (PV.nModel == 2)
                    {
                        form3 = new Form3(PV.CAMERA2_2PATH);
                        form3.ShowDialog();
                    }
                    else if (PV.nModel == 3)
                    {
                        form3 = new Form3(PV.CAMERA2_3PATH);
                        form3.ShowDialog();
                    }
                    else if (PV.nModel == 4)
                    {
                        form3 = new Form3(PV.CAMERA2_4PATH);
                        form3.ShowDialog();
                    }
                    else if (PV.nModel == 5)
                    {
                        form3 = new Form3(PV.CAMERA2_5PATH);
                        form3.ShowDialog();
                    }
                }
                else
                {form3.Activate();}
            }
        }

        #endregion

        
        private void timer4_Tick(object sender, EventArgs e)
        {
            /*
            try
            {
                
                if (PF.IOCheck("0") == "1")
                {
                    timer4.Enabled = false;
                    
                    if (PV.bCAMERA1_State && PV.bCAMERA2_State)
                    {
                        CAMERA1_Job.Stop();
                        PF.Delay(50);
                        CAMERA1_Job.Run();

                        CAMERA2_Job.Stop();
                        PF.Delay(50);
                        CAMERA2_Job.Run();
                    }
                    else
                    {
                        PV.bCAMERA1_State = true;
                        PV.bCAMERA2_State = true;
                        CAMERA1_Job.Stop();
                        CAMERA2_Job.Stop();
                    }
                    
                }
            }
            catch(Exception ex)
            {
                PF.ExceptionWriter("timer4_Tick", ex.Message);
                MessageBox.Show(ex.Message);
                timer4.Enabled = true;
                PF.IOOutPutMessage("1", "0");
                PF.IOOutPutMessage("2", "0");
            }
            
            timer4.Enabled = true;
            */
        }

        private void Task_RunJob()
        {
            while (PV.bIOcheck)
            {
                try
                {
                    if (PF.IOCheck("0") == "1")// PLC Trigger Input on
                    {
                        PV.InputCheck = 1;

                        if ((PV.InputCheck_Old == 0) && (PV.InputCheck == 1))
                        {
                            
                            if (PV.bCAMERA1_State && PV.bCAMERA2_State)
                            {
                                CAMERA1_Job.Stop();
                                PF.Delay(50);
                                CAMERA1_Job.Run();

                                CAMERA2_Job.Stop();
                                PF.Delay(50);
                                CAMERA2_Job.Run();
                            }
                            else
                            {
                                PV.bCAMERA1_State = true;
                                PV.bCAMERA2_State = true;
                                CAMERA1_Job.Stop();
                                CAMERA2_Job.Stop();
                            }

                                
                        }

                        PV.InputCheck_Old = PV.InputCheck;
                    }
                    else
                    {
                        PV.InputCheck = 0;
                        PV.InputCheck_Old = PV.InputCheck;
                    }
                }
                catch (Exception ex)
                {
                    PF.ExceptionWriter("ResultOut", ex.Message);
                    MessageBox.Show(ex.Message);
                    PF.IOOutPutMessage("2", "0");
                    PF.IOOutPutMessage("1", "0");
                    return;
                }

                Thread.Sleep(100);  
            }
        }

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

            ////   IMG_Result2.Image = global::IVSSYSTEM.Properties.Resources.FAIL;
            //lock (obj_lock)
            //{
            //    pic_obj.Image = blamp;
            //}
            ////    f_invoke(IMG_Result2, global::IVSSYSTEM.Properties.Resources.FAIL);

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


        #region 트리거시간테스트용
        private void timer5_Tick(object sender, EventArgs e)
        {
            if (PF.IOCheck("0") == "1")
            {
                PF.SystemDataLogWriter2("trigger high");
                timer5.Enabled = false;
                timer6.Enabled = true;
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if(PF.IOCheck("0") == "0")
            {
                PF.SystemDataLogWriter2("trigger low");
                timer6.Enabled = false;
                timer5.Enabled = true;
            }
        }

        #endregion


        #region 모델 변경

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

                PV.nModel = 1;
                PF.SystemDataLogWriter("Model Select : " + PV.nModel.ToString());
                
                button1.ForeColor = Color.White;
                button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                
                PF.LaodData_Setting1(PV.DataFile + "\\Setting1_1.txt");
                PF.LaodData_Bypass1(PV.DataFile + "\\Bypass1_1.txt");
                PF.LaodData_Offset1(PV.DataFile + "\\Offset1_1.txt");
                PF.LaodData_Calib1(PV.DataFile + "\\Calib1_1.txt");
            
                PF.LaodData_Setting2(PV.DataFile + "\\Setting2_1.txt");
                PF.LaodData_Bypass2(PV.DataFile + "\\Bypass2_1.txt");
                PF.LaodData_Offset2(PV.DataFile + "\\Offset2_1.txt");
                PF.LaodData_Calib2(PV.DataFile + "\\Calib2_1.txt");

                string Logtime = lib.getTime("YYMMDD");
                listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "모델 변경 - Model 1 ");

                
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("button1_Click", ex.Message);
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

                PV.nModel = 2;
                PF.SystemDataLogWriter("Model Select : " + PV.nModel.ToString());

                button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button2.ForeColor = Color.White;
                button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));

                PF.LaodData_Setting1(PV.DataFile + "\\Setting1_2.txt");
                PF.LaodData_Bypass1(PV.DataFile + "\\Bypass1_2.txt");
                PF.LaodData_Offset1(PV.DataFile + "\\Offset1_2.txt");
                PF.LaodData_Calib1(PV.DataFile + "\\Calib1_2.txt");

                PF.LaodData_Setting2(PV.DataFile + "\\Setting2_2.txt");
                PF.LaodData_Bypass2(PV.DataFile + "\\Bypass2_2.txt");
                PF.LaodData_Offset2(PV.DataFile + "\\Offset2_2.txt");
                PF.LaodData_Calib2(PV.DataFile + "\\Calib2_2.txt");

                string Logtime = lib.getTime("YYMMDD");
                listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "모델 변경 - Model 2 ");

            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("button2_Click", ex.Message);
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

                PV.nModel = 3;
                PF.SystemDataLogWriter("Model Select : " + PV.nModel.ToString());

                button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button3.ForeColor = Color.White;
                button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));

                PF.LaodData_Setting1(PV.DataFile + "\\Setting1_3.txt");
                PF.LaodData_Bypass1(PV.DataFile + "\\Bypass1_3.txt");
                PF.LaodData_Offset1(PV.DataFile + "\\Offset1_3.txt");
                PF.LaodData_Calib1(PV.DataFile + "\\Calib1_3.txt");

                PF.LaodData_Setting2(PV.DataFile + "\\Setting2_3.txt");
                PF.LaodData_Bypass2(PV.DataFile + "\\Bypass2_3.txt");
                PF.LaodData_Offset2(PV.DataFile + "\\Offset2_3.txt");
                PF.LaodData_Calib2(PV.DataFile + "\\Calib2_3.txt");

                string Logtime = lib.getTime("YYMMDD");
                listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "모델 변경 - Model 3 ");


            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("button3_Click", ex.Message);
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

                PV.nModel = 4;
                PF.SystemDataLogWriter("Model Select : " + PV.nModel.ToString());

                button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button4.ForeColor = Color.White;
                button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));

                PF.LaodData_Setting1(PV.DataFile + "\\Setting1_4.txt");
                PF.LaodData_Bypass1(PV.DataFile + "\\Bypass1_4.txt");
                PF.LaodData_Offset1(PV.DataFile + "\\Offset1_4.txt");
                PF.LaodData_Calib1(PV.DataFile + "\\Calib1_4.txt");

                PF.LaodData_Setting2(PV.DataFile + "\\Setting2_4.txt");
                PF.LaodData_Bypass2(PV.DataFile + "\\Bypass2_4.txt");
                PF.LaodData_Offset2(PV.DataFile + "\\Offset2_4.txt");
                PF.LaodData_Calib2(PV.DataFile + "\\Calib2_4.txt");

                string Logtime = lib.getTime("YYMMDD");
                listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "모델 변경 - Model 4 ");

            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("button4_Click", ex.Message);
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

                PV.nModel = 5;
                PF.SystemDataLogWriter("Model Select : " + PV.nModel.ToString());

                button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
                button5.ForeColor = Color.White;

                PF.LaodData_Setting1(PV.DataFile + "\\Setting1_5.txt");
                PF.LaodData_Bypass1(PV.DataFile + "\\Bypass1_5.txt");
                PF.LaodData_Offset1(PV.DataFile + "\\Offset1_5.txt");
                PF.LaodData_Calib1(PV.DataFile + "\\Calib1_5.txt");

                PF.LaodData_Setting2(PV.DataFile + "\\Setting2_5.txt");
                PF.LaodData_Bypass2(PV.DataFile + "\\Bypass2_5.txt");
                PF.LaodData_Offset2(PV.DataFile + "\\Offset2_5.txt");
                PF.LaodData_Calib2(PV.DataFile + "\\Calib2_5.txt");

                string Logtime = lib.getTime("YYMMDD");
                listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "모델 변경 - Model 5 ");

            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("button5_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        


        void ResultOut()
        {
            try
            {
                if (PV.bAlarmStop == false)
                {
                    if (PV.CAM1Result && PV.CAM2Result)
                    {
                        PV.dio.Init("DIO000", out PV.m_Id);

                        PF.IOOutPutMessage("2", "1");      // OK
                        PF.SystemDataLogWriter2("ResultOut() - OK");
                        PF.IOOutPutMessage("2", "1");      // OK
                        PF.Delay(1000);
                        PF.IOOutPutMessage("2", "0");
                    }
                    else
                    {
                        PV.dio.Init("DIO000", out PV.m_Id);

                        PF.SystemDataLogWriter2("ResultOut() - NG");
                        PF.IOOutPutMessage("1", "1");      // ng
                        PF.Delay(1000);
                        PF.IOOutPutMessage("1", "0");
                    }
                    timer2.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("ResultOut", ex.Message);
                MessageBox.Show(ex.Message);
                PF.IOOutPutMessage("2", "0");
                PF.IOOutPutMessage("1", "0");
            }

        }

        public void IOTriggerStart()
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
                PV.m_UpCount[TrgBit] = 0;		// Up counter
                PV.m_DownCount[TrgBit] = 0;	// Down counter
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
                    Ret = PV.dio.NotifyTrg(PV.m_Id, TrgBit, TrgKind, Tim, this.Handle.ToInt32());
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
            PV.dio.GetErrorString(Ret, out ErrorString);
            //textBox_ReturnCode.Text = "Ret = " + System.Convert.ToString(Ret) + " : " + ErrorString;
        }


    }
}
