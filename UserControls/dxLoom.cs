using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes
{
    public partial class dxLoom : DevExpress.XtraEditors.XtraUserControl
    {
        int _ShedIndex;
        public int ShedIndex
        {
            get { return _ShedIndex; }
            set { _ShedIndex = value; }
        }

        public DevExpress.XtraEditors.SimpleButton SelectedButton;
        public dxLoom()
        {
            InitializeComponent();
            
            this.popupMenu1.Ribbon = Program.MainWindow.ribbonControl1;
            this.popupMenu1.AddItem(Program.MainWindow.bbi_Data_AssignLoom_CurrentLoomStats);
            this.popupMenu1.AddItem(Program.MainWindow.bbi_Data_AssignLoom_CurrentLoomInfo);
            this.popupMenu1.AddItem(Program.MainWindow.bbi_Data_AssignLoom_Beam);
            this.popupMenu1.AddItem(Program.MainWindow.bbi_Data_AssignLoom_Article);
            
            this.popupMenu1.AddItem(Program.MainWindow.bbi_Data_AssignLoom_Technician);
            this.popupMenu1.AddItem(Program.MainWindow.bbi_Data_Assign_FDNI);
            this.popupMenu1.AddItem(Program.MainWindow.bbi_Data_AssignLoom_FDNE);
            this.popupMenu1.AddItem(Program.MainWindow.bbiSubMenu_AssignStopCause);
            this.popupMenu1.AddItem(Program.MainWindow.bbiSubMenu_AssignToGroup);
            this.popupMenu1.AddItem(Program.MainWindow.bbiSubMenu_AssignPosition);
            this.popupMenu1.AddItem(Program.MainWindow.bbi_Data_Loom_Log);
        }
       
        private void Efficiency_TextChanged(object sender, EventArgs e)
        {
            Efficiency.ForeColor = Program.ss.Machines.PresentationData.Sheds[_ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Convert.ToDouble(this.Efficiency.Tag));
          
        }

        private void LoomNumber_Click(object sender, EventArgs e)
           
        {
            SelectedButton = LoomNumber;
            this.popupMenu1.MenuCaption = "Loom # " + this.LoomNumber.Text;
            CurrentSelection.LoomIndex = Convert.ToInt32(this.LoomNumber.Tag);
            int sIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.ShedID.ToString());
            CurrentSelection.ShedIndex = sIndex;
            if (Program.MainWindow.bbi_Data_Assign_FDNI.Tag.ToString() != Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNI.ToString())
            {
                if (Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNI == false)
                {
                   
                    Program.MainWindow.bbi_Data_Assign_FDNI.Caption = "Exclude from Running Efficiency";
                    Program.MainWindow.bbi_Data_Assign_FDNI.Tag = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNI.ToString();




                }
                else if (Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNI == true)
                {


                    
                    Program.MainWindow.bbi_Data_Assign_FDNI.Caption = "Include into Running Efficiency";
                    Program.MainWindow.bbi_Data_Assign_FDNI.Tag = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNI.ToString();


                }
            }


            if (Program.MainWindow.bbi_Data_AssignLoom_FDNE.Tag.ToString() != Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNE.ToString())
            {
                if (Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNE == false)
                {

                    Program.MainWindow.bbi_Data_AssignLoom_FDNE.Caption = "Force include into Running Efficiency";
                    Program.MainWindow.bbi_Data_AssignLoom_FDNE.Tag = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNE.ToString();
                     
                   


                }
                else if (Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNE == true)
                {


                    Program.MainWindow.bbi_Data_AssignLoom_FDNE.Caption = "Leave at Auto include / exclude";
                    Program.MainWindow.bbi_Data_AssignLoom_FDNE.Tag = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNE.ToString();
                   


                }

            }

            this.popupMenu1.ShowPopup(MousePosition);
        }

        private void dxLoom_Enter(object sender, EventArgs e)
        {
            if (ControlMover.Mode == ControlMover.vMode.Move)
            {
                if (this.LoomNumber.Tag != null)
                {
                    if (this.LoomNumber.Tag.ToString() != "")
                    {

                        CurrentSelection.LoomIndex = Convert.ToInt32(this.LoomNumber.Tag);
                        this.Width = Convert.ToInt32(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.Width)+2;
                        this.Height = Convert.ToInt32(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.Height)+2;
                    }
                }
               
            
            }

            CurrentSelection.SelectedControl = this;
        }

        private void dxLoom_Leave(object sender, EventArgs e)
        {
            if (ControlMover.Mode == ControlMover.vMode.Move)
            {
                if (this.LoomNumber.Tag != null)
                {
                    if (this.LoomNumber.Tag.ToString() != "")
                    {

                        CurrentSelection.LoomIndex = Convert.ToInt32(this.LoomNumber.Tag);
                        this.Width = Convert.ToInt32(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.Width);
                        this.Height = Convert.ToInt32(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.Height);
                    }
                }
            }
        }

        private void LoomNumber_Enter(object sender, EventArgs e)
        {
            if (ControlMover.Mode == ControlMover.vMode.Move)
            {
                if (this.LoomNumber.Tag != null)
                {
                    if (this.LoomNumber.Tag.ToString() != "")
                    {

                        CurrentSelection.LoomIndex = Convert.ToInt32(this.LoomNumber.Tag);
                        this.Width = Convert.ToInt32(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.Width)+2;
                        this.Height = Convert.ToInt32(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.Height)+2;
                    }
                }
            
            }
           
        }

        private void LoomNumber_Leave(object sender, EventArgs e)
        {
            if (ControlMover.Mode == ControlMover.vMode.Move)
            {
                if (this.LoomNumber.Tag != null)
                {
                    if (this.LoomNumber.Tag.ToString() != "")
                    {

                        CurrentSelection.LoomIndex = Convert.ToInt32(this.LoomNumber.Tag);
                        this.Width = Convert.ToInt32(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.Width);
                        this.Height = Convert.ToInt32(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.Height);
                    }
                }
            }
        }

        private void dxLoom_Load(object sender, EventArgs e)
        {
            this.RPM.ImageList = Program.MainWindow.CauseImages;
            this.Efficiency.ImageList = Program.MainWindow.CauseImages;
        }

        private void Efficiency_Click(object sender, EventArgs e)
        {
            SelectedButton = Efficiency;
        }

        private void ElapsedTime_Click(object sender, EventArgs e)
        {
            SelectedButton = ElapsedTime;
        }

        private void RPM_Click(object sender, EventArgs e)
        {
            SelectedButton = RPM;
        }

      
       
    }
}
