using Cognex.VisionPro;
using Cognex.VisionPro.QuickBuild;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.ToolGroup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        #endregion

        #region Inspection Result Setting 변수

        public CogToolGroup II_ToolGroup = null;
        public CogToolBlock II_ToolBlock = null;

        #endregion



        public Main()
        {

            InitializeComponent();
            CAMERA_JobInitialize();
            IOTriggerStart();
            

            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = "COM1";
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);

                serialPort1.Open();

                PF.ExceptionWriter("serialPort1.Open", serialPort1.IsOpen.ToString());
            }

        }



        #region 검사

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
                II_ToolBlock = II_ToolGroup.Tools["CogToolBlock1"] as CogToolBlock;
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
                    cogRecordDisplay_CAMERA1.Zoom = 1.1;
                }));

                


                // Read Error
                if (II_ToolBlock.Outputs["Results_Count1_1"].Value.ToString() == "0" || II_ToolBlock.Outputs["Results_Count1_2"].Value.ToString() == "0")
                {
                    this.Invoke(new Action(delegate ()
                    {
                        listBox1.Items.Insert(0, "[Time] : " + Logtime + "Reading Error");
                        pb1.Image = imageList1.Images[1];
                    }));

                    Task taskOutput = new Task(TaskIOoutput1);
                    taskOutput.Start();
                }
                // Read OK
                else
                {
                    PV.str_Data1_1 = II_ToolBlock.Outputs["Data1_1"].Value.ToString();
                    PV.str_Data1_2 = II_ToolBlock.Outputs["Data1_2"].Value.ToString();

                    this.Invoke(new Action(delegate ()
                    {
                        listBox1.Items.Insert(0, "[Time] : " + Logtime + " Data Matrix 1_1 : " + PV.str_Data1_1 + " / Data Matrix 1_2 : " + PV.str_Data1_2);
                        pb1.Image = imageList1.Images[0];
                    }));

                    SetData();
                }




            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("CAMERA1_UserResultAvailable", ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        private void SetData()
        {
            string strStart = ConvertHex("1B021D10");
            string strEnd = ConvertHex("1B03");
            string strData = PV.str_Data1_1 + PV.str_Data1_2;
            string NullData = "";

            if (strData.Length < 10)
            {
                for (int i = 0; i < 10 - strData.Length; i++)
                    NullData += '\0';
            }

            serialPort1.Write(strStart + '\0' + strData + NullData + strEnd);

        }



        #endregion Camera 1


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
                II_ToolBlock = II_ToolGroup.Tools["CogToolBlock1"] as CogToolBlock;
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
                    cogRecordDisplay_CAMERA2.Zoom = 1.1;
                }));

                PV.str_Data2_1 = II_ToolBlock.Outputs["Data2_1"].Value.ToString();

                if (II_ToolBlock.Outputs["Results_Count"].Value.ToString() == "0")
                {
                    this.Invoke(new Action(delegate ()
                    {
                        pb_2.Image = imageList1.Images[1];
                        listBox2.Items.Insert(0, "[Time] : " + Logtime + " Reading Error");
                    }));

                    Task taskOutput = new Task(TaskIOoutput1);
                    taskOutput.Start();
                }
                else
                {
                    this.Invoke(new Action(delegate ()
                    {
                        listBox2.Items.Insert(0, "[Time] : " + Logtime + " Data Matrix 2 : ");
                    }));

                    if ((PV.str_Data1_1+ PV.str_Data1_2) == PV.str_Data2_1)            // Cam1 DataMatrix & Cam2 Data Matrix 같으면
                    {
                        this.Invoke(new Action(delegate ()
                        {
                            pb_2.Image = imageList1.Images[0];
                            listBox2.Items.Insert(0, "[Time] : " + Logtime + " Result : PASS");
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(delegate ()
                        {
                            pb_2.Image = imageList1.Images[1];
                            listBox2.Items.Insert(0, "[Time] : " + Logtime + " Result : FAIL");
                        }));

                        Task taskOutput = new Task(TaskIOoutput1);
                        taskOutput.Start();
                    }
                }

            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("CAMERA2_UserResultAvailable", ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        #endregion Camera 2

        #endregion

        public void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                string s = sp.ReadExisting();
                string Logtime = PV.lib.getTime("YYMMDD");
                Invoke(new Action(() =>

                listBox1.Items.Insert(0, "[Time] : " + Logtime + " DataReceived : " + AsciiToHex(s))
                ));

                PF.ExceptionWriter("serialPort1_DataReceived", s);
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("serialPort1_DataReceived", ex.ToString());
            }

        }

        #region 이벤트

        private void btn_Start_Click(object sender, EventArgs e)
        {
            btn_Start.Enabled = false;
            btn_Start.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btn_Stop.Enabled = true;

            try
            {
                PV.dio.Init("DIO000", out PV.m_Id);
                PF.IOOutPutMessage("0", "1");

                PV.bIOCheck = true;

                Task task1 = new Task(Task_RunCam1);
                Task task2 = new Task(Task_RunCam2);

                task1.Start();//검사 task
                task2.Start();//검사 task

            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("button_START_Click Exception", ex.Message);
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Start.Enabled = true;
                btn_Start.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
                btn_Stop.Enabled = false;

                PV.bIOCheck = false;

                PV.dio.Init("DIO000", out PV.m_Id);
                PF.IOOutPutMessage("0", "0");      // program STOP
                PV.dio.Exit(0);

                if (serialPort1.IsOpen) serialPort1.Close();
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("button_Stop_Click Exception", ex.Message);
            }


        }




        

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_DateTime.Text = DateTime.Now.ToString("yyyy-MM-dd") + "  " + DateTime.Now.ToString("tt hh:mm:ss");
        }

        private void btn_EXIT_Click(object sender, EventArgs e)
        {
            try
            {
                PV.dio.Init("DIO000", out PV.m_Id);
                PF.IOOutPutMessage("0", "0");      // program STOP
                PF.IOOutPutMessage("1", "0");
                PV.dio.Exit(0);

                PF.ProcessKill("JAVEZ_IVS");
                this.Close();

            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("btn_Exit_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }


        #endregion


        #region JobInitialize / Task


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
                PF.ExceptionWriter("CAMERA_JobInitialize", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void Task_RunCam1()
        {
            while (PV.bIOCheck)
            {
                try
                {
                    if (PF.IOCheck("0") == "1")            // IOCheck 0 = Cam1 trigger
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
                    if (PF.IOCheck("1") == "1")            // IOCheck 0 = Cam1 trigger
                    {
                        PV.InputCheck2 = 1;

                        if ((PV.InputCheck_Old2 == 0) && (PV.InputCheck2 == 1))
                        {
                            CAMERA2_Job.Run();
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
                    return;
                }
            }
            Thread.Sleep(1);
        }

        private void TaskIOoutput1()
        {
            try
            {
                PF.IOOutPutMessage("1", "1");
                PF.Delay(PV.OutputDelay);
                PF.IOOutPutMessage("1", "0");
            }
            catch
            {
                return;
            }
            Thread.Sleep(1);
        }
        #endregion


        #region 기타 (Convert, IO)


        private string AsciiToHex(string ascii)
        {
            string hex = "";
            ascii = ascii.Replace(" ", "");
            int idx = 0;
            char[] arr = ascii.ToArray();
            for (idx = 0; idx < ascii.Length; idx++)
            {
                string asciiVaulesSplit = ascii.Substring(idx, 1);
                int value = arr[idx];
                string hexOutput = String.Format("{0:X}", value);

                hex += hexOutput;
            }

            return hex;
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

        private void button3_Click(object sender, EventArgs e)
        {
            CAMERA2_Job.Run();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CAMERA1_Job.Run();
        }
    }
}
