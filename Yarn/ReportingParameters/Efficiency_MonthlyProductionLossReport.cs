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
    public partial class Efficiency_MonthlyProductionLossReport : DevExpress.XtraEditors.XtraUserControl
    {
        public Efficiency_MonthlyProductionLossReport()
        {
            InitializeComponent();
        }

        private void Efficiency_MonthlyProductionLossReport_Load(object sender, EventArgs e)
        {
            this.FromDate.DateTime = DateTime.Now;
            this.ToDate.DateTime = DateTime.Now;
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            Reports.Efficiency_MonthlyProductionLoss ABC = new Reports.Efficiency_MonthlyProductionLoss();

            //AB.ShedIndex = ShedIndex;

            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_From.Text = this.FromDate.DateTime.ToString("dd/MM/yyyy");
           ABC.repH_To.Text = this.ToDate.DateTime.ToString("dd/MM/yyyy");

            string dsstring = "SELECT     * from RP_MonthlyProductionLoss  where  datepart(DAY, ShiftDate)>=" + this.FromDate.DateTime.Day.ToString() + " and datepart(MONTH, ShiftDate)>=" + this.FromDate.DateTime.Month.ToString() + " and datepart(YEAR, ShiftDate)>=" + this.FromDate.DateTime.Year.ToString() + "  and datepart(DAY, ShiftDate)<=" + this.ToDate.DateTime.Day.ToString() + " and datepart(MONTH, ShiftDate)<=" + this.ToDate.DateTime.Month.ToString() + " and datepart(YEAR, ShiftDate)<=" + this.ToDate.DateTime.Year.ToString() + "  order by ShiftDate ";
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
            MachineEyes.Yarn.ReportingParameters.Yarn_Reports mr = (MachineEyes.Yarn.ReportingParameters.Yarn_Reports)this.Parent.Parent;
            mr.Close();
        }
    }
}
