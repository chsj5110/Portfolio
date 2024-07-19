
namespace chsj
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cogRecordDisplay_CAMERA1 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogRecordDisplay_CAMERA2 = new Cognex.VisionPro.CogRecordDisplay();
            this.btn_EXIT = new System.Windows.Forms.Button();
            this.tb_CenterDis = new System.Windows.Forms.TextBox();
            this.tb_LLower = new System.Windows.Forms.TextBox();
            this.tb_LUpper = new System.Windows.Forms.TextBox();
            this.lb_Distance = new System.Windows.Forms.Label();
            this.btn_trigger = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA2)).BeginInit();
            this.SuspendLayout();
            // 
            // cogRecordDisplay_CAMERA1
            // 
            this.cogRecordDisplay_CAMERA1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay_CAMERA1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay_CAMERA1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay_CAMERA1.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay_CAMERA1.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay_CAMERA1.Location = new System.Drawing.Point(84, 216);
            this.cogRecordDisplay_CAMERA1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay_CAMERA1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay_CAMERA1.Name = "cogRecordDisplay_CAMERA1";
            this.cogRecordDisplay_CAMERA1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay_CAMERA1.OcxState")));
            this.cogRecordDisplay_CAMERA1.Size = new System.Drawing.Size(875, 656);
            this.cogRecordDisplay_CAMERA1.TabIndex = 117;
            // 
            // cogRecordDisplay_CAMERA2
            // 
            this.cogRecordDisplay_CAMERA2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA2.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay_CAMERA2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay_CAMERA2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay_CAMERA2.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay_CAMERA2.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay_CAMERA2.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay_CAMERA2.Location = new System.Drawing.Point(965, 216);
            this.cogRecordDisplay_CAMERA2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay_CAMERA2.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay_CAMERA2.Name = "cogRecordDisplay_CAMERA2";
            this.cogRecordDisplay_CAMERA2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay_CAMERA2.OcxState")));
            this.cogRecordDisplay_CAMERA2.Size = new System.Drawing.Size(875, 656);
            this.cogRecordDisplay_CAMERA2.TabIndex = 118;
            // 
            // btn_EXIT
            // 
            this.btn_EXIT.BackColor = System.Drawing.Color.Transparent;
            this.btn_EXIT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_EXIT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_EXIT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_EXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EXIT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_EXIT.Location = new System.Drawing.Point(1528, 46);
            this.btn_EXIT.Name = "btn_EXIT";
            this.btn_EXIT.Size = new System.Drawing.Size(351, 80);
            this.btn_EXIT.TabIndex = 120;
            this.btn_EXIT.UseVisualStyleBackColor = false;
            this.btn_EXIT.Click += new System.EventHandler(this.btn_EXIT_Click);
            // 
            // tb_CenterDis
            // 
            this.tb_CenterDis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_CenterDis.Font = new System.Drawing.Font("맑은 고딕", 20.25F);
            this.tb_CenterDis.Location = new System.Drawing.Point(367, 925);
            this.tb_CenterDis.Name = "tb_CenterDis";
            this.tb_CenterDis.Size = new System.Drawing.Size(193, 36);
            this.tb_CenterDis.TabIndex = 121;
            this.tb_CenterDis.Text = "00000";
            this.tb_CenterDis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_CenterDis.TextChanged += new System.EventHandler(this.tb_CenterDis_TextChanged);
            // 
            // tb_LLower
            // 
            this.tb_LLower.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_LLower.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_LLower.Location = new System.Drawing.Point(917, 925);
            this.tb_LLower.Name = "tb_LLower";
            this.tb_LLower.Size = new System.Drawing.Size(193, 36);
            this.tb_LLower.TabIndex = 123;
            this.tb_LLower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_LLower.TextChanged += new System.EventHandler(this.tb_LLower_TextChanged);
            // 
            // tb_LUpper
            // 
            this.tb_LUpper.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_LUpper.Font = new System.Drawing.Font("맑은 고딕", 20F);
            this.tb_LUpper.Location = new System.Drawing.Point(1122, 925);
            this.tb_LUpper.Name = "tb_LUpper";
            this.tb_LUpper.Size = new System.Drawing.Size(193, 36);
            this.tb_LUpper.TabIndex = 126;
            this.tb_LUpper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_LUpper.TextChanged += new System.EventHandler(this.tb_LUpper_TextChanged);
            // 
            // lb_Distance
            // 
            this.lb_Distance.AutoSize = true;
            this.lb_Distance.BackColor = System.Drawing.Color.White;
            this.lb_Distance.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Distance.Location = new System.Drawing.Point(1626, 925);
            this.lb_Distance.Name = "lb_Distance";
            this.lb_Distance.Size = new System.Drawing.Size(92, 37);
            this.lb_Distance.TabIndex = 128;
            this.lb_Distance.Text = "00000";
            this.lb_Distance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_trigger
            // 
            this.btn_trigger.BackColor = System.Drawing.Color.Transparent;
            this.btn_trigger.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_trigger.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_trigger.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_trigger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_trigger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btn_trigger.Location = new System.Drawing.Point(1175, 46);
            this.btn_trigger.Name = "btn_trigger";
            this.btn_trigger.Size = new System.Drawing.Size(351, 80);
            this.btn_trigger.TabIndex = 132;
            this.btn_trigger.UseVisualStyleBackColor = false;
            this.btn_trigger.Click += new System.EventHandler(this.btn_trigger_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1904, 1070);
            this.Controls.Add(this.btn_trigger);
            this.Controls.Add(this.lb_Distance);
            this.Controls.Add(this.tb_LUpper);
            this.Controls.Add(this.tb_LLower);
            this.Controls.Add(this.tb_CenterDis);
            this.Controls.Add(this.btn_EXIT);
            this.Controls.Add(this.cogRecordDisplay_CAMERA2);
            this.Controls.Add(this.cogRecordDisplay_CAMERA1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay_CAMERA2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay_CAMERA1;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay_CAMERA2;
        private System.Windows.Forms.Button btn_EXIT;
        private System.Windows.Forms.TextBox tb_CenterDis;
        private System.Windows.Forms.TextBox tb_LLower;
        private System.Windows.Forms.TextBox tb_LUpper;
        private System.Windows.Forms.Label lb_Distance;
        private System.Windows.Forms.Button btn_trigger;
    }
}

