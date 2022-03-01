namespace MachineEyes.Debug
{
    partial class udDevice
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
            this.currentMAC = new System.Windows.Forms.ToolStripTextBox();
            this.setMACAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.currentPauseSeconds = new System.Windows.Forms.ToolStripTextBox();
            this.setPauseSecondstoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DeviceType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.isEnabled = new System.Windows.Forms.TextBox();
            this.PauseSeconds = new System.Windows.Forms.TextBox();
            this.MultipleSheds = new System.Windows.Forms.TextBox();
            this.Shed_3 = new System.Windows.Forms.TextBox();
            this.Shed_2 = new System.Windows.Forms.TextBox();
            this.Shed_1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.RemotePort = new System.Windows.Forms.TextBox();
            this.DeviceName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DeviceID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ClientsList = new System.Windows.Forms.ListView();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.setMACAddressToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.setMACAddressToolStripMenuItem.Text = "Set MAC Address";
            this.setMACAddressToolStripMenuItem.Click += new System.EventHandler(this.setMACAddressToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentMAC,
            this.setMACAddressToolStripMenuItem,
            this.currentPauseSeconds,
            this.setPauseSecondstoolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(213, 99);
            // 
            // currentPauseSeconds
            // 
            this.currentPauseSeconds.Name = "currentPauseSeconds";
            this.currentPauseSeconds.Size = new System.Drawing.Size(100, 23);
            // 
            // setPauseSecondstoolStripMenuItem
            // 
            this.setPauseSecondstoolStripMenuItem.Name = "setPauseSecondstoolStripMenuItem";
            this.setPauseSecondstoolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.setPauseSecondstoolStripMenuItem.Text = "Set Display Pause Seconds";
            this.setPauseSecondstoolStripMenuItem.Click += new System.EventHandler(this.setPauseSecondstoolStripMenuItem_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 2000;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Multiple Sheds";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "ID";
            // 
            // DeviceType
            // 
            this.DeviceType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DeviceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceType.Location = new System.Drawing.Point(87, 50);
            this.DeviceType.Name = "DeviceType";
            this.DeviceType.Size = new System.Drawing.Size(383, 20);
            this.DeviceType.TabIndex = 20;
            this.DeviceType.Text = "0";
            this.DeviceType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Remote Port";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.isEnabled);
            this.groupBox1.Controls.Add(this.PauseSeconds);
            this.groupBox1.Controls.Add(this.MultipleSheds);
            this.groupBox1.Controls.Add(this.Shed_3);
            this.groupBox1.Controls.Add(this.Shed_2);
            this.groupBox1.Controls.Add(this.Shed_1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.RemotePort);
            this.groupBox1.Controls.Add(this.DeviceName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DeviceID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DeviceType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 160);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device info";
            // 
            // isEnabled
            // 
            this.isEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isEnabled.Location = new System.Drawing.Point(348, 120);
            this.isEnabled.Name = "isEnabled";
            this.isEnabled.Size = new System.Drawing.Size(59, 22);
            this.isEnabled.TabIndex = 40;
            // 
            // PauseSeconds
            // 
            this.PauseSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseSeconds.Location = new System.Drawing.Point(192, 95);
            this.PauseSeconds.Name = "PauseSeconds";
            this.PauseSeconds.Size = new System.Drawing.Size(135, 22);
            this.PauseSeconds.TabIndex = 39;
            // 
            // MultipleSheds
            // 
            this.MultipleSheds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultipleSheds.Location = new System.Drawing.Point(348, 72);
            this.MultipleSheds.Name = "MultipleSheds";
            this.MultipleSheds.Size = new System.Drawing.Size(59, 22);
            this.MultipleSheds.TabIndex = 38;
            // 
            // Shed_3
            // 
            this.Shed_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shed_3.Location = new System.Drawing.Point(157, 72);
            this.Shed_3.Name = "Shed_3";
            this.Shed_3.Size = new System.Drawing.Size(29, 22);
            this.Shed_3.TabIndex = 37;
            // 
            // Shed_2
            // 
            this.Shed_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shed_2.Location = new System.Drawing.Point(122, 72);
            this.Shed_2.Name = "Shed_2";
            this.Shed_2.Size = new System.Drawing.Size(29, 22);
            this.Shed_2.TabIndex = 36;
            // 
            // Shed_1
            // 
            this.Shed_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shed_1.Location = new System.Drawing.Point(87, 73);
            this.Shed_1.Name = "Shed_1";
            this.Shed_1.Size = new System.Drawing.Size(29, 22);
            this.Shed_1.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(192, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "Enabled";
            // 
            // label29
            // 
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(14, 97);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(172, 20);
            this.label29.TabIndex = 31;
            this.label29.Text = "Pause (Seconds)";
            // 
            // RemotePort
            // 
            this.RemotePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemotePort.Location = new System.Drawing.Point(123, 120);
            this.RemotePort.Name = "RemotePort";
            this.RemotePort.Size = new System.Drawing.Size(55, 22);
            this.RemotePort.TabIndex = 29;
            // 
            // DeviceName
            // 
            this.DeviceName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceName.Location = new System.Drawing.Point(123, 28);
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.Size = new System.Drawing.Size(348, 20);
            this.DeviceName.TabIndex = 28;
            this.DeviceName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Type";
            // 
            // DeviceID
            // 
            this.DeviceID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DeviceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceID.Location = new System.Drawing.Point(88, 28);
            this.DeviceID.Name = "DeviceID";
            this.DeviceID.Size = new System.Drawing.Size(28, 20);
            this.DeviceID.TabIndex = 26;
            this.DeviceID.Text = "0";
            this.DeviceID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Shed ID";
            // 
            // ClientsList
            // 
            this.ClientsList.BackColor = System.Drawing.SystemColors.Control;
            this.ClientsList.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientsList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ClientsList.Location = new System.Drawing.Point(5, 172);
            this.ClientsList.Name = "ClientsList";
            this.ClientsList.Size = new System.Drawing.Size(481, 206);
            this.ClientsList.TabIndex = 29;
            this.ClientsList.UseCompatibleStateImageBehavior = false;
            // 
            // udDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ClientsList);
            this.Controls.Add(this.groupBox1);
            this.Name = "udDevice";
            this.Size = new System.Drawing.Size(492, 383);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.udDevice_MouseDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripTextBox currentMAC;
        private System.Windows.Forms.ToolStripMenuItem setMACAddressToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label DeviceType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label DeviceID;
        public System.Windows.Forms.Label DeviceName;
        public System.Windows.Forms.TextBox RemotePort;
        private System.Windows.Forms.ToolStripTextBox currentPauseSeconds;
        private System.Windows.Forms.ToolStripMenuItem setPauseSecondstoolStripMenuItem;
        private System.Windows.Forms.Label label29;
        public System.Windows.Forms.TextBox isEnabled;
        public System.Windows.Forms.TextBox PauseSeconds;
        public System.Windows.Forms.TextBox MultipleSheds;
        public System.Windows.Forms.TextBox Shed_3;
        public System.Windows.Forms.TextBox Shed_2;
        public System.Windows.Forms.TextBox Shed_1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ListView ClientsList;
    }
}
