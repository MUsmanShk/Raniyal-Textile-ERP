namespace MachineEyes.Reports
{
    partial class Accounts_Voucher_MDC
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
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xr_Amount = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.RefChequeNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.RefInvoiceNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.RefDeliveryChallanNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_Particulars = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_AccountID_V = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_AccountName_V = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.vDate = new DevExpress.XtraReports.UI.XRLabel();
            this.VoucherType = new DevExpress.XtraReports.UI.XRLabel();
            this.vCompany = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.vDocumentNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.FinancialYear = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xr_TotalAmountWords = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_TotalAmount = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrUserID = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.vBarcode = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine7 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xr_Amount,
            this.xrLabel28,
            this.RefChequeNumber,
            this.RefInvoiceNumber,
            this.RefDeliveryChallanNumber,
            this.xrLabel26,
            this.xrLabel32,
            this.xrLabel24,
            this.xrLabel3,
            this.xr_Particulars,
            this.xr_AccountID_V,
            this.xr_AccountName_V});
            this.Detail.HeightF = 82.00002F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xr_Amount
            // 
            this.xr_Amount.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xr_Amount.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xr_Amount.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Accounts_Vouchers.VDebitAmount", "{0:#,#}")});
            this.xr_Amount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_Amount.ForeColor = System.Drawing.Color.Black;
            this.xr_Amount.LocationFloat = new DevExpress.Utils.PointFloat(531.6834F, 0F);
            this.xr_Amount.Name = "xr_Amount";
            this.xr_Amount.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_Amount.SizeF = new System.Drawing.SizeF(83.79407F, 17F);
            this.xr_Amount.StylePriority.UseFont = false;
            this.xr_Amount.StylePriority.UseForeColor = false;
            this.xr_Amount.StylePriority.UseTextAlignment = false;
            this.xr_Amount.Text = "xr_Amount";
            this.xr_Amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel28
            // 
            this.xrLabel28.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Accounts_Vouchers.VCreditAmount", "{0:#,#}")});
            this.xrLabel28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel28.ForeColor = System.Drawing.Color.Black;
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(617.4775F, 0F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(83.79401F, 17F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseForeColor = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "xrLabel28";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // RefChequeNumber
            // 
            this.RefChequeNumber.BorderColor = System.Drawing.SystemColors.ControlText;
            this.RefChequeNumber.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.RefChequeNumber.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "VRefChequeNumber")});
            this.RefChequeNumber.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefChequeNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.RefChequeNumber.LocationFloat = new DevExpress.Utils.PointFloat(67.20833F, 18.99999F);
            this.RefChequeNumber.Name = "RefChequeNumber";
            this.RefChequeNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.RefChequeNumber.SizeF = new System.Drawing.SizeF(112.7648F, 17F);
            this.RefChequeNumber.StylePriority.UseFont = false;
            this.RefChequeNumber.StylePriority.UseTextAlignment = false;
            this.RefChequeNumber.Text = "xrLabel28";
            this.RefChequeNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // RefInvoiceNumber
            // 
            this.RefInvoiceNumber.BorderColor = System.Drawing.SystemColors.ControlText;
            this.RefInvoiceNumber.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.RefInvoiceNumber.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "VRefInvoiceNumber")});
            this.RefInvoiceNumber.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefInvoiceNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.RefInvoiceNumber.LocationFloat = new DevExpress.Utils.PointFloat(67.20833F, 38.95836F);
            this.RefInvoiceNumber.Name = "RefInvoiceNumber";
            this.RefInvoiceNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.RefInvoiceNumber.SizeF = new System.Drawing.SizeF(112.7648F, 17F);
            this.RefInvoiceNumber.StylePriority.UseFont = false;
            this.RefInvoiceNumber.StylePriority.UseTextAlignment = false;
            this.RefInvoiceNumber.Text = "RefInvoiceNumber";
            this.RefInvoiceNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // RefDeliveryChallanNumber
            // 
            this.RefDeliveryChallanNumber.BorderColor = System.Drawing.SystemColors.ControlText;
            this.RefDeliveryChallanNumber.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.RefDeliveryChallanNumber.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "VRefDeliveryChallanNumber")});
            this.RefDeliveryChallanNumber.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefDeliveryChallanNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.RefDeliveryChallanNumber.LocationFloat = new DevExpress.Utils.PointFloat(67.20833F, 59.58335F);
            this.RefDeliveryChallanNumber.Name = "RefDeliveryChallanNumber";
            this.RefDeliveryChallanNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.RefDeliveryChallanNumber.SizeF = new System.Drawing.SizeF(112.7648F, 17F);
            this.RefDeliveryChallanNumber.StylePriority.UseFont = false;
            this.RefDeliveryChallanNumber.StylePriority.UseTextAlignment = false;
            this.RefDeliveryChallanNumber.Text = "RefDeliveryChallanNumber";
            this.RefDeliveryChallanNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel26
            // 
            this.xrLabel26.BackColor = System.Drawing.Color.White;
            this.xrLabel26.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel26.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel26.CanGrow = false;
            this.xrLabel26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(0F, 59.58335F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(55.20833F, 18.41667F);
            this.xrLabel26.StylePriority.UseBackColor = false;
            this.xrLabel26.StylePriority.UseBorderColor = false;
            this.xrLabel26.StylePriority.UseBorders = false;
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseForeColor = false;
            this.xrLabel26.StylePriority.UsePadding = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "Ref DC #";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel32
            // 
            this.xrLabel32.BackColor = System.Drawing.Color.White;
            this.xrLabel32.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel32.CanGrow = false;
            this.xrLabel32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(0F, 18.99999F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(55.20833F, 18.41667F);
            this.xrLabel32.StylePriority.UseBackColor = false;
            this.xrLabel32.StylePriority.UseBorderColor = false;
            this.xrLabel32.StylePriority.UseBorders = false;
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseForeColor = false;
            this.xrLabel32.StylePriority.UsePadding = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "Cheque #";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel24
            // 
            this.xrLabel24.BackColor = System.Drawing.Color.White;
            this.xrLabel24.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel24.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel24.CanGrow = false;
            this.xrLabel24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(0F, 38.95836F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(55.20833F, 18.41667F);
            this.xrLabel24.StylePriority.UseBackColor = false;
            this.xrLabel24.StylePriority.UseBorderColor = false;
            this.xrLabel24.StylePriority.UseBorders = false;
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UseForeColor = false;
            this.xrLabel24.StylePriority.UsePadding = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "Ref Inv. #";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.BackColor = System.Drawing.Color.White;
            this.xrLabel3.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.CanGrow = false;
            this.xrLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(55.20833F, 17F);
            this.xrLabel3.StylePriority.UseBackColor = false;
            this.xrLabel3.StylePriority.UseBorderColor = false;
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseForeColor = false;
            this.xrLabel3.StylePriority.UsePadding = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "A/C ID";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xr_Particulars
            // 
            this.xr_Particulars.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xr_Particulars.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xr_Particulars.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Accounts_Vouchers.VParticulars")});
            this.xr_Particulars.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_Particulars.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xr_Particulars.LocationFloat = new DevExpress.Utils.PointFloat(186.7007F, 18.99999F);
            this.xr_Particulars.Name = "xr_Particulars";
            this.xr_Particulars.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_Particulars.SizeF = new System.Drawing.SizeF(342.9827F, 57.58336F);
            this.xr_Particulars.StylePriority.UseFont = false;
            this.xr_Particulars.StylePriority.UseForeColor = false;
            this.xr_Particulars.StylePriority.UseTextAlignment = false;
            this.xr_Particulars.Text = "xr_Particulars";
            this.xr_Particulars.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xr_AccountID_V
            // 
            this.xr_AccountID_V.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xr_AccountID_V.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xr_AccountID_V.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Accounts_Vouchers.AccountID_V")});
            this.xr_AccountID_V.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_AccountID_V.ForeColor = System.Drawing.Color.Black;
            this.xr_AccountID_V.LocationFloat = new DevExpress.Utils.PointFloat(67.20833F, 0F);
            this.xr_AccountID_V.Name = "xr_AccountID_V";
            this.xr_AccountID_V.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_AccountID_V.SizeF = new System.Drawing.SizeF(112.7648F, 17F);
            this.xr_AccountID_V.StylePriority.UseFont = false;
            this.xr_AccountID_V.StylePriority.UseForeColor = false;
            this.xr_AccountID_V.StylePriority.UseTextAlignment = false;
            this.xr_AccountID_V.Text = "xr_AccountID_V";
            this.xr_AccountID_V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xr_AccountName_V
            // 
            this.xr_AccountName_V.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xr_AccountName_V.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xr_AccountName_V.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Accounts_Vouchers.AccountName_V")});
            this.xr_AccountName_V.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_AccountName_V.ForeColor = System.Drawing.Color.Black;
            this.xr_AccountName_V.LocationFloat = new DevExpress.Utils.PointFloat(186.7007F, 0F);
            this.xr_AccountName_V.Name = "xr_AccountName_V";
            this.xr_AccountName_V.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_AccountName_V.SizeF = new System.Drawing.SizeF(342.9827F, 17F);
            this.xr_AccountName_V.StylePriority.UseFont = false;
            this.xr_AccountName_V.StylePriority.UseForeColor = false;
            this.xr_AccountName_V.StylePriority.UseTextAlignment = false;
            this.xr_AccountName_V.Text = "xr_AccountName_V";
            this.xr_AccountName_V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 50F;
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
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.vDate,
            this.VoucherType,
            this.vCompany,
            this.xrLabel2,
            this.vDocumentNumber,
            this.FinancialYear});
            this.ReportHeader.HeightF = 71F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // vDate
            // 
            this.vDate.BorderColor = System.Drawing.Color.Black;
            this.vDate.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.vDate.BorderWidth = 1;
            this.vDate.CanGrow = false;
            this.vDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vDate.ForeColor = System.Drawing.Color.Black;
            this.vDate.LocationFloat = new DevExpress.Utils.PointFloat(533.2983F, 31.81168F);
            this.vDate.Name = "vDate";
            this.vDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.vDate.SizeF = new System.Drawing.SizeF(168.7017F, 20.95833F);
            this.vDate.StylePriority.UseBorderColor = false;
            this.vDate.StylePriority.UseBorders = false;
            this.vDate.StylePriority.UseBorderWidth = false;
            this.vDate.StylePriority.UseFont = false;
            this.vDate.StylePriority.UseForeColor = false;
            this.vDate.StylePriority.UsePadding = false;
            this.vDate.StylePriority.UseTextAlignment = false;
            this.vDate.Text = "2nd July 2014";
            this.vDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // VoucherType
            // 
            this.VoucherType.BorderColor = System.Drawing.Color.Silver;
            this.VoucherType.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.VoucherType.BorderWidth = 1;
            this.VoucherType.CanGrow = false;
            this.VoucherType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoucherType.LocationFloat = new DevExpress.Utils.PointFloat(533.2983F, 0F);
            this.VoucherType.Name = "VoucherType";
            this.VoucherType.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.VoucherType.SizeF = new System.Drawing.SizeF(167.9731F, 29.28999F);
            this.VoucherType.StylePriority.UseBorderColor = false;
            this.VoucherType.StylePriority.UseBorders = false;
            this.VoucherType.StylePriority.UseBorderWidth = false;
            this.VoucherType.StylePriority.UseFont = false;
            this.VoucherType.StylePriority.UsePadding = false;
            this.VoucherType.StylePriority.UseTextAlignment = false;
            this.VoucherType.Text = "Bank Payment Voucher";
            this.VoucherType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // vCompany
            // 
            this.vCompany.BorderColor = System.Drawing.Color.Silver;
            this.vCompany.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.vCompany.BorderWidth = 1;
            this.vCompany.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vCompany.ForeColor = System.Drawing.Color.Blue;
            this.vCompany.LocationFloat = new DevExpress.Utils.PointFloat(186.7007F, 0F);
            this.vCompany.Name = "vCompany";
            this.vCompany.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.vCompany.SizeF = new System.Drawing.SizeF(342.9827F, 29.28999F);
            this.vCompany.StylePriority.UseBorderColor = false;
            this.vCompany.StylePriority.UseBorders = false;
            this.vCompany.StylePriority.UseBorderWidth = false;
            this.vCompany.StylePriority.UseFont = false;
            this.vCompany.StylePriority.UseForeColor = false;
            this.vCompany.StylePriority.UsePadding = false;
            this.vCompany.StylePriority.UseTextAlignment = false;
            this.vCompany.Text = "Maksons Textiles (Pvt.) Ltd.";
            this.vCompany.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.BackColor = System.Drawing.Color.White;
            this.xrLabel2.BorderColor = System.Drawing.Color.Black;
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.BorderWidth = 1;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 31.81168F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(95.31609F, 20.95832F);
            this.xrLabel2.StylePriority.UseBackColor = false;
            this.xrLabel2.StylePriority.UseBorderColor = false;
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseBorderWidth = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseForeColor = false;
            this.xrLabel2.StylePriority.UsePadding = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Financial Year";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // vDocumentNumber
            // 
            this.vDocumentNumber.BorderColor = System.Drawing.Color.Silver;
            this.vDocumentNumber.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.vDocumentNumber.BorderWidth = 1;
            this.vDocumentNumber.CanGrow = false;
            this.vDocumentNumber.Font = new System.Drawing.Font("Digital-7", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vDocumentNumber.ForeColor = System.Drawing.Color.Black;
            this.vDocumentNumber.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.vDocumentNumber.Name = "vDocumentNumber";
            this.vDocumentNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.vDocumentNumber.SizeF = new System.Drawing.SizeF(179.9731F, 29.28999F);
            this.vDocumentNumber.StylePriority.UseBorderColor = false;
            this.vDocumentNumber.StylePriority.UseBorders = false;
            this.vDocumentNumber.StylePriority.UseBorderWidth = false;
            this.vDocumentNumber.StylePriority.UseFont = false;
            this.vDocumentNumber.StylePriority.UseForeColor = false;
            this.vDocumentNumber.StylePriority.UsePadding = false;
            this.vDocumentNumber.StylePriority.UseTextAlignment = false;
            this.vDocumentNumber.Text = "0010000100013";
            this.vDocumentNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // FinancialYear
            // 
            this.FinancialYear.BackColor = System.Drawing.Color.White;
            this.FinancialYear.BorderColor = System.Drawing.Color.Black;
            this.FinancialYear.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.FinancialYear.BorderWidth = 1;
            this.FinancialYear.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinancialYear.ForeColor = System.Drawing.Color.Black;
            this.FinancialYear.LocationFloat = new DevExpress.Utils.PointFloat(95.83432F, 31.81168F);
            this.FinancialYear.Name = "FinancialYear";
            this.FinancialYear.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.FinancialYear.SizeF = new System.Drawing.SizeF(84.13878F, 20.95832F);
            this.FinancialYear.StylePriority.UseBackColor = false;
            this.FinancialYear.StylePriority.UseBorderColor = false;
            this.FinancialYear.StylePriority.UseBorders = false;
            this.FinancialYear.StylePriority.UseBorderWidth = false;
            this.FinancialYear.StylePriority.UseFont = false;
            this.FinancialYear.StylePriority.UseForeColor = false;
            this.FinancialYear.StylePriority.UsePadding = false;
            this.FinancialYear.StylePriority.UseTextAlignment = false;
            this.FinancialYear.Text = "2014-2015";
            this.FinancialYear.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.FinancialYear.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.FinancialYear_BeforePrint);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel29,
            this.xrLabel31,
            this.xrLabel1});
            this.PageHeader.HeightF = 24F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel4
            // 
            this.xrLabel4.BackColor = System.Drawing.Color.White;
            this.xrLabel4.BorderColor = System.Drawing.Color.Black;
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(188.4933F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(341.1901F, 21.54167F);
            this.xrLabel4.StylePriority.UseBackColor = false;
            this.xrLabel4.StylePriority.UseBorderColor = false;
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseForeColor = false;
            this.xrLabel4.StylePriority.UsePadding = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Particulars";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel29
            // 
            this.xrLabel29.BackColor = System.Drawing.Color.White;
            this.xrLabel29.BorderColor = System.Drawing.Color.Black;
            this.xrLabel29.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel29.CanGrow = false;
            this.xrLabel29.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.ForeColor = System.Drawing.Color.Black;
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(179.9731F, 21.54167F);
            this.xrLabel29.StylePriority.UseBackColor = false;
            this.xrLabel29.StylePriority.UseBorderColor = false;
            this.xrLabel29.StylePriority.UseBorders = false;
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseForeColor = false;
            this.xrLabel29.StylePriority.UsePadding = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "Account & References";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel31
            // 
            this.xrLabel31.BackColor = System.Drawing.Color.White;
            this.xrLabel31.BorderColor = System.Drawing.Color.Black;
            this.xrLabel31.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel31.CanGrow = false;
            this.xrLabel31.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel31.ForeColor = System.Drawing.Color.Black;
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(531.6835F, 0F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(83.79401F, 21.54167F);
            this.xrLabel31.StylePriority.UseBackColor = false;
            this.xrLabel31.StylePriority.UseBorderColor = false;
            this.xrLabel31.StylePriority.UseBorders = false;
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseForeColor = false;
            this.xrLabel31.StylePriority.UsePadding = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "Debit";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.White;
            this.xrLabel1.BorderColor = System.Drawing.Color.Black;
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(617.4775F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(83.79407F, 21.54167F);
            this.xrLabel1.StylePriority.UseBackColor = false;
            this.xrLabel1.StylePriority.UseBorderColor = false;
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Credit";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xr_TotalAmountWords,
            this.xr_TotalAmount,
            this.xrLabel5,
            this.xrLabel20,
            this.xrLine3,
            this.xrLine7,
            this.xrLine5,
            this.xrLine4,
            this.xrLabel13,
            this.xrLabel46,
            this.xrLabel9,
            this.vBarcode,
            this.xrLabel6,
            this.xrUserID,
            this.xrPageInfo2,
            this.xrPageInfo1,
            this.xrLabel30});
            this.ReportFooter.HeightF = 135F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xr_TotalAmountWords
            // 
            this.xr_TotalAmountWords.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xr_TotalAmountWords.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xr_TotalAmountWords.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xr_TotalAmountWords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.xr_TotalAmountWords.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xr_TotalAmountWords.Name = "xr_TotalAmountWords";
            this.xr_TotalAmountWords.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_TotalAmountWords.SizeF = new System.Drawing.SizeF(529.6835F, 19.12497F);
            this.xr_TotalAmountWords.StylePriority.UseBorders = false;
            this.xr_TotalAmountWords.StylePriority.UseTextAlignment = false;
            this.xr_TotalAmountWords.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xr_TotalAmount
            // 
            this.xr_TotalAmount.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xr_TotalAmount.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xr_TotalAmount.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Accounts_Vouchers.VDebitAmount")});
            this.xr_TotalAmount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_TotalAmount.ForeColor = System.Drawing.Color.Black;
            this.xr_TotalAmount.LocationFloat = new DevExpress.Utils.PointFloat(531.6834F, 0F);
            this.xr_TotalAmount.Name = "xr_TotalAmount";
            this.xr_TotalAmount.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_TotalAmount.SizeF = new System.Drawing.SizeF(83.79401F, 19.20827F);
            this.xr_TotalAmount.StylePriority.UseBorders = false;
            this.xr_TotalAmount.StylePriority.UseFont = false;
            this.xr_TotalAmount.StylePriority.UseForeColor = false;
            this.xr_TotalAmount.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:#,#}";
            xrSummary1.IgnoreNullValues = true;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xr_TotalAmount.Summary = xrSummary1;
            this.xr_TotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xr_TotalAmount.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xr_TotalAmount_BeforePrint);
            // 
            // xrLabel5
            // 
            this.xrLabel5.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Accounts_Vouchers.VCreditAmount")});
            this.xrLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(617.4774F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(83.79407F, 19.12492F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseForeColor = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:#,#}";
            xrSummary2.IgnoreNullValues = true;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel5.Summary = xrSummary2;
            this.xrLabel5.Text = "xrLabel28";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel30
            // 
            this.xrLabel30.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel30.BorderWidth = 1;
            this.xrLabel30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel30.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(460.6946F, 113F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(33.34671F, 18.66667F);
            this.xrLabel30.StylePriority.UseBorderColor = false;
            this.xrLabel30.StylePriority.UseBorders = false;
            this.xrLabel30.StylePriority.UseBorderWidth = false;
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseForeColor = false;
            this.xrLabel30.StylePriority.UsePadding = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "UID";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(36.77136F, 113F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(28.12503F, 18.66667F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseForeColor = false;
            this.xrPageInfo1.StylePriority.UsePadding = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.xrPageInfo2.Format = "{0:hh:mm:ss tt}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(616.7489F, 113F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(83.79407F, 18.66667F);
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
            this.xrUserID.LocationFloat = new DevExpress.Utils.PointFloat(494.0414F, 113F);
            this.xrUserID.Name = "xrUserID";
            this.xrUserID.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrUserID.SizeF = new System.Drawing.SizeF(120.7074F, 18.66669F);
            this.xrUserID.StylePriority.UseBorderColor = false;
            this.xrUserID.StylePriority.UseBorders = false;
            this.xrUserID.StylePriority.UseBorderWidth = false;
            this.xrUserID.StylePriority.UseFont = false;
            this.xrUserID.StylePriority.UseForeColor = false;
            this.xrUserID.StylePriority.UsePadding = false;
            this.xrUserID.StylePriority.UseTextAlignment = false;
            this.xrUserID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrUserID.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrUserID_BeforePrint);
            // 
            // xrLabel6
            // 
            this.xrLabel6.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel6.BorderWidth = 1;
            this.xrLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(3.424581F, 113F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(33.34671F, 18.66667F);
            this.xrLabel6.StylePriority.UseBorderColor = false;
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseBorderWidth = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseForeColor = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Page";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // vBarcode
            // 
            this.vBarcode.BorderColor = System.Drawing.Color.Silver;
            this.vBarcode.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.vBarcode.BorderWidth = 1;
            this.vBarcode.LocationFloat = new DevExpress.Utils.PointFloat(66.47971F, 112.9999F);
            this.vBarcode.Name = "vBarcode";
            this.vBarcode.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.vBarcode.ShowText = false;
            this.vBarcode.SizeF = new System.Drawing.SizeF(380.9218F, 18.66671F);
            this.vBarcode.StylePriority.UseBorderColor = false;
            this.vBarcode.StylePriority.UseBorders = false;
            this.vBarcode.StylePriority.UseBorderWidth = false;
            this.vBarcode.StylePriority.UseTextAlignment = false;
            this.vBarcode.Symbology = code128Generator1;
            this.vBarcode.Text = "0010000100013";
            this.vBarcode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(187.7647F, 70.66669F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(136.52F, 17F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseForeColor = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Checked by";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel46
            // 
            this.xrLabel46.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel46.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel46.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel46.ForeColor = System.Drawing.Color.Black;
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(0F, 70.66669F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(136.52F, 17F);
            this.xrLabel46.StylePriority.UseBorders = false;
            this.xrLabel46.StylePriority.UseForeColor = false;
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            this.xrLabel46.Text = "Prepared by";
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel13
            // 
            this.xrLabel13.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.ForeColor = System.Drawing.Color.Black;
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(376.2581F, 70.66669F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(136.52F, 17F);
            this.xrLabel13.StylePriority.UseBorders = false;
            this.xrLabel13.StylePriority.UseForeColor = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Approved by";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine4
            // 
            this.xrLine4.BorderWidth = 1;
            this.xrLine4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLine4.LineWidth = 3;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(187.4932F, 66.66685F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(135.7916F, 3F);
            this.xrLine4.StylePriority.UseBorderWidth = false;
            this.xrLine4.StylePriority.UseForeColor = false;
            // 
            // xrLine5
            // 
            this.xrLine5.BorderWidth = 1;
            this.xrLine5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLine5.LineWidth = 3;
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(376.2581F, 66.66685F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(135.7916F, 3F);
            this.xrLine5.StylePriority.UseBorderWidth = false;
            this.xrLine5.StylePriority.UseForeColor = false;
            // 
            // xrLine7
            // 
            this.xrLine7.BorderWidth = 1;
            this.xrLine7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLine7.LineWidth = 3;
            this.xrLine7.LocationFloat = new DevExpress.Utils.PointFloat(564.7513F, 66.66685F);
            this.xrLine7.Name = "xrLine7";
            this.xrLine7.SizeF = new System.Drawing.SizeF(135.7916F, 3F);
            this.xrLine7.StylePriority.UseBorderWidth = false;
            this.xrLine7.StylePriority.UseForeColor = false;
            // 
            // xrLabel20
            // 
            this.xrLabel20.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.ForeColor = System.Drawing.Color.Black;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(564.7513F, 70.66669F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(136.52F, 17F);
            this.xrLabel20.StylePriority.UseBorders = false;
            this.xrLabel20.StylePriority.UseForeColor = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Received by";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine3
            // 
            this.xrLine3.BorderWidth = 1;
            this.xrLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLine3.LineWidth = 3;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 66.66685F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(135.7916F, 3F);
            this.xrLine3.StylePriority.UseBorderWidth = false;
            this.xrLine3.StylePriority.UseForeColor = false;
            // 
            // Accounts_Voucher_MDC
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter});
            this.Margins = new System.Drawing.Printing.Margins(74, 51, 50, 32);
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
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        public DevExpress.XtraReports.UI.XRLabel VoucherType;
        public DevExpress.XtraReports.UI.XRLabel vCompany;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        public DevExpress.XtraReports.UI.XRLabel vDocumentNumber;
        private DevExpress.XtraReports.UI.XRLabel FinancialYear;
        public DevExpress.XtraReports.UI.XRLabel vDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel29;
        private DevExpress.XtraReports.UI.XRLabel xrLabel31;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xr_AccountID_V;
        private DevExpress.XtraReports.UI.XRLabel xr_AccountName_V;
        private DevExpress.XtraReports.UI.XRLabel xr_Particulars;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel26;
        private DevExpress.XtraReports.UI.XRLabel xrLabel32;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLabel RefChequeNumber;
        private DevExpress.XtraReports.UI.XRLabel RefInvoiceNumber;
        private DevExpress.XtraReports.UI.XRLabel RefDeliveryChallanNumber;
        private DevExpress.XtraReports.UI.XRLabel xr_Amount;
        private DevExpress.XtraReports.UI.XRLabel xrLabel28;
        public DevExpress.XtraReports.UI.XRLabel xr_TotalAmountWords;
        private DevExpress.XtraReports.UI.XRLabel xr_TotalAmount;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel46;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLine xrLine4;
        private DevExpress.XtraReports.UI.XRLine xrLine5;
        private DevExpress.XtraReports.UI.XRLine xrLine7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        public DevExpress.XtraReports.UI.XRBarCode vBarcode;
        private DevExpress.XtraReports.UI.XRLabel xrLabel30;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRLabel xrUserID;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
    }
}
