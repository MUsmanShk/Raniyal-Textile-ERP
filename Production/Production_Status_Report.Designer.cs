namespace MachineEyes.Production
{
    partial class Production_Status_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Production_Status_Report));
            this.dgridStatusReport = new System.Windows.Forms.DataGridView();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.FromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ToDate = new DevExpress.XtraEditors.DateEdit();
            this.SaleContract = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.RadioPageSetting = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.Print = new DevExpress.XtraEditors.SimpleButton();
            this.CancelThis = new DevExpress.XtraEditors.SimpleButton();
            this.View = new DevExpress.XtraEditors.SimpleButton();
            this.Edit = new DevExpress.XtraEditors.SimpleButton();
            this.CloseThis = new DevExpress.XtraEditors.SimpleButton();
            this.Delete = new DevExpress.XtraEditors.SimpleButton();
            this.Execute = new DevExpress.XtraEditors.SimpleButton();
            this.Add = new DevExpress.XtraEditors.SimpleButton();
            this.checkButton1 = new DevExpress.XtraEditors.CheckButton();
            this.Filter_ContractDate = new DevExpress.XtraEditors.CheckButton();
            this.partyName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgridStatusReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioPageSetting.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dgridStatusReport
            // 
            this.dgridStatusReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridStatusReport.Location = new System.Drawing.Point(3, 218);
            this.dgridStatusReport.Name = "dgridStatusReport";
            this.dgridStatusReport.Size = new System.Drawing.Size(998, 399);
            this.dgridStatusReport.TabIndex = 0;
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl14.LineVisible = true;
            this.labelControl14.Location = new System.Drawing.Point(22, 84);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(230, 17);
            this.labelControl14.TabIndex = 324;
            this.labelControl14.Text = "From Date";
            // 
            // FromDate
            // 
            this.FromDate.EditValue = null;
            this.FromDate.EnterMoveNextControl = true;
            this.FromDate.Location = new System.Drawing.Point(257, 81);
            this.FromDate.Name = "FromDate";
            this.FromDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDate.Properties.Appearance.Options.UseFont = true;
            this.FromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FromDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy";
            this.FromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.FromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.FromDate.Size = new System.Drawing.Size(183, 22);
            this.FromDate.TabIndex = 322;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(537, 81);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(230, 17);
            this.labelControl1.TabIndex = 327;
            this.labelControl1.Text = "To Date";
            // 
            // ToDate
            // 
            this.ToDate.EditValue = null;
            this.ToDate.EnterMoveNextControl = true;
            this.ToDate.Location = new System.Drawing.Point(775, 78);
            this.ToDate.Name = "ToDate";
            this.ToDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDate.Properties.Appearance.Options.UseFont = true;
            this.ToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ToDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy";
            this.ToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ToDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ToDate.Size = new System.Drawing.Size(183, 22);
            this.ToDate.TabIndex = 325;
            // 
            // SaleContract
            // 
            this.SaleContract.Location = new System.Drawing.Point(258, 29);
            this.SaleContract.Name = "SaleContract";
            this.SaleContract.Size = new System.Drawing.Size(241, 21);
            this.SaleContract.TabIndex = 329;
            this.SaleContract.TextChanged += new System.EventHandler(this.SaleContract_TextChanged);
            this.SaleContract.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaleContract_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(22, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(230, 17);
            this.labelControl3.TabIndex = 328;
            this.labelControl3.Text = "Select Sale Contract#";
            // 
            // RadioPageSetting
            // 
            this.RadioPageSetting.EditValue = "H";
            this.RadioPageSetting.Location = new System.Drawing.Point(731, 148);
            this.RadioPageSetting.Name = "RadioPageSetting";
            this.RadioPageSetting.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("H", "Half Page"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("F", "Full Page")});
            this.RadioPageSetting.Size = new System.Drawing.Size(77, 54);
            this.RadioPageSetting.TabIndex = 338;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl13.LineVisible = true;
            this.labelControl13.Location = new System.Drawing.Point(537, 29);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(230, 17);
            this.labelControl13.TabIndex = 339;
            this.labelControl13.Text = "Party Name";
            // 
            // Print
            // 
            this.Print.Image = ((System.Drawing.Image)(resources.GetObject("Print.Image")));
            this.Print.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Print.Location = new System.Drawing.Point(605, 143);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(57, 59);
            this.Print.TabIndex = 337;
            this.Print.Text = "Print";
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // CancelThis
            // 
            this.CancelThis.Image = ((System.Drawing.Image)(resources.GetObject("CancelThis.Image")));
            this.CancelThis.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.CancelThis.Location = new System.Drawing.Point(542, 143);
            this.CancelThis.Name = "CancelThis";
            this.CancelThis.Size = new System.Drawing.Size(57, 59);
            this.CancelThis.TabIndex = 335;
            this.CancelThis.Text = "Cancel";
            // 
            // View
            // 
            this.View.Image = ((System.Drawing.Image)(resources.GetObject("View.Image")));
            this.View.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.View.Location = new System.Drawing.Point(479, 143);
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(57, 59);
            this.View.TabIndex = 334;
            this.View.Text = "View";
            // 
            // Edit
            // 
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Edit.Location = new System.Drawing.Point(353, 144);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(57, 59);
            this.Edit.TabIndex = 332;
            this.Edit.Text = "Edit";
            // 
            // CloseThis
            // 
            this.CloseThis.Image = ((System.Drawing.Image)(resources.GetObject("CloseThis.Image")));
            this.CloseThis.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.CloseThis.Location = new System.Drawing.Point(668, 143);
            this.CloseThis.Name = "CloseThis";
            this.CloseThis.Size = new System.Drawing.Size(57, 59);
            this.CloseThis.TabIndex = 336;
            this.CloseThis.Text = "Close";
            // 
            // Delete
            // 
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Delete.Location = new System.Drawing.Point(416, 144);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(57, 59);
            this.Delete.TabIndex = 333;
            this.Delete.Text = "Delete";
            // 
            // Execute
            // 
            this.Execute.Image = ((System.Drawing.Image)(resources.GetObject("Execute.Image")));
            this.Execute.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Execute.Location = new System.Drawing.Point(290, 143);
            this.Execute.Name = "Execute";
            this.Execute.Size = new System.Drawing.Size(57, 59);
            this.Execute.TabIndex = 331;
            this.Execute.Text = "Execute";
            this.Execute.Click += new System.EventHandler(this.Execute_Click);
            // 
            // Add
            // 
            this.Add.Image = ((System.Drawing.Image)(resources.GetObject("Add.Image")));
            this.Add.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Add.Location = new System.Drawing.Point(227, 143);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(57, 59);
            this.Add.TabIndex = 330;
            this.Add.Text = "Add";
            // 
            // checkButton1
            // 
            this.checkButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkButton1.Appearance.Options.UseFont = true;
            this.checkButton1.Image = global::MachineEyes.Properties.Resources.filter;
            this.checkButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.checkButton1.Location = new System.Drawing.Point(964, 77);
            this.checkButton1.Name = "checkButton1";
            this.checkButton1.Size = new System.Drawing.Size(26, 23);
            this.checkButton1.TabIndex = 326;
            this.checkButton1.TabStop = false;
            // 
            // Filter_ContractDate
            // 
            this.Filter_ContractDate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_ContractDate.Appearance.Options.UseFont = true;
            this.Filter_ContractDate.Image = global::MachineEyes.Properties.Resources.filter;
            this.Filter_ContractDate.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Filter_ContractDate.Location = new System.Drawing.Point(446, 81);
            this.Filter_ContractDate.Name = "Filter_ContractDate";
            this.Filter_ContractDate.Size = new System.Drawing.Size(26, 23);
            this.Filter_ContractDate.TabIndex = 323;
            this.Filter_ContractDate.TabStop = false;
            // 
            // partyName
            // 
            this.partyName.Location = new System.Drawing.Point(773, 25);
            this.partyName.Name = "partyName";
            this.partyName.ReadOnly = true;
            this.partyName.Size = new System.Drawing.Size(241, 21);
            this.partyName.TabIndex = 340;
            // 
            // Production_Status_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.partyName);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.RadioPageSetting);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.CancelThis);
            this.Controls.Add(this.View);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.CloseThis);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Execute);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.SaleContract);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.checkButton1);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.Filter_ContractDate);
            this.Controls.Add(this.dgridStatusReport);
            this.Name = "Production_Status_Report";
            this.Text = "Production Status Report";
            ((System.ComponentModel.ISupportInitialize)(this.dgridStatusReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioPageSetting.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgridStatusReport;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.DateEdit FromDate;
        private DevExpress.XtraEditors.CheckButton Filter_ContractDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit ToDate;
        private DevExpress.XtraEditors.CheckButton checkButton1;
        private System.Windows.Forms.TextBox SaleContract;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.RadioGroup RadioPageSetting;
        private DevExpress.XtraEditors.SimpleButton Print;
        private DevExpress.XtraEditors.SimpleButton CancelThis;
        private DevExpress.XtraEditors.SimpleButton View;
        private DevExpress.XtraEditors.SimpleButton Edit;
        private DevExpress.XtraEditors.SimpleButton CloseThis;
        private DevExpress.XtraEditors.SimpleButton Delete;
        private DevExpress.XtraEditors.SimpleButton Execute;
        private DevExpress.XtraEditors.SimpleButton Add;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private System.Windows.Forms.TextBox partyName;

    }
}