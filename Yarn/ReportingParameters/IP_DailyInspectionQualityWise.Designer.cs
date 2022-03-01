namespace MachineEyes.Yarn.ReportingParameters
{
    partial class IP_DailyInspectionQualityWise
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
            this.Dated = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.CloseMe = new DevExpress.XtraEditors.SimpleButton();
            this.PrintReport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Dated.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dated.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Dated
            // 
            this.Dated.EditValue = null;
            this.Dated.EnterMoveNextControl = true;
            this.Dated.Location = new System.Drawing.Point(52, 31);
            this.Dated.Name = "Dated";
            this.Dated.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Dated.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.Dated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Dated.Properties.EditFormat.FormatString = "dd-MMM-yyyy";
            this.Dated.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Dated.Properties.Mask.EditMask = "dd-MMM-yyyy";
            this.Dated.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Dated.Size = new System.Drawing.Size(143, 20);
            this.Dated.TabIndex = 239;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(3, 34);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(29, 13);
            this.labelControl5.TabIndex = 237;
            this.labelControl5.Text = "Dated";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(222, 25);
            this.labelControl1.TabIndex = 236;
            this.labelControl1.Text = "Daily Inspection Report";
            // 
            // CloseMe
            // 
            this.CloseMe.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseMe.Appearance.Options.UseFont = true;
            this.CloseMe.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseMe.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseMe.Location = new System.Drawing.Point(201, 57);
            this.CloseMe.Name = "CloseMe";
            this.CloseMe.Size = new System.Drawing.Size(26, 25);
            this.CloseMe.TabIndex = 240;
            this.CloseMe.Click += new System.EventHandler(this.CloseMe_Click);
            // 
            // PrintReport
            // 
            this.PrintReport.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintReport.Appearance.Options.UseFont = true;
            this.PrintReport.Image = global::MachineEyes.Properties.Resources.DCNumber;
            this.PrintReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.PrintReport.Location = new System.Drawing.Point(169, 57);
            this.PrintReport.Name = "PrintReport";
            this.PrintReport.Size = new System.Drawing.Size(26, 25);
            this.PrintReport.TabIndex = 238;
            this.PrintReport.Click += new System.EventHandler(this.PrintReport_Click);
            // 
            // IP_DailyInspectionQualityWise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CloseMe);
            this.Controls.Add(this.Dated);
            this.Controls.Add(this.PrintReport);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl1);
            this.Name = "IP_DailyInspectionQualityWise";
            this.Size = new System.Drawing.Size(301, 130);
            ((System.ComponentModel.ISupportInitialize)(this.Dated.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dated.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton CloseMe;
        private DevExpress.XtraEditors.DateEdit Dated;
        private DevExpress.XtraEditors.SimpleButton PrintReport;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
