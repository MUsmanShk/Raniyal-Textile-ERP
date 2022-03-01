namespace MachineEyes.Reports
{
    partial class YarnStockLedger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YarnStockLedger));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.LbsBalance = new DevExpress.XtraReports.UI.XRLabel();
            this.YarnPly = new DevExpress.XtraReports.UI.XRLabel();
            this.Dept = new DevExpress.XtraReports.UI.XRLabel();
            this.YarnSubType = new DevExpress.XtraReports.UI.XRLabel();
            this.LbsAdjusted = new DevExpress.XtraReports.UI.XRLabel();
            this.LbsIssued = new DevExpress.XtraReports.UI.XRLabel();
            this.LbsReceived = new DevExpress.XtraReports.UI.XRLabel();
            this.LbsOpening = new DevExpress.XtraReports.UI.XRLabel();
            this.YarnBrand = new DevExpress.XtraReports.UI.XRLabel();
            this.YarnDesc = new DevExpress.XtraReports.UI.XRLabel();
            this.YarnBlend = new DevExpress.XtraReports.UI.XRLabel();
            this.YarnCount = new DevExpress.XtraReports.UI.XRLabel();
            this.BagsType = new DevExpress.XtraReports.UI.XRLabel();
            this.PlySlash = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Account = new DevExpress.XtraReports.UI.XRLabel();
            this.RepH_Company = new DevExpress.XtraReports.UI.XRLabel();
            this.RepH_DocumentName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_FromDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_ToDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCustomer = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.yarnContract1 = new MachineEyes.DataTables.YarnContract();
            this.qP_YarnStock_YarnStockDetailTableAdapter = new MachineEyes.DataTables.YarnContractTableAdapters.QP_YarnStock_YarnStockDetailTableAdapter();
            this.Additionalinfo = new DevExpress.XtraReports.UI.CalculatedField();
            this.Additional_RICA = new DevExpress.XtraReports.UI.CalculatedField();
            this.Additional_Bags = new DevExpress.XtraReports.UI.CalculatedField();
            this.Additional_Cones = new DevExpress.XtraReports.UI.CalculatedField();
            this.Additional_Lbs = new DevExpress.XtraReports.UI.CalculatedField();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.yarnContract1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.LbsBalance,
            this.YarnPly,
            this.Dept,
            this.YarnSubType,
            this.LbsAdjusted,
            this.LbsIssued,
            this.LbsReceived,
            this.LbsOpening,
            this.YarnBrand,
            this.YarnDesc,
            this.YarnBlend,
            this.YarnCount,
            this.BagsType,
            this.PlySlash});
            this.Detail.HeightF = 22F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // LbsBalance
            // 
            this.LbsBalance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.LbsBalance.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LbsBalance.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Lbs_Balance")});
            this.LbsBalance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbsBalance.LocationFloat = new DevExpress.Utils.PointFloat(693.4232F, 0F);
            this.LbsBalance.Name = "LbsBalance";
            this.LbsBalance.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LbsBalance.SizeF = new System.Drawing.SizeF(56.57678F, 17F);
            this.LbsBalance.StylePriority.UseFont = false;
            this.LbsBalance.StylePriority.UseTextAlignment = false;
            this.LbsBalance.Text = "xr_LbsAdj";
            this.LbsBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // YarnPly
            // 
            this.YarnPly.BorderColor = System.Drawing.SystemColors.ControlText;
            this.YarnPly.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.YarnPly.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "YarnPly")});
            this.YarnPly.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnPly.LocationFloat = new DevExpress.Utils.PointFloat(280.8869F, 0F);
            this.YarnPly.Name = "YarnPly";
            this.YarnPly.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.YarnPly.SizeF = new System.Drawing.SizeF(21.60422F, 17F);
            this.YarnPly.StylePriority.UseFont = false;
            this.YarnPly.StylePriority.UseTextAlignment = false;
            this.YarnPly.Text = "xr_YarnCount";
            this.YarnPly.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Dept
            // 
            this.Dept.BorderColor = System.Drawing.SystemColors.ControlText;
            this.Dept.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Dept.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "InOutDeptTypesName")});
            this.Dept.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dept.LocationFloat = new DevExpress.Utils.PointFloat(103.4926F, 0F);
            this.Dept.Name = "Dept";
            this.Dept.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Dept.SizeF = new System.Drawing.SizeF(82.48314F, 17F);
            this.Dept.StylePriority.UseFont = false;
            this.Dept.StylePriority.UseTextAlignment = false;
            this.Dept.Text = "xr_YarnBagsType";
            this.Dept.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // YarnSubType
            // 
            this.YarnSubType.BorderColor = System.Drawing.SystemColors.ControlText;
            this.YarnSubType.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.YarnSubType.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "InoutSubTypesName")});
            this.YarnSubType.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnSubType.LocationFloat = new DevExpress.Utils.PointFloat(2.000109F, 0F);
            this.YarnSubType.Name = "YarnSubType";
            this.YarnSubType.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.YarnSubType.SizeF = new System.Drawing.SizeF(100.4925F, 17F);
            this.YarnSubType.StylePriority.UseFont = false;
            this.YarnSubType.StylePriority.UseTextAlignment = false;
            this.YarnSubType.Text = "xr_YarnBagsType";
            this.YarnSubType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // LbsAdjusted
            // 
            this.LbsAdjusted.BorderColor = System.Drawing.SystemColors.ControlText;
            this.LbsAdjusted.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LbsAdjusted.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Lbs_Adjusted")});
            this.LbsAdjusted.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbsAdjusted.LocationFloat = new DevExpress.Utils.PointFloat(635.8464F, 0F);
            this.LbsAdjusted.Name = "LbsAdjusted";
            this.LbsAdjusted.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LbsAdjusted.SizeF = new System.Drawing.SizeF(56.57678F, 17F);
            this.LbsAdjusted.StylePriority.UseFont = false;
            this.LbsAdjusted.StylePriority.UseTextAlignment = false;
            this.LbsAdjusted.Text = "LbsAdjusted";
            this.LbsAdjusted.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // LbsIssued
            // 
            this.LbsIssued.BorderColor = System.Drawing.SystemColors.ControlText;
            this.LbsIssued.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LbsIssued.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Lbs_Issued")});
            this.LbsIssued.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbsIssued.LocationFloat = new DevExpress.Utils.PointFloat(578.0921F, 0F);
            this.LbsIssued.Name = "LbsIssued";
            this.LbsIssued.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LbsIssued.SizeF = new System.Drawing.SizeF(56.57678F, 17F);
            this.LbsIssued.StylePriority.UseFont = false;
            this.LbsIssued.StylePriority.UseTextAlignment = false;
            this.LbsIssued.Text = "LbsIssued";
            this.LbsIssued.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // LbsReceived
            // 
            this.LbsReceived.BorderColor = System.Drawing.SystemColors.ControlText;
            this.LbsReceived.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LbsReceived.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Lbs_Received")});
            this.LbsReceived.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbsReceived.LocationFloat = new DevExpress.Utils.PointFloat(520.5153F, 0F);
            this.LbsReceived.Name = "LbsReceived";
            this.LbsReceived.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LbsReceived.SizeF = new System.Drawing.SizeF(56.57678F, 17F);
            this.LbsReceived.StylePriority.UseFont = false;
            this.LbsReceived.StylePriority.UseTextAlignment = false;
            this.LbsReceived.Text = "LbsReceived";
            this.LbsReceived.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // LbsOpening
            // 
            this.LbsOpening.BorderColor = System.Drawing.SystemColors.ControlText;
            this.LbsOpening.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LbsOpening.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Lbs_Opening")});
            this.LbsOpening.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbsOpening.LocationFloat = new DevExpress.Utils.PointFloat(462.9385F, 0F);
            this.LbsOpening.Name = "LbsOpening";
            this.LbsOpening.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LbsOpening.SizeF = new System.Drawing.SizeF(56.57678F, 17F);
            this.LbsOpening.StylePriority.UseFont = false;
            this.LbsOpening.StylePriority.UseTextAlignment = false;
            this.LbsOpening.Text = "LbsOpening";
            this.LbsOpening.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // YarnBrand
            // 
            this.YarnBrand.BorderColor = System.Drawing.SystemColors.ControlText;
            this.YarnBrand.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.YarnBrand.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "YarnBrand")});
            this.YarnBrand.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnBrand.LocationFloat = new DevExpress.Utils.PointFloat(407.3552F, 0F);
            this.YarnBrand.Name = "YarnBrand";
            this.YarnBrand.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.YarnBrand.SizeF = new System.Drawing.SizeF(54.58331F, 17F);
            this.YarnBrand.StylePriority.UseFont = false;
            this.YarnBrand.StylePriority.UseTextAlignment = false;
            this.YarnBrand.Text = "YarnBrand";
            this.YarnBrand.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // YarnDesc
            // 
            this.YarnDesc.BorderColor = System.Drawing.SystemColors.ControlText;
            this.YarnDesc.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.YarnDesc.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "YarnDesc")});
            this.YarnDesc.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnDesc.LocationFloat = new DevExpress.Utils.PointFloat(354.1885F, 0F);
            this.YarnDesc.Name = "YarnDesc";
            this.YarnDesc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.YarnDesc.SizeF = new System.Drawing.SizeF(52.16669F, 17F);
            this.YarnDesc.StylePriority.UseFont = false;
            this.YarnDesc.StylePriority.UseTextAlignment = false;
            this.YarnDesc.Text = "YarnDesc";
            this.YarnDesc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // YarnBlend
            // 
            this.YarnBlend.BorderColor = System.Drawing.SystemColors.ControlText;
            this.YarnBlend.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.YarnBlend.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "YarnBlend")});
            this.YarnBlend.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnBlend.LocationFloat = new DevExpress.Utils.PointFloat(303.4911F, 0F);
            this.YarnBlend.Name = "YarnBlend";
            this.YarnBlend.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.YarnBlend.SizeF = new System.Drawing.SizeF(49.16667F, 17F);
            this.YarnBlend.StylePriority.UseFont = false;
            this.YarnBlend.StylePriority.UseTextAlignment = false;
            this.YarnBlend.Text = "YarnBlend";
            this.YarnBlend.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // YarnCount
            // 
            this.YarnCount.BorderColor = System.Drawing.SystemColors.ControlText;
            this.YarnCount.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.YarnCount.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "YarnCount")});
            this.YarnCount.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnCount.LocationFloat = new DevExpress.Utils.PointFloat(233.58F, 0F);
            this.YarnCount.Name = "YarnCount";
            this.YarnCount.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.YarnCount.SizeF = new System.Drawing.SizeF(38.60423F, 17F);
            this.YarnCount.StylePriority.UseFont = false;
            this.YarnCount.StylePriority.UseTextAlignment = false;
            this.YarnCount.Text = "YarnCount";
            this.YarnCount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // BagsType
            // 
            this.BagsType.BorderColor = System.Drawing.SystemColors.ControlText;
            this.BagsType.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.BagsType.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "YarnBagsType")});
            this.BagsType.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BagsType.LocationFloat = new DevExpress.Utils.PointFloat(187.9758F, 0F);
            this.BagsType.Name = "BagsType";
            this.BagsType.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BagsType.SizeF = new System.Drawing.SizeF(44.60421F, 17F);
            this.BagsType.StylePriority.UseFont = false;
            this.BagsType.StylePriority.UseTextAlignment = false;
            this.BagsType.Text = "BagsType";
            this.BagsType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PlySlash
            // 
            this.PlySlash.BorderColor = System.Drawing.SystemColors.ControlText;
            this.PlySlash.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PlySlash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.PlySlash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.PlySlash.LocationFloat = new DevExpress.Utils.PointFloat(272.1842F, 0F);
            this.PlySlash.Name = "PlySlash";
            this.PlySlash.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PlySlash.SizeF = new System.Drawing.SizeF(7.166718F, 17F);
            this.PlySlash.StylePriority.UseTextAlignment = false;
            this.PlySlash.Text = "/";
            this.PlySlash.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 31F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 41F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Account,
            this.RepH_Company,
            this.RepH_DocumentName,
            this.xrLabel10,
            this.xr_FromDate,
            this.xrLabel12,
            this.xr_ToDate,
            this.xrLabel4});
            this.ReportHeader.HeightF = 50F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // Account
            // 
            this.Account.BorderColor = System.Drawing.SystemColors.ControlText;
            this.Account.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Account.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Account.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.Account.LocationFloat = new DevExpress.Utils.PointFloat(72.49268F, 26.58332F);
            this.Account.Name = "Account";
            this.Account.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Account.SizeF = new System.Drawing.SizeF(301.7454F, 22.58331F);
            this.Account.StylePriority.UseTextAlignment = false;
            this.Account.Text = "Account";
            this.Account.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // RepH_Company
            // 
            this.RepH_Company.BorderColor = System.Drawing.Color.SteelBlue;
            this.RepH_Company.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.RepH_Company.BorderWidth = 1;
            this.RepH_Company.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepH_Company.ForeColor = System.Drawing.Color.Black;
            this.RepH_Company.LocationFloat = new DevExpress.Utils.PointFloat(2.000109F, 0F);
            this.RepH_Company.Name = "RepH_Company";
            this.RepH_Company.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.RepH_Company.SizeF = new System.Drawing.SizeF(372.238F, 26.58333F);
            this.RepH_Company.StylePriority.UseBorderColor = false;
            this.RepH_Company.StylePriority.UseBorders = false;
            this.RepH_Company.StylePriority.UseBorderWidth = false;
            this.RepH_Company.StylePriority.UseFont = false;
            this.RepH_Company.StylePriority.UseForeColor = false;
            this.RepH_Company.StylePriority.UsePadding = false;
            this.RepH_Company.StylePriority.UseTextAlignment = false;
            this.RepH_Company.Text = "Ranyal Textiles";
            this.RepH_Company.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // RepH_DocumentName
            // 
            this.RepH_DocumentName.BorderColor = System.Drawing.Color.SteelBlue;
            this.RepH_DocumentName.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.RepH_DocumentName.BorderWidth = 1;
            this.RepH_DocumentName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepH_DocumentName.LocationFloat = new DevExpress.Utils.PointFloat(536.076F, 0F);
            this.RepH_DocumentName.Name = "RepH_DocumentName";
            this.RepH_DocumentName.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.RepH_DocumentName.SizeF = new System.Drawing.SizeF(213.924F, 26.58333F);
            this.RepH_DocumentName.StylePriority.UseBorderColor = false;
            this.RepH_DocumentName.StylePriority.UseBorders = false;
            this.RepH_DocumentName.StylePriority.UseBorderWidth = false;
            this.RepH_DocumentName.StylePriority.UseFont = false;
            this.RepH_DocumentName.StylePriority.UsePadding = false;
            this.RepH_DocumentName.StylePriority.UseTextAlignment = false;
            this.RepH_DocumentName.Text = "Yarn Stock Ledger";
            this.RepH_DocumentName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel10.BorderWidth = 1;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(536.076F, 26.58334F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(40.03418F, 22.58333F);
            this.xrLabel10.StylePriority.UseBorderColor = false;
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseBorderWidth = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseForeColor = false;
            this.xrLabel10.StylePriority.UsePadding = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "From";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xr_FromDate
            // 
            this.xr_FromDate.BorderColor = System.Drawing.Color.SteelBlue;
            this.xr_FromDate.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xr_FromDate.BorderWidth = 1;
            this.xr_FromDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_FromDate.ForeColor = System.Drawing.Color.Black;
            this.xr_FromDate.LocationFloat = new DevExpress.Utils.PointFloat(576.1102F, 26.58334F);
            this.xr_FromDate.Name = "xr_FromDate";
            this.xr_FromDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xr_FromDate.SizeF = new System.Drawing.SizeF(77.09814F, 22.58333F);
            this.xr_FromDate.StylePriority.UseBorderColor = false;
            this.xr_FromDate.StylePriority.UseBorders = false;
            this.xr_FromDate.StylePriority.UseBorderWidth = false;
            this.xr_FromDate.StylePriority.UseFont = false;
            this.xr_FromDate.StylePriority.UseForeColor = false;
            this.xr_FromDate.StylePriority.UsePadding = false;
            this.xr_FromDate.StylePriority.UseTextAlignment = false;
            this.xr_FromDate.Text = "30/11/2013";
            this.xr_FromDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel12.BorderWidth = 1;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(653.2083F, 26.58331F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(16.7713F, 22.58333F);
            this.xrLabel12.StylePriority.UseBorderColor = false;
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseBorderWidth = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseForeColor = false;
            this.xrLabel12.StylePriority.UsePadding = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "To";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xr_ToDate
            // 
            this.xr_ToDate.BorderColor = System.Drawing.Color.SteelBlue;
            this.xr_ToDate.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xr_ToDate.BorderWidth = 1;
            this.xr_ToDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_ToDate.ForeColor = System.Drawing.Color.Black;
            this.xr_ToDate.LocationFloat = new DevExpress.Utils.PointFloat(672.4378F, 26.58332F);
            this.xr_ToDate.Name = "xr_ToDate";
            this.xr_ToDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xr_ToDate.SizeF = new System.Drawing.SizeF(77.56219F, 22.58333F);
            this.xr_ToDate.StylePriority.UseBorderColor = false;
            this.xr_ToDate.StylePriority.UseBorders = false;
            this.xr_ToDate.StylePriority.UseBorderWidth = false;
            this.xr_ToDate.StylePriority.UseFont = false;
            this.xr_ToDate.StylePriority.UseForeColor = false;
            this.xr_ToDate.StylePriority.UsePadding = false;
            this.xr_ToDate.StylePriority.UseTextAlignment = false;
            this.xr_ToDate.Text = "20/12/2013";
            this.xr_ToDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(2.000109F, 26.58334F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(70.49257F, 22.58331F);
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Account";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.BorderWidth = 1;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(324.7026F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(125.3255F, 14.66667F);
            this.xrLabel3.StylePriority.UseBorderColor = false;
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseBorderWidth = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseForeColor = false;
            this.xrLabel3.StylePriority.UsePadding = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Printing Date & Time";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Format = "{0:dddd, dd MMMM, yyyy h:mm tt}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(450.0281F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(265.6612F, 14.66666F);
            // 
            // xrLabel1
            // 
            this.xrLabel1.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.BorderWidth = 1;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(1.999982F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(53.13837F, 14.66667F);
            this.xrLabel1.StylePriority.UseBorderColor = false;
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseBorderWidth = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Page";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(55.1384F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(37.50002F, 14.66666F);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel16,
            this.xrLabel23,
            this.xrLabel19,
            this.xrLabel32,
            this.lbCustomer,
            this.xrLabel15,
            this.xrLabel17,
            this.xrLabel22,
            this.xrLabel20,
            this.xrLabel21,
            this.xrLabel24});
            this.PageHeader.HeightF = 20F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel2
            // 
            this.xrLabel2.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel2.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.ForeColor = System.Drawing.Color.White;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(1.999982F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(100.4927F, 17F);
            this.xrLabel2.StylePriority.UseBackColor = false;
            this.xrLabel2.StylePriority.UseForeColor = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Sub Type";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel16.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.ForeColor = System.Drawing.Color.White;
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(635.8464F, 0F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(56.57678F, 17F);
            this.xrLabel16.StylePriority.UseBackColor = false;
            this.xrLabel16.StylePriority.UseForeColor = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "Adjusted";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel23
            // 
            this.xrLabel23.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel23.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel23.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel23.ForeColor = System.Drawing.Color.White;
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(462.9386F, 0F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(56.57681F, 17F);
            this.xrLabel23.StylePriority.UseBackColor = false;
            this.xrLabel23.StylePriority.UseForeColor = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "Opening";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel19
            // 
            this.xrLabel19.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel19.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel19.ForeColor = System.Drawing.Color.White;
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(103.4926F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(82.48309F, 17F);
            this.xrLabel19.StylePriority.UseBackColor = false;
            this.xrLabel19.StylePriority.UseForeColor = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "Department";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel32
            // 
            this.xrLabel32.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel32.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel32.ForeColor = System.Drawing.Color.White;
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(187.9758F, 0F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(44.60421F, 17F);
            this.xrLabel32.StylePriority.UseBackColor = false;
            this.xrLabel32.StylePriority.UseForeColor = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "Type";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbCustomer
            // 
            this.lbCustomer.BackColor = System.Drawing.Color.SteelBlue;
            this.lbCustomer.BorderColor = System.Drawing.SystemColors.ControlText;
            this.lbCustomer.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lbCustomer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbCustomer.ForeColor = System.Drawing.Color.White;
            this.lbCustomer.LocationFloat = new DevExpress.Utils.PointFloat(233.58F, 0F);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCustomer.SizeF = new System.Drawing.SizeF(68.91107F, 17F);
            this.lbCustomer.StylePriority.UseBackColor = false;
            this.lbCustomer.StylePriority.UseForeColor = false;
            this.lbCustomer.StylePriority.UseTextAlignment = false;
            this.lbCustomer.Text = "Count";
            this.lbCustomer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel15
            // 
            this.xrLabel15.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel15.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.ForeColor = System.Drawing.Color.White;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(303.4911F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(49.16667F, 17F);
            this.xrLabel15.StylePriority.UseBackColor = false;
            this.xrLabel15.StylePriority.UseForeColor = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "Blend";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel17.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.ForeColor = System.Drawing.Color.White;
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(354.1885F, 0F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(52.16669F, 17F);
            this.xrLabel17.StylePriority.UseBackColor = false;
            this.xrLabel17.StylePriority.UseForeColor = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "Desc.";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel22
            // 
            this.xrLabel22.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel22.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel22.ForeColor = System.Drawing.Color.White;
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(407.3552F, 0F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(54.58328F, 17F);
            this.xrLabel22.StylePriority.UseBackColor = false;
            this.xrLabel22.StylePriority.UseForeColor = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Brand";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel20
            // 
            this.xrLabel20.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel20.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.ForeColor = System.Drawing.Color.White;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(520.5153F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(56.57678F, 17F);
            this.xrLabel20.StylePriority.UseBackColor = false;
            this.xrLabel20.StylePriority.UseForeColor = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Received";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel21
            // 
            this.xrLabel21.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel21.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.ForeColor = System.Drawing.Color.White;
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(578.0921F, 0F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(56.57678F, 17F);
            this.xrLabel21.StylePriority.UseBackColor = false;
            this.xrLabel21.StylePriority.UseForeColor = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "Issued";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel24
            // 
            this.xrLabel24.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel24.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel24.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel24.ForeColor = System.Drawing.Color.White;
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(693.4232F, 0F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(56.57678F, 17F);
            this.xrLabel24.StylePriority.UseBackColor = false;
            this.xrLabel24.StylePriority.UseForeColor = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "Balance";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // yarnContract1
            // 
            this.yarnContract1.DataSetName = "YarnContract";
            this.yarnContract1.EnforceConstraints = false;
            this.yarnContract1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qP_YarnStock_YarnStockDetailTableAdapter
            // 
            this.qP_YarnStock_YarnStockDetailTableAdapter.ClearBeforeFill = true;
            // 
            // Additionalinfo
            // 
            this.Additionalinfo.Expression = resources.GetString("Additionalinfo.Expression");
            this.Additionalinfo.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.Additionalinfo.Name = "Additionalinfo";
            // 
            // Additional_RICA
            // 
            this.Additional_RICA.Expression = "iif(IsNull([LbsIn]),iif(IsNull([LbsOut]),iif(IsNull([LbsAdj]),iif(IsNull([LbsCons" +
    "umed]),\'\',\'Consumed\'),\'Adjusted\'),\'Issued\'),\'Received\')";
            this.Additional_RICA.Name = "Additional_RICA";
            // 
            // Additional_Bags
            // 
            this.Additional_Bags.Expression = "iif(isnull([BagsIn]),0,[BagsIn]) + iif(isnull([Bagsout]),0,[Bagsout]) +  iif(isnu" +
    "ll([BagsAdj]),0,[BagsAdj])+  iif(isnull([BagsConsumed]),0,[BagsConsumed])";
            this.Additional_Bags.Name = "Additional_Bags";
            // 
            // Additional_Cones
            // 
            this.Additional_Cones.Expression = "iif(isnull([ConesIn]),0,[ConesIn]) + iif(isnull([Conesout]),0,[ConesOut]) +  iif(" +
    "isnull([ConesAdj]),0,[ConesAdj])+  iif(isnull([ConesConsumed]),0,[ConesConsumed]" +
    ")";
            this.Additional_Cones.Name = "Additional_Cones";
            // 
            // Additional_Lbs
            // 
            this.Additional_Lbs.Expression = "iif(isnull([LbsIn]),0,[LbsIn]) + iif(isnull([LbsOut]),0,[LbsOut]) +  iif(isnull([" +
    "LbsAdj]),0,[LbsAdj])+  iif(isnull([LbsConsumed]),0,[LbsConsumed])";
            this.Additional_Lbs.Name = "Additional_Lbs";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrLabel1,
            this.xrPageInfo1,
            this.xrLabel3});
            this.PageFooter.HeightF = 26F;
            this.PageFooter.Name = "PageFooter";
            // 
            // YarnStockLedger
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.PageFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.Additionalinfo,
            this.Additional_RICA,
            this.Additional_Bags,
            this.Additional_Cones,
            this.Additional_Lbs});
            this.DataAdapter = this.qP_YarnStock_YarnStockDetailTableAdapter;
            this.DataMember = "QP_YarnStock_YarnStockDetail";
            this.DataSource = this.yarnContract1;
            this.Margins = new System.Drawing.Printing.Margins(91, 0, 31, 41);
            this.SnapToGrid = false;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.yarnContract1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        public DevExpress.XtraReports.UI.XRLabel RepH_Company;
        public DevExpress.XtraReports.UI.XRLabel RepH_DocumentName;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        public DevExpress.XtraReports.UI.XRLabel xr_ToDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        public DevExpress.XtraReports.UI.XRLabel xr_FromDate;
        private DevExpress.XtraReports.UI.XRLabel YarnBrand;
        private DevExpress.XtraReports.UI.XRLabel YarnDesc;
        private DevExpress.XtraReports.UI.XRLabel YarnBlend;
        private DevExpress.XtraReports.UI.XRLabel YarnCount;
        private DevExpress.XtraReports.UI.XRLabel BagsType;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel32;
        private DevExpress.XtraReports.UI.XRLabel lbCustomer;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLabel LbsAdjusted;
        private DevExpress.XtraReports.UI.XRLabel LbsIssued;
        private DevExpress.XtraReports.UI.XRLabel LbsReceived;
        private DevExpress.XtraReports.UI.XRLabel LbsOpening;
        private DataTables.YarnContract yarnContract1;
        public DevExpress.XtraReports.UI.CalculatedField Additionalinfo;
        public DataTables.YarnContractTableAdapters.QP_YarnStock_YarnStockDetailTableAdapter qP_YarnStock_YarnStockDetailTableAdapter;
        private DevExpress.XtraReports.UI.CalculatedField Additional_RICA;
        private DevExpress.XtraReports.UI.CalculatedField Additional_Bags;
        private DevExpress.XtraReports.UI.CalculatedField Additional_Cones;
        private DevExpress.XtraReports.UI.CalculatedField Additional_Lbs;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel YarnPly;
        private DevExpress.XtraReports.UI.XRLabel PlySlash;
        private DevExpress.XtraReports.UI.XRLabel Dept;
        private DevExpress.XtraReports.UI.XRLabel YarnSubType;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel LbsBalance;
        public DevExpress.XtraReports.UI.XRLabel Account;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
    }
}
