using System;

namespace chsj
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblCam2TestResult = new System.Windows.Forms.Label();
            this.lblCam1TestResult = new System.Windows.Forms.Label();
            this.cogRecordDisplay2 = new Cognex.VisionPro.CogRecordDisplay();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.cbNG_Save = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_CAMERA2_Result = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cogRecordDisplay_CAMERA2 = new Cognex.VisionPro.CogRecordDisplay();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_CAMERA1_Result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_LotNo = new System.Windows.Forms.TextBox();
            this.num_DelayTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRunningStop = new System.Windows.Forms.Button();
            this.btnRunningExecute = new System.Windows.Forms.Button();
            this.btn_DelayTime = new System.Windows.Forms.Button();
            this.lbl_NGDelayTime = new System.Windows.Forms.Label();
            this.btn_BuzzOff = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lbl_CAM1TIME = new System.Windows.Forms.Label();
            this.lbl_CAM1TotalCount = new System.Windows.Forms.Label();
            this.cbALL_Save = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.cbNgStop = new System.Windows.Forms.CheckBox();
            this.cogRecordDisplay_CAMERA1 = new Cognex.VisionPro.CogRecordDisplay();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.bt_SetCam1 = new System.Windows.Forms.Button();
            this.bt_SetInsp1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bt_SetInsp2 = new System.Windows.Forms.Button();
            this.bt_SetCam2 = new System.Windows.Forms.Button();
            this.pic_CAM1_CONNECT_ON = new System.Windows.Forms.PictureBox();
            this.pic_CAM1_CONNECT_OFF = new System.Windows.Forms.PictureBox();
            this.lbl_CAM1PassCount = new System.Windows.Forms.Label();
            this.lbl_CAM1PassPercent = new System.Windows.Forms.Label();
            this.lbl_CAM2PassCount = new System.Windows.Forms.Label();
            this.lbl_CAM2PassPercent = new System.Windows.Forms.Label();
            this.lbl_CAM2TIME = new System.Windows.Forms.Label();
            this.lbl_CAM2TotalCount = new System.Windows.Forms.Label();
            this.pic_CAM2_CONNECT_ON = new System.Windows.Forms.PictureBox();
            this.pic_CAM2_CONNECT_OFF = new System.Windows.Forms.PictureBox();
            this.pic_CAM1_Result = new System.Windows.Forms.PictureBox();
            this.pic_CAM2_Result = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_DelayTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CAM1_CONNECT_ON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CAM1_CONNECT_OFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CAM2_CONNECT_ON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CAM2_CONNECT_OFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CAM1_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CAM2_Result)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1247, 850);
            this.tabPage1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1247, 850);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "확   인";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblCam2TestResult);
            this.panel4.Controls.Add(this.lblCam1TestResult);
            this.panel4.Controls.Add(this.cogRecordDisplay2);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.cogRecordDisplay1);
            this.panel4.Location = new System.Drawing.Point(6, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1239, 946);
            this.panel4.TabIndex = 3;
            // 
            // lblCam2TestResult
            // 
            this.lblCam2TestResult.BackColor = System.Drawing.Color.Gray;
            this.lblCam2TestResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCam2TestResult.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCam2TestResult.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblCam2TestResult.Location = new System.Drawing.Point(264, 396);
            this.lblCam2TestResult.Name = "lblCam2TestResult";
            this.lblCam2TestResult.Size = new System.Drawing.Size(146, 37);
            this.lblCam2TestResult.TabIndex = 105;
            this.lblCam2TestResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCam1TestResult
            // 
            this.lblCam1TestResult.BackColor = System.Drawing.Color.Gray;
            this.lblCam1TestResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCam1TestResult.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCam1TestResult.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblCam1TestResult.Location = new System.Drawing.Point(264, 19);
            this.lblCam1TestResult.Name = "lblCam1TestResult";
            this.lblCam1TestResult.Size = new System.Drawing.Size(146, 37);
            this.lblCam1TestResult.TabIndex = 104;
            this.lblCam1TestResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cogRecordDisplay2
            // 
            this.cogRecordDisplay2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay2.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay2.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay2.Location = new System.Drawing.Point(14, 449);
            this.cogRecordDisplay2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay2.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay2.Name = "cogRecordDisplay2";
            this.cogRecordDisplay2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay2.OcxState")));
            this.cogRecordDisplay2.Size = new System.Drawing.Size(1064, 357);
            this.cogRecordDisplay2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.RoyalBlue;
            this.label3.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(19, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 37);
            this.label3.TabIndex = 8;
            this.label3.Text = "CAM #2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
            this.label2.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(19, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 37);
            this.label2.TabIndex = 7;
            this.label2.Text = "CAM #1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cogRecordDisplay1
            // 
            this.cogRecordDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay1.Location = new System.Drawing.Point(14, 59);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(1064, 357);
            this.cogRecordDisplay1.TabIndex = 6;
            // 
            // cbNG_Save
            // 
            this.cbNG_Save.AutoSize = true;
            this.cbNG_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(80)))), ((int)(((byte)(204)))));
            this.cbNG_Save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNG_Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cbNG_Save.Location = new System.Drawing.Point(542, 75);
            this.cbNG_Save.Name = "cbNG_Save";
            this.cbNG_Save.Size = new System.Drawing.Size(120, 23);
            this.cbNG_Save.TabIndex = 13;
            this.cbNG_Save.Text = "NG 이미지 저장";
            this.cbNG_Save.UseVisualStyleBackColor = false;
            this.cbNG_Save.CheckedChanged += new System.EventHandler(this.cbNG_Save_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel3.Controls.Add(this.lbl_CAMERA2_Result);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(4, 359);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1230, 326);
            this.panel3.TabIndex = 12;
            // 
            // lbl_CAMERA2_Result
            // 
            this.lbl_CAMERA2_Result.BackColor = System.Drawing.Color.Gray;
            this.lbl_CAMERA2_Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_CAMERA2_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CAMERA2_Result.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbl_CAMERA2_Result.Location = new System.Drawing.Point(7, 48);
            this.lbl_CAMERA2_Result.Name = "lbl_CAMERA2_Result";
            this.lbl_CAMERA2_Result.Size = new System.Drawing.Size(214, 115);
            this.lbl_CAMERA2_Result.TabIndex = 7;
            this.lbl_CAMERA2_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.RoyalBlue;
            this.label5.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.Location = new System.Drawing.Point(7, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 37);
            this.label5.TabIndex = 0;
            this.label5.Text = "CAM #2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cogRecordDisplay_CAMERA2
            // 
            this.cogRecordDisplay_CAMERA2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA2.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay_CAMERA2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay_CAMERA2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA2.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay_CAMERA2.Location = new System.Drawing.Point(998, 209);
            this.cogRecordDisplay_CAMERA2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay_CAMERA2.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay_CAMERA2.Name = "cogRecordDisplay_CAMERA2";
            this.cogRecordDisplay_CAMERA2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay_CAMERA2.OcxState")));
            this.cogRecordDisplay_CAMERA2.Size = new System.Drawing.Size(500, 418);
            this.cogRecordDisplay_CAMERA2.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.Controls.Add(this.lbl_CAMERA1_Result);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(4, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1230, 326);
            this.panel2.TabIndex = 11;
            // 
            // lbl_CAMERA1_Result
            // 
            this.lbl_CAMERA1_Result.BackColor = System.Drawing.Color.Gray;
            this.lbl_CAMERA1_Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_CAMERA1_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CAMERA1_Result.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbl_CAMERA1_Result.Location = new System.Drawing.Point(8, 49);
            this.lbl_CAMERA1_Result.Name = "lbl_CAMERA1_Result";
            this.lbl_CAMERA1_Result.Size = new System.Drawing.Size(214, 115);
            this.lbl_CAMERA1_Result.TabIndex = 6;
            this.lbl_CAMERA1_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 0;
            // 
            // txt_LotNo
            // 
            this.txt_LotNo.Location = new System.Drawing.Point(0, 0);
            this.txt_LotNo.Name = "txt_LotNo";
            this.txt_LotNo.Size = new System.Drawing.Size(100, 21);
            this.txt_LotNo.TabIndex = 0;
            // 
            // num_DelayTime
            // 
            this.num_DelayTime.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num_DelayTime.Location = new System.Drawing.Point(687, 54);
            this.num_DelayTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_DelayTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_DelayTime.Name = "num_DelayTime";
            this.num_DelayTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.num_DelayTime.Size = new System.Drawing.Size(83, 26);
            this.num_DelayTime.TabIndex = 30;
            this.num_DelayTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_DelayTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_DelayTime.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.GrayText;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(776, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "ms";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // btnRunningStop
            // 
            this.btnRunningStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btnRunningStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRunningStop.BackgroundImage")));
            this.btnRunningStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRunningStop.Enabled = false;
            this.btnRunningStop.FlatAppearance.BorderSize = 0;
            this.btnRunningStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunningStop.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.btnRunningStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnRunningStop.Location = new System.Drawing.Point(1239, 43);
            this.btnRunningStop.Name = "btnRunningStop";
            this.btnRunningStop.Size = new System.Drawing.Size(216, 66);
            this.btnRunningStop.TabIndex = 15;
            this.btnRunningStop.UseVisualStyleBackColor = false;
            this.btnRunningStop.Visible = false;
            this.btnRunningStop.Click += new System.EventHandler(this.btnRunningStop_Click);
            // 
            // btnRunningExecute
            // 
            this.btnRunningExecute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btnRunningExecute.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRunningExecute.BackgroundImage")));
            this.btnRunningExecute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRunningExecute.FlatAppearance.BorderSize = 0;
            this.btnRunningExecute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunningExecute.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.btnRunningExecute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnRunningExecute.Location = new System.Drawing.Point(1239, 43);
            this.btnRunningExecute.Name = "btnRunningExecute";
            this.btnRunningExecute.Size = new System.Drawing.Size(216, 66);
            this.btnRunningExecute.TabIndex = 14;
            this.btnRunningExecute.UseVisualStyleBackColor = false;
            this.btnRunningExecute.Click += new System.EventHandler(this.btnRunningExecute_Click);
            // 
            // btn_DelayTime
            // 
            this.btn_DelayTime.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_DelayTime.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_DelayTime.Location = new System.Drawing.Point(810, 52);
            this.btn_DelayTime.Name = "btn_DelayTime";
            this.btn_DelayTime.Size = new System.Drawing.Size(63, 29);
            this.btn_DelayTime.TabIndex = 13;
            this.btn_DelayTime.Text = "적   용";
            this.btn_DelayTime.UseVisualStyleBackColor = true;
            this.btn_DelayTime.Visible = false;
            // 
            // lbl_NGDelayTime
            // 
            this.lbl_NGDelayTime.BackColor = System.Drawing.Color.RoyalBlue;
            this.lbl_NGDelayTime.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_NGDelayTime.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbl_NGDelayTime.Location = new System.Drawing.Point(687, 6);
            this.lbl_NGDelayTime.Name = "lbl_NGDelayTime";
            this.lbl_NGDelayTime.Size = new System.Drawing.Size(186, 36);
            this.lbl_NGDelayTime.TabIndex = 8;
            this.lbl_NGDelayTime.Text = "NG Delay Time";
            this.lbl_NGDelayTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_NGDelayTime.Visible = false;
            // 
            // btn_BuzzOff
            // 
            this.btn_BuzzOff.AutoSize = true;
            this.btn_BuzzOff.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BuzzOff.BackgroundImage")));
            this.btn_BuzzOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_BuzzOff.FlatAppearance.BorderSize = 0;
            this.btn_BuzzOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BuzzOff.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.btn_BuzzOff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btn_BuzzOff.Location = new System.Drawing.Point(1026, 43);
            this.btn_BuzzOff.Name = "btn_BuzzOff";
            this.btn_BuzzOff.Size = new System.Drawing.Size(216, 66);
            this.btn_BuzzOff.TabIndex = 50;
            this.btn_BuzzOff.UseVisualStyleBackColor = false;
            this.btn_BuzzOff.Click += new System.EventHandler(this.btn_BuzzOff_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lbl_CAM1TIME
            // 
            this.lbl_CAM1TIME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.lbl_CAM1TIME.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_CAM1TIME.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.lbl_CAM1TIME.Location = new System.Drawing.Point(731, 373);
            this.lbl_CAM1TIME.Name = "lbl_CAM1TIME";
            this.lbl_CAM1TIME.Size = new System.Drawing.Size(191, 30);
            this.lbl_CAM1TIME.TabIndex = 24;
            this.lbl_CAM1TIME.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CAM1TotalCount
            // 
            this.lbl_CAM1TotalCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.lbl_CAM1TotalCount.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_CAM1TotalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.lbl_CAM1TotalCount.Location = new System.Drawing.Point(731, 461);
            this.lbl_CAM1TotalCount.Name = "lbl_CAM1TotalCount";
            this.lbl_CAM1TotalCount.Size = new System.Drawing.Size(191, 30);
            this.lbl_CAM1TotalCount.TabIndex = 24;
            this.lbl_CAM1TotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbALL_Save
            // 
            this.cbALL_Save.AutoSize = true;
            this.cbALL_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(80)))), ((int)(((byte)(204)))));
            this.cbALL_Save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbALL_Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cbALL_Save.Location = new System.Drawing.Point(681, 75);
            this.cbALL_Save.Name = "cbALL_Save";
            this.cbALL_Save.Size = new System.Drawing.Size(148, 23);
            this.cbALL_Save.TabIndex = 71;
            this.cbALL_Save.Text = "검사 이미지 모두 저장";
            this.cbALL_Save.UseVisualStyleBackColor = false;
            this.cbALL_Save.CheckedChanged += new System.EventHandler(this.cbALL_Save_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnExit.Location = new System.Drawing.Point(1665, 43);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(216, 66);
            this.btnExit.TabIndex = 72;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 500;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // cbNgStop
            // 
            this.cbNgStop.AutoSize = true;
            this.cbNgStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(80)))), ((int)(((byte)(204)))));
            this.cbNgStop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNgStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cbNgStop.Location = new System.Drawing.Point(851, 75);
            this.cbNgStop.Name = "cbNgStop";
            this.cbNgStop.Size = new System.Drawing.Size(92, 23);
            this.cbNgStop.TabIndex = 73;
            this.cbNgStop.Text = "NG시 멈춤";
            this.cbNgStop.UseVisualStyleBackColor = false;
            this.cbNgStop.CheckedChanged += new System.EventHandler(this.cbNgStop_CheckedChanged);
            // 
            // cogRecordDisplay_CAMERA1
            // 
            this.cogRecordDisplay_CAMERA1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay_CAMERA1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay_CAMERA1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay_CAMERA1.Location = new System.Drawing.Point(64, 209);
            this.cogRecordDisplay_CAMERA1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay_CAMERA1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay_CAMERA1.Name = "cogRecordDisplay_CAMERA1";
            this.cogRecordDisplay_CAMERA1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay_CAMERA1.OcxState")));
            this.cogRecordDisplay_CAMERA1.Size = new System.Drawing.Size(500, 418);
            this.cogRecordDisplay_CAMERA1.TabIndex = 5;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(64, 763);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(858, 210);
            this.listBox1.TabIndex = 76;
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(998, 763);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(858, 210);
            this.listBox2.TabIndex = 77;
            // 
            // bt_SetCam1
            // 
            this.bt_SetCam1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.bt_SetCam1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_SetCam1.BackgroundImage")));
            this.bt_SetCam1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bt_SetCam1.FlatAppearance.BorderSize = 0;
            this.bt_SetCam1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_SetCam1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.bt_SetCam1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.bt_SetCam1.Location = new System.Drawing.Point(584, 210);
            this.bt_SetCam1.Name = "bt_SetCam1";
            this.bt_SetCam1.Size = new System.Drawing.Size(340, 66);
            this.bt_SetCam1.TabIndex = 78;
            this.bt_SetCam1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_SetCam1.UseVisualStyleBackColor = false;
            this.bt_SetCam1.Click += new System.EventHandler(this.bt_SetCam1_Click);
            // 
            // bt_SetInsp1
            // 
            this.bt_SetInsp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.bt_SetInsp1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_SetInsp1.BackgroundImage")));
            this.bt_SetInsp1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bt_SetInsp1.FlatAppearance.BorderSize = 0;
            this.bt_SetInsp1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_SetInsp1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.bt_SetInsp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.bt_SetInsp1.Location = new System.Drawing.Point(584, 282);
            this.bt_SetInsp1.Name = "bt_SetInsp1";
            this.bt_SetInsp1.Size = new System.Drawing.Size(340, 66);
            this.bt_SetInsp1.TabIndex = 79;
            this.bt_SetInsp1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_SetInsp1.UseVisualStyleBackColor = false;
            this.bt_SetInsp1.Click += new System.EventHandler(this.bt_SetInsp1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label8.Location = new System.Drawing.Point(744, 309);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 15);
            this.label8.TabIndex = 80;
            this.label8.Text = "(외경, 내경, 동심도, 각도)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label9.Location = new System.Drawing.Point(1677, 309);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 15);
            this.label9.TabIndex = 83;
            this.label9.Text = "(내형상, 외형상, 외형상함몰)";
            // 
            // bt_SetInsp2
            // 
            this.bt_SetInsp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.bt_SetInsp2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_SetInsp2.BackgroundImage")));
            this.bt_SetInsp2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bt_SetInsp2.FlatAppearance.BorderSize = 0;
            this.bt_SetInsp2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_SetInsp2.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.bt_SetInsp2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.bt_SetInsp2.Location = new System.Drawing.Point(1516, 282);
            this.bt_SetInsp2.Name = "bt_SetInsp2";
            this.bt_SetInsp2.Size = new System.Drawing.Size(340, 66);
            this.bt_SetInsp2.TabIndex = 82;
            this.bt_SetInsp2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_SetInsp2.UseVisualStyleBackColor = false;
            this.bt_SetInsp2.Click += new System.EventHandler(this.bt_SetInsp2_Click);
            // 
            // bt_SetCam2
            // 
            this.bt_SetCam2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.bt_SetCam2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_SetCam2.BackgroundImage")));
            this.bt_SetCam2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bt_SetCam2.FlatAppearance.BorderSize = 0;
            this.bt_SetCam2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_SetCam2.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.bt_SetCam2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.bt_SetCam2.Location = new System.Drawing.Point(1516, 210);
            this.bt_SetCam2.Name = "bt_SetCam2";
            this.bt_SetCam2.Size = new System.Drawing.Size(340, 66);
            this.bt_SetCam2.TabIndex = 81;
            this.bt_SetCam2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_SetCam2.UseVisualStyleBackColor = false;
            this.bt_SetCam2.Click += new System.EventHandler(this.bt_SetCam2_Click);
            // 
            // pic_CAM1_CONNECT_ON
            // 
            this.pic_CAM1_CONNECT_ON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.pic_CAM1_CONNECT_ON.Image = ((System.Drawing.Image)(resources.GetObject("pic_CAM1_CONNECT_ON.Image")));
            this.pic_CAM1_CONNECT_ON.Location = new System.Drawing.Point(731, 592);
            this.pic_CAM1_CONNECT_ON.Name = "pic_CAM1_CONNECT_ON";
            this.pic_CAM1_CONNECT_ON.Size = new System.Drawing.Size(84, 30);
            this.pic_CAM1_CONNECT_ON.TabIndex = 14;
            this.pic_CAM1_CONNECT_ON.TabStop = false;
            // 
            // pic_CAM1_CONNECT_OFF
            // 
            this.pic_CAM1_CONNECT_OFF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.pic_CAM1_CONNECT_OFF.Image = ((System.Drawing.Image)(resources.GetObject("pic_CAM1_CONNECT_OFF.Image")));
            this.pic_CAM1_CONNECT_OFF.Location = new System.Drawing.Point(837, 592);
            this.pic_CAM1_CONNECT_OFF.Name = "pic_CAM1_CONNECT_OFF";
            this.pic_CAM1_CONNECT_OFF.Size = new System.Drawing.Size(84, 30);
            this.pic_CAM1_CONNECT_OFF.TabIndex = 13;
            this.pic_CAM1_CONNECT_OFF.TabStop = false;
            // 
            // lbl_CAM1PassCount
            // 
            this.lbl_CAM1PassCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.lbl_CAM1PassCount.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_CAM1PassCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.lbl_CAM1PassCount.Location = new System.Drawing.Point(731, 548);
            this.lbl_CAM1PassCount.Name = "lbl_CAM1PassCount";
            this.lbl_CAM1PassCount.Size = new System.Drawing.Size(191, 30);
            this.lbl_CAM1PassCount.TabIndex = 84;
            this.lbl_CAM1PassCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CAM1PassPercent
            // 
            this.lbl_CAM1PassPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.lbl_CAM1PassPercent.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_CAM1PassPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.lbl_CAM1PassPercent.Location = new System.Drawing.Point(731, 504);
            this.lbl_CAM1PassPercent.Name = "lbl_CAM1PassPercent";
            this.lbl_CAM1PassPercent.Size = new System.Drawing.Size(191, 30);
            this.lbl_CAM1PassPercent.TabIndex = 85;
            this.lbl_CAM1PassPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CAM2PassCount
            // 
            this.lbl_CAM2PassCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.lbl_CAM2PassCount.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_CAM2PassCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.lbl_CAM2PassCount.Location = new System.Drawing.Point(1665, 548);
            this.lbl_CAM2PassCount.Name = "lbl_CAM2PassCount";
            this.lbl_CAM2PassCount.Size = new System.Drawing.Size(191, 30);
            this.lbl_CAM2PassCount.TabIndex = 91;
            this.lbl_CAM2PassCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CAM2PassPercent
            // 
            this.lbl_CAM2PassPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.lbl_CAM2PassPercent.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_CAM2PassPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.lbl_CAM2PassPercent.Location = new System.Drawing.Point(1665, 504);
            this.lbl_CAM2PassPercent.Name = "lbl_CAM2PassPercent";
            this.lbl_CAM2PassPercent.Size = new System.Drawing.Size(191, 30);
            this.lbl_CAM2PassPercent.TabIndex = 92;
            this.lbl_CAM2PassPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CAM2TIME
            // 
            this.lbl_CAM2TIME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.lbl_CAM2TIME.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_CAM2TIME.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.lbl_CAM2TIME.Location = new System.Drawing.Point(1665, 373);
            this.lbl_CAM2TIME.Name = "lbl_CAM2TIME";
            this.lbl_CAM2TIME.Size = new System.Drawing.Size(191, 30);
            this.lbl_CAM2TIME.TabIndex = 88;
            this.lbl_CAM2TIME.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CAM2TotalCount
            // 
            this.lbl_CAM2TotalCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.lbl_CAM2TotalCount.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_CAM2TotalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.lbl_CAM2TotalCount.Location = new System.Drawing.Point(1665, 461);
            this.lbl_CAM2TotalCount.Name = "lbl_CAM2TotalCount";
            this.lbl_CAM2TotalCount.Size = new System.Drawing.Size(191, 30);
            this.lbl_CAM2TotalCount.TabIndex = 89;
            this.lbl_CAM2TotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pic_CAM2_CONNECT_ON
            // 
            this.pic_CAM2_CONNECT_ON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.pic_CAM2_CONNECT_ON.Image = ((System.Drawing.Image)(resources.GetObject("pic_CAM2_CONNECT_ON.Image")));
            this.pic_CAM2_CONNECT_ON.Location = new System.Drawing.Point(1665, 592);
            this.pic_CAM2_CONNECT_ON.Name = "pic_CAM2_CONNECT_ON";
            this.pic_CAM2_CONNECT_ON.Size = new System.Drawing.Size(84, 30);
            this.pic_CAM2_CONNECT_ON.TabIndex = 87;
            this.pic_CAM2_CONNECT_ON.TabStop = false;
            // 
            // pic_CAM2_CONNECT_OFF
            // 
            this.pic_CAM2_CONNECT_OFF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.pic_CAM2_CONNECT_OFF.Image = ((System.Drawing.Image)(resources.GetObject("pic_CAM2_CONNECT_OFF.Image")));
            this.pic_CAM2_CONNECT_OFF.Location = new System.Drawing.Point(1771, 592);
            this.pic_CAM2_CONNECT_OFF.Name = "pic_CAM2_CONNECT_OFF";
            this.pic_CAM2_CONNECT_OFF.Size = new System.Drawing.Size(84, 30);
            this.pic_CAM2_CONNECT_OFF.TabIndex = 86;
            this.pic_CAM2_CONNECT_OFF.TabStop = false;
            // 
            // pic_CAM1_Result
            // 
            this.pic_CAM1_Result.Location = new System.Drawing.Point(731, 417);
            this.pic_CAM1_Result.Name = "pic_CAM1_Result";
            this.pic_CAM1_Result.Size = new System.Drawing.Size(191, 30);
            this.pic_CAM1_Result.TabIndex = 93;
            this.pic_CAM1_Result.TabStop = false;
            // 
            // pic_CAM2_Result
            // 
            this.pic_CAM2_Result.Location = new System.Drawing.Point(1665, 417);
            this.pic_CAM2_Result.Name = "pic_CAM2_Result";
            this.pic_CAM2_Result.Size = new System.Drawing.Size(191, 30);
            this.pic_CAM2_Result.TabIndex = 94;
            this.pic_CAM2_Result.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btnReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset.BackgroundImage")));
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnReset.Location = new System.Drawing.Point(1453, 43);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(216, 66);
            this.btnReset.TabIndex = 95;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // timer4
            // 
            this.timer4.Interval = 500;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer5
            // 
            this.timer5.Interval = 10;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // timer6
            // 
            this.timer6.Interval = 10;
            this.timer6.Tick += new System.EventHandler(this.timer6_Tick);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::chsj.Properties.Resources._null;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.button1.Location = new System.Drawing.Point(385, 684);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 96;
            this.button1.Text = "Model 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::chsj.Properties.Resources._null;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.button2.Location = new System.Drawing.Point(498, 684);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 97;
            this.button2.Text = "Model 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::chsj.Properties.Resources._null;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.button3.Location = new System.Drawing.Point(611, 684);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 34);
            this.button3.TabIndex = 98;
            this.button3.Text = "Model 3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::chsj.Properties.Resources._null;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.button4.Location = new System.Drawing.Point(724, 684);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 34);
            this.button4.TabIndex = 99;
            this.button4.Text = "Model 4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::chsj.Properties.Resources._null;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.button5.Location = new System.Drawing.Point(837, 684);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 34);
            this.button5.TabIndex = 100;
            this.button5.Text = "Model 5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pic_CAM2_Result);
            this.Controls.Add(this.pic_CAM1_Result);
            this.Controls.Add(this.lbl_CAM2PassCount);
            this.Controls.Add(this.lbl_CAM2PassPercent);
            this.Controls.Add(this.lbl_CAM2TIME);
            this.Controls.Add(this.lbl_CAM2TotalCount);
            this.Controls.Add(this.pic_CAM2_CONNECT_ON);
            this.Controls.Add(this.pic_CAM2_CONNECT_OFF);
            this.Controls.Add(this.lbl_CAM1PassCount);
            this.Controls.Add(this.lbl_CAM1PassPercent);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bt_SetInsp2);
            this.Controls.Add(this.bt_SetCam2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bt_SetInsp1);
            this.Controls.Add(this.bt_SetCam1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cbNgStop);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btn_BuzzOff);
            this.Controls.Add(this.cbALL_Save);
            this.Controls.Add(this.lbl_CAM1TIME);
            this.Controls.Add(this.cbNG_Save);
            this.Controls.Add(this.btnRunningExecute);
            this.Controls.Add(this.btnRunningStop);
            this.Controls.Add(this.lbl_CAM1TotalCount);
            this.Controls.Add(this.pic_CAM1_CONNECT_ON);
            this.Controls.Add(this.pic_CAM1_CONNECT_OFF);
            this.Controls.Add(this.cogRecordDisplay_CAMERA1);
            this.Controls.Add(this.cogRecordDisplay_CAMERA2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.RightToLeftLayout = true;
            this.Text = "Inspection Vision System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_DelayTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CAM1_CONNECT_ON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CAM1_CONNECT_OFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CAM2_CONNECT_ON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CAM2_CONNECT_OFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CAM1_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CAM2_Result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_CAMERA2_Result;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay_CAMERA2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_CAMERA1_Result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_DelayTime;
        private System.Windows.Forms.Label lbl_NGDelayTime;
        private System.Windows.Forms.Button btnRunningStop;
        private System.Windows.Forms.Button btnRunningExecute;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Button btn_BuzzOff;
        private System.Windows.Forms.NumericUpDown num_DelayTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox cbNG_Save;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel4;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_LotNo;
        private System.Windows.Forms.Label lblCam1TestResult;
        private System.Windows.Forms.Label lblCam2TestResult;
        private System.Windows.Forms.Label lbl_CAM1TIME;
        private System.Windows.Forms.Label lbl_CAM1TotalCount;
        private System.Windows.Forms.CheckBox cbALL_Save;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.CheckBox cbNgStop;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay_CAMERA1;
        private System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button bt_SetCam1;
        private System.Windows.Forms.Button bt_SetInsp1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bt_SetInsp2;
        private System.Windows.Forms.Button bt_SetCam2;
        private System.Windows.Forms.PictureBox pic_CAM1_CONNECT_ON;
        private System.Windows.Forms.PictureBox pic_CAM1_CONNECT_OFF;
        private System.Windows.Forms.Label lbl_CAM1PassCount;
        private System.Windows.Forms.Label lbl_CAM1PassPercent;
        private System.Windows.Forms.Label lbl_CAM2PassCount;
        private System.Windows.Forms.Label lbl_CAM2PassPercent;
        private System.Windows.Forms.Label lbl_CAM2TIME;
        private System.Windows.Forms.Label lbl_CAM2TotalCount;
        private System.Windows.Forms.PictureBox pic_CAM2_CONNECT_ON;
        private System.Windows.Forms.PictureBox pic_CAM2_CONNECT_OFF;
        private System.Windows.Forms.PictureBox pic_CAM1_Result;
        private System.Windows.Forms.PictureBox pic_CAM2_Result;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Timer timer6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;

        //soonding

        //soonding

    }
}