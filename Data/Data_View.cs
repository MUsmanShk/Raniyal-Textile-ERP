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
    public partial class Data_View : DevExpress.XtraEditors.XtraForm
    {
        public selectedrow sRow = null;
        public string PrimaryID;
        public string PrimaryString;
        public Data_View()
        {
            InitializeComponent();
        }
        public void Load_View(string query,string PID,string PString)
        {
            try
            {
                DataSet ds = new DataSet();
                this.gridView1.Columns.Clear();
                this.gridControl1.DataSource = null;
                this.PrimaryID = PID;
                this.PrimaryString = PString;
                ds = WS.svc.Get_DataSet(query);


                if (ds != null)
                {
                    this.gridControl1.DataSource = ds.Tables[0];
                    //this.gridView1.Columns[0].Width = 400;
                    //try
                    //{
                    //    this.gridView1.Columns[1].Width = 700;
                    //}
                    //catch
                    //{
                    //}

                }
               

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Data_View_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                sRow.Status = ParameterStatus.Cancelled;

                this.Close();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            sRow.SelectedDataRow = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
            if (sRow.SelectedDataRow != null)
            {
                sRow.PrimeryID = sRow.SelectedDataRow[PrimaryID].ToString();
                sRow.PrimaryString = sRow.SelectedDataRow[PrimaryString].ToString();
            }

            sRow.Status = ParameterStatus.Selected;
            this.Close();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sRow.SelectedDataRow = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
                if (sRow.SelectedDataRow != null)
                {
                    sRow.PrimeryID = sRow.SelectedDataRow[PrimaryID].ToString();
                    sRow.PrimaryString = sRow.SelectedDataRow[PrimaryString].ToString();
                    sRow.Status = ParameterStatus.Selected;
                }

               
                this.Close();
            }
        }
    }
}