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
    public partial class Form5TypeSet : Form
    {
        public string str5Type;
        FormWork formwork = new FormWork();

        public Form5TypeSet()
        {
            InitializeComponent();
            ActiveControl = tb_5_Type;
            LoadData_TypeLV(PV.DataPath + @"\ListView_Type.txt");
        }

        public void LoadData_TypeLV(string fileName)
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
                        lv5.Items.Add(lvi);
                    }
                }
            }
        }
        private void SaveData(string fileName)

        {
            // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))

            {
                // ListView의 Item을 하나씩 가져와서..
                foreach (ListViewItem item in lv5.Items)
                {
                    // 원하는 형태의 문자열로 한줄씩 기록합니다.
                    tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}", item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text
                                                                                        , item.SubItems[4].Text, item.SubItems[5].Text, item.SubItems[6].Text
                                                                                        , item.SubItems[7].Text, item.SubItems[8].Text, item.SubItems[9].Text, item.SubItems[10].Text));

                }

            }

        }

        private void bt_5_Apply_Click(object sender, EventArgs e)
        {
            string str5Type = tb_5_Type.Text;
            string str5Com = tb_5_Name.Text;
            string str5No = tb_5_Com.Text;
            string str5Name = tb_5_No.Text;
            string str5ALC = tb_5_ALC.Text;
            string str5EO = tb_5_EO.Text;
            string str5Unit = tb_5_Unit.Text;
            string str5LLower = tb_5_LLower.Text;
            string str5LUpper = tb_5_LUpper.Text;
            string b5lbp = cb_5_lb.Checked.ToString();

            if (str5Type == "")
            {
                MessageBox.Show("차종을 정확히 입력하세요");
                return;
            }
            if (str5Com == "")
            {
                MessageBox.Show("고객사를 정확히 입력하세요");
                return;
            }
            if (str5No == "")
            {
                MessageBox.Show("품번을 정확히 입력하세요");
                return;
            }
            if (str5Name == "")
            {
                MessageBox.Show("품명을 정확히 입력하세요");
                return;
            }
            if (str5ALC == "")
            {
                MessageBox.Show("ALC 코드를 정확히 입력하세요");
                return;
            }

            if (str5EO == "")
            {
                MessageBox.Show("EO NO를 정확히 입력하세요");
                return;
            }
            if (str5Unit == "")
            {
                MessageBox.Show("포장단위(EA)를 정확히 입력하세요");
                return;
            }
            if (str5LLower == "")
            {
                MessageBox.Show("중량 하한값을 정확히 입력하세요");
                return;
            }
            if (str5LUpper == "")
            {
                MessageBox.Show("중량 상한값을 정확히 입력하세요");
                return;
            }


            string[] strs = new string[12];
            strs[1] = str5Type;
            strs[2] = str5No;
            strs[3] = str5Name;
            strs[4] = str5Com;
            strs[5] = str5ALC;
            strs[6] = str5EO;
            strs[7] = str5Unit;
            strs[8] = str5LLower;
            strs[9] = str5LUpper;
            strs[10] = b5lbp;

            ListViewItem lvi = new ListViewItem(strs);
            lv5.Items.Add(lvi);
            ClearInputControl();

            SaveData(PV.DataPath + "\\ListView_Type.txt");
        }

        private void bt_5_Modify_Click(object sender, EventArgs e)
        {
            bool chkboxSelected = lv5.CheckedItems.Count > 0;
            if (chkboxSelected == false)
            {
                MessageBox.Show("항목 중 하나를 선택하십시오");
                return;
            }


            ListViewItem lvi = lv5.CheckedItems[0];
            str5Type = tb_5_Type.Text;
            string str5Com = tb_5_Name.Text;
            string str5No = tb_5_Com.Text;
            string str5Name = tb_5_No.Text;
            string str5ALC = tb_5_ALC.Text;
            string str5EO = tb_5_EO.Text;
            string str5Unit = tb_5_Unit.Text;
            string str5LLower = tb_5_LLower.Text;
            string str5LUpper = tb_5_LUpper.Text;
            string b5lbp = cb_5_lb.Checked.ToString();

            if (str5Type == "")
            {
                MessageBox.Show("수정하실 차종을 정확히 입력하세요");
                return;
            }
            if (str5Com == "")
            {
                MessageBox.Show("수정하실 고객사를 정확히 입력하세요");
                return;
            }
            if (str5No == "")
            {
                MessageBox.Show("수정하실 품번을 정확히 입력하세요");
                return;
            }
            if (str5Name == "")
            {
                MessageBox.Show("수정하실 품명을 정확히 입력하세요");
                return;
            }
            if (str5ALC == "")
            {
                MessageBox.Show("수정하실 ALC 코드를 정확히 입력하세요");
                return;
            }

            if (str5EO == "")
            {
                MessageBox.Show("수정하실 EO NO를 정확히 입력하세요");
                return;
            }
            if (str5Unit == "")
            {
                MessageBox.Show("수정하실 포장단위(EA)를 정확히 입력하세요");
                return;
            }
            if (str5LLower == "")
            {
                MessageBox.Show("수정하실 중량 하한값을 정확히 입력하세요");
                return;
            }
            if (str5LUpper == "")
            {
                MessageBox.Show("수정하실 중량 상한값을 정확히 입력하세요");
                return;
            }





            lvi.SubItems[1].Text = str5Type;
            lvi.SubItems[2].Text = str5No;
            lvi.SubItems[3].Text = str5Name;
            lvi.SubItems[4].Text = str5Com;
            lvi.SubItems[5].Text = str5ALC;
            lvi.SubItems[6].Text = str5EO;
            lvi.SubItems[7].Text = str5Unit;
            lvi.SubItems[8].Text = str5LLower;
            lvi.SubItems[9].Text = str5LUpper;
            lvi.SubItems[10].Text = b5lbp;

            StreamWriter sw = new StreamWriter(PV.DataPath + "\\ListView_Type.txt", false);
            sw.Close();
            SaveData(PV.DataPath + "\\ListView_Type.txt");
            PF.LogWriter("차종 수정", tb_5_Type.Text);


            MessageBox.Show(tb_5_Type.Text + "의 수정이 완료 되었습니다.");
            ClearInputControl();


        }

        private void bt_5_Delete_Click(object sender, EventArgs e)
        {
            bool chkboxSelected = lv5.CheckedItems.Count > 0;
            if (chkboxSelected == false)
            {
                MessageBox.Show("항목 중 하나를 선택하십시오");
                return;
            }

            if (MessageBox.Show("정말로 목록을 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ListViewItem lvi = lv5.CheckedItems[0];
                str5Type = lvi.SubItems[1].Text;
                lv5.Items.Remove(lv5.CheckedItems[0]);

                StreamWriter sw = new StreamWriter(PV.DataPath + "\\ListView_Type.txt", false);
                sw.Close();
                SaveData(PV.DataPath + "\\ListView_Type.txt");

                PF.LogWriter("차종 삭제", lvi.SubItems[1].Text);
            }
            else
            {
                MessageBox.Show("삭제를 취소하셨습니다.");
                return;
            }

        }


        public void ClearInputControl()
        {
            tb_5_Type.Text = string.Empty;
            tb_5_Name.Text = string.Empty;
            tb_5_Com.Text = string.Empty;
            tb_5_No.Text = string.Empty;
            tb_5_ALC.Text = string.Empty;
            tb_5_EO.Text = string.Empty;
            //tb_5_LOT.Text = string.Empty;
            tb_5_Unit.Text = string.Empty;
            tb_5_LLower.Text = string.Empty;
            tb_5_LUpper.Text = string.Empty;
            cb_5_lb.Checked = false;
    }

        void lv5_SelectedIndexChanged(object sender, EventArgs e)

        {

        }



        private void lv5_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv5_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv5_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv5_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.lv5.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.lv5.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.lv5.Items)
                    item.Checked = !value;

                this.lv5.Invalidate();
            }
        }

        private void lv5_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lv5_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            lv5.ItemChecked -= lv5_ItemChecked;
            foreach (var item in lv5.CheckedItems)
            {
                if (e.Item != item)
                {
                    ((ListViewItem)item).Checked = false;

                }

            }
            lv5.ItemChecked += lv5_ItemChecked;
        }

        private void lv5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = lv5.CheckedItems[0];

            tb_5_Type.Text = lvi.SubItems[1].Text;
            tb_5_Com.Text = lvi.SubItems[2].Text;
            tb_5_No.Text = lvi.SubItems[3].Text;
            tb_5_Name.Text = lvi.SubItems[4].Text;
            tb_5_ALC.Text = lvi.SubItems[5].Text;
            tb_5_EO.Text = lvi.SubItems[6].Text;
            tb_5_Unit.Text = lvi.SubItems[7].Text;
            tb_5_LLower.Text = lvi.SubItems[8].Text;
            tb_5_LUpper.Text = lvi.SubItems[9].Text;
            if(lvi.SubItems[10].Text == "True")
            {
                cb_5_lb.Checked = true;
            }
            else
            {
                cb_5_lb.Checked = false;
            }
        }
    }


}
