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
    public partial class xu_Contraledger : DevExpress.XtraEditors.XtraUserControl
    {
        public string Account_IV;
        public xu_Contraledger()
        {
            InitializeComponent();
        }


        private void xu_Contraledger_Load(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(30, 0, 0, 0);
            this.ToDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            this.FromDate.DateTime = MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod;
            this.AccountIV.Text = Account_IV;
        }

        private void PrintLedger_Click(object sender, EventArgs e)
        {

            Reports.Accounts_ContraLedger Ledger = new Reports.Accounts_ContraLedger();

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
            if (this.AccountID.Text == "" || this.AccountIV.Text == "")
            {
                XtraMessageBox.Show("Select Valid Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountName.Text =="")
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
            string LedgerAccountID = this.AccountIV.Text + this.AccountID.Text;
           // string balancequery = "Select sum(case when vDate<'" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  and vType not in('000','001') then  vDebitAmount-vCreditAmount)+sum(case when vYear='" + fYear + "'  and vType in('000','001') then  vDebitAmount-vCreditAmount) as Balance from Accounts_Vouchers where AccountID_V='" + LedgerAccountID + "' and VCat in(" + VCat + ") and vYear='" + fYear + "' ";
            string balancequery = "Select sum( case when vDate<'" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vType not in('000','001') then  vDebitAmount-vCreditAmount else 0 end )+sum( case when vYear='" + fYear + "' and vType in('000','001') then  vDebitAmount-vCreditAmount else 0 end ) as Balance from Accounts_Vouchers where AccountID_V='" + LedgerAccountID + "' and vYear='" + fYear + "' and VCat in(" + VCat + ") ";
            DataSet ds = WS.svc.Get_DataSet(balancequery);
            
            Ledger.BeginInit();
            if (ds == null)
                Ledger.RunningBalance = 0;
            else if (ds.Tables[0].Rows.Count <= 0)
                Ledger.RunningBalance = 0;
            else if (ds.Tables[0].Rows.Count > 0)
                if (ds.Tables[0].Rows[0]["Balance"] != DBNull.Value)
                    Ledger.RunningBalance = Convert.ToDouble(ds.Tables[0].Rows[0]["Balance"]);
            Ledger.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            Ledger.xr_Balance.Text = Ledger.Get_RunningBalance().ToString("#,##;(#,##)");
            Ledger.xr_FromDate.Text = this.FromDate.DateTime.ToLongDateString();
            Ledger.xr_ToDate.Text = this.ToDate.DateTime.ToLongDateString();
            Ledger.xr_Accountof.Text = LedgerAccountID;
            Ledger.xr_AccountofName.Text = this.AccountName.Text;
            ds = WS.svc.Get_DataSet("Select * from Accounts_Vouchers where vNumber in (select vNumber from AC_Voucher_Sub where AccountID_V='" + LedgerAccountID + "') and VCat in(" + VCat + ") and vDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and VType<>'000' and vType<>'001' and  AccountID_V<>'" + LedgerAccountID + "' and vYear='" + fYear + "' order by vDate,Convert(numeric(18),VNumber) ");
           // ds = WS.svc.Get_DataSet("Select * from Accounts_Vouchers where  vDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and VType<>'000' and vType<>'001' and  AccountID_V='" + LedgerAccountID + "' order by vDate,Convert(numeric(18),VNumber) ");
            
            //string detailquery = "Select * from Accounts_Vouchers_L5 where vNumber in (select vNumber from AC_Voucher_Sub where AccountID_V='" + LedgerAccountID + "') and vnumber in(select vnumber from AC_Voucher_Main where vDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and VType<>'000' and vType<>'001') and  AccountID_V<>'" + LedgerAccountID + "'";
            //DataSet detailaccounts = WS.svc.Get_DataSet(detailquery);
            //detailaccounts.Tables[0].TableName = "tables_Accounts1 - Accounts_Vouchers.Accounts_Vouchers_Accounts_Vouchers_L5";
            //ds.Tables.Add(detailaccounts.Tables[0].Copy());

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

        private void BrowseAccountof_Click(object sender, EventArgs e)
        {

            try
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.AccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID.Substring(10, 3);

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void AccountID_TextChanged(object sender, EventArgs e)
        {
            if (this.AccountID.Text.Length == 3)
            {
                string hName = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(this.AccountIV.Text + this.AccountID.Text);
               this.AccountName.Text = hName;
               
            }
            else
            {
                this.AccountName.Text = "";
               
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
            mr.Close();
        }
    }
}
