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
    public partial class nYarnItemLedger : DevExpress.XtraEditors.XtraUserControl
    {
        public nYarnItemLedger()
        {
            InitializeComponent();
        }

        private void nYarnItemLedger_Load(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
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
            Reports.nYarn_Ledger YLedger = new Reports.nYarn_Ledger();

            YLedger.xr_FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            YLedger.xr_ToDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            string OpeningQuery = "";
            string BalanceQuery = "";
            OpeningQuery = "Select sum(BagsInward)+Sum(BagsReceived)-Sum(BagsOutWard)-Sum(BagsIssued) as BagsBalance,sum(lbsInward)+Sum(lbsReceived)-Sum(lbsOutWard)-Sum(lbsIssued) as LbsBalance from YNQ_Yarn where Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' ";
            BalanceQuery = "Select sum(BagsInward)+Sum(BagsReceived)-Sum(BagsOutWard)-Sum(BagsIssued) as BagsBalance,sum(lbsInward)+Sum(lbsReceived)-Sum(lbsOutWard)-Sum(lbsIssued) as LbsBalance from YNQ_Yarn where Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' ";
            string query = "Select * from YNQ_Yarn where Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' ";
            string YarnSpecs = "";
            if (this.IncludeCommercialSizing.Checked ==false)
            {
                query += " and GodownID <>'06'";
                OpeningQuery +=   " and GodownID <>'06'";
                BalanceQuery += " and GodownID <>'06'";
                YarnSpecs += "Excluding Commerical Sizing A/C ";
            }
            if (BagsType.EditValue != null)
            {
                query += " and YarnBagsType='" + BagsType.EditValue.ToString() + "'";
                OpeningQuery += " and YarnBagsType='" + BagsType.EditValue.ToString() + "'";
                BalanceQuery += " and YarnBagsType='" + BagsType.EditValue.ToString() + "'";
                YarnSpecs += BagsType.EditValue.ToString() + " Bags of ";
            }
           
            if (YarnCount.EditValue != null)
            {
                
                YarnSpecs += " " + YarnCount.EditValue.ToString();
                query += " and YarnCount='" + this.YarnCount.EditValue.ToString() + "'";
                OpeningQuery += " and YarnCount='" + this.YarnCount.EditValue.ToString() + "'";
                BalanceQuery += " and YarnCount='" + this.YarnCount.EditValue.ToString() + "'";
                if (YarnPly.EditValue != null)
                {
                    if (YarnPly.EditValue.ToString() != "")
                    {
                        YarnSpecs += " / " + YarnPly.EditValue.ToString();
                        query += " and YarnPly='" + this.YarnPly.EditValue.ToString() + "'";
                        OpeningQuery += " and YarnPly='" + this.YarnPly.EditValue.ToString() + "'";
                        BalanceQuery += " and YarnPly='" + this.YarnPly.EditValue.ToString() + "'";
                    }
                }
            }
            if (this.YarnPly.EditValue != null)
            {
               
            }
            if (this.YarnBlend.EditValue != null)
            {
                YarnSpecs += " " + YarnBlend.EditValue.ToString();
                query += " and YarnBlend='" + this.YarnBlend.EditValue.ToString() + "'";
                BalanceQuery += " and YarnBlend='" + this.YarnBlend.EditValue.ToString() + "'";
                OpeningQuery += " and YarnBlend='" + this.YarnBlend.EditValue.ToString() + "'";
            }

            if (this.YarnDesc.EditValue != null)
            {
                YarnSpecs += " " + YarnDesc.EditValue.ToString();
                query += " and YarnDesc='" + this.YarnDesc.EditValue.ToString() + "'";
                OpeningQuery += " and YarnDesc='" + this.YarnDesc.EditValue.ToString() + "'";
                BalanceQuery += " and YarnDesc='" + this.YarnDesc.EditValue.ToString() + "'";
            }
           
          
            if (this.YarnBrand.EditValue != null)
            {
                YarnSpecs += " Brand " + this.YarnBrand.EditValue.ToString();
                query += " and YarnBrand='" + this.YarnBrand.EditValue.ToString() + "'";
                OpeningQuery += " and YarnBrand='" + this.YarnBrand.EditValue.ToString() + "'";
                BalanceQuery += " and YarnBrand='" + this.YarnBrand.EditValue.ToString() + "'";
            }
            if (this.Accountof.EditValue != null && this.Accountof.Tag!=null)
            {
                YLedger.Party.Text = this.Accountof.Text;
                query += " and BuyerID='" + this.Accountof.Tag.ToString()+"'";
                OpeningQuery += " and BuyerID='" + this.Accountof.Tag.ToString() + "'";
                BalanceQuery += " and BuyerID='" + this.Accountof.Tag.ToString() + "'";
            }
            DataSet ds = WS.svc.Get_DataSet(query);
            DataSet dsOpening = new DataSet();
            DataSet dsBalance = new DataSet();
            try
            {
                dsOpening= WS.svc.Get_DataSet(OpeningQuery);
            }
            catch
            {
            }
            try
            {
                dsBalance = WS.svc.Get_DataSet(BalanceQuery);
            }
            catch
            {
            }
            YLedger.BeginInit();

            if (ds != null)
                YLedger.DataSource = ds;
            else
                YLedger.DataSource = null;
            if(YarnSpecs!="")
            YLedger.YarnSpecs.Text = YarnSpecs;
            YLedger.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            if (dsOpening != null)
            {
                if (dsOpening.Tables[0].Rows.Count > 0)
                {
                    double Bags = 0;
                    double Lbs = 0;
                    double.TryParse(dsOpening.Tables[0].Rows[0]["BagsBalance"].ToString(), out Bags);
                    double.TryParse(dsOpening.Tables[0].Rows[0]["LbsBalance"].ToString(),out Lbs);
                    YLedger.OpeningBags.Text = Bags.ToString("#,##0.0");
                    YLedger.OpeningLbs.Text = Lbs.ToString("#,##0.00");
                }
            }

            if (dsBalance != null)
            {
                if (dsBalance.Tables[0].Rows.Count > 0)
                {
                    double Bags = 0;
                    double Lbs = 0;
                    double.TryParse(dsBalance.Tables[0].Rows[0]["BagsBalance"].ToString(), out Bags);
                    double.TryParse(dsBalance.Tables[0].Rows[0]["LbsBalance"].ToString(), out Lbs);
                    YLedger.BalanceBags.Text = Bags.ToString("#,##0.0");
                    YLedger.BalanceLbs.Text = Lbs.ToString("#,##0.00");
                }
            }
            YLedger.EndInit();
            YLedger.ShowPreview();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Yarn.ReportingParameters.Yarn_Reports mr = (MachineEyes.Yarn.ReportingParameters.Yarn_Reports)this.Parent.Parent;
            mr.Close();
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
                        this.Accountof.Text = DV.sRow.PrimaryString;
                        this.Accountof.Tag = DV.sRow.PrimeryID;
                    }
                }
            }
        }
    }
}
