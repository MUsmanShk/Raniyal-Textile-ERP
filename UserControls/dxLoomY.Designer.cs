namespace MachineEyes
{
    partial class dxLoomY
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
            this.RPM = new DevExpress.XtraEditors.SimpleButton();
            this.ElapsedTime = new DevExpress.XtraEditors.SimpleButton();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.LoomNumber = new DevExpress.XtraEditors.SimpleButton();
            this.Efficiency = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // RPM
            // 
            this.RPM.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RPM.Appearance.Options.UseFont = true;
            this.RPM.Appearance.Options.UseTextOptions = true;
            this.RPM.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.RPM.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.RPM.Location = new System.Drawing.Point(38, 0);
            this.RPM.Name = "RPM";
            this.RPM.Size = new System.Drawing.Size(36, 26);
            this.RPM.TabIndex = 20;
            this.RPM.Tag = "-1";
            this.RPM.Enter += new System.EventHandler(this.LoomNumber_Enter_1);
            // 
            // ElapsedTime
            // 
            this.ElapsedTime.Appearance.Font = new System.Drawing.Font("Digital-7", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElapsedTime.Appearance.Options.UseFont = true;
            this.ElapsedTime.Appearance.Options.UseTextOptions = true;
            this.ElapsedTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ElapsedTime.ImageIndex = 0;
            this.ElapsedTime.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ElapsedTime.Location = new System.Drawing.Point(0, 47);
            this.ElapsedTime.Name = "ElapsedTime";
            this.ElapsedTime.Size = new System.Drawing.Size(74, 23);
            this.ElapsedTime.TabIndex = 18;
            this.ElapsedTime.Tag = "-1";
            this.ElapsedTime.Enter += new System.EventHandler(this.LoomNumber_Enter_1);
            // 
            // popupMenu1
            // 
            this.popupMenu1.AllowRibbonQATMenu = false;
            this.popupMenu1.MenuAppearance.MenuCaption.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popupMenu1.MenuAppearance.MenuCaption.Options.UseFont = true;
            this.popupMenu1.MenuAppearance.MenuCaption.Options.UseTextOptions = true;
            this.popupMenu1.MenuAppearance.MenuCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.popupMenu1.MenuBarWidth = 1;
            this.popupMenu1.MenuCaption = "Loom #";
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.ShowCaption = true;
            // 
            // LoomNumber
            // 
            this.LoomNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoomNumber.Appearance.Options.UseFont = true;
            this.LoomNumber.Appearance.Options.UseTextOptions = true;
            this.LoomNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LoomNumber.ImageIndex = 0;
            this.LoomNumber.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.LoomNumber.Location = new System.Drawing.Point(0, 0);
            this.LoomNumber.Name = "LoomNumber";
            this.LoomNumber.Size = new System.Drawing.Size(39, 26);
            this.LoomNumber.TabIndex = 19;
            this.LoomNumber.Click += new System.EventHandler(this.LoomNumber_Click);
            this.LoomNumber.Enter += new System.EventHandler(this.LoomNumber_Enter_1);
            // 
            // Efficiency
            // 
            this.Efficiency.Appearance.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Efficiency.Appearance.Options.UseFont = true;
            this.Efficiency.ImageIndex = 0;
            this.Efficiency.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Efficiency.Location = new System.Drawing.Point(0, 25);
            this.Efficiency.Name = "Efficiency";
            this.Efficiency.Size = new System.Drawing.Size(74, 23);
            this.Efficiency.TabIndex = 17;
            this.Efficiency.Tag = "-1";
            this.Efficiency.TextChanged += new System.EventHandler(this.Efficiency_TextChanged);
            this.Efficiency.Enter += new System.EventHandler(this.LoomNumber_Enter_1);
            // 
            // dxLoomY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RPM);
            this.Controls.Add(this.ElapsedTime);
            this.Controls.Add(this.LoomNumber);
            this.Controls.Add(this.Efficiency);
            this.Name = "dxLoomY";
            this.Size = new System.Drawing.Size(74, 70);
            this.Load += new System.EventHandler(this.dxLoomY_Load);
            this.Enter += new System.EventHandler(this.dxLoomY_Enter);
            this.Leave += new System.EventHandler(this.dxLoomY_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton RPM;
        public DevExpress.XtraEditors.SimpleButton ElapsedTime;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        public DevExpress.XtraEditors.SimpleButton LoomNumber;
        public DevExpress.XtraEditors.SimpleButton Efficiency;
    }
}
