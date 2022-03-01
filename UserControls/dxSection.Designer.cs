namespace MachineEyes.UserControls
{
    partial class dxSection
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dxSection));
            this.Section = new DevExpress.XtraEditors.LabelControl();
            this.Efficiency = new DevExpress.XtraEditors.LabelControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.RunningEfficiency = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // Section
            // 
            this.Section.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Section.Appearance.Options.UseFont = true;
            this.Section.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Section.LineVisible = true;
            this.Section.Location = new System.Drawing.Point(0, 1);
            this.Section.Name = "Section";
            this.Section.Size = new System.Drawing.Size(73, 10);
            this.Section.TabIndex = 0;
            this.Section.Text = "Section I";
            // 
            // Efficiency
            // 
            this.Efficiency.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Efficiency.Appearance.ImageIndex = 4;
            this.Efficiency.Appearance.ImageList = this.imageCollection1;
            this.Efficiency.Appearance.Options.UseFont = true;
            this.Efficiency.Appearance.Options.UseTextOptions = true;
            this.Efficiency.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Efficiency.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Efficiency.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.Efficiency.Location = new System.Drawing.Point(68, 1);
            this.Efficiency.Name = "Efficiency";
            this.Efficiency.Size = new System.Drawing.Size(48, 10);
            this.Efficiency.TabIndex = 1;
            this.Efficiency.Text = "89.2";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "NetworkConfigs.png");
            this.imageCollection1.Images.SetKeyName(1, "clock.png");
            this.imageCollection1.Images.SetKeyName(2, "leno.png");
            this.imageCollection1.Images.SetKeyName(3, "RUN16.png");
            this.imageCollection1.Images.SetKeyName(4, "Chart.png");
            // 
            // RunningEfficiency
            // 
            this.RunningEfficiency.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunningEfficiency.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RunningEfficiency.Appearance.ImageIndex = 3;
            this.RunningEfficiency.Appearance.ImageList = this.imageCollection1;
            this.RunningEfficiency.Appearance.Options.UseFont = true;
            this.RunningEfficiency.Appearance.Options.UseTextOptions = true;
            this.RunningEfficiency.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.RunningEfficiency.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.RunningEfficiency.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.RunningEfficiency.Location = new System.Drawing.Point(117, 1);
            this.RunningEfficiency.Name = "RunningEfficiency";
            this.RunningEfficiency.Size = new System.Drawing.Size(50, 10);
            this.RunningEfficiency.TabIndex = 2;
            this.RunningEfficiency.Text = "89.2";
            // 
            // dxSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RunningEfficiency);
            this.Controls.Add(this.Efficiency);
            this.Controls.Add(this.Section);
            this.Name = "dxSection";
            this.Size = new System.Drawing.Size(170, 16);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LabelControl Section;
        public DevExpress.XtraEditors.LabelControl Efficiency;
        public DevExpress.XtraEditors.LabelControl RunningEfficiency;
        private DevExpress.Utils.ImageCollection imageCollection1;



    }
}
