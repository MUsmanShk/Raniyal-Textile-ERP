namespace MachineEyes
{
    partial class dxTypeEffDigital
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
            this.Model = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // Efficiency
            // 
            this.Efficiency.Appearance.BackColor = System.Drawing.Color.Black;
            this.Efficiency.Appearance.BackColor2 = System.Drawing.Color.Black;
            this.Efficiency.Appearance.Font = new System.Drawing.Font("Digital-7", 54.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Efficiency.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Efficiency.Appearance.Options.UseBackColor = true;
            this.Efficiency.Appearance.Options.UseFont = true;
            this.Efficiency.Appearance.Options.UseForeColor = true;
            this.Efficiency.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Efficiency.Location = new System.Drawing.Point(0, 0);
            this.Efficiency.Name = "Efficiency";
            this.Efficiency.Size = new System.Drawing.Size(197, 73);
            this.Efficiency.TabIndex = 0;
            // 
            // Model
            // 
            this.Model.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Model.Appearance.Options.UseFont = true;
            this.Model.Location = new System.Drawing.Point(0, 73);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(197, 36);
            this.Model.TabIndex = 1;
            // 
            // dxTypeEffDigital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Model);
            this.Controls.Add(this.Efficiency);
            this.Name = "dxTypeEffDigital";
            this.Size = new System.Drawing.Size(198, 110);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton Efficiency;
        public DevExpress.XtraEditors.SimpleButton Model;

    }
}
