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
    public partial class xu_MonthlyUnitsQualityWise : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_MonthlyUnitsQualityWise()
        {
            InitializeComponent();
        }

        private void xu_MonthlyUnitsQualityWise_Load(object sender, EventArgs e)
        {
            this.FromDate.DateTime = DateTime.Now;
            this.ToDate.DateTime = DateTime.Now;
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Yarn.ReportingParameters.Yarn_Reports mr = (MachineEyes.Yarn.ReportingParameters.Yarn_Reports)this.Parent.Parent;
            mr.Close();
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {

            int ShedIndex = 0;
            if (this.Shed.Tag != null)
                int.TryParse(this.Shed.Tag.ToString(), out ShedIndex);
            Reports.Efficiency_MonthlyUnitsQualityWise_ABC ABC = new Reports.Efficiency_MonthlyUnitsQualityWise_ABC();

            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_DatedFrom.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            ABC.repH_DatedUpto.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            string dsstring = "SELECT     LoomID,LoomName,ArticleNumber,ArticleShortName,Avg(T_RPM) as T_RPM,Sum(A_Units) as A_Units,Sum(B_Units) as B_Units,Sum(C_Units) as C_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters,Sum(C_Meters) as C_Meters,Sum(T_Meters) as T_Meters,Avg(A_Eff) as A_Eff,Avg(B_Eff) as B_Eff,Avg(C_Eff) as C_Eff,Avg(T_Eff) as T_Eff from RP_dailyShiftSummary  where  Shiftdate>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and ShiftDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") group by ArticleNumber,ArticleShortName,LoomID,LoomName order by Convert(numeric(9),LoomName)";
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            DataView dv_Main = ds.Tables[0].DefaultView;

            DataTable dAB = dv_Main.ToTable();
            ABC.BeginInit();

            ABC.DataSource = dAB;
            ABC.EndInit();
            ABC.ShowPreview();
        }
    }
}
