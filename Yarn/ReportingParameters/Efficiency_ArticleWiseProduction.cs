using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Yarn.ReportingParameters
{
    public partial class Efficiency_ArticleWiseProduction : DevExpress.XtraEditors.XtraUserControl
    {
        public Efficiency_ArticleWiseProduction()
        {
            InitializeComponent();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {

            MachineEyes.Yarn.ReportingParameters.Yarn_Reports mr = (MachineEyes.Yarn.ReportingParameters.Yarn_Reports)this.Parent.Parent;
            mr.Close();
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            Reports.Efficiency_QualityWiseProduction ABC = new Reports.Efficiency_QualityWiseProduction();

            //AB.ShedIndex = ShedIndex;

            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_DatedFrom.Text = this.FromDate.DateTime.ToString("dd/MM/yyyy");
            ABC.repH_DatedTo.Text = this.ToDate.DateTime.ToString("dd/MM/yyyy");
         
            string dsstring = "SELECT     ArticleNumber,ArticleShortName,Avg(T_Eff) as Efficiency,Count(LoomID)  as NoOfLooms,SUM(T_Units) as TotalUnits,SUM(T_Meters) as TotalMeters,SUM(T_Meters)*1.0936 as TotalYards,Avg(T_RPM) as AvgRPM from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)>=" + this.FromDate.DateTime.Day.ToString() + " and datepart(MONTH, ShiftDate)>=" + this.FromDate.DateTime.Month.ToString() + " and datepart(YEAR, ShiftDate)>=" + this.FromDate.DateTime.Year.ToString() + "  and datepart(DAY, ShiftDate)<=" + this.ToDate.DateTime.Day.ToString() + " and datepart(MONTH, ShiftDate)<=" + this.ToDate.DateTime.Month.ToString() + " and datepart(YEAR, ShiftDate)<=" + this.ToDate.DateTime.Year.ToString() + " group by ArticleNumber,ArticleShortName order by ArticleNumber ";
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {

                ABC.DataSource = ds;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }

        private void Efficiency_ArticleWiseProduction_Load(object sender, EventArgs e)
        {
            this.FromDate.DateTime = DateTime.Now;
            this.ToDate.DateTime = DateTime.Now;
        }
    }
}
