namespace MachineEyes.InspectionDelivery.UserControls
{
    partial class Towel_ContractYarnAndTowelSummary
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
            this.PartyID = new DevExpress.XtraEditors.TextEdit();
            this.PartyName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.LedgerType = new DevExpress.XtraEditors.LabelControl();
            this.PrintReport = new DevExpress.XtraEditors.SimpleButton();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.PartyID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartyName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // PartyID
            // 
            this.PartyID.Location = new System.Drawing.Point(62, 41);
            this.PartyID.Name = "PartyID";
            this.PartyID.Size = new System.Drawing.Size(84, 20);
            this.PartyID.TabIndex = 314;
            this.PartyID.EditValueChanged += new System.EventHandler(this.PartyID_EditValueChanged);
            this.PartyID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PartyID_KeyDown);
            // 
            // PartyName
            // 
            this.PartyName.Location = new System.Drawing.Point(152, 41);
            this.PartyName.Name = "PartyName";
            this.PartyName.Properties.ReadOnly = true;
            this.PartyName.Size = new System.Drawing.Size(378, 20);
            this.PartyName.TabIndex = 312;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 311;
            this.labelControl1.Text = "Party";
            // 
            // LedgerType
            // 
            this.LedgerType.Appearance.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LedgerType.Appearance.Options.UseFont = true;
            this.LedgerType.Location = new System.Drawing.Point(97, 3);
            this.LedgerType.Name = "LedgerType";
            this.LedgerType.Size = new System.Drawing.Size(444, 25);
            this.LedgerType.TabIndex = 305;
            this.LedgerType.Text = "Yarn Contract Status and Towel Report";
            // 
            // PrintReport
            // 
            this.PrintReport.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintReport.Appearance.Options.UseFont = true;
            this.PrintReport.Image = global::MachineEyes.Properties.Resources.DCNumber;
            this.PrintReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.PrintReport.Location = new System.Drawing.Point(459, 81);
            this.PrintReport.Name = "PrintReport";
            this.PrintReport.Size = new System.Drawing.Size(30, 30);
            this.PrintReport.TabIndex = 313;
            this.PrintReport.Click += new System.EventHandler(this.PrintReport_Click);
            // 
            // CloseForm
            // 
            this.CloseForm.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseForm.Appearance.Options.UseFont = true;
            this.CloseForm.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseForm.Location = new System.Drawing.Point(500, 81);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(30, 30);
            this.CloseForm.TabIndex = 310;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // Towel_ContractYarnAndTowelSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PartyID);
            this.Controls.Add(this.PrintReport);
            this.Controls.Add(this.PartyName);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.LedgerType);
            this.Name = "Towel_ContractYarnAndTowelSummary";
            this.Size = new System.Drawing.Size(573, 143);
            ((System.ComponentModel.ISupportInitialize)(this.PartyID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartyName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit PartyID;
        private DevExpress.XtraEditors.SimpleButton PrintReport;
        private DevExpress.XtraEditors.TextEdit PartyName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
        public DevExpress.XtraEditors.LabelControl LedgerType;
    }
}
