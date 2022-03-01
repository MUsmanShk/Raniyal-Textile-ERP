using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class FC_PO_TermsDetails : DevExpress.XtraReports.UI.XtraReport
    {
        int indexnumber = 0;
        public FC_PO_TermsDetails()
        {
            InitializeComponent();
        }

        private void index_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexnumber++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = indexnumber.ToString();
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexnumber = 0;
        }

    }
}
