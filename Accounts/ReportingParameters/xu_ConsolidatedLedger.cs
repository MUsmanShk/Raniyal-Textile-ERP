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
    public partial class xu_ConsolidatedLedger : DevExpress.XtraEditors.XtraUserControl
    {
        public string AccountLevel = "4";
        public xu_ConsolidatedLedger()
        {
            InitializeComponent();
        }

        private void xu_ConsolidatedLedger_Load(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(30, 0, 0, 0);
            this.ToDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            this.FromDate.DateTime = this.ToDate.DateTime.Subtract(ts);
           
        }

        private void BrowseAccountof_Click(object sender, EventArgs e)
        {
            string query="";
            selectedrow sRow = new selectedrow();
            if(AccountLevel =="4")
                          query= "Select AccountID_IV as AccountID,AccountName_IV as AccountName,AccountID_III as ReferencedAccount from AC_Level_IV order by AccountName_IV";
            else if(AccountLevel =="3")
                query = "Select AccountID_III as AccountID,AccountName_III as AccountName,AccountID_II as ReferencedAccount from AC_Level_III order by AccountName_III";
            else if (AccountLevel == "2")
                query = "Select AccountID_II as AccountID,AccountName_II as AccountName,AccountID_I as ReferencedAccount from AC_Level_II order by AccountName_II";
            else if (AccountLevel == "1")
                query = "Select AccountID_I as AccountID,AccountName_I as AccountName from AC_Level_I order by AccountName_I";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(query , "AccountID", "AccountName");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.AccountID.Text  = sRow.PrimeryID;
                this.AccountName.Text  = sRow.PrimaryString;
      

            }
        }

        private void PrintLedger_Click(object sender, EventArgs e)
        {
            Reports.Accounts_LedgerConsolidated Ledger = new Reports.Accounts_LedgerConsolidated();

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
            if (this.AccountID.Text == "" )
            {
                XtraMessageBox.Show("Select Valid Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountName.Text == "")
            {
                XtraMessageBox.Show("Select Valid Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            string LedgerAccountID = this.AccountID.Text;
            string query="";
            Ledger.BeginInit();
            if(AccountLevel =="4")
            {
                query = "Select AccountID_V as AccountID , AccountName_V as AccountName,sum(case when vDate<'" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  vtype not in('000','001') then vDebitAmount-vCreditAmount else 0 end)+sum(case when vtype in('000','001') and vYear='" + fYear + "' then vDebitAmount-vCreditAmount else 0 end) as TotalBalanceBF,sum(case when vDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vtype not in('000','001') then vDebitAmount else 0 end) as TotalDebit,sum(case when vDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  and vtype not in('000','001') then vCreditAmount else 0 end) as TotalCredit,sum(case when vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  vType not in('000','0001') then vDebitAmount-vCreditAmount else 0 end)+sum(case when vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vType in('000','0001') and vYear='" + fYear + "' then vDebitAmount-vCreditAmount else 0 end) as TotalBalanceCF from Accounts_Vouchers_AllLevelAccounts where AccountID_IV='" + LedgerAccountID + "' and VCat in(" + VCat + ") and vYear='" + fYear + "' group by AccountID_V,AccountName_V";
                Ledger.xrLevel.Text = "Fourth";
            }
            else if (AccountLevel == "3")
            {
                query = "Select AccountID_IV as AccountID , AccountName_IV as AccountName,sum(case when vDate<'" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  vtype not in('000','001') then vDebitAmount-vCreditAmount else 0 end)+sum(case when vtype in('000','001') and vYear='" + fYear + "' then vDebitAmount-vCreditAmount else 0 end) as TotalBalanceBF,sum(case when vDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vtype not in('000','001') then vDebitAmount else 0 end) as TotalDebit,sum(case when vDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  and vtype not in('000','001') then vCreditAmount else 0 end) as TotalCredit,sum(case when vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  vType not in('000','0001') then vDebitAmount-vCreditAmount else 0 end)+sum(case when vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vType in('000','0001') and vYear='" + fYear + "' then vDebitAmount-vCreditAmount else 0 end) as TotalBalanceCF from Accounts_Vouchers_AllLevelAccounts where AccountID_III='" + LedgerAccountID + "' and VCat in(" + VCat + ") and vYear='" + fYear + "' group by AccountID_IV,AccountName_IV";
                Ledger.xrLevel.Text = "Third";
            }
            else if (AccountLevel == "2")
            {
                query = "Select AccountID_III as AccountID , AccountName_III as AccountName,sum(case when vDate<'" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  vtype not in('000','001') then vDebitAmount-vCreditAmount else 0 end)+sum(case when vtype in('000','001') and vYear='" + fYear + "' then vDebitAmount-vCreditAmount else 0 end) as TotalBalanceBF,sum(case when vDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vtype not in('000','001') then vDebitAmount else 0 end) as TotalDebit,sum(case when vDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  and vtype not in('000','001') then vCreditAmount else 0 end) as TotalCredit,sum(case when vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  vType not in('000','0001') then vDebitAmount-vCreditAmount else 0 end)+sum(case when vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vType in('000','0001') and vYear='" + fYear + "' then vDebitAmount-vCreditAmount else 0 end) as TotalBalanceCF from Accounts_Vouchers_AllLevelAccounts where AccountID_II='" + LedgerAccountID + "' and VCat in(" + VCat + ") and vYear='" + fYear + "' group by AccountID_III,AccountName_III";
                Ledger.xrLevel.Text = "Second";
            }
            else if (AccountLevel == "1")
            {
                query = "Select AccountID_II as AccountID , AccountName_II as AccountName,sum(case when vDate<'" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  vtype not in('000','001') then vDebitAmount-vCreditAmount else 0 end)+sum(case when vtype in('000','001') and vYear='" + fYear + "' then vDebitAmount-vCreditAmount else 0 end) as TotalBalanceBF,sum(case when vDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vtype not in('000','001') then vDebitAmount else 0 end) as TotalDebit,sum(case when vDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  and vtype not in('000','001') then vCreditAmount else 0 end) as TotalCredit,sum(case when vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  vType not in('000','0001') then vDebitAmount-vCreditAmount else 0 end)+sum(case when vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vType in('000','0001') and vYear='" + fYear + "' then vDebitAmount-vCreditAmount else 0 end) as TotalBalanceCF from Accounts_Vouchers_AllLevelAccounts where AccountID_I='" + LedgerAccountID + "'  and VCat in(" + VCat + ") and vYear='" + fYear + "' group by AccountID_II,AccountName_II";
                Ledger.xrLevel.Text = "First";
            }
            DataSet ds = WS.svc.Get_DataSet(query);

           

           
            Ledger.xr_FromDate.Text = this.FromDate.DateTime.ToLongDateString();
            Ledger.xr_ToDate.Text = this.ToDate.DateTime.ToLongDateString();
            Ledger.xr_Accountof.Text = LedgerAccountID;
            Ledger.xr_AccountofName.Text = this.AccountName.Text;
            Ledger.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Ledger.DataSource = ds;


                }
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

        private void AccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                string query = "";
                selectedrow sRow = new selectedrow();
                if (AccountLevel == "4")
                    query = "Select AccountID_IV as AccountID,AccountName_IV as AccountName,AccountID_III as ReferencedAccount from AC_Level_IV order by AccountName_IV";
                else if (AccountLevel == "3")
                    query = "Select AccountID_III as AccountID,AccountName_III as AccountName,AccountID_II as ReferencedAccount from AC_Level_III order by AccountName_III";
                else if (AccountLevel == "2")
                    query = "Select AccountID_II as AccountID,AccountName_II as AccountName,AccountID_I as ReferencedAccount from AC_Level_II order by AccountName_II";
                else if (AccountLevel == "1")
                    query = "Select AccountID_I as AccountID,AccountName_I as AccountName from AC_Level_I order by AccountName_I";
                Data.Data_View FrmView = new Data.Data_View();
                FrmView.Load_View(query, "AccountID", "AccountName");
                FrmView.sRow = sRow;
                FrmView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {

                    if (sRow.SelectedDataRow == null)
                        return;
                    this.AccountID.Text = sRow.PrimeryID;
                    this.AccountName.Text = sRow.PrimaryString;


                }
            }
        }
    }
}
