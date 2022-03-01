namespace MachineEyes.Reports
{
    partial class Store_ReceiveRegister
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
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.Stock = new DevExpress.XtraReports.UI.XRLabel();
            this.Rates = new DevExpress.XtraReports.UI.XRLabel();
            this.Department = new DevExpress.XtraReports.UI.XRLabel();
            this.ItemAccountName = new DevExpress.XtraReports.UI.XRLabel();
            this.UOM = new DevExpress.XtraReports.UI.XRLabel();
            this.PRIndexNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.ReceivedQty = new DevExpress.XtraReports.UI.XRLabel();
            this.Remarks = new DevExpress.XtraReports.UI.XRLabel();
            this.LoomName = new DevExpress.XtraReports.UI.XRLabel();
            this.MC = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.MainRemarks = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.Dated = new DevExpress.XtraReports.UI.XRLabel();
            this.vBarcode = new DevExpress.XtraReports.UI.XRBarCode();
            this.RequisitionNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.PONumberforBarcode = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.PRNO = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.StockQty = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrUserID = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine7 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Stock,
            this.Rates,
            this.Department,
            this.ItemAccountName,
            this.UOM,
            this.PRIndexNumber,
            this.ReceivedQty,
            this.Remarks,
            this.LoomName,
            this.MC});
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Stock
            // 
            this.Stock.BorderColor = System.Drawing.SystemColors.ControlText;
            this.Stock.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Stock.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "StockQty", "{0:n2}")});
            this.Stock.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stock.ForeColor = System.Drawing.Color.Black;
            this.Stock.LocationFloat = new DevExpress.Utils.PointFloat(526.0417F, 0F);
            this.Stock.Name = "Stock";
            this.Stock.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Stock.SizeF = new System.Drawing.SizeF(49.04163F, 19.00003F);
            this.Stock.StylePriority.UseFont = false;
            this.Stock.StylePriority.UseForeColor = false;
            this.Stock.StylePriority.UseTextAlignment = false;
            this.Stock.Text = "IssuedQty";
            this.Stock.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Rates
            // 
            this.Rates.BorderColor = System.Drawing.SystemColors.ControlText;
            this.Rates.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Rates.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PlusRate", "{0:n2}")});
            this.Rates.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rates.ForeColor = System.Drawing.Color.Black;
            this.Rates.LocationFloat = new DevExpress.Utils.PointFloat(380.501F, 0F);
            this.Rates.Name = "Rates";
            this.Rates.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Rates.SizeF = new System.Drawing.SizeF(48.79398F, 19.00003F);
            this.Rates.StylePriority.UseFont = false;
            this.Rates.StylePriority.UseForeColor = false;
            this.Rates.StylePriority.UseTextAlignment = false;
            this.Rates.Text = "IssuedQty";
            this.Rates.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Department
            // 
            this.Department.BorderColor = System.Drawing.SystemColors.ControlText;
            this.Department.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Department.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DepartmentName")});
            this.Department.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Department.ForeColor = System.Drawing.Color.Black;
            this.Department.LocationFloat = new DevExpress.Utils.PointFloat(193.7851F, 0F);
            this.Department.Name = "Department";
            this.Department.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Department.SizeF = new System.Drawing.SizeF(82.63977F, 19.00003F);
            this.Department.StylePriority.UseFont = false;
            this.Department.StylePriority.UseForeColor = false;
            this.Department.StylePriority.UseTextAlignment = false;
            this.Department.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ItemAccountName
            // 
            this.ItemAccountName.BorderColor = System.Drawing.SystemColors.ControlText;
            this.ItemAccountName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ItemAccountName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ItemAccountName")});
            this.ItemAccountName.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemAccountName.ForeColor = System.Drawing.Color.Black;
            this.ItemAccountName.LocationFloat = new DevExpress.Utils.PointFloat(23.13035F, 0F);
            this.ItemAccountName.Name = "ItemAccountName";
            this.ItemAccountName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ItemAccountName.SizeF = new System.Drawing.SizeF(167.6547F, 19.00003F);
            this.ItemAccountName.StylePriority.UseFont = false;
            this.ItemAccountName.StylePriority.UseForeColor = false;
            this.ItemAccountName.StylePriority.UseTextAlignment = false;
            this.ItemAccountName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // UOM
            // 
            this.UOM.BorderColor = System.Drawing.SystemColors.ControlText;
            this.UOM.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.UOM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "UOM")});
            this.UOM.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UOM.ForeColor = System.Drawing.Color.Black;
            this.UOM.LocationFloat = new DevExpress.Utils.PointFloat(490.9138F, 0F);
            this.UOM.Name = "UOM";
            this.UOM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.UOM.SizeF = new System.Drawing.SizeF(33.12793F, 19.00003F);
            this.UOM.StylePriority.UseFont = false;
            this.UOM.StylePriority.UseForeColor = false;
            this.UOM.StylePriority.UseTextAlignment = false;
            this.UOM.Text = "LPR";
            this.UOM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PRIndexNumber
            // 
            this.PRIndexNumber.BorderColor = System.Drawing.SystemColors.ControlText;
            this.PRIndexNumber.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PRIndexNumber.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRIndexNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.PRIndexNumber.LocationFloat = new DevExpress.Utils.PointFloat(1.041667F, 0F);
            this.PRIndexNumber.Name = "PRIndexNumber";
            this.PRIndexNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PRIndexNumber.SizeF = new System.Drawing.SizeF(20.0887F, 19.00003F);
            this.PRIndexNumber.StylePriority.UseFont = false;
            this.PRIndexNumber.StylePriority.UseTextAlignment = false;
            this.PRIndexNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.PRIndexNumber.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.PRIndexNumber_BeforePrint);
            // 
            // ReceivedQty
            // 
            this.ReceivedQty.BorderColor = System.Drawing.SystemColors.ControlText;
            this.ReceivedQty.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ReceivedQty.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PlusQty", "{0:n2}")});
            this.ReceivedQty.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceivedQty.ForeColor = System.Drawing.Color.Black;
            this.ReceivedQty.LocationFloat = new DevExpress.Utils.PointFloat(431.2997F, 0F);
            this.ReceivedQty.Name = "ReceivedQty";
            this.ReceivedQty.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ReceivedQty.SizeF = new System.Drawing.SizeF(58.79407F, 19.00003F);
            this.ReceivedQty.StylePriority.UseFont = false;
            this.ReceivedQty.StylePriority.UseForeColor = false;
            this.ReceivedQty.StylePriority.UseTextAlignment = false;
            this.ReceivedQty.Text = "ReceivedQty";
            this.ReceivedQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Remarks
            // 
            this.Remarks.BorderColor = System.Drawing.SystemColors.ControlText;
            this.Remarks.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Remarks.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Remarks")});
            this.Remarks.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remarks.ForeColor = System.Drawing.Color.Black;
            this.Remarks.LocationFloat = new DevExpress.Utils.PointFloat(577.0833F, 0F);
            this.Remarks.Name = "Remarks";
            this.Remarks.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Remarks.SizeF = new System.Drawing.SizeF(95.46075F, 19.00003F);
            this.Remarks.StylePriority.UseFont = false;
            this.Remarks.StylePriority.UseForeColor = false;
            this.Remarks.StylePriority.UseTextAlignment = false;
            this.Remarks.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // LoomName
            // 
            this.LoomName.BorderColor = System.Drawing.SystemColors.ControlText;
            this.LoomName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LoomName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LoomName")});
            this.LoomName.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoomName.ForeColor = System.Drawing.Color.Black;
            this.LoomName.LocationFloat = new DevExpress.Utils.PointFloat(279.1532F, 0F);
            this.LoomName.Name = "LoomName";
            this.LoomName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LoomName.SizeF = new System.Drawing.SizeF(56.5564F, 19.00003F);
            this.LoomName.StylePriority.UseFont = false;
            this.LoomName.StylePriority.UseForeColor = false;
            this.LoomName.StylePriority.UseTextAlignment = false;
            this.LoomName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // MC
            // 
            this.MC.BorderColor = System.Drawing.SystemColors.ControlText;
            this.MC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.MC.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MC")});
            this.MC.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MC.ForeColor = System.Drawing.Color.Black;
            this.MC.LocationFloat = new DevExpress.Utils.PointFloat(337.7097F, 0F);
            this.MC.Name = "MC";
            this.MC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.MC.SizeF = new System.Drawing.SizeF(41.79135F, 19.00003F);
            this.MC.StylePriority.UseFont = false;
            this.MC.StylePriority.UseForeColor = false;
            this.MC.StylePriority.UseTextAlignment = false;
            this.MC.Text = "MC";
            this.MC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 49F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 38F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8,
            this.MainRemarks,
            this.xrLabel15,
            this.xrLabel22,
            this.Dated,
            this.vBarcode,
            this.RequisitionNumber,
            this.PONumberforBarcode,
            this.xrLabel1,
            this.xrLabel2,
            this.PRNO});
            this.ReportHeader.HeightF = 160F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel8
            // 
            this.xrLabel8.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel8.BorderWidth = 1;
            this.xrLabel8.CanGrow = false;
            this.xrLabel8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.ForeColor = System.Drawing.Color.Blue;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(525.3127F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(147.2313F, 27.28999F);
            this.xrLabel8.StylePriority.UseBorderColor = false;
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseBorderWidth = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseForeColor = false;
            this.xrLabel8.StylePriority.UsePadding = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Store Get Back Register";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // MainRemarks
            // 
            this.MainRemarks.BorderColor = System.Drawing.Color.Silver;
            this.MainRemarks.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.MainRemarks.BorderWidth = 1;
            this.MainRemarks.CanGrow = false;
            this.MainRemarks.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainRemarks.ForeColor = System.Drawing.Color.Black;
            this.MainRemarks.LocationFloat = new DevExpress.Utils.PointFloat(85.41666F, 120.4166F);
            this.MainRemarks.Name = "MainRemarks";
            this.MainRemarks.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.MainRemarks.SizeF = new System.Drawing.SizeF(587.1276F, 35.83334F);
            this.MainRemarks.StylePriority.UseBorderColor = false;
            this.MainRemarks.StylePriority.UseBorders = false;
            this.MainRemarks.StylePriority.UseBorderWidth = false;
            this.MainRemarks.StylePriority.UseFont = false;
            this.MainRemarks.StylePriority.UseForeColor = false;
            this.MainRemarks.StylePriority.UsePadding = false;
            this.MainRemarks.StylePriority.UseTextAlignment = false;
            this.MainRemarks.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.BackColor = System.Drawing.Color.White;
            this.xrLabel15.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel15.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel15.BorderWidth = 1;
            this.xrLabel15.CanGrow = false;
            this.xrLabel15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.ForeColor = System.Drawing.Color.Black;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(0F, 53.91661F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(74.80647F, 18.41668F);
            this.xrLabel15.StylePriority.UseBackColor = false;
            this.xrLabel15.StylePriority.UseBorderColor = false;
            this.xrLabel15.StylePriority.UseBorders = false;
            this.xrLabel15.StylePriority.UseBorderWidth = false;
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseForeColor = false;
            this.xrLabel15.StylePriority.UsePadding = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "Receive Note #";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel22
            // 
            this.xrLabel22.BackColor = System.Drawing.Color.White;
            this.xrLabel22.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel22.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel22.BorderWidth = 1;
            this.xrLabel22.CanGrow = false;
            this.xrLabel22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.ForeColor = System.Drawing.Color.Black;
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(0F, 74.33328F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(74.80645F, 18.41666F);
            this.xrLabel22.StylePriority.UseBackColor = false;
            this.xrLabel22.StylePriority.UseBorderColor = false;
            this.xrLabel22.StylePriority.UseBorders = false;
            this.xrLabel22.StylePriority.UseBorderWidth = false;
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseForeColor = false;
            this.xrLabel22.StylePriority.UsePadding = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Dated";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Dated
            // 
            this.Dated.BorderColor = System.Drawing.Color.Silver;
            this.Dated.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Dated.BorderWidth = 1;
            this.Dated.CanGrow = false;
            this.Dated.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dated.ForeColor = System.Drawing.Color.Black;
            this.Dated.LocationFloat = new DevExpress.Utils.PointFloat(85.41666F, 74.33328F);
            this.Dated.Name = "Dated";
            this.Dated.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.Dated.SizeF = new System.Drawing.SizeF(148.9509F, 18.41667F);
            this.Dated.StylePriority.UseBorderColor = false;
            this.Dated.StylePriority.UseBorders = false;
            this.Dated.StylePriority.UseBorderWidth = false;
            this.Dated.StylePriority.UseFont = false;
            this.Dated.StylePriority.UseForeColor = false;
            this.Dated.StylePriority.UsePadding = false;
            this.Dated.StylePriority.UseTextAlignment = false;
            this.Dated.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // vBarcode
            // 
            this.vBarcode.BorderColor = System.Drawing.Color.Silver;
            this.vBarcode.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.vBarcode.BorderWidth = 1;
            this.vBarcode.LocationFloat = new DevExpress.Utils.PointFloat(138.5417F, 0F);
            this.vBarcode.Name = "vBarcode";
            this.vBarcode.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.vBarcode.ShowText = false;
            this.vBarcode.SizeF = new System.Drawing.SizeF(376.5051F, 27.28999F);
            this.vBarcode.StylePriority.UseBorderColor = false;
            this.vBarcode.StylePriority.UseBorders = false;
            this.vBarcode.StylePriority.UseBorderWidth = false;
            this.vBarcode.StylePriority.UseTextAlignment = false;
            this.vBarcode.Symbology = code128Generator1;
            this.vBarcode.Text = "0010000100013";
            this.vBarcode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // RequisitionNumber
            // 
            this.RequisitionNumber.BorderColor = System.Drawing.Color.Silver;
            this.RequisitionNumber.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.RequisitionNumber.BorderWidth = 1;
            this.RequisitionNumber.CanGrow = false;
            this.RequisitionNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequisitionNumber.ForeColor = System.Drawing.Color.Black;
            this.RequisitionNumber.LocationFloat = new DevExpress.Utils.PointFloat(85.41666F, 97.99995F);
            this.RequisitionNumber.Name = "RequisitionNumber";
            this.RequisitionNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.RequisitionNumber.SizeF = new System.Drawing.SizeF(148.9509F, 18.41667F);
            this.RequisitionNumber.StylePriority.UseBorderColor = false;
            this.RequisitionNumber.StylePriority.UseBorders = false;
            this.RequisitionNumber.StylePriority.UseBorderWidth = false;
            this.RequisitionNumber.StylePriority.UseFont = false;
            this.RequisitionNumber.StylePriority.UseForeColor = false;
            this.RequisitionNumber.StylePriority.UsePadding = false;
            this.RequisitionNumber.StylePriority.UseTextAlignment = false;
            this.RequisitionNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PONumberforBarcode
            // 
            this.PONumberforBarcode.BorderColor = System.Drawing.Color.Silver;
            this.PONumberforBarcode.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PONumberforBarcode.BorderWidth = 1;
            this.PONumberforBarcode.CanGrow = false;
            this.PONumberforBarcode.Font = new System.Drawing.Font("Digital-7", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PONumberforBarcode.ForeColor = System.Drawing.Color.Black;
            this.PONumberforBarcode.LocationFloat = new DevExpress.Utils.PointFloat(1.041667F, 0F);
            this.PONumberforBarcode.Name = "PONumberforBarcode";
            this.PONumberforBarcode.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.PONumberforBarcode.SizeF = new System.Drawing.SizeF(135.8464F, 27.28999F);
            this.PONumberforBarcode.StylePriority.UseBorderColor = false;
            this.PONumberforBarcode.StylePriority.UseBorders = false;
            this.PONumberforBarcode.StylePriority.UseBorderWidth = false;
            this.PONumberforBarcode.StylePriority.UseFont = false;
            this.PONumberforBarcode.StylePriority.UseForeColor = false;
            this.PONumberforBarcode.StylePriority.UsePadding = false;
            this.PONumberforBarcode.StylePriority.UseTextAlignment = false;
            this.PONumberforBarcode.Text = "0010000100013";
            this.PONumberforBarcode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.White;
            this.xrLabel1.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.BorderWidth = 1;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(1.041667F, 97.99995F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(73.76479F, 18.41668F);
            this.xrLabel1.StylePriority.UseBackColor = false;
            this.xrLabel1.StylePriority.UseBorderColor = false;
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseBorderWidth = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Issuance #";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.BackColor = System.Drawing.Color.White;
            this.xrLabel2.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.BorderWidth = 1;
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(1.041667F, 120.4166F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(73.76479F, 35.83333F);
            this.xrLabel2.StylePriority.UseBackColor = false;
            this.xrLabel2.StylePriority.UseBorderColor = false;
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseBorderWidth = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseForeColor = false;
            this.xrLabel2.StylePriority.UsePadding = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Remarks";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PRNO
            // 
            this.PRNO.BorderColor = System.Drawing.Color.Silver;
            this.PRNO.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PRNO.BorderWidth = 1;
            this.PRNO.CanGrow = false;
            this.PRNO.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRNO.ForeColor = System.Drawing.Color.Black;
            this.PRNO.LocationFloat = new DevExpress.Utils.PointFloat(85.41666F, 53.91661F);
            this.PRNO.Name = "PRNO";
            this.PRNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.PRNO.SizeF = new System.Drawing.SizeF(148.9509F, 18.41667F);
            this.PRNO.StylePriority.UseBorderColor = false;
            this.PRNO.StylePriority.UseBorders = false;
            this.PRNO.StylePriority.UseBorderWidth = false;
            this.PRNO.StylePriority.UseFont = false;
            this.PRNO.StylePriority.UseForeColor = false;
            this.PRNO.StylePriority.UsePadding = false;
            this.PRNO.StylePriority.UseTextAlignment = false;
            this.PRNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.StockQty,
            this.xrLabel11,
            this.xrLabel7,
            this.xrLabel26,
            this.xrLabel9,
            this.xrLabel29,
            this.xrLabel12,
            this.xrLabel5,
            this.xrLabel24,
            this.xrLabel10});
            this.PageHeader.HeightF = 20F;
            this.PageHeader.Name = "PageHeader";
            // 
            // StockQty
            // 
            this.StockQty.BackColor = System.Drawing.Color.White;
            this.StockQty.BorderColor = System.Drawing.Color.Silver;
            this.StockQty.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.StockQty.CanGrow = false;
            this.StockQty.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockQty.ForeColor = System.Drawing.Color.Black;
            this.StockQty.LocationFloat = new DevExpress.Utils.PointFloat(526.0417F, 0F);
            this.StockQty.Name = "StockQty";
            this.StockQty.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.StockQty.SizeF = new System.Drawing.SizeF(49.04163F, 18.41667F);
            this.StockQty.StylePriority.UseBackColor = false;
            this.StockQty.StylePriority.UseBorderColor = false;
            this.StockQty.StylePriority.UseBorders = false;
            this.StockQty.StylePriority.UseFont = false;
            this.StockQty.StylePriority.UseForeColor = false;
            this.StockQty.StylePriority.UsePadding = false;
            this.StockQty.StylePriority.UseTextAlignment = false;
            this.StockQty.Text = "Stock";
            this.StockQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.BackColor = System.Drawing.Color.White;
            this.xrLabel11.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel11.CanGrow = false;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(380.501F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(48.79404F, 18.41667F);
            this.xrLabel11.StylePriority.UseBackColor = false;
            this.xrLabel11.StylePriority.UseBorderColor = false;
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseForeColor = false;
            this.xrLabel11.StylePriority.UsePadding = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Rates";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.BackColor = System.Drawing.Color.White;
            this.xrLabel7.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel7.CanGrow = false;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(193.785F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(83.36816F, 18.41667F);
            this.xrLabel7.StylePriority.UseBackColor = false;
            this.xrLabel7.StylePriority.UseBorderColor = false;
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseForeColor = false;
            this.xrLabel7.StylePriority.UsePadding = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Department";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel26
            // 
            this.xrLabel26.BackColor = System.Drawing.Color.White;
            this.xrLabel26.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel26.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel26.CanGrow = false;
            this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel26.ForeColor = System.Drawing.Color.Black;
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(279.1532F, 0F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(56.5564F, 18.41667F);
            this.xrLabel26.StylePriority.UseBackColor = false;
            this.xrLabel26.StylePriority.UseBorderColor = false;
            this.xrLabel26.StylePriority.UseBorders = false;
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseForeColor = false;
            this.xrLabel26.StylePriority.UsePadding = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "Loom #";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.BackColor = System.Drawing.Color.White;
            this.xrLabel9.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel9.CanGrow = false;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(577.0833F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(95.46075F, 18.41667F);
            this.xrLabel9.StylePriority.UseBackColor = false;
            this.xrLabel9.StylePriority.UseBorderColor = false;
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseForeColor = false;
            this.xrLabel9.StylePriority.UsePadding = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Remarks";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel29
            // 
            this.xrLabel29.BackColor = System.Drawing.Color.White;
            this.xrLabel29.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel29.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel29.CanGrow = false;
            this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.ForeColor = System.Drawing.Color.Black;
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(23.13035F, 0F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(167.6547F, 18.41667F);
            this.xrLabel29.StylePriority.UseBackColor = false;
            this.xrLabel29.StylePriority.UseBorderColor = false;
            this.xrLabel29.StylePriority.UseBorders = false;
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseForeColor = false;
            this.xrLabel29.StylePriority.UsePadding = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "Item";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.BackColor = System.Drawing.Color.White;
            this.xrLabel12.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel12.CanGrow = false;
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(490.9138F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(33.1279F, 18.41667F);
            this.xrLabel12.StylePriority.UseBackColor = false;
            this.xrLabel12.StylePriority.UseBorderColor = false;
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseForeColor = false;
            this.xrLabel12.StylePriority.UsePadding = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "UOM";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.BackColor = System.Drawing.Color.White;
            this.xrLabel5.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel5.CanGrow = false;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(21.13037F, 18.41667F);
            this.xrLabel5.StylePriority.UseBackColor = false;
            this.xrLabel5.StylePriority.UseBorderColor = false;
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseForeColor = false;
            this.xrLabel5.StylePriority.UsePadding = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "#";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel24
            // 
            this.xrLabel24.BackColor = System.Drawing.Color.White;
            this.xrLabel24.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel24.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel24.CanGrow = false;
            this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.ForeColor = System.Drawing.Color.Black;
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(337.7096F, 0F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(41.79144F, 18.41667F);
            this.xrLabel24.StylePriority.UseBackColor = false;
            this.xrLabel24.StylePriority.UseBorderColor = false;
            this.xrLabel24.StylePriority.UseBorders = false;
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UseForeColor = false;
            this.xrLabel24.StylePriority.UsePadding = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "Origin";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.BackColor = System.Drawing.Color.White;
            this.xrLabel10.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel10.CanGrow = false;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(431.2998F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(58.79404F, 18.41667F);
            this.xrLabel10.StylePriority.UseBackColor = false;
            this.xrLabel10.StylePriority.UseBorderColor = false;
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseForeColor = false;
            this.xrLabel10.StylePriority.UsePadding = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Issued Qty";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel17,
            this.xrPageInfo1,
            this.xrLabel4,
            this.xrPageInfo2,
            this.xrUserID,
            this.xrLabel14,
            this.xrLine5,
            this.xrLabel18,
            this.xrLine4,
            this.xrLabel20,
            this.xrLabel25,
            this.xrLine7,
            this.xrLabel46,
            this.xrLine6});
            this.PageFooter.HeightF = 109F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLabel17
            // 
            this.xrLabel17.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel17.BorderWidth = 1;
            this.xrLabel17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(2.083397F, 85.95835F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(33.34671F, 18.66667F);
            this.xrLabel17.StylePriority.UseBorderColor = false;
            this.xrLabel17.StylePriority.UseBorders = false;
            this.xrLabel17.StylePriority.UseBorderWidth = false;
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseForeColor = false;
            this.xrLabel17.StylePriority.UsePadding = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "Page";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(35.43008F, 85.95835F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(28.12503F, 18.66667F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseForeColor = false;
            this.xrPageInfo1.StylePriority.UsePadding = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel4.BorderWidth = 1;
            this.xrLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(344.347F, 85.95835F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(122.2005F, 18.66667F);
            this.xrLabel4.StylePriority.UseBorderColor = false;
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseBorderWidth = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseForeColor = false;
            this.xrLabel4.StylePriority.UsePadding = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Printing Date & Time";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.xrPageInfo2.Format = "{0:dddd, dd MMMM, yyyy h:mm tt}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(466.5475F, 85.95835F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(204.161F, 18.66667F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.StylePriority.UseForeColor = false;
            this.xrPageInfo2.StylePriority.UsePadding = false;
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrUserID
            // 
            this.xrUserID.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrUserID.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrUserID.BorderWidth = 1;
            this.xrUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrUserID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.xrUserID.LocationFloat = new DevExpress.Utils.PointFloat(115.8052F, 85.95835F);
            this.xrUserID.Name = "xrUserID";
            this.xrUserID.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrUserID.SizeF = new System.Drawing.SizeF(136.52F, 18.66667F);
            this.xrUserID.StylePriority.UseBorderColor = false;
            this.xrUserID.StylePriority.UseBorders = false;
            this.xrUserID.StylePriority.UseBorderWidth = false;
            this.xrUserID.StylePriority.UseFont = false;
            this.xrUserID.StylePriority.UseForeColor = false;
            this.xrUserID.StylePriority.UsePadding = false;
            this.xrUserID.StylePriority.UseTextAlignment = false;
            this.xrUserID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel14.BorderWidth = 1;
            this.xrLabel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(84.00075F, 85.95835F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(31.33875F, 18.66667F);
            this.xrLabel14.StylePriority.UseBorderColor = false;
            this.xrLabel14.StylePriority.UseBorders = false;
            this.xrLabel14.StylePriority.UseBorderWidth = false;
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseForeColor = false;
            this.xrLabel14.StylePriority.UsePadding = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "UID";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine5
            // 
            this.xrLine5.BorderWidth = 1;
            this.xrLine5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLine5.LineWidth = 3;
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(161.2339F, 53.50019F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(115.1909F, 3F);
            this.xrLine5.StylePriority.UseBorderWidth = false;
            this.xrLine5.StylePriority.UseForeColor = false;
            // 
            // xrLabel18
            // 
            this.xrLabel18.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel18.ForeColor = System.Drawing.Color.Black;
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(555.5176F, 57.49996F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(115.9194F, 17F);
            this.xrLabel18.StylePriority.UseBorders = false;
            this.xrLabel18.StylePriority.UseForeColor = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Received by";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine4
            // 
            this.xrLine4.BorderWidth = 1;
            this.xrLine4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLine4.LineWidth = 3;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(1.533985F, 53.50006F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(115.1909F, 3F);
            this.xrLine4.StylePriority.UseBorderWidth = false;
            this.xrLine4.StylePriority.UseForeColor = false;
            // 
            // xrLabel20
            // 
            this.xrLabel20.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.ForeColor = System.Drawing.Color.Black;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(161.2339F, 57.49996F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(115.9193F, 17F);
            this.xrLabel20.StylePriority.UseBorders = false;
            this.xrLabel20.StylePriority.UseForeColor = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Store Keeper";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel25
            // 
            this.xrLabel25.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel25.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel25.ForeColor = System.Drawing.Color.Black;
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(355.3644F, 57.49996F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(138.6745F, 17F);
            this.xrLabel25.StylePriority.UseBorders = false;
            this.xrLabel25.StylePriority.UseForeColor = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "Approved by";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine7
            // 
            this.xrLine7.BorderWidth = 1;
            this.xrLine7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLine7.LineWidth = 3;
            this.xrLine7.LocationFloat = new DevExpress.Utils.PointFloat(555.5176F, 53.50019F);
            this.xrLine7.Name = "xrLine7";
            this.xrLine7.SizeF = new System.Drawing.SizeF(115.1909F, 3F);
            this.xrLine7.StylePriority.UseBorderWidth = false;
            this.xrLine7.StylePriority.UseForeColor = false;
            // 
            // xrLabel46
            // 
            this.xrLabel46.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel46.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel46.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel46.ForeColor = System.Drawing.Color.Black;
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(1.533985F, 57.49996F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(115.9193F, 17F);
            this.xrLabel46.StylePriority.UseBorders = false;
            this.xrLabel46.StylePriority.UseForeColor = false;
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            this.xrLabel46.Text = "Prepared by";
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine6
            // 
            this.xrLine6.BorderWidth = 1;
            this.xrLine6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLine6.LineWidth = 3;
            this.xrLine6.LocationFloat = new DevExpress.Utils.PointFloat(356.9028F, 53.50019F);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.SizeF = new System.Drawing.SizeF(135.191F, 3F);
            this.xrLine6.StylePriority.UseBorderWidth = false;
            this.xrLine6.StylePriority.UseForeColor = false;
            // 
            // Store_ReceiveRegister
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(100, 52, 49, 38);
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
        public DevExpress.XtraReports.UI.XRLabel xrLabel8;
        public DevExpress.XtraReports.UI.XRLabel MainRemarks;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        public DevExpress.XtraReports.UI.XRLabel Dated;
        public DevExpress.XtraReports.UI.XRBarCode vBarcode;
        public DevExpress.XtraReports.UI.XRLabel RequisitionNumber;
        public DevExpress.XtraReports.UI.XRLabel PONumberforBarcode;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        public DevExpress.XtraReports.UI.XRLabel PRNO;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel26;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel29;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel ItemAccountName;
        private DevExpress.XtraReports.UI.XRLabel UOM;
        private DevExpress.XtraReports.UI.XRLabel PRIndexNumber;
        private DevExpress.XtraReports.UI.XRLabel ReceivedQty;
        private DevExpress.XtraReports.UI.XRLabel Remarks;
        private DevExpress.XtraReports.UI.XRLabel LoomName;
        private DevExpress.XtraReports.UI.XRLabel MC;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLine xrLine5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLine xrLine4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel25;
        private DevExpress.XtraReports.UI.XRLine xrLine7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel46;
        private DevExpress.XtraReports.UI.XRLine xrLine6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRLabel xrUserID;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel Department;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel Rates;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel Stock;
        private DevExpress.XtraReports.UI.XRLabel StockQty;
    }
}
