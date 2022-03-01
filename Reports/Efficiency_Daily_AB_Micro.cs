using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Efficiency_Daily_AB_Micro : DevExpress.XtraReports.UI.XtraReport
    {
        public int ShedIndex;
        public double A_RunningEff;
        public double A_Looms;
        public double B_RunningEff;
        public double B_Looms;
        public double AB_RunningEff;
        public double AB_Looms;
        public Efficiency_Daily_AB_Micro()
        {
            InitializeComponent();
        }
        private void ChangeForeColor(XRLabel xr, ColorCauses CC)
        {
            if (repH_Shed.Tag != null && xr.Text != "")
            {
                if (repH_Shed.Tag.ToString() != "")
                {

                    xr.ForeColor = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnColor(CC, Convert.ToDouble(xr.Text));
                }
            }
        }

        private void Eff_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           

            ChangeForeColor((XRLabel)sender, ColorCauses.EfficiencyColors);
        }

        private void RPM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ChangeForeColor((XRLabel)sender, ColorCauses.RPMColors);
        }

        private void xr_A_Eff_AfterPrint(object sender, EventArgs e)
        {
            XRLabel l = (XRLabel)sender;
            if (l.Text != "")
            {
                double eff = Convert.ToDouble(l.Text);
                if (eff > 0)
                {
                    A_RunningEff += eff;
                    A_Looms++;
                }
            }
        }

        private void xr_B_Eff_AfterPrint(object sender, EventArgs e)
        {
            XRLabel l = (XRLabel)sender;
            if (l.Text != "")
            {
                double eff = Convert.ToDouble(l.Text);
                if (eff > 0)
                {
                    B_RunningEff += eff;
                    B_Looms++;
                }
            }
        }

        private void xr_AB_Eff_AfterPrint(object sender, EventArgs e)
        {
            XRLabel l = (XRLabel)sender;
            if (l.Text != "")
            {
                double eff = Convert.ToDouble(l.Text);
                if (eff > 0)
                {
                    AB_RunningEff += eff;
                    AB_Looms++;
                }
            }
        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.xr_A_Running.Text = Convert.ToDouble(A_RunningEff / A_Looms).ToString("#,##0.0");
            this.xr_B_Running.Text = Convert.ToDouble(B_RunningEff / B_Looms).ToString("#,##0.0");
            this.xr_AB_Running.Text = Convert.ToDouble(AB_RunningEff / AB_Looms).ToString("#,##0.0");
        }

       
    }
}
