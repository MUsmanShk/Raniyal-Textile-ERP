using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Store_ClosingStock : DevExpress.XtraReports.UI.XtraReport
    {
        int indexno = 0;
        public Store_ClosingStock()
        {
            InitializeComponent();
        }

        private void FinancialYear_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int findex = MachineEyes.Classes.Accounting.Return_FinancialYear(MachineEyes.Classes.Accounting.RegAccounts.FinancialYear);
            if (findex != -1)
                FinancialYear.Text = MachineEyes.Classes.Accounting.FinancialYears[findex].YearFormat;
            else
                FinancialYear.Text = "Invalid";
        }

        private void ItemIndex_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexno++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = indexno.ToString();
        }

        private void Group_GroupItems_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void GroupAccountID_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexno = 0;
        }

    }
}
