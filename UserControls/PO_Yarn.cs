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
    public partial class PO_Yarn : DevExpress.XtraEditors.XtraUserControl
    {
        public double LbsTotalRequired = 0;
        public PO_Yarn()
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
                UserControls.PO_Yarn nYarn = new PO_Yarn();
                nYarn.LbsTotalRequired = this.LbsTotalRequired;
                this.Parent.Controls.Add(nYarn);
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
            double lbsRatio;

            double LbsPerBag = 0;
            if (this.Ratio.EditValue != null)
                double.TryParse(this.Ratio.EditValue.ToString(), out lbsRatio);
            else
                lbsRatio = 0;

            LbsQuantity = LbsTotalRequired * lbsRatio / 100;
            
           
          
           
                if (this.LbsPerBag.EditValue != null)
                    LbsPerBag = Convert.ToDouble(this.LbsPerBag.EditValue.ToString());
       

   
            BagsQuantity = LbsQuantity / LbsPerBag;
                 
           
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

       
    }
}
