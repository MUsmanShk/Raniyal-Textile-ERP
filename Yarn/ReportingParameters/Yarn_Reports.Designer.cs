namespace MachineEyes.Yarn.ReportingParameters
{
    partial class Yarn_Reports
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
            this.reportControlParent.Size = new System.Drawing.Size(426, 163);
            this.reportControlParent.TabIndex = 1;
            // 
            // Yarn_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 163);
            this.ControlBox = false;
            this.Controls.Add(this.reportControlParent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Yarn_Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.reportControlParent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.PanelControl reportControlParent;
    }
}