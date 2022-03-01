namespace MachineEyes.Reports
{
    partial class Accounts_LedgerConsolidated
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
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xr_BalanceCF = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_Credit = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_BalanceBF = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_Index = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_AccountID = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_Debit = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_AccountName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLevel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_AccountofName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_ToDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_Accountof = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCustomer = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_FromDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.RepH_Company = new DevExpress.XtraReports.UI.XRLabel();
            this.RepH_DocumentName = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.FinancialYear = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xr_TotalBalanceBF = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_TotalBalanceCF = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_TotalCredit = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_TotalDebit = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xr_BalanceCF,
            this.xr_Credit,
            this.xr_BalanceBF,
            this.xr_Index,
            this.xr_AccountID,
            this.xr_Debit,
            this.xr_AccountName});
            this.Detail.HeightF = 18F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xr_BalanceCF
            // 
            this.xr_BalanceCF.BorderColor = System.Drawing.Color.Silver;
            this.xr_BalanceCF.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xr_BalanceCF.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalBalanceCF", "{0:#,#;(#,#)}")});
            this.xr_BalanceCF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_BalanceCF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xr_BalanceCF.LocationFloat = new DevExpress.Utils.PointFloat(601.2019F, 0F);
            this.xr_BalanceCF.Name = "xr_BalanceCF";
            this.xr_BalanceCF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xr_BalanceCF.SizeF = new System.Drawing.SizeF(96.7981F, 17F);
            this.xr_BalanceCF.StylePriority.UseBorderColor = false;
            this.xr_BalanceCF.StylePriority.UseBorders = false;
            this.xr_BalanceCF.StylePriority.UseFont = false;
            this.xr_BalanceCF.StylePriority.UseForeColor = false;
            this.xr_BalanceCF.StylePriority.UsePadding = false;
            this.xr_BalanceCF.StylePriority.UseTextAlignment = false;
            this.xr_BalanceCF.Text = "xr_BalanceCF";
            this.xr_BalanceCF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xr_Credit
            // 
            this.xr_Credit.BorderColor = System.Drawing.Color.Silver;
            this.xr_Credit.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xr_Credit.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalCredit", "{0:#,#}")});
            this.xr_Credit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_Credit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xr_Credit.LocationFloat = new DevExpress.Utils.PointFloat(532.2501F, 0F);
            this.xr_Credit.Name = "xr_Credit";
            this.xr_Credit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xr_Credit.SizeF = new System.Drawing.SizeF(65.95178F, 17F);
            this.xr_Credit.StylePriority.UseBorderColor = false;
            this.xr_Credit.StylePriority.UseBorders = false;
            this.xr_Credit.StylePriority.UseFont = false;
            this.xr_Credit.StylePriority.UseForeColor = false;
            this.xr_Credit.StylePriority.UsePadding = false;
            this.xr_Credit.StylePriority.UseTextAlignment = false;
            this.xr_Credit.Text = "xr_Debit";
            this.xr_Credit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xr_BalanceBF
            // 
            this.xr_BalanceBF.BorderColor = System.Drawing.Color.Silver;
            this.xr_BalanceBF.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xr_BalanceBF.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalBalanceBF", "{0:#,#;(#,#)}")});
            this.xr_BalanceBF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_BalanceBF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xr_BalanceBF.LocationFloat = new DevExpress.Utils.PointFloat(378.6591F, 0F);
            this.xr_BalanceBF.Name = "xr_BalanceBF";
            this.xr_BalanceBF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xr_BalanceBF.SizeF = new System.Drawing.SizeF(80.53506F, 17F);
            this.xr_BalanceBF.StylePriority.UseBorderColor = false;
            this.xr_BalanceBF.StylePriority.UseBorders = false;
            this.xr_BalanceBF.StylePriority.UseFont = false;
            this.xr_BalanceBF.StylePriority.UseForeColor = false;
            this.xr_BalanceBF.StylePriority.UsePadding = false;
            this.xr_BalanceBF.StylePriority.UseTextAlignment = false;
            this.xr_BalanceBF.Text = "xr_BalanceBF";
            this.xr_BalanceBF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xr_Index
            // 
            this.xr_Index.BorderColor = System.Drawing.Color.Silver;
            this.xr_Index.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xr_Index.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_Index.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xr_Index.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xr_Index.Name = "xr_Index";
            this.xr_Index.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_Index.SizeF = new System.Drawing.SizeF(25.7832F, 17F);
            this.xr_Index.StylePriority.UseBorderColor = false;
            this.xr_Index.StylePriority.UseBorders = false;
            this.xr_Index.StylePriority.UseFont = false;
            this.xr_Index.StylePriority.UseForeColor = false;
            this.xr_Index.StylePriority.UseTextAlignment = false;
            this.xr_Index.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xr_AccountID
            // 
            this.xr_AccountID.BorderColor = System.Drawing.Color.Silver;
            this.xr_AccountID.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xr_AccountID.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountID")});
            this.xr_AccountID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_AccountID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xr_AccountID.LocationFloat = new DevExpress.Utils.PointFloat(26.67898F, 0F);
            this.xr_AccountID.Name = "xr_AccountID";
            this.xr_AccountID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_AccountID.SizeF = new System.Drawing.SizeF(89.21677F, 17F);
            this.xr_AccountID.StylePriority.UseBorderColor = false;
            this.xr_AccountID.StylePriority.UseBorders = false;
            this.xr_AccountID.StylePriority.UseFont = false;
            this.xr_AccountID.StylePriority.UseForeColor = false;
            this.xr_AccountID.StylePriority.UseTextAlignment = false;
            this.xr_AccountID.Text = "xr_AccountID";
            this.xr_AccountID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xr_Debit
            // 
            this.xr_Debit.BorderColor = System.Drawing.Color.Silver;
            this.xr_Debit.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xr_Debit.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalDebit", "{0:#,#}")});
            this.xr_Debit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_Debit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xr_Debit.LocationFloat = new DevExpress.Utils.PointFloat(462.1944F, 0F);
            this.xr_Debit.Name = "xr_Debit";
            this.xr_Debit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xr_Debit.SizeF = new System.Drawing.SizeF(65.95172F, 17F);
            this.xr_Debit.StylePriority.UseBorderColor = false;
            this.xr_Debit.StylePriority.UseBorders = false;
            this.xr_Debit.StylePriority.UseFont = false;
            this.xr_Debit.StylePriority.UseForeColor = false;
            this.xr_Debit.StylePriority.UsePadding = false;
            this.xr_Debit.StylePriority.UseTextAlignment = false;
            this.xr_Debit.Text = "xr_Debit";
            this.xr_Debit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xr_AccountName
            // 
            this.xr_AccountName.BorderColor = System.Drawing.Color.Silver;
            this.xr_AccountName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xr_AccountName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccountName")});
            this.xr_AccountName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_AccountName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xr_AccountName.LocationFloat = new DevExpress.Utils.PointFloat(117.8958F, 0F);
            this.xr_AccountName.Name = "xr_AccountName";
            this.xr_AccountName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_AccountName.SizeF = new System.Drawing.SizeF(257.7634F, 17F);
            this.xr_AccountName.StylePriority.UseBorderColor = false;
            this.xr_AccountName.StylePriority.UseBorders = false;
            this.xr_AccountName.StylePriority.UseFont = false;
            this.xr_AccountName.StylePriority.UseForeColor = false;
            this.xr_AccountName.StylePriority.UseTextAlignment = false;
            this.xr_AccountName.Text = "xr_AccountName";
            this.xr_AccountName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel5.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.ForeColor = System.Drawing.Color.White;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(379.7632F, 52.99994F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(80.53513F, 17F);
            this.xrLabel5.StylePriority.UseBackColor = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseForeColor = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Balance B/F";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLevel
            // 
            this.xrLevel.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLevel.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLevel.BorderWidth = 1;
            this.xrLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLevel.ForeColor = System.Drawing.Color.Black;
            this.xrLevel.LocationFloat = new DevExpress.Utils.PointFloat(299.7422F, 0F);
            this.xrLevel.Name = "xrLevel";
            this.xrLevel.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLevel.SizeF = new System.Drawing.SizeF(99.8125F, 21.99999F);
            this.xrLevel.StylePriority.UseBorderColor = false;
            this.xrLevel.StylePriority.UseBorders = false;
            this.xrLevel.StylePriority.UseBorderWidth = false;
            this.xrLevel.StylePriority.UseFont = false;
            this.xrLevel.StylePriority.UseForeColor = false;
            this.xrLevel.StylePriority.UsePadding = false;
            this.xrLevel.StylePriority.UseTextAlignment = false;
            this.xrLevel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.BorderWidth = 1;
            this.xrLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(244.0831F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(55.65915F, 21.99999F);
            this.xrLabel1.StylePriority.UseBorderColor = false;
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseBorderWidth = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Level";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xr_AccountofName
            // 
            this.xr_AccountofName.BorderColor = System.Drawing.Color.SteelBlue;
            this.xr_AccountofName.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xr_AccountofName.BorderWidth = 1;
            this.xr_AccountofName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_AccountofName.ForeColor = System.Drawing.Color.Black;
            this.xr_AccountofName.LocationFloat = new DevExpress.Utils.PointFloat(92.11737F, 25F);
            this.xr_AccountofName.Name = "xr_AccountofName";
            this.xr_AccountofName.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xr_AccountofName.SizeF = new System.Drawing.SizeF(307.4374F, 21.99999F);
            this.xr_AccountofName.StylePriority.UseBorderColor = false;
            this.xr_AccountofName.StylePriority.UseBorders = false;
            this.xr_AccountofName.StylePriority.UseBorderWidth = false;
            this.xr_AccountofName.StylePriority.UseFont = false;
            this.xr_AccountofName.StylePriority.UseForeColor = false;
            this.xr_AccountofName.StylePriority.UsePadding = false;
            this.xr_AccountofName.StylePriority.UseTextAlignment = false;
            this.xr_AccountofName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel6.BorderWidth = 1;
            this.xrLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(1.041667F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(90.07584F, 21.99999F);
            this.xrLabel6.StylePriority.UseBorderColor = false;
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseBorderWidth = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseForeColor = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Account ID";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel10.BorderWidth = 1;
            this.xrLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(456.9452F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(76.40891F, 21.99999F);
            this.xrLabel10.StylePriority.UseBorderColor = false;
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseBorderWidth = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseForeColor = false;
            this.xrLabel10.StylePriority.UsePadding = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Period From";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel22
            // 
            this.xrLabel22.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel22.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.ForeColor = System.Drawing.Color.White;
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(1.041667F, 52.99994F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(24.7414F, 17F);
            this.xrLabel22.StylePriority.UseBackColor = false;
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseForeColor = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "#";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel8.BorderWidth = 1;
            this.xrLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(91.11749F, 21.99999F);
            this.xrLabel8.StylePriority.UseBorderColor = false;
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseBorderWidth = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseForeColor = false;
            this.xrLabel8.StylePriority.UsePadding = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Account Name";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel23
            // 
            this.xrLabel23.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel23.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel23.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel23.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.ForeColor = System.Drawing.Color.White;
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(601.2019F, 53F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(95.7981F, 17F);
            this.xrLabel23.StylePriority.UseBackColor = false;
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseForeColor = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "Balance C/F";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel32
            // 
            this.xrLabel32.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel32.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel32.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel32.ForeColor = System.Drawing.Color.White;
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(27.78308F, 52.99994F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(89.21677F, 17F);
            this.xrLabel32.StylePriority.UseBackColor = false;
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseForeColor = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "Account ID";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel21
            // 
            this.xrLabel21.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel21.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.ForeColor = System.Drawing.Color.White;
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(532.2501F, 53F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(65.95178F, 17F);
            this.xrLabel21.StylePriority.UseBackColor = false;
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseForeColor = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "Credit";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_ToDate
            // 
            this.xr_ToDate.BorderColor = System.Drawing.Color.SteelBlue;
            this.xr_ToDate.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xr_ToDate.BorderWidth = 1;
            this.xr_ToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_ToDate.ForeColor = System.Drawing.Color.Black;
            this.xr_ToDate.LocationFloat = new DevExpress.Utils.PointFloat(533.3542F, 25F);
            this.xr_ToDate.Name = "xr_ToDate";
            this.xr_ToDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xr_ToDate.SizeF = new System.Drawing.SizeF(163.6458F, 21.99999F);
            this.xr_ToDate.StylePriority.UseBorderColor = false;
            this.xr_ToDate.StylePriority.UseBorders = false;
            this.xr_ToDate.StylePriority.UseBorderWidth = false;
            this.xr_ToDate.StylePriority.UseFont = false;
            this.xr_ToDate.StylePriority.UseForeColor = false;
            this.xr_ToDate.StylePriority.UsePadding = false;
            this.xr_ToDate.StylePriority.UseTextAlignment = false;
            this.xr_ToDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xr_Accountof
            // 
            this.xr_Accountof.BorderColor = System.Drawing.Color.SteelBlue;
            this.xr_Accountof.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xr_Accountof.BorderWidth = 1;
            this.xr_Accountof.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_Accountof.ForeColor = System.Drawing.Color.Black;
            this.xr_Accountof.LocationFloat = new DevExpress.Utils.PointFloat(92.11737F, 0F);
            this.xr_Accountof.Name = "xr_Accountof";
            this.xr_Accountof.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xr_Accountof.SizeF = new System.Drawing.SizeF(151.9658F, 21.99999F);
            this.xr_Accountof.StylePriority.UseBorderColor = false;
            this.xr_Accountof.StylePriority.UseBorders = false;
            this.xr_Accountof.StylePriority.UseBorderWidth = false;
            this.xr_Accountof.StylePriority.UseFont = false;
            this.xr_Accountof.StylePriority.UseForeColor = false;
            this.xr_Accountof.StylePriority.UsePadding = false;
            this.xr_Accountof.StylePriority.UseTextAlignment = false;
            this.xr_Accountof.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel12.BorderWidth = 1;
            this.xrLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(456.9452F, 25F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(76.40891F, 21.99999F);
            this.xrLabel12.StylePriority.UseBorderColor = false;
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseBorderWidth = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseForeColor = false;
            this.xrLabel12.StylePriority.UsePadding = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Period Upto";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbCustomer
            // 
            this.lbCustomer.BackColor = System.Drawing.Color.SteelBlue;
            this.lbCustomer.BorderColor = System.Drawing.SystemColors.ControlText;
            this.lbCustomer.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lbCustomer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustomer.ForeColor = System.Drawing.Color.White;
            this.lbCustomer.LocationFloat = new DevExpress.Utils.PointFloat(118.9999F, 53F);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCustomer.SizeF = new System.Drawing.SizeF(257.7634F, 17F);
            this.lbCustomer.StylePriority.UseBackColor = false;
            this.lbCustomer.StylePriority.UseFont = false;
            this.lbCustomer.StylePriority.UseForeColor = false;
            this.lbCustomer.StylePriority.UseTextAlignment = false;
            this.lbCustomer.Text = "Account Name";
            this.lbCustomer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_FromDate
            // 
            this.xr_FromDate.BorderColor = System.Drawing.Color.SteelBlue;
            this.xr_FromDate.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xr_FromDate.BorderWidth = 1;
            this.xr_FromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_FromDate.ForeColor = System.Drawing.Color.Black;
            this.xr_FromDate.LocationFloat = new DevExpress.Utils.PointFloat(533.3542F, 0F);
            this.xr_FromDate.Name = "xr_FromDate";
            this.xr_FromDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xr_FromDate.SizeF = new System.Drawing.SizeF(163.6458F, 21.99999F);
            this.xr_FromDate.StylePriority.UseBorderColor = false;
            this.xr_FromDate.StylePriority.UseBorders = false;
            this.xr_FromDate.StylePriority.UseBorderWidth = false;
            this.xr_FromDate.StylePriority.UseFont = false;
            this.xr_FromDate.StylePriority.UseForeColor = false;
            this.xr_FromDate.StylePriority.UsePadding = false;
            this.xr_FromDate.StylePriority.UseTextAlignment = false;
            this.xr_FromDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.BackColor = System.Drawing.Color.SteelBlue;
            this.xrLabel20.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.ForeColor = System.Drawing.Color.White;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(463.2983F, 53F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(65.95178F, 17F);
            this.xrLabel20.StylePriority.UseBackColor = false;
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseForeColor = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Debit";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 32F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 48F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.RepH_Company,
            this.RepH_DocumentName});
            this.ReportHeader.HeightF = 33F;
            this.ReportHeader.Name = "ReportHeader";
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
            this.RepH_Company.SizeF = new System.Drawing.SizeF(399.5549F, 26.58333F);
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
            this.RepH_DocumentName.LocationFloat = new DevExpress.Utils.PointFloat(455.9453F, 0F);
            this.RepH_DocumentName.Name = "RepH_DocumentName";
            this.RepH_DocumentName.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.RepH_DocumentName.SizeF = new System.Drawing.SizeF(241.0547F, 26.58333F);
            this.RepH_DocumentName.StylePriority.UseBorderColor = false;
            this.RepH_DocumentName.StylePriority.UseBorders = false;
            this.RepH_DocumentName.StylePriority.UseBorderWidth = false;
            this.RepH_DocumentName.StylePriority.UseFont = false;
            this.RepH_DocumentName.StylePriority.UsePadding = false;
            this.RepH_DocumentName.StylePriority.UseTextAlignment = false;
            this.RepH_DocumentName.Text = "Consolidated Ledger";
            this.RepH_DocumentName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xr_FromDate,
            this.xrLabel20,
            this.lbCustomer,
            this.xrLabel12,
            this.xr_Accountof,
            this.xr_ToDate,
            this.xrLabel21,
            this.xrLabel32,
            this.xrLabel23,
            this.xrLabel8,
            this.xrLabel22,
            this.xrLabel10,
            this.xrLabel6,
            this.xr_AccountofName,
            this.xrLabel1,
            this.xrLevel,
            this.xrLabel5});
            this.PageHeader.HeightF = 75F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.FinancialYear,
            this.xrLabel27,
            this.xrLabel9,
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.PageFooter.HeightF = 20.95832F;
            this.PageFooter.Name = "PageFooter";
            // 
            // FinancialYear
            // 
            this.FinancialYear.BackColor = System.Drawing.Color.Black;
            this.FinancialYear.BorderColor = System.Drawing.Color.Black;
            this.FinancialYear.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.FinancialYear.BorderWidth = 1;
            this.FinancialYear.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinancialYear.ForeColor = System.Drawing.Color.White;
            this.FinancialYear.LocationFloat = new DevExpress.Utils.PointFloat(632.9339F, 0F);
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
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(537.6176F, 0F);
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
            // xrLabel9
            // 
            this.xrLabel9.BorderColor = System.Drawing.Color.SteelBlue;
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel9.BorderWidth = 1;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(53.13837F, 15.66666F);
            this.xrLabel9.StylePriority.UseBorderColor = false;
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseBorderWidth = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseForeColor = false;
            this.xrLabel9.StylePriority.UsePadding = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Page";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(53.13838F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(50.68726F, 15.66666F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Format = "{0:dddd, dd MMMM, yyyy h:mm tt}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(170.3518F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(229.2029F, 15.66666F);
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xr_TotalBalanceBF,
            this.xr_TotalBalanceCF,
            this.xr_TotalCredit,
            this.xr_TotalDebit});
            this.ReportFooter.HeightF = 23F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xr_TotalBalanceBF
            // 
            this.xr_TotalBalanceBF.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xr_TotalBalanceBF.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xr_TotalBalanceBF.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalBalanceBF")});
            this.xr_TotalBalanceBF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_TotalBalanceBF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xr_TotalBalanceBF.LocationFloat = new DevExpress.Utils.PointFloat(379.7632F, 0F);
            this.xr_TotalBalanceBF.Name = "xr_TotalBalanceBF";
            this.xr_TotalBalanceBF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xr_TotalBalanceBF.SizeF = new System.Drawing.SizeF(79.43091F, 19F);
            this.xr_TotalBalanceBF.StylePriority.UseBorders = false;
            this.xr_TotalBalanceBF.StylePriority.UseFont = false;
            this.xr_TotalBalanceBF.StylePriority.UseForeColor = false;
            this.xr_TotalBalanceBF.StylePriority.UsePadding = false;
            this.xr_TotalBalanceBF.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:#,#;(#,#)}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xr_TotalBalanceBF.Summary = xrSummary1;
            this.xr_TotalBalanceBF.Text = "xr_TotalBalanceBF";
            this.xr_TotalBalanceBF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xr_TotalBalanceCF
            // 
            this.xr_TotalBalanceCF.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xr_TotalBalanceCF.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xr_TotalBalanceCF.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalBalanceCF")});
            this.xr_TotalBalanceCF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_TotalBalanceCF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xr_TotalBalanceCF.LocationFloat = new DevExpress.Utils.PointFloat(601.2019F, 0F);
            this.xr_TotalBalanceCF.Name = "xr_TotalBalanceCF";
            this.xr_TotalBalanceCF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xr_TotalBalanceCF.SizeF = new System.Drawing.SizeF(95.7981F, 19F);
            this.xr_TotalBalanceCF.StylePriority.UseBorders = false;
            this.xr_TotalBalanceCF.StylePriority.UseFont = false;
            this.xr_TotalBalanceCF.StylePriority.UseForeColor = false;
            this.xr_TotalBalanceCF.StylePriority.UsePadding = false;
            this.xr_TotalBalanceCF.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:#,#;(#,#)}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xr_TotalBalanceCF.Summary = xrSummary2;
            this.xr_TotalBalanceCF.Text = "xr_TotalCredit";
            this.xr_TotalBalanceCF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xr_TotalCredit
            // 
            this.xr_TotalCredit.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xr_TotalCredit.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xr_TotalCredit.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalCredit")});
            this.xr_TotalCredit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_TotalCredit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xr_TotalCredit.LocationFloat = new DevExpress.Utils.PointFloat(533.3542F, 0F);
            this.xr_TotalCredit.Name = "xr_TotalCredit";
            this.xr_TotalCredit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xr_TotalCredit.SizeF = new System.Drawing.SizeF(64.84772F, 19F);
            this.xr_TotalCredit.StylePriority.UseBorders = false;
            this.xr_TotalCredit.StylePriority.UseFont = false;
            this.xr_TotalCredit.StylePriority.UseForeColor = false;
            this.xr_TotalCredit.StylePriority.UsePadding = false;
            this.xr_TotalCredit.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:#,#}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xr_TotalCredit.Summary = xrSummary3;
            this.xr_TotalCredit.Text = "xr_TotalCredit";
            this.xr_TotalCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xr_TotalDebit
            // 
            this.xr_TotalDebit.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xr_TotalDebit.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xr_TotalDebit.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalDebit")});
            this.xr_TotalDebit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xr_TotalDebit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xr_TotalDebit.LocationFloat = new DevExpress.Utils.PointFloat(463.2983F, 0F);
            this.xr_TotalDebit.Name = "xr_TotalDebit";
            this.xr_TotalDebit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.xr_TotalDebit.SizeF = new System.Drawing.SizeF(64.84784F, 19F);
            this.xr_TotalDebit.StylePriority.UseBorders = false;
            this.xr_TotalDebit.StylePriority.UseFont = false;
            this.xr_TotalDebit.StylePriority.UseForeColor = false;
            this.xr_TotalDebit.StylePriority.UsePadding = false;
            this.xr_TotalDebit.StylePriority.UseTextAlignment = false;
            xrSummary4.FormatString = "{0:#,#}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xr_TotalDebit.Summary = xrSummary4;
            this.xr_TotalDebit.Text = "xr_TotalDebit";
            this.xr_TotalDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Accounts_LedgerConsolidated
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.PageFooter,
            this.ReportFooter});
            this.Margins = new System.Drawing.Printing.Margins(100, 52, 32, 48);
            this.SnapToGrid = false;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        public DevExpress.XtraReports.UI.XRLabel RepH_Company;
        public DevExpress.XtraReports.UI.XRLabel RepH_DocumentName;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        public DevExpress.XtraReports.UI.XRLabel xrLevel;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        public DevExpress.XtraReports.UI.XRLabel xr_AccountofName;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel32;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        public DevExpress.XtraReports.UI.XRLabel xr_ToDate;
        public DevExpress.XtraReports.UI.XRLabel xr_Accountof;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel lbCustomer;
        public DevExpress.XtraReports.UI.XRLabel xr_FromDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xr_Debit;
        private DevExpress.XtraReports.UI.XRLabel xr_AccountID;
        private DevExpress.XtraReports.UI.XRLabel xr_Index;
        private DevExpress.XtraReports.UI.XRLabel xr_BalanceBF;
        private DevExpress.XtraReports.UI.XRLabel xr_AccountName;
        private DevExpress.XtraReports.UI.XRLabel xr_Credit;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xr_BalanceCF;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xr_TotalDebit;
        private DevExpress.XtraReports.UI.XRLabel xr_TotalCredit;
        private DevExpress.XtraReports.UI.XRLabel xr_TotalBalanceCF;
        private DevExpress.XtraReports.UI.XRLabel xr_TotalBalanceBF;
        private DevExpress.XtraReports.UI.XRLabel FinancialYear;
        private DevExpress.XtraReports.UI.XRLabel xrLabel27;
    }
}
