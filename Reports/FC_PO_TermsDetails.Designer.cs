namespace MachineEyes.Reports
{
    partial class FC_PO_TermsDetails
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
            this.index = new DevExpress.XtraReports.UI.XRLabel();
            this.Terms = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.TermsType = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.index,
            this.Terms});
            this.Detail.HeightF = 17F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // index
            // 
            this.index.BackColor = System.Drawing.Color.White;
            this.index.BorderColor = System.Drawing.Color.LightGray;
            this.index.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.index.BorderWidth = 1;
            this.index.CanGrow = false;
            this.index.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.index.ForeColor = System.Drawing.Color.Black;
            this.index.LocationFloat = new DevExpress.Utils.PointFloat(35.23892F, 0F);
            this.index.Name = "index";
            this.index.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.index.SizeF = new System.Drawing.SizeF(19.96941F, 16F);
            this.index.StylePriority.UseBackColor = false;
            this.index.StylePriority.UseBorderColor = false;
            this.index.StylePriority.UseBorders = false;
            this.index.StylePriority.UseBorderWidth = false;
            this.index.StylePriority.UseFont = false;
            this.index.StylePriority.UseForeColor = false;
            this.index.StylePriority.UsePadding = false;
            this.index.StylePriority.UseTextAlignment = false;
            this.index.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.index.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.index_BeforePrint);
            // 
            // Terms
            // 
            this.Terms.BackColor = System.Drawing.Color.White;
            this.Terms.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Terms.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Terms.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Terms")});
            this.Terms.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Terms.LocationFloat = new DevExpress.Utils.PointFloat(55.20833F, 0F);
            this.Terms.Name = "Terms";
            this.Terms.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Terms.SizeF = new System.Drawing.SizeF(295.3521F, 16F);
            this.Terms.StylePriority.UseBackColor = false;
            this.Terms.StylePriority.UseBorderColor = false;
            this.Terms.StylePriority.UseBorders = false;
            this.Terms.StylePriority.UseFont = false;
            this.Terms.StylePriority.UseTextAlignment = false;
            this.Terms.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.TermsType});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("TermsTypeID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 20F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.GroupHeader1_BeforePrint);
            // 
            // TermsType
            // 
            this.TermsType.BackColor = System.Drawing.Color.White;
            this.TermsType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TermsType.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TermsType.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TermsTypeName")});
            this.TermsType.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TermsType.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0.8333842F);
            this.TermsType.Name = "TermsType";
            this.TermsType.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TermsType.SizeF = new System.Drawing.SizeF(219.2577F, 15.16662F);
            this.TermsType.StylePriority.UseBackColor = false;
            this.TermsType.StylePriority.UseBorderColor = false;
            this.TermsType.StylePriority.UseBorders = false;
            this.TermsType.StylePriority.UseFont = false;
            this.TermsType.StylePriority.UseTextAlignment = false;
            this.TermsType.Text = "TermsType";
            this.TermsType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // FC_PO_TermsDetails
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1});
            this.Margins = new System.Drawing.Printing.Margins(100, 396, 0, 0);
            this.SnapToGrid = false;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel Terms;
        private DevExpress.XtraReports.UI.XRLabel TermsType;
        private DevExpress.XtraReports.UI.XRLabel index;
    }
}
