namespace chsj
{
    partial class Form1Type
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
        /// 
        private void InitializeComponent()
        {
            this.bt_1_Select = new System.Windows.Forms.Button();
            this.lb_1_List = new System.Windows.Forms.Label();
            this.lv1 = new System.Windows.Forms.ListView();
            this.ch_1_Chkbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_1_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_1_Com = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_1_No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_1_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_1_ALC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_1_EO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_1_Unit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_1_LLower = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_1_LUpper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_1_lb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // bt_1_Select
            // 
            this.bt_1_Select.BackColor = System.Drawing.Color.White;
            this.bt_1_Select.Location = new System.Drawing.Point(1079, 675);
            this.bt_1_Select.Name = "bt_1_Select";
            this.bt_1_Select.Size = new System.Drawing.Size(100, 28);
            this.bt_1_Select.TabIndex = 0;
            this.bt_1_Select.Text = "선택";
            this.bt_1_Select.UseVisualStyleBackColor = false;
            this.bt_1_Select.Click += new System.EventHandler(this.bt_1_Select_Click);
            // 
            // lb_1_List
            // 
            this.lb_1_List.AutoSize = true;
            this.lb_1_List.Location = new System.Drawing.Point(20, 120);
            this.lb_1_List.Name = "lb_1_List";
            this.lb_1_List.Size = new System.Drawing.Size(71, 12);
            this.lb_1_List.TabIndex = 4;
            this.lb_1_List.Text = "■ 차종 목록";
            // 
            // lv1
            // 
            this.lv1.BackColor = System.Drawing.SystemColors.Control;
            this.lv1.CheckBoxes = true;
            this.lv1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_1_Chkbox,
            this.ch_1_Type,
            this.ch_1_Com,
            this.ch_1_No,
            this.ch_1_Name,
            this.ch_1_ALC,
            this.ch_1_EO,
            this.ch_1_Unit,
            this.ch_1_LLower,
            this.ch_1_LUpper,
            this.ch_1_lb});
            this.lv1.HideSelection = false;
            this.lv1.Location = new System.Drawing.Point(22, 160);
            this.lv1.Name = "lv1";
            this.lv1.OwnerDraw = true;
            this.lv1.Size = new System.Drawing.Size(1157, 499);
            this.lv1.TabIndex = 5;
            this.lv1.UseCompatibleStateImageBehavior = false;
            this.lv1.View = System.Windows.Forms.View.Details;
            this.lv1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv1_ColumnClick);
            this.lv1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lv1_DrawColumnHeader);
            this.lv1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lv1_DrawItem);
            this.lv1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lv1_DrawSubItem);
            this.lv1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv1_ItemChecked);
            this.lv1.SelectedIndexChanged += new System.EventHandler(this.lv1_SelectedIndexChanged);
            // 
            // ch_1_Chkbox
            // 
            this.ch_1_Chkbox.Text = "선택";
            this.ch_1_Chkbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_1_Chkbox.Width = 40;
            // 
            // ch_1_Type
            // 
            this.ch_1_Type.Text = "차종";
            this.ch_1_Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_1_Type.Width = 100;
            // 
            // ch_1_Com
            // 
            this.ch_1_Com.Text = "업체코드";
            this.ch_1_Com.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_1_Com.Width = 100;
            // 
            // ch_1_No
            // 
            this.ch_1_No.Text = "품번";
            this.ch_1_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_1_No.Width = 120;
            // 
            // ch_1_Name
            // 
            this.ch_1_Name.Text = "품명";
            this.ch_1_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_1_Name.Width = 120;
            // 
            // ch_1_ALC
            // 
            this.ch_1_ALC.Text = "ALC코드";
            this.ch_1_ALC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_1_ALC.Width = 120;
            // 
            // ch_1_EO
            // 
            this.ch_1_EO.Text = "EO NO";
            this.ch_1_EO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_1_EO.Width = 150;
            // 
            // ch_1_Unit
            // 
            this.ch_1_Unit.Tag = "";
            this.ch_1_Unit.Text = "포장단위(EA)";
            this.ch_1_Unit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_1_Unit.Width = 100;
            // 
            // ch_1_LLower
            // 
            this.ch_1_LLower.Text = "중량 하한";
            this.ch_1_LLower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_1_LLower.Width = 110;
            // 
            // ch_1_LUpper
            // 
            this.ch_1_LUpper.Text = "중량 상한";
            this.ch_1_LUpper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_1_LUpper.Width = 110;
            // 
            // ch_1_lb
            // 
            this.ch_1_lb.Text = "라벨프린터 사용";
            this.ch_1_lb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_1_lb.Width = 120;
            // 
            // Form1Type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 806);
            this.Controls.Add(this.lb_1_List);
            this.Controls.Add(this.bt_1_Select);
            this.Controls.Add(this.lv1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(625, 200);
            this.Name = "Form1Type";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "차종 선택";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button bt_1_Select;
        private System.Windows.Forms.Label lb_1_List;
        private System.Windows.Forms.ListView lv1;
        private System.Windows.Forms.ColumnHeader ch_1_Chkbox;
        private System.Windows.Forms.ColumnHeader ch_1_Type;
        private System.Windows.Forms.ColumnHeader ch_1_No;
        private System.Windows.Forms.ColumnHeader ch_1_Name;
        private System.Windows.Forms.ColumnHeader ch_1_Com;
        private System.Windows.Forms.ColumnHeader ch_1_ALC;
        private System.Windows.Forms.ColumnHeader ch_1_Unit;
        private System.Windows.Forms.ColumnHeader ch_1_EO;
        private System.Windows.Forms.ColumnHeader ch_1_LLower;
        private System.Windows.Forms.ColumnHeader ch_1_LUpper;
        private System.Windows.Forms.ColumnHeader ch_1_lb;
    }
}