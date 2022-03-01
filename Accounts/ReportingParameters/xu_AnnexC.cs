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
    public partial class xu_AnnexC : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_AnnexC()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
            mr.Close();
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            Reports.Accounts_AnnexC AnnexC = new Reports.Accounts_AnnexC();

           
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


            string query = "SELECT    * from Accounts_Sales_Main where iType='901' and iDate >='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' AND iDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' order by Convert(numeric(18),DocumentNumber)";

            DataSet ds = WS.svc.Get_DataSet(query);



            
            AnnexC.BeginInit();
            AnnexC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AnnexC.xr_FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            AnnexC.xr_ToDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            AnnexC.DataSource = ds;
            AnnexC.EndInit();
            AnnexC.ShowPreview();
        }

       
    }
}
