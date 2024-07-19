using CdioCs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace chsj
{
    public partial class FormWork : Form
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;      // The left button is down.
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;        // The left button is up.

        [DllImport("User32", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [DllImport("User32")]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        private const int SW_SHOWNORMAL = 1;
        private const int SW_MAXIMIZE = 3;
        private const int SW_MINIMIZE = 6;

        FormW_1 formw = new FormW_1();

        #region 변수




        #endregion


        #region IO 출력 변수

        public short m_Id;
        Cdio dio = new Cdio();
        public int[] m_UpCount = new int[8];
        public int[] m_DownCount = new int[8];
        int CAMERA_NG_DelayTime = 0;

        #endregion

        public FormWork()
        {
            InitializeComponent();
            LoadData_LOT(PV.DataPath + "\\Selected_LOT.txt");
            LoadData_Order(PV.DataPath + "\\Selected_Order.txt");
            LoadData_Type(PV.DataPath + "\\Selected_Type.txt");

        }
        public Main MainForm;
        public Form5TypeSet form5;



        #region 로드데이터
        private void FormWork_Load(object sender, EventArgs e)
        {

            try
            {
                LoadData_Worker(PV.DataPath + "\\Selected_Worker.txt");
                LoadData_LOT(PV.DataPath + "\\Selected_LOT.txt");
                LoadData_Order(PV.DataPath + "\\Selected_Order.txt");
                LoadData_Type(PV.DataPath + "\\Selected_Type.txt");


                PV.Length1 = PV.strLT1.Length;
                PV.Length2 = PV.strLT2.Length;
                PV.Length3 = PV.strLT3.Length;
                PV.Length4 = PV.strLT4.Length;
                PV.Length5 = PV.strLT5.Length;
                PV.Length6 = PV.strLT6.Length;
                PV.Length7 = PV.strLT7.Length;
                PV.Length8 = PV.strLT8.Length;


                PF.LogWriter("FormWork_Load", "FormWork_Load");



            }
            catch (Exception ex)
            {
                PF.LogWriter("FormWork_Load", ex.Message);
            }
        }


        private void Task_RunCam1()
        {
            while (PV.bIOCheck)
            {
                try
                {
                    if (PF.IOCheck("0") == "1" || PF.IOCheck("3") == "1")            // cam1 = ng 이거나 cam 2 = ng
                    {
                        PV.InputCheck1 = 1;

                        if ((PV.InputCheck_Old1 == 0) && (PV.InputCheck1 == 1))
                        {
                            this.Invoke(new Action(delegate ()
                            {
                                dataGridView1.Rows.Add("비전 불량", "", "", "", "", "", "", imageList1.Images[1], "");
                                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                            }));
                            RedAlarm();                 //red alarm

                            PF.ScanLogWriter("비전 불량", "", "", "", "", "", "", "NG", "", "");

                        }
                        PF.Delay(PV.DelayTime);
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
                    PF.LogWriter("Task_RunCam1", ex.Message);
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            Thread.Sleep(1);
        }


        private void LoadData_Worker(string fileName)

        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[0]);

                        string strs_SWorker;
                        strs_SWorker = stringArray[0].ToString();

                        PV.Worker = strs_SWorker;
                    }
                }
            }
        }
        private void LoadData_LOT(string fileName)

        {
            try
            {
                using (TextReader tReader = new StreamReader(fileName))
                {
                    string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                    foreach (string stringLine in stringLines)

                    {
                        if (stringLine != string.Empty)
                        {
                            string[] stringArray = stringLine.Split(';');
                            ListViewItem lviary = new ListViewItem(stringArray[0]);

                            string[] strs = new string[2];
                            strs[1] = stringArray[0].ToString();

                            PV.LOT = strs[1];
                        }
                    }
                }
                PF.LogWriter("LoadData_LOT", "LoadData_LOT");
            }
            catch (Exception ex)
            {
                PF.LogWriter("LoadData_LOT", ex.Message);
            }
        }
        private void LoadData_Type(string fileName)
        {

            try
            {
                using (TextReader tReader = new StreamReader(fileName))
                {
                    string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                    foreach (string stringLine in stringLines)

                    {
                        if (stringLine != string.Empty)
                        {
                            string[] stringArray = stringLine.Split(';');
                            ListViewItem lviary = new ListViewItem(stringArray[0]);

                            string[] strs = new string[11];

                            PV.strLT1 = stringArray[0].ToString();      // 차종
                            PV.strLT2 = stringArray[1].ToString();      // 품번
                            PV.strLT3 = stringArray[2].ToString();      // 품명
                            PV.strLT4 = stringArray[3].ToString();      // 고객사
                            PV.strLT5 = stringArray[4].ToString();      // ALC코드
                            PV.strLT6 = stringArray[5].ToString();      // EO NO
                            //strLT7 = stringArray[6].ToString();
                            PV.strLT8 = stringArray[6].ToString();      // 포장단위
                            PV.strLT9 = Convert.ToDouble(stringArray[7]);   // 중량 하한
                            PV.strLT10 = Convert.ToDouble(stringArray[8]);  // 중량 상한
                            PV.bLPCheck = Convert.ToBoolean(stringArray[9]);  // label prt

                            lb_w_LLower.Text = PV.strLT9.ToString();
                            lb_w_LUpper.Text = PV.strLT10.ToString();

                            PV.nEA = Int32.Parse(PV.strLT8);

                        }
                    }
                }
                PF.LogWriter("LoadData_Type", "LoadData_Type");
            }
            catch (Exception ex)
            {
                PF.LogWriter("LoadData_Type", ex.Message);
            }

        }

        private void LoadData_Order(string fileName)
        {

            try
            {
                using (TextReader tReader = new StreamReader(fileName))
                {
                    string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                    foreach (string stringLine in stringLines)

                    {
                        if (stringLine != string.Empty)
                        {
                            string[] stringArray = stringLine.Split(';');
                            ListViewItem lviary = new ListViewItem(stringArray[0]);


                            PV.strLO1 = stringArray[0].ToString();         // 차종
                            PV.strLO2 = stringArray[1].ToString();         // 발주번호
                            PV.strLO3 = stringArray[2].ToString();         // 발주수량
                            PV.strLO4 = stringArray[3].ToString();         // 납기일
                            PV.strLO5 = stringArray[4].ToString();         // 용도
                            PV.strLO6 = stringArray[5].ToString();         // 현재 진행 스캔 수량

                            StringBuilder sb = new StringBuilder();
                            string FilePath = sb.Append(PV.strLO2).Append("_").Append(PV.strLO1).Append("_").Append(PV.strLO5).ToString();
                            string FilePath2 = @"D:\VisionProgram\CsvScanLogPath\" + FilePath + "\\" + FilePath + ".csv";

                            FileInfo fi = new FileInfo(FilePath2);

                            if (fi.Exists == false)
                            {
                                PV.strL07 = "0";
                            }
                            else
                            {
                                using (TextReader tReader1 = new StreamReader(FilePath2))
                                {
                                    int nBox = 0;
                                    string[] stringLines1 = tReader1.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                                    foreach (string stringLine1 in stringLines1)

                                    {
                                        if (stringLine1 != string.Empty && stringLine1.Contains("BOX"))
                                        {
                                            nBox++;

                                        }
                                    }

                                    PV.strL07 = nBox.ToString();
                                }

                            }
                            PV.nOrdered = Int32.Parse(PV.strLO3);
                            PV.nScanned = Int32.Parse(PV.strLO6);
                            PV.nCheckBox = Int32.Parse(PV.strL07);

                            PV.FileNameCsv = PV.strLO2 + "_" + PV.strLO1 + "_" + PV.strLO5;
                        }
                    }
                }
                PF.LogWriter("LoadData_Order", "LoadData_Order");
            }
            catch (Exception ex)
            {
                PF.LogWriter("LoadData_Order", ex.Message);
            }

        }

        public void timer1_Tick(object sender, EventArgs e)
        {

            try
            {

                float nProgressRate;

                tb_w_NoScanned.Text = PV.nScanned.ToString();

                if (PV.strLT9 <= PV.dWeight && PV.dWeight <= PV.strLT10)
                {
                    lb_w_Weight.ForeColor = System.Drawing.Color.LightGreen;
                    lb_w_Weight.Text = PV.dWeight.ToString();

                }
                else
                {
                    lb_w_Weight.ForeColor = System.Drawing.Color.Red;
                    lb_w_Weight.Text = PV.dWeight.ToString();
                }


                if (PV.nScanned != 0)
                {
                    PV.nBox = PV.nScanned / PV.nEA;
                    nProgressRate = (PV.nScanned * 100) / PV.nOrdered;
                }
                else
                {
                    PV.nBox = 0;
                    nProgressRate = 0;
                }
                tb_w_NoBox.Text = PV.nBox.ToString();
                tb_w_ProgressRate.Text = nProgressRate.ToString() + " %";
            }
            catch (Exception ex)
            {
                PF.LogWriter("timer1_Tick", ex.Message);
            }


        }
        #endregion


        #region 웹브라우저
        private void wb_w_1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                //wb_w_1.Navigate(new Uri("http://192.168.1.12:8088/"));
                //PF.LogWriter("wb_w_1_DocumentCompleted", "wb_w_1_DocumentCompleted");
                //lb_w_connectCAM1.BackColor = System.Drawing.Color.Lime;
            }
            catch (Exception ex)
            {
                PF.LogWriter("wb_w_1_DocumentCompleted", ex.Message);
            }
        }

        private void wb_w_2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {

                //wb_w_2.Navigate(new Uri("http://192.168.1.13:8087/"));
                //PF.LogWriter("wb_w_2_DocumentCompleted", "wb_w_2_DocumentCompleted");
                //lb_w_connectCAM2.BackColor = System.Drawing.Color.Lime;
            }
            catch (Exception ex)
            {
                PF.LogWriter("wb_w_2_DocumentCompleted", ex.Message);
            }
        }

        #endregion

        public void ChkStart()
        {
            try
            {
                PV.bIOCheck = true;
                PF.IOOutPutMessage("1", "0");           // 노란불 off
                richTextBox1.Clear();

                LoadData_LOT(PV.DataPath + "\\Selected_LOT.txt");
                LoadData_Order(PV.DataPath + "\\Selected_Order.txt");
                LoadData_Type(PV.DataPath + "\\Selected_Type.txt");

                if (PV.nScanned == 0 && PV.nCheckBox == 0)
                {
                    CheckBoxScan();
                }

                if (PV.nScanned >= PV.nOrdered)
                {
                    MessageBox.Show("발주량 스캔 완료", "스캔 완료", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                dataGridView1.Rows.Clear();

                using (TextReader tReader = new StreamReader(PV.CsvScanLogFile + PV.FileNameCsv + "\\" + PV.FileNameCsv + ".csv", Encoding.Default))
                {
                    string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                    foreach (string stringLine in stringLines)

                    {
                        if (stringLine != string.Empty)
                        {

                            string[] stringArray = stringLine.Split(',');

                            if (stringArray[8] == "NG")
                            {
                                dataGridView1.Rows.Add(stringArray[1], stringArray[2], stringArray[3], stringArray[4], stringArray[5], stringArray[6], stringArray[7], imageList1.Images[1], stringArray[9]);
                            }
                            else if (stringArray[8] == "OK")
                            {
                                dataGridView1.Rows.Add(stringArray[1], stringArray[2], stringArray[3], stringArray[4], stringArray[5], stringArray[6], stringArray[7], imageList1.Images[0], stringArray[9]);
                            }
                            else
                            {
                                dataGridView1.Rows.Add(stringArray[1], stringArray[2], stringArray[3], stringArray[4], stringArray[5], stringArray[6], stringArray[7], imageList1.Images[2], stringArray[9]);
                            }


                        }
                    }
                }

                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                Task taskCam1 = new Task(Task_RunCam1);
                taskCam1.Start();


                // 스캐너
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = "COM6";
                    serialPort1.BaudRate = 9600;
                    serialPort1.DataBits = 8;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Parity = Parity.None;

                    serialPort1.Open();
                }

                // 중량
                if (!serialPort2.IsOpen)
                {

                    serialPort2.PortName = "COM7";
                    serialPort2.BaudRate = 9600;
                    serialPort2.DataBits = 8;
                    serialPort2.StopBits = StopBits.One;
                    serialPort2.Parity = Parity.None;

                    serialPort2.Open();

                }

                // 라벨
                //if (!serialPort3.IsOpen)
                //{

                //    serialPort3.PortName = "COM1";
                //    serialPort3.BaudRate = 9600;
                //    serialPort3.DataBits = 8;
                //    serialPort3.StopBits = StopBits.One;
                //    serialPort3.Parity = Parity.None;

                //    serialPort3.Open();

                //}

                if (PV.bCamCheck)
                {
                    wb_w_1.Navigate(new Uri("http://192.168.1.12:8088/")); // cam1
                    //wb_w_2.Navigate(new Uri("http://192.168.1.13:8087/"));


                }
                PF.LogWriter("button_START_Click", "button_START_Click");

            }
            catch (Exception ex)
            {
                PF.LogWriter("button_START_Click Exception", ex.Message);
            }

        }

        public void ChkStop()
        {
            try
            {
                PF.IOOutPutMessage("1", "1");
                PV.bIOCheck = false;
                dataGridView1.Rows.Clear();

                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                if (formw.serialPort1.IsOpen)
                {
                    formw.serialPort1.Close();
                }

                if (serialPort2.IsOpen)
                {
                    serialPort2.Close();
                }

                //if (serialPort3.IsOpen)
                //{
                //    serialPort3.Close();
                //}
                if (PV.bCamCheck)
                {
                    wb_w_1.Stop();
                    //wb_w_2.Stop();
                }


                PF.LogWriter("button_STOP_Click", "button_STOP_Click");
            }
            catch (Exception ex)
            {
                PF.LogWriter("button_STOP_Click Exception", ex.Message);
            }
        }




        #region 함수
        private void CheckBoxScan()
        {
            try
            {
                FormW_1 formW1 = new FormW_1();
                formW1.formwork = this;
                formW1.ShowDialog();
            }
            catch (Exception ex)
            {
                PF.LogWriter("CheckBoxScan", ex.Message);
            }

        }

        public void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Invoke(new Action(() => tb.Clear()));
            SerialPort sp = (SerialPort)sender;
            string s = sp.ReadExisting();
            Invoke(new Action(() => tb.Text = s));

            PF.LogWriter("serialPort1_DataReceived", "serialPort1_DataReceived");
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            PV.Length1 = PV.strLT1.Length;
            PV.Length2 = PV.strLT2.Length;
            PV.Length3 = PV.strLT3.Length;
            PV.Length4 = PV.strLT4.Length;
            PV.Length5 = PV.strLT5.Length;
            PV.Length6 = PV.strLT6.Length;
            PV.Length7 = PV.strLT7.Length;
            PV.Length8 = PV.strLT8.Length;


            PV.GetCode = tb.Text;

            Int32 rows = dataGridView1.Rows.Count;

            for (int i = 0; i < rows; i++)
            {
                string value = dataGridView1.Rows[i].Cells[8].FormattedValue.ToString();

                if (value == PV.GetCode && PV.GetCode != "")
                {
                    RedAlarm();
                    MessageBox.Show("중복되는 바코드가 읽혔습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    tb.Clear();
                    return;
                }
            }

            try
            {
                if (PV.GetCode.Substring(0, 2) == "KL")
                {
                    PV.GetCode = PV.GetCode.Replace("\r\n", "").Replace("\n", "");
                }
                if (PV.GetCode.Length > 8)
                {
                    if (PV.GetCode.Substring(0, 6) == "[)>06")
                    {
                        if (PV.nCheckBox != PV.nBox + 1)
                        {
                            RedAlarm();
                            MessageBox.Show("박스를 스캔 할 순서입니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            tb.Clear();

                            return;
                        }
                        else
                        {
                            SetStrCodes(PV.GetCode);
                        }


                    }
                    else
                    {

                        if (PV.GetCode.Substring(0, 1) == "J")
                        {
                            if (PV.nBox != 0 && PV.nScanned % PV.nEA == 0)
                            {
                                if (PV.GetCode.Substring(PV.GetCode.Length - PV.strLT6.Length-2, PV.strLT6.Length) == PV.strLT6)
                                {
                                    if (PV.nCheckBox == PV.nBox)
                                    {

                                        PF.ScanLogWriter(PV.GetCode, "박스 스캔", "", "", "", "", "", "", "BOX", "");
                                        dataGridView1.Rows.Add("박스 스캔", "", "", "", "", "", "", imageList1.Images[2], PV.GetCode);
                                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                                        PV.nCheckBox = PV.nCheckBox + 1;
                                        SaveNScanned();
                                        tb.Clear();
                                        return;
                                    }
                                    else
                                    {
                                        RedAlarm();
                                        MessageBox.Show("박스 스캔 순서가 아닙니다", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                        tb.Clear();
                                        return;
                                    }

                                }
                                else
                                {
                                    RedAlarm();
                                    MessageBox.Show("잘못된 박스 바코드입니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    tb.Clear();
                                    return;
                                }
                            }
                            else
                            {
                                RedAlarm();
                                MessageBox.Show("박스 스캔 순서가 아닙니다", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                tb.Clear();
                                return;
                            }
                        }
                        else if ((PV.strLT1 == "NX4"))
                        {

                            // 
                            if (PV.GetCode.Substring(0, 3) == PV.strLT1)
                            {
                                PF.ScanLogWriter(PV.GetCode, PV.dWeight.ToString(), "", "", "", "", "", "OK", tb.Text, "");
                                PV.nScanned = PV.nScanned + 1;
                                SaveNScanned();
                                dataGridView1.Rows.Add(PV.GetCode, PV.dWeight.ToString(), "", "", "", "", "", imageList1.Images[0], tb.Text);
                                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;


                                if (PV.nScanned % PV.nEA == 0)
                                {
                                    if (PV.nScanned >= PV.nOrdered)
                                    {

                                        MessageBox.Show("발주량 스캔 완료");
                                        PF.ScanLogWriter("발주량 스캔 완료", "", "", "", "", "", "", "", "", "");
                                        PF.LogWriter(PV.FileNameCsv, "발주량 스캔 완료");
                                        tb.Clear();
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("박스를 스캔하세요", "박스를 스캔하세요", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        tb.Clear();
                                        return;


                                    }
                                }
                                tb.Clear();
                                return;
                            }
                            //ng
                            else
                            {
                                RedAlarm();
                                dataGridView1.Rows.Add(PV.GetCode, PV.dWeight.ToString(), "", "", "", "", "", imageList1.Images[1], PV.GetCode);
                                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                                PF.ScanLogWriter(PV.GetCode, PV.dWeight.ToString(), "", "", "", "", "", "NG", PV.GetCode, "");
                            }

                            tb.Clear();
                            return;
                        }
                        else if ((PV.strLT1 == "NX4e"))
                        {

                            // 
                            if (PV.GetCode.Substring(0, 3) == "NX4")
                            {
                                PF.ScanLogWriter(PV.GetCode, PV.dWeight.ToString(), "", "", "", "", "", "OK", tb.Text, "");
                                PV.nScanned = PV.nScanned + 1;
                                SaveNScanned();
                                dataGridView1.Rows.Add(PV.GetCode, PV.dWeight.ToString(), "", "", "", "", "", imageList1.Images[0], tb.Text);
                                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;


                                if (PV.nScanned % PV.nEA == 0)
                                {
                                    if (PV.nScanned >= PV.nOrdered)
                                    {

                                        MessageBox.Show("발주량 스캔 완료");
                                        PF.ScanLogWriter("발주량 스캔 완료", "", "", "", "", "", "", "", "", "");
                                        PF.LogWriter(PV.FileNameCsv, "발주량 스캔 완료");
                                        tb.Clear();
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("박스를 스캔하세요", "박스를 스캔하세요", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        tb.Clear();
                                        return;


                                    }
                                }
                                tb.Clear();
                                return;
                            }
                            //ng
                            else
                            {
                                RedAlarm();
                                dataGridView1.Rows.Add(PV.GetCode, PV.dWeight.ToString(), "", "", "", "", "", imageList1.Images[1], PV.GetCode);
                                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                                PF.ScanLogWriter(PV.GetCode, PV.dWeight.ToString(), "", "", "", "", "", "NG", PV.GetCode, "");
                            }

                            tb.Clear();
                            return;
                        }
                        else
                        {
                        }
                    }
                }
                else
                {
                    return;

                }

                if (!PV.bLPCheck)
                {

                    if (PV.StrCode1.Equals(PV.strLT2) && PV.StrCode2.Equals(PV.strLT3) && PV.StrCode3.Equals(PV.strLT5) && PV.StrCode4.Equals(PV.strLT6))
                    {

                        PF.ScanLogWriter(PV.StrCode1, PV.dWeight.ToString(), PV.StrCode2, PV.StrCode2, PV.StrCode4, PV.StrCode5, PV.StrCode8, "OK", tb.Text, "");
                        PV.nScanned = PV.nScanned + 1;
                        SaveNScanned();
                        dataGridView1.Rows.Add(PV.StrCode1, PV.dWeight.ToString(), PV.StrCode2, PV.StrCode2, PV.StrCode4, PV.StrCode5, PV.StrCode8, imageList1.Images[0], tb.Text);
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;


                        if (PV.nScanned % PV.nEA == 0)
                        {
                            if (PV.nScanned >= PV.nOrdered)
                            {

                                MessageBox.Show("발주량 스캔 완료");
                                PF.ScanLogWriter("발주량 스캔 완료", "", "", "", "", "", "", "", "", "");
                                PF.LogWriter(PV.FileNameCsv, "발주량 스캔 완료");
                                tb.Clear();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("박스를 스캔하세요", "박스를 스캔하세요", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                tb.Clear();
                                return;


                            }
                        }
                        tb.Clear();
                        return;
                    }
                    else
                    {
                        RedAlarm();
                        dataGridView1.Rows.Add(PV.StrCode1, PV.dWeight.ToString(), PV.StrCode2, PV.StrCode3, PV.StrCode4, PV.StrCode5, PV.StrCode8, imageList1.Images[1], tb.Text);
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                        PF.ScanLogWriter(PV.StrCode1, PV.dWeight.ToString(), PV.StrCode2, PV.StrCode2, PV.StrCode4, PV.StrCode5, PV.StrCode8, "NG", tb.Text, "");
                    }
                    tb.Clear();
                    return;
                }
                else
                {
                    if (PV.GetCode.Substring(0, 2) == "KL")
                    {
                        PF.ScanLogWriter(PV.GetCode.Replace("\r\n", "").Replace("\n", ""), PV.dWeight.ToString(), "", "", "", "", "", "OK", tb.Text.Replace("\r\n", "").Replace("\n", ""), "");
                        PV.nScanned = PV.nScanned + 1;
                        SaveNScanned();
                        dataGridView1.Rows.Add(PV.GetCode.Replace("\r\n", "").Replace("\n", ""), PV.dWeight.ToString(), "", "", "", "", "", imageList1.Images[0], tb.Text.Replace("\r\n", "").Replace("\n", ""));
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;


                        if (PV.nScanned % PV.nEA == 0)
                        {
                            if (PV.nScanned >= PV.nOrdered)
                            {

                                MessageBox.Show("발주량 스캔 완료");
                                PF.ScanLogWriter("발주량 스캔 완료", "", "", "", "", "", "", "", "", "");
                                PF.LogWriter(PV.FileNameCsv, "발주량 스캔 완료");
                                tb.Clear();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("박스를 스캔하세요", "박스를 스캔하세요", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                tb.Clear();
                                return;


                            }
                        }
                        tb.Clear();
                        return;
                    }
                    //ng
                    else
                    {
                        RedAlarm();
                        dataGridView1.Rows.Add(PV.GetCode.Replace("\r\n", "").Replace("\n", ""), PV.dWeight.ToString(), "", "", "", "", "", imageList1.Images[1], tb.Text.Replace("\r\n", "").Replace("\n", ""));
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                        PF.ScanLogWriter(PV.GetCode.Replace("\r\n", "").Replace("\n", ""), PV.dWeight.ToString(), "", "", "", "", "", "NG", tb.Text.Replace("\r\n", "").Replace("\n", ""), "");
                    }
                }
            }
            catch (Exception ex)
            {
                PF.LogWriter("tb_TextChanged Exception", ex.Message);
            }
            return;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            try
            {
                DataGridView grid = sender as DataGridView;
                //String rowIdx = (e.RowIndex + 1).ToString("X4");
                String rowIdx = (e.RowIndex + 1).ToString();

                StringFormat centerFormat = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top,
                                                        grid.RowHeadersWidth, e.RowBounds.Height);
                e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText,
                                      headerBounds, centerFormat);
            }

            catch (Exception ex)
            {
                PF.LogWriter("dataGridView1_RowPostPaint", ex.Message);
            }




        }

        void SetDataFromCsv(string GetCode, string PassNoPass)
        {
            try
            {
                string[] words = GetCode.Split('');

                if (GetCode.Substring(0, 6) == "[)>06")
                {
                    SetStrCodes(GetCode);

                    if (PV.StrCode1.Equals(PV.strLT4) && PV.StrCode2.Equals(PV.strLT2) && PV.StrCode3.Equals(PV.strLT5) && PV.StrCode4.Equals(PV.strLT6))
                    {
                        dataGridView1.Rows.Add(PV.StrCode1, PV.dWeight.ToString(), PV.StrCode2, PV.StrCode3, PV.StrCode4, PV.StrCode5, PV.StrCode8, imageList1.Images[0], GetCode);
                    }
                    else
                    {
                        dataGridView1.Rows.Add(PV.StrCode1, PV.dWeight.ToString(), PV.StrCode2, PV.StrCode3, PV.StrCode4, PV.StrCode5, PV.StrCode8, imageList1.Images[1], GetCode);
                    }
                }
                else
                {
                    dataGridView1.Rows.Add("박스 스캔", "", "", "", imageList1.Images[2], GetCode);
                }
            }
            catch (Exception ex)
            {
                PF.LogWriter("SetDataFromCsv Exception", ex.Message);
            }
        }

        void CheckLabelPrint()
        {
            MessageBox.Show("라벨을 프린트하세요", "라벨 프린트", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Process[] processes = Process.GetProcesses();
            foreach (Process proc in processes)
            {
                if (proc.ProcessName.Equals("GoLabel"))
                {
                    IntPtr procHandler = FindWindow(null, proc.MainWindowTitle);
                    ShowWindow(procHandler, SW_MAXIMIZE);
                    SetForegroundWindow(procHandler);
                    Cursor.Position = new Point(702, 86);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    PF.Delay(3000);
                    ShowWindow(procHandler, SW_MINIMIZE);

                    return;
                }
            }

            //this.WindowState = FormWindowState.Minimized;
        }
        void SetStrCodes(string GetCode)
        {

            try
            {
                if (GetCode.Length > 8)
                {
                    int length = GetCode.Length - 7;
                    GetCode = GetCode.Substring(7, length);

                    string[] words = GetCode.Split('');

                    PV.StrCode1 = words[0].Substring(1, words[0].Length - 1);         // 업체코드 4 Byte
                    PV.StrCode2 = words[1].Substring(1, words[1].Length - 1);         // 품번 10~15 Byte
                    PV.StrCode3 = words[2].Substring(1, words[2].Length - 1);         // ACL코드 1~8 Byte
                    PV.StrCode4 = words[3].Substring(1, words[3].Length - 1);         // EO NO 8~9 Byte
                    PV.StrCode5 = words[4].Substring(1, words[4].Length - 1);         // LOT NO 14~36 Byte
                    PV.StrCode6 = words[5].Substring(1, words[5].Length - 1);
                    PV.StrCode7 = words[6].Substring(1, words[6].Length - 1);
                    PV.StrCode8 = words[7].Substring(1, words[7].Length - 1);         // 업체영역


                }
                else
                {
                    PV.StrCode1 = "";
                    PV.StrCode2 = "";
                    PV.StrCode3 = "";
                    PV.StrCode4 = "";
                    PV.StrCode5 = "";
                    PV.StrCode8 = "";
                }


            }
            catch (Exception ex)
            {
                PF.LogWriter("SetStrCodes", ex.Message);
            }


        }

        void SaveNScanned()
        {
            using (TextWriter tWriter = new StreamWriter((PV.DataPath + "\\Selected_Order.txt")))
            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4};{5};{6}", PV.strLO1, PV.strLO2, PV.strLO3, PV.strLO4, PV.strLO5, PV.nScanned, PV.nCheckBox));
            }
        }



        #endregion


        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
        }
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
        public void RedAlarm()
        {
            PF.IOOutPutMessage("2", "1");
            PF.Delay(500);
            PF.IOOutPutMessage("2", "0");
        }



        public void WeightNG()
        {

            PF.ScanLogWriter("중량 불량", PV.dWeight.ToString(), "", "", "", "", "", "NG", "", "");
            dataGridView1.Rows.Add("중량 불량", PV.dWeight.ToString(), "", "", "", "", "", imageList1.Images[1], "");
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;

        }
        public void Box()
        {
            this.Invoke(new Action(delegate ()
            {
                dataGridView1.Rows.Add("박스 스캔", "", "", "", "", "", "", imageList1.Images[2], PV.GetCode);
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
            }));
        }

        private void serialPort2_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                string s = sp.ReadExisting();
                string ss = s.Substring(0, s.Length).Replace(" ", "");

                if ((ss != "") && (s != "\n") && (s != "\r\n"))
                {
                    this.Invoke(new Action(delegate ()
                    {
                        richTextBox1.Text = s;
                        PV.dWeight = Convert.ToDouble(s.Substring(0, s.Length).Replace(" ", ""));
                    }));
                }

                if (PV.dWeight == 0)
                {
                    return;
                }

                // 중량 OK
                if (PV.strLT9 <= PV.dWeight && PV.dWeight <= PV.strLT10)
                {

                    if (!PV.bLPCheck)
                    {

                        PF.IOOutPutMessage("15", "1");      // 레이저
                        PF.Delay(500);
                        PF.IOOutPutMessage("15", "0");

                        if (PV.bCamCheck)
                        {
                            PF.Delay(27000);
                            PF.IOOutPutMessage("3", "1");           // 카메라 트리거
                            PF.IOOutPutMessage("4", "1");
                            PF.Delay(500);
                            PF.IOOutPutMessage("3", "0");
                            PF.IOOutPutMessage("4", "0");
                        }
                    }
                    else
                    {
                        CheckLabelPrint();
                        if (PV.bCamCheck)
                        {
                            PF.IOOutPutMessage("3", "1");           // 카메라 트리거
                            PF.IOOutPutMessage("4", "1");
                            PF.Delay(500);
                            PF.IOOutPutMessage("3", "0");
                            PF.IOOutPutMessage("4", "0");
                        }
                    }

                }
                // 중량 NG
                else
                {
                    RedAlarm();

                    PF.ScanLogWriter("중량 불량", PV.dWeight.ToString(), "", "", "", "", "", "NG", "", "");
                    dataGridView1.Rows.Add("중량 불량", PV.dWeight.ToString(), "", "", "", "", "", imageList1.Images[1], "");
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;


                }

            }
            catch (Exception ex)
            {
                PF.LogWriter("serialPort2_DataReceived", ex.ToString());
            }
        }
    }
}




