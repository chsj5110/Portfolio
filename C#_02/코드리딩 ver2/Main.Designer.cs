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
            this.bt_Type = new System.Windows.Forms.Button();
            this.bt_Login = new System.Windows.Forms.Button();
            this.bt_Order = new System.Windows.Forms.Button();
            this.bt_TypeSet = new System.Windows.Forms.Button();
            this.bt_OrderSet = new System.Windows.Forms.Button();
            this.bt_Work = new System.Windows.Forms.Button();
            this.bt_LoginSet = new System.Windows.Forms.Button();
            this.lb_m_SelectedType = new System.Windows.Forms.Label();
            this.lb_m_SelectedWorker = new System.Windows.Forms.Label();
            this.lb_m_SelectedOrder = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.bt_LOT = new System.Windows.Forms.Button();
            this.lb_m_LOT = new System.Windows.Forms.Label();
            this.btn_EXIT = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cb_vc = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Type
            // 
            this.bt_Type.BackColor = System.Drawing.Color.Transparent;
            this.bt_Type.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Type.BackgroundImage")));
            this.bt_Type.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.bt_Type.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_Type.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_Type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Type.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_Type.ForeColor = System.Drawing.Color.Transparent;
            this.bt_Type.Location = new System.Drawing.Point(85, 150);
            this.bt_Type.Name = "bt_Type";
            this.bt_Type.Size = new System.Drawing.Size(511, 94);
            this.bt_Type.TabIndex = 0;
            this.bt_Type.UseVisualStyleBackColor = false;
            this.bt_Type.Click += new System.EventHandler(this.bt_Type_Click);
            // 
            // bt_Login
            // 
            this.bt_Login.BackColor = System.Drawing.Color.Transparent;
            this.bt_Login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Login.BackgroundImage")));
            this.bt_Login.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.bt_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Login.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_Login.ForeColor = System.Drawing.Color.Transparent;
            this.bt_Login.Location = new System.Drawing.Point(85, 247);
            this.bt_Login.Name = "bt_Login";
            this.bt_Login.Size = new System.Drawing.Size(511, 94);
            this.bt_Login.TabIndex = 1;
            this.bt_Login.UseVisualStyleBackColor = false;
            this.bt_Login.Click += new System.EventHandler(this.bt_Login_Click);
            // 
            // bt_Order
            // 
            this.bt_Order.BackColor = System.Drawing.Color.Transparent;
            this.bt_Order.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Order.BackgroundImage")));
            this.bt_Order.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.bt_Order.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_Order.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_Order.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Order.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_Order.Location = new System.Drawing.Point(83, 340);
            this.bt_Order.Name = "bt_Order";
            this.bt_Order.Size = new System.Drawing.Size(511, 94);
            this.bt_Order.TabIndex = 2;
            this.bt_Order.UseVisualStyleBackColor = false;
            this.bt_Order.Click += new System.EventHandler(this.bt_Order_Click);
            // 
            // bt_TypeSet
            // 
            this.bt_TypeSet.BackColor = System.Drawing.Color.Transparent;
            this.bt_TypeSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_TypeSet.BackgroundImage")));
            this.bt_TypeSet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.bt_TypeSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_TypeSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_TypeSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_TypeSet.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_TypeSet.ForeColor = System.Drawing.Color.Transparent;
            this.bt_TypeSet.Location = new System.Drawing.Point(85, 534);
            this.bt_TypeSet.Name = "bt_TypeSet";
            this.bt_TypeSet.Size = new System.Drawing.Size(511, 94);
            this.bt_TypeSet.TabIndex = 4;
            this.bt_TypeSet.UseVisualStyleBackColor = false;
            this.bt_TypeSet.Click += new System.EventHandler(this.bt_TypeSet_Click);
            // 
            // bt_OrderSet
            // 
            this.bt_OrderSet.BackColor = System.Drawing.Color.Transparent;
            this.bt_OrderSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_OrderSet.BackgroundImage")));
            this.bt_OrderSet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.bt_OrderSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_OrderSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_OrderSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_OrderSet.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_OrderSet.ForeColor = System.Drawing.Color.Transparent;
            this.bt_OrderSet.Location = new System.Drawing.Point(85, 726);
            this.bt_OrderSet.Name = "bt_OrderSet";
            this.bt_OrderSet.Size = new System.Drawing.Size(511, 94);
            this.bt_OrderSet.TabIndex = 5;
            this.bt_OrderSet.UseVisualStyleBackColor = false;
            this.bt_OrderSet.Click += new System.EventHandler(this.bt_OrderSet_Click);
            // 
            // bt_Work
            // 
            this.bt_Work.BackColor = System.Drawing.Color.Transparent;
            this.bt_Work.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_Work.BackgroundImage")));
            this.bt_Work.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.bt_Work.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_Work.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_Work.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Work.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_Work.ForeColor = System.Drawing.Color.Transparent;
            this.bt_Work.Location = new System.Drawing.Point(83, 826);
            this.bt_Work.Name = "bt_Work";
            this.bt_Work.Size = new System.Drawing.Size(511, 181);
            this.bt_Work.TabIndex = 6;
            this.bt_Work.UseVisualStyleBackColor = false;
            this.bt_Work.Click += new System.EventHandler(this.bt_Work_Click);
            // 
            // bt_LoginSet
            // 
            this.bt_LoginSet.BackColor = System.Drawing.Color.Transparent;
            this.bt_LoginSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_LoginSet.BackgroundImage")));
            this.bt_LoginSet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.bt_LoginSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_LoginSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_LoginSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_LoginSet.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_LoginSet.ForeColor = System.Drawing.Color.Transparent;
            this.bt_LoginSet.Location = new System.Drawing.Point(83, 628);
            this.bt_LoginSet.Name = "bt_LoginSet";
            this.bt_LoginSet.Size = new System.Drawing.Size(511, 94);
            this.bt_LoginSet.TabIndex = 8;
            this.bt_LoginSet.UseVisualStyleBackColor = false;
            this.bt_LoginSet.Click += new System.EventHandler(this.bt_LoginSet_Click);
            // 
            // lb_m_SelectedType
            // 
            this.lb_m_SelectedType.AutoSize = true;
            this.lb_m_SelectedType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.lb_m_SelectedType.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_m_SelectedType.ForeColor = System.Drawing.Color.White;
            this.lb_m_SelectedType.Location = new System.Drawing.Point(792, 163);
            this.lb_m_SelectedType.Name = "lb_m_SelectedType";
            this.lb_m_SelectedType.Size = new System.Drawing.Size(124, 23);
            this.lb_m_SelectedType.TabIndex = 10;
            this.lb_m_SelectedType.Text = "선택 차종 표시";
            this.lb_m_SelectedType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_m_SelectedWorker
            // 
            this.lb_m_SelectedWorker.AutoSize = true;
            this.lb_m_SelectedWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.lb_m_SelectedWorker.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_m_SelectedWorker.ForeColor = System.Drawing.Color.White;
            this.lb_m_SelectedWorker.Location = new System.Drawing.Point(1214, 163);
            this.lb_m_SelectedWorker.Name = "lb_m_SelectedWorker";
            this.lb_m_SelectedWorker.Size = new System.Drawing.Size(141, 23);
            this.lb_m_SelectedWorker.TabIndex = 11;
            this.lb_m_SelectedWorker.Text = "선택 작업자 표시";
            this.lb_m_SelectedWorker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_m_SelectedOrder
            // 
            this.lb_m_SelectedOrder.AutoSize = true;
            this.lb_m_SelectedOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.lb_m_SelectedOrder.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_m_SelectedOrder.ForeColor = System.Drawing.Color.White;
            this.lb_m_SelectedOrder.Location = new System.Drawing.Point(1439, 163);
            this.lb_m_SelectedOrder.Name = "lb_m_SelectedOrder";
            this.lb_m_SelectedOrder.Size = new System.Drawing.Size(124, 23);
            this.lb_m_SelectedOrder.TabIndex = 12;
            this.lb_m_SelectedOrder.Text = "선택 오더 표시";
            this.lb_m_SelectedOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_LOT
            // 
            this.bt_LOT.BackColor = System.Drawing.Color.Transparent;
            this.bt_LOT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_LOT.BackgroundImage")));
            this.bt_LOT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.bt_LOT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_LOT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_LOT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_LOT.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_LOT.ForeColor = System.Drawing.Color.Transparent;
            this.bt_LOT.Location = new System.Drawing.Point(83, 438);
            this.bt_LOT.Name = "bt_LOT";
            this.bt_LOT.Size = new System.Drawing.Size(511, 94);
            this.bt_LOT.TabIndex = 13;
            this.bt_LOT.UseVisualStyleBackColor = false;
            this.bt_LOT.Click += new System.EventHandler(this.bt_m_LOT_Click);
            // 
            // lb_m_LOT
            // 
            this.lb_m_LOT.AutoSize = true;
            this.lb_m_LOT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.lb_m_LOT.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_m_LOT.ForeColor = System.Drawing.Color.White;
            this.lb_m_LOT.Location = new System.Drawing.Point(1028, 163);
            this.lb_m_LOT.Name = "lb_m_LOT";
            this.lb_m_LOT.Size = new System.Drawing.Size(74, 23);
            this.lb_m_LOT.TabIndex = 14;
            this.lb_m_LOT.Text = "LOT번호";
            this.lb_m_LOT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_EXIT
            // 
            this.btn_EXIT.BackColor = System.Drawing.Color.Transparent;
            this.btn_EXIT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_EXIT.BackgroundImage")));
            this.btn_EXIT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_EXIT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_EXIT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_EXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EXIT.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.btn_EXIT.ForeColor = System.Drawing.Color.Transparent;
            this.btn_EXIT.Location = new System.Drawing.Point(1623, 32);
            this.btn_EXIT.Name = "btn_EXIT";
            this.btn_EXIT.Size = new System.Drawing.Size(210, 60);
            this.btn_EXIT.TabIndex = 15;
            this.btn_EXIT.UseVisualStyleBackColor = false;
            this.btn_EXIT.Click += new System.EventHandler(this.btn_EXIT_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1920, 150);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 150);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(630, 931);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Location = new System.Drawing.Point(629, 1007);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1204, 73);
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.Location = new System.Drawing.Point(1829, 150);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(92, 930);
            this.pictureBox4.TabIndex = 20;
            this.pictureBox4.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.Location = new System.Drawing.Point(630, 150);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(1202, 52);
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(932, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "LOT번호 : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(738, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 23);
            this.label2.TabIndex = 25;
            this.label2.Text = "차종 : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1147, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "작업자 :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1389, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "오더 :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(1796, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "●";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_vc
            // 
            this.cb_vc.AutoSize = true;
            this.cb_vc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.cb_vc.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cb_vc.ForeColor = System.Drawing.Color.White;
            this.cb_vc.Location = new System.Drawing.Point(636, 123);
            this.cb_vc.Name = "cb_vc";
            this.cb_vc.Size = new System.Drawing.Size(154, 27);
            this.cb_vc.TabIndex = 31;
            this.cb_vc.Text = "비전카메라 사용";
            this.cb_vc.UseVisualStyleBackColor = false;
            this.cb_vc.CheckedChanged += new System.EventHandler(this.cb_vc_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.cb_vc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lb_m_LOT);
            this.Controls.Add(this.lb_m_SelectedOrder);
            this.Controls.Add(this.lb_m_SelectedWorker);
            this.Controls.Add(this.lb_m_SelectedType);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.bt_LOT);
            this.Controls.Add(this.bt_LoginSet);
            this.Controls.Add(this.bt_Work);
            this.Controls.Add(this.bt_OrderSet);
            this.Controls.Add(this.bt_TypeSet);
            this.Controls.Add(this.bt_Order);
            this.Controls.Add(this.bt_Login);
            this.Controls.Add(this.bt_Type);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btn_EXIT);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Type;
        private System.Windows.Forms.Button bt_Login;
        private System.Windows.Forms.Button bt_Order;
        private System.Windows.Forms.Button bt_TypeSet;
        private System.Windows.Forms.Button bt_OrderSet;
        private System.Windows.Forms.Button bt_Work;
        private System.Windows.Forms.Button bt_LoginSet;
        public System.Windows.Forms.Label lb_m_SelectedWorker;
        public System.Windows.Forms.Label lb_m_SelectedOrder;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button bt_LOT;
        public System.Windows.Forms.Label lb_m_LOT;
        private System.Windows.Forms.Button btn_EXIT;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        internal System.Windows.Forms.Label lb_m_SelectedType;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox5;
        public System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox cb_vc;
    }
}

