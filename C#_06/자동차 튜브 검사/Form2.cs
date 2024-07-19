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
    public partial class Form2 : Form
    {

        public MainForm MainForm;
        Form3 form3 = null;
        Library lib = new Library();


        public Form2()
        {
            InitializeComponent();
        }

        private void bt_back2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveData_Bypass(string fileName)

        {
            // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))

            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4}", Inner_Geometry_Bypass.Checked, Outer_Geometry_Bypass.Checked, GetBlobs_Area_Bypass.Checked, Inner_Radius_Bypass.Checked, Outer_Radius_Bypass.Checked));
            }

        }

        private void SaveData_Setting(string fileName)

        {
            // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))

            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}", Inner_Geometry_Min.Text,
                    Inner_Geometry_Max.Text, Outer_Geometry_Min.Text, Outer_Geometry_Max.Text, GetBlobs_Area_Min.Text, GetBlobs_Area_Max.Text, Inner_Radius_Min.Text, Inner_Radius_Max.Text ,Outer_Radius_Min.Text, Outer_Radius_Max.Text));
            }

        }

        private void SaveData_Offset(string fileName)

        {
            // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))

            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1};{2};{3};{4}", Inner_Geometry_Offset.Text, Outer_Geometry_Offset.Text, GetBlobs_Area_Offset.Text, Inner_Radius_Offset.Text, Outer_Radius_Offset.Text));
            }

        }

        private void SaveData_Calib(string fileName)

        {
            // StreamWriter를 이용하여 문자작성기를 생성합니다.
            using (TextWriter tWriter = new StreamWriter(fileName))

            {
                // 원하는 형태의 문자열로 한줄씩 기록합니다.
                tWriter.WriteLine(string.Format("{0};{1}", Calib_Inner_Radius.Text, Calib_Outer_Radius.Text));
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //Cam2

            //setting
            Inner_Geometry_Min.Text = String.Format("{0:0.000}", PV.Inner_Geometry_Min);
            Inner_Geometry_Max.Text = String.Format("{0:0.000}", PV.Inner_Geometry_Max);
            Outer_Geometry_Min.Text = String.Format("{0:0.000}", PV.Outer_Geometry_Min);
            Outer_Geometry_Max.Text = String.Format("{0:0.000}", PV.Outer_Geometry_Max);
            GetBlobs_Area_Min.Text = String.Format("{0:0.000}", PV.GetBlobs_Area_Min);
            GetBlobs_Area_Max.Text = String.Format("{0:0.000}", PV.GetBlobs_Area_Max);
            Inner_Radius_Min.Text = String.Format("{0:0.000}", PV.Inner_Radius_Min);
            Inner_Radius_Max.Text = String.Format("{0:0.000}", PV.Inner_Radius_Max);
            Outer_Radius_Min.Text = String.Format("{0:0.000}", PV.Outer_Radius_Min);
            Outer_Radius_Max.Text = String.Format("{0:0.000}", PV.Outer_Radius_Max);

            //bypass
            Inner_Geometry_Bypass.Checked = PV.bInner_Geometry;
            Outer_Geometry_Bypass.Checked = PV.bOuter_Geometry;
            GetBlobs_Area_Bypass.Checked = PV.bGetBlobs_Area;
            Inner_Radius_Bypass.Checked = PV.bInner_Radius;
            Outer_Radius_Bypass.Checked = PV.bOuter_Radius;

            //result
            Inner_Geometry_Result.Text = PV.Inner_Geometry;
            Outer_Geometry_Result.Text = PV.Outer_Geometry;
            GetBlobs_Area_Result.Text = PV.GetBlobs_Area;
            Inner_Radius_Result.Text = PV.Inner_Radius;
            Outer_Radius_Result.Text = PV.Outer_Radius;

            //offset
            Inner_Geometry_Offset.Text = String.Format("{0:0.000}", PV.Inner_Geometry_Offset);
            Outer_Geometry_Offset.Text = String.Format("{0:0.000}", PV.Outer_Geometry_Offset);
            GetBlobs_Area_Offset.Text = String.Format("{0:0.000}", PV.GetBlobs_Area_Offset);
            Inner_Radius_Offset.Text = String.Format("{0:0.000}", PV.Inner_Radius_Offset);
            Outer_Radius_Offset.Text = String.Format("{0:0.000}", PV.Outer_Radius_Offset);

            //calibration
            Calib_Inner_Radius.Text = String.Format("{0:0.000000}", PV.Calib_Inner_Radius);
            Calib_Outer_Radius.Text = String.Format("{0:0.000000}", PV.Calib_Outer_Radius);

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkblank();

            if (PV.nModel == 0)
            {
                MessageBox.Show("모델을 선택하세요");
                return;
            }
            else if (PV.nModel == 1)
            {
                StreamWriter sw = new StreamWriter(PV.DataFile + "\\Bypass2_1.txt", false);
                sw.Close();
                SaveData_Bypass(PV.DataFile + "\\Bypass2_1.txt");

                StreamWriter sw1 = new StreamWriter(PV.DataFile + "\\Setting2_1.txt", false);
                sw1.Close();
                SaveData_Setting(PV.DataFile + "\\Setting2_1.txt");

                StreamWriter sw2 = new StreamWriter(PV.DataFile + "\\Offset2_1.txt", false);
                sw2.Close();
                SaveData_Offset(PV.DataFile + "\\Offset2_1.txt");

                StreamWriter sw3 = new StreamWriter(PV.DataFile + "\\Calib2_1.txt", false);
                sw3.Close();
                SaveData_Calib(PV.DataFile + "\\Calib2_1.txt");

                PF.LaodData_Setting2(PV.DataFile + "\\Setting2_1.txt");
                PF.LaodData_Bypass2(PV.DataFile + "\\Bypass2_1.txt");
                PF.LaodData_Offset2(PV.DataFile + "\\Offset2_1.txt");
                PF.LaodData_Calib2(PV.DataFile + "\\Calib2_1.txt");
            }
            else if (PV.nModel == 2)
            {
                StreamWriter sw = new StreamWriter(PV.DataFile + "\\Bypass2_2.txt", false);
                sw.Close();
                SaveData_Bypass(PV.DataFile + "\\Bypass2_2.txt");

                StreamWriter sw1 = new StreamWriter(PV.DataFile + "\\Setting2_2.txt", false);
                sw1.Close();
                SaveData_Setting(PV.DataFile + "\\Setting2_2.txt");

                StreamWriter sw2 = new StreamWriter(PV.DataFile + "\\Offset2_2.txt", false);
                sw2.Close();
                SaveData_Offset(PV.DataFile + "\\Offset2_2.txt");

                StreamWriter sw3 = new StreamWriter(PV.DataFile + "\\Calib2_2.txt", false);
                sw3.Close();
                SaveData_Calib(PV.DataFile + "\\Calib2_2.txt");

                PF.LaodData_Setting2(PV.DataFile + "\\Setting2_2.txt");
                PF.LaodData_Bypass2(PV.DataFile + "\\Bypass2_2.txt");
                PF.LaodData_Offset2(PV.DataFile + "\\Offset2_2.txt");
                PF.LaodData_Calib2(PV.DataFile + "\\Calib2_2.txt");
            }
            else if (PV.nModel == 3)
            {
                StreamWriter sw = new StreamWriter(PV.DataFile + "\\Bypass2_3.txt", false);
                sw.Close();
                SaveData_Bypass(PV.DataFile + "\\Bypass2_3.txt");

                StreamWriter sw1 = new StreamWriter(PV.DataFile + "\\Setting2_3.txt", false);
                sw1.Close();
                SaveData_Setting(PV.DataFile + "\\Setting2_3.txt");

                StreamWriter sw2 = new StreamWriter(PV.DataFile + "\\Offset2_3.txt", false);
                sw2.Close();
                SaveData_Offset(PV.DataFile + "\\Offset2_3.txt");

                StreamWriter sw3 = new StreamWriter(PV.DataFile + "\\Calib2_3.txt", false);
                sw3.Close();
                SaveData_Calib(PV.DataFile + "\\Calib2_3.txt");

                PF.LaodData_Setting2(PV.DataFile + "\\Setting2_3.txt");
                PF.LaodData_Bypass2(PV.DataFile + "\\Bypass2_3.txt");
                PF.LaodData_Offset2(PV.DataFile + "\\Offset2_3.txt");
                PF.LaodData_Calib2(PV.DataFile + "\\Calib2_3.txt");
            }
            else if (PV.nModel == 4)
            {
                StreamWriter sw = new StreamWriter(PV.DataFile + "\\Bypass2_4.txt", false);
                sw.Close();
                SaveData_Bypass(PV.DataFile + "\\Bypass2_4.txt");

                StreamWriter sw1 = new StreamWriter(PV.DataFile + "\\Setting2_4.txt", false);
                sw1.Close();
                SaveData_Setting(PV.DataFile + "\\Setting2_4.txt");

                StreamWriter sw2 = new StreamWriter(PV.DataFile + "\\Offset2_4.txt", false);
                sw2.Close();
                SaveData_Offset(PV.DataFile + "\\Offset2_4.txt");

                StreamWriter sw3 = new StreamWriter(PV.DataFile + "\\Calib2_4.txt", false);
                sw3.Close();
                SaveData_Calib(PV.DataFile + "\\Calib2_4.txt");

                PF.LaodData_Setting2(PV.DataFile + "\\Setting2_4.txt");
                PF.LaodData_Bypass2(PV.DataFile + "\\Bypass2_4.txt");
                PF.LaodData_Offset2(PV.DataFile + "\\Offset2_4.txt");
                PF.LaodData_Calib2(PV.DataFile + "\\Calib2_4.txt");
            }
            else if (PV.nModel == 5)
            {
                StreamWriter sw = new StreamWriter(PV.DataFile + "\\Bypass2_5.txt", false);
                sw.Close();
                SaveData_Bypass(PV.DataFile + "\\Bypass2_5.txt");

                StreamWriter sw1 = new StreamWriter(PV.DataFile + "\\Setting2_5.txt", false);
                sw1.Close();
                SaveData_Setting(PV.DataFile + "\\Setting2_5.txt");

                StreamWriter sw2 = new StreamWriter(PV.DataFile + "\\Offset2_5.txt", false);
                sw2.Close();
                SaveData_Offset(PV.DataFile + "\\Offset2_5.txt");

                StreamWriter sw3 = new StreamWriter(PV.DataFile + "\\Calib2_5.txt", false);
                sw3.Close();
                SaveData_Calib(PV.DataFile + "\\Calib2_5.txt");

                PF.LaodData_Setting2(PV.DataFile + "\\Setting2_5.txt");
                PF.LaodData_Bypass2(PV.DataFile + "\\Bypass2_5.txt");
                PF.LaodData_Offset2(PV.DataFile + "\\Offset2_5.txt");
                PF.LaodData_Calib2(PV.DataFile + "\\Calib2_5.txt");
            }

            LogWrite_Setting();
            LogWrite_Bypass();
            LogWrite_Offset();
            LogWrite_Calib();

            MainForm.listbox2_CAM2();
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

                string Path = PV.LogFile2 + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
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
                    row.Add("내형상 하한");
                    row.Add("내형상 상한");
                    row.Add("외형상 하한");
                    row.Add("외형상 상한");
                    row.Add("외형상함몰 하한");
                    row.Add("외형상함몰 상한");
                    row.Add("내경 하한");
                    row.Add("내경 상한");
                    row.Add("외경 하한");
                    row.Add("외경 상한");


                    row.Add("\r\n" + Logtime);
                    row.Add("정면");
                    row.Add("검사기준설정 - 상하한 변경");
                    row.Add(Inner_Geometry_Min.Text);
                    row.Add(Inner_Geometry_Max.Text);
                    row.Add(Outer_Geometry_Min.Text);
                    row.Add(Outer_Geometry_Max.Text);
                    row.Add(GetBlobs_Area_Min.Text);
                    row.Add(GetBlobs_Area_Max.Text);
                    row.Add(Inner_Radius_Min.Text);
                    row.Add(Inner_Radius_Max.Text);
                    row.Add(Outer_Radius_Min.Text);
                    row.Add(Outer_Radius_Max.Text);



                }
                else         // Path Exist
                {
                    row.Add("\r\n" + "날짜");
                    row.Add("위치");
                    row.Add("세팅변경");
                    row.Add("내형상 하한");
                    row.Add("내형상 상한");
                    row.Add("외형상 하한");
                    row.Add("내형상 상한");
                    row.Add("외형상함몰 하한");
                    row.Add("외형상함몰 상한");
                    row.Add("내경 하한");
                    row.Add("내경 상한");
                    row.Add("외경 하한");
                    row.Add("외경 상한");


                    row.Add("\r\n" + Logtime);
                    row.Add("정면");
                    row.Add("검사기준설정 - 상하한 변경");
                    row.Add(Inner_Geometry_Min.Text);
                    row.Add(Inner_Geometry_Max.Text);
                    row.Add(Outer_Geometry_Min.Text);
                    row.Add(Outer_Geometry_Max.Text);
                    row.Add(GetBlobs_Area_Min.Text);
                    row.Add(GetBlobs_Area_Max.Text);
                    row.Add(Inner_Radius_Min.Text);
                    row.Add(Inner_Radius_Max.Text);
                    row.Add(Outer_Radius_Min.Text);
                    row.Add(Outer_Radius_Max.Text);
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("LogWrite_Setting-Cam2", ex.Message);
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

                string Path = PV.LogFile2 + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
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
                    row.Add("내형상");
                    row.Add("외형상");
                    row.Add("외형상함몰");
                    row.Add("내경");
                    row.Add("외경");


                    row.Add("\r\n" + Logtime);
                    row.Add("정면");
                    row.Add("검사기준설정 - Bypass 변경");
                    row.Add(Inner_Geometry_Bypass.Checked.ToString());
                    row.Add(Outer_Geometry_Bypass.Checked.ToString());
                    row.Add(GetBlobs_Area_Bypass.Checked.ToString());
                    row.Add(Inner_Radius_Bypass.Checked.ToString());
                    row.Add(Outer_Radius_Bypass.Checked.ToString());



                }
                else         // Path Exist
                {
                    row.Add("날짜");
                    row.Add("위치");
                    row.Add("세팅변경");
                    row.Add("내형상");
                    row.Add("외형상");
                    row.Add("외형상함몰");
                    row.Add("내경");
                    row.Add("외경");


                    row.Add("\r\n" + Logtime);
                    row.Add("정면");
                    row.Add("검사기준설정 - Bypass 변경");
                    row.Add(Inner_Geometry_Bypass.Checked.ToString());
                    row.Add(Outer_Geometry_Bypass.Checked.ToString());
                    row.Add(GetBlobs_Area_Bypass.Checked.ToString());
                    row.Add(Inner_Radius_Bypass.Checked.ToString());
                    row.Add(Outer_Radius_Bypass.Checked.ToString());
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("LogWrite_Bypass-Cam2", ex.Message);
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

                string Path = PV.LogFile2 + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
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
                    row.Add("내형상");
                    row.Add("외형상");
                    row.Add("외형상함몰");
                    row.Add("내경");
                    row.Add("외경");


                    row.Add("\r\n" + Logtime);
                    row.Add("정면");
                    row.Add("검사기준설정 - Offset 변경");
                    row.Add(Inner_Geometry_Offset.Text);
                    row.Add(Outer_Geometry_Offset.Text);
                    row.Add(GetBlobs_Area_Offset.Text);
                    row.Add(Inner_Radius_Offset.Text);
                    row.Add(Outer_Radius_Offset.Text);

                    row.Add("\r\n" + "    ");



                }
                else         // Path Exist
                {
                    row.Add("날짜");
                    row.Add("위치");
                    row.Add("세팅변경");
                    row.Add("내형상");
                    row.Add("외형상");
                    row.Add("외형상함몰");
                    row.Add("내경");
                    row.Add("외경");


                    row.Add("\r\n" + Logtime);
                    row.Add("정면");
                    row.Add("검사기준설정 - Offset 변경");
                    row.Add(Inner_Geometry_Offset.Text);
                    row.Add(Outer_Geometry_Offset.Text);
                    row.Add(GetBlobs_Area_Offset.Text);
                    row.Add(Inner_Radius_Offset.Text);
                    row.Add(Outer_Radius_Offset.Text);


                    row.Add("\r\n" + "    ");
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("LogWrite_Offset-Cam2", ex.Message);
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

                string Path = PV.LogFile2 + DateTime.Now.Year + "-" + strMonth + "-" + strDay + "\\";
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
                    row.Add("내경");
                    row.Add("외경");
                    


                    row.Add("\r\n" + Logtime);
                    row.Add("정면");
                    row.Add("검사기준설정 - Calibration 변경");
                    row.Add(Calib_Inner_Radius.Text);
                    row.Add(Calib_Outer_Radius.Text);

                    row.Add("\r\n" + "    ");



                }
                else         // Path Exist
                {
                    row.Add("날짜");
                    row.Add("위치");
                    row.Add("세팅변경");
                    row.Add("내경");
                    row.Add("외경");



                    row.Add("\r\n" + Logtime);
                    row.Add("정면");
                    row.Add("검사기준설정 - Calibration 변경");
                    row.Add(Calib_Inner_Radius.Text);
                    row.Add(Calib_Outer_Radius.Text);


                    row.Add("\r\n" + "    ");
                }

                writer.WriteCSV(row, Path + CreateFileName);
            }
            catch (Exception ex)
            {
                PF.ExceptionWriter("LogWrite_Calibration-Cam2", ex.Message);
            }
        }

        private void bt_SetCam2_Click(object sender, EventArgs e)
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
                    form3 = new Form3(PV.CAMERA2_1PATH);
                    form3.ShowDialog();
                }
                else if (PV.nModel == 2)
                {
                    form3 = new Form3(PV.CAMERA2_2PATH);
                    form3.ShowDialog();
                }
                else if (PV.nModel == 3)
                {
                    form3 = new Form3(PV.CAMERA2_3PATH);
                    form3.ShowDialog();
                }
                else if (PV.nModel == 4)
                {
                    form3 = new Form3(PV.CAMERA2_4PATH);
                    form3.ShowDialog();
                }
                else if (PV.nModel == 5)
                {
                    form3 = new Form3(PV.CAMERA2_5PATH);
                    form3.ShowDialog();
                }
            }
            else
            {
                form3.Activate();
            }

            string Logtime = lib.getTime("YYMMDD");
            MainForm.listBox2.Items.Insert(0, "[Time] : " + Logtime + " [State] : " + "CAM2 JOB SETTING ");
            PF.SystemDataLogWriter("CAM2 JOB SETTING");
        }

        void checkblank()
        {
            
            if (Inner_Geometry_Min.Text == "")
            {
                Inner_Geometry_Min.Text = "0.000";
            }
            if (Inner_Geometry_Max.Text == "")
            {
                Inner_Geometry_Max.Text = "0.000";
            }
            if (Outer_Geometry_Min.Text == "")
            {
                Outer_Geometry_Min.Text = "0.000";
            }
            if (Outer_Geometry_Max.Text == "")
            {
                Outer_Geometry_Max.Text = "0.000";
            }

            if (GetBlobs_Area_Min.Text == "")
            {
                GetBlobs_Area_Min.Text = "0.000";
            }
            if (GetBlobs_Area_Max.Text == "")
            {
                GetBlobs_Area_Max.Text = "0.000";
            }
            

            //offset

            if (Inner_Geometry_Offset.Text == "")
            {
                Inner_Geometry_Offset.Text = "0.000";
            }
            if (Outer_Geometry_Offset.Text == "")
            {
                Outer_Geometry_Offset.Text = "0.000";
            }
            if (GetBlobs_Area_Offset.Text == "")
            {
                GetBlobs_Area_Offset.Text = "0.000";
            }


            //calibration
            if (Calib_Inner_Radius.Text == "")
            {
                Calib_Inner_Radius.Text = "1";
            }
            if (Calib_Outer_Radius.Text == "")
            {
                Calib_Outer_Radius.Text = "1";
            }


        }
    }
}
