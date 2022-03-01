using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class SW_SizingMonthlyProduction: DevExpress.XtraReports.UI.XtraReport
    {
        public double tRupees, tLbs, tMeters;
        public SW_SizingMonthlyProduction()
        {
            InitializeComponent();
        }

        private void BottomMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void TotalLbs_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if(e.Value!=null)
            tLbs =Convert.ToDouble(e.Value);
        }

        private void TotalMeters_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if(e.Value!=null)
            tMeters = Convert.ToDouble(e.Value);
            try
            {
                double trupeeperlbs = 0;
                if (tLbs > 0)
                    trupeeperlbs = tRupees / tLbs;
              
            }
            catch
            {
            }
        }

        private void TotalRupees_SummaryCalculated(object sender, TextFormatEventArgs e)
        {   if(e.Value!=null)
            tRupees = Convert.ToDouble(e.Value);
        }

        private void RupeesPerLbs_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void RupeesPerMeter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            try
            {
                double trupeespermeter = 0;
                if (tLbs > 0)
                    trupeespermeter = tRupees / tLbs;
            }
            catch
            {
            }
        }

    }
}
