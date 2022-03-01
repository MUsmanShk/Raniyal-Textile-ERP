using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Loom_Log : DevExpress.XtraReports.UI.XtraReport
    {
        public Loom_Log()
        {
            InitializeComponent();
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

        private void xr_Cause_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(xr_State.Tag.ToString()) != (int)State.Running)
                {
                    Cause c = (Cause)Convert.ToInt32(xr_Cause.Tag.ToString());
                    xr_Cause.Text = c.ToString();
                   

                  
                }
                else
                    xr_Cause.Text = "";
            }
            catch
            {
            }
        }

        private void xr_ShiftDated_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(xr_State.Tag.ToString()) == (int)State.Running)
                {

                    xr_Cause.ForeColor = Color.DarkGreen;
                    xr_State.ForeColor = Color.DarkGreen;
                }
                else if (Convert.ToInt32(xr_State.Tag.ToString()) == (int)State.PowerOff)
                {
                    xr_Cause.ForeColor = Color.DarkKhaki;
                    xr_State.ForeColor = Color.DarkKhaki;
                }
                else if (Convert.ToInt32(xr_State.Tag.ToString()) == (int)State.Stopped)
                {
                    if (Convert.ToInt32(xr_Cause.Tag.ToString()) == (int)Cause.Warp)
                    {
                        xr_Cause.ForeColor = Color.Blue;
                        xr_State.ForeColor = Color.Blue;
                    }
                    else if (Convert.ToInt32(xr_Cause.Tag.ToString()) == (int)Cause.Weft)
                    {
                        xr_Cause.ForeColor = Color.Red;
                        xr_State.ForeColor = Color.Red;
                    }
                    else if (Convert.ToInt32(xr_Cause.Tag.ToString()) == (int)Cause.Other)
                    {
                        xr_Cause.ForeColor = Color.Purple;
                        xr_State.ForeColor = Color.Purple;
                    }
                    else 
                    {
                        xr_Cause.ForeColor = Color.DarkOrange;
                        xr_State.ForeColor = Color.DarkOrange;
                    }
                }
                else if (Convert.ToInt32(xr_State.Tag.ToString()) == (int)State.Unknown)
                {
                    xr_Cause.ForeColor = Color.Magenta;
                    xr_State.ForeColor = Color.Magenta;
                }
                else
                {
                    xr_Cause.ForeColor = Color.Black;
                    xr_State.ForeColor = Color.Black;
                }
               
            }
            catch
            {
            }
        }

    }
}
