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
    public partial class Data_YarnFabricParameters : DevExpress.XtraEditors.XtraForm
    {
        ParameterReturn pr = new ParameterReturn();
        private string ColumnName="";
        private string TableName="";
        public Data_YarnFabricParameters()
        {
            InitializeComponent();
        }
        public ParameterReturn Display_Parameter(Point p,string Caption, string ParameterDatabaseColumnName, string ParameterTableName)
        {

            this.Text = "Data : " +  Caption;
        this.gridView1.ViewCaption = Caption;
        ColumnName = ParameterDatabaseColumnName;
        TableName = ParameterTableName;

        try
        {
            DataSet ds = WS.svc.Get_DataSet("Select " + ColumnName + " from " + TableName + "");
            if (ds != null)
            {

              
               this.gridControl1.DataSource  = ds.Tables[0];
                
            }
        }
        catch (Exception ex)
        {
            pr.Status = ParameterStatus.Error;
            pr.ParameterValue = ex.Message;
            return pr;
        }
            this.Left = p.X;
            this.Top = p.Y;
            this.ShowDialog();
            return pr;
        }

        private void Parameter_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string qres=WS.svc.Execute_Query("insert into " +TableName + " values('" +this.Parameter_text.Text + "')");
                if (qres != "**SUCCESS##")
                {
                    pr.ParameterValue = qres;
                    pr.Status = ParameterStatus.Error;
                }
                else
                {
                    pr.ParameterValue = this.Parameter_text.Text;
                    pr.Status = ParameterStatus.Added;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                pr.Status = ParameterStatus.Error;
                pr.ParameterValue = ex.Message;
                this.Close();
            }
        }

        private void Parameter_Cancel_Click(object sender, EventArgs e)
        {
            pr.Status = ParameterStatus.Cancelled;
            pr.ParameterValue = "";
            this.Close();
        }

        private void Parameter_Update_Click(object sender, EventArgs e)
        {
            try
            {
                
                string qres = WS.svc.Execute_Query("update  " + TableName + " set "+ColumnName +"='" + this.Parameter_text.Text + "' where "+ColumnName+"='"+this.Parameter_text.Tag.ToString()+"'");
                if (qres != "**SUCCESS##")
                {
                    pr.ParameterValue = qres;
                    pr.Status = ParameterStatus.Error;
                }
                else
                {
                    pr.ParameterValue = this.Parameter_text.Text;
                    pr.Status = ParameterStatus.Edited;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                pr.Status = ParameterStatus.Error;
                pr.ParameterValue = ex.Message;
                this.Close();
            }
        }
     
        private void Parameter_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                

                DialogResult dg = XtraMessageBox.Show("Are you sure to Delete " + this.Parameter_text.Tag.ToString()+ "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg != DialogResult.Yes)
                {
                    return;
                }
                string qres = WS.svc.Execute_Query("delete from " + TableName + " where " + ColumnName + " ='" + this.Parameter_text.Tag.ToString() + "'");
                if (qres != "**SUCCESS##")
                {
                    pr.ParameterValue = qres;
                    pr.Status = ParameterStatus.Error;
                }
                else
                {
                    pr.ParameterValue = "";
                    pr.Status = ParameterStatus.Deleted;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                pr.Status = ParameterStatus.Error;
                pr.ParameterValue = ex.Message;
                this.Close();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
            DataRow dr = this.gridView1.GetDataRow(e.FocusedRowHandle);
            if (dr != null)
            {
                this.Parameter_text.Text = dr[0].ToString();
                this.Parameter_text.Tag = dr[0].ToString();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

       
      

       
      
    }
}