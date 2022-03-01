namespace MachineEyes.Data
{
    partial class Data_CountManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Data_CountManagement));
            this.AccountsData_groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.RadioCountType = new DevExpress.XtraEditors.RadioGroup();
            this.EnglishCount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.DisplayCount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_View = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.AccountsData_groupControl1)).BeginInit();
            this.AccountsData_groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RadioCountType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AccountsData_groupControl1
            // 
            this.AccountsData_groupControl1.Controls.Add(this.RadioCountType);
            this.AccountsData_groupControl1.Controls.Add(this.EnglishCount);
            this.AccountsData_groupControl1.Controls.Add(this.labelControl4);
            this.AccountsData_groupControl1.Controls.Add(this.DisplayCount);
            this.AccountsData_groupControl1.Controls.Add(this.labelControl1);
            this.AccountsData_groupControl1.Controls.Add(this.labelControl7);
            this.AccountsData_groupControl1.Controls.Add(this.groupControl1);
            this.AccountsData_groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountsData_groupControl1.Location = new System.Drawing.Point(0, 0);
            this.AccountsData_groupControl1.Name = "AccountsData_groupControl1";
            this.AccountsData_groupControl1.Size = new System.Drawing.Size(1008, 730);
            this.AccountsData_groupControl1.TabIndex = 38;
            this.AccountsData_groupControl1.Text = "Yarn Counts";
            // 
            // RadioCountType
            // 
            this.RadioCountType.EditValue = "0";
            this.RadioCountType.Location = new System.Drawing.Point(165, 30);
            this.RadioCountType.Name = "RadioCountType";
            this.RadioCountType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "English Cotton Count (NeB): NeB  =  840-yd / 1-lb"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Denier Count (den): Den  =  g / 9000-m"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "Metric Count (Nm): Nm  =  m / 1-g"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "Tex Count (tex): Tex  =  g / 1000-m")});
            this.RadioCountType.Size = new System.Drawing.Size(453, 75);
            this.RadioCountType.TabIndex = 48;
            // 
            // EnglishCount
            // 
            this.EnglishCount.EnterMoveNextControl = true;
            this.EnglishCount.Location = new System.Drawing.Point(165, 141);
            this.EnglishCount.Name = "EnglishCount";
            this.EnglishCount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnglishCount.Properties.Appearance.Options.UseFont = true;
            this.EnglishCount.Properties.Mask.EditMask = "f2";
            this.EnglishCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.EnglishCount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.EnglishCount.Size = new System.Drawing.Size(102, 25);
            this.EnglishCount.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.LineVisible = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 144);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(147, 18);
            this.labelControl4.TabIndex = 47;
            this.labelControl4.Text = "Equals English Count";
            // 
            // DisplayCount
            // 
            this.DisplayCount.EnterMoveNextControl = true;
            this.DisplayCount.Location = new System.Drawing.Point(165, 111);
            this.DisplayCount.Name = "DisplayCount";
            this.DisplayCount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayCount.Properties.Appearance.Options.UseFont = true;
            this.DisplayCount.Properties.MaxLength = 50;
            this.DisplayCount.Size = new System.Drawing.Size(231, 25);
            this.DisplayCount.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 114);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(147, 18);
            this.labelControl1.TabIndex = 41;
            this.labelControl1.Text = "Display Count";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.LineVisible = true;
            this.labelControl7.Location = new System.Drawing.Point(12, 40);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(147, 18);
            this.labelControl7.TabIndex = 39;
            this.labelControl7.Text = "Count Type";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btn_Close);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.btn_Cancel);
            this.groupControl1.Controls.Add(this.btn_Del);
            this.groupControl1.Controls.Add(this.btn_Add);
            this.groupControl1.Controls.Add(this.btn_Edit);
            this.groupControl1.Controls.Add(this.btn_View);
            this.groupControl1.Controls.Add(this.btn_Save);
            this.groupControl1.Location = new System.Drawing.Point(12, 183);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(612, 86);
            this.groupControl1.TabIndex = 38;
            // 
            // btn_Close
            // 
            this.btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("btn_Close.Image")));
            this.btn_Close.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Close.Location = new System.Drawing.Point(415, 26);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(57, 55);
            this.btn_Close.TabIndex = 12;
            this.btn_Close.Text = "Close";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.simpleButton1.Location = new System.Drawing.Point(475, 25);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(57, 55);
            this.simpleButton1.TabIndex = 13;
            this.simpleButton1.Text = "Print";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Enabled = false;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Cancel.Location = new System.Drawing.Point(355, 25);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(57, 55);
            this.btn_Cancel.TabIndex = 11;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.Enabled = false;
            this.btn_Del.Image = ((System.Drawing.Image)(resources.GetObject("btn_Del.Image")));
            this.btn_Del.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Del.Location = new System.Drawing.Point(235, 25);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(57, 55);
            this.btn_Del.TabIndex = 9;
            this.btn_Del.Text = "Delete";
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Add.Location = new System.Drawing.Point(55, 25);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(57, 55);
            this.btn_Add.TabIndex = 7;
            this.btn_Add.Text = "Add";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Enabled = false;
            this.btn_Edit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Edit.Image")));
            this.btn_Edit.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Edit.Location = new System.Drawing.Point(175, 25);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(57, 55);
            this.btn_Edit.TabIndex = 8;
            this.btn_Edit.Text = "Edit";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_View
            // 
            this.btn_View.Image = ((System.Drawing.Image)(resources.GetObject("btn_View.Image")));
            this.btn_View.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_View.Location = new System.Drawing.Point(295, 26);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(57, 55);
            this.btn_View.TabIndex = 10;
            this.btn_View.Text = "View";
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Enabled = false;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Save.Location = new System.Drawing.Point(115, 25);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(57, 55);
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "Execute";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // Data_CountManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.AccountsData_groupControl1);
            this.Name = "Data_CountManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yarn Counts Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Data_Accounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AccountsData_groupControl1)).EndInit();
            this.AccountsData_groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RadioCountType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl AccountsData_groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_Del;
        private DevExpress.XtraEditors.SimpleButton btn_Add;
        private DevExpress.XtraEditors.SimpleButton btn_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_View;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit DisplayCount;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit EnglishCount;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.RadioGroup RadioCountType;

    }
}