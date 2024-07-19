using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chsj
{
    public partial class FormW_2 : Form
    {
        public FormWork formwork;
        FormWork formw = new FormWork();

        public FormW_2()
        {

            InitializeComponent();
            

            

        }

        private void FormW_2_Load(object sender, EventArgs e)
        {
            tb_fw2_LLower.Text = PV.strLT9.ToString();

            // 중량 OK
            if (PV.strLT9 <= PV.dWeight && PV.dWeight <= PV.strLT10)
            {
                lb_fw2_Weight.ForeColor = System.Drawing.Color.LightGreen;
                lb_fw2_Weight.Text = PV.dWeight.ToString();

                PF.IOOutPutMessage("1", "1");
                PF.Delay(PV.DelayTime);
                PF.IOOutPutMessage("1", "0");
                
            }
            // 중량 NG
            else
            {
                lb_fw2_Weight.ForeColor = System.Drawing.Color.Red;
                lb_fw2_Weight.Text = PV.dWeight.ToString();

                formw.WeightNG();

                PF.IOOutPutMessage("2", "1");
                PF.Delay(PV.DelayTime);
                PF.IOOutPutMessage("2", "0");
            }

            tb_fw2_LUpper.Text = PV.strLT10.ToString();
        }
    }
}
