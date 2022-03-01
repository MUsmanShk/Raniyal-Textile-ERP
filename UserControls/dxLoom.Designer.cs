namespace MachineEyes
{
    partial class dxLoom
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
            this.Efficiency = new DevExpress.XtraEditors.SimpleButton();
            this.ElapsedTime = new DevExpress.XtraEditors.SimpleButton();
            this.RPM = new DevExpress.XtraEditors.SimpleButton();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.LoomNumber = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // Efficiency
            // 
            this.Efficiency.Appearance.BackColor = System.Drawing.Color.Black;
            this.Efficiency.Appearance.BorderColor = System.Drawing.Color.Black;
            this.Efficiency.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Efficiency.Appearance.Options.UseBackColor = true;
            this.Efficiency.Appearance.Options.UseBorderColor = true;
            this.Efficiency.Appearance.Options.UseFont = true;
            this.Efficiency.ImageIndex = 0;
            this.Efficiency.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.Efficiency.Location = new System.Drawing.Point(24, 0);
            this.Efficiency.Name = "Efficiency";
            this.Efficiency.Size = new System.Drawing.Size(35, 20);
            this.Efficiency.TabIndex = 9;
            this.Efficiency.TextChanged += new System.EventHandler(this.Efficiency_TextChanged);
            this.Efficiency.Click += new System.EventHandler(this.Efficiency_Click);
            this.Efficiency.Enter += new System.EventHandler(this.LoomNumber_Enter);
            this.Efficiency.Leave += new System.EventHandler(this.LoomNumber_Leave);
            // 
            // ElapsedTime
            // 
            this.ElapsedTime.Appearance.BackColor = System.Drawing.Color.Black;
            this.ElapsedTime.Appearance.BorderColor = System.Drawing.Color.Black;
            this.ElapsedTime.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElapsedTime.Appearance.Options.UseBackColor = true;
            this.ElapsedTime.Appearance.Options.UseBorderColor = true;
            this.ElapsedTime.Appearance.Options.UseFont = true;
            this.ElapsedTime.Appearance.Options.UseTextOptions = true;
            this.ElapsedTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ElapsedTime.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ElapsedTime.Location = new System.Drawing.Point(24, 20);
            this.ElapsedTime.Name = "ElapsedTime";
            this.ElapsedTime.Size = new System.Drawing.Size(35, 19);
            this.ElapsedTime.TabIndex = 10;
            this.ElapsedTime.Click += new System.EventHandler(this.ElapsedTime_Click);
            this.ElapsedTime.Enter += new System.EventHandler(this.LoomNumber_Enter);
            this.ElapsedTime.Leave += new System.EventHandler(this.LoomNumber_Leave);
            // 
            // RPM
            // 
            this.RPM.Appearance.BackColor = System.Drawing.Color.White;
            this.RPM.Appearance.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RPM.Appearance.Options.UseBackColor = true;
            this.RPM.Appearance.Options.UseFont = true;
            this.RPM.Appearance.Options.UseTextOptions = true;
            this.RPM.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.RPM.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.RPM.Location = new System.Drawing.Point(0, 20);
            this.RPM.Name = "RPM";
            this.RPM.Size = new System.Drawing.Size(25, 19);
            this.RPM.TabIndex = 12;
            this.RPM.Click += new System.EventHandler(this.RPM_Click);
            this.RPM.Enter += new System.EventHandler(this.LoomNumber_Enter);
            this.RPM.Leave += new System.EventHandler(this.LoomNumber_Leave);
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
            this.LoomNumber.Appearance.BackColor = System.Drawing.Color.Blue;
            this.LoomNumber.Appearance.BorderColor = System.Drawing.Color.Blue;
            this.LoomNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoomNumber.Appearance.Options.UseBackColor = true;
            this.LoomNumber.Appearance.Options.UseBorderColor = true;
            this.LoomNumber.Appearance.Options.UseFont = true;
            this.LoomNumber.Appearance.Options.UseTextOptions = true;
            this.LoomNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LoomNumber.ImageIndex = 0;
            this.LoomNumber.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.LoomNumber.Location = new System.Drawing.Point(0, 0);
            this.LoomNumber.Name = "LoomNumber";
            this.LoomNumber.Size = new System.Drawing.Size(25, 20);
            this.LoomNumber.TabIndex = 11;
            this.LoomNumber.Click += new System.EventHandler(this.LoomNumber_Click);
            this.LoomNumber.Enter += new System.EventHandler(this.LoomNumber_Enter);
            this.LoomNumber.Leave += new System.EventHandler(this.LoomNumber_Leave);
            // 
            // dxLoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ElapsedTime);
            this.Controls.Add(this.Efficiency);
            this.Controls.Add(this.RPM);
            this.Controls.Add(this.LoomNumber);
            this.DoubleBuffered = true;
            this.Name = "dxLoom";
            this.Size = new System.Drawing.Size(60, 40);
            this.Load += new System.EventHandler(this.dxLoom_Load);
            this.Enter += new System.EventHandler(this.dxLoom_Enter);
            this.Leave += new System.EventHandler(this.dxLoom_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton Efficiency;
        public DevExpress.XtraEditors.SimpleButton ElapsedTime;
        public DevExpress.XtraEditors.SimpleButton LoomNumber;
        public DevExpress.XtraEditors.SimpleButton RPM;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}
