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
    public partial class frmWait : DevExpress.XtraEditors.XtraForm
    {
        DateTime nTime;
        public frmWait()
        {
            InitializeComponent();
            nTime = DateTime.Now;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString();
            Program.ss.Machines.debugTimer.Enabled = false;
            Program.ss.Machines.webServiceTimer.Enabled = false;
            try
            {
                foreach (DevExpress.XtraEditors.XtraForm form1 in Application.OpenForms)
                {
                    form1.Close();
                }


            }
            catch
            {

            }
            if (DateTime.Now.Subtract(nTime).TotalSeconds >= 15 && Settings.Exit==true)
            {
                nTime = DateTime.Now;
                Application.Exit();
            }
        }

        private void frmWait_Activated(object sender, EventArgs e)
        {
            Program.ss.Machines.debugTimer.Enabled = false;
            Program.ss.Machines.webServiceTimer.Enabled = false;
            try
            {
                foreach (DevExpress.XtraEditors.XtraForm form1 in Application.OpenForms)
                {
                    form1.Close();
                }


            }
            catch
            {

            }
            Application.Exit();
        }
    }
}