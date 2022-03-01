namespace MachineEyes.Yarn.ReportingParameters
{
    partial class Store_BinCardReport
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
            this.ToDate = new DevExpress.XtraEditors.DateEdit();
            this.FromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.LedgerType = new DevExpress.XtraEditors.LabelControl();
            this.ItemAccountID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ItemAccountName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.PrintReport = new DevExpress.XtraEditors.SimpleButton();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemAccountID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemAccountName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ToDate
            // 
            this.ToDate.EditValue = null;
            this.ToDate.EnterMoveNextControl = true;
            this.ToDate.Location = new System.Drawing.Point(102, 116);
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
            this.ToDate.TabIndex = 304;
            // 
            // FromDate
            // 
            this.FromDate.EditValue = null;
            this.FromDate.EnterMoveNextControl = true;
            this.FromDate.Location = new System.Drawing.Point(103, 86);
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
            this.FromDate.TabIndex = 303;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(80, 119);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(16, 13);
            this.labelControl4.TabIndex = 302;
            this.labelControl4.Text = "To:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(68, 89);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 13);
            this.labelControl5.TabIndex = 301;
            this.labelControl5.Text = "From:";
            // 
            // LedgerType
            // 
            this.LedgerType.Appearance.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LedgerType.Appearance.Options.UseFont = true;
            this.LedgerType.Location = new System.Drawing.Point(3, 3);
            this.LedgerType.Name = "LedgerType";
            this.LedgerType.Size = new System.Drawing.Size(266, 25);
            this.LedgerType.TabIndex = 300;
            this.LedgerType.Text = "Store && Spares Bin Card";
            // 
            // ItemAccountID
            // 
            this.ItemAccountID.Location = new System.Drawing.Point(103, 34);
            this.ItemAccountID.Name = "ItemAccountID";
            this.ItemAccountID.Size = new System.Drawing.Size(173, 20);
            this.ItemAccountID.TabIndex = 308;
            this.ItemAccountID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemAccountID_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 13);
            this.labelControl1.TabIndex = 307;
            this.labelControl1.Text = "Item Account ID";
            // 
            // ItemAccountName
            // 
            this.ItemAccountName.Location = new System.Drawing.Point(103, 60);
            this.ItemAccountName.Name = "ItemAccountName";
            this.ItemAccountName.Size = new System.Drawing.Size(306, 20);
            this.ItemAccountName.TabIndex = 309;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 63);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(94, 13);
            this.labelControl2.TabIndex = 310;
            this.labelControl2.Text = "Item Account Name";
            // 
            // PrintReport
            // 
            this.PrintReport.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintReport.Appearance.Options.UseFont = true;
            this.PrintReport.Image = global::MachineEyes.Properties.Resources.DCNumber;
            this.PrintReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.PrintReport.Location = new System.Drawing.Point(205, 155);
            this.PrintReport.Name = "PrintReport";
            this.PrintReport.Size = new System.Drawing.Size(30, 30);
            this.PrintReport.TabIndex = 306;
            this.PrintReport.Click += new System.EventHandler(this.PrintReport_Click);
            // 
            // CloseForm
            // 
            this.CloseForm.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseForm.Appearance.Options.UseFont = true;
            this.CloseForm.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseForm.Location = new System.Drawing.Point(246, 155);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(30, 30);
            this.CloseForm.TabIndex = 305;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // Store_BinCardReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.ItemAccountName);
            this.Controls.Add(this.ItemAccountID);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.PrintReport);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.LedgerType);
            this.Name = "Store_BinCardReport";
            this.Size = new System.Drawing.Size(418, 216);
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemAccountID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemAccountName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton PrintReport;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
        private DevExpress.XtraEditors.DateEdit ToDate;
        private DevExpress.XtraEditors.DateEdit FromDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LabelControl LedgerType;
        private DevExpress.XtraEditors.TextEdit ItemAccountID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit ItemAccountName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
