using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Accounts_BankPaymentVoucher : DevExpress.XtraReports.UI.XtraReport
    {
        public Accounts_BankPaymentVoucher()
        {
            InitializeComponent();
        }

        private void xr_TotalAmount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                XRLabel xr = (XRLabel)sender;
                double amounttotal = 0;
                double.TryParse(xr.Text, out amounttotal);
                xr_TotalAmountWords.Text = MachineEyes.Classes.Accounting.ReturnAmountInWords(amounttotal);
            }
            catch
            {
            }
        }

        private void xrUserID_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel l = (XRLabel)sender;
            l.Text =MachineEyes.Classes.Security.User.SCodes.UserID;
        }

        private void xrUserName_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel l = (XRLabel)sender;
            l.Text =MachineEyes.Classes.Security.User.SCodes.UserName;
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
