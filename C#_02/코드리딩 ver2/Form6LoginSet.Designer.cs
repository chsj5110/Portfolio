namespace chsj
{
    partial class Form6LoginSet
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
            this.lb_6_PW = new System.Windows.Forms.Label();
            this.lb_6_Worker = new System.Windows.Forms.Label();
            this.tb_6_PW = new System.Windows.Forms.RichTextBox();
            this.tb_6_Worker = new System.Windows.Forms.RichTextBox();
            this.lv6 = new System.Windows.Forms.ListView();
            this.ch_6_Chkbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_6_Worker = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_6_PW = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lb_6_List = new System.Windows.Forms.Label();
            this.lb_6_Admin = new System.Windows.Forms.Label();
            this.bt_6_Delete = new System.Windows.Forms.Button();
            this.bt_6_Modify = new System.Windows.Forms.Button();
            this.bt_6_Apply = new System.Windows.Forms.Button();
            this.lb_6_Warn = new System.Windows.Forms.Label();
            this.lb_6_AdminPWSet = new System.Windows.Forms.Label();
            this.lb_6_AdminPW = new System.Windows.Forms.Label();
            this.tb_6_AdminPW = new System.Windows.Forms.RichTextBox();
            this.bt_6_PWApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_6_PW
            // 
            this.lb_6_PW.AutoSize = true;
            this.lb_6_PW.Font = new System.Drawing.Font("굴림", 13F);
            this.lb_6_PW.Location = new System.Drawing.Point(20, 204);
            this.lb_6_PW.Name = "lb_6_PW";
            this.lb_6_PW.Size = new System.Drawing.Size(80, 18);
            this.lb_6_PW.TabIndex = 42;
            this.lb_6_PW.Text = "패스워드";
            // 
            // lb_6_Worker
            // 
            this.lb_6_Worker.AutoSize = true;
            this.lb_6_Worker.Font = new System.Drawing.Font("굴림", 13F);
            this.lb_6_Worker.Location = new System.Drawing.Point(20, 154);
            this.lb_6_Worker.Name = "lb_6_Worker";
            this.lb_6_Worker.Size = new System.Drawing.Size(80, 18);
            this.lb_6_Worker.TabIndex = 41;
            this.lb_6_Worker.Text = "작업자명";
            // 
            // tb_6_PW
            // 
            this.tb_6_PW.BackColor = System.Drawing.SystemColors.Control;
            this.tb_6_PW.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_6_PW.Location = new System.Drawing.Point(132, 204);
            this.tb_6_PW.Name = "tb_6_PW";
            this.tb_6_PW.Size = new System.Drawing.Size(200, 35);
            this.tb_6_PW.TabIndex = 2;
            this.tb_6_PW.Text = "";
            // 
            // tb_6_Worker
            // 
            this.tb_6_Worker.BackColor = System.Drawing.SystemColors.Control;
            this.tb_6_Worker.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_6_Worker.Location = new System.Drawing.Point(132, 154);
            this.tb_6_Worker.Name = "tb_6_Worker";
            this.tb_6_Worker.Size = new System.Drawing.Size(200, 35);
            this.tb_6_Worker.TabIndex = 1;
            this.tb_6_Worker.Text = "";
            // 
            // lv6
            // 
            this.lv6.BackColor = System.Drawing.SystemColors.Control;
            this.lv6.CheckBoxes = true;
            this.lv6.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_6_Chkbox,
            this.ch_6_Worker,
            this.ch_6_PW});
            this.lv6.HideSelection = false;
            this.lv6.Location = new System.Drawing.Point(489, 155);
            this.lv6.Name = "lv6";
            this.lv6.OwnerDraw = true;
            this.lv6.Size = new System.Drawing.Size(344, 462);
            this.lv6.TabIndex = 38;
            this.lv6.UseCompatibleStateImageBehavior = false;
            this.lv6.View = System.Windows.Forms.View.Details;
            this.lv6.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv6_ColumnClick);
            this.lv6.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lv6_DrawColumnHeader);
            this.lv6.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lv6_DrawItem);
            this.lv6.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lv6_DrawSubItem);
            this.lv6.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv6_ItemChecked);
            this.lv6.SelectedIndexChanged += new System.EventHandler(this.lv6_SelectedIndexChanged);
            this.lv6.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv6_MouseDoubleClick);
            // 
            // ch_6_Chkbox
            // 
            this.ch_6_Chkbox.Text = "선택";
            this.ch_6_Chkbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_6_Chkbox.Width = 40;
            // 
            // ch_6_Worker
            // 
            this.ch_6_Worker.Text = "작업자명";
            this.ch_6_Worker.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_6_Worker.Width = 150;
            // 
            // ch_6_PW
            // 
            this.ch_6_PW.Text = "패스워드";
            this.ch_6_PW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_6_PW.Width = 150;
            // 
            // lb_6_List
            // 
            this.lb_6_List.AutoSize = true;
            this.lb_6_List.Location = new System.Drawing.Point(487, 120);
            this.lb_6_List.Name = "lb_6_List";
            this.lb_6_List.Size = new System.Drawing.Size(79, 12);
            this.lb_6_List.TabIndex = 37;
            this.lb_6_List.Text = "■ 작업자목록";
            // 
            // lb_6_Admin
            // 
            this.lb_6_Admin.AutoSize = true;
            this.lb_6_Admin.Location = new System.Drawing.Point(20, 120);
            this.lb_6_Admin.Name = "lb_6_Admin";
            this.lb_6_Admin.Size = new System.Drawing.Size(79, 12);
            this.lb_6_Admin.TabIndex = 36;
            this.lb_6_Admin.Text = "■ 작업자관리";
            // 
            // bt_6_Delete
            // 
            this.bt_6_Delete.BackColor = System.Drawing.Color.White;
            this.bt_6_Delete.Location = new System.Drawing.Point(232, 73);
            this.bt_6_Delete.Name = "bt_6_Delete";
            this.bt_6_Delete.Size = new System.Drawing.Size(100, 28);
            this.bt_6_Delete.TabIndex = 5;
            this.bt_6_Delete.Text = "삭제";
            this.bt_6_Delete.UseVisualStyleBackColor = false;
            this.bt_6_Delete.Click += new System.EventHandler(this.bt_6_Delete_Click);
            // 
            // bt_6_Modify
            // 
            this.bt_6_Modify.BackColor = System.Drawing.Color.White;
            this.bt_6_Modify.Location = new System.Drawing.Point(126, 73);
            this.bt_6_Modify.Name = "bt_6_Modify";
            this.bt_6_Modify.Size = new System.Drawing.Size(100, 28);
            this.bt_6_Modify.TabIndex = 4;
            this.bt_6_Modify.Text = "수정";
            this.bt_6_Modify.UseVisualStyleBackColor = false;
            this.bt_6_Modify.Click += new System.EventHandler(this.bt_6_Modify_Click);
            // 
            // bt_6_Apply
            // 
            this.bt_6_Apply.BackColor = System.Drawing.Color.White;
            this.bt_6_Apply.Location = new System.Drawing.Point(20, 73);
            this.bt_6_Apply.Name = "bt_6_Apply";
            this.bt_6_Apply.Size = new System.Drawing.Size(100, 28);
            this.bt_6_Apply.TabIndex = 3;
            this.bt_6_Apply.Text = "등록";
            this.bt_6_Apply.UseVisualStyleBackColor = false;
            this.bt_6_Apply.Click += new System.EventHandler(this.bt_6_Apply_Click);
            // 
            // lb_6_Warn
            // 
            this.lb_6_Warn.AutoSize = true;
            this.lb_6_Warn.Location = new System.Drawing.Point(18, 528);
            this.lb_6_Warn.Name = "lb_6_Warn";
            this.lb_6_Warn.Size = new System.Drawing.Size(269, 84);
            this.lb_6_Warn.TabIndex = 43;
            this.lb_6_Warn.Text = "■ 수정시 주의사항\r\n\r\n수정 할 작업자 목록을 더블클릭하여 선택하시고 \r\n\r\n수정 내용을 작업자명, 패스워드를 입력 한 후 \r\n\r\n수정 버튼을 " +
    "누르세요";
            // 
            // lb_6_AdminPWSet
            // 
            this.lb_6_AdminPWSet.AutoSize = true;
            this.lb_6_AdminPWSet.Location = new System.Drawing.Point(20, 406);
            this.lb_6_AdminPWSet.Name = "lb_6_AdminPWSet";
            this.lb_6_AdminPWSet.Size = new System.Drawing.Size(95, 12);
            this.lb_6_AdminPWSet.TabIndex = 44;
            this.lb_6_AdminPWSet.Text = "■ 패스워드 관리";
            // 
            // lb_6_AdminPW
            // 
            this.lb_6_AdminPW.AutoSize = true;
            this.lb_6_AdminPW.Font = new System.Drawing.Font("굴림", 13F);
            this.lb_6_AdminPW.Location = new System.Drawing.Point(20, 430);
            this.lb_6_AdminPW.Name = "lb_6_AdminPW";
            this.lb_6_AdminPW.Size = new System.Drawing.Size(80, 18);
            this.lb_6_AdminPW.TabIndex = 46;
            this.lb_6_AdminPW.Text = "패스워드";
            // 
            // tb_6_AdminPW
            // 
            this.tb_6_AdminPW.BackColor = System.Drawing.SystemColors.Control;
            this.tb_6_AdminPW.Font = new System.Drawing.Font("굴림", 13F);
            this.tb_6_AdminPW.Location = new System.Drawing.Point(126, 432);
            this.tb_6_AdminPW.Name = "tb_6_AdminPW";
            this.tb_6_AdminPW.Size = new System.Drawing.Size(200, 35);
            this.tb_6_AdminPW.TabIndex = 6;
            this.tb_6_AdminPW.Text = "";
            // 
            // bt_6_PWApply
            // 
            this.bt_6_PWApply.BackColor = System.Drawing.Color.White;
            this.bt_6_PWApply.Location = new System.Drawing.Point(226, 473);
            this.bt_6_PWApply.Name = "bt_6_PWApply";
            this.bt_6_PWApply.Size = new System.Drawing.Size(100, 28);
            this.bt_6_PWApply.TabIndex = 7;
            this.bt_6_PWApply.Text = "패스워드 등록";
            this.bt_6_PWApply.UseVisualStyleBackColor = false;
            this.bt_6_PWApply.Click += new System.EventHandler(this.bt_6_PWApply_Click);
            // 
            // Form6LoginSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 806);
            this.Controls.Add(this.bt_6_PWApply);
            this.Controls.Add(this.lb_6_AdminPW);
            this.Controls.Add(this.tb_6_AdminPW);
            this.Controls.Add(this.lb_6_AdminPWSet);
            this.Controls.Add(this.lb_6_Warn);
            this.Controls.Add(this.lb_6_PW);
            this.Controls.Add(this.lb_6_Worker);
            this.Controls.Add(this.tb_6_PW);
            this.Controls.Add(this.tb_6_Worker);
            this.Controls.Add(this.lv6);
            this.Controls.Add(this.lb_6_List);
            this.Controls.Add(this.lb_6_Admin);
            this.Controls.Add(this.bt_6_Delete);
            this.Controls.Add(this.bt_6_Modify);
            this.Controls.Add(this.bt_6_Apply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(627, 200);
            this.Name = "Form6LoginSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "작업자 관리";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_6_PW;
        private System.Windows.Forms.Label lb_6_Worker;
        private System.Windows.Forms.RichTextBox tb_6_PW;
        private System.Windows.Forms.RichTextBox tb_6_Worker;
        private System.Windows.Forms.ListView lv6;
        private System.Windows.Forms.ColumnHeader ch_6_Chkbox;
        private System.Windows.Forms.ColumnHeader ch_6_Worker;
        private System.Windows.Forms.ColumnHeader ch_6_PW;
        private System.Windows.Forms.Label lb_6_List;
        private System.Windows.Forms.Label lb_6_Admin;
        private System.Windows.Forms.Button bt_6_Delete;
        private System.Windows.Forms.Button bt_6_Modify;
        private System.Windows.Forms.Button bt_6_Apply;
        private System.Windows.Forms.Label lb_6_Warn;
        private System.Windows.Forms.Label lb_6_AdminPWSet;
        private System.Windows.Forms.Label lb_6_AdminPW;
        private System.Windows.Forms.RichTextBox tb_6_AdminPW;
        private System.Windows.Forms.Button bt_6_PWApply;
    }
}