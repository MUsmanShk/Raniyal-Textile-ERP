namespace MachineEyes
{
    partial class dxWeaverEff
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
            this.Looms = new DevExpress.XtraEditors.SimpleButton();
            this.AvgWeftKnott = new DevExpress.XtraEditors.SimpleButton();
            this.WeaverName = new DevExpress.XtraEditors.SimpleButton();
            this.AvgWarpKnott = new DevExpress.XtraEditors.SimpleButton();
            this.WeaverEff = new DevExpress.XtraEditors.SimpleButton();
            this.IndexNumber = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // Looms
            // 
            this.Looms.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Looms.Appearance.Options.UseFont = true;
            this.Looms.Appearance.Options.UseTextOptions = true;
            this.Looms.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Looms.Location = new System.Drawing.Point(244, 1);
            this.Looms.Name = "Looms";
            this.Looms.Size = new System.Drawing.Size(134, 28);
            this.Looms.TabIndex = 35;
            this.Looms.Text = "0,0,0,0";
            // 
            // AvgWeftKnott
            // 
            this.AvgWeftKnott.Appearance.Font = new System.Drawing.Font("Digital-7", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgWeftKnott.Appearance.Options.UseFont = true;
            this.AvgWeftKnott.Location = new System.Drawing.Point(463, 1);
            this.AvgWeftKnott.Name = "AvgWeftKnott";
            this.AvgWeftKnott.Size = new System.Drawing.Size(80, 28);
            this.AvgWeftKnott.TabIndex = 33;
            this.AvgWeftKnott.Text = "00:00";
            this.AvgWeftKnott.TextChanged += new System.EventHandler(this.AvgWeftKnott_TextChanged);
            // 
            // WeaverName
            // 
            this.WeaverName.Appearance.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeaverName.Appearance.Options.UseFont = true;
            this.WeaverName.Appearance.Options.UseTextOptions = true;
            this.WeaverName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.WeaverName.Location = new System.Drawing.Point(34, 1);
            this.WeaverName.Name = "WeaverName";
            this.WeaverName.Size = new System.Drawing.Size(208, 28);
            this.WeaverName.TabIndex = 32;
            this.WeaverName.Text = "XYZ";
            // 
            // AvgWarpKnott
            // 
            this.AvgWarpKnott.Appearance.Font = new System.Drawing.Font("Digital-7", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgWarpKnott.Appearance.Options.UseFont = true;
            this.AvgWarpKnott.Location = new System.Drawing.Point(381, 1);
            this.AvgWarpKnott.Name = "AvgWarpKnott";
            this.AvgWarpKnott.Size = new System.Drawing.Size(80, 28);
            this.AvgWarpKnott.TabIndex = 44;
            this.AvgWarpKnott.Text = "00:00";
            this.AvgWarpKnott.TextChanged += new System.EventHandler(this.AvgWarpKnott_TextChanged);
            // 
            // WeaverEff
            // 
            this.WeaverEff.Appearance.Font = new System.Drawing.Font("Digital-7", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeaverEff.Appearance.Options.UseFont = true;
            this.WeaverEff.Location = new System.Drawing.Point(545, 1);
            this.WeaverEff.Name = "WeaverEff";
            this.WeaverEff.Size = new System.Drawing.Size(80, 28);
            this.WeaverEff.TabIndex = 45;
            this.WeaverEff.Text = "00.0%";
            this.WeaverEff.TextChanged += new System.EventHandler(this.WeaverEff_TextChanged);
            // 
            // IndexNumber
            // 
            this.IndexNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndexNumber.Appearance.Options.UseFont = true;
            this.IndexNumber.Location = new System.Drawing.Point(2, 1);
            this.IndexNumber.LookAndFeel.SkinName = "Glass Oceans";
            this.IndexNumber.Name = "IndexNumber";
            this.IndexNumber.Size = new System.Drawing.Size(32, 28);
            this.IndexNumber.TabIndex = 46;
            this.IndexNumber.Text = "000";
            // 
            // dxWeaverEff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.IndexNumber);
            this.Controls.Add(this.WeaverEff);
            this.Controls.Add(this.AvgWarpKnott);
            this.Controls.Add(this.AvgWeftKnott);
            this.Controls.Add(this.Looms);
            this.Controls.Add(this.WeaverName);
            this.Name = "dxWeaverEff";
            this.Size = new System.Drawing.Size(628, 32);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton Looms;
        public DevExpress.XtraEditors.SimpleButton AvgWeftKnott;
        public DevExpress.XtraEditors.SimpleButton WeaverName;
        public DevExpress.XtraEditors.SimpleButton AvgWarpKnott;
        public DevExpress.XtraEditors.SimpleButton WeaverEff;
        public DevExpress.XtraEditors.SimpleButton IndexNumber;

    }
}
