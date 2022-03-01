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
    public partial class dxRange : DevExpress.XtraEditors.XtraUserControl
    {
        public dxRange()
        {
            InitializeComponent();
        }

        private void RangeFrom_ValueChanged(object sender, EventArgs e)
        {
            this.RangeColor.Text = RangeFrom.Value.ToString();
        }

        private void dxRange_Enter(object sender, EventArgs e)
        {
            CurrentSelection.CurrentEfficiencyColor = this.RangeColor;
        }
    }
}
