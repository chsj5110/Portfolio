namespace chsj
{
    partial class Form3Order
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3Order));
            this.lv3 = new System.Windows.Forms.ListView();
            this.ch_3_Chkbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_3_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_3_No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_3_Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_3_Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_3_Use = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_3_State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_3_Btn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bt_3_Select = new System.Windows.Forms.Button();
            this.lb_7_Regist = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lv3
            // 
            this.lv3.BackColor = System.Drawing.SystemColors.Control;
            this.lv3.CheckBoxes = true;
            this.lv3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_3_Chkbox,
            this.ch_3_Type,
            this.ch_3_No,
            this.ch_3_Amount,
            this.ch_3_Date,
            this.ch_3_Use,
            this.ch_3_State,
            this.ch_3_Btn});
            this.lv3.FullRowSelect = true;
            this.lv3.HideSelection = false;
            this.lv3.Location = new System.Drawing.Point(22, 160);
            this.lv3.MultiSelect = false;
            this.lv3.Name = "lv3";
            this.lv3.OwnerDraw = true;
            this.lv3.Size = new System.Drawing.Size(1157, 499);
            this.lv3.TabIndex = 52;
            this.lv3.UseCompatibleStateImageBehavior = false;
            this.lv3.View = System.Windows.Forms.View.Details;
            this.lv3.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lv3_DrawColumnHeader);
            this.lv3.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lv3_DrawItem);
            this.lv3.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lv3_DrawSubItem);
            this.lv3.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv3_ItemChecked);
            this.lv3.SelectedIndexChanged += new System.EventHandler(this.lv3_SelectedIndexChanged);
            this.lv3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv3_MouseDoubleClick);
            // 
            // ch_3_Chkbox
            // 
            this.ch_3_Chkbox.Text = "선택";
            this.ch_3_Chkbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_3_Chkbox.Width = 40;
            // 
            // ch_3_Type
            // 
            this.ch_3_Type.Text = "차종";
            this.ch_3_Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_3_Type.Width = 130;
            // 
            // ch_3_No
            // 
            this.ch_3_No.Text = "발주번호";
            this.ch_3_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_3_No.Width = 130;
            // 
            // ch_3_Amount
            // 
            this.ch_3_Amount.Text = "발주수량";
            this.ch_3_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_3_Amount.Width = 130;
            // 
            // ch_3_Date
            // 
            this.ch_3_Date.Text = "납기일";
            this.ch_3_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_3_Date.Width = 130;
            // 
            // ch_3_Use
            // 
            this.ch_3_Use.Text = "용도";
            this.ch_3_Use.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_3_Use.Width = 130;
            // 
            // ch_3_State
            // 
            this.ch_3_State.Text = "진행상태";
            this.ch_3_State.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_3_State.Width = 130;
            // 
            // ch_3_Btn
            // 
            this.ch_3_Btn.Text = "데이터 확인";
            this.ch_3_Btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_3_Btn.Width = 150;
            // 
            // bt_3_Select
            // 
            this.bt_3_Select.BackColor = System.Drawing.Color.White;
            this.bt_3_Select.Location = new System.Drawing.Point(1079, 675);
            this.bt_3_Select.Name = "bt_3_Select";
            this.bt_3_Select.Size = new System.Drawing.Size(100, 28);
            this.bt_3_Select.TabIndex = 53;
            this.bt_3_Select.Text = "선택";
            this.bt_3_Select.UseVisualStyleBackColor = false;
            this.bt_3_Select.Click += new System.EventHandler(this.bt_3_Select_Click);
            // 
            // lb_7_Regist
            // 
            this.lb_7_Regist.AutoSize = true;
            this.lb_7_Regist.Location = new System.Drawing.Point(20, 120);
            this.lb_7_Regist.Name = "lb_7_Regist";
            this.lb_7_Regist.Size = new System.Drawing.Size(71, 12);
            this.lb_7_Regist.TabIndex = 54;
            this.lb_7_Regist.Text = "■ 오더 목록";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "box.bmp");
            this.imageList1.Images.SetKeyName(1, "pass.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(996, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 24);
            this.label1.TabIndex = 55;
            this.label1.Text = "* 오더 선택시 체크박스 확인\r\n* 데이터 확인시 데이터 더블클릭";
            // 
            // Form3Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 806);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_7_Regist);
            this.Controls.Add(this.bt_3_Select);
            this.Controls.Add(this.lv3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(627, 200);
            this.Name = "Form3Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "오더 선택";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv3;
        private System.Windows.Forms.ColumnHeader ch_3_Chkbox;
        private System.Windows.Forms.ColumnHeader ch_3_Type;
        private System.Windows.Forms.ColumnHeader ch_3_No;
        private System.Windows.Forms.ColumnHeader ch_3_Amount;
        private System.Windows.Forms.ColumnHeader ch_3_Date;
        private System.Windows.Forms.ColumnHeader ch_3_Use;
        public System.Windows.Forms.Button bt_3_Select;
        private System.Windows.Forms.Label lb_7_Regist;
        private System.Windows.Forms.ColumnHeader ch_3_State;
        private System.Windows.Forms.ColumnHeader ch_3_Btn;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
    }
}