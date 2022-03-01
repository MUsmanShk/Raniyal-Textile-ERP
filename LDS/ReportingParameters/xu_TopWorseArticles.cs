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
    public partial class xu_TopWorseArticles : DevExpress.XtraEditors.XtraUserControl
    {
        int TotalIncludes = 0;
        public xu_TopWorseArticles()
        {
            InitializeComponent();
            this.FromDate.DateTime = DateTime.Now;
            this.ToDate.DateTime = DateTime.Now;
        }

        private void Close_Click(object sender, EventArgs e)
        {

            MachineEyes.Reports.Parameters.ReportsMDI mr = (MachineEyes.Reports.Parameters.ReportsMDI)this.Parent.Parent;
            mr.Close();
        }
        private void AddLongStop(Reports.Efficiency_TopWorseArticles rpt, string LongStop)
        {
            TotalIncludes++;
            if (TotalIncludes == 1)
                rpt.LongStopLabel_1.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 2)
                rpt.LongStopLabel_2.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 3)
                rpt.LongStopLabel_3.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 4)
                rpt.LongStopLabel_4.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 5)
                rpt.LongStopLabel_5.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 6)
                rpt.LongStopLabel_6.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 7)
                rpt.LongStopLabel_7.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 8)
                rpt.LongStopLabel_8.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 9)
                rpt.LongStopLabel_9.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 10)
                rpt.LongStopLabel_10.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 11)
                rpt.LongStopLabel_11.Text = TotalIncludes.ToString() + " - " + LongStop;
        }

        private void AddLongStop(Reports.Efficiency_TopWorseLooms rpt, string LongStop)
        {
            TotalIncludes++;
            if (TotalIncludes == 1)
                rpt.LongStopLabel_1.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 2)
                rpt.LongStopLabel_2.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 3)
                rpt.LongStopLabel_3.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 4)
                rpt.LongStopLabel_4.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 5)
                rpt.LongStopLabel_5.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 6)
                rpt.LongStopLabel_6.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 7)
                rpt.LongStopLabel_7.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 8)
                rpt.LongStopLabel_8.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 9)
                rpt.LongStopLabel_9.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 10)
                rpt.LongStopLabel_10.Text = TotalIncludes.ToString() + " - " + LongStop;
            if (TotalIncludes == 11)
                rpt.LongStopLabel_11.Text = TotalIncludes.ToString() + " - " + LongStop;
        }
        private void ArticleReport()
        {
            Reports.Efficiency_TopWorseArticles ArticleWiseSubReport = new Reports.Efficiency_TopWorseArticles();
            ArticleWiseSubReport.BeginInit();
            string T_EffFormula = "";
            T_EffFormula += "T_Eff";
            TotalIncludes = 0;
            

            if (chk_Mechanical.Checked == false)
            {

                T_EffFormula += "+T_MechanicalLoss";
            }
            else
                AddLongStop(ArticleWiseSubReport, "Mechanical");
            if (this.chk_Electrical.Checked == false)
            {

                T_EffFormula += "+T_ElectricalLoss";
            }
            else
                AddLongStop(ArticleWiseSubReport, "Electrical");
            if (this.chk_Knotting.Checked == false)
            {

                T_EffFormula += "+T_KnottingLoss";
            }
            else
                AddLongStop(ArticleWiseSubReport, "Knotting");
            if (this.chk_Article.Checked == false)
            {

                T_EffFormula += "+T_ArticleLoss";
            }
            else
                AddLongStop(ArticleWiseSubReport, "Article");
            if (this.chk_PowerOff.Checked == false)
            {

                T_EffFormula += "+T_PowerOffLoss";
            }
            else
                AddLongStop(ArticleWiseSubReport, "Power Off");
            if (this.chk_Other.Checked == false)
            {

                T_EffFormula += "+T_LongOtherLoss";
            }
            else
                AddLongStop(ArticleWiseSubReport, "Other");
            if (this.chk_LongStop_5.Checked == false)
            {

                T_EffFormula += "+T_LongStop_5_Loss";
            }
            else
                AddLongStop(ArticleWiseSubReport, this.chk_LongStop_5.Text);
            if (this.chk_LongStop_6.Checked == false)
            {


                T_EffFormula += "+T_LongStop_6_Loss";
            }
            else
                AddLongStop(ArticleWiseSubReport, this.chk_LongStop_6.Text);
            if (this.chk_LongStop_7.Checked == false)
            {

                T_EffFormula += "+T_LongStop_7_Loss";
            }
            else
                AddLongStop(ArticleWiseSubReport, this.chk_LongStop_7.Text);
            if (this.chk_LongStop_8.Checked == false)
            {

                T_EffFormula += "+T_LongStop_8_Loss";
            }
            else
                AddLongStop(ArticleWiseSubReport, this.chk_LongStop_8.Text);
            if (this.chk_LongStop_9.Checked == false)
            {

                T_EffFormula += "+T_LongStop_9_Loss";
            }
            else
                AddLongStop(ArticleWiseSubReport, this.chk_LongStop_9.Text);





            string ProductionMetersFormula = "";
            if (this.MinimumProduction.EditValue != null)
            {
                if (this.MinimumProduction.EditValue.ToString() != "0" && this.MinimumProduction.EditValue.ToString() != "")
                {
                    ProductionMetersFormula = " having sum(T_Meters)>=" + this.MinimumProduction.EditValue.ToString() + " ";
                }
            }

            string ArticleWiseString = "SELECT     ArticleNumber,ArticleName,Avg(T_RPM) as T_RPM,Count(Distinct LoomID) as TotalLooms,Avg(" + T_EffFormula + ") as T_Eff,Sum(T_WarpStops) as T_WarpStops,Avg(T_WarpPerHour) as T_WarpPerHour , Sum(T_WeftStops) as T_WeftStops,Avg(T_WarpCMPX) as T_WarpCMPX ,Avg(T_WeftCMPX) as T_WeftCMPX,Avg(T_WeftPerHour) as T_WeftPerHour,sum(T_Meters) as T_Meters  from RP_DailyShiftSummary where  ShiftDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and ShiftDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and shedid=" + this.Shed.Tag.ToString() + " ";
         
            ArticleWiseString+=" GROUP BY ArticleNumber, ArticleName   ";
           
           

            if (this.MinimumProduction.EditValue != null)
            {
                ArticleWiseSubReport.MinimumProduction.Text = this.MinimumProduction.Text;
            }
            if (ProductionMetersFormula != "")
                ArticleWiseString += ProductionMetersFormula;
            ArticleWiseString += "order by Avg(" + T_EffFormula + ")";
            ArticleWiseString += this.TopWorseSelection.EditValue.ToString();

            ArticleWiseSubReport.FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            ArticleWiseSubReport.UptoDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            ArticleWiseSubReport.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ArticleWiseSubReport.ShedName.Text = this.Shed.Text;
            if (this.TopWorseSelection.EditValue.ToString() == "DESC")
                ArticleWiseSubReport.ReportName.Text = "Top Articles Report";
            if (this.TopWorseSelection.EditValue.ToString() == "ASC")
                ArticleWiseSubReport.ReportName.Text = "Worse Articles Report";

            DataSet dsArticleWiseSummary = WS.svc.Get_DataSet(ArticleWiseString);
            if (dsArticleWiseSummary != null)
            {

                ArticleWiseSubReport.DataSource = dsArticleWiseSummary.Tables[0];
            }
            ArticleWiseSubReport.EndInit();
            ArticleWiseSubReport.ShowPreview();
        }
        private void LoomReport()
        {
            Reports.Efficiency_TopWorseLooms TopWorseReport = new Reports.Efficiency_TopWorseLooms();
            TopWorseReport.BeginInit();
            string T_EffFormula = "";
            T_EffFormula += "T_Eff";
            TotalIncludes = 0;
            if (chk_Mechanical.Checked == false)
            {

                T_EffFormula += "+T_MechanicalLoss";
            }
            else
                AddLongStop(TopWorseReport, "Mechanical");
            if (this.chk_Electrical.Checked == false)
            {

                T_EffFormula += "+T_ElectricalLoss";
            }
            else
                AddLongStop(TopWorseReport, "Electrical");
            if (this.chk_Knotting.Checked == false)
            {

                T_EffFormula += "+T_KnottingLoss";
            }
            else
                AddLongStop(TopWorseReport, "Knotting");
            if (this.chk_Article.Checked == false)
            {

                T_EffFormula += "+T_ArticleLoss";
            }
            else
                AddLongStop(TopWorseReport, "Article");
            if (this.chk_PowerOff.Checked == false)
            {

                T_EffFormula += "+T_PowerOffLoss";
            }
            else
                AddLongStop(TopWorseReport, "Power Off");
            if (this.chk_Other.Checked == false)
            {

                T_EffFormula += "+T_LongOtherLoss";
            }
            else
                AddLongStop(TopWorseReport, "Other");
            if (this.chk_LongStop_5.Checked == false)
            {

                T_EffFormula += "+T_LongStop_5_Loss";
            }
            else
                AddLongStop(TopWorseReport, this.chk_LongStop_5.Text);
            if (this.chk_LongStop_6.Checked == false)
            {


                T_EffFormula += "+T_LongStop_6_Loss";
            }
            else
                AddLongStop(TopWorseReport, this.chk_LongStop_6.Text);
            if (this.chk_LongStop_7.Checked == false)
            {

                T_EffFormula += "+T_LongStop_7_Loss";
            }
            else
                AddLongStop(TopWorseReport, this.chk_LongStop_7.Text);
            if (this.chk_LongStop_8.Checked == false)
            {

                T_EffFormula += "+T_LongStop_8_Loss";
            }
            else
                AddLongStop(TopWorseReport, this.chk_LongStop_8.Text);
            if (this.chk_LongStop_9.Checked == false)
            {

                T_EffFormula += "+T_LongStop_9_Loss";
            }
            else
                AddLongStop(TopWorseReport, this.chk_LongStop_9.Text);






            string ProductionMetersFormula = "";
            if (this.MinimumProduction.EditValue != null)
            {
                if (this.MinimumProduction.EditValue.ToString() != "0" && this.MinimumProduction.EditValue.ToString() != "")
                {
                    ProductionMetersFormula = " having sum(T_Meters)>=" + this.MinimumProduction.EditValue.ToString() + " ";
                }
            }

            string ArticleWiseString = "SELECT     LoomID,LoomName,Avg(T_RPM) as T_RPM,Avg(" + T_EffFormula + ") as T_Eff,Sum(T_WarpStops) as T_WarpStops,Avg(T_WarpPerHour) as T_WarpPerHour , Sum(T_WeftStops) as T_WeftStops,Avg(T_WarpCMPX) as T_WarpCMPX ,Avg(T_WeftCMPX) as T_WeftCMPX,Avg(T_WeftPerHour) as T_WeftPerHour,sum(T_Meters) as T_Meters  from RP_DailyShiftSummary where  ShiftDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and ShiftDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and shedid=" + this.Shed.Tag.ToString() + " ";
           
            ArticleWiseString += " GROUP BY LoomID, LoomName ";
            if (ProductionMetersFormula != "")
                ArticleWiseString += ProductionMetersFormula;

            ArticleWiseString += "order by Avg(" + T_EffFormula + ")";
            ArticleWiseString += this.TopWorseSelection.EditValue.ToString();

            if (this.MinimumProduction.EditValue != null)
            {
                TopWorseReport.MinimumProduction.Text = this.MinimumProduction.Text;
            }

            TopWorseReport.FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            TopWorseReport.UptoDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            TopWorseReport.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            TopWorseReport.ShedName.Text = this.Shed.Text;
            if (this.TopWorseSelection.EditValue.ToString() == "DESC")
                TopWorseReport.ReportName.Text = "Top Looms Report";
            if (this.TopWorseSelection.EditValue.ToString() == "ASC")
                TopWorseReport.ReportName.Text = "Worse Looms Report";

            DataSet dsTopWorse = WS.svc.Get_DataSet(ArticleWiseString);
            if (dsTopWorse != null)
            {

                TopWorseReport.DataSource = dsTopWorse.Tables[0];
            }
            TopWorseReport.EndInit();
            TopWorseReport.ShowPreview();
        }
        private void Report_Click(object sender, EventArgs e)
        {
            if (this.radioGroupArticleLoom.EditValue.ToString() == "A")
                ArticleReport();
            else if (this.radioGroupArticleLoom.EditValue.ToString() == "L")
                LoomReport();
        }

       
    }
}
