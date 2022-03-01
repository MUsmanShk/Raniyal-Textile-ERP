using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Inspection_StockQualityWise : DevExpress.XtraReports.UI.XtraReport
    {
        int indexno = 0;
        public Inspection_StockQualityWise()
        {
            InitializeComponent();
        }

        private void index_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexno++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = indexno.ToString("#,##");
        }

    }
}
