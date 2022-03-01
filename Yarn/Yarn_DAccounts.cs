using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Yarn
{
    public partial class Yarn_DAccounts : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        public Yarn_DAccounts()
        {
            InitializeComponent();
            this.btn_Save.Enabled = false;
            this.btn_Cancel.Enabled = false;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = false;
            this.btn_Del.Enabled = false;
            this.btn_Refresh.Enabled = true;
            this.btn_View.Enabled = true;
            this.btn_Close.Enabled = true;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            uiMode = UserInputMode.Add;
            GetNextNumber();
            this.btn_Add.Enabled = false;
            this.btn_Cancel.Enabled = true;
            this.btn_Save.Enabled = true;
            this.btn_Edit.Enabled = false;
            this.btn_Close.Enabled = true;
            this.btn_View.Enabled = false;
            this.btn_Del.Enabled = false;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            uiMode = UserInputMode.Edit;
            this.btn_Save.Enabled = true;
            this.btn_Cancel.Enabled = true;
            this.btn_Add.Enabled = false;
            this.btn_Edit.Enabled = false;
            this.btn_Del.Enabled = false;
            this.btn_Refresh.Enabled = false;
            this.btn_View.Enabled = false;
            this.btn_Close.Enabled = true;
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            uiMode = UserInputMode.Delete;
            this.btn_Add.Enabled = false;
            this.btn_Cancel.Enabled = true;
            this.btn_Save.Enabled = true;
            this.btn_Edit.Enabled = false;
            this.btn_Close.Enabled = true;
            this.btn_Del.Enabled = false;
            this.btn_View.Enabled = false;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            this.btn_Save.Enabled = false;
            this.btn_Cancel.Enabled = false;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = true;
            this.btn_Del.Enabled = true;
            this.btn_Refresh.Enabled = true;
            this.btn_View.Enabled = true;
            this.btn_Close.Enabled = true;


            this.DepartmentID.Text = "";
            this.DepartmentName.Text = "";
           
        }
        private bool GetNextNumber()
        {
            string vNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),InOutDeptTypesID))+1 as MaxNumber  from YN_INOutDeptTypes";
                    vNumber = WS.svc.Get_MaxNumber(query);
                    if (vNumber.Length > 3)
                    {
                        XtraMessageBox.Show("invalid length of department id found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                    vNumber = vNumber.PadLeft(3, '0');
                    this.DepartmentID.Text = vNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                return false;
            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (uiMode == UserInputMode.Edit)
            {
                if (this.DepartmentID.Tag == null)
                {
                    XtraMessageBox.Show("invalid Department selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.DepartmentID.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("invalid Department selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Do you sure want to Edit this Record?"
                    + this.DepartmentID.Tag.ToString() + "", "Confirm Service", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string retval = WS.svc.Execute_Query("Update YN_INOutDeptTypes set InOutDeptTypesID='" + DepartmentID.Text + "',InOutDeptTypesName='" + DepartmentName.Text + "',InOnly="+this.RadioInOnly.EditValue.ToString()+" where InOutDeptTypesID='" + this.DepartmentID.Tag.ToString() + "'");
                    if (retval != "**SUCCESS##")
                    {
                        XtraMessageBox.Show(retval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    else
                    {
                        this.DepartmentID.Text = "";
                        this.DepartmentName.Text = "";
                        this.DepartmentID.Tag = null;
                    }

                }
            }
            else if (uiMode == UserInputMode.Add)
            {
                if (this.DepartmentID.Text == "")
                {
                    XtraMessageBox.Show("invalid Department ID", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.DepartmentID.Text.Length != 3)
                {
                    XtraMessageBox.Show("invalid Department ID", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.DepartmentName.Text == "")
                {
                    XtraMessageBox.Show("invalid Department Name", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                //execute save query (save records into database)
                string retval = WS.svc.Execute_Query("insert into YN_InOutDeptTypes (InOutDeptTypesID,InOutDeptTypesName,InOnly) VALUES ('" + DepartmentID.Text + "', '" + DepartmentName.Text + "',"+this.RadioInOnly.EditValue.ToString()+")");
                if (retval != "**SUCCESS##")
                {
                    XtraMessageBox.Show(retval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    this.DepartmentID.Text = "";
                    this.DepartmentName.Text = "";
                }


                //add one row to grid and add the record from textboxers to grid



            }
            else if (uiMode == UserInputMode.Delete)
            {
                if (this.DepartmentID.Tag == null)
                {
                    XtraMessageBox.Show("invalid Department selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.DepartmentID.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("invalid Department selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (XtraMessageBox.Show("Do you sure want to Delete this Record?"
                    + this.DepartmentID.Text + "", "Confirm Service", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string retval = WS.svc.Execute_Query("delete from YN_InOutDeptTypes where InoutDeptTypesID='" + DepartmentID.Tag.ToString() + "'");
                    if (retval != "**SUCCESS##")
                    {

                        XtraMessageBox.Show(retval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    else
                    {
                        this.DepartmentName.Text = "";
                        this.DepartmentID.Text = "";
                        this.DepartmentID.Tag = null;
                    }

                }


            }


            uiMode = UserInputMode.View;
            this.btn_Save.Enabled = false;
            this.btn_Cancel.Enabled = false;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = false;
            this.btn_Del.Enabled = false;
            this.btn_Refresh.Enabled = true;
            this.btn_View.Enabled = true;
            this.btn_Close.Enabled = true;
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();

            strFilterQuery += "select InOutDeptTypesID,InOutDeptTypesName,InOnly from YN_InOutDeptTypes ORDER BY Convert(numeric(18),InOutDeptTypesID) DESC ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "InOutDeptTypesID", "InOutDeptTypesName");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.RefID.Text = sRow.PrimeryID;
                this.RefID.Tag = sRow.PrimeryID;
                this.RefName.Text = sRow.PrimaryString;
                this.DepartmentID.Text = sRow.PrimeryID;
                this.DepartmentID.Tag = sRow.PrimeryID;
                this.DepartmentName.Text = sRow.PrimaryString;
                this.RadioInOnly.EditValue = sRow.SelectedDataRow["InOnly"].ToString();
                this.btn_Save.Enabled = false;
                this.btn_Cancel.Enabled = false;
                this.btn_Add.Enabled = true;
                this.btn_Edit.Enabled = true;
                this.btn_Del.Enabled = true;
                this.btn_Refresh.Enabled = true;
                this.btn_View.Enabled = true;
                this.btn_Close.Enabled = true;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            uiMode = UserInputMode.View;
            this.btn_Save.Enabled = false;
            this.btn_Cancel.Enabled = false;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = false;
            this.btn_Del.Enabled = false;
            this.btn_Refresh.Enabled = true;
            this.btn_View.Enabled = true;
            this.btn_Close.Enabled = true;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_SubDepartment_Click(object sender, EventArgs e)
        {
            if (this.DepartmentID.Tag == null)
            {
                XtraMessageBox.Show("invalid department id selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.DepartmentID.Tag.ToString().Length != 3)
            {
                XtraMessageBox.Show("invalid department id selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.RefID.Tag == null)
            {
                XtraMessageBox.Show("invalid department id selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.RefID.Tag.ToString().Length != 3)
            {
                XtraMessageBox.Show("invalid department id selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            uiMode = UserInputMode.Add;
            GetNextSubDepartmentNumber();
            this.Add_SubDepartment.Enabled = false;
            this.Cancel_SubDepartment.Enabled = true;
            this.Execute_SubDepartment.Enabled = true;
            this.Edit_SubDepartment.Enabled = false;
            this.Close_SubDepartment.Enabled = true;
            this.View_SubDepartment.Enabled = false;
            this.Delete_SubDepartment.Enabled = false;
        }

        private void Execute_SubDepartment_Click(object sender, EventArgs e)
        {
            if (uiMode == UserInputMode.Edit)
            {
                if (this.SubDepartmentID.Tag == null)
                {
                    XtraMessageBox.Show("invalid Sub Department selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.SubDepartmentID.Tag.ToString().Length != 5)
                {
                    XtraMessageBox.Show("invalid Department selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Do you sure want to Edit this Record?"
                    + this.SubDepartmentID.Tag.ToString() + "", "Confirm Service", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string retval = WS.svc.Execute_Query("Update YN_InOutDAccounts set DAccountID='" + SubDepartmentID.Text + "',DAccountName='" + SubDepartmentName.Text + "',InOutDeptID where DAccountID='" + this.SubDepartmentID.Tag.ToString() + "'");
                    if (retval != "**SUCCESS##")
                    {
                        XtraMessageBox.Show(retval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    else
                    {
                        this.SubDepartmentID.Text = "";
                        this.SubDepartmentName.Text = "";
                        this.SubDepartmentID.Tag = null;

                    }

                }
            }
            else if (uiMode == UserInputMode.Add)
            {
                if (this.SubDepartmentID.Text == "")
                {
                    XtraMessageBox.Show("invalid Sub Department ID", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.SubDepartmentID.Text.Length != 5)
                {
                    XtraMessageBox.Show("invalid Sub Department ID", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.SubDepartmentName.Text == "")
                {
                    XtraMessageBox.Show("invalid Sub Department Name", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                //execute save query (save records into database)
                string retval = WS.svc.Execute_Query("insert into YN_InOutDAccounts (DAccountID,DAccountName,InOutDeptID) VALUES ('" + SubDepartmentID.Text + "', '" + SubDepartmentName.Text + "','" + this.DepartmentID.Tag.ToString() + "')");
                if (retval != "**SUCCESS##")
                {
                    XtraMessageBox.Show(retval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    this.SubDepartmentID.Text = "";
                    this.SubDepartmentName.Text = "";
                }


                //add one row to grid and add the record from textboxers to grid



            }
            else if (uiMode == UserInputMode.Delete)
            {
                if (this.SubDepartmentID.Tag == null)
                {
                    XtraMessageBox.Show("invalid Sub Department selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.SubDepartmentID.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("invalid Sub Department selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (XtraMessageBox.Show("Do you sure want to Delete this Record?"
                    + this.SubDepartmentID.Text + "", "Confirm Service", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string retval = WS.svc.Execute_Query("delete from YN_INOutDAccounts where DAccountID='" + SubDepartmentID.Tag.ToString() + "'");
                    if (retval != "**SUCCESS##")
                    {

                        XtraMessageBox.Show(retval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    else
                    {
                        this.SubDepartmentName.Text = "";
                        this.SubDepartmentID.Text = "";
                        this.SubDepartmentID.Tag = null;
                    }

                }


            }



            uiMode = UserInputMode.View;
            this.Execute_SubDepartment.Enabled = false;
            this.Cancel_SubDepartment.Enabled = false;
            this.Add_SubDepartment.Enabled = true;
            this.Edit_SubDepartment.Enabled = false;
            this.Delete_SubDepartment.Enabled = false;
            this.Refresh_SubDepartment.Enabled = true;
            this.View_SubDepartment.Enabled = true;
            this.Close_SubDepartment.Enabled = true;
        }

        private void Edit_SubDepartment_Click(object sender, EventArgs e)
        {
            if (this.SubDepartmentID.Tag == null)
            {
                XtraMessageBox.Show("invalid sub department selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.SubDepartmentID.Tag.ToString().Length != 5)
            {
                XtraMessageBox.Show("invalid sub department selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            uiMode = UserInputMode.Edit;

            this.Add_SubDepartment.Enabled = false;
            this.Cancel_SubDepartment.Enabled = true;
            this.Execute_SubDepartment.Enabled = true;
            this.Edit_SubDepartment.Enabled = false;
            this.Close_SubDepartment.Enabled = true;
            this.View_SubDepartment.Enabled = false;
            this.Delete_SubDepartment.Enabled = false;
        }

        private void Delete_SubDepartment_Click(object sender, EventArgs e)
        {
            if (this.SubDepartmentID.Tag == null)
            {
                XtraMessageBox.Show("invalid sub department selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.SubDepartmentID.Tag.ToString().Length != 5)
            {
                XtraMessageBox.Show("invalid sub department selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            uiMode = UserInputMode.Delete;

            this.Add_SubDepartment.Enabled = false;
            this.Cancel_SubDepartment.Enabled = true;
            this.Execute_SubDepartment.Enabled = true;
            this.Edit_SubDepartment.Enabled = false;
            this.Close_SubDepartment.Enabled = true;
            this.View_SubDepartment.Enabled = false;
            this.Delete_SubDepartment.Enabled = false;
        }

        private void View_SubDepartment_Click(object sender, EventArgs e)
        {
            if (this.DepartmentID.Tag == null)
            {
                XtraMessageBox.Show("select Department from Department Tab", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.DepartmentID.Tag.ToString().Length != 3)
            {
                XtraMessageBox.Show("select Department from Department Tab", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();

            strFilterQuery += "select DAccountID,DAccountName from YN_InOutDAccounts where InOutDeptID='" + this.DepartmentID.Tag.ToString() + "' ORDER BY Convert(numeric(18),DAccountID) DESC ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "DAccountID", "DAccountName");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.SubDepartmentID.Text = sRow.PrimeryID;
                this.SubDepartmentID.Tag = sRow.PrimeryID;
                this.SubDepartmentName.Text = sRow.PrimaryString;
                uiMode = UserInputMode.View;
                this.Execute_SubDepartment.Enabled = false;
                this.Cancel_SubDepartment.Enabled = false;
                this.Add_SubDepartment.Enabled = true;
                this.Edit_SubDepartment.Enabled = true;
                this.Delete_SubDepartment.Enabled = true;
                this.Refresh_SubDepartment.Enabled = true;
                this.View_SubDepartment.Enabled = true;
                this.Close_SubDepartment.Enabled = true;
            }
        }

        private void Cancel_SubDepartment_Click(object sender, EventArgs e)
        {
            uiMode = UserInputMode.View;
            this.Execute_SubDepartment.Enabled = false;
            this.Cancel_SubDepartment.Enabled = false;
            this.Add_SubDepartment.Enabled = true;
            this.Edit_SubDepartment.Enabled = false;
            this.Delete_SubDepartment.Enabled = false;
            this.Refresh_SubDepartment.Enabled = true;
            this.View_SubDepartment.Enabled = true;
            this.Close_SubDepartment.Enabled = true;
        }

        private void Close_SubDepartment_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool GetNextSubDepartmentNumber()
        {
            if (this.RefID.Tag == null) return false;
            if (this.RefID.Text == "") return false;
            if (this.RefID.Tag.ToString().Length != 3) return false;

            string vNumber; string query;
            try
            {
                try
                {
                    query = "select  max(Convert(numeric(18),SubString(DAccountID,4,2)))+1 as MaxNumber  from YN_InOutDAccounts where InOutDeptID='"+this.RefID.Tag+"'";
                    vNumber = WS.svc.Get_MaxNumber(query);
                    if (vNumber.Length > 2)
                    {
                        XtraMessageBox.Show("invalid length of D-Account id found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                    vNumber = vNumber.PadLeft(2, '0');
                    this.SubDepartmentID.Text = this.DepartmentID.Tag.ToString() + vNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                return false;
            }
        }
    }
}