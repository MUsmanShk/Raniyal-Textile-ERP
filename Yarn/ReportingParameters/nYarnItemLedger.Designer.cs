namespace MachineEyes.Yarn.ReportingParameters
{
    partial class nYarnItemLedger
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Accountof = new DevExpress.XtraEditors.TextEdit();
            this.ToDate = new DevExpress.XtraEditors.DateEdit();
            this.FromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.YarnBrand = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.BagsType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.YarnDesc = new DevExpress.XtraEditors.LookUpEdit();
            this.LblYarnCount1 = new DevExpress.XtraEditors.LabelControl();
            this.LblPly1 = new DevExpress.XtraEditors.LabelControl();
            this.LblYarnBlend1 = new DevExpress.XtraEditors.LabelControl();
            this.LblYarnDesc1 = new DevExpress.XtraEditors.LabelControl();
            this.YarnCount = new DevExpress.XtraEditors.LookUpEdit();
            this.YarnBlend = new DevExpress.XtraEditors.LookUpEdit();
            this.YarnPly = new DevExpress.XtraEditors.TextEdit();
            this.IncludeCommercialSizing = new DevExpress.XtraEditors.CheckEdit();
            this.PrintReport = new DevExpress.XtraEditors.SimpleButton();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Accountof.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YarnBrand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BagsType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YarnDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YarnCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YarnBlend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YarnPly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncludeCommercialSizing.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(26, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(98, 19);
            this.labelControl1.TabIndex = 269;
            this.labelControl1.Text = "Party Account";
            // 
            // Accountof
            // 
            this.Accountof.EnterMoveNextControl = true;
            this.Accountof.Location = new System.Drawing.Point(174, 29);
            this.Accountof.Name = "Accountof";
            this.Accountof.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accountof.Properties.Appearance.Options.UseFont = true;
            this.Accountof.Properties.ReadOnly = true;
            this.Accountof.Size = new System.Drawing.Size(333, 26);
            this.Accountof.TabIndex = 0;
            this.Accountof.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Accountof_KeyDown);
            // 
            // ToDate
            // 
            this.ToDate.EditValue = null;
            this.ToDate.EnterMoveNextControl = true;
            this.ToDate.Location = new System.Drawing.Point(173, 142);
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
            this.ToDate.TabIndex = 2;
            // 
            // FromDate
            // 
            this.FromDate.EditValue = null;
            this.FromDate.EnterMoveNextControl = true;
            this.FromDate.Location = new System.Drawing.Point(174, 112);
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
            this.FromDate.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.LineVisible = true;
            this.labelControl4.Location = new System.Drawing.Point(26, 148);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(140, 10);
            this.labelControl4.TabIndex = 264;
            this.labelControl4.Text = "To:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.LineVisible = true;
            this.labelControl5.Location = new System.Drawing.Point(26, 118);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(140, 10);
            this.labelControl5.TabIndex = 263;
            this.labelControl5.Text = "From:";
            // 
            // YarnBrand
            // 
            this.YarnBrand.EnterMoveNextControl = true;
            this.YarnBrand.Location = new System.Drawing.Point(172, 281);
            this.YarnBrand.Name = "YarnBrand";
            this.YarnBrand.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnBrand.Properties.Appearance.Options.UseFont = true;
            this.YarnBrand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.YarnBrand.Properties.NullText = "";
            this.YarnBrand.Properties.NullValuePrompt = "Brand";
            this.YarnBrand.Properties.NullValuePromptShowForEmptyValue = true;
            this.YarnBrand.Size = new System.Drawing.Size(175, 20);
            this.YarnBrand.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(26, 291);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(140, 10);
            this.labelControl3.TabIndex = 281;
            this.labelControl3.Text = "Brand";
            // 
            // BagsType
            // 
            this.BagsType.EnterMoveNextControl = true;
            this.BagsType.Location = new System.Drawing.Point(173, 168);
            this.BagsType.Name = "BagsType";
            this.BagsType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BagsType.Properties.Appearance.Options.UseFont = true;
            this.BagsType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BagsType.Properties.NullText = "";
            this.BagsType.Properties.NullValuePrompt = "Bags Type";
            this.BagsType.Properties.NullValuePromptShowForEmptyValue = true;
            this.BagsType.Size = new System.Drawing.Size(97, 20);
            this.BagsType.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(26, 164);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(140, 29);
            this.labelControl2.TabIndex = 279;
            this.labelControl2.Text = "Bags Type:";
            // 
            // YarnDesc
            // 
            this.YarnDesc.EnterMoveNextControl = true;
            this.YarnDesc.Location = new System.Drawing.Point(172, 255);
            this.YarnDesc.Name = "YarnDesc";
            this.YarnDesc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnDesc.Properties.Appearance.Options.UseFont = true;
            this.YarnDesc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.YarnDesc.Properties.NullText = "";
            this.YarnDesc.Properties.NullValuePrompt = "Description";
            this.YarnDesc.Properties.NullValuePromptShowForEmptyValue = true;
            this.YarnDesc.Size = new System.Drawing.Size(175, 20);
            this.YarnDesc.TabIndex = 7;
            // 
            // LblYarnCount1
            // 
            this.LblYarnCount1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYarnCount1.Appearance.Options.UseFont = true;
            this.LblYarnCount1.Appearance.Options.UseTextOptions = true;
            this.LblYarnCount1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LblYarnCount1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblYarnCount1.LineVisible = true;
            this.LblYarnCount1.Location = new System.Drawing.Point(26, 209);
            this.LblYarnCount1.Name = "LblYarnCount1";
            this.LblYarnCount1.Size = new System.Drawing.Size(140, 10);
            this.LblYarnCount1.TabIndex = 275;
            this.LblYarnCount1.Text = "Yarn Count:";
            // 
            // LblPly1
            // 
            this.LblPly1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPly1.Appearance.Options.UseFont = true;
            this.LblPly1.Location = new System.Drawing.Point(276, 206);
            this.LblPly1.Name = "LblPly1";
            this.LblPly1.Size = new System.Drawing.Size(18, 13);
            this.LblPly1.TabIndex = 277;
            this.LblPly1.Text = "Ply:";
            // 
            // LblYarnBlend1
            // 
            this.LblYarnBlend1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYarnBlend1.Appearance.Options.UseFont = true;
            this.LblYarnBlend1.Appearance.Options.UseTextOptions = true;
            this.LblYarnBlend1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LblYarnBlend1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblYarnBlend1.LineVisible = true;
            this.LblYarnBlend1.Location = new System.Drawing.Point(26, 235);
            this.LblYarnBlend1.Name = "LblYarnBlend1";
            this.LblYarnBlend1.Size = new System.Drawing.Size(140, 10);
            this.LblYarnBlend1.TabIndex = 278;
            this.LblYarnBlend1.Text = "Blend:";
            // 
            // LblYarnDesc1
            // 
            this.LblYarnDesc1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYarnDesc1.Appearance.Options.UseFont = true;
            this.LblYarnDesc1.Appearance.Options.UseTextOptions = true;
            this.LblYarnDesc1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LblYarnDesc1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblYarnDesc1.LineVisible = true;
            this.LblYarnDesc1.Location = new System.Drawing.Point(26, 261);
            this.LblYarnDesc1.Name = "LblYarnDesc1";
            this.LblYarnDesc1.Size = new System.Drawing.Size(140, 10);
            this.LblYarnDesc1.TabIndex = 276;
            this.LblYarnDesc1.Text = "Yarn Desc.:";
            // 
            // YarnCount
            // 
            this.YarnCount.EnterMoveNextControl = true;
            this.YarnCount.Location = new System.Drawing.Point(173, 203);
            this.YarnCount.Name = "YarnCount";
            this.YarnCount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnCount.Properties.Appearance.Options.UseFont = true;
            this.YarnCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.YarnCount.Properties.NullText = "";
            this.YarnCount.Properties.NullValuePrompt = "Count";
            this.YarnCount.Properties.NullValuePromptShowForEmptyValue = true;
            this.YarnCount.Size = new System.Drawing.Size(97, 20);
            this.YarnCount.TabIndex = 4;
            // 
            // YarnBlend
            // 
            this.YarnBlend.EnterMoveNextControl = true;
            this.YarnBlend.Location = new System.Drawing.Point(173, 229);
            this.YarnBlend.Name = "YarnBlend";
            this.YarnBlend.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnBlend.Properties.Appearance.Options.UseFont = true;
            this.YarnBlend.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.YarnBlend.Properties.NullText = "";
            this.YarnBlend.Properties.NullValuePrompt = "Blend";
            this.YarnBlend.Properties.NullValuePromptShowForEmptyValue = true;
            this.YarnBlend.Size = new System.Drawing.Size(174, 20);
            this.YarnBlend.TabIndex = 6;
            // 
            // YarnPly
            // 
            this.YarnPly.EditValue = "1";
            this.YarnPly.EnterMoveNextControl = true;
            this.YarnPly.Location = new System.Drawing.Point(300, 203);
            this.YarnPly.Name = "YarnPly";
            this.YarnPly.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnPly.Properties.Appearance.Options.UseFont = true;
            this.YarnPly.Properties.MaxLength = 50;
            this.YarnPly.Size = new System.Drawing.Size(47, 20);
            this.YarnPly.TabIndex = 5;
            // 
            // IncludeCommercialSizing
            // 
            this.IncludeCommercialSizing.Location = new System.Drawing.Point(175, 68);
            this.IncludeCommercialSizing.Name = "IncludeCommercialSizing";
            this.IncludeCommercialSizing.Properties.Caption = "Include Commerical Sizing";
            this.IncludeCommercialSizing.Size = new System.Drawing.Size(171, 18);
            this.IncludeCommercialSizing.TabIndex = 282;
            // 
            // PrintReport
            // 
            this.PrintReport.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintReport.Appearance.Options.UseFont = true;
            this.PrintReport.Image = global::MachineEyes.Properties.Resources.down16x16;
            this.PrintReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.PrintReport.Location = new System.Drawing.Point(281, 318);
            this.PrintReport.Name = "PrintReport";
            this.PrintReport.Size = new System.Drawing.Size(30, 30);
            this.PrintReport.TabIndex = 9;
            this.PrintReport.Click += new System.EventHandler(this.PrintReport_Click);
            // 
            // CloseForm
            // 
            this.CloseForm.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseForm.Appearance.Options.UseFont = true;
            this.CloseForm.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseForm.Location = new System.Drawing.Point(317, 318);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(30, 30);
            this.CloseForm.TabIndex = 10;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // nYarnItemLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IncludeCommercialSizing);
            this.Controls.Add(this.YarnBrand);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.BagsType);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.YarnDesc);
            this.Controls.Add(this.LblYarnCount1);
            this.Controls.Add(this.LblPly1);
            this.Controls.Add(this.LblYarnBlend1);
            this.Controls.Add(this.LblYarnDesc1);
            this.Controls.Add(this.YarnCount);
            this.Controls.Add(this.YarnBlend);
            this.Controls.Add(this.YarnPly);
            this.Controls.Add(this.PrintReport);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Accountof);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Name = "nYarnItemLedger";
            this.Size = new System.Drawing.Size(564, 366);
            this.Load += new System.EventHandler(this.nYarnItemLedger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Accountof.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YarnBrand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BagsType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YarnDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YarnCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YarnBlend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YarnPly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncludeCommercialSizing.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton PrintReport;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit Accountof;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
        private DevExpress.XtraEditors.DateEdit ToDate;
        private DevExpress.XtraEditors.DateEdit FromDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit YarnBrand;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit BagsType;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit YarnDesc;
        private DevExpress.XtraEditors.LabelControl LblYarnCount1;
        private DevExpress.XtraEditors.LabelControl LblPly1;
        private DevExpress.XtraEditors.LabelControl LblYarnBlend1;
        private DevExpress.XtraEditors.LabelControl LblYarnDesc1;
        private DevExpress.XtraEditors.LookUpEdit YarnCount;
        private DevExpress.XtraEditors.LookUpEdit YarnBlend;
        private DevExpress.XtraEditors.TextEdit YarnPly;
        private DevExpress.XtraEditors.CheckEdit IncludeCommercialSizing;
    }
}
