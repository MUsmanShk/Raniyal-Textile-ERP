namespace MachineEyes.UserControls
{
    partial class AccountGeneral
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
            this.DeliveryChallanNumber = new DevExpress.XtraEditors.TextEdit();
            this.BillNumber = new DevExpress.XtraEditors.TextEdit();
            this.InvoiceNumber = new DevExpress.XtraEditors.TextEdit();
            this.Credit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.AccountID = new DevExpress.XtraEditors.TextEdit();
            this.AccountName = new DevExpress.XtraEditors.TextEdit();
            this.Particulars = new DevExpress.XtraEditors.TextEdit();
            this.Debit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Filter_Debit = new DevExpress.XtraEditors.CheckButton();
            this.Filter_BillNumber = new DevExpress.XtraEditors.CheckButton();
            this.Filter_InvoiceNumber = new DevExpress.XtraEditors.CheckButton();
            this.Filter_DeliveryChallanNumber = new DevExpress.XtraEditors.CheckButton();
            this.Filter_Credit = new DevExpress.XtraEditors.CheckButton();
            this.Filter_AccountID = new DevExpress.XtraEditors.CheckButton();
            this.Browse_Account = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryChallanNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Credit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Particulars.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Debit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // DeliveryChallanNumber
            // 
            this.DeliveryChallanNumber.EnterMoveNextControl = true;
            this.DeliveryChallanNumber.Location = new System.Drawing.Point(681, 46);
            this.DeliveryChallanNumber.Name = "DeliveryChallanNumber";
            this.DeliveryChallanNumber.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeliveryChallanNumber.Properties.Appearance.Options.UseFont = true;
            this.DeliveryChallanNumber.Properties.NullValuePrompt = "Delivery Challan";
            this.DeliveryChallanNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.DeliveryChallanNumber.Size = new System.Drawing.Size(117, 21);
            this.DeliveryChallanNumber.TabIndex = 7;
            this.DeliveryChallanNumber.TabStop = false;
            this.DeliveryChallanNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeliveryChallanNumber_KeyDown);
            // 
            // BillNumber
            // 
            this.BillNumber.EnterMoveNextControl = true;
            this.BillNumber.Location = new System.Drawing.Point(506, 46);
            this.BillNumber.Name = "BillNumber";
            this.BillNumber.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillNumber.Properties.Appearance.Options.UseFont = true;
            this.BillNumber.Properties.NullValuePrompt = "Bill #";
            this.BillNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.BillNumber.Size = new System.Drawing.Size(143, 21);
            this.BillNumber.TabIndex = 6;
            this.BillNumber.TabStop = false;
            this.BillNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BillNumber_KeyDown);
            // 
            // InvoiceNumber
            // 
            this.InvoiceNumber.EnterMoveNextControl = true;
            this.InvoiceNumber.Location = new System.Drawing.Point(331, 46);
            this.InvoiceNumber.Name = "InvoiceNumber";
            this.InvoiceNumber.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceNumber.Properties.Appearance.Options.UseFont = true;
            this.InvoiceNumber.Properties.NullValuePrompt = "Invoice #";
            this.InvoiceNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.InvoiceNumber.Size = new System.Drawing.Size(143, 21);
            this.InvoiceNumber.TabIndex = 5;
            this.InvoiceNumber.TabStop = false;
            this.InvoiceNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InvoiceNumber_KeyDown);
            // 
            // Credit
            // 
            this.Credit.EditValue = "0";
            this.Credit.EnterMoveNextControl = true;
            this.Credit.Location = new System.Drawing.Point(218, 46);
            this.Credit.Name = "Credit";
            this.Credit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Credit.Properties.Appearance.Options.UseFont = true;
            this.Credit.Properties.Appearance.Options.UseTextOptions = true;
            this.Credit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Credit.Properties.AutoHeight = false;
            this.Credit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Credit.Properties.Mask.EditMask = "n0";
            this.Credit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Credit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Credit.Size = new System.Drawing.Size(81, 21);
            this.Credit.TabIndex = 4;
            this.Credit.EditValueChanged += new System.EventHandler(this.Credit_EditValueChanged);
            this.Credit.TextChanged += new System.EventHandler(this.Credit_TextChanged);
            this.Credit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Credit_KeyDown);
            this.Credit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Credit_KeyUp);
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Options.UseTextOptions = true;
            this.labelControl13.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl13.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl13.Location = new System.Drawing.Point(176, 47);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(36, 18);
            this.labelControl13.TabIndex = 243;
            this.labelControl13.Text = "Credit";
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl17.Appearance.Options.UseFont = true;
            this.labelControl17.Appearance.Options.UseTextOptions = true;
            this.labelControl17.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl17.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl17.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl17.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl17.Location = new System.Drawing.Point(0, 24);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(60, 21);
            this.labelControl17.TabIndex = 242;
            this.labelControl17.Text = "Particulars";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Appearance.Options.UseTextOptions = true;
            this.labelControl14.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl14.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl14.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl14.Location = new System.Drawing.Point(0, 0);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(60, 20);
            this.labelControl14.TabIndex = 241;
            this.labelControl14.Text = "Account";
            // 
            // AccountID
            // 
            this.AccountID.EditValue = "";
            this.AccountID.EnterMoveNextControl = true;
            this.AccountID.Location = new System.Drawing.Point(63, 0);
            this.AccountID.Name = "AccountID";
            this.AccountID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountID.Properties.Appearance.Options.UseFont = true;
            this.AccountID.Properties.MaxLength = 13;
            this.AccountID.Size = new System.Drawing.Size(107, 21);
            this.AccountID.TabIndex = 0;
            this.AccountID.TextChanged += new System.EventHandler(this.AccountID_TextChanged);
            this.AccountID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountID_KeyDown);
            // 
            // AccountName
            // 
            this.AccountName.EnterMoveNextControl = true;
            this.AccountName.Location = new System.Drawing.Point(176, 0);
            this.AccountName.Name = "AccountName";
            this.AccountName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountName.Properties.Appearance.Options.UseFont = true;
            this.AccountName.Size = new System.Drawing.Size(596, 21);
            this.AccountName.TabIndex = 238;
            this.AccountName.TabStop = false;
            this.AccountName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountName_KeyDown);
            // 
            // Particulars
            // 
            this.Particulars.EnterMoveNextControl = true;
            this.Particulars.Location = new System.Drawing.Point(63, 24);
            this.Particulars.Name = "Particulars";
            this.Particulars.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Particulars.Properties.Appearance.Options.UseFont = true;
            this.Particulars.Properties.Appearance.Options.UseTextOptions = true;
            this.Particulars.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.Particulars.Properties.AutoHeight = false;
            this.Particulars.Size = new System.Drawing.Size(735, 20);
            this.Particulars.TabIndex = 2;
            this.Particulars.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Particulars_KeyDown);
            // 
            // Debit
            // 
            this.Debit.EditValue = "0";
            this.Debit.EnterMoveNextControl = true;
            this.Debit.Location = new System.Drawing.Point(63, 46);
            this.Debit.Name = "Debit";
            this.Debit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Debit.Properties.Appearance.Options.UseFont = true;
            this.Debit.Properties.Appearance.Options.UseTextOptions = true;
            this.Debit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Debit.Properties.AutoHeight = false;
            this.Debit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Debit.Properties.Mask.EditMask = "n0";
            this.Debit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Debit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Debit.Size = new System.Drawing.Size(91, 21);
            this.Debit.TabIndex = 3;
            this.Debit.EditValueChanged += new System.EventHandler(this.Debit_EditValueChanged);
            this.Debit.TextChanged += new System.EventHandler(this.Debit_TextChanged);
            this.Debit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Debit_KeyDown);
            this.Debit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Debit_KeyUp);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(24, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 20);
            this.labelControl1.TabIndex = 254;
            this.labelControl1.Text = "Debit";
            // 
            // Filter_Debit
            // 
            this.Filter_Debit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_Debit.Appearance.Options.UseFont = true;
            this.Filter_Debit.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_Debit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_Debit.Location = new System.Drawing.Point(160, 46);
            this.Filter_Debit.Name = "Filter_Debit";
            this.Filter_Debit.Size = new System.Drawing.Size(20, 20);
            this.Filter_Debit.TabIndex = 255;
            this.Filter_Debit.TabStop = false;
            // 
            // Filter_BillNumber
            // 
            this.Filter_BillNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_BillNumber.Appearance.Options.UseFont = true;
            this.Filter_BillNumber.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_BillNumber.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_BillNumber.Location = new System.Drawing.Point(655, 46);
            this.Filter_BillNumber.Name = "Filter_BillNumber";
            this.Filter_BillNumber.Size = new System.Drawing.Size(20, 20);
            this.Filter_BillNumber.TabIndex = 250;
            this.Filter_BillNumber.TabStop = false;
            // 
            // Filter_InvoiceNumber
            // 
            this.Filter_InvoiceNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_InvoiceNumber.Appearance.Options.UseFont = true;
            this.Filter_InvoiceNumber.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_InvoiceNumber.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_InvoiceNumber.Location = new System.Drawing.Point(480, 46);
            this.Filter_InvoiceNumber.Name = "Filter_InvoiceNumber";
            this.Filter_InvoiceNumber.Size = new System.Drawing.Size(20, 20);
            this.Filter_InvoiceNumber.TabIndex = 249;
            this.Filter_InvoiceNumber.TabStop = false;
            // 
            // Filter_DeliveryChallanNumber
            // 
            this.Filter_DeliveryChallanNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_DeliveryChallanNumber.Appearance.Options.UseFont = true;
            this.Filter_DeliveryChallanNumber.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_DeliveryChallanNumber.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_DeliveryChallanNumber.Location = new System.Drawing.Point(804, 46);
            this.Filter_DeliveryChallanNumber.Name = "Filter_DeliveryChallanNumber";
            this.Filter_DeliveryChallanNumber.Size = new System.Drawing.Size(20, 20);
            this.Filter_DeliveryChallanNumber.TabIndex = 248;
            this.Filter_DeliveryChallanNumber.TabStop = false;
            // 
            // Filter_Credit
            // 
            this.Filter_Credit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_Credit.Appearance.Options.UseFont = true;
            this.Filter_Credit.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_Credit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_Credit.Location = new System.Drawing.Point(305, 46);
            this.Filter_Credit.Name = "Filter_Credit";
            this.Filter_Credit.Size = new System.Drawing.Size(20, 20);
            this.Filter_Credit.TabIndex = 246;
            this.Filter_Credit.TabStop = false;
            // 
            // Filter_AccountID
            // 
            this.Filter_AccountID.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_AccountID.Appearance.Options.UseFont = true;
            this.Filter_AccountID.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_AccountID.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_AccountID.Location = new System.Drawing.Point(778, 0);
            this.Filter_AccountID.Name = "Filter_AccountID";
            this.Filter_AccountID.Size = new System.Drawing.Size(20, 20);
            this.Filter_AccountID.TabIndex = 245;
            this.Filter_AccountID.TabStop = false;
            // 
            // Browse_Account
            // 
            this.Browse_Account.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Browse_Account.Appearance.Options.UseFont = true;
            this.Browse_Account.Image = global::MachineEyes.Properties.Resources.Account;
            this.Browse_Account.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Browse_Account.Location = new System.Drawing.Point(804, 0);
            this.Browse_Account.Name = "Browse_Account";
            this.Browse_Account.Size = new System.Drawing.Size(20, 20);
            this.Browse_Account.TabIndex = 1;
            this.Browse_Account.Click += new System.EventHandler(this.Browse_Account_Click);
            // 
            // AccountGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Filter_Debit);
            this.Controls.Add(this.Debit);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Filter_BillNumber);
            this.Controls.Add(this.Filter_InvoiceNumber);
            this.Controls.Add(this.Filter_DeliveryChallanNumber);
            this.Controls.Add(this.Filter_Credit);
            this.Controls.Add(this.Filter_AccountID);
            this.Controls.Add(this.DeliveryChallanNumber);
            this.Controls.Add(this.BillNumber);
            this.Controls.Add(this.InvoiceNumber);
            this.Controls.Add(this.Browse_Account);
            this.Controls.Add(this.Credit);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.AccountID);
            this.Controls.Add(this.AccountName);
            this.Controls.Add(this.Particulars);
            this.Name = "AccountGeneral";
            this.Size = new System.Drawing.Size(837, 70);
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryChallanNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Credit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Particulars.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Debit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.CheckButton Filter_BillNumber;
        public DevExpress.XtraEditors.CheckButton Filter_InvoiceNumber;
        public DevExpress.XtraEditors.CheckButton Filter_DeliveryChallanNumber;
        public DevExpress.XtraEditors.CheckButton Filter_Credit;
        public DevExpress.XtraEditors.CheckButton Filter_AccountID;
        public DevExpress.XtraEditors.TextEdit DeliveryChallanNumber;
        public DevExpress.XtraEditors.TextEdit BillNumber;
        public DevExpress.XtraEditors.TextEdit InvoiceNumber;
        public DevExpress.XtraEditors.SimpleButton Browse_Account;
        public DevExpress.XtraEditors.TextEdit Credit;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        public DevExpress.XtraEditors.TextEdit AccountID;
        public DevExpress.XtraEditors.TextEdit AccountName;
        public DevExpress.XtraEditors.TextEdit Particulars;
        public DevExpress.XtraEditors.CheckButton Filter_Debit;
        public DevExpress.XtraEditors.TextEdit Debit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
