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
    
    public partial class dxYarnWarpingAfter : DevExpress.XtraEditors.XtraUserControl
    {
        FillCombos fc = new FillCombos();
        public double Length=0;
        public double EndsTotalWarpBeams = 0;
        public double EnglishCount = 0;
        public dxYarnWarpingAfter()
        {
            InitializeComponent();
            
            fc.YarnCounts(ref Counts);
            fc.YarnPly(ref Ply);
            fc.YarnLbsPerBag(ref LbsPerBag);
            fc.YarnConesPerBag(ref ConesPerBag);
            fc.YarnDesc(ref Desc);
            fc.YarnBlends(ref Blends);
            fc.YarnBagsType(ref BagsType);
            fc.YarnBrands(ref Brand);
            fc.EmptyYarnConeWeight(ref EmptyConesWeight);
            fc.EmptyYarnBagWeight(ref EmptyBagsWeight);
           
        }
        public double GetEnglishCount()
        {
            return EnglishCount;
        }
        private void TakeAction(KeyEventArgs e)
        {
            if (e.Control == false) return;
            if (e.KeyCode == Keys.Delete)
            {
                if (this.Parent.Controls.Count > 1)
                    this.Parent.Controls.Remove(this);
            }
            else if (e.KeyCode == Keys.Insert)
            {
                UserControls.dxYarnWarpingAfter nYarn = new dxYarnWarpingAfter();
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
            try
            {
                decimal BagsQuantity = 0;
                decimal LbsQuantity = 0;
                decimal ConesQuantity = 0;
                decimal LbsPerBag = 0;
                decimal ConesPerBag = 0;
                if (this.BagsType.EditValue == null) return;
                if (this.BagsType.EditValue.ToString() != "Fresh") return;
                if (this.BagsReceived.EditValue == null) BagsQuantity = 0;
                else
                    decimal.TryParse(this.BagsReceived.EditValue.ToString(), out BagsQuantity);
                if (this.LbsPerBag.EditValue != null)
                {
                    if (this.LbsPerBag.EditValue != null)
                        LbsPerBag = Convert.ToDecimal(this.LbsPerBag.EditValue.ToString());
                }

                if (this.ConesPerBag.EditValue != null)
                    ConesPerBag = Convert.ToDecimal(this.ConesPerBag.EditValue.ToString());
                LbsQuantity = BagsQuantity * LbsPerBag;
                LbsReceived.EditValue = LbsQuantity.ToString();
                ConesQuantity = ConesPerBag * BagsQuantity;
                this.ConesReceived.EditValue = ConesQuantity.ToString();
                this.LbsReceived.EditValue = LbsQuantity.ToString();
                CalculateNetWeightConsumed();
            }
            catch
            {
            }
        }

        private void PerBagValueChanged(object sender, EventArgs e)
        {
            AutoFillQuantities();
        }

        private void BagsReceived_EditValueChanged(object sender, EventArgs e)
        {
            AutoFillQuantities();
            CalculateEmptyBagsWeightinLbs();
        }

        private void AddNew_CheckedChanged(object sender, EventArgs e)
        {
            UserControls.dxYarnWarpingAfter nYarn = new dxYarnWarpingAfter();
            this.Parent.Controls.Add(nYarn);
        }

        private void RemoveLast_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Parent.Controls.Count > 1)
                this.Parent.Controls.Remove(this);
        }

        private void BagsType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                fc.YarnBagsType(ref this.BagsType);
        }

        private void Counts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                fc.YarnCounts(ref this.Counts);
        }

        private void Blends_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                fc.YarnBlends(ref this.Blends);
        }

        private void Brand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                fc.YarnBrands(ref this.Brand);
        }

        private void Desc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                fc.YarnDesc(ref this.Desc);
        }

        private void LbsPerBag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                fc.YarnLbsPerBag(ref this.LbsPerBag);
        }

        private void ConesPerBag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                fc.YarnConesPerBag(ref this.ConesPerBag);
        }

        private void EmptyBagsWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                fc.EmptyYarnBagWeight(ref this.EmptyBagsWeight);
        }

        private void EmptyConesWeight_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {

        }

        private void EmptyConesWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                fc.EmptyYarnConeWeight(ref this.EmptyConesWeight);
           
        }

        private void LbsReceived_EditValueChanged(object sender, EventArgs e)
        {
            this.CalcLbsIssued.Text = LbsReceived.Text;
            this.CalcLbsIssued.Tag = LbsReceived.EditValue.ToString();
            CalculateNetWeightConsumed();
        }

        private void KgFullCones_EditValueChanged(object sender, EventArgs e)
        {
            CalculateLbsFullandHalfCones();
            CalculateNetWeightConsumed();
        }
        private void CalculateLbsFullandHalfCones()
        {
            try
            {
                double dKgFullandHalf = 0;
                double dKgFullCones = 0;
                double dKgHalfCones = 0;
                double dLbsFullandHalf = 0;
                if (KgFullCones.EditValue != null)
                    double.TryParse(KgFullCones.EditValue.ToString(), out dKgFullCones);
                if (KgHalfCones.EditValue != null)
                    double.TryParse(KgHalfCones.EditValue.ToString(), out dKgHalfCones);
                dKgFullandHalf = dKgFullCones + dKgHalfCones;
                dLbsFullandHalf = dKgFullandHalf * Settings.KgToLbs;
                this.CalcLbsFullHalfCones.Tag = dLbsFullandHalf;
                this.CalcLbsFullHalfCones.Text = dLbsFullandHalf.ToString("#,##0.00");
            }
            catch
            {
            }
        }

        private void KgHalfCones_EditValueChanged(object sender, EventArgs e)
        {
            CalculateLbsFullandHalfCones();
            CalculateNetWeightConsumed();
        }

        private void EmptyBagsWeight_EditValueChanged(object sender, EventArgs e)
        {
            CalculateEmptyBagsWeightinLbs();
            CalculateNetWeightConsumed();

        }
        private void CalculateEmptyBagsWeightinLbs()
        {
            try
            {
                double dEmptyBagWeight = 0;
                double dTotalBags = 0;
                double dTotalEmptyBagWeight = 0;

                if (EmptyBagsWeight.EditValue != null)
                    double.TryParse(EmptyBagsWeight.EditValue.ToString(), out dEmptyBagWeight);
                if (BagsReceived.EditValue != null)
                    double.TryParse(BagsReceived.EditValue.ToString(), out dTotalBags);
                dTotalEmptyBagWeight = ((dEmptyBagWeight ) * dTotalBags) * Settings.KgToLbs;
                this.CalcEmptyBagsWeightLbs.Text = dTotalEmptyBagWeight.ToString("#,##0.00");
                this.CalcEmptyBagsWeightLbs.Tag = dTotalEmptyBagWeight.ToString();
                CalculateNetWeightConsumed();
            }
            catch
            {
            }
        }
        private void CalculateEmptyConesWeightinLbs()
        {
            try
            {
                double dEmptyConeWeight = 0;
                double dTotalCones = 0;
                double dTotalEmptyConeWeight = 0;

                if (EmptyConesWeight.EditValue != null)
                    double.TryParse(EmptyConesWeight.EditValue.ToString(), out dEmptyConeWeight);
                if (ConesReceived.EditValue != null)
                    double.TryParse(ConesReceived.EditValue.ToString(), out dTotalCones);
                dTotalEmptyConeWeight = ((dEmptyConeWeight ) * dTotalCones) * Settings.KgToLbs;
                this.CalcEmptyConesWeightLbs.Tag = dTotalEmptyConeWeight.ToString();
                this.CalcEmptyConesWeightLbs.Text = dTotalEmptyConeWeight.ToString("#,##0.00");
                CalculateNetWeightConsumed();
            }
            catch
            {
            }
        }
        public void CalculateNetWeightConsumed()
        {
            double dEmptyBagWeight = 0;
            double dTotalBags = 0;
            double dTotalEmptyBagWeight = 0;
            double dEmptyConeWeight = 0;
            double dTotalCones = 0;
            double dTotalEmptyConeWeight = 0;
            double dLbsReceivedGross = 0;
            double dKgFullandHalf = 0;
            double dKgFullCones = 0;
            double dKgHalfCones = 0;
            double dLbsFullandHalf = 0;
            double dLbsFullandHalfNet = 0;
            double NetWeightConsumed=0;
            double YarnWarpCount=0;
            double ActualWarpCount = 0;
            try
            {

               try
               {
                   if(this.Counts.EditValue!=null)
                   {
                       double.TryParse(this.Counts.EditValue.ToString(),out YarnWarpCount);
                   }
               }
                catch
               {
                }
               
                if (KgFullCones.EditValue != null)
                    double.TryParse(KgFullCones.EditValue.ToString(), out dKgFullCones);
                if (KgHalfCones.EditValue != null)
                    double.TryParse(KgHalfCones.EditValue.ToString(), out dKgHalfCones);
                dKgFullandHalf = dKgFullCones + dKgHalfCones;
                dLbsFullandHalf = dKgFullandHalf * Settings.KgToLbs;
                this.CalcLbsFullHalfCones.Tag = dLbsFullandHalf;
                this.CalcLbsFullHalfCones.Text = dLbsFullandHalf.ToString("#,##0.00");
            }
            catch
            {
            }
            try
            {
                if (LbsReceived.EditValue != null)
                    double.TryParse(LbsReceived.EditValue.ToString(), out dLbsReceivedGross);


                if (EmptyBagsWeight.EditValue != null)
                    double.TryParse(EmptyBagsWeight.EditValue.ToString(), out dEmptyBagWeight);
                double fullconesbags = 0;double halfconesbags=0;
                if (this.BagsFullCones.EditValue != null)
                    double.TryParse(this.BagsFullCones.EditValue.ToString(), out fullconesbags);
                if (this.BagsHalfCones.EditValue != null)
                    double.TryParse(this.BagsHalfCones.EditValue.ToString(), out halfconesbags);
                dTotalBags = fullconesbags + halfconesbags;

                dTotalEmptyBagWeight = ((dEmptyBagWeight) * dTotalBags) * Settings.KgToLbs;
                this.CalcEmptyBagsWeightLbs.Text = dTotalEmptyBagWeight.ToString("#,##0.00");
                this.CalcEmptyBagsWeightLbs.Tag = dTotalEmptyBagWeight.ToString();
            }
            catch
            {
            }

            try
            {
             

                if (EmptyConesWeight.EditValue != null)
                    double.TryParse(EmptyConesWeight.EditValue.ToString(), out dEmptyConeWeight);
                double hCones = 0; double fCones = 0;
                if (this.ConesFullCones.EditValue != null)
                    double.TryParse(this.ConesFullCones.EditValue.ToString(), out fCones);
                if (this.ConesHalfCones.EditValue != null)
                    double.TryParse(this.ConesHalfCones.EditValue.ToString(), out hCones);
                dTotalCones = fCones + hCones;
                dTotalEmptyConeWeight = ((dEmptyConeWeight) * dTotalCones) * Settings.KgToLbs;
                this.CalcEmptyConesWeightLbs.Tag = dTotalEmptyConeWeight.ToString();
                this.CalcEmptyConesWeightLbs.Text = dTotalEmptyConeWeight.ToString("#,##0.00");
            }
            catch
            {
            }
            dLbsFullandHalfNet = dLbsFullandHalf - dTotalEmptyBagWeight - dTotalEmptyConeWeight;
            CalcNetFullHalfCones.Text = dLbsFullandHalfNet.ToString("#,##0.00");
            CalcNetFullHalfCones.Tag = dLbsFullandHalfNet.ToString();
            NetWeightConsumed = dLbsReceivedGross - dLbsFullandHalfNet;
            this.CalcNetLbsConsumed.Text = NetWeightConsumed.ToString("#,##0.00");
            this.CalcNetLbsConsumed.Tag = NetWeightConsumed.ToString();
           
            //if(YarnWarpCount>100)
            //{
                ActualWarpCount = (Length * EndsTotalWarpBeams /768.1/NetWeightConsumed);
                WarpCount.Text = ActualWarpCount.ToString("#,##0.00");
                WarpCount.Tag = ActualWarpCount.ToString();
            //}else
            //{
            //    ActualWarpCount = (Length * YarnEnds / 768.1) / NetWeightConsumed;
            //}
            
        }
        private void ConesReceived_EditValueChanged(object sender, EventArgs e)
        {
            CalculateEmptyConesWeightinLbs();
            CalculateNetWeightConsumed();
        }

        private void EmptyConesWeight_EditValueChanged(object sender, EventArgs e)
        {
            CalculateEmptyConesWeightinLbs();
            CalculateNetWeightConsumed();
        }

        private void Counts_EditValueChanged(object sender, EventArgs e)
        {
            if (Counts.EditValue != null)
                double.TryParse(Counts.EditValue.ToString(), out EnglishCount);
            else
                EnglishCount = 1;
        }

        private void dxYarnWarpingAfter_Load(object sender, EventArgs e)
        {

        }
    }
}
