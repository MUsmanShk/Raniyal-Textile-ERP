using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class HighestWarpBreakages : DevExpress.XtraReports.UI.XtraReport
    {
        public HighestWarpBreakages()
        {
            InitializeComponent();
        }

        private void xr_A_WarpETime_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (xr.Tag != null)
            {
                if(xr.Tag.ToString()!="")
                {
                    int WarpETime = Convert.ToInt32(xr.Tag.ToString());
                    TimeSpan ts = new TimeSpan(0, 0, WarpETime);
                    xr.Text = ts.Hours + ":" + ts.Minutes;
                }
            }
        }

        private void xr_A_PL_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;

            if (xr_A_WarpETime.Tag != null)
            {
                if (xr_A_WarpETime.Tag.ToString() != "")
                {
                    double  WarpETime = Convert.ToInt32(xr_A_WarpETime.Tag.ToString());
                   double s = Convert.ToDouble(WarpETime / (12 * 3600) * 100);
                   xr.Text = s.ToString("#,##0.00");
                }
            }
        }

        private void xr_B_WarpETime_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (xr.Tag != null)
            {
                if (xr.Tag.ToString() != "")
                {
                    int WarpETime = Convert.ToInt32(xr.Tag.ToString());
                    TimeSpan ts = new TimeSpan(0, 0, WarpETime);
                    xr.Text = ts.Hours + ":" + ts.Minutes;
                }
            }
        }

        private void xr_AB_WarpETime_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (xr.Tag != null)
            {
                if (xr.Tag.ToString() != "")
                {
                    int WarpETime = Convert.ToInt32(xr.Tag.ToString());
                    TimeSpan ts = new TimeSpan(0, 0, WarpETime);
                    xr.Text = ts.Hours + ":" + ts.Minutes;
                }
            }
        }

        private void xr_B_PL_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;

            if (xr_B_WarpETime.Tag != null)
            {
                if (xr_B_WarpETime.Tag.ToString() != "")
                {
                    double WarpETime = Convert.ToInt32(xr_B_WarpETime.Tag.ToString());
                    double s = Convert.ToDouble(WarpETime / (12 * 3600) * 100);
                    xr.Text = s.ToString("#,##0.00");
                }
            }
        }

        private void xr_AB_PL_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;

            if (xr_AB_WarpETime.Tag != null)
            {
                if (xr_AB_WarpETime.Tag.ToString() != "")
                {
                    double WarpETime = Convert.ToInt32(xr_AB_WarpETime.Tag.ToString());
                    double s = Convert.ToDouble(WarpETime / (12 * 3600) * 100);
                    xr.Text = s.ToString("#,##0.00");
                }
            }
        }

    }
}
