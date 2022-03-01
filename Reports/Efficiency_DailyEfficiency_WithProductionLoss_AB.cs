using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Efficiency_DailyEfficiency_WithProductionLoss_AB : DevExpress.XtraReports.UI.XtraReport
    {
        double A_WarpAvgTime, A_WarpAvgTimeCounts, A_WeftAvgTime, A_WeftAvgTimeCounts, B_WarpAvgTime, B_WarpAvgTimeCounts, B_WeftAvgTime, B_WeftAvgTimeCounts, A_OtherAvgTime, A_OtherAvgTimeCounts, B_OtherAvgTime, B_OtherAvgTimeCounts, T_WarpAvgTime, T_WarpAvgTimeCounts, T_WeftAvgTime, T_WeftAvgTimeCounts, T_OtherAvgTime, T_OtherAvgTimeCounts;
        double TA_WarpAvgTime, TA_WarpAvgTimeCounts, TA_WeftAvgTime, TA_WeftAvgTimeCounts, TB_WarpAvgTime, TB_WarpAvgTimeCounts, TB_WeftAvgTime, TB_WeftAvgTimeCounts, TA_OtherAvgTime, TA_OtherAvgTimeCounts, TB_OtherAvgTime, TB_OtherAvgTimeCounts, TT_WarpAvgTime, TT_WarpAvgTimeCounts, TT_WeftAvgTime, TT_WeftAvgTimeCounts, TT_OtherAvgTime, TT_OtherAvgTimeCounts;
        public Efficiency_DailyEfficiency_WithProductionLoss_AB()
        {
            InitializeComponent();
        }

        private void BeforePrint_MndFormat(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);

                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(secs));
                xr.Text = Program.ss.Get_FormattedTime(ts, (int)TimeFormats.MMSS);
            }
        }

        private void BeforePrint_LongTime(object sender, System.Drawing.Printing.PrintEventArgs e)
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

        private void A_OtherMendings_AfterPrint(object sender, EventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);
                if (secs > 0)
                {
                    A_OtherAvgTime += secs;
                    A_OtherAvgTimeCounts++;
                    TA_OtherAvgTime += secs;
                    TA_OtherAvgTimeCounts++;
                }
            }
        }

        private void B_WarpMendings_AfterPrint(object sender, EventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);
                if (secs > 0)
                {
                    B_WarpAvgTime += secs;
                    B_WarpAvgTimeCounts++;
                    TB_WarpAvgTime += secs;
                    TB_WarpAvgTimeCounts++;
                }
            }
        }

        private void B_WeftMendings_AfterPrint(object sender, EventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);
                if (secs > 0)
                {
                    B_WeftAvgTime += secs;
                    B_WeftAvgTimeCounts++;
                    TB_WeftAvgTime += secs;
                    TB_WeftAvgTimeCounts++;
                }
            }
        }

        private void B_OtherMendings_AfterPrint(object sender, EventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);
                if (secs > 0)
                {
                    B_OtherAvgTime += secs;
                    B_OtherAvgTimeCounts++;
                    TB_OtherAvgTime += secs;
                    TB_OtherAvgTimeCounts++;
                }
            }
        }

        private void T_WarpMendings_AfterPrint(object sender, EventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);
                if (secs > 0)
                {
                    T_WarpAvgTime += secs;
                    T_WarpAvgTimeCounts++;
                    TT_WarpAvgTime += secs;
                    TT_WarpAvgTimeCounts++;
                }
            }
        }

        private void T_WeftMendings_AfterPrint(object sender, EventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);
                if (secs > 0)
                {
                    T_WeftAvgTime += secs;
                    T_WeftAvgTimeCounts++;
                    TT_WeftAvgTime += secs;
                    TT_WeftAvgTimeCounts++;
                }
            }
        }

        private void T_OtherMendings_AfterPrint(object sender, EventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);
                if (secs > 0)
                {
                    T_OtherAvgTime += secs;
                    T_OtherAvgTimeCounts++;
                    TT_OtherAvgTime += secs;
                    TT_OtherAvgTimeCounts++;
                }
            }
        }

    }
}
