using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chsj
{
    class LoginHandler
    {
        Form2Login form2 = new Form2Login();
        string ListViewFile = @"D:\VisionProgram\";
        

        public bool LoginCheck(string Name, string PW,string CompName, string CompPW)
        {
            if (Name.Equals(CompName) && PW.Equals(CompPW))
            {
                form2.SaveData(ListViewFile + "\\Selected_Worker.txt", Name);
                return true;
            }
            return false;
        }
    }
}
