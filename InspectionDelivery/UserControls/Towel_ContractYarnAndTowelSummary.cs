using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.InspectionDelivery.UserControls
{
    public partial class Towel_ContractYarnAndTowelSummary : DevExpress.XtraEditors.XtraUserControl
    {
        public Towel_ContractYarnAndTowelSummary()
        {
            InitializeComponent();
        }

        private void PartyID_EditValueChanged(object sender, EventArgs e)
        {
            if (PartyID.EditValue != null)
            {
                string mAcID = MachineEyes.Classes.Accounting.Get_MappedAccount(this.PartyID.EditValue.ToString());
                if (mAcID != "")
                    this.PartyName.EditValue = mAcID;
                else
                    this.PartyName.EditValue = null;
            }
            else
            {
                PartyName.EditValue = null;
            }
        }

        private void PartyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                selectedrow sRow = new selectedrow();
                Data.Data_Accounts_View aView = new Data.Data_Accounts_View();
                aView.sRow = sRow;
                aView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.PartyID.EditValue = sRow.PrimeryID;
                    this.PartyName.EditValue = sRow.PrimaryString;

                }
            }
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            if (this.PartyID.EditValue == null || this.PartyName.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Party", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Reports.Inspection_Towel_PartyContractYarnStatus Report = new Reports.Inspection_Towel_PartyContractYarnStatus();
            Report.BeginInit();
            Report.StatusDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            Report.PartyName.Text = this.PartyName.EditValue.ToString();
            string query = "";

            query = "Select * from IP_Godown_ContractYarnAndTowelSummary where BuyerID='"+this.PartyID.EditValue.ToString()+"' and POStatusID=0";
            DataSet ds = WS.svc.Get_DataSet(query);
  
          

            if (ds != null)
                Report.DataSource = ds.Tables[0];
            else
                Report.DataSource = null;
            Report.EndInit();
            Report.ShowPreview();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Reports.Parameters.ReportsMDI mr = (Reports.Parameters.ReportsMDI)this.Parent.Parent;
            mr.Close();
        }
    }
}
