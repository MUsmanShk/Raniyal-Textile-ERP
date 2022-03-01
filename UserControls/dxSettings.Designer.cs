namespace MachineEyes.UserControls
{
    partial class dxSettings
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
            this.GetID = new DevExpress.XtraEditors.TextEdit();
            this.GetValue = new DevExpress.XtraEditors.TextEdit();
            this.SetValue = new DevExpress.XtraEditors.TextEdit();
            this.SetDescription = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.GetID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GetID
            // 
            this.GetID.Location = new System.Drawing.Point(0, 0);
            this.GetID.Name = "GetID";
            this.GetID.Size = new System.Drawing.Size(63, 20);
            this.GetID.TabIndex = 0;
            // 
            // GetValue
            // 
            this.GetValue.Location = new System.Drawing.Point(69, 0);
            this.GetValue.Name = "GetValue";
            this.GetValue.Size = new System.Drawing.Size(258, 20);
            this.GetValue.TabIndex = 1;
            // 
            // SetValue
            // 
            this.SetValue.Location = new System.Drawing.Point(333, 0);
            this.SetValue.Name = "SetValue";
            this.SetValue.Size = new System.Drawing.Size(228, 20);
            this.SetValue.TabIndex = 2;
            // 
            // SetDescription
            // 
            this.SetDescription.Location = new System.Drawing.Point(567, 0);
            this.SetDescription.Name = "SetDescription";
            this.SetDescription.Size = new System.Drawing.Size(384, 20);
            this.SetDescription.TabIndex = 3;
            // 
            // dxSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SetDescription);
            this.Controls.Add(this.SetValue);
            this.Controls.Add(this.GetValue);
            this.Controls.Add(this.GetID);
            this.Name = "dxSettings";
            this.Size = new System.Drawing.Size(954, 20);
            ((System.ComponentModel.ISupportInitialize)(this.GetID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit GetID;
        private DevExpress.XtraEditors.TextEdit GetValue;
        private DevExpress.XtraEditors.TextEdit SetValue;
        private DevExpress.XtraEditors.TextEdit SetDescription;
    }
}
