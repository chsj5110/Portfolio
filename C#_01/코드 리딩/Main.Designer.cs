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
            this.SuspendLayout();
            // 
            // bt_Type
            // 
            this.bt_Type.BackColor = System.Drawing.Color.White;
            this.bt_Type.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_Type.Location = new System.Drawing.Point(163, 48);
            this.bt_Type.Name = "bt_Type";
            this.bt_Type.Size = new System.Drawing.Size(124, 44);
            this.bt_Type.TabIndex = 0;
            this.bt_Type.Text = "차종 선택";
            this.bt_Type.UseVisualStyleBackColor = false;
            this.bt_Type.Click += new System.EventHandler(this.bt_Type_Click);
            // 
            // bt_Login
            // 
            this.bt_Login.BackColor = System.Drawing.Color.White;
            this.bt_Login.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_Login.Location = new System.Drawing.Point(163, 104);
            this.bt_Login.Name = "bt_Login";
            this.bt_Login.Size = new System.Drawing.Size(124, 44);
            this.bt_Login.TabIndex = 1;
            this.bt_Login.Text = "작업자 선택";
            this.bt_Login.UseVisualStyleBackColor = false;
            this.bt_Login.Click += new System.EventHandler(this.bt_Login_Click);
            // 
            // bt_Order
            // 
            this.bt_Order.BackColor = System.Drawing.Color.White;
            this.bt_Order.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_Order.Location = new System.Drawing.Point(163, 161);
            this.bt_Order.Name = "bt_Order";
            this.bt_Order.Size = new System.Drawing.Size(124, 44);
            this.bt_Order.TabIndex = 2;
            this.bt_Order.Text = "오더 선택";
            this.bt_Order.UseVisualStyleBackColor = false;
            this.bt_Order.Click += new System.EventHandler(this.bt_Order_Click);
            // 
            // bt_TypeSet
            // 
            this.bt_TypeSet.BackColor = System.Drawing.Color.White;
            this.bt_TypeSet.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_TypeSet.Location = new System.Drawing.Point(163, 299);
            this.bt_TypeSet.Name = "bt_TypeSet";
            this.bt_TypeSet.Size = new System.Drawing.Size(124, 44);
            this.bt_TypeSet.TabIndex = 4;
            this.bt_TypeSet.Text = "차종 관리";
            this.bt_TypeSet.UseVisualStyleBackColor = false;
            this.bt_TypeSet.Click += new System.EventHandler(this.bt_TypeSet_Click);
            // 
            // bt_OrderSet
            // 
            this.bt_OrderSet.BackColor = System.Drawing.Color.White;
            this.bt_OrderSet.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_OrderSet.Location = new System.Drawing.Point(227, 349);
            this.bt_OrderSet.Name = "bt_OrderSet";
            this.bt_OrderSet.Size = new System.Drawing.Size(124, 44);
            this.bt_OrderSet.TabIndex = 5;
            this.bt_OrderSet.Text = "오더 관리";
            this.bt_OrderSet.UseVisualStyleBackColor = false;
            this.bt_OrderSet.Click += new System.EventHandler(this.bt_OrderSet_Click);
            // 
            // bt_Work
            // 
            this.bt_Work.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_Work.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_Work.Location = new System.Drawing.Point(227, 439);
            this.bt_Work.Name = "bt_Work";
            this.bt_Work.Size = new System.Drawing.Size(124, 44);
            this.bt_Work.TabIndex = 6;
            this.bt_Work.Text = "작업 시작";
            this.bt_Work.UseVisualStyleBackColor = false;
            this.bt_Work.Click += new System.EventHandler(this.bt_Work_Click);
            // 
            // bt_LoginSet
            // 
            this.bt_LoginSet.BackColor = System.Drawing.Color.White;
            this.bt_LoginSet.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_LoginSet.Location = new System.Drawing.Point(293, 299);
            this.bt_LoginSet.Name = "bt_LoginSet";
            this.bt_LoginSet.Size = new System.Drawing.Size(124, 44);
            this.bt_LoginSet.TabIndex = 8;
            this.bt_LoginSet.Text = "작업자 관리";
            this.bt_LoginSet.UseVisualStyleBackColor = false;
            this.bt_LoginSet.Click += new System.EventHandler(this.bt_LoginSet_Click);
            // 
            // lb_m_SelectedType
            // 
            this.lb_m_SelectedType.AutoSize = true;
            this.lb_m_SelectedType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(80)))), ((int)(((byte)(204)))));
            this.lb_m_SelectedType.Font = new System.Drawing.Font("굴림", 13F);
            this.lb_m_SelectedType.Location = new System.Drawing.Point(309, 61);
            this.lb_m_SelectedType.Name = "lb_m_SelectedType";
            this.lb_m_SelectedType.Size = new System.Drawing.Size(0, 18);
            this.lb_m_SelectedType.TabIndex = 10;
            this.lb_m_SelectedType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_m_SelectedWorker
            // 
            this.lb_m_SelectedWorker.AutoSize = true;
            this.lb_m_SelectedWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(80)))), ((int)(((byte)(204)))));
            this.lb_m_SelectedWorker.Font = new System.Drawing.Font("굴림", 13F);
            this.lb_m_SelectedWorker.Location = new System.Drawing.Point(309, 117);
            this.lb_m_SelectedWorker.Name = "lb_m_SelectedWorker";
            this.lb_m_SelectedWorker.Size = new System.Drawing.Size(0, 18);
            this.lb_m_SelectedWorker.TabIndex = 11;
            this.lb_m_SelectedWorker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_m_SelectedOrder
            // 
            this.lb_m_SelectedOrder.AutoSize = true;
            this.lb_m_SelectedOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(80)))), ((int)(((byte)(204)))));
            this.lb_m_SelectedOrder.Font = new System.Drawing.Font("굴림", 13F);
            this.lb_m_SelectedOrder.Location = new System.Drawing.Point(309, 165);
            this.lb_m_SelectedOrder.Name = "lb_m_SelectedOrder";
            this.lb_m_SelectedOrder.Size = new System.Drawing.Size(0, 18);
            this.lb_m_SelectedOrder.TabIndex = 12;
            this.lb_m_SelectedOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_LOT
            // 
            this.bt_LOT.BackColor = System.Drawing.Color.White;
            this.bt_LOT.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.bt_LOT.Location = new System.Drawing.Point(163, 223);
            this.bt_LOT.Name = "bt_LOT";
            this.bt_LOT.Size = new System.Drawing.Size(124, 44);
            this.bt_LOT.TabIndex = 13;
            this.bt_LOT.Text = "LOT 입력";
            this.bt_LOT.UseVisualStyleBackColor = false;
            this.bt_LOT.Click += new System.EventHandler(this.bt_m_LOT_Click);
            // 
            // lb_m_LOT
            // 
            this.lb_m_LOT.AutoSize = true;
            this.lb_m_LOT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(80)))), ((int)(((byte)(204)))));
            this.lb_m_LOT.Font = new System.Drawing.Font("굴림", 13F);
            this.lb_m_LOT.Location = new System.Drawing.Point(309, 228);
            this.lb_m_LOT.Name = "lb_m_LOT";
            this.lb_m_LOT.Size = new System.Drawing.Size(0, 18);
            this.lb_m_LOT.TabIndex = 14;
            this.lb_m_LOT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.lb_m_LOT);
            this.Controls.Add(this.bt_LOT);
            this.Controls.Add(this.lb_m_SelectedOrder);
            this.Controls.Add(this.lb_m_SelectedWorker);
            this.Controls.Add(this.lb_m_SelectedType);
            this.Controls.Add(this.bt_LoginSet);
            this.Controls.Add(this.bt_Work);
            this.Controls.Add(this.bt_OrderSet);
            this.Controls.Add(this.bt_TypeSet);
            this.Controls.Add(this.bt_Order);
            this.Controls.Add(this.bt_Login);
            this.Controls.Add(this.bt_Type);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
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
        public System.Windows.Forms.Label lb_m_SelectedType;
        public System.Windows.Forms.Label lb_m_SelectedWorker;
        public System.Windows.Forms.Label lb_m_SelectedOrder;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button bt_LOT;
        public System.Windows.Forms.Label lb_m_LOT;
    }
}

