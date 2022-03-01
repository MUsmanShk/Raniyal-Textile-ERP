namespace MachineEyes.Accounts.ReportingParameters
{
    partial class xu_AuditTrail
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
            this.UserWiseAuditTrail = new DevExpress.XtraEditors.SimpleButton();
            this.Upto = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Close = new DevExpress.XtraEditors.SimpleButton();
            this.PrintReport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Dated.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dated.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Upto.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Upto.Properties)).BeginInit();
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
            this.Dated.TabIndex = 234;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(3, 34);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 13);
            this.labelControl5.TabIndex = 232;
            this.labelControl5.Text = "From";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(167, 25);
            this.labelControl1.TabIndex = 231;
            this.labelControl1.Text = "Audit Trail Report";
            // 
            // UserWiseAuditTrail
            // 
            this.UserWiseAuditTrail.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserWiseAuditTrail.Appearance.Options.UseFont = true;
            this.UserWiseAuditTrail.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.UserWiseAuditTrail.Location = new System.Drawing.Point(57, 95);
            this.UserWiseAuditTrail.Name = "UserWiseAuditTrail";
            this.UserWiseAuditTrail.Size = new System.Drawing.Size(111, 25);
            this.UserWiseAuditTrail.TabIndex = 236;
            this.UserWiseAuditTrail.Text = "User Wise";
            this.UserWiseAuditTrail.Click += new System.EventHandler(this.UserWiseAuditTrail_Click);
            // 
            // Upto
            // 
            this.Upto.EditValue = null;
            this.Upto.EnterMoveNextControl = true;
            this.Upto.Location = new System.Drawing.Point(52, 57);
            this.Upto.Name = "Upto";
            this.Upto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Upto.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.Upto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Upto.Properties.EditFormat.FormatString = "dd-MMM-yyyy";
            this.Upto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Upto.Properties.Mask.EditMask = "dd-MMM-yyyy";
            this.Upto.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Upto.Size = new System.Drawing.Size(143, 20);
            this.Upto.TabIndex = 238;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 13);
            this.labelControl2.TabIndex = 237;
            this.labelControl2.Text = "To";
            // 
            // Close
            // 
            this.Close.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.Appearance.Options.UseFont = true;
            this.Close.Image = global::MachineEyes.Properties.Resources.Close16;
            this.Close.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Close.Location = new System.Drawing.Point(206, 95);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(26, 25);
            this.Close.TabIndex = 235;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // PrintReport
            // 
            this.PrintReport.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintReport.Appearance.Options.UseFont = true;
            this.PrintReport.Image = global::MachineEyes.Properties.Resources.Execute;
            this.PrintReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.PrintReport.Location = new System.Drawing.Point(174, 95);
            this.PrintReport.Name = "PrintReport";
            this.PrintReport.Size = new System.Drawing.Size(26, 25);
            this.PrintReport.TabIndex = 233;
            this.PrintReport.Click += new System.EventHandler(this.PrintReport_Click);
            // 
            // xu_AuditTrail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Upto);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.UserWiseAuditTrail);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Dated);
            this.Controls.Add(this.PrintReport);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl1);
            this.Name = "xu_AuditTrail";
            this.Size = new System.Drawing.Size(310, 143);
            this.Load += new System.EventHandler(this.xu_AuditTrail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dated.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dated.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Upto.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Upto.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit Dated;
        private DevExpress.XtraEditors.SimpleButton PrintReport;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton Close;
        private DevExpress.XtraEditors.SimpleButton UserWiseAuditTrail;
        private DevExpress.XtraEditors.DateEdit Upto;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
