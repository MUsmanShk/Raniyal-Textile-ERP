using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Accounts_TrialBalanceEnding : DevExpress.XtraReports.UI.XtraReport
    {
        Int64 GroupDebit = 0; Int64 GroupCredit = 0;
        Int64 TDebit = 0; Int64 TCredit = 0;
        int indexno = 0;
        public Accounts_TrialBalanceEnding()
        {
            InitializeComponent();
        }

        private void AccountV_Debit_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
            XRLabel xr = (XRLabel)sender;
            int debit = 0;
            if(xr.Tag!=null)
            int.TryParse(xr.Tag.ToString(), out debit);
            if (debit > 0)
            {
                xr.Text = debit.ToString("#,##");
                GroupDebit += debit;
                TDebit += debit;
            }
            else
                xr.Text = "";
           
        }

        private void AccountV_Credit_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            int credit = 0;
            if(xr.Tag!=null)
            int.TryParse(xr.Tag.ToString(), out credit);
            if (credit > 0)
            {
                xr.Text = credit.ToString("#,##");
                GroupCredit += credit;
                TCredit += credit;
            }
            else
                xr.Text = "";
           
        }

        private void AccountIV_Debit_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            XRLabel xr = (XRLabel)sender;
            xr.Text = GroupDebit.ToString("#,##");
            GroupDebit = 0;
        }

        private void AccountIV_Credit_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            xr.Text = GroupCredit.ToString("#,##");
            GroupCredit = 0;
            indexno = 0;
        }

        private void index_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexno++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = indexno.ToString();

        }

        private void TotalDebit_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            xr.Text = TDebit.ToString("#,##");
        }

        private void TotalCredit_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            xr.Text = TCredit.ToString("#,##");
        }

        private void FinancialYear_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int findex = MachineEyes.Classes.Accounting.Return_FinancialYear(MachineEyes.Classes.Accounting.RegAccounts.FinancialYear);
            if (findex != -1)
                FinancialYear.Text = MachineEyes.Classes.Accounting.FinancialYears[findex].YearFormat;
            else
                FinancialYear.Text = "Invalid";
        }

    }
}
