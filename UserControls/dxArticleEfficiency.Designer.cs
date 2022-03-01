namespace MachineEyes.UserControls
{
    partial class dxArticleEfficiency
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
            this.NoOfLooms = new DevExpress.XtraEditors.SimpleButton();
            this.IndexNumber = new DevExpress.XtraEditors.SimpleButton();
            this.RPM = new DevExpress.XtraEditors.SimpleButton();
            this.MetersWeaved = new DevExpress.XtraEditors.SimpleButton();
            this.ArticleName = new DevExpress.XtraEditors.SimpleButton();
            this.ArticleNumber = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // Efficiency
            // 
            this.Efficiency.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Efficiency.Appearance.Options.UseFont = true;
            this.Efficiency.Appearance.Options.UseTextOptions = true;
            this.Efficiency.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Efficiency.Location = new System.Drawing.Point(772, 0);
            this.Efficiency.Name = "Efficiency";
            this.Efficiency.Size = new System.Drawing.Size(70, 28);
            this.Efficiency.TabIndex = 61;
            this.Efficiency.Click += new System.EventHandler(this.SetEff_Uptodate_Click);
            // 
            // NoOfLooms
            // 
            this.NoOfLooms.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoOfLooms.Appearance.Options.UseFont = true;
            this.NoOfLooms.Appearance.Options.UseTextOptions = true;
            this.NoOfLooms.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.NoOfLooms.Location = new System.Drawing.Point(720, 0);
            this.NoOfLooms.Name = "NoOfLooms";
            this.NoOfLooms.Size = new System.Drawing.Size(53, 28);
            this.NoOfLooms.TabIndex = 60;
            // 
            // IndexNumber
            // 
            this.IndexNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndexNumber.Appearance.Options.UseFont = true;
            this.IndexNumber.Location = new System.Drawing.Point(0, 0);
            this.IndexNumber.Name = "IndexNumber";
            this.IndexNumber.Size = new System.Drawing.Size(32, 28);
            this.IndexNumber.TabIndex = 59;
            this.IndexNumber.Text = "1";
            // 
            // RPM
            // 
            this.RPM.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RPM.Appearance.Options.UseFont = true;
            this.RPM.Appearance.Options.UseTextOptions = true;
            this.RPM.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.RPM.Location = new System.Drawing.Point(841, 0);
            this.RPM.Name = "RPM";
            this.RPM.Size = new System.Drawing.Size(69, 28);
            this.RPM.TabIndex = 58;
            // 
            // MetersWeaved
            // 
            this.MetersWeaved.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MetersWeaved.Appearance.Options.UseFont = true;
            this.MetersWeaved.Appearance.Options.UseTextOptions = true;
            this.MetersWeaved.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.MetersWeaved.Location = new System.Drawing.Point(909, 0);
            this.MetersWeaved.Name = "MetersWeaved";
            this.MetersWeaved.Size = new System.Drawing.Size(88, 28);
            this.MetersWeaved.TabIndex = 57;
            // 
            // ArticleName
            // 
            this.ArticleName.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArticleName.Appearance.Options.UseFont = true;
            this.ArticleName.Appearance.Options.UseTextOptions = true;
            this.ArticleName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ArticleName.Location = new System.Drawing.Point(109, 0);
            this.ArticleName.Name = "ArticleName";
            this.ArticleName.Size = new System.Drawing.Size(612, 28);
            this.ArticleName.TabIndex = 56;
            // 
            // ArticleNumber
            // 
            this.ArticleNumber.Appearance.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArticleNumber.Appearance.Options.UseFont = true;
            this.ArticleNumber.Appearance.Options.UseTextOptions = true;
            this.ArticleNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ArticleNumber.Location = new System.Drawing.Point(32, 0);
            this.ArticleNumber.Name = "ArticleNumber";
            this.ArticleNumber.Size = new System.Drawing.Size(77, 28);
            this.ArticleNumber.TabIndex = 55;
            // 
            // dxArticleEfficiency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Efficiency);
            this.Controls.Add(this.NoOfLooms);
            this.Controls.Add(this.IndexNumber);
            this.Controls.Add(this.RPM);
            this.Controls.Add(this.MetersWeaved);
            this.Controls.Add(this.ArticleName);
            this.Controls.Add(this.ArticleNumber);
            this.Name = "dxArticleEfficiency";
            this.Size = new System.Drawing.Size(997, 28);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton Efficiency;
        public DevExpress.XtraEditors.SimpleButton NoOfLooms;
        public DevExpress.XtraEditors.SimpleButton IndexNumber;
        public DevExpress.XtraEditors.SimpleButton RPM;
        public DevExpress.XtraEditors.SimpleButton MetersWeaved;
        public DevExpress.XtraEditors.SimpleButton ArticleName;
        public DevExpress.XtraEditors.SimpleButton ArticleNumber;
    }
}
