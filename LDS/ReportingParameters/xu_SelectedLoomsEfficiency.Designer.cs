namespace MachineEyes.LDS.ReportingParameters
{
    partial class xu_SelectedLoomsEfficiency
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
            this.IncludedList = new System.Windows.Forms.ListBox();
            this.ExcludedList = new System.Windows.Forms.ListBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.LookupShed = new DevExpress.XtraEditors.LookUpEdit();
            this.Dated = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.PrintReport = new DevExpress.XtraEditors.SimpleButton();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.LookupShed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dated.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dated.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // IncludedList
            // 
            this.IncludedList.FormattingEnabled = true;
            this.IncludedList.ItemHeight = 16;
            this.IncludedList.Location = new System.Drawing.Point(254, 23);
            this.IncludedList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IncludedList.Name = "IncludedList";
            this.IncludedList.Size = new System.Drawing.Size(61, 708);
            this.IncludedList.TabIndex = 0;
            // 
            // ExcludedList
            // 
            this.ExcludedList.FormattingEnabled = true;
            this.ExcludedList.ItemHeight = 16;
            this.ExcludedList.Location = new System.Drawing.Point(364, 23);
            this.ExcludedList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ExcludedList.Name = "ExcludedList";
            this.ExcludedList.Size = new System.Drawing.Size(59, 708);
            this.ExcludedList.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(259, 0);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 17);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Include";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(367, 0);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 17);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Exclude";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(1, 23);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 17);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Shed";
            // 
            // LookupShed
            // 
            this.LookupShed.Location = new System.Drawing.Point(41, 20);
            this.LookupShed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LookupShed.Name = "LookupShed";
            this.LookupShed.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookupShed.Size = new System.Drawing.Size(195, 22);
            this.LookupShed.TabIndex = 5;
            this.LookupShed.EditValueChanged += new System.EventHandler(this.LookupShed_EditValueChanged);
            // 
            // Dated
            // 
            this.Dated.EditValue = null;
            this.Dated.EnterMoveNextControl = true;
            this.Dated.Location = new System.Drawing.Point(41, 52);
            this.Dated.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Dated.Name = "Dated";
            this.Dated.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Dated.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.Dated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Dated.Properties.EditFormat.FormatString = "dd-MMM-yyyy";
            this.Dated.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Dated.Properties.Mask.EditMask = "dd-MMM-yyyy";
            this.Dated.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Dated.Size = new System.Drawing.Size(195, 22);
            this.Dated.TabIndex = 268;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(1, 55);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(33, 16);
            this.labelControl5.TabIndex = 267;
            this.labelControl5.Text = "Dated";
            // 
            // PrintReport
            // 
            this.PrintReport.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintReport.Appearance.Options.UseFont = true;
            this.PrintReport.Image = global::MachineEyes.Properties.Resources.down16x16;
            this.PrintReport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.PrintReport.Location = new System.Drawing.Point(159, 84);
            this.PrintReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PrintReport.Name = "PrintReport";
            this.PrintReport.Size = new System.Drawing.Size(35, 37);
            this.PrintReport.TabIndex = 271;
            // 
            // CloseForm
            // 
            this.CloseForm.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseForm.Appearance.Options.UseFont = true;
            this.CloseForm.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseForm.Location = new System.Drawing.Point(201, 84);
            this.CloseForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(35, 37);
            this.CloseForm.TabIndex = 270;
            // 
            // xu_SelectedLoomsEfficiency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PrintReport);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.Dated);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.LookupShed);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ExcludedList);
            this.Controls.Add(this.IncludedList);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "xu_SelectedLoomsEfficiency";
            this.Size = new System.Drawing.Size(1195, 836);
            this.Load += new System.EventHandler(this.xu_SelectedLoomsEfficiency_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LookupShed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dated.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dated.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox IncludedList;
        private System.Windows.Forms.ListBox ExcludedList;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit LookupShed;
        private DevExpress.XtraEditors.DateEdit Dated;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton PrintReport;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
    }
}
