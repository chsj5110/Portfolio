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
    public partial class Form3Order : Form
    {
        string ListViewFile = @"D:\VisionProgram\";
        FormWork formwork = new FormWork();
        public Form3Order()
        {
            InitializeComponent();
            LoadData(ListViewFile + "\\ListView_Order.txt");
        }
        public Main MainForm;


        public void bt_3_Select_Click(object sender, EventArgs e)
        {
            bool chkboxSelected = lv3.CheckedItems.Count > 0;
            if (chkboxSelected == false)
            {
                MessageBox.Show("항목 중 하나를 선택하십시오");
                return;
            }
            
            ListViewItem lvi = lv3.CheckedItems[0];
            string[] strs = new string[6];
            strs[1] = lvi.SubItems[1].Text;                     // 차종
            strs[2] = lvi.SubItems[2].Text;                     // 발주번호
            strs[3] = lvi.SubItems[3].Text;                     // 발주수량
            strs[4] = lvi.SubItems[4].Text;                     // 납기일
            strs[5] = lvi.SubItems[5].Text;                     // 용도


            MainForm.lb_m_SelectedOrder.Text = strs[1] +" / "+ strs[3] + "\r" + strs[4] +" / "+ strs[5];


            StreamWriter sw = new StreamWriter(ListViewFile + "\\Selected_Order.txt", false);
            sw.Close();
            SaveData(ListViewFile + "\\Selected_Order.txt", strs);

            StreamWriter sw1 = new StreamWriter(ListViewFile + "\\Selected_Quantity.txt", false);
            sw1.Close();
            SaveData_Quantity(ListViewFile + "\\Selected_Quantity.txt", strs[3]);

            formwork.LogWriter("오더선택", "발주 번호 :" + strs[2]);

            this.Close();
        }
       
        private void SaveData(string fileName, string[] stringArray)

        {  // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))
            {
                    // 원하는 형태의 문자열로 한줄씩 기록합니다.
                    tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4};{5};{6}", stringArray[1], stringArray[2], stringArray[3], stringArray[4], stringArray[5],"0","0"));
             
            }
        }

        private void SaveData_Quantity(string fileName, string Quantity)

        {  // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))
            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(Quantity);

            }
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

                        string[] strs = new string[7];
                        strs[1] = stringArray[0].ToString();
                        strs[2] = stringArray[1].ToString();
                        strs[3] = stringArray[2].ToString();
                        strs[4] = stringArray[3].ToString();
                        strs[5] = stringArray[4].ToString();

                        ListViewItem lvi = new ListViewItem(strs);
                        lv3.Items.Add(lvi);
                    }
                }
            }
        }

        private void lv3_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool b_Checked = lv3.CheckedItems.Count > 0;

        }

        private void lv3_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }


        private void lv3_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv3_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv3_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.lv3.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.lv3.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.lv3.Items)
                    item.Checked = !value;

                this.lv3.Invalidate();
            }
        }

        private void lv3_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            lv3.ItemChecked -= lv3_ItemChecked;
            foreach (var item in lv3.CheckedItems)
            {
                if (e.Item != item)
                {
                    ((ListViewItem)item).Checked = false;

                }

            }
            lv3.ItemChecked += lv3_ItemChecked;
        }
    }
}
