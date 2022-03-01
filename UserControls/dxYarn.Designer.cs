namespace MachineEyes.UserControls
{
    partial class dxYarn
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
            this.Brand = new DevExpress.XtraEditors.LookUpEdit();
            this.Desc = new DevExpress.XtraEditors.LookUpEdit();
            this.Blends = new DevExpress.XtraEditors.LookUpEdit();
            this.Ply = new DevExpress.XtraEditors.LookUpEdit();
            this.Counts = new DevExpress.XtraEditors.LookUpEdit();
            this.Bags = new DevExpress.XtraEditors.TextEdit();
            this.BagsType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Lbs = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.Cones = new DevExpress.XtraEditors.TextEdit();
            this.LbsPerBag = new DevExpress.XtraEditors.LookUpEdit();
            this.ConesPerBag = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.LabelAvlLbs = new DevExpress.XtraEditors.LabelControl();
            this.AvlLbs = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.AvlBags = new DevExpress.XtraEditors.TextEdit();
            this.AutoManual = new DevExpress.XtraEditors.CheckButton();
            this.Color = new DevExpress.XtraEditors.LookUpEdit();
            this.CheckStock = new DevExpress.XtraEditors.SimpleButton();
            this.Filter_Bags = new DevExpress.XtraEditors.CheckButton();
            this.Filter_Desc = new DevExpress.XtraEditors.CheckButton();
            this.Filter_Brand = new DevExpress.XtraEditors.CheckButton();
            this.Filter_Blend = new DevExpress.XtraEditors.CheckButton();
            this.Filter_Count = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.Brand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Desc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blends.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ply.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Counts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bags.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BagsType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lbs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cones.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LbsPerBag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConesPerBag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvlLbs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvlBags.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Color.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Brand
            // 
            this.Brand.EnterMoveNextControl = true;
            this.Brand.Location = new System.Drawing.Point(529, 2);
            this.Brand.Name = "Brand";
            this.Brand.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Brand.Properties.Appearance.Options.UseFont = true;
            this.Brand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Brand.Properties.NullText = "";
            this.Brand.Properties.NullValuePrompt = "Brand";
            this.Brand.Properties.NullValuePromptShowForEmptyValue = true;
            this.Brand.Size = new System.Drawing.Size(101, 20);
            this.Brand.TabIndex = 4;
            this.Brand.EditValueChanged += new System.EventHandler(this.BagsType_EditValueChanged);
            this.Brand.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.Brand_EditValueChanging);
            this.Brand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionKeyDown);
            // 
            // Desc
            // 
            this.Desc.EnterMoveNextControl = true;
            this.Desc.Location = new System.Drawing.Point(658, 2);
            this.Desc.Name = "Desc";
            this.Desc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Desc.Properties.Appearance.Options.UseFont = true;
            this.Desc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Desc.Properties.NullText = "";
            this.Desc.Properties.NullValuePrompt = "Description";
            this.Desc.Properties.NullValuePromptShowForEmptyValue = true;
            this.Desc.Size = new System.Drawing.Size(113, 20);
            this.Desc.TabIndex = 5;
            this.Desc.EditValueChanged += new System.EventHandler(this.BagsType_EditValueChanged);
            this.Desc.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.Desc_EditValueChanging);
            this.Desc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionKeyDown);
            // 
            // Blends
            // 
            this.Blends.EnterMoveNextControl = true;
            this.Blends.Location = new System.Drawing.Point(351, 2);
            this.Blends.Name = "Blends";
            this.Blends.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Blends.Properties.Appearance.Options.UseFont = true;
            this.Blends.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Blends.Properties.NullText = "";
            this.Blends.Properties.NullValuePrompt = "Blend";
            this.Blends.Properties.NullValuePromptShowForEmptyValue = true;
            this.Blends.Size = new System.Drawing.Size(102, 20);
            this.Blends.TabIndex = 3;
            this.Blends.EditValueChanged += new System.EventHandler(this.BagsType_EditValueChanged);
            this.Blends.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.Blends_EditValueChanging);
            this.Blends.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionKeyDown);
            // 
            // Ply
            // 
            this.Ply.EnterMoveNextControl = true;
            this.Ply.Location = new System.Drawing.Point(278, 2);
            this.Ply.Name = "Ply";
            this.Ply.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ply.Properties.Appearance.Options.UseFont = true;
            this.Ply.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Ply.Properties.NullText = "";
            this.Ply.Properties.NullValuePrompt = "Ply";
            this.Ply.Properties.NullValuePromptShowForEmptyValue = true;
            this.Ply.Size = new System.Drawing.Size(47, 20);
            this.Ply.TabIndex = 2;
            this.Ply.EditValueChanged += new System.EventHandler(this.BagsType_EditValueChanged);
            this.Ply.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.Ply_EditValueChanging);
            this.Ply.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionKeyDown);
            // 
            // Counts
            // 
            this.Counts.EnterMoveNextControl = true;
            this.Counts.Location = new System.Drawing.Point(204, 2);
            this.Counts.Name = "Counts";
            this.Counts.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Counts.Properties.Appearance.Options.UseFont = true;
            this.Counts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Counts.Properties.NullText = "";
            this.Counts.Properties.NullValuePrompt = "Count";
            this.Counts.Properties.NullValuePromptShowForEmptyValue = true;
            this.Counts.Size = new System.Drawing.Size(73, 20);
            this.Counts.TabIndex = 1;
            this.Counts.EditValueChanged += new System.EventHandler(this.BagsType_EditValueChanged);
            this.Counts.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.Counts_EditValueChanging);
            this.Counts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionKeyDown);
            // 
            // Bags
            // 
            this.Bags.EnterMoveNextControl = true;
            this.Bags.Location = new System.Drawing.Point(226, 26);
            this.Bags.Name = "Bags";
            this.Bags.Properties.Mask.EditMask = "n2";
            this.Bags.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Bags.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Bags.Properties.NullValuePrompt = "# of Bags";
            this.Bags.Properties.NullValuePromptShowForEmptyValue = true;
            this.Bags.Size = new System.Drawing.Size(77, 20);
            this.Bags.TabIndex = 8;
            this.Bags.EditValueChanged += new System.EventHandler(this.BagsType_EditValueChanged);
            this.Bags.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionKeyDown);
            // 
            // BagsType
            // 
            this.BagsType.EnterMoveNextControl = true;
            this.BagsType.Location = new System.Drawing.Point(82, 2);
            this.BagsType.Name = "BagsType";
            this.BagsType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BagsType.Properties.Appearance.Options.UseFont = true;
            this.BagsType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BagsType.Properties.NullText = "";
            this.BagsType.Properties.NullValuePrompt = "Type";
            this.BagsType.Properties.NullValuePromptShowForEmptyValue = true;
            this.BagsType.Size = new System.Drawing.Size(73, 20);
            this.BagsType.TabIndex = 0;
            this.BagsType.EditValueChanged += new System.EventHandler(this.BagsType_EditValueChanged);
            this.BagsType.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.BagsType_EditValueChanging);
            this.BagsType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionKeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(161, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 21);
            this.labelControl1.TabIndex = 313;
            this.labelControl1.Text = "# of Bags";
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(329, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 21);
            this.labelControl2.TabIndex = 315;
            this.labelControl2.Text = "Lbs.";
            // 
            // Lbs
            // 
            this.Lbs.EnterMoveNextControl = true;
            this.Lbs.Location = new System.Drawing.Point(363, 26);
            this.Lbs.Name = "Lbs";
            this.Lbs.Properties.Mask.EditMask = "n2";
            this.Lbs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Lbs.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Lbs.Properties.NullValuePrompt = "Lbs.";
            this.Lbs.Properties.NullValuePromptShowForEmptyValue = true;
            this.Lbs.Size = new System.Drawing.Size(74, 20);
            this.Lbs.TabIndex = 9;
            this.Lbs.EditValueChanged += new System.EventHandler(this.BagsType_EditValueChanged);
            this.Lbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionKeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(443, 26);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 21);
            this.labelControl3.TabIndex = 317;
            this.labelControl3.Text = "# of Cones";
            // 
            // Cones
            // 
            this.Cones.EnterMoveNextControl = true;
            this.Cones.Location = new System.Drawing.Point(503, 26);
            this.Cones.Name = "Cones";
            this.Cones.Properties.Mask.EditMask = "n0";
            this.Cones.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Cones.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Cones.Properties.NullValuePrompt = "# of Cones";
            this.Cones.Size = new System.Drawing.Size(69, 20);
            this.Cones.TabIndex = 10;
            this.Cones.EditValueChanged += new System.EventHandler(this.BagsType_EditValueChanged);
            this.Cones.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionKeyDown);
            // 
            // LbsPerBag
            // 
            this.LbsPerBag.EnterMoveNextControl = true;
            this.LbsPerBag.Location = new System.Drawing.Point(3, 26);
            this.LbsPerBag.Name = "LbsPerBag";
            this.LbsPerBag.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbsPerBag.Properties.Appearance.Options.UseFont = true;
            this.LbsPerBag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LbsPerBag.Properties.NullText = "";
            this.LbsPerBag.Properties.NullValuePrompt = "Lbs / Bag";
            this.LbsPerBag.Properties.NullValuePromptShowForEmptyValue = true;
            this.LbsPerBag.Size = new System.Drawing.Size(73, 20);
            this.LbsPerBag.TabIndex = 6;
            this.LbsPerBag.EditValueChanged += new System.EventHandler(this.BagsType_EditValueChanged);
            this.LbsPerBag.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.LbsPerBag_EditValueChanging);
            this.LbsPerBag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionKeyDown);
            // 
            // ConesPerBag
            // 
            this.ConesPerBag.EnterMoveNextControl = true;
            this.ConesPerBag.Location = new System.Drawing.Point(82, 26);
            this.ConesPerBag.Name = "ConesPerBag";
            this.ConesPerBag.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConesPerBag.Properties.Appearance.Options.UseFont = true;
            this.ConesPerBag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ConesPerBag.Properties.NullText = "";
            this.ConesPerBag.Properties.NullValuePrompt = "Cones / Bag";
            this.ConesPerBag.Properties.NullValuePromptShowForEmptyValue = true;
            this.ConesPerBag.Size = new System.Drawing.Size(73, 20);
            this.ConesPerBag.TabIndex = 7;
            this.ConesPerBag.EditValueChanged += new System.EventHandler(this.BagsType_EditValueChanged);
            this.ConesPerBag.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.ConesPerBag_EditValueChanging);
            this.ConesPerBag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionKeyDown);
            // 
            // labelControl5
            // 
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.LineVisible = true;
            this.labelControl5.Location = new System.Drawing.Point(161, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 21);
            this.labelControl5.TabIndex = 326;
            this.labelControl5.Text = "Count";
            // 
            // labelControl7
            // 
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.LineVisible = true;
            this.labelControl7.Location = new System.Drawing.Point(480, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(43, 21);
            this.labelControl7.TabIndex = 328;
            this.labelControl7.Text = "Brand";
            // 
            // LabelAvlLbs
            // 
            this.LabelAvlLbs.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LabelAvlLbs.LineVisible = true;
            this.LabelAvlLbs.Location = new System.Drawing.Point(690, 25);
            this.LabelAvlLbs.Name = "LabelAvlLbs";
            this.LabelAvlLbs.Size = new System.Drawing.Size(46, 21);
            this.LabelAvlLbs.TabIndex = 333;
            this.LabelAvlLbs.Text = "Avl. Lbs.";
            // 
            // AvlLbs
            // 
            this.AvlLbs.Location = new System.Drawing.Point(742, 26);
            this.AvlLbs.Name = "AvlLbs";
            this.AvlLbs.Properties.Mask.EditMask = "n2";
            this.AvlLbs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.AvlLbs.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.AvlLbs.Properties.NullValuePrompt = "Avbl. Lbs.";
            this.AvlLbs.Properties.NullValuePromptShowForEmptyValue = true;
            this.AvlLbs.Properties.ReadOnly = true;
            this.AvlLbs.Size = new System.Drawing.Size(74, 20);
            this.AvlLbs.TabIndex = 12;
            this.AvlLbs.TabStop = false;
            // 
            // labelControl11
            // 
            this.labelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl11.LineVisible = true;
            this.labelControl11.Location = new System.Drawing.Point(574, 26);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(59, 21);
            this.labelControl11.TabIndex = 331;
            this.labelControl11.Text = "Avl. Bags";
            // 
            // AvlBags
            // 
            this.AvlBags.Location = new System.Drawing.Point(639, 26);
            this.AvlBags.Name = "AvlBags";
            this.AvlBags.Properties.Mask.EditMask = "n0";
            this.AvlBags.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.AvlBags.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.AvlBags.Properties.NullValuePrompt = "Avbl. Bags";
            this.AvlBags.Properties.NullValuePromptShowForEmptyValue = true;
            this.AvlBags.Properties.ReadOnly = true;
            this.AvlBags.Size = new System.Drawing.Size(49, 20);
            this.AvlBags.TabIndex = 11;
            this.AvlBags.TabStop = false;
            // 
            // AutoManual
            // 
            this.AutoManual.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoManual.Appearance.Options.UseFont = true;
            this.AutoManual.Checked = true;
            this.AutoManual.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.AutoManual.Location = new System.Drawing.Point(3, 2);
            this.AutoManual.Name = "AutoManual";
            this.AutoManual.Size = new System.Drawing.Size(74, 20);
            this.AutoManual.TabIndex = 337;
            this.AutoManual.TabStop = false;
            this.AutoManual.Tag = "";
            this.AutoManual.Text = "Manual Calc.";
            this.AutoManual.ToolTip = "Click to change category of voucher between G and N";
            this.AutoManual.ToolTipTitle = "Voucher Category";
            this.AutoManual.CheckedChanged += new System.EventHandler(this.AutoManual_CheckedChanged);
            // 
            // Color
            // 
            this.Color.EnterMoveNextControl = true;
            this.Color.Location = new System.Drawing.Point(794, 2);
            this.Color.Name = "Color";
            this.Color.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Color.Properties.Appearance.Options.UseFont = true;
            this.Color.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Color.Properties.NullText = "";
            this.Color.Properties.NullValuePrompt = "Color";
            this.Color.Properties.NullValuePromptShowForEmptyValue = true;
            this.Color.Size = new System.Drawing.Size(98, 20);
            this.Color.TabIndex = 338;
            // 
            // CheckStock
            // 
            this.CheckStock.Location = new System.Drawing.Point(822, 25);
            this.CheckStock.Name = "CheckStock";
            this.CheckStock.Size = new System.Drawing.Size(68, 20);
            this.CheckStock.TabIndex = 339;
            this.CheckStock.Text = "Check Stock";
            this.CheckStock.Click += new System.EventHandler(this.CheckStock_Click);
            // 
            // Filter_Bags
            // 
            this.Filter_Bags.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_Bags.Appearance.Options.UseFont = true;
            this.Filter_Bags.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_Bags.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_Bags.Location = new System.Drawing.Point(305, 26);
            this.Filter_Bags.Name = "Filter_Bags";
            this.Filter_Bags.Size = new System.Drawing.Size(20, 20);
            this.Filter_Bags.TabIndex = 324;
            this.Filter_Bags.TabStop = false;
            // 
            // Filter_Desc
            // 
            this.Filter_Desc.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_Desc.Appearance.Options.UseFont = true;
            this.Filter_Desc.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_Desc.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_Desc.Location = new System.Drawing.Point(772, 2);
            this.Filter_Desc.Name = "Filter_Desc";
            this.Filter_Desc.Size = new System.Drawing.Size(20, 20);
            this.Filter_Desc.TabIndex = 323;
            this.Filter_Desc.TabStop = false;
            // 
            // Filter_Brand
            // 
            this.Filter_Brand.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_Brand.Appearance.Options.UseFont = true;
            this.Filter_Brand.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_Brand.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_Brand.Location = new System.Drawing.Point(632, 2);
            this.Filter_Brand.Name = "Filter_Brand";
            this.Filter_Brand.Size = new System.Drawing.Size(20, 20);
            this.Filter_Brand.TabIndex = 322;
            this.Filter_Brand.TabStop = false;
            // 
            // Filter_Blend
            // 
            this.Filter_Blend.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_Blend.Appearance.Options.UseFont = true;
            this.Filter_Blend.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_Blend.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_Blend.Location = new System.Drawing.Point(454, 2);
            this.Filter_Blend.Name = "Filter_Blend";
            this.Filter_Blend.Size = new System.Drawing.Size(20, 20);
            this.Filter_Blend.TabIndex = 321;
            this.Filter_Blend.TabStop = false;
            // 
            // Filter_Count
            // 
            this.Filter_Count.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_Count.Appearance.Options.UseFont = true;
            this.Filter_Count.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_Count.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_Count.Location = new System.Drawing.Point(325, 2);
            this.Filter_Count.Name = "Filter_Count";
            this.Filter_Count.Size = new System.Drawing.Size(20, 20);
            this.Filter_Count.TabIndex = 320;
            this.Filter_Count.TabStop = false;
            // 
            // dxYarn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CheckStock);
            this.Controls.Add(this.Color);
            this.Controls.Add(this.AutoManual);
            this.Controls.Add(this.LabelAvlLbs);
            this.Controls.Add(this.AvlLbs);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.AvlBags);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.Filter_Bags);
            this.Controls.Add(this.Filter_Desc);
            this.Controls.Add(this.Filter_Brand);
            this.Controls.Add(this.Filter_Blend);
            this.Controls.Add(this.Filter_Count);
            this.Controls.Add(this.LbsPerBag);
            this.Controls.Add(this.ConesPerBag);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.Cones);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.Lbs);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.BagsType);
            this.Controls.Add(this.Bags);
            this.Controls.Add(this.Brand);
            this.Controls.Add(this.Desc);
            this.Controls.Add(this.Blends);
            this.Controls.Add(this.Ply);
            this.Controls.Add(this.Counts);
            this.Name = "dxYarn";
            this.Size = new System.Drawing.Size(894, 51);
            this.Load += new System.EventHandler(this.dxYarn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Brand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Desc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blends.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ply.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Counts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bags.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BagsType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lbs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cones.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LbsPerBag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConesPerBag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvlLbs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvlBags.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Color.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LookUpEdit Brand;
        public DevExpress.XtraEditors.LookUpEdit Desc;
        public DevExpress.XtraEditors.LookUpEdit Blends;
        public DevExpress.XtraEditors.LookUpEdit Ply;
        public DevExpress.XtraEditors.LookUpEdit Counts;
        public DevExpress.XtraEditors.LookUpEdit BagsType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.LookUpEdit LbsPerBag;
        public DevExpress.XtraEditors.LookUpEdit ConesPerBag;
        public DevExpress.XtraEditors.TextEdit Bags;
        public DevExpress.XtraEditors.TextEdit Lbs;
        public DevExpress.XtraEditors.TextEdit Cones;
        public DevExpress.XtraEditors.CheckButton Filter_Count;
        public DevExpress.XtraEditors.CheckButton Filter_Blend;
        public DevExpress.XtraEditors.CheckButton Filter_Brand;
        public DevExpress.XtraEditors.CheckButton Filter_Desc;
        public DevExpress.XtraEditors.CheckButton Filter_Bags;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl LabelAvlLbs;
        public DevExpress.XtraEditors.TextEdit AvlLbs;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        public DevExpress.XtraEditors.TextEdit AvlBags;
        private DevExpress.XtraEditors.CheckButton AutoManual;
        public DevExpress.XtraEditors.LookUpEdit Color;
        private DevExpress.XtraEditors.SimpleButton CheckStock;
    }
}
