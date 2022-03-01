namespace MachineEyes.Reports
{
    partial class Accounts_ChartofAccount
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.AccountIndex = new DevExpress.XtraReports.UI.XRLabel();
            this.AccountName_V = new DevExpress.XtraReports.UI.XRLabel();
            this.AccountID_V = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.RepH_DocumentName = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.AccountName_IV = new DevExpress.XtraReports.UI.XRLabel();
            this.AccountID_IV = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.AccountName_III = new DevExpress.XtraReports.UI.XRLabel();
            this.AccountID_III = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.AccountName_II = new DevExpress.XtraReports.UI.XRLabel();
            this.AccountID_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.AccountName_I = new DevExpress.XtraReports.UI.XRLabel();
            this.AccountID_I = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.FinancialYear = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.AccountIndex,
            this.AccountName_V,
            this.AccountID_V});
            this.Detail.HeightF = 21F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // AccountIndex
            // 
            this.AccountIndex.BorderColor = System.Drawing.Color.Silver;
            this.AccountIndex.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AccountIndex.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountIndex.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountIndex.LocationFloat = new DevExpress.Utils.PointFloat(147.7746F, 0F);
            this.AccountIndex.Name = "AccountIndex";
            this.AccountIndex.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountIndex.SizeF = new System.Drawing.SizeF(26.8996F, 17F);
            this.AccountIndex.StylePriority.UseBorderColor = false;
            this.AccountIndex.StylePriority.UseBorders = false;
            this.AccountIndex.StylePriority.UseFont = false;
            this.AccountIndex.StylePriority.UseForeColor = false;
            this.AccountIndex.StylePriority.UseTextAlignment = false;
            this.AccountIndex.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.AccountIndex.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.AccountIndex_BeforePrint);
            // 
            // AccountName_V
            // 
            this.AccountName_V.BorderColor = System.Drawing.Color.Silver;
            this.AccountName_V.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AccountName_V.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountName_V")});
            this.AccountName_V.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountName_V.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountName_V.LocationFloat = new DevExpress.Utils.PointFloat(273.9583F, 0F);
            this.AccountName_V.Name = "AccountName_V";
            this.AccountName_V.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountName_V.SizeF = new System.Drawing.SizeF(384.7009F, 17F);
            this.AccountName_V.StylePriority.UseBorderColor = false;
            this.AccountName_V.StylePriority.UseBorders = false;
            this.AccountName_V.StylePriority.UseFont = false;
            this.AccountName_V.StylePriority.UseForeColor = false;
            this.AccountName_V.StylePriority.UseTextAlignment = false;
            this.AccountName_V.Text = "xr_DocNumber";
            this.AccountName_V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // AccountID_V
            // 
            this.AccountID_V.BorderColor = System.Drawing.Color.Silver;
            this.AccountID_V.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AccountID_V.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountID_V")});
            this.AccountID_V.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountID_V.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountID_V.LocationFloat = new DevExpress.Utils.PointFloat(174.6742F, 0F);
            this.AccountID_V.Name = "AccountID_V";
            this.AccountID_V.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountID_V.SizeF = new System.Drawing.SizeF(99.28416F, 17F);
            this.AccountID_V.StylePriority.UseBorderColor = false;
            this.AccountID_V.StylePriority.UseBorders = false;
            this.AccountID_V.StylePriority.UseFont = false;
            this.AccountID_V.StylePriority.UseForeColor = false;
            this.AccountID_V.StylePriority.UseTextAlignment = false;
            this.AccountID_V.Text = "xr_DocNumber";
            this.AccountID_V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 46F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 32F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.BorderColor = System.Drawing.Color.Silver;
            this.xrPageInfo1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPageInfo1.BorderWidth = 1;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.Format = "{0:dddd, MMMM dd, yyyy h:mm tt}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(202.3955F, 22.58332F);
            this.xrPageInfo1.StylePriority.UseBorderColor = false;
            this.xrPageInfo1.StylePriority.UseBorders = false;
            this.xrPageInfo1.StylePriority.UseBorderWidth = false;
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.BorderColor = System.Drawing.Color.Silver;
            this.xrPageInfo2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPageInfo2.BorderWidth = 1;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "Page {0} of {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(607.0211F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(81.97888F, 22.58332F);
            this.xrPageInfo2.StylePriority.UseBorderColor = false;
            this.xrPageInfo2.StylePriority.UseBorders = false;
            this.xrPageInfo2.StylePriority.UseBorderWidth = false;
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // RepH_DocumentName
            // 
            this.RepH_DocumentName.BorderColor = System.Drawing.Color.Silver;
            this.RepH_DocumentName.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.RepH_DocumentName.BorderWidth = 1;
            this.RepH_DocumentName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepH_DocumentName.LocationFloat = new DevExpress.Utils.PointFloat(273.9583F, 0F);
            this.RepH_DocumentName.Name = "RepH_DocumentName";
            this.RepH_DocumentName.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.RepH_DocumentName.SizeF = new System.Drawing.SizeF(110.729F, 22.58333F);
            this.RepH_DocumentName.StylePriority.UseBorderColor = false;
            this.RepH_DocumentName.StylePriority.UseBorders = false;
            this.RepH_DocumentName.StylePriority.UseBorderWidth = false;
            this.RepH_DocumentName.StylePriority.UseFont = false;
            this.RepH_DocumentName.StylePriority.UsePadding = false;
            this.RepH_DocumentName.StylePriority.UseTextAlignment = false;
            this.RepH_DocumentName.Text = "Chart of Accounts";
            this.RepH_DocumentName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.PageFooter.HeightF = 27F;
            this.PageFooter.Name = "PageFooter";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.FinancialYear,
            this.xrLabel27,
            this.RepH_DocumentName});
            this.ReportHeader.HeightF = 26F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.AccountName_IV,
            this.AccountID_IV});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("AccountID_IV", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 20F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // AccountName_IV
            // 
            this.AccountName_IV.BorderColor = System.Drawing.Color.Silver;
            this.AccountName_IV.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AccountName_IV.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountName_IV")});
            this.AccountName_IV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountName_IV.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountName_IV.LocationFloat = new DevExpress.Utils.PointFloat(216.1667F, 0F);
            this.AccountName_IV.Name = "AccountName_IV";
            this.AccountName_IV.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountName_IV.SizeF = new System.Drawing.SizeF(384.7009F, 20F);
            this.AccountName_IV.StylePriority.UseBorderColor = false;
            this.AccountName_IV.StylePriority.UseBorders = false;
            this.AccountName_IV.StylePriority.UseFont = false;
            this.AccountName_IV.StylePriority.UseForeColor = false;
            this.AccountName_IV.StylePriority.UseTextAlignment = false;
            this.AccountName_IV.Text = "xr_DocNumber";
            this.AccountName_IV.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.AccountName_IV.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.AccountName_IV_BeforePrint);
            // 
            // AccountID_IV
            // 
            this.AccountID_IV.BorderColor = System.Drawing.Color.Silver;
            this.AccountID_IV.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AccountID_IV.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountID_IV")});
            this.AccountID_IV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountID_IV.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountID_IV.LocationFloat = new DevExpress.Utils.PointFloat(116.8825F, 0F);
            this.AccountID_IV.Name = "AccountID_IV";
            this.AccountID_IV.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountID_IV.SizeF = new System.Drawing.SizeF(99.28414F, 20F);
            this.AccountID_IV.StylePriority.UseBorderColor = false;
            this.AccountID_IV.StylePriority.UseBorders = false;
            this.AccountID_IV.StylePriority.UseFont = false;
            this.AccountID_IV.StylePriority.UseForeColor = false;
            this.AccountID_IV.StylePriority.UseTextAlignment = false;
            this.AccountID_IV.Text = "xr_DocNumber";
            this.AccountID_IV.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.AccountName_III,
            this.AccountID_III});
            this.GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("AccountID_III", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader2.HeightF = 23F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // AccountName_III
            // 
            this.AccountName_III.BorderColor = System.Drawing.Color.Silver;
            this.AccountName_III.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AccountName_III.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountName_III")});
            this.AccountName_III.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountName_III.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountName_III.LocationFloat = new DevExpress.Utils.PointFloat(183.875F, 0F);
            this.AccountName_III.Name = "AccountName_III";
            this.AccountName_III.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountName_III.SizeF = new System.Drawing.SizeF(384.7009F, 23F);
            this.AccountName_III.StylePriority.UseBorderColor = false;
            this.AccountName_III.StylePriority.UseBorders = false;
            this.AccountName_III.StylePriority.UseFont = false;
            this.AccountName_III.StylePriority.UseForeColor = false;
            this.AccountName_III.StylePriority.UseTextAlignment = false;
            this.AccountName_III.Text = "xr_DocNumber";
            this.AccountName_III.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // AccountID_III
            // 
            this.AccountID_III.BorderColor = System.Drawing.Color.Silver;
            this.AccountID_III.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AccountID_III.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountID_III")});
            this.AccountID_III.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountID_III.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountID_III.LocationFloat = new DevExpress.Utils.PointFloat(84.59082F, 0F);
            this.AccountID_III.Name = "AccountID_III";
            this.AccountID_III.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountID_III.SizeF = new System.Drawing.SizeF(99.28413F, 23F);
            this.AccountID_III.StylePriority.UseBorderColor = false;
            this.AccountID_III.StylePriority.UseBorders = false;
            this.AccountID_III.StylePriority.UseFont = false;
            this.AccountID_III.StylePriority.UseForeColor = false;
            this.AccountID_III.StylePriority.UseTextAlignment = false;
            this.AccountID_III.Text = "xr_DocNumber";
            this.AccountID_III.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.AccountName_II,
            this.AccountID_2});
            this.GroupHeader3.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("AccountID_II", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3.HeightF = 22F;
            this.GroupHeader3.Level = 2;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // AccountName_II
            // 
            this.AccountName_II.BorderColor = System.Drawing.Color.Silver;
            this.AccountName_II.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AccountName_II.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountName_II")});
            this.AccountName_II.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountName_II.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountName_II.LocationFloat = new DevExpress.Utils.PointFloat(134.9167F, 0F);
            this.AccountName_II.Name = "AccountName_II";
            this.AccountName_II.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountName_II.SizeF = new System.Drawing.SizeF(384.701F, 22F);
            this.AccountName_II.StylePriority.UseBorderColor = false;
            this.AccountName_II.StylePriority.UseBorders = false;
            this.AccountName_II.StylePriority.UseFont = false;
            this.AccountName_II.StylePriority.UseForeColor = false;
            this.AccountName_II.StylePriority.UseTextAlignment = false;
            this.AccountName_II.Text = "xr_DocNumber";
            this.AccountName_II.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // AccountID_2
            // 
            this.AccountID_2.BorderColor = System.Drawing.Color.Silver;
            this.AccountID_2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AccountID_2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountID_II")});
            this.AccountID_2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountID_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountID_2.LocationFloat = new DevExpress.Utils.PointFloat(35.63248F, 0F);
            this.AccountID_2.Name = "AccountID_2";
            this.AccountID_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountID_2.SizeF = new System.Drawing.SizeF(99.28416F, 22F);
            this.AccountID_2.StylePriority.UseBorderColor = false;
            this.AccountID_2.StylePriority.UseBorders = false;
            this.AccountID_2.StylePriority.UseFont = false;
            this.AccountID_2.StylePriority.UseForeColor = false;
            this.AccountID_2.StylePriority.UseTextAlignment = false;
            this.AccountID_2.Text = "xr_DocNumber";
            this.AccountID_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.AccountName_I,
            this.AccountID_I});
            this.GroupHeader4.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("AccountID_I", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader4.HeightF = 24F;
            this.GroupHeader4.Level = 3;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // AccountName_I
            // 
            this.AccountName_I.BorderColor = System.Drawing.Color.Silver;
            this.AccountName_I.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AccountName_I.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountName_I")});
            this.AccountName_I.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountName_I.ForeColor = System.Drawing.Color.Gray;
            this.AccountName_I.LocationFloat = new DevExpress.Utils.PointFloat(99.28416F, 0F);
            this.AccountName_I.Name = "AccountName_I";
            this.AccountName_I.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountName_I.SizeF = new System.Drawing.SizeF(559.375F, 24F);
            this.AccountName_I.StylePriority.UseBorderColor = false;
            this.AccountName_I.StylePriority.UseBorders = false;
            this.AccountName_I.StylePriority.UseFont = false;
            this.AccountName_I.StylePriority.UseForeColor = false;
            this.AccountName_I.StylePriority.UseTextAlignment = false;
            this.AccountName_I.Text = "xr_DocNumber";
            this.AccountName_I.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // AccountID_I
            // 
            this.AccountID_I.BorderColor = System.Drawing.Color.Silver;
            this.AccountID_I.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AccountID_I.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountID_I")});
            this.AccountID_I.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountID_I.ForeColor = System.Drawing.Color.Gray;
            this.AccountID_I.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.AccountID_I.Name = "AccountID_I";
            this.AccountID_I.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountID_I.SizeF = new System.Drawing.SizeF(99.28416F, 24F);
            this.AccountID_I.StylePriority.UseBorderColor = false;
            this.AccountID_I.StylePriority.UseBorders = false;
            this.AccountID_I.StylePriority.UseFont = false;
            this.AccountID_I.StylePriority.UseForeColor = false;
            this.AccountID_I.StylePriority.UseTextAlignment = false;
            this.AccountID_I.Text = "AccountID_I";
            this.AccountID_I.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel27
            // 
            this.xrLabel27.BackColor = System.Drawing.Color.Black;
            this.xrLabel27.BorderColor = System.Drawing.Color.Black;
            this.xrLabel27.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel27.BorderWidth = 1;
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.ForeColor = System.Drawing.Color.White;
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(539.6177F, 1.624997F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(95.31609F, 20.95832F);
            this.xrLabel27.StylePriority.UseBackColor = false;
            this.xrLabel27.StylePriority.UseBorderColor = false;
            this.xrLabel27.StylePriority.UseBorders = false;
            this.xrLabel27.StylePriority.UseBorderWidth = false;
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseForeColor = false;
            this.xrLabel27.StylePriority.UsePadding = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Financial Year";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // FinancialYear
            // 
            this.FinancialYear.BackColor = System.Drawing.Color.Black;
            this.FinancialYear.BorderColor = System.Drawing.Color.Black;
            this.FinancialYear.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.FinancialYear.BorderWidth = 1;
            this.FinancialYear.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinancialYear.ForeColor = System.Drawing.Color.White;
            this.FinancialYear.LocationFloat = new DevExpress.Utils.PointFloat(634.9339F, 1.624997F);
            this.FinancialYear.Name = "FinancialYear";
            this.FinancialYear.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.FinancialYear.SizeF = new System.Drawing.SizeF(64.06609F, 20.95832F);
            this.FinancialYear.StylePriority.UseBackColor = false;
            this.FinancialYear.StylePriority.UseBorderColor = false;
            this.FinancialYear.StylePriority.UseBorders = false;
            this.FinancialYear.StylePriority.UseBorderWidth = false;
            this.FinancialYear.StylePriority.UseFont = false;
            this.FinancialYear.StylePriority.UseForeColor = false;
            this.FinancialYear.StylePriority.UsePadding = false;
            this.FinancialYear.StylePriority.UseTextAlignment = false;
            this.FinancialYear.Text = "2014-2015";
            this.FinancialYear.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.FinancialYear.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.FinancialYear_BeforePrint);
            // 
            // Accounts_ChartofAccount
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageFooter,
            this.ReportHeader,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupHeader3,
            this.GroupHeader4});
            this.Margins = new System.Drawing.Printing.Margins(100, 51, 46, 32);
            this.SnapToGrid = false;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        public DevExpress.XtraReports.UI.XRLabel RepH_DocumentName;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader4;
        private DevExpress.XtraReports.UI.XRLabel AccountIndex;
        private DevExpress.XtraReports.UI.XRLabel AccountName_V;
        private DevExpress.XtraReports.UI.XRLabel AccountID_V;
        private DevExpress.XtraReports.UI.XRLabel AccountName_IV;
        private DevExpress.XtraReports.UI.XRLabel AccountID_IV;
        private DevExpress.XtraReports.UI.XRLabel AccountName_III;
        private DevExpress.XtraReports.UI.XRLabel AccountID_III;
        private DevExpress.XtraReports.UI.XRLabel AccountName_II;
        private DevExpress.XtraReports.UI.XRLabel AccountID_2;
        private DevExpress.XtraReports.UI.XRLabel AccountName_I;
        private DevExpress.XtraReports.UI.XRLabel AccountID_I;
        private DevExpress.XtraReports.UI.XRLabel FinancialYear;
        private DevExpress.XtraReports.UI.XRLabel xrLabel27;
    }
}
