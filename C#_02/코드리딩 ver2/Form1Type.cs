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
        public Main MainForm;
        FormWork formwork = new FormWork();

        public Form1Type()
        {
            InitializeComponent();
            LoadData_TypeLV(PV.DataPath + @"\ListView_Type.txt");
        }


        public void LoadData_TypeLV(string fileName)
        {
            lv1.Items.Clear();
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    if (stringLine != string.Empty)
                    {
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[0]);

                        PV.List_Type = new string[11];
                        PV.List_Type[1] = stringArray[0].ToString();
                        PV.List_Type[2] = stringArray[1].ToString();
                        PV.List_Type[3] = stringArray[2].ToString();
                        PV.List_Type[4] = stringArray[3].ToString();
                        PV.List_Type[5] = stringArray[4].ToString();
                        PV.List_Type[6] = stringArray[5].ToString();
                        PV.List_Type[7] = stringArray[6].ToString();
                        PV.List_Type[8] = stringArray[7].ToString();
                        PV.List_Type[9] = stringArray[8].ToString();
                        PV.List_Type[10] = stringArray[9].ToString();

                        ListViewItem lvi = new ListViewItem(PV.List_Type);
                        lv1.Items.Add(lvi);
                    }
                }
            }
        }

        public void bt_1_Select_Click(object sender, EventArgs e)
        {
            bool chkboxSelected = lv1.CheckedItems.Count > 0;
            if (chkboxSelected == false)
            {
                MessageBox.Show("항목 중 하나를 선택하십시오");
                return;
            }

            ListViewItem lvi = lv1.CheckedItems[0];
            string[] strs = new string[11];
            strs[1] = lvi.SubItems[1].Text;                     // 차종
            strs[2] = lvi.SubItems[2].Text;
            strs[3] = lvi.SubItems[3].Text;                     // 
            strs[4] = lvi.SubItems[4].Text;
            strs[5] = lvi.SubItems[5].Text;
            strs[6] = lvi.SubItems[6].Text;
            strs[7] = lvi.SubItems[7].Text;
            strs[8] = lvi.SubItems[8].Text;
            strs[9] = lvi.SubItems[9].Text;
            strs[10] = lvi.SubItems[10].Text;


            PV.bLPCheck = Convert.ToBoolean(strs[10]);
            StreamWriter sw = new StreamWriter(PV.DataPath + "\\Selected_Type.txt", false);
            sw.Close();
            SaveData(PV.DataPath + "\\Selected_Type.txt", strs);
            PF.LogWriter("차종선택", strs[1]);
            lv1.CheckedItems[0].Checked = false;
            PF.LoadData_Type(PV.DataPath + "\\Selected_Type.txt");

            Send_Model(strs[1]);
            PF.IOOutPutMessage("5", "1");           // job load 1 2
            PF.Delay(1000);
            PF.IOOutPutMessage("5", "0");           // job load 1 2
        }

        public void Send_Model(string Model)
        {
            switch (Model)
            {
                //1
                case "NX4e":
                    PF.IOReset();
                    // 
                    PF.IOOutPutMessage("6", "1");
                    // Model
                    PF.IOOutPutMessage("9", "1");

                    PF.IOOutPutMessage("0", "1");
                    PF.IOOutPutMessage("1", "1");
                    return;

                //2
                case "BC3 CUV":
                    PF.IOReset();
                    // 
                    PF.IOOutPutMessage("7", "1");
                    // Model
                    PF.IOOutPutMessage("10", "1");

                    PF.IOOutPutMessage("0", "1");
                    PF.IOOutPutMessage("1", "1");
                    return;

                //3
                case "BC3 STD":
                    PF.IOReset();
                    // 
                    PF.IOOutPutMessage("6", "1");
                    PF.IOOutPutMessage("7", "1");
                    // Model
                    PF.IOOutPutMessage("11", "1");

                    PF.IOOutPutMessage("0", "1");
                    PF.IOOutPutMessage("1", "1");
                    return;

                //4
                case "NX4":
                    PF.IOReset();
                    // 
                    PF.IOOutPutMessage("8", "1");
                    // Model
                    PF.IOOutPutMessage("12", "1");

                    PF.IOOutPutMessage("0", "1");
                    PF.IOOutPutMessage("1", "1");
                    return;

                //5
                case "BC3 N":
                    PF.IOReset();
                    // 
                    PF.IOOutPutMessage("6", "1");
                    PF.IOOutPutMessage("8", "1");
                    // Model
                    PF.IOOutPutMessage("13", "1");

                    PF.IOOutPutMessage("0", "1");
                    PF.IOOutPutMessage("1", "1");
                    return;

                //6
                case "AC3 STD":
                    PF.IOReset();
                    // 
                    PF.IOOutPutMessage("7", "1");
                    PF.IOOutPutMessage("8", "1");
                    // Model
                    PF.IOOutPutMessage("14", "1");

                    PF.IOOutPutMessage("0", "1");
                    PF.IOOutPutMessage("1", "1");
                    return;

                default:
                    PF.IOReset();

                    PF.IOOutPutMessage("0", "1");
                    PF.IOOutPutMessage("1", "1");
                    return;
            }
            

        }

        private void SaveData(string fileName, string[] stringArray)

        {  // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))
            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}", stringArray[1], stringArray[2], stringArray[3], stringArray[4],
                                                                                        stringArray[5], stringArray[6], stringArray[7], stringArray[8], stringArray[9], stringArray[10]));

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
