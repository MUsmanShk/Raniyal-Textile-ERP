using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Accounts_PurchasesSummary : DevExpress.XtraReports.UI.XtraReport
    {
        int index = 0;
        public Accounts_PurchasesSummary()
        {
            InitializeComponent();
        }

        private void InvoiceType_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            index = 0;
            XRLabel xr = (XRLabel)sender;
            if (xr.Tag.ToString().Substring(2, 1) == "1")
            {
                xr.Text = "Purchases";
            }
            else if (xr.Tag.ToString().Substring(2, 1) == "2")
            {
                xr.Text = "Return";
            }
        }

        private void xrIndex_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            index++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = index.ToString();
        }

    }
}
