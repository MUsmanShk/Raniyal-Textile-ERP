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
    public partial class Efficiency_ArticleReport : DevExpress.XtraEditors.XtraUserControl
    {
        public Efficiency_ArticleReport()
        {
            InitializeComponent();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Yarn.ReportingParameters.Yarn_Reports mr = (MachineEyes.Yarn.ReportingParameters.Yarn_Reports)this.Parent.Parent;
            mr.Close();
        }

        private void Article_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                if (Program.MainWindow.ListsLoaded == false) Program.MainWindow.LoadLists();

                Program.MainWindow.ArticleView.ShowDialog();
                try
                {
                    if (Program.MainWindow.ArticleView.SelectedRow.Status != ParameterStatus.Cancelled)
                    {

                        this.Article.Tag = Program.MainWindow.ArticleView.SelectedRow.PrimeryID;
                        this.Article.Text = Program.MainWindow.ArticleView.SelectedRow.PrimaryString;


                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
        }

        private void Efficiency_ArticleReport_Load(object sender, EventArgs e)
        {
            this.FromDate.DateTime = DateTime.Now;
            this.ToDate.DateTime = DateTime.Now;
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {

            Reports.Efficiency_Quality_FromTo ABC = new Reports.Efficiency_Quality_FromTo();

            //AB.ShedIndex = ShedIndex;
           
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_DatedFrom.Text = this.FromDate.DateTime.ToString("dd/MM/yyyy");
            ABC.repH_DatedTo.Text = this.ToDate.DateTime.ToString("dd/MM/yyyy");
            ABC.repH_Article.Text = this.Article.Text;
            string dsstring = "SELECT     ShiftDate as ShiftDated,Avg(T_Eff) as Efficiency,Count(LoomID)  as NoOfLooms,Sum(T_WarpStops) as TotalWarpStops,Avg(T_WarpPerHour) as AverageWarpPerHour,Avg(T_WeftPerHour) as AverageWeftPerHour,SUM(T_WeftStops) as TotalWeftStops,SUM(T_Units) as TotalUnits,SUM(T_Meters) as TotalMeters,SUM(T_Meters)*1.0936 as TotalYards,Avg(T_RPM) as AvgRPM from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)>=" + this.FromDate.DateTime.Day.ToString() + " and datepart(MONTH, ShiftDate)>=" + this.FromDate.DateTime.Month.ToString() + " and datepart(YEAR, ShiftDate)>=" + this.FromDate.DateTime.Year.ToString() + "  and datepart(DAY, ShiftDate)<=" + this.ToDate.DateTime.Day.ToString() + " and datepart(MONTH, ShiftDate)<=" + this.ToDate.DateTime.Month.ToString() + " and datepart(YEAR, ShiftDate)<=" + this.ToDate.DateTime.Year.ToString() + " and articlenumber='" + this.Article.Tag.ToString() + "' group by ShiftDate order by ShiftDate ";
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
    }
}
