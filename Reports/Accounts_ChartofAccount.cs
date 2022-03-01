using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Accounts_ChartofAccount : DevExpress.XtraReports.UI.XtraReport
    {
        int index = 0;
        public Accounts_ChartofAccount()
        {
            InitializeComponent();
            
        }

        private void AccountIndex_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            index++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = index.ToString();
        }

        private void AccountName_IV_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            index = 0;
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
