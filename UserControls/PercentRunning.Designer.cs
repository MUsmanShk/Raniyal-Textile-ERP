namespace MachineEyes.UserControls
{
    partial class PercentRunning
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RunningPercent = new DevExpress.XtraEditors.LabelControl();
            this.RunningLabel = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // RunningPercent
            // 
            this.RunningPercent.Appearance.BackColor = System.Drawing.Color.Black;
            this.RunningPercent.Appearance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunningPercent.Appearance.ForeColor = System.Drawing.Color.White;
            this.RunningPercent.Appearance.Options.UseBackColor = true;
            this.RunningPercent.Appearance.Options.UseFont = true;
            this.RunningPercent.Appearance.Options.UseForeColor = true;
            this.RunningPercent.Appearance.Options.UseTextOptions = true;
            this.RunningPercent.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.RunningPercent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.RunningPercent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.RunningPercent.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
            this.RunningPercent.Location = new System.Drawing.Point(3, 35);
            this.RunningPercent.Name = "RunningPercent";
            this.RunningPercent.Padding = new System.Windows.Forms.Padding(2);
            this.RunningPercent.Size = new System.Drawing.Size(196, 67);
            this.RunningPercent.TabIndex = 119;
            this.RunningPercent.Text = "100.0";
            // 
            // RunningLabel
            // 
            this.RunningLabel.Appearance.BackColor = System.Drawing.Color.Black;
            this.RunningLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunningLabel.Appearance.ForeColor = System.Drawing.Color.White;
            this.RunningLabel.Appearance.Options.UseBackColor = true;
            this.RunningLabel.Appearance.Options.UseFont = true;
            this.RunningLabel.Appearance.Options.UseForeColor = true;
            this.RunningLabel.Appearance.Options.UseTextOptions = true;
            this.RunningLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RunningLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.RunningLabel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.RunningLabel.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
            this.RunningLabel.Location = new System.Drawing.Point(3, 3);
            this.RunningLabel.Name = "RunningLabel";
            this.RunningLabel.Padding = new System.Windows.Forms.Padding(2);
            this.RunningLabel.Size = new System.Drawing.Size(196, 30);
            this.RunningLabel.TabIndex = 120;
            this.RunningLabel.Text = "Running (%)";
            // 
            // PercentRunning
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RunningLabel);
            this.Controls.Add(this.RunningPercent);
            this.Name = "PercentRunning";
            this.Size = new System.Drawing.Size(202, 105);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LabelControl RunningPercent;
        public DevExpress.XtraEditors.LabelControl RunningLabel;
    }
}
