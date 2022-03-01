namespace MachineEyes.LDS.ReportingParameters
{
    partial class xu_MachineLog
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
            this.dUpto = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dFrom = new DevExpress.XtraEditors.DateEdit();
            this.Radio_RecordsType = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.LongStopMinutes = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.Close = new DevExpress.XtraEditors.SimpleButton();
            this.SelectDate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dUpto.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dUpto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radio_RecordsType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LongStopMinutes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dUpto
            // 
            this.dUpto.EditValue = null;
            this.dUpto.Location = new System.Drawing.Point(52, 39);
            this.dUpto.Name = "dUpto";
            this.dUpto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dUpto.Properties.DisplayFormat.FormatString = "dddd, MMMM dd, yyyy hh:mm:ss tt";
            this.dUpto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dUpto.Properties.EditFormat.FormatString = "dddd, MMMM dd, yyyy hh:mm:ss tt";
            this.dUpto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dUpto.Properties.Mask.EditMask = "dddd, MMMM dd, yyyy hh:mm:ss tt";
            this.dUpto.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dUpto.Size = new System.Drawing.Size(333, 20);
            this.dUpto.TabIndex = 211;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(16, 13);
            this.labelControl2.TabIndex = 208;
            this.labelControl2.Text = "To:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 207;
            this.labelControl1.Text = "From:";
            // 
            // dFrom
            // 
            this.dFrom.EditValue = null;
            this.dFrom.Location = new System.Drawing.Point(52, 13);
            this.dFrom.Name = "dFrom";
            this.dFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dFrom.Properties.DisplayFormat.FormatString = "dddd, MMMM dd, yyyy hh:mm:ss tt";
            this.dFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dFrom.Properties.EditFormat.FormatString = "dddd, MMMM dd, yyyy hh:mm:ss tt";
            this.dFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dFrom.Properties.Mask.EditMask = "dddd, MMMM dd, yyyy hh:mm:ss tt";
            this.dFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dFrom.Size = new System.Drawing.Size(333, 20);
            this.dFrom.TabIndex = 206;
            // 
            // Radio_RecordsType
            // 
            this.Radio_RecordsType.EditValue = "1";
            this.Radio_RecordsType.Location = new System.Drawing.Point(52, 65);
            this.Radio_RecordsType.Name = "Radio_RecordsType";
            this.Radio_RecordsType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "All Records"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Long Stops"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "Short Stops"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "All Stops only"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("4", "All Running")});
            this.Radio_RecordsType.Size = new System.Drawing.Size(285, 59);
            this.Radio_RecordsType.TabIndex = 212;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(268, 170);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(19, 13);
            this.labelControl3.TabIndex = 213;
            this.labelControl3.Text = " >=";
            // 
            // LongStopMinutes
            // 
            this.LongStopMinutes.EditValue = "5";
            this.LongStopMinutes.Location = new System.Drawing.Point(293, 167);
            this.LongStopMinutes.Name = "LongStopMinutes";
            this.LongStopMinutes.Size = new System.Drawing.Size(44, 20);
            this.LongStopMinutes.TabIndex = 214;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(343, 170);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 215;
            this.labelControl4.Text = "Minute(s)";
            // 
            // Close
            // 
            this.Close.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.Appearance.Options.UseFont = true;
            this.Close.Image = global::MachineEyes.Properties.Resources.Close16;
            this.Close.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Close.Location = new System.Drawing.Point(359, 197);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(26, 25);
            this.Close.TabIndex = 210;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // SelectDate
            // 
            this.SelectDate.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDate.Appearance.Options.UseFont = true;
            this.SelectDate.Image = global::MachineEyes.Properties.Resources.Execute;
            this.SelectDate.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SelectDate.Location = new System.Drawing.Point(327, 197);
            this.SelectDate.Name = "SelectDate";
            this.SelectDate.Size = new System.Drawing.Size(26, 25);
            this.SelectDate.TabIndex = 209;
            this.SelectDate.Click += new System.EventHandler(this.SelectDate_Click);
            // 
            // xu_MachineLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.LongStopMinutes);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.Radio_RecordsType);
            this.Controls.Add(this.dUpto);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.SelectDate);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dFrom);
            this.Name = "xu_MachineLog";
            this.Size = new System.Drawing.Size(509, 248);
            ((System.ComponentModel.ISupportInitialize)(this.dUpto.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dUpto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radio_RecordsType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LongStopMinutes.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dUpto;
        private DevExpress.XtraEditors.SimpleButton Close;
        private DevExpress.XtraEditors.SimpleButton SelectDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dFrom;
        private DevExpress.XtraEditors.RadioGroup Radio_RecordsType;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit LongStopMinutes;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
