using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Accounts_SalesSummary : DevExpress.XtraReports.UI.XtraReport
    {
        int index = 0;
        public Accounts_SalesSummary()
        {
            InitializeComponent();
        }

        private void AccountID_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            index = 0;
        }

        private void xrIndex_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            index++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = index.ToString();
        }

    }
}
