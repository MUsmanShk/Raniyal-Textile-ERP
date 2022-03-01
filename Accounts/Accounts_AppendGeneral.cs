using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MachineEyes.Classes;

namespace MachineEyes.Accounts
{
   
    public partial class Accounts_AppendGeneral : DevExpress.XtraEditors.XtraForm
    {
        public easyVoucherCalculations vCalc = new easyVoucherCalculations();
        public Accounts_AppendGeneral()
        {
            InitializeComponent();
            vCalc.controls_Difference = this.Difference;
            vCalc.controls_MultiTotal = this.DebitTotal;
            vCalc.controls_SingleTotal = this.CreditTotal;
            UserControls.AccountGeneral General = new UserControls.AccountGeneral();
            General.eVC = vCalc;
            this.tableLayoutPanel_Detail.Controls.Add(General);
        }
        public UserControls.AccountGeneral AddControl()
        {
            vCalc.controls_Difference = this.Difference;
            vCalc.controls_MultiTotal = this.DebitTotal;
            vCalc.controls_SingleTotal = this.CreditTotal;
            UserControls.AccountGeneral General = new UserControls.AccountGeneral();
            General.eVC = vCalc;
            this.tableLayoutPanel_Detail.Controls.Add(General);
            return General;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Accounts_AppendGeneral_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Hide();
        }

        private void Accounts_AppendGeneral_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}