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
    public partial class nYarnGodownWiseStockSummary : DevExpress.XtraEditors.XtraUserControl
    {
        public nYarnGodownWiseStockSummary()
        {
            InitializeComponent();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Yarn.ReportingParameters.Yarn_Reports mr = (MachineEyes.Yarn.ReportingParameters.Yarn_Reports)this.Parent.Parent;
            mr.Close();
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {

            Reports.nYarn_PartyWiseStock_GodownPosition YLedger = new Reports.nYarn_PartyWiseStock_GodownPosition();

            if (this.Godown.EditValue == null)
            {
                XtraMessageBox.Show("Invalid weaving department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.Godown.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid weaving department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.FromDate.DateTime == null)
            {
                XtraMessageBox.Show("invalid date, please enter valid date for stock ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.FromDate.Focus();
                return;
            }
            if (this.ToDate.DateTime == null)
            {
                XtraMessageBox.Show("invalid date, please enter valid date for stock ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.ToDate.Focus();
                return;
            }
            if (this.FromDate.EditValue == null)
            {
                XtraMessageBox.Show("invalid date, please enter valid date for stock ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.ToDate.Focus();
                return;
            }
            if (this.ToDate.EditValue == null)
            {
                XtraMessageBox.Show("invalid date, please enter valid date for stock ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.ToDate.Focus();
                return;
            }

            SelectedDate.Date = this.FromDate.DateTime;
            SelectedDate.upTo = this.ToDate.DateTime;
            YLedger.xr_FromDate.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            YLedger.xr_ToDate.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");
            YLedger.DepartmentLabel.Text = "Partition";
            YLedger.DeparmentName.Text = this.Godown.Text;
            YLedger.RepH_DocumentName.Text = "Godown / Partition Stock Summary";
            YLedger.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            string query = "Select BuyerID,BuyerName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,sum(case when Dated<'" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsInward-LbsOutward+LbsReceived-LbsIssued else 0 end) as Lbs_Opening,sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsReceived else 0 end) as Lbs_Received,sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIssued else 0 end) as Lbs_Issued,sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsInward else 0 end) as Lbs_Inward,sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOutward else 0 end) as Lbs_Outward,sum(case when Dated<'" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsReceived-LbsIssued+LbsInward-LbsOutward else 0 end) +sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsReceived else 0 end)-sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIssued else 0 end)+sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsInward else 0 end) -sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOutward else 0 end) as Lbs_Balance,sum(case when Dated<'" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsInward-BagsOutward+BagsReceived-BagsIssued else 0 end) as Bags_Opening,sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsReceived else 0 end) as Bags_Received,sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIssued else 0 end) as Bags_Issued,sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsInward else 0 end) as Bags_Inward,sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOutward else 0 end) as Bags_Outward,sum(case when Dated<'" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsReceived-BagsIssued+BagsInward-BagsOutward else 0 end) +sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsReceived else 0 end)-sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIssued else 0 end)+sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsInward else 0 end) -sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOutward else 0 end) as Bags_Balance     from YNQ_Yarn where GodownID='" + this.Godown.EditValue.ToString() + "'  group by  BuyerId,BuyerName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc ";
            DataSet ds = WS.svc.Get_DataSet(query);
           

            YLedger.BeginInit();

            if (ds != null)
            {
                if (ZeroBalance.Checked == false)
                    ds.Tables[0].DefaultView.RowFilter = "Bags_Balance<>0";
                YLedger.DataSource = ds;
            }
            else
                YLedger.DataSource = null;

            YLedger.EndInit();
            YLedger.ShowPreview();
        }

        private void nYarnGodownWiseStockSummary_Load(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
            fc.YarnGodowns(ref this.Godown);
        }
    }
}
