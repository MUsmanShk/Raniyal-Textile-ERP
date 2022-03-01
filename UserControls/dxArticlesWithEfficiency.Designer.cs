namespace MachineEyes.UserControls
{
    partial class dxArticlesWithEfficiency
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
            this.ArticleNumber = new DevExpress.XtraEditors.SimpleButton();
            this.ArticleGroup = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleGroup)).BeginInit();
            this.ArticleGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // Efficiency
            // 
            this.Efficiency.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Efficiency.Appearance.Options.UseFont = true;
            this.Efficiency.Appearance.Options.UseTextOptions = true;
            this.Efficiency.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Efficiency.Location = new System.Drawing.Point(764, 0);
            this.Efficiency.Name = "Efficiency";
            this.Efficiency.Size = new System.Drawing.Size(70, 21);
            this.Efficiency.TabIndex = 68;
            // 
            // NoOfLooms
            // 
            this.NoOfLooms.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoOfLooms.Appearance.Options.UseFont = true;
            this.NoOfLooms.Appearance.Options.UseTextOptions = true;
            this.NoOfLooms.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.NoOfLooms.Location = new System.Drawing.Point(833, 0);
            this.NoOfLooms.Name = "NoOfLooms";
            this.NoOfLooms.Size = new System.Drawing.Size(53, 21);
            this.NoOfLooms.TabIndex = 67;
            // 
            // IndexNumber
            // 
            this.IndexNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndexNumber.Appearance.Options.UseFont = true;
            this.IndexNumber.Location = new System.Drawing.Point(961, 0);
            this.IndexNumber.Name = "IndexNumber";
            this.IndexNumber.Size = new System.Drawing.Size(32, 21);
            this.IndexNumber.TabIndex = 66;
            this.IndexNumber.Text = "1";
            // 
            // RPM
            // 
            this.RPM.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RPM.Appearance.Options.UseFont = true;
            this.RPM.Appearance.Options.UseTextOptions = true;
            this.RPM.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.RPM.Location = new System.Drawing.Point(696, 0);
            this.RPM.Name = "RPM";
            this.RPM.Size = new System.Drawing.Size(69, 21);
            this.RPM.TabIndex = 65;
            // 
            // ArticleNumber
            // 
            this.ArticleNumber.Appearance.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArticleNumber.Appearance.Options.UseFont = true;
            this.ArticleNumber.Appearance.Options.UseTextOptions = true;
            this.ArticleNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ArticleNumber.Location = new System.Drawing.Point(885, 0);
            this.ArticleNumber.Name = "ArticleNumber";
            this.ArticleNumber.Size = new System.Drawing.Size(77, 21);
            this.ArticleNumber.TabIndex = 62;
            // 
            // ArticleGroup
            // 
            this.ArticleGroup.Controls.Add(this.IndexNumber);
            this.ArticleGroup.Controls.Add(this.RPM);
            this.ArticleGroup.Controls.Add(this.Efficiency);
            this.ArticleGroup.Controls.Add(this.ArticleNumber);
            this.ArticleGroup.Controls.Add(this.NoOfLooms);
            this.ArticleGroup.Location = new System.Drawing.Point(1, 1);
            this.ArticleGroup.Name = "ArticleGroup";
            this.ArticleGroup.Size = new System.Drawing.Size(999, 67);
            this.ArticleGroup.TabIndex = 69;
            this.ArticleGroup.Text = "Article";
            // 
            // dxArticlesWithEfficiency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ArticleGroup);
            this.Name = "dxArticlesWithEfficiency";
            this.Size = new System.Drawing.Size(1000, 70);
            ((System.ComponentModel.ISupportInitialize)(this.ArticleGroup)).EndInit();
            this.ArticleGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton Efficiency;
        public DevExpress.XtraEditors.SimpleButton NoOfLooms;
        public DevExpress.XtraEditors.SimpleButton IndexNumber;
        public DevExpress.XtraEditors.SimpleButton RPM;
        public DevExpress.XtraEditors.SimpleButton ArticleNumber;
        public DevExpress.XtraEditors.GroupControl ArticleGroup;
    }
}
