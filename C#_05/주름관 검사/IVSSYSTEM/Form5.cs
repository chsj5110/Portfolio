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
    public partial class Form5 : Form
    {
        private string Path;
        public Form5(string path)
        {
            Path = path;
            InitializeComponent();
            cogJobManagerEdit1.LoadJobManager(Path);
        }
        
    }
}
