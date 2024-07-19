using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chsj
{
    class PF
    {


        public static DateTime Delay(int MS)
        {
            // Thread 와 Timer보다 효율 적으로 사용할 수 있음.
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }

        public static void ProcessKill(string processName)
        {
            Process[] process = Process.GetProcessesByName(processName);

            Process CurrentProcess = Process.GetCurrentProcess();

            foreach (Process p in process)
            {
                if (p.ProcessName == CurrentProcess.ProcessName)
                    p.Kill();
            }
        }
    }
}
