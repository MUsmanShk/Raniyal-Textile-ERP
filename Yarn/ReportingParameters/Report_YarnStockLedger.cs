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
    public partial class Report_YarnStockLedger : DevExpress.XtraEditors.XtraForm
    {
        public Report_YarnStockLedger()
        {
            InitializeComponent();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (Accountof.Tag == null)
            {
                XtraMessageBox.Show("Select Valid Account", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateFrom.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date from which you want to see ledger records", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateTo.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective To Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (RadioTypeofReport.EditValue.ToString() == "L")
            {
                Reports.YarnStockLedger YLedger = new Reports.YarnStockLedger();

                YLedger.xr_FromDate.Text = Convert.ToDateTime(DateFrom.EditValue).ToString("dd/MM/yyyy");
                YLedger.xr_ToDate.Text = Convert.ToDateTime(DateTo.EditValue).ToString("dd/MM/yyyy");
                YLedger.Account.Text = this.Accountof.Text;
                string query = "Select InOutSubTypeID,InOutSubTypesName,InOutDeptID,InOutDeptTypesName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,sum(case when Dated<'" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn-LbsOut+LbsAdj else 0 end) as Lbs_Opening,sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn else 0 end) as Lbs_Received,sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOut else 0 end) as Lbs_Issued,sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end) as Lbs_Adjusted,sum(case when Dated<'" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn-LbsOut+LbsAdj else 0 end) +sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn else 0 end)-sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOut else 0 end)+sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end) as Lbs_Balance   from QP_YarnStock where Accountid='" + this.Accountof.Tag.ToString() + "' group by  InOutSubTypeID,InOutSubTypesName,InOutDeptID,InOutDeptTypesName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc ";
                DataSet ds = WS.svc.Get_DataSet(query);

                YLedger.BeginInit();

                if (ds != null)
                    YLedger.DataSource = ds;
                else
                    YLedger.DataSource = null;

                YLedger.EndInit();
                YLedger.ShowPreview();
            }
            else if (RadioTypeofReport.EditValue.ToString() == "B")
            {
                Reports.YarnStockLedgerWithBags YLedger = new Reports.YarnStockLedgerWithBags();

                YLedger.xr_FromDate.Text = Convert.ToDateTime(DateFrom.EditValue).ToString("dd/MM/yyyy");
                YLedger.xr_ToDate.Text = Convert.ToDateTime(DateTo.EditValue).ToString("dd/MM/yyyy");
                YLedger.Account.Text = this.Accountof.Text;
                string query = "Select InOutSubTypeID,InOutSubTypesName,InOutDeptID,InOutDeptTypesName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,sum(case when Dated<'" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn-LbsOut+LbsAdj else 0 end) as Lbs_Opening,sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn else 0 end) as Lbs_Received,sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOut else 0 end) as Lbs_Issued,sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end) as Lbs_Adjusted,sum(case when Dated<'" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn-LbsOut+LbsAdj else 0 end) +sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn else 0 end)-sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOut else 0 end)+sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end) as Lbs_Balance,sum(case when Dated<'" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn-BagsOut+BagsAdj else 0 end) as Bags_Opening,sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn else 0 end) as Bags_Received,sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOut else 0 end) as Bags_Issued,sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsAdj else 0 end) as Bags_Adjusted,sum(case when Dated<'" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn-BagsOut+BagsAdj else 0 end) +sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn else 0 end)-sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOut else 0 end)+sum(case when Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsAdj else 0 end) as Bags_Balance    from QP_YarnStock where Accountid='" + this.Accountof.Tag.ToString() + "' group by  InOutSubTypeID,InOutSubTypesName,InOutDeptID,InOutDeptTypesName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc ";
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

        private void BrowseAccountof_Click(object sender, EventArgs e)
        {
            selectedrow sRow = new selectedrow();
            Data.Data_View DV = new Data_View();
            DV.Load_View("select AccountID,AccountName,MailingAddress,ConcernedPerson1,ConcernedPerson2 from PP_Accounts order by AccountName", "AccountID", "AccountName");
            DV.sRow = sRow;
            DV.ShowDialog();
            if (DV.sRow != null)
            {
                if (DV.sRow.Status == ParameterStatus.Selected)
                {
                    this.Accountof.Text = DV.sRow.PrimaryString;
                    this.Accountof.Tag = DV.sRow.PrimeryID;
                }
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Report_YarnStockLedger_Load(object sender, EventArgs e)
        {
            TimeSpan ts=new TimeSpan(30,0,0,0);
            this.DateFrom.EditValue = DateTime.Now.Subtract(ts);
            this.DateTo.EditValue = DateTime.Now;
        }

        private void Ledger_Click(object sender, EventArgs e)
        {
            if (Accountof.Tag == null)
            {
                XtraMessageBox.Show("Select Valid Account", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateFrom.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date from which you want to see ledger records", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateTo.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective To Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Reports.Yarn_Ledger YLedger = new Reports.Yarn_Ledger();

            YLedger.xr_FromDate.Text = Convert.ToDateTime(DateFrom.EditValue).ToString("dd/MM/yyyy");
            YLedger.xr_ToDate.Text = Convert.ToDateTime(DateTo.EditValue).ToString("dd/MM/yyyy");
            YLedger.Account.Text = this.Accountof.Text;
            // YLedger.xr_Accountof.Text = Accountof.Tag.ToString();
            // YLedger.xr_AccountofName.Text = Accountof.Text;
            string query = "Select *  from QP_YarnStock where Accountid='" + this.Accountof.Tag.ToString() + "' and Dated>='" + DateFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + DateTo.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' order by Dated,Convert(numeric(18,0),GRNGIN) ";
            DataSet ds = WS.svc.Get_DataSet(query);

            YLedger.BeginInit();

            if (ds != null)
                YLedger.DataSource = ds;
            else
                YLedger.DataSource = null;

            YLedger.EndInit();
            YLedger.ShowPreview();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RadioPageSetting_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}