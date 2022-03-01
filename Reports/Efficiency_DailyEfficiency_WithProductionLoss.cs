using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Efficiency_DailyEfficiency_WithProductionLoss : DevExpress.XtraReports.UI.XtraReport
    {
        double A_WarpAvgTime, A_WarpAvgTimeCounts, A_WeftAvgTime, A_WeftAvgTimeCounts;
        double TA_WarpAvgTime, TA_WarpAvgTimeCounts, TA_WeftAvgTime, TA_WeftAvgTimeCounts;
        public Efficiency_DailyEfficiency_WithProductionLoss()
        {
            InitializeComponent();
        }

        private void BeforePrint_SecondsToTimeFormat(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);

                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(secs));
                xr.Text = Program.ss.Get_FormattedTime(ts,(int)TimeFormats.MMSS);
            }
        }

        private void BeforePrint_LongSecondsToTimeFormat(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);

                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(secs));
                xr.Text = Program.ss.Get_FormattedTime(ts, (int)TimeFormats.HHMM);
            }
        }

        private void A_WarpMendings_AfterPrint(object sender, EventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);
                if (secs > 0)
                {
                    A_WarpAvgTime += secs;
                    A_WarpAvgTimeCounts++;
                    TA_WarpAvgTime += secs;
                    TA_WarpAvgTimeCounts++;
                }
            }
        }

        private void A_WeftMendings_AfterPrint(object sender, EventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);
                if (secs > 0)
                {
                    A_WeftAvgTime += secs;
                    A_WeftAvgTimeCounts++;
                    TA_WeftAvgTime += secs;
                    TA_WeftAvgTimeCounts++;
                }
            }
        }

        private void G_WarpMendings_TextChanged(object sender, EventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Text != null)
            {
                double.TryParse(xr.Text.ToString(), out secs);

                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(secs));
                xr.Text = Program.ss.Get_FormattedTime(ts, (int)TimeFormats.MMSS);
            }
        }

    }
}
