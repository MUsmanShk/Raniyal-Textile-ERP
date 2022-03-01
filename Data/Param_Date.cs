using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes
{
    public partial class Param_Date : DevExpress.XtraEditors.XtraForm
    {
        public Param_Date()
        {
            InitializeComponent();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSelectDate_Click(object sender, EventArgs e)
        {
            SelectedDate.Date = this.monthCalendar1.SelectionStart;
            SelectedDate.isCanceled = false;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedDate.isCanceled = true;
            this.Close();
        }
    }
}