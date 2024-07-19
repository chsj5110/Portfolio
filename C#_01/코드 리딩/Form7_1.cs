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
    public partial class Form7_1 : Form
    {
        string ListViewFile = @"D:\VisionProgram\";
        public Form7_1()
        {
            InitializeComponent();
            LoadData(ListViewFile + "\\ListView_Type.txt");
        }
        public Form7OrderSet form7;

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

                        string[] strs = new string[2];
                        strs[1] = stringArray[0].ToString();

                        ListViewItem lvi = new ListViewItem(strs);
                        lv_71.Items.Add(lvi);
                    }
                }
            }
        }

        private void lv_71_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv_71_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv_71_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lv_71_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void lv_71_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.lv_71.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.lv_71.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.lv_71.Items)
                    item.Checked = !value;

                this.lv_71.Invalidate();
            }
        }

        public void bt_71_Click(object sender, EventArgs e)
        {
            bool chkboxSelected = lv_71.CheckedItems.Count > 0;
            if (chkboxSelected == false)
            {
                MessageBox.Show("항목 중 하나를 선택하십시오");
                return;
            }

            ListViewItem lvi = lv_71.CheckedItems[0];
            string SendType = lvi.SubItems[1].Text;
            form7.tb_7_Type.Text = SendType;
            

            this.Close();
        }

        private void lv_71_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            lv_71.ItemChecked -= lv_71_ItemChecked;
            foreach (var item in lv_71.CheckedItems)
            {
                if (e.Item != item)
                {
                    ((ListViewItem)item).Checked = false;

                }

            }
            lv_71.ItemChecked += lv_71_ItemChecked;
        }
    }
}
