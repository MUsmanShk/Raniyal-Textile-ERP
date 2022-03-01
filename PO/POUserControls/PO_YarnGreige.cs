using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.PO.POUserControls
{
    public partial class PO_YarnGreige : DevExpress.XtraEditors.XtraUserControl
    {
        public double MetersRequired = 0;
        public PO_YarnGreige()
        {
            InitializeComponent();
        }

        private void PO_Yarn_Load(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
            fc.YarnCounts(ref Counts);
            fc.YarnPly(ref Ply);
            fc.YarnLbsPerBag(ref LbsPerBag);
          
            fc.YarnDesc(ref Desc);
            fc.YarnBlends(ref Blends);
           

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
                POUserControls.PO_YarnGreige nYarn = new PO_YarnGreige();
                nYarn.MetersRequired = this.MetersRequired;
                this.Parent.Controls.Add(nYarn);
                nYarn.WastageAllowed.Focus();
            }

            else if (e.KeyCode == Keys.D && e.Control == true)
            {
                if (this.Parent.Controls.Count > 1)
                    this.Parent.Controls.Remove(this);
            }

        }
        public void AutoFillQuantities()
        {

            double BagsQuantity = 0;
            double LbsQuantity = 0;
            double LbsAsPerArticle;
            double LbsWastageAllowed = 0;
            double PercentWastageAllowed = 0;
            double LbsPerBag = 0;
            if (this.Weight.EditValue != null)
                double.TryParse(this.Weight.EditValue.ToString(), out LbsAsPerArticle);
            else
                LbsAsPerArticle = 0;
            if (this.WastageAllowed.EditValue != null)
                double.TryParse(this.WastageAllowed.EditValue.ToString(), out PercentWastageAllowed);
            else
                PercentWastageAllowed = 0;
            try
            {
                LbsQuantity = MetersRequired * LbsAsPerArticle;
                LbsWastageAllowed = LbsQuantity * PercentWastageAllowed / 100;
                LbsQuantity += LbsWastageAllowed;
            }
            catch
            {
            }
          
           
                if (this.LbsPerBag.EditValue != null)
                    LbsPerBag = Convert.ToDouble(this.LbsPerBag.EditValue.ToString());


                try
                {
                    BagsQuantity = LbsQuantity / LbsPerBag;
                }
                catch
                {
                }
           
            this.Lbs.EditValue = LbsQuantity.ToString();
            this.Bags.EditValue = BagsQuantity.ToString();

        }

        private void TakeActionAtKeyDown(object sender, KeyEventArgs e)
        {
            AutoFillQuantities();
            TakeAction(e);
        }

        private void Ratio_EditValueChanged(object sender, EventArgs e)
        {
            AutoFillQuantities();
        }

        private void LbsPerBag_EditValueChanged(object sender, EventArgs e)
        {
            AutoFillQuantities();
        }

        private void WastageAllowed_EditValueChanged(object sender, EventArgs e)
        {
            AutoFillQuantities();
        }

       
    }
}
