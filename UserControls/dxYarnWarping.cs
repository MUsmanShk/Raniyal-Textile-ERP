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
    public partial class dxYarnWarping : DevExpress.XtraEditors.XtraUserControl
    {
        public dxYarnWarping()
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
                UserControls.dxYarnWarping nYarn = new dxYarnWarping();
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
            if (this.BagsType.EditValue.ToString() != "Fresh") return;
            if (this.Bags.EditValue == null) BagsQuantity = 0;
            else
                decimal.TryParse(this.Bags.EditValue.ToString(), out BagsQuantity);
            if (this.LbsPerBag.EditValue != null)
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

        private void InsertDelNewControl(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void ActionKeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void BagsType_EditValueChanged(object sender, EventArgs e)
        {
            AutoFillQuantities();
        }

        private void LbsPerBag_EditValueChanged(object sender, EventArgs e)
        {
            AutoFillQuantities();
        }

        private void ConesPerBag_EditValueChanged(object sender, EventArgs e)
        {
            AutoFillQuantities();
        }

        private void Bags_EditValueChanged(object sender, EventArgs e)
        {
            AutoFillQuantities();
        }
    }
}
