using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes
{
    public partial class DashBoard_WeaversMainView : DevExpress.XtraEditors.XtraForm
    {
        string CurrentlySelectedShift;
        public int ShedIndex;

        public DashBoard_WeaversMainView()
        {
            InitializeComponent();
        }

        private void DashBoard_WeaversMainView_Load(object sender, EventArgs e)
        {
            CurrentlySelectedShift = Program.ss.Machines.PresentationData.CurrentShift.WShift;
            for (int x = 0; x < Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups.Length; x++)
            {
                dxLoomGroup LGroup = new dxLoomGroup();
                LGroup.ShedIndex = ShedIndex;
                LGroup.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[x].GroupNumber.ToString();
                LGroup.Group.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[x].GroupName;
                LGroup.Group.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[x].GroupNumber.ToString();
                //LGroup.Weaver.Tag = Program.ss.Machines.PresentationData.LoomGroups[x].GroupNumber.ToString();

                LGroup.Left = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[x].x;
                LGroup.Top = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[x].y;
                LGroup.WeaverEfficiency.Tag = "-1";
                LGroup.WarpKnottTime.Tag = "-1";
                LGroup.WeftKnottTime.Tag = "-1";
                LGroup.Efficiency_1.Tag = "-1";
                LGroup.Efficiency_2.Tag = "-1";
                LGroup.Efficiency_3.Tag = "-1";
                LGroup.Efficiency_4.Tag = "-1";
                LGroup.Efficiency_5.Tag = "-1";
                LGroup.Efficiency_6.Tag = "-1";
                for (int y = 0; y < Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[x].LoomIndexes.Length; y++)
                {
                    DevExpress.XtraEditors.SimpleButton LoomNumber = null; ;
                    switch (y)
                    {
                        case 0:
                            LoomNumber = LGroup.Loom_1;

                            break;
                        case 1:
                            LoomNumber = LGroup.Loom_2;
                            break;
                        case 2:
                            LoomNumber = LGroup.Loom_3;
                            break;
                        case 3:
                            LoomNumber = LGroup.Loom_4;
                            break;
                        case 4:
                            LoomNumber = LGroup.Loom_5;
                            LoomNumber.Visible = true;
                            LGroup.Efficiency_5.Visible = true;
                            break;
                        case 5:
                            LoomNumber = LGroup.Loom_6;
                            LGroup.Efficiency_6.Visible = true;
                            LoomNumber.Visible = true;
                            break;
                        default:
                            break;
                    }

                    LoomNumber.Tag = Program.ss.Machines.Looms[Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[x].LoomIndexes[y]].PersonalInfo.LoomID;
                    LoomNumber.Text = Program.ss.Machines.Looms[Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[x].LoomIndexes[y]].PersonalInfo.LoomName;
                    

                }
                ControlMover.Init(LGroup);
               this.panelControl1.Controls.Add(LGroup);
            }
            ChangeWeavers();
        }
        private void LoadPictures()
        {
        
            try
            {
                DataSet ds = new DataSet();
                
                ds = WS.svc.Get_DataSet("Select * from Distinct_Weavers order by Groupnumber");
                if (ds != null)
                {
                    for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                    {


                        foreach (Control dxCtr in this.panelControl1.Controls)
                        {
                            dxLoomGroup dxGroup = (dxLoomGroup)dxCtr;
                            if (dxGroup.Weaver.Tag.ToString() == ds.Tables[0].Rows[x]["WeaverID_A"].ToString())
                            {
                                //if (ds.Tables[0].Rows[x]["PictureEmployee_A"].ToString() != "")
                                //{
                                //    byte[] image;
                                //    image = (byte[])ds.Tables[0].Rows[x]["PictureEmployee_A"];
                                //    dxGroup.WeaverPicture.Image = Program.byteArrayToImage(image);
                                //}
                            }
                            else if(dxGroup.Weaver.Tag.ToString() == ds.Tables[0].Rows[x]["WeaverID_B"].ToString())
                            {
                                //if (ds.Tables[0].Rows[x]["PictureEmployee_B"].ToString() != "")
                                //{
                                //    byte[] image;
                                //    image = (byte[])ds.Tables[0].Rows[x]["PictureEmployee_B"];
                                //    dxGroup.WeaverPicture.Image = Program.byteArrayToImage(image);
                                //}
                            }
                              else if(dxGroup.Weaver.Tag.ToString() == ds.Tables[0].Rows[x]["WeaverID_C"].ToString())
                            {
                                //if (ds.Tables[0].Rows[x]["PictureEmployee_C"].ToString() != "")
                                //{
                                //    byte[] image;
                                //    image = (byte[])ds.Tables[0].Rows[x]["PictureEmployee_C"];
                                //    dxGroup.WeaverPicture.Image = Program.byteArrayToImage(image);
                                //}
                            }
                            
                        }
                        }
                    }
                    ds = null;
                }
            
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Assigning Weavers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void ChangeWeavers()
        {
            foreach (Control dxCtr in this.panelControl1.Controls)
            {
                dxLoomGroup dxGroup = (dxLoomGroup)dxCtr;
                int GroupIndex = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnArrayIndex_LoomGroup(Convert.ToInt32(dxGroup.Tag.ToString()));
                dxGroup.Weaver.Tag = "-1";
                    try
                    {
                        if (CurrentlySelectedShift == "A")
                        {
                            dxGroup.Weaver.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverID_A;
                            dxGroup.Weaver.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverName_A;
                        }
                        else if (CurrentlySelectedShift == "B")
                        {
                            dxGroup.Weaver.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverID_B;
                            dxGroup.Weaver.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverName_B;
                        }
                        else if (CurrentlySelectedShift == "C")
                        {
                            dxGroup.Weaver.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverID_C;
                            dxGroup.Weaver.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverName_C;
                        }
                       

                    }
                    catch
                    {
                    }
                

            }
            LoadPictures();
        }
        private void timer_AutoRefresh_Tick(object sender, EventArgs e)
        {
            if (CurrentlySelectedShift != Program.ss.Machines.PresentationData.CurrentShift.WShift)
            {
                CurrentlySelectedShift = Program.ss.Machines.PresentationData.CurrentShift.WShift;
                ChangeWeavers();
            }
            foreach (Control dxCtr in this.panelControl1.Controls)
            {
                dxLoomGroup dxGroup = (dxLoomGroup)dxCtr;
                int GroupIndex = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnArrayIndex_LoomGroup(Convert.ToInt32(dxGroup.Tag.ToString()));
                if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Efficiency != Convert.ToDouble(dxGroup.WeaverEfficiency.Tag))
                {
                    try
                    {
                        if (dxGroup.WeaverEfficiency.Tag.ToString() != Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Efficiency.ToString())
                        {
                            dxGroup.WeaverEfficiency.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Efficiency.ToString();
                            dxGroup.WeaverEfficiency.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Efficiency.ToString("#,##0.0");
                        }

                        if (Convert.ToDouble(dxGroup.WarpKnottTime.Tag.ToString()) != Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].WarpKnottTime)
                        {
                            dxGroup.WarpKnottTime.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].WarpKnottTime.ToString();
                            TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].WarpKnottTime));
                            dxGroup.WarpKnottTime.Text = Get_FormattedTime(ts);
                        }
                        if (Convert.ToDouble(dxGroup.WeftKnottTime.Tag.ToString()) != Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].WeftKnottTime)
                        {
                            dxGroup.WeftKnottTime.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].WeftKnottTime.ToString();
                            TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].WeftKnottTime));
                            dxGroup.WeftKnottTime.Text = Get_FormattedTime(ts);
                        }
                        for (int x = 0; x < Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].LoomIndexes.Length; x++)
                        {
                            DevExpress.XtraEditors.SimpleButton LoomEff = null; ;
                            switch (x)
                            {
                                case 0:
                                    LoomEff = dxGroup.Efficiency_1;
                                   
                                    break;
                                case 1:
                                    LoomEff = dxGroup.Efficiency_2;
                                    break;
                                case 2:
                                    LoomEff = dxGroup.Efficiency_3;
                                    break;
                                case 3:
                                    LoomEff = dxGroup.Efficiency_4;
                                    break;
                                case 4:
                                    LoomEff = dxGroup.Efficiency_5;
                                    break;
                                case 5:
                                    LoomEff = dxGroup.Efficiency_6;
                                    break;
                                default:
                                    break;
                            }
                            if (Convert.ToDouble(LoomEff.Tag.ToString()) != Program.ss.Machines.Looms[Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].LoomIndexes[x]].CurrentParams.Current_Eff)
                            {
                                LoomEff.Tag = Program.ss.Machines.Looms[Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].LoomIndexes[x]].CurrentParams.Current_Eff.ToString();
                                LoomEff.Text = Program.ss.Machines.Looms[Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].LoomIndexes[x]].CurrentParams.Current_Eff.ToString("#,##0.0");
                            }

                        }

                    }
                    catch
                    {
                    }
                }
               
            }
        }

        private void DashBoard_WeaversMainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Exit == false) { e.Cancel = true; this.Hide(); }
        }
    }
}