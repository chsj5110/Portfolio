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
    public partial class Form7OrderSet : Form
    {

        FormWork formwork = new FormWork();
        public Form7OrderSet()
        {
            InitializeComponent();
            LoadData_OrderLV(PV.DataPath + @"\ListView_Order.txt");

        }
        public Form7_1 form7_1;

        public void LoadData_OrderLV(string fileName)

        {
            using (TextReader tReader = new StreamReader(fileName))
            {
                string[] stringLines = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                foreach (string stringLine in stringLines)

                {
                    int OKNo = 0;
                    if (stringLine != string.Empty)
                    {
                        
                        string[] stringArray = stringLine.Split(';');
                        ListViewItem lviary = new ListViewItem(stringArray[0]);

                        PV.List_Order = new string[6];
                        PV.List_Order[1] = stringArray[0].ToString();
                        PV.List_Order[2] = stringArray[1].ToString();
                        PV.List_Order[3] = stringArray[2].ToString();
                        PV.List_Order[4] = stringArray[3].ToString();
                        PV.List_Order[5] = stringArray[4].ToString();
                             // 진행상태

                        

                        ListViewItem lvi = new ListViewItem(PV.List_Order);
                        lv7.Items.Add(lvi);

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
                foreach (ListViewItem item in lv7.Items)
                {
                    // 원하는 형태의 문자열로 한줄씩 기록합니다.
                    tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4}", item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text, item.SubItems[5].Text));

                }

            }

        }

        private void bt_7_Apply_Click(object sender, EventArgs e)
        {
            string str7Type = tb_7_Type.Text;
            string str7No = tb_7_No.Text;
            string str7Amount = tb_7_Amount.Text;
            string str7Date = tb_7_Date.Text;
            string str7Use = tb_7_Use.Text;


            if (str7Type == "")
            {
                MessageBox.Show("차종을 정확히 입력하세요");
                return;
            }

            if (str7No == "")
            {
                MessageBox.Show("발주번호를 정확히 입력하세요");
                return;
            }
            if (str7Amount == "")
            {
                MessageBox.Show("발주수량을 정확히 입력하세요");
                return;
            }
            if (str7Date == "")
            {
                MessageBox.Show("납기일을 정확히 입력하세요");
                return;
            }
            if (str7Use == "")
            {
                MessageBox.Show("용도를 정확히 입력하세요");
                return;
            }

            string[] strs = new string[7];
            strs[1] = str7Type;
            strs[2] = str7No;
            strs[3] = str7Amount;
            strs[4] = str7Date;
            strs[5] = str7Use;
            strs[6] = "0";

            ListViewItem lvi = new ListViewItem(strs);
            lv7.Items.Add(lvi);
            ClearInputControl();


            SaveData(PV.DataPath + "\\ListView_Order.txt");
        }

        private void bt_7_Modify_Click(object sender, EventArgs e)
        {
            bool chkboxSelected = lv7.CheckedItems.Count > 0;
            if (chkboxSelected == false)
            {
                MessageBox.Show("항목 중 하나를 선택하십시오");
                return;
            }

            ListViewItem lvi = lv7.CheckedItems[0];
            string str7Type = tb_7_Type.Text;
            string str7No = tb_7_No.Text;
            string str7Amount = tb_7_Amount.Text;
            string str7Date = tb_7_Date.Text;
            string str7Use = tb_7_Use.Text;


            if (str7Type == "")
            {
                MessageBox.Show("수정하실 차종을 정확히 입력하세요");
                return;
            }

            if (str7No == "")
            {
                MessageBox.Show("수정하실 발주번호를 정확히 입력하세요");
                return;
            }
            if (str7Amount == "")
            {
                MessageBox.Show("수정하실 발주수량을 정확히 입력하세요");
                return;
            }
            if (str7Date == "")
            {
                MessageBox.Show("수정하실 납기일을 정확히 입력하세요");
                return;
            }
            if (str7Use == "")
            {
                MessageBox.Show("수정하실 용도를 정확히 입력하세요");
                return;
            }

            lvi.SubItems[1].Text = str7Type;
            lvi.SubItems[2].Text = str7No;
            lvi.SubItems[3].Text = str7Amount;
            lvi.SubItems[4].Text = str7Date;
            lvi.SubItems[5].Text = str7Use;

            StreamWriter sw = new StreamWriter(PV.DataPath + "\\ListView_Order.txt", false);
            sw.Close();
            SaveData(PV.DataPath + "\\ListView_Order.txt");

            PF.LogWriter("오더 수정", "발주 번호 :" + lvi.SubItems[2].Text);

            MessageBox.Show(str7No + "의 수정이 완료 되었습니다.");
            ClearInputControl();
        }

        private void bt_7_Delete_Click(object sender, EventArgs e)
        {
            bool chkboxSelected = lv7.CheckedItems.Count > 0;
            if (chkboxSelected == false)
            {
                MessageBox.Show("항목 중 하나를 선택하십시오");
                return;
            }

            if (MessageBox.Show("정말로 목록을 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ListViewItem lvi = lv7.CheckedItems[0];
                lv7.Items.Remove(lv7.CheckedItems[0]);

                StreamWriter sw = new StreamWriter(PV.DataPath + "\\ListView_Order.txt", false);
                sw.Close();
                SaveData(PV.DataPath + "\\ListView_Order.txt");
                PF.LogWriter("오더 삭제", "발주 번호 :" + lvi.SubItems[2].Text);
            }
            else
            {
                MessageBox.Show("삭제를 취소하셨습니다.");
                return;
            }


        }


        private void ClearInputControl()
        {
            tb_7_Type.Text = string.Empty;
            tb_7_No.Text = string.Empty;
            tb_7_Amount.Text = string.Empty;
            tb_7_Date.Text = string.Empty;
            tb_7_Use.Text = string.Empty;
        }


        private void lv7_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            bool b_Checked = lv7.CheckedItems.Count > 0;
            bt_7_Delete.Enabled = bt_7_Modify.Enabled = b_Checked;

            if (b_Checked == false)

            {

                ClearInputControl();

                return;

            }

            ListViewItem lvi = lv7.SelectedItems[0];

            tb_7_Type.Text = lvi.SubItems[1].Text;
            tb_7_No.Text = lvi.SubItems[2].Text;
            tb_7_Amount.Text = lvi.SubItems[3].Text;
            tb_7_Date.Text = lvi.SubItems[4].Text;
            tb_7_Use.Text = lvi.SubItems[5].Text;
            */


        }

        private void lv7_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.lv7.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.lv7.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.lv7.Items)
                    item.Checked = !value;

                this.lv7.Invalidate();
            }
        }

        private void lv7_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv7_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv7_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }


        private void tb_7_Type_Click(object sender, EventArgs e)
        {
            tb_7_No.Focus();
            Form7_1 form7_1 = new Form7_1();
            form7_1.form7 = this;
            form7_1.ShowDialog();

            tb_7_No.Focus();
        }

        private void lv7_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            lv7.ItemChecked -= lv7_ItemChecked;
            foreach (var item in lv7.CheckedItems)
            {
                if (e.Item != item)
                {
                    ((ListViewItem)item).Checked = false;

                }

            }
            lv7.ItemChecked += lv7_ItemChecked;

        }

        private void lv7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = lv7.CheckedItems[0];

            tb_7_Type.Text = lvi.SubItems[1].Text;
            tb_7_No.Text = lvi.SubItems[2].Text;
            tb_7_Amount.Text = lvi.SubItems[3].Text;
            tb_7_Date.Text = lvi.SubItems[4].Text;
            tb_7_Use.Text = lvi.SubItems[5].Text;
        }
    }
}
