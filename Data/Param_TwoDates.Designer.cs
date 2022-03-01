namespace MachineEyes.Data
{
    partial class Param_TwoDates
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
            this.dFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dUpto = new DevExpress.XtraEditors.DateEdit();
            this.SelectDate = new DevExpress.XtraEditors.SimpleButton();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dUpto.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dUpto.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dFrom
            // 
            this.dFrom.EditValue = null;
            this.dFrom.Location = new System.Drawing.Point(58, 12);
            this.dFrom.Name = "dFrom";
            this.dFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dFrom.Size = new System.Drawing.Size(164, 20);
            this.dFrom.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "From:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(16, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "To:";
            // 
            // dUpto
            // 
            this.dUpto.EditValue = null;
            this.dUpto.Location = new System.Drawing.Point(58, 38);
            this.dUpto.Name = "dUpto";
            this.dUpto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dUpto.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dUpto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dUpto.Properties.EditFormat.FormatString = "dddd, MMMM dd, yyyy hh:mm:ss tt";
            this.dUpto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dUpto.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dUpto.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dUpto.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dUpto.Size = new System.Drawing.Size(164, 20);
            this.dUpto.TabIndex = 205;
            // 
            // SelectDate
            // 
            this.SelectDate.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDate.Appearance.Options.UseFont = true;
            this.SelectDate.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SelectDate.Location = new System.Drawing.Point(58, 62);
            this.SelectDate.Name = "SelectDate";
            this.SelectDate.Size = new System.Drawing.Size(132, 25);
            this.SelectDate.TabIndex = 203;
            this.SelectDate.Text = "Select";
            this.SelectDate.Click += new System.EventHandler(this.SelectDate_Click);
            // 
            // CloseForm
            // 
            this.CloseForm.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseForm.Appearance.Options.UseFont = true;
            this.CloseForm.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseForm.Location = new System.Drawing.Point(196, 62);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(26, 25);
            this.CloseForm.TabIndex = 204;
            this.CloseForm.Click += new System.EventHandler(this.Close_Click);
            // 
            // Param_TwoDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 99);
            this.ControlBox = false;
            this.Controls.Add(this.dUpto);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.SelectDate);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dFrom);
            this.Name = "Param_TwoDates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dUpto.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dUpto.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dFrom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
        private DevExpress.XtraEditors.SimpleButton SelectDate;
        private DevExpress.XtraEditors.DateEdit dUpto;
    }
}