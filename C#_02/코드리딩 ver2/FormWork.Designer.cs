namespace chsj
{
    partial class FormWork
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWork));
            this.tb_w_NoScanned = new System.Windows.Forms.TextBox();
            this.tb_w_NoBox = new System.Windows.Forms.TextBox();
            this.tb_w_ProgressRate = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.wb_w_1 = new System.Windows.Forms.WebBrowser();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ComCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALCCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EONO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PNONEP = new System.Windows.Forms.DataGridViewImageColumn();
            this.OriBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tb = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lb_w_Weight = new System.Windows.Forms.Label();
            this.lb_w_LLower = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_w_LUpper = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.serialPort3 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_w_NoScanned
            // 
            this.tb_w_NoScanned.BackColor = System.Drawing.Color.White;
            this.tb_w_NoScanned.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_w_NoScanned.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.tb_w_NoScanned.ForeColor = System.Drawing.Color.Black;
            this.tb_w_NoScanned.Location = new System.Drawing.Point(122, 13);
            this.tb_w_NoScanned.Name = "tb_w_NoScanned";
            this.tb_w_NoScanned.ReadOnly = true;
            this.tb_w_NoScanned.Size = new System.Drawing.Size(215, 27);
            this.tb_w_NoScanned.TabIndex = 88;
            this.tb_w_NoScanned.TabStop = false;
            this.tb_w_NoScanned.Text = "스캔 수량";
            this.tb_w_NoScanned.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_w_NoBox
            // 
            this.tb_w_NoBox.BackColor = System.Drawing.Color.White;
            this.tb_w_NoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_w_NoBox.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.tb_w_NoBox.ForeColor = System.Drawing.Color.Black;
            this.tb_w_NoBox.Location = new System.Drawing.Point(568, 13);
            this.tb_w_NoBox.Name = "tb_w_NoBox";
            this.tb_w_NoBox.ReadOnly = true;
            this.tb_w_NoBox.Size = new System.Drawing.Size(215, 27);
            this.tb_w_NoBox.TabIndex = 89;
            this.tb_w_NoBox.TabStop = false;
            this.tb_w_NoBox.Text = "스캔수량/포장단위";
            this.tb_w_NoBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_w_ProgressRate
            // 
            this.tb_w_ProgressRate.BackColor = System.Drawing.Color.White;
            this.tb_w_ProgressRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_w_ProgressRate.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.tb_w_ProgressRate.ForeColor = System.Drawing.Color.Black;
            this.tb_w_ProgressRate.Location = new System.Drawing.Point(969, 13);
            this.tb_w_ProgressRate.Name = "tb_w_ProgressRate";
            this.tb_w_ProgressRate.ReadOnly = true;
            this.tb_w_ProgressRate.Size = new System.Drawing.Size(215, 27);
            this.tb_w_ProgressRate.TabIndex = 90;
            this.tb_w_ProgressRate.TabStop = false;
            this.tb_w_ProgressRate.Text = "진행률";
            this.tb_w_ProgressRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // wb_w_1
            // 
            this.wb_w_1.Location = new System.Drawing.Point(12, 120);
            this.wb_w_1.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb_w_1.Name = "wb_w_1";
            this.wb_w_1.Size = new System.Drawing.Size(1176, 381);
            this.wb_w_1.TabIndex = 91;
            this.wb_w_1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_w_1_DocumentCompleted);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM5";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("맑은 고딕", 8F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView1.ColumnHeadersHeight = 20;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComCode,
            this.Weight,
            this.No,
            this.ALCCode,
            this.EONO,
            this.LotNo,
            this.CP,
            this.PNONEP,
            this.OriBarcode});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("굴림", 10F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView1.Location = new System.Drawing.Point(10, 507);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1178, 187);
            this.dataGridView1.TabIndex = 106;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // ComCode
            // 
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.ComCode.DefaultCellStyle = dataGridViewCellStyle13;
            this.ComCode.Frozen = true;
            this.ComCode.HeaderText = "업체코드";
            this.ComCode.Name = "ComCode";
            this.ComCode.ReadOnly = true;
            this.ComCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ComCode.Width = 130;
            // 
            // Weight
            // 
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            this.Weight.DefaultCellStyle = dataGridViewCellStyle14;
            this.Weight.Frozen = true;
            this.Weight.HeaderText = "중량";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            this.Weight.Width = 130;
            // 
            // No
            // 
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            this.No.DefaultCellStyle = dataGridViewCellStyle15;
            this.No.Frozen = true;
            this.No.HeaderText = "품번";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 130;
            // 
            // ALCCode
            // 
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            this.ALCCode.DefaultCellStyle = dataGridViewCellStyle16;
            this.ALCCode.Frozen = true;
            this.ALCCode.HeaderText = "ALC코드";
            this.ALCCode.Name = "ALCCode";
            this.ALCCode.ReadOnly = true;
            this.ALCCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ALCCode.Width = 130;
            // 
            // EONO
            // 
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            this.EONO.DefaultCellStyle = dataGridViewCellStyle17;
            this.EONO.Frozen = true;
            this.EONO.HeaderText = "EO NO";
            this.EONO.Name = "EONO";
            this.EONO.ReadOnly = true;
            this.EONO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EONO.Width = 130;
            // 
            // LotNo
            // 
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            this.LotNo.DefaultCellStyle = dataGridViewCellStyle18;
            this.LotNo.Frozen = true;
            this.LotNo.HeaderText = "LOT NO";
            this.LotNo.Name = "LotNo";
            this.LotNo.ReadOnly = true;
            this.LotNo.Width = 130;
            // 
            // CP
            // 
            this.CP.Frozen = true;
            this.CP.HeaderText = "업체영역";
            this.CP.Name = "CP";
            this.CP.ReadOnly = true;
            this.CP.Width = 130;
            // 
            // PNONEP
            // 
            this.PNONEP.Frozen = true;
            this.PNONEP.HeaderText = "판정";
            this.PNONEP.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.PNONEP.Name = "PNONEP";
            this.PNONEP.ReadOnly = true;
            this.PNONEP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PNONEP.Width = 200;
            // 
            // OriBarcode
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Silver;
            this.OriBarcode.DefaultCellStyle = dataGridViewCellStyle19;
            this.OriBarcode.Frozen = true;
            this.OriBarcode.HeaderText = "Ori";
            this.OriBarcode.Name = "OriBarcode";
            this.OriBarcode.ReadOnly = true;
            this.OriBarcode.Width = 55;
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(1090, 62);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(100, 21);
            this.tb.TabIndex = 110;
            this.tb.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pass.bmp");
            this.imageList1.Images.SetKeyName(1, "nonpass.bmp");
            this.imageList1.Images.SetKeyName(2, "box.bmp");
            // 
            // serialPort2
            // 
            this.serialPort2.PortName = "COM7";
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort2_DataReceived_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(241, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 30);
            this.label1.TabIndex = 111;
            this.label1.Text = "현재 중량 : ";
            // 
            // lb_w_Weight
            // 
            this.lb_w_Weight.AutoSize = true;
            this.lb_w_Weight.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_w_Weight.ForeColor = System.Drawing.Color.Black;
            this.lb_w_Weight.Location = new System.Drawing.Point(370, 67);
            this.lb_w_Weight.Name = "lb_w_Weight";
            this.lb_w_Weight.Size = new System.Drawing.Size(49, 30);
            this.lb_w_Weight.TabIndex = 112;
            this.lb_w_Weight.Text = "000";
            // 
            // lb_w_LLower
            // 
            this.lb_w_LLower.AutoSize = true;
            this.lb_w_LLower.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_w_LLower.ForeColor = System.Drawing.Color.Black;
            this.lb_w_LLower.Location = new System.Drawing.Point(157, 67);
            this.lb_w_LLower.Name = "lb_w_LLower";
            this.lb_w_LLower.Size = new System.Drawing.Size(49, 30);
            this.lb_w_LLower.TabIndex = 115;
            this.lb_w_LLower.Text = "000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(28, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 30);
            this.label3.TabIndex = 114;
            this.label3.Text = "중량 하한 : ";
            // 
            // lb_w_LUpper
            // 
            this.lb_w_LUpper.AutoSize = true;
            this.lb_w_LUpper.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_w_LUpper.ForeColor = System.Drawing.Color.Black;
            this.lb_w_LUpper.Location = new System.Drawing.Point(580, 67);
            this.lb_w_LUpper.Name = "lb_w_LUpper";
            this.lb_w_LUpper.Size = new System.Drawing.Size(49, 30);
            this.lb_w_LUpper.TabIndex = 117;
            this.lb_w_LUpper.Text = "000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(451, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 30);
            this.label5.TabIndex = 116;
            this.label5.Text = "중량 상한 : ";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(1090, 81);
            this.richTextBox1.Multiline = false;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(82, 18);
            this.richTextBox1.TabIndex = 118;
            this.richTextBox1.Text = "";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(1201, 62);
            this.pictureBox5.TabIndex = 120;
            this.pictureBox5.TabStop = false;
            // 
            // FormWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1202, 806);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lb_w_LUpper);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_w_LLower);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_w_Weight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.wb_w_1);
            this.Controls.Add(this.tb_w_ProgressRate);
            this.Controls.Add(this.tb_w_NoBox);
            this.Controls.Add(this.tb_w_NoScanned);
            this.Controls.Add(this.pictureBox5);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(627, 200);
            this.Name = "FormWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BARCODE_READING_PROGRAM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormWork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox tb_w_NoScanned;
        private System.Windows.Forms.TextBox tb_w_NoBox;
        private System.Windows.Forms.TextBox tb_w_ProgressRate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.WebBrowser wb_w_1;
        public System.IO.Ports.SerialPort serialPort1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALCCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn EONO;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CP;
        private System.Windows.Forms.DataGridViewImageColumn PNONEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriBarcode;
        public System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_w_Weight;
        private System.Windows.Forms.Label lb_w_LLower;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_w_LUpper;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        public System.IO.Ports.SerialPort serialPort3;
    }
}