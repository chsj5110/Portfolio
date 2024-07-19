using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace chsj
{
    public partial class FormW_1 : Form
    {
        public FormWork formwork;

        [DllImport("User32", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [DllImport("User32")]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        private const int SW_SHOWNORMAL = 1;
        private const int SW_MAXIMIZE = 3;
        private const int SW_MINIMIZE = 6;

        Image Box = Properties.Resources.box;
        
        public FormW_1()
        {
            InitializeComponent();
            
        }
        

        private void FormW_1_Load(object sender, EventArgs e)
        {
            
            if (formwork.serialPort1.IsOpen)
            {
                formwork.serialPort1.Close();
            }

            serialPort1.PortName = "COM4";
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.DataBits = 8;
            serialPort1.Handshake = Handshake.None;
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);

            serialPort1.Open();

            if(formwork.nScanned != 0)
            {
                label1.Visible = true;
            }
            else
            {
                
            }

            formwork.LogWriter("FormW_1_Load", "FormW_1_Load");

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Invoke(new Action(() => tb.Clear()));
            SerialPort sp = (SerialPort)sender;
            string s = sp.ReadExisting();
            Invoke(new Action(() => tb_w1.Text += s));
        }
        private void tb_w1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(tb_w1.Text.Length > 8)
                {
                    if (tb_w1.Text.Substring(0, 1) == "J")
                    {
                        if(tb_w1.Text.Substring(24, 10) == formwork.strLT2)
                        {
                            formwork.ScanLogWriter(tb_w1.Text, "BOX", "");
                            formwork.dataGridView1.Rows.Add("박스 스캔", "", "", "", Box, tb_w1.Text);
                            formwork.dataGridView1.FirstDisplayedScrollingRowIndex = formwork.dataGridView1.Rows.Count - 1;
                            formwork.nCheckBox = formwork.nCheckBox + 1;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("잘못된 바코드 입니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);              // EO NO와 일치 하지 않을때
                            tb_w1.Clear();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("박스 바코드가 아닙니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tb_w1.Clear();
                        return;
                    }
                }
                else
                {
                    tb_w1.Clear();
                    return;
                }
                
            }
            catch (Exception ex)
            {
                formwork.LogWriter("tb_w1_TextChanged", ex.Message);
            }

        }

        private void FormW_1_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            formwork.serialPort1.PortName = "COM4";
            formwork.serialPort1.BaudRate = 9600;
            formwork.serialPort1.Parity = Parity.None;
            formwork.serialPort1.StopBits = StopBits.One;
            formwork.serialPort1.DataBits = 8;
            formwork.serialPort1.Handshake = Handshake.None;
            formwork.serialPort1.DataReceived += new SerialDataReceivedEventHandler(formwork.serialPort1_DataReceived);

            formwork.serialPort1.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process proc in processes)
            {
                if (proc.ProcessName.Equals("GoLabel"))
                {
                    IntPtr procHandler = FindWindow(null, proc.MainWindowTitle);
                    ShowWindow(procHandler, SW_MAXIMIZE);
                    SetForegroundWindow(procHandler);


                }
            }
        }
    }
}
