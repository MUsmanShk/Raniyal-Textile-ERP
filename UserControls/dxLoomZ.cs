using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.UserControls
{
    public partial class dxLoomZ : DevExpress.XtraEditors.XtraUserControl
    {
        public int ShedIndex;
        public dxLoomZ()
        {
            InitializeComponent();
           
        }

        private void dxLoomZ_Enter(object sender, EventArgs e)
        {
            CurrentSelection.SelectedControl = this;
        }

        private void Efficiency_Click(object sender, EventArgs e)
        {
           
        }
    }
}
