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
    public partial class Dashboard_Shed : DevExpress.XtraEditors.XtraForm
    {
        int ShedIndex;
        
        public Dashboard_Shed()
        {
            InitializeComponent();
        }

        private void dxShedView_Load(object sender, EventArgs e)
        {

            ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.Tag.ToString());
            Settings.DataWaitingSeconds = 300;
            if (dxShed1.ShedEfficiency.Tag == null) dxShed1.ShedEfficiency.Tag = "0";
            if (dxShed1.RPM_Val.Tag == null) dxShed1.RPM_Val.Tag = "0";
            dxShed1.RunningEff.Tag = "0";

          
            for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
            {
                if (Program.ss.Machines.Looms[x].PersonalInfo.ShedID == Convert.ToInt16(this.Tag.ToString()))
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

            try
            {
                this.navBarGroup_Mechanical.SmallImage = CauseImages.Images["Mechanical"];
                this.navBarGroup_Article.SmallImage = CauseImages.Images["Article"];
                this.navBarGroup_Electrical.SmallImage = CauseImages.Images["Electrical"];
                this.navBarGroup_Knotting.SmallImage = CauseImages.Images["Knotting"];
                this.navBarGroup_LongStop_5.SmallImage = CauseImages.Images["LongStop_5"];
                this.navBarGroup_LongStop_6.SmallImage = CauseImages.Images["LongStop_6"];
                this.navBarGroup_LongStop_7.SmallImage = CauseImages.Images["LongStop_7"];
                this.navBarGroup_LongStop_8.SmallImage = CauseImages.Images["LongStop_8"];
                this.navBarGroup_LongStop_9.SmallImage = CauseImages.Images["LongStop_9"];
                this.navBarGroup_Other.SmallImage = CauseImages.Images["OtherLong"];
                this.navBarGroup_PowerOff.SmallImage = CauseImages.Images["PowerOff"];
                











            }
            catch
            {
            }
            //try
            //{
            //    DataSet DSRunningPercent = WS.svc.Get_DataSet("Select * from MT_Sheds where ShedID=" + ShedIndex.ToString() + "");
            //    if (DSRunningPercent != null)
            //    {
            //        if (DSRunningPercent.Tables[0].Rows[0]["PercentRunningDisplay"].ToString() == "1")
            //        {
            //            this.panelControl1.Controls.Add(percentRunning);
            //            int pX = 0;
            //            int.TryParse(DSRunningPercent.Tables[0].Rows[0]["PercentRunningX"].ToString(), out pX);
            //            int pY = 0;
            //            int.TryParse(DSRunningPercent.Tables[0].Rows[0]["PercentRunningY"].ToString(), out pY);
            //            percentRunning.Left = pX;
            //            percentRunning.Top = pY;
            //            percentRunning.Tag = ShedIndex.ToString();
            //        }
            //    }
            //}
            //catch
            //{
            //}

            DataSet DSLoomsLayout = WS.svc.Get_DataSet("Select * from MT_ShedsLoomsLayout_Employees where EmployeeID='" + MachineEyes.Classes.Security.User.UserID + "' and ShedID=" + ShedIndex.ToString() + "");
            DataSet DSShedLayout = WS.svc.Get_DataSet("Select * from MT_ShedsLayout_Employees where EmployeeID='" + MachineEyes.Classes.Security.User.UserID + "' and ShedID=" + ShedIndex.ToString() + "");

            if (DSShedLayout != null && DSLoomsLayout!=null)
            {


                if (DSLoomsLayout != null)
                {
                    if (DSLoomsLayout.Tables[0].Rows.Count > 0)
                    {

                        for (int x = 0; x < DSLoomsLayout.Tables[0].Rows.Count; x++)
                        {
                            int Loom_X = 0, Loom_Y = 0; int LoomID = -1;



                            int.TryParse(DSLoomsLayout.Tables[0].Rows[0]["Loom_X"].ToString(), out Loom_X);
                            int.TryParse(DSLoomsLayout.Tables[0].Rows[0]["Loom_Y"].ToString(), out Loom_Y);
                            int.TryParse(DSLoomsLayout.Tables[0].Rows[0]["LoomID"].ToString(), out LoomID);
                            Program.ss.Machines.Looms[Program.ss.ReturnArrayLoomIndex(LoomID.ToString())].Drawing.x = Loom_X;
                            Program.ss.Machines.Looms[Program.ss.ReturnArrayLoomIndex(LoomID.ToString())].Drawing.y = Loom_Y;
                            dxLoom dxL = ReturnControl(LoomID.ToString());
                            if (dxL != null)
                            {
                                dxL.Left = Loom_X;
                                dxL.Top = Loom_Y;
                            }






                        }
                    }
                }

                if (DSShedLayout.Tables[0].Rows.Count > 0 & DSLoomsLayout.Tables[0].Rows.Count>0)
                {

                    int Loom_H = 0, Loom_W = 0; 
                   

                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["H_Loom"].ToString(),out Loom_H);
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["W_Loom"].ToString(),out Loom_W);

                    int Efficiency_H = 0, Efficiency_W = 0, Efficiency_X = 0, Efficiency_Y = 0;
                    float Efficiency_S = 12; string Efficiency_F = "Tahoma";
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["H_Efficiency"].ToString(), out Efficiency_H);
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["W_Efficiency"].ToString(), out Efficiency_W);
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["X_Efficiency"].ToString(), out Efficiency_X);
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["Y_Efficiency"].ToString(), out Efficiency_Y);
                    float.TryParse(DSShedLayout.Tables[0].Rows[0]["S_Efficiency"].ToString(), out Efficiency_S);
                    Efficiency_F = DSShedLayout.Tables[0].Rows[0]["F_Efficiency"].ToString();


                    int RPM_H = 0, RPM_W = 0, RPM_X = 0, RPM_Y = 0;
                    float RPM_S = 12; string RPM_F = "Tahoma";
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["H_RPM"].ToString(), out RPM_H);
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["W_RPM"].ToString(), out RPM_W);
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["X_RPM"].ToString(), out RPM_X);
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["Y_RPM"].ToString(), out RPM_Y);
                    float.TryParse(DSShedLayout.Tables[0].Rows[0]["S_RPM"].ToString(), out RPM_S);
                    RPM_F = DSShedLayout.Tables[0].Rows[0]["F_RPM"].ToString();

                    int TimeElapsed_H = 0, TimeElapsed_W = 0, TimeElapsed_X = 0, TimeElapsed_Y = 0;
                    float TimeElapsed_S = 12; string TimeElapsed_F = "Tahoma";
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["H_ElapsedTime"].ToString(), out TimeElapsed_H);
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["W_ElapsedTime"].ToString(), out TimeElapsed_W);
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["X_ElapsedTime"].ToString(), out TimeElapsed_X);
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["Y_ElapsedTime"].ToString(), out TimeElapsed_Y);
                    float.TryParse(DSShedLayout.Tables[0].Rows[0]["S_ElapsedTime"].ToString(), out TimeElapsed_S);
                    TimeElapsed_F = DSShedLayout.Tables[0].Rows[0]["F_ElapsedTime"].ToString();

                    int LoomNumber_H = 0, LoomNumber_W = 0, LoomNumber_X = 0, LoomNumber_Y = 0;
                    float LoomNumber_S = 12; string LoomNumber_F = "Tahoma";
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["H_LoomNumber"].ToString(), out LoomNumber_H);
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["W_LoomNumber"].ToString(), out LoomNumber_W);
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["X_LoomNumber"].ToString(), out LoomNumber_X);
                    int.TryParse(DSShedLayout.Tables[0].Rows[0]["Y_LoomNumber"].ToString(), out LoomNumber_Y);
                    float.TryParse(DSShedLayout.Tables[0].Rows[0]["S_LoomNumber"].ToString(), out LoomNumber_S);
                    LoomNumber_F = DSShedLayout.Tables[0].Rows[0]["F_LoomNumber"].ToString();
                    for (int x = 0; x < this.panelControl1.Controls.Count; x++)
                    {
                        if (Program.ss.Machines.Looms[x].PersonalInfo.ShedID == Convert.ToInt16(this.Tag.ToString()))
                        {

                            dxLoom uc = (dxLoom)this.panelControl1.Controls[x];
                            int LoomID = -1; int.TryParse(uc.LoomNumber.Tag.ToString(), out LoomID);

                            Program.ss.Machines.Looms[Program.ss.ReturnArrayLoomIndex(LoomID.ToString())].Drawing.Height = Loom_H;
                            Program.ss.Machines.Looms[Program.ss.ReturnArrayLoomIndex(LoomID.ToString())].Drawing.Width = Loom_W;
                            uc.Height = Loom_H;
                            uc.Width = Loom_W;
                            uc.Efficiency.Left = Efficiency_X;
                            uc.Efficiency.Top = Efficiency_Y;
                            uc.Efficiency.Height = Efficiency_H;
                            uc.Efficiency.Width = Efficiency_W;
                            uc.Efficiency.Font = new Font(Efficiency_F, Efficiency_S);

                            uc.LoomNumber.Left = LoomNumber_X;
                            uc.LoomNumber.Top = LoomNumber_Y;
                            uc.LoomNumber.Height = LoomNumber_H;
                            uc.LoomNumber.Width = LoomNumber_W;
                            uc.LoomNumber.Font = new Font(LoomNumber_F, LoomNumber_S);

                            uc.ElapsedTime.Left = TimeElapsed_X;
                            uc.ElapsedTime.Top = TimeElapsed_Y;
                            uc.ElapsedTime.Height = TimeElapsed_H;
                            uc.ElapsedTime.Width = TimeElapsed_W;
                            uc.ElapsedTime.Font = new Font(TimeElapsed_F, TimeElapsed_S);

                            uc.RPM.Left = RPM_X;
                            uc.RPM.Top = RPM_Y;
                            uc.RPM.Height = RPM_H;
                            uc.RPM.Width = RPM_W;
                            uc.RPM.Font = new Font(RPM_F, RPM_S);
                           // uc.Left = Convert.ToInt32(Program.ss.Machines.Looms[Program.ss.ReturnArrayLoomIndex(LoomID.ToString())].Drawing.x);
                           // uc.Top = Convert.ToInt32(Program.ss.Machines.Looms[Program.ss.ReturnArrayLoomIndex(LoomID.ToString())].Drawing.y);
                          

                        }



                    }
                }
            }





           


            for (int x = 0; x < Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms.Length; x++)
            {
                dxTypeEff LoomType = new dxTypeEff();

                
                LoomType.Model.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[x].TypeName;
                LoomType.Model.Tag = x.ToString();
                LoomType.RunningEfficiency.Text = "0.0";
                LoomType.RunningEfficiency.Tag = "0.0";
                LoomType.ShedEfficiency.Text = "0.0";
                LoomType.RPM.Text = "0";
                LoomType.RPM.Tag = "0";
                LoomType.TotalMachines.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[x].LoomIndexes.Length.ToString();
                this.dxShed1.tableLayoutPanel_Types.Controls.Add(LoomType);
            }

            for (int x = 0; x < Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections.Length; x++)
            {
                UserControls.dxSection sType = new UserControls.dxSection();

                sType.Section.Tag = x.ToString();
                sType.Section.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[x].SectionName;
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
        private void CheckLongStoppedMachines(Cause MachineCause,TableLayoutPanel CurrentPanel)
        {
            var StoppedMachines = from i in Program.ss.Machines.Looms
                                      where i.CurrentParams.Current_Cause==(int)MachineCause && i.CurrentParams.Current_State != (int)State.Running && i.PersonalInfo.ShedID.ToString() == Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID
                                      orderby i.PersonalInfo.LoomID ascending
                                      select i;
            if (MachineCause == Cause.Mechanical)
            {
                this.navBarGroup_Mechanical.Caption = "Mechanical : " + StoppedMachines.Count().ToString();
                if (StoppedMachines.Count() > 0)
                {
                    this.navBarGroup_Mechanical.Expanded = true;
                    this.navBarGroup_Mechanical.Visible = true;
                    this.navBarGroup_Mechanical.Appearance.ForeColor = Color.Red;
                }
                else
                {
                    this.navBarGroup_Mechanical.Expanded = false;
                    this.navBarGroup_Mechanical.Appearance.ForeColor = Color.Black;
                    this.navBarGroup_Mechanical.Visible = false;
                }
            }
            else if (MachineCause == Cause.Electrical)
            {
                this.navBarGroup_Electrical.Caption = "Electrical : " + StoppedMachines.Count().ToString();
                if (StoppedMachines.Count() > 0)
                {
                    this.navBarGroup_Electrical.Visible = true;
                    this.navBarGroup_Electrical.Expanded = true;
                    this.navBarGroup_Electrical.Appearance.ForeColor = Color.Red;
                }
                else
                {
                    this.navBarGroup_Electrical.Expanded = false;
                    this.navBarGroup_Electrical.Appearance.ForeColor = Color.Black;
                    this.navBarGroup_Electrical.Visible = false;
                }
            }
            else if (MachineCause == Cause.ArticleChange)
            {
                this.navBarGroup_Article.Caption = "Article : " + StoppedMachines.Count().ToString();
                if (StoppedMachines.Count() > 0)
                {
                    this.navBarGroup_Article.Expanded = true;
                    this.navBarGroup_Article.Visible = true;
                    this.navBarGroup_Article.Appearance.ForeColor = Color.Red;
                }
                else
                {
                    this.navBarGroup_Article.Expanded = false;
                    this.navBarGroup_Article.Appearance.ForeColor = Color.Black;
                    this.navBarGroup_Article.Visible = false;
                }
            }
            else if (MachineCause == Cause.Knotting)
            {
                this.navBarGroup_Knotting.Caption = "Knotting : " + StoppedMachines.Count().ToString();
                if (StoppedMachines.Count() > 0)
                {
                    this.navBarGroup_Knotting.Expanded = true;
                    this.navBarGroup_Knotting.Appearance.ForeColor = Color.Red;
                    this.navBarGroup_Knotting.Visible = true;
                }
                else
                {
                    this.navBarGroup_Knotting.Expanded = false;
                    this.navBarGroup_Knotting.Appearance.ForeColor = Color.Black;
                    this.navBarGroup_Knotting.Visible = false;
                }
            }
            else if (MachineCause == Cause.OtherLong)
            {
                this.navBarGroup_Other.Caption = "Other : " + StoppedMachines.Count().ToString();
                if (StoppedMachines.Count() > 0)
                {
                    this.navBarGroup_Other.Expanded = true;
                    this.navBarGroup_Other.Appearance.ForeColor = Color.Red;
                    this.navBarGroup_Other.Visible = true;
                }
                else
                {
                    this.navBarGroup_Other.Expanded = false;
                    this.navBarGroup_Other.Appearance.ForeColor = Color.Black;
                    this.navBarGroup_Other.Visible = false;
                }
            }
            else if (MachineCause == Cause.PowerOff)
            {
                this.navBarGroup_PowerOff.Caption = "PowerOff : " + StoppedMachines.Count().ToString();
                if (StoppedMachines.Count() > 0)
                {
                    this.navBarGroup_PowerOff.Expanded = true;
                    this.navBarGroup_PowerOff.Appearance.ForeColor = Color.Red;
                    this.navBarGroup_PowerOff.Visible = true;
                }
                else
                {
                    this.navBarGroup_PowerOff.Expanded = false;
                    this.navBarGroup_PowerOff.Appearance.ForeColor = Color.Black;
                    this.navBarGroup_PowerOff.Visible = false;
                }
            }
            else if (MachineCause == Cause.LongStop_5)
            {
                this.navBarGroup_LongStop_5.Caption = Settings.stopCauses[12].CauseName + " : " +   StoppedMachines.Count().ToString();
                if (StoppedMachines.Count() > 0)
                {
                    this.navBarGroup_LongStop_5.Expanded = true;
                    this.navBarGroup_LongStop_5.Appearance.ForeColor = Color.Red;
                    this.navBarGroup_LongStop_5.Visible = true;
                }
                else
                {
                    this.navBarGroup_LongStop_5.Expanded = false;
                    this.navBarGroup_LongStop_5.Appearance.ForeColor = Color.Black;
                    this.navBarGroup_LongStop_5.Visible = false;
                }
            }
            else if (MachineCause == Cause.LongStop_6)
            {
                this.navBarGroup_LongStop_6.Caption = Settings.stopCauses[13].CauseName + " : " + StoppedMachines.Count().ToString();
                if (StoppedMachines.Count() > 0)
                {
                    this.navBarGroup_LongStop_6.Expanded = true;
                    this.navBarGroup_LongStop_6.Appearance.ForeColor = Color.Red;
                    this.navBarGroup_LongStop_6.Visible = true;
                }
                else
                {
                    this.navBarGroup_LongStop_6.Expanded = false;
                    this.navBarGroup_LongStop_6.Appearance.ForeColor = Color.Black;
                    this.navBarGroup_LongStop_6.Visible = false;
                }
            }
            else if (MachineCause == Cause.LongStop_7)
            {
                this.navBarGroup_LongStop_7.Caption = Settings.stopCauses[14].CauseName + " : " + StoppedMachines.Count().ToString();
                if (StoppedMachines.Count() > 0)
                {
                    this.navBarGroup_LongStop_7.Expanded = true;
                    this.navBarGroup_LongStop_7.Appearance.ForeColor = Color.Red;
                    this.navBarGroup_LongStop_7.Visible = true;
                }
                else
                {
                    this.navBarGroup_LongStop_7.Expanded = false;
                    this.navBarGroup_LongStop_7.Appearance.ForeColor = Color.Black;
                    this.navBarGroup_LongStop_7.Visible = false;

                }
            }
            else if (MachineCause == Cause.LongStop_8)
            {
                this.navBarGroup_LongStop_8.Caption = Settings.stopCauses[15].CauseName + " : " + StoppedMachines.Count().ToString();
                if (StoppedMachines.Count() > 0)
                {
                    this.navBarGroup_LongStop_8.Expanded = true;
                    this.navBarGroup_LongStop_8.Appearance.ForeColor = Color.Red;
                    this.navBarGroup_LongStop_8.Visible = true;
                }
                else
                {
                    this.navBarGroup_LongStop_8.Expanded = false;
                    this.navBarGroup_LongStop_8.Appearance.ForeColor = Color.Black;
                    this.navBarGroup_LongStop_8.Visible = false;
                }
            }
            else if (MachineCause == Cause.LongStop_9)
            {
                this.navBarGroup_LongStop_9.Caption = Settings.stopCauses[16].CauseName + " : " + StoppedMachines.Count().ToString();
                if (StoppedMachines.Count() > 0)
                {
                    this.navBarGroup_LongStop_9.Expanded = true;
                    this.navBarGroup_LongStop_9.Appearance.ForeColor = Color.Red;
                    this.navBarGroup_LongStop_9.Visible = true;
                }
                else
                {
                    this.navBarGroup_LongStop_9.Expanded = false;
                    this.navBarGroup_LongStop_9.Appearance.ForeColor = Color.Black;
                    this.navBarGroup_LongStop_9.Visible = false;
                }
            }
            

            foreach (var sMachines in StoppedMachines)
            {
                MachineService.Loom sloom = (MachineService.Loom)sMachines;
                AddLongStoppedMachineIntoPanel(sloom,CurrentPanel);
            }
            foreach (Control ctr in CurrentPanel.Controls)
            {
                
                bool Found = false; ; UserControls.dxLongStoppedLoom loom = (UserControls.dxLongStoppedLoom)ctr;
                foreach (var sMachines in StoppedMachines)
                {
                    MachineService.Loom sloom = (MachineService.Loom)sMachines;
                    if (loom.LoomNumber.Tag != null)
                    {
                        if (Convert.ToInt32(loom.LoomNumber.Tag) == sloom.PersonalInfo.LoomID)
                        {
                            Found = true;
                            break;
                        }
                    }
                }
                if (Found == false) CurrentPanel.Controls.Remove(ctr);
                else if (Found == true) Found = false;

            }
        }
        private void AddLongStoppedMachineIntoPanel(MachineService.Loom sLoom,TableLayoutPanel CurrentPanel)
        {
            foreach (Control ctr in CurrentPanel.Controls)
            {
                UserControls.dxLongStoppedLoom loom = (UserControls.dxLongStoppedLoom)ctr;
                if(loom.LoomNumber.Tag!=null)
                if (loom.LoomNumber.Tag.ToString() == sLoom.PersonalInfo.LoomID.ToString()) return;
            }
            UserControls.dxLongStoppedLoom newLoom = new UserControls.dxLongStoppedLoom();
            newLoom.LoomNumber.Tag = sLoom.PersonalInfo.LoomID.ToString();
            newLoom.LoomNumber.Text = sLoom.PersonalInfo.LoomName;
            
            CurrentPanel.Controls.Add(newLoom);
            Program.ss.SetLongStoppedMachineDisplay(ref sLoom,ref  newLoom);

        }
        private void UpdateLongStoppedMachineDisplay(TableLayoutPanel tb)
        {
           
           
            for (int x = 0; x < tb.Controls.Count; x++)
            {
                Control uictr = tb.Controls[x];
                if (uictr is UserControls.dxLongStoppedLoom)
                {
                    
                    UserControls.dxLongStoppedLoom uiLoom = (UserControls.dxLongStoppedLoom)uictr;

                    try
                    {
                        Program.ss.SetLongStoppedMachineDisplay(ref Program.ss.Machines.Looms[Convert.ToInt32(uiLoom.LoomNumber.Tag)], ref uiLoom);
                    }
                    catch
                    {
                    }
                }
            }

        }
        private void timer_AutoRefresh_Tick(object sender, EventArgs e)
        {




            int TotalLooms = 0; 

            #region Looms
            for (int x = 0; x < this.panelControl1.Controls.Count; x++)
            {
                Control uictr = this.panelControl1.Controls[x];
                if(uictr is dxLoom)
                {
                   
                    TotalLooms++;
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
            UpdateLongStoppedMachineDisplay(this.tbArticle);
            UpdateLongStoppedMachineDisplay(this.tbElectrical);
            UpdateLongStoppedMachineDisplay(this.tbKnotting);
            UpdateLongStoppedMachineDisplay(this.tbLongStop_5);
            UpdateLongStoppedMachineDisplay(this.tbLongStop_6);
            UpdateLongStoppedMachineDisplay(this.tbLongStop_7);
            UpdateLongStoppedMachineDisplay(this.tbLongStop_8);
            UpdateLongStoppedMachineDisplay(this.tbLongStop_9);
            UpdateLongStoppedMachineDisplay(this.tbMechanical);
            UpdateLongStoppedMachineDisplay(this.tbOtherLong);
            UpdateLongStoppedMachineDisplay(this.tbPowerOff);
            
         
           

            try
            {
                #region shedEff
                if (Settings.efficiencyType == EfficiencyType.ShedEfficiency)
                {
                    dxShed1.EfficiencyTypeLabel.Text = "Shed Efficiency";
                      dxShed1.ShedEfficiency.Tag = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff.ToString();
                        dxShed1.ShedEfficiency.Text = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff.ToString("#,##0.0");

                        
                  
                        dxShed1.RunningEff.Tag = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.RunningEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.RunningEff.ToString();
                        dxShed1.RunningEff.Text = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.RunningEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.RunningEff.ToString("#,##0.0");

                }
                else if (Settings.efficiencyType == EfficiencyType.ProductionEfficiency)
                {
                    //dxShed1.EfficiencyTypeLabel.Text = "Production Eff.";
                    //dxShed1.ShedEfficiency.Tag = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.ProductionEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.ProductionEff.ToString();
                    //dxShed1.ShedEfficiency.Text = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.ProductionEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.ProductionEff.ToString("#,##0.0");



                    //dxShed1.RunningEff.Tag = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.ProductionEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.ProductionEff.ToString();
                    //dxShed1.RunningEff.Text = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.ProductionEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.ProductionEff.ToString("#,##0.0");

                }
                else if (Settings.efficiencyType == EfficiencyType.TimeEfficiency)
                {
                    dxShed1.EfficiencyTypeLabel.Text = "Time Eff.";
                    dxShed1.ShedEfficiency.Tag = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeEff.ToString();
                    dxShed1.ShedEfficiency.Text = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeEff.ToString("#,##0.0");



                    dxShed1.RunningEff.Tag = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeEff.ToString();
                    dxShed1.RunningEff.Text = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeEff.ToString("#,##0.0");

                }
                else if (Settings.efficiencyType == EfficiencyType.TimeProductionEfficiency)
                {
                    dxShed1.EfficiencyTypeLabel.Text = "Time Prod. Eff.";
                    dxShed1.ShedEfficiency.Tag = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeProdEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeProdEff.ToString();
                    dxShed1.ShedEfficiency.Text = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeProdEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeProdEff.ToString("#,##0.0");



                    dxShed1.RunningEff.Tag = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeProdEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeProdEff.ToString();
                    dxShed1.RunningEff.Text = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeProdEff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeProdEff.ToString("#,##0.0");

                }
                #endregion
            }
            catch 
            {
            }
            try
            {
                #region shedRPM

                if (dxShed1.RPM_Val.Tag.ToString() != Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.RPM.ToString())
                {
                    dxShed1.RPM_Val.Tag = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.RPM) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.RPM.ToString();

                    dxShed1.RPM_Val.Text = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.RPM) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.RPM.ToString("#,##");

                }

                #endregion
            }
            catch 
            {
            }
            //try
            //{
            //    #region LongStops
            //    this.dxShed1.LongStops_Article_Val.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.ArticleChange.Length.ToString();
            //    this.dxShed1.LongStops_Electrical_Val.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Electrical.Length.ToString();
            //    this.dxShed1.LongStops_Knotting_Val.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Knotting.Length.ToString();
            //    this.dxShed1.LongStops_Mechanical_Val.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Mechanical.Length.ToString();
            //    this.dxShed1.LongStops_Others_Val.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Others.Length.ToString();

            //    #endregion
            //}
            //catch 
            //{
            //}

            try
            {
                #region Losses
                try
                {
                    double s;
                    double Defficiency = 0;
                    if (Settings.efficiencyType == EfficiencyType.ShedEfficiency || Settings.efficiencyType == EfficiencyType.ProductionEfficiency)
                    Defficiency=100 - Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff;

                    else if (Settings.efficiencyType == EfficiencyType.TimeEfficiency || Settings.efficiencyType==EfficiencyType.TimeProductionEfficiency)
                        Defficiency = 100 - Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.TimeEff;
                  


                    if (Defficiency < 0) Defficiency = 0;

                    

                    if (Settings.efficiencyType == EfficiencyType.ShedEfficiency || Settings.efficiencyType == EfficiencyType.ProductionEfficiency)
                    {
                        double ShortLoss = 0;
                        s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sOtherElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                        ShortLoss += double.IsNaN(s) == true ? 0 : s;
                        
                        this.dxShed1.Loss_Other.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWarpElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                        ShortLoss += double.IsNaN(s) == true ? 0 : s;
                        this.dxShed1.Loss_Warp.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWeftElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                        ShortLoss += double.IsNaN(s) == true ? 0 : s;
                        this.dxShed1.Loss_Weft.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        double TotalLongLoss = 0;
                        s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lElectricalElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                        TotalLongLoss += double.IsNaN(s)==true?0:s;
                        this.dxShed1.LongStops_Electrical_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lKnottingElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                        TotalLongLoss += double.IsNaN(s) == true ? 0 : s;

                        this.dxShed1.LongStops_Knotting_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lMechanicalElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                        TotalLongLoss += double.IsNaN(s) == true ? 0 : s;

                        this.dxShed1.LongStops_Mechanical_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        s = (((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lOtherElapsed+Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lLongStop_6+Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lLongStop_7+Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lLongStop_8+Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lLongStop_9) / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                        TotalLongLoss += double.IsNaN(s) == true ? 0 : s;

                        this.dxShed1.LongStops_Others_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lArticleElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                        TotalLongLoss += double.IsNaN(s) == true ? 0 : s;

                        this.dxShed1.LongStops_Article_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lPowerOffElapsed / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                        TotalLongLoss += double.IsNaN(s) == true ? 0 : s;

                        this.dxShed1.LongStops_PoweredOff_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.lLongStop_5 / Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.TotalDownTime) * 100) * Defficiency / 100;
                        TotalLongLoss += double.IsNaN(s) == true ? 0 : s;

                        this.dxShed1.LongStops_BeamShort_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");

                        this.dxShed1.LongStopLossDefficiency.Text = TotalLongLoss.ToString("#,##0.0");
                        if(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff + TotalLongLoss<=100)
                        this.dxShed1.ProductionEfficiency.Text = (Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff + TotalLongLoss).ToString("#,##0.0");
                        this.dxShed1.Counter_Loss_Total.Text = ShortLoss.ToString("#,##0.00");
                        double TotalCounters = Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sOtherTotalBreakages + Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWarpTotalBreakages + Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWeftTotalBreakages;
                        this.dxShed1.Counter_Total.Text = TotalCounters.ToString("#,##");
                        double TotalHoursPassed = DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ChangedAt).TotalHours;
                        double WarpPerHour = (Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWarpTotalBreakages / TotalHoursPassed)/TotalLooms;
                        this.dxShed1.Counter_Warp_PerHour.Text = WarpPerHour.ToString("#,##0.00");
                        double WeftPerHour = (Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWeftTotalBreakages / TotalHoursPassed)/TotalLooms;
                        this.dxShed1.Counter_Weft_PerHour.Text = WeftPerHour.ToString("#,##0.00");
                        double OtherPerHour = (Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sOtherTotalBreakages / TotalHoursPassed)/TotalLooms;
                        this.dxShed1.Counter_Other_PerHour.Text = OtherPerHour.ToString("#,##0.00");
                        double TotalPerHour = WarpPerHour + WeftPerHour + OtherPerHour;
                        this.dxShed1.Counter_Total_PerHour.Text = TotalPerHour.ToString("#,##0.00");
                        
                    }
                    else if (Settings.efficiencyType == EfficiencyType.ProductionEfficiency || Settings.efficiencyType == EfficiencyType.TimeProductionEfficiency)
                    {
                        s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sOtherElapsed / (Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWarpElapsed+Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWeftElapsed+Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sOtherElapsed)) * 100) * Defficiency / 100;
                        this.dxShed1.Loss_Other.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWarpElapsed / (Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWarpElapsed + Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWeftElapsed + Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sOtherElapsed)) * 100) * Defficiency / 100;
                        this.dxShed1.Loss_Warp.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        s = ((Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWeftElapsed / (Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWarpElapsed + Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWeftElapsed + Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sOtherElapsed)) * 100) * Defficiency / 100;
                        this.dxShed1.Loss_Weft.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        s = 0;
                        this.dxShed1.LongStops_Electrical_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        this.dxShed1.LongStops_Knotting_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        this.dxShed1.LongStops_Mechanical_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        this.dxShed1.LongStops_Others_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        this.dxShed1.LongStops_Article_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        this.dxShed1.LongStops_PoweredOff_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                        this.dxShed1.LongStops_BeamShort_Loss.Text = double.IsNaN(s) == true ? "" : s.ToString("#,##0.00");
                    }

                    this.dxShed1.Counter_Warp.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWarpTotalBreakages.ToString();
                    this.dxShed1.Counter_Weft.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sWeftTotalBreakages.ToString();
                    this.dxShed1.Counter_Other.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].StoppedStats.sOtherTotalBreakages.ToString();

                    this.dxShed1.LongStops_Article_Val.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.ArticleChange.Length.ToString();
                    this.dxShed1.LongStops_Electrical_Val.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Electrical.Length.ToString();
                    this.dxShed1.LongStops_Knotting_Val.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Knotting.Length.ToString();
                    this.dxShed1.LongStops_Mechanical_Val.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Mechanical.Length.ToString();
                    this.dxShed1.LongStops_PowerOff_Val.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.PowerOff.Length.ToString();
                    this.dxShed1.LongStops_BeamShort_Val.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.BeamShort.Length.ToString();
                    this.dxShed1.LongStops_Others_Val.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Others.Length.ToString();
                    this.dxShed1.Total_LongStopped.Text = Convert.ToString(Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.ArticleChange.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Electrical.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Knotting.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Mechanical.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Others.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.PowerOff.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.BeamShort.Length);
                    
                    //#endregion
                    //#region ShortStops
                    this.dxShed1.Stopped_Other.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Others.Length.ToString();
                    this.dxShed1.Stopped_Warp.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Warp.Length.ToString();
                    this.dxShed1.Stopped_Weft.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Weft.Length.ToString();
                    this.dxShed1.Total_ShortStopped.Text = Convert.ToString(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Others.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Warp.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Weft.Length);
                    int longstopped = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.ArticleChange.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Electrical.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Knotting.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Mechanical.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.Others.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.PowerOff.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].LongStops.BeamShort.Length;
                    int shortstopped = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Others.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Warp.Length + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShortStops.Weft.Length;
                   
                    this.dxShed1.TotalLooms.Text = TotalLooms.ToString();
                    
                    this.dxShed1.RunningLooms.Text = Convert.ToString(TotalLooms - longstopped - shortstopped);
                    double  RunningPercent=(Convert.ToDouble(TotalLooms) - Convert.ToDouble(longstopped) - Convert.ToDouble(shortstopped)) / Convert.ToDouble(TotalLooms) * 100;
                    this.dxShed1.RunningPercent.Text = RunningPercent.ToString("#,##0.0");
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


                    if (Settings.efficiencyType == EfficiencyType.ShedEfficiency)
                    {
                        if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].Eff.ToString() != dxType.RunningEfficiency.Tag.ToString())
                        {
                            try
                            {
                                dxType.RunningEfficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RunningEff.ToString();
                                dxType.RunningEfficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RunningEff.ToString("#,##0.0");
                                dxType.ShedEfficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].Eff.ToString("#,##0.0");

                                double RunningPercentType = Convert.ToDouble(Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RunningLooms) / Convert.ToDouble( Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].LoomIndexes.Length) * 100;
                                if (Double.IsNaN(RunningPercentType) == true) RunningPercentType = 0;
                                dxType.RunningEfficiency.ForeColor = Program.ss.Machines.PresentationData.Sheds[this.ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, RunningPercentType);
                                dxType.RunningEfficiency.Tag = RunningPercentType;
                                dxType.RunningEfficiency.Text = RunningPercentType.ToString("#,##0.0");
                            }
                            catch
                            {
                            }
                        }
                        if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString() != dxType.RPM.Tag.ToString())
                        {
                            dxType.RPM.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString();
                            dxType.RPM.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString("#,##");

                        }
                    }
                    else if (Settings.efficiencyType == EfficiencyType.ProductionEfficiency)
                    {
                        if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].ProdEff.ToString() != dxType.RunningEfficiency.Tag.ToString())
                        {
                            try
                            {
                                dxType.RunningEfficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].ProdEff.ToString();
                                dxType.RunningEfficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].ProdEff.ToString("#,##0.0");
                                dxType.ShedEfficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].ProdEff.ToString("#,##0.0");
                            }
                            catch
                            {
                            }
                        }
                        if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString() != dxType.RPM.Tag.ToString())
                        {
                            dxType.RPM.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString();
                            dxType.RPM.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString("#,##");

                        }
                    }
                    else if (Settings.efficiencyType == EfficiencyType.TimeEfficiency)
                    {
                        if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].TimeEff.ToString() != dxType.RunningEfficiency.Tag.ToString())
                        {
                            try
                            {
                                dxType.RunningEfficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].TimeEff.ToString();
                                dxType.RunningEfficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].TimeEff.ToString("#,##0.0");
                                dxType.ShedEfficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].TimeEff.ToString("#,##0.0");
                            }
                            catch
                            {
                            }
                        }
                        if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString() != dxType.RPM.Tag.ToString())
                        {
                            dxType.RPM.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString();
                            dxType.RPM.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString("#,##");

                        }
                    }
                    else if (Settings.efficiencyType == EfficiencyType.TimeProductionEfficiency)
                    {
                        if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].TimeProdEff.ToString() != dxType.RunningEfficiency.Tag.ToString())
                        {
                            try
                            {
                                dxType.RunningEfficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].TimeProdEff.ToString();
                                dxType.RunningEfficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].TimeProdEff.ToString("#,##0.0");
                                dxType.ShedEfficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].TimeProdEff.ToString("#,##0.0");
                            }
                            catch
                            {
                            }
                        }
                        if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString() != dxType.RPM.Tag.ToString())
                        {
                            dxType.RPM.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString();
                            dxType.RPM.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[Convert.ToInt16(dxType.Model.Tag)].RPM.ToString("#,##");

                        }
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
                    UserControls.dxSection dxSection = (UserControls.dxSection)dxCtr;

                    if (Settings.efficiencyType == EfficiencyType.ShedEfficiency)
                    {
                        if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].RunningEff.ToString() != dxSection.Efficiency.Tag.ToString())
                        {
                            try
                            {
                                dxSection.Efficiency.ForeColor = Program.ss.Machines.PresentationData.Sheds[this.ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].Eff);
                                dxSection.Efficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].Eff.ToString();
                                dxSection.Efficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].Eff.ToString("#,##0.0");
                                int Running = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].RunningLooms_ForRunningPercent;
                                int TotalSectionLooms = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].NumberofLooms;
                                double RunningPercentSection = Convert.ToDouble(Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].RunningLooms_ForRunningPercent) / Convert.ToDouble(Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].NumberofLooms) * 100;
                                if (Double.IsNaN(RunningPercentSection) == true) RunningPercentSection = 0;
                                dxSection.RunningEfficiency.ForeColor = Program.ss.Machines.PresentationData.Sheds[this.ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, RunningPercentSection);
                                dxSection.RunningEfficiency.Tag = RunningPercentSection;
                                dxSection.RunningEfficiency.Text = RunningPercentSection.ToString("#,##0.0");

                            }
                            catch
                            {
                            }
                        }
                    }

                    else if (Settings.efficiencyType == EfficiencyType.ProductionEfficiency)
                    {
                        if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].ProdEff.ToString() != dxSection.Efficiency.Tag.ToString())
                        {
                            try
                            {
                                dxSection.Efficiency.ForeColor = Program.ss.Machines.PresentationData.Sheds[this.ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].ProdEff);
                                dxSection.Efficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].ProdEff.ToString();
                                dxSection.Efficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].ProdEff.ToString("#,##0.0");


                                dxSection.RunningEfficiency.ForeColor = Program.ss.Machines.PresentationData.Sheds[this.ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].ProdEff);
                                dxSection.RunningEfficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].ProdEff.ToString();
                                dxSection.RunningEfficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].ProdEff.ToString("#,##0.0");

                            }
                            catch
                            {
                            }
                        }
                    }
                    else if (Settings.efficiencyType == EfficiencyType.TimeEfficiency)
                    {
                        if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].TimeEff.ToString() != dxSection.Efficiency.Tag.ToString())
                        {
                            try
                            {
                                dxSection.Efficiency.ForeColor = Program.ss.Machines.PresentationData.Sheds[this.ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].TimeEff);
                                dxSection.Efficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].TimeEff.ToString();
                                dxSection.Efficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].TimeEff.ToString("#,##0.0");


                                dxSection.RunningEfficiency.ForeColor = Program.ss.Machines.PresentationData.Sheds[this.ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].TimeEff);
                                dxSection.RunningEfficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].TimeEff.ToString();
                                dxSection.RunningEfficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].TimeEff.ToString("#,##0.0");

                            }
                            catch
                            {
                            }
                        }
                    }
                    else if (Settings.efficiencyType == EfficiencyType.TimeProductionEfficiency)
                    {
                        if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].TimeProdEff.ToString() != dxSection.Efficiency.Tag.ToString())
                        {
                            try
                            {
                                dxSection.Efficiency.ForeColor = Program.ss.Machines.PresentationData.Sheds[this.ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].TimeProdEff);
                                dxSection.Efficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].TimeProdEff.ToString();
                                dxSection.Efficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].TimeProdEff.ToString("#,##0.0");


                                dxSection.RunningEfficiency.ForeColor = Program.ss.Machines.PresentationData.Sheds[this.ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].TimeProdEff);
                                dxSection.RunningEfficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].TimeProdEff.ToString();
                                dxSection.RunningEfficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[Convert.ToInt16(dxSection.Section.Tag)].TimeProdEff.ToString("#,##0.0");

                            }
                            catch
                            {
                            }
                        }
                    }
                   
                }
                #endregion
            }
            catch
            {
            }

            try
            {
                CheckLongStoppedMachines(Cause.Mechanical, this.tbMechanical);
               

                CheckLongStoppedMachines(Cause.ArticleChange, this.tbArticle);
                CheckLongStoppedMachines(Cause.Electrical, this.tbElectrical);
                CheckLongStoppedMachines(Cause.Knotting, this.tbKnotting);
                CheckLongStoppedMachines(Cause.LongStop_5, this.tbLongStop_5);
                CheckLongStoppedMachines(Cause.LongStop_6, this.tbLongStop_6);
                CheckLongStoppedMachines(Cause.LongStop_7, this.tbLongStop_7);
                CheckLongStoppedMachines(Cause.LongStop_8, this.tbLongStop_8);
                CheckLongStoppedMachines(Cause.LongStop_9, this.tbLongStop_9);
                CheckLongStoppedMachines(Cause.OtherLong, this.tbOtherLong);
                CheckLongStoppedMachines(Cause.PowerOff, this.tbPowerOff);
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

        private dxLoom ReturnControl(string LoomID)
        {
            for (int x = 0; x < this.panelControl1.Controls.Count; x++)
            {

                dxLoom uc = (dxLoom)this.panelControl1.Controls[x];
                if (uc.LoomNumber.Tag.ToString() == LoomID)
                    return uc;
            }
            return null;
        }
       
    }
}