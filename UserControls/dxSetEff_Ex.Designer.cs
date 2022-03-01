namespace MachineEyes.UserControls
{
    partial class dxSetEff_Ex
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
            this.Length = new DevExpress.XtraEditors.SimpleButton();
            this.NoofBeams = new DevExpress.XtraEditors.SimpleButton();
            this.Efficiency = new DevExpress.XtraEditors.SimpleButton();
            this.AvgBreakages = new DevExpress.XtraEditors.SimpleButton();
            this.SizingDate = new DevExpress.XtraEditors.SimpleButton();
            this.SetNumber = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // Length
            // 
            this.Length.Location = new System.Drawing.Point(256, 0);
            this.Length.Name = "Length";
            this.Length.Size = new System.Drawing.Size(75, 23);
            this.Length.TabIndex = 51;
            // 
            // NoofBeams
            // 
            this.NoofBeams.Location = new System.Drawing.Point(192, 0);
            this.NoofBeams.Name = "NoofBeams";
            this.NoofBeams.Size = new System.Drawing.Size(64, 23);
            this.NoofBeams.TabIndex = 50;
            // 
            // Efficiency
            // 
            this.Efficiency.Location = new System.Drawing.Point(433, 0);
            this.Efficiency.Name = "Efficiency";
            this.Efficiency.Size = new System.Drawing.Size(64, 23);
            this.Efficiency.TabIndex = 49;
            // 
            // AvgBreakages
            // 
            this.AvgBreakages.Location = new System.Drawing.Point(339, 0);
            this.AvgBreakages.Name = "AvgBreakages";
            this.AvgBreakages.Size = new System.Drawing.Size(94, 23);
            this.AvgBreakages.TabIndex = 48;
            // 
            // SizingDate
            // 
            this.SizingDate.Location = new System.Drawing.Point(98, 0);
            this.SizingDate.Name = "SizingDate";
            this.SizingDate.Size = new System.Drawing.Size(94, 23);
            this.SizingDate.TabIndex = 47;
            // 
            // SetNumber
            // 
            this.SetNumber.Location = new System.Drawing.Point(0, 0);
            this.SetNumber.Name = "SetNumber";
            this.SetNumber.Size = new System.Drawing.Size(98, 23);
            this.SetNumber.TabIndex = 46;
            // 
            // dxSetEff_Ex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Length);
            this.Controls.Add(this.NoofBeams);
            this.Controls.Add(this.Efficiency);
            this.Controls.Add(this.AvgBreakages);
            this.Controls.Add(this.SizingDate);
            this.Controls.Add(this.SetNumber);
            this.Name = "dxSetEff_Ex";
            this.Size = new System.Drawing.Size(497, 23);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton Length;
        public DevExpress.XtraEditors.SimpleButton NoofBeams;
        public DevExpress.XtraEditors.SimpleButton Efficiency;
        public DevExpress.XtraEditors.SimpleButton AvgBreakages;
        public DevExpress.XtraEditors.SimpleButton SizingDate;
        public DevExpress.XtraEditors.SimpleButton SetNumber;

    }
}
