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
    public partial class Form1Type : Form
    {

        string ListViewFile = @"D:\VisionProgram\";

        FormWork formwork = new FormWork();
        public Form1Type()
        {
            InitializeComponent();
            LoadData(ListViewFile + "\\ListView_Type.txt");

        }
        public Main MainForm;


        public void bt_1_Select_Click(object sender, EventArgs e)
        {
            bool chkboxSelected = lv1.CheckedItems.Count > 0;
            if (chkboxSelected == false)
            {
                MessageBox.Show("항목 중 하나를 선택하십시오");
                return;
            }

            ListViewItem lvi = lv1.CheckedItems[0];
            string[] strs = new string[8];
            strs[1] = lvi.SubItems[1].Text;
            strs[2] = lvi.SubItems[2].Text;
            strs[3] = lvi.SubItems[3].Text;                     // 
            strs[4] = lvi.SubItems[4].Text;
            strs[5] = lvi.SubItems[5].Text;
            strs[6] = lvi.SubItems[6].Text;
            strs[7] = lvi.SubItems[7].Text;


            string SendType = lvi.SubItems[1].Text;

            MainForm.lb_m_SelectedType.Text = SendType;

            



            StreamWriter sw = new StreamWriter(ListViewFile + "\\Selected_Type.txt", false);
            sw.Close();
            SaveData(ListViewFile + "\\Selected_Type.txt", strs);
            formwork.LogWriter("차종선택", strs[1]);
            this.Close();

        }

       
        private void LoadData(string fileName)

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
                        strs[1] = stringArray[0].ToString();
                        strs[2] = stringArray[1].ToString();
                        strs[3] = stringArray[2].ToString();
                        strs[4] = stringArray[3].ToString();
                        strs[5] = stringArray[4].ToString();
                        strs[6] = stringArray[5].ToString();
                        strs[7] = stringArray[6].ToString();


                        ListViewItem lvi = new ListViewItem(strs);
                        lv1.Items.Add(lvi);
                    }
                }
            }
        }

        private void SaveData(string fileName, string[] stringArray)

        {  // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))
            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4};{5};{6}", stringArray[1], stringArray[2], stringArray[3], stringArray[4], stringArray[5], stringArray[6], stringArray[7]));

            }
        }

        private void lv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool b_Checked = lv1.CheckedItems.Count > 0;
            
        }
        
        private void lv1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
             e.DrawDefault = true;
        }
        

        private void lv1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.lv1.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.lv1.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.lv1.Items)
                    item.Checked = !value;

                this.lv1.Invalidate();
            }
        }

        private void lv1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            lv1.ItemChecked -= lv1_ItemChecked;
            foreach (var item in lv1.CheckedItems)
            {
                if (e.Item != item)
                {
                    ((ListViewItem)item).Checked = false;

                }

            }
            lv1.ItemChecked += lv1_ItemChecked;

                                                                // checkbox selected only one
        }
        
    }
}
