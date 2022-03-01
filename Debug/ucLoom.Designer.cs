namespace MachineEyes.Debug
{
    partial class ucLoom
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
            this.components = new System.ComponentModel.Container();
            this.lblLoomNumber = new System.Windows.Forms.Label();
            this.lblRPM = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblStateAndCause = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.NewCounterFetched = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enableDebuggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableDebuggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.enableZbStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableZbStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.currentMAC = new System.Windows.Forms.ToolStripTextBox();
            this.setMACAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentCASSeconds = new System.Windows.Forms.ToolStripTextBox();
            this.setCASSecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentLRFID = new System.Windows.Forms.ToolStripTextBox();
            this.setRFIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Picks = new System.Windows.Forms.Label();
            this.SinkNumber = new System.Windows.Forms.Label();
            this.ShedID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RFID = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLoomNumber
            // 
            this.lblLoomNumber.BackColor = System.Drawing.Color.Yellow;
            this.lblLoomNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLoomNumber.ForeColor = System.Drawing.Color.Black;
            this.lblLoomNumber.Location = new System.Drawing.Point(31, 3);
            this.lblLoomNumber.Name = "lblLoomNumber";
            this.lblLoomNumber.Size = new System.Drawing.Size(40, 16);
            this.lblLoomNumber.TabIndex = 0;
            this.lblLoomNumber.Text = "1";
            this.lblLoomNumber.DoubleClick += new System.EventHandler(this.lblLoomNumber_DoubleClick);
            // 
            // lblRPM
            // 
            this.lblRPM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRPM.ForeColor = System.Drawing.Color.White;
            this.lblRPM.Location = new System.Drawing.Point(75, 3);
            this.lblRPM.Name = "lblRPM";
            this.lblRPM.Size = new System.Drawing.Size(36, 16);
            this.lblRPM.TabIndex = 1;
            this.lblRPM.Text = "897.2";
            this.lblRPM.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCounter
            // 
            this.lblCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounter.ForeColor = System.Drawing.Color.White;
            this.lblCounter.Location = new System.Drawing.Point(75, 21);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(36, 19);
            this.lblCounter.TabIndex = 2;
            this.lblCounter.Text = "1";
            this.lblCounter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.lblCounter, "Normal");
            // 
            // lblTime
            // 
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTime.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(3, 21);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(68, 19);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "30 min 2 sec";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStateAndCause
            // 
            this.lblStateAndCause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStateAndCause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStateAndCause.ForeColor = System.Drawing.Color.White;
            this.lblStateAndCause.Location = new System.Drawing.Point(3, 58);
            this.lblStateAndCause.Name = "lblStateAndCause";
            this.lblStateAndCause.Size = new System.Drawing.Size(108, 16);
            this.lblStateAndCause.TabIndex = 4;
            this.lblStateAndCause.Text = "RUNNING";
            this.lblStateAndCause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 2000;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            // 
            // NewCounterFetched
            // 
            this.NewCounterFetched.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewCounterFetched.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewCounterFetched.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCounterFetched.ForeColor = System.Drawing.Color.White;
            this.NewCounterFetched.Location = new System.Drawing.Point(3, 41);
            this.NewCounterFetched.Name = "NewCounterFetched";
            this.NewCounterFetched.Size = new System.Drawing.Size(108, 16);
            this.NewCounterFetched.TabIndex = 6;
            this.NewCounterFetched.Text = "30 min 2 sec";
            this.NewCounterFetched.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableDebuggingToolStripMenuItem,
            this.disableDebuggingToolStripMenuItem,
            this.toolStripMenuItem1,
            this.enableZbStateToolStripMenuItem,
            this.disableZbStateToolStripMenuItem,
            this.toolStripMenuItem2,
            this.currentMAC,
            this.setMACAddressToolStripMenuItem,
            this.currentCASSeconds,
            this.setCASSecondsToolStripMenuItem,
            this.currentLRFID,
            this.setRFIDToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 246);
            // 
            // enableDebuggingToolStripMenuItem
            // 
            this.enableDebuggingToolStripMenuItem.Name = "enableDebuggingToolStripMenuItem";
            this.enableDebuggingToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.enableDebuggingToolStripMenuItem.Text = "Enable Debugging";
            // 
            // disableDebuggingToolStripMenuItem
            // 
            this.disableDebuggingToolStripMenuItem.Name = "disableDebuggingToolStripMenuItem";
            this.disableDebuggingToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.disableDebuggingToolStripMenuItem.Text = "Disable Debugging";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(207, 6);
            // 
            // enableZbStateToolStripMenuItem
            // 
            this.enableZbStateToolStripMenuItem.Name = "enableZbStateToolStripMenuItem";
            this.enableZbStateToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.enableZbStateToolStripMenuItem.Text = "Enable zbState";
            // 
            // disableZbStateToolStripMenuItem
            // 
            this.disableZbStateToolStripMenuItem.Name = "disableZbStateToolStripMenuItem";
            this.disableZbStateToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.disableZbStateToolStripMenuItem.Text = "Disable zbState";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(207, 6);
            // 
            // currentMAC
            // 
            this.currentMAC.AutoSize = false;
            this.currentMAC.Font = new System.Drawing.Font("Tahoma", 10F);
            this.currentMAC.Name = "currentMAC";
            this.currentMAC.Size = new System.Drawing.Size(150, 24);
            // 
            // setMACAddressToolStripMenuItem
            // 
            this.setMACAddressToolStripMenuItem.Name = "setMACAddressToolStripMenuItem";
            this.setMACAddressToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.setMACAddressToolStripMenuItem.Text = "Set MAC Address";
            this.setMACAddressToolStripMenuItem.Click += new System.EventHandler(this.setMACAddressToolStripMenuItem_Click);
            // 
            // currentCASSeconds
            // 
            this.currentCASSeconds.Name = "currentCASSeconds";
            this.currentCASSeconds.Size = new System.Drawing.Size(100, 23);
            // 
            // setCASSecondsToolStripMenuItem
            // 
            this.setCASSecondsToolStripMenuItem.Name = "setCASSecondsToolStripMenuItem";
            this.setCASSecondsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.setCASSecondsToolStripMenuItem.Text = "Set CASSeconds";
            // 
            // currentLRFID
            // 
            this.currentLRFID.Name = "currentLRFID";
            this.currentLRFID.Size = new System.Drawing.Size(100, 23);
            // 
            // setRFIDToolStripMenuItem
            // 
            this.setRFIDToolStripMenuItem.Name = "setRFIDToolStripMenuItem";
            this.setRFIDToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.setRFIDToolStripMenuItem.Text = "Set RFID";
            this.setRFIDToolStripMenuItem.Click += new System.EventHandler(this.setRFIDToolStripMenuItem_Click);
            // 
            // Picks
            // 
            this.Picks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Picks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Picks.ForeColor = System.Drawing.Color.White;
            this.Picks.Location = new System.Drawing.Point(45, 75);
            this.Picks.Name = "Picks";
            this.Picks.Size = new System.Drawing.Size(66, 16);
            this.Picks.TabIndex = 8;
            this.Picks.Text = "0";
            this.Picks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SinkNumber
            // 
            this.SinkNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SinkNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SinkNumber.ForeColor = System.Drawing.Color.White;
            this.SinkNumber.Location = new System.Drawing.Point(3, 93);
            this.SinkNumber.Name = "SinkNumber";
            this.SinkNumber.Size = new System.Drawing.Size(108, 14);
            this.SinkNumber.TabIndex = 9;
            this.SinkNumber.Text = "0";
            this.SinkNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShedID
            // 
            this.ShedID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ShedID.ForeColor = System.Drawing.Color.White;
            this.ShedID.Location = new System.Drawing.Point(3, 3);
            this.ShedID.Name = "ShedID";
            this.ShedID.Size = new System.Drawing.Size(22, 16);
            this.ShedID.TabIndex = 10;
            this.ShedID.Text = "1";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Picks";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "RFID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RFID
            // 
            this.RFID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RFID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RFID.ForeColor = System.Drawing.Color.White;
            this.RFID.Location = new System.Drawing.Point(27, 109);
            this.RFID.Name = "RFID";
            this.RFID.Size = new System.Drawing.Size(84, 16);
            this.RFID.TabIndex = 13;
            this.RFID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucLoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.RFID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShedID);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.SinkNumber);
            this.Controls.Add(this.Picks);
            this.Controls.Add(this.lblStateAndCause);
            this.Controls.Add(this.NewCounterFetched);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblLoomNumber);
            this.Controls.Add(this.lblRPM);
            this.Name = "ucLoom";
            this.Size = new System.Drawing.Size(115, 131);
            this.Load += new System.EventHandler(this.ucLoom_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucLoom_MouseDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblLoomNumber;
        public System.Windows.Forms.Label lblRPM;
        public System.Windows.Forms.Label lblCounter;
        public System.Windows.Forms.Label lblTime;
        public System.Windows.Forms.Label lblStateAndCause;
        public System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Label NewCounterFetched;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem enableDebuggingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableDebuggingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem enableZbStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableZbStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setMACAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripTextBox currentMAC;
        public System.Windows.Forms.Label Picks;
        public System.Windows.Forms.Label SinkNumber;
        private System.Windows.Forms.ToolStripTextBox currentCASSeconds;
        private System.Windows.Forms.ToolStripMenuItem setCASSecondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox currentLRFID;
        private System.Windows.Forms.ToolStripMenuItem setRFIDToolStripMenuItem;
        public System.Windows.Forms.Label ShedID;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label RFID;

    }
}
