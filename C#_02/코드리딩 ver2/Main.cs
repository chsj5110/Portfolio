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
using System.Threading;

namespace chsj
{

    public partial class Main : Form
    {


        //자식폼
        Form1Type frmType = new Form1Type();
        //Form2Login form2 = new Form2Login();
        Form3Order frmOrder = new Form3Order();
        Form5TypeSet frmTypeSet = new Form5TypeSet();
        Form6LoginSet frmLoginSet = new Form6LoginSet();
        Form7OrderSet frmOrderSet = new Form7OrderSet();
        FormWork frmWork = new FormWork();



        public Main()
        {
            InitializeComponent();

            //io 모듈
            PF.DioInit();
            IOTriggerStart();
            PF.IOOutPutMessage("0", "1");           // 초록불
            PF.IOOutPutMessage("1", "1");           // 노란불

            PF.LoadData_LOT(PV.DataPath + "\\Selected_LOT.txt");
            PF.LoadData_Type(PV.DataPath + "\\Selected_Type.txt");
            PF.LoadData_Worker(PV.DataPath + "\\Selected_Worker.txt");
            PF.LoadData_Order(PV.DataPath + "\\Selected_Order.txt");

            lb_m_LOT.Text = PV.sLOT;
            lb_m_SelectedType.Text = PV.strs_SType;
            lb_m_SelectedWorker.Text = PV.strs_SWorker;
            lb_m_SelectedOrder.Text = PV.strs_Order[1] + " / " + PV.strs_Order[3] + PV.strs_Order[4] + " / " + PV.strs_Order[5];

            
            OpenForm("Form3Order");
            OpenForm("Form5TypeSet");
            OpenForm("Form6LoginSet");
            OpenForm("Form7OrderSet");
            OpenForm("Form1Type");

            Task taskReadyCam1 = new Task(Task_ReadyCam1);
            taskReadyCam1.Start();
        }

        private void OpenForm(string frmName)
        {
            Form frm = new Form();

            switch (frmName)
            {
                case "Form1Type":
                    frm = frmType;
                    break;
                case "Form3Order":
                    frm = frmOrder;
                    break;
                case "Form5TypeSet":
                    frm = frmTypeSet;
                    break;
                case "Form6LoginSet":
                    frm = frmLoginSet;
                    break;
                case "Form7OrderSet":
                    frm = frmOrderSet;
                    break;
                case "FormWork":
                    frm = frmWork;
                    break;
            }

            frm.MdiParent = this;
            frm.Show();
        }

        // 화면 앞으로 가져오기
        private void FrontForm(string frmName)
        {
            if (frmName == "Form1Type")
            {
                PV.WorkStart = false;
                frmWork.ChkStop();
                frmType.WindowState = FormWindowState.Normal;
                frmType.Activate();
                frmType.BringToFront();
            }
            else if (frmName == "Form3Order")
            {
                PV.WorkStart = false;
                frmOrder.WindowState = FormWindowState.Normal;
                frmOrder.Activate();
                frmOrder.BringToFront();
            }
            else if (frmName == "Form5TypeSet")
            {
                PV.WorkStart = false;
                frmTypeSet.WindowState = FormWindowState.Normal;
                frmTypeSet.Activate();
                frmTypeSet.BringToFront();
            }
            else if (frmName == "Form6LoginSet")
            {
                PV.WorkStart = false;
                frmLoginSet.WindowState = FormWindowState.Normal;
                frmLoginSet.Activate();
                frmLoginSet.BringToFront();
            }
            else if (frmName == "Form7OrderSet")
            {
                PV.WorkStart = false;
                
                frmOrderSet.WindowState = FormWindowState.Normal;
                frmOrderSet.Activate();
                frmOrderSet.BringToFront();
            }
            else if (frmName == "FormWork")
            {
                PV.WorkStart = true;
                frmWork.WindowState = FormWindowState.Normal;
                frmWork.Activate();
                frmWork.BringToFront();
            }
        }


        public void bt_Type_Click(object sender, EventArgs e)
        {
            frmType.LoadData_TypeLV(PV.DataPath + @"\ListView_Type.txt");
            FrontForm("Form1Type");
            frmWork.ChkStop();
        }

        public void bt_Login_Click(object sender, EventArgs e)
        {
            Form2Login newform = new Form2Login();
            newform.MainForm = this;

            PF.LogWriter("bt_Login_Click", "bt_Login_Click");

            newform.loginEventHandler += new EventHandler(LoginSuccess);

            switch (newform.ShowDialog())
            {
                case DialogResult.OK:
                    newform.Close();
                    frmWork.ChkStop();
                    break;
                case DialogResult.Cancel:
                    break;
            }


        }
        public void LoginSuccess(string userName)
        {
            MessageBox.Show(userName + "으로 로그인 되었습니다.");
            PF.LoadData_Worker(PV.DataPath + "\\Selected_Worker.txt");
            PF.LogWriter("LoginSuccess", userName + "으로 로그인 되었습니다.");
            lb_m_SelectedWorker.Text = PV.strs_SWorker;
        }

        private void bt_Order_Click(object sender, EventArgs e)
        {
            frmOrder.LoadData_OrderLV(PV.DataPath + "\\ListView_Order.txt");
            FrontForm("Form3Order");
            frmWork.ChkStop();
        }

        private void bt_Work_Click(object sender, EventArgs e)
        {
            if (lb_m_SelectedType.Text != "" && lb_m_SelectedOrder.Text != "" && lb_m_SelectedWorker.Text != "" && lb_m_LOT.Text != "")
            {
                OpenForm("FormWork");
                FrontForm("FormWork");
                
                frmWork.ChkStart();


            }
            else
            {
                MessageBox.Show("차종 / 작업자 / 오더 / LOT 를 모두 선택하세요");
                return;
            }

        }
        private void Task_ReadyCam1()
        {
            while (!PV.bIOCheck)
            {
                try
                {
                    if (PF.IOCheck("2") == "1")
                    {

                        label5.ForeColor = System.Drawing.Color.LimeGreen;
                    }
                    else
                    {
                        label5.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    PF.LogWriter("Task_ReadyCam1", ex.Message);
                    MessageBox.Show(ex.ToString());
                    return;
                }
                Thread.Sleep(1);
            }
        }

   
        private void bt_TypeSet_Click(object sender, EventArgs e)
        {
            Form0Password form0 = new Form0Password();
            form0.ShowDialog();

            if (form0.PWCheck(form0.tb_0.Text))
            {
                FrontForm("Form5TypeSet");
                frmWork.ChkStop();
            }
            else
            {
                MessageBox.Show("비밀번호가 틀렸습니다.");
            }

            PF.LogWriter("bt_TypeSet_Click", "bt_TypeSet_Click");

        }

        private void bt_LoginSet_Click(object sender, EventArgs e)
        {

            Form0Password form0 = new Form0Password();
            form0.ShowDialog();

            if (form0.PWCheck(form0.tb_0.Text))
            {
                FrontForm("Form6LoginSet");
                frmWork.ChkStop();
            }
            else
            {
                MessageBox.Show("비밀번호가 틀렸습니다.");
            }

            PF.LogWriter("bt_LoginSet_Click", "bt_LoginSet_Click");

        }

        private void bt_OrderSet_Click(object sender, EventArgs e)
        {

            Form0Password form0 = new Form0Password();
            form0.ShowDialog();

            if (form0.PWCheck(form0.tb_0.Text))
            {
                FrontForm("Form7OrderSet");
                frmWork.ChkStop();
            }
            else
            {
                MessageBox.Show("비밀번호가 틀렸습니다.");
            }

            PF.LogWriter("bt_OrderSet_Click", "bt_OrderSet_Click");

        }




        private void bt_m_LOT_Click(object sender, EventArgs e)
        {
            Form8LOT newform = new Form8LOT();
            newform.MainForm = this;
            newform.ShowDialog();
            frmWork.ChkStop();
            PF.LogWriter("bt_LOT_Click", "bt_LOT_Click");
        }

        private void btn_EXIT_Click(object sender, EventArgs e)
        {
            PF.IOReset();
            PF.ProcessKill("chsj");
            
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_m_LOT.Text = PV.sLOT;
            lb_m_SelectedType.Text = PV.strs_SType;
            lb_m_SelectedWorker.Text = PV.strs_SWorker;
            lb_m_SelectedOrder.Text = PV.strs_Order[1] + " / " + PV.strs_Order[3] + " / " + PV.strs_Order[4] + " / " + PV.strs_Order[5];
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

        private void cb_vc_CheckedChanged(object sender, EventArgs e)
        {
            PV.bCamCheck = cb_vc.Checked;
        }
    }

}

