using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.LDS.ReportingParameters
{
    public partial class xu_Monthly_Loom_Production : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_Monthly_Loom_Production()
        {
            InitializeComponent();
        }

        private void Shed_EditValueChanged(object sender, EventArgs e)
        {
            int shedindex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.Shed.Text);
            if (shedindex != -1)
            {
                this.Shed.Tag = this.Shed.Text;
                this.ShedName.Text = Program.ss.Machines.PresentationData.Sheds[shedindex].ShedName;
            }
            else
            {
                this.Shed.Tag = null;
                this.ShedName.Text = "";
            }
        }

        private void LoomNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.Shed.Tag == null)
            {
                this.LoomNumber.ForeColor = Color.White;
                this.LoomNumber.BackColor = Color.Red;
                this.LoomNumber.Tag = null;
                return;
            }
            int loomid = Program.ss.Machines.ReturnArrayIndex_Loom(this.LoomNumber.Text, this.Shed.Tag.ToString());
            if (loomid != -1)
            {
                this.LoomNumber.ForeColor = Color.Black;
                this.LoomNumber.BackColor = Color.White;
                this.LoomNumber.Tag = loomid.ToString();
            }
            else
            {
                this.LoomNumber.ForeColor = Color.White;
                this.LoomNumber.BackColor = Color.Red;
                this.LoomNumber.Tag = null;
            }
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {

            Reports.Efficiency_Loom_FromTo ABC = new Reports.Efficiency_Loom_FromTo();

            //AB.ShedIndex = ShedIndex;

            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_DatedFrom.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            ABC.repH_DatedTo.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            ABC.repH_Loom.Text = this.LoomNumber.EditValue.ToString();
            string dsstring = "SELECT     ArticleNumber,ArticleShortName,ShiftDate as ShiftDated,Avg(T_Eff) as Efficiency,Sum(T_WarpStops) as TotalWarpStops,Avg(T_WarpPerHour) as AverageWarpPerHour,Avg(T_WeftPerHour) as AverageWeftPerHour,SUM(T_WeftStops) as TotalWeftStops,SUM(T_Units) as TotalUnits,SUM(T_Meters) as TotalMeters,SUM(T_Meters)*1.0936 as TotalYards,Avg(T_RPM) as AvgRPM from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)>=" + this.FromDate.DateTime.Day.ToString() + " and datepart(MONTH, ShiftDate)>=" + this.FromDate.DateTime.Month.ToString() + " and datepart(YEAR, ShiftDate)>=" + this.FromDate.DateTime.Year.ToString() + "  and datepart(DAY, ShiftDate)<=" + this.ToDate.DateTime.Day.ToString() + " and datepart(MONTH, ShiftDate)<=" + this.ToDate.DateTime.Month.ToString() + " and datepart(YEAR, ShiftDate)<=" + this.ToDate.DateTime.Year.ToString() + " and loomid=" + this.LoomNumber.Tag.ToString() + " group by ArticleNumber,ArticleShortName,ShiftDate order by ArticleNumber,ArticleShortName,ShiftDate ";
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

        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Reports.Parameters.ReportsMDI mr = (MachineEyes.Reports.Parameters.ReportsMDI)this.Parent.Parent;
            mr.Close();
        }
    }
}
