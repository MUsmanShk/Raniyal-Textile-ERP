using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGauges.Win.Base;
namespace MachineEyes.Data
{
    public partial class Data_AboutLoom : DevExpress.XtraEditors.XtraForm
    {
        public int LoomIndex = -1;
        public Data_AboutLoom()
        {
            InitializeComponent();
        }

        private void Data_AboutLoom_Load(object sender, EventArgs e)
        {
            int ShedIndex = -1;
            int TypeIndex = -1;
            if (LoomIndex == -1) return;
            ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(Program.ss.Machines.Looms[LoomIndex].PersonalInfo.ShedID.ToString());
            TypeIndex = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnArrayIndex_Types(Program.ss.Machines.Looms[LoomIndex].PersonalInfo.TypeID.ToString());
            this.L_Article.Appearance.ImageList = Program.MainWindow.CauseImages;
            this.L_Article.Appearance.ImageIndex = (int)Cause.ArticleChange;

            this.L_Electrical.Appearance.ImageList = Program.MainWindow.CauseImages;
            this.L_Knotting.Appearance.ImageList = Program.MainWindow.CauseImages;
            this.L_Mechanical.Appearance.ImageList = Program.MainWindow.CauseImages;
            this.L_OtherBreakages.Appearance.ImageList = Program.MainWindow.CauseImages;
            this.L_OtherLong.Appearance.ImageList = Program.MainWindow.CauseImages;
            this.L_PowerOff.Appearance.ImageList = Program.MainWindow.CauseImages;
            this.L_WarpBreakages.Appearance.ImageList = Program.MainWindow.CauseImages;
            this.L_WeftBreakages.Appearance.ImageList = Program.MainWindow.CauseImages;
            this.L_Electrical.Appearance.ImageIndex = (int)Cause.Electrical;
            this.L_Knotting.Appearance.ImageIndex = (int)Cause.Knotting;
            this.L_Mechanical.Appearance.ImageIndex = (int)Cause.Mechanical;
            this.L_OtherBreakages.Appearance.ImageIndex = (int)Cause.Other;
            this.L_OtherLong.Appearance.ImageIndex = (int)Cause.OtherLong;
            this.L_PowerOff.Appearance.ImageIndex = (int)Cause.PowerOff;
            this.L_WarpBreakages.Appearance.ImageIndex = (int)Cause.Warp;
            this.L_WeftBreakages.Appearance.ImageIndex = (int)Cause.Weft;
            this.CurrentCause.Appearance.ImageList =Program.MainWindow.CauseImages;

            this.LoomName.Text = Program.ss.Machines.Looms[LoomIndex].PersonalInfo.LoomName;
            this.Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            this.Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            this.Type.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[TypeIndex].TypeName;
            this.Type.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[TypeIndex].TypeID;
            this.Stops_Warp.Text = Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_Warps.ToString();
            this.Stops_Weft.Text = Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_Wefts.ToString();
            this.Stops_Other.Text = Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_Others.ToString();

                     double s;
                     double Defficiency = 100 - Program.ss.Machines.Looms[LoomIndex].CurrentParams.Current_Eff;
                    
                    if (Defficiency < 0) Defficiency = 0;
                   
                     s = ((Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_WarpETime / Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_DownTime) * 100) * Defficiency / 100;
                    this.Stops_WarpLoss.Text = double.IsNaN(s)==true?"0.00%": s.ToString("#,##0.00") + "%";

                    s = ((Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_WeftETime / Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_DownTime) * 100) * Defficiency / 100;
                    this.Stops_WeftLoss.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                    s = ((Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_OtherETime / Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_DownTime) * 100) * Defficiency / 100;
                    this.Stops_OtherLoss.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";

                    s = ((Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_MechanicalETime / Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_DownTime) * 100) * Defficiency / 100;
                    this.Defficiency_Mechanical.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                    s = ((Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_ArticleETime / Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_DownTime) * 100) * Defficiency / 100;
                    this.Defficiency_Article.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                    s = ((Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_LongStop_5_ETime / Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_DownTime) * 100) * Defficiency / 100;
                    this.Defficiency_BeamShort.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                    s = ((Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_ElectricalETime / Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_DownTime) * 100) * Defficiency / 100;
                    this.Defficiency_Electrical.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                    s = ((Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_KnottingETime / Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_DownTime) * 100) * Defficiency / 100;
                    this.Defficiency_Knotting.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                    s = ((Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_LongOtherETime / Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_DownTime) * 100) * Defficiency / 100;
                    this.Defficiency_OtherLong.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                    s = ((Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_PowerOffETime / Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_DownTime) * 100) * Defficiency / 100;
                    this.Defficiency_PoweredOff.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
            this.Stops_WarpElapsed.Text = Program.ss.Get_FormattedTime(Convert.ToInt32(Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_WarpETime));
            this.Stops_OtherElapsed.Text = Program.ss.Get_FormattedTime(Convert.ToInt32(Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_OtherETime));
            this.Stops_WeftElapsed.Text = Program.ss.Get_FormattedTime(Convert.ToInt32(Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_WeftETime));
            try
            {
                this.Weaved_Units.Text = Convert.ToDouble(Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_Picks / 1000).ToString("#,##0.00");
            }
            catch
            {
            }
            this.Stops_MechanicalTime.Text = Program.ss.Get_FormattedTime(Convert.ToInt32(Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_MechanicalETime));
            this.Stops_ElectricalTime.Text = Program.ss.Get_FormattedTime(Convert.ToInt32(Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_ElectricalETime));
            this.Stops_KnottingTime.Text = Program.ss.Get_FormattedTime(Convert.ToInt32(Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_KnottingETime));
            this.Stops_ArticleTime.Text = Program.ss.Get_FormattedTime(Convert.ToInt32(Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_ArticleETime));
            this.Stops_PowerOffTime.Text = Program.ss.Get_FormattedTime(Convert.ToInt32(Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_PowerOffETime));
            this.Stops_OtherLongTime.Text = Program.ss.Get_FormattedTime(Convert.ToInt32(Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_LongOtherETime));
            this.Stops_BeamShortETime.Text = Program.ss.Get_FormattedTime(Convert.ToInt32(Program.ss.Machines.Looms[LoomIndex].ShiftParams.Shift_LongStop_5_ETime));
            this.SetNo.Text = Program.ss.Machines.Looms[LoomIndex].CurrentAssignedParams.SetNo;
            this.BeamNo.Text = Program.ss.Machines.Looms[LoomIndex].CurrentAssignedParams.BeamNo;
            this.ArticleNumber.Text = Program.ss.Machines.Looms[LoomIndex].CurrentAssignedParams.ArticleNumber;
            if (Program.ss.Machines.Looms[LoomIndex].CurrentAssignedParams.ArticleNumber != "-1")
                this.ArticleName.Text = Program.ss.Machines.PresentationData.Articles[Program.ss.Machines.Looms[LoomIndex].CurrentAssignedParams.ArticleNumber].ArticleName;
            else
                this.ArticleName.Text = "NO ARTICLE DEFINED";
            this.ACSNumber.Text = Program.ss.Machines.Looms[LoomIndex].CurrentAssignedParams.ACSNumber;
            this.RPM.Text = Math.Round(Program.ss.Machines.Looms[LoomIndex].CurrentParams.Current_RPM, 0).ToString();
         
            Cause cs = (Cause)Program.ss.Machines.Looms[LoomIndex].CurrentParams.Current_Cause;

            this.CurrentCause.Text =cs.ToString();
            if ((State)Program.ss.Machines.Looms[LoomIndex].CurrentParams.Current_State != State.Running)
                this.CurrentCause.Appearance.ImageIndex = Program.ss.Machines.Looms[LoomIndex].CurrentParams.Current_Cause;
            else
                this.CurrentCause.Appearance.ImageIndex = -1;
            State st = (State)Program.ss.Machines.Looms[LoomIndex].CurrentParams.Current_State;
            this.CurrentState.Text = st.ToString();
            this.CurrentEfficiency.Text = Program.ss.Machines.Looms[LoomIndex].CurrentParams.Current_Eff.ToString("#,##0.0") + "%";
            this.CurrentEfficiency.Tag = Program.ss.Machines.Looms[LoomIndex].CurrentParams.Current_Eff.ToString();

            this.ProductionEfficiency.Text = Program.ss.Machines.Looms[LoomIndex].CurrentParams.Current_Prod_Eff.ToString("#,##0.0") + "%";
            this.ProductionEfficiency.Tag = Program.ss.Machines.Looms[LoomIndex].CurrentParams.Current_Prod_Eff.ToString();
            this.TimeEfficiency.Text = Program.ss.Machines.Looms[LoomIndex].CurrentParams.Current_Time_Eff.ToString("#,##0.0") + "%";
            this.TimeEfficiency.Tag = Program.ss.Machines.Looms[LoomIndex].CurrentParams.Current_Time_Eff.ToString();
            this.TimeProductionEfficiency.Text = Program.ss.Machines.Looms[LoomIndex].CurrentParams.Current_Time_Prod_Eff.ToString("#,##0.0") + "%";
            this.TimeProductionEfficiency.Tag = Program.ss.Machines.Looms[LoomIndex].CurrentParams.Current_Time_Prod_Eff.ToString();
 

            DataSet ds = WS.svc.Get_DataSet("Select * from MT_Looms where LoomID=" + LoomIndex.ToString() + "");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.IndexNumber.Text = LoomIndex.ToString();
                    this.LoomSize.Text = ds.Tables[0].Rows[0]["LoomSize"].ToString();
                    this.LoomModel.Text = ds.Tables[0].Rows[0]["LoomModel"].ToString();
                    this.LoomMake.Text = ds.Tables[0].Rows[0]["LoomMake"].ToString();

                }
            }
        }

        private void Close_CheckedChanged(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelControl19_Click(object sender, EventArgs e)
        {

        }

    }
}