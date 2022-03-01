namespace MachineEyes
{
    partial class dxTypeEff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dxTypeEff));
            this.Model = new DevExpress.XtraEditors.SimpleButton();
            this.RunningEfficiency = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.TotalMachines = new DevExpress.XtraEditors.SimpleButton();
            this.RPM = new DevExpress.XtraEditors.SimpleButton();
            this.LongStops = new DevExpress.XtraEditors.SimpleButton();
            this.ShedEfficiency = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // Model
            // 
            this.Model.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Model.Appearance.Options.UseFont = true;
            this.Model.Appearance.Options.UseTextOptions = true;
            this.Model.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            this.Model.Location = new System.Drawing.Point(1, 0);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(82, 20);
            this.Model.TabIndex = 0;
            // 
            // RunningEfficiency
            // 
            this.RunningEfficiency.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunningEfficiency.Appearance.Options.UseFont = true;
            this.RunningEfficiency.ImageList = this.imageCollection1;
            this.RunningEfficiency.Location = new System.Drawing.Point(134, 0);
            this.RunningEfficiency.Name = "RunningEfficiency";
            this.RunningEfficiency.Size = new System.Drawing.Size(31, 20);
            this.RunningEfficiency.TabIndex = 1;
            this.RunningEfficiency.TextChanged += new System.EventHandler(this.Efficiency_TextChanged);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "NetworkConfigs.png");
            this.imageCollection1.Images.SetKeyName(1, "clock.png");
            this.imageCollection1.Images.SetKeyName(2, "leno.png");
            this.imageCollection1.Images.SetKeyName(3, "RUN16.png");
            // 
            // TotalMachines
            // 
            this.TotalMachines.ImageIndex = 0;
            this.TotalMachines.Location = new System.Drawing.Point(82, 0);
            this.TotalMachines.Name = "TotalMachines";
            this.TotalMachines.Size = new System.Drawing.Size(27, 20);
            this.TotalMachines.TabIndex = 4;
            // 
            // RPM
            // 
            this.RPM.ImageList = this.imageCollection1;
            this.RPM.Location = new System.Drawing.Point(108, 0);
            this.RPM.Name = "RPM";
            this.RPM.Size = new System.Drawing.Size(25, 20);
            this.RPM.TabIndex = 5;
            this.RPM.Click += new System.EventHandler(this.RPM_Click);
            // 
            // LongStops
            // 
            this.LongStops.ImageList = this.imageCollection1;
            this.LongStops.Location = new System.Drawing.Point(195, 0);
            this.LongStops.Name = "LongStops";
            this.LongStops.Size = new System.Drawing.Size(23, 20);
            this.LongStops.TabIndex = 6;
            // 
            // ShedEfficiency
            // 
            this.ShedEfficiency.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShedEfficiency.Appearance.Options.UseFont = true;
            this.ShedEfficiency.ImageList = this.imageCollection1;
            this.ShedEfficiency.Location = new System.Drawing.Point(165, 0);
            this.ShedEfficiency.Name = "ShedEfficiency";
            this.ShedEfficiency.Size = new System.Drawing.Size(31, 20);
            this.ShedEfficiency.TabIndex = 7;
            // 
            // dxTypeEff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ShedEfficiency);
            this.Controls.Add(this.LongStops);
            this.Controls.Add(this.RPM);
            this.Controls.Add(this.TotalMachines);
            this.Controls.Add(this.RunningEfficiency);
            this.Controls.Add(this.Model);
            this.Name = "dxTypeEff";
            this.Size = new System.Drawing.Size(220, 21);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollection1;
        public DevExpress.XtraEditors.SimpleButton Model;
        public DevExpress.XtraEditors.SimpleButton RunningEfficiency;
        public DevExpress.XtraEditors.SimpleButton TotalMachines;
        public DevExpress.XtraEditors.SimpleButton RPM;
        public DevExpress.XtraEditors.SimpleButton LongStops;
        public DevExpress.XtraEditors.SimpleButton ShedEfficiency;

    }
}
