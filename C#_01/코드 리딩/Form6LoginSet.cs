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
    public partial class Form6LoginSet : Form
    {
        string ListViewFile = @"D:\VisionProgram\";
        FormWork formwork = new FormWork();

        public Form6LoginSet()
        {
            InitializeComponent();
            ActiveControl = tb_6_Worker;
            LoadData(ListViewFile + "\\ListView_Login.txt");
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

                        string[] strs = new string[3];
                        strs[1] = stringArray[0].ToString();
                        strs[2] = stringArray[1].ToString();

                        ListViewItem lvi = new ListViewItem(strs);
                        lv6.Items.Add(lvi);
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
                foreach (ListViewItem item in lv6.Items)
                {
                    // 원하는 형태의 문자열로 한줄씩 기록합니다.
                    tWriter.WriteLine(string.Format("{0};{1}", item.SubItems[1].Text, item.SubItems[2].Text));

                }

            }

        }
       
        private void bt_6_Apply_Click(object sender, EventArgs e)
        {
            string str6Worker = tb_6_Worker.Text;
            string str6PW = tb_6_PW.Text;

            if (str6Worker == "")
            {
                MessageBox.Show("작업자 이름을 정확히 입력하세요");
                return;
            }
            if (str6PW == "")
            {
                MessageBox.Show("비밀번호를 정확히 입력하세요");
                return;
            }

            string[] strs = new string[3];
            strs[1] = str6Worker;
            strs[2] = str6PW;

            ListViewItem lvi = new ListViewItem(strs);
            lv6.Items.Add(lvi);
            ClearInputControl();

            StreamWriter sw = new StreamWriter(ListViewFile + "\\ListView_Login.txt", false);
            sw.Close();
            SaveData(ListViewFile + "\\ListView_Login.txt");
        }

        private void bt_6_Modify_Click(object sender, EventArgs e)
        {
            bool chkboxSelected = lv6.CheckedItems.Count > 0;
            if (chkboxSelected == false)
            {
                MessageBox.Show("항목 중 하나를 선택하십시오");
                return;
            }

            ListViewItem lvi = lv6.CheckedItems[0];
            string str6Worker = tb_6_Worker.Text;
            string str6PW = tb_6_PW.Text;

            if (str6Worker == "")
            {
                MessageBox.Show("수정하실 작업자 이름을 정확히 입력하세요");
                return;
            }
            if (str6PW == "")
            {
                MessageBox.Show("수정하실 비밀번호를 정확히 입력하세요");
                return;
            }


            lvi.SubItems[1].Text = str6Worker;
            lvi.SubItems[2].Text = str6PW;

            StreamWriter sw = new StreamWriter(ListViewFile + "\\ListView_Login.txt", false);
            sw.Close();
            SaveData(ListViewFile + "\\ListView_Login.txt");
            formwork.LogWriter("작업자 수정", str6Worker);

            MessageBox.Show(str6Worker + "의 수정이 완료 되었습니다.");

            ClearInputControl();
        }

        private void bt_6_Delete_Click(object sender, EventArgs e)
        {
            bool chkboxSelected = lv6.CheckedItems.Count > 0;
            if (chkboxSelected == false)
            {
                MessageBox.Show("항목 중 하나를 선택하십시오");
                return;
            }
            if (MessageBox.Show("정말로 목록을 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ListViewItem lvi = lv6.CheckedItems[0];
                lv6.Items.Remove(lv6.CheckedItems[0]);

                StreamWriter sw = new StreamWriter(ListViewFile + "\\ListView_Login.txt", false);
                sw.Close();
                SaveData(ListViewFile + "\\ListView_Login.txt");

                formwork.LogWriter("작업자 삭제", lvi.SubItems[1].Text);
            }
            else
            {
                MessageBox.Show("삭제를 취소하셨습니다.");
                return;
            }
            
        }

        private void lv6_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv6_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv6_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv6_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void ClearInputControl()
        {
            tb_6_Worker.Text = string.Empty;
            tb_6_PW.Text = string.Empty;
        }

        private void lv6_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.lv6.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.lv6.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.lv6.Items)
                    item.Checked = !value;

                this.lv6.Invalidate();
            }
        }

        private void bt_6_PWApply_Click(object sender, EventArgs e)
        {
            string str6AdminPW = tb_6_AdminPW.Text;

            if(str6AdminPW == "")
            {
                MessageBox.Show("비밀번호를 정확히 입력하세요");
                return;
            }

            tb_6_AdminPW.Text = string.Empty;

            StreamWriter sw = new StreamWriter(ListViewFile + "\\PASSWORD.txt", false);
            sw.Close();
            SaveData_PW(ListViewFile + "\\PASSWORD.txt", str6AdminPW);

            MessageBox.Show("설정 된 패스워드는 : " + str6AdminPW + " 입니다.");
        }

        private void SaveData_PW(string fileName, string PW)

        { using (TextWriter tWriter = new StreamWriter(fileName))

            {
                    tWriter.WriteLine(PW);

            }

        }

        private void lv6_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            lv6.ItemChecked -= lv6_ItemChecked;
            foreach (var item in lv6.CheckedItems)
            {
                if (e.Item != item)
                {
                    ((ListViewItem)item).Checked = false;

                }

            }
            lv6.ItemChecked += lv6_ItemChecked;
        }

        private void lv6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = lv6.SelectedItems[0];
            tb_6_Worker.Text = lvi.SubItems[1].Text;
            tb_6_PW.Text = lvi.SubItems[2].Text;
        }
    }
}
