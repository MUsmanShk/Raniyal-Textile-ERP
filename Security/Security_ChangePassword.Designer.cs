namespace MachineEyes.Security
{
    partial class Security_ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Security_ChangePassword));
            this.OldPassword = new DevExpress.XtraEditors.TextEdit();
            this.NewPassword = new DevExpress.XtraEditors.TextEdit();
            this.VerifyNewPassword = new DevExpress.XtraEditors.TextEdit();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            this.ChangePassword = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.OldPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerifyNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OldPassword
            // 
            this.OldPassword.EditValue = "";
            this.OldPassword.EnterMoveNextControl = true;
            this.OldPassword.Location = new System.Drawing.Point(223, 24);
            this.OldPassword.Name = "OldPassword";
            this.OldPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OldPassword.Properties.Appearance.Options.UseFont = true;
            this.OldPassword.Properties.Appearance.Options.UseTextOptions = true;
            this.OldPassword.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.OldPassword.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.OldPassword.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.OldPassword.Properties.AutoHeight = false;
            this.OldPassword.Properties.NullValuePrompt = "Current Password";
            this.OldPassword.Properties.NullValuePromptShowForEmptyValue = true;
            this.OldPassword.Properties.PasswordChar = '.';
            this.OldPassword.Size = new System.Drawing.Size(218, 27);
            this.OldPassword.TabIndex = 18;
            // 
            // NewPassword
            // 
            this.NewPassword.EditValue = "";
            this.NewPassword.EnterMoveNextControl = true;
            this.NewPassword.Location = new System.Drawing.Point(223, 72);
            this.NewPassword.Name = "NewPassword";
            this.NewPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPassword.Properties.Appearance.Options.UseFont = true;
            this.NewPassword.Properties.Appearance.Options.UseTextOptions = true;
            this.NewPassword.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.NewPassword.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NewPassword.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.NewPassword.Properties.AutoHeight = false;
            this.NewPassword.Properties.NullValuePrompt = "New Password";
            this.NewPassword.Properties.NullValuePromptShowForEmptyValue = true;
            this.NewPassword.Properties.PasswordChar = '.';
            this.NewPassword.Size = new System.Drawing.Size(218, 27);
            this.NewPassword.TabIndex = 19;
            // 
            // VerifyNewPassword
            // 
            this.VerifyNewPassword.EditValue = "";
            this.VerifyNewPassword.EnterMoveNextControl = true;
            this.VerifyNewPassword.Location = new System.Drawing.Point(223, 117);
            this.VerifyNewPassword.Name = "VerifyNewPassword";
            this.VerifyNewPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyNewPassword.Properties.Appearance.Options.UseFont = true;
            this.VerifyNewPassword.Properties.Appearance.Options.UseTextOptions = true;
            this.VerifyNewPassword.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.VerifyNewPassword.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.VerifyNewPassword.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.VerifyNewPassword.Properties.AutoHeight = false;
            this.VerifyNewPassword.Properties.NullValuePrompt = "Verify New Password";
            this.VerifyNewPassword.Properties.NullValuePromptShowForEmptyValue = true;
            this.VerifyNewPassword.Properties.PasswordChar = '.';
            this.VerifyNewPassword.Size = new System.Drawing.Size(218, 27);
            this.VerifyNewPassword.TabIndex = 20;
            // 
            // CloseForm
            // 
            this.CloseForm.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseForm.Location = new System.Drawing.Point(407, 157);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(34, 34);
            this.CloseForm.TabIndex = 22;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // ChangePassword
            // 
            this.ChangePassword.Image = global::MachineEyes.Properties.Resources.SecurityAllowed;
            this.ChangePassword.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ChangePassword.Location = new System.Drawing.Point(367, 157);
            this.ChangePassword.Name = "ChangePassword";
            this.ChangePassword.Size = new System.Drawing.Size(34, 34);
            this.ChangePassword.TabIndex = 21;
            this.ChangePassword.Click += new System.EventHandler(this.ChangePassword_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 179);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // Security_ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 197);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.ChangePassword);
            this.Controls.Add(this.VerifyNewPassword);
            this.Controls.Add(this.NewPassword);
            this.Controls.Add(this.OldPassword);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Security_ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.OldPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerifyNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.TextEdit OldPassword;
        private DevExpress.XtraEditors.TextEdit NewPassword;
        private DevExpress.XtraEditors.TextEdit VerifyNewPassword;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
        private DevExpress.XtraEditors.SimpleButton ChangePassword;
    }
}