namespace MachineEyes.UserControls
{
    partial class dx_FilterView
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cGrid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cLoom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cSection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cRPM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cEfficiency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cProdEfficiency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cStopCause = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cArticle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cWarpStops = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cWeftStops = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cWarpPerHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cWeftPerHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemCalcEdit1,
            this.repositoryItemSpinEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1024, 768);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cGrid,
            this.cLoom,
            this.cSection,
            this.cType,
            this.cRPM,
            this.cEfficiency,
            this.cProdEfficiency,
            this.cStopCause,
            this.cArticle,
            this.cWarpStops,
            this.cWeftStops,
            this.cWarpPerHour,
            this.cWeftPerHour});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "LoomNumber", this.cLoom, "{0:#,#}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "RPM", this.cRPM, "{0:#,#}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WarpStops", this.cWarpStops, "{0:#,#}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WeftStops", this.cWeftStops, "{0:#,#}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "Efficiency", this.cEfficiency, "{0:#,#0.0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "WarpPerHour", this.cWarpPerHour, "{0:#,#0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "WeftPerHour", this.cWeftPerHour, "{0:#,#0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "ProdEff", this.cProdEfficiency, "{0:#,#0.0}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.cArticle, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // cGrid
            // 
            this.cGrid.AppearanceCell.Options.UseTextOptions = true;
            this.cGrid.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cGrid.Caption = "Shed";
            this.cGrid.DisplayFormat.FormatString = "#,##";
            this.cGrid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cGrid.FieldName = "Shed";
            this.cGrid.Name = "cGrid";
            this.cGrid.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.cGrid.Visible = true;
            this.cGrid.VisibleIndex = 0;
            this.cGrid.Width = 41;
            // 
            // cLoom
            // 
            this.cLoom.AppearanceCell.Options.UseTextOptions = true;
            this.cLoom.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cLoom.Caption = "Loom #";
            this.cLoom.DisplayFormat.FormatString = "{0:n1}";
            this.cLoom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cLoom.FieldName = "LoomNumber";
            this.cLoom.Name = "cLoom";
            this.cLoom.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.cLoom.Visible = true;
            this.cLoom.VisibleIndex = 1;
            this.cLoom.Width = 47;
            // 
            // cSection
            // 
            this.cSection.AppearanceCell.Options.UseTextOptions = true;
            this.cSection.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.cSection.Caption = "Section";
            this.cSection.FieldName = "LoomSection";
            this.cSection.Name = "cSection";
            this.cSection.Visible = true;
            this.cSection.VisibleIndex = 3;
            this.cSection.Width = 133;
            // 
            // cType
            // 
            this.cType.AppearanceCell.Options.UseTextOptions = true;
            this.cType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.cType.Caption = "Type";
            this.cType.FieldName = "LoomType";
            this.cType.Name = "cType";
            this.cType.Visible = true;
            this.cType.VisibleIndex = 4;
            this.cType.Width = 133;
            // 
            // cRPM
            // 
            this.cRPM.AppearanceCell.Options.UseTextOptions = true;
            this.cRPM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cRPM.Caption = "RPM";
            this.cRPM.DisplayFormat.FormatString = "{0:#,#}";
            this.cRPM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.cRPM.FieldName = "RPM";
            this.cRPM.GroupFormat.FormatString = "{0:#,#}";
            this.cRPM.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.cRPM.Name = "cRPM";
            this.cRPM.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.cRPM.Visible = true;
            this.cRPM.VisibleIndex = 5;
            this.cRPM.Width = 60;
            // 
            // cEfficiency
            // 
            this.cEfficiency.AppearanceCell.Options.UseTextOptions = true;
            this.cEfficiency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cEfficiency.Caption = "Efficiency";
            this.cEfficiency.DisplayFormat.FormatString = "{0:#,#0.0}";
            this.cEfficiency.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.cEfficiency.FieldName = "Efficiency";
            this.cEfficiency.Name = "cEfficiency";
            this.cEfficiency.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.cEfficiency.Visible = true;
            this.cEfficiency.VisibleIndex = 6;
            this.cEfficiency.Width = 96;
            // 
            // cProdEfficiency
            // 
            this.cProdEfficiency.AppearanceCell.Options.UseTextOptions = true;
            this.cProdEfficiency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cProdEfficiency.Caption = "Prod. Eff.";
            this.cProdEfficiency.DisplayFormat.FormatString = "{0:#,#0.0}";
            this.cProdEfficiency.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.cProdEfficiency.FieldName = "ProdEff";
            this.cProdEfficiency.Name = "cProdEfficiency";
            this.cProdEfficiency.Visible = true;
            this.cProdEfficiency.VisibleIndex = 7;
            this.cProdEfficiency.Width = 141;
            // 
            // cStopCause
            // 
            this.cStopCause.AppearanceCell.Options.UseTextOptions = true;
            this.cStopCause.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cStopCause.Caption = "Stop Cause";
            this.cStopCause.FieldName = "StopCause";
            this.cStopCause.Name = "cStopCause";
            this.cStopCause.Visible = true;
            this.cStopCause.VisibleIndex = 12;
            this.cStopCause.Width = 133;
            // 
            // cArticle
            // 
            this.cArticle.AppearanceCell.Options.UseTextOptions = true;
            this.cArticle.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.cArticle.Caption = "Article";
            this.cArticle.FieldName = "Article";
            this.cArticle.Name = "cArticle";
            this.cArticle.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.cArticle.Width = 33;
            // 
            // cWarpStops
            // 
            this.cWarpStops.AppearanceCell.Options.UseTextOptions = true;
            this.cWarpStops.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cWarpStops.Caption = "Warp Stops";
            this.cWarpStops.DisplayFormat.FormatString = "{0:#,#}";
            this.cWarpStops.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.cWarpStops.FieldName = "WarpStops";
            this.cWarpStops.Name = "cWarpStops";
            this.cWarpStops.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.cWarpStops.Visible = true;
            this.cWarpStops.VisibleIndex = 8;
            this.cWarpStops.Width = 113;
            // 
            // cWeftStops
            // 
            this.cWeftStops.AppearanceCell.Options.UseTextOptions = true;
            this.cWeftStops.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cWeftStops.Caption = "Weft Stops";
            this.cWeftStops.DisplayFormat.FormatString = "{0:#,#}";
            this.cWeftStops.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.cWeftStops.FieldName = "WeftStops";
            this.cWeftStops.Name = "cWeftStops";
            this.cWeftStops.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.cWeftStops.Visible = true;
            this.cWeftStops.VisibleIndex = 9;
            this.cWeftStops.Width = 104;
            // 
            // cWarpPerHour
            // 
            this.cWarpPerHour.AppearanceCell.Options.UseTextOptions = true;
            this.cWarpPerHour.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cWarpPerHour.Caption = "W / H";
            this.cWarpPerHour.DisplayFormat.FormatString = "{0:#,#}";
            this.cWarpPerHour.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.cWarpPerHour.FieldName = "WarpPerHour";
            this.cWarpPerHour.Name = "cWarpPerHour";
            this.cWarpPerHour.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.cWarpPerHour.Visible = true;
            this.cWarpPerHour.VisibleIndex = 10;
            this.cWarpPerHour.Width = 71;
            // 
            // cWeftPerHour
            // 
            this.cWeftPerHour.AppearanceCell.Options.UseTextOptions = true;
            this.cWeftPerHour.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cWeftPerHour.Caption = "F / H";
            this.cWeftPerHour.DisplayFormat.FormatString = "{0:#,#}";
            this.cWeftPerHour.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.cWeftPerHour.FieldName = "WeftPerHour";
            this.cWeftPerHour.Name = "cWeftPerHour";
            this.cWeftPerHour.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.cWeftPerHour.Visible = true;
            this.cWeftPerHour.VisibleIndex = 11;
            this.cWeftPerHour.Width = 74;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", "Product Name")});
            this.repositoryItemLookUpEdit1.DisplayMember = "ProductName";
            this.repositoryItemLookUpEdit1.DropDownRows = 10;
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.PopupWidth = 220;
            this.repositoryItemLookUpEdit1.ValueMember = "ProductID";
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.IsFloatValue = false;
            this.repositoryItemSpinEdit1.Mask.EditMask = "N00";
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // dx_FilterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.gridControl1);
            this.Name = "dx_FilterView";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.dx_FilterView_Load);
            this.Leave += new System.EventHandler(this.dx_FilterView_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn cGrid;
        private DevExpress.XtraGrid.Columns.GridColumn cLoom;
        private DevExpress.XtraGrid.Columns.GridColumn cArticle;
        private DevExpress.XtraGrid.Columns.GridColumn cRPM;
        private DevExpress.XtraGrid.Columns.GridColumn cEfficiency;
        private DevExpress.XtraGrid.Columns.GridColumn cWarpStops;
        private DevExpress.XtraGrid.Columns.GridColumn cWeftStops;
        private DevExpress.XtraGrid.Columns.GridColumn cWarpPerHour;
        private DevExpress.XtraGrid.Columns.GridColumn cWeftPerHour;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn cSection;
        private DevExpress.XtraGrid.Columns.GridColumn cType;
        private DevExpress.XtraGrid.Columns.GridColumn cProdEfficiency;
        private DevExpress.XtraGrid.Columns.GridColumn cStopCause;


    }
}
