using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
namespace MachineEyes.Classes
{
    public static class Printing
    {
        public static void Print_SW_ProgramSheet(string ProgramNumber, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from SWQ_ProgramSheet where WarpProgNumber='" + ProgramNumber + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;

            DataSet ds_sub = WS.svc.Get_DataSet("select * from SW_ProgramSheet_Sub where WarpProgNumber='" + ProgramNumber + "'");
            if (ds_sub == null) return;
            if (ds_sub.Tables[0].Rows.Count <= 0)
                return;
           


            Reports.SW_ProgramSheet rpVoucher = new Reports.SW_ProgramSheet();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["WarpProgNumber"].ToString();
            rpVoucher.ProgramDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["ProgramDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();
            rpVoucher.RequiredDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["RequiredDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();
            rpVoucher.vStatus.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["iStatus"].ToString();
            rpVoucher.WarpProgNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["WarpProgNumber"].ToString();
            rpVoucher.WarpingCompany.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["WarpingCompanyName"].ToString();
            rpVoucher.AccountName.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AccountName"].ToString();
            rpVoucher.ArticleNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["ArticleShortName"].ToString();
            rpVoucher.AttentionTo.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AttentionTo"].ToString();
            rpVoucher.BeamLength.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["Beamlength"].ToString();
            rpVoucher.BeamSpace.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BeamSpace"].ToString();
            rpVoucher.BeamType.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BeamType"].ToString();
            rpVoucher.NoofBeams.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["NoofBeams"].ToString();
            rpVoucher.FledgeDia.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["FledgeDia"].ToString();
            rpVoucher.Department.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["DeptWarpedForName"].ToString();
            rpVoucher.FCC.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["FCC"].ToString();
            rpVoucher.Remarks.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["Remarks"].ToString();
           


            rpVoucher.DataSource = ds_sub;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_FC_PO_SizingWorkOrder(string ProgramNumber, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from RFC_PO_SizingWorkOrder where SWONO='" + ProgramNumber + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;

            DataSet ds_sub = WS.svc.Get_DataSet("select * from FC_PO_SizingWorkOrder_Sub where SWONO='" + ProgramNumber + "'");
            if (ds_sub == null) return;
            if (ds_sub.Tables[0].Rows.Count <= 0)
                return;



            Reports.FC_PO_SizingWorkOrder rpVoucher = new Reports.FC_PO_SizingWorkOrder();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SWONO"].ToString();
            rpVoucher.ProgramDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["ProgramDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();
            rpVoucher.RequiredDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["RequiredDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();
           
            rpVoucher.WarpProgNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SWONO"].ToString();
            rpVoucher.WarpingCompany.Text = MachineEyes.Classes.Accounting.Get_MappedAccount(ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerID"].ToString());
            //rpVoucher.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["POPartyName"].ToString();
            rpVoucher.ArticleNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["ArticleShortName"].ToString();
            rpVoucher.AttentionTo.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AttentionTo"].ToString();
            rpVoucher.BeamLength.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["Beamlength"].ToString();
            rpVoucher.BeamSpace.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BeamSpace"].ToString();
            rpVoucher.BeamType.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BeamType"].ToString();
            rpVoucher.NoofBeams.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["NoofBeams"].ToString();
            rpVoucher.FledgeDia.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["FledgeDia"].ToString();
            rpVoucher.Department.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["DepartmentName"].ToString();
            rpVoucher.FCC.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["REFPONO"].ToString();
            rpVoucher.Remarks.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["Remarks"].ToString();
            rpVoucher.DataSource = ds_sub;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_FC_PO_DoublingWorkOrder(string ProgramNumber, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from RFC_PO_DoublingWorkOrder where DBWNO='" + ProgramNumber + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;

            DataSet ds_sub = WS.svc.Get_DataSet("select * from FC_PO_DoublingWorkOrder_Sub where DBWNO='" + ProgramNumber + "'");
            if (ds_sub == null) return;
            if (ds_sub.Tables[0].Rows.Count <= 0)
                return;



            Reports.FC_PO_DoublingWorkOrder rpVoucher = new Reports.FC_PO_DoublingWorkOrder();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["DBWNO"].ToString();
            rpVoucher.ProgramDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["ProgramDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();
            rpVoucher.RequiredDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["RequiredDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();

            rpVoucher.WarpProgNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["DBWNO"].ToString();
            rpVoucher.WarpingCompany.Text = MachineEyes.Classes.Accounting.Get_MappedAccount(ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerID"].ToString());
            //rpVoucher.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["POPartyName"].ToString();
            rpVoucher.ArticleNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["ArticleShortName"].ToString();
            rpVoucher.AttentionTo.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AttentionTo"].ToString();
          
            rpVoucher.RequiredPly.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["RequiredPly"].ToString();
           
            rpVoucher.Department.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["DepartmentName"].ToString();
            rpVoucher.FCC.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["REFPONO"].ToString();
            rpVoucher.Remarks.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["Remarks"].ToString();
            rpVoucher.DataSource = ds_sub;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_FC_PO_YarnDyingWorkOrder(string ProgramNumber, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from RFC_PO_DoublingWorkOrder where DBWNO='" + ProgramNumber + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;

            DataSet ds_sub = WS.svc.Get_DataSet("select * from FC_PO_DoublingWorkOrder_Sub where DBWNO='" + ProgramNumber + "'");
            if (ds_sub == null) return;
            if (ds_sub.Tables[0].Rows.Count <= 0)
                return;



            Reports.FC_PO_DoublingWorkOrder rpVoucher = new Reports.FC_PO_DoublingWorkOrder();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["DBWNO"].ToString();
            rpVoucher.ProgramDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["ProgramDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();
            rpVoucher.RequiredDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["RequiredDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();

            rpVoucher.WarpProgNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["DBWNO"].ToString();
            rpVoucher.WarpingCompany.Text = MachineEyes.Classes.Accounting.Get_MappedAccount(ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerID"].ToString());
            //rpVoucher.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["POPartyName"].ToString();
            rpVoucher.ArticleNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["ArticleShortName"].ToString();
            rpVoucher.AttentionTo.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AttentionTo"].ToString();

            rpVoucher.RequiredPly.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["RequiredPly"].ToString();

            rpVoucher.Department.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["DepartmentName"].ToString();
            rpVoucher.FCC.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["REFPONO"].ToString();
            rpVoucher.Remarks.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["Remarks"].ToString();
            rpVoucher.DataSource = ds_sub;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_SW_WarpingSheet(string ProgramNumber, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from SWQ_Warping where WarpingProgramNumber='" + ProgramNumber + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;

            DataSet ds_sub = WS.svc.Get_DataSet("select * from SWQ_Warping_YarnConsumption where WarpingProgramNumber='" + ProgramNumber + "'");
            if (ds_sub == null) return;
            if (ds_sub.Tables[0].Rows.Count <= 0)
                return;
          


            Reports.SW_Warping rpVoucher = new Reports.SW_Warping();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["WarpingProgramNumber"].ToString();
            rpVoucher.ProgramDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["WarpingProgramDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();
            rpVoucher.vStatus.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["iStatus"].ToString();
            rpVoucher.WarpProgNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["WarpingProgramNumber"].ToString();
            rpVoucher.AccountName.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PartyName"].ToString();
            rpVoucher.ArticleNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["ArticleShortName"].ToString();
            rpVoucher.NoOfWarpedBeams.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["NoofWarpBeams"].ToString();
            rpVoucher.NoOfCreels.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["NoOfCreels"].ToString();
            rpVoucher.EndsPerWarpBeam.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["EndsPerWarpBeam"].ToString();
            rpVoucher.LengthPerWarpBeam.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["LengthPerWarpBeam"].ToString();
            rpVoucher.WarpingMachine.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["WarpMachineDesc"].ToString();
            rpVoucher.RefProgramSheetNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["ProgramSheetNumber"].ToString();
            rpVoucher.OutSideProgramNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["OutSideProgramNumber"].ToString();
            rpVoucher.TotalBreaks.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["TotalBreaks"].ToString();
            rpVoucher.FCC.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["FCC"].ToString();
            rpVoucher.Remarks.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["Remarks"].ToString();

           


            rpVoucher.DataSource = ds_sub;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_SW_WarpingSheetSection(string ProgramNumber, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from SWQ_Warping where WarpingProgramNumber='" + ProgramNumber + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;

            DataSet ds_sub = WS.svc.Get_DataSet("select * from SWQ_Warping_YarnConsumption where WarpingProgramNumber='" + ProgramNumber + "'");
            if (ds_sub == null) return;
            if (ds_sub.Tables[0].Rows.Count <= 0)
                return;
           
            DataSet ds_sectionbeams = WS.svc.Get_DataSet("select * from SWQ_Sizing_Details where SetNo='" + ProgramNumber + "'");
            if (ds_sectionbeams == null) return;
            if (ds_sectionbeams.Tables[0].Rows.Count <= 0)
                return;

            Reports.SW_WarpingSection rpVoucher = new Reports.SW_WarpingSection();
            Reports.SW_WarpingSection_BeamDetails rpBeams = new Reports.SW_WarpingSection_BeamDetails();

            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["WarpingProgramNumber"].ToString();
            rpVoucher.ProgramDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["WarpingProgramDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();
            rpVoucher.vStatus.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["iStatus"].ToString();
            rpVoucher.WarpProgNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["WarpingProgramNumber"].ToString();
            rpVoucher.AccountName.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PartyName"].ToString();
            rpVoucher.ArticleNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["ArticleShortName"].ToString();
            rpVoucher.NoOfWarpedBeams.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["NoofWarpBeams"].ToString();
            rpVoucher.NoOfCreels.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["NoOfCreels"].ToString();
            rpVoucher.EndsPerWarpBeam.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["EndsPerWarpBeam"].ToString();
            rpVoucher.LengthPerWarpBeam.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["LengthPerWarpBeam"].ToString();
            rpVoucher.WarpingMachine.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["WarpMachineDesc"].ToString();
            rpVoucher.RefProgramSheetNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["ProgramSheetNumber"].ToString();
            rpVoucher.OutSideProgramNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["OutSideProgramNumber"].ToString();
            rpVoucher.TotalBreaks.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["TotalBreaks"].ToString();
            rpVoucher.FCC.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["FCC"].ToString();
            rpVoucher.Remarks.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["Remarks"].ToString();

           
            rpBeams.BeginInit();
            rpBeams.DataSource = ds_sectionbeams;
            rpBeams.EndInit();
            rpVoucher.SectionWarpingBeams.ReportSource = rpBeams;

            rpVoucher.DataSource = ds_sub;

            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_SW_SizingSheetSelf(string ProgramNumber, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from SWQ_Sizing where SetNo='" + ProgramNumber + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;

            DataSet ds_sub = WS.svc.Get_DataSet("select * from SWQ_Sizing_Details where SetNo='" + ProgramNumber + "'");
            if (ds_sub == null) return;
            if (ds_sub.Tables[0].Rows.Count <= 0)
                return;
          


            Reports.SW_SizingSheet_Self rpVoucher = new Reports.SW_SizingSheet_Self();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SetNo"].ToString();

            rpVoucher.vStatus.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["iStatus"].ToString();
            rpVoucher.WarpProgNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["WarpingProgramNumber"].ToString();
            rpVoucher.SizingMachine.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SizingMachineName"].ToString();
            try
            {
                rpVoucher.SizingDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["SizingDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();
                rpVoucher.StartTime.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["StartTime"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString() + " " + Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["StartTime"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortTimeString();
                rpVoucher.EndTime.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["EndTime"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString() + " " + Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["StartTime"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortTimeString();
            }
            catch
            {
            }


            rpVoucher.Breakages.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["Breakages"].ToString();
            rpVoucher.TotalSizedBeams.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["TotalSizedBeams"].ToString();
            rpVoucher.Remarks.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["Remarks"].ToString();

           

            if (ds_sub != null)
                rpVoucher.DataSource = ds_sub;
            else
                rpVoucher.DataSource = null;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_ST_PO(string PONO, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from ST_PurchaseOrder where PONO='" + PONO + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("PO # not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet ds_sub = WS.svc.Get_DataSet("select * from RST_PurchaseOrderDetails where PONO='" + PONO + "'");
            if (ds_sub == null) return;
            if (ds_sub.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("PO Details not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           


            Reports.Store_PurchaseOrder rpVoucher = new Reports.Store_PurchaseOrder();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PONO"].ToString();
            try
            {
                rpVoucher.AccountID.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AccountID_V"].ToString();
                rpVoucher.AccountName.Text = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(ds_AC_Voucher_Main.Tables[0].Rows[0]["AccountID_V"].ToString());
            }
            catch
            {
            }
            rpVoucher.PODate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["Dated"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();
            rpVoucher.vStatus.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["iStatus"].ToString();
            rpVoucher.PONumberforBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PONO"].ToString();
            
           
           

            rpVoucher.DataSource = ds_sub;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_ST_PO_PAKA(string PONO,string CopyType)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from RST_PurchaseOrder where PONO='" + PONO + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("PO # not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet ds_sub = WS.svc.Get_DataSet("select * from RST_PurchaseOrderDetails where PONO='" + PONO + "'");
            if (ds_sub == null) return;
            if (ds_sub.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("PO Details not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            Reports.Store_PurchaseOrderPaka rpVoucher = new Reports.Store_PurchaseOrderPaka();
            rpVoucher.BeginInit();
            rpVoucher.xrCopyType.Text = CopyType;
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PONO"].ToString();
            try
            {
                
                rpVoucher.VendorName.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AccountName"].ToString();
                rpVoucher.VendorAddress.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["MailingAddress"].ToString();
                rpVoucher.VendorEmail.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["EMAIL"].ToString();
                rpVoucher.VendorFax.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["FAX"].ToString();
                rpVoucher.VendorGSTNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["GST"].ToString();
                rpVoucher.VendorNTNNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["NTN"].ToString();
                rpVoucher.VendorPhone.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["Phone1"].ToString();
            }
            catch
            {
            }
            rpVoucher.ShiptoAddress.Text = Program.ss.Machines.PresentationData.CPInfo.cpAddress;
            rpVoucher.ShiptoCompanyName.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            rpVoucher.ShiptoEmail.Text = Program.ss.Machines.PresentationData.CPInfo.cpEmail;
            rpVoucher.ShiptoFax.Text = Program.ss.Machines.PresentationData.CPInfo.cpFAX;
            rpVoucher.ShiptoNTN.Text = Program.ss.Machines.PresentationData.CPInfo.cpNTN;
            rpVoucher.ShiptoPhone.Text = Program.ss.Machines.PresentationData.CPInfo.cpPhone;
            rpVoucher.ShiptoSalesTaxNumber.Text = Program.ss.Machines.PresentationData.CPInfo.cpSTN;
            rpVoucher.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            rpVoucher.vDocumentNumber.Text = PONO;
            rpVoucher.vEmail.Text = Program.ss.Machines.PresentationData.CPInfo.cpEmail;
            rpVoucher.vAddress.Text = Program.ss.Machines.PresentationData.CPInfo.cpAddress;
            rpVoucher.Dated.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["Dated"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM-yyyy");
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PONO"].ToString();
            double GrossAmount = 0;
            double DiscountAmount = 0;
            double AmountBeforeGST = 0;
            double AmountBeforeDeductions = 0;
            double NetAmount = 0;
            double GSTAmount = 0;
            double WHTAmount = 0;
            double WHSTAmount = 0;

            DataSet dsGross = WS.svc.Get_DataSet("select Sum(Amount) as GrossAmount from RST_PurchaseOrderDetails where PONO='" + PONO + "'");
            if (dsGross != null)
            {
                try
                {
                    double.TryParse(dsGross.Tables[0].Rows[0]["GrossAmount"].ToString(), out GrossAmount);
                }
                catch
                {
                }
            }
            try
            {
                double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["DiscountAmount"].ToString(), out DiscountAmount);
            }
            catch
            {
            }
            try
            {
                double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["GSTAmount"].ToString(), out GSTAmount);
            }
            catch
            {
            }
            try
            {
                double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["WHTAmount"].ToString(), out WHTAmount);
            }
            catch
            {
            }
            try
            {
                double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["WHSTAmount"].ToString(), out WHSTAmount);
            }
            catch
            {
            }
            AmountBeforeGST = GrossAmount - DiscountAmount;
            AmountBeforeDeductions = AmountBeforeGST + GSTAmount;
            NetAmount = AmountBeforeDeductions - WHTAmount - WHSTAmount;

            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["DiscountPercent"].ToString() != "" && ds_AC_Voucher_Main.Tables[0].Rows[0]["DiscountPercent"].ToString() != "0")
                rpVoucher.DiscountLabel.Text = "Discount @ " + ds_AC_Voucher_Main.Tables[0].Rows[0]["DiscountPercent"].ToString() + "%";
            else
            rpVoucher.DiscountLabel.Text = "Discount ";

            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["GSTPercent"].ToString() != "" && ds_AC_Voucher_Main.Tables[0].Rows[0]["GSTPercent"].ToString() != "0")
                rpVoucher.GSTLabel.Text = "Sales Tax @ " + ds_AC_Voucher_Main.Tables[0].Rows[0]["GSTPercent"].ToString() + "%";
            else
                rpVoucher.GSTLabel.Text = "Sales Tax ";

            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["WHTPercent"].ToString() != "" && ds_AC_Voucher_Main.Tables[0].Rows[0]["WHTPercent"].ToString() != "0")
                rpVoucher.WHTLabel.Text = "WHT @ " + ds_AC_Voucher_Main.Tables[0].Rows[0]["WHTPercent"].ToString() + "%";
            else
                rpVoucher.WHTLabel.Text = "WHT ";
            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["WHSTPercent"].ToString() != "" && ds_AC_Voucher_Main.Tables[0].Rows[0]["WHSTPercent"].ToString() != "0")
                rpVoucher.WHSTLabel.Text = "WHST @ " + ds_AC_Voucher_Main.Tables[0].Rows[0]["WHSTPercent"].ToString() + "%";
            else
                rpVoucher.WHSTLabel.Text = "WHST ";
            rpVoucher.DiscountAmount.Text = DiscountAmount.ToString("#,##");
            rpVoucher.AmountBeforeTax.Text = AmountBeforeGST.ToString("#,##");
            rpVoucher.GSTAmount.Text = GSTAmount.ToString("#,##");
            rpVoucher.AmountBeforeDeductions.Text = AmountBeforeDeductions.ToString("#,##");
            rpVoucher.AmountAfterDeductions.Text = NetAmount.ToString("#,##");
            rpVoucher.WHTAmount.Text = WHTAmount.ToString("#,##");
            rpVoucher.WHSTAmount.Text = WHSTAmount.ToString("#,##");
            rpVoucher.NetAmountLabel.Text = "Net Amount: " + MachineEyes.Classes.Accounting.ReturnAmountInWords(NetAmount);
            rpVoucher.DataSource = ds_sub;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_IP_TowelInspection(DateTime inspectiondate)
        {
            string query = "select * from RIP_Godown_Towel_Details  where GodownEntryCode in (select GodownEntryCode from IP_Godown_Towel where Dated='" + inspectiondate.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and GodownEntryTypeID=1)";
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet(query);
            
           

           




            Reports.Inspection_DailyInspection_Towel_QualityWise rpVoucher = new Reports.Inspection_DailyInspection_Towel_QualityWise();
            rpVoucher.BeginInit();


            rpVoucher.repH_Dated.Text = inspectiondate.ToString("dd-MMMM-yyyy");
            if (ds_AC_Voucher_Main != null)
                rpVoucher.DataSource = ds_AC_Voucher_Main;
            else
                rpVoucher.DataSource = null;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_IP_GreigeInspection(DateTime inspectiondate,string GodownEntryTypeID,string ReportName)
        {
            string query = "select * from RIP_Godown_Greige_Details   where Dated='" + inspectiondate.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and GodownEntryTypeID="+GodownEntryTypeID+"";
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet(query);
            Reports.Inspection_DailyInspection_Greige_QualityWise rpVoucher = new Reports.Inspection_DailyInspection_Greige_QualityWise();
            rpVoucher.BeginInit();
            rpVoucher.ReportName.Text = ReportName;

            rpVoucher.repH_Dated.Text = inspectiondate.ToString("dd-MMMM-yyyy");
            if (ds_AC_Voucher_Main != null)
                rpVoucher.DataSource = ds_AC_Voucher_Main;
            else
                rpVoucher.DataSource = null;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_IP_GreigeInspectionOutward(DateTime inspectiondate, string GodownEntryTypeID, string ReportName)
        {
            string query = "select * from RIP_Godown_Greige_Details   where Dated='" + inspectiondate.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and GodownEntryTypeID=" + GodownEntryTypeID + "";
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet(query);
            Reports.Inspection_DailyInspectionOutward_Greige_QualityWise rpVoucher = new Reports.Inspection_DailyInspectionOutward_Greige_QualityWise();
            rpVoucher.BeginInit();
            rpVoucher.ReportName.Text = ReportName;

            rpVoucher.repH_Dated.Text = inspectiondate.ToString("dd-MMMM-yyyy");
            if (ds_AC_Voucher_Main != null)
                rpVoucher.DataSource = ds_AC_Voucher_Main;
            else
                rpVoucher.DataSource = null;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_IP_TowelPackingList(string packingListNumber)
        {
            string query = "select * from RIP_Godown_Towel_Details  where GodownEntryCode='"+packingListNumber+"'";
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet(query);


            query = "select * from RIP_Godown_Towel where GodownEntryCode='" + packingListNumber + "'";
            DataSet ds = WS.svc.Get_DataSet(query);

            if (ds == null)
            {
                XtraMessageBox.Show("Invalid Packing list #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            Reports.Inspection_Towel_PackingList rpVoucher = new Reports.Inspection_Towel_PackingList();
            rpVoucher.BeginInit();


            rpVoucher.Dated.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Dated"]).ToString("dd-MMMM-yyyy");
            rpVoucher.Driver.Text =ds.Tables[0].Rows[0]["Driver"].ToString();
            rpVoucher.VehicleNumber.Text = ds.Tables[0].Rows[0]["VRN"].ToString();
            rpVoucher.vBarcode.Text = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString();
            rpVoucher.PLNO.Text = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString();
            rpVoucher.AccountID.Text = ds.Tables[0].Rows[0]["AccountID"].ToString();
            rpVoucher.AccountName.Text = ds.Tables[0].Rows[0]["AccountName"].ToString();
            if (ds_AC_Voucher_Main != null)
                rpVoucher.DataSource = ds_AC_Voucher_Main;
            else
                rpVoucher.DataSource = null;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_IP_GreigePackingList(string packingListNumber)
        {
            string query = "select PONO,ArticleNumber,ArticleShortName,OUT_A as Meters from RIP_Godown_Greige_Details  where GodownEntryCode='" + packingListNumber + "'";
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet(query);

            string queryB = "select PONO,ArticleNumber,ArticleShortName,OUT_B as Meters from RIP_Godown_Greige_Details  where GodownEntryCode='" + packingListNumber + "'";
            DataSet ds_B = WS.svc.Get_DataSet(queryB);
            string queryC = "select PONO,ArticleNumber,ArticleShortName,OUT_C as Meters from RIP_Godown_Greige_Details  where GodownEntryCode='" + packingListNumber + "'";
            DataSet ds_C = WS.svc.Get_DataSet(queryC);
            string querySP = "select PONO,ArticleNumber,ArticleShortName,OUT_SP as Meters from RIP_Godown_Greige_Details  where GodownEntryCode='" + packingListNumber + "'";
            DataSet ds_SP= WS.svc.Get_DataSet(querySP);
            string queryCP= "select PONO,ArticleNumber,ArticleShortName,OUT_CP as Meters from RIP_Godown_Greige_Details  where GodownEntryCode='" + packingListNumber + "'";
            DataSet ds_CP = WS.svc.Get_DataSet(queryCP);

            ds_AC_Voucher_Main.Merge(ds_B);
            ds_AC_Voucher_Main.Merge(ds_C);
            ds_AC_Voucher_Main.Merge(ds_SP);
            ds_AC_Voucher_Main.Merge(ds_CP);

            ds_AC_Voucher_Main.Tables[0].DefaultView.RowFilter = "Meters>0";


            query = "select * from RIP_Godown_Greige where GodownEntryCode='" + packingListNumber + "'";
            DataSet ds = WS.svc.Get_DataSet(query);

            if (ds == null)
            {
                XtraMessageBox.Show("Invalid Packing list #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            Reports.Inspection_Greige_PackingList rpVoucher = new Reports.Inspection_Greige_PackingList();
            rpVoucher.BeginInit();


            rpVoucher.Dated.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Dated"]).ToString("dd-MMMM-yyyy");
            rpVoucher.Driver.Text = ds.Tables[0].Rows[0]["Driver"].ToString();
            rpVoucher.VehicleNumber.Text = ds.Tables[0].Rows[0]["VRN"].ToString();
            rpVoucher.vBarcode.Text = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString();
            rpVoucher.PLNO.Text = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString();
            rpVoucher.Party.Text = ds.Tables[0].Rows[0]["AccountName"].ToString();
            if (ds_AC_Voucher_Main != null)
                rpVoucher.DataSource = ds_AC_Voucher_Main;

            else
                rpVoucher.DataSource = null;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_ST_PR(string PRNO, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from ST_StorePR where PRNO='" + PRNO + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("PR # not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet ds_sub = WS.svc.Get_DataSet("select * from RST_StoreDetails where PRNO='" + PRNO + "'");
            if (ds_sub == null) return;
            if (ds_sub.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("PO Details not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
       


            Reports.Store_PurchaseRegister rpVoucher = new Reports.Store_PurchaseRegister();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PRNO"].ToString();
            rpVoucher.PODate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["Dated"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();
            //rpVoucher.vStatus.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["iStatus"].ToString();
            rpVoucher.PONumberforBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PRNO"].ToString();
            rpVoucher.PONO.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PONO"].ToString();
            rpVoucher.PRNO.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PRNO"].ToString();
            rpVoucher.AccountID.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AccountID"].ToString();
            rpVoucher.AccountName.Text = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(ds_AC_Voucher_Main.Tables[0].Rows[0]["AccountID"].ToString());


            rpVoucher.DataSource = ds_sub;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_ST_IssueNote(string PRNO, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from ST_StorePR where PRNO='" + PRNO + "' ");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("PR # not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet ds_sub = WS.svc.Get_DataSet("select * from RST_StoreDetails where PRNO='" + PRNO + "' order by SubDepartmentID");
            if (ds_sub == null) return;
            if (ds_sub.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("PO Details not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          

            Reports.Store_IssueRegister rpVoucher = new Reports.Store_IssueRegister();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PRNO"].ToString();

            rpVoucher.Dated.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["Dated"]).ToString("dd-MMM-yyyy");
            //rpVoucher.vStatus.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["iStatus"].ToString();
            rpVoucher.PONumberforBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PRNO"].ToString();
           // rpVoucher.RequisitionNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["RQNO"].ToString();
            rpVoucher.PRNO.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PRNO"].ToString();
            rpVoucher.MainRemarks.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["Remarks"].ToString();



            rpVoucher.DataSource = ds_sub;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_ST_ReceiveNote(string PRNO, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from ST_StorePR where PRNO='" + PRNO + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("PR # not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet ds_sub = WS.svc.Get_DataSet("select * from RST_StoreDetails where PRNO='" + PRNO + "'");
            if (ds_sub == null) return;
            if (ds_sub.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("PO Details not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           


            Reports.Store_ReceiveRegister rpVoucher = new Reports.Store_ReceiveRegister();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PRNO"].ToString();

            rpVoucher.Dated.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["Dated"]).ToString("dd-MMM-yyyy");
            //rpVoucher.vStatus.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["iStatus"].ToString();
            rpVoucher.PONumberforBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PRNO"].ToString();
            // rpVoucher.RequisitionNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["RQNO"].ToString();
            rpVoucher.PRNO.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PRNO"].ToString();
            rpVoucher.MainRemarks.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["Remarks"].ToString();



            rpVoucher.DataSource = ds_sub;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_ST_PurchaseReturn(string PRNO, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from ST_StorePR where PRNO='" + PRNO + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("PR # not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet ds_sub = WS.svc.Get_DataSet("select * from RST_StoreDetails where PRNO='" + PRNO + "'");
            if (ds_sub == null) return;
            if (ds_sub.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("PO Details not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          


            Reports.Store_PurchaseReturn rpVoucher = new Reports.Store_PurchaseReturn();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PRNO"].ToString();

            rpVoucher.Dated.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["Dated"]).ToString("dd-MMM-yyyy");
            //rpVoucher.vStatus.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["iStatus"].ToString();
            rpVoucher.PONumberforBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PRNO"].ToString();
            rpVoucher.PONO.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PONO"].ToString();
            rpVoucher.PRNO.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PRNO"].ToString();
            rpVoucher.MainRemarks.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["Remarks"].ToString();
            rpVoucher.AccountID.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AccountID"].ToString();
            rpVoucher.AccountName.Text = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(ds_AC_Voucher_Main.Tables[0].Rows[0]["AccountID"].ToString());


            rpVoucher.DataSource = ds_sub;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_FC_PO_Greige(string PONO, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from RFC_PO_Main where PONumber='" + PONO + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;

            DataSet dsArticle = WS.svc.Get_DataSet("select * from RFC_PO_YarnRequired where PONO='" + PONO + "'");
            DataSet dsTerms = WS.svc.Get_DataSet("Select * from RFC_PO_Terms where PONumber='" + PONO + "'");
            Reports.FC_PO rpVoucher = new Reports.FC_PO();
            Reports.FC_PO_GreigeDetails rpArticle = new Reports.FC_PO_GreigeDetails();
            Reports.FC_PO_TermsDetails rpTerms = new Reports.FC_PO_TermsDetails();
         

            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            rpVoucher.POType.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["POType"].ToString();
            rpVoucher.BarcodeNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PONumber"].ToString();
            rpVoucher.WeavingDepartment.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["DepartmentName"].ToString();
            rpVoucher.PoDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["Dated"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMMM-yyyy");
            if(ds_AC_Voucher_Main.Tables[0].Rows[0]["ExpiryDate"].ToString()!="")
            rpVoucher.Expirydate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["ExpiryDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMMM-yyyy");
            rpVoucher.PONumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PONumber"].ToString();
            rpVoucher.CommissionAgentName.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentName"].ToString();
            rpVoucher.CommissionAgentContactPerson.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentConcernedPerson1"].ToString();
            rpVoucher.CommissionAgentEmail.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentEmail"].ToString();
            rpVoucher.CommissionAgentFax.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentFax"].ToString();
            rpVoucher.CommissionAgentMailingAddress.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentMailingAddress"].ToString();
            //rpVoucher.CommissionAgentMobile.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentMobile1"].ToString();
            rpVoucher.CommissionAgentNTN.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentNTN"].ToString();
            //rpVoucher.CommissionAgentPersonEmail.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentCP1Email"].ToString();
            rpVoucher.CommissionAgentRate.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["CommissionRate"].ToString();
            rpVoucher.BuyerEmail.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerEmail"].ToString();
            rpVoucher.BuyerFax.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerFax"].ToString();
            rpVoucher.BuyerMailingAddress.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerMailingAddress"].ToString();
            rpVoucher.BuyerName.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerName"].ToString();
            rpVoucher.BuyerNTN.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerNTN"].ToString();

            rpVoucher.BuyerPhone.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerPhone1"].ToString() + "  " + ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerPhone2"].ToString();
            rpVoucher.BuyerSTN.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerGST"].ToString();
            rpVoucher.SellerEmail.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerEmail"].ToString();
            rpVoucher.SellerFax.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerFax"].ToString();
            rpVoucher.SellerMailingAddress.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerMailingAddress"].ToString();
            rpVoucher.SellerName.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerName"].ToString();
            rpVoucher.SellerNTN.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerNTN"].ToString();
            rpVoucher.SellerPhone.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerPhone1"].ToString() + "  " + ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerPhone2"].ToString();
            rpVoucher.SellerSTN.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerGST"].ToString();
           
            rpVoucher.ReferenceNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["ReferenceNumber"].ToString();
            if (dsArticle != null) rpArticle.DataSource = dsArticle.Tables[0];
            rpVoucher.SubReport_Article.ReportSource = rpArticle;
           
            if (dsTerms != null) rpTerms.DataSource = dsTerms.Tables[0];
            rpVoucher.SubReport_Terms.ReportSource = rpTerms;

           

            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_FC_PO_Towel(string PONO, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from RFC_PO_Main where PONumber='" + PONO + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;

            DataSet dsArticle = WS.svc.Get_DataSet("select * from RFC_PO_YarnRequired where PONO='" + PONO + "'");
           
            DataSet dsTerms = WS.svc.Get_DataSet("Select * from RFC_PO_Terms where PONO='" + PONO + "'");
          
            Reports.FC_PO rpVoucher = new Reports.FC_PO();
            Reports.FC_PO_TowelDetails rpArticle = new Reports.FC_PO_TowelDetails();
            Reports.FC_PO_TermsDetails rpTerms = new Reports.FC_PO_TermsDetails();
  

            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.POType.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["POType"].ToString();
            rpVoucher.BarcodeNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PONumber"].ToString();
            rpVoucher.PoDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["Dated"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMMM-yyyy");
            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["ExpiryDate"].ToString() != "")
                rpVoucher.Expirydate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["ExpiryDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMMM-yyyy");
            rpVoucher.PONumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PONumber"].ToString();
            rpVoucher.CommissionAgentName.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentName"].ToString();
            rpVoucher.CommissionAgentContactPerson.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentConcernedPerson1"].ToString();
            rpVoucher.CommissionAgentEmail.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentEmail"].ToString();
            rpVoucher.CommissionAgentFax.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentFax"].ToString();
            rpVoucher.CommissionAgentMailingAddress.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentMailingAddress"].ToString();
            //rpVoucher.CommissionAgentMobile.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentMobile1"].ToString();
            rpVoucher.CommissionAgentNTN.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentNTN"].ToString();
            //rpVoucher.CommissionAgentPersonEmail.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AgentCP1Email"].ToString();
            rpVoucher.CommissionAgentRate.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["CommissionRate"].ToString();
            rpVoucher.BuyerEmail.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerEmail"].ToString();
            rpVoucher.BuyerFax.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerFax"].ToString();
            rpVoucher.BuyerMailingAddress.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerMailingAddress"].ToString();
            rpVoucher.BuyerName.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerName"].ToString();
            rpVoucher.BuyerNTN.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerNTN"].ToString();

            rpVoucher.BuyerPhone.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerPhone1"].ToString() + "  " + ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerPhone2"].ToString();
            rpVoucher.BuyerSTN.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["BuyerGST"].ToString();
            rpVoucher.SellerEmail.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerEmail"].ToString();
            rpVoucher.SellerFax.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerFax"].ToString();
            rpVoucher.SellerMailingAddress.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerMailingAddress"].ToString();
            rpVoucher.SellerName.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerName"].ToString();
            rpVoucher.SellerNTN.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerNTN"].ToString();
            rpVoucher.SellerPhone.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerPhone1"].ToString() + "  " + ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerPhone2"].ToString();
            rpVoucher.SellerSTN.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["SellerGST"].ToString();

            rpVoucher.ReferenceNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["ReferenceNumber"].ToString();
            if (dsArticle != null) rpArticle.DataSource = dsArticle.Tables[0];
            rpVoucher.SubReport_Article.ReportSource = rpArticle;
           
            if (dsTerms != null) rpTerms.DataSource = dsTerms.Tables[0];
            rpVoucher.SubReport_Terms.ReportSource = rpTerms;
           
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_SW_SizingSummary(string SetNo, string PageSize)
        {
            Reports.SW_SizingSummary SizingSummaryReport = new Reports.SW_SizingSummary();
            Reports.SW_SizingSummary_Yarninfo SS_YarnInfo = new Reports.SW_SizingSummary_Yarninfo();
            Reports.SW_SizingSummary_SizingInfo SS_SizingInfo = new Reports.SW_SizingSummary_SizingInfo();
            DataSet ds = WS.svc.Get_DataSet("Select * From SWQ_Sizing where SetNo='" + SetNo + "'");
            if (ds == null)
            {
                XtraMessageBox.Show("invalid setno ", "Error", MessageBoxButtons.OK);
                return;
            }
            if (ds.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("invalid setno ", "Error", MessageBoxButtons.OK);
                return;
            }
            DataSet dsYarn = WS.svc.Get_DataSet("Select * from SWQ_Warping_YarnConsumption where WarpingProgramNumber='" + ds.Tables[0].Rows[0]["WarpingProgramNumber"].ToString() + "'");
            DataSet dsSizingDetails = WS.svc.Get_DataSet("Select * from SWQ_Sizing_Details where SetNo='" + SetNo + "'");


            if (dsYarn != null)
            {

                SS_YarnInfo.DataSource = dsYarn.Tables[0];
            }
            else
                SS_YarnInfo.DataSource = null;
            if (dsSizingDetails != null)
            {
                SS_SizingInfo.DataSource = dsSizingDetails.Tables[0];

            }
            else
                SS_SizingInfo.DataSource = null;
            SizingSummaryReport.BeginInit();
            if (PageSize== "H")
            {
                SizingSummaryReport.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                SizingSummaryReport.PageHeight = SizingSummaryReport.PageHeight / 2;
            }
            SizingSummaryReport.SetNo.Text = ds.Tables[0].Rows[0]["Setno"].ToString();
            SizingSummaryReport.BarcodeNumber.Text = ds.Tables[0].Rows[0]["Setno"].ToString();
            SizingSummaryReport.TotalBreaks.Text = ds.Tables[0].Rows[0]["Breakages"].ToString();
            SizingSummaryReport.TotalSizedBeams.Text = ds.Tables[0].Rows[0]["TotalSizedBeams"].ToString();
            SizingSummaryReport.RateperLbs.Text = ds.Tables[0].Rows[0]["RatePerlbs"].ToString();
            SizingSummaryReport.SizingDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["SizingDate"].ToString()).ToString("dd-MMM-yy");
            SizingSummaryReport.PartyID.Text = ds.Tables[0].Rows[0]["PartyID"].ToString();
            SizingSummaryReport.PartyName.Text = ds.Tables[0].Rows[0]["PartyName"].ToString();
            SizingSummaryReport.ArticleID.Text = ds.Tables[0].Rows[0]["ArticleNumber"].ToString();
            SizingSummaryReport.ArticleName.Text = ds.Tables[0].Rows[0]["ArticleShortName"].ToString();
            SizingSummaryReport.Department.Text = ds.Tables[0].Rows[0]["DeptWarpedForName"].ToString();
            SizingSummaryReport.SubReportYarnInfo.ReportSource = SS_YarnInfo;
            SizingSummaryReport.SubReportSizingInfo.ReportSource = SS_SizingInfo;
            SizingSummaryReport.EndInit();
            SizingSummaryReport.ShowPreview();
        }
    }
}
