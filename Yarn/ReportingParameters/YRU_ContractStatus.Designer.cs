namespace MachineEyes.Yarn.ReportingParameters
{
    partial class YRU_ContractStatus
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
            this.ContractSummary = new DevExpress.XtraEditors.SimpleButton();
            this.ToDate = new DevExpress.XtraEditors.DateEdit();
            this.FromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.LedgerType = new DevExpress.XtraEditors.LabelControl();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ContractSummary
            // 
            this.ContractSummary.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContractSummary.Appearance.Options.UseFont = true;
            this.ContractSummary.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ContractSummary.Location = new System.Drawing.Point(220, 34);
            this.ContractSummary.Name = "ContractSummary";
            this.ContractSummary.Size = new System.Drawing.Size(68, 49);
            this.ContractSummary.TabIndex = 284;
            this.ContractSummary.ToolTip = "Yarn Contracts Summary";
            this.ContractSummary.ToolTipTitle = "Contract Status";
            this.ContractSummary.Click += new System.EventHandler(this.ContractSummary_Click);
            // 
            // ToDate
            // 
            this.ToDate.EditValue = null;
            this.ToDate.EnterMoveNextControl = true;
            this.ToDate.Location = new System.Drawing.Point(40, 63);
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
            this.ToDate.TabIndex = 283;
            // 
            // FromDate
            // 
            this.FromDate.EditValue = null;
            this.FromDate.EnterMoveNextControl = true;
            this.FromDate.Location = new System.Drawing.Point(41, 33);
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
            this.FromDate.TabIndex = 282;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(18, 66);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(16, 13);
            this.labelControl4.TabIndex = 281;
            this.labelControl4.Text = "To:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(6, 36);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 13);
            this.labelControl5.TabIndex = 280;
            this.labelControl5.Text = "From:";
            // 
            // LedgerType
            // 
            this.LedgerType.Appearance.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LedgerType.Appearance.Options.UseFont = true;
            this.LedgerType.Location = new System.Drawing.Point(1, 2);
            this.LedgerType.Name = "LedgerType";
            this.LedgerType.Size = new System.Drawing.Size(287, 25);
            this.LedgerType.TabIndex = 279;
            this.LedgerType.Text = "Contract Status Summary";
            // 
            // CloseForm
            // 
            this.CloseForm.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseForm.Appearance.Options.UseFont = true;
            this.CloseForm.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseForm.Location = new System.Drawing.Point(365, 149);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(30, 30);
            this.CloseForm.TabIndex = 285;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // YRU_ContractStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.ContractSummary);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.LedgerType);
            this.Name = "YRU_ContractStatus";
            this.Size = new System.Drawing.Size(426, 197);
            this.Load += new System.EventHandler(this.YRU_ContractStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton ContractSummary;
        private DevExpress.XtraEditors.DateEdit ToDate;
        private DevExpress.XtraEditors.DateEdit FromDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LabelControl LedgerType;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
    }
}
