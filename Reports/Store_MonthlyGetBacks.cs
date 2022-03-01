using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Store_MonthlyGetBacks : DevExpress.XtraReports.UI.XtraReport
    {
        int indexno = 0;
        public Store_MonthlyGetBacks()
        {
            InitializeComponent();
        }

        private void PRIndexNumber_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexno++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = indexno.ToString();
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexno = 0;
        }

    }
}
