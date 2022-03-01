namespace MachineEyes.Reports
{
    partial class SW_SizingSheet_Self
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
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.WarpProgNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalSizedBeams = new DevExpress.XtraReports.UI.XRLabel();
            this.vUserInputDateTime = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.vUser = new DevExpress.XtraReports.UI.XRLabel();
            this.vSecurityNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.vStatus = new DevExpress.XtraReports.UI.XRLabel();
            this.vUserID = new DevExpress.XtraReports.UI.XRLabel();
            this.vInputMode = new DevExpress.XtraReports.UI.XRLabel();
            this.vBarcode = new DevExpress.XtraReports.UI.XRBarCode();
            this.vCategory = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.SizingDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.SetNo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.Breakages = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Remarks = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.SizingMachine = new DevExpress.XtraReports.UI.XRLabel();
            this.StartTime = new DevExpress.XtraReports.UI.XRLabel();
            this.WarpingProgramNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.EndTime = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.BeamRemarks = new DevExpress.XtraReports.UI.XRLabel();
            this.BeamShift = new DevExpress.XtraReports.UI.XRLabel();
            this.BeamSizer = new DevExpress.XtraReports.UI.XRLabel();
            this.BeamGrossWeight = new DevExpress.XtraReports.UI.XRLabel();
            this.BeamPressure = new DevExpress.XtraReports.UI.XRLabel();
            this.BeamSpeed = new DevExpress.XtraReports.UI.XRLabel();
            this.BeamLength = new DevExpress.XtraReports.UI.XRLabel();
            this.BeamNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.IndexNo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.BeamLength,
            this.BeamSpeed,
            this.IndexNo,
            this.BeamNumber,
            this.BeamPressure,
            this.BeamShift,
            this.BeamRemarks,
            this.BeamGrossWeight,
            this.BeamSizer});
            this.Detail.HeightF = 20F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 23F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel7,
            this.EndTime,
            this.xrLabel14,
            this.xrLabel5,
            this.SizingMachine,
            this.StartTime,
            this.xrLabel11,
            this.Remarks,
            this.xrLabel18,
            this.xrLabel9,
            this.WarpingProgramNumber,
            this.xrLabel22,
            this.vStatus,
            this.xrLabel21,
            this.vUserID,
            this.vBarcode,
            this.vInputMode,
            this.vSecurityNumber,
            this.TotalSizedBeams,
            this.WarpProgNumber,
            this.vUserInputDateTime,
            this.vUser,
            this.xrLabel19,
            this.SetNo,
            this.xrLabel6,
            this.Breakages,
            this.xrLabel24,
            this.xrLabel4,
            this.xrLabel3,
            this.vCategory,
            this.SizingDate,
            this.xrLabel23,
            this.xrLabel8});
            this.ReportHeader.HeightF = 171F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel28,
            this.xrLabel27,
            this.xrLabel41,
            this.xrLabel54,
            this.xrLabel29,
            this.xrLabel32,
            this.xrLabel33,
            this.xrLabel30,
            this.xrLabel31});
            this.PageHeader.HeightF = 20F;
            this.PageHeader.Name = "PageHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrLine1,
            this.xrLine4,
            this.xrLabel2,
            this.xrLabel10,
            this.xrLabel12});
            this.ReportFooter.Name = "ReportFooter";
            // 
            // PageFooter
            // 
            this.PageFooter.Name = "PageFooter";
            // 
            // WarpProgNumber
            // 
            this.WarpProgNumber.BorderColor = System.Drawing.Color.Silver;
            this.WarpProgNumber.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.WarpProgNumber.BorderWidth = 1;
            this.WarpProgNumber.CanGrow = false;
            this.WarpProgNumber.Font = new System.Drawing.Font("Digital-7", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarpProgNumber.ForeColor = System.Drawing.Color.Black;
            this.WarpProgNumber.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.WarpProgNumber.Name = "WarpProgNumber";
            this.WarpProgNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.WarpProgNumber.SizeF = new System.Drawing.SizeF(140.7651F, 27.28999F);
            this.WarpProgNumber.StylePriority.UseBorderColor = false;
            this.WarpProgNumber.StylePriority.UseBorders = false;
            this.WarpProgNumber.StylePriority.UseBorderWidth = false;
            this.WarpProgNumber.StylePriority.UseFont = false;
            this.WarpProgNumber.StylePriority.UseForeColor = false;
            this.WarpProgNumber.StylePriority.UsePadding = false;
            this.WarpProgNumber.StylePriority.UseTextAlignment = false;
            this.WarpProgNumber.Text = "0010000100013";
            this.WarpProgNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // TotalSizedBeams
            // 
            this.TotalSizedBeams.BorderColor = System.Drawing.Color.Silver;
            this.TotalSizedBeams.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.TotalSizedBeams.BorderWidth = 1;
            this.TotalSizedBeams.CanGrow = false;
            this.TotalSizedBeams.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalSizedBeams.ForeColor = System.Drawing.Color.Black;
            this.TotalSizedBeams.LocationFloat = new DevExpress.Utils.PointFloat(359.5644F, 107.9167F);
            this.TotalSizedBeams.Name = "TotalSizedBeams";
            this.TotalSizedBeams.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.TotalSizedBeams.SizeF = new System.Drawing.SizeF(73.73843F, 18.41664F);
            this.TotalSizedBeams.StylePriority.UseBorderColor = false;
            this.TotalSizedBeams.StylePriority.UseBorders = false;
            this.TotalSizedBeams.StylePriority.UseBorderWidth = false;
            this.TotalSizedBeams.StylePriority.UseFont = false;
            this.TotalSizedBeams.StylePriority.UseForeColor = false;
            this.TotalSizedBeams.StylePriority.UsePadding = false;
            this.TotalSizedBeams.StylePriority.UseTextAlignment = false;
            this.TotalSizedBeams.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // vUserInputDateTime
            // 
            this.vUserInputDateTime.BorderColor = System.Drawing.Color.Silver;
            this.vUserInputDateTime.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.vUserInputDateTime.BorderWidth = 1;
            this.vUserInputDateTime.CanGrow = false;
            this.vUserInputDateTime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vUserInputDateTime.ForeColor = System.Drawing.Color.Black;
            this.vUserInputDateTime.LocationFloat = new DevExpress.Utils.PointFloat(525.2917F, 107.9166F);
            this.vUserInputDateTime.Name = "vUserInputDateTime";
            this.vUserInputDateTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.vUserInputDateTime.SizeF = new System.Drawing.SizeF(196.6265F, 18.41667F);
            this.vUserInputDateTime.StylePriority.UseBorderColor = false;
            this.vUserInputDateTime.StylePriority.UseBorders = false;
            this.vUserInputDateTime.StylePriority.UseBorderWidth = false;
            this.vUserInputDateTime.StylePriority.UseFont = false;
            this.vUserInputDateTime.StylePriority.UseForeColor = false;
            this.vUserInputDateTime.StylePriority.UsePadding = false;
            this.vUserInputDateTime.StylePriority.UseTextAlignment = false;
            this.vUserInputDateTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel19
            // 
            this.xrLabel19.BackColor = System.Drawing.Color.White;
            this.xrLabel19.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel19.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel19.BorderWidth = 1;
            this.xrLabel19.CanGrow = false;
            this.xrLabel19.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.ForeColor = System.Drawing.Color.Black;
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(450.0001F, 87.5F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(73.68683F, 18.41666F);
            this.xrLabel19.StylePriority.UseBackColor = false;
            this.xrLabel19.StylePriority.UseBorderColor = false;
            this.xrLabel19.StylePriority.UseBorders = false;
            this.xrLabel19.StylePriority.UseBorderWidth = false;
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseForeColor = false;
            this.xrLabel19.StylePriority.UsePadding = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "Security Tag";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // vUser
            // 
            this.vUser.BorderColor = System.Drawing.Color.Silver;
            this.vUser.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.vUser.BorderWidth = 1;
            this.vUser.CanGrow = false;
            this.vUser.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vUser.ForeColor = System.Drawing.Color.Black;
            this.vUser.LocationFloat = new DevExpress.Utils.PointFloat(612.5F, 44.79167F);
            this.vUser.Name = "vUser";
            this.vUser.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.vUser.SizeF = new System.Drawing.SizeF(109.4183F, 18.41666F);
            this.vUser.StylePriority.UseBorderColor = false;
            this.vUser.StylePriority.UseBorders = false;
            this.vUser.StylePriority.UseBorderWidth = false;
            this.vUser.StylePriority.UseFont = false;
            this.vUser.StylePriority.UseForeColor = false;
            this.vUser.StylePriority.UsePadding = false;
            this.vUser.StylePriority.UseTextAlignment = false;
            this.vUser.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // vSecurityNumber
            // 
            this.vSecurityNumber.BorderColor = System.Drawing.Color.Silver;
            this.vSecurityNumber.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.vSecurityNumber.BorderWidth = 1;
            this.vSecurityNumber.CanGrow = false;
            this.vSecurityNumber.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vSecurityNumber.ForeColor = System.Drawing.Color.Black;
            this.vSecurityNumber.LocationFloat = new DevExpress.Utils.PointFloat(525F, 87.5F);
            this.vSecurityNumber.Name = "vSecurityNumber";
            this.vSecurityNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.vSecurityNumber.SizeF = new System.Drawing.SizeF(196.9183F, 18.41666F);
            this.vSecurityNumber.StylePriority.UseBorderColor = false;
            this.vSecurityNumber.StylePriority.UseBorders = false;
            this.vSecurityNumber.StylePriority.UseBorderWidth = false;
            this.vSecurityNumber.StylePriority.UseFont = false;
            this.vSecurityNumber.StylePriority.UseForeColor = false;
            this.vSecurityNumber.StylePriority.UsePadding = false;
            this.vSecurityNumber.StylePriority.UseTextAlignment = false;
            this.vSecurityNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel21
            // 
            this.xrLabel21.BackColor = System.Drawing.Color.White;
            this.xrLabel21.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel21.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel21.BorderWidth = 1;
            this.xrLabel21.CanGrow = false;
            this.xrLabel21.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.ForeColor = System.Drawing.Color.Black;
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(450.0001F, 107.9166F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(73.68677F, 18.41666F);
            this.xrLabel21.StylePriority.UseBackColor = false;
            this.xrLabel21.StylePriority.UseBorderColor = false;
            this.xrLabel21.StylePriority.UseBorders = false;
            this.xrLabel21.StylePriority.UseBorderWidth = false;
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseForeColor = false;
            this.xrLabel21.StylePriority.UsePadding = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "Date & Time";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // vStatus
            // 
            this.vStatus.BorderColor = System.Drawing.Color.Silver;
            this.vStatus.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.vStatus.BorderWidth = 1;
            this.vStatus.CanGrow = false;
            this.vStatus.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vStatus.ForeColor = System.Drawing.Color.Black;
            this.vStatus.LocationFloat = new DevExpress.Utils.PointFloat(573.882F, 66.20833F);
            this.vStatus.Name = "vStatus";
            this.vStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.vStatus.SizeF = new System.Drawing.SizeF(38.61804F, 18.41668F);
            this.vStatus.StylePriority.UseBorderColor = false;
            this.vStatus.StylePriority.UseBorders = false;
            this.vStatus.StylePriority.UseBorderWidth = false;
            this.vStatus.StylePriority.UseFont = false;
            this.vStatus.StylePriority.UseForeColor = false;
            this.vStatus.StylePriority.UsePadding = false;
            this.vStatus.StylePriority.UseTextAlignment = false;
            this.vStatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // vUserID
            // 
            this.vUserID.BorderColor = System.Drawing.Color.Silver;
            this.vUserID.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.vUserID.BorderWidth = 1;
            this.vUserID.CanGrow = false;
            this.vUserID.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vUserID.ForeColor = System.Drawing.Color.Black;
            this.vUserID.LocationFloat = new DevExpress.Utils.PointFloat(524.9999F, 44.79167F);
            this.vUserID.Name = "vUserID";
            this.vUserID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.vUserID.SizeF = new System.Drawing.SizeF(87.50006F, 18.41666F);
            this.vUserID.StylePriority.UseBorderColor = false;
            this.vUserID.StylePriority.UseBorders = false;
            this.vUserID.StylePriority.UseBorderWidth = false;
            this.vUserID.StylePriority.UseFont = false;
            this.vUserID.StylePriority.UseForeColor = false;
            this.vUserID.StylePriority.UsePadding = false;
            this.vUserID.StylePriority.UseTextAlignment = false;
            this.vUserID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // vInputMode
            // 
            this.vInputMode.BorderColor = System.Drawing.Color.Silver;
            this.vInputMode.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.vInputMode.BorderWidth = 1;
            this.vInputMode.CanGrow = false;
            this.vInputMode.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vInputMode.ForeColor = System.Drawing.Color.Black;
            this.vInputMode.LocationFloat = new DevExpress.Utils.PointFloat(656.5414F, 66.20836F);
            this.vInputMode.Name = "vInputMode";
            this.vInputMode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.vInputMode.SizeF = new System.Drawing.SizeF(65.37683F, 18.41666F);
            this.vInputMode.StylePriority.UseBorderColor = false;
            this.vInputMode.StylePriority.UseBorders = false;
            this.vInputMode.StylePriority.UseBorderWidth = false;
            this.vInputMode.StylePriority.UseFont = false;
            this.vInputMode.StylePriority.UseForeColor = false;
            this.vInputMode.StylePriority.UsePadding = false;
            this.vInputMode.StylePriority.UseTextAlignment = false;
            this.vInputMode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // vBarcode
            // 
            this.vBarcode.BorderColor = System.Drawing.Color.Silver;
            this.vBarcode.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.vBarcode.BorderWidth = 1;
            this.vBarcode.LocationFloat = new DevExpress.Utils.PointFloat(140.7651F, 0F);
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
            // vCategory
            // 
            this.vCategory.BorderColor = System.Drawing.Color.Silver;
            this.vCategory.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.vCategory.BorderWidth = 1;
            this.vCategory.CanGrow = false;
            this.vCategory.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vCategory.ForeColor = System.Drawing.Color.Black;
            this.vCategory.LocationFloat = new DevExpress.Utils.PointFloat(525F, 66.20833F);
            this.vCategory.Name = "vCategory";
            this.vCategory.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.vCategory.SizeF = new System.Drawing.SizeF(48.88208F, 18.41665F);
            this.vCategory.StylePriority.UseBorderColor = false;
            this.vCategory.StylePriority.UseBorders = false;
            this.vCategory.StylePriority.UseBorderWidth = false;
            this.vCategory.StylePriority.UseFont = false;
            this.vCategory.StylePriority.UseForeColor = false;
            this.vCategory.StylePriority.UsePadding = false;
            this.vCategory.StylePriority.UseTextAlignment = false;
            this.vCategory.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.BackColor = System.Drawing.Color.White;
            this.xrLabel3.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.BorderWidth = 1;
            this.xrLabel3.CanGrow = false;
            this.xrLabel3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(450.0001F, 66.20833F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(73.68677F, 18.41666F);
            this.xrLabel3.StylePriority.UseBackColor = false;
            this.xrLabel3.StylePriority.UseBorderColor = false;
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseBorderWidth = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseForeColor = false;
            this.xrLabel3.StylePriority.UsePadding = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Status";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // SizingDate
            // 
            this.SizingDate.BorderColor = System.Drawing.Color.Silver;
            this.SizingDate.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.SizingDate.BorderWidth = 1;
            this.SizingDate.CanGrow = false;
            this.SizingDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SizingDate.ForeColor = System.Drawing.Color.Black;
            this.SizingDate.LocationFloat = new DevExpress.Utils.PointFloat(142.7651F, 66.20833F);
            this.SizingDate.Name = "SizingDate";
            this.SizingDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.SizingDate.SizeF = new System.Drawing.SizeF(114.5759F, 18.41666F);
            this.SizingDate.StylePriority.UseBorderColor = false;
            this.SizingDate.StylePriority.UseBorders = false;
            this.SizingDate.StylePriority.UseBorderWidth = false;
            this.SizingDate.StylePriority.UseFont = false;
            this.SizingDate.StylePriority.UseForeColor = false;
            this.SizingDate.StylePriority.UsePadding = false;
            this.SizingDate.StylePriority.UseTextAlignment = false;
            this.SizingDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel8.BorderWidth = 1;
            this.xrLabel8.CanGrow = false;
            this.xrLabel8.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(517.2702F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(204.6481F, 27.28999F);
            this.xrLabel8.StylePriority.UseBorderColor = false;
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseBorderWidth = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UsePadding = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Sizing Sheet";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel23
            // 
            this.xrLabel23.BackColor = System.Drawing.Color.White;
            this.xrLabel23.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel23.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel23.BorderWidth = 1;
            this.xrLabel23.CanGrow = false;
            this.xrLabel23.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.ForeColor = System.Drawing.Color.Black;
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(612.5F, 66.20833F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(41.95819F, 18.41666F);
            this.xrLabel23.StylePriority.UseBackColor = false;
            this.xrLabel23.StylePriority.UseBorderColor = false;
            this.xrLabel23.StylePriority.UseBorders = false;
            this.xrLabel23.StylePriority.UseBorderWidth = false;
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseForeColor = false;
            this.xrLabel23.StylePriority.UsePadding = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "IPM";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.BackColor = System.Drawing.Color.White;
            this.xrLabel4.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.BorderWidth = 1;
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 66.20833F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(140.7651F, 18.41666F);
            this.xrLabel4.StylePriority.UseBackColor = false;
            this.xrLabel4.StylePriority.UseBorderColor = false;
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseBorderWidth = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseForeColor = false;
            this.xrLabel4.StylePriority.UsePadding = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Program Date";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.BackColor = System.Drawing.Color.White;
            this.xrLabel6.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel6.BorderWidth = 1;
            this.xrLabel6.CanGrow = false;
            this.xrLabel6.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(448.3953F, 44.79167F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(75.2916F, 18.41666F);
            this.xrLabel6.StylePriority.UseBackColor = false;
            this.xrLabel6.StylePriority.UseBorderColor = false;
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseBorderWidth = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseForeColor = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Input User";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // SetNo
            // 
            this.SetNo.BorderColor = System.Drawing.Color.Silver;
            this.SetNo.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.SetNo.BorderWidth = 1;
            this.SetNo.CanGrow = false;
            this.SetNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetNo.ForeColor = System.Drawing.Color.Black;
            this.SetNo.LocationFloat = new DevExpress.Utils.PointFloat(142.7651F, 44.79168F);
            this.SetNo.Name = "SetNo";
            this.SetNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.SetNo.SizeF = new System.Drawing.SizeF(114.5759F, 18.41667F);
            this.SetNo.StylePriority.UseBorderColor = false;
            this.SetNo.StylePriority.UseBorders = false;
            this.SetNo.StylePriority.UseBorderWidth = false;
            this.SetNo.StylePriority.UseFont = false;
            this.SetNo.StylePriority.UseForeColor = false;
            this.SetNo.StylePriority.UsePadding = false;
            this.SetNo.StylePriority.UseTextAlignment = false;
            this.SetNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel24
            // 
            this.xrLabel24.BackColor = System.Drawing.Color.White;
            this.xrLabel24.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel24.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel24.BorderWidth = 1;
            this.xrLabel24.CanGrow = false;
            this.xrLabel24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.ForeColor = System.Drawing.Color.Black;
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(257.341F, 44.79167F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(75.29166F, 18.41667F);
            this.xrLabel24.StylePriority.UseBackColor = false;
            this.xrLabel24.StylePriority.UseBorderColor = false;
            this.xrLabel24.StylePriority.UseBorders = false;
            this.xrLabel24.StylePriority.UseBorderWidth = false;
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UseForeColor = false;
            this.xrLabel24.StylePriority.UsePadding = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "Ref WPN #";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Breakages
            // 
            this.Breakages.BorderColor = System.Drawing.Color.Silver;
            this.Breakages.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Breakages.BorderWidth = 1;
            this.Breakages.CanGrow = false;
            this.Breakages.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Breakages.ForeColor = System.Drawing.Color.Black;
            this.Breakages.LocationFloat = new DevExpress.Utils.PointFloat(142.7651F, 107.9166F);
            this.Breakages.Name = "Breakages";
            this.Breakages.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.Breakages.SizeF = new System.Drawing.SizeF(114.5759F, 18.41667F);
            this.Breakages.StylePriority.UseBorderColor = false;
            this.Breakages.StylePriority.UseBorders = false;
            this.Breakages.StylePriority.UseBorderWidth = false;
            this.Breakages.StylePriority.UseFont = false;
            this.Breakages.StylePriority.UseForeColor = false;
            this.Breakages.StylePriority.UsePadding = false;
            this.Breakages.StylePriority.UseTextAlignment = false;
            this.Breakages.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(257.341F, 107.9166F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(102.2234F, 18.41666F);
            this.xrLabel22.StylePriority.UseBackColor = false;
            this.xrLabel22.StylePriority.UseBorderColor = false;
            this.xrLabel22.StylePriority.UseBorders = false;
            this.xrLabel22.StylePriority.UseBorderWidth = false;
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseForeColor = false;
            this.xrLabel22.StylePriority.UsePadding = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "# of Beams";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.BackColor = System.Drawing.Color.White;
            this.xrLabel11.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel11.BorderWidth = 1;
            this.xrLabel11.CanGrow = false;
            this.xrLabel11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(1.041794F, 149.7499F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(139.7232F, 18.41669F);
            this.xrLabel11.StylePriority.UseBackColor = false;
            this.xrLabel11.StylePriority.UseBorderColor = false;
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseBorderWidth = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseForeColor = false;
            this.xrLabel11.StylePriority.UsePadding = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Remarks (if any)";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Remarks
            // 
            this.Remarks.BorderColor = System.Drawing.Color.Silver;
            this.Remarks.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Remarks.BorderWidth = 1;
            this.Remarks.CanGrow = false;
            this.Remarks.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remarks.ForeColor = System.Drawing.Color.Black;
            this.Remarks.LocationFloat = new DevExpress.Utils.PointFloat(142.7651F, 149.7499F);
            this.Remarks.Name = "Remarks";
            this.Remarks.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.Remarks.SizeF = new System.Drawing.SizeF(579.1531F, 18.41667F);
            this.Remarks.StylePriority.UseBorderColor = false;
            this.Remarks.StylePriority.UseBorders = false;
            this.Remarks.StylePriority.UseBorderWidth = false;
            this.Remarks.StylePriority.UseFont = false;
            this.Remarks.StylePriority.UseForeColor = false;
            this.Remarks.StylePriority.UsePadding = false;
            this.Remarks.StylePriority.UseTextAlignment = false;
            this.Remarks.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.BackColor = System.Drawing.Color.White;
            this.xrLabel18.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel18.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel18.BorderWidth = 1;
            this.xrLabel18.CanGrow = false;
            this.xrLabel18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.ForeColor = System.Drawing.Color.Black;
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(1.041794F, 87.5F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(139.7233F, 18.41667F);
            this.xrLabel18.StylePriority.UseBackColor = false;
            this.xrLabel18.StylePriority.UseBorderColor = false;
            this.xrLabel18.StylePriority.UseBorders = false;
            this.xrLabel18.StylePriority.UseBorderWidth = false;
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseForeColor = false;
            this.xrLabel18.StylePriority.UsePadding = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Sizing Machine";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.BackColor = System.Drawing.Color.White;
            this.xrLabel5.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel5.BorderWidth = 1;
            this.xrLabel5.CanGrow = false;
            this.xrLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(1.041794F, 107.9166F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(139.7232F, 18.41666F);
            this.xrLabel5.StylePriority.UseBackColor = false;
            this.xrLabel5.StylePriority.UseBorderColor = false;
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseBorderWidth = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseForeColor = false;
            this.xrLabel5.StylePriority.UsePadding = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Total Breakages";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.BackColor = System.Drawing.Color.White;
            this.xrLabel14.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel14.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel14.BorderWidth = 1;
            this.xrLabel14.CanGrow = false;
            this.xrLabel14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.ForeColor = System.Drawing.Color.Black;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(0F, 129.3333F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(57.58348F, 18.41667F);
            this.xrLabel14.StylePriority.UseBackColor = false;
            this.xrLabel14.StylePriority.UseBorderColor = false;
            this.xrLabel14.StylePriority.UseBorders = false;
            this.xrLabel14.StylePriority.UseBorderWidth = false;
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseForeColor = false;
            this.xrLabel14.StylePriority.UsePadding = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Start Time";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // SizingMachine
            // 
            this.SizingMachine.BorderColor = System.Drawing.Color.Silver;
            this.SizingMachine.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.SizingMachine.BorderWidth = 1;
            this.SizingMachine.CanGrow = false;
            this.SizingMachine.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SizingMachine.ForeColor = System.Drawing.Color.Black;
            this.SizingMachine.LocationFloat = new DevExpress.Utils.PointFloat(142.7651F, 87.5F);
            this.SizingMachine.Name = "SizingMachine";
            this.SizingMachine.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.SizingMachine.SizeF = new System.Drawing.SizeF(290.5378F, 18.41667F);
            this.SizingMachine.StylePriority.UseBorderColor = false;
            this.SizingMachine.StylePriority.UseBorders = false;
            this.SizingMachine.StylePriority.UseBorderWidth = false;
            this.SizingMachine.StylePriority.UseFont = false;
            this.SizingMachine.StylePriority.UseForeColor = false;
            this.SizingMachine.StylePriority.UsePadding = false;
            this.SizingMachine.StylePriority.UseTextAlignment = false;
            this.SizingMachine.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // StartTime
            // 
            this.StartTime.BorderColor = System.Drawing.Color.Silver;
            this.StartTime.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.StartTime.BorderWidth = 1;
            this.StartTime.CanGrow = false;
            this.StartTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTime.ForeColor = System.Drawing.Color.Black;
            this.StartTime.LocationFloat = new DevExpress.Utils.PointFloat(57.58349F, 129.3333F);
            this.StartTime.Name = "StartTime";
            this.StartTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.StartTime.SizeF = new System.Drawing.SizeF(176.8257F, 18.41667F);
            this.StartTime.StylePriority.UseBorderColor = false;
            this.StartTime.StylePriority.UseBorders = false;
            this.StartTime.StylePriority.UseBorderWidth = false;
            this.StartTime.StylePriority.UseFont = false;
            this.StartTime.StylePriority.UseForeColor = false;
            this.StartTime.StylePriority.UsePadding = false;
            this.StartTime.StylePriority.UseTextAlignment = false;
            this.StartTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // WarpingProgramNumber
            // 
            this.WarpingProgramNumber.BorderColor = System.Drawing.Color.Silver;
            this.WarpingProgramNumber.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.WarpingProgramNumber.BorderWidth = 1;
            this.WarpingProgramNumber.CanGrow = false;
            this.WarpingProgramNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarpingProgramNumber.ForeColor = System.Drawing.Color.Black;
            this.WarpingProgramNumber.LocationFloat = new DevExpress.Utils.PointFloat(332.6326F, 44.79168F);
            this.WarpingProgramNumber.Name = "WarpingProgramNumber";
            this.WarpingProgramNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.WarpingProgramNumber.SizeF = new System.Drawing.SizeF(100.6702F, 18.41666F);
            this.WarpingProgramNumber.StylePriority.UseBorderColor = false;
            this.WarpingProgramNumber.StylePriority.UseBorders = false;
            this.WarpingProgramNumber.StylePriority.UseBorderWidth = false;
            this.WarpingProgramNumber.StylePriority.UseFont = false;
            this.WarpingProgramNumber.StylePriority.UseForeColor = false;
            this.WarpingProgramNumber.StylePriority.UsePadding = false;
            this.WarpingProgramNumber.StylePriority.UseTextAlignment = false;
            this.WarpingProgramNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.BackColor = System.Drawing.Color.White;
            this.xrLabel9.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel9.BorderWidth = 1;
            this.xrLabel9.CanGrow = false;
            this.xrLabel9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 44.79167F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(140.7651F, 18.41666F);
            this.xrLabel9.StylePriority.UseBackColor = false;
            this.xrLabel9.StylePriority.UseBorderColor = false;
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseBorderWidth = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseForeColor = false;
            this.xrLabel9.StylePriority.UsePadding = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Program #";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // EndTime
            // 
            this.EndTime.BorderColor = System.Drawing.Color.Silver;
            this.EndTime.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.EndTime.BorderWidth = 1;
            this.EndTime.CanGrow = false;
            this.EndTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndTime.ForeColor = System.Drawing.Color.Black;
            this.EndTime.LocationFloat = new DevExpress.Utils.PointFloat(291.9927F, 129.3333F);
            this.EndTime.Name = "EndTime";
            this.EndTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 1, 100F);
            this.EndTime.SizeF = new System.Drawing.SizeF(141.3101F, 18.41667F);
            this.EndTime.StylePriority.UseBorderColor = false;
            this.EndTime.StylePriority.UseBorders = false;
            this.EndTime.StylePriority.UseBorderWidth = false;
            this.EndTime.StylePriority.UseFont = false;
            this.EndTime.StylePriority.UseForeColor = false;
            this.EndTime.StylePriority.UsePadding = false;
            this.EndTime.StylePriority.UseTextAlignment = false;
            this.EndTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.BackColor = System.Drawing.Color.White;
            this.xrLabel7.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel7.BorderWidth = 1;
            this.xrLabel7.CanGrow = false;
            this.xrLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(234.4092F, 129.3333F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(57.5835F, 18.41667F);
            this.xrLabel7.StylePriority.UseBackColor = false;
            this.xrLabel7.StylePriority.UseBorderColor = false;
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseBorderWidth = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseForeColor = false;
            this.xrLabel7.StylePriority.UsePadding = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "End Time";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel33
            // 
            this.xrLabel33.BackColor = System.Drawing.Color.HotPink;
            this.xrLabel33.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel33.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.ForeColor = System.Drawing.Color.Black;
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(537.2749F, 0F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(184.6433F, 16.99998F);
            this.xrLabel33.StylePriority.UseBackColor = false;
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseForeColor = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "Remarks";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel32
            // 
            this.xrLabel32.BackColor = System.Drawing.Color.HotPink;
            this.xrLabel32.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel32.ForeColor = System.Drawing.Color.Black;
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(499.0757F, 0F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(34.95834F, 16.99998F);
            this.xrLabel32.StylePriority.UseBackColor = false;
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseForeColor = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "Shift";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel31
            // 
            this.xrLabel31.BackColor = System.Drawing.Color.HotPink;
            this.xrLabel31.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel31.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel31.ForeColor = System.Drawing.Color.Black;
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(359.9661F, 0F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(135.8687F, 16.99998F);
            this.xrLabel31.StylePriority.UseBackColor = false;
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseForeColor = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "Sizer";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel30
            // 
            this.xrLabel30.BackColor = System.Drawing.Color.HotPink;
            this.xrLabel30.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel30.ForeColor = System.Drawing.Color.Black;
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(278.0169F, 0F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(78.70834F, 16.99998F);
            this.xrLabel30.StylePriority.UseBackColor = false;
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseForeColor = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "Gross Weight";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel29
            // 
            this.xrLabel29.BackColor = System.Drawing.Color.HotPink;
            this.xrLabel29.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel29.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel29.ForeColor = System.Drawing.Color.Black;
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(222.1094F, 0F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(52.66666F, 16.99998F);
            this.xrLabel29.StylePriority.UseBackColor = false;
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseForeColor = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "Pressure";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel27
            // 
            this.xrLabel27.BackColor = System.Drawing.Color.HotPink;
            this.xrLabel27.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel27.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.ForeColor = System.Drawing.Color.Black;
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(89.83765F, 0F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(80.4149F, 16.99998F);
            this.xrLabel27.StylePriority.UseBackColor = false;
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseForeColor = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Length (Mtrs)";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel28
            // 
            this.xrLabel28.BackColor = System.Drawing.Color.HotPink;
            this.xrLabel28.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel28.ForeColor = System.Drawing.Color.Black;
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(26.90287F, 16.99998F);
            this.xrLabel28.StylePriority.UseBackColor = false;
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseForeColor = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "#";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel54
            // 
            this.xrLabel54.BackColor = System.Drawing.Color.HotPink;
            this.xrLabel54.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel54.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel54.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel54.ForeColor = System.Drawing.Color.Black;
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(173.4934F, 0F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.SizeF = new System.Drawing.SizeF(45.37505F, 16.99998F);
            this.xrLabel54.StylePriority.UseBackColor = false;
            this.xrLabel54.StylePriority.UseFont = false;
            this.xrLabel54.StylePriority.UseForeColor = false;
            this.xrLabel54.StylePriority.UseTextAlignment = false;
            this.xrLabel54.Text = "Speed";
            this.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel41
            // 
            this.xrLabel41.BackColor = System.Drawing.Color.HotPink;
            this.xrLabel41.BorderColor = System.Drawing.SystemColors.ControlText;
            this.xrLabel41.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel41.ForeColor = System.Drawing.Color.Black;
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(30.14375F, 0F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(56.45302F, 16.99996F);
            this.xrLabel41.StylePriority.UseBackColor = false;
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.StylePriority.UseForeColor = false;
            this.xrLabel41.StylePriority.UseTextAlignment = false;
            this.xrLabel41.Text = "Beam #";
            this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BeamRemarks
            // 
            this.BeamRemarks.BorderColor = System.Drawing.Color.HotPink;
            this.BeamRemarks.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.BeamRemarks.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Remarks")});
            this.BeamRemarks.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeamRemarks.LocationFloat = new DevExpress.Utils.PointFloat(537.2749F, 0F);
            this.BeamRemarks.Name = "BeamRemarks";
            this.BeamRemarks.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BeamRemarks.SizeF = new System.Drawing.SizeF(184.6433F, 16.99998F);
            this.BeamRemarks.StylePriority.UseBorderColor = false;
            this.BeamRemarks.StylePriority.UseBorders = false;
            this.BeamRemarks.StylePriority.UseFont = false;
            this.BeamRemarks.StylePriority.UseTextAlignment = false;
            this.BeamRemarks.Text = "BeamRemarks";
            this.BeamRemarks.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // BeamShift
            // 
            this.BeamShift.BorderColor = System.Drawing.Color.HotPink;
            this.BeamShift.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.BeamShift.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Shift")});
            this.BeamShift.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeamShift.LocationFloat = new DevExpress.Utils.PointFloat(499.0757F, 0F);
            this.BeamShift.Name = "BeamShift";
            this.BeamShift.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BeamShift.SizeF = new System.Drawing.SizeF(34.95834F, 16.99998F);
            this.BeamShift.StylePriority.UseBorderColor = false;
            this.BeamShift.StylePriority.UseBorders = false;
            this.BeamShift.StylePriority.UseFont = false;
            this.BeamShift.StylePriority.UseTextAlignment = false;
            this.BeamShift.Text = "BeamShift";
            this.BeamShift.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BeamSizer
            // 
            this.BeamSizer.BorderColor = System.Drawing.Color.HotPink;
            this.BeamSizer.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.BeamSizer.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SizerName")});
            this.BeamSizer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeamSizer.LocationFloat = new DevExpress.Utils.PointFloat(359.9662F, 0F);
            this.BeamSizer.Name = "BeamSizer";
            this.BeamSizer.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BeamSizer.SizeF = new System.Drawing.SizeF(135.8687F, 16.99998F);
            this.BeamSizer.StylePriority.UseBorderColor = false;
            this.BeamSizer.StylePriority.UseBorders = false;
            this.BeamSizer.StylePriority.UseFont = false;
            this.BeamSizer.StylePriority.UseTextAlignment = false;
            this.BeamSizer.Text = "BeamSizer";
            this.BeamSizer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // BeamGrossWeight
            // 
            this.BeamGrossWeight.BorderColor = System.Drawing.Color.HotPink;
            this.BeamGrossWeight.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.BeamGrossWeight.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "GWeight")});
            this.BeamGrossWeight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeamGrossWeight.LocationFloat = new DevExpress.Utils.PointFloat(278.0169F, 0F);
            this.BeamGrossWeight.Name = "BeamGrossWeight";
            this.BeamGrossWeight.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BeamGrossWeight.SizeF = new System.Drawing.SizeF(78.70834F, 16.99998F);
            this.BeamGrossWeight.StylePriority.UseBorderColor = false;
            this.BeamGrossWeight.StylePriority.UseBorders = false;
            this.BeamGrossWeight.StylePriority.UseFont = false;
            this.BeamGrossWeight.StylePriority.UseTextAlignment = false;
            this.BeamGrossWeight.Text = "BeamGrossWeight";
            this.BeamGrossWeight.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // BeamPressure
            // 
            this.BeamPressure.BorderColor = System.Drawing.Color.HotPink;
            this.BeamPressure.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.BeamPressure.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Pressure")});
            this.BeamPressure.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeamPressure.LocationFloat = new DevExpress.Utils.PointFloat(222.1093F, 0F);
            this.BeamPressure.Name = "BeamPressure";
            this.BeamPressure.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BeamPressure.SizeF = new System.Drawing.SizeF(52.66666F, 16.99998F);
            this.BeamPressure.StylePriority.UseBorderColor = false;
            this.BeamPressure.StylePriority.UseBorders = false;
            this.BeamPressure.StylePriority.UseFont = false;
            this.BeamPressure.StylePriority.UseTextAlignment = false;
            this.BeamPressure.Text = "BeamPressure";
            this.BeamPressure.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // BeamSpeed
            // 
            this.BeamSpeed.BorderColor = System.Drawing.Color.HotPink;
            this.BeamSpeed.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.BeamSpeed.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Speed")});
            this.BeamSpeed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeamSpeed.LocationFloat = new DevExpress.Utils.PointFloat(173.4935F, 0F);
            this.BeamSpeed.Name = "BeamSpeed";
            this.BeamSpeed.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BeamSpeed.SizeF = new System.Drawing.SizeF(45.37506F, 16.99998F);
            this.BeamSpeed.StylePriority.UseBorderColor = false;
            this.BeamSpeed.StylePriority.UseBorders = false;
            this.BeamSpeed.StylePriority.UseFont = false;
            this.BeamSpeed.StylePriority.UseTextAlignment = false;
            this.BeamSpeed.Text = "BeamSpeed";
            this.BeamSpeed.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // BeamLength
            // 
            this.BeamLength.BorderColor = System.Drawing.Color.HotPink;
            this.BeamLength.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.BeamLength.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BeamLength")});
            this.BeamLength.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeamLength.LocationFloat = new DevExpress.Utils.PointFloat(89.83765F, 0F);
            this.BeamLength.Name = "BeamLength";
            this.BeamLength.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BeamLength.SizeF = new System.Drawing.SizeF(80.4149F, 16.99998F);
            this.BeamLength.StylePriority.UseBorderColor = false;
            this.BeamLength.StylePriority.UseBorders = false;
            this.BeamLength.StylePriority.UseFont = false;
            this.BeamLength.StylePriority.UseTextAlignment = false;
            this.BeamLength.Text = "BeamLength";
            this.BeamLength.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // BeamNumber
            // 
            this.BeamNumber.BorderColor = System.Drawing.Color.HotPink;
            this.BeamNumber.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.BeamNumber.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BeamNumber")});
            this.BeamNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeamNumber.LocationFloat = new DevExpress.Utils.PointFloat(30.14374F, 0F);
            this.BeamNumber.Name = "BeamNumber";
            this.BeamNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BeamNumber.SizeF = new System.Drawing.SizeF(56.45302F, 16.99998F);
            this.BeamNumber.StylePriority.UseBorderColor = false;
            this.BeamNumber.StylePriority.UseBorders = false;
            this.BeamNumber.StylePriority.UseFont = false;
            this.BeamNumber.StylePriority.UseTextAlignment = false;
            this.BeamNumber.Text = "BeamNumber";
            this.BeamNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // IndexNo
            // 
            this.IndexNo.BorderColor = System.Drawing.Color.HotPink;
            this.IndexNo.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.IndexNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndexNo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.IndexNo.Name = "IndexNo";
            this.IndexNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.IndexNo.SizeF = new System.Drawing.SizeF(27.94453F, 16.99998F);
            this.IndexNo.StylePriority.UseBorderColor = false;
            this.IndexNo.StylePriority.UseBorders = false;
            this.IndexNo.StylePriority.UseFont = false;
            this.IndexNo.StylePriority.UseTextAlignment = false;
            this.IndexNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.BorderWidth = 2;
            this.xrLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(566.6689F, 67.41667F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(136.2169F, 22.58332F);
            this.xrLabel2.StylePriority.UseBorderColor = false;
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseBorderWidth = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseForeColor = false;
            this.xrLabel2.StylePriority.UsePadding = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Authorized by";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel10.BorderWidth = 2;
            this.xrLabel10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(21.77731F, 67.41667F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(136.2169F, 22.58332F);
            this.xrLabel10.StylePriority.UseBorderColor = false;
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseBorderWidth = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseForeColor = false;
            this.xrLabel10.StylePriority.UsePadding = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Prepared by";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel12.BorderWidth = 2;
            this.xrLabel12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(278.0169F, 67.41667F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 1, 1, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(136.2169F, 22.58332F);
            this.xrLabel12.StylePriority.UseBorderColor = false;
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseBorderWidth = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseForeColor = false;
            this.xrLabel12.StylePriority.UsePadding = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Checked by";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine2
            // 
            this.xrLine2.BorderWidth = 1;
            this.xrLine2.ForeColor = System.Drawing.Color.Orange;
            this.xrLine2.LineWidth = 2;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(278.0169F, 62.16663F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(136.2169F, 5.250015F);
            this.xrLine2.StylePriority.UseBorderWidth = false;
            this.xrLine2.StylePriority.UseForeColor = false;
            // 
            // xrLine1
            // 
            this.xrLine1.BorderWidth = 1;
            this.xrLine1.ForeColor = System.Drawing.Color.Orange;
            this.xrLine1.LineWidth = 2;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(21.77731F, 62.16663F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(136.2169F, 5.250015F);
            this.xrLine1.StylePriority.UseBorderWidth = false;
            this.xrLine1.StylePriority.UseForeColor = false;
            // 
            // xrLine4
            // 
            this.xrLine4.BorderWidth = 1;
            this.xrLine4.ForeColor = System.Drawing.Color.Orange;
            this.xrLine4.LineWidth = 2;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(566.6689F, 62.16663F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(136.2169F, 5.250015F);
            this.xrLine4.StylePriority.UseBorderWidth = false;
            this.xrLine4.StylePriority.UseForeColor = false;
            // 
            // SW_SizingSheet_Self
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(75, 52, 23, 100);
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        public DevExpress.XtraReports.UI.XRLabel SizingMachine;
        public DevExpress.XtraReports.UI.XRLabel StartTime;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        public DevExpress.XtraReports.UI.XRLabel Remarks;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        public DevExpress.XtraReports.UI.XRLabel WarpingProgramNumber;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        public DevExpress.XtraReports.UI.XRLabel vStatus;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        public DevExpress.XtraReports.UI.XRLabel vUserID;
        public DevExpress.XtraReports.UI.XRBarCode vBarcode;
        public DevExpress.XtraReports.UI.XRLabel vInputMode;
        public DevExpress.XtraReports.UI.XRLabel vSecurityNumber;
        public DevExpress.XtraReports.UI.XRLabel TotalSizedBeams;
        public DevExpress.XtraReports.UI.XRLabel WarpProgNumber;
        public DevExpress.XtraReports.UI.XRLabel vUserInputDateTime;
        public DevExpress.XtraReports.UI.XRLabel vUser;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        public DevExpress.XtraReports.UI.XRLabel SetNo;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        public DevExpress.XtraReports.UI.XRLabel Breakages;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        public DevExpress.XtraReports.UI.XRLabel vCategory;
        public DevExpress.XtraReports.UI.XRLabel SizingDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        public DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        public DevExpress.XtraReports.UI.XRLabel EndTime;
        private DevExpress.XtraReports.UI.XRLabel xrLabel28;
        private DevExpress.XtraReports.UI.XRLabel xrLabel27;
        private DevExpress.XtraReports.UI.XRLabel xrLabel41;
        private DevExpress.XtraReports.UI.XRLabel xrLabel54;
        private DevExpress.XtraReports.UI.XRLabel xrLabel29;
        private DevExpress.XtraReports.UI.XRLabel xrLabel32;
        private DevExpress.XtraReports.UI.XRLabel xrLabel33;
        private DevExpress.XtraReports.UI.XRLabel xrLabel30;
        private DevExpress.XtraReports.UI.XRLabel xrLabel31;
        private DevExpress.XtraReports.UI.XRLabel BeamLength;
        private DevExpress.XtraReports.UI.XRLabel BeamSpeed;
        private DevExpress.XtraReports.UI.XRLabel IndexNo;
        private DevExpress.XtraReports.UI.XRLabel BeamNumber;
        private DevExpress.XtraReports.UI.XRLabel BeamPressure;
        private DevExpress.XtraReports.UI.XRLabel BeamShift;
        private DevExpress.XtraReports.UI.XRLabel BeamRemarks;
        private DevExpress.XtraReports.UI.XRLabel BeamGrossWeight;
        private DevExpress.XtraReports.UI.XRLabel BeamSizer;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLine xrLine4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
    }
}
