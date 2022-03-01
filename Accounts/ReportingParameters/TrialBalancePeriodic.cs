using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Accounts.ReportingParameters
{
    public partial class TrialBalancePeriodic : DevExpress.XtraEditors.XtraForm
    {
        public TrialBalancePeriodic()
        {
            InitializeComponent();
        }

        private void TrialBalancePeriodic_Load(object sender, EventArgs e)
        {
            TimeSpan ts=new TimeSpan(30,0,0,0);
            this.ToDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            this.FromDate.DateTime = MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod;

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintLedger_Click(object sender, EventArgs e)
        {

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
            
            Reports.Accounts_TrialBalance_V TrialBalance = new Reports.Accounts_TrialBalance_V();
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


            string query = "SELECT     AccountID_I, AccountID_II, AccountID_III, AccountID_IV,AccountID_V, AccountName_V,AccountName_IV, SUM(CASE WHEN vDate < '" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' or VType='000' or Vtype='001'  THEN vDebitAmount ELSE 0 END) AS sDebit, " +
                      "sum(case when vDate <  '" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' or VType='000' or Vtype='001'  THEN vCreditAmount ELSE 0 END) AS sCredit, SUM(CASE WHEN vDate >= '" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' AND " +
                      "vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vType<>'000' and vType<>'001' THEN vDebitAmount ELSE 0 END) AS dDebit" +
                      ", SUM(CASE WHEN vDate >= '" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' AND vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vType<>'000' and vType<>'001' THEN vCreditAmount ELSE 0 END) AS dCredit, " +
                      " SUM(CASE WHEN vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) +
                      "' THEN vDebitAmount ELSE 0 END)-SUM(CASE WHEN vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  THEN vCreditAmount ELSE 0 END) AS eDebit, " +
                      "SUM(CASE WHEN vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  THEN vCreditAmount ELSE 0 END)-SUM(CASE WHEN vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' THEN vDebitAmount ELSE 0 END) AS eCredit FROM  dbo.Accounts_Vouchers where VCat in(" + VCat + ") and vYear='" + fYear + "' GROUP BY AccountID_I, AccountID_II, AccountID_III, AccountID_IV,AccountID_V, AccountName_V,AccountName_IV order by AccountID_I,AccountID_II,AccountID_III,AccountID_IV,AccountID_V";


            //string query = "SELECT     AccountID_I, AccountID_II, AccountID_III, AccountID_IV,AccountID_V, AccountName_V,AccountName_IV, SUM(CASE WHEN vYear='" + this.FromDate.DateTime.Year.ToString() + "' and ( vDate < '" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' or VType='000' or Vtype='001' ) THEN vDebitAmount ELSE 0 END) AS sDebit, " +
            //         "sum(case when vYear='" + this.FromDate.DateTime.Year.ToString() + "' and  ( vDate <  '" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' or VType='000' or Vtype='001' ) THEN vCreditAmount ELSE 0 END) AS sCredit, SUM(CASE WHEN vDate >= '" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' AND " +
            //         "vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vType<>'000' and vType<>'001' THEN vDebitAmount ELSE 0 END) AS dDebit" +
            //         ", SUM(CASE WHEN vDate >= '" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' AND vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vType<>'000' and vType<>'001' THEN vCreditAmount ELSE 0 END) AS dCredit, " +
            //         " SUM(CASE WHEN vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) +
            //         "' THEN vDebitAmount ELSE 0 END)-SUM(CASE WHEN vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  THEN vCreditAmount ELSE 0 END) AS eDebit, " +
            //         "SUM(CASE WHEN vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  THEN vCreditAmount ELSE 0 END)-SUM(CASE WHEN vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' THEN vDebitAmount ELSE 0 END) AS eCredit FROM  dbo.Accounts_Vouchers where VCat in(" + VCat + ") GROUP BY AccountID_I, AccountID_II, AccountID_III, AccountID_IV,AccountID_V, AccountName_V,AccountName_IV order by AccountID_I,AccountID_II,AccountID_III,AccountID_IV,AccountID_V";
            
            
            DataSet ds = WS.svc.Get_DataSet(query);
           // ds.Tables[0].DefaultView.RowFilter = "eDebit<>0 and eCredit<>0";
            TrialBalance.BeginInit();
            TrialBalance.RepH_Company.Text =  Program.ss.Machines.PresentationData.CPInfo.cpName;
            TrialBalance.Category.Text  = this.radioGroup1.EditValue.ToString();
            TrialBalance.Cap_Before.Text = "Before " + this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            TrialBalance.Cap_During.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy") + " to " + this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            TrialBalance.Cap_After.Text = "As On " + this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            TrialBalance.DataSource = ds;
            TrialBalance.EndInit();
            TrialBalance.ShowPreview();
        }
    }
}