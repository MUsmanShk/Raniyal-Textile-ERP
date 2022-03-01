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
    public partial class IP_DailyInspectionQualityWise : DevExpress.XtraEditors.XtraUserControl
    {
        public IP_DailyInspectionQualityWise()
        {
            InitializeComponent();
            this.Dated.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            Reports.Inspection_DailyInspection_QualityWise DailyInspection = new Reports.Inspection_DailyInspection_QualityWise();


            if (this.Dated.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date from which you want to see records", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.Dated.DateTime == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SelectedDate.Date = this.Dated.DateTime;

            string query = "select * from RIP_DailyInspectionWithDetails where Dated='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' ";
            DataSet ds = WS.svc.Get_DataSet(query);


            if (ds == null)
            {
                XtraMessageBox.Show("No records found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (ds.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("No records found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            DailyInspection.BeginInit();
            DailyInspection.repH_Dated.Text = this.Dated.DateTime.ToString("dd-MMM-yyyy");
            DailyInspection.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            DailyInspection.DataSource = ds;
            DailyInspection.EndInit();
            DailyInspection.ShowPreview();
        }

        private void CloseMe_Click(object sender, EventArgs e)
        {
            MachineEyes.Yarn.ReportingParameters.Yarn_Reports mr = (MachineEyes.Yarn.ReportingParameters.Yarn_Reports)this.Parent.Parent;
            mr.Close();
        }
    }
}
