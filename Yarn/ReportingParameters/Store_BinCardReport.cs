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
    public partial class Store_BinCardReport : DevExpress.XtraEditors.XtraUserControl
    {
        public Store_BinCardReport()
        {
            InitializeComponent();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Yarn.ReportingParameters.Yarn_Reports mr = (MachineEyes.Yarn.ReportingParameters.Yarn_Reports)this.Parent.Parent;
            mr.Close();
        }

        private void ItemAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                selectedrow sRow;
                sRow = Program.MainWindow.StoreAccountsList.SelectedRow;
                Program.MainWindow.StoreAccountsList.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.ItemAccountID.EditValue = sRow.PrimeryID;
                    this.ItemAccountName.EditValue = sRow.PrimaryString;
                    
                }
            }
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            if (this.ItemAccountID.EditValue == null)
            {
                XtraMessageBox.Show("invalid item account", "Error");
                return;
            }
            if (this.FromDate.DateTime == null)
            {
                XtraMessageBox.Show("Invalid date", "Error");
                return;
            }
            if (this.ToDate.DateTime == null)
            {
                XtraMessageBox.Show("invalid date", "Error");
                return;
            }
            string dsstring = "Select Sum(PlusQty)-Sum(MinusQty) as Balance from ST_StoreDetails where ItemAccountID='" + this.ItemAccountID.EditValue.ToString() + "'  and Dated<'" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  ";

            DataSet ds = WS.svc.Get_DataSet(dsstring);
            string dsItemstring = "Select * from RST_ItemAccounts where ItemAccountID='" + this.ItemAccountID.EditValue.ToString() + "'";
            DataSet dsItem = WS.svc.Get_DataSet(dsItemstring);

            Reports.Store_ItemBinCard BinCard = new Reports.Store_ItemBinCard();
            BinCard.BeginInit();
            BinCard.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            BinCard.ItemAccountID.Text = this.ItemAccountID.EditValue.ToString();
            BinCard.ItemAccountName.Text = this.ItemAccountName.EditValue.ToString();
            if (ds != null)
            {
              
                if (ds.Tables[0].Rows[0]["Balance"].ToString() != "")
                    BinCard.Opening.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
                else
                    BinCard.Opening.Text = "0.00";
                BinCard.SetBalance(Convert.ToDouble(BinCard.Opening.Text));
            }
            if (dsItem != null)
            {
                 BinCard.GroupAccountID.Text = dsItem.Tables[0].Rows[0]["GroupAccountID"].ToString();
                 BinCard.GroupAccountName.Text = dsItem.Tables[0].Rows[0]["GroupAccountName"].ToString();
                 BinCard.UOM.Text = dsItem.Tables[0].Rows[0]["bUnit"].ToString();
                 BinCard.LPR.Text = dsItem.Tables[0].Rows[0]["bUnitRate"].ToString();
            }
            BinCard.From.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            BinCard.Upto.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");

            string sdetail = "Select * from RST_StoreDetails where ItemAccountID='" + this.ItemAccountID.EditValue.ToString() + "'  and Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'   ";
            DataSet dsdetails = WS.svc.Get_DataSet(sdetail);
            if (dsdetails != null)
                BinCard.DataSource = dsdetails.Tables[0];
            else
                dsdetails = null;
            BinCard.EndInit();
            BinCard.ShowPreview();
          
        }
    }
}
