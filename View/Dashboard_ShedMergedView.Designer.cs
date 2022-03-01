namespace MachineEyes
{
    partial class Dashboard_ShedMergedView
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
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.timer_AutoRefresh = new System.Windows.Forms.Timer(this.components);
            this.dxShed1 = new MachineEyes.dxShed();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1362, 559);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            this.panelControl1.Enter += new System.EventHandler(this.panelControl1_Enter);
            // 
            // timer_AutoRefresh
            // 
            this.timer_AutoRefresh.Enabled = true;
            this.timer_AutoRefresh.Interval = 1000;
            this.timer_AutoRefresh.Tick += new System.EventHandler(this.timer_AutoRefresh_Tick);
            // 
            // dxShed1
            // 
            this.dxShed1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dxShed1.Location = new System.Drawing.Point(0, 565);
            this.dxShed1.Name = "dxShed1";
            this.dxShed1.Size = new System.Drawing.Size(1362, 183);
            this.dxShed1.TabIndex = 0;
            this.dxShed1.Load += new System.EventHandler(this.dxShed1_Load);
            // 
            // Dashboard_Shed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 748);
            this.Controls.Add(this.dxShed1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Dashboard_Shed";
            this.Text = "Shed Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_Shed_FormClosing);
            this.Load += new System.EventHandler(this.dxShedView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Timer timer_AutoRefresh;
        private dxShed dxShed1;

    }
}