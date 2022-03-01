using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Efficiency_Daily_LoomWise_ABC : DevExpress.XtraReports.UI.XtraReport
    {
        double A_WarpAvgTime, A_WarpAvgTimeCounts, A_WeftAvgTime, A_WeftAvgTimeCounts, B_WarpAvgTime, B_WarpAvgTimeCounts, B_WeftAvgTime, B_WeftAvgTimeCounts, C_WarpAvgTime, C_WarpAvgTimeCounts,C_WeftAvgTime, C_WeftAvgTimeCounts, G_LongTime;
        double TA_WarpAvgTime, TA_WarpAvgTimeCounts, TA_WeftAvgTime, TA_WeftAvgTimeCounts, TB_WarpAvgTime, TB_WarpAvgTimeCounts, TB_WeftAvgTime, TB_WeftAvgTimeCounts, TC_WarpAvgTime, TC_WarpAvgTimeCounts, TC_WeftAvgTime, TC_WeftAvgTimeCounts, TG_LongTime;
        public Efficiency_Daily_LoomWise_ABC()
        {
            InitializeComponent();
        }

        private void xr_A_WarpMendings_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);

                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(secs));
                xr.Text = Program.ss.Get_FormattedTime(ts, 1);
            }
        }

        private void xr_A_WarpMendings_AfterPrint(object sender, EventArgs e)
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

        private void xr_A_WeftMendings_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);

                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(secs));
                xr.Text = Program.ss.Get_FormattedTime(ts, 1);
            }
        }

        private void xr_A_WeftMendings_AfterPrint(object sender, EventArgs e)
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

        private void xr_B_WarpMendings_AfterPrint(object sender, EventArgs e)
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

        private void xr_B_WeftMendings_AfterPrint(object sender, EventArgs e)
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

        private void xr_T_LongETime_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);

                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(secs));
                G_LongTime += secs;
                TG_LongTime += secs;
                xr.Text = Program.ss.Get_FormattedTime(ts, 3);
            }
        }

        private void xr_T_A_WarpMendings_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (TA_WarpAvgTimeCounts > 0)
            {
                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(TA_WarpAvgTime) / Convert.ToInt32(TA_WarpAvgTimeCounts));
                xr.Text = Program.ss.Get_FormattedTime(ts, 1);

            }
            TA_WarpAvgTime = 0; TA_WarpAvgTimeCounts = 0;
        }

        private void xr_T_A_WeftMendings_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (TA_WeftAvgTimeCounts > 0)
            {
                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(TA_WeftAvgTime) / Convert.ToInt32(TA_WeftAvgTimeCounts));
                xr.Text = Program.ss.Get_FormattedTime(ts, 1);

            }
            TA_WeftAvgTime = 0; TA_WeftAvgTimeCounts = 0;
        }

        private void xr_T_B_WarpMendings_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (TB_WarpAvgTimeCounts > 0)
            {
                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(TB_WarpAvgTime) / Convert.ToInt32(TB_WarpAvgTimeCounts));
                xr.Text = Program.ss.Get_FormattedTime(ts, 1);

            }
            TB_WarpAvgTime = 0; TB_WarpAvgTimeCounts = 0;
        }

        private void xr_T_B_WeftMendings_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (TB_WeftAvgTimeCounts > 0)
            {
                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(TB_WeftAvgTime) / Convert.ToInt32(TB_WeftAvgTimeCounts));
                xr.Text = Program.ss.Get_FormattedTime(ts, 1);

            }
            TB_WeftAvgTime = 0; TB_WeftAvgTimeCounts = 0;
        }

        private void xr_T_LongTime_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;

            if (TG_LongTime != 0)
            {


                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(G_LongTime));

                xr.Text = Program.ss.Get_FormattedTime(ts, 1);
            }
            G_LongTime = 0;
        }

        private void xr_B_WarpMendings_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);

                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(secs));
                xr.Text = Program.ss.Get_FormattedTime(ts, 1);
            }
        }

        private void xr_B_WeftMendings_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);

                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(secs));
                xr.Text = Program.ss.Get_FormattedTime(ts, 1);
            }
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void C_WarpMending_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);

                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(secs));
                xr.Text = Program.ss.Get_FormattedTime(ts, 1);
            }
        }

        private void C_WarpMending_AfterPrint(object sender, EventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);
                if (secs > 0)
                {
                    C_WarpAvgTime += secs;
                    C_WarpAvgTimeCounts++;
                    TC_WarpAvgTime += secs;
                    TC_WarpAvgTimeCounts++;
                }
            }
        }

        private void C_WeftMending_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);

                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(secs));
                xr.Text = Program.ss.Get_FormattedTime(ts, 1);
            }
        }

        private void C_WeftMending_AfterPrint(object sender, EventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double secs = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out secs);
                if (secs > 0)
                {
                    C_WeftAvgTime += secs;
                    C_WeftAvgTimeCounts++;
                    TC_WeftAvgTime += secs;
                    TC_WeftAvgTimeCounts++;
                }
            }
        }

        private void C_AvgWarpMending_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (TC_WarpAvgTimeCounts > 0)
            {
                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(TC_WarpAvgTime) / Convert.ToInt32(TC_WarpAvgTimeCounts));
                xr.Text = Program.ss.Get_FormattedTime(ts, 1);

            }
            TC_WarpAvgTime = 0; TC_WarpAvgTimeCounts = 0;
        }

        private void C_AvgWeftMending_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (TC_WeftAvgTimeCounts > 0)
            {
                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(TC_WeftAvgTime) / Convert.ToInt32(TC_WeftAvgTimeCounts));
                xr.Text = Program.ss.Get_FormattedTime(ts, 1);

            }
            TC_WeftAvgTime = 0; TC_WeftAvgTimeCounts = 0;
        }

    }
}
