namespace MachineEyes.Data
{
    partial class Data_LoomCategories_Looms
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
            this.Panel_Looms = new System.Windows.Forms.Panel();
            this.Looms_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.Looms_Remove = new DevExpress.XtraEditors.SimpleButton();
            this.Looms_Add = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GridControl_Looms = new DevExpress.XtraGrid.GridControl();
            this.GridVew_Looms = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_LoomID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_ShedID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_ShedName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_LoomName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Panel_Looms.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl_Looms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridVew_Looms)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_Looms
            // 
            this.Panel_Looms.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel_Looms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Looms.Controls.Add(this.Looms_Cancel);
            this.Panel_Looms.Controls.Add(this.Looms_Remove);
            this.Panel_Looms.Controls.Add(this.Looms_Add);
            this.Panel_Looms.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Looms.Location = new System.Drawing.Point(0, 0);
            this.Panel_Looms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel_Looms.Name = "Panel_Looms";
            this.Panel_Looms.Size = new System.Drawing.Size(472, 54);
            this.Panel_Looms.TabIndex = 2;
            // 
            // Looms_Cancel
            // 
            this.Looms_Cancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Looms_Cancel.Appearance.Options.UseFont = true;
            this.Looms_Cancel.ImageIndex = 0;
            this.Looms_Cancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Looms_Cancel.Location = new System.Drawing.Point(276, 1);
            this.Looms_Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Looms_Cancel.Name = "Looms_Cancel";
            this.Looms_Cancel.Size = new System.Drawing.Size(80, 47);
            this.Looms_Cancel.TabIndex = 3;
            this.Looms_Cancel.Text = "&Cancel";
            this.Looms_Cancel.Click += new System.EventHandler(this.Looms_Cancel_Click);
            // 
            // Looms_Remove
            // 
            this.Looms_Remove.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Looms_Remove.Appearance.Options.UseFont = true;
            this.Looms_Remove.ImageIndex = 0;
            this.Looms_Remove.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Looms_Remove.Location = new System.Drawing.Point(189, 1);
            this.Looms_Remove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Looms_Remove.Name = "Looms_Remove";
            this.Looms_Remove.Size = new System.Drawing.Size(80, 47);
            this.Looms_Remove.TabIndex = 2;
            this.Looms_Remove.Text = "&Remove";
            this.Looms_Remove.Click += new System.EventHandler(this.Looms_Remove_Click);
            // 
            // Looms_Add
            // 
            this.Looms_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Looms_Add.Appearance.Options.UseFont = true;
            this.Looms_Add.ImageIndex = 0;
            this.Looms_Add.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.Looms_Add.Location = new System.Drawing.Point(101, 1);
            this.Looms_Add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Looms_Add.Name = "Looms_Add";
            this.Looms_Add.Size = new System.Drawing.Size(80, 47);
            this.Looms_Add.TabIndex = 1;
            this.Looms_Add.Text = "&Add";
            this.Looms_Add.Click += new System.EventHandler(this.Looms_Add_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.GridControl_Looms);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 539);
            this.panel1.TabIndex = 3;
            // 
            // GridControl_Looms
            // 
            this.GridControl_Looms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl_Looms.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridControl_Looms.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridControl_Looms.Location = new System.Drawing.Point(0, 0);
            this.GridControl_Looms.MainView = this.GridVew_Looms;
            this.GridControl_Looms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridControl_Looms.Name = "GridControl_Looms";
            this.GridControl_Looms.Size = new System.Drawing.Size(470, 537);
            this.GridControl_Looms.TabIndex = 20;
            this.GridControl_Looms.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridVew_Looms});
            // 
            // GridVew_Looms
            // 
            this.GridVew_Looms.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.GridVew_Looms.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.GridVew_Looms.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.GridVew_Looms.Appearance.FocusedCell.Options.UseFont = true;
            this.GridVew_Looms.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.GridVew_Looms.Appearance.FocusedRow.Options.UseFont = true;
            this.GridVew_Looms.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.GridVew_Looms.Appearance.GroupPanel.Options.UseFont = true;
            this.GridVew_Looms.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.GridVew_Looms.Appearance.HeaderPanel.Options.UseFont = true;
            this.GridVew_Looms.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.GridVew_Looms.Appearance.Row.Options.UseFont = true;
            this.GridVew_Looms.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.GridVew_Looms.Appearance.ViewCaption.Options.UseFont = true;
            this.GridVew_Looms.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.GridVew_Looms.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_LoomID,
            this.gridColumn_ShedID,
            this.gridColumn_ShedName,
            this.gridColumn_LoomName});
            this.GridVew_Looms.GridControl = this.GridControl_Looms;
            this.GridVew_Looms.Name = "GridVew_Looms";
            this.GridVew_Looms.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridVew_Looms.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridVew_Looms.OptionsBehavior.Editable = false;
            this.GridVew_Looms.OptionsNavigation.AutoFocusNewRow = true;
            this.GridVew_Looms.OptionsSelection.MultiSelect = true;
            this.GridVew_Looms.OptionsView.ShowAutoFilterRow = true;
            this.GridVew_Looms.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            // 
            // gridColumn_LoomID
            // 
            this.gridColumn_LoomID.Caption = "Index";
            this.gridColumn_LoomID.FieldName = "LoomID";
            this.gridColumn_LoomID.Name = "gridColumn_LoomID";
            this.gridColumn_LoomID.Visible = true;
            this.gridColumn_LoomID.VisibleIndex = 0;
            this.gridColumn_LoomID.Width = 45;
            // 
            // gridColumn_ShedID
            // 
            this.gridColumn_ShedID.Caption = "Shed ID";
            this.gridColumn_ShedID.FieldName = "ShedID";
            this.gridColumn_ShedID.Name = "gridColumn_ShedID";
            this.gridColumn_ShedID.Visible = true;
            this.gridColumn_ShedID.VisibleIndex = 1;
            this.gridColumn_ShedID.Width = 52;
            // 
            // gridColumn_ShedName
            // 
            this.gridColumn_ShedName.Caption = "Shed Name";
            this.gridColumn_ShedName.FieldName = "ShedName";
            this.gridColumn_ShedName.Name = "gridColumn_ShedName";
            this.gridColumn_ShedName.Visible = true;
            this.gridColumn_ShedName.VisibleIndex = 2;
            this.gridColumn_ShedName.Width = 175;
            // 
            // gridColumn_LoomName
            // 
            this.gridColumn_LoomName.Caption = "Loom #";
            this.gridColumn_LoomName.FieldName = "LoomName";
            this.gridColumn_LoomName.Name = "gridColumn_LoomName";
            this.gridColumn_LoomName.Visible = true;
            this.gridColumn_LoomName.VisibleIndex = 3;
            this.gridColumn_LoomName.Width = 79;
            // 
            // Data_LoomCategories_Looms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 593);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel_Looms);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Data_LoomCategories_Looms";
            this.Text = "Looms Categories Add / Remove Panel";
            this.Panel_Looms.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl_Looms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridVew_Looms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel Panel_Looms;
        public System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl GridControl_Looms;
        private DevExpress.XtraGrid.Views.Grid.GridView GridVew_Looms;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_LoomID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_ShedID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_ShedName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_LoomName;
        private DevExpress.XtraEditors.SimpleButton Looms_Cancel;
        private DevExpress.XtraEditors.SimpleButton Looms_Remove;
        private DevExpress.XtraEditors.SimpleButton Looms_Add;
    }
}