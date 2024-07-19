using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.QuickBuild;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.ToolGroup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chsj
{
    public partial class Form1 : Form
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
        #endregion

        #region Inspection Result Setting 변수

        public CogToolGroup II_ToolGroup = null;
        public CogToolBlock II_ToolBlock = null;

        CogImageFileTool ImageFileTool = new CogImageFileTool();
        #endregion
        public Form1()
        {
            InitializeComponent();
            CAMERA_JobInitialize();
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

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }
        }

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
                II_ToolBlock = II_ToolGroup.Tools["Result"] as CogToolBlock;

                ICogRecord topRecord = null;
                topRecord = CAMERA1_JobManager.UserResult();
                ICogRecord tmpRecord = null;
                tmpRecord = topRecord.SubRecords["ShowLastRunRecordForUserQueue"];
                tmpRecord = tmpRecord.SubRecords["LastRun"];
                tmpRecord = tmpRecord.SubRecords["Image Source.OutputImage"];

                this.Invoke(new Action(delegate ()
                {
                    cogRecordDisplay_CAMERA1.Record = tmpRecord;
                    cogRecordDisplay_CAMERA1.AutoFit = true;
                }));
                PF.Delay(100);
                PV.dDistanceL = Math.Round(Convert.ToDouble(II_ToolBlock.Outputs["Distance"].Value));       // distance 값

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void CAMERA2_UserResultAvailable(object sender, CogJobManagerActionEventArgs e)
        {


            if (InvokeRequired)
            {
                Invoke(new CAMERA1_Delegate(CAMERA2_UserResultAvailable), new object[] { sender, e });
                return;
            }

            try
            {
                II_ToolGroup = CAMERA2_Job.VisionTool as CogToolGroup;
                II_ToolBlock = II_ToolGroup.Tools["Result"] as CogToolBlock;

                ICogRecord topRecord = null;
                topRecord = CAMERA2_JobManager.UserResult();
                ICogRecord tmpRecord = null;
                tmpRecord = topRecord.SubRecords["ShowLastRunRecordForUserQueue"];
                tmpRecord = tmpRecord.SubRecords["LastRun"];
                tmpRecord = tmpRecord.SubRecords["Image Source.OutputImage"];

                this.Invoke(new Action(delegate ()
                {
                    cogRecordDisplay_CAMERA2.Record = tmpRecord;
                    cogRecordDisplay_CAMERA2.AutoFit = true;
                }));
                PF.Delay(100);
                PV.dDistanceR = Math.Round(Convert.ToDouble(II_ToolBlock.Outputs["Distance"].Value));       // distance 값



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_EXIT_Click(object sender, EventArgs e)
        {
            PF.ProcessKill("IVS_SYSTEM");
            this.Close();
        }

        private void tb_LLower_TextChanged(object sender, EventArgs e)
        {
            PV.dLLower = Convert.ToDouble(tb_LLower.Text);
        }

        private void tb_LUpper_TextChanged(object sender, EventArgs e)
        {
            PV.dLUpper = Convert.ToDouble(tb_LUpper.Text);
        }

        private void btn_trigger_Click(object sender, EventArgs e)
        {
            CAMERA1_Job.Run();
            PF.Delay(100);
            CAMERA2_Job.Run();

            // 전체 검사 시작
            PF.Delay(100);
            PV.dResult = PV.dCameraD + PV.dDistanceL + PV.dDistanceR;

            if ((PV.dLLower <= PV.dResult) && (PV.dResult <= PV.dLUpper))               // ok
            {
                this.Invoke(new Action(delegate ()
                {
                    lb_Distance.Text = PV.dResult.ToString();
                    lb_Distance.ForeColor = System.Drawing.Color.LimeGreen;
                }));
            }
            else
            {
                this.Invoke(new Action(delegate ()
                {
                    lb_Distance.Text = PV.dResult.ToString();
                    lb_Distance.ForeColor = System.Drawing.Color.Red;
                }));
            }
        }

        private void tb_CenterDis_TextChanged(object sender, EventArgs e)
        {
            PV.dCameraD = Convert.ToDouble(tb_CenterDis.Text);
        }
    }
}
