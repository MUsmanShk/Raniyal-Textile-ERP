namespace MachineEyes
{
    partial class DashBoard_Shed_MakeView
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
            this.dxMMSBottom1 = new MachineEyes.UserControls.dxMMSBottom();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1008, 578);
            this.panelControl1.TabIndex = 1;
            // 
            // timer_AutoRefresh
            // 
            this.timer_AutoRefresh.Enabled = true;
            this.timer_AutoRefresh.Interval = 1000;
            this.timer_AutoRefresh.Tick += new System.EventHandler(this.timer_AutoRefresh_Tick);
            // 
            // dxMMSBottom1
            // 
            this.dxMMSBottom1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dxMMSBottom1.Location = new System.Drawing.Point(0, 584);
            this.dxMMSBottom1.Name = "dxMMSBottom1";
            this.dxMMSBottom1.Size = new System.Drawing.Size(1008, 146);
            this.dxMMSBottom1.TabIndex = 2;
            // 
            // DashBoard_Shed_MakeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.dxMMSBottom1);
            this.Controls.Add(this.panelControl1);
            this.Name = "DashBoard_Shed_MakeView";
            this.Text = "Make / Model Shed View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DashBoard_Shed_MakeView_FormClosing);
            this.Load += new System.EventHandler(this.DashBoard_Shed_MakeView_Load);
            this.Enter += new System.EventHandler(this.DashBoard_Shed_MakeView_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Timer timer_AutoRefresh;
        private UserControls.dxMMSBottom dxMMSBottom1;
    }
}