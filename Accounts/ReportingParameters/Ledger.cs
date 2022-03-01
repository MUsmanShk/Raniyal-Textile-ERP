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
    public partial class Ledger : DevExpress.XtraEditors.XtraForm
    {
        public Ledger()
        {
            InitializeComponent();
           
        }

        private void BrowseAccountof_Click(object sender, EventArgs e)
        {
            Program.MainWindow.AccountsList.ShowDialog();
            if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
            {
                this.AccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                this.AccountName.Text = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
                this.AccountName.Tag = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
            }

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintLedger_Click(object sender, EventArgs e)
        {
            Reports.Accounts_Ledger Ledger = new Reports.Accounts_Ledger();
           
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
            //string PreviousFinancialYear = Convert.ToString(this.FromDate.DateTime.Year - 1);
            //string dBalance = "D_" + PreviousFinancialYear;
            //string cBalance = "C_" + PreviousFinancialYear;
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
            string balancequery = "Select sum( case when vDate<'" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vType not in('000','001') then  vDebitAmount-vCreditAmount else 0 end )+sum( case when vYear='" + fYear + "' and vType in('000','001') then  vDebitAmount-vCreditAmount else 0 end ) as Balance from Accounts_Vouchers where AccountID_V='" + this.AccountID.Text + "' and vYear='"+fYear+"' and VCat in(" + VCat + ") ";
            DataSet ds = WS.svc.Get_DataSet(balancequery);
            Ledger.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
               Ledger.BeginInit();
            if (ds == null)
                Ledger.RunningBalance = 0;
            else if (ds.Tables[0].Rows.Count <= 0)
                Ledger.RunningBalance = 0;
            else if (ds.Tables[0].Rows.Count > 0)
                               if(ds.Tables[0].Rows[0]["Balance"]!=DBNull.Value)
                Ledger.RunningBalance = Convert.ToDouble(ds.Tables[0].Rows[0]["Balance"]);
            Ledger.xr_Balance.Text = Ledger.Get_RunningBalance().ToString("#,##;(#,##)");
            Ledger.xr_FromDate.Text = this.FromDate.DateTime.ToLongDateString();
            Ledger.xr_ToDate.Text = this.ToDate.DateTime.ToLongDateString();
            Ledger.xr_Accountof.Text = this.AccountID.Text;
            Ledger.xr_AccountofName.Text = this.AccountName.Text;
            ds = WS.svc.Get_DataSet("Select * from Accounts_Vouchers where AccountID_V='" + this.AccountID.Text + "' and vDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and VType<>'000' and vType<>'001' and VCat in(" + VCat + ") and vYear='" + fYear + "' order by vDate,Convert(numeric(18),VNumber) ");
            //if (ds == null)
            //{
            //    XtraMessageBox.Show("No record found for the period , balance B/F was " + Ledger.RunningBalance.ToString("#,##;(#,##)") + "", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //if (ds.Tables[0].Rows.Count<=0)
            //{
            //    XtraMessageBox.Show("No record found for the period , balance B/F was " + Ledger.RunningBalance.ToString("#,##;(#,##)") + "", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

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

        private void Ledger_Load(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(30, 0, 0, 0);
            this.ToDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            this.FromDate.DateTime = MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod;
        }

        private void AccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.AccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                    this.AccountName.Text = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
                    this.AccountName.Tag = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
                }
            }
        }
    }
}