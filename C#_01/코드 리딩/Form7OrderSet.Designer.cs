namespace chsj
{
    partial class Form7OrderSet
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
            this.lb_5_Warn = new System.Windows.Forms.Label();
            this.bt_7_Delete = new System.Windows.Forms.Button();
            this.bt_7_Modify = new System.Windows.Forms.Button();
            this.bt_7_Apply = new System.Windows.Forms.Button();
            this.lb_7_Use = new System.Windows.Forms.Label();
            this.lb_7_Amount = new System.Windows.Forms.Label();
            this.lb_7_No = new System.Windows.Forms.Label();
            this.lb_7_Date = new System.Windows.Forms.Label();
            this.lb_7_Type = new System.Windows.Forms.Label();
            this.tb_7_Use = new System.Windows.Forms.RichTextBox();
            this.tb_7_Amount = new System.Windows.Forms.RichTextBox();
            this.tb_7_No = new System.Windows.Forms.RichTextBox();
            this.tb_7_Date = new System.Windows.Forms.RichTextBox();
            this.lv7 = new System.Windows.Forms.ListView();
            this.ch_7_Chkbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_7_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_7_No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_7_Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_7_Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_7_Use = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lb_5_List = new System.Windows.Forms.Label();
            this.lb_7_Regist = new System.Windows.Forms.Label();
            this.tb_7_Type = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lb_5_Warn
            // 
            this.lb_5_Warn.AutoSize = true;
            this.lb_5_Warn.Location = new System.Drawing.Point(25, 352);
            this.lb_5_Warn.Name = "lb_5_Warn";
            this.lb_5_Warn.Size = new System.Drawing.Size(257, 84);
            this.lb_5_Warn.TabIndex = 48;
            this.lb_5_Warn.Text = "■ 수정시 주의사항\r\n\r\n수정 할 오더 목록을 더블클릭하여 선택하시고 \r\n\r\n수정 내용을 입력 한 후 \r\n\r\n수정 버튼을 누르세요";
            // 
            // bt_7_Delete
            // 
            this.bt_7_Delete.BackColor = System.Drawing.Color.White;
            this.bt_7_Delete.Location = new System.Drawing.Point(237, 22);
            this.bt_7_Delete.Name = "bt_7_Delete";
            this.bt_7_Delete.Size = new System.Drawing.Size(100, 28);
            this.bt_7_Delete.TabIndex = 47;
            this.bt_7_Delete.Text = "삭제";
            this.bt_7_Delete.UseVisualStyleBackColor = false;
            this.bt_7_Delete.Click += new System.EventHandler(this.bt_7_Delete_Click);
            // 
            // bt_7_Modify
            // 
            this.bt_7_Modify.BackColor = System.Drawing.Color.White;
            this.bt_7_Modify.Location = new System.Drawing.Point(131, 22);
            this.bt_7_Modify.Name = "bt_7_Modify";
            this.bt_7_Modify.Size = new System.Drawing.Size(100, 28);
            this.bt_7_Modify.TabIndex = 46;
            this.bt_7_Modify.Text = "수정";
            this.bt_7_Modify.UseVisualStyleBackColor = false;
            this.bt_7_Modify.Click += new System.EventHandler(this.bt_7_Modify_Click);
            // 
            // bt_7_Apply
            // 
            this.bt_7_Apply.BackColor = System.Drawing.Color.White;
            this.bt_7_Apply.Location = new System.Drawing.Point(25, 22);
            this.bt_7_Apply.Name = "bt_7_Apply";
            this.bt_7_Apply.Size = new System.Drawing.Size(100, 28);
            this.bt_7_Apply.TabIndex = 45;
            this.bt_7_Apply.Text = "등록";
            this.bt_7_Apply.UseVisualStyleBackColor = false;
            this.bt_7_Apply.Click += new System.EventHandler(this.bt_7_Apply_Click);
            // 
            // lb_7_Use
            // 
            this.lb_7_Use.AutoSize = true;
            this.lb_7_Use.Font = new System.Drawing.Font("굴림", 10F);
            this.lb_7_Use.Location = new System.Drawing.Point(25, 264);
            this.lb_7_Use.Name = "lb_7_Use";
            this.lb_7_Use.Size = new System.Drawing.Size(35, 14);
            this.lb_7_Use.TabIndex = 63;
            this.lb_7_Use.Text = "용도";
            // 
            // lb_7_Amount
            // 
            this.lb_7_Amount.AutoSize = true;
            this.lb_7_Amount.Font = new System.Drawing.Font("굴림", 10F);
            this.lb_7_Amount.Location = new System.Drawing.Point(25, 182);
            this.lb_7_Amount.Name = "lb_7_Amount";
            this.lb_7_Amount.Size = new System.Drawing.Size(63, 14);
            this.lb_7_Amount.TabIndex = 62;
            this.lb_7_Amount.Text = "발주수량";
            // 
            // lb_7_No
            // 
            this.lb_7_No.AutoSize = true;
            this.lb_7_No.Font = new System.Drawing.Font("굴림", 10F);
            this.lb_7_No.Location = new System.Drawing.Point(25, 141);
            this.lb_7_No.Name = "lb_7_No";
            this.lb_7_No.Size = new System.Drawing.Size(63, 14);
            this.lb_7_No.TabIndex = 61;
            this.lb_7_No.Text = "발주번호";
            // 
            // lb_7_Date
            // 
            this.lb_7_Date.AutoSize = true;
            this.lb_7_Date.Font = new System.Drawing.Font("굴림", 10F);
            this.lb_7_Date.Location = new System.Drawing.Point(25, 221);
            this.lb_7_Date.Name = "lb_7_Date";
            this.lb_7_Date.Size = new System.Drawing.Size(49, 14);
            this.lb_7_Date.TabIndex = 60;
            this.lb_7_Date.Text = "납기일";
            // 
            // lb_7_Type
            // 
            this.lb_7_Type.AutoSize = true;
            this.lb_7_Type.Font = new System.Drawing.Font("굴림", 10F);
            this.lb_7_Type.Location = new System.Drawing.Point(25, 98);
            this.lb_7_Type.Name = "lb_7_Type";
            this.lb_7_Type.Size = new System.Drawing.Size(35, 14);
            this.lb_7_Type.TabIndex = 59;
            this.lb_7_Type.Text = "차종";
            // 
            // tb_7_Use
            // 
            this.tb_7_Use.BackColor = System.Drawing.SystemColors.Control;
            this.tb_7_Use.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_7_Use.Location = new System.Drawing.Point(93, 262);
            this.tb_7_Use.Name = "tb_7_Use";
            this.tb_7_Use.Size = new System.Drawing.Size(200, 35);
            this.tb_7_Use.TabIndex = 5;
            this.tb_7_Use.Text = "";
            // 
            // tb_7_Amount
            // 
            this.tb_7_Amount.BackColor = System.Drawing.SystemColors.Control;
            this.tb_7_Amount.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_7_Amount.Location = new System.Drawing.Point(93, 180);
            this.tb_7_Amount.Name = "tb_7_Amount";
            this.tb_7_Amount.Size = new System.Drawing.Size(200, 35);
            this.tb_7_Amount.TabIndex = 3;
            this.tb_7_Amount.Text = "";
            // 
            // tb_7_No
            // 
            this.tb_7_No.BackColor = System.Drawing.SystemColors.Control;
            this.tb_7_No.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_7_No.Location = new System.Drawing.Point(93, 139);
            this.tb_7_No.Name = "tb_7_No";
            this.tb_7_No.Size = new System.Drawing.Size(200, 35);
            this.tb_7_No.TabIndex = 2;
            this.tb_7_No.Text = "";
            // 
            // tb_7_Date
            // 
            this.tb_7_Date.BackColor = System.Drawing.SystemColors.Control;
            this.tb_7_Date.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_7_Date.Location = new System.Drawing.Point(93, 221);
            this.tb_7_Date.Name = "tb_7_Date";
            this.tb_7_Date.Size = new System.Drawing.Size(200, 35);
            this.tb_7_Date.TabIndex = 4;
            this.tb_7_Date.Text = "";
            // 
            // lv7
            // 
            this.lv7.BackColor = System.Drawing.SystemColors.Control;
            this.lv7.CheckBoxes = true;
            this.lv7.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_7_Chkbox,
            this.ch_7_Type,
            this.ch_7_No,
            this.ch_7_Amount,
            this.ch_7_Date,
            this.ch_7_Use});
            this.lv7.Location = new System.Drawing.Point(309, 98);
            this.lv7.MultiSelect = false;
            this.lv7.Name = "lv7";
            this.lv7.OwnerDraw = true;
            this.lv7.Size = new System.Drawing.Size(695, 330);
            this.lv7.TabIndex = 51;
            this.lv7.UseCompatibleStateImageBehavior = false;
            this.lv7.View = System.Windows.Forms.View.Details;
            this.lv7.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv7_ColumnClick);
            this.lv7.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lv7_DrawColumnHeader);
            this.lv7.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lv7_DrawItem);
            this.lv7.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lv7_DrawSubItem);
            this.lv7.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv7_ItemChecked);
            this.lv7.SelectedIndexChanged += new System.EventHandler(this.lv7_SelectedIndexChanged);
            this.lv7.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv7_MouseDoubleClick);
            // 
            // ch_7_Chkbox
            // 
            this.ch_7_Chkbox.Text = "선택";
            this.ch_7_Chkbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_7_Chkbox.Width = 40;
            // 
            // ch_7_Type
            // 
            this.ch_7_Type.Text = "차종";
            this.ch_7_Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_7_Type.Width = 130;
            // 
            // ch_7_No
            // 
            this.ch_7_No.Text = "발주번호";
            this.ch_7_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_7_No.Width = 130;
            // 
            // ch_7_Amount
            // 
            this.ch_7_Amount.Text = "발주수량";
            this.ch_7_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_7_Amount.Width = 130;
            // 
            // ch_7_Date
            // 
            this.ch_7_Date.Text = "납기일";
            this.ch_7_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_7_Date.Width = 130;
            // 
            // ch_7_Use
            // 
            this.ch_7_Use.Text = "용도";
            this.ch_7_Use.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_7_Use.Width = 130;
            // 
            // lb_5_List
            // 
            this.lb_5_List.AutoSize = true;
            this.lb_5_List.Location = new System.Drawing.Point(307, 64);
            this.lb_5_List.Name = "lb_5_List";
            this.lb_5_List.Size = new System.Drawing.Size(67, 12);
            this.lb_5_List.TabIndex = 50;
            this.lb_5_List.Text = "■ 오더목록";
            // 
            // lb_7_Regist
            // 
            this.lb_7_Regist.AutoSize = true;
            this.lb_7_Regist.Location = new System.Drawing.Point(25, 64);
            this.lb_7_Regist.Name = "lb_7_Regist";
            this.lb_7_Regist.Size = new System.Drawing.Size(71, 12);
            this.lb_7_Regist.TabIndex = 49;
            this.lb_7_Regist.Text = "■ 오더 등록";
            // 
            // tb_7_Type
            // 
            this.tb_7_Type.BackColor = System.Drawing.SystemColors.Control;
            this.tb_7_Type.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_7_Type.Location = new System.Drawing.Point(93, 98);
            this.tb_7_Type.Name = "tb_7_Type";
            this.tb_7_Type.ReadOnly = true;
            this.tb_7_Type.Size = new System.Drawing.Size(200, 35);
            this.tb_7_Type.TabIndex = 1;
            this.tb_7_Type.Text = "";
            this.tb_7_Type.Click += new System.EventHandler(this.tb_7_Type_Click);
            // 
            // Form7OrderSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1016, 463);
            this.Controls.Add(this.tb_7_Type);
            this.Controls.Add(this.lb_7_Use);
            this.Controls.Add(this.lb_7_Amount);
            this.Controls.Add(this.lb_7_No);
            this.Controls.Add(this.lb_7_Date);
            this.Controls.Add(this.lb_7_Type);
            this.Controls.Add(this.tb_7_Use);
            this.Controls.Add(this.tb_7_Amount);
            this.Controls.Add(this.tb_7_No);
            this.Controls.Add(this.tb_7_Date);
            this.Controls.Add(this.lv7);
            this.Controls.Add(this.lb_5_List);
            this.Controls.Add(this.lb_7_Regist);
            this.Controls.Add(this.lb_5_Warn);
            this.Controls.Add(this.bt_7_Delete);
            this.Controls.Add(this.bt_7_Modify);
            this.Controls.Add(this.bt_7_Apply);
            this.Name = "Form7OrderSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "오더관리";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_5_Warn;
        private System.Windows.Forms.Button bt_7_Delete;
        private System.Windows.Forms.Button bt_7_Modify;
        private System.Windows.Forms.Button bt_7_Apply;
        private System.Windows.Forms.Label lb_7_Use;
        private System.Windows.Forms.Label lb_7_Amount;
        private System.Windows.Forms.Label lb_7_No;
        private System.Windows.Forms.Label lb_7_Date;
        private System.Windows.Forms.Label lb_7_Type;
        private System.Windows.Forms.RichTextBox tb_7_Use;
        private System.Windows.Forms.RichTextBox tb_7_Amount;
        private System.Windows.Forms.RichTextBox tb_7_No;
        private System.Windows.Forms.RichTextBox tb_7_Date;
        private System.Windows.Forms.ListView lv7;
        private System.Windows.Forms.ColumnHeader ch_7_Chkbox;
        private System.Windows.Forms.ColumnHeader ch_7_Type;
        private System.Windows.Forms.ColumnHeader ch_7_No;
        private System.Windows.Forms.ColumnHeader ch_7_Amount;
        private System.Windows.Forms.ColumnHeader ch_7_Date;
        private System.Windows.Forms.ColumnHeader ch_7_Use;
        private System.Windows.Forms.Label lb_5_List;
        private System.Windows.Forms.Label lb_7_Regist;
        public System.Windows.Forms.RichTextBox tb_7_Type;
    }
}