namespace MachineEyes.InspectionDelivery.UserControls
{
    partial class Towel_ArticleBinCard
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
            this.Article = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ToDate = new DevExpress.XtraEditors.DateEdit();
            this.FromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.LedgerType = new DevExpress.XtraEditors.LabelControl();
            this.ArticleNumber = new DevExpress.XtraEditors.TextEdit();
            this.WAA = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.PrintReport = new DevExpress.XtraEditors.SimpleButton();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Article.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WAA.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Article
            // 
            this.Article.Location = new System.Drawing.Point(145, 41);
            this.Article.Name = "Article";
            this.Article.Properties.ReadOnly = true;
            this.Article.Size = new System.Drawing.Size(378, 20);
            this.Article.TabIndex = 300;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 13);
            this.labelControl1.TabIndex = 299;
            this.labelControl1.Text = "Article";
            // 
            // ToDate
            // 
            this.ToDate.EditValue = null;
            this.ToDate.EnterMoveNextControl = true;
            this.ToDate.Location = new System.Drawing.Point(55, 97);
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
            this.ToDate.TabIndex = 297;
            // 
            // FromDate
            // 
            this.FromDate.EditValue = null;
            this.FromDate.EnterMoveNextControl = true;
            this.FromDate.Location = new System.Drawing.Point(56, 67);
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
            this.FromDate.TabIndex = 296;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(33, 100);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(16, 13);
            this.labelControl4.TabIndex = 295;
            this.labelControl4.Text = "To:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(21, 70);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 13);
            this.labelControl5.TabIndex = 294;
            this.labelControl5.Text = "From:";
            // 
            // LedgerType
            // 
            this.LedgerType.Appearance.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LedgerType.Appearance.Options.UseFont = true;
            this.LedgerType.Location = new System.Drawing.Point(156, 3);
            this.LedgerType.Name = "LedgerType";
            this.LedgerType.Size = new System.Drawing.Size(183, 25);
            this.LedgerType.TabIndex = 293;
            this.LedgerType.Text = "Article Bin Card";
            // 
            // ArticleNumber
            // 
            this.ArticleNumber.Location = new System.Drawing.Point(55, 41);
            this.ArticleNumber.Name = "ArticleNumber";
            this.ArticleNumber.Size = new System.Drawing.Size(84, 20);
            this.ArticleNumber.TabIndex = 302;
            this.ArticleNumber.EditValueChanged += new System.EventHandler(this.ArticleNumber_EditValueChanged);
            this.ArticleNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArticleNumber_KeyDown);
            // 
            // WAA
            // 
            this.WAA.Location = new System.Drawing.Point(439, 63);
            this.WAA.Name = "WAA";
            this.WAA.Properties.ReadOnly = true;
            this.WAA.Size = new System.Drawing.Size(84, 20);
            this.WAA.TabIndex = 303;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(403, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 304;
            this.labelControl2.Text = "WAA";
            // 
            // PrintReport
            // 
            this.PrintReport.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintReport.Appearance.Options.UseFont = true;
            this.PrintReport.Image = global::MachineEyes.Properties.Resources.DCNumber;
            this.PrintReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.PrintReport.Location = new System.Drawing.Point(452, 117);
            this.PrintReport.Name = "PrintReport";
            this.PrintReport.Size = new System.Drawing.Size(30, 30);
            this.PrintReport.TabIndex = 301;
            this.PrintReport.Click += new System.EventHandler(this.PrintReport_Click);
            // 
            // CloseForm
            // 
            this.CloseForm.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseForm.Appearance.Options.UseFont = true;
            this.CloseForm.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseForm.Location = new System.Drawing.Point(493, 117);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(30, 30);
            this.CloseForm.TabIndex = 298;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // Towel_ArticleBinCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.WAA);
            this.Controls.Add(this.ArticleNumber);
            this.Controls.Add(this.PrintReport);
            this.Controls.Add(this.Article);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.LedgerType);
            this.Name = "Towel_ArticleBinCard";
            this.Size = new System.Drawing.Size(570, 194);
            this.Load += new System.EventHandler(this.Towel_ArticleBinCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Article.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WAA.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton PrintReport;
        private DevExpress.XtraEditors.TextEdit Article;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
        private DevExpress.XtraEditors.DateEdit ToDate;
        private DevExpress.XtraEditors.DateEdit FromDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LabelControl LedgerType;
        private DevExpress.XtraEditors.TextEdit ArticleNumber;
        private DevExpress.XtraEditors.TextEdit WAA;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
