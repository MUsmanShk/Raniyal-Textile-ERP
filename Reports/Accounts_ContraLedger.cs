using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Accounts_ContraLedger : DevExpress.XtraReports.UI.XtraReport
    {
        private int indexnumber = 0;
        public double RunningBalance = 0;
        public Accounts_ContraLedger()
        {
            InitializeComponent();
        }
        public double  Get_RunningBalance()
        {
            double rBalance = RunningBalance;
            return rBalance;
        }
        private void xr_Index_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexnumber++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = indexnumber.ToString();
        }

        private void xr_RunningBalance_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (xr_Debit.Tag != null)
                RunningBalance = RunningBalance + Convert.ToDouble(xr_Debit.Tag.ToString());
            if (xr_Credit.Tag != null)
                RunningBalance = RunningBalance - Convert.ToDouble(xr_Credit.Tag.ToString());
            XRLabel xr = (XRLabel)sender;
            if (RunningBalance != 0)
            {

                xr.Text = RunningBalance.ToString("#,##;(#,##)");
            }
            else
                xr.Text = "0";
        }

        private void xr_TotalBalance_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (RunningBalance != 0)
            {

                xr.Text = RunningBalance.ToString("#,##;(#,##)");
            }
            else
                xr.Text = "0";
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
