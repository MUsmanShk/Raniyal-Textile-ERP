using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.UserControls
{
   
    public partial class dxYarn : DevExpress.XtraEditors.XtraUserControl
    {
        public string DeptID = "";
        public string AccountID = "";
       
        public string GodownID = "";
        public string PONO = "";
        System.ComponentModel.BackgroundWorker debugger = new System.ComponentModel.BackgroundWorker();
        public bool CanChangeSpecs = true;
        public dxYarn()
        {
            InitializeComponent();
            FillCombos fc = new FillCombos();
            fc.YarnCounts(ref Counts);
            fc.YarnPly(ref Ply);
            fc.YarnLbsPerBag(ref LbsPerBag);
            fc.YarnConesPerBag(ref ConesPerBag);
            fc.YarnDesc(ref Desc);
            fc.YarnBlends(ref Blends);
            fc.YarnBagsType(ref BagsType);
            fc.YarnBrands(ref Brand);
            fc.YarnColors(ref Color);
            //debugger.DoWork += new System.ComponentModel.DoWorkEventHandler(DoSyncYarnBalance);
            //debugger.WorkerReportsProgress = false;
            //debugger.WorkerSupportsCancellation = true;
            //debugger.RunWorkerCompleted +=
            //          new RunWorkerCompletedEventHandler(DebuggerWorkerCompleted);

        }
        //private void DoSyncYarnBalance(object sender, DoWorkEventArgs e)
        //{
            
           
        //    //try
        //    //{
        //    //    string query = "Select sum(BagsIn)-Sum(BagsOut)+Sum(BagsAdj) as BagsBal,sum(LbsIn)-Sum(LbsOut)+Sum(LbsAdj) as LbsBal,sum(ConesIn)-Sum(ConesOut)+Sum(ConesAdj) as ConesBal from YN_YarnStockDetail where AccountID='" + AccountID + "' and InOutDeptID='" + DeptID + "' and YarnBagsType='" + this.BagsType.EditValue.ToString() + "' and YarnCount='" + this.Counts.EditValue.ToString() + "' and YarnPly='" + this.Ply.EditValue.ToString() + "' and YarnBlend='" + this.Blends.EditValue.ToString() + "' and YarnBrand='" + this.Brand.EditValue.ToString() + "' and YarnDesc='" + this.Desc.EditValue.ToString() + "'";
        //    //    DataSet ds = WS.svc.Get_DataSet(query);
        //    //    if (ds != null)
        //    //    {
        //    //        if (ds.Tables[0].Rows.Count > 0)
        //    //        {
        //    //            BalBags = ds.Tables[0].Rows[0]["BagsBal"].ToString();
        //    //            BalLbs = ds.Tables[0].Rows[0]["LbsBal"].ToString();
        //    //            BalCones = ds.Tables[0].Rows[0]["ConesBal"].ToString();
        //    //        }
        //    //    }

        //    //}
        //    //catch(Exception ex)
        //    //{
        //    //    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //}

        
        //}
        //private void DebuggerWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        ////    this.AvlBags.EditValue = BalBags;
        ////    this.AvlCones.EditValue = BalCones;
        ////    this.AvlLbs.EditValue = BalLbs;
        //}
        private void TakeAction(KeyEventArgs e)
        {
            if (e.Control == false) return;
            if (CanChangeSpecs == false) return;
            if (e.KeyCode == Keys.Delete)
            {
                if (this.Parent.Controls.Count > 1)
                    this.Parent.Controls.Remove(this);
            }
            else if (e.KeyCode == Keys.Insert)
            {
                UserControls.dxYarn nYarn = new dxYarn();
                nYarn.AccountID = this.AccountID;
                nYarn.DeptID = this.DeptID;
                nYarn.GodownID = this.GodownID;
                nYarn.PONO = this.PONO;
                this.Parent.Controls.Add(nYarn);
            }

            else if (e.KeyCode == Keys.D && e.Control == true)
            {
                if (this.Parent.Controls.Count > 1)
                    this.Parent.Controls.Remove(this);
            }

        }
        private void AutoFillQuantities()
        {

            decimal BagsQuantity = 0;
            decimal LbsQuantity = 0;
            decimal ConesQuantity = 0;
            decimal LbsPerBag = 0;
            decimal ConesPerBag = 0;
            if (this.BagsType.EditValue == null) return;
            if (this.AutoManual.Checked == true) return;
            if (this.Bags.EditValue == null) BagsQuantity = 0;
            else
                decimal.TryParse(this.Bags.EditValue.ToString(), out BagsQuantity);
            if ( this.LbsPerBag.EditValue != null)
            {
                if (this.LbsPerBag.EditValue != null)
                    LbsPerBag = Convert.ToDecimal(this.LbsPerBag.EditValue.ToString());
            }

            if (this.ConesPerBag.EditValue != null)
                ConesPerBag = Convert.ToDecimal(this.ConesPerBag.EditValue.ToString());
            LbsQuantity = BagsQuantity * LbsPerBag;
            Lbs.EditValue = LbsQuantity.ToString();
            ConesQuantity = ConesPerBag * BagsQuantity;
            this.Cones.EditValue = ConesQuantity.ToString();
            this.Lbs.EditValue = LbsQuantity.ToString();
           
        }
        //public void CalcBalance()
        //{
        //    if (DeptID == "") return;
        //    if (AccountID == "") return;
        //    if (this.Counts.EditValue == null) return;
        //    if (this.Ply.EditValue == null) return;
        //    if (this.Blends.EditValue == null) return;
        //    if (this.Brand.EditValue == null) return;
        //    if (this.Desc.EditValue == null) return;
        //    if (this.BagsType.EditValue == null) return;
        //    if (PONO == "") return;
        //    if (GodownID == "") return;
        //    if (debugger.IsBusy == false)
        //    {
        //        try
        //        {
        //            debugger.RunWorkerAsync();

        //        }
        //        catch
        //        {

        //        }
        //    }
        //}
        private void BagsType_EditValueChanged(object sender, EventArgs e)
        {
            AutoFillQuantities();
           
        }

        private void BagsType_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CanChangeSpecs == false) e.Cancel = true;
        }

        private void Counts_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CanChangeSpecs == false) e.Cancel = true;
        }

        private void Ply_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CanChangeSpecs == false) e.Cancel = true;
        }

        private void Blends_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CanChangeSpecs == false) e.Cancel = true;
        }

        private void Brand_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CanChangeSpecs == false) e.Cancel = true;
        }

        private void Desc_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CanChangeSpecs == false) e.Cancel = true;
        }

        private void LbsPerBag_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CanChangeSpecs == false) e.Cancel = true;
        }

        private void ConesPerBag_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (CanChangeSpecs == false) e.Cancel = true;
        }

        private void ActionKeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

       

        private void dxYarn_Load(object sender, EventArgs e)
        {

        }

        private void AutoManual_CheckedChanged(object sender, EventArgs e)
        {
            if (this.AutoManual.Checked == true)
                AutoManual.Text = "Manual Calc.";
            else
                AutoManual.Text = "Auto Calc.";
        }
        public bool CheckAvailabilityOfYarn()
        {
            if (PONO == "")
            {
                XtraMessageBox.Show("invalid PONO", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (GodownID == "")
            {
                XtraMessageBox.Show("invalid Godown / Partition Selection", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Counts.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Yarn Count", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Counts.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Yarn Count", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (this.Ply.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Yarn Ply", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Ply.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Yarn Ply", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (this.Blends.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Yarn Blend", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Blends.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Yarn Blend", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Brand.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Yarn Brand", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Brand.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Yarn Brand", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Desc.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Yarn Description", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Desc.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Yarn Description", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.BagsType.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Yarn Bags Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.BagsType.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Yarn Bags Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            string argPONO = PONO; ;
            if (argPONO == "") return false;
            string argGodownID = "";
            string argYarnBagsType = "";
            string argYarnBlend = "";
            string argYarnBrand = "";
            string argYarnCount = "";
            string argYarnDesc = "";
            string argYarnPly = "";
            argYarnBagsType = this.BagsType.EditValue.ToString();
            argYarnBlend = this.Blends.EditValue.ToString();
            argYarnBrand = this.Brand.EditValue.ToString();
            argYarnCount = this.Counts.EditValue.ToString();
            argYarnDesc = this.Desc.EditValue.ToString();
            argYarnPly = this.Ply.EditValue.ToString();
            argGodownID = GodownID;
            if (argYarnBagsType == "") return false;
            if (argYarnBlend == "") return false;
            if (argYarnBrand == "") return false;
            if (argYarnCount == "") return false;
            if (argYarnDesc == "") return false;
            if (argYarnPly == "") return false;
            if (argGodownID == "") return false;
            double AvailableBags = 0;
            double AvailableLbs = 0;
            double AvailableCones = 0;
       
          
            DataSet ds = WS.svc.Get_DataSet("Select sum(BagsInward)+Sum(BagsReceived)-Sum(BagsOutWard)-Sum(BagsIssued)-Sum(BagsAdj) as BagsBalance,sum(lbsInward)+Sum(lbsReceived)-Sum(lbsOutWard)-Sum(lbsIssued)-Sum(lbsAdj) as LbsBalance,sum(ConesInward)+Sum(ConesReceived)-Sum(ConesOutWard)-Sum(ConesIssued)-Sum(ConesAdj) as ConesBalance from YN_YarnDetail where PONO='" + argPONO + "' and YarnBagsType='" + argYarnBagsType + "' and YarnCount='" + argYarnCount + "' and YarnPly='" + argYarnPly + "' and YarnBrand='" + argYarnBrand + "' and YarnBlend='" + argYarnBlend + "' and YarnDesc='" + argYarnDesc + "' and GodownID='" + argGodownID + "'");
            if (ds == null)
            {
                XtraMessageBox.Show("Data set returned null value , please check connection ....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            this.AvlBags.EditValue = ds.Tables[0].Rows[0]["BagsBalance"].ToString();
            
            this.AvlLbs.EditValue = ds.Tables[0].Rows[0]["LbsBalance"].ToString();
            double.TryParse(ds.Tables[0].Rows[0]["BagsBalance"].ToString(), out AvailableBags);
            double.TryParse(ds.Tables[0].Rows[0]["LbsBalance"].ToString(), out AvailableLbs);
            double.TryParse(ds.Tables[0].Rows[0]["ConesBalance"].ToString(), out AvailableCones);

           

         

          
           
           
          
           
            return true;
        }
        private void CheckStock_Click(object sender, EventArgs e)
        {
            CheckAvailabilityOfYarn();
        }
    }
}
