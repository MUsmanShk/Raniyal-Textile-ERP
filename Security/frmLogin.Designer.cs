namespace MachineEyes
{
    partial class frmLogin
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_Login = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit_IP = new DevExpress.XtraEditors.ComboBoxEdit();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.radioButton_WAN = new System.Windows.Forms.RadioButton();
            this.radioButton_LAN = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.finYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.ServiceMode = new DevExpress.XtraEditors.GroupControl();
            this.ERPOnly = new System.Windows.Forms.RadioButton();
            this.MonitoringAndERP = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.simpleButton_Close = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Login = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit_Password = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Login.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_IP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceMode)).BeginInit();
            this.ServiceMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(154, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(25, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Login";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(154, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Password";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(154, 63);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "IP Address";
            // 
            // textEdit_Login
            // 
            this.textEdit_Login.EditValue = "";
            this.textEdit_Login.EnterMoveNextControl = true;
            this.textEdit_Login.Location = new System.Drawing.Point(224, 8);
            this.textEdit_Login.Name = "textEdit_Login";
            this.textEdit_Login.Properties.NullValuePrompt = "User ID";
            this.textEdit_Login.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEdit_Login.Size = new System.Drawing.Size(100, 20);
            this.textEdit_Login.TabIndex = 0;
            // 
            // comboBoxEdit_IP
            // 
            this.comboBoxEdit_IP.EnterMoveNextControl = true;
            this.comboBoxEdit_IP.Location = new System.Drawing.Point(224, 60);
            this.comboBoxEdit_IP.Name = "comboBoxEdit_IP";
            this.comboBoxEdit_IP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_IP.Properties.NullValuePrompt = "IP Address of Machine Eyes ERP Server";
            this.comboBoxEdit_IP.Properties.NullValuePromptShowForEmptyValue = true;
            this.comboBoxEdit_IP.Size = new System.Drawing.Size(218, 20);
            this.comboBoxEdit_IP.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.groupControl1.Controls.Add(this.radioButton_WAN);
            this.groupControl1.Controls.Add(this.radioButton_LAN);
            this.groupControl1.Location = new System.Drawing.Point(221, 110);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(138, 34);
            this.groupControl1.TabIndex = 13;
            this.groupControl1.Text = "Mode";
            // 
            // radioButton_WAN
            // 
            this.radioButton_WAN.AutoSize = true;
            this.radioButton_WAN.Location = new System.Drawing.Point(84, 8);
            this.radioButton_WAN.Name = "radioButton_WAN";
            this.radioButton_WAN.Size = new System.Drawing.Size(49, 17);
            this.radioButton_WAN.TabIndex = 1;
            this.radioButton_WAN.Text = "WAN";
            this.radioButton_WAN.UseVisualStyleBackColor = true;
            // 
            // radioButton_LAN
            // 
            this.radioButton_LAN.AutoSize = true;
            this.radioButton_LAN.Checked = true;
            this.radioButton_LAN.Location = new System.Drawing.Point(5, 8);
            this.radioButton_LAN.Name = "radioButton_LAN";
            this.radioButton_LAN.Size = new System.Drawing.Size(44, 17);
            this.radioButton_LAN.TabIndex = 0;
            this.radioButton_LAN.TabStop = true;
            this.radioButton_LAN.Text = "LAN";
            this.radioButton_LAN.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // finYear
            // 
            this.finYear.EnterMoveNextControl = true;
            this.finYear.Location = new System.Drawing.Point(224, 84);
            this.finYear.Name = "finYear";
            this.finYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.finYear.Size = new System.Drawing.Size(82, 20);
            this.finYear.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(154, 87);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(66, 13);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Financial Year";
            // 
            // ServiceMode
            // 
            this.ServiceMode.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.ServiceMode.Controls.Add(this.ERPOnly);
            this.ServiceMode.Controls.Add(this.MonitoringAndERP);
            this.ServiceMode.Location = new System.Drawing.Point(221, 150);
            this.ServiceMode.Name = "ServiceMode";
            this.ServiceMode.ShowCaption = false;
            this.ServiceMode.Size = new System.Drawing.Size(218, 58);
            this.ServiceMode.TabIndex = 16;
            // 
            // ERPOnly
            // 
            this.ERPOnly.AutoSize = true;
            this.ERPOnly.Location = new System.Drawing.Point(5, 31);
            this.ERPOnly.Name = "ERPOnly";
            this.ERPOnly.Size = new System.Drawing.Size(69, 17);
            this.ERPOnly.TabIndex = 1;
            this.ERPOnly.Text = "ERP Only";
            this.ERPOnly.UseVisualStyleBackColor = true;
            // 
            // MonitoringAndERP
            // 
            this.MonitoringAndERP.AutoSize = true;
            this.MonitoringAndERP.Checked = true;
            this.MonitoringAndERP.Location = new System.Drawing.Point(5, 8);
            this.MonitoringAndERP.Name = "MonitoringAndERP";
            this.MonitoringAndERP.Size = new System.Drawing.Size(107, 17);
            this.MonitoringAndERP.TabIndex = 0;
            this.MonitoringAndERP.TabStop = true;
            this.MonitoringAndERP.Text = "Monitoring && ERP";
            this.MonitoringAndERP.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MachineEyes.Properties.Resources.keys;
            this.pictureBox1.Location = new System.Drawing.Point(12, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // simpleButton_Close
            // 
            this.simpleButton_Close.Image = global::MachineEyes.Properties.Resources.Close16;
            this.simpleButton_Close.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton_Close.Location = new System.Drawing.Point(405, 110);
            this.simpleButton_Close.Name = "simpleButton_Close";
            this.simpleButton_Close.Size = new System.Drawing.Size(34, 34);
            this.simpleButton_Close.TabIndex = 5;
            this.simpleButton_Close.Click += new System.EventHandler(this.simpleButton_Close_Click);
            // 
            // simpleButton_Login
            // 
            this.simpleButton_Login.Image = global::MachineEyes.Properties.Resources.SecurityAllowed;
            this.simpleButton_Login.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton_Login.Location = new System.Drawing.Point(365, 110);
            this.simpleButton_Login.Name = "simpleButton_Login";
            this.simpleButton_Login.Size = new System.Drawing.Size(34, 34);
            this.simpleButton_Login.TabIndex = 4;
            this.simpleButton_Login.Click += new System.EventHandler(this.simpleButton_Login_Click);
            // 
            // textEdit_Password
            // 
            this.textEdit_Password.Location = new System.Drawing.Point(224, 33);
            this.textEdit_Password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textEdit_Password.Name = "textEdit_Password";
            this.textEdit_Password.PasswordChar = '*';
            this.textEdit_Password.Size = new System.Drawing.Size(119, 21);
            this.textEdit_Password.TabIndex = 17;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 210);
            this.ControlBox = false;
            this.Controls.Add(this.textEdit_Password);
            this.Controls.Add(this.ServiceMode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.finYear);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.simpleButton_Close);
            this.Controls.Add(this.simpleButton_Login);
            this.Controls.Add(this.comboBoxEdit_IP);
            this.Controls.Add(this.textEdit_Login);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login Machine Eyes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Login.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_IP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceMode)).EndInit();
            this.ServiceMode.ResumeLayout(false);
            this.ServiceMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEdit_Login;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_IP;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Login;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Close;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.RadioButton radioButton_WAN;
        private System.Windows.Forms.RadioButton radioButton_LAN;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.ComboBoxEdit finYear;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.GroupControl ServiceMode;
        private System.Windows.Forms.RadioButton ERPOnly;
        private System.Windows.Forms.RadioButton MonitoringAndERP;
        private System.Windows.Forms.TextBox textEdit_Password;
    }
}