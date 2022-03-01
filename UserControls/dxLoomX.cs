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
    public partial class dxLoomX : DevExpress.XtraEditors.XtraUserControl
    {
        public int ShedIndex;
        public dxLoomX()
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

      
        private void LoomNumber_Click(object sender, EventArgs e)
        {
            this.popupMenu1.MenuCaption = "Loom # " + this.LoomNumber.Text;
            CurrentSelection.LoomIndex = Convert.ToInt32(this.LoomNumber.Tag);
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.ShedID.ToString());
            CurrentSelection.ShedIndex = ShedIndex;
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

        private void Efficiency_TextChanged(object sender, EventArgs e)
        {
            Efficiency.ForeColor = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Convert.ToDouble(this.Efficiency.Tag));
        }

        private void dxLoomX_Enter(object sender, EventArgs e)
        {
            CurrentSelection.SelectedControl = this;
            if (ControlMover.Mode == ControlMover.vMode.Move)
            { this.Width = 75+10; this.Height = 38+10; }
        }

        private void dxLoomX_Leave(object sender, EventArgs e)
        {
            if (ControlMover.Mode == ControlMover.vMode.Move)
            { this.Width = 75; this.Height = 38; }
        }

        private void Efficiency_Enter(object sender, EventArgs e)
        {
            if (ControlMover.Mode == ControlMover.vMode.Move)
            { this.Width =75+ 10; this.Height = 38 + 10; }
        }

        private void Efficiency_Leave(object sender, EventArgs e)
        {
            if (ControlMover.Mode == ControlMover.vMode.Move)
            { this.Width =75; this.Height = 38; }
        }

        private void dxLoomX_Load(object sender, EventArgs e)
        {
          
           //this.Efficiency.ImageList =(ImageList) Program.MainWindow.CauseImages;
        }

        private void Efficiency_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.popupMenu1.MenuCaption = "Loom # " + this.LoomNumber.Text;
                CurrentSelection.LoomIndex = Convert.ToInt32(this.LoomNumber.Tag);
                int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.ShedID.ToString());
                CurrentSelection.ShedIndex = ShedIndex;
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
        }
    }
}
