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
    public partial class YRU_Itemledger_CountBlendDesc : DevExpress.XtraEditors.XtraUserControl
    {
        public YRU_Itemledger_CountBlendDesc()
        {
            InitializeComponent();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Yarn.ReportingParameters.Yarn_Reports mr = (MachineEyes.Yarn.ReportingParameters.Yarn_Reports)this.Parent.Parent;
            mr.Close();
        }

        private void YRU_Itemledger_CountBlendDesc_Load(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
            fc.InOutDepartments(ref this.Department);
            fc.YarnBagsType(ref this.BagsType);
            fc.YarnCounts(ref this.YarnCount);
            fc.YarnDesc(ref this.YarnDesc);
            fc.YarnBlends(ref this.YarnBlend);
            fc.YarnBrands(ref this.YarnBrand);
            TimeSpan ts = new TimeSpan(30, 0, 0, 0);
            this.ToDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            this.FromDate.DateTime = this.ToDate.DateTime.Subtract(ts);

        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            if (this.YarnPly.Text == "")
            {
                XtraMessageBox.Show("Invalid yarn ply", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.Department.EditValue == null)
            {
                XtraMessageBox.Show("Invalid yarn Department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.BagsType.EditValue==null)
            {
                XtraMessageBox.Show("Invalid yarn Bags Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.YarnCount.EditValue == null)
            {
                XtraMessageBox.Show("Invalid yarn Count", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.YarnDesc.EditValue == null)
            {
                XtraMessageBox.Show("Invalid yarn Desc", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.YarnBlend.EditValue == null)
            {
                XtraMessageBox.Show("Invalid yarn Blend ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Reports.Yarn_Ledger_CountBlendDesc Ledger = new Reports.Yarn_Ledger_CountBlendDesc();

                DataSet ds = WS.svc.Get_DataSet("Select sum(BagsIn)-Sum(BagsOut)+Sum(BagsAdj) as BagsBal,Sum(LbsIn)-Sum(LbsOut)+Sum(LbsAdj) as LbsBal from YN_YarnStockDetail where YarnBagsType='" + this.BagsType.EditValue.ToString() + "' and YarnCount='" + this.YarnCount.EditValue.ToString() + "' and YarnPly='" + this.YarnPly.Text + "' and YarnBlend='" + this.YarnBlend.EditValue.ToString() + "' and YarnDesc='" + this.YarnDesc.EditValue.ToString() + "' and InOutDeptID='" + this.Department.EditValue.ToString() + "' and GRNGIN In(select GRNGIN from YN_YarnStock where Dated<'" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "')");
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Ledger.SetYarnOpeningBalance(ds.Tables[0].Rows[0]["BagsBal"].ToString(), ds.Tables[0].Rows[0]["LbsBal"].ToString());
                    }
                }
                string query = "Select * from YNQ_YarnLedger_CountBlendDesc where YarnBagsType='" + this.BagsType.EditValue.ToString() + "' and YarnCount='" + this.YarnCount.EditValue.ToString() + "' and YarnPly='" + this.YarnPly.Text + "' and YarnBlend='" + this.YarnBlend.EditValue.ToString() + "' and YarnDesc='" + this.YarnDesc.EditValue.ToString() + "' and InOutDeptID='" + this.Department.EditValue.ToString() + "' and GRNGIN In(select GRNGIN from YN_YarnStock where Dated>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "')";
                ds = WS.svc.Get_DataSet(query);
                Ledger.BeginInit();


                Ledger.xr_FromDate.Text = this.FromDate.DateTime.ToShortDateString();
                Ledger.xr_ToDate.Text = this.ToDate.DateTime.ToShortDateString();
                Ledger.Department.Text = this.Department.Text;
                Ledger.OpeningLabel.Text = "Opening as on " + this.FromDate.DateTime.ToShortDateString();
                Ledger.YarnSpecs.Text =this.BagsType.EditValue.ToString() +  " Bags of " + this.YarnCount.EditValue.ToString() + "/" + this.YarnPly.Text + " " + this.YarnBlend.EditValue.ToString() + " " + this.YarnDesc.EditValue.ToString();
                
              
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                        Ledger.DataSource = ds;
                    else
                        Ledger.DataSource = null;
                }
                else
                    Ledger.DataSource = null;
                Ledger.EndInit();
                Ledger.ShowPreview();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintLedgerWithBrand_Click(object sender, EventArgs e)
        {
            if (this.YarnPly.Text == "")
            {
                XtraMessageBox.Show("Invalid yarn ply", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.Department.EditValue == null)
            {
                XtraMessageBox.Show("Invalid yarn Department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.BagsType.EditValue == null)
            {
                XtraMessageBox.Show("Invalid yarn Bags Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.YarnCount.EditValue == null)
            {
                XtraMessageBox.Show("Invalid yarn Count", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.YarnDesc.EditValue == null)
            {
                XtraMessageBox.Show("Invalid yarn Desc", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.YarnBlend.EditValue == null)
            {
                XtraMessageBox.Show("Invalid yarn Blend ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.YarnBrand.EditValue == null)
            {
                XtraMessageBox.Show("Invalid yarn Brand ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Reports.Yarn_Ledger_CountBlendDescBrand Ledger = new Reports.Yarn_Ledger_CountBlendDescBrand();

                DataSet ds = WS.svc.Get_DataSet("Select sum(BagsIn)-Sum(BagsOut)+Sum(BagsAdj) as BagsBal,Sum(LbsIn)-Sum(LbsOut)+Sum(LbsAdj) as LbsBal from YN_YarnStockDetail where YarnBagsType='" + this.BagsType.EditValue.ToString() + "' and YarnCount='" + this.YarnCount.EditValue.ToString() + "' and YarnPly='" + this.YarnPly.Text + "' and YarnBlend='" + this.YarnBlend.EditValue.ToString() + "' and YarnDesc='" + this.YarnDesc.EditValue.ToString() + "' and YarnBrand='" + this.YarnBrand.EditValue.ToString() + "' and InOutDeptID='" + this.Department.EditValue.ToString() + "' and GRNGIN In(select GRNGIN from YN_YarnStock where Dated<'" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "')");
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Ledger.SetYarnOpeningBalance(ds.Tables[0].Rows[0]["BagsBal"].ToString(), ds.Tables[0].Rows[0]["LbsBal"].ToString());
                    }
                }
                string query = "Select * from YNQ_YarnLedger_CountBlendDesc where YarnBagsType='" + this.BagsType.EditValue.ToString() + "' and YarnCount='" + this.YarnCount.EditValue.ToString() + "' and YarnPly='" + this.YarnPly.Text + "' and YarnBlend='" + this.YarnBlend.EditValue.ToString() + "' and YarnDesc='" + this.YarnDesc.EditValue.ToString() + "' and YarnBrand='" + this.YarnBrand.EditValue.ToString() + "' and InOutDeptID='" + this.Department.EditValue.ToString() + "' and GRNGIN In(select GRNGIN from YN_YarnStock where Dated>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "')";
                ds = WS.svc.Get_DataSet(query);
                Ledger.BeginInit();


                Ledger.xr_FromDate.Text = this.FromDate.DateTime.ToShortDateString();
                Ledger.xr_ToDate.Text = this.ToDate.DateTime.ToShortDateString();
                Ledger.Department.Text = this.Department.Text;
                Ledger.OpeningLabel.Text = "Opening as on " + this.FromDate.DateTime.ToShortDateString();
                Ledger.YarnSpecs.Text = this.BagsType.EditValue.ToString() + " Bags of " + this.YarnCount.EditValue.ToString() + "/" + this.YarnPly.Text + " " + this.YarnBlend.EditValue.ToString() + " " + this.YarnDesc.EditValue.ToString();
                Ledger.Brand.Text = this.YarnBrand.EditValue.ToString();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                        Ledger.DataSource = ds;
                    else
                        Ledger.DataSource = null;
                }
                else
                    Ledger.DataSource = null;
                Ledger.EndInit();
                Ledger.ShowPreview();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeptLedger_Click(object sender, EventArgs e)
        {
            if (this.Department.EditValue == null)
            {
                XtraMessageBox.Show("Select Department", "Department", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Reports.Yarn_Ledger_DeptPosition YLedger = new Reports.Yarn_Ledger_DeptPosition();

            YLedger.xr_FromDate.Text = this.FromDate.DateTime.ToShortDateString();
            YLedger.xr_ToDate.Text = this.ToDate.DateTime.ToShortDateString();
            YLedger.DeptName.Text = this.Department.Text;
            string query = "Select AccountID,AccountName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn-LbsOut+LbsAdj else 0 end) as Lbs_Opening,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn else 0 end) as Lbs_Received,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOut else 0 end) as Lbs_Issued,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end) as Lbs_Adjusted,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn-LbsOut+LbsAdj else 0 end) +sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn else 0 end)-sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOut else 0 end)+sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end) as Lbs_Balance,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn-BagsOut+BagsAdj else 0 end) as Bags_Opening,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn else 0 end) as Bags_Received,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOut else 0 end) as Bags_Issued,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsAdj else 0 end) as Bags_Adjusted,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn-BagsOut+BagsAdj else 0 end) +sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn else 0 end)-sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOut else 0 end)+sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsAdj else 0 end) as Bags_Balance    from QP_YarnStock where InOutDeptID='" + this.Department.EditValue.ToString() + "' group by  AccountID,AccountName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc ";
            DataSet ds = WS.svc.Get_DataSet(query);

            YLedger.BeginInit();

            if (ds != null)
                YLedger.DataSource = ds;
            else
                YLedger.DataSource = null;

            YLedger.EndInit();
            YLedger.ShowPreview();
        }

        private void StockSummary_Click(object sender, EventArgs e)
        {
            Reports.Yarn_Ledger_GodownPosition YLedger = new Reports.Yarn_Ledger_GodownPosition();

            YLedger.xr_FromDate.Text = this.FromDate.DateTime.ToShortDateString();
            YLedger.xr_ToDate.Text = this.ToDate.DateTime.ToShortDateString();
            
            string query = "Select AccountID,AccountName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn-LbsOut+LbsAdj else 0 end) as Lbs_Opening,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn else 0 end) as Lbs_Received,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOut else 0 end) as Lbs_Issued,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end) as Lbs_Adjusted,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn-LbsOut+LbsAdj else 0 end) +sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn else 0 end)-sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOut else 0 end)+sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end) as Lbs_Balance,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn-BagsOut+BagsAdj else 0 end) as Bags_Opening,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn else 0 end) as Bags_Received,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOut else 0 end) as Bags_Issued,sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsAdj else 0 end) as Bags_Adjusted,sum(case when Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn-BagsOut+BagsAdj else 0 end) +sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn else 0 end)-sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOut else 0 end)+sum(case when Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsAdj else 0 end) as Bags_Balance    from QP_YarnStock where InoutDeptId in(select InOutDeptTypesID from YN_InOutDeptTypes where InOnly=1) group by  AccountID,AccountName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc ";
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
