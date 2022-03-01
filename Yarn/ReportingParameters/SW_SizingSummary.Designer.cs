namespace MachineEyes.Yarn.ReportingParameters
{
    partial class SW_SizingSummary
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SetNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.RefWarpingProgramNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.RadioPageSetting = new DevExpress.XtraEditors.RadioGroup();
            this.CloseMe = new DevExpress.XtraEditors.SimpleButton();
            this.PrintReport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.SetNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefWarpingProgramNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioPageSetting.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(60, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(155, 25);
            this.labelControl1.TabIndex = 241;
            this.labelControl1.Text = "Sizing Summary";
            // 
            // SetNo
            // 
            this.SetNo.Location = new System.Drawing.Point(60, 31);
            this.SetNo.Name = "SetNo";
            this.SetNo.Size = new System.Drawing.Size(201, 20);
            this.SetNo.TabIndex = 293;
            this.SetNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetNo_KeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(27, 13);
            this.labelControl2.TabIndex = 292;
            this.labelControl2.Text = "Set #";
            // 
            // RefWarpingProgramNumber
            // 
            this.RefWarpingProgramNumber.Location = new System.Drawing.Point(60, 55);
            this.RefWarpingProgramNumber.Name = "RefWarpingProgramNumber";
            this.RefWarpingProgramNumber.Properties.ReadOnly = true;
            this.RefWarpingProgramNumber.Size = new System.Drawing.Size(201, 20);
            this.RefWarpingProgramNumber.TabIndex = 295;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 58);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(27, 13);
            this.labelControl3.TabIndex = 294;
            this.labelControl3.Text = "Set #";
            // 
            // RadioPageSetting
            // 
            this.RadioPageSetting.EditValue = "H";
            this.RadioPageSetting.Location = new System.Drawing.Point(60, 81);
            this.RadioPageSetting.Name = "RadioPageSetting";
            this.RadioPageSetting.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("H", "Half Page"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("F", "Full Page")});
            this.RadioPageSetting.Size = new System.Drawing.Size(100, 54);
            this.RadioPageSetting.TabIndex = 296;
            // 
            // CloseMe
            // 
            this.CloseMe.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseMe.Appearance.Options.UseFont = true;
            this.CloseMe.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseMe.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseMe.Location = new System.Drawing.Point(235, 81);
            this.CloseMe.Name = "CloseMe";
            this.CloseMe.Size = new System.Drawing.Size(26, 25);
            this.CloseMe.TabIndex = 243;
            this.CloseMe.Click += new System.EventHandler(this.CloseMe_Click);
            // 
            // PrintReport
            // 
            this.PrintReport.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintReport.Appearance.Options.UseFont = true;
            this.PrintReport.Image = global::MachineEyes.Properties.Resources.DCNumber;
            this.PrintReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.PrintReport.Location = new System.Drawing.Point(203, 81);
            this.PrintReport.Name = "PrintReport";
            this.PrintReport.Size = new System.Drawing.Size(26, 25);
            this.PrintReport.TabIndex = 242;
            this.PrintReport.Click += new System.EventHandler(this.PrintReport_Click);
            // 
            // SW_SizingSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RadioPageSetting);
            this.Controls.Add(this.RefWarpingProgramNumber);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.SetNo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.CloseMe);
            this.Controls.Add(this.PrintReport);
            this.Controls.Add(this.labelControl1);
            this.Name = "SW_SizingSummary";
            this.Size = new System.Drawing.Size(298, 142);
            ((System.ComponentModel.ISupportInitialize)(this.SetNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefWarpingProgramNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioPageSetting.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton CloseMe;
        private DevExpress.XtraEditors.SimpleButton PrintReport;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit SetNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit RefWarpingProgramNumber;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.RadioGroup RadioPageSetting;
    }
}
