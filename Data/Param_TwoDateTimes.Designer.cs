namespace MachineEyes.Data
{
    partial class Param_TwoDateTimes
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
            this.dUpto = new DevExpress.XtraEditors.DateEdit();
            this.SelectDate = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dFrom = new DevExpress.XtraEditors.DateEdit();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dUpto.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dUpto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dUpto
            // 
            this.dUpto.EditValue = null;
            this.dUpto.Location = new System.Drawing.Point(57, 38);
            this.dUpto.Name = "dUpto";
            this.dUpto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dUpto.Properties.DisplayFormat.FormatString = "g";
            this.dUpto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dUpto.Properties.EditFormat.FormatString = "g";
            this.dUpto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dUpto.Properties.Mask.EditMask = "g";
            this.dUpto.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dUpto.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dUpto.Size = new System.Drawing.Size(176, 20);
            this.dUpto.TabIndex = 211;
            this.dUpto.EditValueChanged += new System.EventHandler(this.dUpto_EditValueChanged);
            // 
            // SelectDate
            // 
            this.SelectDate.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDate.Appearance.Options.UseFont = true;
            this.SelectDate.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SelectDate.Location = new System.Drawing.Point(57, 62);
            this.SelectDate.Name = "SelectDate";
            this.SelectDate.Size = new System.Drawing.Size(144, 25);
            this.SelectDate.TabIndex = 209;
            this.SelectDate.Text = "Select";
            this.SelectDate.Click += new System.EventHandler(this.SelectDate_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(16, 13);
            this.labelControl2.TabIndex = 208;
            this.labelControl2.Text = "To:";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 207;
            this.labelControl1.Text = "From:";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // dFrom
            // 
            this.dFrom.EditValue = null;
            this.dFrom.Location = new System.Drawing.Point(57, 12);
            this.dFrom.Name = "dFrom";
            this.dFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dFrom.Properties.DisplayFormat.FormatString = "g";
            this.dFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dFrom.Properties.EditFormat.FormatString = "g";
            this.dFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dFrom.Properties.Mask.EditMask = "g";
            this.dFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dFrom.Size = new System.Drawing.Size(176, 20);
            this.dFrom.TabIndex = 206;
            this.dFrom.EditValueChanged += new System.EventHandler(this.dFrom_EditValueChanged);
            // 
            // CloseForm
            // 
            this.CloseForm.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseForm.Appearance.Options.UseFont = true;
            this.CloseForm.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseForm.Location = new System.Drawing.Point(207, 62);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(26, 25);
            this.CloseForm.TabIndex = 210;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // Param_TwoDateTimes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 102);
            this.ControlBox = false;
            this.Controls.Add(this.dUpto);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.SelectDate);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Param_TwoDateTimes";
            this.Load += new System.EventHandler(this.Param_TwoDateTimes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dUpto.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dUpto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dUpto;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
        private DevExpress.XtraEditors.SimpleButton SelectDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dFrom;
    }
}