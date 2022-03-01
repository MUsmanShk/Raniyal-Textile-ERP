using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Accounts.ReportingParameters
{
    public partial class xu_PurchasesSummary_AccountsWise : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_PurchasesSummary_AccountsWise()
        {
            InitializeComponent();
        }

        private void AccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.AccountID.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                    this.AccountName.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
                }
            }
            else if (e.KeyCode == Keys.F1 && this.AccountID.EditValue != null)
            {

                Accounts.Account_info info = new Accounts.Account_info();
                info.FillAccount(this.AccountID.Text);
                info.ShowDialog();


            }
        }

        private void xu_PurchasesSummary_AccountsWise_Load(object sender, EventArgs e)
        {
           
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            Reports.Accounts_PurchasesSummary_InvoiceWise_GroupParty Ledger = new Reports.Accounts_PurchasesSummary_InvoiceWise_GroupParty();
            if (this.FromDate.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date from which you want to see ledger records", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.ToDate.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective To Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.FromDate.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.ToDate.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.radioGroup1.EditValue == null)
            {
                radioGroup1.EditValue = "G";
            }
            if (this.AccountID.EditValue == null)
            {
                XtraMessageBox.Show("invalid Account", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.AccountName.EditValue == null)
            {
                XtraMessageBox.Show("invalid Account name", "Error", MessageBoxButtons.OK);
                return;
            }
            string fYear = MachineEyes.Classes.Accounting.Return_FinancialYear(this.FromDate.DateTime);
            if (fYear == "")
            {
                XtraMessageBox.Show("Invalid financial year ...not found in directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string VCat = "";
            if (this.radioGroup1.EditValue.ToString() == "G")
                VCat = "'G'";
            else if (this.radioGroup1.EditValue.ToString() == "N")
                VCat = "'N'";
            else if (this.radioGroup1.EditValue.ToString() == "B")
                VCat = "'G','N'";
            // string BalanceFinancialQuery = "Select (sum(" + dBalance + ")+sum(vDebitAmount))- (sum(vCreditAmount)-sum(" + cBalance + ")) as Balance from Accounts_Vouchers where AccountID_V='" + this.AccountID.Text + "' and VCat in(" + VCat + ") and (vDate<'" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' or vType='000' or vType='001') ";
            string balancequery = "Select sum( case when vDate<'" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vType not in('000','001') then  vDebitAmount-vCreditAmount else 0 end )+sum( case when vYear='" + fYear + "' and vType in('000','001') then  vDebitAmount-vCreditAmount else 0 end ) as Balance from Accounts_Vouchers where AccountID_V='" + this.AccountID.Text + "' and vYear='" + fYear + "' and VCat in(" + VCat + ") ";
            DataSet ds = WS.svc.Get_DataSet(balancequery);
        
            Ledger.BeginInit();
            Ledger.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            Ledger.xr_Accountof.Text = this.AccountID.EditValue.ToString();
            Ledger.xr_AccountofName.Text = this.AccountName.EditValue.ToString();

            Ledger.xr_FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            Ledger.xr_ToDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            Ledger.xr_Accountof.Text = this.AccountID.EditValue.ToString();
            Ledger.xr_AccountofName.Text = this.AccountName.EditValue.ToString();
            string gquery = "Select * from Accounts_Purchases_Sub where SupplierID='" + this.AccountID.EditValue.ToString() + "' and iDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and iDate<='" + ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and iCat in(" + VCat + ") and iYear='" + fYear + "' order by iDate,Convert(numeric(18),iNumber) ";
            ds = WS.svc.Get_DataSet(gquery);
            
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    Ledger.DataSource = ds;
                else
                    Ledger.DataSource = null;
            }
            else
                Ledger.DataSource = null;
            Ledger.EndInit();
            Ledger.ShowPreview();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
            mr.Close();
        }
    }
}
