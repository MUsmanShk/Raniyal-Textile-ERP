using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Accounts
{
    public partial class Account_info : DevExpress.XtraEditors.XtraForm
    {
        public Account_info()
        {
            InitializeComponent();
        }
        public void FillAccount(string argAccountID_V)
        {
            MachineEyes.Classes.Account ac = new Classes.Account();
            ac = MachineEyes.Classes.Accounting.Get_Account_ByAccountID_V(argAccountID_V);
            if (ac != null)
            {
                this.AccountID_I.Text = ac.AccountID_I;
                this.AccountID_II.Text = ac.AccountID_II;
                this.AccountID_III.Text = ac.AccountID_III;
                this.AccountID_IV.Text = ac.AccountID_IV;
                this.AccountID_V.Text = ac.AccountID_V;
                this.AccountName_I.Text = ac.AccountName_I;
                this.AccountName_II.Text = ac.AccountName_II;
                this.AccountName_III.Text = ac.AccountName_III;
                this.AccountName_IV.Text = ac.AccountName_IV;
                this.AccountName_V.Text = ac.AccountName_V;
            }
        }

        private void Account_info_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Close_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}