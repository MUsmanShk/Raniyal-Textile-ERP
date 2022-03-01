namespace MachineEyes
{
    partial class dxRange
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
            this.RangeColor = new DevExpress.XtraEditors.SimpleButton();
            this.RangeFrom = new DevExpress.XtraEditors.SpinEdit();
            this.RangeEG = new DevExpress.XtraEditors.SimpleButton();
            this.rangeFromcap = new DevExpress.XtraEditors.SimpleButton();
            this.RangeTo = new DevExpress.XtraEditors.SpinEdit();
            this.rangeToCap = new DevExpress.XtraEditors.SimpleButton();
            this.IndexNumber = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.RangeFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // RangeColor
            // 
            this.RangeColor.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RangeColor.Appearance.Options.UseFont = true;
            this.RangeColor.ImageIndex = 0;
            this.RangeColor.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.RangeColor.Location = new System.Drawing.Point(462, 3);
            this.RangeColor.Name = "RangeColor";
            this.RangeColor.Size = new System.Drawing.Size(50, 20);
            this.RangeColor.TabIndex = 15;
            this.RangeColor.Text = "87.2%";
            // 
            // RangeFrom
            // 
            this.RangeFrom.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RangeFrom.Location = new System.Drawing.Point(190, 3);
            this.RangeFrom.Name = "RangeFrom";
            this.RangeFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.RangeFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.RangeFrom.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.RangeFrom.Size = new System.Drawing.Size(56, 20);
            this.RangeFrom.TabIndex = 13;
            this.RangeFrom.ValueChanged += new System.EventHandler(this.RangeFrom_ValueChanged);
            // 
            // RangeEG
            // 
            this.RangeEG.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RangeEG.Appearance.Options.UseFont = true;
            this.RangeEG.ImageIndex = 0;
            this.RangeEG.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.RangeEG.Location = new System.Drawing.Point(427, 3);
            this.RangeEG.Name = "RangeEG";
            this.RangeEG.Size = new System.Drawing.Size(36, 20);
            this.RangeEG.TabIndex = 17;
            this.RangeEG.Text = "e.g";
            // 
            // rangeFromcap
            // 
            this.rangeFromcap.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeFromcap.Appearance.Options.UseFont = true;
            this.rangeFromcap.Appearance.Options.UseTextOptions = true;
            this.rangeFromcap.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rangeFromcap.ImageIndex = 0;
            this.rangeFromcap.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.rangeFromcap.Location = new System.Drawing.Point(49, 3);
            this.rangeFromcap.Name = "rangeFromcap";
            this.rangeFromcap.Size = new System.Drawing.Size(135, 20);
            this.rangeFromcap.TabIndex = 18;
            this.rangeFromcap.Text = "Range From";
            // 
            // RangeTo
            // 
            this.RangeTo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RangeTo.Location = new System.Drawing.Point(365, 3);
            this.RangeTo.Name = "RangeTo";
            this.RangeTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.RangeTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.RangeTo.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.RangeTo.Size = new System.Drawing.Size(56, 20);
            this.RangeTo.TabIndex = 19;
            this.RangeTo.ValueChanged += new System.EventHandler(this.RangeFrom_ValueChanged);
            // 
            // rangeToCap
            // 
            this.rangeToCap.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeToCap.Appearance.Options.UseFont = true;
            this.rangeToCap.Appearance.Options.UseTextOptions = true;
            this.rangeToCap.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.rangeToCap.ImageIndex = 0;
            this.rangeToCap.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.rangeToCap.Location = new System.Drawing.Point(254, 3);
            this.rangeToCap.Name = "rangeToCap";
            this.rangeToCap.Size = new System.Drawing.Size(105, 20);
            this.rangeToCap.TabIndex = 20;
            this.rangeToCap.Text = "Range upto";
            // 
            // IndexNumber
            // 
            this.IndexNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndexNumber.Appearance.Options.UseFont = true;
            this.IndexNumber.ImageIndex = 0;
            this.IndexNumber.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.IndexNumber.Location = new System.Drawing.Point(3, 2);
            this.IndexNumber.Name = "IndexNumber";
            this.IndexNumber.Size = new System.Drawing.Size(36, 20);
            this.IndexNumber.TabIndex = 21;
            this.IndexNumber.Text = "1";
            // 
            // dxRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IndexNumber);
            this.Controls.Add(this.rangeToCap);
            this.Controls.Add(this.RangeTo);
            this.Controls.Add(this.rangeFromcap);
            this.Controls.Add(this.RangeEG);
            this.Controls.Add(this.RangeColor);
            this.Controls.Add(this.RangeFrom);
            this.Name = "dxRange";
            this.Size = new System.Drawing.Size(519, 25);
            this.Enter += new System.EventHandler(this.dxRange_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.RangeFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeTo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton RangeColor;
        public DevExpress.XtraEditors.SimpleButton RangeEG;
        public DevExpress.XtraEditors.SimpleButton rangeFromcap;
        public DevExpress.XtraEditors.SimpleButton rangeToCap;
        public DevExpress.XtraEditors.SpinEdit RangeFrom;
        public DevExpress.XtraEditors.SpinEdit RangeTo;
        public DevExpress.XtraEditors.SimpleButton IndexNumber;
    }
}
