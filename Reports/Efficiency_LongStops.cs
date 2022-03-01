using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Efficiency_LongStops : DevExpress.XtraReports.UI.XtraReport
    {
        public Efficiency_LongStops()
        {
            InitializeComponent();
        }

        private void xr_State_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                State s = (State)Convert.ToInt32(xr_State.Tag.ToString());
                xr_State.Text = s.ToString();
            }
            catch
            {
            }
        }

        private void xr_ElapsedTime_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                DateTime from = Convert.ToDateTime(xr_StartTime.Tag);
                DateTime to = Convert.ToDateTime(xr_EndTime.Tag);
                TimeSpan ts = to.Subtract(from);
                xr_ElapsedTime.Text = Program.ss.Get_FormattedTime(Convert.ToInt32(ts.TotalSeconds));
            }
            catch
            {
            }
        }

    }
}
