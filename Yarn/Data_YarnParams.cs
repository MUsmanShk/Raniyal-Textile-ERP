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
    public partial class Data_YarnParams : DevExpress.XtraEditors.XtraForm
    {
        ParameterReturn pr = new ParameterReturn();
        private  string ColumnName_Yarn = "";
        private string TableName_Yarn = "";
      
        public Data_YarnParams()
        {
            InitializeComponent();
        }
        public ParameterReturn Display_Parameter(Point p, string Caption, string ParameterDatabaseColumnName_Yarn, string ParameterTableName_Yarn)
        {


            this.gridView1.ViewCaption = Caption;
            ColumnName_Yarn = ParameterDatabaseColumnName_Yarn;
            TableName_Yarn = ParameterTableName_Yarn;
           
            try
            {
                DataSet ds = WS.svc.Get_DataSet("Select " + ColumnName_Yarn + " from " + TableName_Yarn + "");
                if (ds != null)
                {


                    this.gridControl1.DataSource = ds.Tables[0];

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
                string[] qres = new string[0];
                Array.Resize(ref qres,3);
               
                qres[0] = "insert into " + TableName_Yarn+" ("+ColumnName_Yarn+") values('"+this.Parameter_text.Text +"')";
              
               string result=WS.svc.Execute_Query(qres[0]);
               // = WS.svc.Execute_Query("insert into " + TableName + " values('" + this.Parameter_text.Text + "')");
                if (result != "**SUCCESS##")
                {
                    pr.ParameterValue = result;
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

        private void Parameter_Update_Click(object sender, EventArgs e)
        {
            try
            {
                string[] qres = new string[0];
                Array.Resize(ref qres, 3);

                qres[0] = "update " + TableName_Yarn + " set "+ColumnName_Yarn+"='" + this.Parameter_text.Text + "' where "+ColumnName_Yarn+" ='"+this.Parameter_text.Tag.ToString()+"'";
               
                string result = WS.svc.Execute_Query(qres[0]);
                
                if (result != "**SUCCESS##")
                {
                    pr.ParameterValue = result;
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

                string[] qres = new string[0];
                Array.Resize(ref qres, 3);

                qres[0] = "delete from " + TableName_Yarn + "  where " + ColumnName_Yarn + " ='" + this.Parameter_text.Tag.ToString() + "'";
              
                DialogResult dg = XtraMessageBox.Show("Are you sure to Delete " + this.Parameter_text.Tag.ToString() + "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg != DialogResult.Yes)
                {
                    return;
                }
                string result = WS.svc.Execute_Query(qres[0]);
                if (result != "**SUCCESS##")
                {
                    pr.ParameterValue = result;
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

        private void Parameter_Cancel_Click(object sender, EventArgs e)
        {
            pr.Status = ParameterStatus.Cancelled;
            pr.ParameterValue = "";
            this.Close();
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
    }
}