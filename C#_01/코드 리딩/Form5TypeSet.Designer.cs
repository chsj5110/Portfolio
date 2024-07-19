namespace chsj
{
    partial class Form5TypeSet
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
            this.bt_5_Delete = new System.Windows.Forms.Button();
            this.bt_5_Modify = new System.Windows.Forms.Button();
            this.bt_5_Apply = new System.Windows.Forms.Button();
            this.lb_5_Unit = new System.Windows.Forms.Label();
            this.lb_5_EO = new System.Windows.Forms.Label();
            this.lb_5_ALC = new System.Windows.Forms.Label();
            this.lb_5_Name = new System.Windows.Forms.Label();
            this.lb_5_No = new System.Windows.Forms.Label();
            this.lb_5_Com = new System.Windows.Forms.Label();
            this.lb_5_Type = new System.Windows.Forms.Label();
            this.tb_5_Unit = new System.Windows.Forms.RichTextBox();
            this.tb_5_EO = new System.Windows.Forms.RichTextBox();
            this.tb_5_ALC = new System.Windows.Forms.RichTextBox();
            this.tb_5_Name = new System.Windows.Forms.RichTextBox();
            this.tb_5_No = new System.Windows.Forms.RichTextBox();
            this.tb_5_Com = new System.Windows.Forms.RichTextBox();
            this.tb_5_Type = new System.Windows.Forms.RichTextBox();
            this.lv5 = new System.Windows.Forms.ListView();
            this.ch_5_Chkbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_5_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_5_No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_5_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_5_Com = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_5_ALC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_5_EONO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_5_Unit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lb_5_List = new System.Windows.Forms.Label();
            this.lb_5_Admin = new System.Windows.Forms.Label();
            this.lb_5_Warn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_5_Delete
            // 
            this.bt_5_Delete.BackColor = System.Drawing.Color.White;
            this.bt_5_Delete.Location = new System.Drawing.Point(237, 22);
            this.bt_5_Delete.Name = "bt_5_Delete";
            this.bt_5_Delete.Size = new System.Drawing.Size(100, 28);
            this.bt_5_Delete.TabIndex = 11;
            this.bt_5_Delete.Text = "삭제";
            this.bt_5_Delete.UseVisualStyleBackColor = false;
            this.bt_5_Delete.Click += new System.EventHandler(this.bt_5_Delete_Click);
            // 
            // bt_5_Modify
            // 
            this.bt_5_Modify.BackColor = System.Drawing.Color.White;
            this.bt_5_Modify.Location = new System.Drawing.Point(131, 22);
            this.bt_5_Modify.Name = "bt_5_Modify";
            this.bt_5_Modify.Size = new System.Drawing.Size(100, 28);
            this.bt_5_Modify.TabIndex = 10;
            this.bt_5_Modify.Text = "수정";
            this.bt_5_Modify.UseVisualStyleBackColor = false;
            this.bt_5_Modify.Click += new System.EventHandler(this.bt_5_Modify_Click);
            // 
            // bt_5_Apply
            // 
            this.bt_5_Apply.BackColor = System.Drawing.Color.White;
            this.bt_5_Apply.Location = new System.Drawing.Point(25, 22);
            this.bt_5_Apply.Name = "bt_5_Apply";
            this.bt_5_Apply.Size = new System.Drawing.Size(100, 28);
            this.bt_5_Apply.TabIndex = 9;
            this.bt_5_Apply.Text = "등록";
            this.bt_5_Apply.UseVisualStyleBackColor = false;
            this.bt_5_Apply.Click += new System.EventHandler(this.bt_5_Apply_Click);
            // 
            // lb_5_Unit
            // 
            this.lb_5_Unit.AutoSize = true;
            this.lb_5_Unit.Font = new System.Drawing.Font("굴림", 10F);
            this.lb_5_Unit.Location = new System.Drawing.Point(22, 385);
            this.lb_5_Unit.Name = "lb_5_Unit";
            this.lb_5_Unit.Size = new System.Drawing.Size(63, 14);
            this.lb_5_Unit.TabIndex = 36;
            this.lb_5_Unit.Text = "포장단위";
            // 
            // lb_5_EO
            // 
            this.lb_5_EO.AutoSize = true;
            this.lb_5_EO.Font = new System.Drawing.Font("굴림", 10F);
            this.lb_5_EO.Location = new System.Drawing.Point(22, 303);
            this.lb_5_EO.Name = "lb_5_EO";
            this.lb_5_EO.Size = new System.Drawing.Size(54, 14);
            this.lb_5_EO.TabIndex = 35;
            this.lb_5_EO.Text = "EO NO";
            // 
            // lb_5_ALC
            // 
            this.lb_5_ALC.AutoSize = true;
            this.lb_5_ALC.Font = new System.Drawing.Font("굴림", 10F);
            this.lb_5_ALC.Location = new System.Drawing.Point(22, 262);
            this.lb_5_ALC.Name = "lb_5_ALC";
            this.lb_5_ALC.Size = new System.Drawing.Size(62, 14);
            this.lb_5_ALC.TabIndex = 34;
            this.lb_5_ALC.Text = "ALC코드";
            // 
            // lb_5_Name
            // 
            this.lb_5_Name.AutoSize = true;
            this.lb_5_Name.Font = new System.Drawing.Font("굴림", 10F);
            this.lb_5_Name.Location = new System.Drawing.Point(24, 180);
            this.lb_5_Name.Name = "lb_5_Name";
            this.lb_5_Name.Size = new System.Drawing.Size(35, 14);
            this.lb_5_Name.TabIndex = 33;
            this.lb_5_Name.Text = "품명";
            // 
            // lb_5_No
            // 
            this.lb_5_No.AutoSize = true;
            this.lb_5_No.Font = new System.Drawing.Font("굴림", 10F);
            this.lb_5_No.Location = new System.Drawing.Point(25, 139);
            this.lb_5_No.Name = "lb_5_No";
            this.lb_5_No.Size = new System.Drawing.Size(35, 14);
            this.lb_5_No.TabIndex = 32;
            this.lb_5_No.Text = "품번";
            // 
            // lb_5_Com
            // 
            this.lb_5_Com.AutoSize = true;
            this.lb_5_Com.Font = new System.Drawing.Font("굴림", 10F);
            this.lb_5_Com.Location = new System.Drawing.Point(22, 219);
            this.lb_5_Com.Name = "lb_5_Com";
            this.lb_5_Com.Size = new System.Drawing.Size(63, 14);
            this.lb_5_Com.TabIndex = 31;
            this.lb_5_Com.Text = "업체코드";
            // 
            // lb_5_Type
            // 
            this.lb_5_Type.AutoSize = true;
            this.lb_5_Type.Font = new System.Drawing.Font("굴림", 10F);
            this.lb_5_Type.Location = new System.Drawing.Point(25, 98);
            this.lb_5_Type.Name = "lb_5_Type";
            this.lb_5_Type.Size = new System.Drawing.Size(35, 14);
            this.lb_5_Type.TabIndex = 30;
            this.lb_5_Type.Text = "차종";
            // 
            // tb_5_Unit
            // 
            this.tb_5_Unit.BackColor = System.Drawing.SystemColors.Control;
            this.tb_5_Unit.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_5_Unit.Location = new System.Drawing.Point(93, 385);
            this.tb_5_Unit.Name = "tb_5_Unit";
            this.tb_5_Unit.Size = new System.Drawing.Size(200, 35);
            this.tb_5_Unit.TabIndex = 8;
            this.tb_5_Unit.Text = "";
            // 
            // tb_5_EO
            // 
            this.tb_5_EO.BackColor = System.Drawing.SystemColors.Control;
            this.tb_5_EO.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_5_EO.Location = new System.Drawing.Point(93, 303);
            this.tb_5_EO.Name = "tb_5_EO";
            this.tb_5_EO.Size = new System.Drawing.Size(200, 35);
            this.tb_5_EO.TabIndex = 6;
            this.tb_5_EO.Text = "";
            // 
            // tb_5_ALC
            // 
            this.tb_5_ALC.BackColor = System.Drawing.SystemColors.Control;
            this.tb_5_ALC.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_5_ALC.Location = new System.Drawing.Point(93, 262);
            this.tb_5_ALC.Name = "tb_5_ALC";
            this.tb_5_ALC.Size = new System.Drawing.Size(200, 35);
            this.tb_5_ALC.TabIndex = 5;
            this.tb_5_ALC.Text = "";
            // 
            // tb_5_Name
            // 
            this.tb_5_Name.BackColor = System.Drawing.SystemColors.Control;
            this.tb_5_Name.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_5_Name.Location = new System.Drawing.Point(93, 180);
            this.tb_5_Name.Name = "tb_5_Name";
            this.tb_5_Name.Size = new System.Drawing.Size(200, 35);
            this.tb_5_Name.TabIndex = 3;
            this.tb_5_Name.Text = "";
            // 
            // tb_5_No
            // 
            this.tb_5_No.BackColor = System.Drawing.SystemColors.Control;
            this.tb_5_No.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_5_No.Location = new System.Drawing.Point(93, 139);
            this.tb_5_No.Name = "tb_5_No";
            this.tb_5_No.Size = new System.Drawing.Size(200, 35);
            this.tb_5_No.TabIndex = 2;
            this.tb_5_No.Text = "";
            // 
            // tb_5_Com
            // 
            this.tb_5_Com.BackColor = System.Drawing.SystemColors.Control;
            this.tb_5_Com.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_5_Com.Location = new System.Drawing.Point(93, 221);
            this.tb_5_Com.Name = "tb_5_Com";
            this.tb_5_Com.Size = new System.Drawing.Size(200, 35);
            this.tb_5_Com.TabIndex = 4;
            this.tb_5_Com.Text = "";
            // 
            // tb_5_Type
            // 
            this.tb_5_Type.BackColor = System.Drawing.SystemColors.Control;
            this.tb_5_Type.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_5_Type.Location = new System.Drawing.Point(93, 98);
            this.tb_5_Type.Name = "tb_5_Type";
            this.tb_5_Type.Size = new System.Drawing.Size(200, 35);
            this.tb_5_Type.TabIndex = 1;
            this.tb_5_Type.Text = "";
            // 
            // lv5
            // 
            this.lv5.BackColor = System.Drawing.SystemColors.Control;
            this.lv5.CheckBoxes = true;
            this.lv5.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_5_Chkbox,
            this.ch_5_Type,
            this.ch_5_No,
            this.ch_5_Name,
            this.ch_5_Com,
            this.ch_5_ALC,
            this.ch_5_EONO,
            this.ch_5_Unit});
            this.lv5.Location = new System.Drawing.Point(299, 98);
            this.lv5.Name = "lv5";
            this.lv5.OwnerDraw = true;
            this.lv5.Size = new System.Drawing.Size(688, 322);
            this.lv5.TabIndex = 22;
            this.lv5.UseCompatibleStateImageBehavior = false;
            this.lv5.View = System.Windows.Forms.View.Details;
            this.lv5.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv5_ColumnClick);
            this.lv5.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lv5_DrawColumnHeader);
            this.lv5.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lv5_DrawItem);
            this.lv5.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lv5_DrawSubItem);
            this.lv5.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv5_ItemChecked);
            this.lv5.SelectedIndexChanged += new System.EventHandler(this.lv5_SelectedIndexChanged);
            this.lv5.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv5_MouseDoubleClick);
            // 
            // ch_5_Chkbox
            // 
            this.ch_5_Chkbox.Text = "선택";
            this.ch_5_Chkbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_5_Chkbox.Width = 36;
            // 
            // ch_5_Type
            // 
            this.ch_5_Type.Text = "차종";
            this.ch_5_Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ch_5_No
            // 
            this.ch_5_No.Text = "품번";
            this.ch_5_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_5_No.Width = 120;
            // 
            // ch_5_Name
            // 
            this.ch_5_Name.Text = "품명";
            this.ch_5_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_5_Name.Width = 100;
            // 
            // ch_5_Com
            // 
            this.ch_5_Com.Text = "업체코드";
            this.ch_5_Com.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ch_5_ALC
            // 
            this.ch_5_ALC.Text = "ALC코드";
            this.ch_5_ALC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_5_ALC.Width = 100;
            // 
            // ch_5_EONO
            // 
            this.ch_5_EONO.Text = "EO NO";
            this.ch_5_EONO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_5_EONO.Width = 120;
            // 
            // ch_5_Unit
            // 
            this.ch_5_Unit.Text = "포장단위";
            this.ch_5_Unit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_5_List
            // 
            this.lb_5_List.AutoSize = true;
            this.lb_5_List.Location = new System.Drawing.Point(297, 64);
            this.lb_5_List.Name = "lb_5_List";
            this.lb_5_List.Size = new System.Drawing.Size(67, 12);
            this.lb_5_List.TabIndex = 21;
            this.lb_5_List.Text = "■ 차종목록";
            // 
            // lb_5_Admin
            // 
            this.lb_5_Admin.AutoSize = true;
            this.lb_5_Admin.Location = new System.Drawing.Point(25, 64);
            this.lb_5_Admin.Name = "lb_5_Admin";
            this.lb_5_Admin.Size = new System.Drawing.Size(71, 12);
            this.lb_5_Admin.TabIndex = 20;
            this.lb_5_Admin.Text = "■ 차종 관리";
            // 
            // lb_5_Warn
            // 
            this.lb_5_Warn.AutoSize = true;
            this.lb_5_Warn.Location = new System.Drawing.Point(23, 436);
            this.lb_5_Warn.Name = "lb_5_Warn";
            this.lb_5_Warn.Size = new System.Drawing.Size(257, 84);
            this.lb_5_Warn.TabIndex = 44;
            this.lb_5_Warn.Text = "■ 수정시 주의사항\r\n\r\n수정 할 차종 목록을 더블클릭하여 선택하시고 \r\n\r\n수정 내용을 입력 한 후 \r\n\r\n수정 버튼을 누르세요";
            // 
            // Form5TypeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1014, 542);
            this.Controls.Add(this.lb_5_Warn);
            this.Controls.Add(this.lb_5_Unit);
            this.Controls.Add(this.lb_5_EO);
            this.Controls.Add(this.lb_5_ALC);
            this.Controls.Add(this.lb_5_Name);
            this.Controls.Add(this.lb_5_No);
            this.Controls.Add(this.lb_5_Com);
            this.Controls.Add(this.lb_5_Type);
            this.Controls.Add(this.tb_5_Unit);
            this.Controls.Add(this.tb_5_EO);
            this.Controls.Add(this.tb_5_ALC);
            this.Controls.Add(this.tb_5_Name);
            this.Controls.Add(this.tb_5_No);
            this.Controls.Add(this.tb_5_Com);
            this.Controls.Add(this.tb_5_Type);
            this.Controls.Add(this.lv5);
            this.Controls.Add(this.lb_5_List);
            this.Controls.Add(this.lb_5_Admin);
            this.Controls.Add(this.bt_5_Delete);
            this.Controls.Add(this.bt_5_Modify);
            this.Controls.Add(this.bt_5_Apply);
            this.Name = "Form5TypeSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "차종 관리";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_5_Delete;
        private System.Windows.Forms.Button bt_5_Modify;
        private System.Windows.Forms.Button bt_5_Apply;
        private System.Windows.Forms.Label lb_5_Unit;
        private System.Windows.Forms.Label lb_5_EO;
        private System.Windows.Forms.Label lb_5_ALC;
        private System.Windows.Forms.Label lb_5_Name;
        private System.Windows.Forms.Label lb_5_No;
        private System.Windows.Forms.Label lb_5_Com;
        private System.Windows.Forms.Label lb_5_Type;
        private System.Windows.Forms.RichTextBox tb_5_Unit;
        private System.Windows.Forms.RichTextBox tb_5_EO;
        private System.Windows.Forms.RichTextBox tb_5_ALC;
        private System.Windows.Forms.RichTextBox tb_5_Name;
        private System.Windows.Forms.RichTextBox tb_5_No;
        private System.Windows.Forms.RichTextBox tb_5_Com;
        public System.Windows.Forms.RichTextBox tb_5_Type;
        private System.Windows.Forms.ListView lv5;
        private System.Windows.Forms.ColumnHeader ch_5_Chkbox;
        private System.Windows.Forms.ColumnHeader ch_5_Type;
        private System.Windows.Forms.ColumnHeader ch_5_No;
        private System.Windows.Forms.ColumnHeader ch_5_Name;
        private System.Windows.Forms.ColumnHeader ch_5_Com;
        private System.Windows.Forms.ColumnHeader ch_5_ALC;
        private System.Windows.Forms.ColumnHeader ch_5_Unit;
        private System.Windows.Forms.Label lb_5_List;
        private System.Windows.Forms.Label lb_5_Admin;
        private System.Windows.Forms.Label lb_5_Warn;
        private System.Windows.Forms.ColumnHeader ch_5_EONO;
    }
}