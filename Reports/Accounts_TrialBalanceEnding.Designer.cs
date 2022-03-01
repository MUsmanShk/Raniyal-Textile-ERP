namespace MachineEyes.Reports
{
    partial class Accounts_TrialBalanceEnding
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
            this.AccountV_Credit = new DevExpress.XtraReports.UI.XRLabel();
            this.AccountName_V = new DevExpress.XtraReports.UI.XRLabel();
            this.AccountID_V = new DevExpress.XtraReports.UI.XRLabel();
            this.AccountV_Debit = new DevExpress.XtraReports.UI.XRLabel();
            this.index = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.FinancialYear = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.NGB = new DevExpress.XtraReports.UI.XRLabel();
            this.RepH_Company = new DevExpress.XtraReports.UI.XRLabel();
            this.RepH_DocumentName = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.lbCustomer = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.TotalDebit = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalCredit = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.AccountIV_ID = new DevExpress.XtraReports.UI.XRLabel();
            this.AccountIV_Name = new DevExpress.XtraReports.UI.XRLabel();
            this.AccountIV_Debit = new DevExpress.XtraReports.UI.XRLabel();
            this.AccountIV_Credit = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.AccountV_Credit,
            this.AccountName_V,
            this.AccountID_V,
            this.AccountV_Debit,
            this.index});
            this.Detail.HeightF = 20F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // AccountV_Credit
            // 
            this.AccountV_Credit.BorderColor = System.Drawing.Color.Silver;
            this.AccountV_Credit.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.AccountV_Credit.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Tag", null, "eCredit")});
            this.AccountV_Credit.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountV_Credit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountV_Credit.LocationFloat = new DevExpress.Utils.PointFloat(601.1095F, 0F);
            this.AccountV_Credit.Name = "AccountV_Credit";
            this.AccountV_Credit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountV_Credit.SizeF = new System.Drawing.SizeF(93.86145F, 17F);
            this.AccountV_Credit.StylePriority.UseBorderColor = false;
            this.AccountV_Credit.StylePriority.UseBorders = false;
            this.AccountV_Credit.StylePriority.UseFont = false;
            this.AccountV_Credit.StylePriority.UseForeColor = false;
            this.AccountV_Credit.StylePriority.UseTextAlignment = false;
            this.AccountV_Credit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.AccountV_Credit.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.AccountV_Credit_BeforePrint);
            // 
            // AccountName_V
            // 
            this.AccountName_V.BorderColor = System.Drawing.Color.Silver;
            this.AccountName_V.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.AccountName_V.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountName_V")});
            this.AccountName_V.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountName_V.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountName_V.LocationFloat = new DevExpress.Utils.PointFloat(153.8359F, 0F);
            this.AccountName_V.Name = "AccountName_V";
            this.AccountName_V.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountName_V.SizeF = new System.Drawing.SizeF(357.5302F, 17F);
            this.AccountName_V.StylePriority.UseBorderColor = false;
            this.AccountName_V.StylePriority.UseBorders = false;
            this.AccountName_V.StylePriority.UseFont = false;
            this.AccountName_V.StylePriority.UseForeColor = false;
            this.AccountName_V.StylePriority.UseTextAlignment = false;
            this.AccountName_V.Text = "AccountName_V";
            this.AccountName_V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // AccountID_V
            // 
            this.AccountID_V.BorderColor = System.Drawing.Color.Silver;
            this.AccountID_V.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.AccountID_V.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountID_V")});
            this.AccountID_V.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountID_V.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountID_V.LocationFloat = new DevExpress.Utils.PointFloat(36.10058F, 0F);
            this.AccountID_V.Name = "AccountID_V";
            this.AccountID_V.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountID_V.SizeF = new System.Drawing.SizeF(115.7354F, 17F);
            this.AccountID_V.StylePriority.UseBorderColor = false;
            this.AccountID_V.StylePriority.UseBorders = false;
            this.AccountID_V.StylePriority.UseFont = false;
            this.AccountID_V.StylePriority.UseForeColor = false;
            this.AccountID_V.StylePriority.UseTextAlignment = false;
            this.AccountID_V.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // AccountV_Debit
            // 
            this.AccountV_Debit.BorderColor = System.Drawing.Color.Silver;
            this.AccountV_Debit.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.AccountV_Debit.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Tag", null, "eDebit")});
            this.AccountV_Debit.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountV_Debit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountV_Debit.LocationFloat = new DevExpress.Utils.PointFloat(511.3661F, 0F);
            this.AccountV_Debit.Name = "AccountV_Debit";
            this.AccountV_Debit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountV_Debit.SizeF = new System.Drawing.SizeF(89.74341F, 17F);
            this.AccountV_Debit.StylePriority.UseBorderColor = false;
            this.AccountV_Debit.StylePriority.UseBorders = false;
            this.AccountV_Debit.StylePriority.UseFont = false;
            this.AccountV_Debit.StylePriority.UseForeColor = false;
            this.AccountV_Debit.StylePriority.UseTextAlignment = false;
            this.AccountV_Debit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.AccountV_Debit.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.AccountV_Debit_BeforePrint);
            // 
            // index
            // 
            this.index.BorderColor = System.Drawing.Color.Silver;
            this.index.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.index.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.index.ForeColor = System.Drawing.SystemColors.ControlText;
            this.index.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.index.Name = "index";
            this.index.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.index.SizeF = new System.Drawing.SizeF(34.11639F, 17F);
            this.index.StylePriority.UseBorderColor = false;
            this.index.StylePriority.UseBorders = false;
            this.index.StylePriority.UseFont = false;
            this.index.StylePriority.UseForeColor = false;
            this.index.StylePriority.UseTextAlignment = false;
            this.index.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.index.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.index_BeforePrint);
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
            this.BottomMargin.HeightF = 45F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.FinancialYear,
            this.xrLabel27,
            this.NGB,
            this.RepH_Company,
            this.RepH_DocumentName});
            this.ReportHeader.HeightF = 39.16666F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // FinancialYear
            // 
            this.FinancialYear.BackColor = System.Drawing.Color.Black;
            this.FinancialYear.BorderColor = System.Drawing.Color.Black;
            this.FinancialYear.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.FinancialYear.BorderWidth = 1;
            this.FinancialYear.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinancialYear.ForeColor = System.Drawing.Color.White;
            this.FinancialYear.LocationFloat = new DevExpress.Utils.PointFloat(631.9339F, 18.20834F);
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
            // xrLabel27
            // 
            this.xrLabel27.BackColor = System.Drawing.Color.Black;
            this.xrLabel27.BorderColor = System.Drawing.Color.Black;
            this.xrLabel27.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel27.BorderWidth = 1;
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.ForeColor = System.Drawing.Color.White;
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(536.6178F, 18.20834F);
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
            // NGB
            // 
            this.NGB.BorderColor = System.Drawing.Color.SteelBlue;
            this.NGB.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.NGB.BorderWidth = 1;
            this.NGB.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NGB.LocationFloat = new DevExpress.Utils.PointFloat(304.0003F, 0F);
            this.NGB.Name = "NGB";
            this.NGB.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.NGB.SizeF = new System.Drawing.SizeF(26.30457F, 17.20833F);
            this.NGB.StylePriority.UseBorderColor = false;
            this.NGB.StylePriority.UseBorders = false;
            this.NGB.StylePriority.UseBorderWidth = false;
            this.NGB.StylePriority.UseFont = false;
            this.NGB.StylePriority.UsePadding = false;
            this.NGB.StylePriority.UseTextAlignment = false;
            this.NGB.Text = "G";
            this.NGB.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // RepH_Company
            // 
            this.RepH_Company.BorderColor = System.Drawing.Color.SteelBlue;
            this.RepH_Company.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.RepH_Company.BorderWidth = 1;
            this.RepH_Company.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepH_Company.ForeColor = System.Drawing.Color.Black;
            this.RepH_Company.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.RepH_Company.Name = "RepH_Company";
            this.RepH_Company.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.RepH_Company.SizeF = new System.Drawing.SizeF(249.0833F, 17.20833F);
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
            this.RepH_DocumentName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepH_DocumentName.LocationFloat = new DevExpress.Utils.PointFloat(536.6178F, 0F);
            this.RepH_DocumentName.Name = "RepH_DocumentName";
            this.RepH_DocumentName.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.RepH_DocumentName.SizeF = new System.Drawing.SizeF(158.3693F, 17.20833F);
            this.RepH_DocumentName.StylePriority.UseBorderColor = false;
            this.RepH_DocumentName.StylePriority.UseBorders = false;
            this.RepH_DocumentName.StylePriority.UseBorderWidth = false;
            this.RepH_DocumentName.StylePriority.UseFont = false;
            this.RepH_DocumentName.StylePriority.UsePadding = false;
            this.RepH_DocumentName.StylePriority.UseTextAlignment = false;
            this.RepH_DocumentName.Text = "Ending Trial Balance";
            this.RepH_DocumentName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbCustomer,
            this.xrLabel1,
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel22});
            this.PageHeader.HeightF = 17F;
            this.PageHeader.Name = "PageHeader";
            // 
            // lbCustomer
            // 
            this.lbCustomer.BackColor = System.Drawing.Color.White;
            this.lbCustomer.BorderColor = System.Drawing.SystemColors.ControlText;
            this.lbCustomer.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustomer.ForeColor = System.Drawing.Color.Black;
            this.lbCustomer.LocationFloat = new DevExpress.Utils.PointFloat(153.8518F, 0F);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCustomer.SizeF = new System.Drawing.SizeF(357.5143F, 17F);
            this.lbCustomer.StylePriority.UseBackColor = false;
            this.lbCustomer.StylePriority.UseBorders = false;
            this.lbCustomer.StylePriority.UseFont = false;
            this.lbCustomer.StylePriority.UseForeColor = false;
            this.lbCustomer.StylePriority.UseTextAlignment = false;
            this.lbCustomer.Text = "Accounts Name";
            this.lbCustomer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.White;
            this.xrLabel1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(36.11639F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(117.7354F, 17F);
            this.xrLabel1.StylePriority.UseBackColor = false;
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Accounts ID";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel21
            // 
            this.xrLabel21.BackColor = System.Drawing.Color.White;
            this.xrLabel21.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel21.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.ForeColor = System.Drawing.Color.Black;
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(601.1095F, 0F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(93.86151F, 17F);
            this.xrLabel21.StylePriority.UseBackColor = false;
            this.xrLabel21.StylePriority.UseBorders = false;
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseForeColor = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "Credit";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel20
            // 
            this.xrLabel20.BackColor = System.Drawing.Color.White;
            this.xrLabel20.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel20.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.ForeColor = System.Drawing.Color.Black;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(511.3661F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(89.74341F, 17F);
            this.xrLabel20.StylePriority.UseBackColor = false;
            this.xrLabel20.StylePriority.UseBorders = false;
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseForeColor = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Debit";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel22
            // 
            this.xrLabel22.BackColor = System.Drawing.Color.White;
            this.xrLabel22.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel22.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.ForeColor = System.Drawing.Color.Black;
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(36.11639F, 17F);
            this.xrLabel22.StylePriority.UseBackColor = false;
            this.xrLabel22.StylePriority.UseBorders = false;
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseForeColor = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "#";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.TotalDebit,
            this.TotalCredit});
            this.ReportFooter.HeightF = 17F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // TotalDebit
            // 
            this.TotalDebit.BorderColor = System.Drawing.Color.Silver;
            this.TotalDebit.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.TotalDebit.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalDebit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TotalDebit.LocationFloat = new DevExpress.Utils.PointFloat(511.3661F, 0F);
            this.TotalDebit.Name = "TotalDebit";
            this.TotalDebit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalDebit.SizeF = new System.Drawing.SizeF(89.74341F, 17F);
            this.TotalDebit.StylePriority.UseBorderColor = false;
            this.TotalDebit.StylePriority.UseBorders = false;
            this.TotalDebit.StylePriority.UseFont = false;
            this.TotalDebit.StylePriority.UseForeColor = false;
            this.TotalDebit.StylePriority.UseTextAlignment = false;
            this.TotalDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.TotalDebit.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.TotalDebit_BeforePrint);
            // 
            // TotalCredit
            // 
            this.TotalCredit.BorderColor = System.Drawing.Color.Silver;
            this.TotalCredit.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.TotalCredit.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalCredit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TotalCredit.LocationFloat = new DevExpress.Utils.PointFloat(601.1096F, 0F);
            this.TotalCredit.Name = "TotalCredit";
            this.TotalCredit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalCredit.SizeF = new System.Drawing.SizeF(93.86139F, 17F);
            this.TotalCredit.StylePriority.UseBorderColor = false;
            this.TotalCredit.StylePriority.UseBorders = false;
            this.TotalCredit.StylePriority.UseFont = false;
            this.TotalCredit.StylePriority.UseForeColor = false;
            this.TotalCredit.StylePriority.UseTextAlignment = false;
            this.TotalCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.TotalCredit.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.TotalCredit_BeforePrint);
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.xrLabel6,
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.PageFooter.HeightF = 21F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLabel5
            // 
            this.xrLabel5.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel5.BorderWidth = 1;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(53.13837F, 14.66667F);
            this.xrLabel5.StylePriority.UseBorderColor = false;
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseBorderWidth = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseForeColor = false;
            this.xrLabel5.StylePriority.UsePadding = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Page";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel6.BorderWidth = 1;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(304.0003F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(125.3255F, 14.66667F);
            this.xrLabel6.StylePriority.UseBorderColor = false;
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseBorderWidth = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseForeColor = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Printing Date & Time";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Format = "{0:dddd, dd MMMM, yyyy h:mm tt}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(429.3258F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(265.6612F, 14.66666F);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(53.13838F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(37.50002F, 14.66666F);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.AccountIV_ID,
            this.AccountIV_Name});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("AccountID_IV", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 17F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // AccountIV_ID
            // 
            this.AccountIV_ID.BorderColor = System.Drawing.Color.Silver;
            this.AccountIV_ID.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.AccountIV_ID.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountID_IV")});
            this.AccountIV_ID.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountIV_ID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountIV_ID.LocationFloat = new DevExpress.Utils.PointFloat(36.10058F, 0F);
            this.AccountIV_ID.Name = "AccountIV_ID";
            this.AccountIV_ID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountIV_ID.SizeF = new System.Drawing.SizeF(117.7512F, 17F);
            this.AccountIV_ID.StylePriority.UseBorderColor = false;
            this.AccountIV_ID.StylePriority.UseBorders = false;
            this.AccountIV_ID.StylePriority.UseFont = false;
            this.AccountIV_ID.StylePriority.UseForeColor = false;
            this.AccountIV_ID.StylePriority.UseTextAlignment = false;
            this.AccountIV_ID.Text = "[Accounts_Vouchers_Opening.AccountID_IV]";
            this.AccountIV_ID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // AccountIV_Name
            // 
            this.AccountIV_Name.BorderColor = System.Drawing.Color.Silver;
            this.AccountIV_Name.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.AccountIV_Name.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountName_IV")});
            this.AccountIV_Name.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountIV_Name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountIV_Name.LocationFloat = new DevExpress.Utils.PointFloat(153.8518F, 0F);
            this.AccountIV_Name.Name = "AccountIV_Name";
            this.AccountIV_Name.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountIV_Name.SizeF = new System.Drawing.SizeF(354.5143F, 17F);
            this.AccountIV_Name.StylePriority.UseBorderColor = false;
            this.AccountIV_Name.StylePriority.UseBorders = false;
            this.AccountIV_Name.StylePriority.UseFont = false;
            this.AccountIV_Name.StylePriority.UseForeColor = false;
            this.AccountIV_Name.StylePriority.UseTextAlignment = false;
            this.AccountIV_Name.Text = "[Accounts_Vouchers_Opening.AccountName_IV]";
            this.AccountIV_Name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // AccountIV_Debit
            // 
            this.AccountIV_Debit.BorderColor = System.Drawing.Color.Silver;
            this.AccountIV_Debit.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.AccountIV_Debit.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountIV_Debit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountIV_Debit.LocationFloat = new DevExpress.Utils.PointFloat(511.3661F, 0F);
            this.AccountIV_Debit.Name = "AccountIV_Debit";
            this.AccountIV_Debit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountIV_Debit.SizeF = new System.Drawing.SizeF(89.74347F, 17F);
            this.AccountIV_Debit.StylePriority.UseBorderColor = false;
            this.AccountIV_Debit.StylePriority.UseBorders = false;
            this.AccountIV_Debit.StylePriority.UseFont = false;
            this.AccountIV_Debit.StylePriority.UseForeColor = false;
            this.AccountIV_Debit.StylePriority.UseTextAlignment = false;
            this.AccountIV_Debit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.AccountIV_Debit.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.AccountIV_Debit_BeforePrint);
            // 
            // AccountIV_Credit
            // 
            this.AccountIV_Credit.BorderColor = System.Drawing.Color.Silver;
            this.AccountIV_Credit.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.AccountIV_Credit.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountIV_Credit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AccountIV_Credit.LocationFloat = new DevExpress.Utils.PointFloat(601.1096F, 0F);
            this.AccountIV_Credit.Name = "AccountIV_Credit";
            this.AccountIV_Credit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountIV_Credit.SizeF = new System.Drawing.SizeF(93.86139F, 17F);
            this.AccountIV_Credit.StylePriority.UseBorderColor = false;
            this.AccountIV_Credit.StylePriority.UseBorders = false;
            this.AccountIV_Credit.StylePriority.UseFont = false;
            this.AccountIV_Credit.StylePriority.UseForeColor = false;
            this.AccountIV_Credit.StylePriority.UseTextAlignment = false;
            this.AccountIV_Credit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.AccountIV_Credit.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.AccountIV_Credit_BeforePrint);
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.AccountIV_Credit,
            this.AccountIV_Debit});
            this.GroupFooter1.HeightF = 17F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLabel3
            // 
            this.xrLabel3.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountName_IV")});
            this.xrLabel3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(153.8676F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(354.4985F, 17F);
            this.xrLabel3.StylePriority.UseBorderColor = false;
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseForeColor = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "[Accounts_Vouchers_Opening.AccountName_IV]";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Accounts_TrialBalanceEnding
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.PageFooter,
            this.GroupHeader1,
            this.GroupFooter1});
            this.Margins = new System.Drawing.Printing.Margins(79, 52, 46, 45);
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
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        public DevExpress.XtraReports.UI.XRLabel RepH_Company;
        public DevExpress.XtraReports.UI.XRLabel RepH_DocumentName;
        private DevExpress.XtraReports.UI.XRLabel lbCustomer;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel AccountV_Debit;
        private DevExpress.XtraReports.UI.XRLabel AccountID_V;
        private DevExpress.XtraReports.UI.XRLabel AccountV_Credit;
        private DevExpress.XtraReports.UI.XRLabel AccountName_V;
        private DevExpress.XtraReports.UI.XRLabel index;
        private DevExpress.XtraReports.UI.XRLabel AccountIV_Debit;
        private DevExpress.XtraReports.UI.XRLabel AccountIV_ID;
        private DevExpress.XtraReports.UI.XRLabel AccountIV_Credit;
        private DevExpress.XtraReports.UI.XRLabel AccountIV_Name;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel TotalDebit;
        private DevExpress.XtraReports.UI.XRLabel TotalCredit;
        public DevExpress.XtraReports.UI.XRLabel NGB;
        private DevExpress.XtraReports.UI.XRLabel FinancialYear;
        private DevExpress.XtraReports.UI.XRLabel xrLabel27;
    }
}
