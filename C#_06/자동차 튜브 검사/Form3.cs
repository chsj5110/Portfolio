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
    public partial class Form3 : Form
    {
        public MainForm MainForm;
        private string Path;
        public Form3(string path)
        {
            Path = path;
            InitializeComponent();
            cogJobManagerEdit1.LoadJobManager(Path);
        }

        public void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.CAMERA1_Job != null && MainForm.CAMERA1_JobManager != null)
            {
                MainForm.CAMERA1_Job.Reset();
                MainForm.CAMERA1_JobManager.Reset();
            }
            if (MainForm.CAMERA2_Job != null && MainForm.CAMERA2_JobManager != null)
            {
                MainForm.CAMERA2_Job.Reset();
                MainForm.CAMERA2_JobManager.Reset();
            }
        }
    }
}
