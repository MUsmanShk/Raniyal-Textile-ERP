namespace MachineEyes
{
    partial class dxTechniciansEff
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
            this.IndexNumber = new DevExpress.XtraEditors.SimpleButton();
            this.RPM = new DevExpress.XtraEditors.SimpleButton();
            this.TechnicianName = new DevExpress.XtraEditors.SimpleButton();
            this.Efficiency = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // IndexNumber
            // 
            this.IndexNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndexNumber.Appearance.Options.UseFont = true;
            this.IndexNumber.Location = new System.Drawing.Point(0, 0);
            this.IndexNumber.Name = "IndexNumber";
            this.IndexNumber.Size = new System.Drawing.Size(28, 22);
            this.IndexNumber.TabIndex = 49;
            this.IndexNumber.Text = "0";
            // 
            // RPM
            // 
            this.RPM.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RPM.Appearance.Options.UseFont = true;
            this.RPM.Location = new System.Drawing.Point(193, 0);
            this.RPM.Name = "RPM";
            this.RPM.Size = new System.Drawing.Size(39, 22);
            this.RPM.TabIndex = 48;
            this.RPM.Text = "---";
            // 
            // TechnicianName
            // 
            this.TechnicianName.Appearance.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TechnicianName.Appearance.Options.UseFont = true;
            this.TechnicianName.Appearance.Options.UseTextOptions = true;
            this.TechnicianName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.TechnicianName.Location = new System.Drawing.Point(27, 0);
            this.TechnicianName.Name = "TechnicianName";
            this.TechnicianName.Size = new System.Drawing.Size(166, 22);
            this.TechnicianName.TabIndex = 47;
            this.TechnicianName.Text = "--";
            // 
            // Efficiency
            // 
            this.Efficiency.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Efficiency.Appearance.Options.UseFont = true;
            this.Efficiency.Location = new System.Drawing.Point(233, 0);
            this.Efficiency.Name = "Efficiency";
            this.Efficiency.Size = new System.Drawing.Size(51, 22);
            this.Efficiency.TabIndex = 50;
            this.Efficiency.Text = "---";
            // 
            // dxTechniciansEff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Efficiency);
            this.Controls.Add(this.IndexNumber);
            this.Controls.Add(this.RPM);
            this.Controls.Add(this.TechnicianName);
            this.Name = "dxTechniciansEff";
            this.Size = new System.Drawing.Size(286, 22);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton IndexNumber;
        public DevExpress.XtraEditors.SimpleButton RPM;
        public DevExpress.XtraEditors.SimpleButton TechnicianName;
        public DevExpress.XtraEditors.SimpleButton Efficiency;
    }
}
