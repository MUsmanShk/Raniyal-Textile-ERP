namespace MachineEyes.View
{
    partial class Dashboard_DigitalDisplay
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
            this.timer_AutoRefresh = new System.Windows.Forms.Timer(this.components);
            this.ShedEfficiency = new DevExpress.XtraEditors.SimpleButton();
            this.scrollLooms = new DevExpress.XtraEditors.XtraScrollableControl();
            this.SuspendLayout();
            // 
            // timer_AutoRefresh
            // 
            this.timer_AutoRefresh.Enabled = true;
            this.timer_AutoRefresh.Interval = 10;
            this.timer_AutoRefresh.Tick += new System.EventHandler(this.timer_AutoRefresh_Tick);
            // 
            // ShedEfficiency
            // 
            this.ShedEfficiency.Appearance.BackColor = System.Drawing.Color.Black;
            this.ShedEfficiency.Appearance.Font = new System.Drawing.Font("Digital-7", 200.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShedEfficiency.Appearance.ForeColor = System.Drawing.Color.Lime;
            this.ShedEfficiency.Appearance.Options.UseBackColor = true;
            this.ShedEfficiency.Appearance.Options.UseFont = true;
            this.ShedEfficiency.Appearance.Options.UseForeColor = true;
            this.ShedEfficiency.Appearance.Options.UseTextOptions = true;
            this.ShedEfficiency.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ShedEfficiency.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ShedEfficiency.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.ShedEfficiency.Location = new System.Drawing.Point(1, 570);
            this.ShedEfficiency.Name = "ShedEfficiency";
            this.ShedEfficiency.Size = new System.Drawing.Size(1019, 195);
            this.ShedEfficiency.TabIndex = 2;
            this.ShedEfficiency.Tag = "0";
            this.ShedEfficiency.Text = "89.5";
            // 
            // scrollLooms
            // 
            this.scrollLooms.AlwaysScrollActiveControlIntoView = false;
            this.scrollLooms.AutoScroll = false;
            this.scrollLooms.Location = new System.Drawing.Point(1, 5);
            this.scrollLooms.Name = "scrollLooms";
            this.scrollLooms.Size = new System.Drawing.Size(1019, 561);
            this.scrollLooms.TabIndex = 5;
            // 
            // Dashboard_DigitalDisplay
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.ShedEfficiency);
            this.Controls.Add(this.scrollLooms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Dashboard_DigitalDisplay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_DigitalDisplay_FormClosing);
            this.Load += new System.EventHandler(this.Dashboard_DigitalDisplay_Load);
            this.Enter += new System.EventHandler(this.Dashboard_DigitalDisplay_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dashboard_DigitalDisplay_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_AutoRefresh;
        private DevExpress.XtraEditors.SimpleButton ShedEfficiency;
        public DevExpress.XtraEditors.XtraScrollableControl scrollLooms;
    }
}