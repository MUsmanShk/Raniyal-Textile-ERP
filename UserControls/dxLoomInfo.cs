using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGauges.Win.Base;
namespace MachineEyes.UserControls
{
    public partial class dxLoomInfo : DevExpress.XtraEditors.XtraUserControl
    {
       
        public dxLoomInfo()
        {
            InitializeComponent();
        }

        private void dxLoomInfo_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoomNumber.Text = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.LoomName;
                this.LoomNumber.Tag = CurrentSelection.LoomIndex.ToString();
                this.MAC.Text = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.MAC;
                
                this.CurrentState.ImageList = Program.MainWindow.CauseImages;
                State st = (State)Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.Current_State;
                Cause cs = (Cause)Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.Current_Cause;
                this.CurrentState.Text = "State: " + st.ToString();
                if (st != State.Running)
                    this.CurrentState.Text += " Cause: " + cs.ToString();
                this.CurrentState.ImageIndex = (int)Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.Current_Cause;
                ((IDigitalGauge)this.gaugeControl_Efficiency.Gauges[0]).Text = double.IsNaN(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.Current_Eff) == true ? "0.00" : Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.Current_Eff.ToString("#,##0.00");
                ((ICircularGauge)this.gaugeControl_RPM.Gauges[0]).Labels[0].Text = double.IsNaN(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.Current_RPM) == true ? "0" : Convert.ToInt32(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.Current_RPM).ToString("#,##");
                ((ICircularGauge)this.gaugeControl_RPM.Gauges[0]).Scales[0].Value = double.IsNaN(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.Current_RPM) == true ? 0 : Convert.ToInt32(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.Current_RPM);
                this.Shed.Text = Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.ShedID].ShedName;
                this.Shed.Tag = Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.ShedID].ShedID.ToString();
                int TypeIndex = Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.ShedID].ReturnArrayIndex_Types(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.TypeID.ToString());
                if (TypeIndex != -1)
                {
                    this.ModelMake.Text = Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.ShedID].TypesOfLooms[TypeIndex].TypeName;
                    this.ModelMake.Tag = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.TypeID.ToString();
                }
                else
                {
                    this.ModelMake.Text = "";

                }
            }
            catch 
            {
            }
        }

        private void gaugeControl_Efficiency_Click(object sender, EventArgs e)
        {

        }

      
    }
}
