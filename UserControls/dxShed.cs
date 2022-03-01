using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGauges.Win.Base;
namespace MachineEyes
{
    public partial class dxShed : DevExpress.XtraEditors.XtraUserControl
    {
        public int ShedIndex;
        public dxShed()
        {
            InitializeComponent();
        }

        private void dxShed_Load(object sender, EventArgs e)
        {

        }

        private void Eff_Val_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void RPM_Val_TextChanged(object sender, EventArgs e)
        {
            double EffVal = Convert.ToDouble(RPM_Val.Tag);
            ((ICircularGauge)this.RPM_GC.Gauges[0]).Scales[0].Value = double.IsNaN(EffVal) == true ? 0 : Convert.ToInt16(EffVal);
        }

        private void LongStops_LabelOnly_Click(object sender, EventArgs e)
        {

        }

        private void LongStops_Electrical_LabelOnly_Click(object sender, EventArgs e)
        {

        }

        private void LongStops_Others_Val_Click(object sender, EventArgs e)
        {

        }

        private void LongStops_BeamShort_Val_Click(object sender, EventArgs e)
        {

        }

        private void RunningEff_TextChanged(object sender, EventArgs e)
        {
            this.RunningEff.ForeColor = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Convert.ToDouble(this.RunningEff.Tag));
            double EffVal = Convert.ToDouble(this.RunningEff.Tag);
            ((ILinearGauge)this.Eff_GC.Gauges[0]).Scales[0].Value = double.IsNaN(EffVal) == true ? 0 : Convert.ToInt16(EffVal);
        }

        private void ShedEfficiency_TextChanged(object sender, EventArgs e)
        {
            this.ShedEfficiency.ForeColor = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Convert.ToDouble(this.ShedEfficiency.Tag));
          
        }

        private void tableLayoutPanel_Section_Paint(object sender, PaintEventArgs e)
        {

        }

       

      
     

     

      

      
    }
}
