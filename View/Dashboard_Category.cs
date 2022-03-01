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
    public partial class Dashboard_Category : DevExpress.XtraEditors.XtraForm
    {
     
        
        public Dashboard_Category()
        {
            InitializeComponent();
        }

        private void Dashboard_Category_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = WS.svc.Get_DataSet("Select * from MT_LoomCategories");
                if (ds != null)
                {
                    for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                    {
                        UserControls.dxLoomCategory loomCat = new UserControls.dxLoomCategory();
                        loomCat.CategoryName.Text = ds.Tables[0].Rows[x]["CategoryName"].ToString();
                        loomCat.CategoryName.Tag = ds.Tables[0].Rows[x]["CategoryID"].ToString();
                        int height = 0;
                        int width = 0;
                        int left = 0;
                        int top = 0;
                        int.TryParse(ds.Tables[0].Rows[x]["X"].ToString(), out left);
                        int.TryParse(ds.Tables[0].Rows[x]["Y"].ToString(), out top);
                        int.TryParse(ds.Tables[0].Rows[x]["Height"].ToString(), out height);
                        int.TryParse(ds.Tables[0].Rows[x]["Width"].ToString(), out width);
                        if(height!=0)
                        loomCat.Height = height;
                        if(width!=0)
                        loomCat.Width = width;

                        loomCat.Left = left;
                        loomCat.Top = top;
                        //DataSet dsLooms = WS.svc.Get_DataSet("Select LoomID from MT_Looms where CategoryID=" + ds.Tables[0].Rows[x]["CategoryID"].ToString() + "");
                        //if (dsLooms != null)
                        //{
                        //    Array.Resize(ref loomCat.LoomfallsinCategory, dsLooms.Tables[0].Rows.Count);
                        //    for (int y = 0; y < dsLooms.Tables[0].Rows.Count; y++)
                        //    {
                        //        loomCat.LoomfallsinCategory[y] = Convert.ToInt16(dsLooms.Tables[0].Rows[y]["LoomID"]);

                        //    }
                        //}
                        loomCat.GetCategoryLooms();
                        this.panelControl1.Controls.Add(loomCat);
                    }
                }
            }
            catch
            {
            }
        }

        private void timer_AutoRefresh_Tick(object sender, EventArgs e)
        {
            for (int x = 0; x < this.panelControl1.Controls.Count; x++)
            {
                int TotalLooms = 0;
                double Cat_Eff = 0;
                double Cat_WarpPerHour = 0;
                double Cat_WeftPerHour = 0;
                double Cat_WarpLoss = 0;
                double Cat_WeftLoss = 0;
                double Cat_LSD = 0;
                double Cat_STD = 0;
                double Cat_WarpStops = 0;
                double Cat_WeftStops = 0;
                double Cat_DownTime = 0;
                double Cat_ShortETime = 0;
                double Cat_LongETime = 0;
                double Cat_WarpETime=0;
                double Cat_WeftETime=0;
                UserControls.dxLoomCategory loomCat = (UserControls.dxLoomCategory)this.panelControl1.Controls[x];
                for (int l = 0; l < loomCat.tableLayoutPanel_Looms.Controls.Count; l++)
                {
                    dxLoom dxL = (dxLoom)loomCat.tableLayoutPanel_Looms.Controls[l];
                    TotalLooms++; int LoomID = 0;
                    int.TryParse(dxL.LoomNumber.Tag.ToString(), out LoomID);
                    Program.ss.SetMachineDisplay(ref Program.ss.Machines.Looms[LoomID], ref dxL);
                    Cat_Eff += Program.ss.Machines.Looms[LoomID].CurrentParams.Current_Eff;
                    Cat_WarpStops += Program.ss.Machines.Looms[LoomID].ShiftParams.Shift_Warps;
                    Cat_WeftStops += Program.ss.Machines.Looms[LoomID].ShiftParams.Shift_Wefts;
                    Cat_DownTime += Program.ss.Machines.Looms[LoomID].ShiftParams.Shift_DownTime;
                    Cat_ShortETime += Program.ss.Machines.Looms[LoomID].ShiftParams.Shift_ShortETime;
                    Cat_LongETime += Program.ss.Machines.Looms[LoomID].ShiftParams.Shift_LongETime;

                        Cat_WarpETime += Program.ss.Machines.Looms[LoomID].ShiftParams.Shift_WarpETime;
                       Cat_WeftETime+=Program.ss.Machines.Looms[LoomID].ShiftParams.Shift_WeftETime;
                    

                    
                }
                if (TotalLooms > 0)
                {
                    Cat_Eff = Cat_Eff / TotalLooms;
                    loomCat.TotalLooms.Text = TotalLooms.ToString("#,##");
                    loomCat.Efficiency.Text = Cat_Eff.ToString("#,#0.0");
                    loomCat.Warp_Stops.Text = Cat_WarpStops.ToString("#,##");
                    loomCat.Weft_Stops.Text = Cat_WeftStops.ToString("#,##");
                    double Defficiency = 0;

                    Defficiency = 100 - Cat_Eff;

                    if (Defficiency < 0) Defficiency = 0;
                    double s;

                    s = ((Cat_ShortETime / Cat_DownTime) * 100) * Defficiency / 100;
                    Cat_STD = double.IsNaN(s) == true ? 0 : s;
                    s = ((Cat_LongETime / Cat_DownTime) * 100) * Defficiency / 100;
                    Cat_LSD = double.IsNaN(s) == true ? 0 : s;
                    s = ((Cat_WarpETime / Cat_DownTime) * 100) * Defficiency / 100;
                    Cat_WarpLoss = double.IsNaN(s) == true ? 0 : s;
                    s = ((Cat_WeftETime / Cat_DownTime) * 100) * Defficiency / 100;
                    Cat_WeftLoss = double.IsNaN(s) == true ? 0 : s;
                    loomCat.Warp_Loss.Text = Cat_WarpLoss.ToString("#,##0.00");
                    loomCat.Weft_Loss.Text = Cat_WeftLoss.ToString("#,##0.00");
                    loomCat.STD.Text = Cat_STD.ToString("#,##0.00");
                    loomCat.LSD.Text = Cat_LSD.ToString("#,##0.00");

                    double TotalHoursPassed = DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ChangedAt).TotalHours;
                    Cat_WarpPerHour = (Cat_WarpStops / TotalHoursPassed) / TotalLooms;

                    Cat_WeftPerHour = (Cat_WeftStops / TotalHoursPassed) / TotalLooms;
                    loomCat.Warp_perHour.Text = Cat_WarpPerHour.ToString("#,##0.00");
                    loomCat.Weft_PerHour.Text = Cat_WeftPerHour.ToString("#,##0.00");

                }


            }
        }

     
   
     
     
   
      

      

      
       
    }
}