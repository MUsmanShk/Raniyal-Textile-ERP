using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Inspection_Towel_PackingList : DevExpress.XtraReports.UI.XtraReport
    {
        int index = 0;
        public Inspection_Towel_PackingList()
        {
            InitializeComponent();
        }

        private void IndexNo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            index++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = index.ToString();
        }

        private void ArticleNumber_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            index = 0;
        }

    }
}
