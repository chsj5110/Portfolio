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
        string ListViewFile = @"D:\VisionProgram\";
        //@"D:\VisionProgram\";
        
        //string CsvLogFile = @"D:\InspectionLogPath\";
        string CsvLogFile = @"D:\VisionProgram\InspectionLogPath\";
        string CsvScanLogFile = @"D:\VisionProgram\CsvScanLogPath\";

        public SerialPort mySerialPort = new SerialPort("COM4");

        //변수 선언
        string StrCode1 = "";
        string StrCode2 = "";
        string StrCode3 = "";
        string StrCode4 = "";
        string StrCode5 = "";
        string StrCode6 = "";
        string StrCode7 = "";
        string StrCode8 = "";

        string strMonth = DateTime.Now.Month.ToString();
        string strDay = DateTime.Now.Day.ToString();
        string strHour = DateTime.Now.Hour.ToString();
        string strMinute = DateTime.Now.Minute.ToString();
        string strSecond = DateTime.Now.Second.ToString();
        string strMilSecond = DateTime.Now.Millisecond.ToString();
        

        public int nScanned;            ////스캔 된 수량
        int nEA = 0;                    // 포장 단위
        int nOrdered = 0;               // 발주 수량
        public int nCheckBox = 0;
        int nBox;

        int Tick = 0;

        Timer time1r = new System.Windows.Forms.Timer();
        
        string strLT1 = "";                 //차종
        public string strLT2 = "";                 //품번
        string strLT3 = "";                 //품명
        string strLT4 = "";                 //업체코드
        string strLT5 = "";                 //ALC 코드
        string strLT6 = "";                 //EO 넘버
        string strLT7 = "";                 //LOT 넘버
        string strLT8 = "";                 //포장단위

        string strLO1 = "";
        string strLO2 = "";
        string strLO3 = "";
        string strLO4 = "";
        string strLO5 = "";
        string strLO6 = "";
        string strL07 = "";

        string GetCode;

        int Length1 = 0;
        int Length2 = 0;
        int Length3 = 0;
        int Length4 = 0;
        int Length5 = 0;
        int Length6 = 0;
        int Length7 = 0;
        int Length8 = 0;

        Image Pass = Properties.Resources.pass;
        Image NPass = Properties.Resources.nonpass;
        Image Box = Properties.Resources.box;

        string FileNameCsv;
        string LOT;
        string Worker;

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
            LoadData_LOT(ListViewFile + "\\Selected_LOT.txt");
            LoadData_Order(ListViewFile + "\\Selected_Order.txt");
            LoadData_Type(ListViewFile + "\\Selected_Type.txt");

            button_STOP.Enabled = false;
            

        }
        public Main MainForm;
        public Form5TypeSet form5;


        #region 로그
        public void ScanLogWriter(string Barcode, string Message, string PnP)
        {
            try
            {

                if (strMonth.Length == 1)
                    strMonth = "0" + strMonth;

                if (strDay.Length == 1)
                    strDay = "0" + strDay;

                string Time = DateTime.Now.Year + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMinute + ":" + strSecond + "-" + strMilSecond;

                string Path = CsvScanLogFile  + FileNameCsv + "\\";
                string CreateFileName = FileNameCsv + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("Time");
                    row.Add("Barcode");
                    row.Add("Message");
                    row.Add("Pass / No Pass");

                    row.Add("\r\n" + Time);
                    row.Add(Barcode);
                    row.Add(Message);
                    row.Add(PnP);
                }
                else
                {
                    row.Add(Time);
                    row.Add(Barcode);
                    row.Add(Message);
                    row.Add(PnP);
                }

                writer.WriteCSV(row, Path + CreateFileName);


            }
            catch (Exception ex)
            {
                LogWriter("ScanLogWriter", ex.Message);
            }
        }

        public void LogWriter(string LogLocation, string LogMessage)
        {
            try
            {

                if (strMonth.Length == 1)
                    strMonth = "0" + strMonth;

                if (strDay.Length == 1)
                    strDay = "0" + strDay;

                string Time = DateTime.Now.Year + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMinute + ":" + strSecond + "-" + strMilSecond;

                string Path = CsvLogFile + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("Time");
                    row.Add("LogLocation");
                    row.Add("Message");

                    row.Add("\r\n" + Time);
                    row.Add(LogLocation);
                    row.Add(LogMessage);
                }
                else
                {
                    row.Add(Time);
                    row.Add(LogLocation);
                    row.Add(LogMessage);
                }

                writer.WriteCSV(row, Path + CreateFileName);


                /*
                Txt_Log.Clear();
                string[] readText = File.ReadAllLines(Path + CreateFileName, Encoding.GetEncoding(949));


                foreach (string s in readText)
                {
                    Txt_Log.Text = s + "\r\n" + Txt_Log.Text;
                }

                */

            }
            catch (Exception ex)
            {
                LogWriter("LogWriter", ex.Message);
            }
        }
        #endregion


        #region 프로세스 및 로드데이터
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

        private void FormWork_Load(object sender, EventArgs e)
        {

            try
            {
                LoadData_Worker(ListViewFile + "\\Selected_Worker.txt");
                LoadData_LOT(MainForm.ListViewFile + "\\Selected_LOT.txt");
                LoadData_Order(ListViewFile + "\\Selected_Order.txt");
                LoadData_Type(ListViewFile + "\\Selected_Type.txt");

                //MessageBox.Show(strLT1 + strLT2 + strLT3);

                //string strLT1 = "";                 //차종
                //string strLT2 = "";                 //품번
                // string strLT3 = "";                 //품명
                //string strLT4 = "";                 //업체코드
                //string strLT5 = "";                 //ALC 코드
                //string strLT6 = "";                 //EO 넘버
                //string strLT7 = "";                 //LOT 넘버
                //string strLT8 = "";                 //포장단위

                Length1 = strLT1.Length;
                Length2 = strLT2.Length;
                Length3 = strLT3.Length;
                Length4 = strLT4.Length;
                Length5 = strLT5.Length;
                Length6 = strLT6.Length;
                Length7 = strLT7.Length;
                Length8 = strLT8.Length;

                richTextBox1.Text = "차종 : " + strLT1 + "\r"
                                    + "품번 : " + strLT2 + "\r"
                                    + "품명 : " + strLT3 + "\r"
                                    + "업체코드 : " + strLT4 + "\r"
                                    + "ALC코드 : " + strLT5 + "\r"
                                    + "EO NO : " + strLT6 + "\r"
                                    + "LOT NO : " + LOT + "\r"
                                    + "포장단위 : " + strLT8 + "EA";

                LogWriter("FormWork_Load", "FormWork_Load");
            }
            catch (Exception ex)
            {
                LogWriter("FormWork_Load", ex.Message);
            }
            
            
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

                        Worker = strs_SWorker;
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

                            LOT = strs[1];
                        }
                    }
                }
                LogWriter("LoadData_LOT", "LoadData_LOT");
            }
            catch (Exception ex)
            {
                LogWriter("LoadData_LOT", ex.Message);
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

                            string[] strs = new string[8];

                            strLT1 = stringArray[0].ToString();
                            strLT2 = stringArray[1].ToString();
                            strLT3 = stringArray[2].ToString();
                            strLT4 = stringArray[3].ToString();
                            strLT5 = stringArray[4].ToString();
                            strLT6 = stringArray[5].ToString();
                            //strLT7 = stringArray[6].ToString();
                            strLT8 = stringArray[6].ToString();

                            nEA = Int32.Parse(strLT8);

                        }
                    }
                }
                LogWriter("LoadData_Type", "LoadData_Type");
            }
            catch (Exception ex)
            {
                LogWriter("LoadData_Type", ex.Message);
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


                            strLO1 = stringArray[0].ToString();         // 차종
                            strLO2 = stringArray[1].ToString();         // 발주번호
                            strLO3 = stringArray[2].ToString();         // 발주수량
                            strLO4 = stringArray[3].ToString();         // 납기일
                            strLO5 = stringArray[4].ToString();         // 용도
                            strLO6 = stringArray[5].ToString();         // 현재 진행 스캔 수량
                            strL07 = stringArray[6].ToString();


                            nOrdered = Int32.Parse(strLO3);
                            nScanned = Int32.Parse(strLO6);
                            nCheckBox = Int32.Parse(strL07);

                            lb_w_Order.Text = strLO1 + " / " + strLO3 + " / " + strLO4 + " / " + strLO5 + " / 작업자 : " + Worker;

                            FileNameCsv = strLO2 + "_" + strLO1 + "_" + strLO5 +"_" + LOT;
                        }
                    }
                }
                LogWriter("LoadData_Order", "LoadData_Order");
            }
            catch (Exception ex)
            {
                LogWriter("LoadData_Order", ex.Message);
            }

        }

        public void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                tb_w_NoScanned.Text = nScanned.ToString();
                
                
                float nProgressRate;

                if (nScanned != 0)
                {
                    nBox = nScanned / nEA;
                    nProgressRate = (nScanned * 100) / nOrdered;
                }
                else
                {
                    nBox = 0;
                    nProgressRate = 0;
                }
                tb_w_NoBox.Text = nBox.ToString();
                tb_w_ProgressRate.Text = nProgressRate.ToString() + " %";
            }
            catch (Exception ex)
            {
                LogWriter("timer1_Tick", ex.Message);
            }
            

        }
        #endregion


        #region 웹브라우저
        private void wb_w_1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                //wb_w_1.Navigate(new Uri("http://192.168.1.22:8087/"));
                LogWriter("wb_w_1_DocumentCompleted", "wb_w_1_DocumentCompleted");
                //lb_w_connectCAM1.BackColor = System.Drawing.Color.Lime;
            }
            catch (Exception ex)
            {
                LogWriter("wb_w_1_DocumentCompleted", ex.Message);
            }
        }

        private void wb_w_2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {

                //wb_w_2.Navigate(new Uri("http://192.168.1.22:8088/"));
                LogWriter("wb_w_2_DocumentCompleted", "wb_w_2_DocumentCompleted");
                //lb_w_connectCAM2.BackColor = System.Drawing.Color.Lime;
            }
            catch (Exception ex)
            {
                LogWriter("wb_w_2_DocumentCompleted", ex.Message);
            }
        }

        #endregion


        #region 버튼 이벤트
        private void button_START_Click(object sender, EventArgs e)
        {
            button_START.Enabled = false;
            button_STOP.Enabled = true;
            
            try
            {

                if (nScanned == 0)
                {
                    CheckBoxScan();
                }

                if (nScanned >= nOrdered)
                {
                    MessageBox.Show("발주량 스캔 완료", "스캔 완료", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = "COM4";                          
                    serialPort1.BaudRate = 9600;
                    serialPort1.DataBits = 8;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Parity = Parity.None;
                    serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);

                    serialPort1.Open();
                    
                }

                //lb_w_connectBARCODE.BackColor = System.Drawing.Color.Lime;

                wb_w_1.Navigate(new Uri("http://192.168.1.20:8088/")); // cam1
                wb_w_2.Navigate(new Uri("http://192.168.1.22:8087/"));


                //=============
                dataGridView1.Rows.Clear();
                using (TextReader tReader = new StreamReader(CsvScanLogFile + FileNameCsv + "\\" + FileNameCsv + ".csv"))
                {
                    string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                    foreach (string stringLine in stringLines)

                    {
                        if (stringLine != string.Empty)
                        {
                            string[] stringArray = stringLine.Split(',');

                            if (stringLine.Substring(0, 1) != "T")
                            {
                                GetCode = stringArray[1];

                                SetDataFromCsv(GetCode, stringArray[3].ToString());
                            }

                        }
                    }
                }

                

                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;

                //==============

                LogWriter("button_START_Click", "button_START_Click");


            }
            catch (Exception ex)
            {
                LogWriter("button_START_Click Exception", ex.Message);
            }
        }
        
        private void button_STOP_Click(object sender, EventArgs e)
        {
            button_STOP.Enabled = false;
            button_START.Enabled = true;
            try
            {
                dataGridView1.Rows.Clear();

                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                if (formw.serialPort1.IsOpen)
                {
                    formw.serialPort1.Close();
                }

                wb_w_1.Stop();
                wb_w_2.Stop();

                //lb_w_connectCAM1.BackColor = System.Drawing.Color.Red;
                //lb_w_connectCAM2.BackColor = System.Drawing.Color.Red;
                //lb_w_connectBARCODE.BackColor = System.Drawing.Color.Red;

                //Button_disconnect_Click(sender, e);

                LogWriter("button_STOP_Click", "button_STOP_Click");
            }
            catch (Exception ex)
            {
                LogWriter("button_STOP_Click Exception", ex.Message);
            }



        }

        private void button_EXIT_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                if (formw.serialPort1.IsOpen)
                {
                    formw.serialPort1.Close();
                }
                
                //ProcessKill("BARCODE_IVS");
                this.Close();
                LogWriter("button_EXIT_Click", "button_EXIT_Click");
            }
            catch (Exception ex)
            {
                LogWriter("button_EXIT_Click", ex.Message);
            }
        }
        
        #endregion


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
                LogWriter("CheckBoxScan", ex.Message);
            }

        }
        



        public void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Invoke(new Action(() => tb.Clear()));
            SerialPort sp = (SerialPort)sender;
            string s = sp.ReadExisting();
            Invoke(new Action(() => tb.Text = s));

            LogWriter("serialPort1_DataReceived", "serialPort1_DataReceived");
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            //string strLT1 = "";                 //차종
            //string strLT2 = "";                 //품번
            // string strLT3 = "";                 //품명
            //string strLT4 = "";                 //업체코드
            //string strLT5 = "";                 //ALC 코드
            //string strLT6 = "";                 //EO 넘버
            //string strLT7 = "";                 //LOT 넘버
            //string strLT8 = "";                 //포장단위

            Length1 = strLT1.Length;
            Length2 = strLT2.Length;
            Length3 = strLT3.Length;
            Length4 = strLT4.Length;
            Length5 = strLT5.Length;
            Length6 = strLT6.Length;
            Length7 = strLT7.Length;
            Length8 = strLT8.Length;


            GetCode = tb.Text;

            //CheckOverCodes(GetCode);

            Int32 rows = dataGridView1.Rows.Count;

            for (int i = 0; i < rows; i++)
            {
                string value = dataGridView1.Rows[i].Cells[5].FormattedValue.ToString();

                if (value == GetCode)
                {
                    MessageBox.Show("중복되는 바코드가 읽혔습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb.Clear();
                    return;
                }
                
            }


            try
            {
                if (GetCode.Length > 8)
                {
                    if (GetCode.Substring(0, 6) == "[)>06")
                    {
                        if(nCheckBox != nBox + 1)
                        {
                            MessageBox.Show("박스를 스캔 할 순서입니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tb.Clear();
                            return;
                        }
                        else
                        {
                            SetStrCodes(GetCode);
                        }
                        
                        
                    }
                    else
                    {
                        /*
                        if (GetCode.Substring(24, 10) == strLT2)
                        {
                            ScanLogWriter(GetCode, "BOX", "");
                            dataGridView1.Rows.Add("박스 스캔", "", "", "", Box, GetCode);
                            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                            
                        }
                        else
                        {
                            MessageBox.Show("잘못된 박스 바코드입니다.");
                            return;
                        }
                        */

                        if(GetCode.Substring(0, 1) == "J")
                        {
                            if(nBox!=0 && nScanned % nEA == 0)
                            {
                                if (GetCode.Substring(24, 10) == strLT2)
                                {
                                    if (nCheckBox == nBox)
                                    {
                                        ScanLogWriter(GetCode, "BOX", "");
                                        dataGridView1.Rows.Add("박스 스캔", "", "", "", Box, GetCode);
                                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                                        nCheckBox = nCheckBox + 1;
                                        SaveNScanned();
                                        //MessageBox.Show(nCheckBox.ToString());
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("박스 스캔 순서가 아닙니다", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        tb.Clear();
                                        return;
                                    }
                                    
                                }
                                else
                                {
                                    MessageBox.Show("잘못된 박스 바코드입니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    tb.Clear();
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("박스 스캔 순서가 아닙니다", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                tb.Clear();
                                return;
                            }
                        }
                        return;
                    }
                }
                else
                {
                    return;

                }
                
                if (StrCode1.Equals(strLT4) && StrCode2.Equals(strLT2) && StrCode3.Equals(strLT5) && StrCode4.Equals(strLT6))
                {
                    ScanLogWriter(tb.Text, "Barcode", "합격");
                    nScanned = nScanned + 1;
                    SaveNScanned();
                    dataGridView1.Rows.Add(StrCode1, StrCode2, StrCode3, StrCode4, Pass, tb.Text);
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                    timer1_Tick(sender, e);

                    if (nScanned % nEA == 0)
                    {
                        if (nScanned >= nOrdered)
                        {
                            CheckLabelPrint();
                            MessageBox.Show("발주량 스캔 완료");
                            ScanLogWriter("발주량 스캔 완료", "", "");
                            LogWriter(FileNameCsv, "발주량 스캔 완료");
                            this.Close();
                            return;
                        }
                        else
                        {
                            CheckLabelPrint();
                            MessageBox.Show("박스를 스캔하세요", "박스를 스캔하세요", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tb.Clear();
                            return;


                        }
                    }
                    
                }
                else
                {
                    ScanLogWriter(tb.Text, "Barcode", "불합격");
                    dataGridView1.Rows.Add(StrCode1, StrCode2, StrCode3, StrCode4, NPass, tb.Text);
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                }
                return;
            }
            
            catch (Exception ex)
            {
                LogWriter("tb_TextChanged Exception", ex.Message);
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
                LogWriter("dataGridView1_RowPostPaint", ex.Message);
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

                    if (StrCode1.Equals(strLT4) && StrCode2.Equals(strLT2) && StrCode3.Equals(strLT5) && StrCode4.Equals(strLT6))
                    {
                        dataGridView1.Rows.Add(StrCode1, StrCode2, StrCode3, StrCode4, Pass, GetCode);
                    }
                    else
                    {
                        dataGridView1.Rows.Add(StrCode1, StrCode2, StrCode3, StrCode4, NPass, GetCode);
                    }
                }
                else
                {
                    dataGridView1.Rows.Add("박스 스캔", "", "", "", Box, GetCode);
                }
            }
            catch (Exception ex)
            {
                LogWriter("SetDataFromCsv Exception", ex.Message);
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
                    mouse_event(MOUSEEVENTF_LEFTDOWN,0,0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    Delay(3000);
                    ShowWindow(procHandler, SW_MINIMIZE);


                }
            }
            
            //this.WindowState = FormWindowState.Minimized;
        }
        void SetStrCodes(string GetCode)
        {

            try
            {
                if(GetCode.Length > 8)
                {
                    int length = GetCode.Length - 7;
                    GetCode = GetCode.Substring(7, length);

                    string[] words = GetCode.Split('');

                    StrCode1 = words[0].Substring(1, words[0].Length - 1);         // 업체코드 4 Byte
                    StrCode2 = words[1].Substring(1, words[1].Length - 1);         // 품번 10~15 Byte
                    StrCode3 = words[2].Substring(1, words[2].Length - 1);         // ACL코드 1~8 Byte
                    StrCode4 = words[3].Substring(1, words[3].Length - 1);         // EO NO 8~9 Byte
                    StrCode5 = words[4].Substring(1, words[4].Length - 1);         // LOT NO 14~36 Byte
                }
                else
                {
                    StrCode1 = "";
                    StrCode2 = "";
                    StrCode3 = "";
                    StrCode4 = "";
                    StrCode5 = "";
                }
                

            }
            catch (Exception ex)
            {
                LogWriter("SetStrCodes", ex.Message);
            }

            
        }

        void SaveNScanned()
        {
            using (TextWriter tWriter = new StreamWriter((ListViewFile + "\\Selected_Order.txt")))
            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4};{5};{6}", strLO1, strLO2, strLO3, strLO4, strLO5, nScanned, nCheckBox));
            }
        }
        

        private static DateTime Delay(int MS)
        {
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
        #endregion

        private void FormWork_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ProcessKill("BARCODE_IVS");
            //ProcessKill("svchost.exe");
        }
    }
}

    


