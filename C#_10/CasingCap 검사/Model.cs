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
    public partial class Model : Form
    {
        public Main main;
        private string Path;
        public Model(string path)
        {
            InitializeComponent();
            cogJobManagerEdit1.LoadJobManager(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(PV.nModel == 1)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH1_1);
            }
            else if(PV.nModel == 2)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH1_2);
            }
            else if (PV.nModel == 1)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH1_3);
            }
            else if (PV.nModel == 2)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH1_4);
            }
            else
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH1_5);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PV.nModel == 1)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH2_1);
            }
            else if (PV.nModel == 2)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH2_2);
            }
            else if (PV.nModel == 1)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH2_3);
            }
            else if (PV.nModel == 2)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH2_4);
            }
            else
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH2_5);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (PV.nModel == 1)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH3_1);
            }
            else if (PV.nModel == 2)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH3_2);
            }
            else if (PV.nModel == 1)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH3_3);
            }
            else if (PV.nModel == 2)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH3_4);
            }
            else
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH3_5);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (PV.nModel == 1)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH4_1);
            }
            else if (PV.nModel == 2)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH4_2);
            }
            else if (PV.nModel == 1)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH4_3);
            }
            else if (PV.nModel == 2)
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH4_4);
            }
            else
            {
                cogJobManagerEdit1.LoadJobManager(PV.CAMERA_PATH4_5);
            }
        }
    }
}
