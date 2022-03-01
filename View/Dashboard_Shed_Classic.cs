using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
namespace MachineEyes
{
    public partial class Dashboard_Shed_Classic : DevExpress.XtraEditors.XtraForm
    {
        
        DateTime LastLongStoppedCheck;
        int ShedIndex;
        public Dashboard_Shed_Classic()
        {
            InitializeComponent();
        
            this.popupMenu1.Ribbon = Program.MainWindow.ribbonControl1;
            this.popupMenu1.AddItem(Program.MainWindow.ClassicalCheck_Efficiency);
            this.popupMenu1.AddItem(Program.MainWindow.ClassicalCheck_RPMView);
            this.popupMenu1.AddItem(Program.MainWindow.ClassicalCheck_WarpView);
            this.popupMenu1.AddItem(Program.MainWindow.ClassicalCheck_WarpKnottView);
            this.popupMenu1.AddItem(Program.MainWindow.ClassicalCheck_WeftView);
            this.popupMenu1.AddItem(Program.MainWindow.ClassicalCheck_WeftKnottView);
            
        }
        private void LoadSymbolColors()
        {
            this.Symbol_Article.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.ArticleChange);
            this.Symbol_Article.BackColor = Settings.Get_StopCauseColor_backColor(Cause.ArticleChange);
            this.Symbol_Article.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.ArticleChange);
            this.Loss_Article.BackColor = Settings.Get_StopCauseColor_backColor(Cause.ArticleChange);
            this.Loss_Article.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.ArticleChange);

            this.Symbol_Electrical.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Electrical);
            this.Symbol_Electrical.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Electrical);
            this.Symbol_Electrical.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.Electrical);

            this.Loss_Electrical.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Electrical);
            this.Loss_Electrical.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Electrical);

            this.Symbol_Knotting.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Knotting);
            this.Symbol_Knotting.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Knotting);
            this.Symbol_Knotting.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.Knotting);
            this.Loss_Knotting.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Knotting);
            this.Loss_Knotting.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Knotting);

            //this.Symbol_Leno.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Leno);
            //this.Symbol_Leno.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Leno);
            //this.Symbol_Leno.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.Leno);
           
            this.Symbol_Mechanical.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Mechanical);
            this.Symbol_Mechanical.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Mechanical);
            this.Symbol_Mechanical.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.Mechanical);

            this.Loss_Mechanical.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Mechanical);
            this.Loss_Mechanical.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Mechanical);

            this.Symbol_Other.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Other);
            this.Symbol_Other.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Other);
            this.Symbol_Other.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.Other);

            this.Loss_Other.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Other);
            this.Loss_Other.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Other);

            this.Symbol_OtherLong.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.OtherLong);
            this.Symbol_OtherLong.BackColor = Settings.Get_StopCauseColor_backColor(Cause.OtherLong);
            this.Symbol_OtherLong.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.OtherLong);
            this.Loss_OtherLong.BackColor = Settings.Get_StopCauseColor_backColor(Cause.OtherLong);
            this.Loss_OtherLong.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.OtherLong);
            //this.Symbol_Pile.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Pile);
            //this.Symbol_Pile.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Pile);
            //this.Symbol_Pile.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.Pile);

            this.Symbol_PowerOff.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.PowerOff);
            this.Symbol_PowerOff.BackColor = Settings.Get_StopCauseColor_backColor(Cause.PowerOff);
            this.Symbol_PowerOff.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.PowerOff);
            this.Loss_PowerOff.BackColor = Settings.Get_StopCauseColor_backColor(Cause.PowerOff);
            this.Loss_PowerOff.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.PowerOff);
            //this.Symbol_Unknown.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Unknown);
            //this.Symbol_Unknown.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Unknown);
            //this.Symbol_Unknown.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.Unknown);

            this.Symbol_Warp.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Warp);
            this.Symbol_Warp.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Warp);
            this.Symbol_Warp.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.Warp);
            this.Loss_Warp.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Warp);
            this.Loss_Warp.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Warp);
            this.Symbol_Weft.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Weft);
            this.Symbol_Weft.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Weft);
            this.Symbol_Weft.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.Weft);
            this.Loss_Weft.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Weft);
            this.Loss_Weft.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Weft);
        }
        private void Dashboard_Shed_Classic_Load(object sender, EventArgs e)
        {
            LastLongStoppedCheck = DateTime.Now;
            ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.Tag.ToString());
           
            for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
            {

                if (Program.ss.Machines.Looms[x].PersonalInfo.ShedID.ToString() == this.Tag.ToString())
                {
                    dxLoomX uc = new dxLoomX();

                    uc.LoomNumber.Text = Program.ss.Machines.Looms[x].PersonalInfo.LoomName;
                    uc.LoomNumber.Tag = Program.ss.Machines.Looms[x].PersonalInfo.LoomID;
                    uc.Efficiency.Tag = "0.0";
                    uc.Left = Convert.ToInt32(Program.ss.Machines.Looms[x].Drawing.x);
                    uc.Top = Convert.ToInt32(Program.ss.Machines.Looms[x].Drawing.y);
                    ControlMover.Init(uc);
                    this.Shed.Controls.Add(uc);
                   
                }
          
                


            }

            LoadSymbolColors();

            this.TargetEfficiency.EditValue = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TargetEff.ToString();
            this.TargetRPM.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TargetRPM.ToString();
            this.TargetWarpLoss.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TargetWarpLoss.ToString();
            this.TargetWeftLoss.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TargetWeftLoss.ToString();
            this.TargertRunningEff.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TargetRunningEff.ToString();
            try
            {
                Program.MainWindow.bar_Shift.Caption = "Shift: " + Program.ss.Machines.PresentationData.CurrentShift.WShift;
                //Authentication.CurrentShift = Authentication.svc.Get_CurrentShift();
                //Program.MainWindow.timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error executing fuctions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
       
        private void timer_AutoRefresh_Tick(object sender, EventArgs e)
        {
           
            #region Looms
            this.TotalLooms.Text = this.Shed.Controls.Count.ToString();
          

            if (Settings.CurrentClassicalView == ClassicalViewType.EfficiencyView)
                this.ViewLabel.Text = "Efficiency View";
            else if (Settings.CurrentClassicalView == ClassicalViewType.RPMView)
                this.ViewLabel.Text = "RPM View";
            else if (Settings.CurrentClassicalView == ClassicalViewType.WarpCounterView)
                this.ViewLabel.Text = "Warp Counter View";
            else if (Settings.CurrentClassicalView == ClassicalViewType.WarpKnottView)
                this.ViewLabel.Text = "Warp Avg Knot. View";
            else if (Settings.CurrentClassicalView == ClassicalViewType.WeftCounterView)
                this.ViewLabel.Text = "Weft Counter View";
            else if (Settings.CurrentClassicalView == ClassicalViewType.WeftKnottView)
                this.ViewLabel.Text = "Weft Avg Knot. View";
           
            try
            {
                for (int x = 0; x < this.Shed.Controls.Count; x++)
                {
                    Control uictr = this.Shed.Controls[x];
                  
                    if (uictr is dxLoomX)
                    {
                        dxLoomX uiLoom = (dxLoomX)uictr;
                        try
                        {
                            Program.ss.SetMachineDisplayX(ref Program.ss.Machines.Looms[Convert.ToInt32(uiLoom.LoomNumber.Tag)], ref uiLoom);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {
            }
            #endregion
           
          
            this.ShedEfficiency.Text = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff.ToString("#,##0.0");
            this.RunningEfficiency.Text  = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.RunningEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.RunningEff.ToString("#,##0.0");
            try
            {
                double achieved = ((double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff) == true ? 0 : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff) /Program.ss.Machines.PresentationData.Sheds[ShedIndex].TargetEff) * 100;
                this.TargetAchieved.Text = achieved.ToString("#,##0.0");
            }
            catch
            {
                this.TargetAchieved.Text = "Err";
            }
          

                this.AverageRPM.Text  = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.RPM) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.RPM.ToString("#,##");

           
               
               double s;
               TimeSpan shiftElapsedTime = DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate);
               this.ShiftElapsedTime.Text = Program.ss.Get_FormattedTime(shiftElapsedTime, 1);
               this.CurrentTime.Text = DateTime.Now.ToLongDateString() + " " +  DateTime.Now.ToLongTimeString();
               this.shiftStartTime.Text = Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate.ToLongDateString() + " " + Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate.ToShortTimeString();
   
               double Defficiency = 100 - Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff;
               if (Defficiency < 0) Defficiency = 0;
               
               s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sOtherElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100)*Defficiency/100;
               this.Loss_Other.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWarpElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100)*Defficiency/100;
                this.Loss_Warp.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
              s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWeftElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
              this.Loss_Weft.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
              s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lElectricalElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100)*Defficiency/100;
              this.Loss_Electrical.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
              s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lKnottingElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100)*Defficiency/100;
              this.Loss_Knotting.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
              s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lMechanicalElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100)*Defficiency/100;
              this.Loss_Mechanical.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
              s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lOtherElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100)*Defficiency/100;
              this.Loss_OtherLong.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
             s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lArticleElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100)*Defficiency/100;
             this.Loss_Article.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
             s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lPowerOffElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100)*Defficiency/100;
             this.Loss_PowerOff.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
             this.Counter_Warp.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWarpTotalBreakages.ToString();
             this.Counter_Weft.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWeftTotalBreakages.ToString();
             this.Counter_Other.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sOtherTotalBreakages.ToString();

            this.Stopped_Article.Text  = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.ArticleChange.Length.ToString();
            this.Stopped_Electrical.Text  = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Electrical.Length.ToString();
            this.Stopped_Knotting.Text  = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Knotting.Length.ToString();
            this.Stopped_Mechanical.Text  = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Mechanical.Length.ToString();
            this.Stopped_PowerOff.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.PowerOff.Length.ToString();
            this.Stopped_OtherLong.Text = (Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Others.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.BeamShort.Length).ToString();
            this.Total_LongStopped.Text = Convert.ToString(Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.ArticleChange.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Electrical.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Knotting.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Mechanical.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Others.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.PowerOff.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.BeamShort.Length);
            //#endregion
            //#region ShortStops
             this.Stopped_Other.Text  = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Others.Length.ToString();
             this.Stopped_Warp.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Warp.Length.ToString();
             this.Stopped_Weft.Text  = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Weft.Length.ToString();
             this.Total_ShortStopped.Text = Convert.ToString(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Others.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Warp.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Weft.Length);

             int longstopped = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.ArticleChange.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Electrical.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Knotting.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Mechanical.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Others.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.PowerOff.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.BeamShort.Length;
             int shortstopped = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Others.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Warp.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Weft.Length;
             int TotalLooms = this.Shed.Controls.Count;
             this.TotalLooms.Text = TotalLooms.ToString();
             this.RunningLooms.Text = Convert.ToString(TotalLooms - longstopped - shortstopped);

        }

        private void Dashboard_Shed_Classic_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Exit == false) { e.Cancel = true; this.Hide(); }
        }

        private void Dashboard_Shed_Classic_Enter(object sender, EventArgs e)
        {
            CurrentSelection.SelectedView = this;
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Shed_Classic_Activated(object sender, EventArgs e)
        {

        }

        private void TargetEfficiency_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TargetEfficiency_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                try
                {
                    DialogResult dg = XtraMessageBox.Show("Are you sure to change target efficiency?", "Change Target", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg != DialogResult.Yes) return;
                    string s = WS.svc.Execute_Query("update MT_Sheds set TargetEff='" + this.TargetEfficiency.EditValue.ToString() + "' where ShedID="+Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID+"");
                    if (s.Contains("**SUCCESS##") == false)
                    {
                        XtraMessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        double.TryParse(this.TargetEfficiency.EditValue.ToString(), out Program.ss.Machines.PresentationData.Sheds[ShedIndex].TargetEff);
                        XtraMessageBox.Show("Target has been changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void Shed_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Settings.CurrentClassicalView == ClassicalViewType.EfficiencyView)
                {
                    Program.MainWindow.ClassicalCheck_Efficiency.Checked = true;
                   
                    
                }
                else if (Settings.CurrentClassicalView == ClassicalViewType.RPMView)
                    Program.MainWindow.ClassicalCheck_RPMView.Checked = true;
                else if (Settings.CurrentClassicalView == ClassicalViewType.WarpCounterView)
                    Program.MainWindow.ClassicalCheck_WarpView.Checked = true;
                else if (Settings.CurrentClassicalView == ClassicalViewType.WarpKnottView)
                    Program.MainWindow.ClassicalCheck_WarpKnottView.Checked = true;
                else if (Settings.CurrentClassicalView == ClassicalViewType.WeftKnottView)
                    Program.MainWindow.ClassicalCheck_WeftKnottView.Checked = true;
                else if (Settings.CurrentClassicalView == ClassicalViewType.WeftCounterView)
                    Program.MainWindow.ClassicalCheck_WeftView.Checked = true;
                this.popupMenu1.MenuCaption = "Current View: " + this.ViewLabel.Text;

                this.popupMenu1.ShowPopup(MousePosition);
                

            }
        }

        private void TargetWarpLoss_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                try
                {
                    DialogResult dg = XtraMessageBox.Show("Are you sure to change target Warp Loss Percentage?", "Change Target", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg != DialogResult.Yes) return;
                    string s = WS.svc.Execute_Query("update MT_Sheds set TargetWarpLoss='" + this.TargetWarpLoss.EditValue.ToString() + "' where ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + "");
                    if (s.Contains("**SUCCESS##") == false)
                    {
                        XtraMessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        double.TryParse(this.TargetWarpLoss.EditValue.ToString(), out Program.ss.Machines.PresentationData.Sheds[ShedIndex].TargetWarpLoss);
                        XtraMessageBox.Show("Target has been changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void TargetWeftLoss_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                try
                {
                    DialogResult dg = XtraMessageBox.Show("Are you sure to change target Weft Loss Percentage?", "Change Target", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg != DialogResult.Yes) return;
                    string s = WS.svc.Execute_Query("update MT_Sheds set TargetWeftLoss='" + this.TargetWeftLoss.EditValue.ToString() + "' where ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + "");
                    if (s.Contains("**SUCCESS##") == false)
                    {
                        XtraMessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        double.TryParse(this.TargetWeftLoss.EditValue.ToString(), out Program.ss.Machines.PresentationData.Sheds[ShedIndex].TargetWeftLoss);
                        XtraMessageBox.Show("Target has been changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void TargertRunningEff_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                try
                {
                    DialogResult dg = XtraMessageBox.Show("Are you sure to change target Running Efficiency Percentage?", "Change Target", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg != DialogResult.Yes) return;
                    string s = WS.svc.Execute_Query("update MT_Sheds set TargetRunningEff='" + this.TargertRunningEff.EditValue.ToString() + "' where ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + "");
                    if (s.Contains("**SUCCESS##") == false)
                    {
                        XtraMessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        double.TryParse(this.TargertRunningEff.EditValue.ToString(), out Program.ss.Machines.PresentationData.Sheds[ShedIndex].TargetRunningEff);
                        XtraMessageBox.Show("Target has been changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void TargetRPM_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                try
                {
                    DialogResult dg = XtraMessageBox.Show("Are you sure to change target RPM?", "Change Target", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg != DialogResult.Yes) return;
                    string s = WS.svc.Execute_Query("update MT_Sheds set TargetRPM='" + this.TargetRPM.EditValue.ToString() + "' where ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + "");
                    if (s.Contains("**SUCCESS##") == false)
                    {
                        XtraMessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        double.TryParse(this.TargetRPM.EditValue.ToString(), out Program.ss.Machines.PresentationData.Sheds[ShedIndex].TargetRPM);
                        XtraMessageBox.Show("Target has been changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}