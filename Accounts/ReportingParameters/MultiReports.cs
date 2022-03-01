using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Accounts.ReportingParameters
{
    public partial class MultiReports : DevExpress.XtraEditors.XtraForm
    {
        public MultiReports()
        {
            InitializeComponent();
        }

        private void MultiReports_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        public void ShutDown()
        {
            this.Close();
        }
    }
}