namespace MachineEyes.Data
{
    partial class Report_YarnStockLedger
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report_YarnStockLedger));
            this.Accountof = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.DateFrom = new DevExpress.XtraEditors.DateEdit();
            this.DateTo = new DevExpress.XtraEditors.DateEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.Ledger = new DevExpress.XtraEditors.SimpleButton();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            this.Print = new DevExpress.XtraEditors.SimpleButton();
            this.RadioTypeofReport = new DevExpress.XtraEditors.RadioGroup();
            this.BrowseAccountof = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Accountof.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RadioTypeofReport.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Accountof
            // 
            this.Accountof.Location = new System.Drawing.Point(128, 22);
            this.Accountof.Name = "Accountof";
            this.Accountof.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accountof.Properties.Appearance.Options.UseFont = true;
            this.Accountof.Properties.MaxLength = 50;
            this.Accountof.Size = new System.Drawing.Size(263, 26);
            this.Accountof.TabIndex = 169;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(110, 19);
            this.labelControl1.TabIndex = 174;
            this.labelControl1.Text = "Ledger Account";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 72);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(112, 19);
            this.labelControl2.TabIndex = 175;
            this.labelControl2.Text = "Effective From :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 113);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(109, 19);
            this.labelControl3.TabIndex = 176;
            this.labelControl3.Text = "Effective Upto :";
            // 
            // DateFrom
            // 
            this.DateFrom.EditValue = null;
            this.DateFrom.Location = new System.Drawing.Point(128, 69);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateFrom.Properties.Appearance.Options.UseFont = true;
            this.DateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateFrom.Size = new System.Drawing.Size(230, 26);
            this.DateFrom.TabIndex = 177;
            // 
            // DateTo
            // 
            this.DateTo.EditValue = null;
            this.DateTo.Location = new System.Drawing.Point(128, 110);
            this.DateTo.Name = "DateTo";
            this.DateTo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTo.Properties.Appearance.Options.UseFont = true;
            this.DateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateTo.Size = new System.Drawing.Size(230, 26);
            this.DateTo.TabIndex = 178;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.Ledger);
            this.groupControl1.Controls.Add(this.CloseForm);
            this.groupControl1.Controls.Add(this.Print);
            this.groupControl1.Location = new System.Drawing.Point(128, 156);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(195, 63);
            this.groupControl1.TabIndex = 179;
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // Ledger
            // 
            this.Ledger.Image = global::MachineEyes.Properties.Resources.Doc_State32;
            this.Ledger.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Ledger.Location = new System.Drawing.Point(68, 4);
            this.Ledger.Name = "Ledger";
            this.Ledger.Size = new System.Drawing.Size(57, 55);
            this.Ledger.TabIndex = 65;
            this.Ledger.TabStop = false;
            this.Ledger.Text = "Ledger";
            this.Ledger.Click += new System.EventHandler(this.Ledger_Click);
            // 
            // CloseForm
            // 
            this.CloseForm.Image = ((System.Drawing.Image)(resources.GetObject("CloseForm.Image")));
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.CloseForm.Location = new System.Drawing.Point(131, 4);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(57, 55);
            this.CloseForm.TabIndex = 7;
            this.CloseForm.TabStop = false;
            this.CloseForm.Text = "Close";
            this.CloseForm.Click += new System.EventHandler(this.Close_Click);
            // 
            // Print
            // 
            this.Print.Image = ((System.Drawing.Image)(resources.GetObject("Print.Image")));
            this.Print.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Print.Location = new System.Drawing.Point(5, 4);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(57, 55);
            this.Print.TabIndex = 64;
            this.Print.TabStop = false;
            this.Print.Text = "Stock";
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // RadioTypeofReport
            // 
            this.RadioTypeofReport.EditValue = "L";
            this.RadioTypeofReport.Location = new System.Drawing.Point(329, 156);
            this.RadioTypeofReport.Name = "RadioTypeofReport";
            this.RadioTypeofReport.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("L", "Lbs Only"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("B", "Print with Bags")});
            this.RadioTypeofReport.Size = new System.Drawing.Size(140, 63);
            this.RadioTypeofReport.TabIndex = 180;
            this.RadioTypeofReport.SelectedIndexChanged += new System.EventHandler(this.RadioPageSetting_SelectedIndexChanged);
            // 
            // BrowseAccountof
            // 
            this.BrowseAccountof.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseAccountof.Appearance.Options.UseFont = true;
            this.BrowseAccountof.Image = global::MachineEyes.Properties.Resources.browse;
            this.BrowseAccountof.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.BrowseAccountof.Location = new System.Drawing.Point(397, 22);
            this.BrowseAccountof.Name = "BrowseAccountof";
            this.BrowseAccountof.Size = new System.Drawing.Size(26, 26);
            this.BrowseAccountof.TabIndex = 173;
            this.BrowseAccountof.TabStop = false;
            this.BrowseAccountof.Click += new System.EventHandler(this.BrowseAccountof_Click);
            // 
            // Report_YarnStockLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 220);
            this.ControlBox = false;
            this.Controls.Add(this.RadioTypeofReport);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.DateTo);
            this.Controls.Add(this.DateFrom);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.BrowseAccountof);
            this.Controls.Add(this.Accountof);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Report_YarnStockLedger";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yarn Stock Ledger";
            this.Load += new System.EventHandler(this.Report_YarnStockLedger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Accountof.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RadioTypeofReport.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BrowseAccountof;
        private DevExpress.XtraEditors.TextEdit Accountof;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit DateFrom;
        private DevExpress.XtraEditors.DateEdit DateTo;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
        private DevExpress.XtraEditors.SimpleButton Print;
        private DevExpress.XtraEditors.SimpleButton Ledger;
        private DevExpress.XtraEditors.RadioGroup RadioTypeofReport;
    }
}