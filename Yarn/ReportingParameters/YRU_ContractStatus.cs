using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Yarn.ReportingParameters
{
    public partial class YRU_ContractStatus : DevExpress.XtraEditors.XtraUserControl
    {
        public YRU_ContractStatus()
        {
            InitializeComponent();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Yarn.ReportingParameters.Yarn_Reports mr = (MachineEyes.Yarn.ReportingParameters.Yarn_Reports)this.Parent.Parent;
            mr.Close();
        }

        private void YRU_ContractStatus_Load(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(30, 0, 0, 0);
            this.ToDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            this.FromDate.DateTime = this.ToDate.DateTime.Subtract(ts);
        }

        private void ContractSummary_Click(object sender, EventArgs e)
        {
            Reports.Yarn_YarnContracts YLedger = new Reports.Yarn_YarnContracts();

            YLedger.xr_FromDate.Text = this.FromDate.DateTime.ToShortDateString();
            YLedger.xr_ToDate.Text = this.ToDate.DateTime.ToShortDateString();

            string query = "Select * from qyn_YarnContracts where ContractDate>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and ContractDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  order by ContractDate,Convert(Numeric(18,0),yarnContractNumber)";

            DataSet ds = WS.svc.Get_DataSet(query);

            YLedger.BeginInit();

            if (ds != null)
                YLedger.DataSource = ds;
            else
                YLedger.DataSource = null;

            YLedger.EndInit();
            YLedger.ShowPreview();
        }

       
    }
}
