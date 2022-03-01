namespace MachineEyes.Reports
{
    partial class XtraReport1
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
            this.PileBlend_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PileBlend_0 = new DevExpress.XtraReports.UI.XRLabel();
            this.PileWastage_0 = new DevExpress.XtraReports.UI.XRLabel();
            this.PilePly_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.WarpSlash_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PileWastage_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.WarpSlash_0 = new DevExpress.XtraReports.UI.XRLabel();
            this.PileCount_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PileLbs_0 = new DevExpress.XtraReports.UI.XRLabel();
            this.PileDesc_0 = new DevExpress.XtraReports.UI.XRLabel();
            this.PileBags_0 = new DevExpress.XtraReports.UI.XRLabel();
            this.PileRatio_0 = new DevExpress.XtraReports.UI.XRLabel();
            this.PileCount_0 = new DevExpress.XtraReports.UI.XRLabel();
            this.PilePly_0 = new DevExpress.XtraReports.UI.XRLabel();
            this.PileRatio_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PileBags_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PileDesc_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PileLbs_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.dailyShift_Summary1 = new MachineEyes.DataTables.DailyShift_Summary();
            this.rP_DailyShiftSummaryTableAdapter = new MachineEyes.DataTables.DailyShift_SummaryTableAdapters.RP_DailyShiftSummaryTableAdapter();
            this.calculatedField1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.CalculatedFieldX = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dailyShift_Summary1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.PileBlend_1,
            this.PileBlend_0,
            this.PileWastage_0,
            this.PilePly_1,
            this.WarpSlash_1,
            this.PileWastage_1,
            this.WarpSlash_0,
            this.PileCount_1,
            this.PileLbs_0,
            this.PileDesc_0,
            this.PileBags_0,
            this.PileRatio_0,
            this.PileCount_0,
            this.PilePly_0,
            this.PileRatio_1,
            this.PileBags_1,
            this.PileDesc_1,
            this.PileLbs_1});
            this.Detail.HeightF = 144F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PileBlend_1
            // 
            this.PileBlend_1.BackColor = System.Drawing.Color.White;
            this.PileBlend_1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PileBlend_1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PileBlend_1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnBlend_1")});
            this.PileBlend_1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.PileBlend_1.LocationFloat = new DevExpress.Utils.PointFloat(135.8305F, 24.79165F);
            this.PileBlend_1.Name = "PileBlend_1";
            this.PileBlend_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PileBlend_1.SizeF = new System.Drawing.SizeF(58.37115F, 17F);
            this.PileBlend_1.StylePriority.UseBackColor = false;
            this.PileBlend_1.StylePriority.UseBorderColor = false;
            this.PileBlend_1.StylePriority.UseBorders = false;
            this.PileBlend_1.StylePriority.UseTextAlignment = false;
            this.PileBlend_1.Text = "YarnBagsType";
            this.PileBlend_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.PileBlend_1.WordWrap = false;
            // 
            // PileBlend_0
            // 
            this.PileBlend_0.BackColor = System.Drawing.Color.White;
            this.PileBlend_0.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PileBlend_0.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PileBlend_0.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnBlend_0")});
            this.PileBlend_0.Font = new System.Drawing.Font("Tahoma", 8F);
            this.PileBlend_0.LocationFloat = new DevExpress.Utils.PointFloat(70.521F, 24.79165F);
            this.PileBlend_0.Name = "PileBlend_0";
            this.PileBlend_0.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PileBlend_0.SizeF = new System.Drawing.SizeF(58.37128F, 17F);
            this.PileBlend_0.StylePriority.UseBackColor = false;
            this.PileBlend_0.StylePriority.UseBorderColor = false;
            this.PileBlend_0.StylePriority.UseBorders = false;
            this.PileBlend_0.StylePriority.UseTextAlignment = false;
            this.PileBlend_0.Text = "YarnBagsType";
            this.PileBlend_0.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.PileBlend_0.WordWrap = false;
            // 
            // PileWastage_0
            // 
            this.PileWastage_0.BackColor = System.Drawing.Color.White;
            this.PileWastage_0.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PileWastage_0.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PileWastage_0.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnWastage_0")});
            this.PileWastage_0.Font = new System.Drawing.Font("Tahoma", 8F);
            this.PileWastage_0.LocationFloat = new DevExpress.Utils.PointFloat(70.521F, 82.125F);
            this.PileWastage_0.Name = "PileWastage_0";
            this.PileWastage_0.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PileWastage_0.SizeF = new System.Drawing.SizeF(58.37122F, 17F);
            this.PileWastage_0.StylePriority.UseBackColor = false;
            this.PileWastage_0.StylePriority.UseBorderColor = false;
            this.PileWastage_0.StylePriority.UseBorders = false;
            this.PileWastage_0.StylePriority.UseTextAlignment = false;
            this.PileWastage_0.Text = "YarnBagsType";
            this.PileWastage_0.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.PileWastage_0.WordWrap = false;
            // 
            // PilePly_1
            // 
            this.PilePly_1.BackColor = System.Drawing.Color.White;
            this.PilePly_1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PilePly_1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PilePly_1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnPly_1")});
            this.PilePly_1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.PilePly_1.LocationFloat = new DevExpress.Utils.PointFloat(175.1841F, 5.791664F);
            this.PilePly_1.Name = "PilePly_1";
            this.PilePly_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PilePly_1.SizeF = new System.Drawing.SizeF(19.01767F, 17F);
            this.PilePly_1.StylePriority.UseBackColor = false;
            this.PilePly_1.StylePriority.UseBorderColor = false;
            this.PilePly_1.StylePriority.UseBorders = false;
            this.PilePly_1.StylePriority.UseTextAlignment = false;
            this.PilePly_1.Text = "YarnBagsType";
            this.PilePly_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.PilePly_1.WordWrap = false;
            // 
            // WarpSlash_1
            // 
            this.WarpSlash_1.BackColor = System.Drawing.Color.White;
            this.WarpSlash_1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.WarpSlash_1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.WarpSlash_1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.WarpSlash_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.WarpSlash_1.LocationFloat = new DevExpress.Utils.PointFloat(164.343F, 5.791664F);
            this.WarpSlash_1.Name = "WarpSlash_1";
            this.WarpSlash_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.WarpSlash_1.SizeF = new System.Drawing.SizeF(10.84106F, 17F);
            this.WarpSlash_1.StylePriority.UseBackColor = false;
            this.WarpSlash_1.StylePriority.UseBorderColor = false;
            this.WarpSlash_1.StylePriority.UseBorders = false;
            this.WarpSlash_1.StylePriority.UseFont = false;
            this.WarpSlash_1.StylePriority.UseTextAlignment = false;
            this.WarpSlash_1.Text = "/";
            this.WarpSlash_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PileWastage_1
            // 
            this.PileWastage_1.BackColor = System.Drawing.Color.White;
            this.PileWastage_1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PileWastage_1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PileWastage_1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnWastage_1")});
            this.PileWastage_1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.PileWastage_1.LocationFloat = new DevExpress.Utils.PointFloat(135.8305F, 82.125F);
            this.PileWastage_1.Name = "PileWastage_1";
            this.PileWastage_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PileWastage_1.SizeF = new System.Drawing.SizeF(58.37122F, 17F);
            this.PileWastage_1.StylePriority.UseBackColor = false;
            this.PileWastage_1.StylePriority.UseBorderColor = false;
            this.PileWastage_1.StylePriority.UseBorders = false;
            this.PileWastage_1.StylePriority.UseTextAlignment = false;
            this.PileWastage_1.Text = "YarnBagsType";
            this.PileWastage_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.PileWastage_1.WordWrap = false;
            // 
            // WarpSlash_0
            // 
            this.WarpSlash_0.BackColor = System.Drawing.Color.White;
            this.WarpSlash_0.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.WarpSlash_0.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.WarpSlash_0.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.WarpSlash_0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(157)))), ((int)(((byte)(134)))));
            this.WarpSlash_0.LocationFloat = new DevExpress.Utils.PointFloat(99.03355F, 5.791664F);
            this.WarpSlash_0.Name = "WarpSlash_0";
            this.WarpSlash_0.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.WarpSlash_0.SizeF = new System.Drawing.SizeF(10.84106F, 17F);
            this.WarpSlash_0.StylePriority.UseBackColor = false;
            this.WarpSlash_0.StylePriority.UseBorderColor = false;
            this.WarpSlash_0.StylePriority.UseBorders = false;
            this.WarpSlash_0.StylePriority.UseFont = false;
            this.WarpSlash_0.StylePriority.UseTextAlignment = false;
            this.WarpSlash_0.Text = "/";
            this.WarpSlash_0.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PileCount_1
            // 
            this.PileCount_1.BackColor = System.Drawing.Color.White;
            this.PileCount_1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PileCount_1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PileCount_1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnCount_1")});
            this.PileCount_1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.PileCount_1.LocationFloat = new DevExpress.Utils.PointFloat(135.8305F, 5.791664F);
            this.PileCount_1.Name = "PileCount_1";
            this.PileCount_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PileCount_1.SizeF = new System.Drawing.SizeF(28.51245F, 17F);
            this.PileCount_1.StylePriority.UseBackColor = false;
            this.PileCount_1.StylePriority.UseBorderColor = false;
            this.PileCount_1.StylePriority.UseBorders = false;
            this.PileCount_1.StylePriority.UseTextAlignment = false;
            this.PileCount_1.Text = "YarnBagsType";
            this.PileCount_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.PileCount_1.WordWrap = false;
            // 
            // PileLbs_0
            // 
            this.PileLbs_0.BackColor = System.Drawing.Color.White;
            this.PileLbs_0.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PileLbs_0.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PileLbs_0.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnLbsRequired_0", "{0:#.00}")});
            this.PileLbs_0.Font = new System.Drawing.Font("Tahoma", 8F);
            this.PileLbs_0.LocationFloat = new DevExpress.Utils.PointFloat(70.5211F, 120.125F);
            this.PileLbs_0.Name = "PileLbs_0";
            this.PileLbs_0.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PileLbs_0.SizeF = new System.Drawing.SizeF(58.37115F, 16.99999F);
            this.PileLbs_0.StylePriority.UseBackColor = false;
            this.PileLbs_0.StylePriority.UseBorderColor = false;
            this.PileLbs_0.StylePriority.UseBorders = false;
            this.PileLbs_0.StylePriority.UseTextAlignment = false;
            this.PileLbs_0.Text = "PileLbs_0";
            this.PileLbs_0.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PileDesc_0
            // 
            this.PileDesc_0.BackColor = System.Drawing.Color.White;
            this.PileDesc_0.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PileDesc_0.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PileDesc_0.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnDesc_0")});
            this.PileDesc_0.Font = new System.Drawing.Font("Tahoma", 8F);
            this.PileDesc_0.LocationFloat = new DevExpress.Utils.PointFloat(70.521F, 43.79165F);
            this.PileDesc_0.Name = "PileDesc_0";
            this.PileDesc_0.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PileDesc_0.SizeF = new System.Drawing.SizeF(58.37122F, 17F);
            this.PileDesc_0.StylePriority.UseBackColor = false;
            this.PileDesc_0.StylePriority.UseBorderColor = false;
            this.PileDesc_0.StylePriority.UseBorders = false;
            this.PileDesc_0.StylePriority.UseTextAlignment = false;
            this.PileDesc_0.Text = "PileDesc_0";
            this.PileDesc_0.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.PileDesc_0.WordWrap = false;
            // 
            // PileBags_0
            // 
            this.PileBags_0.BackColor = System.Drawing.Color.White;
            this.PileBags_0.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PileBags_0.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PileBags_0.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnBagsRequired_0", "{0:n2}")});
            this.PileBags_0.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PileBags_0.LocationFloat = new DevExpress.Utils.PointFloat(70.5211F, 101.125F);
            this.PileBags_0.Name = "PileBags_0";
            this.PileBags_0.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PileBags_0.SizeF = new System.Drawing.SizeF(58.37109F, 17.00002F);
            this.PileBags_0.StylePriority.UseBackColor = false;
            this.PileBags_0.StylePriority.UseBorderColor = false;
            this.PileBags_0.StylePriority.UseBorders = false;
            this.PileBags_0.StylePriority.UseFont = false;
            this.PileBags_0.StylePriority.UseTextAlignment = false;
            this.PileBags_0.Text = "PileBags_0";
            this.PileBags_0.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PileRatio_0
            // 
            this.PileRatio_0.BackColor = System.Drawing.Color.White;
            this.PileRatio_0.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PileRatio_0.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PileRatio_0.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnRatio_0")});
            this.PileRatio_0.Font = new System.Drawing.Font("Tahoma", 8F);
            this.PileRatio_0.LocationFloat = new DevExpress.Utils.PointFloat(70.5211F, 62.7916F);
            this.PileRatio_0.Name = "PileRatio_0";
            this.PileRatio_0.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PileRatio_0.SizeF = new System.Drawing.SizeF(58.37115F, 17F);
            this.PileRatio_0.StylePriority.UseBackColor = false;
            this.PileRatio_0.StylePriority.UseBorderColor = false;
            this.PileRatio_0.StylePriority.UseBorders = false;
            this.PileRatio_0.StylePriority.UseTextAlignment = false;
            this.PileRatio_0.Text = "YarnBagsType";
            this.PileRatio_0.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.PileRatio_0.WordWrap = false;
            // 
            // PileCount_0
            // 
            this.PileCount_0.BackColor = System.Drawing.Color.White;
            this.PileCount_0.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PileCount_0.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PileCount_0.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnCount_0")});
            this.PileCount_0.Font = new System.Drawing.Font("Tahoma", 8F);
            this.PileCount_0.LocationFloat = new DevExpress.Utils.PointFloat(70.5211F, 5.791664F);
            this.PileCount_0.Name = "PileCount_0";
            this.PileCount_0.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PileCount_0.SizeF = new System.Drawing.SizeF(28.51245F, 17F);
            this.PileCount_0.StylePriority.UseBackColor = false;
            this.PileCount_0.StylePriority.UseBorderColor = false;
            this.PileCount_0.StylePriority.UseBorders = false;
            this.PileCount_0.StylePriority.UseTextAlignment = false;
            this.PileCount_0.Text = "YarnBagsType";
            this.PileCount_0.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.PileCount_0.WordWrap = false;
            // 
            // PilePly_0
            // 
            this.PilePly_0.BackColor = System.Drawing.Color.White;
            this.PilePly_0.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PilePly_0.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PilePly_0.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnPly_0")});
            this.PilePly_0.Font = new System.Drawing.Font("Tahoma", 8F);
            this.PilePly_0.LocationFloat = new DevExpress.Utils.PointFloat(109.8746F, 5.791664F);
            this.PilePly_0.Name = "PilePly_0";
            this.PilePly_0.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PilePly_0.SizeF = new System.Drawing.SizeF(19.01767F, 17F);
            this.PilePly_0.StylePriority.UseBackColor = false;
            this.PilePly_0.StylePriority.UseBorderColor = false;
            this.PilePly_0.StylePriority.UseBorders = false;
            this.PilePly_0.StylePriority.UseTextAlignment = false;
            this.PilePly_0.Text = "YarnBagsType";
            this.PilePly_0.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.PilePly_0.WordWrap = false;
            // 
            // PileRatio_1
            // 
            this.PileRatio_1.BackColor = System.Drawing.Color.White;
            this.PileRatio_1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PileRatio_1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PileRatio_1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnRatio_1")});
            this.PileRatio_1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.PileRatio_1.LocationFloat = new DevExpress.Utils.PointFloat(135.8305F, 62.7916F);
            this.PileRatio_1.Name = "PileRatio_1";
            this.PileRatio_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PileRatio_1.SizeF = new System.Drawing.SizeF(58.37122F, 17F);
            this.PileRatio_1.StylePriority.UseBackColor = false;
            this.PileRatio_1.StylePriority.UseBorderColor = false;
            this.PileRatio_1.StylePriority.UseBorders = false;
            this.PileRatio_1.StylePriority.UseTextAlignment = false;
            this.PileRatio_1.Text = "YarnBagsType";
            this.PileRatio_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.PileRatio_1.WordWrap = false;
            // 
            // PileBags_1
            // 
            this.PileBags_1.BackColor = System.Drawing.Color.White;
            this.PileBags_1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PileBags_1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PileBags_1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnBagsRequired_1", "{0:n2}")});
            this.PileBags_1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PileBags_1.LocationFloat = new DevExpress.Utils.PointFloat(135.8307F, 101.125F);
            this.PileBags_1.Name = "PileBags_1";
            this.PileBags_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PileBags_1.SizeF = new System.Drawing.SizeF(58.37109F, 17.00002F);
            this.PileBags_1.StylePriority.UseBackColor = false;
            this.PileBags_1.StylePriority.UseBorderColor = false;
            this.PileBags_1.StylePriority.UseBorders = false;
            this.PileBags_1.StylePriority.UseFont = false;
            this.PileBags_1.StylePriority.UseTextAlignment = false;
            this.PileBags_1.Text = "PileBags_1";
            this.PileBags_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PileDesc_1
            // 
            this.PileDesc_1.BackColor = System.Drawing.Color.White;
            this.PileDesc_1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PileDesc_1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PileDesc_1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnDesc_1")});
            this.PileDesc_1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.PileDesc_1.LocationFloat = new DevExpress.Utils.PointFloat(135.8305F, 43.79165F);
            this.PileDesc_1.Name = "PileDesc_1";
            this.PileDesc_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PileDesc_1.SizeF = new System.Drawing.SizeF(58.37122F, 17F);
            this.PileDesc_1.StylePriority.UseBackColor = false;
            this.PileDesc_1.StylePriority.UseBorderColor = false;
            this.PileDesc_1.StylePriority.UseBorders = false;
            this.PileDesc_1.StylePriority.UseTextAlignment = false;
            this.PileDesc_1.Text = "YarnBagsType";
            this.PileDesc_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.PileDesc_1.WordWrap = false;
            // 
            // PileLbs_1
            // 
            this.PileLbs_1.BackColor = System.Drawing.Color.White;
            this.PileLbs_1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PileLbs_1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.PileLbs_1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PileYarnLbsRequired_1", "{0:#.00}")});
            this.PileLbs_1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.PileLbs_1.LocationFloat = new DevExpress.Utils.PointFloat(135.8307F, 120.125F);
            this.PileLbs_1.Name = "PileLbs_1";
            this.PileLbs_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PileLbs_1.SizeF = new System.Drawing.SizeF(58.37115F, 16.99999F);
            this.PileLbs_1.StylePriority.UseBackColor = false;
            this.PileLbs_1.StylePriority.UseBorderColor = false;
            this.PileLbs_1.StylePriority.UseBorders = false;
            this.PileLbs_1.StylePriority.UseTextAlignment = false;
            this.PileLbs_1.Text = "Lbs";
            this.PileLbs_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CalculatedFieldX});
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dailyShift_Summary1
            // 
            this.dailyShift_Summary1.DataSetName = "DailyShift_Summary";
            this.dailyShift_Summary1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rP_DailyShiftSummaryTableAdapter
            // 
            this.rP_DailyShiftSummaryTableAdapter.ClearBeforeFill = true;
            // 
            // calculatedField1
            // 
            this.calculatedField1.DataMember = "RP_DailyShiftSummary";
            this.calculatedField1.DataSource = this.dailyShift_Summary1;
            this.calculatedField1.Expression = "sum([A_Eff])*sum([A_RPM])";
            this.calculatedField1.Name = "calculatedField1";
            // 
            // CalculatedFieldX
            // 
            this.CalculatedFieldX.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RP_DailyShiftSummary.calculatedField1")});
            this.CalculatedFieldX.LocationFloat = new DevExpress.Utils.PointFloat(94.20166F, 0F);
            this.CalculatedFieldX.Name = "CalculatedFieldX";
            this.CalculatedFieldX.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CalculatedFieldX.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.CalculatedFieldX.Text = "CalculatedFieldX";
            // 
            // XtraReport1
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.calculatedField1});
            this.DataAdapter = this.rP_DailyShiftSummaryTableAdapter;
            this.DataMember = "RP_DailyShiftSummary";
            this.DataSource = this.dailyShift_Summary1;
            this.SnapToGrid = false;
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.dailyShift_Summary1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel PileBlend_1;
        private DevExpress.XtraReports.UI.XRLabel PileBlend_0;
        private DevExpress.XtraReports.UI.XRLabel PileWastage_0;
        private DevExpress.XtraReports.UI.XRLabel PilePly_1;
        private DevExpress.XtraReports.UI.XRLabel WarpSlash_1;
        private DevExpress.XtraReports.UI.XRLabel PileWastage_1;
        private DevExpress.XtraReports.UI.XRLabel WarpSlash_0;
        private DevExpress.XtraReports.UI.XRLabel PileCount_1;
        private DevExpress.XtraReports.UI.XRLabel PileLbs_0;
        private DevExpress.XtraReports.UI.XRLabel PileDesc_0;
        private DevExpress.XtraReports.UI.XRLabel PileBags_0;
        private DevExpress.XtraReports.UI.XRLabel PileRatio_0;
        private DevExpress.XtraReports.UI.XRLabel PileCount_0;
        private DevExpress.XtraReports.UI.XRLabel PilePly_0;
        private DevExpress.XtraReports.UI.XRLabel PileRatio_1;
        private DevExpress.XtraReports.UI.XRLabel PileBags_1;
        private DevExpress.XtraReports.UI.XRLabel PileDesc_1;
        private DevExpress.XtraReports.UI.XRLabel PileLbs_1;
        private DevExpress.XtraReports.UI.XRLabel CalculatedFieldX;
        private DataTables.DailyShift_Summary dailyShift_Summary1;
        private DataTables.DailyShift_SummaryTableAdapters.RP_DailyShiftSummaryTableAdapter rP_DailyShiftSummaryTableAdapter;
        private DevExpress.XtraReports.UI.CalculatedField calculatedField1;
    }
}
