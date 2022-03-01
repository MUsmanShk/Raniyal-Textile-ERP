namespace MachineEyes.Accounts.ReportingParameters
{
    partial class xu_ChangeStatus
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
            this.NewStatus = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.DocumentNumber = new DevExpress.XtraEditors.LabelControl();
            this.CurrentStatus = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.Proceed = new DevExpress.XtraEditors.SimpleButton();
            this.Closeit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.NewStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // NewStatus
            // 
            this.NewStatus.Location = new System.Drawing.Point(3, 3);
            this.NewStatus.Name = "NewStatus";
            this.NewStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("U", "Change to Unposted"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("P", "Change to Posted"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("A", "Change to Audited")});
            this.NewStatus.Size = new System.Drawing.Size(193, 96);
            this.NewStatus.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(205, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Document Number";
            // 
            // DocumentNumber
            // 
            this.DocumentNumber.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.DocumentNumber.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.DocumentNumber.Location = new System.Drawing.Point(230, 19);
            this.DocumentNumber.Name = "DocumentNumber";
            this.DocumentNumber.Size = new System.Drawing.Size(131, 19);
            this.DocumentNumber.TabIndex = 2;
            this.DocumentNumber.Text = "XXXXXXX";
            // 
            // CurrentStatus
            // 
            this.CurrentStatus.Appearance.Options.UseTextOptions = true;
            this.CurrentStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CurrentStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.CurrentStatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.CurrentStatus.Location = new System.Drawing.Point(230, 55);
            this.CurrentStatus.Name = "CurrentStatus";
            this.CurrentStatus.Size = new System.Drawing.Size(46, 15);
            this.CurrentStatus.TabIndex = 4;
            this.CurrentStatus.Text = "U";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(205, 38);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(71, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Current Status";
            // 
            // Proceed
            // 
            this.Proceed.Location = new System.Drawing.Point(205, 76);
            this.Proceed.Name = "Proceed";
            this.Proceed.Size = new System.Drawing.Size(75, 23);
            this.Proceed.TabIndex = 5;
            this.Proceed.Text = "Proceed";
            this.Proceed.Click += new System.EventHandler(this.Proceed_Click);
            // 
            // Closeit
            // 
            this.Closeit.Location = new System.Drawing.Point(286, 76);
            this.Closeit.Name = "Closeit";
            this.Closeit.Size = new System.Drawing.Size(75, 23);
            this.Closeit.TabIndex = 6;
            this.Closeit.Text = "Close";
            this.Closeit.Click += new System.EventHandler(this.Closeit_Click);
            // 
            // xu_ChangeStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Closeit);
            this.Controls.Add(this.Proceed);
            this.Controls.Add(this.CurrentStatus);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.DocumentNumber);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.NewStatus);
            this.Name = "xu_ChangeStatus";
            this.Size = new System.Drawing.Size(372, 108);
            ((System.ComponentModel.ISupportInitialize)(this.NewStatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup NewStatus;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton Proceed;
        private DevExpress.XtraEditors.SimpleButton Closeit;
        public DevExpress.XtraEditors.LabelControl DocumentNumber;
        public DevExpress.XtraEditors.LabelControl CurrentStatus;
    }
}
