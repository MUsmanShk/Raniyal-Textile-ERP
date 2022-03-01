namespace MachineEyes.Debug
{
    partial class Debug_SinkClients
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
            this.ClientsList = new System.Windows.Forms.ListView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ClientsList
            // 
            this.ClientsList.BackColor = System.Drawing.SystemColors.Control;
            this.ClientsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientsList.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientsList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ClientsList.Location = new System.Drawing.Point(0, 0);
            this.ClientsList.Name = "ClientsList";
            this.ClientsList.Size = new System.Drawing.Size(1008, 730);
            this.ClientsList.TabIndex = 4;
            this.ClientsList.UseCompatibleStateImageBehavior = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Debug_SinkClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.ClientsList);
            this.Name = "Debug_SinkClients";
            this.Text = "Coordinators Attached";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView ClientsList;
        private System.Windows.Forms.Timer timer1;
    }
}