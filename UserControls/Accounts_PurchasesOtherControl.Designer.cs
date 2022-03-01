namespace MachineEyes.UserControls
{
    partial class Accounts_PurchasesOtherControl
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
            this.Item = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.RefDebiteNoteNumber = new DevExpress.XtraEditors.TextEdit();
            this.ContractNumber = new DevExpress.XtraEditors.TextEdit();
            this.RefInv = new DevExpress.XtraEditors.TextEdit();
            this.GSTRate = new DevExpress.XtraEditors.TextEdit();
            this.SellingUnit = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.AmountTax = new DevExpress.XtraEditors.TextEdit();
            this.Quantity = new DevExpress.XtraEditors.TextEdit();
            this.DeliveryChallanNumber = new DevExpress.XtraEditors.TextEdit();
            this.GatePassNumber = new DevExpress.XtraEditors.TextEdit();
            this.PackingListNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.AmountIncludingTax = new DevExpress.XtraEditors.TextEdit();
            this.AmountExcludingTax = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Rate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.AccountID = new DevExpress.XtraEditors.TextEdit();
            this.AccountName = new DevExpress.XtraEditors.TextEdit();
            this.checkRateQty = new DevExpress.XtraEditors.CheckButton();
            this.checkTax = new DevExpress.XtraEditors.CheckButton();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.Filter_Item = new DevExpress.XtraEditors.CheckButton();
            this.Filter_AccountID = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.Item.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefDebiteNoteNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefInv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GSTRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellingUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountTax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryChallanNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GatePassNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PackingListNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountIncludingTax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountExcludingTax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Item
            // 
            this.Item.EnterMoveNextControl = true;
            this.Item.Location = new System.Drawing.Point(48, 26);
            this.Item.Name = "Item";
            this.Item.Properties.MaxLength = 200;
            this.Item.Size = new System.Drawing.Size(367, 20);
            this.Item.TabIndex = 1;
            this.Item.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Item_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.Location = new System.Drawing.Point(17, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 370;
            this.labelControl1.Text = "Item";
            // 
            // RefDebiteNoteNumber
            // 
            this.RefDebiteNoteNumber.EnterMoveNextControl = true;
            this.RefDebiteNoteNumber.Location = new System.Drawing.Point(676, 50);
            this.RefDebiteNoteNumber.Name = "RefDebiteNoteNumber";
            this.RefDebiteNoteNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefDebiteNoteNumber.Properties.Appearance.Options.UseFont = true;
            this.RefDebiteNoteNumber.Properties.NullValuePrompt = "Delivery Note #";
            this.RefDebiteNoteNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.RefDebiteNoteNumber.Size = new System.Drawing.Size(150, 20);
            this.RefDebiteNoteNumber.TabIndex = 368;
            // 
            // ContractNumber
            // 
            this.ContractNumber.EnterMoveNextControl = true;
            this.ContractNumber.Location = new System.Drawing.Point(517, 50);
            this.ContractNumber.Name = "ContractNumber";
            this.ContractNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContractNumber.Properties.Appearance.Options.UseFont = true;
            this.ContractNumber.Properties.NullValuePrompt = "Ref Contract";
            this.ContractNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.ContractNumber.Size = new System.Drawing.Size(153, 20);
            this.ContractNumber.TabIndex = 365;
            // 
            // RefInv
            // 
            this.RefInv.EnterMoveNextControl = true;
            this.RefInv.Location = new System.Drawing.Point(676, 26);
            this.RefInv.Name = "RefInv";
            this.RefInv.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefInv.Properties.Appearance.Options.UseFont = true;
            this.RefInv.Properties.NullValuePrompt = "Referenced Invoice";
            this.RefInv.Properties.NullValuePromptShowForEmptyValue = true;
            this.RefInv.Properties.ReadOnly = true;
            this.RefInv.Size = new System.Drawing.Size(150, 20);
            this.RefInv.TabIndex = 363;
            this.RefInv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RefInv_KeyDown);
            // 
            // GSTRate
            // 
            this.GSTRate.EditValue = "";
            this.GSTRate.EnterMoveNextControl = true;
            this.GSTRate.Location = new System.Drawing.Point(104, 75);
            this.GSTRate.Name = "GSTRate";
            this.GSTRate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GSTRate.Properties.Appearance.Options.UseFont = true;
            this.GSTRate.Properties.Appearance.Options.UseTextOptions = true;
            this.GSTRate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.GSTRate.Properties.Mask.EditMask = "n2";
            this.GSTRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.GSTRate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.GSTRate.Properties.MaxLength = 13;
            this.GSTRate.Size = new System.Drawing.Size(49, 22);
            this.GSTRate.TabIndex = 5;
            this.GSTRate.Tag = "0";
            this.GSTRate.TextChanged += new System.EventHandler(this.GSTRate_TextChanged);
            this.GSTRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GSTRate_KeyUp);
            // 
            // SellingUnit
            // 
            this.SellingUnit.Location = new System.Drawing.Point(421, 26);
            this.SellingUnit.Name = "SellingUnit";
            this.SellingUnit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellingUnit.Properties.Appearance.Options.UseFont = true;
            this.SellingUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SellingUnit.Properties.NullText = "";
            this.SellingUnit.Properties.NullValuePrompt = "Unit";
            this.SellingUnit.Properties.NullValuePromptShowForEmptyValue = true;
            this.SellingUnit.Size = new System.Drawing.Size(68, 20);
            this.SellingUnit.TabIndex = 2;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl5.Location = new System.Drawing.Point(75, 78);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(18, 13);
            this.labelControl5.TabIndex = 360;
            this.labelControl5.Text = "Tax";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl3.Location = new System.Drawing.Point(300, 57);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 13);
            this.labelControl3.TabIndex = 359;
            this.labelControl3.Text = "Value Ex. Tax";
            // 
            // AmountTax
            // 
            this.AmountTax.EditValue = "";
            this.AmountTax.EnterMoveNextControl = true;
            this.AmountTax.Location = new System.Drawing.Point(155, 75);
            this.AmountTax.Name = "AmountTax";
            this.AmountTax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountTax.Properties.Appearance.Options.UseFont = true;
            this.AmountTax.Properties.Appearance.Options.UseTextOptions = true;
            this.AmountTax.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AmountTax.Properties.Mask.EditMask = "n0";
            this.AmountTax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.AmountTax.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.AmountTax.Size = new System.Drawing.Size(82, 22);
            this.AmountTax.TabIndex = 6;
            this.AmountTax.TabStop = false;
            this.AmountTax.Tag = "0";
            this.AmountTax.EditValueChanged += new System.EventHandler(this.AmountTax_EditValueChanged);
            this.AmountTax.TextChanged += new System.EventHandler(this.AmountTax_TextChanged);
            this.AmountTax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AmountTax_KeyDown);
            // 
            // Quantity
            // 
            this.Quantity.EditValue = "";
            this.Quantity.EnterMoveNextControl = true;
            this.Quantity.Location = new System.Drawing.Point(227, 50);
            this.Quantity.Name = "Quantity";
            this.Quantity.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.Properties.Appearance.Options.UseFont = true;
            this.Quantity.Properties.Appearance.Options.UseTextOptions = true;
            this.Quantity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Quantity.Properties.Mask.EditMask = "n2";
            this.Quantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Quantity.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Quantity.Size = new System.Drawing.Size(67, 22);
            this.Quantity.TabIndex = 4;
            this.Quantity.TextChanged += new System.EventHandler(this.Quantity_TextChanged);
            this.Quantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Quantity_KeyUp);
            // 
            // DeliveryChallanNumber
            // 
            this.DeliveryChallanNumber.EnterMoveNextControl = true;
            this.DeliveryChallanNumber.Location = new System.Drawing.Point(676, 3);
            this.DeliveryChallanNumber.Name = "DeliveryChallanNumber";
            this.DeliveryChallanNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeliveryChallanNumber.Properties.Appearance.Options.UseFont = true;
            this.DeliveryChallanNumber.Properties.NullValuePrompt = "Delivery Challan";
            this.DeliveryChallanNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.DeliveryChallanNumber.Size = new System.Drawing.Size(150, 20);
            this.DeliveryChallanNumber.TabIndex = 344;
            // 
            // GatePassNumber
            // 
            this.GatePassNumber.EnterMoveNextControl = true;
            this.GatePassNumber.Location = new System.Drawing.Point(517, 26);
            this.GatePassNumber.Name = "GatePassNumber";
            this.GatePassNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GatePassNumber.Properties.Appearance.Options.UseFont = true;
            this.GatePassNumber.Properties.NullValuePrompt = "Gate Pass";
            this.GatePassNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.GatePassNumber.Size = new System.Drawing.Size(153, 20);
            this.GatePassNumber.TabIndex = 345;
            // 
            // PackingListNumber
            // 
            this.PackingListNumber.EnterMoveNextControl = true;
            this.PackingListNumber.Location = new System.Drawing.Point(517, 3);
            this.PackingListNumber.Name = "PackingListNumber";
            this.PackingListNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PackingListNumber.Properties.Appearance.Options.UseFont = true;
            this.PackingListNumber.Properties.NullValuePrompt = "Packing List";
            this.PackingListNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.PackingListNumber.Size = new System.Drawing.Size(153, 20);
            this.PackingListNumber.TabIndex = 343;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl4.Location = new System.Drawing.Point(203, 56);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(18, 13);
            this.labelControl4.TabIndex = 353;
            this.labelControl4.Text = "Qty";
            // 
            // AmountIncludingTax
            // 
            this.AmountIncludingTax.EditValue = "";
            this.AmountIncludingTax.Enabled = false;
            this.AmountIncludingTax.EnterMoveNextControl = true;
            this.AmountIncludingTax.Location = new System.Drawing.Point(372, 75);
            this.AmountIncludingTax.Name = "AmountIncludingTax";
            this.AmountIncludingTax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountIncludingTax.Properties.Appearance.Options.UseFont = true;
            this.AmountIncludingTax.Properties.Appearance.Options.UseTextOptions = true;
            this.AmountIncludingTax.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AmountIncludingTax.Properties.Mask.EditMask = "n0";
            this.AmountIncludingTax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.AmountIncludingTax.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.AmountIncludingTax.Size = new System.Drawing.Size(117, 22);
            this.AmountIncludingTax.TabIndex = 352;
            this.AmountIncludingTax.TabStop = false;
            this.AmountIncludingTax.Tag = "0";
            this.AmountIncludingTax.EditValueChanged += new System.EventHandler(this.AmountIncludingTax_EditValueChanged);
            this.AmountIncludingTax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AmountIncludingTax_KeyDown);
            // 
            // AmountExcludingTax
            // 
            this.AmountExcludingTax.EditValue = "";
            this.AmountExcludingTax.Enabled = false;
            this.AmountExcludingTax.EnterMoveNextControl = true;
            this.AmountExcludingTax.Location = new System.Drawing.Point(372, 51);
            this.AmountExcludingTax.Name = "AmountExcludingTax";
            this.AmountExcludingTax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountExcludingTax.Properties.Appearance.Options.UseFont = true;
            this.AmountExcludingTax.Properties.Appearance.Options.UseTextOptions = true;
            this.AmountExcludingTax.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AmountExcludingTax.Properties.Mask.EditMask = "n0";
            this.AmountExcludingTax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.AmountExcludingTax.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.AmountExcludingTax.Properties.EditValueChanged += new System.EventHandler(this.AmountExcludingTax_Properties_EditValueChanged);
            this.AmountExcludingTax.Size = new System.Drawing.Size(117, 22);
            this.AmountExcludingTax.TabIndex = 351;
            this.AmountExcludingTax.TabStop = false;
            this.AmountExcludingTax.Tag = "0";
            this.AmountExcludingTax.TextChanged += new System.EventHandler(this.AmountExcludingTax_TextChanged);
            this.AmountExcludingTax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AmountExcludingTax_KeyDown);
            this.AmountExcludingTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AmountExcludingTax_KeyUp);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.Location = new System.Drawing.Point(75, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 350;
            this.labelControl2.Text = "Rate";
            // 
            // Rate
            // 
            this.Rate.EditValue = "";
            this.Rate.EnterMoveNextControl = true;
            this.Rate.Location = new System.Drawing.Point(104, 50);
            this.Rate.Name = "Rate";
            this.Rate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rate.Properties.Appearance.Options.UseFont = true;
            this.Rate.Properties.Appearance.Options.UseTextOptions = true;
            this.Rate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Rate.Properties.Mask.EditMask = "n6";
            this.Rate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Rate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Rate.Size = new System.Drawing.Size(93, 22);
            this.Rate.TabIndex = 3;
            this.Rate.TextChanged += new System.EventHandler(this.Rate_TextChanged);
            this.Rate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Rate_KeyUp);
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Appearance.Options.UseTextOptions = true;
            this.labelControl14.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl14.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl14.Location = new System.Drawing.Point(1, 3);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(39, 13);
            this.labelControl14.TabIndex = 347;
            this.labelControl14.Text = "Account";
            // 
            // AccountID
            // 
            this.AccountID.EditValue = "";
            this.AccountID.EnterMoveNextControl = true;
            this.AccountID.Location = new System.Drawing.Point(48, 3);
            this.AccountID.Name = "AccountID";
            this.AccountID.Properties.MaxLength = 13;
            this.AccountID.Size = new System.Drawing.Size(105, 20);
            this.AccountID.TabIndex = 0;
            this.AccountID.EditValueChanged += new System.EventHandler(this.AccountID_EditValueChanged);
            this.AccountID.TextChanged += new System.EventHandler(this.AccountID_TextChanged);
            this.AccountID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountID_KeyDown);
            // 
            // AccountName
            // 
            this.AccountName.EnterMoveNextControl = true;
            this.AccountName.Location = new System.Drawing.Point(155, 3);
            this.AccountName.Name = "AccountName";
            this.AccountName.Size = new System.Drawing.Size(334, 20);
            this.AccountName.TabIndex = 346;
            this.AccountName.TabStop = false;
            this.AccountName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountName_KeyDown);
            // 
            // checkRateQty
            // 
            this.checkRateQty.Location = new System.Drawing.Point(3, 50);
            this.checkRateQty.Name = "checkRateQty";
            this.checkRateQty.Size = new System.Drawing.Size(67, 20);
            this.checkRateQty.TabIndex = 373;
            this.checkRateQty.Text = "= Rate*Qty";
            this.checkRateQty.CheckedChanged += new System.EventHandler(this.checkRateQty_CheckedChanged);
            // 
            // checkTax
            // 
            this.checkTax.Location = new System.Drawing.Point(3, 74);
            this.checkTax.Name = "checkTax";
            this.checkTax.Size = new System.Drawing.Size(67, 20);
            this.checkTax.TabIndex = 374;
            this.checkTax.Text = "@Tax Rate";
            this.checkTax.CheckedChanged += new System.EventHandler(this.checkTax_CheckedChanged);
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Appearance.Options.UseTextOptions = true;
            this.labelControl13.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl13.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl13.Location = new System.Drawing.Point(300, 81);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(69, 13);
            this.labelControl13.TabIndex = 375;
            this.labelControl13.Text = "Value Inc. Tax";
            // 
            // Filter_Item
            // 
            this.Filter_Item.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_Item.Appearance.Options.UseFont = true;
            this.Filter_Item.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_Item.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_Item.Location = new System.Drawing.Point(491, 26);
            this.Filter_Item.Name = "Filter_Item";
            this.Filter_Item.Size = new System.Drawing.Size(20, 20);
            this.Filter_Item.TabIndex = 349;
            this.Filter_Item.TabStop = false;
            // 
            // Filter_AccountID
            // 
            this.Filter_AccountID.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_AccountID.Appearance.Options.UseFont = true;
            this.Filter_AccountID.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_AccountID.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_AccountID.Location = new System.Drawing.Point(491, 3);
            this.Filter_AccountID.Name = "Filter_AccountID";
            this.Filter_AccountID.Size = new System.Drawing.Size(20, 20);
            this.Filter_AccountID.TabIndex = 348;
            this.Filter_AccountID.TabStop = false;
            // 
            // Accounts_PurchasesOtherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.checkTax);
            this.Controls.Add(this.checkRateQty);
            this.Controls.Add(this.Item);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.RefDebiteNoteNumber);
            this.Controls.Add(this.ContractNumber);
            this.Controls.Add(this.RefInv);
            this.Controls.Add(this.GSTRate);
            this.Controls.Add(this.SellingUnit);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.AmountTax);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.DeliveryChallanNumber);
            this.Controls.Add(this.GatePassNumber);
            this.Controls.Add(this.PackingListNumber);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.AmountIncludingTax);
            this.Controls.Add(this.AmountExcludingTax);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.Rate);
            this.Controls.Add(this.Filter_Item);
            this.Controls.Add(this.Filter_AccountID);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.AccountID);
            this.Controls.Add(this.AccountName);
            this.Name = "Accounts_PurchasesOtherControl";
            this.Size = new System.Drawing.Size(834, 97);
            ((System.ComponentModel.ISupportInitialize)(this.Item.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefDebiteNoteNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefInv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GSTRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellingUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountTax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryChallanNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GatePassNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PackingListNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountIncludingTax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountExcludingTax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit Item;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit RefDebiteNoteNumber;
        public DevExpress.XtraEditors.TextEdit ContractNumber;
        public DevExpress.XtraEditors.TextEdit RefInv;
        public DevExpress.XtraEditors.TextEdit GSTRate;
        public DevExpress.XtraEditors.LookUpEdit SellingUnit;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit AmountTax;
        public DevExpress.XtraEditors.TextEdit Quantity;
        public DevExpress.XtraEditors.TextEdit DeliveryChallanNumber;
        public DevExpress.XtraEditors.TextEdit GatePassNumber;
        public DevExpress.XtraEditors.TextEdit PackingListNumber;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit AmountIncludingTax;
        public DevExpress.XtraEditors.TextEdit AmountExcludingTax;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit Rate;
        public DevExpress.XtraEditors.CheckButton Filter_Item;
        public DevExpress.XtraEditors.CheckButton Filter_AccountID;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        public DevExpress.XtraEditors.TextEdit AccountID;
        public DevExpress.XtraEditors.TextEdit AccountName;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        public DevExpress.XtraEditors.CheckButton checkRateQty;
        public DevExpress.XtraEditors.CheckButton checkTax;
    }
}
