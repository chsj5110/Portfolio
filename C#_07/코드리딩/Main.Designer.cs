
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
            this.btn_Stop = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lbl_DateTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pb_2 = new System.Windows.Forms.PictureBox();
            this.cogRecordDisplay_CAMERA1 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogRecordDisplay_CAMERA2 = new Cognex.VisionPro.CogRecordDisplay();
            this.btn_EXIT = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pb1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.Transparent;
            this.btn_Start.BackgroundImage = global::chsj.Properties.Resources.btn_START;
            this.btn_Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Start.Location = new System.Drawing.Point(1222, 33);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(210, 60);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.BackgroundImage = global::chsj.Properties.Resources.btn_STOP;
            this.btn_Stop.Enabled = false;
            this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Stop.Location = new System.Drawing.Point(1433, 33);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(210, 60);
            this.btn_Stop.TabIndex = 1;
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // lbl_DateTime
            // 
            this.lbl_DateTime.AutoSize = true;
            this.lbl_DateTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.lbl_DateTime.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_DateTime.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbl_DateTime.Location = new System.Drawing.Point(379, 54);
            this.lbl_DateTime.Name = "lbl_DateTime";
            this.lbl_DateTime.Size = new System.Drawing.Size(219, 14);
            this.lbl_DateTime.TabIndex = 5;
            this.lbl_DateTime.Text = "yyyy-MM-dd  오전 00:00:00";
            this.lbl_DateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pass1.png");
            this.imageList1.Images.SetKeyName(1, "fail1.png");
            // 
            // pb_2
            // 
            this.pb_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.pb_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pb_2.Location = new System.Drawing.Point(1632, 156);
            this.pb_2.Name = "pb_2";
            this.pb_2.Size = new System.Drawing.Size(222, 58);
            this.pb_2.TabIndex = 8;
            this.pb_2.TabStop = false;
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
            this.cogRecordDisplay_CAMERA1.Location = new System.Drawing.Point(69, 191);
            this.cogRecordDisplay_CAMERA1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay_CAMERA1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay_CAMERA1.Name = "cogRecordDisplay_CAMERA1";
            this.cogRecordDisplay_CAMERA1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay_CAMERA1.OcxState")));
            this.cogRecordDisplay_CAMERA1.Size = new System.Drawing.Size(866, 635);
            this.cogRecordDisplay_CAMERA1.TabIndex = 10;
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
            this.cogRecordDisplay_CAMERA2.Location = new System.Drawing.Point(988, 191);
            this.cogRecordDisplay_CAMERA2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay_CAMERA2.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay_CAMERA2.Name = "cogRecordDisplay_CAMERA2";
            this.cogRecordDisplay_CAMERA2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay_CAMERA2.OcxState")));
            this.cogRecordDisplay_CAMERA2.Size = new System.Drawing.Size(866, 635);
            this.cogRecordDisplay_CAMERA2.TabIndex = 109;
            // 
            // btn_EXIT
            // 
            this.btn_EXIT.BackgroundImage = global::chsj.Properties.Resources.btn_EXIT;
            this.btn_EXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EXIT.Location = new System.Drawing.Point(1644, 33);
            this.btn_EXIT.Name = "btn_EXIT";
            this.btn_EXIT.Size = new System.Drawing.Size(210, 60);
            this.btn_EXIT.TabIndex = 112;
            this.btn_EXIT.UseVisualStyleBackColor = true;
            this.btn_EXIT.Click += new System.EventHandler(this.btn_EXIT_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(69, 868);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(866, 144);
            this.listBox1.TabIndex = 113;
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(40)))));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(988, 868);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(866, 144);
            this.listBox2.TabIndex = 114;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.Window;
            this.button2.Location = new System.Drawing.Point(657, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 29);
            this.button2.TabIndex = 121;
            this.button2.Text = "Cam1";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.Window;
            this.button3.Location = new System.Drawing.Point(1576, 156);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 29);
            this.button3.TabIndex = 122;
            this.button3.Text = "Cam2";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pb1
            // 
            this.pb1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.pb1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pb1.Location = new System.Drawing.Point(713, 156);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(222, 58);
            this.pb1.TabIndex = 123;
            this.pb1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::chsj.Properties.Resources.UI;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pb_2);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_EXIT);
            this.Controls.Add(this.cogRecordDisplay_CAMERA2);
            this.Controls.Add(this.cogRecordDisplay_CAMERA1);
            this.Controls.Add(this.lbl_DateTime);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JAVEZ_IVS";
            ((System.ComponentModel.ISupportInitialize)(this.pb_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lbl_DateTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pb_2;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay_CAMERA1;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay_CAMERA2;
        private System.Windows.Forms.Button btn_EXIT;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pb1;
    }
}

