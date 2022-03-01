namespace MachineEyes.Security
{
    partial class Authenticity
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ALU = new DevExpress.XtraEditors.TextEdit();
            this.GPU = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.AdminPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ALU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdminPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(21, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(126, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ALU Unit ID";
            // 
            // ALU
            // 
            this.ALU.Location = new System.Drawing.Point(153, 12);
            this.ALU.Name = "ALU";
            this.ALU.Size = new System.Drawing.Size(52, 20);
            this.ALU.TabIndex = 1;
            // 
            // GPU
            // 
            this.GPU.Location = new System.Drawing.Point(153, 38);
            this.GPU.Name = "GPU";
            this.GPU.Size = new System.Drawing.Size(52, 20);
            this.GPU.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(21, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(126, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "GPU Unit ID";
            // 
            // AdminPassword
            // 
            this.AdminPassword.Location = new System.Drawing.Point(153, 64);
            this.AdminPassword.Name = "AdminPassword";
            this.AdminPassword.Properties.PasswordChar = '*';
            this.AdminPassword.Size = new System.Drawing.Size(191, 20);
            this.AdminPassword.TabIndex = 5;
            this.AdminPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AdminPassword_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(21, 67);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(126, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Admin Passoword";
            // 
            // Authenticity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 126);
            this.Controls.Add(this.AdminPassword);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.GPU);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.ALU);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Authenticity";
            this.ShowInTaskbar = false;
            this.Text = "Perfs";
            ((System.ComponentModel.ISupportInitialize)(this.ALU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdminPassword.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit ALU;
        private DevExpress.XtraEditors.TextEdit GPU;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit AdminPassword;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}