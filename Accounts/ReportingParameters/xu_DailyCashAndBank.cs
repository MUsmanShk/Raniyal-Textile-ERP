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
    public partial class xu_DailyCashAndBank : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_DailyCashAndBank()
        {
            InitializeComponent();
            this.Dated.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
          
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            Reports.Accounts_DailyCashAndBank CashBank = new Reports.Accounts_DailyCashAndBank();


            if (this.Dated.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date from which you want to see records", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.Dated.DateTime == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SelectedDate.Date = this.Dated.DateTime;

            string query = "select * from Accounts_Vouchers_DailyCashAndBank where isHead=0  and vNumber in(select vNumber from AC_Voucher_Main where vDate='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vnumber in(select vnumber from Accounts_Vouchers_DailyCashAndBank where AccountID_IV in('"+MachineEyes.Classes.Accounting.RegAccounts.Bank_IV+"','"+MachineEyes.Classes.Accounting.RegAccounts.Cash_IV+"')))";
            DataSet ds = WS.svc.Get_DataSet(query);


            if (ds == null)
            {
                XtraMessageBox.Show("No records found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (ds.Tables[0].Rows.Count<=0)
            {
                XtraMessageBox.Show("No records found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //Ledger.xr_FromDate.Text = this.FromDate.DateTime.ToLongDateString();
            //Ledger.xr_ToDate.Text = this.ToDate.DateTime.ToLongDateString();
            //Ledger.xr_Accountof.Text = this.AccountID.Text;
            // Ledger.xr_AccountofName.Text = this.AccountName.Text;
            //ds = WS.svc.Get_DataSet("Select * from Accounts_Vouchers where AccountID_V='" + this.AccountID.Text + "' and vDate>='" + FromDate.DateTime.ToString("s") + "' and vDate<='" + ToDate.DateTime.ToString("s") + "' ");
            CashBank.BeginInit();
            CashBank.repH_Dated.Text =this.Dated.DateTime.ToString("dd-MMM-yyyy");
            CashBank.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            CashBank.DataSource = ds;
            CashBank.EndInit();
            CashBank.ShowPreview();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
            mr.Close();
        }
    }
}
