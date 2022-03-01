namespace MachineEyes
{
    partial class dxWeaver_NameEff
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
            this.Index = new DevExpress.XtraEditors.SimpleButton();
            this.Weaver = new DevExpress.XtraEditors.SimpleButton();
            this.Efficiency = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // Index
            // 
            this.Index.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Index.Appearance.Options.UseFont = true;
            this.Index.Location = new System.Drawing.Point(0, 0);
            this.Index.Name = "Index";
            this.Index.Size = new System.Drawing.Size(28, 23);
            this.Index.TabIndex = 0;
            this.Index.Text = "1";
            // 
            // Weaver
            // 
            this.Weaver.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Weaver.Appearance.Options.UseFont = true;
            this.Weaver.Appearance.Options.UseTextOptions = true;
            this.Weaver.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Weaver.Location = new System.Drawing.Point(27, 0);
            this.Weaver.Name = "Weaver";
            this.Weaver.Size = new System.Drawing.Size(178, 23);
            this.Weaver.TabIndex = 1;
            // 
            // Efficiency
            // 
            this.Efficiency.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Efficiency.Appearance.Options.UseFont = true;
            this.Efficiency.Appearance.Options.UseTextOptions = true;
            this.Efficiency.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Efficiency.Location = new System.Drawing.Point(204, 0);
            this.Efficiency.Name = "Efficiency";
            this.Efficiency.Size = new System.Drawing.Size(64, 23);
            this.Efficiency.TabIndex = 2;
            // 
            // dxWeaver_NameEff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Efficiency);
            this.Controls.Add(this.Weaver);
            this.Controls.Add(this.Index);
            this.Name = "dxWeaver_NameEff";
            this.Size = new System.Drawing.Size(268, 24);
            this.Load += new System.EventHandler(this.dxWeaver_NameEff_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton Index;
        public DevExpress.XtraEditors.SimpleButton Weaver;
        public DevExpress.XtraEditors.SimpleButton Efficiency;

    }
}
