using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Data
{
    public partial class Param_TwoDates : DevExpress.XtraEditors.XtraForm
    {
        public Param_TwoDates()
        {
            InitializeComponent();
            dFrom.EditValue = DateTime.Now;
            dUpto.EditValue = DateTime.Now;
        }

        private void SelectDate_Click(object sender, EventArgs e)
        {
            if (this.dFrom.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Start Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dFrom.Focus();
                return;
            }

            if (this.dUpto.EditValue == null)
            {
                XtraMessageBox.Show("Invalid End Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dUpto.Focus();
                return;
            }


            SelectedDate.Date = this.dFrom.DateTime;
            SelectedDate.upTo = this.dUpto.DateTime;
            SelectedDate.isCanceled = false;
            this.Close();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            SelectedDate.isCanceled = true;
            this.Close();
        }
    }
}