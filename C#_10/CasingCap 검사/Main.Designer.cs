
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
            this.btn_Start = new System.Windows.Forms.Button();
            this.cogRecordDisplay_CAMERA1 = new Cognex.VisionPro.CogRecordDisplay();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cb_NGSave = new System.Windows.Forms.CheckBox();
            this.cb_AllSave = new System.Windows.Forms.CheckBox();
            this.lb_Model = new System.Windows.Forms.Label();
            this.btn_Model = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pb_FileLoading = new System.Windows.Forms.PictureBox();
            this.lb_NowTime = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btn_CountReset = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btn_EXIT = new System.Windows.Forms.Button();
            this.btn_AddModel = new System.Windows.Forms.Button();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.pb2 = new System.Windows.Forms.PictureBox();
            this.pb3 = new System.Windows.Forms.PictureBox();
            this.pb4 = new System.Windows.Forms.PictureBox();
            this.cogRecordDisplay_CAMERA2 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogRecordDisplay_CAMERA3 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogRecordDisplay_CAMERA4 = new Cognex.VisionPro.CogRecordDisplay();
            this.btn_Bypass_1 = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Bypass_2 = new System.Windows.Forms.Button();
            this.btn_Bypass_3 = new System.Windows.Forms.Button();
            this.btn_Bypass_4 = new System.Windows.Forms.Button();
            this.lb_InsTime1 = new System.Windows.Forms.Label();
            this.lb_InsTime2 = new System.Windows.Forms.Label();
            this.lb_InsTime3 = new System.Windows.Forms.Label();
            this.lb_InsTime4 = new System.Windows.Forms.Label();
            this.lb_InsCount1 = new System.Windows.Forms.Label();
            this.lb_InsCount2 = new System.Windows.Forms.Label();
            this.lb_InsCount3 = new System.Windows.Forms.Label();
            this.lb_InsCount4 = new System.Windows.Forms.Label();
            this.lb_PassCount1 = new System.Windows.Forms.Label();
            this.lb_PassCount2 = new System.Windows.Forms.Label();
            this.lb_PassCount3 = new System.Windows.Forms.Label();
            this.lb_PassCount4 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_FileLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA4)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.Transparent;
            this.btn_Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Start.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.btn_Start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_Start.Location = new System.Drawing.Point(1322, 59);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(274, 71);
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
            this.cogRecordDisplay_CAMERA1.Location = new System.Drawing.Point(82, 204);
            this.cogRecordDisplay_CAMERA1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay_CAMERA1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay_CAMERA1.Name = "cogRecordDisplay_CAMERA1";
            this.cogRecordDisplay_CAMERA1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay_CAMERA1.OcxState")));
            this.cogRecordDisplay_CAMERA1.Size = new System.Drawing.Size(502, 380);
            this.cogRecordDisplay_CAMERA1.TabIndex = 116;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(1419, 446);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(419, 360);
            this.listBox1.TabIndex = 125;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "img_Pass.png");
            this.imageList1.Images.SetKeyName(1, "img_Fail.png");
            // 
            // cb_NGSave
            // 
            this.cb_NGSave.AutoSize = true;
            this.cb_NGSave.BackColor = System.Drawing.Color.Transparent;
            this.cb_NGSave.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.cb_NGSave.ForeColor = System.Drawing.SystemColors.Control;
            this.cb_NGSave.Location = new System.Drawing.Point(663, 68);
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
            this.cb_AllSave.Location = new System.Drawing.Point(815, 68);
            this.cb_AllSave.Name = "cb_AllSave";
            this.cb_AllSave.Size = new System.Drawing.Size(191, 25);
            this.cb_AllSave.TabIndex = 130;
            this.cb_AllSave.Text = "검사 이미지 모두 저장";
            this.cb_AllSave.UseVisualStyleBackColor = false;
            this.cb_AllSave.CheckedChanged += new System.EventHandler(this.cb_AllSave_CheckedChanged);
            // 
            // lb_Model
            // 
            this.lb_Model.AutoSize = true;
            this.lb_Model.BackColor = System.Drawing.Color.Transparent;
            this.lb_Model.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.lb_Model.Location = new System.Drawing.Point(1546, 313);
            this.lb_Model.Name = "lb_Model";
            this.lb_Model.Size = new System.Drawing.Size(70, 28);
            this.lb_Model.TabIndex = 134;
            this.lb_Model.Text = "Model";
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
            this.btn_Model.Location = new System.Drawing.Point(1422, 928);
            this.btn_Model.Name = "btn_Model";
            this.btn_Model.Size = new System.Drawing.Size(419, 89);
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
            this.lb_NowTime.Location = new System.Drawing.Point(423, 69);
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
            // btn_CountReset
            // 
            this.btn_CountReset.BackColor = System.Drawing.Color.Transparent;
            this.btn_CountReset.FlatAppearance.BorderSize = 0;
            this.btn_CountReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_CountReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_CountReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CountReset.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_CountReset.ForeColor = System.Drawing.Color.Black;
            this.btn_CountReset.Location = new System.Drawing.Point(1052, 58);
            this.btn_CountReset.Name = "btn_CountReset";
            this.btn_CountReset.Size = new System.Drawing.Size(274, 71);
            this.btn_CountReset.TabIndex = 146;
            this.btn_CountReset.UseVisualStyleBackColor = false;
            this.btn_CountReset.Click += new System.EventHandler(this.btn_CountReset_Click);
            // 
            // btn_EXIT
            // 
            this.btn_EXIT.BackColor = System.Drawing.Color.Transparent;
            this.btn_EXIT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_EXIT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_EXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EXIT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_EXIT.Location = new System.Drawing.Point(1594, 59);
            this.btn_EXIT.Name = "btn_EXIT";
            this.btn_EXIT.Size = new System.Drawing.Size(274, 71);
            this.btn_EXIT.TabIndex = 115;
            this.btn_EXIT.UseVisualStyleBackColor = false;
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
            this.btn_AddModel.Location = new System.Drawing.Point(1422, 832);
            this.btn_AddModel.Name = "btn_AddModel";
            this.btn_AddModel.Size = new System.Drawing.Size(419, 89);
            this.btn_AddModel.TabIndex = 147;
            this.btn_AddModel.UseVisualStyleBackColor = false;
            this.btn_AddModel.Click += new System.EventHandler(this.btn_AddModel_Click);
            // 
            // pb1
            // 
            this.pb1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.pb1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb1.Location = new System.Drawing.Point(595, 485);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(143, 93);
            this.pb1.TabIndex = 124;
            this.pb1.TabStop = false;
            // 
            // pb2
            // 
            this.pb2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.pb2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb2.Location = new System.Drawing.Point(1263, 485);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(143, 93);
            this.pb2.TabIndex = 153;
            this.pb2.TabStop = false;
            // 
            // pb3
            // 
            this.pb3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.pb3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb3.Location = new System.Drawing.Point(595, 924);
            this.pb3.Name = "pb3";
            this.pb3.Size = new System.Drawing.Size(143, 93);
            this.pb3.TabIndex = 154;
            this.pb3.TabStop = false;
            // 
            // pb4
            // 
            this.pb4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.pb4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb4.Location = new System.Drawing.Point(1263, 928);
            this.pb4.Name = "pb4";
            this.pb4.Size = new System.Drawing.Size(143, 93);
            this.pb4.TabIndex = 155;
            this.pb4.TabStop = false;
            // 
            // cogRecordDisplay_CAMERA2
            // 
            this.cogRecordDisplay_CAMERA2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA2.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay_CAMERA2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay_CAMERA2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA2.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay_CAMERA2.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay_CAMERA2.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay_CAMERA2.Location = new System.Drawing.Point(750, 204);
            this.cogRecordDisplay_CAMERA2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay_CAMERA2.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay_CAMERA2.Name = "cogRecordDisplay_CAMERA2";
            this.cogRecordDisplay_CAMERA2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay_CAMERA2.OcxState")));
            this.cogRecordDisplay_CAMERA2.Size = new System.Drawing.Size(502, 380);
            this.cogRecordDisplay_CAMERA2.TabIndex = 156;
            // 
            // cogRecordDisplay_CAMERA3
            // 
            this.cogRecordDisplay_CAMERA3.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA3.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay_CAMERA3.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay_CAMERA3.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA3.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay_CAMERA3.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay_CAMERA3.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay_CAMERA3.Location = new System.Drawing.Point(82, 641);
            this.cogRecordDisplay_CAMERA3.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay_CAMERA3.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay_CAMERA3.Name = "cogRecordDisplay_CAMERA3";
            this.cogRecordDisplay_CAMERA3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay_CAMERA3.OcxState")));
            this.cogRecordDisplay_CAMERA3.Size = new System.Drawing.Size(502, 380);
            this.cogRecordDisplay_CAMERA3.TabIndex = 157;
            // 
            // cogRecordDisplay_CAMERA4
            // 
            this.cogRecordDisplay_CAMERA4.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA4.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay_CAMERA4.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay_CAMERA4.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA4.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay_CAMERA4.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay_CAMERA4.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay_CAMERA4.Location = new System.Drawing.Point(750, 641);
            this.cogRecordDisplay_CAMERA4.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay_CAMERA4.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay_CAMERA4.Name = "cogRecordDisplay_CAMERA4";
            this.cogRecordDisplay_CAMERA4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay_CAMERA4.OcxState")));
            this.cogRecordDisplay_CAMERA4.Size = new System.Drawing.Size(502, 380);
            this.cogRecordDisplay_CAMERA4.TabIndex = 158;
            // 
            // btn_Bypass_1
            // 
            this.btn_Bypass_1.BackColor = System.Drawing.Color.Transparent;
            this.btn_Bypass_1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_Bypass_1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Bypass_1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Bypass_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Bypass_1.Location = new System.Drawing.Point(595, 422);
            this.btn_Bypass_1.Name = "btn_Bypass_1";
            this.btn_Bypass_1.Size = new System.Drawing.Size(143, 26);
            this.btn_Bypass_1.TabIndex = 159;
            this.btn_Bypass_1.UseVisualStyleBackColor = false;
            this.btn_Bypass_1.Click += new System.EventHandler(this.btn_Bypass_1_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "btn_BypassOff.png");
            this.imageList2.Images.SetKeyName(1, "btn_BypassOn.png");
            // 
            // btn_Bypass_2
            // 
            this.btn_Bypass_2.BackColor = System.Drawing.Color.Transparent;
            this.btn_Bypass_2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_Bypass_2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Bypass_2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Bypass_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Bypass_2.Location = new System.Drawing.Point(1263, 422);
            this.btn_Bypass_2.Name = "btn_Bypass_2";
            this.btn_Bypass_2.Size = new System.Drawing.Size(143, 26);
            this.btn_Bypass_2.TabIndex = 160;
            this.btn_Bypass_2.UseVisualStyleBackColor = false;
            this.btn_Bypass_2.Click += new System.EventHandler(this.btn_Bypass_2_Click);
            // 
            // btn_Bypass_3
            // 
            this.btn_Bypass_3.BackColor = System.Drawing.Color.Transparent;
            this.btn_Bypass_3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_Bypass_3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Bypass_3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Bypass_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Bypass_3.Location = new System.Drawing.Point(595, 860);
            this.btn_Bypass_3.Name = "btn_Bypass_3";
            this.btn_Bypass_3.Size = new System.Drawing.Size(143, 26);
            this.btn_Bypass_3.TabIndex = 161;
            this.btn_Bypass_3.UseVisualStyleBackColor = false;
            this.btn_Bypass_3.Click += new System.EventHandler(this.btn_Bypass_3_Click);
            // 
            // btn_Bypass_4
            // 
            this.btn_Bypass_4.BackColor = System.Drawing.Color.Transparent;
            this.btn_Bypass_4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_Bypass_4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Bypass_4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Bypass_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Bypass_4.Location = new System.Drawing.Point(1263, 860);
            this.btn_Bypass_4.Name = "btn_Bypass_4";
            this.btn_Bypass_4.Size = new System.Drawing.Size(143, 26);
            this.btn_Bypass_4.TabIndex = 162;
            this.btn_Bypass_4.UseVisualStyleBackColor = false;
            this.btn_Bypass_4.Click += new System.EventHandler(this.btn_Bypass_4_Click);
            // 
            // lb_InsTime1
            // 
            this.lb_InsTime1.AutoSize = true;
            this.lb_InsTime1.BackColor = System.Drawing.Color.Transparent;
            this.lb_InsTime1.Location = new System.Drawing.Point(593, 235);
            this.lb_InsTime1.Name = "lb_InsTime1";
            this.lb_InsTime1.Size = new System.Drawing.Size(38, 12);
            this.lb_InsTime1.TabIndex = 165;
            this.lb_InsTime1.Text = "label4";
            // 
            // lb_InsTime2
            // 
            this.lb_InsTime2.AutoSize = true;
            this.lb_InsTime2.BackColor = System.Drawing.Color.Transparent;
            this.lb_InsTime2.Location = new System.Drawing.Point(1261, 235);
            this.lb_InsTime2.Name = "lb_InsTime2";
            this.lb_InsTime2.Size = new System.Drawing.Size(38, 12);
            this.lb_InsTime2.TabIndex = 166;
            this.lb_InsTime2.Text = "label4";
            // 
            // lb_InsTime3
            // 
            this.lb_InsTime3.AutoSize = true;
            this.lb_InsTime3.BackColor = System.Drawing.Color.Transparent;
            this.lb_InsTime3.Location = new System.Drawing.Point(593, 670);
            this.lb_InsTime3.Name = "lb_InsTime3";
            this.lb_InsTime3.Size = new System.Drawing.Size(38, 12);
            this.lb_InsTime3.TabIndex = 167;
            this.lb_InsTime3.Text = "label4";
            // 
            // lb_InsTime4
            // 
            this.lb_InsTime4.AutoSize = true;
            this.lb_InsTime4.BackColor = System.Drawing.Color.Transparent;
            this.lb_InsTime4.Location = new System.Drawing.Point(1261, 670);
            this.lb_InsTime4.Name = "lb_InsTime4";
            this.lb_InsTime4.Size = new System.Drawing.Size(38, 12);
            this.lb_InsTime4.TabIndex = 168;
            this.lb_InsTime4.Text = "label4";
            // 
            // lb_InsCount1
            // 
            this.lb_InsCount1.AutoSize = true;
            this.lb_InsCount1.BackColor = System.Drawing.Color.Transparent;
            this.lb_InsCount1.Location = new System.Drawing.Point(593, 302);
            this.lb_InsCount1.Name = "lb_InsCount1";
            this.lb_InsCount1.Size = new System.Drawing.Size(38, 12);
            this.lb_InsCount1.TabIndex = 169;
            this.lb_InsCount1.Text = "label4";
            // 
            // lb_InsCount2
            // 
            this.lb_InsCount2.AutoSize = true;
            this.lb_InsCount2.BackColor = System.Drawing.Color.Transparent;
            this.lb_InsCount2.Location = new System.Drawing.Point(1261, 302);
            this.lb_InsCount2.Name = "lb_InsCount2";
            this.lb_InsCount2.Size = new System.Drawing.Size(38, 12);
            this.lb_InsCount2.TabIndex = 170;
            this.lb_InsCount2.Text = "label4";
            // 
            // lb_InsCount3
            // 
            this.lb_InsCount3.AutoSize = true;
            this.lb_InsCount3.BackColor = System.Drawing.Color.Transparent;
            this.lb_InsCount3.Location = new System.Drawing.Point(593, 739);
            this.lb_InsCount3.Name = "lb_InsCount3";
            this.lb_InsCount3.Size = new System.Drawing.Size(38, 12);
            this.lb_InsCount3.TabIndex = 171;
            this.lb_InsCount3.Text = "label4";
            // 
            // lb_InsCount4
            // 
            this.lb_InsCount4.AutoSize = true;
            this.lb_InsCount4.BackColor = System.Drawing.Color.Transparent;
            this.lb_InsCount4.Location = new System.Drawing.Point(1261, 739);
            this.lb_InsCount4.Name = "lb_InsCount4";
            this.lb_InsCount4.Size = new System.Drawing.Size(38, 12);
            this.lb_InsCount4.TabIndex = 172;
            this.lb_InsCount4.Text = "label4";
            // 
            // lb_PassCount1
            // 
            this.lb_PassCount1.AutoSize = true;
            this.lb_PassCount1.BackColor = System.Drawing.Color.Transparent;
            this.lb_PassCount1.Location = new System.Drawing.Point(593, 366);
            this.lb_PassCount1.Name = "lb_PassCount1";
            this.lb_PassCount1.Size = new System.Drawing.Size(38, 12);
            this.lb_PassCount1.TabIndex = 173;
            this.lb_PassCount1.Text = "label4";
            // 
            // lb_PassCount2
            // 
            this.lb_PassCount2.AutoSize = true;
            this.lb_PassCount2.BackColor = System.Drawing.Color.Transparent;
            this.lb_PassCount2.Location = new System.Drawing.Point(1261, 366);
            this.lb_PassCount2.Name = "lb_PassCount2";
            this.lb_PassCount2.Size = new System.Drawing.Size(38, 12);
            this.lb_PassCount2.TabIndex = 174;
            this.lb_PassCount2.Text = "label4";
            // 
            // lb_PassCount3
            // 
            this.lb_PassCount3.AutoSize = true;
            this.lb_PassCount3.BackColor = System.Drawing.Color.Transparent;
            this.lb_PassCount3.Location = new System.Drawing.Point(593, 804);
            this.lb_PassCount3.Name = "lb_PassCount3";
            this.lb_PassCount3.Size = new System.Drawing.Size(38, 12);
            this.lb_PassCount3.TabIndex = 175;
            this.lb_PassCount3.Text = "label4";
            // 
            // lb_PassCount4
            // 
            this.lb_PassCount4.AutoSize = true;
            this.lb_PassCount4.BackColor = System.Drawing.Color.Transparent;
            this.lb_PassCount4.Location = new System.Drawing.Point(1261, 804);
            this.lb_PassCount4.Name = "lb_PassCount4";
            this.lb_PassCount4.Size = new System.Drawing.Size(38, 12);
            this.lb_PassCount4.TabIndex = 176;
            this.lb_PassCount4.Text = "label4";
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.lb_PassCount4);
            this.Controls.Add(this.lb_PassCount3);
            this.Controls.Add(this.lb_PassCount2);
            this.Controls.Add(this.lb_PassCount1);
            this.Controls.Add(this.lb_InsCount4);
            this.Controls.Add(this.lb_InsCount3);
            this.Controls.Add(this.lb_InsCount2);
            this.Controls.Add(this.lb_InsCount1);
            this.Controls.Add(this.lb_InsTime4);
            this.Controls.Add(this.lb_InsTime3);
            this.Controls.Add(this.lb_InsTime2);
            this.Controls.Add(this.lb_InsTime1);
            this.Controls.Add(this.btn_Bypass_4);
            this.Controls.Add(this.btn_Bypass_3);
            this.Controls.Add(this.btn_Bypass_2);
            this.Controls.Add(this.btn_Bypass_1);
            this.Controls.Add(this.cogRecordDisplay_CAMERA4);
            this.Controls.Add(this.cogRecordDisplay_CAMERA3);
            this.Controls.Add(this.pb_FileLoading);
            this.Controls.Add(this.cogRecordDisplay_CAMERA2);
            this.Controls.Add(this.pb4);
            this.Controls.Add(this.pb3);
            this.Controls.Add(this.pb2);
            this.Controls.Add(this.btn_AddModel);
            this.Controls.Add(this.btn_CountReset);
            this.Controls.Add(this.lb_NowTime);
            this.Controls.Add(this.btn_Model);
            this.Controls.Add(this.lb_Model);
            this.Controls.Add(this.cb_AllSave);
            this.Controls.Add(this.cb_NGSave);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.cogRecordDisplay_CAMERA1);
            this.Controls.Add(this.btn_EXIT);
            this.Controls.Add(this.btn_Start);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_FileLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Start;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay_CAMERA1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox cb_NGSave;
        private System.Windows.Forms.CheckBox cb_AllSave;
        private System.Windows.Forms.Label lb_Model;
        private System.Windows.Forms.Button btn_Model;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pb_FileLoading;
        private System.Windows.Forms.Label lb_NowTime;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btn_CountReset;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btn_EXIT;
        private System.Windows.Forms.Button btn_AddModel;
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.PictureBox pb2;
        private System.Windows.Forms.PictureBox pb3;
        private System.Windows.Forms.PictureBox pb4;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay_CAMERA2;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay_CAMERA3;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay_CAMERA4;
        private System.Windows.Forms.Button btn_Bypass_1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btn_Bypass_2;
        private System.Windows.Forms.Button btn_Bypass_3;
        private System.Windows.Forms.Button btn_Bypass_4;
        private System.Windows.Forms.Label lb_InsTime1;
        private System.Windows.Forms.Label lb_InsTime2;
        private System.Windows.Forms.Label lb_InsTime3;
        private System.Windows.Forms.Label lb_InsTime4;
        private System.Windows.Forms.Label lb_InsCount1;
        private System.Windows.Forms.Label lb_InsCount2;
        private System.Windows.Forms.Label lb_InsCount3;
        private System.Windows.Forms.Label lb_InsCount4;
        private System.Windows.Forms.Label lb_PassCount1;
        private System.Windows.Forms.Label lb_PassCount2;
        private System.Windows.Forms.Label lb_PassCount3;
        private System.Windows.Forms.Label lb_PassCount4;
        private System.Windows.Forms.Timer timer3;
    }
}

