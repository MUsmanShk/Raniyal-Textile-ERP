using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class ColorIndications : DevExpress.XtraReports.UI.XtraReport
    {
        public ColorIndications()
        {
            InitializeComponent();
        }

        private void xr_Color_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;

            if (xr.Tag != null)
            {
                ColorConverter cr = new ColorConverter();
                
                xr.BackColor = (Color)cr.ConvertFromString(xr.Tag.ToString());
            }
        }

    }
}
