using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Accounts.ReportingParameters
{
    public partial class xu_AnnexI_DebitNote : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_AnnexI_DebitNote()
        {
            InitializeComponent();
        }

        private void Closeit_Click(object sender, EventArgs e)
        {
            MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
            mr.Close();
        }

        private void xu_AnnexI_DebitNote_Load(object sender, EventArgs e)
        {
            this.FromDate.DateTime = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0));
            this.ToDate.DateTime = DateTime.Now;
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {

            Reports.Accounts_AnnexI_DebitNote AnnexI = new Reports.Accounts_AnnexI_DebitNote();


            if (this.FromDate.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date from which you want to see ledger records", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.ToDate.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective To Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string query = "SELECT    * from Accounts_Purchases_Main where iType='702' and iDate >='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' AND iDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' order by Convert(numeric(18),DocumentNumber)";

            DataSet ds = WS.svc.Get_DataSet(query);




            AnnexI.BeginInit();
            AnnexI.xr_FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            AnnexI.xr_ToDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            AnnexI.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AnnexI.DataSource = ds;
            AnnexI.EndInit();
            AnnexI.ShowPreview();
        }
    }
}
