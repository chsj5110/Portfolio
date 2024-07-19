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
        public Form8LOT()
        {
            InitializeComponent();
            PF.LoadData_LOT(PV.DataPath + "\\Selected_LOT.txt");
            tb_8_LOT.Text = PV.sLOT;
        }



        private void bt_8_Select_Click(object sender, EventArgs e)
        {
            PV.sLOT = tb_8_LOT.Text;
            SaveData(PV.DataPath + "\\Selected_LOT.txt", PV.sLOT);
            MainForm.lb_m_LOT.Text = PV.sLOT;
            this.Close();
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
