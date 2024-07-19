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


            if (!serialPort1.IsOpen)
            {
                serialPort1.Open();
                string Logtime = PV.lib.getTime("YYMMDD");
                StringBuilder sb = new StringBuilder();
                listBox1.Items.Insert(0, sb.Append("[Time] : ").Append(Logtime).Append(" 시리얼포트 연결 "));
            }

            PF.ReadModelData();

            Task taskGetLight = new Task(Task_GetLight);
            taskGetLight.Start();

            Task taskGetModel = new Task(Task_GetModel);
            taskGetModel.Start();


            pb_FileLoading.Visible = false;


        }

        // io모듈로 신호 받을 시 -> Task_RunCam1
        #region 검사
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
                CogPMAlignTool CogPMAlignTool1 = II_ToolGroup.Tools["회전 위치 찾기"] as CogPMAlignTool;
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
                double Result1 = Math.Round(Convert.ToDouble(II_ToolBlock.Outputs["Angle"].Value) + Convert.ToDouble(tb_OffsetAngle.Text));

                PV.dResult1 = Result1;


                this.Invoke(new Action(delegate ()
                {
                    StringBuilder sbAngle = new StringBuilder();
                    listBox1.Items.Insert(0, sbAngle.Append("[Time] : ").Append(Logtime).Append(" Angle : ").Append(Convert.ToDouble(II_ToolBlock.Outputs["Angle"].Value)));
                    StringBuilder sbOffset = new StringBuilder();
                    listBox1.Items.Insert(1, sbOffset.Append("[Time] : ").Append(Logtime).Append(" tb_OffsetAngle.Text : ").Append(tb_OffsetAngle.Text));
                }));


                PV.dScore = Math.Round(Convert.ToDouble(II_ToolBlock.Outputs["Pattern_Score"].Value), 3, MidpointRounding.AwayFromZero);
                PV.dScore1 = Math.Round(Convert.ToDouble(II_ToolBlock.Outputs["Pattern_Score1"].Value), 3, MidpointRounding.AwayFromZero);



                // ok
                if (((II_ToolBlock.Inputs["Results_Count"].Value.ToString() == "1") && (PV.dScore >= Convert.ToDouble(tb_ScoreShape.Text))))
                {
                    PV.sResult2_1 = "OK";
                }
                // ng
                else
                {
                    PV.sResult2_1 = "NG";

                    if (PV.bNGSave || PV.bAllSave)
                    {
                        string FileName = PF.ImageSave("NG");
                        ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                        ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                        ImageFileTool.Run();
                        ImageFileTool.Operator.Close();
                    }
                }

                if ((II_ToolBlock.Inputs["Results_Count1"].Value.ToString() == "1") && PV.dScore1 >= Convert.ToDouble(tb_ScoreAngle.Text))
                {
                    PV.sResult2_2 = "OK";
                }
                else
                {
                    PV.sResult2_2 = "NG";
                }

                PV.nTotalCount++;
                Task taskAngle = new Task(Task_OutputAngle);
                taskAngle.Start();
                Task taskOutput = new Task(TaskIOoutput);
                taskOutput.Start();




                StringBuilder sb = new StringBuilder();
                StringBuilder sb1 = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();
                StringBuilder sb3 = new StringBuilder();
                StringBuilder sb4 = new StringBuilder();

                this.Invoke(new Action(delegate ()
                {
                    listBox1.Items.Insert(0, sb.Append("[Time] : ").Append(Logtime).Append(" 각도 검사 결과 : ").Append(PV.dResult1));
                    listBox1.Items.Insert(1, sb1.Append("[Time] : ").Append(Logtime).Append(" 형상 스코어 : ").Append(PV.dScore).Append(" / ").Append(PV.sResult2_1));
                    listBox1.Items.Insert(2, sb2.Append("[Time] : ").Append(Logtime).Append(" 각도 스코어 : ").Append(PV.dScore1).Append(" / ").Append(PV.sResult2_2));
                    listBox1.Items.Insert(3, sb3.Append("Shape_PatterCount : ").Append(II_ToolBlock.Inputs["Results_Count"].Value).Append(" / Angle_PatternCount : ").Append(II_ToolBlock.Inputs["Results_Count1"].Value));
                    lb_Angle2.Text = sb4.Append("Angle : ").Append(PV.dResult1).ToString();
                }));

            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("CAMERA1_UserResultAvailable", ex.Message);
                MessageBox.Show(ex.Message);
            }

        }




        #endregion Camera 1

        #region JobInitialize / Task / IOTriggerStart / Convert


        public void CAMERA_JobInitialize()
        {
            try
            {

                switch (PV.iModelNum)
                {
                    case 1:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH1) as CogJobManager;
                        break;

                    case 2:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH2) as CogJobManager;
                        break;

                    case 3:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH3) as CogJobManager;
                        break;

                    case 4:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH4) as CogJobManager;
                        break;

                    case 5:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH5) as CogJobManager;
                        break;

                    case 6:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH6) as CogJobManager;
                        break;

                    case 7:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH7) as CogJobManager;
                        break;

                    case 8:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH8) as CogJobManager;
                        break;

                    case 9:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH9) as CogJobManager;
                        break;

                    case 10:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH10) as CogJobManager;
                        break;

                    case 11:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH11) as CogJobManager;
                        break;

                    case 12:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH12) as CogJobManager;
                        break;

                    case 13:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH13) as CogJobManager;
                        break;

                    case 14:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH14) as CogJobManager;
                        break;

                    case 15:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH15) as CogJobManager;
                        break;

                    case 16:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH16) as CogJobManager;
                        break;

                    case 17:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH17) as CogJobManager;
                        break;

                    case 18:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH18) as CogJobManager;
                        break;

                    case 19:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH19) as CogJobManager;
                        break;

                    case 20:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH20) as CogJobManager;
                        break;

                    case 21:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH21) as CogJobManager;
                        break;

                    case 22:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH22) as CogJobManager;
                        break;

                    case 23:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH23) as CogJobManager;
                        break;

                    case 24:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH24) as CogJobManager;
                        break;

                    case 25:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH25) as CogJobManager;
                        break;

                    case 26:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH26) as CogJobManager;
                        break;

                    case 27:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH27) as CogJobManager;
                        break;

                    case 28:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH28) as CogJobManager;
                        break;

                    case 29:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH29) as CogJobManager;
                        break;

                    case 30:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH30) as CogJobManager;
                        break;

                    case 31:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH31) as CogJobManager;
                        break;

                    case 32:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH32) as CogJobManager;
                        break;

                    case 33:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH33) as CogJobManager;
                        break;

                    case 34:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH34) as CogJobManager;
                        break;

                    case 35:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH35) as CogJobManager;
                        break;

                    case 36:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH36) as CogJobManager;
                        break;

                    case 37:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH37) as CogJobManager;
                        break;

                    case 38:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH38) as CogJobManager;
                        break;

                    case 39:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH39) as CogJobManager;
                        break;

                    case 40:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH40) as CogJobManager;
                        break;

                    case 41:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH41) as CogJobManager;
                        break;

                    case 42:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH42) as CogJobManager;
                        break;

                    case 43:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH43) as CogJobManager;
                        break;

                    case 44:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH44) as CogJobManager;
                        break;

                    case 45:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH45) as CogJobManager;
                        break;

                    case 46:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH46) as CogJobManager;
                        break;

                    case 47:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH47) as CogJobManager;
                        break;

                    case 48:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH48) as CogJobManager;
                        break;

                    case 49:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH49) as CogJobManager;
                        break;

                    case 50:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH50) as CogJobManager;
                        break;

                    case 51:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH51) as CogJobManager;
                        break;

                    case 52:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH52) as CogJobManager;
                        break;

                    case 53:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH53) as CogJobManager;
                        break;

                    case 54:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH54) as CogJobManager;
                        break;

                    case 55:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH55) as CogJobManager;
                        break;

                    case 56:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH56) as CogJobManager;
                        break;

                    case 57:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH57) as CogJobManager;
                        break;

                    case 58:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH58) as CogJobManager;
                        break;

                    case 59:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH59) as CogJobManager;
                        break;

                    case 60:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH60) as CogJobManager;
                        break;

                    case 61:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH61) as CogJobManager;
                        break;

                    case 62:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH62) as CogJobManager;
                        break;

                    case 63:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH63) as CogJobManager;
                        break;

                    case 64:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH64) as CogJobManager;
                        break;

                    case 65:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH65) as CogJobManager;
                        break;

                    case 66:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH66) as CogJobManager;
                        break;

                    case 67:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH67) as CogJobManager;
                        break;

                    case 68:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH68) as CogJobManager;
                        break;

                    case 69:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH69) as CogJobManager;
                        break;

                    case 70:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH70) as CogJobManager;
                        break;

                    case 71:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH71) as CogJobManager;
                        break;


                    case 72:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH72) as CogJobManager;
                        break;

                    case 73:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH73) as CogJobManager;
                        break;

                    case 74:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH74) as CogJobManager;
                        break;

                    case 75:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH75) as CogJobManager;
                        break;

                    case 76:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH76) as CogJobManager;
                        break;

                    case 77:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH77) as CogJobManager;
                        break;

                    case 78:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH78) as CogJobManager;
                        break;

                    case 79:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH79) as CogJobManager;
                        break;

                    case 80:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH80) as CogJobManager;
                        break;

                    case 81:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH81) as CogJobManager;
                        break;

                    case 82:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH82) as CogJobManager;
                        break;

                    case 83:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH83) as CogJobManager;
                        break;

                    case 84:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH84) as CogJobManager;
                        break;

                    case 85:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH85) as CogJobManager;
                        break;

                    case 86:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH86) as CogJobManager;
                        break;

                    case 87:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH87) as CogJobManager;
                        break;

                    case 88:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH88) as CogJobManager;
                        break;

                    case 89:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH89) as CogJobManager;
                        break;

                    case 90:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH90) as CogJobManager;
                        break;

                    case 91:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH91) as CogJobManager;
                        break;

                    case 92:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH92) as CogJobManager;
                        break;

                    case 93:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH93) as CogJobManager;
                        break;

                    case 94:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH94) as CogJobManager;
                        break;

                    case 95:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH95) as CogJobManager;
                        break;

                    case 96:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH96) as CogJobManager;
                        break;

                    case 97:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH97) as CogJobManager;
                        break;

                    case 98:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH98) as CogJobManager;
                        break;

                    case 99:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH99) as CogJobManager;
                        break;

                    case 100:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH100) as CogJobManager;
                        break;

                    case 101:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH101) as CogJobManager;
                        break;

                    case 102:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH102) as CogJobManager;
                        break;

                    case 103:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH103) as CogJobManager;
                        break;

                    case 104:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH104) as CogJobManager;
                        break;

                    case 105:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH105) as CogJobManager;
                        break;

                    case 106:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH106) as CogJobManager;
                        break;

                    case 107:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH107) as CogJobManager;
                        break;

                    case 108:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH108) as CogJobManager;
                        break;

                    case 109:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH109) as CogJobManager;
                        break;

                    case 110:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH110) as CogJobManager;
                        break;

                    case 111:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH111) as CogJobManager;
                        break;

                    case 112:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH112) as CogJobManager;
                        break;

                    case 113:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH113) as CogJobManager;
                        break;

                    case 114:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH114) as CogJobManager;
                        break;

                    case 115:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH115) as CogJobManager;
                        break;

                    case 116:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH116) as CogJobManager;
                        break;

                    case 117:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH117) as CogJobManager;
                        break;

                    case 118:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH118) as CogJobManager;
                        break;

                    case 119:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH119) as CogJobManager;
                        break;

                    case 120:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH120) as CogJobManager;
                        break;

                    case 121:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH121) as CogJobManager;
                        break;

                    case 122:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH122) as CogJobManager;
                        break;

                    case 123:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH123) as CogJobManager;
                        break;

                    case 124:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH124) as CogJobManager;
                        break;

                    case 125:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH125) as CogJobManager;
                        break;

                    case 126:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH126) as CogJobManager;
                        break;

                    case 127:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH127) as CogJobManager;
                        break;

                    case 128:
                        CAMERA1_JobManager = CogSerializer.LoadObjectFromFile(PV.CAMERA_PATH128) as CogJobManager;
                        break;

                    default:
                        MessageBox.Show("등록되지 않은 모델");
                        break;
                }


                CAMERA1_Job = CAMERA1_JobManager.Job(0);
                CAMERA1_JobIndependent = CAMERA1_Job.OwnedIndependent;
                CAMERA1_JobManager.UserQueueFlush();
                CAMERA1_JobManager.FailureQueueFlush();
                CAMERA1_Job.ImageQueueFlush();
                CAMERA1_JobIndependent.RealTimeQueueFlush();
                CAMERA1_JobManager.UserResultAvailable += new CogJobManager.CogUserResultAvailableEventHandler(CAMERA1_UserResultAvailable);



            }
            catch (Exception ex)
            {

                PF.ExceptionWriter("CAMERA_JobInitialize", ex.Message);
                MessageBox.Show(ex.Message);
                IOReset();
                return;
            }
        }


        public static string ConvertHex(string hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    string hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    ulong decval = Convert.ToUInt64(hs, 16);
                    long deccc = Convert.ToInt64(hs, 16);
                    char character = Convert.ToChar(deccc);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
        }

        private void Task_OutputAngle()
        {
            try
            {
                // 방향 : +
                if (0 < PV.dResult1)
                {
                    PF.IOOutPutMessage("19", "1");

                    // ~5
                    if (PV.dResult1 <= 10)
                    {
                        PF.IOOutPutMessage("13", "1");
                    }
                    // 5-10
                    else if (10 < PV.dResult1 && PV.dResult1 <= 20)
                    {
                        PF.IOOutPutMessage("14", "1");
                    }
                    // 10-15
                    else if (20 < PV.dResult1 && PV.dResult1 <= 30)
                    {
                        PF.IOOutPutMessage("15", "1");
                    }
                    // 15-20
                    else if (30 < PV.dResult1 && PV.dResult1 <= 40)
                    {
                        PF.IOOutPutMessage("16", "1");
                    }
                    // 20~25
                    else if (40 < PV.dResult1 && PV.dResult1 <= 50)
                    {
                        PF.IOOutPutMessage("17", "1");
                    }
                    // 25-
                    else if (50 < PV.dResult1)
                    {
                        PF.IOOutPutMessage("18", "1");
                    }

                    PF.Delay(PV.OutputDelay);
                    PF.IOOutPutMessage("19", "0");
                    PF.IOOutPutMessage("13", "0");
                    PF.IOOutPutMessage("14", "0");
                    PF.IOOutPutMessage("15", "0");
                    PF.IOOutPutMessage("16", "0");
                    PF.IOOutPutMessage("17", "0");
                    PF.IOOutPutMessage("18", "0");
                }
                // 방향 : -
                else
                {
                    PF.IOOutPutMessage("12", "1");

                    // -5 ~ 0
                    if (-10 <= PV.dResult1 && PV.dResult1 < 0)
                    {
                        PF.IOOutPutMessage("13", "1");
                    }
                    // -10 ~ -5
                    else if (-20 <= PV.dResult1 && PV.dResult1 < -10)
                    {
                        PF.IOOutPutMessage("14", "1");
                    }
                    // -15 ~ -10
                    else if (-30 <= PV.dResult1 && PV.dResult1 < -20)
                    {
                        PF.IOOutPutMessage("15", "1");
                    }
                    // -20 ~ -15
                    else if (-40 <= PV.dResult1 && PV.dResult1 < -30)
                    {
                        PF.IOOutPutMessage("16", "1");
                    }
                    // -25 ~ -20
                    else if (-50 <= PV.dResult1 && PV.dResult1 < -40)
                    {
                        PF.IOOutPutMessage("17", "1");
                    }
                    // -25 ~
                    else if (PV.dResult1 < -50)
                    {
                        PF.IOOutPutMessage("18", "1");
                    }

                    PF.Delay(PV.OutputDelay);
                    PF.IOOutPutMessage("12", "0");
                    PF.IOOutPutMessage("13", "0");
                    PF.IOOutPutMessage("14", "0");
                    PF.IOOutPutMessage("15", "0");
                    PF.IOOutPutMessage("16", "0");
                    PF.IOOutPutMessage("17", "0");
                    PF.IOOutPutMessage("18", "0");
                }
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("Task_OutputAngle", ex.Message);
                MessageBox.Show(ex.Message);

                return;
            }

            Thread.Sleep(1);
        }

        private void Task_GetLight()
        {
            // 
            while (true)
            {
                try
                {
                    // 조명 on
                    if (PF.IOCheck("10") == "1")
                    {
                        // 1번 채널만 사용
                        serialPort1.Write("setonoff 0 1" + ConvertHex("0A"));

                    }
                    else
                    {
                        serialPort1.Write("setonoff 0 0" + ConvertHex("0A"));
                    }
                }
                catch (Exception ex)
                {
                    PF.ExceptionWriter("Task_GetLight", ex.Message);
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
                    if (PF.IOCheck("1") == "1")
                    {
                        PV.sInput1 = "1";

                    }
                    else
                    {
                        PV.sInput1 = "0";
                    }

                    if (PF.IOCheck("2") == "1")
                    {
                        PV.sInput2 = "1";
                    }
                    else
                    {
                        PV.sInput2 = "0";
                    }

                    if (PF.IOCheck("3") == "1")
                    {
                        PV.sInput3 = "1";
                    }
                    else
                    {
                        PV.sInput3 = "0";
                    }

                    if (PF.IOCheck("4") == "1")
                    {
                        PV.sInput4 = "1";
                    }
                    else
                    {
                        PV.sInput4 = "0";
                    }

                    if (PF.IOCheck("5") == "1")
                    {
                        PV.sInput5 = "1";
                    }
                    else
                    {
                        PV.sInput5 = "0";
                    }

                    if (PF.IOCheck("6") == "1")
                    {
                        PV.sInput6 = "1";
                    }
                    else
                    {
                        PV.sInput6 = "0";
                    }

                    if (PF.IOCheck("7") == "1")
                    {
                        PV.sInput7 = "1";
                    }
                    else
                    {
                        PV.sInput7 = "0";
                    }

                    if (PF.IOCheck("8") == "1")
                    {
                        PV.sInput8 = "1";
                    }
                    else
                    {
                        PV.sInput8 = "0";
                    }

                    IOReset();
                    PF.IOOutPutMessage("2", PV.sInput1);
                    PF.IOOutPutMessage("3", PV.sInput2);
                    PF.IOOutPutMessage("4", PV.sInput3);
                    PF.IOOutPutMessage("5", PV.sInput4);
                    PF.IOOutPutMessage("6", PV.sInput5);
                    PF.IOOutPutMessage("7", PV.sInput6);
                    PF.IOOutPutMessage("8", PV.sInput7);
                    PF.IOOutPutMessage("9", PV.sInput8);

                    PV.bModelNum = "";
                    StringBuilder sb = new StringBuilder();
                    PV.bModelNum = sb.Append(PV.sInput8).Append(PV.sInput7).Append(PV.sInput6).Append(PV.sInput5).Append(PV.sInput4).Append(PV.sInput3).Append(PV.sInput2).Append(PV.sInput1).ToString();
                    PV.iModelNum = Convert.ToInt32(PV.bModelNum, 2);


                    PV.Result1LowerLimit = Convert.ToInt32(PV.stringArray_Limit[PV.iModelNum - 1].Split(',')[0]);
                    PV.Result1UpperLimit = Convert.ToInt32(PV.stringArray_Limit[PV.iModelNum - 1].Split(',')[1]);

                    if (PV.iModelNum != 0)
                    {
                        this.Invoke(new Action(delegate ()
                                            {
                                                lb_Model.Text = PV.stringArray_Model[PV.iModelNum - 1].ToString();
                                                lb_ModelName.Text = "Model : " + PV.stringArray_Model[PV.iModelNum - 1].ToString();
                                                tb_OffsetAngle.Text = PV.stringArray_Offset[PV.iModelNum - 1];
                                                tb_ScoreShape.Text = PV.stringArray_Score[PV.iModelNum - 1];
                                                tb_ScoreAngle.Text = PV.stringArray_AngleScore[PV.iModelNum - 1];
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
        private void Task_GetModel1()
        {
            // start에만 모델명 불러옴
            while (PV.bIOCheck)
            {
                try
                {
                    if (PF.IOCheck("11") == "1")
                    {
                        if (PF.IOCheck("1") == "1")
                        {
                            PV.sInput1 = "1";

                        }
                        else
                        {
                            PV.sInput1 = "0";
                        }

                        if (PF.IOCheck("2") == "1")
                        {
                            PV.sInput2 = "1";
                        }
                        else
                        {
                            PV.sInput2 = "0";
                        }

                        if (PF.IOCheck("3") == "1")
                        {
                            PV.sInput3 = "1";
                        }
                        else
                        {
                            PV.sInput3 = "0";
                        }

                        if (PF.IOCheck("4") == "1")
                        {
                            PV.sInput4 = "1";
                        }
                        else
                        {
                            PV.sInput4 = "0";
                        }

                        if (PF.IOCheck("5") == "1")
                        {
                            PV.sInput5 = "1";
                        }
                        else
                        {
                            PV.sInput5 = "0";
                        }

                        if (PF.IOCheck("6") == "1")
                        {
                            PV.sInput6 = "1";
                        }
                        else
                        {
                            PV.sInput6 = "0";
                        }

                        if (PF.IOCheck("7") == "1")
                        {
                            PV.sInput7 = "1";
                        }
                        else
                        {
                            PV.sInput7 = "0";
                        }

                        if (PF.IOCheck("8") == "1")
                        {
                            PV.sInput8 = "1";
                        }
                        else
                        {
                            PV.sInput8 = "0";
                        }

                        PF.IOOutPutMessage("2", PV.sInput1);
                        PF.IOOutPutMessage("3", PV.sInput2);
                        PF.IOOutPutMessage("4", PV.sInput3);
                        PF.IOOutPutMessage("5", PV.sInput4);
                        PF.IOOutPutMessage("6", PV.sInput5);
                        PF.IOOutPutMessage("7", PV.sInput6);
                        PF.IOOutPutMessage("8", PV.sInput7);
                        PF.IOOutPutMessage("9", PV.sInput8);

                        PV.bModelNum = "";
                        StringBuilder sb = new StringBuilder();
                        PV.bModelNum = sb.Append(PV.sInput8).Append(PV.sInput7).Append(PV.sInput6).Append(PV.sInput5).Append(PV.sInput4).Append(PV.sInput3).Append(PV.sInput2).Append(PV.sInput1).ToString();
                        PV.iModelNum = Convert.ToInt32(PV.bModelNum, 2);


                        PV.Result1LowerLimit = Convert.ToInt32(PV.stringArray_Limit[PV.iModelNum - 1].Split(',')[0]);
                        PV.Result1UpperLimit = Convert.ToInt32(PV.stringArray_Limit[PV.iModelNum - 1].Split(',')[1]);

                        if (PV.iModelNum != 0)
                        {
                            this.Invoke(new Action(delegate ()
                            {
                                lb_Model.Text = PV.stringArray_Model[PV.iModelNum - 1].ToString();
                                lb_ModelName.Text = "Model : " + PV.stringArray_Model[PV.iModelNum - 1].ToString();
                                tb_OffsetAngle.Text = PV.stringArray_Offset[PV.iModelNum - 1];
                                tb_ScoreShape.Text = PV.stringArray_Score[PV.iModelNum - 1];
                                tb_ScoreAngle.Text = PV.stringArray_AngleScore[PV.iModelNum - 1];
                            }));
                        }


                        if (PV.iModelNum_Old != PV.iModelNum)
                        {
                            this.Invoke(new Action(delegate ()
                            {
                                pb_FileLoading.Visible = true;
                                PF.Delay(100);
                                CAMERA_JobInitialize();
                                pb_FileLoading.Visible = false;
                                
                            }));

                        }PV.iModelNum_Old = PV.iModelNum;
                    }

                }
                catch (Exception ex)
                {
                    PF.ExceptionWriter("Task_GetModel1", ex.Message);
                    MessageBox.Show(ex.ToString());
                    IOReset();
                    return;
                }
            }
            Thread.Sleep(1000);
        }

        private void IOReset()
        {
            PF.IOOutPutMessage("0", "0");
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
            PF.IOOutPutMessage("14", "0");
            PF.IOOutPutMessage("15", "0");
            PF.IOOutPutMessage("16", "0");
            PF.IOOutPutMessage("17", "0");
            PF.IOOutPutMessage("18", "0");
            PF.IOOutPutMessage("19", "0");
            PF.IOOutPutMessage("20", "0");
            PF.IOOutPutMessage("21", "0");
            PF.IOOutPutMessage("22", "0");
            PF.IOOutPutMessage("23", "0");
            PF.IOOutPutMessage("24", "0");
            PF.IOOutPutMessage("25", "0");
            PF.IOOutPutMessage("26", "0");
            PF.IOOutPutMessage("27", "0");
            PF.IOOutPutMessage("28", "0");
            PF.IOOutPutMessage("29", "0");
            PF.IOOutPutMessage("30", "0");
            PF.IOOutPutMessage("31", "0");
            PF.IOOutPutMessage("32", "0");
        }

        private void Task_RunCam1()
        {
            while (PV.bIOCheck)
            {
                try
                {
                    if (PF.IOCheck("9") == "1")            // IOCheck 0 = Cam1 trigger
                    {
                        PV.InputCheck1 = 1;

                        if ((PV.InputCheck_Old1 == 0) && (PV.InputCheck1 == 1))
                        {
                            CAMERA1_Job.Run();
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

        private void TaskIOoutput()
        {
            try
            {
                II_ToolGroup = CAMERA1_Job.VisionTool as CogToolGroup;
                II_ToolBlock = II_ToolGroup.Tools["Results"] as CogToolBlock;
                CogPMAlignTool CogPMAlignTool1 = II_ToolGroup.Tools["회전 위치 찾기"] as CogPMAlignTool;

                StringBuilder sbScore = new StringBuilder();
                StringBuilder sbScore1 = new StringBuilder();

                // 형상검사
                if (PV.sResult2_1 == "OK" && PV.sResult2_2 == "OK")
                {
                    PV.nPassCount++;
                    PF.IOOutPutMessage("20", "1");
                    PF.Delay(PV.OutputDelay);
                    PF.IOOutPutMessage("20", "0");


                    this.Invoke(new Action(delegate ()
                    {
                        lb_Shape.Text = sbScore.Append(PV.dScore).Append(" / OK").ToString();
                        pb1.Image = imageList1.Images[0];
                    }));


                    if (PV.bAllSave)
                    {
                        this.Invoke(new Action(delegate ()
                        {
                            string FileName = PF.ImageSave("OK");
                            ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                            ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                            ImageFileTool.Run();
                            ImageFileTool.Operator.Close();
                        }));
                    }

                }
                else
                {
                    PV.nFailCount++;

                    PF.IOOutPutMessage("21", "1");
                    PF.Delay(PV.OutputDelay);
                    PF.IOOutPutMessage("21", "0");

                    this.Invoke(new Action(delegate ()
                    {
                        lb_Shape.Text = sbScore.Append(PV.dScore).Append(" / NG").ToString();
                        pb1.Image = imageList1.Images[1];
                    }));

                    if (PV.bNGSave || PV.bAllSave)
                    {
                        this.Invoke(new Action(delegate ()
                        {
                            string FileName = PF.ImageSave("NG");
                            ImageFileTool.Operator.Open(FileName, CogImageFileModeConstants.Write);
                            ImageFileTool.InputImage = (CogImage8Grey)CogPMAlignTool1.InputImage;
                            ImageFileTool.Run();
                            ImageFileTool.Operator.Close();
                        }));
                    }
                }

                //각도검사
                StringBuilder sb2 = new StringBuilder();
                //ok
                if ((PV.Result1LowerLimit <= PV.dResult1 && PV.dResult1 <= PV.Result1UpperLimit))
                {
                    PF.IOOutPutMessage("10", "1");
                    PF.Delay(PV.OutputDelay);
                    PF.IOOutPutMessage("10", "0");

                    this.Invoke(new Action(delegate ()
                    {
                        lb_Angle.Text = sb2.Append(PV.dResult1).Append(" / OK   / ").Append(PV.sResult2_2).ToString();
                    }));

                }
                else
                {
                    PF.IOOutPutMessage("11", "1");
                    PF.Delay(PV.OutputDelay);
                    PF.IOOutPutMessage("11", "0");

                    this.Invoke(new Action(delegate ()
                    {
                        lb_Angle.Text = sb2.Append(PV.dResult1).Append(" / NG   / ").Append(PV.sResult2_2).ToString();
                    }));
                }



            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("TaskIOoutput", ex.Message);
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
                if (PV.iModelNum == 0)
                {
                    MessageBox.Show("모델을 선택하세요.");
                    return;
                }

                pb_FileLoading.Visible = true;
                PF.Delay(100);

                btn_Start.Enabled = false;
                btn_Start.FlatAppearance.BorderColor = Color.White;
                btn_Stop.Enabled = true;
                btn_Stop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
                btn_AddModel.Enabled = false;
                tb_OffsetAngle.ReadOnly = true;
                tb_ScoreShape.ReadOnly = true;

                CAMERA_JobInitialize();

                PV.bIOCheck = true;
                timer1.Enabled = true;

                Task taskGetModel1 = new Task(Task_GetModel1);
                taskGetModel1.Start();

                Task taskRun = new Task(Task_RunCam1);
                taskRun.Start();



                pb_FileLoading.Visible = false;

                PF.IOOutPutMessage("1", "1");

                this.Invoke(new Action(delegate ()
                {
                    string Logtime = PV.lib.getTime("YYMMDD");
                    StringBuilder sb = new StringBuilder();
                    listBox1.Items.Insert(0, sb.Append("[Time] : ").Append(Logtime).Append(" Start"));
                }));
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("btn_Start_Click", ex.Message);
                MessageBox.Show(ex.Message);
                IOReset();
                return;
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Start.Enabled = true;
                btn_Start.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
                btn_Stop.Enabled = false;
                btn_Stop.FlatAppearance.BorderColor = Color.White;
                btn_AddModel.Enabled = true;
                tb_OffsetAngle.ReadOnly = false;
                tb_ScoreShape.ReadOnly = false;

                PV.bIOCheck = false;

                timer1.Enabled = false;

                IOReset();

                Task taskGetLight = new Task(Task_GetLight);
                taskGetLight.Start();

                Task taskGetModel = new Task(Task_GetModel);
                taskGetModel.Start();

                this.Invoke(new Action(delegate ()
                {
                    string Logtime = PV.lib.getTime("YYMMDD");
                    StringBuilder sb = new StringBuilder();
                    listBox1.Items.Insert(0, sb.Append("[Time] : ").Append(Logtime).Append(" Stop"));
                }));
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("btn_Stop_Click", ex.Message);
                MessageBox.Show(ex.Message);
                IOReset();
                return;
            }

        }


        private void btn_EXIT_Click(object sender, EventArgs e)
        {
            IOReset();
            PF.ProcessKill("IVSSYSTEM");
            this.Close();
        }


        private void cb_NGSave_CheckedChanged(object sender, EventArgs e)
        {
            PV.bNGSave = cb_NGSave.Checked;
            string Logtime = lib.getTime("YYMMDD");
            StringBuilder sb = new StringBuilder();
            listBox1.Items.Insert(0, sb.Append("[Time] : ").Append(Logtime).Append(" [State] : NG Image Save : ").Append(PV.bNGSave));
        }

        private void cb_AllSave_CheckedChanged(object sender, EventArgs e)
        {
            PV.bAllSave = cb_AllSave.Checked;
            string Logtime = lib.getTime("YYMMDD");
            StringBuilder sb = new StringBuilder();
            listBox1.Items.Insert(0, sb.Append("[Time] : ").Append(Logtime).Append(" [State] : All Image Save : ").Append(PV.bAllSave));
        }


        private void btn_Model_Click(object sender, EventArgs e)
        {
            FormPassword form0 = new FormPassword();
            form0.ShowDialog();

            if (form0.PWCheck(form0.tb_0.Text))
            {
                if (PV.bIOCheck == false)
                {
                    if (model == null || model.Text == "Model")
                    {
                        switch (PV.iModelNum)
                        {
                            case 1:
                                model = new Model(PV.CAMERA_PATH1);
                                break;

                            case 2:
                                model = new Model(PV.CAMERA_PATH2);
                                break;

                            case 3:
                                model = new Model(PV.CAMERA_PATH3);
                                break;

                            case 4:
                                model = new Model(PV.CAMERA_PATH4);
                                break;

                            case 5:
                                model = new Model(PV.CAMERA_PATH5);
                                break;

                            case 6:
                                model = new Model(PV.CAMERA_PATH6);
                                break;

                            case 7:
                                model = new Model(PV.CAMERA_PATH7);
                                break;

                            case 8:
                                model = new Model(PV.CAMERA_PATH8);
                                break;

                            case 9:
                                model = new Model(PV.CAMERA_PATH9);
                                break;

                            case 10:
                                model = new Model(PV.CAMERA_PATH10);
                                break;

                            case 11:
                                model = new Model(PV.CAMERA_PATH11);
                                break;

                            case 12:
                                model = new Model(PV.CAMERA_PATH12);
                                break;

                            case 13:
                                model = new Model(PV.CAMERA_PATH13);
                                break;

                            case 14:
                                model = new Model(PV.CAMERA_PATH14);
                                break;

                            case 15:
                                model = new Model(PV.CAMERA_PATH15);
                                break;

                            case 16:
                                model = new Model(PV.CAMERA_PATH16);
                                break;

                            case 17:
                                model = new Model(PV.CAMERA_PATH17);
                                break;

                            case 18:
                                model = new Model(PV.CAMERA_PATH18);
                                break;

                            case 19:
                                model = new Model(PV.CAMERA_PATH19);
                                break;

                            case 20:
                                model = new Model(PV.CAMERA_PATH20);
                                break;

                            case 21:
                                model = new Model(PV.CAMERA_PATH21);
                                break;

                            case 22:
                                model = new Model(PV.CAMERA_PATH22);
                                break;

                            case 23:
                                model = new Model(PV.CAMERA_PATH23);
                                break;

                            case 24:
                                model = new Model(PV.CAMERA_PATH24);
                                break;

                            case 25:
                                model = new Model(PV.CAMERA_PATH25);
                                break;

                            case 26:
                                model = new Model(PV.CAMERA_PATH26);
                                break;

                            case 27:
                                model = new Model(PV.CAMERA_PATH27);
                                break;

                            case 28:
                                model = new Model(PV.CAMERA_PATH28);
                                break;

                            case 29:
                                model = new Model(PV.CAMERA_PATH29);
                                break;

                            case 30:
                                model = new Model(PV.CAMERA_PATH30);
                                break;


                            case 31:
                                model = new Model(PV.CAMERA_PATH31);
                                break;

                            case 32:
                                model = new Model(PV.CAMERA_PATH32);
                                break;

                            case 33:
                                model = new Model(PV.CAMERA_PATH33);
                                break;

                            case 34:
                                model = new Model(PV.CAMERA_PATH34);
                                break;

                            case 35:
                                model = new Model(PV.CAMERA_PATH35);
                                break;

                            case 36:
                                model = new Model(PV.CAMERA_PATH36);
                                break;

                            case 37:
                                model = new Model(PV.CAMERA_PATH37);
                                break;

                            case 38:
                                model = new Model(PV.CAMERA_PATH38);
                                break;

                            case 39:
                                model = new Model(PV.CAMERA_PATH39);
                                break;

                            case 40:
                                model = new Model(PV.CAMERA_PATH40);
                                break;

                            case 41:
                                model = new Model(PV.CAMERA_PATH41);
                                break;

                            case 42:
                                model = new Model(PV.CAMERA_PATH42);
                                break;

                            case 43:
                                model = new Model(PV.CAMERA_PATH43);
                                break;

                            case 44:
                                model = new Model(PV.CAMERA_PATH44);
                                break;

                            case 45:
                                model = new Model(PV.CAMERA_PATH45);
                                break;

                            case 46:
                                model = new Model(PV.CAMERA_PATH46);
                                break;

                            case 47:
                                model = new Model(PV.CAMERA_PATH47);
                                break;

                            case 48:
                                model = new Model(PV.CAMERA_PATH48);
                                break;

                            case 49:
                                model = new Model(PV.CAMERA_PATH49);
                                break;

                            case 50:
                                model = new Model(PV.CAMERA_PATH50);
                                break;

                            case 51:
                                model = new Model(PV.CAMERA_PATH51);
                                break;

                            case 52:
                                model = new Model(PV.CAMERA_PATH52);
                                break;

                            case 53:
                                model = new Model(PV.CAMERA_PATH53);
                                break;

                            case 54:
                                model = new Model(PV.CAMERA_PATH54);
                                break;

                            case 55:
                                model = new Model(PV.CAMERA_PATH55);
                                break;

                            case 56:
                                model = new Model(PV.CAMERA_PATH56);
                                break;

                            case 57:
                                model = new Model(PV.CAMERA_PATH57);
                                break;

                            case 58:
                                model = new Model(PV.CAMERA_PATH58);
                                break;

                            case 59:
                                model = new Model(PV.CAMERA_PATH59);
                                break;

                            case 60:
                                model = new Model(PV.CAMERA_PATH60);
                                break;

                            case 61:
                                model = new Model(PV.CAMERA_PATH61);
                                break;

                            case 62:
                                model = new Model(PV.CAMERA_PATH62);
                                break;

                            case 63:
                                model = new Model(PV.CAMERA_PATH63);
                                break;

                            case 64:
                                model = new Model(PV.CAMERA_PATH64);
                                break;

                            case 65:
                                model = new Model(PV.CAMERA_PATH65);
                                break;

                            case 66:
                                model = new Model(PV.CAMERA_PATH66);
                                break;

                            case 67:
                                model = new Model(PV.CAMERA_PATH67);
                                break;

                            case 68:
                                model = new Model(PV.CAMERA_PATH68);
                                break;

                            case 69:
                                model = new Model(PV.CAMERA_PATH69);
                                break;

                            case 70:
                                model = new Model(PV.CAMERA_PATH70);
                                break;

                            case 71:
                                model = new Model(PV.CAMERA_PATH71);
                                break;


                            case 72:
                                model = new Model(PV.CAMERA_PATH72);
                                break;

                            case 73:
                                model = new Model(PV.CAMERA_PATH73);
                                break;

                            case 74:
                                model = new Model(PV.CAMERA_PATH74);
                                break;

                            case 75:
                                model = new Model(PV.CAMERA_PATH75);
                                break;

                            case 76:
                                model = new Model(PV.CAMERA_PATH76);
                                break;

                            case 77:
                                model = new Model(PV.CAMERA_PATH77);
                                break;

                            case 78:
                                model = new Model(PV.CAMERA_PATH78);
                                break;

                            case 79:
                                model = new Model(PV.CAMERA_PATH79);
                                break;

                            case 80:
                                model = new Model(PV.CAMERA_PATH80);
                                break;

                            case 81:
                                model = new Model(PV.CAMERA_PATH81);
                                break;

                            case 82:
                                model = new Model(PV.CAMERA_PATH82);
                                break;

                            case 83:
                                model = new Model(PV.CAMERA_PATH83);
                                break;

                            case 84:
                                model = new Model(PV.CAMERA_PATH84);
                                break;

                            case 85:
                                model = new Model(PV.CAMERA_PATH85);
                                break;

                            case 86:
                                model = new Model(PV.CAMERA_PATH86);
                                break;

                            case 87:
                                model = new Model(PV.CAMERA_PATH87);
                                break;

                            case 88:
                                model = new Model(PV.CAMERA_PATH88);
                                break;

                            case 89:
                                model = new Model(PV.CAMERA_PATH89);
                                break;

                            case 90:
                                model = new Model(PV.CAMERA_PATH90);
                                break;

                            case 91:
                                model = new Model(PV.CAMERA_PATH91);
                                break;

                            case 92:
                                model = new Model(PV.CAMERA_PATH92);
                                break;

                            case 93:
                                model = new Model(PV.CAMERA_PATH93);
                                break;

                            case 94:
                                model = new Model(PV.CAMERA_PATH94);
                                break;

                            case 95:
                                model = new Model(PV.CAMERA_PATH95);
                                break;

                            case 96:
                                model = new Model(PV.CAMERA_PATH96);
                                break;

                            case 97:
                                model = new Model(PV.CAMERA_PATH97);
                                break;

                            case 98:
                                model = new Model(PV.CAMERA_PATH98);
                                break;

                            case 99:
                                model = new Model(PV.CAMERA_PATH99);
                                break;

                            case 100:
                                model = new Model(PV.CAMERA_PATH100);
                                break;

                            case 101:
                                model = new Model(PV.CAMERA_PATH101);
                                break;

                            case 102:
                                model = new Model(PV.CAMERA_PATH102);
                                break;

                            case 103:
                                model = new Model(PV.CAMERA_PATH103);
                                break;

                            case 104:
                                model = new Model(PV.CAMERA_PATH104);
                                break;

                            case 105:
                                model = new Model(PV.CAMERA_PATH105);
                                break;

                            case 106:
                                model = new Model(PV.CAMERA_PATH106);
                                break;

                            case 107:
                                model = new Model(PV.CAMERA_PATH107);
                                break;

                            case 108:
                                model = new Model(PV.CAMERA_PATH108);
                                break;

                            case 109:
                                model = new Model(PV.CAMERA_PATH109);
                                break;

                            case 110:
                                model = new Model(PV.CAMERA_PATH110);
                                break;

                            case 111:
                                model = new Model(PV.CAMERA_PATH111);
                                break;

                            case 112:
                                model = new Model(PV.CAMERA_PATH112);
                                break;

                            case 113:
                                model = new Model(PV.CAMERA_PATH113);
                                break;

                            case 114:
                                model = new Model(PV.CAMERA_PATH114);
                                break;

                            case 115:
                                model = new Model(PV.CAMERA_PATH115);
                                break;

                            case 116:
                                model = new Model(PV.CAMERA_PATH116);
                                break;

                            case 117:
                                model = new Model(PV.CAMERA_PATH117);
                                break;

                            case 118:
                                model = new Model(PV.CAMERA_PATH118);
                                break;

                            case 119:
                                model = new Model(PV.CAMERA_PATH119);
                                break;

                            case 120:
                                model = new Model(PV.CAMERA_PATH120);
                                break;

                            case 121:
                                model = new Model(PV.CAMERA_PATH121);
                                break;

                            case 122:
                                model = new Model(PV.CAMERA_PATH122);
                                break;

                            case 123:
                                model = new Model(PV.CAMERA_PATH123);
                                break;

                            case 124:
                                model = new Model(PV.CAMERA_PATH124);
                                break;

                            case 125:
                                model = new Model(PV.CAMERA_PATH125);
                                break;

                            case 126:
                                model = new Model(PV.CAMERA_PATH126);
                                break;

                            case 127:
                                model = new Model(PV.CAMERA_PATH127);
                                break;

                            case 128:
                                model = new Model(PV.CAMERA_PATH128);
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
            else
            {
                MessageBox.Show("비밀번호가 틀렸습니다.");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_Count.Text = PV.nTotalCount.ToString();
            lb_FailCount.Text = PV.nFailCount.ToString();
            lb_PassCount.Text = PV.nPassCount.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            lb_NowTime.Text = sb.Append(DateTime.Now.ToString("yyyy-MM-dd")).Append("  ").Append(DateTime.Now.ToString("tt hh:mm:ss")).ToString();
        }
        private void btn_CountReset_Click(object sender, EventArgs e)
        {
            PV.nTotalCount = 0;
            PV.nFailCount = 0;
            PV.nPassCount = 0;
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string s = sp.ReadExisting();
            Invoke(new Action(() => listBox1.Items.Insert(0, s)));
        }

        private void btn_AddModel_Click(object sender, EventArgs e)
        {
            PF.ReadModelData();
            Add_ModelList newform = new Add_ModelList();
            newform.main = this;
            newform.ShowDialog();
        }
        #endregion



    }

}
