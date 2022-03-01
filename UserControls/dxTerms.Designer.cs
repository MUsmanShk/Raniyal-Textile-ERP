namespace MachineEyes.UserControls
{
    partial class dxTerms
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
            this.Terms = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Terms.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Terms
            // 
            this.Terms.EnterMoveNextControl = true;
            this.Terms.Location = new System.Drawing.Point(0, 0);
            this.Terms.Name = "Terms";
            this.Terms.Size = new System.Drawing.Size(802, 20);
            this.Terms.TabIndex = 0;
            this.Terms.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Terms_KeyDown);
            this.Terms.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Terms_KeyPress);
            // 
            // dxTerms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Terms);
            this.Name = "dxTerms";
            this.Size = new System.Drawing.Size(804, 20);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dxTerms_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Terms.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit Terms;

    }
}
