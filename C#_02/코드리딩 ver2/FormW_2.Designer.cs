
namespace chsj
{
    partial class FormW_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormW_2));
            this.lb_w1 = new System.Windows.Forms.Label();
            this.tb_fw2_LLower = new System.Windows.Forms.TextBox();
            this.tb_fw2_LUpper = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_fw2_Weight = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lb_w1
            // 
            this.lb_w1.AutoSize = true;
            this.lb_w1.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_w1.Location = new System.Drawing.Point(81, 64);
            this.lb_w1.Name = "lb_w1";
            this.lb_w1.Size = new System.Drawing.Size(118, 23);
            this.lb_w1.TabIndex = 1;
            this.lb_w1.Text = "중량검사 결과";
            // 
            // tb_fw2_LLower
            // 
            this.tb_fw2_LLower.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_fw2_LLower.Location = new System.Drawing.Point(33, 114);
            this.tb_fw2_LLower.Name = "tb_fw2_LLower";
            this.tb_fw2_LLower.ReadOnly = true;
            this.tb_fw2_LLower.Size = new System.Drawing.Size(63, 29);
            this.tb_fw2_LLower.TabIndex = 10;
            this.tb_fw2_LLower.TabStop = false;
            this.tb_fw2_LLower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_fw2_LUpper
            // 
            this.tb_fw2_LUpper.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_fw2_LUpper.Location = new System.Drawing.Point(183, 114);
            this.tb_fw2_LUpper.Name = "tb_fw2_LUpper";
            this.tb_fw2_LUpper.ReadOnly = true;
            this.tb_fw2_LUpper.Size = new System.Drawing.Size(63, 29);
            this.tb_fw2_LUpper.TabIndex = 10;
            this.tb_fw2_LUpper.TabStop = false;
            this.tb_fw2_LUpper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label1.Location = new System.Drawing.Point(29, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "중량 하한";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label2.Location = new System.Drawing.Point(187, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "중량 상한";
            // 
            // lb_fw2_Weight
            // 
            this.lb_fw2_Weight.AutoSize = true;
            this.lb_fw2_Weight.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.lb_fw2_Weight.Location = new System.Drawing.Point(105, 109);
            this.lb_fw2_Weight.Name = "lb_fw2_Weight";
            this.lb_fw2_Weight.Size = new System.Drawing.Size(72, 37);
            this.lb_fw2_Weight.TabIndex = 8;
            this.lb_fw2_Weight.Text = "00.0";
            this.lb_fw2_Weight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "nonpass.png");
            // 
            // FormW_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lb_fw2_Weight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_fw2_LUpper);
            this.Controls.Add(this.tb_fw2_LLower);
            this.Controls.Add(this.lb_w1);
            this.Name = "FormW_2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "중량검사";
            this.Load += new System.EventHandler(this.FormW_2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_w1;
        private System.Windows.Forms.TextBox tb_fw2_LLower;
        private System.Windows.Forms.TextBox tb_fw2_LUpper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_fw2_Weight;
        private System.Windows.Forms.ImageList imageList1;
    }
}