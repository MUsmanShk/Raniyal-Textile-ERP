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
    public partial class YarnStockSummary_SelectedType : DevExpress.XtraEditors.XtraUserControl
    {
        public YarnStockSummary_SelectedType()
        {
            InitializeComponent();
            this.FromDate.DateTime = DateTime.Now;
            this.ToDate.DateTime = DateTime.Now;
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            if (this.YarnInOutTypes.EditValue == null)
            {
                XtraMessageBox.Show("Select Type", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.FromDate.DateTime == null || this.ToDate.DateTime ==null)
            {
                XtraMessageBox.Show("invalid date", "Error", MessageBoxButtons.OK);
                return;
            }
           
            Reports.YarnLedger_GodownPosition_SelectedType YLedger = new Reports.YarnLedger_GodownPosition_SelectedType();

            YLedger.xr_FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            YLedger.xr_ToDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            YLedger.InOutType.Text = this.YarnInOutTypes.Text;
            string query = "Select AccountID,AccountName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn-LbsOut+LbsAdj else 0 end) as Lbs_Opening,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn else 0 end) as Lbs_Received,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOut else 0 end) as Lbs_Issued,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end) as Lbs_Adjusted,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn-LbsOut+LbsAdj else 0 end) +sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn else 0 end)-sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOut else 0 end)+sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end) as Lbs_Balance,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn-BagsOut+BagsAdj else 0 end) as Bags_Opening,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn else 0 end) as Bags_Received,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOut else 0 end) as Bags_Issued,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsAdj else 0 end) as Bags_Adjusted,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn-BagsOut+BagsAdj else 0 end) +sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn else 0 end)-sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOut else 0 end)+sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsAdj else 0 end) as Bags_Balance    from QP_YarnStock where InoutDeptId in(select InOutDeptTypesID from YN_InOutDeptTypes where InOnly=1) and InOutTypeID='"+this.YarnInOutTypes.EditValue.ToString()+"' group by  AccountID,AccountName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc ";
            DataSet ds = WS.svc.Get_DataSet(query);

            YLedger.BeginInit();
            ds.Tables[0].DefaultView.RowFilter = "Lbs_Balance>0";
            if (ds != null)
                YLedger.DataSource = ds;
            else
                YLedger.DataSource = null;

            YLedger.EndInit();
            YLedger.ShowPreview();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Yarn.ReportingParameters.Yarn_Reports mr = (MachineEyes.Yarn.ReportingParameters.Yarn_Reports)this.Parent.Parent;
            mr.Close();
        }

        private void YarnStockSummary_SelectedType_Load(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
            fc.InOutTypes(ref this.YarnInOutTypes);
        }
    }
}
