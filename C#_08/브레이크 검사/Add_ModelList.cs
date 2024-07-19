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
    public partial class Add_ModelList : Form
    {
        public Main main;
        public Add_ModelList()
        {
            InitializeComponent();
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                if (PV.stringArray_Model != null && PV.stringArray_Limit != null)
                {
                    for (int i = 0; i < PV.stringArray_Model.Length-1; i++)
                    {
                        dataGridView1.Rows.Add(i + 1, PV.stringArray_Model[i], PV.stringArray_Limit[i].Split(',')[0], PV.stringArray_Limit[i].Split(',')[1], PV.stringArray_Offset[i], PV.stringArray_AngleScore[i], PV.stringArray_Score[i]);
                        dataGridView1.FirstDisplayedScrollingRowIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("LoadDataGrid", ex.Message);
                MessageBox.Show(ex.Message);
            }

        }
        private void btn_BackToMain_Click(object sender, EventArgs e)
        {

            this.Close();

            PF.ReadModelData();
        }

        private void btn_SaveModel_Click(object sender, EventArgs e)
        {

            if ((tb_ModelName.Text != "") && (tb_LowerLimit.Text != "") && (tb_UpperLimit.Text != "") && (tb_Offset.Text != "") && (tb_Score.Text != ""))
            {
                dataGridView1.Rows.Clear();

                // Model Name
                StreamWriter sw;
                string FileName = PV.DataPath + @"\ModelList.txt";
                sw = new StreamWriter(FileName, true, Encoding.Default);
                sw.WriteLine(tb_ModelName.Text);
                sw.Close();


                // Limit
                StreamWriter sw1;
                string FileName1 = PV.DataPath + @"LimitList.txt";
                sw1 = new StreamWriter(FileName1, true, Encoding.Default);
                sw1.WriteLine(tb_LowerLimit.Text + "," + tb_UpperLimit.Text);
                sw1.Close();

                // Offset
                StreamWriter sw2;
                string FileName2 = PV.DataPath + @"OffsetList.txt";
                sw2 = new StreamWriter(FileName2, true, Encoding.Default);
                sw2.WriteLine(tb_Offset.Text);
                sw2.Close();

                // Score
                StreamWriter sw3;
                string FileName3 = PV.DataPath + @"ScoreList.txt";
                sw3 = new StreamWriter(FileName3, true, Encoding.Default);
                sw3.WriteLine(tb_Score.Text);
                sw3.Close();

                // AngleScore
                StreamWriter sw4;
                string FileName4 = PV.DataPath + @"ScoreList1.txt";
                sw4 = new StreamWriter(FileName4, true, Encoding.Default);
                sw4.WriteLine(tb_AngleScore.Text);
                sw4.Close();

                tb_ModelName.Clear();
                PF.ReadModelData();
                LoadDataGrid();
            }
            else
            {
                MessageBox.Show("정확히 입력하세요");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FileName_Model = PV.DataPath + @"\ModelList.txt";
            string FileName_Offset = PV.DataPath + @"\OffsetList.txt";
            string FileName_Limit = PV.DataPath + @"\LimitList.txt";
            string FileName_AngleScore = PV.DataPath + @"\ScoreList1.txt";
            string FileName_Score = PV.DataPath + @"\ScoreList.txt";

            StreamWriter sw1;
            StreamWriter sw2;
            StreamWriter sw3;
            StreamWriter sw4;
            StreamWriter sw5;

            sw1 = new StreamWriter(FileName_Model, false, Encoding.Default);
            sw2 = new StreamWriter(FileName_Limit, false, Encoding.Default);
            sw3 = new StreamWriter(FileName_Offset, false, Encoding.Default);
            sw4 = new StreamWriter(FileName_AngleScore, false, Encoding.Default);
            sw5 = new StreamWriter(FileName_Score, false, Encoding.Default);

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {

                sw1.WriteLine(dataGridView1[1, i].Value);
                sw2.WriteLine(dataGridView1[2, i].Value + "," + dataGridView1[3, i].Value);
                sw3.WriteLine(dataGridView1[4, i].Value);
                sw4.WriteLine(dataGridView1[5, i].Value);
                sw5.WriteLine(dataGridView1[6, i].Value);
            }
            sw1.Close();
            sw2.Close();
            sw3.Close();
            sw4.Close();
            sw5.Close();
        }

        private void btn_passwordsave_Click(object sender, EventArgs e)
        {
            string str6AdminPW = tb_6_AdminPW.Text;

            if (str6AdminPW == "")
            {
                MessageBox.Show("비밀번호를 정확히 입력하세요");
                return;
            }

            tb_6_AdminPW.Text = string.Empty;

            StreamWriter sw = new StreamWriter(PV.DataPath + "\\PASSWORD.txt", false);
            sw.Close();
            SaveData_PW(PV.DataPath + "\\PASSWORD.txt", str6AdminPW);

            MessageBox.Show("설정 된 패스워드는 : " + str6AdminPW + " 입니다.");
        }

        private void SaveData_PW(string fileName, string PW)

        {
            using (TextWriter tWriter = new StreamWriter(fileName))

            {
                tWriter.WriteLine(PW);

            }

        }
    }
}
