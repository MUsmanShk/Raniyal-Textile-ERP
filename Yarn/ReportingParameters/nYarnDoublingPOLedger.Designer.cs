namespace MachineEyes.Yarn.ReportingParameters
{
    partial class nYarnDoublingPOLedger
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
            this.DoublingPartyAccount = new DevExpress.XtraEditors.TextEdit();
            this.ToDate = new DevExpress.XtraEditors.DateEdit();
            this.FromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.WorkOrderLabel = new DevExpress.XtraEditors.LabelControl();
            this.DoublingWorkOrderNumber = new DevExpress.XtraEditors.TextEdit();
            this.PrintReport = new DevExpress.XtraEditors.SimpleButton();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.DoublingPartyAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoublingWorkOrderNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(167, 19);
            this.labelControl1.TabIndex = 269;
            this.labelControl1.Text = "Doubling Party Account";
            // 
            // DoublingPartyAccount
            // 
            this.DoublingPartyAccount.EnterMoveNextControl = true;
            this.DoublingPartyAccount.Location = new System.Drawing.Point(173, 29);
            this.DoublingPartyAccount.Name = "DoublingPartyAccount";
            this.DoublingPartyAccount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoublingPartyAccount.Properties.Appearance.Options.UseFont = true;
            this.DoublingPartyAccount.Properties.ReadOnly = true;
            this.DoublingPartyAccount.Size = new System.Drawing.Size(333, 26);
            this.DoublingPartyAccount.TabIndex = 0;
            this.DoublingPartyAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Accountof_KeyDown);
            // 
            // ToDate
            // 
            this.ToDate.EditValue = null;
            this.ToDate.EnterMoveNextControl = true;
            this.ToDate.Location = new System.Drawing.Point(172, 143);
            this.ToDate.Name = "ToDate";
            this.ToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ToDate.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.ToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ToDate.Properties.EditFormat.FormatString = "dd-MMM-yyyy";
            this.ToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ToDate.Properties.Mask.EditMask = "dd-MMM-yyyy";
            this.ToDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ToDate.Size = new System.Drawing.Size(174, 20);
            this.ToDate.TabIndex = 3;
            // 
            // FromDate
            // 
            this.FromDate.EditValue = null;
            this.FromDate.EnterMoveNextControl = true;
            this.FromDate.Location = new System.Drawing.Point(173, 113);
            this.FromDate.Name = "FromDate";
            this.FromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FromDate.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.FromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.FromDate.Properties.EditFormat.FormatString = "dd-MMM-yyyy";
            this.FromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.FromDate.Properties.Mask.EditMask = "dd-MMM-yyyy";
            this.FromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.FromDate.Size = new System.Drawing.Size(173, 20);
            this.FromDate.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.LineVisible = true;
            this.labelControl4.Location = new System.Drawing.Point(25, 149);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(140, 10);
            this.labelControl4.TabIndex = 264;
            this.labelControl4.Text = "To:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.LineVisible = true;
            this.labelControl5.Location = new System.Drawing.Point(25, 119);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(140, 10);
            this.labelControl5.TabIndex = 263;
            this.labelControl5.Text = "From:";
            // 
            // WorkOrderLabel
            // 
            this.WorkOrderLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkOrderLabel.Appearance.Options.UseFont = true;
            this.WorkOrderLabel.Location = new System.Drawing.Point(69, 75);
            this.WorkOrderLabel.Name = "WorkOrderLabel";
            this.WorkOrderLabel.Size = new System.Drawing.Size(100, 19);
            this.WorkOrderLabel.TabIndex = 283;
            this.WorkOrderLabel.Text = "Work Order #";
            // 
            // DoublingWorkOrderNumber
            // 
            this.DoublingWorkOrderNumber.EnterMoveNextControl = true;
            this.DoublingWorkOrderNumber.Location = new System.Drawing.Point(173, 72);
            this.DoublingWorkOrderNumber.Name = "DoublingWorkOrderNumber";
            this.DoublingWorkOrderNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoublingWorkOrderNumber.Properties.Appearance.Options.UseFont = true;
            this.DoublingWorkOrderNumber.Properties.ReadOnly = true;
            this.DoublingWorkOrderNumber.Size = new System.Drawing.Size(333, 26);
            this.DoublingWorkOrderNumber.TabIndex = 1;
            this.DoublingWorkOrderNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoublingWorkOrderNumber_KeyDown);
            // 
            // PrintReport
            // 
            this.PrintReport.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintReport.Appearance.Options.UseFont = true;
            this.PrintReport.Image = global::MachineEyes.Properties.Resources.down16x16;
            this.PrintReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.PrintReport.Location = new System.Drawing.Point(280, 182);
            this.PrintReport.Name = "PrintReport";
            this.PrintReport.Size = new System.Drawing.Size(30, 30);
            this.PrintReport.TabIndex = 4;
            this.PrintReport.Click += new System.EventHandler(this.PrintReport_Click);
            // 
            // CloseForm
            // 
            this.CloseForm.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseForm.Appearance.Options.UseFont = true;
            this.CloseForm.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseForm.Location = new System.Drawing.Point(316, 182);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(30, 30);
            this.CloseForm.TabIndex = 5;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // nYarnDoublingPOLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WorkOrderLabel);
            this.Controls.Add(this.DoublingWorkOrderNumber);
            this.Controls.Add(this.PrintReport);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.DoublingPartyAccount);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Name = "nYarnDoublingPOLedger";
            this.Size = new System.Drawing.Size(564, 280);
            this.Load += new System.EventHandler(this.nYarnItemLedger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DoublingPartyAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoublingWorkOrderNumber.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton PrintReport;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit DoublingPartyAccount;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
        private DevExpress.XtraEditors.DateEdit ToDate;
        private DevExpress.XtraEditors.DateEdit FromDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LabelControl WorkOrderLabel;
        public DevExpress.XtraEditors.TextEdit DoublingWorkOrderNumber;
    }
}
