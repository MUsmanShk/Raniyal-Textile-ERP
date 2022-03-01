using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Store
{
    public partial class Store_ItemsList : DevExpress.XtraEditors.XtraForm
    {
        public selectedrow SelectedRow = new selectedrow();
        int FocusedRowHandle = -1;
        public Store_ItemsList()
        {
            InitializeComponent();
           
        }
        public void LoadItems()
        {
            try
            {
                DataSet ds = WS.svc.Get_DataSet("Select ItemAccountID,ItemAccountName,PartNumber,StockQty,GroupAccountID,ControlAccountID,GroupAccountName,ControlAccountName,bUnit,bUnitRate,bDate,cUnit,cUnitRate,cUnitinPUnit,ItemTypeID,ReOrderLevel,iStatus,AvgBuyingRate from RST_ItemAccounts order by ItemAccountName,GroupAccountName,ControlAccountName");

                this.gridControl_Item.DataSource = ds.Tables[0];
                if (ds != null)
                {
                    if (ds.Tables[0].Columns.Count > 0)
                    {
                        for (int x = 4; x < ds.Tables[0].Columns.Count; x++)
                        {
                            this.gridView_Item.Columns[x].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("LoadItems::" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView_Item_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            FocusedRowHandle = e.FocusedRowHandle;
        }

        private void gridView_Item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { SelectRow(); }
            else if (e.KeyCode == Keys.F5)
                LoadItems();
            else if (e.KeyCode == Keys.Escape)
            {
                SelectedRow.Status = ParameterStatus.Cancelled;
                this.Hide();
                return;
            }
        }
        private void SelectRow()
        {
           
            if(FocusedRowHandle==-1)
            {
               SelectedRow.Status = ParameterStatus.Cancelled;
                this.Hide();
                return;
            }
                SelectedRow.SelectedDataRow = this.gridView_Item.GetDataRow(FocusedRowHandle);
                if (SelectedRow.SelectedDataRow != null)
                {
                    SelectedRow.PrimeryID = SelectedRow.SelectedDataRow[0].ToString();
                    SelectedRow.PrimaryString = SelectedRow.SelectedDataRow[1].ToString();
                }

                SelectedRow.Status = ParameterStatus.Selected;
                this.Hide();
         }

        private void gridView_Item_DoubleClick(object sender, EventArgs e)
        {
            SelectRow();
        }

        private void Store_ItemsList_Load(object sender, EventArgs e)
        {
            LoadItems();
        }
        
    }
}