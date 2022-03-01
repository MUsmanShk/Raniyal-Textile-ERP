using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Yarn.ReportingParameters
{
    public partial class nYarnDyingPOLedger : DevExpress.XtraEditors.XtraUserControl
    {
        public nYarnDyingPOLedger()
        {
            InitializeComponent();
        }

        private void nYarnItemLedger_Load(object sender, EventArgs e)
        {
           
            TimeSpan ts = new TimeSpan(30, 0, 0, 0);
            this.ToDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            this.FromDate.DateTime = this.ToDate.DateTime.Subtract(ts);

        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
           

            if (this.DyingPartyAccount.EditValue == null || this.DyingPartyAccount.Tag == null)
            {
                XtraMessageBox.Show("Invalid Dying Account !", "Validaiton", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DyingPartyAccount.Focus();
                return;
            }
            if (this.DyingWorkOrderNumber.Visible == true)
            {
                if (this.DyingWorkOrderNumber.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Dying Work Order !", "Validaiton", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DyingPartyAccount.Focus();
                    return;
                }
            }
            if (DyingWorkOrderNumber.Visible == true)
                DyingLedger();
            else if (DyingWorkOrderNumber.Visible == false)
                DyingSummary();
           
        }
        private void DyingSummary()
        {
            Reports.nYarn_Summary_Doubling_PO YLedger = new Reports.nYarn_Summary_Doubling_PO();
            YLedger.RepH_DocumentName.Text = "Yarn Dying Work Order Ledger";
            YLedger.xr_FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            YLedger.xr_ToDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
           
            YLedger.Party.Text = this.DyingPartyAccount.EditValue.ToString();
            YLedger.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            string query = "Select REFPONO,YarnBagsType,YarnCount,YarnBrand,YarnBlend,YarnDesc,sum(case  when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then   BagsInward+BagsReceived-BagsOutWard-BagsIssued+BagsAdj else 0 end) as BagsOpening,sum(case when  Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsInward else 0 end) as BagsInward,Sum(case when  Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsReceived else 0 end) as BagsReceived,Sum(case when  Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOutWard else 0 end) as BagsOutward,Sum( case when  Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIssued else 0 end) as BagsIssued,Sum(case when  Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsAdj else 0 end) as BagsAdj,sum(  case when Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsInward+BagsReceived-BagsOutWard-BagsIssued+BagsAdj else 0 end) as BagsBalance,sum(case  when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then   LbsInward+LbsReceived-LbsOutWard-LbsIssued+LbsAdj else 0 end) as LbsOpening,sum(case when  Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsInward else 0 end) as LbsInward,Sum(case when  Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsReceived else 0 end) as LbsReceived,Sum(case when  Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOutWard else 0 end) as LbsOutward,Sum( case when  Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIssued else 0 end) as LbsIssued,Sum(case when  Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end) as LbsAdj,sum(  case when Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsInward+LbsReceived-LbsOutWard-LbsIssued+LbsAdj else 0 end) as LbsBalance from YNQ_Yarn where REFPONO in(Select PONumber  from FC_PO_Main where BuyerID='" + this.DyingPartyAccount.Tag.ToString() + "')  Group by REFPONO,YarnBagsType,YarnCount,YarnBrand,YarnBlend,YarnDesc ";







            if (this.DyingWorkOrderNumber.EditValue != null)
            {
                YLedger.Party.Text = this.DyingPartyAccount.Text;
              
            }
            DataSet ds = WS.svc.Get_DataSet(query);
            
           
            YLedger.BeginInit();

            if (ds != null)
                YLedger.DataSource = ds;
            else
                YLedger.DataSource = null;

           

           
            YLedger.EndInit();
            YLedger.ShowPreview();
        }
        private void DyingLedger()
        {
            Reports.nYarn_Ledger_Doubling_PO YLedger = new Reports.nYarn_Ledger_Doubling_PO();
            YLedger.RepH_DocumentName.Text = "Yarn Dying Work Orders Summary";
            YLedger.xr_FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            YLedger.xr_ToDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            YLedger.DoublingWorkOrderNumber.Text = this.DyingWorkOrderNumber.Text;
            YLedger.Party.Text = this.DyingPartyAccount.EditValue.ToString();
            YLedger.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            string OpeningQuery = "";
            string BalanceQuery = "";
            OpeningQuery = "Select sum(BagsInward)+Sum(BagsReceived)-Sum(BagsOutWard)-Sum(BagsIssued)+Sum(BagsAdj) as BagsBalance,sum(lbsInward)+Sum(lbsReceived)-Sum(lbsOutWard)-Sum(lbsIssued)+Sum(lbsAdj) as LbsBalance from YNQ_Yarn where Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' ";
            BalanceQuery = "Select sum(BagsInward)+Sum(BagsReceived)-Sum(BagsOutWard)-Sum(BagsIssued)+Sum(BagsAdj) as BagsBalance,sum(lbsInward)+Sum(lbsReceived)-Sum(lbsOutWard)-Sum(lbsIssued)+Sum(lbsAdj) as LbsBalance from YNQ_Yarn where Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' ";
            string query = "Select * from YNQ_Yarn where Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' ";







            if (this.DyingWorkOrderNumber.EditValue != null)
            {
                YLedger.Party.Text = this.DyingPartyAccount.Text;
                query += " and REFPONO='" + this.DyingWorkOrderNumber.EditValue.ToString() + "'";
                OpeningQuery += " and REFPONO='" + this.DyingWorkOrderNumber.EditValue.ToString() + "'";
                BalanceQuery += " and REFPONO='" + this.DyingWorkOrderNumber.EditValue.ToString() + "'";
            }
            DataSet ds = WS.svc.Get_DataSet(query);
            DataSet dsOpening = new DataSet();
            DataSet dsBalance = new DataSet();
            try
            {
                dsOpening = WS.svc.Get_DataSet(OpeningQuery);
            }
            catch
            {
            }
            try
            {
                dsBalance = WS.svc.Get_DataSet(BalanceQuery);
            }
            catch
            {
            }
            YLedger.BeginInit();

            if (ds != null)
                YLedger.DataSource = ds;
            else
                YLedger.DataSource = null;

            if (dsOpening != null)
            {
                if (dsOpening.Tables[0].Rows.Count > 0)
                {
                    double Bags = 0;
                    double Lbs = 0;
                    double.TryParse(dsOpening.Tables[0].Rows[0]["BagsBalance"].ToString(), out Bags);
                    double.TryParse(dsOpening.Tables[0].Rows[0]["LbsBalance"].ToString(), out Lbs);
                    YLedger.OpeningBags.Text = Bags.ToString("#,##0.0");
                    YLedger.OpeningLbs.Text = Lbs.ToString("#,##0.00");
                }
            }

            if (dsBalance != null)
            {
                if (dsBalance.Tables[0].Rows.Count > 0)
                {
                    double Bags = 0;
                    double Lbs = 0;
                    double.TryParse(dsBalance.Tables[0].Rows[0]["BagsBalance"].ToString(), out Bags);
                    double.TryParse(dsBalance.Tables[0].Rows[0]["LbsBalance"].ToString(), out Lbs);
                    YLedger.BalanceBags.Text = Bags.ToString("#,##0.0");
                    YLedger.BalanceLbs.Text = Lbs.ToString("#,##0.00");
                }
            }
            YLedger.EndInit();
            YLedger.ShowPreview();
        }
        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Yarn.ReportingParameters.Yarn_Reports mr = (MachineEyes.Yarn.ReportingParameters.Yarn_Reports)this.Parent.Parent;
            mr.Close();
        }

        private void Accountof_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                selectedrow sRow = new selectedrow();
                Data.Data_View DV = new Data.Data_View();
                DV.Load_View("select AccountID,AccountName,MailingAddress,ConcernedPerson1,ConcernedPerson2 from PP_Accounts order by AccountName", "AccountID", "AccountName");
                DV.sRow = sRow;
                DV.ShowDialog();
                if (DV.sRow != null)
                {
                    if (DV.sRow.Status == ParameterStatus.Selected)
                    {
                        this.DyingPartyAccount.Text = DV.sRow.PrimaryString;
                        this.DyingPartyAccount.Tag = DV.sRow.PrimeryID;
                    }
                }
            }
        }

        private void DoublingWorkOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                string query = "";

                query = "SELECT Distinct PONumber as WorkOrderNo,BUYERID as AccountID,BuyerName as AccountName from RFC_PO_Main where POStatusID=0 and POTYPEID ='14'";

                if (this.DyingPartyAccount.EditValue != null && this.DyingPartyAccount.Tag != null)
                {

                    query += " and ";

                    query += " BuyerID='" + this.DyingPartyAccount.Tag.ToString() + "'";
                }
                selectedrow sRow = new selectedrow();

                Data.Data_View FrmView = new Data.Data_View();
                FrmView.sRow = sRow;
                FrmView.Load_View(query, "WorkOrderNo", "AccountID");
                FrmView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {

                    if (sRow.SelectedDataRow == null)
                        return;
                    this.DyingWorkOrderNumber.EditValue = sRow.PrimeryID;
                  

                    try
                    {
                        this.DyingPartyAccount.EditValue = sRow.SelectedDataRow["AccountName"].ToString();
                        this.DyingPartyAccount.Tag = sRow.SelectedDataRow["AccountID"].ToString();

                    }
                    catch
                    {


                    }

                }



            }
        }
    }
}
