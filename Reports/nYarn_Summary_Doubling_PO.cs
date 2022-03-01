using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class nYarn_Summary_Doubling_PO : DevExpress.XtraReports.UI.XtraReport
    {
        
        int indexno = 0;
        public nYarn_Summary_Doubling_PO()
        {
            InitializeComponent();
        }
       

       

      


     

     
      

        private void xrIndex_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexno++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = indexno.ToString();
        }

      

       
    }
}
