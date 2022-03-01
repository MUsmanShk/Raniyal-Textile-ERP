namespace MachineEyes
{
    partial class dxLoom_NameEff
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
            this.Efficiency = new DevExpress.XtraEditors.SimpleButton();
            this.Loom = new DevExpress.XtraEditors.SimpleButton();
            this.Index = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // Efficiency
            // 
            this.Efficiency.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Efficiency.Appearance.Options.UseFont = true;
            this.Efficiency.Appearance.Options.UseTextOptions = true;
            this.Efficiency.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Efficiency.Location = new System.Drawing.Point(73, 0);
            this.Efficiency.Name = "Efficiency";
            this.Efficiency.Size = new System.Drawing.Size(64, 23);
            this.Efficiency.TabIndex = 5;
            this.Efficiency.Text = "00.0%";
            // 
            // Loom
            // 
            this.Loom.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loom.Appearance.Options.UseFont = true;
            this.Loom.Appearance.Options.UseTextOptions = true;
            this.Loom.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Loom.Location = new System.Drawing.Point(27, 0);
            this.Loom.Name = "Loom";
            this.Loom.Size = new System.Drawing.Size(47, 23);
            this.Loom.TabIndex = 4;
            this.Loom.Text = "00";
            // 
            // Index
            // 
            this.Index.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Index.Appearance.Options.UseFont = true;
            this.Index.Location = new System.Drawing.Point(0, 0);
            this.Index.Name = "Index";
            this.Index.Size = new System.Drawing.Size(28, 23);
            this.Index.TabIndex = 3;
            this.Index.Text = "0";
            // 
            // dxLoom_NameEff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Efficiency);
            this.Controls.Add(this.Loom);
            this.Controls.Add(this.Index);
            this.Name = "dxLoom_NameEff";
            this.Size = new System.Drawing.Size(138, 24);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton Efficiency;
        public DevExpress.XtraEditors.SimpleButton Loom;
        public DevExpress.XtraEditors.SimpleButton Index;
    }
}
