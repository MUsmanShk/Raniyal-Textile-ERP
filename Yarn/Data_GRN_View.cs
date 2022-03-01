using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Data
{
    public partial class Data_GRN_View : DevExpress.XtraEditors.XtraForm
    {
        public enum DocumentType { GRN = 0, GIN = 1 };
        public DocumentType mDocumentType; // 0=GRN, 1=GIN

        public selectedrow sRow = null;
        public Data_GRN_View()
        {
            InitializeComponent();
        }

        private void Data_GRN_View_Load(object sender, EventArgs e)
        {
           

      
        }
        public void LoadContracts(string Query)
        {
            DataSet ds = new DataSet();
            this.gridView1.Columns.Clear();
            this.gridControl1.DataSource = null;
           
            ds = WS.svc.Get_DataSet(Query);

            if (ds != null)
            {
                this.gridControl1.DataSource = ds.Tables[0];
            
            }
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            sRow.SelectedDataRow = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
            if (sRow.SelectedDataRow != null)
            {
                sRow.PrimeryID = sRow.SelectedDataRow[0].ToString();
                sRow.PrimaryString = sRow.SelectedDataRow[1].ToString();
            }
            sRow.Status = ParameterStatus.Selected;
            this.Close();
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sRow.SelectedDataRow = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
                if (sRow.SelectedDataRow != null)
                {
                    sRow.PrimeryID = sRow.SelectedDataRow[0].ToString();
                    sRow.PrimaryString = sRow.SelectedDataRow[1].ToString();
                }
                sRow.Status = ParameterStatus.Selected;
                this.Close();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Data_GRN_View_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void Data_GRN_View_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                sRow.Status = ParameterStatus.Cancelled;
                this.Close();
            }
        }
    }
}