using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Efficiency_TopWorseLooms: DevExpress.XtraReports.UI.XtraReport
    {
        int index = 0;
        public Efficiency_TopWorseLooms()
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