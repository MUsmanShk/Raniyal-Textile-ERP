namespace MachineEyes.Store
{
    partial class Store_RequestApproval
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
            this.gridControl_Selection = new DevExpress.XtraGrid.GridControl();
            this.gridView_Selection = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.RequisitionNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Dated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemAccountName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QtyApprovedByDirector = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Stock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Department = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LoomName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RequisitionStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RequestStatusLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.AverageBuyingRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage_View = new DevExpress.XtraTab.XtraTabPage();
            this.Filter_RequisitionStatus = new DevExpress.XtraEditors.RadioGroup();
            this.GetRecords = new DevExpress.XtraEditors.SimpleButton();
            this.DateReq = new DevExpress.XtraEditors.DateEdit();
            this.Filter_Stock = new DevExpress.XtraEditors.RadioGroup();
            this.DepartmentReq = new DevExpress.XtraEditors.LookUpEdit();
            this.Filter_Date = new DevExpress.XtraEditors.RadioGroup();
            this.Filter_Department = new DevExpress.XtraEditors.RadioGroup();
            this.xtraTabPage_Reports = new DevExpress.XtraTab.XtraTabPage();
            this.R_GetRequisitions = new DevExpress.XtraEditors.SimpleButton();
            this.R_Status_PORaised = new DevExpress.XtraEditors.CheckEdit();
            this.R_Status_Served = new DevExpress.XtraEditors.CheckEdit();
            this.R_Status_Discuss = new DevExpress.XtraEditors.CheckEdit();
            this.R_Status_Rejected = new DevExpress.XtraEditors.CheckEdit();
            this.R_Status_Approved = new DevExpress.XtraEditors.CheckEdit();
            this.R_Status_Requested = new DevExpress.XtraEditors.CheckEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.R_UptoDate = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.R_FromDate = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.R_Departments = new DevExpress.XtraEditors.LookUpEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Selection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Selection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RequestStatusLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage_View.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_RequisitionStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateReq.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateReq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Stock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentReq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Department.Properties)).BeginInit();
            this.xtraTabPage_Reports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.R_Status_PORaised.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_Status_Served.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_Status_Discuss.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_Status_Rejected.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_Status_Approved.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_Status_Requested.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_UptoDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_UptoDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_FromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_FromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_Departments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_Selection
            // 
            this.gridControl_Selection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Selection.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl_Selection.Location = new System.Drawing.Point(2, 2);
            this.gridControl_Selection.MainView = this.gridView_Selection;
            this.gridControl_Selection.Name = "gridControl_Selection";
            this.gridControl_Selection.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RequestStatusLookup});
            this.gridControl_Selection.Size = new System.Drawing.Size(1004, 635);
            this.gridControl_Selection.TabIndex = 20;
            this.gridControl_Selection.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Selection});
            // 
            // gridView_Selection
            // 
            this.gridView_Selection.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView_Selection.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView_Selection.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridView_Selection.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView_Selection.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Selection.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView_Selection.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Selection.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Selection.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView_Selection.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView_Selection.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView_Selection.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_Selection.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView_Selection.Appearance.Row.Options.UseFont = true;
            this.gridView_Selection.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView_Selection.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView_Selection.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView_Selection.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView_Selection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gridView_Selection.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.RequisitionNumber,
            this.Dated,
            this.ItemAccountName,
            this.QtyApprovedByDirector,
            this.ItemRate,
            this.Stock,
            this.UOM,
            this.Amount,
            this.Department,
            this.LoomName,
            this.RequisitionStatus,
            this.AverageBuyingRate});
            this.gridView_Selection.GridControl = this.gridControl_Selection;
            this.gridView_Selection.GroupCount = 1;
            this.gridView_Selection.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", this.Amount, "{0:#,#}")});
            this.gridView_Selection.Name = "gridView_Selection";
            this.gridView_Selection.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Selection.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Selection.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_Selection.OptionsView.ShowAutoFilterRow = true;
            this.gridView_Selection.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Department, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // RequisitionNumber
            // 
            this.RequisitionNumber.Caption = "Req #";
            this.RequisitionNumber.DisplayFormat.FormatString = "n2";
            this.RequisitionNumber.FieldName = "RequisitionNumber";
            this.RequisitionNumber.Name = "RequisitionNumber";
            this.RequisitionNumber.OptionsColumn.AllowEdit = false;
            this.RequisitionNumber.OptionsColumn.ReadOnly = true;
            this.RequisitionNumber.Visible = true;
            this.RequisitionNumber.VisibleIndex = 0;
            this.RequisitionNumber.Width = 87;
            // 
            // Dated
            // 
            this.Dated.Caption = "Date";
            this.Dated.FieldName = "Dated";
            this.Dated.Name = "Dated";
            this.Dated.OptionsColumn.AllowEdit = false;
            this.Dated.OptionsColumn.ReadOnly = true;
            this.Dated.Visible = true;
            this.Dated.VisibleIndex = 1;
            this.Dated.Width = 93;
            // 
            // ItemAccountName
            // 
            this.ItemAccountName.Caption = "Part / Item Name";
            this.ItemAccountName.FieldName = "ItemAccountName";
            this.ItemAccountName.Name = "ItemAccountName";
            this.ItemAccountName.OptionsColumn.AllowEdit = false;
            this.ItemAccountName.OptionsColumn.ReadOnly = true;
            this.ItemAccountName.Visible = true;
            this.ItemAccountName.VisibleIndex = 2;
            this.ItemAccountName.Width = 325;
            // 
            // QtyApprovedByDirector
            // 
            this.QtyApprovedByDirector.Caption = "Quantity";
            this.QtyApprovedByDirector.FieldName = "QTYAPPROVED";
            this.QtyApprovedByDirector.Name = "QtyApprovedByDirector";
            this.QtyApprovedByDirector.Visible = true;
            this.QtyApprovedByDirector.VisibleIndex = 3;
            this.QtyApprovedByDirector.Width = 83;
            // 
            // ItemRate
            // 
            this.ItemRate.Caption = "@Rs.";
            this.ItemRate.FieldName = "LPR";
            this.ItemRate.Name = "ItemRate";
            this.ItemRate.Visible = true;
            this.ItemRate.VisibleIndex = 4;
            // 
            // Stock
            // 
            this.Stock.Caption = "Stock";
            this.Stock.FieldName = "STOCKATTIME";
            this.Stock.Name = "Stock";
            this.Stock.OptionsColumn.ReadOnly = true;
            this.Stock.Visible = true;
            this.Stock.VisibleIndex = 5;
            this.Stock.Width = 70;
            // 
            // UOM
            // 
            this.UOM.Caption = "UOM";
            this.UOM.FieldName = "UOM";
            this.UOM.Name = "UOM";
            this.UOM.OptionsColumn.AllowEdit = false;
            this.UOM.OptionsColumn.ReadOnly = true;
            this.UOM.Visible = true;
            this.UOM.VisibleIndex = 6;
            this.UOM.Width = 42;
            // 
            // Amount
            // 
            this.Amount.Caption = "Amount";
            this.Amount.DisplayFormat.FormatString = "{0:#,#}";
            this.Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.FieldName = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.OptionsColumn.ReadOnly = true;
            this.Amount.UnboundExpression = "[LPR]*[QTYAPPROVED]";
            this.Amount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.Amount.Visible = true;
            this.Amount.VisibleIndex = 7;
            // 
            // Department
            // 
            this.Department.Caption = "Department";
            this.Department.FieldName = "DepartmentName";
            this.Department.Name = "Department";
            this.Department.OptionsColumn.AllowEdit = false;
            this.Department.OptionsColumn.ReadOnly = true;
            this.Department.Visible = true;
            this.Department.VisibleIndex = 9;
            this.Department.Width = 117;
            // 
            // LoomName
            // 
            this.LoomName.Caption = "Loom #";
            this.LoomName.FieldName = "LoomName";
            this.LoomName.Name = "LoomName";
            this.LoomName.OptionsColumn.AllowEdit = false;
            this.LoomName.OptionsColumn.ReadOnly = true;
            this.LoomName.Visible = true;
            this.LoomName.VisibleIndex = 8;
            this.LoomName.Width = 60;
            // 
            // RequisitionStatus
            // 
            this.RequisitionStatus.Caption = "Approve / Reject";
            this.RequisitionStatus.ColumnEdit = this.RequestStatusLookup;
            this.RequisitionStatus.FieldName = "RequisitionStatusID";
            this.RequisitionStatus.Name = "RequisitionStatus";
            this.RequisitionStatus.Visible = true;
            this.RequisitionStatus.VisibleIndex = 9;
            this.RequisitionStatus.Width = 110;
            // 
            // RequestStatusLookup
            // 
            this.RequestStatusLookup.AutoHeight = false;
            this.RequestStatusLookup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RequestStatusLookup.Name = "RequestStatusLookup";
            this.RequestStatusLookup.NullText = "";
            this.RequestStatusLookup.NullValuePrompt = "Approve / Reject";
            this.RequestStatusLookup.EditValueChanged += new System.EventHandler(this.RequestStatusLookup_EditValueChanged);
            // 
            // AverageBuyingRate
            // 
            this.AverageBuyingRate.Caption = "@Rs.";
            this.AverageBuyingRate.FieldName = "AvgBuyingRate";
            this.AverageBuyingRate.Name = "AverageBuyingRate";
            this.AverageBuyingRate.OptionsColumn.AllowEdit = false;
            this.AverageBuyingRate.OptionsColumn.ReadOnly = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.xtraTabControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1008, 91);
            this.panelControl1.TabIndex = 21;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_View;
            this.xtraTabControl1.Size = new System.Drawing.Size(1004, 87);
            this.xtraTabControl1.TabIndex = 7;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage_View,
            this.xtraTabPage_Reports});
            // 
            // xtraTabPage_View
            // 
            this.xtraTabPage_View.Controls.Add(this.Filter_RequisitionStatus);
            this.xtraTabPage_View.Controls.Add(this.GetRecords);
            this.xtraTabPage_View.Controls.Add(this.DateReq);
            this.xtraTabPage_View.Controls.Add(this.Filter_Stock);
            this.xtraTabPage_View.Controls.Add(this.DepartmentReq);
            this.xtraTabPage_View.Controls.Add(this.Filter_Date);
            this.xtraTabPage_View.Controls.Add(this.Filter_Department);
            this.xtraTabPage_View.Name = "xtraTabPage_View";
            this.xtraTabPage_View.Size = new System.Drawing.Size(996, 58);
            this.xtraTabPage_View.Text = "View";
            // 
            // Filter_RequisitionStatus
            // 
            this.Filter_RequisitionStatus.EditValue = "\'0\'";
            this.Filter_RequisitionStatus.Location = new System.Drawing.Point(3, 3);
            this.Filter_RequisitionStatus.Name = "Filter_RequisitionStatus";
            this.Filter_RequisitionStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("\'0\',\'1\',\'2\',\'7\'", "All Records"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("\'0\'", "Requested"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("\'1\'", "Approved"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("\'2\'", "Rejected"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("\'5\'", "Discuss")});
            this.Filter_RequisitionStatus.Size = new System.Drawing.Size(271, 52);
            this.Filter_RequisitionStatus.TabIndex = 0;
            // 
            // GetRecords
            // 
            this.GetRecords.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GetRecords.Appearance.Options.UseFont = true;
            this.GetRecords.Location = new System.Drawing.Point(926, 2);
            this.GetRecords.Name = "GetRecords";
            this.GetRecords.Size = new System.Drawing.Size(66, 52);
            this.GetRecords.TabIndex = 6;
            this.GetRecords.Text = "&Get";
            this.GetRecords.Click += new System.EventHandler(this.GetRecords_Click);
            // 
            // DateReq
            // 
            this.DateReq.EditValue = null;
            this.DateReq.Location = new System.Drawing.Point(374, 26);
            this.DateReq.Name = "DateReq";
            this.DateReq.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateReq.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.DateReq.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DateReq.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.DateReq.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateReq.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.DateReq.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DateReq.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateReq.Size = new System.Drawing.Size(124, 20);
            this.DateReq.TabIndex = 2;
            // 
            // Filter_Stock
            // 
            this.Filter_Stock.EditValue = "3";
            this.Filter_Stock.Location = new System.Drawing.Point(788, 2);
            this.Filter_Stock.Name = "Filter_Stock";
            this.Filter_Stock.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.Filter_Stock.Properties.Appearance.Options.UseFont = true;
            this.Filter_Stock.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "Available Stock"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Purchase Order Required"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "Any")});
            this.Filter_Stock.Size = new System.Drawing.Size(134, 52);
            this.Filter_Stock.TabIndex = 4;
            this.Filter_Stock.SelectedIndexChanged += new System.EventHandler(this.Filter_Stock_SelectedIndexChanged);
            // 
            // DepartmentReq
            // 
            this.DepartmentReq.EnterMoveNextControl = true;
            this.DepartmentReq.Location = new System.Drawing.Point(634, 26);
            this.DepartmentReq.Name = "DepartmentReq";
            this.DepartmentReq.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentReq.Properties.Appearance.Options.UseFont = true;
            this.DepartmentReq.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DepartmentReq.Properties.NullText = "";
            this.DepartmentReq.Properties.NullValuePrompt = "Ref Department";
            this.DepartmentReq.Size = new System.Drawing.Size(145, 20);
            this.DepartmentReq.TabIndex = 5;
            // 
            // Filter_Date
            // 
            this.Filter_Date.EditValue = "0";
            this.Filter_Date.Location = new System.Drawing.Point(276, 2);
            this.Filter_Date.Name = "Filter_Date";
            this.Filter_Date.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "All Dates"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Specified Date")});
            this.Filter_Date.Size = new System.Drawing.Size(226, 52);
            this.Filter_Date.TabIndex = 1;
            // 
            // Filter_Department
            // 
            this.Filter_Department.EditValue = "0";
            this.Filter_Department.Location = new System.Drawing.Point(504, 2);
            this.Filter_Department.Name = "Filter_Department";
            this.Filter_Department.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "All Departments"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Specified Department")});
            this.Filter_Department.Size = new System.Drawing.Size(282, 52);
            this.Filter_Department.TabIndex = 3;
            // 
            // xtraTabPage_Reports
            // 
            this.xtraTabPage_Reports.Controls.Add(this.R_GetRequisitions);
            this.xtraTabPage_Reports.Controls.Add(this.R_Status_PORaised);
            this.xtraTabPage_Reports.Controls.Add(this.R_Status_Served);
            this.xtraTabPage_Reports.Controls.Add(this.R_Status_Discuss);
            this.xtraTabPage_Reports.Controls.Add(this.R_Status_Rejected);
            this.xtraTabPage_Reports.Controls.Add(this.R_Status_Approved);
            this.xtraTabPage_Reports.Controls.Add(this.R_Status_Requested);
            this.xtraTabPage_Reports.Controls.Add(this.label3);
            this.xtraTabPage_Reports.Controls.Add(this.R_UptoDate);
            this.xtraTabPage_Reports.Controls.Add(this.label2);
            this.xtraTabPage_Reports.Controls.Add(this.R_FromDate);
            this.xtraTabPage_Reports.Controls.Add(this.label1);
            this.xtraTabPage_Reports.Controls.Add(this.R_Departments);
            this.xtraTabPage_Reports.Name = "xtraTabPage_Reports";
            this.xtraTabPage_Reports.Size = new System.Drawing.Size(997, 58);
            this.xtraTabPage_Reports.Text = "Reports";
            // 
            // R_GetRequisitions
            // 
            this.R_GetRequisitions.Location = new System.Drawing.Point(461, 30);
            this.R_GetRequisitions.Name = "R_GetRequisitions";
            this.R_GetRequisitions.Size = new System.Drawing.Size(97, 22);
            this.R_GetRequisitions.TabIndex = 18;
            this.R_GetRequisitions.Text = "Get Requisitions";
            this.R_GetRequisitions.Click += new System.EventHandler(this.R_GetRequisitions_Click);
            // 
            // R_Status_PORaised
            // 
            this.R_Status_PORaised.Location = new System.Drawing.Point(377, 34);
            this.R_Status_PORaised.Name = "R_Status_PORaised";
            this.R_Status_PORaised.Properties.Caption = "P/O Raised";
            this.R_Status_PORaised.Size = new System.Drawing.Size(76, 18);
            this.R_Status_PORaised.TabIndex = 17;
            this.R_Status_PORaised.Tag = "4";
            // 
            // R_Status_Served
            // 
            this.R_Status_Served.Location = new System.Drawing.Point(313, 34);
            this.R_Status_Served.Name = "R_Status_Served";
            this.R_Status_Served.Properties.Caption = "Served";
            this.R_Status_Served.Size = new System.Drawing.Size(76, 18);
            this.R_Status_Served.TabIndex = 16;
            this.R_Status_Served.Tag = "3";
            // 
            // R_Status_Discuss
            // 
            this.R_Status_Discuss.Location = new System.Drawing.Point(249, 34);
            this.R_Status_Discuss.Name = "R_Status_Discuss";
            this.R_Status_Discuss.Properties.Caption = "Discuss";
            this.R_Status_Discuss.Size = new System.Drawing.Size(76, 18);
            this.R_Status_Discuss.TabIndex = 15;
            this.R_Status_Discuss.Tag = "5";
            // 
            // R_Status_Rejected
            // 
            this.R_Status_Rejected.Location = new System.Drawing.Point(177, 34);
            this.R_Status_Rejected.Name = "R_Status_Rejected";
            this.R_Status_Rejected.Properties.Caption = "Rejected";
            this.R_Status_Rejected.Size = new System.Drawing.Size(76, 18);
            this.R_Status_Rejected.TabIndex = 14;
            this.R_Status_Rejected.Tag = "2";
            // 
            // R_Status_Approved
            // 
            this.R_Status_Approved.Location = new System.Drawing.Point(95, 34);
            this.R_Status_Approved.Name = "R_Status_Approved";
            this.R_Status_Approved.Properties.Caption = "Approved";
            this.R_Status_Approved.Size = new System.Drawing.Size(76, 18);
            this.R_Status_Approved.TabIndex = 13;
            this.R_Status_Approved.Tag = "1";
            // 
            // R_Status_Requested
            // 
            this.R_Status_Requested.Location = new System.Drawing.Point(13, 34);
            this.R_Status_Requested.Name = "R_Status_Requested";
            this.R_Status_Requested.Properties.Caption = "Requested";
            this.R_Status_Requested.Size = new System.Drawing.Size(76, 18);
            this.R_Status_Requested.TabIndex = 12;
            this.R_Status_Requested.Tag = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Upto";
            // 
            // R_UptoDate
            // 
            this.R_UptoDate.EditValue = null;
            this.R_UptoDate.Location = new System.Drawing.Point(434, 6);
            this.R_UptoDate.Name = "R_UptoDate";
            this.R_UptoDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.R_UptoDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.R_UptoDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.R_UptoDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.R_UptoDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.R_UptoDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.R_UptoDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.R_UptoDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.R_UptoDate.Size = new System.Drawing.Size(124, 20);
            this.R_UptoDate.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "From";
            // 
            // R_FromDate
            // 
            this.R_FromDate.EditValue = null;
            this.R_FromDate.Location = new System.Drawing.Point(265, 6);
            this.R_FromDate.Name = "R_FromDate";
            this.R_FromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.R_FromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.R_FromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.R_FromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.R_FromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.R_FromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.R_FromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.R_FromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.R_FromDate.Size = new System.Drawing.Size(124, 20);
            this.R_FromDate.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Department";
            // 
            // R_Departments
            // 
            this.R_Departments.EnterMoveNextControl = true;
            this.R_Departments.Location = new System.Drawing.Point(77, 6);
            this.R_Departments.Name = "R_Departments";
            this.R_Departments.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R_Departments.Properties.Appearance.Options.UseFont = true;
            this.R_Departments.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.R_Departments.Properties.NullText = "";
            this.R_Departments.Properties.NullValuePrompt = "Ref Department";
            this.R_Departments.Size = new System.Drawing.Size(145, 20);
            this.R_Departments.TabIndex = 6;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControl_Selection);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 91);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1008, 639);
            this.panelControl2.TabIndex = 22;
            // 
            // Store_RequestApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "Store_RequestApproval";
            this.Text = "Approval / Rejection";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Selection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Selection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RequestStatusLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage_View.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Filter_RequisitionStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateReq.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateReq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Stock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentReq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Department.Properties)).EndInit();
            this.xtraTabPage_Reports.ResumeLayout(false);
            this.xtraTabPage_Reports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.R_Status_PORaised.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_Status_Served.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_Status_Discuss.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_Status_Rejected.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_Status_Approved.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_Status_Requested.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_UptoDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_UptoDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_FromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_FromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_Departments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Selection;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Selection;
        private DevExpress.XtraGrid.Columns.GridColumn RequisitionNumber;
        private DevExpress.XtraGrid.Columns.GridColumn Dated;
        private DevExpress.XtraGrid.Columns.GridColumn ItemAccountName;
        private DevExpress.XtraGrid.Columns.GridColumn QtyApprovedByDirector;
        private DevExpress.XtraGrid.Columns.GridColumn Stock;
        private DevExpress.XtraGrid.Columns.GridColumn UOM;
        private DevExpress.XtraGrid.Columns.GridColumn Department;
        private DevExpress.XtraGrid.Columns.GridColumn LoomName;
        private DevExpress.XtraGrid.Columns.GridColumn RequisitionStatus;
        private DevExpress.XtraGrid.Columns.GridColumn Amount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit RequestStatusLookup;
        private DevExpress.XtraGrid.Columns.GridColumn AverageBuyingRate;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.RadioGroup Filter_RequisitionStatus;
        private DevExpress.XtraEditors.RadioGroup Filter_Date;
        private DevExpress.XtraEditors.DateEdit DateReq;
        private DevExpress.XtraEditors.RadioGroup Filter_Department;
        private DevExpress.XtraEditors.RadioGroup Filter_Stock;
        private DevExpress.XtraEditors.LookUpEdit DepartmentReq;
        private DevExpress.XtraEditors.SimpleButton GetRecords;
        private DevExpress.XtraGrid.Columns.GridColumn ItemRate;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_View;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_Reports;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit R_Departments;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.DateEdit R_UptoDate;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit R_FromDate;
        private DevExpress.XtraEditors.SimpleButton R_GetRequisitions;
        private DevExpress.XtraEditors.CheckEdit R_Status_PORaised;
        private DevExpress.XtraEditors.CheckEdit R_Status_Served;
        private DevExpress.XtraEditors.CheckEdit R_Status_Discuss;
        private DevExpress.XtraEditors.CheckEdit R_Status_Rejected;
        private DevExpress.XtraEditors.CheckEdit R_Status_Approved;
        private DevExpress.XtraEditors.CheckEdit R_Status_Requested;
    }
}