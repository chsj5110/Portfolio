namespace chsj
{
    partial class Form2Login
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
            this.bt_2_Login = new System.Windows.Forms.Button();
            this.lb_2_Name = new System.Windows.Forms.Label();
            this.lb_2_PW = new System.Windows.Forms.Label();
            this.tb_2_PW = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.combobox_2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bt_2_Login
            // 
            this.bt_2_Login.Location = new System.Drawing.Point(99, 143);
            this.bt_2_Login.Name = "bt_2_Login";
            this.bt_2_Login.Size = new System.Drawing.Size(92, 32);
            this.bt_2_Login.TabIndex = 7;
            this.bt_2_Login.Text = "로그인";
            this.bt_2_Login.UseVisualStyleBackColor = true;
            this.bt_2_Login.Click += new System.EventHandler(this.bt_2_Login_Click);
            // 
            // lb_2_Name
            // 
            this.lb_2_Name.AutoSize = true;
            this.lb_2_Name.Location = new System.Drawing.Point(38, 57);
            this.lb_2_Name.Name = "lb_2_Name";
            this.lb_2_Name.Size = new System.Drawing.Size(29, 12);
            this.lb_2_Name.TabIndex = 3;
            this.lb_2_Name.Text = "이름";
            // 
            // lb_2_PW
            // 
            this.lb_2_PW.AutoSize = true;
            this.lb_2_PW.Location = new System.Drawing.Point(20, 107);
            this.lb_2_PW.Name = "lb_2_PW";
            this.lb_2_PW.Size = new System.Drawing.Size(53, 12);
            this.lb_2_PW.TabIndex = 4;
            this.lb_2_PW.Text = "패스워드";
            // 
            // tb_2_PW
            // 
            this.tb_2_PW.Location = new System.Drawing.Point(96, 104);
            this.tb_2_PW.Name = "tb_2_PW";
            this.tb_2_PW.Size = new System.Drawing.Size(121, 21);
            this.tb_2_PW.TabIndex = 6;
            this.tb_2_PW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_2_PW_KeyDown);
            // 
            // combobox_2
            // 
            this.combobox_2.FormattingEnabled = true;
            this.combobox_2.Location = new System.Drawing.Point(96, 54);
            this.combobox_2.Name = "combobox_2";
            this.combobox_2.Size = new System.Drawing.Size(121, 20);
            this.combobox_2.TabIndex = 8;
            this.combobox_2.SelectedIndexChanged += new System.EventHandler(this.combobox_2_SelectedIndexChanged);
            // 
            // Form2Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(261, 207);
            this.Controls.Add(this.combobox_2);
            this.Controls.Add(this.tb_2_PW);
            this.Controls.Add(this.lb_2_PW);
            this.Controls.Add(this.lb_2_Name);
            this.Controls.Add(this.bt_2_Login);
            this.Name = "Form2Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "작업자 선택";
            this.Load += new System.EventHandler(this.Form2Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_2_Login;
        private System.Windows.Forms.Label lb_2_Name;
        private System.Windows.Forms.Label lb_2_PW;
        private System.Windows.Forms.TextBox tb_2_PW;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox combobox_2;
    }
}