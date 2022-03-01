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
    public partial class nYarnSizingPOLedger : DevExpress.XtraEditors.XtraUserControl
    {
        public nYarnSizingPOLedger()
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
           

            if (this.SizingPartyAccount.EditValue == null || this.SizingPartyAccount.Tag == null)
            {
                XtraMessageBox.Show("Invalid Doubling Account !", "Validaiton", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.SizingPartyAccount.Focus();
                return;
            }
            
                SizingLedger();
           
           
        }
        
        private void SizingLedger()
        {
            Reports.nYarn_Ledger_Sizing_PO YLedger = new Reports.nYarn_Ledger_Sizing_PO();
            YLedger.xr_FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            YLedger.xr_ToDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            YLedger.Party.Text = this.SizingPartyAccount.EditValue.ToString();
            YLedger.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            string OpeningQuery = "";
            string BalanceQuery = "";
            OpeningQuery = "Select sum(lbsInward)+Sum(lbsReceived)-Sum(lbsOutWard)-Sum(lbsIssued)+Sum(lbsAdj) as LbsBalance from YNQ_Yarn where Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and DeptID='00606' ";
            BalanceQuery = "Select sum(lbsInward)+Sum(lbsReceived)-Sum(lbsOutWard)-Sum(lbsIssued)+Sum(lbsAdj) as LbsBalance from YNQ_Yarn where Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and DeptID='00606' ";
            string query = "Select * from YNQ_Yarn where Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and DeptID='00606' ";







            if (this.SizingPartyAccount.Tag != null)
            {
                YLedger.Party.Text = this.SizingPartyAccount.Text;
                query += " and BuyerID='" + this.SizingPartyAccount.Tag.ToString() + "'";
                OpeningQuery += " and BuyerID='" + this.SizingPartyAccount.Tag.ToString() + "'";
                BalanceQuery += " and BuyerID='" + this.SizingPartyAccount.Tag.ToString() + "'";
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
                    
                    double Lbs = 0;
                   
                    double.TryParse(dsOpening.Tables[0].Rows[0]["LbsBalance"].ToString(), out Lbs);
                    
                    YLedger.OpeningLbs.Text = Lbs.ToString("#,##0.00");
                }
            }

            if (dsBalance != null)
            {
                if (dsBalance.Tables[0].Rows.Count > 0)
                {
                  
                    double Lbs = 0;
                
                    double.TryParse(dsBalance.Tables[0].Rows[0]["LbsBalance"].ToString(), out Lbs);
                   
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
                        this.SizingPartyAccount.Text = DV.sRow.PrimaryString;
                        this.SizingPartyAccount.Tag = DV.sRow.PrimeryID;
                    }
                }
            }
        }

        
    }
}
