namespace MachineEyes.UserControls
{
    partial class dxLoomZ
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
            this.Efficiency = new DevExpress.XtraEditors.LabelControl();
            this.LoomNumber = new DevExpress.XtraEditors.LabelControl();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // Efficiency
            // 
            this.Efficiency.Appearance.Font = new System.Drawing.Font("Digital-7", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Efficiency.Appearance.ForeColor = System.Drawing.Color.Lime;
            this.Efficiency.Appearance.Options.UseFont = true;
            this.Efficiency.Appearance.Options.UseForeColor = true;
            this.Efficiency.Appearance.Options.UseTextOptions = true;
            this.Efficiency.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Efficiency.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Efficiency.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Efficiency.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.Efficiency.Location = new System.Drawing.Point(78, 3);
            this.Efficiency.Name = "Efficiency";
            this.Efficiency.Size = new System.Drawing.Size(110, 55);
            this.Efficiency.TabIndex = 0;
            this.Efficiency.Tag = "0";
            this.Efficiency.Click += new System.EventHandler(this.Efficiency_Click);
            // 
            // LoomNumber
            // 
            this.LoomNumber.Appearance.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoomNumber.Appearance.ForeColor = System.Drawing.Color.White;
            this.LoomNumber.Appearance.Options.UseFont = true;
            this.LoomNumber.Appearance.Options.UseForeColor = true;
            this.LoomNumber.Appearance.Options.UseTextOptions = true;
            this.LoomNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LoomNumber.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LoomNumber.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LoomNumber.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.LoomNumber.Location = new System.Drawing.Point(3, 3);
            this.LoomNumber.Name = "LoomNumber";
            this.LoomNumber.Size = new System.Drawing.Size(74, 55);
            this.LoomNumber.TabIndex = 1;
            this.LoomNumber.Tag = "0";
            this.LoomNumber.Click += new System.EventHandler(this.Efficiency_Click);
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
            // dxLoomZ
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LoomNumber);
            this.Controls.Add(this.Efficiency);
            this.Name = "dxLoomZ";
            this.Size = new System.Drawing.Size(189, 59);
            this.Tag = "0";
            this.Enter += new System.EventHandler(this.dxLoomZ_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LabelControl Efficiency;
        public DevExpress.XtraEditors.LabelControl LoomNumber;
        private DevExpress.XtraBars.PopupMenu popupMenu1;

    }
}
