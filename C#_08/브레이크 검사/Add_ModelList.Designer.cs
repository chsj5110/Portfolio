
namespace chsj
{
    partial class Add_ModelList
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
            this.btn_BackToMain = new System.Windows.Forms.Button();
            this.tb_ModelName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_UpperLimit = new System.Windows.Forms.TextBox();
            this.tb_LowerLimit = new System.Windows.Forms.TextBox();
            this.btn_SaveModel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LowerLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpperLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AngleScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_Offset = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Score = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_AngleScore = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_6_AdminPW = new System.Windows.Forms.Label();
            this.tb_6_AdminPW = new System.Windows.Forms.RichTextBox();
            this.lb_6_AdminPWSet = new System.Windows.Forms.Label();
            this.btn_passwordsave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_BackToMain
            // 
            this.btn_BackToMain.Location = new System.Drawing.Point(1272, 46);
            this.btn_BackToMain.Name = "btn_BackToMain";
            this.btn_BackToMain.Size = new System.Drawing.Size(211, 71);
            this.btn_BackToMain.TabIndex = 0;
            this.btn_BackToMain.Text = "검사 화면으로 돌아가기";
            this.btn_BackToMain.UseVisualStyleBackColor = true;
            this.btn_BackToMain.Click += new System.EventHandler(this.btn_BackToMain_Click);
            // 
            // tb_ModelName
            // 
            this.tb_ModelName.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.tb_ModelName.Location = new System.Drawing.Point(947, 179);
            this.tb_ModelName.Name = "tb_ModelName";
            this.tb_ModelName.Size = new System.Drawing.Size(378, 34);
            this.tb_ModelName.TabIndex = 133;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(790, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 28);
            this.label1.TabIndex = 134;
            this.label1.Text = "Model Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(790, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 28);
            this.label2.TabIndex = 135;
            this.label2.Text = "한도 설정";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(946, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 19);
            this.label3.TabIndex = 136;
            this.label3.Text = "각도 하한";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(1024, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 137;
            this.label4.Text = "각도 상한";
            // 
            // tb_UpperLimit
            // 
            this.tb_UpperLimit.Font = new System.Drawing.Font("Arial", 12F);
            this.tb_UpperLimit.ForeColor = System.Drawing.Color.Black;
            this.tb_UpperLimit.Location = new System.Drawing.Point(1025, 279);
            this.tb_UpperLimit.Name = "tb_UpperLimit";
            this.tb_UpperLimit.Size = new System.Drawing.Size(66, 26);
            this.tb_UpperLimit.TabIndex = 143;
            this.tb_UpperLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_LowerLimit
            // 
            this.tb_LowerLimit.Font = new System.Drawing.Font("Arial", 12F);
            this.tb_LowerLimit.ForeColor = System.Drawing.Color.Black;
            this.tb_LowerLimit.Location = new System.Drawing.Point(947, 279);
            this.tb_LowerLimit.Name = "tb_LowerLimit";
            this.tb_LowerLimit.Size = new System.Drawing.Size(66, 26);
            this.tb_LowerLimit.TabIndex = 142;
            this.tb_LowerLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_SaveModel
            // 
            this.btn_SaveModel.Location = new System.Drawing.Point(1349, 280);
            this.btn_SaveModel.Name = "btn_SaveModel";
            this.btn_SaveModel.Size = new System.Drawing.Size(63, 26);
            this.btn_SaveModel.TabIndex = 147;
            this.btn_SaveModel.Text = "저장";
            this.btn_SaveModel.UseVisualStyleBackColor = true;
            this.btn_SaveModel.Click += new System.EventHandler(this.btn_SaveModel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.ModelName,
            this.LowerLimit,
            this.UpperLimit,
            this.Column1,
            this.AngleScore,
            this.Score});
            this.dataGridView1.Location = new System.Drawing.Point(23, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(692, 913);
            this.dataGridView1.TabIndex = 150;
            // 
            // Number
            // 
            this.Number.HeaderText = "No.";
            this.Number.Name = "Number";
            this.Number.Width = 30;
            // 
            // ModelName
            // 
            this.ModelName.HeaderText = "모델명";
            this.ModelName.Name = "ModelName";
            this.ModelName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ModelName.Width = 200;
            // 
            // LowerLimit
            // 
            this.LowerLimit.HeaderText = "하한선";
            this.LowerLimit.Name = "LowerLimit";
            this.LowerLimit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LowerLimit.Width = 70;
            // 
            // UpperLimit
            // 
            this.UpperLimit.HeaderText = "상한선";
            this.UpperLimit.Name = "UpperLimit";
            this.UpperLimit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UpperLimit.Width = 70;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Offset";
            this.Column1.Name = "Column1";
            this.Column1.Width = 70;
            // 
            // AngleScore
            // 
            this.AngleScore.HeaderText = "각도 스코어";
            this.AngleScore.Name = "AngleScore";
            // 
            // Score
            // 
            this.Score.HeaderText = "형상 스코어";
            this.Score.Name = "Score";
            // 
            // tb_Offset
            // 
            this.tb_Offset.Font = new System.Drawing.Font("Arial", 12F);
            this.tb_Offset.ForeColor = System.Drawing.Color.Black;
            this.tb_Offset.Location = new System.Drawing.Point(1103, 279);
            this.tb_Offset.Name = "tb_Offset";
            this.tb_Offset.Size = new System.Drawing.Size(66, 26);
            this.tb_Offset.TabIndex = 144;
            this.tb_Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(1112, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 146;
            this.label5.Text = "Offset";
            // 
            // tb_Score
            // 
            this.tb_Score.Font = new System.Drawing.Font("Arial", 12F);
            this.tb_Score.ForeColor = System.Drawing.Color.Black;
            this.tb_Score.Location = new System.Drawing.Point(1259, 279);
            this.tb_Score.Name = "tb_Score";
            this.tb_Score.Size = new System.Drawing.Size(66, 26);
            this.tb_Score.TabIndex = 146;
            this.tb_Score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(1268, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 38);
            this.label6.TabIndex = 152;
            this.label6.Text = "형상\r\n스코어";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_AngleScore
            // 
            this.tb_AngleScore.Font = new System.Drawing.Font("Arial", 12F);
            this.tb_AngleScore.ForeColor = System.Drawing.Color.Black;
            this.tb_AngleScore.Location = new System.Drawing.Point(1181, 279);
            this.tb_AngleScore.Name = "tb_AngleScore";
            this.tb_AngleScore.Size = new System.Drawing.Size(66, 26);
            this.tb_AngleScore.TabIndex = 145;
            this.tb_AngleScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(1190, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 38);
            this.label7.TabIndex = 154;
            this.label7.Text = "각도 \r\n스코어";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(756, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 26);
            this.button1.TabIndex = 155;
            this.button1.Text = "수정";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_6_AdminPW
            // 
            this.lb_6_AdminPW.AutoSize = true;
            this.lb_6_AdminPW.Font = new System.Drawing.Font("굴림", 13F);
            this.lb_6_AdminPW.ForeColor = System.Drawing.SystemColors.Control;
            this.lb_6_AdminPW.Location = new System.Drawing.Point(1025, 878);
            this.lb_6_AdminPW.Name = "lb_6_AdminPW";
            this.lb_6_AdminPW.Size = new System.Drawing.Size(80, 18);
            this.lb_6_AdminPW.TabIndex = 159;
            this.lb_6_AdminPW.Text = "패스워드";
            // 
            // tb_6_AdminPW
            // 
            this.tb_6_AdminPW.BackColor = System.Drawing.SystemColors.Control;
            this.tb_6_AdminPW.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_6_AdminPW.Location = new System.Drawing.Point(1125, 875);
            this.tb_6_AdminPW.Name = "tb_6_AdminPW";
            this.tb_6_AdminPW.Size = new System.Drawing.Size(200, 35);
            this.tb_6_AdminPW.TabIndex = 156;
            this.tb_6_AdminPW.Text = "";
            // 
            // lb_6_AdminPWSet
            // 
            this.lb_6_AdminPWSet.AutoSize = true;
            this.lb_6_AdminPWSet.ForeColor = System.Drawing.SystemColors.Control;
            this.lb_6_AdminPWSet.Location = new System.Drawing.Point(1019, 849);
            this.lb_6_AdminPWSet.Name = "lb_6_AdminPWSet";
            this.lb_6_AdminPWSet.Size = new System.Drawing.Size(95, 12);
            this.lb_6_AdminPWSet.TabIndex = 158;
            this.lb_6_AdminPWSet.Text = "■ 패스워드 관리";
            // 
            // btn_passwordsave
            // 
            this.btn_passwordsave.Location = new System.Drawing.Point(1349, 876);
            this.btn_passwordsave.Name = "btn_passwordsave";
            this.btn_passwordsave.Size = new System.Drawing.Size(63, 26);
            this.btn_passwordsave.TabIndex = 160;
            this.btn_passwordsave.Text = "저장";
            this.btn_passwordsave.UseVisualStyleBackColor = true;
            this.btn_passwordsave.Click += new System.EventHandler(this.btn_passwordsave_Click);
            // 
            // Add_ModelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(1511, 1033);
            this.Controls.Add(this.btn_passwordsave);
            this.Controls.Add(this.lb_6_AdminPW);
            this.Controls.Add(this.tb_6_AdminPW);
            this.Controls.Add(this.lb_6_AdminPWSet);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_AngleScore);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_Score);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_Offset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_SaveModel);
            this.Controls.Add(this.tb_UpperLimit);
            this.Controls.Add(this.tb_LowerLimit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ModelName);
            this.Controls.Add(this.btn_BackToMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_ModelList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_ModelList";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_BackToMain;
        private System.Windows.Forms.TextBox tb_ModelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_UpperLimit;
        private System.Windows.Forms.TextBox tb_LowerLimit;
        private System.Windows.Forms.Button btn_SaveModel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tb_Offset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_Score;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LowerLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpperLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AngleScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.TextBox tb_AngleScore;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_6_AdminPW;
        private System.Windows.Forms.RichTextBox tb_6_AdminPW;
        private System.Windows.Forms.Label lb_6_AdminPWSet;
        private System.Windows.Forms.Button btn_passwordsave;
    }
}