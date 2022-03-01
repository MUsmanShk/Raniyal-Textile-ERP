using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class HighestWeftBreakages : DevExpress.XtraReports.UI.XtraReport
    {
        public HighestWeftBreakages()
        {
            InitializeComponent();
        }

        private void xr_A_WeftETime_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (xr.Tag != null)
            {
                if (xr.Tag.ToString() != "")
                {
                    int WeftETime = Convert.ToInt32(xr.Tag.ToString());
                    TimeSpan ts = new TimeSpan(0, 0, WeftETime);
                    xr.Text = ts.Hours + ":" + ts.Minutes;
                }
            }
        }

        private void xr_B_WeftETime_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (xr.Tag != null)
            {
                if (xr.Tag.ToString() != "")
                {
                    int WeftETime = Convert.ToInt32(xr.Tag.ToString());
                    TimeSpan ts = new TimeSpan(0, 0, WeftETime);
                    xr.Text = ts.Hours + ":" + ts.Minutes;
                }
            }
        }

        private void xr_AB_WeftETime_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (xr.Tag != null)
            {
                if (xr.Tag.ToString() != "")
                {
                    int WeftETime = Convert.ToInt32(xr.Tag.ToString());
                    TimeSpan ts = new TimeSpan(0, 0, WeftETime);
                    xr.Text = ts.Hours + ":" + ts.Minutes;
                }
            }
        }

        private void xr_A_PL_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;

            if (xr_A_WeftETime.Tag != null)
            {
                if (xr_A_WeftETime.Tag.ToString() != "")
                {
                    double WeftETime = Convert.ToInt32(xr_A_WeftETime.Tag.ToString());
                    double s = Convert.ToDouble(WeftETime / (12 * 3600) * 100);
                    xr.Text = s.ToString("#,##0.00");
                }
            }
        }

        private void xr_B_PL_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;

            if (xr_B_WeftETime.Tag != null)
            {
                if (xr_B_WeftETime.Tag.ToString() != "")
                {
                    double WeftETime = Convert.ToInt32(xr_B_WeftETime.Tag.ToString());
                    double s = Convert.ToDouble(WeftETime / (12 * 3600) * 100);
                    xr.Text = s.ToString("#,##0.00");
                }
            }
        }

        private void xr_AB_PL_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;

            if (xr_AB_WeftETime.Tag != null)
            {
                if (xr_AB_WeftETime.Tag.ToString() != "")
                {
                    double WeftETime = Convert.ToInt32(xr_AB_WeftETime.Tag.ToString());
                    double s = Convert.ToDouble(WeftETime / (12 * 3600) * 100);
                    xr.Text = s.ToString("#,##0.00");
                }
            }
        }

       

    }
}
