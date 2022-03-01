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
    public partial class Dashboard_ModelShedEff : DevExpress.XtraEditors.XtraForm
    {
        DateTime LastsTopThreeCheck;
        public int ShedIndex;
        public Dashboard_ModelShedEff()
        {
            InitializeComponent();
        }

        private void Dashboard_ModelShedEff_Load(object sender, EventArgs e)
        {
            LastsTopThreeCheck = DateTime.Now;
            this.chart1.Series.Clear();

            this.ShedEfficiency.Tag = "";
            for (int x = 0; x < 3; x++)
            {
                dxWeaver_NameEff TopThree = new dxWeaver_NameEff();
                TopThree.Index.Text = Convert.ToString(x + 1);
                TopThree.Weaver.Tag = "-1";
                TopThree.Efficiency.Tag = "-1";
                
                this.tableLayoutPanel_TopThreeWeavers.Controls.Add(TopThree);

                dxLoom_NameEff TopLoom = new dxLoom_NameEff();
                TopLoom.Index.Text  = Convert.ToString(x + 1);
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
                System.Windows.Forms.DataVisualization.Charting.Series s = new System.Windows.Forms.DataVisualization.Charting.Series("Shift");
                this.chart1.Series.Add(s);
              
            //}

                for (int y = 0; y < Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms.Length; y++)
            {

                System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 0);
                this.chart1.Series[0].Points.Add(dp);
                this.chart1.Series[0].Points[y].BorderColor = Color.Black;
                this.chart1.Series[0].Points[y].IsValueShownAsLabel = false;
                this.chart1.Series[0].Points[y].Label = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[y].TypeName;
                this.chart1.Series[0].Points[y].LabelBorderWidth = 2;
                dxTypeEffDigital TypesEff = new dxTypeEffDigital();





                TypesEff.Model.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[y].TypeName;
                TypesEff.Model.Tag = y.ToString();
                TypesEff.Efficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[y].Eff.ToString("#,##0.0") + "%";
                TypesEff.Efficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[y].Eff.ToString();
               
               this.tableLayoutPanel_Efficiencies.Controls.Add(TypesEff);

            }

           
        }

        private void  Display_TopThree()
        {

           
            try
            {
                TimeSpan ts = DateTime.Now.Subtract(LastsTopThreeCheck);
                    if(ts.TotalSeconds<30)return;
                LastsTopThreeCheck=DateTime.Now;
                IEnumerable<int> Topthree = (from i in Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups
                                             orderby i.Efficiency descending
                                             select i.GroupNumber).Take(3);


                for (int x = 0; x < 3; x++)
                {
                    dxWeaver_NameEff ctrWeaver = (dxWeaver_NameEff)this.tableLayoutPanel_TopThreeWeavers.Controls[x];
                    bool WeaverNameFound = false;
                    loomGroup Weaver = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnArrayIndex_LoomGroup(Topthree.ElementAt(x))];
                    if (Program.ss.Machines.PresentationData.CurrentShift.WShift == "A")
                    {
                        if (ctrWeaver.Weaver.Tag.ToString() != Weaver.Weavers.WeaverID_A)
                        {
                            ctrWeaver.Weaver.Text = Weaver.GroupName;
                            ctrWeaver.Weaver.Tag = Weaver.Weavers.WeaverID_A;
                            ctrWeaver.Weaver.Text = Weaver.Weavers.WeaverName_A;
                            WeaverNameFound = true;
                        }
                    }
                    else if (Program.ss.Machines.PresentationData.CurrentShift.WShift == "B")
                    {
                        if (ctrWeaver.Weaver.Tag.ToString() != Weaver.Weavers.WeaverID_B)
                        {
                            ctrWeaver.Weaver.Text = Weaver.GroupName;
                            ctrWeaver.Weaver.Tag = Weaver.Weavers.WeaverID_B;
                            ctrWeaver.Weaver.Text = Weaver.Weavers.WeaverName_B;
                            WeaverNameFound = true ;
                        }
                    }
                    else if (Program.ss.Machines.PresentationData.CurrentShift.WShift == "C")
                    {
                        if (ctrWeaver.Weaver.Tag.ToString() != Weaver.Weavers.WeaverID_C)
                        {
                            ctrWeaver.Weaver.Text = Weaver.GroupName;
                            ctrWeaver.Weaver.Tag = Weaver.Weavers.WeaverID_C;
                            ctrWeaver.Weaver.Text = Weaver.Weavers.WeaverName_C;
                            WeaverNameFound =true;
                        }
                    }
                    if (ctrWeaver.Efficiency.Tag.ToString() != Weaver.Efficiency.ToString())
                    {
                        ctrWeaver.Efficiency.Tag = Weaver.Efficiency.ToString();
                        ctrWeaver.Efficiency.Text = Weaver.Efficiency.ToString("#,##0.0") + "%";
                        
                    }
                    if (WeaverNameFound == false)
                    {
                        ctrWeaver.Weaver.Text = Weaver.GroupName;
                    }
                }



                var TopthreeLooms = (from i in Program.ss.Machines.Looms where i.PersonalInfo.ShedID.ToString()==Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID
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
                                     where i.PersonalInfo.ShedID.ToString() == Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID
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

                var StoppedMachines = from i in Program.ss.Machines.Looms where DateTime.Now.Subtract(i.CurrentParams.Session_ActualStartTime).TotalMinutes>=Settings.CurrentSettings.ConsiderLongStop  && i.CurrentParams.Current_State!=(int)State.Running && i.PersonalInfo.ShedID.ToString()==Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID
                                     orderby i.PersonalInfo.LoomID ascending
                                     select i;
                
                foreach (var sMachines in StoppedMachines)
                {
                    MachineService.Loom sloom = (MachineService.Loom)sMachines;
                    AddLongStoppedMachine(ref sloom);
                }
                foreach (Control ctr in this.tableLayoutPanel_LongStoppedMachines.Controls)
                {
                    bool Found = false; ; dxLoom loom = (dxLoom)ctr;
                    foreach (var sMachines in StoppedMachines)
                    {
                        MachineService.Loom sloom = (MachineService.Loom)sMachines;

                        if (Convert.ToInt32(loom.LoomNumber.Tag) == sloom.PersonalInfo.LoomID)
                        {
                            Found = true;
                            break;
                        }
                    }
                    if (Found == false) this.tableLayoutPanel_LongStoppedMachines.Controls.Remove(ctr);
                    else if (Found == true) Found = false;
                    
                }

            }
            catch
            {
            }
        }
        
        private void AddLongStoppedMachine(ref MachineService.Loom sloom)
        {
            foreach (Control ctr in this.tableLayoutPanel_LongStoppedMachines.Controls)
            {
                dxLoom loom = (dxLoom)ctr;
                if (Convert.ToInt32(loom.LoomNumber.Tag) == sloom.PersonalInfo.LoomID) return;
            }
            dxLoom newLoom = new dxLoom();
            newLoom.LoomNumber.Tag = sloom.PersonalInfo.LoomID.ToString();
            newLoom.LoomNumber.Text = sloom.PersonalInfo.LoomName;
            this.tableLayoutPanel_LongStoppedMachines.Controls.Add(newLoom);
            Program.ss.SetMachineDisplay(ref sloom, ref newLoom);

        }
        
        
        private void timer1_Tick(object sender, EventArgs e)
        {


            Display_TopThree();
            foreach (Control ctr in this.tableLayoutPanel_LongStoppedMachines.Controls)
            {
                dxLoom loom = (dxLoom)ctr;
                Program.ss.SetMachineDisplay(ref Program.ss.Machines.Looms[Convert.ToInt32(loom.LoomNumber.Tag)], ref loom);
            }
            for (int x = 0; x < Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms.Length; x++)
            {


               
                if (this.chart1.Series[0].Points[x].YValues[0] != Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[x].Eff)
                {
                    dxTypeEffDigital TypesEff = (dxTypeEffDigital)this.tableLayoutPanel_Efficiencies.Controls[x];
                    TypesEff.Efficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[x].Eff.ToString("#,##0.0") + "%";
                    TypesEff.Efficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[x].Eff.ToString();
                    this.chart1.Series[0].Points[x].YValues[0] = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[x].Eff;
                    this.chart1.Series[0].Points[x].Color = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[x].Eff);
                }
                if (this.ShedEfficiency.Tag.ToString() != Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff.ToString())
                {
                    this.ShedEfficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff.ToString();
                    this.ShedEfficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff.ToString("#,##0.0") + "%";
                }




            }
        }

        private void Dashboard_ModelShedEff_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Exit == false) { e.Cancel = true; this.Hide(); }
        }
    }
}