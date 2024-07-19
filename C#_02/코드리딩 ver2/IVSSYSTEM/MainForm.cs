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
using Cognex.VisionPro.Exceptions;

using System.IO;
using Cognex.VisionPro.Display;

using CdioCs;
using System.Diagnostics;
using System.Threading;

namespace IVSSYSTEM
{

    public partial class MainForm : Form
    {
        #region Job Setting 변수

        public CogJobManager CAMERA1_JobManager = null;
        public CogJob CAMERA1_Job = null;
        public CogJobIndependent CAMERA1_JobIndependent = null;
        delegate void CAMERA1_Delegate(Object sender, CogJobManagerActionEventArgs e);

        
        public CogJobManager CAMERA2_JobManager = null;
        public CogJob CAMERA2_Job = null;
        public CogJobIndependent CAMERA2_JobIndependent = null;
        delegate void CAMERA2_Delegate(Object sender, CogJobManagerActionEventArgs e);

        public CogJobManager CAMERA3_JobManager = null;
        public CogJob CAMERA3_Job = null;
        public CogJobIndependent CAMERA3_JobIndependent = null;
        delegate void CAMERA3_Delegate(Object sender, CogJobManagerActionEventArgs e);

        public CogJobManager CAMERA4_JobManager = null;
        public CogJob CAMERA4_Job = null;
        public CogJobIndependent CAMERA4_JobIndependent = null;
        delegate void CAMERA4_Delegate(Object sender, CogJobManagerActionEventArgs e);


        #endregion

        #region 자식창 변수

        Form1 form1 = new Form1();
        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        Form4 form4 = new Form4();
        Form5 form5 = null;

        #endregion
        
        #region Inspection Result Setting 변수

        public CogToolGroup II_ToolGroup = null;
        public CogToolBlock II_ToolBlock = null;

        #endregion

        #region Inspection Setting 변수

        CogPolygon CAMERA1_Region = new CogPolygon();
        CogPolygon CAMERA2_Region = new CogPolygon();
        CogPolygon CAMERA3_Region = new CogPolygon();
        CogPolygon CAMERA4_Region = new CogPolygon();

        CogImageFileTool ImageFileTool = new CogImageFileTool();
        

        public ICogRecord tmpRecord = null;
        public ICogRecord topRecord = null;

        #endregion

        #region Inpsection System 변수

        Library lib = new Library();
        SettingInfo SettingIngInfo = new SettingInfo();
        CogCompositeShape CompositeShape = new CogCompositeShape();

        public static bool Run = false;

        #endregion


        #region 시스템 이벤트

        public MainForm()
        {
            PF.WriteSysLog("MainForm", "OPEN PROGRAM ");
            InitializeComponent();
            CAMERA_JobInitialize();
            IOTriggerStart();
            PF.CreateFolder();

            timer4.Enabled = true;
            timer5.Enabled = false;
            timer6.Enabled = true;
            timer7.Enabled = false;


            // 세팅 데이터 읽기
            PF.ReadSettingDataCam1();
            PF.ReadSettingDataCam2();
            PF.ReadSettingDataCam3();
            PF.ReadSettingDataCam4();

            pic_CAM1_CONNECT_ON.Visible = false;
            pic_CAM1_CONNECT_OFF.Visible = true;
            pic_CAM2_CONNECT_ON.Visible = false;
            pic_CAM2_CONNECT_OFF.Visible = true;
            pic_CAM3_CONNECT_ON.Visible = false;
            pic_CAM3_CONNECT_OFF.Visible = true;
            pic_CAM4_CONNECT_ON.Visible = false;
            pic_CAM4_CONNECT_OFF.Visible = true;
            
            PV.bCAMERA1_State = false;
            PV.bCAMERA2_State = false;
            PV.bCAMERA3_State = false;
            PV.bCAMERA4_State = false;

            

        }
        
        private void btnRunningExecute_Click(object sender, EventArgs e)
        {
            timer4.Enabled = false;
            timer6.Enabled = false;

            PV.dio.Init("DIO000", out PV.m_Id);

            try
            {
                RunCam12(sender, e);
                RunCam34(sender, e);
                
                PF.WriteSysLog("btnRunningExecute_Click", "START");

            }
            catch (Exception ex)
            {
                PF.WriteSysLog("btnRunningExecute_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRunningStop_Click(object sender, EventArgs e)
        {
            timer4.Enabled = true;
            timer5.Enabled = false;
            timer6.Enabled = true;
            timer7.Enabled = false;

            Run = false;
            
            PV.dio.Init("DIO000", out PV.m_Id);

            PF.IOOutPutMessage("0", "0");      // cam1 NG
            PF.IOOutPutMessage("1", "0");      // cam1 OK
            PF.IOOutPutMessage("2", "0");      // cam2 NG
            PF.IOOutPutMessage("3", "0");      // cam2 OK
            PF.IOOutPutMessage("4", "0");      // cam3 NG
            PF.IOOutPutMessage("5", "0");      // cam3 OK
            PF.IOOutPutMessage("6", "0");      // cam4 NG
            PF.IOOutPutMessage("7", "0");      // cam4 OK

            

            StopCam12(sender, e);
            StopCam34(sender, e);
            

            PF.WriteSysLog("btnRunningStop_Click", "STOP");
            

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                timer4.Enabled = false;
                timer5.Enabled = false;
                timer6.Enabled = false;
                timer7.Enabled = false;

                PV.dio.Init("DIO000", out PV.m_Id);

                PF.IOOutPutMessage("0", "0");      // cam1 NG
                PF.IOOutPutMessage("1", "0");      // cam1 OK
                PF.IOOutPutMessage("2", "0");      // cam2 NG
                PF.IOOutPutMessage("3", "0");      // cam2 OK
                PF.IOOutPutMessage("4", "0");      // cam3 NG
                PF.IOOutPutMessage("5", "0");      // cam3 OK
                PF.IOOutPutMessage("6", "0");      // cam4 NG
                PF.IOOutPutMessage("7", "0");      // cam4 OK

                PV.dio.Exit(0);

                PF.WriteSysLog("btnExit_Click", "EXIT");

                PF.ProcessKill("IVSSYSTEM");
                this.Close();
            }
            catch (Exception ex)
            {
                PF.WriteSysLog("btnExit_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
  

        private void timer1_Tick(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss");

            label20.Text = date + " " + time;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            lbl_CAM1FailCount.Text = PV.nCAM1FAIL.ToString();
            lbl_CAM2FailCount.Text = PV.nCAM2FAIL.ToString();
            lbl_CAM3FailCount.Text = PV.nCAM3FAIL.ToString();
            lbl_CAM4FailCount.Text = PV.nCAM4FAIL.ToString();
        }

        public void timer4_Tick(object sender, EventArgs e)
        {
            PV.dio.Init("DIO000", out PV.m_Id);

            if (PF.IOCheck("0") == "1")
            {
                timer4.Enabled = false;

                //MessageBox.Show("RunCam12");
                RunCam12(sender, e);
                timer5.Enabled = true;
            }
        }


        private void timer5_Tick(object sender, EventArgs e)
        {
            PV.dio.Init("DIO000", out PV.m_Id);

            if (PF.IOCheck("0") == "0")
            {
                timer5.Enabled = false;

                //MessageBox.Show("StopCam12");
                StopCam12(sender, e);
                timer4.Enabled = true;

            }
        }


        private void timer6_Tick(object sender, EventArgs e)
        {
            PV.dio.Init("DIO000", out PV.m_Id);

            if (PF.IOCheck("1") == "1")
            {
                timer6.Enabled = false;

                //MessageBox.Show("RunCam34");
                RunCam34(sender, e);

                timer7.Enabled = true;

            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            PV.dio.Init("DIO000", out PV.m_Id);

            if (PF.IOCheck("1") == "0")
            {
                timer7.Enabled = false;

                //MessageBox.Show("StopCam34");
                StopCam34(sender, e);

                timer6.Enabled = true;

            }
        }



        #endregion

        #region 카메라 상태 변경

        private void bCAMERA1_State_Changed(object sender, EventArgs e)
        {

            try
            {
                if (PV.bCAMERA1_State == true)
                {
                    CAMERA1_Job.RunContinuous();

                    pic_CAM1_CONNECT_ON.Visible = true;
                    pic_CAM1_CONNECT_OFF.Visible = false;
                }
                else
                {
                    CAMERA1_Job.Stop();

                    pic_CAM1_CONNECT_ON.Visible = false;
                    pic_CAM1_CONNECT_OFF.Visible = true;

                }
            }
            catch (Exception ex)
            {
                PF.WriteSysLog("bCAMERA1_State_CheckedChanged", ex.Message);
                btnRunningStop_Click(sender, e);
            }
        }
        
        private void bCAMERA2_State_Changed(object sender, EventArgs e)
        {
            try
            {
                if (PV.bCAMERA2_State == true)
                {
                    CAMERA2_Job.RunContinuous();

                    pic_CAM2_CONNECT_ON.Visible = true;
                    pic_CAM2_CONNECT_OFF.Visible = false;

                }
                else
                {
                    CAMERA2_Job.Stop();

                    pic_CAM2_CONNECT_ON.Visible = false;
                    pic_CAM2_CONNECT_OFF.Visible = true;

                }
                //CAMERAStatus();
            }
            catch (Exception ex)
            {
                PF.WriteSysLog("bCAMERA2_State_CheckedChanged", ex.Message);
                btnRunningStop_Click(sender, e);
            }
        }

        private void bCAMERA3_State_Changed(object sender, EventArgs e)
        {
            try
            {
                if (PV.bCAMERA3_State == true)
                {
                    CAMERA3_Job.RunContinuous();

                    pic_CAM3_CONNECT_ON.Visible = true;
                    pic_CAM3_CONNECT_OFF.Visible = false;

                }
                else
                {
                    CAMERA3_Job.Stop();

                    pic_CAM3_CONNECT_ON.Visible = false;
                    pic_CAM3_CONNECT_OFF.Visible = true;

                }
                //CAMERAStatus();
            }
            catch (Exception ex)
            {
                PF.WriteSysLog("bCAMERA3_State_CheckedChanged", ex.Message);
                btnRunningStop_Click(sender, e);
            }
        }

        private void bCAMERA4_State_Changed(object sender, EventArgs e)
        {
            try
            {
                if (PV.bCAMERA4_State == true)
                {
                    CAMERA4_Job.RunContinuous();

                    pic_CAM4_CONNECT_ON.Visible = true;
                    pic_CAM4_CONNECT_OFF.Visible = false;

                }
                else
                {
                    CAMERA4_Job.Stop();

                    pic_CAM4_CONNECT_ON.Visible = false;
                    pic_CAM4_CONNECT_OFF.Visible = true;

                }
                //CAMERAStatus();
            }
            catch (Exception ex)
            {
                PF.WriteSysLog("bCAMERA4_State_CheckedChanged", ex.Message);
                btnRunningStop_Click(sender, e);
            }
        }

        #endregion

        #region 시스템 메소드

        private void CAMERAStatus()
        {
            if (PV.bCAMERA1_State || PV.bCAMERA2_State || PV.bCAMERA3_State || PV.bCAMERA4_State)
            {
                btnRunningExecute.BackColor = Color.Yellow;
                btnRunningExecute.Enabled = false;
                btnRunningStop.Enabled = true;

                bt_SetCam1.Enabled = false;
                bt_SetCam2.Enabled = false;
                bt_SetCam3.Enabled = false;
                bt_SetCam4.Enabled = false;

                bt_SetInsp1.Enabled = false;
                bt_SetInsp2.Enabled = false;
                bt_SetInsp3.Enabled = false;
                bt_SetInsp4.Enabled = false;
            }
            else if (!PV.bCAMERA1_State && !PV.bCAMERA2_State && !PV.bCAMERA3_State && !PV.bCAMERA4_State)
            {
                btnRunningExecute.BackColor = Color.Black;
                btnRunningExecute.Enabled = true;
                btnRunningStop.Enabled = false;

                bt_SetCam1.Enabled = true;
                bt_SetCam2.Enabled = true;
                bt_SetCam3.Enabled = true;
                bt_SetCam4.Enabled = true;

                bt_SetInsp1.Enabled = true;
                bt_SetInsp2.Enabled = true;
                bt_SetInsp3.Enabled = true;
                bt_SetInsp4.Enabled = true;
            }
        }
        
        public void CAMERA_JobInitialize()
        {
            try
            {
                CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA1_PATH) as CogJobManager;
                CAMERA1_Job = CAMERA1_JobManager.Job(0);
                CAMERA1_JobIndependent = CAMERA1_Job.OwnedIndependent;
                CAMERA1_JobManager.UserQueueFlush();
                CAMERA1_JobManager.FailureQueueFlush();
                CAMERA1_Job.ImageQueueFlush();
                CAMERA1_JobIndependent.RealTimeQueueFlush();
                CAMERA1_JobManager.UserResultAvailable += new CogJobManager.CogUserResultAvailableEventHandler(CAMERA1_UserResultAvailable);

                
                CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA2_PATH) as CogJobManager;
                CAMERA2_Job = CAMERA2_JobManager.Job(0);
                CAMERA2_JobIndependent = CAMERA2_Job.OwnedIndependent;
                CAMERA2_JobManager.UserQueueFlush();
                CAMERA2_JobManager.FailureQueueFlush();
                CAMERA2_Job.ImageQueueFlush();
                CAMERA2_JobIndependent.RealTimeQueueFlush();
                CAMERA2_JobManager.UserResultAvailable += new CogJobManager.CogUserResultAvailableEventHandler(CAMERA2_UserResultAvailable);


                CAMERA3_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA3_PATH) as CogJobManager;
                CAMERA3_Job = CAMERA3_JobManager.Job(0);
                CAMERA3_JobIndependent = CAMERA3_Job.OwnedIndependent;
                CAMERA3_JobManager.UserQueueFlush();
                CAMERA3_JobManager.FailureQueueFlush();
                CAMERA3_Job.ImageQueueFlush();
                CAMERA3_JobIndependent.RealTimeQueueFlush();
                CAMERA3_JobManager.UserResultAvailable += new CogJobManager.CogUserResultAvailableEventHandler(CAMERA3_UserResultAvailable);


                CAMERA4_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA4_PATH) as CogJobManager;
                CAMERA4_Job = CAMERA4_JobManager.Job(0);
                CAMERA4_JobIndependent = CAMERA4_Job.OwnedIndependent;
                CAMERA4_JobManager.UserQueueFlush();
                CAMERA4_JobManager.FailureQueueFlush();
                CAMERA4_Job.ImageQueueFlush();
                CAMERA4_JobIndependent.RealTimeQueueFlush();
                CAMERA4_JobManager.UserResultAvailable += new CogJobManager.CogUserResultAvailableEventHandler(CAMERA4_UserResultAvailable);

                
            }
            catch (Exception ex)
            {
                PF.WriteSysLog("CAMERA_JobInitialize", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        
        

        #endregion

        #region 검사 이벤트


        #region Camera 1
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
                CogFixtureTool CogFixtureTool1 = II_ToolGroup.Tools["CogFixtureTool1"] as CogFixtureTool;

                
                // 관이 있는지 확인
                bool GetLine = false;
                string sGetLine = Convert.ToString(II_ToolBlock.Outputs["Results_GetLine_Y"].Value);
                double returnGetLine = 0;
                bool bGetLine = double.TryParse(Convert.ToString(II_ToolBlock.Outputs["Results_GetLine_Y"].Value), out returnGetLine);


                if (bGetLine)
                {GetLine = true; }


                // 주름관 있음
                if (GetLine)
                {
                    Cam1_Run();

                    // 주름관 결과
                    int Results = Convert.ToInt32(II_ToolBlock.Outputs["Results"].Value);

                    PV.dio.Init("DIO000", out PV.m_Id);
                    // 주름관 - OK
                    if (Results == 1)
                    {
                        CAMERA1_OK();
                        PF.WriteDataCam1("OK", "주름관", PV.Pattern_Result_Score_11, PV.GetBlobs_Area_11, PV.CogHistogramTool_Result_Mean_11, "");

                        if (PV.bALL_Save)
                        {
                            string FileName = "";
                            FileName = PF.GetImgFileName("OK", "카메라1");

                            ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                            ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                            ImageFileTool.Run();
                            ImageFileTool.Operator.Close();
                        }
                    }
                    // 주름관 - NG
                    else
                    {
                        PV.checkNG = 0;
                        PV.checkOK = 0;

                        CheckBypass1();

                        // 결과가 OK이고 모든사진 저장이면 사진저장
                        if (PV.checkOK != 0 && PV.bALL_Save)
                        {
                            string FileName = "";
                            FileName = PF.GetImgFileName("OK", "카메라1");

                            ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                            ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                            ImageFileTool.Run();
                            ImageFileTool.Operator.Close();
                        }

                        // 결과가 NG이고 모든사진 저장이거나 NG 사진저장이면 사진저장
                        if (PV.checkNG != 0)
                        {
                            if (PV.bNG_Save || PV.bALL_Save)
                            {
                                string FileName = "";
                                FileName = PF.GetImgFileName("NG", "카메라1");

                                ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                                ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                                ImageFileTool.Run();
                                ImageFileTool.Operator.Close();
                            }

                            if (PV.bNgStop)
                            {
                                PV.bCAMERA1_State = false;
                                PV.bCAMERA2_State = false;
                                PV.bCAMERA3_State = false;
                                PV.bCAMERA4_State = false;

                                bCAMERA1_State_Changed(sender, e);
                                bCAMERA2_State_Changed(sender, e);
                                bCAMERA3_State_Changed(sender, e);
                                bCAMERA4_State_Changed(sender, e);

                                btnRunningExecute.BackColor = Color.Black;
                                btnRunningExecute.Enabled = true;
                                btnRunningStop.Enabled = false;
                            }
                        }
                    }

                


            }
                //검사체 없음
                else
                {
                    Cam1_Run();
                    CAMERA1_NG();
                    PF.WriteDataCam1("NG", "", "", "", "", "검사체없음");

                    //와이어 없음은 사진 저장x
                }
            }
            catch (Exception ex)
            {
                PF.WriteSysLog("CAMERA1_UserResultAvailable", ex.Message);
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


            PV.dio.Init("DIO000", out PV.m_Id);
            // 주름관

            // Pattern_Result_Score
            double dpattern = Convert.ToDouble(II_ToolBlock.Outputs["Pattern_Results_Score"].Value);
            PV.Pattern_Result_Score_11 = dpattern.ToString();

            // GetBlobs_Area
            double dgetblob = Convert.ToDouble(II_ToolBlock.Outputs["GetBlobs_Area"].Value);
            PV.GetBlobs_Area_11 = dgetblob.ToString();


            // Concentricity_Left_Distance
            double dmean = Convert.ToDouble(II_ToolBlock.Outputs["CogHistogramTool_Result_Mean"].Value);
            PV.CogHistogramTool_Result_Mean_11 = dmean.ToString();
        }

        void CheckBypass1()
        {
            double dPattern_Result_Score_1 = Convert.ToDouble(PV.Pattern_Result_Score_11);
            double dGetBlobs_Area_1 = Convert.ToDouble(PV.GetBlobs_Area_11);
            double dCogHistogramTool_Result_Mean_1 = Convert.ToDouble(PV.CogHistogramTool_Result_Mean_11);

            // 주름관 바이패스 true가 아니면 NG
            if (!PV.bBypass_11)
            {
                CAMERA1_NG();
                PF.WriteDataCam1("NG", "주름관", PV.Pattern_Result_Score_11, PV.GetBlobs_Area_11, PV.CogHistogramTool_Result_Mean_11, "");
                PV.checkNG++;
            }
            // true  면 OK
            else
            {
                CAMERA1_OK();
                PF.WriteDataCam1("OK", "주름관", PV.Pattern_Result_Score_11, PV.GetBlobs_Area_11, PV.CogHistogramTool_Result_Mean_11, "");
                PV.checkOK++;
            }
        }

        private void CAMERA1_NG()
        {
            try
            {
                pic_CAM1_Result.Image = global::IVSSYSTEM.Properties.Resources.fail;
                PV.nCAM1FAIL++;
                PV.nCAM1TOTAL++;
                int pass = PV.nCAM1FAIL * 100;
                PV.nCAM1PER = (pass / PV.nCAM1TOTAL);

                if (PV.bAlarmStop == false)
                {
                    PF.IOOutPutMessage("1", "0");
                    PF.IOOutPutMessage("0", "1");      // cam1 NG
                    PF.Delay(100);
                    PF.IOOutPutMessage("0", "0");      // cam1 NG

                    if (PV.bNgStop == true)
                    {
                        CAMERA1_Job.Stop();
                        CAMERA2_Job.Stop();
                        CAMERA3_Job.Stop();
                        CAMERA4_Job.Stop();
                    }
                    timer2.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                PF.WriteSysLog("CAMERA1_NG", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void CAMERA1_OK()
        {
            pic_CAM1_Result.Image = global::IVSSYSTEM.Properties.Resources.PASS;

            PV.nCAM1TOTAL++;
            int pass = PV.nCAM1FAIL * 100;
            PV.nCAM1PER = (pass / PV.nCAM1TOTAL);

            if (PV.bAlarmStop == false)
            {
                PF.IOOutPutMessage("0", "0");
                //PF.IOOutPutMessage("1", "1");      // cam1 OK
                //PF.Delay(100);
                //PF.IOOutPutMessage("1", "0");      // cam1 OK


                timer2.Enabled = true;
            }
        }

        #endregion


        #region Camera 2

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
                CogFixtureTool CogFixtureTool1 = II_ToolGroup.Tools["CogFixtureTool1"] as CogFixtureTool;


                // 관이 있는지 확인
                bool GetLine = false;
                string sGetLine = Convert.ToString(II_ToolBlock.Outputs["Results_GetLine_Y"].Value);
                double returnGetLine = 0;
                bool bGetLine = double.TryParse(Convert.ToString(II_ToolBlock.Outputs["Results_GetLine_Y"].Value), out returnGetLine);


                if (bGetLine)
                { GetLine = true; }


                // 주름관 있음
                if (GetLine)
                {
                    Cam2_Run();

                    // 주름관 결과
                    int Results = Convert.ToInt32(II_ToolBlock.Outputs["Results"].Value);

                    PV.dio.Init("DIO000", out PV.m_Id);


                    if (Results == 1)
                    {
                        CAMERA2_OK();
                        PF.WriteDataCam2("OK", "주름관", PV.Pattern_Result_Score_21, PV.GetBlobs_Area_21, PV.CogHistogramTool_Result_Mean_21, "");

                        if (PV.bALL_Save)
                        {
                            string FileName = "";
                            FileName = PF.GetImgFileName("OK", "카메라2");

                            ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                            ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                            ImageFileTool.Run();
                            ImageFileTool.Operator.Close();
                        }
                    }
                    // 주름관 - NG
                    else
                    {
                        PV.checkNG2 = 0;
                        PV.checkOK2 = 0;

                        // int result = 1 : 주름관 / 2 : 민자관
                        CheckBypass2();

                        // 결과가 OK이고 모든사진 저장이면 사진저장
                        if (PV.checkOK2 != 0 && PV.bALL_Save)
                        {
                            string FileName = "";
                            FileName = PF.GetImgFileName("OK", "카메라2");

                            ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                            ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                            ImageFileTool.Run();
                            ImageFileTool.Operator.Close();
                        }

                        // 결과가 NG이고 모든사진 저장이거나 NG 사진저장이면 사진저장
                        if (PV.checkNG2 != 0)
                        {
                            if (PV.bNG_Save || PV.bALL_Save)
                            {
                                string FileName = "";
                                FileName = PF.GetImgFileName("NG", "카메라2");

                                ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                                ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                                ImageFileTool.Run();
                                ImageFileTool.Operator.Close();
                            }

                            if (PV.bNgStop)
                            {
                                PV.bCAMERA1_State = false;
                                PV.bCAMERA2_State = false;
                                PV.bCAMERA3_State = false;
                                PV.bCAMERA4_State = false;

                                bCAMERA1_State_Changed(sender, e);
                                bCAMERA2_State_Changed(sender, e);
                                bCAMERA3_State_Changed(sender, e);
                                bCAMERA4_State_Changed(sender, e);

                                btnRunningExecute.BackColor = Color.Black;
                                btnRunningExecute.Enabled = true;
                                btnRunningStop.Enabled = false;
                            }
                        }
                    }

                }
                //검사체 없음
                else
                {
                    Cam2_Run();
                    CAMERA2_NG();
                    PF.WriteDataCam2("NG", "", "", "", "", "검사체없음");

                    //와이어 없음은 사진 저장x
                }
            }
            catch (Exception ex)
            {
                PF.WriteSysLog("CAMERA2_UserResultAvailable", ex.Message);
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

            PV.dio.Init("DIO000", out PV.m_Id);
            // 주름관
            // Pattern_Result_Score
            double dpattern = Convert.ToDouble(II_ToolBlock.Outputs["Pattern_Results_Score"].Value);
            PV.Pattern_Result_Score_21 = dpattern.ToString();

            // GetBlobs_Area
            double dgetblob = Convert.ToDouble(II_ToolBlock.Outputs["GetBlobs_Area"].Value);
            PV.GetBlobs_Area_21 = dgetblob.ToString();


            // Concentricity_Left_Distance
            double dmean = Convert.ToDouble(II_ToolBlock.Outputs["CogHistogramTool_Result_Mean"].Value);
            PV.CogHistogramTool_Result_Mean_21 = dmean.ToString();
        }

        void CheckBypass2()
        {
            double dPattern_Result_Score_1 = Convert.ToDouble(PV.Pattern_Result_Score_21);
            double dGetBlobs_Area_1 = Convert.ToDouble(PV.GetBlobs_Area_21);
            double dCogHistogramTool_Result_Mean_1 = Convert.ToDouble(PV.CogHistogramTool_Result_Mean_21);



            // 주름관 바이패스 true가 아니면 NG
            if (!PV.bBypass_21)
            {
                CAMERA2_NG();
                PF.WriteDataCam2("NG", "주름관", PV.Pattern_Result_Score_21, PV.GetBlobs_Area_21, PV.CogHistogramTool_Result_Mean_21, "");
                PV.checkNG2++;
            }
            // true  면 OK
            else
            {
                CAMERA2_OK();
                PF.WriteDataCam2("OK", "주름관", PV.Pattern_Result_Score_21, PV.GetBlobs_Area_21, PV.CogHistogramTool_Result_Mean_21, "");
                PV.checkOK2++;
            }


        }

         private void CAMERA2_NG()
        {
            pic_CAM2_Result.Image = global::IVSSYSTEM.Properties.Resources.fail;
            PV.nCAM2FAIL++;
            PV.nCAM2TOTAL++;
            int fail = PV.nCAM2FAIL * 100;
            PV.nCAM2PER = (fail / PV.nCAM2TOTAL);

            if (PV.bAlarmStop == false)
            {
                PF.IOOutPutMessage("3", "0");
                PF.IOOutPutMessage("2", "1");      // cam2 NG
                PF.Delay(100);
                PF.IOOutPutMessage("2", "0");      // cam2 NG


                if (PV.bNgStop == true)
                {
                    CAMERA1_Job.Stop();
                    CAMERA2_Job.Stop();
                    CAMERA3_Job.Stop();
                    CAMERA4_Job.Stop();
                }


                timer2.Enabled = true;

            }

        }


        private void CAMERA2_OK()
        {
            pic_CAM2_Result.Image = global::IVSSYSTEM.Properties.Resources.PASS;

            PV.nCAM2TOTAL++;
            int fail = PV.nCAM2FAIL * 100;
            PV.nCAM2PER = (fail / PV.nCAM2TOTAL);

            if (PV.bAlarmStop == false)
            {
                PF.IOOutPutMessage("2", "0");
                //PF.IOOutPutMessage("3", "1");      // cam2 OK
                //PF.Delay(100);
                //PF.IOOutPutMessage("3", "0");      // cam2 OK



                timer2.Enabled = true;
            }
        }

        #endregion


        #region Camera 3

        void CAMERA3_UserResultAvailable(object sender, CogJobManagerActionEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CAMERA3_Delegate(CAMERA3_UserResultAvailable), new object[] { sender, e });
                return;
            }

            try
            {


                II_ToolGroup = CAMERA3_Job.VisionTool as CogToolGroup;
                II_ToolBlock = II_ToolGroup.Tools["Results"] as CogToolBlock;
                CogFixtureTool CogFixtureTool1 = II_ToolGroup.Tools["CogFixtureTool1"] as CogFixtureTool;


                // 관이 있는지 확인
                bool GetLine = false;
                string sGetLine = Convert.ToString(II_ToolBlock.Outputs["Results_GetLine_Y"].Value);
                double returnGetLine = 0;
                bool bGetLine = double.TryParse(Convert.ToString(II_ToolBlock.Outputs["Results_GetLine_Y"].Value), out returnGetLine);


                if (bGetLine)
                { GetLine = true; }


                // 주름관 있음
                if (GetLine)
                {
                    Cam3_Run();

                    // 주름관 결과
                    int Results = Convert.ToInt32(II_ToolBlock.Outputs["Results"].Value);

                    PV.dio.Init("DIO000", out PV.m_Id);


                    // 주름관 - OK
                    if (Results == 1)
                    {
                        CAMERA3_OK();
                        PF.WriteDataCam3("OK", "주름관", PV.Pattern_Result_Score_31, PV.GetBlobs_Area_31, PV.CogHistogramTool_Result_Mean_31, "");

                        if (PV.bALL_Save)
                        {
                            string FileName = "";
                            FileName = PF.GetImgFileName("OK", "카메라3");

                            ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                            ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                            ImageFileTool.Run();
                            ImageFileTool.Operator.Close();
                        }
                    }
                    // 주름관 - NG
                    else
                    {
                        PV.checkNG3 = 0;
                        PV.checkOK3 = 0;

                        // int result = 1 : 주름관 / 2 : 민자관
                        CheckBypass3();

                        // 결과가 OK이고 모든사진 저장이면 사진저장
                        if (PV.checkOK3 != 0 && PV.bALL_Save)
                        {
                            string FileName = "";
                            FileName = PF.GetImgFileName("OK", "카메라3");

                            ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                            ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                            ImageFileTool.Run();
                            ImageFileTool.Operator.Close();
                        }

                        // 결과가 NG이고 모든사진 저장이거나 NG 사진저장이면 사진저장
                        if (PV.checkNG3 != 0)
                        {
                            if (PV.bNG_Save || PV.bALL_Save)
                            {
                                string FileName = "";
                                FileName = PF.GetImgFileName("NG", "카메라3");

                                ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                                ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                                ImageFileTool.Run();
                                ImageFileTool.Operator.Close();
                            }

                            if (PV.bNgStop)
                            {
                                PV.bCAMERA1_State = false;
                                PV.bCAMERA2_State = false;
                                PV.bCAMERA3_State = false;
                                PV.bCAMERA4_State = false;

                                bCAMERA1_State_Changed(sender, e);
                                bCAMERA2_State_Changed(sender, e);
                                bCAMERA3_State_Changed(sender, e);
                                bCAMERA4_State_Changed(sender, e);

                                btnRunningExecute.BackColor = Color.Black;
                                btnRunningExecute.Enabled = true;
                                btnRunningStop.Enabled = false;
                            }
                        }
                    }

                }
                //검사체 없음
                else
                {
                    Cam3_Run();
                    CAMERA3_NG();
                    PF.WriteDataCam3("NG", "", "", "", "", "검사체없음");

                    //와이어 없음은 사진 저장x
                }
            }
            catch (Exception ex)
            {
                PF.WriteSysLog("CAMERA3_UserResultAvailable", ex.Message);
                MessageBox.Show(ex.Message);
            }

        }
        
        void Cam3_Run()
        {
            ICogRecord topRecord = null;
            topRecord = CAMERA3_JobManager.UserResult();
            ICogRecord tmpRecord = null;
            tmpRecord = topRecord.SubRecords["ShowLastRunRecordForUserQueue"];
            tmpRecord = tmpRecord.SubRecords["LastRun"];
            tmpRecord = tmpRecord.SubRecords["Image Source.OutputImage"];

            cogRecordDisplay_CAMERA3.Record = tmpRecord;
            cogRecordDisplay_CAMERA3.AutoFit = true;


            // Pattern_Result_Score
            double dpattern = Convert.ToDouble(II_ToolBlock.Outputs["Pattern_Results_Score"].Value);
            PV.Pattern_Result_Score_31 = dpattern.ToString();

            // GetBlobs_Area
            double dgetblob = Convert.ToDouble(II_ToolBlock.Outputs["GetBlobs_Area"].Value);
            PV.GetBlobs_Area_31 = dgetblob.ToString();


            // Concentricity_Left_Distance
            double dmean = Convert.ToDouble(II_ToolBlock.Outputs["CogHistogramTool_Result_Mean"].Value);
            PV.CogHistogramTool_Result_Mean_31 = dmean.ToString();

        }

        void CheckBypass3()
        {
            double dPattern_Result_Score_1 = Convert.ToDouble(PV.Pattern_Result_Score_31);
            double dGetBlobs_Area_1 = Convert.ToDouble(PV.GetBlobs_Area_31);
            double dCogHistogramTool_Result_Mean_1 = Convert.ToDouble(PV.CogHistogramTool_Result_Mean_31);

            // 주름관 바이패스 true가 아니면 NG
            if (!PV.bBypass_31)
            {
                CAMERA3_NG();
                PF.WriteDataCam3("NG", "주름관", PV.Pattern_Result_Score_31, PV.GetBlobs_Area_31, PV.CogHistogramTool_Result_Mean_31, "");
                PV.checkNG3++;
            }
            // true  면 OK
            else
            {
                CAMERA3_OK();
                PF.WriteDataCam3("OK", "주름관", PV.Pattern_Result_Score_31, PV.GetBlobs_Area_31, PV.CogHistogramTool_Result_Mean_31, "");
                PV.checkOK3++;
            }


        }

        private void CAMERA3_NG()
        {
            pic_CAM3_Result.Image = global::IVSSYSTEM.Properties.Resources.fail;
            PV.nCAM3FAIL++;
            PV.nCAM3TOTAL++;
            int fail = PV.nCAM3FAIL * 100;
            PV.nCAM3PER = (fail / PV.nCAM3TOTAL);

            if (PV.bAlarmStop == false)
            {
                PF.IOOutPutMessage("5", "0");
                PF.IOOutPutMessage("4", "1");      // cam3 NG
                PF.Delay(100);
                PF.IOOutPutMessage("4", "0");      // cam3 NG

                if (PV.bNgStop == true)
                {
                    CAMERA1_Job.Stop();
                    CAMERA2_Job.Stop();
                    CAMERA3_Job.Stop();
                    CAMERA4_Job.Stop();
                }


                timer2.Enabled = true;

            }

        }

        private void CAMERA3_OK()
        {
            pic_CAM3_Result.Image = global::IVSSYSTEM.Properties.Resources.PASS;

            PV.nCAM3TOTAL++;
            int fail = PV.nCAM3FAIL * 100;
            PV.nCAM3PER = (fail / PV.nCAM3TOTAL);

            if (PV.bAlarmStop == false)
            {
                PF.IOOutPutMessage("4", "0");
                //PF.IOOutPutMessage("5", "1");      // cam3 OK
                //PF.Delay(100);
                //PF.IOOutPutMessage("5", "0");      // cam3 OK

                timer2.Enabled = true;
            }
        }


        #endregion


        #region Camera 4

        void CAMERA4_UserResultAvailable(object sender, CogJobManagerActionEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CAMERA4_Delegate(CAMERA4_UserResultAvailable), new object[] { sender, e });
                return;
            }

            try
            {


                II_ToolGroup = CAMERA4_Job.VisionTool as CogToolGroup;
                II_ToolBlock = II_ToolGroup.Tools["Results"] as CogToolBlock;
                CogFixtureTool CogFixtureTool1 = II_ToolGroup.Tools["CogFixtureTool1"] as CogFixtureTool;


                // 관이 있는지 확인
                bool GetLine = false;
                string sGetLine = Convert.ToString(II_ToolBlock.Outputs["Results_GetLine_Y"].Value);
                double returnGetLine = 0;
                bool bGetLine = double.TryParse(Convert.ToString(II_ToolBlock.Outputs["Results_GetLine_Y"].Value), out returnGetLine);


                if (bGetLine)
                { GetLine = true; }


                // 주름관 있음
                if (GetLine)
                {
                    Cam4_Run();

                    // 주름관 결과
                    int Results = Convert.ToInt32(II_ToolBlock.Outputs["Results"].Value);

                    PV.dio.Init("DIO000", out PV.m_Id);


                    // 주름관 - OK
                    if (Results == 1)
                    {
                        CAMERA4_OK();
                        PF.WriteDataCam4("OK", "주름관", PV.Pattern_Result_Score_41, PV.GetBlobs_Area_41, PV.CogHistogramTool_Result_Mean_41, "");

                        if (PV.bALL_Save)
                        {
                            string FileName = "";
                            FileName = PF.GetImgFileName("OK", "카메라4");

                            ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                            ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                            ImageFileTool.Run();
                            ImageFileTool.Operator.Close();
                        }
                    }
                    // 주름관 - NG
                    else
                    {
                        PV.checkNG4 = 0;
                        PV.checkOK4 = 0;

                        // int result = 1 : 주름관 / 2 : 민자관
                        CheckBypass4();

                        // 결과가 OK이고 모든사진 저장이면 사진저장
                        if (PV.checkOK4 != 0 && PV.bALL_Save)
                        {
                            string FileName = "";
                            FileName = PF.GetImgFileName("OK", "카메라4");

                            ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                            ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                            ImageFileTool.Run();
                            ImageFileTool.Operator.Close();
                        }

                        // 결과가 NG이고 모든사진 저장이거나 NG 사진저장이면 사진저장
                        if (PV.checkNG4 != 0)
                        {
                            if (PV.bNG_Save || PV.bALL_Save)
                            {
                                string FileName = "";
                                FileName = PF.GetImgFileName("NG", "카메라4");

                                ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                                ImageFileTool.InputImage = (CogImage8Grey)CogFixtureTool1.InputImage;
                                ImageFileTool.Run();
                                ImageFileTool.Operator.Close();
                            }

                            if (PV.bNgStop)
                            {
                                PV.bCAMERA1_State = false;
                                PV.bCAMERA2_State = false;
                                PV.bCAMERA3_State = false;
                                PV.bCAMERA4_State = false;

                                bCAMERA1_State_Changed(sender, e);
                                bCAMERA2_State_Changed(sender, e);
                                bCAMERA3_State_Changed(sender, e);
                                bCAMERA4_State_Changed(sender, e);

                                btnRunningExecute.BackColor = Color.Black;
                                btnRunningExecute.Enabled = true;
                                btnRunningStop.Enabled = false;
                            }
                        }
                    }

                }
                //검사체 없음
                else
                {
                    Cam4_Run();
                    CAMERA4_NG();
                    PF.WriteDataCam4("NG", "", "", "", "", "검사체없음");

                    //와이어 없음은 사진 저장x
                }
            }
            catch (Exception ex)
            {
                PF.WriteSysLog("CAMERA4_UserResultAvailable", ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        void Cam4_Run()
        {
            ICogRecord topRecord = null;
            topRecord = CAMERA4_JobManager.UserResult();
            ICogRecord tmpRecord = null;
            tmpRecord = topRecord.SubRecords["ShowLastRunRecordForUserQueue"];
            tmpRecord = tmpRecord.SubRecords["LastRun"];
            tmpRecord = tmpRecord.SubRecords["Image Source.OutputImage"];

            cogRecordDisplay_CAMERA4.Record = tmpRecord;
            cogRecordDisplay_CAMERA4.AutoFit = true;

            // Pattern_Result_Score
            double dpattern = Convert.ToDouble(II_ToolBlock.Outputs["Pattern_Results_Score"].Value);
            PV.Pattern_Result_Score_41 = dpattern.ToString();

            // GetBlobs_Area
            double dgetblob = Convert.ToDouble(II_ToolBlock.Outputs["GetBlobs_Area"].Value);
            PV.GetBlobs_Area_41 = dgetblob.ToString();


            // Concentricity_Left_Distance
            double dmean = Convert.ToDouble(II_ToolBlock.Outputs["CogHistogramTool_Result_Mean"].Value);
            PV.CogHistogramTool_Result_Mean_41 = dmean.ToString();

        }

        void CheckBypass4()
        {
            double dPattern_Result_Score_1 = Convert.ToDouble(PV.Pattern_Result_Score_41);
            double dGetBlobs_Area_1 = Convert.ToDouble(PV.GetBlobs_Area_41);
            double dCogHistogramTool_Result_Mean_1 = Convert.ToDouble(PV.CogHistogramTool_Result_Mean_41);

            // 주름관 바이패스 true가 아니면 NG
            if (!PV.bBypass_41)
            {
                CAMERA4_NG();
                PF.WriteDataCam4("NG", "주름관", PV.Pattern_Result_Score_41, PV.GetBlobs_Area_41, PV.CogHistogramTool_Result_Mean_41, "");
                PV.checkNG4++;
            }
            // true  면 OK
            else
            {
                CAMERA4_OK();
                PF.WriteDataCam4("OK", "주름관", PV.Pattern_Result_Score_41, PV.GetBlobs_Area_41, PV.CogHistogramTool_Result_Mean_41, "");
                PV.checkOK4++;
            }

        }

        private void CAMERA4_NG()
        {
            pic_CAM4_Result.Image = global::IVSSYSTEM.Properties.Resources.fail;
            PV.nCAM4FAIL++;
            PV.nCAM4TOTAL++;
            int fail = PV.nCAM4FAIL * 100;
            PV.nCAM4PER = (fail / PV.nCAM4TOTAL);

            if (PV.bAlarmStop == false)
            {
                PF.IOOutPutMessage("7", "0");
                PF.IOOutPutMessage("6", "1");      // cam4 NG
                PF.Delay(100);
                PF.IOOutPutMessage("6", "0");      // cam4 NG


                if (PV.bNgStop == true)
                {
                    CAMERA1_Job.Stop();
                    CAMERA2_Job.Stop();
                    CAMERA3_Job.Stop();
                    CAMERA4_Job.Stop();

                }


                timer2.Enabled = true;

            }

        }
        
        private void CAMERA4_OK()
        {
            pic_CAM4_Result.Image = global::IVSSYSTEM.Properties.Resources.PASS;

            PV.nCAM4TOTAL++;
            int fail = PV.nCAM4FAIL * 100;
            PV.nCAM4PER = (fail / PV.nCAM4TOTAL);

            if (PV.bAlarmStop == false)
            {
                PF.IOOutPutMessage("6", "0");
                //PF.IOOutPutMessage("7", "1");      // cam4 OK
                //PF.Delay(100);
                //PF.IOOutPutMessage("7", "0");      // cam4 OK


                timer2.Enabled = true;
            }
        }

        #endregion

        #endregion

        #region Cam run/stop

        public void RunCam12(object sender, EventArgs e)
        {
            try
            {
                Run = true;

                btnRunningExecute.Enabled = false;
                btnRunningExecute.Visible = false;
                btnRunningStop.Enabled = true;
                btnRunningStop.Visible = true;
                btnReset.Enabled = false;
                btnReset.BackgroundImage = global::IVSSYSTEM.Properties.Resources._null;
                btnExit.Enabled = false;


                bt_SetCam1.Enabled = false;
                bt_SetCam2.Enabled = false;

                bt_SetInsp1.Enabled = false;
                bt_SetInsp2.Enabled = false;


                PV.bCAMERA1_State = true;
                PV.bCAMERA2_State = true;

                bCAMERA1_State_Changed(sender, e);
                bCAMERA2_State_Changed(sender, e);

                

                PF.WriteSysLog("timer4_Tick", "CAM1, CAM2 Start");

            }
            catch (Exception ex)
            {
                PF.WriteSysLog("timer4_Tick", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        public void StopCam12(object sender, EventArgs e)
        {
            try
            {
                Run = false;


                btnRunningExecute.Enabled = true;
                btnRunningExecute.Visible = true;
                btnRunningStop.Enabled = false;
                btnRunningStop.Visible = false;
                btnReset.Enabled = true;
                btnReset.BackgroundImage = global::IVSSYSTEM.Properties.Resources.KakaoTalk_20210629_172802482;
                btnExit.Enabled = true;

                bt_SetCam1.Enabled = true;
                bt_SetCam2.Enabled = true;

                bt_SetInsp1.Enabled = true;
                bt_SetInsp2.Enabled = true;

                cbALL_Save.Enabled = true;
                cbNgStop.Enabled = true;
                cbNG_Save.Enabled = true;


                PV.bCAMERA1_State = false;
                PV.bCAMERA2_State = false;

                bCAMERA1_State_Changed(sender, e);
                bCAMERA2_State_Changed(sender, e);


                

                PF.IOOutPutMessage("0", "0");      // cam1 NG
                PF.IOOutPutMessage("1", "0");      // cam1 OK
                PF.IOOutPutMessage("2", "0");      // cam2 NG
                PF.IOOutPutMessage("3", "0");      // cam2 OK

                PF.WriteSysLog("timer5_Tick", "CAM1, CAM2 Stop");

            }
            catch (Exception ex)
            {
                PF.WriteSysLog("timer5_Tick", ex.Message);
                MessageBox.Show(ex.Message);
            }

        }


        public void RunCam34(object sender, EventArgs e)
        {
            try
            {
                Run = true;

                btnRunningExecute.Enabled = false;
                btnRunningExecute.Visible = false;
                btnRunningStop.Enabled = true;
                btnRunningStop.Visible = true;
                btnReset.Enabled = false;
                btnReset.BackgroundImage = global::IVSSYSTEM.Properties.Resources._null;
                btnExit.Enabled = false;


                bt_SetCam3.Enabled = false;
                bt_SetCam4.Enabled = false;

                bt_SetInsp3.Enabled = false;
                bt_SetInsp4.Enabled = false;


                PV.bCAMERA3_State = true;
                PV.bCAMERA4_State = true;

                bCAMERA3_State_Changed(sender, e);
                bCAMERA4_State_Changed(sender, e);

                

                PF.WriteSysLog("timer6_Tick", "CAM3, CAM4 Start");

            }
            catch (Exception ex)
            {
                PF.WriteSysLog("timer6_Tick", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        public void StopCam34(object sender, EventArgs e)
        {
            try
            {
                Run = false;


                btnRunningExecute.Enabled = true;
                btnRunningExecute.Visible = true;
                btnRunningStop.Enabled = false;
                btnRunningStop.Visible = false;
                btnReset.Enabled = true;
                btnReset.BackgroundImage = global::IVSSYSTEM.Properties.Resources.KakaoTalk_20210629_172802482;
                btnExit.Enabled = true;

                bt_SetCam3.Enabled = true;
                bt_SetCam4.Enabled = true;

                bt_SetInsp3.Enabled = true;
                bt_SetInsp4.Enabled = true;

                cbALL_Save.Enabled = true;
                cbNgStop.Enabled = true;
                cbNG_Save.Enabled = true;


                PV.bCAMERA3_State = false;
                PV.bCAMERA4_State = false;

                bCAMERA3_State_Changed(sender, e);
                bCAMERA4_State_Changed(sender, e);


                

                PF.IOOutPutMessage("4", "0");      // cam3 NG
                PF.IOOutPutMessage("5", "0");      // cam3 OK
                PF.IOOutPutMessage("6", "0");      // cam4 NG
                PF.IOOutPutMessage("7", "0");      // cam4 OK

                PF.WriteSysLog("timer7_Tick", "CAM3, CAM4 Stop");

            }
            catch (Exception ex)
            {
                PF.WriteSysLog("timer7_Tick", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region 클릭 이벤트

        private void bt_SetInsp1_Click(object sender, EventArgs e)
        {
            Form1 newform = new Form1();
            newform.MainForm = this;
            newform.ShowDialog();
        }

        private void bt_SetInsp2_Click(object sender, EventArgs e)
        {
            Form2 newform = new Form2();
            newform.MainForm = this;
            newform.ShowDialog();
        }

        private void bt_SetInsp3_Click(object sender, EventArgs e)
        {
            Form3 newform = new Form3();
            newform.MainForm = this;
            newform.ShowDialog();
        }

        private void bt_SetInsp4_Click(object sender, EventArgs e)
        {
            Form4 newform = new Form4();
            newform.MainForm = this;
            newform.ShowDialog();
        }



        private void bt_SetCam1_Click(object sender, EventArgs e)
        {
            
            PF.WriteSysLog("bt_SetCam1_Click", "CAM1 JOB SETTING ");
            if (Run == false)
            {
                if (form5 == null || form5.Text == "Setting")
                {
                    form5 = new Form5(PV.CAMERA1_PATH);
                    form5.ShowDialog();
                }
                else
                {form5.Activate();}
            }



        }

        private void bt_SetCam2_Click(object sender, EventArgs e)
        {
            PF.WriteSysLog("bt_SetCam2_Click", "CAM2 JOB SETTING ");
            if (Run == false)
            {
                if (form5 == null || form5.Text == "Setting")
                {
                    form5 = new Form5(PV.CAMERA2_PATH);
                    form5.ShowDialog();
                }
                else
                {form5.Activate();}
            }
        }


        private void bt_SetCam3_Click(object sender, EventArgs e)
        {
            PF.WriteSysLog("bt_SetCam3_Click", "CAM3 JOB SETTING ");
            if (Run == false)
            {
                if (form5 == null || form5.Text == "Setting")
                {
                    form5 = new Form5(PV.CAMERA3_PATH);
                    form5.ShowDialog();
                }
                else
                { form5.Activate();}
            }
        }

        private void bt_SetCam4_Click(object sender, EventArgs e)
        {
            PF.WriteSysLog("bt_SetCam4_Click", "CAM4 JOB SETTING ");
            if (Run == false)
            {
                if (form5 == null || form5.Text == "Setting")
                {
                    form5 = new Form5(PV.CAMERA4_PATH);
                    form5.ShowDialog();
                }
                else
                {form5.Activate();}
            }
        }

        

        private void btnReset_Click(object sender, EventArgs e)
        {

            //CAM1Stopwatch.Reset();
            //CAM2Stopwatch.Reset();

            pic_CAM1_Result.Image = null;
            pic_CAM2_Result.Image = null;
            pic_CAM3_Result.Image = null;
            pic_CAM4_Result.Image = null;

            PV.nCAM1TOTAL = 0;
            PV.nCAM1FAIL = 0;
            PV.nCAM1PER = 0;

            PV.nCAM2TOTAL = 0;
            PV.nCAM2FAIL = 0;
            PV.nCAM2PER = 0;

            PV.nCAM3TOTAL = 0;
            PV.nCAM3FAIL = 0;
            PV.nCAM3PER = 0;

            PV.nCAM4TOTAL = 0;
            PV.nCAM4FAIL = 0;
            PV.nCAM4PER = 0;

            cogRecordDisplay_CAMERA1.Record = null;
            cogRecordDisplay_CAMERA1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            cogRecordDisplay_CAMERA2.Record = null;
            cogRecordDisplay_CAMERA2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));

            cogRecordDisplay_CAMERA3.Record = null;
            cogRecordDisplay_CAMERA3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            cogRecordDisplay_CAMERA4.Record = null;
            cogRecordDisplay_CAMERA4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            
            
            PV.dio.Init("DIO000", out PV.m_Id);

            PF.IOOutPutMessage("0", "0");       // cam1 NG
            PF.IOOutPutMessage("1", "0");       // cam1 OK
            PF.IOOutPutMessage("2", "0");       // cam2 NG
            PF.IOOutPutMessage("3", "0");       // cam2 OK
            PF.IOOutPutMessage("4", "0");       // cam3 NG
            PF.IOOutPutMessage("5", "0");       // cam3 OK
            PF.IOOutPutMessage("6", "0");       // cam4 NG
            PF.IOOutPutMessage("7", "0");       // cam4 OK

        }
        
        private void cbNG_Save_CheckedChanged(object sender, EventArgs e)
        {
            PV.bNG_Save = cbNG_Save.Checked;
            PF.WriteSysLog("cbNG_Save_CheckedChanged", "NG IMG SAVE : " + cbNG_Save.Checked);
        }
        
        private void cbALL_Save_CheckedChanged(object sender, EventArgs e)
        {
            PV.bALL_Save = cbALL_Save.Checked;

            PF.WriteSysLog("cbALL_Save_CheckedChanged", "ALL IMG SAVE : " + cbALL_Save.Checked);
        }

        private void cbNgStop_CheckedChanged(object sender, EventArgs e)
        {
            PV.bNgStop = cbNgStop.Checked;
            PF.WriteSysLog("cbNgStop_CheckedChanged", "NG STOP : " + cbNgStop.Checked);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PV.dio.Init("DIO000", out PV.m_Id);

            PF.IOOutPutMessage("0", "0");       // cam1 NG
            PF.IOOutPutMessage("1", "0");       // cam1 OK
            PF.IOOutPutMessage("2", "0");       // cam2 NG
            PF.IOOutPutMessage("3", "0");       // cam2 OK
            PF.IOOutPutMessage("4", "0");       // cam3 NG
            PF.IOOutPutMessage("5", "0");       // cam3 OK
            PF.IOOutPutMessage("6", "0");       // cam4 NG
            PF.IOOutPutMessage("7", "0");       // cam4 OK

            PV.dio.Exit(0);

            PF.ProcessKill("IVSSYSTEM");
            PF.WriteSysLog("MainForm_FormClosing", "MAINFORM CLOSE");
        }

        private void btn_BuzzOff_Click(object sender, EventArgs e)
        {
            try
            {
                PF.WriteSysLog("btn_BuzzOff_Click", "BUZZER OFF");
            }
            catch (Exception ex)
            {
                PF.WriteSysLog("btn_BuzzOff_Click", ex.Message);
            }
        }

        #endregion

        #region 기타


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

        #endregion

      
       
    }
}
