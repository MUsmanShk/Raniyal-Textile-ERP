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
    public partial class dxWeaverEff : DevExpress.XtraEditors.XtraUserControl
    {
        public int ShedIndex;
        public dxWeaverEff()
        {
            InitializeComponent();
        }

        private void WeaverEff_TextChanged(object sender, EventArgs e)
        {
            WeaverEff.ForeColor = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnColor(ColorCauses.WeaversEfficiency, Convert.ToDouble(this.WeaverEff.Tag));
            this.IndexNumber.ForeColor = WeaverEff.ForeColor;
            this.WeaverName.ForeColor = WeaverEff.ForeColor;
            this.Looms.ForeColor = WeaverEff.ForeColor;
            this.AvgWarpKnott.ForeColor = WeaverEff.ForeColor;
            this.AvgWeftKnott.ForeColor = WeaverEff.ForeColor;
        }

        private void AvgWeftKnott_TextChanged(object sender, EventArgs e)
        {
           // AvgWeftKnott.ForeColor = Program.ss.Machines.PresentationData.ReturnColor(ColorCauses.AvgWeftKnotTime, Convert.ToDouble(this.AvgWeftKnott.Tag));
        }

        private void AvgWarpKnott_TextChanged(object sender, EventArgs e)
        {
            //AvgWarpKnott.ForeColor = Program.ss.Machines.PresentationData.ReturnColor(ColorCauses.AvgWarpKnotTime, Convert.ToDouble(this.AvgWarpKnott.Tag));
        }
    }
}
