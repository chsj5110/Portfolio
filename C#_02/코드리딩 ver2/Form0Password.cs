using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chsj
{
    public partial class Form0Password : Form
    {
        string strs_PW;
        public Form0Password()
        {
            InitializeComponent();
            ActiveControl = tb_0;
            LoadData_PW(PV.DataPath + "\\PASSWORD.txt");
            tb_0.Focus();

        }
        public Main MainForm;


        private void LoadData_PW(string fileName)

        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach(string stringLine in stringLines)

                {
                    if (stringLine.Trim() != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[0]);

                        strs_PW = stringArray[0].ToString();
                    }
                }

            }
        }
        public void bt_0_Click(object sender, EventArgs e)
        {
            string PassWord = tb_0.Text;
            PWCheck(PassWord);

            return;
        }

        public bool PWCheck(string PassWord)
        {
            if (PassWord.Equals(strs_PW))
            {
                this.Close();
                return true;
            }
            this.Close();
            return false;
        }

        private void tb_0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bt_0_Click(sender, e);
            }
        }
    }
}
