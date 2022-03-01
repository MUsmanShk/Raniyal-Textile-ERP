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
    public partial class xu_TrialBalanceConsolidated : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_TrialBalanceConsolidated()
        {
            InitializeComponent();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
            mr.Close();
        }

        private void PrintLedger_Click(object sender, EventArgs e)
        {

            Reports.Accounts_TrialBalanceFinalBalances TrialBalance = new Reports.Accounts_TrialBalanceFinalBalances();

            if (this.FromDate.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Starting Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.ToDate.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Ending Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string fYear = MachineEyes.Classes.Accounting.Return_FinancialYear(this.FromDate.DateTime);
            if (fYear == "")
            {
                XtraMessageBox.Show("Invalid financial year ...not found in directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string VCat = "";
            if (this.radioGroup1.EditValue == null)
            {
                radioGroup1.EditValue = "G";
            }
            if (this.radioGroup1.EditValue.ToString() == "G")
                VCat = "'G'";
            else if (this.radioGroup1.EditValue.ToString() == "N")
                VCat = "'N'";
            else if (this.radioGroup1.EditValue.ToString() == "B")
                VCat = "'G','N'";
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


            string query = "SELECT     AccountID_V, AccountName_V,SUM(vDebitAmount) -SUM(vCreditAmount) AS eDebit,SUM(vCreditAmount)-SUM(vDebitAmount) as eCredit,SUM(vDebitAmount)-SUM(vCreditAmount) as eBalance " +
                      " FROM  dbo.Accounts_Vouchers where VCat in(" + VCat + ") and vDate >= '" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vYear='" + fYear + "' GROUP BY AccountID_V, AccountName_V order by AccountID_V";
            //string query = "SELECT     AccountID_V, AccountName_V,SUM(vDebitAmount) AS eDebit,SUM(vCreditAmount) as eCredit,SUM(vDebitAmount)-SUM(vCreditAmount) as eBalance " +
            //      " FROM  dbo.Accounts_Vouchers where VCat in(" + VCat + ") and vDate >= '" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' GROUP BY AccountID_V, AccountName_V order by AccountID_V";
            DataSet ds = WS.svc.Get_DataSet(query);
            TrialBalance.BeginInit();
            TrialBalance.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            TrialBalance.Category.Text = this.radioGroup1.EditValue.ToString();
            TrialBalance.xr_FromDate.Text = "From:  " + this.FromDate.DateTime.ToString("dd-MMM-yyyy") + " To : " + this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            TrialBalance.DataSource = ds;
            TrialBalance.EndInit();
            TrialBalance.ShowPreview();
        }

        private void xu_TrialBalanceConsolidated_Load(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(30, 0, 0, 0);
            this.ToDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            this.FromDate.DateTime = MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod;
        }
    }
}
