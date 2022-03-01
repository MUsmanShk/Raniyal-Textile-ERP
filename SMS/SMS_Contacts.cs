using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.SMS
{
    public partial class SMS_Contacts : DevExpress.XtraEditors.XtraForm
    {
        selectedrow SelectedContact = new selectedrow();
        public SMS_Contacts()
        {
            InitializeComponent();
            Fill_SMSKeywords();
            Fill_SMSConditionalOperators();
        }

        private void SMSBrowse_Click(object sender, EventArgs e)
        {
            selectedrow srow = new selectedrow();
            MachineEyes.Data.Data_View View = new Data.Data_View();
            View.Load_View("select SMSTypeID,Description from SMS_Types", "SMStypeID", "Description");
            View.sRow = srow;
            View.ShowDialog();
            if (srow.Status == ParameterStatus.Selected)
            {
                FillSMS(srow.PrimeryID);
            }

        }
        
        private void Fill_SMSKeywords()
        {
            DataSet ds;
            this.SMSKeyword.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select SMSKeyword,KeywordExplanation from SMS_Keywords order by KeywordExplanation ");
            if (ds != null) this.SMSKeyword.Properties.DataSource = ds.Tables[0];
            this.SMSKeyword.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KeywordExplanation"));
            this.SMSKeyword.Properties.DisplayMember = "KeywordExplanation";
            this.SMSKeyword.Properties.ValueMember = "SMSKeyword";
        }

        private void Fill_SMSConditionalOperators()
        {
            DataSet ds;
            this.SMSCondition.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select CO from SMS_ConditionalOperators");
            if (ds != null) this.SMSCondition.Properties.DataSource = ds.Tables[0];
            this.SMSCondition.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CO"));
            this.SMSCondition.Properties.DisplayMember = "CO";
            this.SMSCondition.Properties.ValueMember = "CO";
        }
        private void FillSMS(string argSMSTypeID)
        {
            try
            {
                DataSet ds = WS.svc.Get_DataSet("Select * from SMS_Types where SMSTypeID='" + argSMSTypeID + "'");
                this.SMS.Text = "";
                this.SMSCondition.EditValue = null;
                this.SMSDescription.Text = "";
                this.SMSKeyword.EditValue = null;
                this.SMSTypeID.Text = "";
                if (ds == null) return;
                if (ds.Tables[0].Rows.Count <= 0) return;
                this.SMSTypeID.Text = ds.Tables[0].Rows[0]["SMSTypeID"].ToString();
                this.SMS.Text = ds.Tables[0].Rows[0]["SmsString"].ToString();
                this.SMSDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                this.SMSCondition.EditValue = ds.Tables[0].Rows[0]["ConditionalOperator"].ToString();
                this.SMSConditionalValue.Text = ds.Tables[0].Rows[0]["ConditionalValue"].ToString();
                this.RadioisActive.EditValue = ds.Tables[0].Rows[0]["isActive"].ToString();
                this.radioGroup1.EditValue = ds.Tables[0].Rows[0]["isLoomSMS"].ToString();
                this.gridView1.Columns.Clear();
                DataSet ds_Contacts = WS.svc.Get_DataSet("Select * from SMS_ContactsList where SMSTypeID='" + argSMSTypeID + "'");
                this.gridControl1.DataSource = ds_Contacts.Tables[0];
                this.gridView1.Columns[0].Width = 20 * this.gridControl1.Width / 100;
                this.gridView1.Columns[1].Width = 20 * this.gridControl1.Width / 100;
                this.gridView1.Columns[2].Width = 50 * this.gridControl1.Width / 100;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void SMSUpdate_Click(object sender, EventArgs e)
        {
            if (this.SMSTypeID.Text == "")
                return;
            DialogResult dg = XtraMessageBox.Show("Are you sure to update " + this.SMSTypeID.Text + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
            try
            {
                string res = WS.svc.Execute_Query("update SMS_Types set ConditionalValue='"+this.SMSConditionalValue.Text +"',ConditionalOperator='"+this.SMSCondition.EditValue.ToString()+"',SMSString='"+this.SMS.Text +"',isActive="+this.RadioisActive.EditValue.ToString()+",isLoomSMS="+this.radioGroup1.EditValue.ToString()+",Description='"+this.SMSDescription.Text +"' where SMSTypeID='" + this.SMSTypeID.Text + "'");
                if (res == "**SUCCESS##")
                {
                    string smsres = WS.svc.SMS_ReloadSMSTypes();
                    this.SMS.Text = "";
                    this.SMSCondition.EditValue = null;
                    this.SMSDescription.Text = "";
                    this.SMSKeyword.EditValue = null;
                    this.SMSTypeID.Text = "";
                    this.gridView1.Columns.Clear();

                }
                else
                {
                    XtraMessageBox.Show(res, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SMSEdit_Click(object sender, EventArgs e)
        {

        }

        private void AddContacts_Click(object sender, EventArgs e)
        {
            selectedrow SelectedRow=new selectedrow();
             string query = "select * from QP_Employees where EmployeeID not in(Select SMSContactID from SMS_Contacts where SMSTypeID='"+this.SMSTypeID.Text +"') order by Convert(numeric(18),EmployeeID)";
            Data_Emp_View EmployeesView = new Data_Emp_View();
            EmployeesView.LoadEmployees_OnQuery(query);
            EmployeesView.sRow = SelectedRow;
            EmployeesView.ShowDialog();
            try
            {
                if (SelectedRow.Status == ParameterStatus.Selected && SelectedRow != null && SMSTypeID.Text != "")
                {
                    string res = WS.svc.Execute_Query("insert into SMS_Contacts (SMSContactID,SMSTypeID) values('" + SelectedRow.SelectedDataRow["EmployeeID"].ToString() + "','" + this.SMSTypeID.Text + "')");
                    if (res != "**SUCCESS##")
                    {
                        XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        try
                        {
                            this.gridView1.Columns.Clear();
                            DataSet ds_Contacts = WS.svc.Get_DataSet("Select * from SMS_ContactsList where SMSTypeID='" + SMSTypeID.Text + "'");
                            this.gridControl1.DataSource = ds_Contacts.Tables[0];
                            this.gridView1.Columns[0].Width = 20 * this.gridControl1.Width / 100;
                            this.gridView1.Columns[1].Width = 20 * this.gridControl1.Width / 100;
                            this.gridView1.Columns[2].Width = 50 * this.gridControl1.Width / 100;
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            SelectedContact.SelectedDataRow = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
            if (SelectedContact.SelectedDataRow != null)
            {
                this.RemoveContacts.Enabled = true;
            }
            else
                this.RemoveContacts.Enabled = false;
        }

        private void RemoveContacts_Click(object sender, EventArgs e)
        {
            try
            {
                string res = WS.svc.Execute_Query("delete from SMS_Contacts where SMSContactID='" + SelectedContact.SelectedDataRow["SMSContactID"].ToString() + "'  and SMSTypeID='" + this.SMSTypeID.Text + "'");
                if (res != "**SUCCESS##")
                {
                    XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    try
                    {
                        this.gridView1.Columns.Clear();
                        DataSet ds_Contacts = WS.svc.Get_DataSet("Select * from SMS_ContactsList where SMSTypeID='" + SMSTypeID.Text + "'");
                        this.gridControl1.DataSource = ds_Contacts.Tables[0];
                        this.gridView1.Columns[0].Width = 20 * this.gridControl1.Width / 100;
                        this.gridView1.Columns[1].Width = 20 * this.gridControl1.Width / 100;
                        this.gridView1.Columns[2].Width = 50 * this.gridControl1.Width / 100;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SMSDelete_Click(object sender, EventArgs e)
        {
            if (this.SMSTypeID.Text == "")
                return;
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete " + this.SMSTypeID.Text + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
            try
            {
                string res = WS.svc.Execute_Query("delete from SMS_Types where SMSTypeID='" + this.SMSTypeID.Text + "");
                if (res == "**SUCCESS##")
                {
                    string smsres = WS.svc.SMS_ReloadSMSTypes();
                    this.SMS.Text = "";
                    this.SMSCondition.EditValue = null;
                    this.SMSDescription.Text = "";
                    this.SMSKeyword.EditValue = null;
                    this.SMSTypeID.Text = "";
                                      this.gridView1.Columns.Clear();
                  
                }
                else
                {
                    XtraMessageBox.Show(res, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SMSAddKeyword_Click(object sender, EventArgs e)
        {
            this.SMS.Text += this.SMSKeyword.EditValue.ToString();
        }
    }
}