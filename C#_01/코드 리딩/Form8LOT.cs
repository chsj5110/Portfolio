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
    public partial class Form8LOT : Form
    {
        public Main MainForm = new Main();
        string LOT = "";
        public Form8LOT()
        {
            InitializeComponent();
            LoadData_LOT(MainForm.ListViewFile + "\\Selected_LOT.txt");
        }



        private void bt_8_Select_Click(object sender, EventArgs e)
        {
            LOT = tb_8_LOT.Text;
            SaveData(MainForm.ListViewFile + "\\Selected_LOT.txt", LOT);
            MainForm.lb_m_LOT.Text = LOT;
            this.Close();
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
                        tb_8_LOT.Text = LOT;


                    }
                }
            }
        }

        private void SaveData(string fileName, string LOT)
        {
            using (TextWriter tWriter = new StreamWriter(fileName))
            {
                tWriter.WriteLine(LOT);

            }
        }
        
    }
}
