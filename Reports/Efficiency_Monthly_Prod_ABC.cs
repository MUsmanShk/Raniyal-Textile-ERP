using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Efficiency_Monthly_ABC : DevExpress.XtraReports.UI.XtraReport
    {
        public Efficiency_Monthly_ABC()
        {
            InitializeComponent();
        }
        public XRControl   GetXRControlByName(string argLabelName)
        {
            foreach (XRControl    c in fXRControls)
            {
                foreach (XRControl xrc in c)
                {
                    if (xrc.Name == argLabelName)
                        return xrc;
                }
            }
            return null; 
        }
    }
}
