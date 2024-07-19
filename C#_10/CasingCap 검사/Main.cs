using Cognex.VisionPro;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.QuickBuild;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.ToolGroup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chsj
{
    public partial class Main : Form
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

        #region Inspection Result Setting 변수

        public CogToolGroup II_ToolGroup = null;
        public CogToolBlock II_ToolBlock = null;

        CogImageFileTool ImageFileTool = new CogImageFileTool();
        #endregion

        #region 자식창 변수

        Model model = null;
        Add_ModelList addmodel = null;
        #endregion

        Library lib = new Library();

        public object sender { get; private set; }
        public EventArgs e { get; private set; }

        public Main()
        {
            InitializeComponent();

            PF.DioInit();
            IOTriggerStart();


            PF.ReadModelData();


            Task taskGetModel = new Task(Task_GetModel);
            taskGetModel.Start();


            pb_FileLoading.Visible = false;


        }

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
                CogPMAlignTool CogPMAlignTool1 = II_ToolGroup.Tools["CogPMAlignTool1"] as CogPMAlignTool;
                string Logtime = PV.lib.getTime("YYMMDD");

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


                PV.Cam1_Results_Item_0_Score = Convert.ToDouble(II_ToolBlock.Outputs["Results_Item_0_Score"].Value);
                PV.Cam1_Results_GetBlobs_Count = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Count"].Value); ;
                PV.Cam1_Results_GetBlobs_Item_0_Area = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Item_0_Area"].Value); ;
                PV.Cam1_Results_GetBlobs_Count1 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Count1"].Value); ;
                PV.Cam1_Results_GetBlobs_Item_0_Area1 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Item_0_Area1"].Value); ;
                PV.Cam1_Results_GetBlobs_Count2 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Count2"].Value); ;
                PV.Cam1_Results_GetBlobs_Item_0_Area2 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Item_0_Area2"].Value); ;
                PV.Cam1_Result_Mean = Convert.ToDouble(II_ToolBlock.Outputs["Result_Mean"].Value); ;
                PV.Cam1_Result_StandardDeviation = Convert.ToDouble(II_ToolBlock.Outputs["Result_StandardDeviation"].Value); ;
                PV.Cam1_Result_Mean1 = Convert.ToDouble(II_ToolBlock.Outputs["Result_Mean1"].Value); ;
                PV.Cam1_Result_StandardDeviation1 = Convert.ToDouble(II_ToolBlock.Outputs["Result_StandardDeviation1"].Value); ;

                PV.nTotalCount1++;


                // ng
                if (((PV.Cam1_Results_Item_0_Score < Convert.ToDouble(PV.stringArray_Limit1[0])) ||
                    (PV.Cam1_Results_GetBlobs_Count < Convert.ToDouble(PV.stringArray_Limit1[1])) ||
                    (PV.Cam1_Results_GetBlobs_Item_0_Area < Convert.ToDouble(PV.stringArray_Limit1[2])) ||
                    (PV.Cam1_Results_GetBlobs_Count1 < Convert.ToDouble(PV.stringArray_Limit1[3])) ||
                    (PV.Cam1_Results_GetBlobs_Item_0_Area1 < Convert.ToDouble(PV.stringArray_Limit1[4])) ||
                    (PV.Cam1_Results_GetBlobs_Count2 < Convert.ToDouble(PV.stringArray_Limit1[5])) ||
                    (PV.Cam1_Results_GetBlobs_Item_0_Area2 < Convert.ToDouble(PV.stringArray_Limit1[6])) ||
                    (PV.Cam1_Result_Mean < Convert.ToDouble(PV.stringArray_Limit1[7])) ||
                    (PV.Cam1_Result_Mean > Convert.ToDouble(PV.stringArray_Limit1[8])) ||
                    (PV.Cam1_Result_StandardDeviation < Convert.ToDouble(PV.stringArray_Limit1[9])) ||
                    (PV.Cam1_Result_StandardDeviation > Convert.ToDouble(PV.stringArray_Limit1[10])) ||
                    (PV.Cam1_Result_Mean1 < Convert.ToDouble(PV.stringArray_Limit1[11])) ||
                    (PV.Cam1_Result_Mean1 > Convert.ToDouble(PV.stringArray_Limit1[12])) ||
                    (PV.Cam1_Result_StandardDeviation1 < Convert.ToDouble(PV.stringArray_Limit1[13])) ||
                    (PV.Cam1_Result_StandardDeviation1 > Convert.ToDouble(PV.stringArray_Limit1[14]))) && !PV.bBypass1
                    )
                {
                    PV.nFailCount1++;
                    if (PV.bNGSave || PV.bAllSave)
                    {
                        string FileName = PF.ImageSave("NG", "Cam1");
                        ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                        ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                        ImageFileTool.Run();
                        ImageFileTool.Operator.Close();
                    }
                    this.Invoke(new Action(delegate ()
                    {
                        pb1.Image = imageList1.Images[1];
                    }));
                    PF.LogWriter1("불량", PV.nModel);

                    PV.sResult1 = "NG";
                }
                // ok
                else
                {
                    PV.nPassCount1++;
                    if (PV.bAllSave)
                    {
                        string FileName = PF.ImageSave("OK", "Cam1");
                        ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                        ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                        ImageFileTool.Run();
                        ImageFileTool.Operator.Close();
                    }
                    this.Invoke(new Action(delegate ()
                    {
                        pb1.Image = imageList1.Images[0];
                    }));
                    PF.LogWriter1("양품", PV.nModel);

                    PV.sResult1 = "OK";
                }


                StringBuilder sb01 = new StringBuilder();
                StringBuilder sb02 = new StringBuilder();
                StringBuilder sb03 = new StringBuilder();
                StringBuilder sb04 = new StringBuilder();
                StringBuilder sb05 = new StringBuilder();
                StringBuilder sb06 = new StringBuilder();
                StringBuilder sb07 = new StringBuilder();
                StringBuilder sb08 = new StringBuilder();
                StringBuilder sb09 = new StringBuilder();
                StringBuilder sb010 = new StringBuilder();
                StringBuilder sb011 = new StringBuilder();
                StringBuilder sb012 = new StringBuilder();
                this.Invoke(new Action(delegate ()
                {
                    listBox1.Items.Insert(0, sb01.Append("[Time] : ").Append(Logtime).Append(" Cam1 결과 : ").Append(PV.sResult1));
                    listBox1.Items.Insert(1, sb02.Append("Cam1_Results_Item_0_Score : ").Append(PV.Cam1_Results_Item_0_Score));
                    listBox1.Items.Insert(2, sb03.Append("Cam1_Results_GetBlobs_Count : ").Append(PV.Cam1_Results_GetBlobs_Count));
                    listBox1.Items.Insert(3, sb04.Append("Cam1_Results_GetBlobs_Item_0_Area : ").Append(PV.Cam1_Results_GetBlobs_Item_0_Area));
                    listBox1.Items.Insert(4, sb05.Append("Cam1_Results_GetBlobs_Count1 : ").Append(PV.Cam1_Results_GetBlobs_Count1));
                    listBox1.Items.Insert(5, sb06.Append("Cam1_Results_GetBlobs_Item_0_Area1 : ").Append(PV.Cam1_Results_GetBlobs_Item_0_Area1));
                    listBox1.Items.Insert(6, sb07.Append("Cam1_Results_GetBlobs_Count2 : ").Append(PV.Cam1_Results_GetBlobs_Count2));
                    listBox1.Items.Insert(7, sb08.Append("Cam1_Results_GetBlobs_Item_0_Area2 : ").Append(PV.Cam1_Results_GetBlobs_Item_0_Area2));
                    listBox1.Items.Insert(8, sb09.Append("Cam1_Result_Mean : ").Append(PV.Cam1_Result_Mean));
                    listBox1.Items.Insert(9, sb010.Append("Cam1_Result_StandardDeviation : ").Append(PV.Cam1_Result_StandardDeviation));
                    listBox1.Items.Insert(10, sb011.Append("Cam1_Result_Mean1 : ").Append(PV.Cam1_Result_Mean1));
                    listBox1.Items.Insert(11, sb012.Append("Cam1_Result_StandardDeviation1 : ").Append(PV.Cam1_Result_StandardDeviation1));

                }));

            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("CAMERA1_UserResultAvailable", ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        #endregion 

        #region Camera 2
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
                II_ToolBlock = II_ToolGroup.Tools["Results"] as CogToolBlock;
                CogPMAlignTool CogPMAlignTool1 = II_ToolGroup.Tools["CogPMAlignTool1"] as CogPMAlignTool;
                string Logtime = PV.lib.getTime("YYMMDD");

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


                PV.Cam2_Results_Item_0_Score = Convert.ToDouble(II_ToolBlock.Outputs["Results_Item_0_Score"].Value);
                PV.Cam2_Results_GetBlobs_Count = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Count"].Value); ;
                PV.Cam2_Results_GetBlobs_Item_0_Area = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Item_0_Area"].Value); ;
                PV.Cam2_Results_GetBlobs_Count1 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Count1"].Value); ;
                PV.Cam2_Results_GetBlobs_Item_0_Area1 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Item_0_Area1"].Value); ;
                PV.Cam2_Results_GetBlobs_Count2 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Count2"].Value); ;
                PV.Cam2_Results_GetBlobs_Item_0_Area2 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Item_0_Area2"].Value); ;
                PV.Cam2_Result_Mean = Convert.ToDouble(II_ToolBlock.Outputs["Result_Mean"].Value); ;
                PV.Cam2_Result_StandardDeviation = Convert.ToDouble(II_ToolBlock.Outputs["Result_StandardDeviation"].Value); ;
                PV.Cam2_Result_Mean1 = Convert.ToDouble(II_ToolBlock.Outputs["Result_Mean1"].Value); ;
                PV.Cam2_Result_StandardDeviation1 = Convert.ToDouble(II_ToolBlock.Outputs["Result_StandardDeviation1"].Value); ;

                PV.nTotalCount2++;



                // ng
                if (((PV.Cam2_Results_Item_0_Score < Convert.ToDouble(PV.stringArray_Limit1[0])) ||
                    (PV.Cam2_Results_GetBlobs_Count < Convert.ToDouble(PV.stringArray_Limit1[1])) ||
                    (PV.Cam2_Results_GetBlobs_Item_0_Area < Convert.ToDouble(PV.stringArray_Limit1[2])) ||
                    (PV.Cam2_Results_GetBlobs_Count1 < Convert.ToDouble(PV.stringArray_Limit1[3])) ||
                    (PV.Cam2_Results_GetBlobs_Item_0_Area1 < Convert.ToDouble(PV.stringArray_Limit1[4])) ||
                    (PV.Cam2_Results_GetBlobs_Count2 < Convert.ToDouble(PV.stringArray_Limit1[5])) ||
                    (PV.Cam2_Results_GetBlobs_Item_0_Area2 < Convert.ToDouble(PV.stringArray_Limit1[6])) ||
                    (PV.Cam2_Result_Mean < Convert.ToDouble(PV.stringArray_Limit1[7])) ||
                    (PV.Cam2_Result_Mean > Convert.ToDouble(PV.stringArray_Limit1[8])) ||
                    (PV.Cam2_Result_StandardDeviation < Convert.ToDouble(PV.stringArray_Limit1[9])) ||
                    (PV.Cam2_Result_StandardDeviation > Convert.ToDouble(PV.stringArray_Limit1[10])) ||
                    (PV.Cam2_Result_Mean1 < Convert.ToDouble(PV.stringArray_Limit1[11])) ||
                    (PV.Cam2_Result_Mean1 > Convert.ToDouble(PV.stringArray_Limit1[12])) ||
                    (PV.Cam2_Result_StandardDeviation1 < Convert.ToDouble(PV.stringArray_Limit1[13])) ||
                    (PV.Cam2_Result_StandardDeviation1 > Convert.ToDouble(PV.stringArray_Limit1[14]))) && !PV.bBypass2
                    )
                {
                    PV.nFailCount2++;
                    if (PV.bNGSave || PV.bAllSave)
                    {
                        string FileName = PF.ImageSave("NG", "Cam2");
                        ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                        ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                        ImageFileTool.Run();
                        ImageFileTool.Operator.Close();
                    }
                    this.Invoke(new Action(delegate ()
                    {
                        pb2.Image = imageList1.Images[1];
                    }));
                    PF.LogWriter2("불량", PV.nModel);

                    PV.sResult2 = "NG";
                }
                // ok
                else
                {
                    PV.nPassCount2++;
                    if (PV.bAllSave)
                    {
                        string FileName = PF.ImageSave("OK", "Cam2");
                        ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                        ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                        ImageFileTool.Run();
                        ImageFileTool.Operator.Close();
                    }
                    this.Invoke(new Action(delegate ()
                    {
                        pb2.Image = imageList1.Images[0];
                    }));
                    PF.LogWriter2("양품", PV.nModel);

                    PV.sResult2 = "OK";
                }


                StringBuilder sb11 = new StringBuilder();
                StringBuilder sb12 = new StringBuilder();
                StringBuilder sb13 = new StringBuilder();
                StringBuilder sb14 = new StringBuilder();
                StringBuilder sb15 = new StringBuilder();
                StringBuilder sb16 = new StringBuilder();
                StringBuilder sb17 = new StringBuilder();
                StringBuilder sb18 = new StringBuilder();
                StringBuilder sb19 = new StringBuilder();
                StringBuilder sb110 = new StringBuilder();
                StringBuilder sb111 = new StringBuilder();
                StringBuilder sb112 = new StringBuilder();
                this.Invoke(new Action(delegate ()
                {
                    listBox1.Items.Insert(0, sb11.Append("[Time] : ").Append(Logtime).Append(" Cam2 결과 : ").Append(PV.sResult2));
                    listBox1.Items.Insert(1, sb12.Append("Cam2_Results_Item_0_Score : ").Append(PV.Cam2_Results_Item_0_Score));
                    listBox1.Items.Insert(2, sb13.Append("Cam2_Results_GetBlobs_Count : ").Append(PV.Cam2_Results_GetBlobs_Count));
                    listBox1.Items.Insert(3, sb14.Append("Cam2_Results_GetBlobs_Item_0_Area : ").Append(PV.Cam2_Results_GetBlobs_Item_0_Area));
                    listBox1.Items.Insert(4, sb15.Append("Cam2_Results_GetBlobs_Count1 : ").Append(PV.Cam2_Results_GetBlobs_Count1));
                    listBox1.Items.Insert(5, sb16.Append("Cam2_Results_GetBlobs_Item_0_Area1 : ").Append(PV.Cam2_Results_GetBlobs_Item_0_Area1));
                    listBox1.Items.Insert(6, sb17.Append("Cam2_Results_GetBlobs_Count2 : ").Append(PV.Cam2_Results_GetBlobs_Count2));
                    listBox1.Items.Insert(7, sb18.Append("Cam2_Results_GetBlobs_Item_0_Area2 : ").Append(PV.Cam2_Results_GetBlobs_Item_0_Area2));
                    listBox1.Items.Insert(8, sb19.Append("Cam2_Result_Mean : ").Append(PV.Cam2_Result_Mean));
                    listBox1.Items.Insert(9, sb110.Append("Cam2_Result_StandardDeviation : ").Append(PV.Cam2_Result_StandardDeviation));
                    listBox1.Items.Insert(10, sb111.Append("Cam2_Result_Mean1 : ").Append(PV.Cam2_Result_Mean1));
                    listBox1.Items.Insert(11, sb112.Append("Cam2_Result_StandardDeviation1 : ").Append(PV.Cam2_Result_StandardDeviation1));

                }));

            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("CAMERA2_UserResultAvailable", ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        #endregion 

        #region Camera 3
        void CAMERA3_UserResultAvailable(object sender, CogJobManagerActionEventArgs e)
        {


            if (InvokeRequired)
            {
                Invoke(new CAMERA1_Delegate(CAMERA3_UserResultAvailable), new object[] { sender, e });
                return;
            }

            try
            {
                II_ToolGroup = CAMERA3_Job.VisionTool as CogToolGroup;
                II_ToolBlock = II_ToolGroup.Tools["Results"] as CogToolBlock;
                CogPMAlignTool CogPMAlignTool1 = II_ToolGroup.Tools["CogPMAlignTool1"] as CogPMAlignTool;
                string Logtime = PV.lib.getTime("YYMMDD");

                ICogRecord topRecord = null;
                topRecord = CAMERA3_JobManager.UserResult();
                ICogRecord tmpRecord = null;
                tmpRecord = topRecord.SubRecords["ShowLastRunRecordForUserQueue"];
                tmpRecord = tmpRecord.SubRecords["LastRun"];
                tmpRecord = tmpRecord.SubRecords["Image Source.OutputImage"];

                this.Invoke(new Action(delegate ()
                {
                    cogRecordDisplay_CAMERA3.Record = tmpRecord;
                    cogRecordDisplay_CAMERA3.AutoFit = true;
                }));


                PV.Cam3_Results_Item_0_Score = Convert.ToDouble(II_ToolBlock.Outputs["Results_Item_0_Score"].Value);
                PV.Cam3_Results_GetBlobs_Count = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Count"].Value); ;
                PV.Cam3_Results_GetBlobs_Item_0_Area = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Item_0_Area"].Value); ;
                PV.Cam3_Results_GetBlobs_Count1 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Count1"].Value); ;
                PV.Cam3_Results_GetBlobs_Item_0_Area1 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Item_0_Area1"].Value); ;
                PV.Cam3_Results_GetBlobs_Count2 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Count2"].Value); ;
                PV.Cam3_Results_GetBlobs_Item_0_Area2 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Item_0_Area2"].Value); ;
                PV.Cam3_Result_Mean = Convert.ToDouble(II_ToolBlock.Outputs["Result_Mean"].Value); ;
                PV.Cam3_Result_StandardDeviation = Convert.ToDouble(II_ToolBlock.Outputs["Result_StandardDeviation"].Value); ;
                PV.Cam3_Result_Mean1 = Convert.ToDouble(II_ToolBlock.Outputs["Result_Mean1"].Value); ;
                PV.Cam3_Result_StandardDeviation1 = Convert.ToDouble(II_ToolBlock.Outputs["Result_StandardDeviation1"].Value); ;

                PV.nTotalCount3++;



                // ng
                if (((PV.Cam3_Results_Item_0_Score < Convert.ToDouble(PV.stringArray_Limit1[0])) ||
                    (PV.Cam3_Results_GetBlobs_Count < Convert.ToDouble(PV.stringArray_Limit1[1])) ||
                    (PV.Cam3_Results_GetBlobs_Item_0_Area < Convert.ToDouble(PV.stringArray_Limit1[2])) ||
                    (PV.Cam3_Results_GetBlobs_Count1 < Convert.ToDouble(PV.stringArray_Limit1[3])) ||
                    (PV.Cam3_Results_GetBlobs_Item_0_Area1 < Convert.ToDouble(PV.stringArray_Limit1[4])) ||
                    (PV.Cam3_Results_GetBlobs_Count2 < Convert.ToDouble(PV.stringArray_Limit1[5])) ||
                    (PV.Cam3_Results_GetBlobs_Item_0_Area2 < Convert.ToDouble(PV.stringArray_Limit1[6])) ||
                    (PV.Cam3_Result_Mean < Convert.ToDouble(PV.stringArray_Limit1[7])) ||
                    (PV.Cam3_Result_Mean > Convert.ToDouble(PV.stringArray_Limit1[8])) ||
                    (PV.Cam3_Result_StandardDeviation < Convert.ToDouble(PV.stringArray_Limit1[9])) ||
                    (PV.Cam3_Result_StandardDeviation > Convert.ToDouble(PV.stringArray_Limit1[10])) ||
                    (PV.Cam3_Result_Mean1 < Convert.ToDouble(PV.stringArray_Limit1[11])) ||
                    (PV.Cam3_Result_Mean1 > Convert.ToDouble(PV.stringArray_Limit1[12])) ||
                    (PV.Cam3_Result_StandardDeviation1 < Convert.ToDouble(PV.stringArray_Limit1[13])) ||
                    (PV.Cam3_Result_StandardDeviation1 > Convert.ToDouble(PV.stringArray_Limit1[14]))) && !PV.bBypass3
                    )
                {
                    PV.nFailCount3++;
                    if (PV.bNGSave || PV.bAllSave)
                    {
                        string FileName = PF.ImageSave("NG", "Cam3");
                        ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                        ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                        ImageFileTool.Run();
                        ImageFileTool.Operator.Close();
                    }
                    this.Invoke(new Action(delegate ()
                    {
                        pb3.Image = imageList1.Images[1];
                    }));
                    PF.LogWriter3("불량", PV.nModel);

                    PV.sResult3 = "NG";
                }
                // ok
                else
                {
                    PV.nPassCount3++;
                    if (PV.bAllSave)
                    {
                        string FileName = PF.ImageSave("OK", "Cam3");
                        ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                        ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                        ImageFileTool.Run();
                        ImageFileTool.Operator.Close();
                    }
                    this.Invoke(new Action(delegate ()
                    {
                        pb3.Image = imageList1.Images[0];
                    }));
                    PF.LogWriter3("양품", PV.nModel);

                    PV.sResult3 = "OK";
                }

                StringBuilder sb21 = new StringBuilder();
                StringBuilder sb22 = new StringBuilder();
                StringBuilder sb23 = new StringBuilder();
                StringBuilder sb24 = new StringBuilder();
                StringBuilder sb25 = new StringBuilder();
                StringBuilder sb26 = new StringBuilder();
                StringBuilder sb27 = new StringBuilder();
                StringBuilder sb28 = new StringBuilder();
                StringBuilder sb29 = new StringBuilder();
                StringBuilder sb210 = new StringBuilder();
                StringBuilder sb211 = new StringBuilder();
                StringBuilder sb212 = new StringBuilder();
                this.Invoke(new Action(delegate ()
                {
                    listBox1.Items.Insert(0, sb21.Append("[Time] : ").Append(Logtime).Append(" Cam3 결과 : ").Append(PV.sResult3));
                    listBox1.Items.Insert(1, sb22.Append("Cam3_Results_Item_0_Score : ").Append(PV.Cam3_Results_Item_0_Score));
                    listBox1.Items.Insert(2, sb23.Append("Cam3_Results_GetBlobs_Count : ").Append(PV.Cam3_Results_GetBlobs_Count));
                    listBox1.Items.Insert(3, sb24.Append("Cam3_Results_GetBlobs_Item_0_Area : ").Append(PV.Cam3_Results_GetBlobs_Item_0_Area));
                    listBox1.Items.Insert(4, sb25.Append("Cam3_Results_GetBlobs_Count1 : ").Append(PV.Cam3_Results_GetBlobs_Count1));
                    listBox1.Items.Insert(5, sb26.Append("Cam3_Results_GetBlobs_Item_0_Area1 : ").Append(PV.Cam3_Results_GetBlobs_Item_0_Area1));
                    listBox1.Items.Insert(6, sb27.Append("Cam3_Results_GetBlobs_Count2 : ").Append(PV.Cam3_Results_GetBlobs_Count2));
                    listBox1.Items.Insert(7, sb28.Append("Cam3_Results_GetBlobs_Item_0_Area2 : ").Append(PV.Cam3_Results_GetBlobs_Item_0_Area2));
                    listBox1.Items.Insert(8, sb29.Append("Cam3_Result_Mean : ").Append(PV.Cam3_Result_Mean));
                    listBox1.Items.Insert(9, sb210.Append("Cam3_Result_StandardDeviation : ").Append(PV.Cam3_Result_StandardDeviation));
                    listBox1.Items.Insert(10, sb211.Append("Cam3_Result_Mean1 : ").Append(PV.Cam3_Result_Mean1));
                    listBox1.Items.Insert(11, sb212.Append("Cam3_Result_StandardDeviation1 : ").Append(PV.Cam3_Result_StandardDeviation1));

                }));

            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("CAMERA3_UserResultAvailable", ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        #endregion 


        #region Camera 4
        void CAMERA4_UserResultAvailable(object sender, CogJobManagerActionEventArgs e)
        {


            if (InvokeRequired)
            {
                Invoke(new CAMERA1_Delegate(CAMERA4_UserResultAvailable), new object[] { sender, e });
                return;
            }

            try
            {
                II_ToolGroup = CAMERA4_Job.VisionTool as CogToolGroup;
                II_ToolBlock = II_ToolGroup.Tools["Results"] as CogToolBlock;
                CogPMAlignTool CogPMAlignTool1 = II_ToolGroup.Tools["CogPMAlignTool1"] as CogPMAlignTool;
                string Logtime = PV.lib.getTime("YYMMDD");

                ICogRecord topRecord = null;
                topRecord = CAMERA4_JobManager.UserResult();
                ICogRecord tmpRecord = null;
                tmpRecord = topRecord.SubRecords["ShowLastRunRecordForUserQueue"];
                tmpRecord = tmpRecord.SubRecords["LastRun"];
                tmpRecord = tmpRecord.SubRecords["Image Source.OutputImage"];

                this.Invoke(new Action(delegate ()
                {
                    cogRecordDisplay_CAMERA4.Record = tmpRecord;
                    cogRecordDisplay_CAMERA4.AutoFit = true;
                }));


                PV.Cam4_Results_Item_0_Score = Convert.ToDouble(II_ToolBlock.Outputs["Results_Item_0_Score"].Value);
                PV.Cam4_Results_GetBlobs_Count = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Count"].Value); ;
                PV.Cam4_Results_GetBlobs_Item_0_Area = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Item_0_Area"].Value); ;
                PV.Cam4_Results_GetBlobs_Count1 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Count1"].Value); ;
                PV.Cam4_Results_GetBlobs_Item_0_Area1 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Item_0_Area1"].Value); ;
                PV.Cam4_Results_GetBlobs_Count2 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Count2"].Value); ;
                PV.Cam4_Results_GetBlobs_Item_0_Area2 = Convert.ToDouble(II_ToolBlock.Outputs["Results_GetBlobs_Item_0_Area2"].Value); ;
                PV.Cam4_Result_Mean = Convert.ToDouble(II_ToolBlock.Outputs["Result_Mean"].Value); ;
                PV.Cam4_Result_StandardDeviation = Convert.ToDouble(II_ToolBlock.Outputs["Result_StandardDeviation"].Value); ;
                PV.Cam4_Result_Mean1 = Convert.ToDouble(II_ToolBlock.Outputs["Result_Mean1"].Value); ;
                PV.Cam4_Result_StandardDeviation1 = Convert.ToDouble(II_ToolBlock.Outputs["Result_StandardDeviation1"].Value); ;

                PV.nTotalCount4++;


                // ng
                if (((PV.Cam4_Results_Item_0_Score < Convert.ToDouble(PV.stringArray_Limit1[0])) ||
                    (PV.Cam4_Results_GetBlobs_Count < Convert.ToDouble(PV.stringArray_Limit1[1])) ||
                    (PV.Cam4_Results_GetBlobs_Item_0_Area < Convert.ToDouble(PV.stringArray_Limit1[2])) ||
                    (PV.Cam4_Results_GetBlobs_Count1 < Convert.ToDouble(PV.stringArray_Limit1[3])) ||
                    (PV.Cam4_Results_GetBlobs_Item_0_Area1 < Convert.ToDouble(PV.stringArray_Limit1[4])) ||
                    (PV.Cam4_Results_GetBlobs_Count2 < Convert.ToDouble(PV.stringArray_Limit1[5])) ||
                    (PV.Cam4_Results_GetBlobs_Item_0_Area2 < Convert.ToDouble(PV.stringArray_Limit1[6])) ||
                    (PV.Cam4_Result_Mean < Convert.ToDouble(PV.stringArray_Limit1[7])) ||
                    (PV.Cam4_Result_Mean > Convert.ToDouble(PV.stringArray_Limit1[8])) ||
                    (PV.Cam4_Result_StandardDeviation < Convert.ToDouble(PV.stringArray_Limit1[9])) ||
                    (PV.Cam4_Result_StandardDeviation > Convert.ToDouble(PV.stringArray_Limit1[10])) ||
                    (PV.Cam4_Result_Mean1 < Convert.ToDouble(PV.stringArray_Limit1[11])) ||
                    (PV.Cam4_Result_Mean1 > Convert.ToDouble(PV.stringArray_Limit1[12])) ||
                    (PV.Cam4_Result_StandardDeviation1 < Convert.ToDouble(PV.stringArray_Limit1[13])) ||
                    (PV.Cam4_Result_StandardDeviation1 > Convert.ToDouble(PV.stringArray_Limit1[14]))) && !PV.bBypass4
                    )
                {
                    PV.nFailCount4++;
                    if (PV.bNGSave || PV.bAllSave)
                    {
                        string FileName = PF.ImageSave("NG", "Cam4");
                        ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                        ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                        ImageFileTool.Run();
                        ImageFileTool.Operator.Close();
                    }
                    this.Invoke(new Action(delegate ()
                    {
                        pb4.Image = imageList1.Images[1];
                    }));
                    PF.LogWriter4("불량", PV.nModel);

                    PV.sResult4 = "NG";
                }
                // ok
                else
                {
                    PV.nPassCount4++;
                    if (PV.bAllSave)
                    {
                        string FileName = PF.ImageSave("OK", "Cam4");
                        ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                        ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                        ImageFileTool.Run();
                        ImageFileTool.Operator.Close();
                    }
                    this.Invoke(new Action(delegate ()
                    {
                        pb4.Image = imageList1.Images[0];
                    }));
                    PF.LogWriter4("양품", PV.nModel);

                    PV.sResult4 = "OK";
                }

                StringBuilder sb31 = new StringBuilder();
                StringBuilder sb32 = new StringBuilder();
                StringBuilder sb33 = new StringBuilder();
                StringBuilder sb34 = new StringBuilder();
                StringBuilder sb35 = new StringBuilder();
                StringBuilder sb36 = new StringBuilder();
                StringBuilder sb37 = new StringBuilder();
                StringBuilder sb38 = new StringBuilder();
                StringBuilder sb39 = new StringBuilder();
                StringBuilder sb310 = new StringBuilder();
                StringBuilder sb311 = new StringBuilder();
                StringBuilder sb312 = new StringBuilder();
                this.Invoke(new Action(delegate ()
                {
                    listBox1.Items.Insert(0, sb31.Append("[Time] : ").Append(Logtime).Append(" Cam4 결과 : ").Append(PV.sResult4));
                    listBox1.Items.Insert(1, sb32.Append("Cam4_Results_Item_0_Score : ").Append(PV.Cam4_Results_Item_0_Score));
                    listBox1.Items.Insert(2, sb33.Append("Cam4_Results_GetBlobs_Count : ").Append(PV.Cam4_Results_GetBlobs_Count));
                    listBox1.Items.Insert(3, sb34.Append("Cam4_Results_GetBlobs_Item_0_Area : ").Append(PV.Cam4_Results_GetBlobs_Item_0_Area));
                    listBox1.Items.Insert(4, sb35.Append("Cam4_Results_GetBlobs_Count1 : ").Append(PV.Cam4_Results_GetBlobs_Count1));
                    listBox1.Items.Insert(5, sb36.Append("Cam4_Results_GetBlobs_Item_0_Area1 : ").Append(PV.Cam4_Results_GetBlobs_Item_0_Area1));
                    listBox1.Items.Insert(6, sb37.Append("Cam4_Results_GetBlobs_Count2 : ").Append(PV.Cam4_Results_GetBlobs_Count2));
                    listBox1.Items.Insert(7, sb38.Append("Cam4_Results_GetBlobs_Item_0_Area2 : ").Append(PV.Cam4_Results_GetBlobs_Item_0_Area2));
                    listBox1.Items.Insert(8, sb39.Append("Cam4_Result_Mean : ").Append(PV.Cam4_Result_Mean));
                    listBox1.Items.Insert(9, sb310.Append("Cam4_Result_StandardDeviation : ").Append(PV.Cam4_Result_StandardDeviation));
                    listBox1.Items.Insert(10, sb311.Append("Cam4_Result_Mean1 : ").Append(PV.Cam4_Result_Mean1));
                    listBox1.Items.Insert(11, sb312.Append("Cam4_Result_StandardDeviation1 : ").Append(PV.Cam4_Result_StandardDeviation1));

                }));

            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("CAMERA4_UserResultAvailable", ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        #endregion 



        #region JobInitialize / Task / IOTriggerStart / 


        public void CAMERA_JobInitialize()
        {
            try
            {
                if (PV.nModel == 1)
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH1_1) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH2_1) as CogJobManager;
                    CAMERA3_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH3_1) as CogJobManager;
                    CAMERA4_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH4_1) as CogJobManager;
                }
                else if (PV.nModel == 2)
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH1_2) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH2_2) as CogJobManager;
                    CAMERA3_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH3_2) as CogJobManager;
                    CAMERA4_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH4_2) as CogJobManager;
                }
                else if (PV.nModel == 3)
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH1_3) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH2_3) as CogJobManager;
                    CAMERA3_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH3_3) as CogJobManager;
                    CAMERA4_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH4_3) as CogJobManager;
                }
                else if (PV.nModel == 4)
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH1_4) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH2_4) as CogJobManager;
                    CAMERA3_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH3_4) as CogJobManager;
                    CAMERA4_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH4_4) as CogJobManager;
                }
                else if (PV.nModel == 5)
                {
                    CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH1_5) as CogJobManager;
                    CAMERA2_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH2_5) as CogJobManager;
                    CAMERA3_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH3_5) as CogJobManager;
                    CAMERA4_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH4_5) as CogJobManager;
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

                CAMERA3_Job = CAMERA3_JobManager.Job(0);
                CAMERA3_JobIndependent = CAMERA3_Job.OwnedIndependent;
                CAMERA3_JobManager.UserQueueFlush();
                CAMERA3_JobManager.FailureQueueFlush();
                CAMERA3_Job.ImageQueueFlush();
                CAMERA3_JobIndependent.RealTimeQueueFlush();
                CAMERA3_JobManager.UserResultAvailable += new CogJobManager.CogUserResultAvailableEventHandler(CAMERA3_UserResultAvailable);

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

                PF.ExceptionWriter("CAMERA_JobInitialize", ex.Message);
                MessageBox.Show(ex.Message);
                IOReset();
                return;
            }
        }

        private void Task_RunCam1()
        {
            while (PV.bIOCheck)
            {
                try
                {
                    if (PF.IOCheck("1") == "1")            //  Cam1 trigger
                    {
                        PV.InputCheck1 = 1;

                        if ((PV.InputCheck_Old1 == 0) && (PV.InputCheck1 == 1))
                        {
                            PF.Delay(50);
                            CAMERA1_Job.Run();

                            Task taskOutput1 = new Task(TaskIOoutput1);
                            taskOutput1.Start();
                        }
                        PV.InputCheck_Old1 = PV.InputCheck1;
                    }
                    else
                    {
                        PV.InputCheck1 = 0;
                        PV.InputCheck_Old1 = PV.InputCheck1;
                    }
                }
                catch (Exception ex)
                {
                    PF.ExceptionWriter("Task_RunCam1", ex.Message);
                    MessageBox.Show(ex.ToString());
                    IOReset();
                    return;
                }
            }
            Thread.Sleep(1);
        }

        private void Task_RunCam2()
        {
            while (PV.bIOCheck)
            {
                try
                {
                    if (PF.IOCheck("2") == "1")            //  Cam2 trigger
                    {
                        PV.InputCheck2 = 1;

                        if ((PV.InputCheck_Old2 == 0) && (PV.InputCheck2 == 1))
                        {
                            PF.Delay(50);
                            CAMERA2_Job.Run();

                            Task taskOutput2 = new Task(TaskIOoutput2);
                            taskOutput2.Start();
                        }
                        PV.InputCheck_Old2 = PV.InputCheck2;
                    }
                    else
                    {
                        PV.InputCheck2 = 0;
                        PV.InputCheck_Old2 = PV.InputCheck2;
                    }
                }
                catch (Exception ex)
                {
                    PF.ExceptionWriter("Task_RunCam2", ex.Message);
                    MessageBox.Show(ex.ToString());
                    IOReset();
                    return;
                }
            }
            Thread.Sleep(1);
        }

        private void Task_RunCam3()
        {
            while (PV.bIOCheck)
            {
                try
                {
                    if (PF.IOCheck("3") == "1")            //  Cam3 trigger
                    {
                        PV.InputCheck3 = 1;

                        if ((PV.InputCheck_Old3 == 0) && (PV.InputCheck3 == 1))
                        {
                            PF.Delay(50);
                            PV.sResult3 = "OK";
                            //CAMERA3_Job.Run();

                            Task taskOutput3 = new Task(TaskIOoutput3);
                            taskOutput3.Start();
                        }
                        PV.InputCheck_Old3 = PV.InputCheck3;
                    }
                    else
                    {
                        PV.InputCheck3 = 0;
                        PV.InputCheck_Old3 = PV.InputCheck3;
                    }
                }
                catch (Exception ex)
                {
                    PF.ExceptionWriter("Task_RunCam3", ex.Message);
                    MessageBox.Show(ex.ToString());
                    IOReset();
                    return;
                }
            }
            Thread.Sleep(1);
        }

        private void Task_RunCam4()
        {
            while (PV.bIOCheck)
            {
                try
                {
                    if (PF.IOCheck("4") == "1")            //  Cam4 trigger
                    {
                        PV.InputCheck4 = 1;

                        if ((PV.InputCheck_Old4 == 0) && (PV.InputCheck4 == 1))
                        {
                            PF.Delay(50);
                            PV.sResult4 = "OK";
                            //CAMERA4_Job.Run();



                            PF.Delay(500);
                            Task taskOutput4 = new Task(TaskIOoutput4);
                            taskOutput4.Start();

                        }
                        PV.InputCheck_Old4 = PV.InputCheck4;
                    }
                    else
                    {
                        PV.InputCheck4 = 0;
                        PV.InputCheck_Old4 = PV.InputCheck4;
                    }

                }
                catch (Exception ex)
                {
                    PF.ExceptionWriter("Task_RunCam4", ex.Message);
                    MessageBox.Show(ex.ToString());
                    IOReset();
                    return;
                }
            }
            Thread.Sleep(1);
        }

        private void Task_GetModel()
        {
            // stop에만 모델명 불러옴
            while (!PV.bIOCheck)
            {
                try
                {
                    if (PF.IOCheck("5") == "1")
                    {
                        PV.nModel = 1;
                    }
                    else
                    {
                    }

                    if (PF.IOCheck("6") == "1")
                    {
                        PV.nModel = 2;
                    }
                    else
                    {
                    }

                    if (PF.IOCheck("7") == "1")
                    {
                        PV.nModel = 3;
                    }
                    else
                    {
                    }

                    if (PF.IOCheck("8") == "1")
                    {
                        PV.nModel = 4;
                    }
                    else
                    {
                    }

                    if (PF.IOCheck("9") == "1")
                    {
                        PV.nModel = 5;
                    }
                    else
                    {
                    }

                    if (PV.nModel != 0)
                    {
                        this.Invoke(new Action(delegate ()
                                            {
                                                lb_Model.Text = "Model : " + PV.nModel.ToString();
                                            }));

                    }

                }
                catch (Exception ex)
                {
                    PF.ExceptionWriter("Task_GetModel", ex.Message);
                    MessageBox.Show(ex.ToString());
                    IOReset();
                    return;
                }
            }
            Thread.Sleep(1);
        }

        private void IOReset()
        {

            PF.IOOutPutMessage("1", "0");
            PF.IOOutPutMessage("2", "0");
            PF.IOOutPutMessage("3", "0");
            PF.IOOutPutMessage("4", "0");
            PF.IOOutPutMessage("5", "0");
            PF.IOOutPutMessage("6", "0");
            PF.IOOutPutMessage("7", "0");
            PF.IOOutPutMessage("8", "0");
            PF.IOOutPutMessage("9", "0");
            PF.IOOutPutMessage("10", "0");
            PF.IOOutPutMessage("11", "0");
            PF.IOOutPutMessage("12", "0");
            PF.IOOutPutMessage("13", "0");

        }

        private void TaskIOoutput1()
        {
            try
            {
                if (PV.sResult1 != "")
                {
                    //ok
                    if (PV.sResult1 == "OK")
                    {
                        PF.IOOutPutMessage("1", "1");
                        PF.Delay(500);
                        PF.IOOutPutMessage("1", "0");
                    }
                    else
                    {
                        PF.IOOutPutMessage("2", "1");
                        PF.Delay(500);
                        PF.IOOutPutMessage("2", "0");
                    }
                }
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("TaskIOoutput1", ex.Message);
                MessageBox.Show(ex.Message);

                IOReset();
                return;
            }
            Thread.Sleep(1);
        }
        private void TaskIOoutput2()
        {
            try
            {
                if (PV.sResult2 != "")
                {
                    //ok
                    if (PV.sResult2 == "OK")
                    {
                        PF.IOOutPutMessage("3", "1");
                        PF.Delay(500);
                        PF.IOOutPutMessage("3", "0");
                    }
                    else
                    {
                        PF.IOOutPutMessage("4", "1");
                        PF.Delay(500);
                        PF.IOOutPutMessage("4", "0");
                    }
                }
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("TaskIOoutput2", ex.Message);
                MessageBox.Show(ex.Message);

                IOReset();
                return;
            }
            Thread.Sleep(1);
        }
        private void TaskIOoutput3()
        {
            try
            {
                if (PV.sResult3 != "")
                {
                    //ok
                    if (PV.sResult3 == "OK")
                    {
                        PF.IOOutPutMessage("5", "1");
                        PF.Delay(500);
                        PF.IOOutPutMessage("5", "0");
                    }
                    else
                    {
                        PF.IOOutPutMessage("6", "1");
                        PF.Delay(500);
                        PF.IOOutPutMessage("6", "0");
                    }
                }
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("TaskIOoutput3", ex.Message);
                MessageBox.Show(ex.Message);

                IOReset();
                return;
            }
            Thread.Sleep(1);
        }
        private void TaskIOoutput4()
        {
            try
            {
                if (PV.sResult4 != "")
                {
                    //ok
                    if (PV.sResult4 == "OK")
                    {
                        PF.IOOutPutMessage("7", "1");
                        PF.Delay(500);
                        PF.IOOutPutMessage("7", "0");
                    }
                    else
                    {
                        PF.IOOutPutMessage("8", "1");
                        PF.Delay(500);
                        PF.IOOutPutMessage("8", "0");
                    }
                }
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("TaskIOoutput4", ex.Message);
                MessageBox.Show(ex.Message);

                IOReset();
                return;
            }
            Thread.Sleep(1);
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
                PV.m_UpCount[TrgBit] = 0;       // Up counter
                PV.m_DownCount[TrgBit] = 0; // Down counter
            }
            //-----------------------------
            // Witch check
            //-----------------------------
            Tim = 100;                                                              // Observe in cycle 100ms
            TrgKind = (short)CdioConst.DIO_TRG_RISE | (short)CdioConst.DIO_TRG_FALL;    // Observe both of Up/Down
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

        #region 이벤트



        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                // start 버튼 click
                if (!PV.bIOCheck)
                {
                    if (PV.nModel == 0)
                    {
                        MessageBox.Show("모델을 선택하세요.");
                        return;
                    }
                    btn_Start.BackgroundImage = global::chsj.Properties.Resources.btn_STOP;
                    PV.bIOCheck = true;

                    btn_AddModel.Enabled = false;

                    pb_FileLoading.Visible = true;
                    PF.Delay(100);

                    CAMERA_JobInitialize();

                    pb_FileLoading.Visible = false;

                    Task taskRun1 = new Task(Task_RunCam1);
                    taskRun1.Start();
                    Task taskRun2 = new Task(Task_RunCam2);
                    taskRun2.Start();
                    Task taskRun3 = new Task(Task_RunCam3);
                    taskRun3.Start();
                    Task taskRun4 = new Task(Task_RunCam4);
                    taskRun4.Start();

                    timer1.Enabled = true;
                    PV.CAM1Stopwatch.Start();
                    PV.CAM2Stopwatch.Start();
                    PV.CAM3Stopwatch.Start();
                    PV.CAM4Stopwatch.Start();

                    PF.IOOutPutMessage("0", "1");

                    this.Invoke(new Action(delegate ()
                    {
                        string Logtime = PV.lib.getTime("YYMMDD");
                        StringBuilder sb = new StringBuilder();
                        listBox1.Items.Insert(0, sb.Append("[Time] : ").Append(Logtime).Append(" Start"));
                    }));

                }
                // stop 버튼 click
                else
                {
                    btn_Start.BackgroundImage = null;
                    PV.bIOCheck = false;

                    timer1.Enabled = false;

                    PV.CAM1Stopwatch.Stop();
                    PV.CAM2Stopwatch.Stop();
                    PV.CAM3Stopwatch.Stop();
                    PV.CAM4Stopwatch.Stop();

                    PF.IOOutPutMessage("0", "0");
                    btn_AddModel.Enabled = true;

                    IOReset();

                    Task taskGetModel = new Task(Task_GetModel);
                    taskGetModel.Start();

                    this.Invoke(new Action(delegate ()
                    {
                        string Logtime = PV.lib.getTime("YYMMDD");
                        StringBuilder sb = new StringBuilder();
                        listBox1.Items.Insert(0, sb.Append("[Time] : ").Append(Logtime).Append(" Stop"));
                    }));
                }



            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("btn_Start_Click", ex.Message);
                MessageBox.Show(ex.Message);
                IOReset();
                return;
            }
        }

        private void btn_EXIT_Click(object sender, EventArgs e)
        {
            PF.IOOutPutMessage("0", "0");
            IOReset();
            PF.ProcessKill("chsj");
            this.Close();
        }

        private void cb_NGSave_CheckedChanged(object sender, EventArgs e)
        {
            PV.bNGSave = cb_NGSave.Checked;

        }

        private void cb_AllSave_CheckedChanged(object sender, EventArgs e)
        {
            PV.bAllSave = cb_AllSave.Checked;

        }

        private void btn_Model_Click(object sender, EventArgs e)
        {

            try
            {

                if (PV.bIOCheck == false)
                {
                    if (model == null || model.Text == "Model")
                    {
                        switch (PV.nModel)
                        {
                            case 1:
                                model = new Model(PV.CAMERA_PATH1_1);
                                break;

                            case 2:
                                model = new Model(PV.CAMERA_PATH1_2);
                                break;

                            case 3:
                                model = new Model(PV.CAMERA_PATH1_3);
                                break;

                            case 4:
                                model = new Model(PV.CAMERA_PATH1_4);
                                break;

                            case 5:
                                model = new Model(PV.CAMERA_PATH1_5);
                                break;


                            default:
                                MessageBox.Show("모델 정보 없음");
                                return;
                        }
                        model.ShowDialog();

                    }
                    else
                    { model.Activate(); }

                }

            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("btn_Model_Click", ex.Message);
                MessageBox.Show(ex.Message);
                return;
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PV.ts1 = PV.CAM1Stopwatch.Elapsed;
            string temp1 = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", PV.ts1.Hours, PV.ts1.Minutes, PV.ts1.Seconds, PV.ts1.Milliseconds);
            lb_InsTime1.Text = temp1;

            PV.ts2 = PV.CAM2Stopwatch.Elapsed;
            string temp2 = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", PV.ts2.Hours, PV.ts2.Minutes, PV.ts2.Seconds, PV.ts2.Milliseconds);
            lb_InsTime2.Text = temp2;

            PV.ts3 = PV.CAM3Stopwatch.Elapsed;
            string temp3 = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", PV.ts3.Hours, PV.ts3.Minutes, PV.ts3.Seconds, PV.ts3.Milliseconds);
            lb_InsTime3.Text = temp3;

            PV.ts4 = PV.CAM4Stopwatch.Elapsed;
            string temp4 = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", PV.ts4.Hours, PV.ts4.Minutes, PV.ts4.Seconds, PV.ts4.Milliseconds);
            lb_InsTime4.Text = temp4;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            lb_NowTime.Text = sb.Append(DateTime.Now.ToString("yyyy-MM-dd")).Append("  ").Append(DateTime.Now.ToString("tt hh:mm:ss")).ToString();
        }

        private void btn_CountReset_Click(object sender, EventArgs e)
        {
            PV.nFailCount1 = 0;
            PV.nFailCount2 = 0;
            PV.nFailCount3 = 0;
            PV.nFailCount4 = 0;

            PV.nPassCount1 = 0;
            PV.nPassCount2 = 0;
            PV.nPassCount3 = 0;
            PV.nPassCount4 = 0;

            PV.nTotalCount1 = 0;
            PV.nTotalCount2 = 0;
            PV.nTotalCount3 = 0;
            PV.nTotalCount4 = 0;

            lb_InsCount1.Text = PV.nTotalCount1.ToString();
            lb_InsCount2.Text = PV.nTotalCount2.ToString();
            lb_InsCount3.Text = PV.nTotalCount3.ToString();
            lb_InsCount4.Text = PV.nTotalCount4.ToString();

            lb_PassCount1.Text = PV.nPassCount1.ToString();
            lb_PassCount2.Text = PV.nPassCount2.ToString();
            lb_PassCount3.Text = PV.nPassCount3.ToString();
            lb_PassCount4.Text = PV.nPassCount4.ToString();

            PV.CAM1Stopwatch.Reset();
            PV.CAM2Stopwatch.Reset();
            PV.CAM3Stopwatch.Reset();
            PV.CAM4Stopwatch.Reset();

            PV.ts1 = PV.CAM1Stopwatch.Elapsed;
            string temp1 = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", PV.ts1.Hours, PV.ts1.Minutes, PV.ts1.Seconds, PV.ts1.Milliseconds);
            lb_InsTime1.Text = temp1;

            PV.ts2 = PV.CAM2Stopwatch.Elapsed;
            string temp2 = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", PV.ts2.Hours, PV.ts2.Minutes, PV.ts2.Seconds, PV.ts2.Milliseconds);
            lb_InsTime2.Text = temp2;

            PV.ts3 = PV.CAM3Stopwatch.Elapsed;
            string temp3 = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", PV.ts3.Hours, PV.ts3.Minutes, PV.ts3.Seconds, PV.ts3.Milliseconds);
            lb_InsTime3.Text = temp3;

            PV.ts4 = PV.CAM4Stopwatch.Elapsed;
            string temp4 = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", PV.ts4.Hours, PV.ts4.Minutes, PV.ts4.Seconds, PV.ts4.Milliseconds);
            lb_InsTime4.Text = temp4;
        }


        private void btn_AddModel_Click(object sender, EventArgs e)
        {
            PF.ReadModelData();
            Add_ModelList newform = new Add_ModelList();
            newform.main = this;
            newform.ShowDialog();
        }



        private void btn_Bypass_1_Click(object sender, EventArgs e)
        {
            if (!PV.bBypass1)
            {
                PV.bBypass1 = true;
                btn_Bypass_1.Image = imageList2.Images[1];
            }
            else
            {
                PV.bBypass1 = false;
                btn_Bypass_1.Image = imageList2.Images[0];
            }
        }

        private void btn_Bypass_2_Click(object sender, EventArgs e)
        {
            if (!PV.bBypass2)
            {
                PV.bBypass2 = true;
                btn_Bypass_2.Image = imageList2.Images[1];
            }
            else
            {
                PV.bBypass2 = false;
                btn_Bypass_2.Image = imageList2.Images[0];
            }

        }

        private void btn_Bypass_3_Click(object sender, EventArgs e)
        {
            if (!PV.bBypass3)
            {
                PV.bBypass3 = true;
                btn_Bypass_3.Image = imageList2.Images[1];
            }
            else
            {
                PV.bBypass3 = false;
                btn_Bypass_3.Image = imageList2.Images[0];
            }
        }

        private void btn_Bypass_4_Click(object sender, EventArgs e)
        {
            if (!PV.bBypass4)
            {
                PV.bBypass4 = true;
                btn_Bypass_4.Image = imageList2.Images[1];
            }
            else
            {
                PV.bBypass4 = false;
                btn_Bypass_4.Image = imageList2.Images[0];
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            lb_InsCount1.Text = PV.nTotalCount1.ToString();
            lb_InsCount2.Text = PV.nTotalCount2.ToString();
            lb_InsCount3.Text = PV.nTotalCount3.ToString();
            lb_InsCount4.Text = PV.nTotalCount4.ToString();

            lb_PassCount1.Text = PV.nPassCount1.ToString();
            lb_PassCount2.Text = PV.nPassCount2.ToString();
            lb_PassCount3.Text = PV.nPassCount3.ToString();
            lb_PassCount4.Text = PV.nPassCount4.ToString();
        }

        #endregion


    }

}
