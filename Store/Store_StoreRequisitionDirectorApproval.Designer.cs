namespace MachineEyes.Store
{
    partial class Store_StoreRequisitionDirectorApproval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Store_StoreRequisitionDirectorApproval));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.PODGrid_Item = new DevExpress.XtraGrid.GridControl();
            this.PODGridView_Item = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_ItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_PartNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_QtyAvailable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_QtyApproved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_DepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PODGrid_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PODGridView_Item)).BeginInit();
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
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl6);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1008, 730);
            this.panelControl2.TabIndex = 5;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.PODGrid_Item);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl6.Location = new System.Drawing.Point(2, 2);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(1004, 726);
            this.panelControl6.TabIndex = 0;
            // 
            // PODGrid_Item
            // 
            this.PODGrid_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PODGrid_Item.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PODGrid_Item.Location = new System.Drawing.Point(2, 2);
            this.PODGrid_Item.MainView = this.PODGridView_Item;
            this.PODGrid_Item.Name = "PODGrid_Item";
            this.PODGrid_Item.Size = new System.Drawing.Size(1000, 722);
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
            this.gridColumn_PartNumber,
            this.gridColumn_Quantity,
            this.gridColumn_Unit,
            this.gridColumn_QtyAvailable,
            this.gridColumn_QtyApproved,
            this.gridColumn1,
            this.gridColumn_DepartmentName});
            this.PODGridView_Item.GridControl = this.PODGrid_Item;
            this.PODGridView_Item.GroupCount = 1;
            this.PODGridView_Item.Name = "PODGridView_Item";
            this.PODGridView_Item.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.PODGridView_Item.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.PODGridView_Item.OptionsBehavior.Editable = false;
            this.PODGridView_Item.OptionsNavigation.AutoFocusNewRow = true;
            this.PODGridView_Item.OptionsView.ShowAutoFilterRow = true;
            this.PODGridView_Item.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.PODGridView_Item.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn_DepartmentName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.PODGridView_Item.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.PODGridView_Item_FocusedRowChanged);
            this.PODGridView_Item.Click += new System.EventHandler(this.PODGridView_Item_Click);
            this.PODGridView_Item.DoubleClick += new System.EventHandler(this.PODGridView_Item_DoubleClick);
            // 
            // gridColumn_ItemID
            // 
            this.gridColumn_ItemID.Caption = "Item ID";
            this.gridColumn_ItemID.FieldName = "ItemAccountID";
            this.gridColumn_ItemID.Name = "gridColumn_ItemID";
            this.gridColumn_ItemID.Visible = true;
            this.gridColumn_ItemID.VisibleIndex = 0;
            this.gridColumn_ItemID.Width = 116;
            // 
            // gridColumn_ItemName
            // 
            this.gridColumn_ItemName.Caption = "Item Name";
            this.gridColumn_ItemName.FieldName = "ItemAccountName";
            this.gridColumn_ItemName.Name = "gridColumn_ItemName";
            this.gridColumn_ItemName.Visible = true;
            this.gridColumn_ItemName.VisibleIndex = 1;
            this.gridColumn_ItemName.Width = 322;
            // 
            // gridColumn_PartNumber
            // 
            this.gridColumn_PartNumber.Caption = "Part Number";
            this.gridColumn_PartNumber.FieldName = "PartNumber";
            this.gridColumn_PartNumber.Name = "gridColumn_PartNumber";
            this.gridColumn_PartNumber.Visible = true;
            this.gridColumn_PartNumber.VisibleIndex = 2;
            this.gridColumn_PartNumber.Width = 159;
            // 
            // gridColumn_Quantity
            // 
            this.gridColumn_Quantity.Caption = "Quantity";
            this.gridColumn_Quantity.FieldName = "QTYREQUESTED";
            this.gridColumn_Quantity.Name = "gridColumn_Quantity";
            this.gridColumn_Quantity.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn_Quantity.Visible = true;
            this.gridColumn_Quantity.VisibleIndex = 3;
            this.gridColumn_Quantity.Width = 56;
            // 
            // gridColumn_Unit
            // 
            this.gridColumn_Unit.Caption = "Unit";
            this.gridColumn_Unit.FieldName = "UOM";
            this.gridColumn_Unit.Name = "gridColumn_Unit";
            this.gridColumn_Unit.Visible = true;
            this.gridColumn_Unit.VisibleIndex = 4;
            this.gridColumn_Unit.Width = 44;
            // 
            // gridColumn_QtyAvailable
            // 
            this.gridColumn_QtyAvailable.Caption = "Qty Avl.";
            this.gridColumn_QtyAvailable.Name = "gridColumn_QtyAvailable";
            this.gridColumn_QtyAvailable.Visible = true;
            this.gridColumn_QtyAvailable.VisibleIndex = 5;
            this.gridColumn_QtyAvailable.Width = 69;
            // 
            // gridColumn_QtyApproved
            // 
            this.gridColumn_QtyApproved.Caption = "Qty Approved.";
            this.gridColumn_QtyApproved.Name = "gridColumn_QtyApproved";
            this.gridColumn_QtyApproved.Visible = true;
            this.gridColumn_QtyApproved.VisibleIndex = 6;
            this.gridColumn_QtyApproved.Width = 69;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Approve / Reject";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 69;
            // 
            // gridColumn_DepartmentName
            // 
            this.gridColumn_DepartmentName.Caption = "Department";
            this.gridColumn_DepartmentName.Name = "gridColumn_DepartmentName";
            this.gridColumn_DepartmentName.Visible = true;
            this.gridColumn_DepartmentName.VisibleIndex = 8;
            this.gridColumn_DepartmentName.Width = 78;
            // 
            // Store_StoreRequisitionDirectorApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.panelControl2);
            this.Name = "Store_StoreRequisitionDirectorApproval";
            this.Text = "Department Requisition Slip";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PODGrid_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PODGridView_Item)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraGrid.GridControl PODGrid_Item;
        private DevExpress.XtraGrid.Views.Grid.GridView PODGridView_Item;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_ItemID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_PartNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Unit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_QtyAvailable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_QtyApproved;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_DepartmentName;

    }
}