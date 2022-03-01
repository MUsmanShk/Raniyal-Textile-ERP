using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MachineEyes
{
    public partial class dxYarnCountTwistBlend : DevExpress.XtraEditors.XtraUserControl
    {
       

        public dxYarnCountTwistBlend()
        {
            InitializeComponent();
            FillCombos fc = new FillCombos();
            fc.YarnCounts(ref Counts);
            fc.YarnColors(ref Color);
            fc.YarnBlends(ref Blends);
            fc.YarnPly(ref Ply);
            fc.YarnDesc(ref Desc);
        }
       
        private void Refresh_Click(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
            fc.YarnCounts(ref Counts);
            fc.YarnColors(ref Color);
            fc.YarnBlends(ref Blends);
            fc.YarnPly(ref Ply);
            fc.YarnDesc(ref Desc);
        }

       
    }
}
