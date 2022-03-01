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
    public partial class DashBoard_Shed_MakeView : DevExpress.XtraEditors.XtraForm
    {
        public int ShedIndex;
        public int MakeIndex;
        public DashBoard_Shed_MakeView()
        {
            InitializeComponent();
        }

        private void DashBoard_Shed_MakeView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Exit == false) { e.Cancel = true; this.Hide(); }
        }

        private void timer_AutoRefresh_Tick(object sender, EventArgs e)
        {
            long TotalWarps = 0; int TotalWefts = 0;
            #region Looms
            for (int x = 0; x < this.panelControl1.Controls.Count; x++)
            {
                Control uictr = this.panelControl1.Controls[x];
                if (uictr is dxLoomY)
                {
                    dxLoomY uiLoom = (dxLoomY)uictr;

                    Program.ss.SetMachineDisplayY(ref Program.ss.Machines.Looms[Convert.ToInt32(uiLoom.LoomNumber.Tag)], ref uiLoom);
                    TotalWarps += Program.ss.Machines.Looms[Convert.ToInt32(uiLoom.LoomNumber.Tag)].ShiftParams.Shift_Warps;
                    TotalWefts += Program.ss.Machines.Looms[Convert.ToInt32(uiLoom.LoomNumber.Tag)].ShiftParams.Shift_Wefts;

                }
            }

            dxMMSBottom1.Val_TotalWarpBrekages.Text = TotalWarps.ToString("#,##");
            dxMMSBottom1.Val_TotalWeftBreakages.Text = TotalWefts.ToString("#,##");
            if(this.panelControl1.Controls.Count>0)
            {
             double s= Convert.ToDouble(TotalWarps / this.panelControl1.Controls.Count);
             dxMMSBottom1.Val_AvgWarpBreakages.Text = s.ToString("#,##0.0");
             s = Convert.ToDouble(TotalWefts / this.panelControl1.Controls.Count);
             dxMMSBottom1.Val_AvgWeftBreakages.Text = s.ToString("#,##0.0");
            }
            #endregion
          
            
        

            #region TypesUpdate
          
               
                    try
                    {
                      
                    if(Convert.ToDouble(dxMMSBottom1.Val_Efficiency.Tag.ToString())!=Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[MakeIndex].Eff)
                    {
                        dxMMSBottom1.Val_Efficiency.Tag =Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[MakeIndex].Eff.ToString();
                        dxMMSBottom1.Val_Efficiency.Text =Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[MakeIndex].Eff.ToString("#,##0.0");
                       
                    }
                    if (Convert.ToDouble(dxMMSBottom1.Val_RunningEfficiency.Tag.ToString()) != Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[MakeIndex].RunningEff)
                    {
                        dxMMSBottom1.Val_RunningEfficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[MakeIndex].RunningEff.ToString();
                        dxMMSBottom1.Val_RunningEfficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[MakeIndex].RunningEff.ToString("#,##0.0");

                    }
                    if(Convert.ToDouble(dxMMSBottom1.Val_RPM.Tag)!=Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[MakeIndex].RPM)
                    {
                         dxMMSBottom1.Val_RPM.Tag  =Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[MakeIndex].RPM.ToString();
                        dxMMSBottom1.Val_RPM.Text =Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[MakeIndex].RPM.ToString("#,##0.0");
                    }
                       
                    }
                    catch
                    {
                    }
                
               
            
            #endregion

                    var StoppedMachines = from i in Program.ss.Machines.Looms where i.CurrentParams.Current_State != (int)State.Running && i.PersonalInfo.ShedID.ToString() == Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID && i.PersonalInfo.TypeID.ToString() ==Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[MakeIndex].TypeID 
                                          orderby i.PersonalInfo.LoomID ascending
                                          select i;

                    int Warp=0, Weft=0, Other=0, Mechanical=0, Electrical=0, Knotting=0, Article=0, OtherLong=0;
          
                    foreach (var sMachines in StoppedMachines)
                    {


                        MachineService.Loom sloom = (MachineService.Loom)sMachines;

                        switch ((Cause)sloom.CurrentParams.Current_Cause)
                        {
                            case Cause.Unknown:
                                Other++;
                                break;
                            case Cause.Warp:
                                Warp++;
                               
                                break;
                            case Cause.Weft:
                                Weft++;
                               
                                break;
                            case Cause.Leno:
                                Other++;
                           
                                break;
                            case Cause.Other:
                                Other++;
                              
                                break;
                            case Cause.Pile:
                                Other++;
                              
                                break;
                            case Cause.Mechanical:
                                Mechanical++;
                                
                                break;
                            case Cause.Electrical:
                                Electrical++;
                                
                                break;
                            case Cause.Knotting:
                                Knotting++;
                                
                                break;
                            case Cause.ArticleChange:
                                Article++;
                               
                                break;
                            case Cause.OtherLong:
                                OtherLong++;
                               
                                break;
                            default:
                                break;
                        }
                       
                    }
                    dxMMSBottom1.Val_Electrical.Text = Electrical.ToString();
                    dxMMSBottom1.Val_Articles.Text = Article.ToString();
                    dxMMSBottom1.Val_Knottings.Text = Knotting.ToString();
                    dxMMSBottom1.Val_Mechanical.Text = Mechanical.ToString();
                    dxMMSBottom1.Val_OtherLong.Text = OtherLong.ToString();
                    dxMMSBottom1.Val_Others.Text = Other.ToString();
                    dxMMSBottom1.Val_Warps.Text = Warp.ToString();
                    dxMMSBottom1.Val_Wefts.Text = Weft.ToString();


                    var BotthreeLooms = (from i in Program.ss.Machines.Looms
                                         where i.PersonalInfo.ShedID.ToString() == Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID && i.PersonalInfo.TypeID.ToString() == Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[MakeIndex].TypeID 
                                         orderby i.CurrentParams.Current_Eff ascending
                                         select i).Take(3);
                    int loomx = 0;
                    foreach (var sMachines in BotthreeLooms)
                    {

                        if (dxMMSBottom1.tlp_Poor3.Controls.Count > 0)
                        {
                            MachineService.Loom sloom = (MachineService.Loom)sMachines;
                            dxLoomY uiLoom = (dxLoomY)dxMMSBottom1.tlp_Poor3.Controls[loomx++];
                            uiLoom.Tag = sloom.PersonalInfo.LoomID;
                            uiLoom.LoomNumber.Text = sloom.PersonalInfo.LoomName;
                            uiLoom.LoomNumber.Tag = sloom.PersonalInfo.LoomID;
                            Program.ss.SetMachineDisplayY(ref Program.ss.Machines.Looms[Convert.ToInt32(uiLoom.LoomNumber.Tag)], ref uiLoom);
                        }
                    }
    
        }

        private void DashBoard_Shed_MakeView_Load(object sender, EventArgs e)
        {
           
            int LoomIndex;
           
           
            
          
            for (int x = 0; x < Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[MakeIndex].LoomIndexes.Length; x++)
            {
                dxLoomY uc = new dxLoomY();
                LoomIndex = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[MakeIndex].LoomIndexes[x];
                uc.LoomNumber.Text = Program.ss.Machines.Looms[LoomIndex].PersonalInfo.LoomName;
                uc.LoomNumber.Tag = Program.ss.Machines.Looms[LoomIndex].PersonalInfo.LoomID;
                uc.Efficiency.Tag = "0.0";
                uc.Left = Convert.ToInt32(Program.ss.Machines.Looms[LoomIndex].Drawing.DrawMakeX);
                uc.Top = Convert.ToInt32(Program.ss.Machines.Looms[LoomIndex].Drawing.DrawMakeY);
                ControlMover.Init(uc);
                this.panelControl1.Controls.Add(uc);
            }
            for (int x = 0; x < 3; x++)
            {
                dxLoomY uc = new dxLoomY();
                dxMMSBottom1.tlp_Poor3.Controls.Add(uc);
            }
           
       }

        private void DashBoard_Shed_MakeView_Enter(object sender, EventArgs e)
        {
            CurrentSelection.SelectedView = this;
        }
    }
}
