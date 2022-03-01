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
    public partial class Dashboard_Weavers : DevExpress.XtraEditors.XtraForm
    {
       // DataTable WeaversTable = new DataTable();
        public int ShedIndex;
        string CurrentlySelectedShift = "";
        DateTime newCardTime = new DateTime();
        bool MinusSide = false;
        bool Scrolling = false;
        public Dashboard_Weavers()
        {
            InitializeComponent();
           
        }
        private void Load_Weavers()
        {
            CurrentlySelectedShift = Program.ss.Machines.PresentationData.CurrentShift.WShift;
            newCardTime = DateTime.Now;
            //WeaversTable.Columns.Add("EmployeeID", typeof(string));
           // WeaversTable.Columns.Add("EmployeeName",typeof(string));
           // WeaversTable.Columns.Add("Picture", typeof(Image));
           // WeaversTable.Columns.Add("Efficiency", typeof(double));
            
            for (int x = 0; x < Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups.Length; x++)
            {
                
                dxWeaverEff WeaversEff = new dxWeaverEff();
                this.scrollWeavers.Controls.Add(WeaversEff);
                WeaversEff.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[x].GroupNumber.ToString();
                
                WeaversEff.WeaverEff.Tag = "-1";
                WeaversEff.AvgWarpKnott.Tag = "-1";
                WeaversEff.AvgWeftKnott.Tag = "-1";
                if (x > 0) WeaversEff.Top = this.scrollWeavers.Controls[x - 1].Top + this.scrollWeavers.Controls[x - 1].Height;
                WeaversEff.IndexNumber.Text = Convert.ToString(x + 1);
                //WeaversTable.Rows.Add(Program.ss.Machines.PresentationData.LoomGroups[x].Weavers.WeaverName_B, null, Program.ss.Machines.PresentationData.LoomGroups[x].Efficiency);
                
                
            }


            //this.gridControl1.DataSource = WeaversTable;
            ChangeWeavers();
        }
        private void ChangeWeavers()
        {
            
            foreach (Control dxCtr in this.scrollWeavers.Controls)
            {
                dxWeaverEff WeaversEff = (dxWeaverEff)dxCtr;
                string sqlquery = "";
                int GroupIndex = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnArrayIndex_LoomGroup(Convert.ToInt32(WeaversEff.Tag.ToString()));
                string LoomNumbers = "";
                try
                {
                    if (CurrentlySelectedShift == "A")
                    {
                        sqlquery = "select * from QP_WeaversDataTableView where EmployeeID in(Select WeaverID_A from Mt_looms) order by convert(numeric,EmployeeID) ";
                        WeaversEff.WeaverName.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverName_A;
                        WeaversEff.WeaverName.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverID_A;
                        

                    }
                    else if (CurrentlySelectedShift == "B")
                    {
                        sqlquery = "select * from QP_WeaversDataTableView where EmployeeID in(Select WeaverID_B from Mt_looms) order by convert(numeric,EmployeeID) ";
                        WeaversEff.WeaverName.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverName_B;
                        WeaversEff.WeaverName.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverID_B;

                    }
                    else if (CurrentlySelectedShift == "C")
                    {
                        sqlquery = "select * from QP_WeaversDataTableView where EmployeeID in(Select WeaverID_C from Mt_looms) order by convert(numeric,EmployeeID) ";
                        WeaversEff.WeaverName.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverName_C;
                        WeaversEff.WeaverName.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverID_C;
                    }
                    LoomNumbers = "";
                    for (int x = 0; x < Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].LoomIndexes.Length; x++)
                    {
                        LoomNumbers += Program.ss.Machines.Looms[Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].LoomIndexes[x]].PersonalInfo.LoomName;
                        if (x + 1 < Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].LoomIndexes.Length)
                            LoomNumbers += " , ";
                    }
                    WeaversEff.Looms.Text = LoomNumbers;
                    DataSet ds = new DataSet();
                    ds = WS.svc.Get_DataSet(sqlquery);
                    this.gridControl1.DataSource = ds.Tables[0];
                }
                catch
                {
                }


            }
        }
        private void Load_Technicians()
        {
            //for (int x = 0; x < Program.ss.Machines.PresentationData.Technicians.Length; x++)
            //{

            //    dxTechniciansEff TechEff = new dxTechniciansEff();
            //    this.scrollTechnician.Controls.Add(TechEff);
            //    if (x > 0) TechEff.Top = this.scrollTechnician.Controls[x - 1].Top + this.scrollTechnician.Controls[x - 1].Height;
            //    TechEff.IndexNumber.Text = Convert.ToString(x + 1);
            //    TechEff.TechnicianName.Text = Program.ss.Machines.PresentationData.Technicians[x].TechnicianName;
            //    TechEff.TechnicianName.Tag = Program.ss.Machines.PresentationData.Technicians[x].TechnicianID;

            //}           
        }
        private void dxWeaversView_Load(object sender, EventArgs e)
        {
            


            Load_Weavers();
            Load_Technicians();
           

        }
        private string Get_FormattedTime(TimeSpan ts)
        {
            string s = "";
            if (ts.Days > 0)
                s = ts.Days.ToString() + "d " + ts.Hours.ToString();
            else if (ts.Hours > 0)
                s = ts.Hours.ToString() + "h " + ts.Minutes.ToString();
            else if (ts.Minutes > 0)
                s = ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
            else
                s = ts.Seconds.ToString();
            return s;
        }
        private void ChangeTops()
        {
            if (Scrolling == false) return;
            int GroupIndex=0;
            for (int x = 0; x < this.scrollWeavers.Controls.Count; x++)
            {
                
                dxWeaverEff WeaversEff = (dxWeaverEff)this.scrollWeavers.Controls[x];
                GroupIndex = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnArrayIndex_LoomGroup(Convert.ToInt32(WeaversEff.Tag));
                if (Double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Efficiency) == false)
                {
                    if (WeaversEff.WeaverEff.Tag.ToString() != Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Efficiency.ToString())
                    {

                        WeaversEff.WeaverEff.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Efficiency.ToString();
                        WeaversEff.WeaverEff.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Efficiency.ToString("#,##0.0") + "%";
                    }
                }
                if (double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].WarpKnottTime) == false)
                {
                    if (WeaversEff.AvgWarpKnott.Tag.ToString() != Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].WarpKnottTime.ToString())
                {
                    WeaversEff.AvgWarpKnott.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].WarpKnottTime.ToString();
                    TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].WarpKnottTime));
                    
                    WeaversEff.AvgWarpKnott.Text = Get_FormattedTime(ts);
                }
                }
                if (double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].WeftKnottTime) == false)
                {
                    if (WeaversEff.AvgWeftKnott.Tag.ToString() != Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].WeftKnottTime.ToString())
                    {
                        WeaversEff.AvgWeftKnott.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].WeftKnottTime.ToString();
                        TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].WeftKnottTime));

                        WeaversEff.AvgWeftKnott.Text = Get_FormattedTime(ts);
                    }
                }
                this.scrollWeavers.Controls[x].Top = this.scrollWeavers.Controls[x].Top- 1;
                if(this.scrollWeavers.Controls[x].Top<(this.scrollWeavers.Controls[x].Height-(this.scrollWeavers.Controls[x].Height*2)))
                   this.scrollWeavers.Controls[x].Top =this.scrollWeavers.Controls[x==0?this.scrollWeavers.Controls.Count-1:x-1].Top+this.scrollWeavers.Controls[0].Height;
               
            }
        }
        private void GetNewCard()
        {

            if (layoutView1.DataRowCount > 0)
            {
                if (layoutView1.FocusedRowHandle == layoutView1.DataRowCount-1)
                    MinusSide = true;
                else if (layoutView1.FocusedRowHandle == 0 && MinusSide == true)
                    MinusSide = false;
                if (layoutView1.FocusedRowHandle < layoutView1.DataRowCount && MinusSide == false)
                    layoutView1.FocusedRowHandle++;
                else if (layoutView1.FocusedRowHandle > 0 && MinusSide == true)
                    layoutView1.FocusedRowHandle--;
                newCardTime = DateTime.Now;
                DataRow dr = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);

                //var FocusedGroup = (from i in Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups
                //                      select i).Take(1);
                //if(CurrentlySelectedShift =="A")
                //{
                //    FocusedGroup = (from i in Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups
                //                   where i.Weavers.WeaverID_A ==dr["EmployeeID"].ToString()
                //                                       select i).Take(1);
                //}else if(CurrentlySelectedShift=="B")
                //{
                //    FocusedGroup = (from i in Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups
                //                    where i.Weavers.WeaverID_B == dr["EmployeeID"].ToString()
                //                    select i).Take(1);
                //}
                //else
                //{
                //    FocusedGroup = (from i in Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups
                //                    where i.Weavers.WeaverID_C == dr["EmployeeID"].ToString()
                //                    select i).Take(1);
                //}
                try
                {
                    int GroupIndex = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnArrayIndex_LoomGroup_ByWeaverID(dr["EmployeeID"].ToString(), CurrentlySelectedShift);
                    if (GroupIndex == -1) return;

                    loomGroup sGroup = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex];
                    string ActualValue = dr["Efficiency"].ToString();

                    if (sGroup.Efficiency.ToString("#,##0.0") + "%" != Convert.ToString(dr["Efficiency"]) + "%")
                    {

                        dr["Efficiency"] = sGroup.Efficiency.ToString("#,##0.0") + "%";
                        for(int x=0;x<sGroup.LoomIndexes.Length;x++)
                        {
                            if(x==0)
                            dr["Loom1"] = "# " + Program.ss.Machines.Looms[sGroup.LoomIndexes[x]].PersonalInfo.LoomName + " @ " + Program.ss.Machines.Looms[sGroup.LoomIndexes[x]].CurrentParams.Current_Eff.ToString("#,##0.0") + "%";
                            else if (x == 1)
                                dr["Loom2"] = "# " + Program.ss.Machines.Looms[sGroup.LoomIndexes[x]].PersonalInfo.LoomName + " @ " + Program.ss.Machines.Looms[sGroup.LoomIndexes[x]].CurrentParams.Current_Eff.ToString("#,##0.0") + "%";
                            else if (x == 2)
                                dr["Loom3"] = "# " + Program.ss.Machines.Looms[sGroup.LoomIndexes[x]].PersonalInfo.LoomName + " @ " + Program.ss.Machines.Looms[sGroup.LoomIndexes[x]].CurrentParams.Current_Eff.ToString("#,##0.0") + "%";
                            else if (x == 3)
                                dr["Loom4"] = "# " + Program.ss.Machines.Looms[sGroup.LoomIndexes[x]].PersonalInfo.LoomName + " @ " + Program.ss.Machines.Looms[sGroup.LoomIndexes[x]].CurrentParams.Current_Eff.ToString("#,##0.0") + "%";
                            else if (x == 4)
                                dr["Loom5"] = "# " + Program.ss.Machines.Looms[sGroup.LoomIndexes[x]].PersonalInfo.LoomName + " @ " + Program.ss.Machines.Looms[sGroup.LoomIndexes[x]].CurrentParams.Current_Eff.ToString("#,##0.0") + "%";
                            else if (x == 5)
                                dr["Loom6"] = "# " + Program.ss.Machines.Looms[sGroup.LoomIndexes[x]].PersonalInfo.LoomName + " @ " + Program.ss.Machines.Looms[sGroup.LoomIndexes[x]].CurrentParams.Current_Eff.ToString("#,##0.0") + "%";

                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now.Subtract(newCardTime);
            if (ts.TotalSeconds > 5)
            {
                GetNewCard();
            }
            ChangeTops();
            if (CurrentlySelectedShift != Program.ss.Machines.PresentationData.CurrentShift.WShift)
            {
                CurrentlySelectedShift = Program.ss.Machines.PresentationData.CurrentShift.WShift;
                ChangeWeavers();
            }  
          
           
        
        }

        private void Dashboard_Weavers_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Exit == false) { e.Cancel = true; this.Hide(); }
        }

        private void EfficiencyScrollButton_Click(object sender, EventArgs e)
        {

        }

        private void EfficiencyScrollButton_DoubleClick(object sender, EventArgs e)
        {
            if (Scrolling == false)
                Scrolling = true;
            else if (Scrolling == true)
                Scrolling = false;
        }

      
    }
}