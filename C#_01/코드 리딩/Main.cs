using chsj;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace chsj
{
    
    public partial class Main : Form
    {
        


        Form1Type form1 = new Form1Type();
        //Form2Login form2 = new Form2Login();
        Form3Order form3 = new Form3Order();
        FormWork formwork = new FormWork();

        public string ListViewFile = @"D:\VisionProgram\";
        public bool b_PassWord;
        public int nnScanned = 0;                //스캔 된 수량
        string LOT;
        
        public Main()
        {
            InitializeComponent();
            LoadData_LOT(ListViewFile + "\\Selected_LOT.txt");
            LoadData_Type(ListViewFile + "\\Selected_Type.txt");
            LoadData_Worker(ListViewFile + "\\Selected_Worker.txt");
            LoadData_Order(ListViewFile + "\\Selected_Order.txt");
        }


        private void LoadData_LOT(string fileName)

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


                        LOT = stringArray[0].ToString();
                        lb_m_LOT.Text = LOT;


                    }
                }
            }
        }
        private void LoadData_Type(string fileName)

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

                        string strs_SType;
                        strs_SType = stringArray[0].ToString();

                        lb_m_SelectedType.Text = strs_SType;
                    }
                }
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

                        lb_m_SelectedWorker.Text = strs_SWorker;
                    }
                }
            }
        }
        private void LoadData_Order(string fileName)

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

                        string[] strs = new string[6];
                        strs[1] = stringArray[0].ToString();
                        strs[2] = stringArray[1].ToString();
                        strs[3] = stringArray[2].ToString();
                        strs[4] = stringArray[3].ToString();
                        strs[5] = stringArray[4].ToString();



                        lb_m_SelectedOrder.Text = strs[1] + " / " + strs[3] + "\r" + strs[4] + " / " + strs[5];
                    }
                }
            }
        }

        public void bt_Type_Click(object sender, EventArgs e)
        {
            Form1Type newform = new Form1Type();
            newform.MainForm = this;
            newform.ShowDialog();

            formwork.LogWriter("bt_Type_Click", "bt_Type_Click");
        }

        public void bt_Login_Click(object sender, EventArgs e)
        {
            Form2Login newform = new Form2Login();
            newform.MainForm = this;
            //newform.ShowDialog();

            formwork.LogWriter("bt_Login_Click", "bt_Login_Click");

            newform.loginEventHandler += new EventHandler(LoginSuccess);
            
            switch (newform.ShowDialog())
            {
                case DialogResult.OK:
                    newform.Close();
                    break;
                case DialogResult.Cancel:
                    //Dispose();
                    break;
            }

           
        }
        public void LoginSuccess(string userName)
        {
            MessageBox.Show(userName + "으로 로그인 되었습니다.");
            LoadData_Worker(ListViewFile + "\\Selected_Worker.txt");
            formwork.LogWriter("LoginSuccess", userName + "으로 로그인 되었습니다.");
        }

        private void bt_Order_Click(object sender, EventArgs e)
        {
            Form3Order newform = new Form3Order();
            newform.MainForm = this;
            newform.ShowDialog();
            formwork.LogWriter("bt_Order_Click", "bt_Order_Click");
        }

        private void bt_Work_Click(object sender, EventArgs e)
        {
            if(lb_m_SelectedType.Text !="" && lb_m_SelectedOrder.Text != "" && lb_m_SelectedWorker.Text != "" && lb_m_LOT.Text !="")
            {
                FormWork newform = new FormWork();
                newform.MainForm = this;
                newform.ShowDialog();
                formwork.LogWriter("bt_Work_Click", "bt_Work_Click");
            }
            else
            {
                MessageBox.Show("차종 / 작업자 / 오더 / LOT 를 모두 선택하세요");
                return;
            }
            
        }

        private void bt_TypeSet_Click(object sender, EventArgs e)
        {
            Form0Password form0 = new Form0Password();
            form0.ShowDialog();

            if (form0.PWCheck(form0.tb_0.Text))
            {
                Form5TypeSet newform = new Form5TypeSet();
                newform.ShowDialog();
            }
            else
            {
                MessageBox.Show("비밀번호가 틀렸습니다.");
            }

            formwork.LogWriter("bt_TypeSet_Click", "bt_TypeSet_Click");

        }

        private void bt_LoginSet_Click(object sender, EventArgs e)
        {

            Form0Password form0 = new Form0Password();
            form0.ShowDialog();

            if (form0.PWCheck(form0.tb_0.Text))
            {
                Form6LoginSet newform = new Form6LoginSet();
                newform.ShowDialog();
            }
            else
            {
                MessageBox.Show("비밀번호가 틀렸습니다.");
            }

            formwork.LogWriter("bt_LoginSet_Click", "bt_LoginSet_Click");

        }

        private void bt_OrderSet_Click(object sender, EventArgs e)
        {

            Form0Password form0 = new Form0Password();
            form0.ShowDialog();

            if (form0.PWCheck(form0.tb_0.Text))
            {
                Form7OrderSet newform = new Form7OrderSet();
                newform.ShowDialog();
            }
            else
            {
                MessageBox.Show("비밀번호가 틀렸습니다.");
            }

            formwork.LogWriter("bt_OrderSet_Click", "bt_OrderSet_Click");

        }


       

        private void SaveData(string fileName, string SendType)

        {  // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))
            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine();
            }
        }

        private void bt_m_LOT_Click(object sender, EventArgs e)
        {
            Form8LOT newform = new Form8LOT();
            newform.MainForm = this;
            newform.ShowDialog();
            formwork.LogWriter("bt_LOT_Click", "bt_LOT_Click");
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProcessKill("BARCODE_IVS");
        }

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
    }
    }

