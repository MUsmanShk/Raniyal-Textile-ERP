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
    public partial class dxGreigeArticleParams : DevExpress.XtraEditors.XtraUserControl
    {
        public double EPI = 0;
        public double PPI = 0;
        public double WIDTH = 0;
        public double WarpWeight = 0;
        public double WeftWeight = 0;
        public bool isWarp = false;
        public dxGreigeArticleParams()
        {
            InitializeComponent();
            FillCombos fc = new FillCombos();
            fc.YarnCounts(ref Counts);
            fc.YarnColors(ref Color);
            fc.YarnBlends(ref Blends);
            fc.YarnPly(ref Ply);
            fc.YarnDesc(ref Desc);
        }

        private void RefreshYarn_Click(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
            fc.YarnCounts(ref Counts);
            fc.YarnColors(ref Color);
            fc.YarnBlends(ref Blends);
            fc.YarnPly(ref Ply);
            fc.YarnDesc(ref Desc);
        }

        private void Counts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.Counts.EditValue = null;
        }

        private void Ply_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.Ply.EditValue = null;
        }

        private void Blends_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.Blends.EditValue = null;
        }

        private void Desc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.Desc.EditValue = null;
        }

        private void Color_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.Color.EditValue = null;
        }
        public void CalculateWarpWeftWeight()
        {
            
           
            double EnglishCount = 0;
            int YarnPly=1;
           
            
            if(this.Ply.EditValue!=null)
                int.TryParse(this.Ply.EditValue.ToString(),out YarnPly);
            if (this.Counts.EditValue != null)
                EnglishCount = Program.ss.Machines.PresentationData.Return_EnglishCount(this.Counts.EditValue.ToString());



            if (isWarp == true)
            {

                WarpWeight = (((EPI * WIDTH) / 768.1) / (EnglishCount / YarnPly));
                if (double.IsInfinity(WarpWeight) == false && double.IsNaN(WarpWeight) == false)
                    this.Weight.EditValue = WarpWeight.ToString();
                else
                    this.Weight.EditValue = null; ;
               
            }
            else
            {
                double ReedSpace = ((EPI /(EPI-4)* WIDTH)) ;
                WeftWeight = (ReedSpace * PPI / 768.1) / (EnglishCount / YarnPly);
                if (double.IsInfinity(WeftWeight) == false && double.IsNaN(WeftWeight) == false)
                    this.Weight.EditValue = WeftWeight.ToString();
                else
                    this.Weight.EditValue = null;
            }
            
        }

        private void Counts_EditValueChanged(object sender, EventArgs e)
        {
            CalculateWarpWeftWeight();
        }

        private void Ply_EditValueChanged(object sender, EventArgs e)
        {
            CalculateWarpWeftWeight();
        }
    }
}
