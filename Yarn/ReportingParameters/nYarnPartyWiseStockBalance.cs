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
    public partial class nYarnPartyWiseStockBalance : DevExpress.XtraEditors.XtraUserControl
    {
        public nYarnPartyWiseStockBalance()
        {
            InitializeComponent();
            
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {

            if (this.Accountof.Tag == null)
            {
                XtraMessageBox.Show("Invalid Account ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Accountof.Focus();
                return;
            }

            if (this.Accountof.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Account ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Accountof.Focus();
                return;
            }
            if (this.Accountof.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Accountof.Focus();
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


            Reports.nYarn_Ledger_GodownPosition YLedger = new Reports.nYarn_Ledger_GodownPosition();

            YLedger.xr_FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            YLedger.xr_ToDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
          
            YLedger.AccountName.Text = this.Accountof.Text;
            YLedger.AccountID.Text = this.Accountof.Tag.ToString();
            string query = "Select PONO,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsInward-LbsOutward+LbsReceived-LbsIssued else 0 end) as Lbs_Opening,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsReceived else 0 end) as Lbs_Received,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIssued else 0 end) as Lbs_Issued,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsInward else 0 end) as Lbs_Inward,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOutward else 0 end) as Lbs_Outward,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsReceived-LbsIssued+LbsInward-LbsOutward else 0 end) +sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsReceived else 0 end)-sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIssued else 0 end)+sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsInward else 0 end) -sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOutward else 0 end) as Lbs_Balance,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsInward-BagsOutward+BagsReceived-BagsIssued else 0 end) as Bags_Opening,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsReceived else 0 end) as Bags_Received,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIssued else 0 end) as Bags_Issued,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsInward else 0 end) as Bags_Inward,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOutward else 0 end) as Bags_Outward,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsReceived-BagsIssued+BagsInward-BagsOutward else 0 end) +sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsReceived else 0 end)-sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIssued else 0 end)+sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsInward else 0 end) -sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOutward else 0 end) as Bags_Balance     from YNQ_Yarn where BuyerID='" + this.Accountof.Tag.ToString() + "' group by  PONO,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc ";
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

        private void Accountof_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                selectedrow sRow = new selectedrow();
                Data.Data_View DV = new Data.Data_View();
                DV.Load_View("select AccountID,AccountName,MailingAddress,ConcernedPerson1,ConcernedPerson2 from PP_Accounts order by AccountName", "AccountID", "AccountName");
                DV.sRow = sRow;
                DV.ShowDialog();
                if (DV.sRow != null)
                {
                    if (DV.sRow.Status == ParameterStatus.Selected)
                    {
                        this.Accountof.EditValue = DV.sRow.PrimaryString;
                        this.Accountof.Tag = DV.sRow.PrimeryID;
                    }
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                this.Accountof.Text = "";
                this.Accountof.Tag = null;
                this.Accountof.EditValue = null;
            }
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Yarn.ReportingParameters.Yarn_Reports mr = (MachineEyes.Yarn.ReportingParameters.Yarn_Reports)this.Parent.Parent;
            mr.Close();
        }
    }
}
