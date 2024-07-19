namespace chsj
{
    partial class Form8LOT
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
            this.lb_8 = new System.Windows.Forms.Label();
            this.tb_8_LOT = new System.Windows.Forms.RichTextBox();
            this.bt_8_Select = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_8
            // 
            this.lb_8.AutoSize = true;
            this.lb_8.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.lb_8.Location = new System.Drawing.Point(60, 56);
            this.lb_8.Name = "lb_8";
            this.lb_8.Size = new System.Drawing.Size(164, 18);
            this.lb_8.TabIndex = 5;
            this.lb_8.Text = "LOT를 입력하세요";
            // 
            // tb_8_LOT
            // 
            this.tb_8_LOT.Location = new System.Drawing.Point(60, 99);
            this.tb_8_LOT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_8_LOT.Multiline = false;
            this.tb_8_LOT.Name = "tb_8_LOT";
            this.tb_8_LOT.Size = new System.Drawing.Size(165, 62);
            this.tb_8_LOT.TabIndex = 6;
            this.tb_8_LOT.Text = "";
            // 
            // bt_8_Select
            // 
            this.bt_8_Select.BackColor = System.Drawing.Color.White;
            this.bt_8_Select.Location = new System.Drawing.Point(83, 169);
            this.bt_8_Select.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_8_Select.Name = "bt_8_Select";
            this.bt_8_Select.Size = new System.Drawing.Size(114, 35);
            this.bt_8_Select.TabIndex = 7;
            this.bt_8_Select.Text = "선택";
            this.bt_8_Select.UseVisualStyleBackColor = false;
            this.bt_8_Select.Click += new System.EventHandler(this.bt_8_Select_Click);
            // 
            // Form8LOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.bt_8_Select);
            this.Controls.Add(this.tb_8_LOT);
            this.Controls.Add(this.lb_8);
            this.Name = "Form8LOT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form8LOT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_8;
        public System.Windows.Forms.RichTextBox tb_8_LOT;
        public System.Windows.Forms.Button bt_8_Select;
    }
}