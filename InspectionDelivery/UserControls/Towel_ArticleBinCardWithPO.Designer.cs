namespace MachineEyes.InspectionDelivery.UserControls
{
    partial class Towel_ArticleBinCardWithPO
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.WAA = new DevExpress.XtraEditors.TextEdit();
            this.ToDate = new DevExpress.XtraEditors.DateEdit();
            this.FromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.LedgerType = new DevExpress.XtraEditors.LabelControl();
            this.PrintReport = new DevExpress.XtraEditors.SimpleButton();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            this.PONO = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.PartyName = new DevExpress.XtraEditors.TextEdit();
            this.PartyID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.ArticleShortName = new DevExpress.XtraEditors.TextEdit();
            this.ArticleNumber = new DevExpress.XtraEditors.TextEdit();
            this.LabelItemAccount = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.WAA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PONO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartyID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(380, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 316;
            this.labelControl2.Text = "WAA";
            // 
            // WAA
            // 
            this.WAA.Location = new System.Drawing.Point(416, 89);
            this.WAA.Name = "WAA";
            this.WAA.Properties.ReadOnly = true;
            this.WAA.Size = new System.Drawing.Size(84, 20);
            this.WAA.TabIndex = 315;
            // 
            // ToDate
            // 
            this.ToDate.EditValue = null;
            this.ToDate.EnterMoveNextControl = true;
            this.ToDate.Location = new System.Drawing.Point(188, 145);
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
            this.ToDate.TabIndex = 309;
            // 
            // FromDate
            // 
            this.FromDate.EditValue = null;
            this.FromDate.EnterMoveNextControl = true;
            this.FromDate.Location = new System.Drawing.Point(189, 115);
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
            this.FromDate.TabIndex = 308;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(166, 148);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(16, 13);
            this.labelControl4.TabIndex = 307;
            this.labelControl4.Text = "To:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(154, 118);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 13);
            this.labelControl5.TabIndex = 306;
            this.labelControl5.Text = "From:";
            // 
            // LedgerType
            // 
            this.LedgerType.Appearance.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LedgerType.Appearance.Options.UseFont = true;
            this.LedgerType.Location = new System.Drawing.Point(165, 6);
            this.LedgerType.Name = "LedgerType";
            this.LedgerType.Size = new System.Drawing.Size(322, 25);
            this.LedgerType.TabIndex = 305;
            this.LedgerType.Text = "Article Bin Card Specified PO";
            // 
            // PrintReport
            // 
            this.PrintReport.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintReport.Appearance.Options.UseFont = true;
            this.PrintReport.Image = global::MachineEyes.Properties.Resources.DCNumber;
            this.PrintReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.PrintReport.Location = new System.Drawing.Point(429, 135);
            this.PrintReport.Name = "PrintReport";
            this.PrintReport.Size = new System.Drawing.Size(30, 30);
            this.PrintReport.TabIndex = 313;
            this.PrintReport.Click += new System.EventHandler(this.PrintReport_Click);
            // 
            // CloseForm
            // 
            this.CloseForm.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseForm.Appearance.Options.UseFont = true;
            this.CloseForm.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseForm.Location = new System.Drawing.Point(470, 135);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(30, 30);
            this.CloseForm.TabIndex = 310;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // PONO
            // 
            this.PONO.EnterMoveNextControl = true;
            this.PONO.Location = new System.Drawing.Point(189, 86);
            this.PONO.Name = "PONO";
            this.PONO.Properties.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PONO.Properties.Appearance.Options.UseFont = true;
            this.PONO.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.PONO.Properties.MaxLength = 13;
            this.PONO.Properties.ReadOnly = true;
            this.PONO.Size = new System.Drawing.Size(179, 23);
            this.PONO.TabIndex = 396;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(10, 89);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(163, 17);
            this.labelControl1.TabIndex = 400;
            this.labelControl1.Text = "Contract / PO #";
            // 
            // PartyName
            // 
            this.PartyName.EnterMoveNextControl = true;
            this.PartyName.Location = new System.Drawing.Point(274, 61);
            this.PartyName.Name = "PartyName";
            this.PartyName.Properties.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartyName.Properties.Appearance.Options.UseFont = true;
            this.PartyName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.PartyName.Properties.MaxLength = 160;
            this.PartyName.Properties.ReadOnly = true;
            this.PartyName.Size = new System.Drawing.Size(386, 23);
            this.PartyName.TabIndex = 398;
            this.PartyName.TabStop = false;
            // 
            // PartyID
            // 
            this.PartyID.EnterMoveNextControl = true;
            this.PartyID.Location = new System.Drawing.Point(189, 61);
            this.PartyID.Name = "PartyID";
            this.PartyID.Properties.Appearance.BackColor = System.Drawing.Color.Yellow;
            this.PartyID.Properties.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartyID.Properties.Appearance.Options.UseBackColor = true;
            this.PartyID.Properties.Appearance.Options.UseFont = true;
            this.PartyID.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.PartyID.Properties.MaxLength = 10;
            this.PartyID.Size = new System.Drawing.Size(86, 23);
            this.PartyID.TabIndex = 395;
            this.PartyID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PartyID_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(11, 64);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(163, 17);
            this.labelControl3.TabIndex = 399;
            this.labelControl3.Text = "Party ID";
            // 
            // ArticleShortName
            // 
            this.ArticleShortName.EnterMoveNextControl = true;
            this.ArticleShortName.Location = new System.Drawing.Point(274, 37);
            this.ArticleShortName.Name = "ArticleShortName";
            this.ArticleShortName.Properties.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArticleShortName.Properties.Appearance.Options.UseFont = true;
            this.ArticleShortName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.ArticleShortName.Properties.MaxLength = 160;
            this.ArticleShortName.Properties.ReadOnly = true;
            this.ArticleShortName.Size = new System.Drawing.Size(386, 23);
            this.ArticleShortName.TabIndex = 393;
            this.ArticleShortName.TabStop = false;
            // 
            // ArticleNumber
            // 
            this.ArticleNumber.EnterMoveNextControl = true;
            this.ArticleNumber.Location = new System.Drawing.Point(189, 37);
            this.ArticleNumber.Name = "ArticleNumber";
            this.ArticleNumber.Properties.Appearance.BackColor = System.Drawing.Color.Yellow;
            this.ArticleNumber.Properties.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArticleNumber.Properties.Appearance.Options.UseBackColor = true;
            this.ArticleNumber.Properties.Appearance.Options.UseFont = true;
            this.ArticleNumber.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.ArticleNumber.Properties.MaxLength = 10;
            this.ArticleNumber.Size = new System.Drawing.Size(86, 23);
            this.ArticleNumber.TabIndex = 394;
            this.ArticleNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArticleNumber_KeyDown);
            // 
            // LabelItemAccount
            // 
            this.LabelItemAccount.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelItemAccount.Appearance.Options.UseFont = true;
            this.LabelItemAccount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LabelItemAccount.LineVisible = true;
            this.LabelItemAccount.Location = new System.Drawing.Point(10, 40);
            this.LabelItemAccount.Name = "LabelItemAccount";
            this.LabelItemAccount.Size = new System.Drawing.Size(163, 17);
            this.LabelItemAccount.TabIndex = 397;
            this.LabelItemAccount.Text = "Article #";
            // 
            // Towel_ArticleBinCardWithPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PONO);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.PartyName);
            this.Controls.Add(this.PartyID);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.ArticleShortName);
            this.Controls.Add(this.ArticleNumber);
            this.Controls.Add(this.LabelItemAccount);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.WAA);
            this.Controls.Add(this.PrintReport);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.LedgerType);
            this.Name = "Towel_ArticleBinCardWithPO";
            this.Size = new System.Drawing.Size(782, 252);
            ((System.ComponentModel.ISupportInitialize)(this.WAA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PONO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartyID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleNumber.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit WAA;
        private DevExpress.XtraEditors.SimpleButton PrintReport;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
        private DevExpress.XtraEditors.DateEdit ToDate;
        private DevExpress.XtraEditors.DateEdit FromDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LabelControl LedgerType;
        private DevExpress.XtraEditors.TextEdit PONO;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit PartyName;
        private DevExpress.XtraEditors.TextEdit PartyID;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit ArticleShortName;
        private DevExpress.XtraEditors.TextEdit ArticleNumber;
        private DevExpress.XtraEditors.LabelControl LabelItemAccount;
    }
}
