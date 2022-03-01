using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using DevExpress.XtraGauges.Win.Base;
namespace MachineEyes.View
{
    public partial class Dashboard_Executive : DevExpress.XtraEditors.XtraForm
    {
        public enum graphMode : int { SingleShed = 0, MultiSheds = 1}
        graphMode GraphMode = graphMode.SingleShed;
        Boolean doScrollArticles = false;
        public MachineService.paramsStatus FetchedParamStatus = new MachineService.paramsStatus();
        private DateTime LastAssignedParamsCheck;
        private DateTime LastTopCheck;
        public Dashboard_Executive()
        {
            InitializeComponent();

        }
        private void Load_TopBottomThree()
        {
            LastTopCheck = DateTime.Now;
        

            for (int x = 0; x < 3; x++)
            {
                dxWeaver_NameEff BThree = new dxWeaver_NameEff();
                BThree.Index.Text = Convert.ToString(x + 1);
                BThree.Weaver.Tag = "-1";
                BThree.Efficiency.Tag = "-1";

                this.tableLayoutPanel_TopThreeWeavers.Controls.Add(BThree);

                dxLoom_NameEff TopLoom = new dxLoom_NameEff();
                TopLoom.Index.Text = Convert.ToString(x + 1);
                TopLoom.Efficiency.Tag = "";
                TopLoom.Loom.Tag = "";
                TopLoom.Efficiency.Text = "";
                TopLoom.Loom.Text = "";
                this.tableLayoutPanel_TopThreeLooms.Controls.Add(TopLoom);

                dxLoom_NameEff BotLoom = new dxLoom_NameEff();
                BotLoom.Index.Text = Convert.ToString(x + 1);
                BotLoom.Efficiency.Tag = "";
                BotLoom.Loom.Tag = "";
                BotLoom.Efficiency.Text = "";
                BotLoom.Loom.Text = "";
                this.tableLayoutPanel_BottomThreeLooms.Controls.Add(BotLoom);
            }
          

            //}

       

        }

        private void Load_GraphSingleShed()
        {
            this.chart1.Series.Clear();
            System.Windows.Forms.DataVisualization.Charting.Series s = new System.Windows.Forms.DataVisualization.Charting.Series("Shift");
            this.chart1.Series.Add(s);
            for (int y = 0; y < Program.ss.Machines.PresentationData.Sheds[0].TypesOfLooms.Length; y++)
            {

                System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 0);
                this.chart1.Series[0].Points.Add(dp);
                this.chart1.Series[0].Points[y].BorderColor = Color.Black;
                this.chart1.Series[0].Points[y].IsValueShownAsLabel = false;
                this.chart1.Series[0].Points[y].Label = Program.ss.Machines.PresentationData.Sheds[0].TypesOfLooms[y].TypeName;
                this.chart1.Series[0].Points[y].LabelBorderWidth = 2;
               
            }
        }
        private void Refresh_Efficiency()
        {
            ((IDigitalGauge)this.gaugeControl_Efficiency.Gauges[0]).Text = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[0].ShedEfficiency.Eff) == true ? "0.00" : Program.ss.Machines.PresentationData.Sheds[0].ShedEfficiency.Eff.ToString("#,##0.00");
            ((ICircularGauge)this.gaugeControl_RPM.Gauges[0]).Labels[0].Text = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[0].ShedEfficiency.RPM) == true ? "0" : Convert.ToInt32(Program.ss.Machines.PresentationData.Sheds[0].ShedEfficiency.RPM).ToString("#,##");
            ((ICircularGauge)this.gaugeControl_RPM.Gauges[0]).Scales[0].Value = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[0].ShedEfficiency.RPM) == true ? 0 : Convert.ToInt32(Program.ss.Machines.PresentationData.Sheds[0].ShedEfficiency.RPM);
        }
        public void Load_Articles()
        {

            DataSet dsArticles = new DataSet();
            this.scrollArticles.Controls.Clear();
            dsArticles = WS.svc.Get_DataSet("Select articlenumber,count(LoomID) as TotalLooms from MT_looms group by ArticleNumber order by ArticleNumber");
            if (dsArticles != null)
            {


                for (int x = 0; x < dsArticles.Tables[0].Rows.Count; x++)
                {
                    try
                    {
                        MachineEyes.UserControls.dxArticleEfficiency_Ex ArticlesCtr = new UserControls.dxArticleEfficiency_Ex();
                        this.scrollArticles.Controls.Add(ArticlesCtr);
                        ArticlesCtr.Tag = dsArticles.Tables[0].Rows[x]["ArticleNumber"].ToString() == "" ? "-1" : dsArticles.Tables[0].Rows[x]["ArticleNumber"].ToString();
                        ArticlesCtr.Index.Text = Convert.ToString(x + 1);
                        ArticlesCtr.Construction.Text = Program.ss.Machines.PresentationData.Articles[ArticlesCtr.Tag.ToString()].ArticleName;
                        ArticlesCtr.ArticleNumber.Text = ArticlesCtr.Tag.ToString();
                        ArticlesCtr.NoofLooms.Text = dsArticles.Tables[0].Rows[x]["TotalLooms"].ToString() == "" ? "0" : dsArticles.Tables[0].Rows[x]["TotalLooms"].ToString();
                        ArticlesCtr.Efficiency.Tag = "0";
                        ArticlesCtr.RPM.Tag = "0";
                        if (x > 0) ArticlesCtr.Top = this.scrollArticles.Controls[x - 1].Top + this.scrollArticles.Controls[x - 1].Height;
                        if (ArticlesCtr.Top >= scrollArticles.Height) doScrollArticles = true;
                    }
                    catch
                    {

                    }
                }
            }

        }
        private void Refresh_Articles()
        {





            for (int x = 0; x < this.scrollArticles.Controls.Count; x++)
            {
                try
                {
                    MachineEyes.UserControls.dxArticleEfficiency_Ex ArticlesEff = (MachineEyes.UserControls.dxArticleEfficiency_Ex)this.scrollArticles.Controls[x];


                    if (Convert.ToDouble(ArticlesEff.RPM.Tag.ToString()) != Program.ss.Machines.PresentationData.Articles[ArticlesEff.Tag.ToString()].rpm)
                    {
                        ArticlesEff.RPM.Tag = Program.ss.Machines.PresentationData.Articles[ArticlesEff.Tag.ToString()].rpm;
                        ArticlesEff.RPM.Text = Program.ss.Machines.PresentationData.Articles[ArticlesEff.Tag.ToString()].rpm.ToString("#,##");
                    }

                    if (Convert.ToDouble(ArticlesEff.Efficiency.Tag.ToString()) != Program.ss.Machines.PresentationData.Articles[ArticlesEff.Tag.ToString()].eff)
                    {
                        ArticlesEff.Efficiency.Tag = Program.ss.Machines.PresentationData.Articles[ArticlesEff.Tag.ToString()].eff;
                        ArticlesEff.Efficiency.Text = Program.ss.Machines.PresentationData.Articles[ArticlesEff.Tag.ToString()].eff.ToString("#,##0.0") + "%";
                    }
                    if (this.doScrollArticles == true)
                    {
                        this.scrollArticles.Controls[x].Top = this.scrollArticles.Controls[x].Top - 1;
                        if (this.scrollArticles.Controls[x].Top < (this.scrollArticles.Controls[x].Height - (this.scrollArticles.Controls[x].Height * 2)))
                            this.scrollArticles.Controls[x].Top = this.scrollArticles.Controls[x == 0 ? this.scrollArticles.Controls.Count - 1 : x - 1].Top + this.scrollArticles.Controls[0].Height;
                    }
                }
                catch
                {
                }
            }
        }
        private void Refresh_TopBottoms()
        {


            try
            {
                TimeSpan ts = DateTime.Now.Subtract(LastTopCheck);
                if (ts.TotalSeconds < 60) return;
                LastTopCheck = DateTime.Now;
                IEnumerable<int> Bthree = (from i in Program.ss.Machines.PresentationData.Sheds[0].LoomGroups
                                             orderby i.Efficiency ascending
                                             select i.GroupNumber).Take(3);


                for (int x = 0; x < 3; x++)
                {
                    dxWeaver_NameEff ctrWeaver = (dxWeaver_NameEff)this.tableLayoutPanel_TopThreeWeavers.Controls[x];
                    loomGroup Weaver = Program.ss.Machines.PresentationData.Sheds[0].LoomGroups[Program.ss.Machines.PresentationData.Sheds[0].ReturnArrayIndex_LoomGroup(Bthree.ElementAt(x))];
                    if (Program.ss.Machines.PresentationData.CurrentShift.WShift == "A")
                    {
                        if (ctrWeaver.Weaver.Tag.ToString() != Weaver.Weavers.WeaverID_A)
                        {
                            ctrWeaver.Weaver.Tag = Weaver.Weavers.WeaverID_A;
                            ctrWeaver.Weaver.Text = Weaver.Weavers.WeaverName_A;
                        }
                    }
                    else if (Program.ss.Machines.PresentationData.CurrentShift.WShift == "B")
                    {
                        if (ctrWeaver.Weaver.Tag.ToString() != Weaver.Weavers.WeaverID_B)
                        {
                            ctrWeaver.Weaver.Tag = Weaver.Weavers.WeaverID_B;
                            ctrWeaver.Weaver.Text = Weaver.Weavers.WeaverName_B;
                        }
                    }
                    else if (Program.ss.Machines.PresentationData.CurrentShift.WShift == "C")
                    {
                        if (ctrWeaver.Weaver.Tag.ToString() != Weaver.Weavers.WeaverID_C)
                        {
                            ctrWeaver.Weaver.Tag = Weaver.Weavers.WeaverID_C;
                            ctrWeaver.Weaver.Text = Weaver.Weavers.WeaverName_C;
                        }
                    }
                    if (ctrWeaver.Efficiency.Tag.ToString() != Weaver.Efficiency.ToString())
                    {
                        ctrWeaver.Efficiency.Tag = Weaver.Efficiency.ToString();
                        ctrWeaver.Efficiency.Text = Weaver.Efficiency.ToString("#,##0.0") + "%";
                    }

                }



                var TopthreeLooms = (from i in Program.ss.Machines.Looms
                                     where i.PersonalInfo.ShedID.ToString() == Program.ss.Machines.PresentationData.Sheds[0].ShedID
                                     orderby i.CurrentParams.Current_Eff descending
                                     select i).Take(3);


                for (int x = 0; x < 3; x++)
                {
                    dxLoom_NameEff ctrLoom = (dxLoom_NameEff)this.tableLayoutPanel_TopThreeLooms.Controls[x];
                    MachineService.Loom loom = (MachineService.Loom)TopthreeLooms.ElementAt(x);

                    if (ctrLoom.Loom.Tag.ToString() != loom.PersonalInfo.LoomID.ToString())
                    {
                        ctrLoom.Loom.Tag = loom.PersonalInfo.LoomID.ToString();
                        ctrLoom.Loom.Text = loom.PersonalInfo.LoomName;

                    }
                    if (ctrLoom.Efficiency.Tag.ToString() != loom.CurrentParams.Current_Eff.ToString())
                    {
                        ctrLoom.Efficiency.Tag = loom.CurrentParams.Current_Eff.ToString();
                        ctrLoom.Efficiency.Text = loom.CurrentParams.Current_Eff.ToString("#,##0.0") + "%";
                    }

                }

                var BotthreeLooms = (from i in Program.ss.Machines.Looms
                                     where i.PersonalInfo.ShedID.ToString() == Program.ss.Machines.PresentationData.Sheds[0].ShedID
                                     orderby i.CurrentParams.Current_Eff ascending
                                     select i).Take(3);


                for (int x = 0; x < 3; x++)
                {
                    dxLoom_NameEff ctrLoom = (dxLoom_NameEff)this.tableLayoutPanel_BottomThreeLooms.Controls[x];
                    MachineService.Loom loom = (MachineService.Loom)BotthreeLooms.ElementAt(x);

                    if (ctrLoom.Loom.Tag.ToString() != loom.PersonalInfo.LoomID.ToString())
                    {
                        ctrLoom.Loom.Tag = loom.PersonalInfo.LoomID.ToString();
                        ctrLoom.Loom.Text = loom.PersonalInfo.LoomName;

                    }
                    if (ctrLoom.Efficiency.Tag.ToString() != loom.CurrentParams.Current_Eff.ToString())
                    {
                        ctrLoom.Efficiency.Tag = loom.CurrentParams.Current_Eff.ToString();
                        ctrLoom.Efficiency.Text = loom.CurrentParams.Current_Eff.ToString("#,##0.0") + "%";
                    }

                }


              

            }
            catch
            {
            }
        }
        private void Refresh_Graph_SingleShed()
        {
            for (int x = 0; x < Program.ss.Machines.PresentationData.Sheds[0].TypesOfLooms.Length; x++)
            {


                try
                {
                    if (this.chart1.Series[0].Points[x].YValues[0] != Program.ss.Machines.PresentationData.Sheds[0].TypesOfLooms[x].Eff)
                    {

                        this.chart1.Series[0].Points[x].YValues[0] = Program.ss.Machines.PresentationData.Sheds[0].TypesOfLooms[x].Eff;
                        this.chart1.Series[0].Points[x].Color = Program.ss.Machines.PresentationData.Sheds[0].ReturnColor(ColorCauses.EfficiencyColors, Program.ss.Machines.PresentationData.Sheds[0].TypesOfLooms[x].Eff);
                    }
                }
                catch
                {
                }



            }
        }
        private void Load_Sizing()
        {
            this.scrollSizing.Controls.Clear();
            for (int x = 0; x < Program.ss.Machines.PresentationData.Sets.Length; x++)
            {
                MachineEyes.UserControls.dxSetEff_Ex setsEff = new UserControls.dxSetEff_Ex();
                this.scrollSizing.Controls.Add(setsEff);
                if (x > 0) setsEff.Top = this.scrollSizing.Controls[x - 1].Top + this.scrollSizing.Controls[x - 1].Height;
                setsEff.Text = Convert.ToString(x + 1);
                setsEff.SetNumber.Text = Program.ss.Machines.PresentationData.Sets[x].SetNumber;
                setsEff.SetNumber.Tag = Program.ss.Machines.PresentationData.Sets[x].SetNumber;
                setsEff.SizingDate.Text = Program.ss.Machines.PresentationData.Sets[x].SizingDate.ToShortDateString();
                setsEff.AvgBreakages.Text = Program.ss.Machines.PresentationData.Sets[x].AvgWarpBreakagesPerHour_Current.ToString();
                setsEff.Efficiency.Text = Program.ss.Machines.PresentationData.Sets[x].Efficiency_Current.ToString("#,##0.0") + "%";

            }

        }
        private void Refresh_Sizing()
        {

            for (int x = 0; x < this.scrollSizing.Controls.Count; x++)
            {

                this.scrollSizing.Controls[x].Top = this.scrollSizing.Controls[x].Top - 1;
                if (this.scrollSizing.Controls[x].Top < (this.scrollSizing.Controls[x].Height - (this.scrollSizing.Controls[x].Height * 2)))
                    this.scrollSizing.Controls[x].Top = this.scrollSizing.Controls[x == 0 ? this.scrollSizing.Controls.Count - 1 : x - 1].Top + this.scrollSizing.Controls[0].Height;

            }
        }
        private void timer_AutoRefresh_Tick(object sender, EventArgs e)
        {

            if (GraphMode == graphMode.SingleShed)
                Refresh_Graph_SingleShed();
            else if (GraphMode == graphMode.MultiSheds)
                Refresh_Graph_SingleShed();
            Refresh_Articles();
            Refresh_Efficiency();
            Refresh_TopBottoms();
            if (DateTime.Now.Subtract(LastAssignedParamsCheck).TotalMinutes > 5)
            {
                LastAssignedParamsCheck = DateTime.Now;
                try
                {
                    MachineService.paramsStatus ps = WS.svc.Get_ParamStatus();
                    if (ps.LoomsCurrentAssignedParamNumber != FetchedParamStatus.LoomsCurrentAssignedParamNumber)
                    {
                        Load_Articles();
                        Program.ss.init_AssignLooms_Articles();
                        FetchedParamStatus.LoomsCurrentAssignedParamNumber = ps.LoomsCurrentAssignedParamNumber;
                    }
                }
                catch
                {
                }
            }

            try
            {
                #region LongStops
                this.LongStops_Article_Val.Text = Program.ss.Machines.PresentationData.Sheds[0].LongStops.ArticleChange.Length.ToString();
                this.LongStops_Electrical_Val.Text = Program.ss.Machines.PresentationData.Sheds[0].LongStops.Electrical.Length.ToString();
                this.LongStops_Knotting_Val.Text = Program.ss.Machines.PresentationData.Sheds[0].LongStops.Knotting.Length.ToString();
                this.LongStops_Mechanical_Val.Text = Program.ss.Machines.PresentationData.Sheds[0].LongStops.Mechanical.Length.ToString();
                this.LongStops_Others_Val.Text = Program.ss.Machines.PresentationData.Sheds[0].LongStops.Others.Length.ToString();

                #endregion
            }
            catch
            {
            }
            try
            {
                #region ShortStops
                this.ShortStops_Others_Val.Text = Program.ss.Machines.PresentationData.Sheds[0].ShortStops.Others.Length.ToString();
                this.ShortStops_Warp_Val.Text = Program.ss.Machines.PresentationData.Sheds[0].ShortStops.Warp.Length.ToString();
                this.ShortStops_Weft_Val.Text = Program.ss.Machines.PresentationData.Sheds[0].ShortStops.Weft.Length.ToString();
                #endregion
            }
            catch 
            {
            }
            try
            {
                #region Losses
                try
                {
                    double TotalLooms = 0;
                    for (int tx = 0; tx < Program.ss.Machines.PresentationData.Sheds[0].TypesOfLooms.Length; tx++)
                    {
                        TotalLooms += Program.ss.Machines.PresentationData.Sheds[0].TypesOfLooms[tx].LoomIndexes.Length;
                    }
                    double TotalSeconds = DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalSeconds * TotalLooms;

                    double s = (Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.sWarpTotalBreakages / Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.Units) * 10;
                    this.ShortStops_Warp_AvgPerUnit.Text = s.ToString("#,##0.00");
                    s = (Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.sWeftTotalBreakages / Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.Units) * 10;
                    this.ShortStops_Weft_AvgPerUnit.Text = s.ToString("#,##0.00");
                    s = (Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.sOtherTotalBreakages / Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.Units) * 10;
                    this.ShortStops_Others_AvgPerUnit.Text = s.ToString("#,##0.00");
                    s = (Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.sOtherElapsed / TotalSeconds) * 100;
                    this.ShortStops_Others_Loss.Text = s.ToString("#,##0.00");
                    s = (Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.sWarpElapsed / TotalSeconds) * 100;
                    this.ShortStops_Warp_Loss.Text = s.ToString("#,##0.00");
                    s = (Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.sWeftElapsed / TotalSeconds) * 100;
                    this.ShortStops_Weft_Loss.Text = s.ToString("#,##0.00");
                    s = (Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.lElectricalElapsed / TotalSeconds) * 100;
                    this.LongStops_Electrical_Loss.Text = s.ToString("#,##0.00");
                    s = (Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.lKnottingElapsed / TotalSeconds) * 100;
                    this.LongStops_Knotting_Loss.Text = s.ToString("#,##0.00");
                    s = (Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.lMechanicalElapsed / TotalSeconds) * 100;
                    this.LongStops_Mechanical_Loss.Text = s.ToString("#,##0.00");
                    s = (Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.lOtherElapsed / TotalSeconds) * 100;
                    this.LongStops_Others_Loss.Text = s.ToString("#,##0.00");
                    s = (Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.lArticleElapsed / TotalSeconds) * 100;
                    this.LongStops_Article_Loss.Text = s.ToString("#,##0.00");
                    s = Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.sWarpTotalBreakages / TotalLooms;
                    this.ShortStops_Warp_Average.Text = s.ToString("#,##0.00");
                    s = Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.sWeftTotalBreakages / TotalLooms;
                    this.ShortStops_Weft_Average.Text = s.ToString("#,##0.00");
                    s = Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.sOtherTotalBreakages / TotalLooms;
                    this.ShortStops_Others_Average.Text = s.ToString("#,##0.00");
                    s = (Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.sWarpTotalBreakages / TotalLooms) / DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalHours;
                    this.ShortStops_Warp_AvgPerHour.Text = s.ToString("#,##0.00");
                    s = (Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.sWeftTotalBreakages / TotalLooms) / DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalHours;
                    this.ShortStops_Weft_AvgPerHour.Text = s.ToString("#,##0.00");
                    s = (Program.ss.Machines.PresentationData.Sheds[0].StoppedStats.sOtherTotalBreakages / TotalLooms) / DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalHours;
                    this.ShortStops_Others_AvgPerHour.Text = s.ToString("#,##0.00");

                }
                catch 
                {
                }
                #endregion
            }
            catch 
            {
            }
           
        }

        private void Dashboard_Executive_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Dashboard_Executive_Load(object sender, EventArgs e)
        {
            if (GraphMode == graphMode.SingleShed)
                        Load_GraphSingleShed();
            Load_Articles();
            Load_Sizing();
            Load_TopBottomThree();
        }
    }
}