
namespace chsj
{
    partial class Model
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
            this.cogJobManagerEdit1 = new Cognex.VisionPro.QuickBuild.CogJobManagerEdit();
            this.lb_Model = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cogJobManagerEdit1
            // 
            this.cogJobManagerEdit1.Location = new System.Drawing.Point(46, 78);
            this.cogJobManagerEdit1.Name = "cogJobManagerEdit1";
            this.cogJobManagerEdit1.ShowLocalizationTab = false;
            this.cogJobManagerEdit1.Size = new System.Drawing.Size(776, 404);
            this.cogJobManagerEdit1.Subject = null;
            this.cogJobManagerEdit1.TabIndex = 1;
            // 
            // lb_Model
            // 
            this.lb_Model.AutoSize = true;
            this.lb_Model.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Model.Location = new System.Drawing.Point(12, 9);
            this.lb_Model.Name = "lb_Model";
            this.lb_Model.Size = new System.Drawing.Size(91, 28);
            this.lb_Model.TabIndex = 2;
            this.lb_Model.Text = "Model : ";
            // 
            // Model
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(869, 560);
            this.Controls.Add(this.lb_Model);
            this.Controls.Add(this.cogJobManagerEdit1);
            this.Name = "Model";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cognex.VisionPro.QuickBuild.CogJobManagerEdit cogJobManagerEdit1;
        private System.Windows.Forms.Label lb_Model;
    }
}