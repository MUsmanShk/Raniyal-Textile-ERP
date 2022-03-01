using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.FilterEditor;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
namespace MachineEyes.UserControls
{
    public partial class dx_FilterView : DevExpress.XtraEditors.XtraUserControl
    {
        public dx_FilterView()
        {
            InitializeComponent();
        }
        bool initProperties = false;
        private void sbApply_Click(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
             DataTable dt = new DataTable();


            dt.Columns.Add("Shed");
            dt.Columns.Add("LoomNumber");
            dt.Columns.Add("LoomSection");
            dt.Columns.Add("LoomType");
            dt.Columns.Add("Article");
            dt.Columns.Add("RPM");
            dt.Columns.Add("Efficiency");
            dt.Columns.Add("ProdEff");
            dt.Columns.Add("WarpStops");
            dt.Columns.Add("WeftStops");
            dt.Columns.Add("WarpPerHour");
            dt.Columns.Add("WeftPerHour");
            dt.Columns.Add("StopCause");
          
        
         
           for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
           {
               double WarpPerHour = 0;
               double WeftPerHour = 0;
               double HrsPassed=DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate).TotalHours;
              
               try
               {
                   WarpPerHour = Program.ss.Machines.Looms[x].ShiftParams.Shift_Warps / HrsPassed;
               }
               catch
               {
               }
               try
               {
                   WeftPerHour = Program.ss.Machines.Looms[x].ShiftParams.Shift_Wefts / HrsPassed;
               }
               catch
               {
               }
               string ArticleName = "";
               string SectionName = "";
               string TypeName = "";
              
               try
               {
                   if (Program.ss.Machines.Looms[x].CurrentAssignedParams.ArticleNumber != "")
                       ArticleName = Program.ss.Machines.PresentationData.Articles[Program.ss.Machines.Looms[x].CurrentAssignedParams.ArticleNumber].ArticleName;
                   else
                       ArticleName = "NO_ARTICLE_DEFINED";

               }
               catch
               {
                       ArticleName="NO_ARTICLE_DEFINED";
               }

               try
                  
               {
                   int SectionIndex = Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.Looms[x].PersonalInfo.ShedID].Return_SectionIndex(Program.ss.Machines.Looms[x].PersonalInfo.SectionID.ToString());
                   if (Program.ss.Machines.Looms[x].PersonalInfo.SectionID !=-1)
                      SectionName= Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.Looms[x].PersonalInfo.ShedID].Sections[SectionIndex].SectionName;
                   else
                       SectionName = "NO_SECTION_DEFINED";

               }
               catch
               {
                   SectionName = "NO_SECTION_DEFINED";
               }
               try
               {
                   int TypeIndex = Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.Looms[x].PersonalInfo.ShedID].ReturnArrayIndex_Types(Program.ss.Machines.Looms[x].PersonalInfo.TypeID.ToString());
                   if (Program.ss.Machines.Looms[x].PersonalInfo.TypeID != -1)
                       TypeName = Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.Looms[x].PersonalInfo.ShedID].TypesOfLooms[TypeIndex].TypeName;
                   else
                       TypeName = "NO_TYPE_DEFINED";

               }
               catch
               {
                   TypeName = "NO_TYPE_DEFINED";
               }

               try
               {
                   int cCause = Program.ss.Machines.Looms[x].CurrentParams.Current_Cause;
                   Cause CurrentCause = (Cause)cCause;
                  // if(Program.ss.Machines.Looms[x].CurrentParams.Current_State
                 

               }
               catch
               {
                   TypeName = "NO_TYPE_DEFINED";
               }
               object[] row = new object[] { Convert.ToInt32(Program.ss.Machines.Looms[x].PersonalInfo.ShedID), Convert.ToInt32(Program.ss.Machines.Looms[x].PersonalInfo.LoomName), SectionName, TypeName, ArticleName, Convert.ToInt32(Program.ss.Machines.Looms[x].ShiftParams.Shift_RPM), Program.ss.Machines.Looms[x].CurrentParams.Current_Eff, Program.ss.Machines.Looms[x].CurrentParams.Current_Prod_Eff, Program.ss.Machines.Looms[x].ShiftParams.Shift_Warps, Program.ss.Machines.Looms[x].ShiftParams.Shift_Wefts, WarpPerHour, WeftPerHour};
               dt.Rows.Add(row);
           }
            this.gridControl1.DataSource = dt;
        }
       

       
        

      

       

      

        private void seLevelIndent_EditValueChanged(object sender, EventArgs e)
        {
            if (initProperties) return;
          
        }

        private void seSeparatorHeight_EditValueChanged(object sender, EventArgs e)
        {
            if (initProperties) return;
          
        }

        private void ceGroupCommandsIcon_EditValueChanged(object sender, EventArgs e)
        {
           
        }

       

       


        private void dx_FilterView_Leave(object sender, EventArgs e)
        {

        }

        private void dx_FilterView_Load(object sender, EventArgs e)
        {
           
           
            LoadData();
           
         
            
        }
      
        
    }
}
