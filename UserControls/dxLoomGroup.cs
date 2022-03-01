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
    public partial class dxLoomGroup : DevExpress.XtraEditors.XtraUserControl
    {
        public int ShedIndex;
        public dxLoomGroup()
        {
            InitializeComponent();
        }

        private void Weaver_Enter(object sender, EventArgs e)
        {
            if (ControlMover.Mode == ControlMover.vMode.Move)
            { this.Width = 152+15; this.Height = 115+15; }
        }

        private void dxLoomGroup_Enter(object sender, EventArgs e)
        {
            if (ControlMover.Mode == ControlMover.vMode.Move)
            { this.Width = 152 + 15; this.Height = 115 +15; }
        }

        private void dxLoomGroup_Leave(object sender, EventArgs e)
        {
            if (ControlMover.Mode == ControlMover.vMode.Move)
            { this.Width = 152; this.Height = 115 ; }
        }

        private void Weaver_Leave(object sender, EventArgs e)
        {
            if (ControlMover.Mode == ControlMover.vMode.Move)
            { this.Width = 152 ; this.Height = 115; }
        }

        private void Weaver_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CurrentSelection.ShedIndex = ShedIndex;
                CurrentSelection.CurrentGroupIndex = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnArrayIndex_LoomGroup(Convert.ToInt32(this.Tag.ToString()));
                Data_Assign_Weaver AssignWeaver = new Data_Assign_Weaver();
                AssignWeaver.Text = "Assign Weavers to Group";
                AssignWeaver.ShowDialog(this);
                if (Program.ss.Machines.PresentationData.CurrentShift.WShift == "A")
                    Weaver.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverName_A;
                else if (Program.ss.Machines.PresentationData.CurrentShift.WShift == "B")
                    Weaver.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverName_B;
                else if (Program.ss.Machines.PresentationData.CurrentShift.WShift == "C")
                    Weaver.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverName_C;
            }
            catch
            {
            }
        }

        private void WeaverEfficiency_TextChanged(object sender, EventArgs e)
        {
            WeaverEfficiency.ForeColor = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnColor(ColorCauses.WeaversEfficiency, Convert.ToDouble(this.WeaverEfficiency.Tag));
        }

        private void Efficiency_5_TextChanged(object sender, EventArgs e)
        {
            SimpleButton Eff = (SimpleButton)sender;
            Eff.ForeColor = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Convert.ToDouble(Eff.Tag));
        }

        private void WarpKnottTime_TextChanged(object sender, EventArgs e)
        {

            WarpKnottTime.ForeColor = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnColor(ColorCauses.AvgWarpKnotTime, Convert.ToDouble(WarpKnottTime.Tag));
        }

        private void WeftKnottTime_TextChanged(object sender, EventArgs e)
        {
            WeftKnottTime.ForeColor = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnColor(ColorCauses.AvgWeftKnotTime, Convert.ToDouble(WeftKnottTime.Tag));
        }

        private void Weaver_Click(object sender, EventArgs e)
        {

        }

       
    }
}
