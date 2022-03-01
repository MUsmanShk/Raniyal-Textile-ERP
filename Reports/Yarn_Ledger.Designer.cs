namespace MachineEyes.Reports
{
    partial class Yarn_Ledger
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
            this.Dated = new DevExpress.XtraReports.UI.XRLabel();
            this.DocumentNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.LbsAdjusted = new DevExpress.XtraReports.UI.XRLabel();
            this.LbsIssued = new DevExpress.XtraReports.UI.XRLabel();
            this.LbsReceived = new DevExpress.XtraReports.UI.XRLabel();
            this.InOutSubType = new DevExpress.XtraReports.UI.XRLabel();
            this.PlySlash = new DevExpress.XtraReports.UI.XRLabel();
            this.YarnPly = new DevExpress.XtraReports.UI.XRLabel();
            this.Dept = new DevExpress.XtraReports.UI.XRLabel();
            this.YarnCount = new DevExpress.XtraReports.UI.XRLabel();
            this.BagsType = new DevExpress.XtraReports.UI.XRLabel();
            this.YarnBlend = new DevExpress.XtraReports.UI.XRLabel();
            this.YarnBrand = new DevExpress.XtraReports.UI.XRLabel();
            this.YarnDesc = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.RepH_DocumentName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.Account = new DevExpress.XtraReports.UI.XRLabel();
            this.RepH_Company = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_ToDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_FromDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Dated,
            this.DocumentNumber,
            this.LbsAdjusted,
            this.LbsIssued,
            this.LbsReceived,
            this.InOutSubType,
            this.PlySlash,
            this.YarnPly,
            this.Dept,
            this.YarnCount,
            this.BagsType,
            this.YarnBlend,
            this.YarnBrand,
            this.YarnDesc});
            this.Detail.HeightF = 22F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Dated
            // 
            this.Dated.BorderColor = System.Drawing.SystemColors.ControlText;
            this.Dated.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Dated.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Dated", "{0:dd/MM/yyyy}")});
            this.Dated.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dated.LocationFloat = new DevExpress.Utils.PointFloat(81.49242F, 0F);
            this.Dated.Name = "Dated";
            this.Dated.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Dated.SizeF = new System.Drawing.SizeF(70.49243F, 17F);
            this.Dated.StylePriority.UseFont = false;
            this.Dated.StylePriority.UseTextAlignment = false;
            this.Dated.Text = "Dated";
            this.Dated.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DocumentNumber
            // 
            this.DocumentNumber.BorderColor = System.Drawing.SystemColors.ControlText;
            this.DocumentNumber.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DocumentNumber.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "GRNGIN")});
            this.DocumentNumber.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentNumber.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.DocumentNumber.Name = "DocumentNumber";
            this.DocumentNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DocumentNumber.SizeF = new System.Drawing.SizeF(79.49243F, 17F);
            this.DocumentNumber.StylePriority.UseFont = false;
            this.DocumentNumber.StylePriority.UseTextAlignment = false;
            this.DocumentNumber.Text = "xr_YarnBagsType";
            this.DocumentNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // LbsAdjusted
            // 
            this.LbsAdjusted.BorderColor = System.Drawing.SystemColors.ControlText;
            this.LbsAdjusted.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LbsAdjusted.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LbsAdj")});
            this.LbsAdjusted.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbsAdjusted.LocationFloat = new DevExpress.Utils.PointFloat(706.4232F, 0F);
            this.LbsAdjusted.Name = "LbsAdjusted";
            this.LbsAdjusted.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LbsAdjusted.SizeF = new System.Drawing.SizeF(44.57678F, 17F);
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
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LbsOut")});
            this.LbsIssued.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbsIssued.LocationFloat = new DevExpress.Utils.PointFloat(661.7285F, 0F);
            this.LbsIssued.Name = "LbsIssued";
            this.LbsIssued.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LbsIssued.SizeF = new System.Drawing.SizeF(44.57678F, 17F);
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
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LbsIn")});
            this.LbsReceived.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbsReceived.LocationFloat = new DevExpress.Utils.PointFloat(617.1518F, 0F);
            this.LbsReceived.Name = "LbsReceived";
            this.LbsReceived.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LbsReceived.SizeF = new System.Drawing.SizeF(44.57678F, 17F);
            this.LbsReceived.StylePriority.UseFont = false;
            this.LbsReceived.StylePriority.UseTextAlignment = false;
            this.LbsReceived.Text = "LbsReceived";
            this.LbsReceived.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // InOutSubType
            // 
            this.InOutSubType.BorderColor = System.Drawing.SystemColors.ControlText;
            this.InOutSubType.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.InOutSubType.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "InoutSubTypesName")});
            this.InOutSubType.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InOutSubType.LocationFloat = new DevExpress.Utils.PointFloat(153.9848F, 0F);
            this.InOutSubType.Name = "InOutSubType";
            this.InOutSubType.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.InOutSubType.SizeF = new System.Drawing.SizeF(100.4925F, 17F);
            this.InOutSubType.StylePriority.UseFont = false;
            this.InOutSubType.StylePriority.UseTextAlignment = false;
            this.InOutSubType.Text = "xr_YarnBagsType";
            this.InOutSubType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PlySlash
            // 
            this.PlySlash.BorderColor = System.Drawing.SystemColors.ControlText;
            this.PlySlash.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PlySlash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.PlySlash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.PlySlash.LocationFloat = new DevExpress.Utils.PointFloat(425.3976F, 0F);
            this.PlySlash.Name = "PlySlash";
            this.PlySlash.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PlySlash.SizeF = new System.Drawing.SizeF(7.166718F, 17F);
            this.PlySlash.StylePriority.UseTextAlignment = false;
            this.PlySlash.Text = "/";
            this.PlySlash.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // YarnPly
            // 
            this.YarnPly.BorderColor = System.Drawing.SystemColors.ControlText;
            this.YarnPly.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.YarnPly.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "YarnPly")});
            this.YarnPly.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnPly.LocationFloat = new DevExpress.Utils.PointFloat(434.1003F, 0F);
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
            this.Dept.LocationFloat = new DevExpress.Utils.PointFloat(256.4774F, 0F);
            this.Dept.Name = "Dept";
            this.Dept.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Dept.SizeF = new System.Drawing.SizeF(82.48314F, 17F);
            this.Dept.StylePriority.UseFont = false;
            this.Dept.StylePriority.UseTextAlignment = false;
            this.Dept.Text = "xr_YarnBagsType";
            this.Dept.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // YarnCount
            // 
            this.YarnCount.BorderColor = System.Drawing.SystemColors.ControlText;
            this.YarnCount.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.YarnCount.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "YarnCount")});
            this.YarnCount.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnCount.LocationFloat = new DevExpress.Utils.PointFloat(386.7934F, 0F);
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
            this.BagsType.LocationFloat = new DevExpress.Utils.PointFloat(341.1891F, 0F);
            this.BagsType.Name = "BagsType";
            this.BagsType.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BagsType.SizeF = new System.Drawing.SizeF(44.60421F, 17F);
            this.BagsType.StylePriority.UseFont = false;
            this.BagsType.StylePriority.UseTextAlignment = false;
            this.BagsType.Text = "BagsType";
            this.BagsType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // YarnBlend
            // 
            this.YarnBlend.BorderColor = System.Drawing.SystemColors.ControlText;
            this.YarnBlend.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.YarnBlend.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "YarnBlend")});
            this.YarnBlend.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnBlend.LocationFloat = new DevExpress.Utils.PointFloat(456.7045F, 0F);
            this.YarnBlend.Name = "YarnBlend";
            this.YarnBlend.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.YarnBlend.SizeF = new System.Drawing.SizeF(49.16667F, 17F);
            this.YarnBlend.StylePriority.UseFont = false;
            this.YarnBlend.StylePriority.UseTextAlignment = false;
            this.YarnBlend.Text = "YarnBlend";
            this.YarnBlend.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // YarnBrand
            // 
            this.YarnBrand.BorderColor = System.Drawing.SystemColors.ControlText;
            this.YarnBrand.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.YarnBrand.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "YarnBrand")});
            this.YarnBrand.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YarnBrand.LocationFloat = new DevExpress.Utils.PointFloat(560.5685F, 0F);
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
            this.YarnDesc.LocationFloat = new DevExpress.Utils.PointFloat(507.402F, 0F);
            this.YarnDesc.Name = "YarnDesc";
            this.YarnDesc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.YarnDesc.SizeF = new System.Drawing.SizeF(52.16669F, 17F);
            this.YarnDesc.StylePriority.UseFont = false;
            this.YarnDesc.StylePriority.UseTextAlignment = false;
            this.YarnDesc.Text = "YarnDesc";
            this.YarnDesc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 49F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.RepH_DocumentName,
            this.xrLabel10,
            this.Account,
            this.RepH_Company,
            this.xrLabel4,
            this.xr_ToDate,
            this.xr_FromDate,
            this.xrLabel12});
            this.ReportHeader.HeightF = 53F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // RepH_DocumentName
            // 
            this.RepH_DocumentName.BorderColor = System.Drawing.Color.SteelBlue;
            this.RepH_DocumentName.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.RepH_DocumentName.BorderWidth = 1;
            this.RepH_DocumentName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepH_DocumentName.LocationFloat = new DevExpress.Utils.PointFloat(527.825F, 0F);
            this.RepH_DocumentName.Name = "RepH_DocumentName";
            this.RepH_DocumentName.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.RepH_DocumentName.SizeF = new System.Drawing.SizeF(216.9241F, 15.125F);
            this.RepH_DocumentName.StylePriority.UseBorderColor = false;
            this.RepH_DocumentName.StylePriority.UseBorders = false;
            this.RepH_DocumentName.StylePriority.UseBorderWidth = false;
            this.RepH_DocumentName.StylePriority.UseFont = false;
            this.RepH_DocumentName.StylePriority.UsePadding = false;
            this.RepH_DocumentName.StylePriority.UseTextAlignment = false;
            this.RepH_DocumentName.Text = "Yarn Ledger";
            this.RepH_DocumentName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel10.BorderWidth = 1;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(528.8251F, 15.12499F);
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
            // Account
            // 
            this.Account.BorderColor = System.Drawing.SystemColors.ControlText;
            this.Account.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Account.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Account.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.Account.LocationFloat = new DevExpress.Utils.PointFloat(80.71207F, 26.58335F);
            this.Account.Name = "Account";
            this.Account.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Account.SizeF = new System.Drawing.SizeF(291.5259F, 22.58331F);
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
            this.RepH_Company.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
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
            // xrLabel4
            // 
            this.xrLabel4.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 26.58335F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(70.49257F, 22.58331F);
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Account";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xr_ToDate
            // 
            this.xr_ToDate.BorderColor = System.Drawing.Color.SteelBlue;
            this.xr_ToDate.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xr_ToDate.BorderWidth = 1;
            this.xr_ToDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_ToDate.ForeColor = System.Drawing.Color.Black;
            this.xr_ToDate.LocationFloat = new DevExpress.Utils.PointFloat(665.7286F, 15.12499F);
            this.xr_ToDate.Name = "xr_ToDate";
            this.xr_ToDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xr_ToDate.SizeF = new System.Drawing.SizeF(79.02057F, 22.58333F);
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
            // xr_FromDate
            // 
            this.xr_FromDate.BorderColor = System.Drawing.Color.SteelBlue;
            this.xr_FromDate.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xr_FromDate.BorderWidth = 1;
            this.xr_FromDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_FromDate.ForeColor = System.Drawing.Color.Black;
            this.xr_FromDate.LocationFloat = new DevExpress.Utils.PointFloat(568.8593F, 15.12499F);
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
            this.xrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel12.BorderWidth = 1;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(645.9573F, 15.12492F);
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
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel19,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel16,
            this.xrLabel20,
            this.xrLabel13,
            this.xrLabel11,
            this.xrLabel9});
            this.PageHeader.HeightF = 21F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel19
            // 
            this.xrLabel19.BackColor = System.Drawing.Color.White;
            this.xrLabel19.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel19.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel19.ForeColor = System.Drawing.Color.Gray;
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(706.4233F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(44.57672F, 16.99999F);
            this.xrLabel19.StylePriority.UseBackColor = false;
            this.xrLabel19.StylePriority.UseBorderColor = false;
            this.xrLabel19.StylePriority.UseBorders = false;
            this.xrLabel19.StylePriority.UseForeColor = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "Adj.";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel18
            // 
            this.xrLabel18.BackColor = System.Drawing.Color.White;
            this.xrLabel18.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel18.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel18.ForeColor = System.Drawing.Color.Gray;
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(661.7286F, 0F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(44.57672F, 16.99999F);
            this.xrLabel18.StylePriority.UseBackColor = false;
            this.xrLabel18.StylePriority.UseBorderColor = false;
            this.xrLabel18.StylePriority.UseBorders = false;
            this.xrLabel18.StylePriority.UseForeColor = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Issue";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.BackColor = System.Drawing.Color.White;
            this.xrLabel17.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel17.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.ForeColor = System.Drawing.Color.Gray;
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(617.1518F, 0F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(44.57678F, 16.99999F);
            this.xrLabel17.StylePriority.UseBackColor = false;
            this.xrLabel17.StylePriority.UseBorderColor = false;
            this.xrLabel17.StylePriority.UseBorders = false;
            this.xrLabel17.StylePriority.UseForeColor = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "Rec.";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.BackColor = System.Drawing.Color.White;
            this.xrLabel16.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel16.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.ForeColor = System.Drawing.Color.Gray;
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(256.4774F, 0F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(82.48312F, 16.99999F);
            this.xrLabel16.StylePriority.UseBackColor = false;
            this.xrLabel16.StylePriority.UseBorderColor = false;
            this.xrLabel16.StylePriority.UseBorders = false;
            this.xrLabel16.StylePriority.UseForeColor = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "Department";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel20
            // 
            this.xrLabel20.BackColor = System.Drawing.Color.White;
            this.xrLabel20.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel20.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.ForeColor = System.Drawing.Color.Gray;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(341.189F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(273.9628F, 16.99999F);
            this.xrLabel20.StylePriority.UseBackColor = false;
            this.xrLabel20.StylePriority.UseBorderColor = false;
            this.xrLabel20.StylePriority.UseBorders = false;
            this.xrLabel20.StylePriority.UseForeColor = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Yarn Specs";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel13
            // 
            this.xrLabel13.BackColor = System.Drawing.Color.White;
            this.xrLabel13.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.ForeColor = System.Drawing.Color.Gray;
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(153.9848F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(100.4925F, 16.99999F);
            this.xrLabel13.StylePriority.UseBackColor = false;
            this.xrLabel13.StylePriority.UseBorderColor = false;
            this.xrLabel13.StylePriority.UseBorders = false;
            this.xrLabel13.StylePriority.UseForeColor = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Sub Type";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.BackColor = System.Drawing.Color.White;
            this.xrLabel11.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.ForeColor = System.Drawing.Color.Gray;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(80.71205F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(70.49245F, 17F);
            this.xrLabel11.StylePriority.UseBackColor = false;
            this.xrLabel11.StylePriority.UseBorderColor = false;
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseForeColor = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Date";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.BackColor = System.Drawing.Color.White;
            this.xrLabel9.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.ForeColor = System.Drawing.Color.Gray;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(79.49244F, 17F);
            this.xrLabel9.StylePriority.UseBackColor = false;
            this.xrLabel9.StylePriority.UseBorderColor = false;
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseForeColor = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Document #";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel3,
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.PageFooter.HeightF = 24F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLabel1
            // 
            this.xrLabel1.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.BorderWidth = 1;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(7.676379F, 0F);
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
            // xrLabel3
            // 
            this.xrLabel3.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.BorderWidth = 1;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(330.379F, 0F);
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
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(455.7045F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(265.6612F, 14.66666F);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(60.81479F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(37.50002F, 14.66666F);
            // 
            // Yarn_Ledger
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(35, 41, 100, 49);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.SnapToGrid = false;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        public DevExpress.XtraReports.UI.XRLabel RepH_DocumentName;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        public DevExpress.XtraReports.UI.XRLabel Account;
        public DevExpress.XtraReports.UI.XRLabel RepH_Company;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        public DevExpress.XtraReports.UI.XRLabel xr_ToDate;
        public DevExpress.XtraReports.UI.XRLabel xr_FromDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel Dated;
        private DevExpress.XtraReports.UI.XRLabel DocumentNumber;
        private DevExpress.XtraReports.UI.XRLabel LbsAdjusted;
        private DevExpress.XtraReports.UI.XRLabel LbsIssued;
        private DevExpress.XtraReports.UI.XRLabel LbsReceived;
        private DevExpress.XtraReports.UI.XRLabel InOutSubType;
        private DevExpress.XtraReports.UI.XRLabel PlySlash;
        private DevExpress.XtraReports.UI.XRLabel YarnPly;
        private DevExpress.XtraReports.UI.XRLabel Dept;
        private DevExpress.XtraReports.UI.XRLabel YarnCount;
        private DevExpress.XtraReports.UI.XRLabel BagsType;
        private DevExpress.XtraReports.UI.XRLabel YarnBlend;
        private DevExpress.XtraReports.UI.XRLabel YarnBrand;
        private DevExpress.XtraReports.UI.XRLabel YarnDesc;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
    }
}
