using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Info
{
    public partial class shortStopInfo : DevExpress.XtraEditors.XtraForm
    {
        public shortStopInfo()
        {
            InitializeComponent();
            this.Cap_Article.ImageList = Program.MainWindow.CauseImages;
            this.Cap_Article.ImageIndex = (int)Cause.ArticleChange;
            this.Cap_Warp.ImageList = Program.MainWindow.CauseImages;
            this.Cap_Warp.ImageIndex = (int)Cause.Warp;
            this.Cap_Weft.ImageList = Program.MainWindow.CauseImages;
            this.Cap_Weft.ImageIndex = (int)Cause.Weft;
            this.Cap_Other.ImageList = Program.MainWindow.CauseImages;
            this.Cap_Other.ImageIndex = (int)Cause.Other;
            this.Cap_Mechanical.ImageList = Program.MainWindow.CauseImages;
            this.Cap_Mechanical.ImageIndex = (int)Cause.Mechanical;
            this.Cap_Electrical.ImageList = Program.MainWindow.CauseImages;
            this.Cap_Electrical.ImageIndex = (int)Cause.Electrical;
            this.Cap_Knotting.ImageList = Program.MainWindow.CauseImages;
            this.Cap_Knotting.ImageIndex = (int)Cause.Knotting;
            this.Cap_Unknown.ImageList = Program.MainWindow.CauseImages;
            this.Cap_Unknown.ImageIndex = (int)Cause.OtherLong;
            LoadShortStopsInfo();
        }
        private double  ReturnElapsedTime(Cause cc,int x)
        {
            if ((State)Program.ss.Machines.Looms[x].CurrentParams.Current_State != State.Running)
            {
                if ((Cause)Program.ss.Machines.Looms[x].CurrentParams.Current_Cause == cc)
                    return DateTime.Now.Subtract(Program.ss.Machines.Looms[x].CurrentParams.Session_ActualStartTime).TotalSeconds;
                else return 0;
            }
            else return 0;
                                   
                                
        }
        private void LoadShortStopsInfo()
        {
            this.SS_WarpBreakages.Text = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Warps.ToString();
            this.SS_WarpElapsedTime.Text = Settings.FormatSeconds(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_WarpETime + ReturnElapsedTime(Cause.Warp, CurrentSelection.LoomIndex));
            this.SS_WarpAvgTime.Text = Settings.FormatSeconds((Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_WarpETime+ ReturnElapsedTime(Cause.Warp, CurrentSelection.LoomIndex)) / Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Warps);
            double s=Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Warps/DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalHours;
            this.SS_WarpAvgPerHour.Text = s.ToString("#,##0.00") + " / Hour";
            s =Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Warps/(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Picks/100);
            this.SS_WarpAvgPerUnit.Text = s.ToString("#,##0.000") + " / 10xU";
            double TotalSeconds = DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalSeconds ;
            s = ((Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_WarpETime+ ReturnElapsedTime(Cause.Warp, CurrentSelection.LoomIndex)) / TotalSeconds) * 100;
            this.SS_WarpLoss.Text = s.ToString("#,##0.00") + " %";


            this.SS_WeftBreakages.Text = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Wefts.ToString();
            this.SS_WeftElapsedTime.Text = Settings.FormatSeconds(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_WeftETime + ReturnElapsedTime(Cause.Weft, CurrentSelection.LoomIndex));
            this.SS_WeftAvgTime.Text = Settings.FormatSeconds((Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_WeftETime+ ReturnElapsedTime(Cause.Weft, CurrentSelection.LoomIndex)) / Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Wefts);
            s = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Wefts / DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalHours;
            this.SS_WeftAvgPerHour.Text = s.ToString("#,##0.00") + " / Hour";
            s = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Wefts / (Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Picks / 100);
            this.SS_WeftAvgPerUnit.Text = s.ToString("#,##0.000") + " / 10xU";
            TotalSeconds = DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalSeconds;
            s = ((Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_WeftETime+ ReturnElapsedTime(Cause.Weft, CurrentSelection.LoomIndex)) / TotalSeconds) * 100;
            this.SS_WeftLoss.Text = s.ToString("#,##0.00") + " %";


       

            this.SS_OtherBreakages.Text = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Others.ToString();
            this.SS_OtherElapsedTime.Text = Settings.FormatSeconds(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_OtherETime + ReturnElapsedTime(Cause.Other, CurrentSelection.LoomIndex));
            this.SS_OtherAvgTime.Text = Settings.FormatSeconds((Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_OtherETime+ ReturnElapsedTime(Cause.Other, CurrentSelection.LoomIndex)) / Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Others);
            s = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Others / DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalHours;
            this.SS_OtherAvgPerHour.Text = s.ToString("#,##0.00") + " / Hour";
            s = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Others / (Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_Picks / 100);
            this.SS_OtherAvgPerUnit.Text = s.ToString("#,##0.000") + " / 10xU";
            TotalSeconds = DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalSeconds;
            s = ((Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_OtherETime+ ReturnElapsedTime(Cause.Other, CurrentSelection.LoomIndex)) / TotalSeconds) * 100;
            this.SS_OtherLoss.Text = s.ToString("#,##0.00") + " %";




           
            this.SS_MechanicalElapsedTime.Text = Settings.FormatSeconds(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_MechanicalETime + ReturnElapsedTime(Cause.Mechanical, CurrentSelection.LoomIndex));
            s = ((Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_MechanicalETime + ReturnElapsedTime(Cause.Mechanical, CurrentSelection.LoomIndex)) / DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalSeconds) * 100;
            this.SS_MechanicalLoss.Text = s.ToString("#,##0.00") + " %";

            this.SS_ElectricalElapsedTime.Text = Settings.FormatSeconds(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_ElectricalETime + ReturnElapsedTime(Cause.Electrical, CurrentSelection.LoomIndex));
            s = ((Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_ElectricalETime + ReturnElapsedTime(Cause.Electrical, CurrentSelection.LoomIndex)) / DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalSeconds) * 100;
            this.SS_ElectricalLoss.Text = s.ToString("#,##0.00") + " %";

            this.SS_KnottingElapsedTime.Text = Settings.FormatSeconds(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_KnottingETime + ReturnElapsedTime(Cause.Knotting, CurrentSelection.LoomIndex));
            s = ((Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_KnottingETime + ReturnElapsedTime(Cause.Knotting, CurrentSelection.LoomIndex)) / DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalSeconds) * 100;
            this.SS_KnottingLoss.Text = s.ToString("#,##0.00") + " %";

            this.SS_ArticleElapsedTime.Text = Settings.FormatSeconds(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_ArticleETime + ReturnElapsedTime(Cause.ArticleChange, CurrentSelection.LoomIndex));
            s = ((Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_ArticleETime + ReturnElapsedTime(Cause.ArticleChange, CurrentSelection.LoomIndex)) / DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalSeconds) * 100;
            this.SS_ArticleLoss.Text = s.ToString("#,##0.00") + " %";

            this.SS_UnknownElapsedTime.Text = Settings.FormatSeconds(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_LongOtherETime + ReturnElapsedTime(Cause.OtherLong, CurrentSelection.LoomIndex));
            s = ((Program.ss.Machines.Looms[CurrentSelection.LoomIndex].ShiftParams.Shift_LongOtherETime + ReturnElapsedTime(Cause.OtherLong, CurrentSelection.LoomIndex)) / DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalSeconds) * 100;
            this.SS_UnknownLoss.Text = s.ToString("#,##0.00") + " %";
        }

     
    }
}