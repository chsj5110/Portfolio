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
        

        public bool LoginCheck(string Name, string PW,string CompName, string CompPW)
        {
            if (Name.Equals(CompName) && PW.Equals(CompPW))
            {
                PF.SaveData_SelectedWorker(PV.DataPath + @"\Selected_Worker.txt", Name);

                return true;
            }
            return false;
        }
    }
}
