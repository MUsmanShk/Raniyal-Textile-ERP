using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class SW_SizingSummary_SizingInfo : DevExpress.XtraReports.UI.XtraReport
    {
        int indexnumber = 0;
        public SW_SizingSummary_SizingInfo()
        {
            InitializeComponent();
        }

        private void IndexNo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            indexnumber++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = indexnumber.ToString();
        }

    }
}
