namespace chsj
{
    partial class Form0Password
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
            this.bt_0 = new System.Windows.Forms.Button();
            this.tb_0 = new System.Windows.Forms.TextBox();
            this.lb_0 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_0
            // 
            this.bt_0.Location = new System.Drawing.Point(104, 138);
            this.bt_0.Name = "bt_0";
            this.bt_0.Size = new System.Drawing.Size(75, 23);
            this.bt_0.TabIndex = 0;
            this.bt_0.Text = "확인";
            this.bt_0.UseVisualStyleBackColor = true;
            this.bt_0.Click += new System.EventHandler(this.bt_0_Click);
            // 
            // tb_0
            // 
            this.tb_0.Font = new System.Drawing.Font("굴림", 15F);
            this.tb_0.Location = new System.Drawing.Point(86, 94);
            this.tb_0.Name = "tb_0";
            this.tb_0.PasswordChar = '*';
            this.tb_0.Size = new System.Drawing.Size(113, 30);
            this.tb_0.TabIndex = 1;
            this.tb_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_0_KeyDown);
            // 
            // lb_0
            // 
            this.lb_0.AutoSize = true;
            this.lb_0.Font = new System.Drawing.Font("굴림", 13F);
            this.lb_0.Location = new System.Drawing.Point(49, 56);
            this.lb_0.Name = "lb_0";
            this.lb_0.Size = new System.Drawing.Size(194, 18);
            this.lb_0.TabIndex = 2;
            this.lb_0.Text = "비밀번호를 입력하세요";
            // 
            // Form0Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lb_0);
            this.Controls.Add(this.tb_0);
            this.Controls.Add(this.bt_0);
            this.Name = "Form0Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PASSWORD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_0;
        public System.Windows.Forms.TextBox tb_0;
        private System.Windows.Forms.Label lb_0;
    }
}