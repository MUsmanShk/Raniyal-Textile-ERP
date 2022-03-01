using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Efficiency_ArticleWiseSubReport: DevExpress.XtraReports.UI.XtraReport
    {
        int index = 0;
        public Efficiency_ArticleWiseSubReport()
        {
            InitializeComponent();
        }

        private void Indexno_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            index++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = index.ToString();
        }

    }
}
