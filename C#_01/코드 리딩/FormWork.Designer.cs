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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_EXIT = new System.Windows.Forms.Button();
            this.button_START = new System.Windows.Forms.Button();
            this.button_STOP = new System.Windows.Forms.Button();
            this.lb_w_WorkingOrder = new System.Windows.Forms.Label();
            this.lb_w_Order = new System.Windows.Forms.Label();
            this.lb_w_NoScanned = new System.Windows.Forms.Label();
            this.lb_w_NoBox = new System.Windows.Forms.Label();
            this.lb_w_ProgressRate = new System.Windows.Forms.Label();
            this.tb_w_NoScanned = new System.Windows.Forms.TextBox();
            this.tb_w_NoBox = new System.Windows.Forms.TextBox();
            this.tb_w_ProgressRate = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.wb_w_1 = new System.Windows.Forms.WebBrowser();
            this.wb_w_2 = new System.Windows.Forms.WebBrowser();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tb = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox7 = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ComCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALCCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EONO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PNONEP = new System.Windows.Forms.DataGridViewImageColumn();
            this.OriBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_EXIT
            // 
            this.button_EXIT.BackColor = System.Drawing.Color.Black;
            this.button_EXIT.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_EXIT.ForeColor = System.Drawing.SystemColors.Control;
            this.button_EXIT.Location = new System.Drawing.Point(1726, 138);
            this.button_EXIT.Name = "button_EXIT";
            this.button_EXIT.Size = new System.Drawing.Size(150, 35);
            this.button_EXIT.TabIndex = 78;
            this.button_EXIT.Text = "EXIT";
            this.button_EXIT.UseVisualStyleBackColor = false;
            this.button_EXIT.Click += new System.EventHandler(this.button_EXIT_Click);
            // 
            // button_START
            // 
            this.button_START.BackColor = System.Drawing.Color.Black;
            this.button_START.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_START.ForeColor = System.Drawing.SystemColors.Control;
            this.button_START.Location = new System.Drawing.Point(1726, 12);
            this.button_START.Name = "button_START";
            this.button_START.Size = new System.Drawing.Size(150, 77);
            this.button_START.TabIndex = 76;
            this.button_START.Text = "START";
            this.button_START.UseVisualStyleBackColor = false;
            this.button_START.Click += new System.EventHandler(this.button_START_Click);
            // 
            // button_STOP
            // 
            this.button_STOP.BackColor = System.Drawing.Color.Black;
            this.button_STOP.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_STOP.ForeColor = System.Drawing.SystemColors.Control;
            this.button_STOP.Location = new System.Drawing.Point(1726, 96);
            this.button_STOP.Name = "button_STOP";
            this.button_STOP.Size = new System.Drawing.Size(150, 35);
            this.button_STOP.TabIndex = 77;
            this.button_STOP.Text = "STOP";
            this.button_STOP.UseVisualStyleBackColor = false;
            this.button_STOP.Click += new System.EventHandler(this.button_STOP_Click);
            // 
            // lb_w_WorkingOrder
            // 
            this.lb_w_WorkingOrder.AutoSize = true;
            this.lb_w_WorkingOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(80)))), ((int)(((byte)(204)))));
            this.lb_w_WorkingOrder.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.lb_w_WorkingOrder.ForeColor = System.Drawing.Color.White;
            this.lb_w_WorkingOrder.Location = new System.Drawing.Point(422, 9);
            this.lb_w_WorkingOrder.Name = "lb_w_WorkingOrder";
            this.lb_w_WorkingOrder.Size = new System.Drawing.Size(110, 24);
            this.lb_w_WorkingOrder.TabIndex = 81;
            this.lb_w_WorkingOrder.Text = "진행오더";
            this.lb_w_WorkingOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_w_Order
            // 
            this.lb_w_Order.AutoSize = true;
            this.lb_w_Order.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(80)))), ((int)(((byte)(204)))));
            this.lb_w_Order.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.lb_w_Order.ForeColor = System.Drawing.Color.White;
            this.lb_w_Order.Location = new System.Drawing.Point(761, 9);
            this.lb_w_Order.Name = "lb_w_Order";
            this.lb_w_Order.Size = new System.Drawing.Size(110, 24);
            this.lb_w_Order.TabIndex = 82;
            this.lb_w_Order.Text = "진행오더";
            this.lb_w_Order.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_w_NoScanned
            // 
            this.lb_w_NoScanned.AutoSize = true;
            this.lb_w_NoScanned.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(80)))), ((int)(((byte)(204)))));
            this.lb_w_NoScanned.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.lb_w_NoScanned.ForeColor = System.Drawing.Color.White;
            this.lb_w_NoScanned.Location = new System.Drawing.Point(422, 77);
            this.lb_w_NoScanned.Name = "lb_w_NoScanned";
            this.lb_w_NoScanned.Size = new System.Drawing.Size(110, 24);
            this.lb_w_NoScanned.TabIndex = 83;
            this.lb_w_NoScanned.Text = "스캔수량";
            this.lb_w_NoScanned.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_w_NoBox
            // 
            this.lb_w_NoBox.AutoSize = true;
            this.lb_w_NoBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(80)))), ((int)(((byte)(204)))));
            this.lb_w_NoBox.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.lb_w_NoBox.ForeColor = System.Drawing.Color.White;
            this.lb_w_NoBox.Location = new System.Drawing.Point(813, 65);
            this.lb_w_NoBox.Name = "lb_w_NoBox";
            this.lb_w_NoBox.Size = new System.Drawing.Size(110, 48);
            this.lb_w_NoBox.TabIndex = 85;
            this.lb_w_NoBox.Text = "포장박스\r\n수량";
            this.lb_w_NoBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_w_ProgressRate
            // 
            this.lb_w_ProgressRate.AutoSize = true;
            this.lb_w_ProgressRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(80)))), ((int)(((byte)(204)))));
            this.lb_w_ProgressRate.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.lb_w_ProgressRate.ForeColor = System.Drawing.Color.White;
            this.lb_w_ProgressRate.Location = new System.Drawing.Point(1202, 77);
            this.lb_w_ProgressRate.Name = "lb_w_ProgressRate";
            this.lb_w_ProgressRate.Size = new System.Drawing.Size(85, 24);
            this.lb_w_ProgressRate.TabIndex = 87;
            this.lb_w_ProgressRate.Text = "진행률";
            this.lb_w_ProgressRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_w_NoScanned
            // 
            this.tb_w_NoScanned.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_w_NoScanned.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.tb_w_NoScanned.ForeColor = System.Drawing.Color.Red;
            this.tb_w_NoScanned.Location = new System.Drawing.Point(538, 77);
            this.tb_w_NoScanned.Name = "tb_w_NoScanned";
            this.tb_w_NoScanned.ReadOnly = true;
            this.tb_w_NoScanned.Size = new System.Drawing.Size(215, 28);
            this.tb_w_NoScanned.TabIndex = 88;
            this.tb_w_NoScanned.Text = "현재 스캔 된 수량";
            this.tb_w_NoScanned.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_w_NoBox
            // 
            this.tb_w_NoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_w_NoBox.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.tb_w_NoBox.ForeColor = System.Drawing.Color.Red;
            this.tb_w_NoBox.Location = new System.Drawing.Point(929, 77);
            this.tb_w_NoBox.Name = "tb_w_NoBox";
            this.tb_w_NoBox.ReadOnly = true;
            this.tb_w_NoBox.Size = new System.Drawing.Size(215, 28);
            this.tb_w_NoBox.TabIndex = 89;
            this.tb_w_NoBox.Text = "스캔수량/포장단위";
            this.tb_w_NoBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_w_ProgressRate
            // 
            this.tb_w_ProgressRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_w_ProgressRate.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.tb_w_ProgressRate.ForeColor = System.Drawing.Color.Red;
            this.tb_w_ProgressRate.Location = new System.Drawing.Point(1293, 77);
            this.tb_w_ProgressRate.Name = "tb_w_ProgressRate";
            this.tb_w_ProgressRate.ReadOnly = true;
            this.tb_w_ProgressRate.Size = new System.Drawing.Size(215, 28);
            this.tb_w_ProgressRate.TabIndex = 90;
            this.tb_w_ProgressRate.Text = "현재 스캔 된 수량";
            this.tb_w_ProgressRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // wb_w_1
            // 
            this.wb_w_1.Location = new System.Drawing.Point(52, 200);
            this.wb_w_1.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb_w_1.Name = "wb_w_1";
            this.wb_w_1.Size = new System.Drawing.Size(885, 497);
            this.wb_w_1.TabIndex = 91;
            this.wb_w_1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_w_1_DocumentCompleted);
            // 
            // wb_w_2
            // 
            this.wb_w_2.Location = new System.Drawing.Point(981, 200);
            this.wb_w_2.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb_w_2.Name = "wb_w_2";
            this.wb_w_2.Size = new System.Drawing.Size(884, 497);
            this.wb_w_2.TabIndex = 92;
            this.wb_w_2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_w_2_DocumentCompleted);
            // 
            // tb
            // 
            this.tb.Font = new System.Drawing.Font("굴림", 20F);
            this.tb.Location = new System.Drawing.Point(52, 716);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(463, 38);
            this.tb.TabIndex = 96;
            this.tb.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(52, 126);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(166, 53);
            this.richTextBox1.TabIndex = 97;
            this.richTextBox1.Text = "";
            // 
            // richTextBox7
            // 
            this.richTextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox7.Font = new System.Drawing.Font("굴림", 10F);
            this.richTextBox7.Location = new System.Drawing.Point(1453, 943);
            this.richTextBox7.Name = "richTextBox7";
            this.richTextBox7.Size = new System.Drawing.Size(234, 29);
            this.richTextBox7.TabIndex = 103;
            this.richTextBox7.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComCode,
            this.No,
            this.ALCCode,
            this.EONO,
            this.PNONEP,
            this.OriBarcode});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("굴림", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Location = new System.Drawing.Point(52, 775);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1815, 281);
            this.dataGridView1.TabIndex = 106;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // ComCode
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.ComCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.ComCode.Frozen = true;
            this.ComCode.HeaderText = "업체코드";
            this.ComCode.Name = "ComCode";
            this.ComCode.ReadOnly = true;
            this.ComCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ComCode.Width = 200;
            // 
            // No
            // 
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.No.DefaultCellStyle = dataGridViewCellStyle3;
            this.No.Frozen = true;
            this.No.HeaderText = "품번";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 400;
            // 
            // ALCCode
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.ALCCode.DefaultCellStyle = dataGridViewCellStyle4;
            this.ALCCode.Frozen = true;
            this.ALCCode.HeaderText = "ALC코드";
            this.ALCCode.Name = "ALCCode";
            this.ALCCode.ReadOnly = true;
            this.ALCCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ALCCode.Width = 300;
            // 
            // EONO
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.EONO.DefaultCellStyle = dataGridViewCellStyle5;
            this.EONO.Frozen = true;
            this.EONO.HeaderText = "EO NO";
            this.EONO.Name = "EONO";
            this.EONO.ReadOnly = true;
            this.EONO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EONO.Width = 400;
            // 
            // PNONEP
            // 
            this.PNONEP.Frozen = true;
            this.PNONEP.HeaderText = "판정";
            this.PNONEP.Name = "PNONEP";
            this.PNONEP.ReadOnly = true;
            this.PNONEP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PNONEP.Width = 200;
            // 
            // OriBarcode
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Silver;
            this.OriBarcode.DefaultCellStyle = dataGridViewCellStyle6;
            this.OriBarcode.Frozen = true;
            this.OriBarcode.HeaderText = "Ori";
            this.OriBarcode.Name = "OriBarcode";
            this.OriBarcode.ReadOnly = true;
            this.OriBarcode.Width = 250;
            // 
            // label1
            // 
            this.label1.Image = global::chsj.Properties.Resources._11;
            this.label1.Location = new System.Drawing.Point(50, 716);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(887, 39);
            this.label1.TabIndex = 107;
            // 
            // label2
            // 
            this.label2.Image = global::chsj.Properties.Resources._11;
            this.label2.Location = new System.Drawing.Point(980, 716);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(887, 39);
            this.label2.TabIndex = 108;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(998, 775);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(887, 39);
            this.label3.TabIndex = 109;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Image = global::chsj.Properties.Resources.ji_korea;
            this.label4.Location = new System.Drawing.Point(35, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(357, 89);
            this.label4.TabIndex = 110;
            // 
            // FormWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::chsj.Properties.Resources.BackGround;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.richTextBox7);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.wb_w_2);
            this.Controls.Add(this.wb_w_1);
            this.Controls.Add(this.tb_w_ProgressRate);
            this.Controls.Add(this.tb_w_NoBox);
            this.Controls.Add(this.tb_w_NoScanned);
            this.Controls.Add(this.lb_w_ProgressRate);
            this.Controls.Add(this.lb_w_NoBox);
            this.Controls.Add(this.lb_w_NoScanned);
            this.Controls.Add(this.lb_w_Order);
            this.Controls.Add(this.lb_w_WorkingOrder);
            this.Controls.Add(this.button_EXIT);
            this.Controls.Add(this.button_START);
            this.Controls.Add(this.button_STOP);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BARCODE_READING_PROGRAM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormWork_FormClosed);
            this.Load += new System.EventHandler(this.FormWork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_EXIT;
        private System.Windows.Forms.Button button_START;
        private System.Windows.Forms.Button button_STOP;
        private System.Windows.Forms.Label lb_w_WorkingOrder;
        private System.Windows.Forms.Label lb_w_Order;
        private System.Windows.Forms.Label lb_w_NoScanned;
        private System.Windows.Forms.Label lb_w_NoBox;
        private System.Windows.Forms.Label lb_w_ProgressRate;
        public System.Windows.Forms.TextBox tb_w_NoScanned;
        private System.Windows.Forms.TextBox tb_w_NoBox;
        private System.Windows.Forms.TextBox tb_w_ProgressRate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.WebBrowser wb_w_1;
        private System.Windows.Forms.WebBrowser wb_w_2;
        public System.IO.Ports.SerialPort serialPort1;
        public System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox7;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALCCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn EONO;
        private System.Windows.Forms.DataGridViewImageColumn PNONEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriBarcode;
        private System.Windows.Forms.Label label4;
    }
}