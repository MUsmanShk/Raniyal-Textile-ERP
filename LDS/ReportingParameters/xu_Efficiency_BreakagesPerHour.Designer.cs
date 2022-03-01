namespace MachineEyes.LDS.ReportingParameters
{
    partial class xu_Efficiency_BreakagesPerHour
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.LoomNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.ShedID = new DevExpress.XtraEditors.TextEdit();
            this.ShedName = new DevExpress.XtraEditors.TextEdit();
            this.ArticleNumber = new DevExpress.XtraEditors.TextEdit();
            this.ToDate = new DevExpress.XtraEditors.DateEdit();
            this.FromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.LedgerType = new DevExpress.XtraEditors.LabelControl();
            this.PrintReport = new DevExpress.XtraEditors.SimpleButton();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoomNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShedID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShedName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ArticleName
            // 
            this.ArticleName.Location = new System.Drawing.Point(216, 41);
            this.ArticleName.Name = "ArticleName";
            this.ArticleName.Properties.ReadOnly = true;
            this.ArticleName.Size = new System.Drawing.Size(308, 20);
            this.ArticleName.TabIndex = 444;
            this.ArticleName.TabStop = false;
            this.ArticleName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArticleName_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(8, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(131, 16);
            this.labelControl1.TabIndex = 442;
            this.labelControl1.Text = "Article";
            // 
            // labelControl21
            // 
            this.labelControl21.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl21.Appearance.Options.UseFont = true;
            this.labelControl21.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl21.LineVisible = true;
            this.labelControl21.Location = new System.Drawing.Point(7, 99);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(131, 17);
            this.labelControl21.TabIndex = 439;
            this.labelControl21.Text = "Loom #";
            // 
            // LoomNumber
            // 
            this.LoomNumber.EnterMoveNextControl = true;
            this.LoomNumber.Location = new System.Drawing.Point(144, 96);
            this.LoomNumber.Name = "LoomNumber";
            this.LoomNumber.Properties.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoomNumber.Properties.Appearance.Options.UseFont = true;
            this.LoomNumber.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.LoomNumber.Properties.MaxLength = 3;
            this.LoomNumber.Size = new System.Drawing.Size(65, 23);
            this.LoomNumber.TabIndex = 2;
            this.LoomNumber.EditValueChanged += new System.EventHandler(this.LoomNumber_EditValueChanged);
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl14.LineVisible = true;
            this.labelControl14.Location = new System.Drawing.Point(7, 73);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(131, 10);
            this.labelControl14.TabIndex = 440;
            this.labelControl14.Text = "Shed";
            // 
            // ShedID
            // 
            this.ShedID.EditValue = "0";
            this.ShedID.EnterMoveNextControl = true;
            this.ShedID.Location = new System.Drawing.Point(144, 67);
            this.ShedID.Name = "ShedID";
            this.ShedID.Properties.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShedID.Properties.Appearance.Options.UseFont = true;
            this.ShedID.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.ShedID.Size = new System.Drawing.Size(32, 23);
            this.ShedID.TabIndex = 1;
            this.ShedID.EditValueChanged += new System.EventHandler(this.ShedID_EditValueChanged);
            // 
            // ShedName
            // 
            this.ShedName.EnterMoveNextControl = true;
            this.ShedName.Location = new System.Drawing.Point(182, 67);
            this.ShedName.Name = "ShedName";
            this.ShedName.Properties.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShedName.Properties.Appearance.Options.UseFont = true;
            this.ShedName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.ShedName.Properties.ReadOnly = true;
            this.ShedName.Size = new System.Drawing.Size(138, 23);
            this.ShedName.TabIndex = 441;
            this.ShedName.TabStop = false;
            // 
            // ArticleNumber
            // 
            this.ArticleNumber.EnterMoveNextControl = true;
            this.ArticleNumber.Location = new System.Drawing.Point(145, 41);
            this.ArticleNumber.Name = "ArticleNumber";
            this.ArticleNumber.Size = new System.Drawing.Size(65, 20);
            this.ArticleNumber.TabIndex = 0;
            this.ArticleNumber.EditValueChanged += new System.EventHandler(this.ArticleNumber_EditValueChanged);
            this.ArticleNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArticleNumber_KeyDown);
            // 
            // ToDate
            // 
            this.ToDate.EditValue = null;
            this.ToDate.EnterMoveNextControl = true;
            this.ToDate.Location = new System.Drawing.Point(143, 155);
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
            this.ToDate.TabIndex = 4;
            // 
            // FromDate
            // 
            this.FromDate.EditValue = null;
            this.FromDate.EnterMoveNextControl = true;
            this.FromDate.Location = new System.Drawing.Point(144, 125);
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
            this.FromDate.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(116, 158);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(16, 13);
            this.labelControl4.TabIndex = 438;
            this.labelControl4.Text = "To:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(104, 128);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 13);
            this.labelControl5.TabIndex = 437;
            this.labelControl5.Text = "From:";
            // 
            // LedgerType
            // 
            this.LedgerType.Appearance.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LedgerType.Appearance.Options.UseFont = true;
            this.LedgerType.Location = new System.Drawing.Point(105, 3);
            this.LedgerType.Name = "LedgerType";
            this.LedgerType.Size = new System.Drawing.Size(279, 25);
            this.LedgerType.TabIndex = 436;
            this.LedgerType.Text = "Breakages / Hour Report";
            // 
            // PrintReport
            // 
            this.PrintReport.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintReport.Appearance.Options.UseFont = true;
            this.PrintReport.Image = global::MachineEyes.Properties.Resources.DCNumber;
            this.PrintReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.PrintReport.Location = new System.Drawing.Point(453, 171);
            this.PrintReport.Name = "PrintReport";
            this.PrintReport.Size = new System.Drawing.Size(30, 30);
            this.PrintReport.TabIndex = 5;
            this.PrintReport.Click += new System.EventHandler(this.PrintReport_Click);
            // 
            // CloseForm
            // 
            this.CloseForm.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseForm.Appearance.Options.UseFont = true;
            this.CloseForm.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseForm.Location = new System.Drawing.Point(494, 171);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(30, 30);
            this.CloseForm.TabIndex = 6;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // xu_Efficiency_BreakagesPerHour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ArticleName);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl21);
            this.Controls.Add(this.LoomNumber);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.ShedID);
            this.Controls.Add(this.ShedName);
            this.Controls.Add(this.PrintReport);
            this.Controls.Add(this.ArticleNumber);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.LedgerType);
            this.Name = "xu_Efficiency_BreakagesPerHour";
            this.Size = new System.Drawing.Size(589, 267);
            this.Load += new System.EventHandler(this.xu_Efficiency_BreakagesPerHour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ArticleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoomNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShedID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShedName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit ArticleName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.TextEdit LoomNumber;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.TextEdit ShedID;
        private DevExpress.XtraEditors.TextEdit ShedName;
        private DevExpress.XtraEditors.SimpleButton PrintReport;
        private DevExpress.XtraEditors.TextEdit ArticleNumber;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
        private DevExpress.XtraEditors.DateEdit ToDate;
        private DevExpress.XtraEditors.DateEdit FromDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LabelControl LedgerType;
    }
}
