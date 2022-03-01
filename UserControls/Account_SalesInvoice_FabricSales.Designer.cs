namespace MachineEyes.UserControls
{
    partial class Account_SalesInvoice_FabricSales
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
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.AccountID = new DevExpress.XtraEditors.TextEdit();
            this.AccountName = new DevExpress.XtraEditors.TextEdit();
            this.Item = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Rate = new DevExpress.XtraEditors.TextEdit();
            this.AmountExcludingTax = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.AmountIncludingTax = new DevExpress.XtraEditors.TextEdit();
            this.DeliveryChallanNumber = new DevExpress.XtraEditors.TextEdit();
            this.GatePassNumber = new DevExpress.XtraEditors.TextEdit();
            this.PackingListNumber = new DevExpress.XtraEditors.TextEdit();
            this.ItemID = new DevExpress.XtraEditors.TextEdit();
            this.Quantity = new DevExpress.XtraEditors.TextEdit();
            this.AmountTax = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.SellingUnit = new DevExpress.XtraEditors.LookUpEdit();
            this.GSTRate = new DevExpress.XtraEditors.TextEdit();
            this.RefInv = new DevExpress.XtraEditors.TextEdit();
            this.ContractNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.RefDebiteNoteNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.checkTax = new DevExpress.XtraEditors.CheckButton();
            this.checkRateQty = new DevExpress.XtraEditors.CheckButton();
            this.Filter_Item = new DevExpress.XtraEditors.CheckButton();
            this.Filter_AccountID = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.AccountID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountExcludingTax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountIncludingTax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryChallanNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GatePassNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PackingListNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountTax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellingUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GSTRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefInv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefDebiteNoteNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Appearance.Options.UseTextOptions = true;
            this.labelControl14.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl14.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl14.Location = new System.Drawing.Point(2, 3);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(39, 13);
            this.labelControl14.TabIndex = 223;
            this.labelControl14.Text = "Account";
            // 
            // AccountID
            // 
            this.AccountID.EditValue = "";
            this.AccountID.EnterMoveNextControl = true;
            this.AccountID.Location = new System.Drawing.Point(49, 3);
            this.AccountID.Name = "AccountID";
            this.AccountID.Properties.MaxLength = 13;
            this.AccountID.Size = new System.Drawing.Size(105, 20);
            this.AccountID.TabIndex = 0;
            this.AccountID.TextChanged += new System.EventHandler(this.AccountID_TextChanged);
            this.AccountID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountID_KeyDown);
            // 
            // AccountName
            // 
            this.AccountName.EnterMoveNextControl = true;
            this.AccountName.Location = new System.Drawing.Point(156, 3);
            this.AccountName.Name = "AccountName";
            this.AccountName.Size = new System.Drawing.Size(334, 20);
            this.AccountName.TabIndex = 222;
            this.AccountName.TabStop = false;
            this.AccountName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountName_KeyDown);
            // 
            // Item
            // 
            this.Item.EnterMoveNextControl = true;
            this.Item.Location = new System.Drawing.Point(156, 25);
            this.Item.Name = "Item";
            this.Item.Size = new System.Drawing.Size(273, 20);
            this.Item.TabIndex = 225;
            this.Item.TabStop = false;
            this.Item.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Item_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.Location = new System.Drawing.Point(19, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 226;
            this.labelControl1.Text = "Item";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.Location = new System.Drawing.Point(76, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 229;
            this.labelControl2.Text = "Rate";
            // 
            // Rate
            // 
            this.Rate.EditValue = "";
            this.Rate.EnterMoveNextControl = true;
            this.Rate.Location = new System.Drawing.Point(105, 50);
            this.Rate.Name = "Rate";
            this.Rate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rate.Properties.Appearance.Options.UseFont = true;
            this.Rate.Properties.Appearance.Options.UseTextOptions = true;
            this.Rate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Rate.Properties.Mask.EditMask = "n6";
            this.Rate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Rate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Rate.Size = new System.Drawing.Size(80, 22);
            this.Rate.TabIndex = 3;
            this.Rate.EditValueChanged += new System.EventHandler(this.Rate_EditValueChanged);
            this.Rate.TextChanged += new System.EventHandler(this.Rate_TextChanged);
            this.Rate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Rate_KeyDown);
            this.Rate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Rate_KeyUp);
            // 
            // AmountExcludingTax
            // 
            this.AmountExcludingTax.EditValue = "";
            this.AmountExcludingTax.EnterMoveNextControl = true;
            this.AmountExcludingTax.Location = new System.Drawing.Point(383, 50);
            this.AmountExcludingTax.Name = "AmountExcludingTax";
            this.AmountExcludingTax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountExcludingTax.Properties.Appearance.Options.UseFont = true;
            this.AmountExcludingTax.Properties.Appearance.Options.UseTextOptions = true;
            this.AmountExcludingTax.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AmountExcludingTax.Properties.Mask.EditMask = "n0";
            this.AmountExcludingTax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.AmountExcludingTax.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.AmountExcludingTax.Properties.MaxLength = 13;
            this.AmountExcludingTax.Properties.ReadOnly = true;
            this.AmountExcludingTax.Size = new System.Drawing.Size(129, 22);
            this.AmountExcludingTax.TabIndex = 230;
            this.AmountExcludingTax.TabStop = false;
            this.AmountExcludingTax.Tag = "0";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl4.Location = new System.Drawing.Point(191, 53);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(18, 13);
            this.labelControl4.TabIndex = 233;
            this.labelControl4.Text = "Qty";
            // 
            // AmountIncludingTax
            // 
            this.AmountIncludingTax.EditValue = "";
            this.AmountIncludingTax.EnterMoveNextControl = true;
            this.AmountIncludingTax.Location = new System.Drawing.Point(383, 75);
            this.AmountIncludingTax.Name = "AmountIncludingTax";
            this.AmountIncludingTax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountIncludingTax.Properties.Appearance.Options.UseFont = true;
            this.AmountIncludingTax.Properties.Appearance.Options.UseTextOptions = true;
            this.AmountIncludingTax.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AmountIncludingTax.Properties.Mask.EditMask = "n0";
            this.AmountIncludingTax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.AmountIncludingTax.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.AmountIncludingTax.Properties.MaxLength = 13;
            this.AmountIncludingTax.Properties.ReadOnly = true;
            this.AmountIncludingTax.Size = new System.Drawing.Size(129, 22);
            this.AmountIncludingTax.TabIndex = 232;
            this.AmountIncludingTax.TabStop = false;
            this.AmountIncludingTax.Tag = "0";
            // 
            // DeliveryChallanNumber
            // 
            this.DeliveryChallanNumber.EnterMoveNextControl = true;
            this.DeliveryChallanNumber.Location = new System.Drawing.Point(705, 3);
            this.DeliveryChallanNumber.Name = "DeliveryChallanNumber";
            this.DeliveryChallanNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeliveryChallanNumber.Properties.Appearance.Options.UseFont = true;
            this.DeliveryChallanNumber.Properties.NullValuePrompt = "Delivery Challan";
            this.DeliveryChallanNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.DeliveryChallanNumber.Size = new System.Drawing.Size(122, 20);
            this.DeliveryChallanNumber.TabIndex = 9;
            this.DeliveryChallanNumber.TabStop = false;
            // 
            // GatePassNumber
            // 
            this.GatePassNumber.EnterMoveNextControl = true;
            this.GatePassNumber.Location = new System.Drawing.Point(543, 26);
            this.GatePassNumber.Name = "GatePassNumber";
            this.GatePassNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GatePassNumber.Properties.Appearance.Options.UseFont = true;
            this.GatePassNumber.Properties.NullValuePrompt = "Gate Pass";
            this.GatePassNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.GatePassNumber.Size = new System.Drawing.Size(128, 20);
            this.GatePassNumber.TabIndex = 7;
            this.GatePassNumber.TabStop = false;
            // 
            // PackingListNumber
            // 
            this.PackingListNumber.EnterMoveNextControl = true;
            this.PackingListNumber.Location = new System.Drawing.Point(543, 3);
            this.PackingListNumber.Name = "PackingListNumber";
            this.PackingListNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PackingListNumber.Properties.Appearance.Options.UseFont = true;
            this.PackingListNumber.Properties.NullValuePrompt = "Packing List";
            this.PackingListNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.PackingListNumber.Size = new System.Drawing.Size(128, 20);
            this.PackingListNumber.TabIndex = 6;
            this.PackingListNumber.TabStop = false;
            // 
            // ItemID
            // 
            this.ItemID.EditValue = "";
            this.ItemID.EnterMoveNextControl = true;
            this.ItemID.Location = new System.Drawing.Point(49, 25);
            this.ItemID.Name = "ItemID";
            this.ItemID.Properties.ReadOnly = true;
            this.ItemID.Size = new System.Drawing.Size(105, 20);
            this.ItemID.TabIndex = 1;
            this.ItemID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemID_KeyDown);
            // 
            // Quantity
            // 
            this.Quantity.EditValue = "";
            this.Quantity.EnterMoveNextControl = true;
            this.Quantity.Location = new System.Drawing.Point(215, 49);
            this.Quantity.Name = "Quantity";
            this.Quantity.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.Properties.Appearance.Options.UseFont = true;
            this.Quantity.Properties.Appearance.Options.UseTextOptions = true;
            this.Quantity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Quantity.Properties.Mask.EditMask = "n2";
            this.Quantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Quantity.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Quantity.Size = new System.Drawing.Size(81, 22);
            this.Quantity.TabIndex = 4;
            this.Quantity.EditValueChanged += new System.EventHandler(this.Quantity_EditValueChanged);
            this.Quantity.TextChanged += new System.EventHandler(this.Quantity_TextChanged);
            this.Quantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Rate_KeyDown);
            this.Quantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Quantity_KeyUp);
            // 
            // AmountTax
            // 
            this.AmountTax.EditValue = "";
            this.AmountTax.EnterMoveNextControl = true;
            this.AmountTax.Location = new System.Drawing.Point(215, 75);
            this.AmountTax.Name = "AmountTax";
            this.AmountTax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountTax.Properties.Appearance.Options.UseFont = true;
            this.AmountTax.Properties.Appearance.Options.UseTextOptions = true;
            this.AmountTax.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AmountTax.Properties.Mask.EditMask = "n0";
            this.AmountTax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.AmountTax.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.AmountTax.Properties.MaxLength = 13;
            this.AmountTax.Properties.ReadOnly = true;
            this.AmountTax.Size = new System.Drawing.Size(81, 22);
            this.AmountTax.TabIndex = 252;
            this.AmountTax.TabStop = false;
            this.AmountTax.Tag = "0";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl3.Location = new System.Drawing.Point(302, 55);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 13);
            this.labelControl3.TabIndex = 253;
            this.labelControl3.Text = "Value Ex. Tax";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl5.Location = new System.Drawing.Point(76, 78);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(32, 13);
            this.labelControl5.TabIndex = 254;
            this.labelControl5.Text = "Tax @";
            // 
            // SellingUnit
            // 
            this.SellingUnit.Location = new System.Drawing.Point(432, 25);
            this.SellingUnit.Name = "SellingUnit";
            this.SellingUnit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellingUnit.Properties.Appearance.Options.UseFont = true;
            this.SellingUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SellingUnit.Properties.NullText = "";
            this.SellingUnit.Properties.NullValuePrompt = "Unit";
            this.SellingUnit.Properties.NullValuePromptShowForEmptyValue = true;
            this.SellingUnit.Size = new System.Drawing.Size(58, 20);
            this.SellingUnit.TabIndex = 2;
            this.SellingUnit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SellingUnit_KeyUp);
            // 
            // GSTRate
            // 
            this.GSTRate.EditValue = "";
            this.GSTRate.EnterMoveNextControl = true;
            this.GSTRate.Location = new System.Drawing.Point(114, 75);
            this.GSTRate.Name = "GSTRate";
            this.GSTRate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GSTRate.Properties.Appearance.Options.UseFont = true;
            this.GSTRate.Properties.Appearance.Options.UseTextOptions = true;
            this.GSTRate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.GSTRate.Properties.Mask.EditMask = "n2";
            this.GSTRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.GSTRate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.GSTRate.Properties.MaxLength = 13;
            this.GSTRate.Size = new System.Drawing.Size(71, 22);
            this.GSTRate.TabIndex = 5;
            this.GSTRate.TabStop = false;
            this.GSTRate.Tag = "0";
            this.GSTRate.EditValueChanged += new System.EventHandler(this.GSTRate_EditValueChanged);
            this.GSTRate.TextChanged += new System.EventHandler(this.GSTRate_TextChanged);
            this.GSTRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Rate_KeyDown);
            // 
            // RefInv
            // 
            this.RefInv.EnterMoveNextControl = true;
            this.RefInv.Location = new System.Drawing.Point(705, 26);
            this.RefInv.Name = "RefInv";
            this.RefInv.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefInv.Properties.Appearance.Options.UseFont = true;
            this.RefInv.Properties.NullValuePrompt = "Referenced Invoice";
            this.RefInv.Properties.NullValuePromptShowForEmptyValue = true;
            this.RefInv.Properties.ReadOnly = true;
            this.RefInv.Size = new System.Drawing.Size(122, 20);
            this.RefInv.TabIndex = 10;
            this.RefInv.TabStop = false;
            this.RefInv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RefInv_KeyDown);
            // 
            // ContractNumber
            // 
            this.ContractNumber.EnterMoveNextControl = true;
            this.ContractNumber.Location = new System.Drawing.Point(543, 48);
            this.ContractNumber.Name = "ContractNumber";
            this.ContractNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContractNumber.Properties.Appearance.Options.UseFont = true;
            this.ContractNumber.Properties.NullValuePrompt = "Ref Contract";
            this.ContractNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.ContractNumber.Properties.ReadOnly = true;
            this.ContractNumber.Size = new System.Drawing.Size(128, 20);
            this.ContractNumber.TabIndex = 8;
            this.ContractNumber.TabStop = false;
            this.ContractNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContractNumber_KeyDown);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Appearance.Options.UseTextOptions = true;
            this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl9.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl9.Location = new System.Drawing.Point(302, 75);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Padding = new System.Windows.Forms.Padding(2);
            this.labelControl9.Size = new System.Drawing.Size(75, 20);
            this.labelControl9.TabIndex = 264;
            this.labelControl9.Text = "Value Inc.Tax";
            // 
            // RefDebiteNoteNumber
            // 
            this.RefDebiteNoteNumber.EnterMoveNextControl = true;
            this.RefDebiteNoteNumber.Location = new System.Drawing.Point(705, 48);
            this.RefDebiteNoteNumber.Name = "RefDebiteNoteNumber";
            this.RefDebiteNoteNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefDebiteNoteNumber.Properties.Appearance.Options.UseFont = true;
            this.RefDebiteNoteNumber.Properties.NullValuePrompt = "Debit Note #";
            this.RefDebiteNoteNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.RefDebiteNoteNumber.Size = new System.Drawing.Size(122, 20);
            this.RefDebiteNoteNumber.TabIndex = 11;
            this.RefDebiteNoteNumber.TabStop = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseTextOptions = true;
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl6.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(518, 3);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(21, 20);
            this.labelControl6.TabIndex = 265;
            this.labelControl6.Text = "P/L";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseTextOptions = true;
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl7.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Location = new System.Drawing.Point(677, 3);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(24, 20);
            this.labelControl7.TabIndex = 266;
            this.labelControl7.Text = "D/C";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseTextOptions = true;
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl8.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.Location = new System.Drawing.Point(518, 25);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(22, 20);
            this.labelControl8.TabIndex = 267;
            this.labelControl8.Text = "G/P";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Appearance.Options.UseTextOptions = true;
            this.labelControl10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl10.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl10.Location = new System.Drawing.Point(677, 26);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(24, 20);
            this.labelControl10.TabIndex = 268;
            this.labelControl10.Text = "INV";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Appearance.Options.UseTextOptions = true;
            this.labelControl11.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl11.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl11.Location = new System.Drawing.Point(514, 52);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(23, 20);
            this.labelControl11.TabIndex = 269;
            this.labelControl11.Text = "W/O";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Appearance.Options.UseTextOptions = true;
            this.labelControl12.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl12.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl12.Location = new System.Drawing.Point(677, 52);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(24, 20);
            this.labelControl12.TabIndex = 270;
            this.labelControl12.Text = "D/N";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Appearance.Options.UseTextOptions = true;
            this.labelControl13.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl13.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl13.Location = new System.Drawing.Point(191, 80);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(18, 13);
            this.labelControl13.TabIndex = 271;
            this.labelControl13.Text = "Tax";
            // 
            // checkTax
            // 
            this.checkTax.Location = new System.Drawing.Point(3, 75);
            this.checkTax.Name = "checkTax";
            this.checkTax.Size = new System.Drawing.Size(67, 20);
            this.checkTax.TabIndex = 376;
            this.checkTax.Text = "@Tax Rate";
            this.checkTax.CheckedChanged += new System.EventHandler(this.checkTax_CheckedChanged);
            // 
            // checkRateQty
            // 
            this.checkRateQty.Location = new System.Drawing.Point(3, 50);
            this.checkRateQty.Name = "checkRateQty";
            this.checkRateQty.Size = new System.Drawing.Size(67, 20);
            this.checkRateQty.TabIndex = 375;
            this.checkRateQty.Text = "= Rate*Qty";
            this.checkRateQty.CheckedChanged += new System.EventHandler(this.checkRateQty_CheckedChanged);
            // 
            // Filter_Item
            // 
            this.Filter_Item.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_Item.Appearance.Options.UseFont = true;
            this.Filter_Item.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_Item.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_Item.Location = new System.Drawing.Point(492, 26);
            this.Filter_Item.Name = "Filter_Item";
            this.Filter_Item.Size = new System.Drawing.Size(20, 20);
            this.Filter_Item.TabIndex = 227;
            this.Filter_Item.TabStop = false;
            // 
            // Filter_AccountID
            // 
            this.Filter_AccountID.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_AccountID.Appearance.Options.UseFont = true;
            this.Filter_AccountID.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_AccountID.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_AccountID.Location = new System.Drawing.Point(492, 3);
            this.Filter_AccountID.Name = "Filter_AccountID";
            this.Filter_AccountID.Size = new System.Drawing.Size(20, 20);
            this.Filter_AccountID.TabIndex = 224;
            this.Filter_AccountID.TabStop = false;
            // 
            // Account_SalesInvoice_FabricSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkTax);
            this.Controls.Add(this.checkRateQty);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.RefDebiteNoteNumber);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.ContractNumber);
            this.Controls.Add(this.RefInv);
            this.Controls.Add(this.GSTRate);
            this.Controls.Add(this.SellingUnit);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.AmountTax);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.ItemID);
            this.Controls.Add(this.DeliveryChallanNumber);
            this.Controls.Add(this.GatePassNumber);
            this.Controls.Add(this.PackingListNumber);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.AmountIncludingTax);
            this.Controls.Add(this.AmountExcludingTax);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.Rate);
            this.Controls.Add(this.Filter_Item);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Item);
            this.Controls.Add(this.Filter_AccountID);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.AccountID);
            this.Controls.Add(this.AccountName);
            this.Name = "Account_SalesInvoice_FabricSales";
            this.Size = new System.Drawing.Size(831, 101);
            ((System.ComponentModel.ISupportInitialize)(this.AccountID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountExcludingTax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountIncludingTax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryChallanNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GatePassNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PackingListNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountTax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellingUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GSTRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefInv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefDebiteNoteNumber.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.CheckButton Filter_AccountID;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        public DevExpress.XtraEditors.TextEdit AccountID;
        public DevExpress.XtraEditors.TextEdit AccountName;
        public DevExpress.XtraEditors.TextEdit Item;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.CheckButton Filter_Item;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit Rate;
        public DevExpress.XtraEditors.TextEdit AmountExcludingTax;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit AmountIncludingTax;
        public DevExpress.XtraEditors.TextEdit DeliveryChallanNumber;
        public DevExpress.XtraEditors.TextEdit GatePassNumber;
        public DevExpress.XtraEditors.TextEdit PackingListNumber;
        public DevExpress.XtraEditors.TextEdit ItemID;
        public DevExpress.XtraEditors.TextEdit Quantity;
        public DevExpress.XtraEditors.TextEdit AmountTax;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LookUpEdit SellingUnit;
        public DevExpress.XtraEditors.TextEdit GSTRate;
        public DevExpress.XtraEditors.TextEdit RefInv;
        public DevExpress.XtraEditors.TextEdit ContractNumber;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        public DevExpress.XtraEditors.TextEdit RefDebiteNoteNumber;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        public DevExpress.XtraEditors.CheckButton checkTax;
        public DevExpress.XtraEditors.CheckButton checkRateQty;
    }
}
