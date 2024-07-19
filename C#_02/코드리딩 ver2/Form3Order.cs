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
    public partial class Form3Order : Form
    {
        FormWork formwork = new FormWork();
        public Form3Order()
        {
            InitializeComponent();
            LoadData_OrderLV(PV.DataPath + "\\ListView_Order.txt");
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
            string[] strs = new string[8];
            strs[1] = lvi.SubItems[1].Text;                     // 차종
            strs[2] = lvi.SubItems[2].Text;                     // 발주번호
            strs[3] = lvi.SubItems[3].Text;                     // 발주수량
            strs[4] = lvi.SubItems[4].Text;                     // 납기일
            strs[5] = lvi.SubItems[5].Text;                     // 용도
            strs[6] = lvi.SubItems[6].Text;                     // 진행상태

            if(lvi.SubItems[6].Text == "완료")
            {
                PV.nScanned = Int32.Parse(strs[3]);
            }
            else
            {
                PV.nScanned = Int32.Parse(strs[6]);
            }

            

            StreamWriter sw = new StreamWriter(PV.DataPath + "\\Selected_Order.txt", false);
            sw.Close();
            SaveData(PV.DataPath + "\\Selected_Order.txt", strs);

            StreamWriter sw1 = new StreamWriter(PV.DataPath + "\\Selected_Quantity.txt", false);
            sw1.Close();
            SaveData_Quantity(PV.DataPath + "\\Selected_Quantity.txt", strs[3]);

            PF.LogWriter("오더선택", "발주 번호 :" + strs[2]);
            PV.strs_Order[1] = strs[1];
            PV.strs_Order[3] = strs[3];
            PV.strs_Order[4] = strs[4];
            PV.strs_Order[5] = strs[5];

            lv3.CheckedItems[0].Checked = false;
        }

        private void SaveData(string fileName, string[] stringArray)

        {  // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))
            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4};{5}", stringArray[1], stringArray[2], stringArray[3], stringArray[4], stringArray[5], stringArray[6]));

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

        public void LoadData_OrderLV(string fileName)

        {
            lv3.Items.Clear();
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
                        strs[1] = stringArray[0].ToString();        // 차종
                        strs[2] = stringArray[1].ToString();        // 발주번호
                        strs[3] = stringArray[2].ToString();        // 발주수량
                        strs[4] = stringArray[3].ToString();        // 납기일
                        strs[5] = stringArray[4].ToString();        // 용도


                        StringBuilder sb = new StringBuilder();
                        string FilePath = sb.Append(strs[2]).Append("_").Append(strs[1]).Append("_").Append(strs[5]).ToString();
                        string FilePath2 = @"D:\VisionProgram\CsvScanLogPath\" + FilePath + "\\" + FilePath + ".csv";

                        FileInfo fi = new FileInfo(FilePath2);

                        if (fi.Exists == false)
                        {
                            strs[6] = "0";
                        }
                        else
                        {
                            using (TextReader tReader1 = new StreamReader(FilePath2))
                            {
                                int nOK = 0;
                                string[] stringLines1 = tReader1.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                                foreach (string stringLine1 in stringLines1)

                                {
                                    if (stringLine1 != string.Empty && stringLine1.Contains("OK"))
                                    {
                                        nOK++;
                                    }
                                }
                                if (Convert.ToInt32(strs[3]) == nOK)
                                {
                                    strs[6] = "완료";
                                }
                                else
                                {
                                    strs[6] = nOK.ToString();
                                }

                            }
                        }

                        strs[7] = "데이터 확인";

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

        private void lv3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lv3.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = lv3.SelectedItems;
                ListViewItem lvItem = items[0];
                string FilePath1 = lvItem.SubItems[2].Text + "_" + lvItem.SubItems[1].Text + "_" + lvItem.SubItems[5].Text;
                string FilePath = @"D:\VisionProgram\CsvScanLogPath\" + FilePath1 + "\\";
                if (Directory.Exists(FilePath))
                {
                    Process.Start(FilePath);
                }
                else
                {
                    MessageBox.Show("데이터 없음");
                }
                
            }
        }

    }
}
