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
    public partial class Data_DocStates : DevExpress.XtraEditors.XtraForm
    {
        public docState dState;
        public Data_DocStates()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void Select_Click(object sender, EventArgs e)
        {
            if (this.radioStates.EditValue != null) 
          dState=(docState)Convert.ToInt16(this.radioStates.EditValue);
            this.Close();
        }
    }
}