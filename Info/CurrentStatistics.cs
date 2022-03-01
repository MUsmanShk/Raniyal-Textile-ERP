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
    public partial class CurrentStatistics : DevExpress.XtraEditors.XtraForm
    {
        public CurrentStatistics()
        {
            InitializeComponent();
        }
        private void LoadWeaver()
        {
            int GroupIndex = Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].ReturnArrayIndex_LoomGroup_ByLoomIndex(CurrentSelection.LoomIndex);
            byte[] image;
            try
            {
                
                if (GroupIndex == -1) return;
                this.Weaver_AvgKnotTimeWarp.Text = Settings.FormatSeconds(Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[GroupIndex].WarpKnottTime);
                this.Weaver_AvgKnotTimeWeft.Text = Settings.FormatSeconds(Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[GroupIndex].WeftKnottTime);
                this.Weaver_GroupName.Text = Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[GroupIndex].GroupName;
                this.Weaver_GroupName.Tag = Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[GroupIndex].GroupNumber;
                this.Weaver_Efficiency.Text = Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[GroupIndex].Efficiency.ToString("#,##0.00");
                string assignedlooms = "";
                for (int x = 0; x < Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[GroupIndex].LoomIndexes.Length; x++)
                {
                    assignedlooms += Program.ss.Machines.Looms[Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[GroupIndex].LoomIndexes[x]].PersonalInfo.LoomName;
                    if (x +1 < Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[GroupIndex].LoomIndexes.Length)
                        assignedlooms += ", ";

                }
                this.Weaver_AssignedLooms.Text = assignedlooms;


            }
            catch 
            {
            }
            try
            {
                if (GroupIndex == -1) return;
                string WeaverID = "NO_ID";
                if (Program.ss.Machines.PresentationData.CurrentShift.WShift == "A")
                    WeaverID = Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverID_A;
                else if (Program.ss.Machines.PresentationData.CurrentShift.WShift == "B")
                    WeaverID = Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverID_B;
                else if (Program.ss.Machines.PresentationData.CurrentShift.WShift == "C")
                    WeaverID = Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverID_C;
                DataSet ds;

                ds = WS.svc.Get_DataSet("select * from PP_Employees where EmployeeID='" + WeaverID + "'  ");
                if (ds == null) return;
                if (ds.Tables[0].Rows.Count <= 0) return;
                this.Weaver_WeaverID.Text = ds.Tables[0].Rows[0]["EmployeeID"].ToString();
                this.Weaver_WeaverName.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                this.Weaver_RFID.Text = ds.Tables[0].Rows[0]["ERFID"].ToString();
                this.Weaver_Mob1.Text = ds.Tables[0].Rows[0]["Mobile_1"].ToString();
                this.Weaver_Mob2.Text = ds.Tables[0].Rows[0]["Mobile_2"].ToString();
                this.Weaver_Mob3.Text = ds.Tables[0].Rows[0]["Mobile_3"].ToString();
                if (ds.Tables[0].Rows[0]["picture"].ToString() != "")
                {
                    image = (byte[])ds.Tables[0].Rows[0]["picture"];
                    this.Weaver_Picture.Image = Program.byteArrayToImage(image);

                }
                else
                {
                    this.Weaver_Picture.Image = MachineEyes.Properties.Resources.technician;
                    image = Program.imageToByteArray(MachineEyes.Properties.Resources.technician);

                }
            }
            catch 
            {
            }

        }

        private void CurrentStatistics_Load(object sender, EventArgs e)
        {
            LoadWeaver();
        }
    }
}