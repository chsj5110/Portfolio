using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.ToolGroup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IVSSYSTEM
{
    public partial class Form4 : Form
    {

        public MainForm MainForm;
        Form5 form5 = null;
        Library lib = new Library();


        public Form4()
        {
            InitializeComponent();
        }

        private void bt_back4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveData_Bypass(string fileName)

        {
            // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))

            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0}", Bypass_1.Checked));
            }

        }

        private void SaveData_Setting(string fileName)

        {
            // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))

            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4};{5}", Pattern_Result_Score_1_Min.Text,
                    Pattern_Result_Score_1_Max.Text, GetBlobs_Area_1_Min.Text, GetBlobs_Area_1_Max.Text, CogHistogramTool_Result_Mean_1_Min.Text, CogHistogramTool_Result_Mean_1_Max.Text));
            }

        }

        private void SaveData_Offset(string fileName)

        {
            // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))

            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1};{2}", Pattern_Result_Score_1_Offset.Text, GetBlobs_Area_1_Offset.Text, CogHistogramTool_Result_Mean_1_Offset.Text));
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            MainForm.II_ToolGroup = MainForm.CAMERA4_Job.VisionTool as CogToolGroup;
            num_threshold.Value = ((CogBlobTool)MainForm.II_ToolGroup.Tools["CogBlobTool1"]).RunParams.SegmentationParams.HardFixedThreshold;
            num_pixel.Value = ((CogBlobTool)MainForm.II_ToolGroup.Tools["CogBlobTool1"]).RunParams.ConnectivityMinPixels;

            //Cam4

            // 주름관
            //setting
            Pattern_Result_Score_1_Min.Text = String.Format("{0:0.000}", PV.Pattern_Result_Score_41_Min);
            Pattern_Result_Score_1_Max.Text = String.Format("{0:0.000}", PV.Pattern_Result_Score_41_Max);
            GetBlobs_Area_1_Min.Text = String.Format("{0:0.000}", PV.GetBlobs_Area_41_Min);
            GetBlobs_Area_1_Max.Text = String.Format("{0:0.000}", PV.GetBlobs_Area_41_Max);
            CogHistogramTool_Result_Mean_1_Min.Text = String.Format("{0:0.000}", PV.CogHistogramTool_Result_Mean_41_Min);
            CogHistogramTool_Result_Mean_1_Max.Text = String.Format("{0:0.000}", PV.CogHistogramTool_Result_Mean_41_Max);

            //bypass
            Bypass_1.Checked = PV.bBypass_41;

            //result
            Pattern_Result_Score_1_Result.Text = PV.Pattern_Result_Score_41;
            GetBlobs_Area_1_Result.Text = PV.GetBlobs_Area_41;
            CogHistogramTool_Result_Mean_1_Result.Text = PV.CogHistogramTool_Result_Mean_41;

            //offset
            Pattern_Result_Score_1_Offset.Text = String.Format("{0:0.000}", PV.Pattern_Result_Score_41_Offset);
            GetBlobs_Area_1_Offset.Text = String.Format("{0:0.000}", PV.GetBlobs_Area_41_Offset);
            CogHistogramTool_Result_Mean_1_Offset.Text = String.Format("{0:0.000}", PV.CogHistogramTool_Result_Mean_41_Offset);



            // 민자관
            //setting
            Pattern_Result_Score_2_Min.Text = String.Format("{0:0.000}", PV.Pattern_Result_Score_41_Min);
            Pattern_Result_Score_2_Max.Text = String.Format("{0:0.000}", PV.Pattern_Result_Score_41_Max);
            GetBlobs_Area_2_Min.Text = String.Format("{0:0.000}", PV.GetBlobs_Area_41_Min);
            GetBlobs_Area_2_Max.Text = String.Format("{0:0.000}", PV.GetBlobs_Area_41_Max);
            CogHistogramTool_Result_Mean_2_Min.Text = String.Format("{0:0.000}", PV.CogHistogramTool_Result_Mean_41_Min);
            CogHistogramTool_Result_Mean_2_Max.Text = String.Format("{0:0.000}", PV.CogHistogramTool_Result_Mean_41_Max);

            //bypass
            Bypass_2.Checked = PV.bBypass_41;

            //result
            Pattern_Result_Score_2_Result.Text = PV.Pattern_Result_Score_41;
            GetBlobs_Area_2_Result.Text = PV.GetBlobs_Area_41;
            CogHistogramTool_Result_Mean_2_Result.Text = PV.CogHistogramTool_Result_Mean_41;

            //offset
            Pattern_Result_Score_2_Offset.Text = String.Format("{0:0.000}", PV.Pattern_Result_Score_41_Offset);
            GetBlobs_Area_2_Offset.Text = String.Format("{0:0.000}", PV.GetBlobs_Area_41_Offset);
            CogHistogramTool_Result_Mean_2_Offset.Text = String.Format("{0:0.000}", PV.CogHistogramTool_Result_Mean_41_Offset);

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                checkblank();

                ReWriteSettings();
                ReWriteJob();
                PF.ReadSettingDataCam4();


                if (MainForm.CAMERA4_Job != null && MainForm.CAMERA4_JobManager != null)
                {
                    MainForm.CAMERA4_Job.Reset();
                    MainForm.CAMERA4_JobManager.Reset();
                }

                MainForm.CAMERA_JobInitialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        void ReWriteJob()
        {
            MainForm.II_ToolGroup = MainForm.CAMERA4_Job.VisionTool as CogToolGroup;
            MainForm.II_ToolBlock = MainForm.II_ToolGroup.Tools["Results"] as CogToolBlock;

            // 검출기준 수정
            ((CogBlobTool)MainForm.II_ToolGroup.Tools["CogBlobTool1"]).RunParams.SegmentationParams.HardFixedThreshold = Convert.ToInt32(num_threshold.Value);
            ((CogBlobTool)MainForm.II_ToolGroup.Tools["CogBlobTool1"]).RunParams.ConnectivityMinPixels = Convert.ToInt32(num_pixel.Value);

            (MainForm.II_ToolBlock.Inputs["PatternMin_1"]).Value = Convert.ToDouble(Pattern_Result_Score_1_Min.Text);
            (MainForm.II_ToolBlock.Inputs["PatternMax_1"]).Value = Convert.ToDouble(Pattern_Result_Score_1_Max.Text);
            (MainForm.II_ToolBlock.Inputs["GetBlobMin_1"]).Value = Convert.ToDouble(GetBlobs_Area_1_Min.Text);
            (MainForm.II_ToolBlock.Inputs["GetBlobMax_1"]).Value = Convert.ToDouble(GetBlobs_Area_1_Max.Text);
            (MainForm.II_ToolBlock.Inputs["MeanMin_1"]).Value = Convert.ToDouble(CogHistogramTool_Result_Mean_1_Min.Text);
            (MainForm.II_ToolBlock.Inputs["MeanMax_1"]).Value = Convert.ToDouble(CogHistogramTool_Result_Mean_1_Max.Text);

            //(MainForm.II_ToolBlock.Inputs["PatternMin_2"]).Value = Convert.ToDouble(Pattern_Result_Score_2_Min.Text);
            //(MainForm.II_ToolBlock.Inputs["PatternMax_2"]).Value = Convert.ToDouble(Pattern_Result_Score_2_Max.Text);
            //(MainForm.II_ToolBlock.Inputs["GetBlobMin_2"]).Value = Convert.ToDouble(GetBlobs_Area_2_Min.Text);
            //(MainForm.II_ToolBlock.Inputs["GetBlobMax_2"]).Value = Convert.ToDouble(GetBlobs_Area_2_Max.Text);
            //(MainForm.II_ToolBlock.Inputs["MeanMin_2"]).Value = Convert.ToDouble(CogHistogramTool_Result_Mean_2_Min.Text);
            //(MainForm.II_ToolBlock.Inputs["MeanMax_2"]).Value = Convert.ToDouble(CogHistogramTool_Result_Mean_2_Max.Text);

            // 오프셋값
            (MainForm.II_ToolBlock.Inputs["PatternOffset_1"]).Value = Convert.ToDouble(Pattern_Result_Score_1_Offset.Text);
            (MainForm.II_ToolBlock.Inputs["GetBlobOffset_1"]).Value = Convert.ToDouble(GetBlobs_Area_1_Offset.Text);
            (MainForm.II_ToolBlock.Inputs["MeanOffset_1"]).Value = Convert.ToDouble(CogHistogramTool_Result_Mean_1_Offset.Text);

            //(MainForm.II_ToolBlock.Inputs["PatternOffset_2"]).Value = Convert.ToDouble(Pattern_Result_Score_2_Offset.Text);
            //(MainForm.II_ToolBlock.Inputs["GetBlobOffset_2"]).Value = Convert.ToDouble(GetBlobs_Area_2_Offset.Text);
            //(MainForm.II_ToolBlock.Inputs["MeanOffset_2"]).Value = Convert.ToDouble(CogHistogramTool_Result_Mean_2_Offset.Text);

            CogSerializer.SaveObjectToFile(MainForm.CAMERA4_JobManager, PV.CAMERA4_PATH, typeof(BinaryFormatter), CogSerializationOptionsConstants.All);
        }


        void ReWriteSettings()
        {

            StreamWriter sw1;
            string FileName_Bypass = PV.SettingDataPath + @"\Bypass4.txt";
            StreamWriter sw2;
            string FileName_Setting = PV.SettingDataPath + @"\Setting4.txt";
            StreamWriter sw3;
            string FileName_Offset = PV.SettingDataPath + @"\Offset4.txt";

            // Bypass
            if (!File.Exists(FileName_Bypass))
            { sw1 = new StreamWriter(FileName_Bypass, true, Encoding.Default); }
            else
            { sw1 = new StreamWriter(FileName_Bypass, false, Encoding.Default); }

            sw1.WriteLine(Bypass_1.Checked);
            sw1.Close();

            // Setting
            if (!File.Exists(FileName_Setting))
            { sw2 = new StreamWriter(FileName_Setting, true, Encoding.Default); }
            else
            { sw2 = new StreamWriter(FileName_Setting, false, Encoding.Default); }

            sw2.WriteLine(Pattern_Result_Score_1_Min.Text + ";" + Pattern_Result_Score_1_Max.Text + ";" + GetBlobs_Area_1_Min.Text + ";" + GetBlobs_Area_1_Max.Text + ";" + CogHistogramTool_Result_Mean_1_Min.Text + ";" + CogHistogramTool_Result_Mean_1_Max.Text);
            sw2.Close();

            // Offset
            if (!File.Exists(FileName_Offset))
            { sw3 = new StreamWriter(FileName_Offset, true, Encoding.Default); }
            else
            { sw3 = new StreamWriter(FileName_Offset, false, Encoding.Default); }

            sw3.WriteLine(Pattern_Result_Score_1_Offset.Text + ";" + GetBlobs_Area_1_Offset.Text + ";" + CogHistogramTool_Result_Mean_1_Offset.Text);
            sw3.Close();


            // 세팅변경사항 로그 쓰기
            StreamWriter sw;
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss.fff");
            string FileName = PV.DirData + @"\카메라4\" + date + ".csv";

            sw = new StreamWriter(FileName, true, Encoding.Default);

            // 세팅 변경
            sw.WriteLine("시간, 위치, 세팅변경, 주름관 형상 하한, 주름관 형상 상한, 주름관 블랍 하한, 주름관 블랍 상한, 주름관 표면밝기 하한, 주름관 표면밝기 상한");

            sw.WriteLine(date + "_" + time + ", 카메라4, 검사기준설정 - 상하한 변경, " + Pattern_Result_Score_1_Min.Text + "," + Pattern_Result_Score_1_Max.Text + "," + GetBlobs_Area_1_Min.Text + "," + GetBlobs_Area_1_Max.Text + "," + CogHistogramTool_Result_Mean_1_Min.Text + "," + CogHistogramTool_Result_Mean_1_Max.Text);

            // 바이패스 변경
            sw.WriteLine("시간, 위치, 세팅변경, 주름관");

            sw.WriteLine(date + "_" + time + ", 카메라4, 검사기준설정 - Bypass 변경, " + Bypass_1.Checked);

            // 오프셋 변경
            sw.WriteLine("시간, 위치, 세팅변경, 주름관 형상, 주름관 블랍, 주름관 표면밝기, 민자관 형상, 민자관 블랍, 민자관 표면밝기");

            sw.WriteLine(date + "_" + time + ", 카메라4, 검사기준설정 - Offset 변경, " + Pattern_Result_Score_1_Offset.Text + "," + GetBlobs_Area_1_Offset.Text + "," + CogHistogramTool_Result_Mean_1_Offset.Text);

            // 검출 기준 변경
            sw.WriteLine("시간, 위치, 세팅변경, 검출 민감도, 검출 최소크기");

            sw.WriteLine(date + "_" + time + ", 카메라4, 검사기준설정 - 검출 기준 변경, " + num_threshold.Value + "," + num_pixel.Value
             );
            sw.Close();

        }

        private void bt_SetCam4_Click(object sender, EventArgs e)
        {

            if (form5 == null || form5.Text == "Setting")
            {
                form5 = new Form5(PV.CAMERA4_PATH);
                form5.ShowDialog();
            }
            else
            {
                form5.Activate();
            }
            PF.WriteSysLog("bt_SetCam4_Click", "CAM4 JOB SETTING");
        }

        void checkblank()
        {

            if (Pattern_Result_Score_1_Min.Text == "")
            {
                Pattern_Result_Score_1_Min.Text = "0.000";
            }
            if (Pattern_Result_Score_1_Max.Text == "")
            {
                Pattern_Result_Score_1_Max.Text = "0.000";
            }

            if (GetBlobs_Area_1_Min.Text == "")
            {
                GetBlobs_Area_1_Min.Text = "0.000";
            }
            if (GetBlobs_Area_1_Max.Text == "")
            {
                GetBlobs_Area_1_Max.Text = "0.000";
            }
            if (CogHistogramTool_Result_Mean_1_Min.Text == "")
            {
                CogHistogramTool_Result_Mean_1_Min.Text = "0.000";
            }
            if (CogHistogramTool_Result_Mean_1_Max.Text == "")
            {
                CogHistogramTool_Result_Mean_1_Max.Text = "0.000";
            }

            if (Pattern_Result_Score_2_Min.Text == "")
            {
                Pattern_Result_Score_2_Min.Text = "0.000";
            }
            if (Pattern_Result_Score_2_Max.Text == "")
            {
                Pattern_Result_Score_2_Max.Text = "0.000";
            }

            if (GetBlobs_Area_2_Min.Text == "")
            {
                GetBlobs_Area_2_Min.Text = "0.000";
            }
            if (GetBlobs_Area_2_Max.Text == "")
            {
                GetBlobs_Area_2_Max.Text = "0.000";
            }
            if (CogHistogramTool_Result_Mean_2_Min.Text == "")
            {
                CogHistogramTool_Result_Mean_2_Min.Text = "0.000";
            }
            if (CogHistogramTool_Result_Mean_2_Max.Text == "")
            {
                CogHistogramTool_Result_Mean_2_Max.Text = "0.000";
            }




            //offset
            if (Pattern_Result_Score_1_Offset.Text == "")
            {
                Pattern_Result_Score_1_Offset.Text = "0.000";
            }
            if (GetBlobs_Area_1_Offset.Text == "")
            {
                GetBlobs_Area_1_Offset.Text = "0.000";
            }
            if (CogHistogramTool_Result_Mean_1_Offset.Text == "")
            {
                CogHistogramTool_Result_Mean_1_Offset.Text = "0.000";
            }
            if (Pattern_Result_Score_2_Offset.Text == "")
            {
                Pattern_Result_Score_2_Offset.Text = "0.000";
            }
            if (GetBlobs_Area_2_Offset.Text == "")
            {
                GetBlobs_Area_2_Offset.Text = "0.000";
            }
            if (CogHistogramTool_Result_Mean_2_Offset.Text == "")
            {
                CogHistogramTool_Result_Mean_2_Offset.Text = "0.000";
            }


        }
    }
}
