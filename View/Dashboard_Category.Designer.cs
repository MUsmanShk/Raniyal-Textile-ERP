namespace MachineEyes
{
    partial class Dashboard_Category 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard_Category));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.timer_AutoRefresh = new System.Windows.Forms.Timer(this.components);
            this.CauseImages = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CauseImages)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1598, 921);
            this.panelControl1.TabIndex = 0;
            // 
            // timer_AutoRefresh
            // 
            this.timer_AutoRefresh.Enabled = true;
            this.timer_AutoRefresh.Interval = 1000;
            this.timer_AutoRefresh.Tick += new System.EventHandler(this.timer_AutoRefresh_Tick);
            // 
            // CauseImages
            // 
            this.CauseImages.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("CauseImages.ImageStream")));
            this.CauseImages.Images.SetKeyName(0, "Unknown");
            this.CauseImages.Images.SetKeyName(1, "Warp");
            this.CauseImages.Images.SetKeyName(2, "Weft");
            this.CauseImages.Images.SetKeyName(3, "Leno");
            this.CauseImages.Images.SetKeyName(4, "Other");
            this.CauseImages.Images.SetKeyName(5, "Pile");
            this.CauseImages.Images.SetKeyName(6, "Mechanical");
            this.CauseImages.Images.SetKeyName(7, "Electrical");
            this.CauseImages.Images.SetKeyName(8, "Knotting");
            this.CauseImages.Images.SetKeyName(9, "Article");
            this.CauseImages.Images.SetKeyName(10, "OtherLong");
            this.CauseImages.Images.SetKeyName(11, "PowerOff");
            this.CauseImages.Images.SetKeyName(12, "LongStop_5");
            this.CauseImages.Images.SetKeyName(13, "LongStop_6");
            this.CauseImages.Images.SetKeyName(14, "LongStop_7");
            this.CauseImages.Images.SetKeyName(15, "LongStop_8");
            this.CauseImages.Images.SetKeyName(16, "LongStop_9");
            this.CauseImages.Images.SetKeyName(17, "waiting.png");
            // 
            // Dashboard_Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1598, 921);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Dashboard_Category";
            this.Text = "Category Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Category_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CauseImages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Timer timer_AutoRefresh;
        public DevExpress.Utils.ImageCollection CauseImages;

    }
}