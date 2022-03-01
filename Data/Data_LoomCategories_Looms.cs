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
    public partial class Data_LoomCategories_Looms : DevExpress.XtraEditors.XtraForm
    {
        public Data_LoomCategories_Looms()
        {
            InitializeComponent();
        }
        public Data_LoomCategories_Looms(bool AddLooms,string query)
        {
            InitializeComponent();
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {
                this.GridControl_Looms.DataSource = ds.Tables[0];

            }
            if (AddLooms == true)
            {
                this.Looms_Add.Enabled = true;
                this.Looms_Remove.Enabled = false;

            }
        }

        private void Looms_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Looms_Add_Click(object sender, EventArgs e)
        {
            int[] selectedhandles = this.GridVew_Looms.GetSelectedRows();
            for (int x = 0; x < selectedhandles.Length; x++)
            {
                
                DataRow dr = this.GridVew_Looms.GetDataRow(selectedhandles[x]);
                if (dr != null)
                {
                    string s = WS.svc.Execute_Query("Update MT_Looms set CategoryID=" + CurrentSelection.CategorySelected.CategoryName.Tag.ToString() + " where LoomID=" + dr["LoomID"].ToString() + "");
                    if (s != "**SUCCESS##")
                    {
                        DialogResult dg = XtraMessageBox.Show(s, "Error Updating category...do you want to continue?", MessageBoxButtons.AbortRetryIgnore);
                        if (dg == DialogResult.Abort)
                            return;

                    }
                    else
                    {
                        CurrentSelection.CategorySelected.AddLoom(Convert.ToInt16(dr["LoomID"].ToString()));
                        dr.Delete();
                    }
                }

            }
        }

        private void Looms_Remove_Click(object sender, EventArgs e)
        {

            int[] selectedhandles = this.GridVew_Looms.GetSelectedRows();
            for (int x = 0; x < selectedhandles.Length; x++)
            {

                DataRow dr = this.GridVew_Looms.GetDataRow(selectedhandles[x]);
                if (dr != null)
                {
                    string s = WS.svc.Execute_Query("Update MT_Looms set CategoryID=null where LoomID=" + dr["LoomID"].ToString() + "");
                    if (s != "**SUCCESS##")
                    {
                        DialogResult dg = XtraMessageBox.Show(s, "Error Updating category...do you want to continue?", MessageBoxButtons.AbortRetryIgnore);
                        if (dg == DialogResult.Abort)
                            return;

                    }
                    else
                    {
                        CurrentSelection.CategorySelected.RemoveLoom(Convert.ToInt16(dr["LoomID"].ToString()));
                        dr.Delete();
                    }
                }

            }
        }
    }
}