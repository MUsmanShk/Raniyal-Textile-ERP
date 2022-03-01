namespace MachineEyes.Accounts.ReportingParameters
{
    partial class MultiReports
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
            this.reportControlParent = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.reportControlParent)).BeginInit();
            this.SuspendLayout();
            // 
            // reportControlParent
            // 
            this.reportControlParent.AutoSize = true;
            this.reportControlParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportControlParent.Location = new System.Drawing.Point(0, 0);
            this.reportControlParent.Name = "reportControlParent";
            this.reportControlParent.Size = new System.Drawing.Size(403, 159);
            this.reportControlParent.TabIndex = 0;
            // 
            // MultiReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(403, 159);
            this.ControlBox = false;
            this.Controls.Add(this.reportControlParent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "MultiReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MultiReports_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.reportControlParent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.PanelControl reportControlParent;


    }
}