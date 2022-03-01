using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Accounts_Voucher_MDC : DevExpress.XtraReports.UI.XtraReport
    {
        public Accounts_Voucher_MDC()
        {
            InitializeComponent();
        }

        private void xrUserID_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel l = (XRLabel)sender;
            l.Text = MachineEyes.Classes.Security.User.SCodes.UserID;
        }

        private void FinancialYear_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int findex = MachineEyes.Classes.Accounting.Return_FinancialYear(MachineEyes.Classes.Accounting.RegAccounts.FinancialYear);
            if (findex != -1)
                FinancialYear.Text = MachineEyes.Classes.Accounting.FinancialYears[findex].YearFormat;
            else
                FinancialYear.Text = "Invalid";
        }

        private void xr_TotalAmount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                XRLabel xr = (XRLabel)sender;
                double amounttotal = 0;
                double.TryParse(xr.Summary.GetResult().ToString(), out amounttotal);
                xr_TotalAmountWords.Text = MachineEyes.Classes.Accounting.ReturnAmountInWords(amounttotal);
            }
            catch
            {
            }
        }

    }
}
