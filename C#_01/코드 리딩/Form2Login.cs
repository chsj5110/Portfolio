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

namespace chsj
{

    public delegate void EventHandler(string userName);
    
    public partial class Form2Login : Form
    {
        public event EventHandler loginEventHandler;
        string ListViewFile = @"D:\VisionProgram\";
        public string CompName;
        public string CompPW;
        public Form2Login()
        {
            ActiveControl = combobox_2;
            InitializeComponent();
        }
        public Main MainForm;
        
        
        public void bt_2_Login_Click(object sender, EventArgs e)
        {
            LoginHandler loginHandler = new LoginHandler();
            string userName = combobox_2.SelectedItem.ToString();
            string userPW = tb_2_PW.Text;

            if (ControlCheck())
            {
                CompareNamePW(userName);

                if (loginHandler.LoginCheck(userName, userPW, CompName, CompPW))
                {
                    try
                    {
                        loginEventHandler(userName);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }


                }
                else
                {
                    MessageBox.Show("로그인 정보가 정확하지 않습니다", "알림");
                    tb_2_PW.Clear();
                }
            }
        }

        private bool ControlCheck()
        {
            if (String.IsNullOrEmpty(combobox_2.SelectedItem.ToString()))
            {
                MessageBox.Show("이름과 패스워드를 입력해주세요.", "알림");
                combobox_2.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(tb_2_PW.Text))
            {
                MessageBox.Show("패스워드를 입력해주세요.", "알림");
                tb_2_PW.Focus();
                return false;
            }
            return true;
        }
        public void CompareNamePW(string Name)
        {
            string strColumn;
            string userPW = tb_2_PW.Text;
            using (StreamReader file = new StreamReader(ListViewFile + "\\ListView_Login.txt"))
            {
                strColumn = file.ReadToEnd();
                string[] stringLines = strColumn.Replace("\n", "").Split((char)Keys.Enter);
                
                foreach (string stringLine in stringLines)

                {
                    if (stringLine.Contains(Name))
                    {
                        string[] stringArray = stringLine.Split(';');

                        CompName = stringArray[0].ToString();
                        CompPW = stringArray[1].ToString();
                       // MessageBox.Show(Name + "/" + userPW);
                    }
                }

            }
        }

        public void SaveData(string fileName, string UserName)

        {  // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))
            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(UserName);
            }
        }

        private void Form2Login_Load(object sender, EventArgs e)
        {
            using (TextReader tReader = new StreamReader(ListViewFile + "\\ListView_Login.txt"))
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

                        combobox_2.Items.Add(strs[1]);
                    }
                }
            }
        }

        private void combobox_2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tb_2_PW_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                bt_2_Login_Click(sender, e);
            }
        }
    }
}
