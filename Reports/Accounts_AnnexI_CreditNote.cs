using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Accounts_AnnexI_CreditNote : DevExpress.XtraReports.UI.XtraReport
    {
        int index = 0;
        public Accounts_AnnexI_CreditNote()
        {
            InitializeComponent();
        }

        private void xr_Index_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            index++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = index.ToString();
        }

    }
}
