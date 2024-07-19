
namespace chsj
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.cogRecordDisplay_CAMERA1 = new Cognex.VisionPro.CogRecordDisplay();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cb_NGSave = new System.Windows.Forms.CheckBox();
            this.cb_AllSave = new System.Windows.Forms.CheckBox();
            this.tb_OffsetAngle = new System.Windows.Forms.TextBox();
            this.lb_Model = new System.Windows.Forms.Label();
            this.lb_Angle = new System.Windows.Forms.Label();
            this.lb_Shape = new System.Windows.Forms.Label();
            this.lb_Count = new System.Windows.Forms.Label();
            this.btn_Model = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pb_FileLoading = new System.Windows.Forms.PictureBox();
            this.lb_NowTime = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ScoreShape = new System.Windows.Forms.TextBox();
            this.btn_CountReset = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btn_EXIT = new System.Windows.Forms.Button();
            this.btn_AddModel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_ScoreAngle = new System.Windows.Forms.TextBox();
            this.lb_ModelName = new System.Windows.Forms.Label();
            this.lb_Angle2 = new System.Windows.Forms.Label();
            this.lb_PassCount = new System.Windows.Forms.Label();
            this.lb_FailCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_FileLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Stop
            // 
            this.btn_Stop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Stop.BackgroundImage")));
            this.btn_Stop.Enabled = false;
            this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Stop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_Stop.Location = new System.Drawing.Point(1450, 25);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(210, 60);
            this.btn_Stop.TabIndex = 114;
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.Transparent;
            this.btn_Start.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Start.BackgroundImage")));
            this.btn_Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Start.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_Start.Location = new System.Drawing.Point(1239, 25);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(210, 60);
            this.btn_Start.TabIndex = 113;
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // cogRecordDisplay_CAMERA1
            // 
            this.cogRecordDisplay_CAMERA1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay_CAMERA1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay_CAMERA1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay_CAMERA1.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay_CAMERA1.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay_CAMERA1.Location = new System.Drawing.Point(82, 173);
            this.cogRecordDisplay_CAMERA1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay_CAMERA1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay_CAMERA1.Name = "cogRecordDisplay_CAMERA1";
            this.cogRecordDisplay_CAMERA1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay_CAMERA1.OcxState")));
            this.cogRecordDisplay_CAMERA1.Size = new System.Drawing.Size(1011, 846);
            this.cogRecordDisplay_CAMERA1.TabIndex = 116;
            // 
            // pb1
            // 
            this.pb1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.pb1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb1.Location = new System.Drawing.Point(1649, 444);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(167, 52);
            this.pb1.TabIndex = 124;
            this.pb1.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(1107, 608);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(731, 204);
            this.listBox1.TabIndex = 125;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "PASS.png");
            this.imageList1.Images.SetKeyName(1, "FAIL.png");
            // 
            // cb_NGSave
            // 
            this.cb_NGSave.AutoSize = true;
            this.cb_NGSave.BackColor = System.Drawing.Color.Transparent;
            this.cb_NGSave.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.cb_NGSave.ForeColor = System.Drawing.SystemColors.Control;
            this.cb_NGSave.Location = new System.Drawing.Point(762, 60);
            this.cb_NGSave.Name = "cb_NGSave";
            this.cb_NGSave.Size = new System.Drawing.Size(144, 25);
            this.cb_NGSave.TabIndex = 129;
            this.cb_NGSave.Text = "NG 이미지 저장";
            this.cb_NGSave.UseVisualStyleBackColor = false;
            this.cb_NGSave.CheckedChanged += new System.EventHandler(this.cb_NGSave_CheckedChanged);
            // 
            // cb_AllSave
            // 
            this.cb_AllSave.AutoSize = true;
            this.cb_AllSave.BackColor = System.Drawing.Color.Transparent;
            this.cb_AllSave.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.cb_AllSave.ForeColor = System.Drawing.SystemColors.Control;
            this.cb_AllSave.Location = new System.Drawing.Point(914, 60);
            this.cb_AllSave.Name = "cb_AllSave";
            this.cb_AllSave.Size = new System.Drawing.Size(191, 25);
            this.cb_AllSave.TabIndex = 130;
            this.cb_AllSave.Text = "검사 이미지 모두 저장";
            this.cb_AllSave.UseVisualStyleBackColor = false;
            this.cb_AllSave.CheckedChanged += new System.EventHandler(this.cb_AllSave_CheckedChanged);
            // 
            // tb_OffsetAngle
            // 
            this.tb_OffsetAngle.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.tb_OffsetAngle.Location = new System.Drawing.Point(1594, 302);
            this.tb_OffsetAngle.Name = "tb_OffsetAngle";
            this.tb_OffsetAngle.ReadOnly = true;
            this.tb_OffsetAngle.Size = new System.Drawing.Size(70, 34);
            this.tb_OffsetAngle.TabIndex = 132;
            this.tb_OffsetAngle.Text = "0";
            this.tb_OffsetAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_Model
            // 
            this.lb_Model.AutoSize = true;
            this.lb_Model.BackColor = System.Drawing.Color.Transparent;
            this.lb_Model.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lb_Model.Location = new System.Drawing.Point(1290, 262);
            this.lb_Model.Name = "lb_Model";
            this.lb_Model.Size = new System.Drawing.Size(58, 21);
            this.lb_Model.TabIndex = 134;
            this.lb_Model.Text = "Model";
            // 
            // lb_Angle
            // 
            this.lb_Angle.AutoSize = true;
            this.lb_Angle.BackColor = System.Drawing.Color.Transparent;
            this.lb_Angle.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lb_Angle.Location = new System.Drawing.Point(1353, 311);
            this.lb_Angle.Name = "lb_Angle";
            this.lb_Angle.Size = new System.Drawing.Size(53, 21);
            this.lb_Angle.TabIndex = 135;
            this.lb_Angle.Text = "Angle";
            // 
            // lb_Shape
            // 
            this.lb_Shape.AutoSize = true;
            this.lb_Shape.BackColor = System.Drawing.Color.Transparent;
            this.lb_Shape.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lb_Shape.Location = new System.Drawing.Point(1354, 362);
            this.lb_Shape.Name = "lb_Shape";
            this.lb_Shape.Size = new System.Drawing.Size(55, 21);
            this.lb_Shape.TabIndex = 136;
            this.lb_Shape.Text = "Shape";
            // 
            // lb_Count
            // 
            this.lb_Count.AutoSize = true;
            this.lb_Count.BackColor = System.Drawing.Color.Transparent;
            this.lb_Count.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.lb_Count.Location = new System.Drawing.Point(1188, 455);
            this.lb_Count.Name = "lb_Count";
            this.lb_Count.Size = new System.Drawing.Size(68, 28);
            this.lb_Count.TabIndex = 137;
            this.lb_Count.Text = "Count";
            // 
            // btn_Model
            // 
            this.btn_Model.BackColor = System.Drawing.Color.Transparent;
            this.btn_Model.FlatAppearance.BorderSize = 0;
            this.btn_Model.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Model.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Model.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Model.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Model.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Model.Location = new System.Drawing.Point(1107, 929);
            this.btn_Model.Name = "btn_Model";
            this.btn_Model.Size = new System.Drawing.Size(734, 89);
            this.btn_Model.TabIndex = 138;
            this.btn_Model.UseVisualStyleBackColor = false;
            this.btn_Model.Click += new System.EventHandler(this.btn_Model_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pb_FileLoading
            // 
            this.pb_FileLoading.BackgroundImage = global::chsj.Properties.Resources.loading;
            this.pb_FileLoading.Location = new System.Drawing.Point(872, 481);
            this.pb_FileLoading.Name = "pb_FileLoading";
            this.pb_FileLoading.Size = new System.Drawing.Size(296, 94);
            this.pb_FileLoading.TabIndex = 141;
            this.pb_FileLoading.TabStop = false;
            // 
            // lb_NowTime
            // 
            this.lb_NowTime.AutoSize = true;
            this.lb_NowTime.BackColor = System.Drawing.Color.Transparent;
            this.lb_NowTime.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lb_NowTime.ForeColor = System.Drawing.SystemColors.Control;
            this.lb_NowTime.Location = new System.Drawing.Point(516, 61);
            this.lb_NowTime.Name = "lb_NowTime";
            this.lb_NowTime.Size = new System.Drawing.Size(218, 21);
            this.lb_NowTime.TabIndex = 142;
            this.lb_NowTime.Text = "yyyy-MM-dd  오전 00:00:00";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(1512, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 143;
            this.label1.Text = "Offset :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(1670, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 25);
            this.label2.TabIndex = 145;
            this.label2.Text = "Score :";
            // 
            // tb_ScoreShape
            // 
            this.tb_ScoreShape.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.tb_ScoreShape.Location = new System.Drawing.Point(1746, 353);
            this.tb_ScoreShape.Name = "tb_ScoreShape";
            this.tb_ScoreShape.ReadOnly = true;
            this.tb_ScoreShape.Size = new System.Drawing.Size(70, 34);
            this.tb_ScoreShape.TabIndex = 144;
            this.tb_ScoreShape.Text = "0";
            this.tb_ScoreShape.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_CountReset
            // 
            this.btn_CountReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.btn_CountReset.FlatAppearance.BorderSize = 0;
            this.btn_CountReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CountReset.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_CountReset.ForeColor = System.Drawing.Color.Black;
            this.btn_CountReset.Location = new System.Drawing.Point(1716, 405);
            this.btn_CountReset.Name = "btn_CountReset";
            this.btn_CountReset.Size = new System.Drawing.Size(100, 34);
            this.btn_CountReset.TabIndex = 146;
            this.btn_CountReset.Text = "Count Reset";
            this.btn_CountReset.UseVisualStyleBackColor = false;
            this.btn_CountReset.Click += new System.EventHandler(this.btn_CountReset_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 38400;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // btn_EXIT
            // 
            this.btn_EXIT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_EXIT.BackgroundImage")));
            this.btn_EXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EXIT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_EXIT.Location = new System.Drawing.Point(1661, 25);
            this.btn_EXIT.Name = "btn_EXIT";
            this.btn_EXIT.Size = new System.Drawing.Size(210, 60);
            this.btn_EXIT.TabIndex = 115;
            this.btn_EXIT.UseVisualStyleBackColor = true;
            this.btn_EXIT.Click += new System.EventHandler(this.btn_EXIT_Click);
            // 
            // btn_AddModel
            // 
            this.btn_AddModel.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddModel.FlatAppearance.BorderSize = 0;
            this.btn_AddModel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_AddModel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_AddModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddModel.ForeColor = System.Drawing.Color.Transparent;
            this.btn_AddModel.Location = new System.Drawing.Point(1107, 838);
            this.btn_AddModel.Name = "btn_AddModel";
            this.btn_AddModel.Size = new System.Drawing.Size(734, 89);
            this.btn_AddModel.TabIndex = 147;
            this.btn_AddModel.UseVisualStyleBackColor = false;
            this.btn_AddModel.Click += new System.EventHandler(this.btn_AddModel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(1670, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 149;
            this.label3.Text = "Score :";
            // 
            // tb_ScoreAngle
            // 
            this.tb_ScoreAngle.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.tb_ScoreAngle.Location = new System.Drawing.Point(1746, 302);
            this.tb_ScoreAngle.Name = "tb_ScoreAngle";
            this.tb_ScoreAngle.ReadOnly = true;
            this.tb_ScoreAngle.Size = new System.Drawing.Size(70, 34);
            this.tb_ScoreAngle.TabIndex = 148;
            this.tb_ScoreAngle.Text = "0";
            this.tb_ScoreAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_ModelName
            // 
            this.lb_ModelName.AutoSize = true;
            this.lb_ModelName.BackColor = System.Drawing.Color.Black;
            this.lb_ModelName.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lb_ModelName.ForeColor = System.Drawing.SystemColors.Control;
            this.lb_ModelName.Location = new System.Drawing.Point(111, 184);
            this.lb_ModelName.Name = "lb_ModelName";
            this.lb_ModelName.Size = new System.Drawing.Size(72, 28);
            this.lb_ModelName.TabIndex = 150;
            this.lb_ModelName.Text = "Model";
            // 
            // lb_Angle2
            // 
            this.lb_Angle2.AutoSize = true;
            this.lb_Angle2.BackColor = System.Drawing.Color.Black;
            this.lb_Angle2.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lb_Angle2.ForeColor = System.Drawing.SystemColors.Control;
            this.lb_Angle2.Location = new System.Drawing.Point(448, 184);
            this.lb_Angle2.Name = "lb_Angle2";
            this.lb_Angle2.Size = new System.Drawing.Size(67, 28);
            this.lb_Angle2.TabIndex = 151;
            this.lb_Angle2.Text = "Angle";
            // 
            // lb_PassCount
            // 
            this.lb_PassCount.AutoSize = true;
            this.lb_PassCount.BackColor = System.Drawing.Color.Transparent;
            this.lb_PassCount.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.lb_PassCount.Location = new System.Drawing.Point(1353, 455);
            this.lb_PassCount.Name = "lb_PassCount";
            this.lb_PassCount.Size = new System.Drawing.Size(68, 28);
            this.lb_PassCount.TabIndex = 152;
            this.lb_PassCount.Text = "Count";
            // 
            // lb_FailCount
            // 
            this.lb_FailCount.AutoSize = true;
            this.lb_FailCount.BackColor = System.Drawing.Color.Transparent;
            this.lb_FailCount.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.lb_FailCount.Location = new System.Drawing.Point(1523, 455);
            this.lb_FailCount.Name = "lb_FailCount";
            this.lb_FailCount.Size = new System.Drawing.Size(68, 28);
            this.lb_FailCount.TabIndex = 153;
            this.lb_FailCount.Text = "Count";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.lb_FailCount);
            this.Controls.Add(this.lb_PassCount);
            this.Controls.Add(this.pb_FileLoading);
            this.Controls.Add(this.lb_Angle2);
            this.Controls.Add(this.lb_ModelName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_ScoreAngle);
            this.Controls.Add(this.btn_AddModel);
            this.Controls.Add(this.btn_CountReset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_ScoreShape);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_NowTime);
            this.Controls.Add(this.btn_Model);
            this.Controls.Add(this.lb_Count);
            this.Controls.Add(this.lb_Shape);
            this.Controls.Add(this.lb_Angle);
            this.Controls.Add(this.lb_Model);
            this.Controls.Add(this.tb_OffsetAngle);
            this.Controls.Add(this.cb_AllSave);
            this.Controls.Add(this.cb_NGSave);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.cogRecordDisplay_CAMERA1);
            this.Controls.Add(this.btn_EXIT);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_FileLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Start;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay_CAMERA1;
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox cb_NGSave;
        private System.Windows.Forms.CheckBox cb_AllSave;
        private System.Windows.Forms.TextBox tb_OffsetAngle;
        private System.Windows.Forms.Label lb_Model;
        private System.Windows.Forms.Label lb_Angle;
        private System.Windows.Forms.Label lb_Shape;
        private System.Windows.Forms.Label lb_Count;
        private System.Windows.Forms.Button btn_Model;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pb_FileLoading;
        private System.Windows.Forms.Label lb_NowTime;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_ScoreShape;
        private System.Windows.Forms.Button btn_CountReset;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btn_EXIT;
        private System.Windows.Forms.Button btn_AddModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_ScoreAngle;
        private System.Windows.Forms.Label lb_ModelName;
        private System.Windows.Forms.Label lb_Angle2;
        private System.Windows.Forms.Label lb_PassCount;
        private System.Windows.Forms.Label lb_FailCount;
    }
}

