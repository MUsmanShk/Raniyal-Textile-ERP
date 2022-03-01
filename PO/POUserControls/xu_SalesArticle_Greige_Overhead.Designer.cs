namespace MachineEyes.PO.POUserControls
{
    partial class xu_SalesArticle_Greige_Overhead
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.QuantityMtrs = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.Currency = new DevExpress.XtraEditors.LookUpEdit();
            this.ArticleName = new DevExpress.XtraEditors.TextEdit();
            this.WeavingRatePerMeter = new DevExpress.XtraEditors.TextEdit();
            this.ArticleNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.scroll_Weft = new DevExpress.XtraEditors.XtraScrollableControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.scroll_Fancy = new DevExpress.XtraEditors.XtraScrollableControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ExchangeCurrency = new DevExpress.XtraEditors.LookUpEdit();
            this.ExchangeRate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.WeavingRatePerPick = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.NoofLooms = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityMtrs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Currency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeavingRatePerMeter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeavingRatePerPick.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoofLooms.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(620, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(116, 17);
            this.labelControl3.TabIndex = 406;
            this.labelControl3.Text = "Weaving Rate /Mtr";
            // 
            // QuantityMtrs
            // 
            this.QuantityMtrs.EnterMoveNextControl = true;
            this.QuantityMtrs.Location = new System.Drawing.Point(553, 3);
            this.QuantityMtrs.Name = "QuantityMtrs";
            this.QuantityMtrs.Properties.Mask.EditMask = "n0";
            this.QuantityMtrs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.QuantityMtrs.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.QuantityMtrs.Properties.NullValuePrompt = "Meters";
            this.QuantityMtrs.Properties.NullValuePromptShowForEmptyValue = true;
            this.QuantityMtrs.Size = new System.Drawing.Size(62, 20);
            this.QuantityMtrs.TabIndex = 1;
            this.QuantityMtrs.EditValueChanged += new System.EventHandler(this.QuantityMtrs_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(490, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 17);
            this.labelControl1.TabIndex = 404;
            this.labelControl1.Text = "Meters";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl15.LineVisible = true;
            this.labelControl15.Location = new System.Drawing.Point(6, 6);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(57, 17);
            this.labelControl15.TabIndex = 403;
            this.labelControl15.Text = "Article";
            // 
            // Currency
            // 
            this.Currency.EditValue = "PKR";
            this.Currency.EnterMoveNextControl = true;
            this.Currency.Location = new System.Drawing.Point(490, 31);
            this.Currency.Name = "Currency";
            this.Currency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Currency.Properties.NullText = "";
            this.Currency.Properties.NullValuePrompt = "Unit";
            this.Currency.Properties.NullValuePromptShowForEmptyValue = true;
            this.Currency.Size = new System.Drawing.Size(68, 20);
            this.Currency.TabIndex = 5;
            // 
            // ArticleName
            // 
            this.ArticleName.Location = new System.Drawing.Point(144, 3);
            this.ArticleName.Name = "ArticleName";
            this.ArticleName.Properties.NullValuePrompt = "Article / Construction";
            this.ArticleName.Properties.NullValuePromptShowForEmptyValue = true;
            this.ArticleName.Properties.ReadOnly = true;
            this.ArticleName.Size = new System.Drawing.Size(340, 20);
            this.ArticleName.TabIndex = 402;
            this.ArticleName.TabStop = false;
            // 
            // WeavingRatePerMeter
            // 
            this.WeavingRatePerMeter.EnterMoveNextControl = true;
            this.WeavingRatePerMeter.Location = new System.Drawing.Point(742, 1);
            this.WeavingRatePerMeter.Name = "WeavingRatePerMeter";
            this.WeavingRatePerMeter.Properties.Mask.EditMask = "n4";
            this.WeavingRatePerMeter.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.WeavingRatePerMeter.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.WeavingRatePerMeter.Size = new System.Drawing.Size(76, 20);
            this.WeavingRatePerMeter.TabIndex = 2;
            this.WeavingRatePerMeter.EditValueChanged += new System.EventHandler(this.Price_EditValueChanged);
            // 
            // ArticleNumber
            // 
            this.ArticleNumber.EnterMoveNextControl = true;
            this.ArticleNumber.Location = new System.Drawing.Point(65, 3);
            this.ArticleNumber.Name = "ArticleNumber";
            this.ArticleNumber.Properties.NullValuePrompt = "Article Number";
            this.ArticleNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.ArticleNumber.Size = new System.Drawing.Size(75, 20);
            this.ArticleNumber.TabIndex = 0;
            this.ArticleNumber.EditValueChanged += new System.EventHandler(this.ArticleNumber_EditValueChanged);
            this.ArticleNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArticleNumber_KeyDown);
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl18.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl18.Appearance.Options.UseFont = true;
            this.labelControl18.Appearance.Options.UseForeColor = true;
            this.labelControl18.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl18.LineVisible = true;
            this.labelControl18.Location = new System.Drawing.Point(7, 72);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Padding = new System.Windows.Forms.Padding(2);
            this.labelControl18.Size = new System.Drawing.Size(812, 20);
            this.labelControl18.TabIndex = 418;
            this.labelControl18.Text = "Weft";
            // 
            // scroll_Weft
            // 
            this.scroll_Weft.Location = new System.Drawing.Point(23, 98);
            this.scroll_Weft.Name = "scroll_Weft";
            this.scroll_Weft.Size = new System.Drawing.Size(931, 80);
            this.scroll_Weft.TabIndex = 9;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl12.LineVisible = true;
            this.labelControl12.Location = new System.Drawing.Point(7, 184);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Padding = new System.Windows.Forms.Padding(2);
            this.labelControl12.Size = new System.Drawing.Size(811, 20);
            this.labelControl12.TabIndex = 420;
            this.labelControl12.Text = "Fancy";
            // 
            // scroll_Fancy
            // 
            this.scroll_Fancy.Location = new System.Drawing.Point(23, 210);
            this.scroll_Fancy.Name = "scroll_Fancy";
            this.scroll_Fancy.Size = new System.Drawing.Size(931, 80);
            this.scroll_Fancy.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(564, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(107, 17);
            this.labelControl2.TabIndex = 423;
            this.labelControl2.Text = "Exchange Rate";
            // 
            // ExchangeCurrency
            // 
            this.ExchangeCurrency.EditValue = "PKR";
            this.ExchangeCurrency.EnterMoveNextControl = true;
            this.ExchangeCurrency.Location = new System.Drawing.Point(762, 31);
            this.ExchangeCurrency.Name = "ExchangeCurrency";
            this.ExchangeCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ExchangeCurrency.Properties.NullText = "";
            this.ExchangeCurrency.Properties.NullValuePrompt = "Unit";
            this.ExchangeCurrency.Properties.NullValuePromptShowForEmptyValue = true;
            this.ExchangeCurrency.Size = new System.Drawing.Size(56, 20);
            this.ExchangeCurrency.TabIndex = 7;
            // 
            // ExchangeRate
            // 
            this.ExchangeRate.EnterMoveNextControl = true;
            this.ExchangeRate.Location = new System.Drawing.Point(677, 31);
            this.ExchangeRate.Name = "ExchangeRate";
            this.ExchangeRate.Properties.Mask.EditMask = "n4";
            this.ExchangeRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ExchangeRate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.ExchangeRate.Properties.NullValuePrompt = "@ Exchange";
            this.ExchangeRate.Properties.NullValuePromptShowForEmptyValue = true;
            this.ExchangeRate.Size = new System.Drawing.Size(79, 20);
            this.ExchangeRate.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.LineVisible = true;
            this.labelControl4.Location = new System.Drawing.Point(7, 32);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(131, 17);
            this.labelControl4.TabIndex = 425;
            this.labelControl4.Text = "Weaving Rate / Pick";
            // 
            // WeavingRatePerPick
            // 
            this.WeavingRatePerPick.EnterMoveNextControl = true;
            this.WeavingRatePerPick.Location = new System.Drawing.Point(144, 31);
            this.WeavingRatePerPick.Name = "WeavingRatePerPick";
            this.WeavingRatePerPick.Properties.Mask.EditMask = "n4";
            this.WeavingRatePerPick.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.WeavingRatePerPick.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.WeavingRatePerPick.Size = new System.Drawing.Size(54, 20);
            this.WeavingRatePerPick.TabIndex = 3;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.LineVisible = true;
            this.labelControl6.Location = new System.Drawing.Point(206, 32);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(98, 17);
            this.labelControl6.TabIndex = 427;
            this.labelControl6.Text = "No of Looms";
            // 
            // NoofLooms
            // 
            this.NoofLooms.EnterMoveNextControl = true;
            this.NoofLooms.Location = new System.Drawing.Point(310, 29);
            this.NoofLooms.Name = "NoofLooms";
            this.NoofLooms.Properties.Mask.EditMask = "n0";
            this.NoofLooms.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.NoofLooms.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.NoofLooms.Size = new System.Drawing.Size(52, 20);
            this.NoofLooms.TabIndex = 4;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.LineVisible = true;
            this.labelControl5.Location = new System.Drawing.Point(377, 32);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(107, 17);
            this.labelControl5.TabIndex = 428;
            this.labelControl5.Text = "Currency Name";
            // 
            // xu_SalesArticle_Greige_Overhead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.NoofLooms);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.WeavingRatePerPick);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.ExchangeCurrency);
            this.Controls.Add(this.ExchangeRate);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.scroll_Fancy);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.scroll_Weft);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.QuantityMtrs);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.Currency);
            this.Controls.Add(this.ArticleName);
            this.Controls.Add(this.WeavingRatePerMeter);
            this.Controls.Add(this.ArticleNumber);
            this.Name = "xu_SalesArticle_Greige_Overhead";
            this.Size = new System.Drawing.Size(987, 323);
            this.Load += new System.EventHandler(this.xu_SalesArticle_Greige_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuantityMtrs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Currency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeavingRatePerMeter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeavingRatePerPick.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoofLooms.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit QuantityMtrs;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        public DevExpress.XtraEditors.LookUpEdit Currency;
        public DevExpress.XtraEditors.TextEdit ArticleName;
        public DevExpress.XtraEditors.TextEdit WeavingRatePerMeter;
        public DevExpress.XtraEditors.TextEdit ArticleNumber;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        public DevExpress.XtraEditors.XtraScrollableControl scroll_Weft;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        public DevExpress.XtraEditors.XtraScrollableControl scroll_Fancy;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit ExchangeCurrency;
        public DevExpress.XtraEditors.TextEdit ExchangeRate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit WeavingRatePerPick;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit NoofLooms;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}
