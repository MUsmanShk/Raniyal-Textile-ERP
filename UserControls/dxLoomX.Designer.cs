namespace MachineEyes
{
    partial class dxLoomX
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
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.LoomNumber = new DevExpress.XtraEditors.LabelControl();
            this.Efficiency = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
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
            this.LoomNumber.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.LoomNumber.Appearance.Options.UseFont = true;
            this.LoomNumber.Appearance.Options.UseForeColor = true;
            this.LoomNumber.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LoomNumber.Location = new System.Drawing.Point(1, -1);
            this.LoomNumber.Name = "LoomNumber";
            this.LoomNumber.Size = new System.Drawing.Size(26, 15);
            this.LoomNumber.TabIndex = 0;
            this.LoomNumber.Text = "0";
            // 
            // Efficiency
            // 
            this.Efficiency.BackColor = System.Drawing.Color.Black;
            this.Efficiency.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Efficiency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Efficiency.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Efficiency.ForeColor = System.Drawing.Color.Yellow;
            this.Efficiency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Efficiency.Location = new System.Drawing.Point(1, 16);
            this.Efficiency.Name = "Efficiency";
            this.Efficiency.Size = new System.Drawing.Size(61, 23);
            this.Efficiency.TabIndex = 3;
            this.Efficiency.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Efficiency.UseVisualStyleBackColor = false;
            this.Efficiency.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Efficiency_MouseClick);
            // 
            // dxLoomX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Efficiency);
            this.Controls.Add(this.LoomNumber);
            this.DoubleBuffered = true;
            this.Name = "dxLoomX";
            this.Size = new System.Drawing.Size(66, 41);
            this.Load += new System.EventHandler(this.dxLoomX_Load);
            this.Enter += new System.EventHandler(this.dxLoomX_Enter);
            this.Leave += new System.EventHandler(this.dxLoomX_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenu1;
        public DevExpress.XtraEditors.LabelControl LoomNumber;
        public System.Windows.Forms.Button Efficiency;
    }
}
