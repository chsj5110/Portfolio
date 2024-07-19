using Cognex.VisionPro;
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
    public partial class Form1 : Form
    {

        public MainForm MainForm;
        Form3 form3 = null;
        Library lib = new Library();


        public Form1()
        {
            InitializeComponent();

        }

        private void bt_back1_Click(object sender, EventArgs e)
        {
            
            this.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Cam1

            //setting
            Pattern_Result_Score_Min.Text = String.Format("{0:0.000}", PV.Pattern_Result_Score_Min);
            Pattern_Result_Score_Max.Text = String.Format("{0:0.000}", PV.Pattern_Result_Score_Max);
            Inner_Diameter_Min.Text = String.Format("{0:0.000}", PV.Inner_Diameter_Min);
            Inner_Diameter_Max.Text = String.Format("{0:0.000}", PV.Inner_Diameter_Max);
            Concentricity_Left_Distance_Min.Text = String.Format("{0:0.000}", PV.Concentricity_Left_Distance_Min);
            Concentricity_Left_Distance_Max.Text = String.Format("{0:0.000}", PV.Concentricity_Left_Distance_Max);
            Concentricity_Right_Distance_Min.Text = String.Format("{0:0.000}", PV.Concentricity_Right_Distance_Min);
            Concentricity_Right_Distance_Max.Text = String.Format("{0:0.000}", PV.Concentricity_Right_Distance_Max);
            Left_Angle_Min.Text = String.Format("{0:0.000}", PV.Left_Angle_Min);
            Left_Angle_Max.Text = String.Format("{0:0.000}", PV.Left_Angle_Max);
            Right_Angle_Min.Text = String.Format("{0:0.000}", PV.Right_Angle_Min);
            Right_Angle_Max.Text = String.Format("{0:0.000}", PV.Right_Angle_Max);

            //bypass
            Pattern_Result_Score_Bypass.Checked = PV.bPattern_Result_Score;
            Inner_Diameter_Bypass.Checked = PV.bInner_Diameter;
            Concentricity_Left_Distance_Bypass.Checked = PV.bConcentricity_Left_Distance;
            Concentricity_Right_Distance_Bypass.Checked = PV.bConcentricity_Right_Distance;
            Left_Angle_Bypass.Checked = PV.bLeft_Angle;
            Right_Angle_Bypass.Checked = PV.bRight_Angle;
            
            //result
            Pattern_Result_Score_Result.Text = PV.Pattern_Result_Score;
            Inner_Diameter_Result.Text = PV.Inner_Diameter;
            Concentricity_Left_Distance_Result.Text = PV.Concentricity_Left_Distance;
            Concentricity_Right_Distance_Result.Text = PV.Concentricity_Right_Distance;
            Left_Angle_Result.Text = PV.Left_Angle;
            Right_Angle_Result.Text = PV.Right_Angle;

            //offset
            Pattern_Result_Score_Offset.Text = String.Format("{0:0.000}", PV.Pattern_Result_Score_Offset);
            Inner_Diameter_Offset.Text = String.Format("{0:0.000}", PV.Inner_Diameter_Offset);
            Concentricity_Left_Distance_Offset.Text = String.Format("{0:0.000}", PV.Concentricity_Left_Distance_Offset);
            Concentricity_Right_Distance_Offset.Text = String.Format("{0:0.000}", PV.Concentricity_Right_Distance_Offset);
            Left_Angle_Offset.Text = String.Format("{0:0.000}", PV.Left_Angle_Offset);
            Right_Angle_Offset.Text = String.Format("{0:0.000}", PV.Right_Angle_Offset);

            //calibration
            Calib_Inner_Diameter.Text = String.Format("{0:0.000000}", PV.Calib_Inner_Diameter);
            Calib_Concentricity.Text = String.Format("{0:0.000000}", PV.Calib_Concentricity);
            Calib_Angle.Text = String.Format("{0:0.000000}", PV.Calib_Angle);


        }

        private void SaveData_Bypass(string fileName)

        {
            // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))

            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4};{5}",  Pattern_Result_Score_Bypass.Checked, Inner_Diameter_Bypass.Checked, Concentricity_Left_Distance_Bypass.Checked, Concentricity_Right_Distance_Bypass.Checked, Left_Angle_Bypass.Checked, Right_Angle_Bypass.Checked));
            }

        }

        private void SaveData_Setting(string fileName)

        {
            // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))

            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11}",  Pattern_Result_Score_Min.Text,
                    Pattern_Result_Score_Max.Text, Inner_Diameter_Min.Text, Inner_Diameter_Max.Text, Concentricity_Left_Distance_Min.Text, Concentricity_Left_Distance_Max.Text, Concentricity_Right_Distance_Min.Text, Concentricity_Right_Distance_Max.Text
                    , Left_Angle_Min.Text, Left_Angle_Max.Text, Right_Angle_Min.Text, Right_Angle_Max.Text));
            }

        }

        private void SaveData_Offset(string fileName)

        {
            // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))

            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4};{5}",  Pattern_Result_Score_Offset.Text, Inner_Diameter_Offset.Text,
                    Concentricity_Left_Distance_Offset.Text, Concentricity_Right_Distance_Offset.Text, Left_Angle_Offset.Text, Right_Angle_Offset.Text));
            }

        }
        private void SaveData_Calib(string fileName)

        {
            // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))

            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1};{2}", Calib_Inner_Diameter.Text, Calib_Concentricity.Text, Calib_Angle.Text));
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkblank();


            if (PV.nModel == 0)
            {
                MessageBox.Show("모델을 선택하세요");
                return;
            }
            else if (PV.nModel == 1)
            {
                StreamWriter sw = new StreamWriter(PV.DataFile + "\\Bypass1_1.txt", false);
                sw.Close();
                SaveData_Bypass(PV.DataFile + "\\Bypass1_1.txt");

                StreamWriter sw1 = new StreamWriter(PV.DataFile + "\\Setting1_1.txt", false);
                sw1.Close();
                SaveData_Setting(PV.DataFile + "\\Setting1_1.txt");

                StreamWriter sw2 = new StreamWriter(PV.DataFile + "\\Offset1_1.txt", false);
                sw2.Close();
                SaveData_Offset(PV.DataFile + "\\Offset1_1.txt");

                StreamWriter sw3 = new StreamWriter(PV.DataFile + "\\Calib1_1.txt", false);
                sw3.Close();
                SaveData_Calib(PV.DataFile + "\\Calib1_1.txt");

                PF.LaodData_Setting1(PV.DataFile + "\\Setting1_1.txt");
                PF.LaodData_Bypass1(PV.DataFile + "\\Bypass1_1.txt");
                PF.LaodData_Offset1(PV.DataFile + "\\Offset1_1.txt");
                PF.LaodData_Calib1(PV.DataFile + "\\Calib1_1.txt");
            }
            else if (PV.nModel == 2)
            {
                StreamWriter sw = new StreamWriter(PV.DataFile + "\\Bypass1_2.txt", false);
                sw.Close();
                SaveData_Bypass(PV.DataFile + "\\Bypass1_2.txt");

                StreamWriter sw1 = new StreamWriter(PV.DataFile + "\\Setting1_2.txt", false);
                sw1.Close();
                SaveData_Setting(PV.DataFile + "\\Setting1_2.txt");

                StreamWriter sw2 = new StreamWriter(PV.DataFile + "\\Offset1_2.txt", false);
                sw2.Close();
                SaveData_Offset(PV.DataFile + "\\Offset1_2.txt");

                StreamWriter sw3 = new StreamWriter(PV.DataFile + "\\Calib1_2.txt", false);
                sw3.Close();
                SaveData_Calib(PV.DataFile + "\\Calib1_2.txt");

                PF.LaodData_Setting1(PV.DataFile + "\\Setting1_2.txt");
                PF.LaodData_Bypass1(PV.DataFile + "\\Bypass1_2.txt");
                PF.LaodData_Offset1(PV.DataFile + "\\Offset1_2.txt");
                PF.LaodData_Calib1(PV.DataFile + "\\Calib1_2.txt");
            }
            else if (PV.nModel == 3)
            {
                StreamWriter sw = new StreamWriter(PV.DataFile + "\\Bypass1_3.txt", false);
                sw.Close();
                SaveData_Bypass(PV.DataFile + "\\Bypass1_3.txt");

                StreamWriter sw1 = new StreamWriter(PV.DataFile + "\\Setting1_3.txt", false);
                sw1.Close();
                SaveData_Setting(PV.DataFile + "\\Setting1_3.txt");

                StreamWriter sw2 = new StreamWriter(PV.DataFile + "\\Offset1_3.txt", false);
                sw2.Close();
                SaveData_Offset(PV.DataFile + "\\Offset1_3.txt");

                StreamWriter sw3 = new StreamWriter(PV.DataFile + "\\Calib1_3.txt", false);
                sw3.Close();
                SaveData_Calib(PV.DataFile + "\\Calib1_3.txt");

                PF.LaodData_Setting1(PV.DataFile + "\\Setting1_3.txt");
                PF.LaodData_Bypass1(PV.DataFile + "\\Bypass1_3.txt");
                PF.LaodData_Offset1(PV.DataFile + "\\Offset1_3.txt");
                PF.LaodData_Calib1(PV.DataFile + "\\Calib1_3.txt");
            }
            else if (PV.nModel == 4)
            {
                StreamWriter sw = new StreamWriter(PV.DataFile + "\\Bypass1_4.txt", false);
                sw.Close();
                SaveData_Bypass(PV.DataFile + "\\Bypass1_4.txt");

                StreamWriter sw1 = new StreamWriter(PV.DataFile + "\\Setting1_4.txt", false);
                sw1.Close();
                SaveData_Setting(PV.DataFile + "\\Setting1_4.txt");

                StreamWriter sw2 = new StreamWriter(PV.DataFile + "\\Offset1_4.txt", false);
                sw2.Close();
                SaveData_Offset(PV.DataFile + "\\Offset1_4.txt");

                StreamWriter sw3 = new StreamWriter(PV.DataFile + "\\Calib1_4.txt", false);
                sw3.Close();
                SaveData_Calib(PV.DataFile + "\\Calib1_4.txt");

                PF.LaodData_Setting1(PV.DataFile + "\\Setting1_4.txt");
                PF.LaodData_Bypass1(PV.DataFile + "\\Bypass1_4.txt");
                PF.LaodData_Offset1(PV.DataFile + "\\Offset1_4.txt");
                PF.LaodData_Calib1(PV.DataFile + "\\Calib1_4.txt");
            }
            else if (PV.nModel == 5)
            {
                StreamWriter sw = new StreamWriter(PV.DataFile + "\\Bypass1_5.txt", false);
                sw.Close();
                SaveData_Bypass(PV.DataFile + "\\Bypass1_5.txt");

                StreamWriter sw1 = new StreamWriter(PV.DataFile + "\\Setting1_5.txt", false);
                sw1.Close();
                SaveData_Setting(PV.DataFile + "\\Setting1_5.txt");

                StreamWriter sw2 = new StreamWriter(PV.DataFile + "\\Offset1_5.txt", false);
                sw2.Close();
                SaveData_Offset(PV.DataFile + "\\Offset1_5.txt");

                StreamWriter sw3 = new StreamWriter(PV.DataFile + "\\Calib1_5.txt", false);
                sw3.Close();
                SaveData_Calib(PV.DataFile + "\\Calib1_5.txt");

                PF.LaodData_Setting1(PV.DataFile + "\\Setting1_5.txt");
                PF.LaodData_Bypass1(PV.DataFile + "\\Bypass1_5.txt");
                PF.LaodData_Offset1(PV.DataFile + "\\Offset1_5.txt");
                PF.LaodData_Calib1(PV.DataFile + "\\Calib1_5.txt");
            }

            LogWrite_Setting();
            LogWrite_Bypass();
            LogWrite_Offset();
            LogWrite_Calib();
            

            MainForm.listbox2_CAM1();
            
        }
        void LogWrite_Setting()
        {

            try
            {
                string strMonth = DateTime.Now.Month.ToString();
                string strDay = DateTime.Now.Day.ToString();
                string strHour = DateTime.Now.Hour.ToString();
                string strMinute = DateTime.Now.Minute.ToString();
                string strSecond = DateTime.Now.Second.ToString();
                string strMilSecond = DateTime.Now.Millisecond.ToString();

                if (strMonth.Length == 1)
                    strMonth = "0" + strMonth;

                if (strDay.Length == 1)
                    strDay = "0" + strDay;

                string ErrorTime = DateTime.Now.Year + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMinute + ":" + strSecond + "-" + strMilSecond;

                string Path = PV.LogFile1 + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = lib.getTime("YYMMDD");

                

                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("\r\n" + "날짜");
                    row.Add("위치");
                    row.Add("세팅변경");
                    row.Add("형상검사 하한");
                    row.Add("형상검사 상한");
                    row.Add("내경 하한");
                    row.Add("내경 상한");
                    row.Add("동심도 왼쪽 하한");
                    row.Add("동심도 왼쪽 상한");
                    row.Add("동심도 오른쪽 하한");
                    row.Add("동심도 오른쪽 상한");
                    row.Add("각도 왼쪽 하한");
                    row.Add("각도 왼쪽 상한");
                    row.Add("각도 오른쪽 하한");
                    row.Add("각도 오른쪽 상한");


                    row.Add("\r\n" + Logtime);
                    row.Add("측면");
                    row.Add("검사기준설정 - 상하한 변경");
                    row.Add(Pattern_Result_Score_Min.Text);
                    row.Add(Pattern_Result_Score_Max.Text);
                    row.Add(Inner_Diameter_Min.Text);
                    row.Add(Inner_Diameter_Min.Text);
                    row.Add(Concentricity_Left_Distance_Min.Text);
                    row.Add(Concentricity_Left_Distance_Max.Text);
                    row.Add(Concentricity_Right_Distance_Min.Text);
                    row.Add(Concentricity_Right_Distance_Max.Text);
                    row.Add(Left_Angle_Min.Text);
                    row.Add(Left_Angle_Max.Text);
                    row.Add(Right_Angle_Min.Text);
                    row.Add(Right_Angle_Max.Text);



                }
                else         // Path Exist
                {
                    row.Add("\r\n" + "날짜");
                    row.Add("위치");
                    row.Add("세팅변경");
                    row.Add("형상검사 하한");
                    row.Add("형상검사 상한");
                    row.Add("내경 하한");
                    row.Add("내경 상한");
                    row.Add("동심도 왼쪽 하한");
                    row.Add("동심도 왼쪽 상한");
                    row.Add("동심도 오른쪽 하한");
                    row.Add("동심도 오른쪽 상한");
                    row.Add("각도 왼쪽 하한");
                    row.Add("각도 왼쪽 상한");
                    row.Add("각도 오른쪽 하한");
                    row.Add("각도 오른쪽 상한");


                    row.Add("\r\n" + Logtime);
                    row.Add("측면");
                    row.Add("검사기준설정 - 상하한 변경");
                    row.Add(Pattern_Result_Score_Min.Text);
                    row.Add(Pattern_Result_Score_Max.Text);
                    row.Add(Inner_Diameter_Min.Text);
                    row.Add(Inner_Diameter_Min.Text);
                    row.Add(Concentricity_Left_Distance_Min.Text);
                    row.Add(Concentricity_Left_Distance_Max.Text);
                    row.Add(Concentricity_Right_Distance_Min.Text);
                    row.Add(Concentricity_Right_Distance_Max.Text);
                    row.Add(Left_Angle_Min.Text);
                    row.Add(Left_Angle_Max.Text);
                    row.Add(Right_Angle_Min.Text);
                    row.Add(Right_Angle_Max.Text);
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("LogWrite_Setting-Cam1", ex.Message);
            }
        }

        void LogWrite_Bypass()
        {

            try
            {
                string strMonth = DateTime.Now.Month.ToString();
                string strDay = DateTime.Now.Day.ToString();
                string strHour = DateTime.Now.Hour.ToString();
                string strMinute = DateTime.Now.Minute.ToString();
                string strSecond = DateTime.Now.Second.ToString();
                string strMilSecond = DateTime.Now.Millisecond.ToString();

                if (strMonth.Length == 1)
                    strMonth = "0" + strMonth;

                if (strDay.Length == 1)
                    strDay = "0" + strDay;

                string ErrorTime = DateTime.Now.Year + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMinute + ":" + strSecond + "-" + strMilSecond;

                string Path = PV.LogFile1 + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = lib.getTime("YYMMDD");



                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("날짜");
                    row.Add("위치");
                    row.Add("세팅변경");
                    row.Add("형상검사");
                    row.Add("내경");
                    row.Add("동심도 왼쪽");
                    row.Add("동심도 오른쪽");
                    row.Add("각도 왼쪽");
                    row.Add("각도 오른쪽");
                    

                    row.Add("\r\n" + Logtime);
                    row.Add("측면");
                    row.Add("검사기준설정 - Bypass 변경");
                    row.Add(Pattern_Result_Score_Bypass.Checked.ToString());
                    row.Add(Inner_Diameter_Bypass.Checked.ToString());
                    row.Add(Concentricity_Left_Distance_Bypass.Checked.ToString());
                    row.Add(Concentricity_Right_Distance_Bypass.Checked.ToString());
                    row.Add(Left_Angle_Bypass.Checked.ToString());
                    row.Add(Right_Angle_Bypass.Checked.ToString());



                }
                else         // Path Exist
                {
                    row.Add("날짜");
                    row.Add("위치");
                    row.Add("세팅변경");
                    row.Add("형상검사");
                    row.Add("내경");
                    row.Add("동심도 왼쪽");
                    row.Add("동심도 오른쪽");
                    row.Add("각도 왼쪽");
                    row.Add("각도 오른쪽");


                    row.Add("\r\n" + Logtime);
                    row.Add("측면");
                    row.Add("검사기준설정 - Bypass 변경");
                    row.Add(Pattern_Result_Score_Bypass.Checked.ToString());
                    row.Add(Inner_Diameter_Bypass.Checked.ToString());
                    row.Add(Concentricity_Left_Distance_Bypass.Checked.ToString());
                    row.Add(Concentricity_Right_Distance_Bypass.Checked.ToString());
                    row.Add(Left_Angle_Bypass.Checked.ToString());
                    row.Add(Right_Angle_Bypass.Checked.ToString());
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("LogWrite_Bypass-Cam1", ex.Message);
            }
        }

        void LogWrite_Offset()
        {

            try
            {
                string strMonth = DateTime.Now.Month.ToString();
                string strDay = DateTime.Now.Day.ToString();
                string strHour = DateTime.Now.Hour.ToString();
                string strMinute = DateTime.Now.Minute.ToString();
                string strSecond = DateTime.Now.Second.ToString();
                string strMilSecond = DateTime.Now.Millisecond.ToString();

                if (strMonth.Length == 1)
                    strMonth = "0" + strMonth;

                if (strDay.Length == 1)
                    strDay = "0" + strDay;

                string ErrorTime = DateTime.Now.Year + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMinute + ":" + strSecond + "-" + strMilSecond;

                string Path = PV.LogFile1 + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = lib.getTime("YYMMDD");



                if (dir.Exists == false)
                {
                    dir.Create();
                    
                    row.Add("날짜");
                    row.Add("위치");
                    row.Add("세팅변경");
                    row.Add("형상검사");
                    row.Add("내경");
                    row.Add("동심도 왼쪽");
                    row.Add("동심도 오른쪽");
                    row.Add("각도 왼쪽");
                    row.Add("각도 오른쪽");
                    

                   
                    row.Add("\r\n" + Logtime);
                    row.Add("측면");
                    row.Add("검사기준설정 - Offset 변경");
                    row.Add(Pattern_Result_Score_Offset.Text);
                    row.Add(Inner_Diameter_Offset.Text);
                    row.Add(Concentricity_Left_Distance_Offset.Text);
                    row.Add(Concentricity_Right_Distance_Offset.Text);
                    row.Add(Left_Angle_Offset.Text);
                    row.Add(Right_Angle_Offset.Text);

                    row.Add("\r\n" + "    ");




                }
                else         // Path Exist
                {
                    row.Add("날짜");
                    row.Add("위치");
                    row.Add("세팅변경");
                    row.Add("형상검사");
                    row.Add("내경");
                    row.Add("동심도 왼쪽");
                    row.Add("동심도 오른쪽");
                    row.Add("각도 왼쪽");
                    row.Add("각도 오른쪽");



                    row.Add("\r\n" + Logtime);
                    row.Add("측면");
                    row.Add("검사기준설정 - Offset 변경");
                    row.Add(Pattern_Result_Score_Offset.Text);
                    row.Add(Inner_Diameter_Offset.Text);
                    row.Add(Concentricity_Left_Distance_Offset.Text);
                    row.Add(Concentricity_Right_Distance_Offset.Text);
                    row.Add(Left_Angle_Offset.Text);
                    row.Add(Right_Angle_Offset.Text);

                    row.Add("\r\n" + "    ");
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("LogWrite_Offset-Cam1", ex.Message);
            }
        }
        void LogWrite_Calib()
        {

            try
            {
                string strMonth = DateTime.Now.Month.ToString();
                string strDay = DateTime.Now.Day.ToString();
                string strHour = DateTime.Now.Hour.ToString();
                string strMinute = DateTime.Now.Minute.ToString();
                string strSecond = DateTime.Now.Second.ToString();
                string strMilSecond = DateTime.Now.Millisecond.ToString();

                if (strMonth.Length == 1)
                    strMonth = "0" + strMonth;

                if (strDay.Length == 1)
                    strDay = "0" + strDay;

                string ErrorTime = DateTime.Now.Year + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMinute + ":" + strSecond + "-" + strMilSecond;

                string Path = PV.LogFile1 + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
                string CreateFileName = DateTime.Now.Year + "-" + strMonth + "-" + strDay + ".csv";

                CsvFileReadWrite writer = new CsvFileReadWrite();
                CsvRow row = new CsvRow();

                DirectoryInfo dir = new DirectoryInfo(Path);

                string Logtime = lib.getTime("YYMMDD");



                if (dir.Exists == false)
                {
                    dir.Create();

                    row.Add("날짜");
                    row.Add("위치");
                    row.Add("캘리브레이션");
                    row.Add("내경");
                    row.Add("동심도");
                    row.Add("각도");



                    row.Add("\r\n" + Logtime);
                    row.Add("측면");
                    row.Add("검사기준설정 - Calibration 변경");
                    row.Add(Calib_Inner_Diameter.Text);
                    row.Add(Calib_Concentricity.Text);
                    row.Add(Calib_Angle.Text);

                    row.Add("\r\n" + "    ");




                }
                else         // Path Exist
                {
                    row.Add("날짜");
                    row.Add("위치");
                    row.Add("캘리브레이션");
                    row.Add("내경");
                    row.Add("동심도");
                    row.Add("각도");



                    row.Add("\r\n" + Logtime);
                    row.Add("측면");
                    row.Add("검사기준설정 - Calibration 변경");
                    row.Add(Calib_Inner_Diameter.Text);
                    row.Add(Calib_Concentricity.Text);
                    row.Add(Calib_Angle.Text);

                    row.Add("\r\n" + "    ");
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("LogWrite_Calibration-Cam1", ex.Message);
            }
        }



        private void bt_SetCam1_Click(object sender, EventArgs e)
        {
            

            if (form3 == null || form3.Text == "Setting")
            {
                if (PV.nModel == 0)
                {
                    MessageBox.Show("모델을 선택하세요");
                    return;
                }
                else if (PV.nModel == 1)
                {
                    form3 = new Form3(PV.CAMERA1_1PATH);
                    form3.ShowDialog();
                }
                else if (PV.nModel == 2)
                {
                    form3 = new Form3(PV.CAMERA1_2PATH);
                    form3.ShowDialog();
                }
                else if (PV.nModel == 3)
                {
                    form3 = new Form3(PV.CAMERA1_3PATH);
                    form3.ShowDialog();
                }
                else if (PV.nModel == 4)
                {
                    form3 = new Form3(PV.CAMERA1_4PATH);
                    form3.ShowDialog();
                }
                else if (PV.nModel == 5)
                {
                    form3 = new Form3(PV.CAMERA1_5PATH);
                    form3.ShowDialog();
                }
            }
            else
            {
                form3.Activate();
            }

            string Logtime = lib.getTime("YYMMDD");
            MainForm.listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "CAM1 JOB SETTING ");
            PF.SystemDataLogWriter("CAM1 JOB SETTING");
        }




        void checkblank()
        {
            if (Pattern_Result_Score_Min.Text == "")
            {
                Pattern_Result_Score_Min.Text = "0.000";
            }
            if(Pattern_Result_Score_Max.Text == "")
            {
                Pattern_Result_Score_Max.Text = "0.000";
            }

            if (Inner_Diameter_Min.Text == "")
            {
                Inner_Diameter_Min.Text = "0.000";
            }
            if (Inner_Diameter_Max.Text == "")
            {
                Inner_Diameter_Max.Text = "0.000";
            }
            if (Concentricity_Left_Distance_Min.Text == "")
            {
                Concentricity_Left_Distance_Min.Text = "0.000";
            }
            if (Concentricity_Left_Distance_Max.Text == "")
            {
                Concentricity_Left_Distance_Max.Text = "0.000";
            }

            if (Concentricity_Right_Distance_Min.Text == "")
            {
                Concentricity_Right_Distance_Min.Text = "0.000";
            }
            if (Concentricity_Right_Distance_Max.Text == "")
            {
                Concentricity_Right_Distance_Max.Text = "0.000";
            }
            if (Left_Angle_Min.Text == "")
            {
                Left_Angle_Min.Text = "0.000";
            }
            if (Left_Angle_Max.Text == "")
            {
                Left_Angle_Max.Text = "0.000";
            }
            if (Right_Angle_Min.Text == "")
            {
                Right_Angle_Min.Text = "0.000";
            }
            if (Right_Angle_Max.Text == "")
            {
                Right_Angle_Max.Text = "0.000";
            }




            //offset
            if (Pattern_Result_Score_Offset.Text == "")
            {
                Pattern_Result_Score_Offset.Text = "0.000";
            }
            if (Inner_Diameter_Offset.Text == "")
            {
                Inner_Diameter_Offset.Text = "0.000";
            }
            if (Concentricity_Left_Distance_Offset.Text == "")
            {
                Concentricity_Left_Distance_Offset.Text = "0.000";
            }
            if (Concentricity_Right_Distance_Offset.Text == "")
            {
                Concentricity_Right_Distance_Offset.Text = "0.000";
            }
            if (Left_Angle_Offset.Text == "")
            {
                Left_Angle_Offset.Text = "0.000";
            }
            if (Right_Angle_Offset.Text == "")
            {
                Right_Angle_Offset.Text = "0.000";
            }



            //calibration
            if (Calib_Inner_Diameter.Text == "")
            {
                Calib_Inner_Diameter.Text = "1";
            }
            if (Calib_Concentricity.Text == "")
            {
                Calib_Concentricity.Text = "1";
            }
            if (Calib_Angle.Text == "")
            {
                Calib_Angle.Text = "1";
            }


        }
    }
}
