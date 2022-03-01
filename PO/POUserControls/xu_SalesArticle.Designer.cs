namespace MachineEyes.PO.POUserControls
{
    partial class xu_SalesArticle
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
            this.ArticleName = new DevExpress.XtraEditors.TextEdit();
            this.Amount = new DevExpress.XtraEditors.TextEdit();
            this.Price = new DevExpress.XtraEditors.TextEdit();
            this.QuantityLbs = new DevExpress.XtraEditors.TextEdit();
            this.ArticleNumber = new DevExpress.XtraEditors.TextEdit();
            this.Currency = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.QuantityPcs = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.scroll_Fancy = new DevExpress.XtraEditors.XtraScrollableControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.scroll_Weft = new DevExpress.XtraEditors.XtraScrollableControl();
            this.scroll_Pile = new DevExpress.XtraEditors.XtraScrollableControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.scroll_Warp = new DevExpress.XtraEditors.XtraScrollableControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.WPP = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.WastageAllowed = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.RatioTotal = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityLbs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Currency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityPcs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WPP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WastageAllowed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RatioTotal.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ArticleName
            // 
            this.ArticleName.Location = new System.Drawing.Point(141, 5);
            this.ArticleName.Name = "ArticleName";
            this.ArticleName.Properties.NullValuePrompt = "Article / Construction";
            this.ArticleName.Properties.NullValuePromptShowForEmptyValue = true;
            this.ArticleName.Properties.ReadOnly = true;
            this.ArticleName.Size = new System.Drawing.Size(183, 20);
            this.ArticleName.TabIndex = 11;
            this.ArticleName.TabStop = false;
            this.ArticleName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArticleName_KeyDown);
            this.ArticleName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ArticleNumber_KeyUp);
            // 
            // Amount
            // 
            this.Amount.Location = new System.Drawing.Point(588, 34);
            this.Amount.Name = "Amount";
            this.Amount.Properties.Mask.EditMask = "n0";
            this.Amount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Amount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Amount.Properties.NullValuePrompt = "Total Amount";
            this.Amount.Properties.NullValuePromptShowForEmptyValue = true;
            this.Amount.Properties.ReadOnly = true;
            this.Amount.Size = new System.Drawing.Size(148, 20);
            this.Amount.TabIndex = 9;
            this.Amount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEdit4_KeyDown);
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(410, 34);
            this.Price.Name = "Price";
            this.Price.Properties.Mask.EditMask = "n2";
            this.Price.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Price.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Price.Properties.NullValuePrompt = "Price";
            this.Price.Properties.NullValuePromptShowForEmptyValue = true;
            this.Price.Size = new System.Drawing.Size(79, 20);
            this.Price.TabIndex = 3;
            this.Price.EditValueChanged += new System.EventHandler(this.Price_EditValueChanged);
            this.Price.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Price_KeyDown);
            // 
            // QuantityLbs
            // 
            this.QuantityLbs.Location = new System.Drawing.Point(245, 34);
            this.QuantityLbs.Name = "QuantityLbs";
            this.QuantityLbs.Properties.Mask.EditMask = "n2";
            this.QuantityLbs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.QuantityLbs.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.QuantityLbs.Properties.NullValuePrompt = "Quantity lbs";
            this.QuantityLbs.Properties.NullValuePromptShowForEmptyValue = true;
            this.QuantityLbs.Properties.ReadOnly = true;
            this.QuantityLbs.Size = new System.Drawing.Size(79, 20);
            this.QuantityLbs.TabIndex = 7;
            this.QuantityLbs.TabStop = false;
            this.QuantityLbs.EditValueChanged += new System.EventHandler(this.Quantity_EditValueChanged);
            this.QuantityLbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Quantity_KeyDown);
            // 
            // ArticleNumber
            // 
            this.ArticleNumber.Location = new System.Drawing.Point(83, 5);
            this.ArticleNumber.Name = "ArticleNumber";
            this.ArticleNumber.Properties.NullValuePrompt = "Article Number";
            this.ArticleNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.ArticleNumber.Size = new System.Drawing.Size(58, 20);
            this.ArticleNumber.TabIndex = 0;
            this.ArticleNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArticleNumber_KeyDown);
            this.ArticleNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ArticleNumber_KeyUp);
            // 
            // Currency
            // 
            this.Currency.EditValue = "PKR";
            this.Currency.Location = new System.Drawing.Point(736, 34);
            this.Currency.Name = "Currency";
            this.Currency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Currency.Properties.NullText = "";
            this.Currency.Properties.NullValuePrompt = "Unit";
            this.Currency.Properties.NullValuePromptShowForEmptyValue = true;
            this.Currency.Size = new System.Drawing.Size(79, 20);
            this.Currency.TabIndex = 4;
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl15.LineVisible = true;
            this.labelControl15.Location = new System.Drawing.Point(3, 8);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(74, 17);
            this.labelControl15.TabIndex = 376;
            this.labelControl15.Text = "Article";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 17);
            this.labelControl1.TabIndex = 377;
            this.labelControl1.Text = "Qty (Pcs)";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(165, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 17);
            this.labelControl2.TabIndex = 379;
            this.labelControl2.Text = "Qty (Lbs)";
            // 
            // QuantityPcs
            // 
            this.QuantityPcs.Location = new System.Drawing.Point(83, 34);
            this.QuantityPcs.Name = "QuantityPcs";
            this.QuantityPcs.Properties.Mask.EditMask = "n2";
            this.QuantityPcs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.QuantityPcs.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.QuantityPcs.Properties.NullValuePrompt = "Quantity Pcs";
            this.QuantityPcs.Properties.NullValuePromptShowForEmptyValue = true;
            this.QuantityPcs.Size = new System.Drawing.Size(79, 20);
            this.QuantityPcs.TabIndex = 2;
            this.QuantityPcs.EditValueChanged += new System.EventHandler(this.QuantityPcs_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(330, 35);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(74, 17);
            this.labelControl3.TabIndex = 380;
            this.labelControl3.Text = "Rate / Lbs";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl12.LineVisible = true;
            this.labelControl12.Location = new System.Drawing.Point(4, 399);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Padding = new System.Windows.Forms.Padding(2);
            this.labelControl12.Size = new System.Drawing.Size(750, 20);
            this.labelControl12.TabIndex = 388;
            this.labelControl12.Text = "Fancy";
            // 
            // scroll_Fancy
            // 
            this.scroll_Fancy.Location = new System.Drawing.Point(19, 428);
            this.scroll_Fancy.Name = "scroll_Fancy";
            this.scroll_Fancy.Size = new System.Drawing.Size(773, 80);
            this.scroll_Fancy.TabIndex = 384;
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl19.Appearance.ForeColor = System.Drawing.Color.Green;
            this.labelControl19.Appearance.Options.UseFont = true;
            this.labelControl19.Appearance.Options.UseForeColor = true;
            this.labelControl19.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl19.LineVisible = true;
            this.labelControl19.Location = new System.Drawing.Point(4, 287);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Padding = new System.Windows.Forms.Padding(2);
            this.labelControl19.Size = new System.Drawing.Size(750, 20);
            this.labelControl19.TabIndex = 387;
            this.labelControl19.Text = "Pile";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl18.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl18.Appearance.Options.UseFont = true;
            this.labelControl18.Appearance.Options.UseForeColor = true;
            this.labelControl18.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl18.LineVisible = true;
            this.labelControl18.Location = new System.Drawing.Point(4, 172);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Padding = new System.Windows.Forms.Padding(2);
            this.labelControl18.Size = new System.Drawing.Size(750, 20);
            this.labelControl18.TabIndex = 386;
            this.labelControl18.Text = "Weft";
            // 
            // scroll_Weft
            // 
            this.scroll_Weft.Location = new System.Drawing.Point(19, 198);
            this.scroll_Weft.Name = "scroll_Weft";
            this.scroll_Weft.Size = new System.Drawing.Size(773, 80);
            this.scroll_Weft.TabIndex = 382;
            // 
            // scroll_Pile
            // 
            this.scroll_Pile.Location = new System.Drawing.Point(19, 313);
            this.scroll_Pile.Name = "scroll_Pile";
            this.scroll_Pile.Size = new System.Drawing.Size(773, 80);
            this.scroll_Pile.TabIndex = 383;
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl17.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.labelControl17.Appearance.Options.UseFont = true;
            this.labelControl17.Appearance.Options.UseForeColor = true;
            this.labelControl17.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl17.LineVisible = true;
            this.labelControl17.Location = new System.Drawing.Point(3, 57);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Padding = new System.Windows.Forms.Padding(2);
            this.labelControl17.Size = new System.Drawing.Size(751, 20);
            this.labelControl17.TabIndex = 385;
            this.labelControl17.Text = "Warp";
            // 
            // scroll_Warp
            // 
            this.scroll_Warp.Location = new System.Drawing.Point(19, 86);
            this.scroll_Warp.Name = "scroll_Warp";
            this.scroll_Warp.Size = new System.Drawing.Size(773, 80);
            this.scroll_Warp.TabIndex = 381;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.LineVisible = true;
            this.labelControl4.Location = new System.Drawing.Point(330, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(74, 17);
            this.labelControl4.TabIndex = 390;
            this.labelControl4.Text = "g/p";
            // 
            // WPP
            // 
            this.WPP.Location = new System.Drawing.Point(410, 5);
            this.WPP.Name = "WPP";
            this.WPP.Properties.Mask.EditMask = "n2";
            this.WPP.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.WPP.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.WPP.Properties.NullValuePrompt = "grams / piece";
            this.WPP.Properties.NullValuePromptShowForEmptyValue = true;
            this.WPP.Properties.ReadOnly = true;
            this.WPP.Size = new System.Drawing.Size(79, 20);
            this.WPP.TabIndex = 389;
            this.WPP.TabStop = false;
            this.WPP.EditValueChanged += new System.EventHandler(this.WPP_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.LineVisible = true;
            this.labelControl5.Location = new System.Drawing.Point(508, 37);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(74, 17);
            this.labelControl5.TabIndex = 391;
            this.labelControl5.Text = "Amount";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.LineVisible = true;
            this.labelControl6.Location = new System.Drawing.Point(508, 6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(109, 17);
            this.labelControl6.TabIndex = 392;
            this.labelControl6.Text = "Yarn Wastage %";
            // 
            // WastageAllowed
            // 
            this.WastageAllowed.Location = new System.Drawing.Point(623, 5);
            this.WastageAllowed.Name = "WastageAllowed";
            this.WastageAllowed.Properties.Mask.EditMask = "n2";
            this.WastageAllowed.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.WastageAllowed.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.WastageAllowed.Properties.NullValuePrompt = "Quantity Pcs";
            this.WastageAllowed.Properties.NullValuePromptShowForEmptyValue = true;
            this.WastageAllowed.Size = new System.Drawing.Size(51, 20);
            this.WastageAllowed.TabIndex = 1;
            this.WastageAllowed.EditValueChanged += new System.EventHandler(this.WastageAllowed_EditValueChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.LineVisible = true;
            this.labelControl7.Location = new System.Drawing.Point(691, 6);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(39, 17);
            this.labelControl7.TabIndex = 394;
            this.labelControl7.Text = "R/T";
            // 
            // RatioTotal
            // 
            this.RatioTotal.Location = new System.Drawing.Point(736, 5);
            this.RatioTotal.Name = "RatioTotal";
            this.RatioTotal.Properties.Mask.EditMask = "n2";
            this.RatioTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.RatioTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.RatioTotal.Properties.NullValuePrompt = "grams / piece";
            this.RatioTotal.Properties.NullValuePromptShowForEmptyValue = true;
            this.RatioTotal.Properties.ReadOnly = true;
            this.RatioTotal.Size = new System.Drawing.Size(79, 20);
            this.RatioTotal.TabIndex = 393;
            this.RatioTotal.TabStop = false;
            // 
            // xu_SalesArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.RatioTotal);
            this.Controls.Add(this.WastageAllowed);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl19);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.WPP);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.scroll_Fancy);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.scroll_Weft);
            this.Controls.Add(this.scroll_Pile);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.scroll_Warp);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.QuantityPcs);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.Currency);
            this.Controls.Add(this.ArticleName);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.QuantityLbs);
            this.Controls.Add(this.ArticleNumber);
            this.Name = "xu_SalesArticle";
            this.Size = new System.Drawing.Size(818, 516);
            ((System.ComponentModel.ISupportInitialize)(this.ArticleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityLbs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Currency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityPcs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WPP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WastageAllowed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RatioTotal.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit Amount;
        public DevExpress.XtraEditors.TextEdit Price;
        public DevExpress.XtraEditors.TextEdit QuantityLbs;
        public DevExpress.XtraEditors.TextEdit ArticleNumber;
        public DevExpress.XtraEditors.LookUpEdit Currency;
        public DevExpress.XtraEditors.TextEdit ArticleName;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit QuantityPcs;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit WPP;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.XtraScrollableControl scroll_Fancy;
        public DevExpress.XtraEditors.XtraScrollableControl scroll_Weft;
        public DevExpress.XtraEditors.XtraScrollableControl scroll_Pile;
        public DevExpress.XtraEditors.XtraScrollableControl scroll_Warp;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit WastageAllowed;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit RatioTotal;
    }
}
