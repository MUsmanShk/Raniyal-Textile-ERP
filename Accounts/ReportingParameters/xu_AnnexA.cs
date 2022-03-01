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
    public partial class xu_AnnexA : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_AnnexA()
        {
            InitializeComponent();
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            Reports.Accounts_AnnexA AnnexA = new Reports.Accounts_AnnexA();


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


            string query = "SELECT    * from Accounts_Purchases_Main where iType='701' and iDate >='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' AND iDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' order by Convert(numeric(18),DocumentNumber)";

            DataSet ds = WS.svc.Get_DataSet(query);




            AnnexA.BeginInit();
            AnnexA.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AnnexA.xr_FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            AnnexA.xr_ToDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            AnnexA.DataSource = ds;
            AnnexA.EndInit();
            AnnexA.ShowPreview();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
            mr.Close();
        }

        private void xu_AnnexA_Load(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(30, 0, 0, 0);
            this.ToDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            this.FromDate.DateTime = this.ToDate.DateTime.Subtract(ts);
        }
    }
}
