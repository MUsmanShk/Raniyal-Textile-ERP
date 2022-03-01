namespace MachineEyes.Accounts.ReportingParameters
{
    partial class xu_SalesTaxRegister_FilterArticle
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
            this.LedgerType = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.ToDate = new DevExpress.XtraEditors.DateEdit();
            this.FromDate = new DevExpress.XtraEditors.DateEdit();
            this.ArticleID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ArticleName = new DevExpress.XtraEditors.LabelControl();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            this.PrintReport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LedgerType
            // 
            this.LedgerType.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LedgerType.Appearance.Options.UseFont = true;
            this.LedgerType.Location = new System.Drawing.Point(3, 3);
            this.LedgerType.Name = "LedgerType";
            this.LedgerType.Size = new System.Drawing.Size(248, 25);
            this.LedgerType.TabIndex = 270;
            this.LedgerType.Text = "Article Sales Tax Register";
            // 
            // radioGroup1
            // 
            this.radioGroup1.EditValue = "G";
            this.radioGroup1.Location = new System.Drawing.Point(228, 138);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("G", "Type [G]"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "Type [N]"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("B", "Type [B]")});
            this.radioGroup1.Size = new System.Drawing.Size(148, 82);
            this.radioGroup1.TabIndex = 269;
            // 
            // ToDate
            // 
            this.ToDate.EditValue = null;
            this.ToDate.EnterMoveNextControl = true;
            this.ToDate.Location = new System.Drawing.Point(79, 164);
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
            this.ToDate.Size = new System.Drawing.Size(143, 20);
            this.ToDate.TabIndex = 266;
            // 
            // FromDate
            // 
            this.FromDate.EditValue = null;
            this.FromDate.EnterMoveNextControl = true;
            this.FromDate.Location = new System.Drawing.Point(78, 138);
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
            this.FromDate.Size = new System.Drawing.Size(143, 20);
            this.FromDate.TabIndex = 265;
            // 
            // ArticleID
            // 
            this.ArticleID.Location = new System.Drawing.Point(79, 38);
            this.ArticleID.Name = "ArticleID";
            this.ArticleID.Size = new System.Drawing.Size(134, 20);
            this.ArticleID.TabIndex = 263;
            this.ArticleID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArticleID_KeyDown);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(57, 167);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(16, 13);
            this.labelControl4.TabIndex = 261;
            this.labelControl4.Text = "To:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(44, 141);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 13);
            this.labelControl5.TabIndex = 260;
            this.labelControl5.Text = "From:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(33, 67);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 13);
            this.labelControl3.TabIndex = 259;
            this.labelControl3.Text = "Article";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 258;
            this.labelControl2.Text = "Article ID";
            // 
            // ArticleName
            // 
            this.ArticleName.Appearance.Options.UseTextOptions = true;
            this.ArticleName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ArticleName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.ArticleName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.ArticleName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.ArticleName.Location = new System.Drawing.Point(79, 67);
            this.ArticleName.Name = "ArticleName";
            this.ArticleName.Size = new System.Drawing.Size(297, 65);
            this.ArticleName.TabIndex = 271;
            // 
            // CloseForm
            // 
            this.CloseForm.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseForm.Appearance.Options.UseFont = true;
            this.CloseForm.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseForm.Location = new System.Drawing.Point(192, 190);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(30, 30);
            this.CloseForm.TabIndex = 268;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // PrintReport
            // 
            this.PrintReport.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintReport.Appearance.Options.UseFont = true;
            this.PrintReport.Image = global::MachineEyes.Properties.Resources.Execute;
            this.PrintReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.PrintReport.Location = new System.Drawing.Point(160, 190);
            this.PrintReport.Name = "PrintReport";
            this.PrintReport.Size = new System.Drawing.Size(30, 30);
            this.PrintReport.TabIndex = 262;
            this.PrintReport.Click += new System.EventHandler(this.PrintReport_Click);
            // 
            // xu_SalesTaxRegister_FilterArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ArticleName);
            this.Controls.Add(this.LedgerType);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.ArticleID);
            this.Controls.Add(this.PrintReport);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Name = "xu_SalesTaxRegister_FilterArticle";
            this.Size = new System.Drawing.Size(382, 233);
            this.Load += new System.EventHandler(this.xu_SalesTaxRegister_FilterArticle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.LabelControl LedgerType;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
        private DevExpress.XtraEditors.DateEdit ToDate;
        private DevExpress.XtraEditors.DateEdit FromDate;
        private DevExpress.XtraEditors.TextEdit ArticleID;
        private DevExpress.XtraEditors.SimpleButton PrintReport;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl ArticleName;
    }
}
