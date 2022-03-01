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
    public partial class dxSizingChemicalConsumption : DevExpress.XtraEditors.XtraUserControl
    {
        public dxSizingChemicalConsumption()
        {
            InitializeComponent();
        }

        private void dxSizingChemicalConsumption_Load(object sender, EventArgs e)
        {

        }
        private void ViewChemicals()
        {
            try
            {
                selectedrow sr = new selectedrow();
                Data.Data_View DView = new Data.Data_View();
                DView.Load_View("Select ItemAccountID as ChemicalID,ItemAccountName as ChemicalName,cUnit,cUnitRate from ST_ItemAccounts where ItemAccountId in(select ChemicalID from SW_Sizing_Chemicals) order by ItemAccountName", "ChemicalID", "ChemicalName");
                DView.sRow = sr;
                DView.ShowDialog();
                if (sr.Status != ParameterStatus.Selected)
                    return;
                this.ChemicalID.Tag = sr.PrimeryID;
                this.ChemicalID.Text = sr.PrimaryString;
                this.cUnit.Text = sr.SelectedDataRow["cUnit"].ToString();
                this.cUnit.Tag = sr.SelectedDataRow["cUnitRate"].ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                UserControls.dxSizingChemicalConsumption sz = new UserControls.dxSizingChemicalConsumption();

                this.Parent.Controls.Add(sz);
            }


        }

        private void ChemicalID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
                ViewChemicals();
            else
                TakeAction(e);
        }

        private void cUnit_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void Quantity_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void Remarks_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void Quantity_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
