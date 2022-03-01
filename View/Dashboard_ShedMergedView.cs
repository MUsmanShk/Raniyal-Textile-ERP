using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes
{
    public partial class Dashboard_ShedMergedView : DevExpress.XtraEditors.XtraForm
    {
        public int LayoutIndex;
       
        public Dashboard_ShedMergedView()
        {
            InitializeComponent();
        }

        private void dxShedView_Load(object sender, EventArgs e)
        {

           
            Settings.DataWaitingSeconds = 300;
            if (dxShed1.ShedEfficiency.Tag == null) dxShed1.ShedEfficiency.Tag = "0";
            if (dxShed1.RPM_Val.Tag == null) dxShed1.RPM_Val.Tag = "0";
            dxShed1.RunningEff.Tag = "0";

          
            for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
            {

                int lIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_MergedSheds(Program.ss.Machines.Looms[x].PersonalInfo.ShedID.ToString());
                if (lIndex == LayoutIndex)
                {
                    

                        dxLoom uc = new dxLoom();
                        uc.LoomNumber.Text = Program.ss.Machines.Looms[x].PersonalInfo.LoomName;
                        uc.LoomNumber.Tag = Program.ss.Machines.Looms[x].PersonalInfo.LoomID;
                        uc.Efficiency.Tag = "0.0";
                        uc.Left = Convert.ToInt32(Program.ss.Machines.Looms[x].Drawing.x);
                        uc.Top = Convert.ToInt32(Program.ss.Machines.Looms[x].Drawing.y);
                        uc.Name = "Loom" + x.ToString();
                        ControlMover.Init(uc);
                        this.panelControl1.Controls.Add(uc);
              

                }


            }
            DataSet DSLoomsLayout = WS.svc.Get_DataSet("Select * from MT_Looms Order by LoomID");

            if (DSLoomsLayout!=null)
            {


                if (DSLoomsLayout != null)
                {
                    if (DSLoomsLayout.Tables[0].Rows.Count > 0)
                    {

                        for (int x = 0; x < DSLoomsLayout.Tables[0].Rows.Count; x++)
                        {
                            int Loom_X = 0, Loom_Y = 0; int LoomID = -1;

                            

                            int.TryParse(DSLoomsLayout.Tables[0].Rows[x]["ML_" + LayoutIndex.ToString() + "_X"].ToString(), out Loom_X);
                            int.TryParse(DSLoomsLayout.Tables[0].Rows[x]["ML_" + LayoutIndex.ToString() + "_Y"].ToString(), out Loom_Y);
                            int.TryParse(DSLoomsLayout.Tables[0].Rows[x]["LoomID"].ToString(), out LoomID);
                            dxLoom uc=ReturnUC(LoomID);
                            if(uc!=null)
                            {
                                uc.Left =Loom_X;
                                uc.Top = Loom_Y;
                            }






                        }
                    }
                }
            }

            for (int x = 0; x < Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].TypesOfLooms.Length; x++)
            {
                dxTypeEff LoomType = new dxTypeEff();

               
                LoomType.Model.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].TypesOfLooms[x].TypeName;
                LoomType.Model.Tag = x.ToString();
                LoomType.RunningEfficiency.Text = "0.0";
                LoomType.RunningEfficiency.Tag = "0.0";
                LoomType.ShedEfficiency.Text = "0.0";
                LoomType.RPM.Text = "0";
                LoomType.RPM.Tag = "0";
                LoomType.TotalMachines.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].TypesOfLooms[x].LoomIndexes.Length.ToString();
                this.dxShed1.tableLayoutPanel_Types.Controls.Add(LoomType);
            }

            for (int x = 0; x < Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections.Length; x++)
            {
                UserControls.dxSection sType = new UserControls.dxSection();

                sType.Section.Tag = x.ToString();
                sType.Section.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[x].SectionName;
                sType.Efficiency.Tag = "0";
                this.dxShed1.tableLayoutPanel_Section.Controls.Add(sType);
            }
            
           
           
            try
            {
                Program.MainWindow.bar_Shift.Caption = "Shift: " +  Program.ss.Machines.PresentationData.CurrentShift.WShift;
    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error executing fuctions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private dxLoom ReturnUC(int LoomID)
        {
                    for (int x = 0; x < this.panelControl1.Controls.Count; x++)
                    {
                        dxLoom uc = (dxLoom)this.panelControl1.Controls[x];
                        if (uc.LoomNumber.Tag.ToString() == LoomID.ToString())
                        {


                            return uc;
                        }
                        }
                    return null;

        }
        private void timer_AutoRefresh_Tick(object sender, EventArgs e)
        {
            
           
            
           
          
            #region Looms
            for (int x = 0; x < this.panelControl1.Controls.Count; x++)
            {
                Control uictr = this.panelControl1.Controls[x];
                if(uictr is dxLoom)
                {
                    dxLoom uiLoom=(dxLoom)uictr;
                    
                    try
                    {
                        Program.ss.SetMachineDisplay(ref Program.ss.Machines.Looms[Convert.ToInt32(uiLoom.LoomNumber.Tag)], ref uiLoom);
                    }
                    catch
                    {
                    }
                }
            }
        
            #endregion
            try
            {
                #region shedEff
             
               
                if (dxShed1.ShedEfficiency.Tag.ToString() != Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.Eff.ToString())
                {
                    dxShed1.ShedEfficiency.Tag = double.IsNaN(Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.Eff) == true ? "0.0" : Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.Eff.ToString();
                    dxShed1.ShedEfficiency.Text = double.IsNaN(Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.Eff) == true ? "0.0" : Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.Eff.ToString("#,##0.0");

                }

                if (dxShed1.RunningEff.Tag.ToString() != Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.RunningEff.ToString())
                {
                    dxShed1.RunningEff.Tag = double.IsNaN(Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.RunningEff) == true ? "0.0" : Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.RunningEff.ToString();
                    dxShed1.RunningEff.Text = double.IsNaN(Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.RunningEff) == true ? "0.0" : Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.RunningEff.ToString("#,##0.0");

                }
                #endregion
            }
            catch 
            {
            }
            try
            {
                #region shedRPM

                if (dxShed1.RPM_Val.Tag.ToString() != Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.RPM.ToString())
                {
                    dxShed1.RPM_Val.Tag = double.IsNaN(Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.RPM) == true ? "0.0" : Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.RPM.ToString();

                    dxShed1.RPM_Val.Text = double.IsNaN(Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.RPM) == true ? "0.0" : Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.RPM.ToString("#,##");

                }

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
                    double s;
                    double Defficiency = 100 - Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShedEfficiency.Eff;
                    if (Defficiency < 0) Defficiency = 0;

                    s = ((Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.sOtherElapsed / Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                    this.dxShed1.Loss_Other.Text = double.IsNaN(s)==true?"": s.ToString("#,##0.00");
                    s = ((Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.sWarpElapsed / Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                    this.dxShed1.Loss_Warp.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                    s = ((Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.sWeftElapsed / Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                    this.dxShed1.Loss_Weft.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                    s = ((Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.lElectricalElapsed / Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                    this.dxShed1.LongStops_Electrical_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                    s = ((Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.lKnottingElapsed / Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                    this.dxShed1.LongStops_Knotting_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                    s = ((Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.lMechanicalElapsed / Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                    this.dxShed1.LongStops_Mechanical_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                    s = ((Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.lOtherElapsed / Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                    this.dxShed1.LongStops_Others_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                    s = ((Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.lArticleElapsed / Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                    this.dxShed1.LongStops_Article_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                    s = ((Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.lPowerOffElapsed / Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                    this.dxShed1.LongStops_PoweredOff_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                    s = ((Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.lLongStop_5 / Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                    this.dxShed1.LongStops_BeamShort_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                    this.dxShed1.Counter_Warp.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.sWarpTotalBreakages.ToString();
                    this.dxShed1.Counter_Weft.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.sWeftTotalBreakages.ToString();
                    this.dxShed1.Counter_Other.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].StoppedStats.sOtherTotalBreakages.ToString();

                    this.dxShed1.LongStops_Article_Val.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.ArticleChange.Length.ToString();
                    this.dxShed1.LongStops_Electrical_Val.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.Electrical.Length.ToString();
                    this.dxShed1.LongStops_Knotting_Val.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.Knotting.Length.ToString();
                    this.dxShed1.LongStops_Mechanical_Val.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.Mechanical.Length.ToString();
                    this.dxShed1.LongStops_PowerOff_Val.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.PowerOff.Length.ToString();
                    this.dxShed1.LongStops_BeamShort_Val.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.BeamShort.Length.ToString();
                    this.dxShed1.LongStops_Others_Val.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.Others.Length.ToString();
                    this.dxShed1.Total_LongStopped.Text = Convert.ToString(Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.ArticleChange.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.Electrical.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.Knotting.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.Mechanical.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.Others.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.PowerOff.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.BeamShort.Length);
                   
                    //#endregion
                    //#region ShortStops
                    this.dxShed1.Stopped_Other.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShortStops.Others.Length.ToString();
                    this.dxShed1.Stopped_Warp.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShortStops.Warp.Length.ToString();
                    this.dxShed1.Stopped_Weft.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShortStops.Weft.Length.ToString();
                    this.dxShed1.Total_ShortStopped.Text = Convert.ToString(Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShortStops.Others.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShortStops.Warp.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShortStops.Weft.Length);
                    int longstopped = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.ArticleChange.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.Electrical.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.Knotting.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.Mechanical.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.Others.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.PowerOff.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].LongStops.BeamShort.Length;
                    int shortstopped = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShortStops.Others.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShortStops.Warp.Length + Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ShortStops.Weft.Length;
                    int TotalLooms = this.panelControl1.Controls.Count;
                    this.dxShed1.TotalLooms.Text = TotalLooms.ToString();
                    this.dxShed1.RunningLooms.Text = Convert.ToString(TotalLooms - longstopped - shortstopped);
                    this.dxShed1.TotalRunningInShed.Text = (TotalLooms - longstopped).ToString();
                }
                catch 
                {
                }
                #endregion
            }
            catch 
            {
            }
            try
            {
                #region TypesUpdate
                foreach (Control dxCtr in this.dxShed1.tableLayoutPanel_Types.Controls)
                {
                    dxTypeEff dxType = (dxTypeEff)dxCtr;
                    if (Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].Eff.ToString() != dxType.RunningEfficiency.Tag.ToString())
                    {
                        try
                        {
                            dxType.RunningEfficiency.Tag = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RunningEff.ToString();
                            dxType.RunningEfficiency.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RunningEff.ToString("#,##0.0");
                            dxType.ShedEfficiency.Text =Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].Eff.ToString("#,##0.0");
                        }
                        catch
                        {
                        }
                    }
                    if (Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString() != dxType.RPM.Tag.ToString())
                    {
                        dxType.RPM.Tag = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString();
                        dxType.RPM.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString("#,##");

                    }
                }
                #endregion
            }
            catch
            {
            }

            try
            {
                #region SectionUpdate
                foreach (Control dxCtr in this.dxShed1.tableLayoutPanel_Section.Controls)
                {
                    UserControls.dxSection dxType = (UserControls.dxSection)dxCtr;
                    if (Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[Convert.ToInt16(dxType.Section.Tag)].RunningEff.ToString() != dxType.Efficiency.Tag.ToString())
                    {
                        try
                        {
                            dxType.Efficiency.ForeColor =Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ReturnColor(ColorCauses.EfficiencyColors,Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[Convert.ToInt16(dxType.Section.Tag)].Eff);
                            dxType.Efficiency.Tag = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[Convert.ToInt16(dxType.Section.Tag)].Eff.ToString();
                            dxType.Efficiency.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[Convert.ToInt16(dxType.Section.Tag)].Eff.ToString("#,##0.0");


                            dxType.RunningEfficiency.ForeColor = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].ReturnColor(ColorCauses.EfficiencyColors, Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[Convert.ToInt16(dxType.Section.Tag)].RunningEff);
                            dxType.RunningEfficiency.Tag = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[Convert.ToInt16(dxType.Section.Tag)].RunningEff.ToString();
                            dxType.RunningEfficiency.Text = Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[Convert.ToInt16(dxType.Section.Tag)].RunningEff.ToString("#,##0.0");
                          
                            
                        }
                        catch
                        {
                        }
                    }
                    
                }
                #endregion
            }
            catch
            {
            }
        }
        
        private void Dashboard_Shed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Exit == false) { e.Cancel = true; this.Hide(); }
        }

        private void panelControl1_Enter(object sender, EventArgs e)
        {
            CurrentSelection.SelectedView = this;
        }

        private void dxShed1_Load(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}