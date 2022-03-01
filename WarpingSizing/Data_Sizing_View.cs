using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes
{
    public partial class Data_Sizing_View : DevExpress.XtraEditors.XtraForm
    {
        selectedrow sRow;
        public Data_Sizing_View()
        {
            InitializeComponent();
        }
        public void SelectSizingProgram(ref selectedrow SelectedRow,string query)
        {
            if(query!="")
            Load_SizingPrograms(query);
            sRow = SelectedRow;
            this.ShowDialog();


            if (sRow.Status == ParameterStatus.Selected)
            {
                SelectedRow.SelectedDataRow = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
                if (SelectedRow.SelectedDataRow != null)
                {
                    SelectedRow.PrimeryID = SelectedRow.SelectedDataRow["SetNo"].ToString();
                    SelectedRow.PrimaryString = SelectedRow.SelectedDataRow["warpProgID"].ToString();
                }
            }
            else
            {
                SelectedRow.PrimaryString = "";
                SelectedRow.PrimeryID = "";
                SelectedRow.SelectedDataRow = null;
            }

        }
        public void Load_SizingPrograms(string query)
        {
        
            DataSet ds = new DataSet();
            this.gridView1.Columns.Clear();
            this.gridControl1.DataSource = null;
            

            ds = WS.svc.Get_DataSet(query);


            if (ds != null)
            {
                this.gridControl1.DataSource = ds.Tables[0];
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            sRow.Status = ParameterStatus.Cancelled;
            this.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            sRow.Status = ParameterStatus.Selected;
            this.Close();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sRow.Status = ParameterStatus.Selected;
                this.Close();
            }
        }

        private void Data_Sizing_View_Load(object sender, EventArgs e)
        {
           
        }

        private void Data_Sizing_View_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                sRow.Status = ParameterStatus.Cancelled;
                this.Close();
            }
        }
    }
}