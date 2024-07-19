namespace chsj
{
    partial class Form7_1
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
            this.lv_71 = new System.Windows.Forms.ListView();
            this.lv_71_checkbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_71_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bt_71 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lv_71
            // 
            this.lv_71.BackColor = System.Drawing.SystemColors.Control;
            this.lv_71.CheckBoxes = true;
            this.lv_71.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_71_checkbox,
            this.lv_71_Type});
            this.lv_71.HideSelection = false;
            this.lv_71.Location = new System.Drawing.Point(40, 63);
            this.lv_71.Name = "lv_71";
            this.lv_71.Size = new System.Drawing.Size(206, 160);
            this.lv_71.TabIndex = 0;
            this.lv_71.UseCompatibleStateImageBehavior = false;
            this.lv_71.View = System.Windows.Forms.View.Details;
            this.lv_71.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lv_71_DrawColumnHeader);
            this.lv_71.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lv_71_DrawItem);
            this.lv_71.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lv_71_DrawSubItem);
            this.lv_71.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_71_ItemChecked);
            this.lv_71.SelectedIndexChanged += new System.EventHandler(this.lv_71_SelectedIndexChanged);
            // 
            // lv_71_checkbox
            // 
            this.lv_71_checkbox.Text = "선택";
            this.lv_71_checkbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lv_71_checkbox.Width = 40;
            // 
            // lv_71_Type
            // 
            this.lv_71_Type.Text = "차종";
            this.lv_71_Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lv_71_Type.Width = 160;
            // 
            // bt_71
            // 
            this.bt_71.BackColor = System.Drawing.Color.White;
            this.bt_71.Location = new System.Drawing.Point(96, 25);
            this.bt_71.Name = "bt_71";
            this.bt_71.Size = new System.Drawing.Size(100, 28);
            this.bt_71.TabIndex = 1;
            this.bt_71.Text = "선택";
            this.bt_71.UseVisualStyleBackColor = false;
            this.bt_71.Click += new System.EventHandler(this.bt_71_Click);
            // 
            // Form7_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.bt_71);
            this.Controls.Add(this.lv_71);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form7_1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "차종선택";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_71;
        public System.Windows.Forms.Button bt_71;
        private System.Windows.Forms.ColumnHeader lv_71_Type;
        private System.Windows.Forms.ColumnHeader lv_71_checkbox;
    }
}