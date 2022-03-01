namespace MachineEyes.Store
{
    partial class Store_StoreRequisitionList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Store_StoreRequisitionList));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.PODGrid_Item = new DevExpress.XtraGrid.GridControl();
            this.PODGridView_Item = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_ItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Rates = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_ReqStatusID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Department = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.UptoDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.FromDate = new DevExpress.XtraEditors.DateEdit();
            this.GetRecords = new DevExpress.XtraEditors.SimpleButton();
            this.DepartmentReq = new DevExpress.XtraEditors.LookUpEdit();
            this.Filter_Stock = new DevExpress.XtraEditors.RadioGroup();
            this.Filter_Department = new DevExpress.XtraEditors.RadioGroup();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.PODGrid_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PODGridView_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UptoDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UptoDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentReq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Stock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Department.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.png");
            this.imageList1.Images.SetKeyName(1, "2.png");
            this.imageList1.Images.SetKeyName(2, "3.png");
            this.imageList1.Images.SetKeyName(3, "4.png");
            this.imageList1.Images.SetKeyName(4, "5.png");
            this.imageList1.Images.SetKeyName(5, "6.png");
            this.imageList1.Images.SetKeyName(6, "7.png");
            this.imageList1.Images.SetKeyName(7, "8.png");
            this.imageList1.Images.SetKeyName(8, "9.png");
            this.imageList1.Images.SetKeyName(9, "10.png");
            this.imageList1.Images.SetKeyName(10, "11.png");
            this.imageList1.Images.SetKeyName(11, "12.png");
            // 
            // PODGrid_Item
            // 
            this.PODGrid_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PODGrid_Item.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PODGrid_Item.Location = new System.Drawing.Point(2, 2);
            this.PODGrid_Item.MainView = this.PODGridView_Item;
            this.PODGrid_Item.Name = "PODGrid_Item";
            this.PODGrid_Item.Size = new System.Drawing.Size(1004, 653);
            this.PODGrid_Item.TabIndex = 0;
            this.PODGrid_Item.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PODGridView_Item});
            // 
            // PODGridView_Item
            // 
            this.PODGridView_Item.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.PODGridView_Item.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.PODGridView_Item.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.PODGridView_Item.Appearance.FocusedCell.Options.UseFont = true;
            this.PODGridView_Item.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.PODGridView_Item.Appearance.FocusedRow.Options.UseFont = true;
            this.PODGridView_Item.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.PODGridView_Item.Appearance.GroupPanel.Options.UseFont = true;
            this.PODGridView_Item.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.PODGridView_Item.Appearance.HeaderPanel.Options.UseFont = true;
            this.PODGridView_Item.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.PODGridView_Item.Appearance.Row.Options.UseFont = true;
            this.PODGridView_Item.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.PODGridView_Item.Appearance.ViewCaption.Options.UseFont = true;
            this.PODGridView_Item.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.PODGridView_Item.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_ItemID,
            this.gridColumn_ItemName,
            this.gridColumn_Quantity,
            this.gridColumn_Unit,
            this.gridColumn_Rates,
            this.gridColumn_Amount,
            this.gridColumn_Status,
            this.gridColumn_ReqStatusID,
            this.gridColumn_Department});
            this.PODGridView_Item.GridControl = this.PODGrid_Item;
            this.PODGridView_Item.GroupCount = 1;
            this.PODGridView_Item.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", this.gridColumn_Amount, "{0:#,#}")});
            this.PODGridView_Item.Name = "PODGridView_Item";
            this.PODGridView_Item.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.PODGridView_Item.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.PODGridView_Item.OptionsBehavior.Editable = false;
            this.PODGridView_Item.OptionsNavigation.AutoFocusNewRow = true;
            this.PODGridView_Item.OptionsView.ShowAutoFilterRow = true;
            this.PODGridView_Item.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.PODGridView_Item.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn_Department, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn_ItemID
            // 
            this.gridColumn_ItemID.Caption = "Item ID";
            this.gridColumn_ItemID.FieldName = "ItemAccountID";
            this.gridColumn_ItemID.Name = "gridColumn_ItemID";
            this.gridColumn_ItemID.Visible = true;
            this.gridColumn_ItemID.VisibleIndex = 0;
            this.gridColumn_ItemID.Width = 98;
            // 
            // gridColumn_ItemName
            // 
            this.gridColumn_ItemName.Caption = "Item Name";
            this.gridColumn_ItemName.FieldName = "ItemAccountName";
            this.gridColumn_ItemName.Name = "gridColumn_ItemName";
            this.gridColumn_ItemName.Visible = true;
            this.gridColumn_ItemName.VisibleIndex = 1;
            this.gridColumn_ItemName.Width = 259;
            // 
            // gridColumn_Quantity
            // 
            this.gridColumn_Quantity.Caption = "Quantity";
            this.gridColumn_Quantity.FieldName = "QTYAPPROVED";
            this.gridColumn_Quantity.Name = "gridColumn_Quantity";
            this.gridColumn_Quantity.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn_Quantity.Visible = true;
            this.gridColumn_Quantity.VisibleIndex = 2;
            this.gridColumn_Quantity.Width = 64;
            // 
            // gridColumn_Unit
            // 
            this.gridColumn_Unit.Caption = "Unit";
            this.gridColumn_Unit.FieldName = "UOM";
            this.gridColumn_Unit.Name = "gridColumn_Unit";
            this.gridColumn_Unit.Visible = true;
            this.gridColumn_Unit.VisibleIndex = 3;
            this.gridColumn_Unit.Width = 41;
            // 
            // gridColumn_Rates
            // 
            this.gridColumn_Rates.Caption = "@ Rs.";
            this.gridColumn_Rates.FieldName = "LPR";
            this.gridColumn_Rates.Name = "gridColumn_Rates";
            this.gridColumn_Rates.Visible = true;
            this.gridColumn_Rates.VisibleIndex = 4;
            this.gridColumn_Rates.Width = 73;
            // 
            // gridColumn_Amount
            // 
            this.gridColumn_Amount.Caption = "Amount";
            this.gridColumn_Amount.DisplayFormat.FormatString = "{0:#,#}";
            this.gridColumn_Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn_Amount.FieldName = "Amount";
            this.gridColumn_Amount.Name = "gridColumn_Amount";
            this.gridColumn_Amount.UnboundExpression = "[LPR]*[QTYAPPROVED]";
            this.gridColumn_Amount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn_Amount.Visible = true;
            this.gridColumn_Amount.VisibleIndex = 5;
            this.gridColumn_Amount.Width = 95;
            // 
            // gridColumn_Status
            // 
            this.gridColumn_Status.Caption = "Status";
            this.gridColumn_Status.FieldName = "RequisitionStatusName";
            this.gridColumn_Status.Name = "gridColumn_Status";
            this.gridColumn_Status.Visible = true;
            this.gridColumn_Status.VisibleIndex = 6;
            this.gridColumn_Status.Width = 281;
            // 
            // gridColumn_ReqStatusID
            // 
            this.gridColumn_ReqStatusID.Caption = "ReqID";
            this.gridColumn_ReqStatusID.FieldName = "RequisitionStatusID";
            this.gridColumn_ReqStatusID.Name = "gridColumn_ReqStatusID";
            this.gridColumn_ReqStatusID.Visible = true;
            this.gridColumn_ReqStatusID.VisibleIndex = 7;
            this.gridColumn_ReqStatusID.Width = 72;
            // 
            // gridColumn_Department
            // 
            this.gridColumn_Department.Caption = "Department";
            this.gridColumn_Department.FieldName = "DepartmentName";
            this.gridColumn_Department.Name = "gridColumn_Department";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.GetRecords);
            this.panelControl1.Controls.Add(this.DepartmentReq);
            this.panelControl1.Controls.Add(this.Filter_Stock);
            this.panelControl1.Controls.Add(this.Filter_Department);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1008, 73);
            this.panelControl1.TabIndex = 22;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.UptoDate);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.FromDate);
            this.groupControl1.Location = new System.Drawing.Point(2, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(170, 71);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Date Selection";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Upto";
            // 
            // UptoDate
            // 
            this.UptoDate.EditValue = null;
            this.UptoDate.Location = new System.Drawing.Point(35, 48);
            this.UptoDate.Name = "UptoDate";
            this.UptoDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UptoDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.UptoDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.UptoDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.UptoDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.UptoDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.UptoDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.UptoDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.UptoDate.Size = new System.Drawing.Size(130, 20);
            this.UptoDate.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "From";
            // 
            // FromDate
            // 
            this.FromDate.EditValue = null;
            this.FromDate.Location = new System.Drawing.Point(35, 25);
            this.FromDate.Name = "FromDate";
            this.FromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.FromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.FromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.FromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.FromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.FromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.FromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.FromDate.Size = new System.Drawing.Size(130, 20);
            this.FromDate.TabIndex = 2;
            // 
            // GetRecords
            // 
            this.GetRecords.Location = new System.Drawing.Point(941, 9);
            this.GetRecords.Name = "GetRecords";
            this.GetRecords.Size = new System.Drawing.Size(55, 52);
            this.GetRecords.TabIndex = 6;
            this.GetRecords.Text = "&Get";
            this.GetRecords.Click += new System.EventHandler(this.GetRecords_Click);
            // 
            // DepartmentReq
            // 
            this.DepartmentReq.EnterMoveNextControl = true;
            this.DepartmentReq.Location = new System.Drawing.Point(307, 41);
            this.DepartmentReq.Name = "DepartmentReq";
            this.DepartmentReq.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentReq.Properties.Appearance.Options.UseFont = true;
            this.DepartmentReq.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DepartmentReq.Properties.NullText = "";
            this.DepartmentReq.Properties.NullValuePrompt = "Ref Department";
            this.DepartmentReq.Size = new System.Drawing.Size(312, 20);
            this.DepartmentReq.TabIndex = 5;
            // 
            // Filter_Stock
            // 
            this.Filter_Stock.EditValue = "3";
            this.Filter_Stock.Location = new System.Drawing.Point(761, 3);
            this.Filter_Stock.Name = "Filter_Stock";
            this.Filter_Stock.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.Filter_Stock.Properties.Appearance.Options.UseFont = true;
            this.Filter_Stock.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "Available Stock"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Purchase Order Required"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "Any")});
            this.Filter_Stock.Size = new System.Drawing.Size(154, 68);
            this.Filter_Stock.TabIndex = 4;
            // 
            // Filter_Department
            // 
            this.Filter_Department.EditValue = "0";
            this.Filter_Department.Location = new System.Drawing.Point(176, 3);
            this.Filter_Department.Name = "Filter_Department";
            this.Filter_Department.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "All Departments"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Specified Department")});
            this.Filter_Department.Size = new System.Drawing.Size(465, 68);
            this.Filter_Department.TabIndex = 3;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.PODGrid_Item);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 73);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1008, 657);
            this.panelControl3.TabIndex = 2;
            // 
            // Store_StoreRequisitionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Name = "Store_StoreRequisitionList";
            this.Text = "Department Requisitions List";
            ((System.ComponentModel.ISupportInitialize)(this.PODGrid_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PODGridView_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UptoDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UptoDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentReq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Stock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Department.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraGrid.GridControl PODGrid_Item;
        private DevExpress.XtraGrid.Views.Grid.GridView PODGridView_Item;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_ItemID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Unit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Status;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton GetRecords;
        private DevExpress.XtraEditors.LookUpEdit DepartmentReq;
        private DevExpress.XtraEditors.RadioGroup Filter_Stock;
        private DevExpress.XtraEditors.RadioGroup Filter_Department;
        private DevExpress.XtraEditors.DateEdit FromDate;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_ReqStatusID;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit UptoDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Department;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Rates;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Amount;

    }
}