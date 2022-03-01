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
    public partial class dxTypeEff : DevExpress.XtraEditors.XtraUserControl
    {
        public int ShedIndex;
        public dxTypeEff()
        {
            InitializeComponent();
        }

        private void Efficiency_TextChanged(object sender, EventArgs e)
        {
            RunningEfficiency.ForeColor = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Convert.ToDouble(this.RunningEfficiency.Tag));
        }

        private void RPM_Click(object sender, EventArgs e)
        {

        }
    }
}
