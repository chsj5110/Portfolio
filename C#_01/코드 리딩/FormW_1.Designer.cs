namespace chsj
{
    partial class FormW_1
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
            this.lb_w1 = new System.Windows.Forms.Label();
            this.tb_w1 = new System.Windows.Forms.RichTextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_w1
            // 
            this.lb_w1.AutoSize = true;
            this.lb_w1.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.lb_w1.Location = new System.Drawing.Point(44, 65);
            this.lb_w1.Name = "lb_w1";
            this.lb_w1.Size = new System.Drawing.Size(200, 18);
            this.lb_w1.TabIndex = 0;
            this.lb_w1.Text = "박스를 스캔 해 주세요";
            // 
            // tb_w1
            // 
            this.tb_w1.Location = new System.Drawing.Point(69, 103);
            this.tb_w1.Name = "tb_w1";
            this.tb_w1.Size = new System.Drawing.Size(145, 50);
            this.tb_w1.TabIndex = 2;
            this.tb_w1.Text = "";
            this.tb_w1.TextChanged += new System.EventHandler(this.tb_w1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 10F);
            this.label1.Location = new System.Drawing.Point(53, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "라벨이 제대로 프린트되지 \r\n않았다면 클릭하세요";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FormW_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_w1);
            this.Controls.Add(this.lb_w1);
            this.Name = "FormW_1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormW_1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormW_1_FormClosed);
            this.Load += new System.EventHandler(this.FormW_1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_w1;
        public System.Windows.Forms.RichTextBox tb_w1;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
    }
}