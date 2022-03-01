namespace MachineEyes.UserControls
{
    partial class AccountField
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
            this.Amount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.AccountID = new DevExpress.XtraEditors.TextEdit();
            this.Particulars = new DevExpress.XtraEditors.TextEdit();
            this.ChequeNumber = new DevExpress.XtraEditors.TextEdit();
            this.InvoiceNumber = new DevExpress.XtraEditors.TextEdit();
            this.BillNumber = new DevExpress.XtraEditors.TextEdit();
            this.DeliveryChallanNumber = new DevExpress.XtraEditors.TextEdit();
            this.AccountName = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.Filter_BillNumber = new DevExpress.XtraEditors.CheckButton();
            this.Filter_InvoiceNumber = new DevExpress.XtraEditors.CheckButton();
            this.Filter_DeliveryChallanNumber = new DevExpress.XtraEditors.CheckButton();
            this.Filter_ChequeNumber = new DevExpress.XtraEditors.CheckButton();
            this.Filter_Amount = new DevExpress.XtraEditors.CheckButton();
            this.Filter_AccountID = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.Amount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Particulars.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChequeNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryChallanNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Amount
            // 
            this.Amount.EditValue = "0";
            this.Amount.EnterMoveNextControl = true;
            this.Amount.Location = new System.Drawing.Point(516, 26);
            this.Amount.Name = "Amount";
            this.Amount.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amount.Properties.Appearance.Options.UseFont = true;
            this.Amount.Properties.Appearance.Options.UseTextOptions = true;
            this.Amount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Amount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.Properties.Mask.EditMask = "n0";
            this.Amount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Amount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Amount.Size = new System.Drawing.Size(76, 21);
            this.Amount.TabIndex = 3;
            this.Amount.EditValueChanged += new System.EventHandler(this.Amount_EditValueChanged);
            this.Amount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Amount_KeyDown);
            this.Amount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Amount_KeyUp);
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(473, 28);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(37, 13);
            this.labelControl13.TabIndex = 191;
            this.labelControl13.Text = "Amount";
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl17.Appearance.Options.UseFont = true;
            this.labelControl17.Appearance.Options.UseTextOptions = true;
            this.labelControl17.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl17.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl17.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl17.Location = new System.Drawing.Point(3, 25);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(55, 20);
            this.labelControl17.TabIndex = 184;
            this.labelControl17.Text = "Particulars";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Appearance.Options.UseTextOptions = true;
            this.labelControl14.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl14.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl14.Location = new System.Drawing.Point(2, 3);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(55, 20);
            this.labelControl14.TabIndex = 177;
            this.labelControl14.Text = "Account";
            // 
            // AccountID
            // 
            this.AccountID.EditValue = "";
            this.AccountID.EnterMoveNextControl = true;
            this.AccountID.Location = new System.Drawing.Point(63, 3);
            this.AccountID.Name = "AccountID";
            this.AccountID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountID.Properties.Appearance.Options.UseFont = true;
            this.AccountID.Properties.MaxLength = 13;
            this.AccountID.Properties.ReadOnly = true;
            this.AccountID.Size = new System.Drawing.Size(107, 21);
            this.AccountID.TabIndex = 0;
            this.AccountID.EditValueChanged += new System.EventHandler(this.AccountID_EditValueChanged);
            this.AccountID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountID_KeyDown);
            // 
            // Particulars
            // 
            this.Particulars.EnterMoveNextControl = true;
            this.Particulars.Location = new System.Drawing.Point(63, 25);
            this.Particulars.Name = "Particulars";
            this.Particulars.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Particulars.Properties.Appearance.Options.UseFont = true;
            this.Particulars.Size = new System.Drawing.Size(404, 21);
            this.Particulars.TabIndex = 2;
            this.Particulars.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Particulars_KeyDown);
            // 
            // ChequeNumber
            // 
            this.ChequeNumber.EnterMoveNextControl = true;
            this.ChequeNumber.Location = new System.Drawing.Point(644, 2);
            this.ChequeNumber.Name = "ChequeNumber";
            this.ChequeNumber.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChequeNumber.Properties.Appearance.Options.UseFont = true;
            this.ChequeNumber.Properties.MaxLength = 13;
            this.ChequeNumber.Properties.NullValuePrompt = "Cheque #";
            this.ChequeNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.ChequeNumber.Size = new System.Drawing.Size(106, 21);
            this.ChequeNumber.TabIndex = 4;
            this.ChequeNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChequeNumber_KeyDown);
            // 
            // InvoiceNumber
            // 
            this.InvoiceNumber.EnterMoveNextControl = true;
            this.InvoiceNumber.Location = new System.Drawing.Point(804, 2);
            this.InvoiceNumber.Name = "InvoiceNumber";
            this.InvoiceNumber.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceNumber.Properties.Appearance.Options.UseFont = true;
            this.InvoiceNumber.Properties.MaxLength = 13;
            this.InvoiceNumber.Properties.NullValuePrompt = "Invoice Number";
            this.InvoiceNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.InvoiceNumber.Properties.ReadOnly = true;
            this.InvoiceNumber.Size = new System.Drawing.Size(132, 21);
            this.InvoiceNumber.TabIndex = 6;
            this.InvoiceNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InvoiceNumber_KeyDown);
            // 
            // BillNumber
            // 
            this.BillNumber.EnterMoveNextControl = true;
            this.BillNumber.Location = new System.Drawing.Point(804, 25);
            this.BillNumber.Name = "BillNumber";
            this.BillNumber.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillNumber.Properties.Appearance.Options.UseFont = true;
            this.BillNumber.Properties.MaxLength = 13;
            this.BillNumber.Properties.NullValuePrompt = "Bill Number";
            this.BillNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.BillNumber.Size = new System.Drawing.Size(132, 21);
            this.BillNumber.TabIndex = 7;
            this.BillNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BillNumber_KeyDown);
            // 
            // DeliveryChallanNumber
            // 
            this.DeliveryChallanNumber.EnterMoveNextControl = true;
            this.DeliveryChallanNumber.Location = new System.Drawing.Point(644, 25);
            this.DeliveryChallanNumber.Name = "DeliveryChallanNumber";
            this.DeliveryChallanNumber.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeliveryChallanNumber.Properties.Appearance.Options.UseFont = true;
            this.DeliveryChallanNumber.Properties.MaxLength = 13;
            this.DeliveryChallanNumber.Properties.NullValuePrompt = "Delivery Challan";
            this.DeliveryChallanNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.DeliveryChallanNumber.Size = new System.Drawing.Size(106, 21);
            this.DeliveryChallanNumber.TabIndex = 5;
            this.DeliveryChallanNumber.EditValueChanged += new System.EventHandler(this.DeliveryChallanNumber_EditValueChanged);
            this.DeliveryChallanNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeliveryChallanNumber_KeyDown);
            // 
            // AccountName
            // 
            this.AccountName.EnterMoveNextControl = true;
            this.AccountName.Location = new System.Drawing.Point(170, 3);
            this.AccountName.Name = "AccountName";
            this.AccountName.Properties.Appearance.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountName.Properties.Appearance.Options.UseFont = true;
            this.AccountName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AccountName.Properties.NullText = "";
            this.AccountName.Properties.NullValuePrompt = "Account Name";
            this.AccountName.Size = new System.Drawing.Size(422, 22);
            this.AccountName.TabIndex = 1;
            this.AccountName.EditValueChanged += new System.EventHandler(this.AccountName_EditValueChanged);
            this.AccountName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountName_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(617, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 21);
            this.labelControl1.TabIndex = 226;
            this.labelControl1.Text = "CHQ";
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(617, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(21, 21);
            this.labelControl2.TabIndex = 227;
            this.labelControl2.Text = "D/C";
            // 
            // labelControl3
            // 
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(777, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(21, 21);
            this.labelControl3.TabIndex = 228;
            this.labelControl3.Text = "INV";
            // 
            // labelControl4
            // 
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(777, 24);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(21, 21);
            this.labelControl4.TabIndex = 229;
            this.labelControl4.Text = "G/P";
            // 
            // Filter_BillNumber
            // 
            this.Filter_BillNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_BillNumber.Appearance.Options.UseFont = true;
            this.Filter_BillNumber.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_BillNumber.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_BillNumber.Location = new System.Drawing.Point(942, 25);
            this.Filter_BillNumber.Name = "Filter_BillNumber";
            this.Filter_BillNumber.Size = new System.Drawing.Size(20, 20);
            this.Filter_BillNumber.TabIndex = 225;
            this.Filter_BillNumber.TabStop = false;
            // 
            // Filter_InvoiceNumber
            // 
            this.Filter_InvoiceNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_InvoiceNumber.Appearance.Options.UseFont = true;
            this.Filter_InvoiceNumber.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_InvoiceNumber.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_InvoiceNumber.Location = new System.Drawing.Point(942, 3);
            this.Filter_InvoiceNumber.Name = "Filter_InvoiceNumber";
            this.Filter_InvoiceNumber.Size = new System.Drawing.Size(20, 20);
            this.Filter_InvoiceNumber.TabIndex = 224;
            this.Filter_InvoiceNumber.TabStop = false;
            // 
            // Filter_DeliveryChallanNumber
            // 
            this.Filter_DeliveryChallanNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_DeliveryChallanNumber.Appearance.Options.UseFont = true;
            this.Filter_DeliveryChallanNumber.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_DeliveryChallanNumber.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_DeliveryChallanNumber.Location = new System.Drawing.Point(751, 25);
            this.Filter_DeliveryChallanNumber.Name = "Filter_DeliveryChallanNumber";
            this.Filter_DeliveryChallanNumber.Size = new System.Drawing.Size(20, 20);
            this.Filter_DeliveryChallanNumber.TabIndex = 223;
            this.Filter_DeliveryChallanNumber.TabStop = false;
            // 
            // Filter_ChequeNumber
            // 
            this.Filter_ChequeNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_ChequeNumber.Appearance.Options.UseFont = true;
            this.Filter_ChequeNumber.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_ChequeNumber.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_ChequeNumber.Location = new System.Drawing.Point(751, 3);
            this.Filter_ChequeNumber.Name = "Filter_ChequeNumber";
            this.Filter_ChequeNumber.Size = new System.Drawing.Size(20, 20);
            this.Filter_ChequeNumber.TabIndex = 222;
            this.Filter_ChequeNumber.TabStop = false;
            // 
            // Filter_Amount
            // 
            this.Filter_Amount.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_Amount.Appearance.Options.UseFont = true;
            this.Filter_Amount.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_Amount.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_Amount.Location = new System.Drawing.Point(591, 27);
            this.Filter_Amount.Name = "Filter_Amount";
            this.Filter_Amount.Size = new System.Drawing.Size(20, 20);
            this.Filter_Amount.TabIndex = 221;
            this.Filter_Amount.TabStop = false;
            // 
            // Filter_AccountID
            // 
            this.Filter_AccountID.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_AccountID.Appearance.Options.UseFont = true;
            this.Filter_AccountID.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_AccountID.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_AccountID.Location = new System.Drawing.Point(591, 3);
            this.Filter_AccountID.Name = "Filter_AccountID";
            this.Filter_AccountID.Size = new System.Drawing.Size(20, 20);
            this.Filter_AccountID.TabIndex = 220;
            this.Filter_AccountID.TabStop = false;
            // 
            // AccountField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.AccountName);
            this.Controls.Add(this.Filter_BillNumber);
            this.Controls.Add(this.Filter_InvoiceNumber);
            this.Controls.Add(this.Filter_DeliveryChallanNumber);
            this.Controls.Add(this.Filter_ChequeNumber);
            this.Controls.Add(this.Filter_Amount);
            this.Controls.Add(this.Filter_AccountID);
            this.Controls.Add(this.DeliveryChallanNumber);
            this.Controls.Add(this.BillNumber);
            this.Controls.Add(this.InvoiceNumber);
            this.Controls.Add(this.ChequeNumber);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.AccountID);
            this.Controls.Add(this.Particulars);
            this.Name = "AccountField";
            this.Size = new System.Drawing.Size(965, 48);
            this.Load += new System.EventHandler(this.AccountField_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountField_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Amount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Particulars.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChequeNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryChallanNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        public DevExpress.XtraEditors.TextEdit ChequeNumber;
        public DevExpress.XtraEditors.TextEdit InvoiceNumber;
        public DevExpress.XtraEditors.TextEdit BillNumber;
        public DevExpress.XtraEditors.TextEdit DeliveryChallanNumber;
        public DevExpress.XtraEditors.TextEdit Amount;
        public DevExpress.XtraEditors.TextEdit AccountID;
        public DevExpress.XtraEditors.TextEdit Particulars;
        public DevExpress.XtraEditors.CheckButton Filter_AccountID;
        public DevExpress.XtraEditors.CheckButton Filter_Amount;
        public DevExpress.XtraEditors.CheckButton Filter_ChequeNumber;
        public DevExpress.XtraEditors.CheckButton Filter_DeliveryChallanNumber;
        public DevExpress.XtraEditors.CheckButton Filter_InvoiceNumber;
        public DevExpress.XtraEditors.CheckButton Filter_BillNumber;
        private DevExpress.XtraEditors.LookUpEdit AccountName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
