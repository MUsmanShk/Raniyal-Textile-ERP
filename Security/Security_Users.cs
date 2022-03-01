using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Linq;
using System.Linq.Expressions;
namespace MachineEyes.Security
{
    
    public partial class Security_Users : DevExpress.XtraEditors.XtraForm
    {
        public selectedrow SelectedRow = new selectedrow();
        
        private byte[] image;
        public Security_Users()
        {
            InitializeComponent();
           
            Get_Dept();
            this.treeList1.SelectImageList = Program.MainWindow.CauseImages;
            
        }
        private bool ConverttoBoolean(string b)
        {
            if (b == "")
                return false;
            else if (b == "1")
                return true;
            else return false;

        }

        private void AppendNodes()
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            DataSet ds = WS.svc.Get_DataSet("select * from SP_SecurityRights where UserID='"+this.UserID.Tag.ToString()+"'");
            ds.Tables[0].TableName = "PP_SecurityRights";

            treeList1.ClearNodes();
            if (ds == null) return;
            if (ds.Tables[0].Rows.Count <= 0) return;
            treeList1.BeginUnboundLoad();
            TreeListNode nodeI;
            TreeListNode nodeII;
        
           
            var I = from t in ds.Tables[0].AsEnumerable()
                    group t by new { GroupID = t["iUniqueGroupID"], GroupName = t["SecurityGroupName"] }
                        into groupedTable
                        select new
                        {
                            GroupID = groupedTable.Key.GroupID,
                            GroupName = groupedTable.Key.GroupName
                        };

           



            foreach (var rowI in I)
            {
                if (rowI.GroupID.ToString() != "")
                {
                    nodeI = treeList1.AppendNode(new object[] { rowI.GroupName.ToString() }, null);
                    nodeI.Tag = rowI.GroupID.ToString();
                    nodeI.ImageIndex = MachineEyes.Classes.Security.GetGroupImageIndex(rowI.GroupID.ToString());

                    var II = from t in ds.Tables[0].AsEnumerable()
                             where t.Field<string>("iUniqueGroupID") == rowI.GroupID.ToString()
                             group t by new { UniqueID = t["iUniqueName"], UniqueName = t["iDescription"],Permission=t["Permission"] }
                                 into groupedTable
                                 select new
                                 {
                                     UniqueID = groupedTable.Key.UniqueID,
                                     UniqueName = groupedTable.Key.UniqueName,
                                     Permission=groupedTable.Key.Permission
                                 };

                    foreach (var rowII in II)
                    {
                        if (rowII.UniqueID.ToString() != "")
                        {
                            
                            nodeI.HasChildren = true;
                            nodeII = treeList1.AppendNode(new object[] { rowII.UniqueName.ToString() }, nodeI.Id);
                            nodeII.Tag = rowII.UniqueID.ToString();
                            nodeII.ImageIndex = rowII.Permission.ToString() == "1" ? (int)PermissionState.Permitted : (int)PermissionState.NotPermitted;
                            nodeII.SelectImageIndex = nodeII.ImageIndex;
                            nodeII.Checked = rowII.Permission.ToString() == "1" ? true : false;
                            //DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = (DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit)nodeII.TreeList.Columns["Permission"].ColumnEdit;
                           //chk.ima= rowII.Permission.ToString() == "1" ? 147 : false;
                          
                         // repositoryItemCheckEdit1 = (repositoryItemCheckEdit1) nodeII.TreeList.Columns["Permission"].ColumnEdit
                            
                        }
                    }



                }
            }
           
            treeList1.EndUnboundLoad();

            Cursor.Current = currentCursor;
        }
        private void ClearUserSystemRights()
        {
            this.isERPUser.EditValue = "0";
            this.doAddDocument.Checked = false;
            
            this.doDeleteAuthorizedDoc.Checked = false;
            this.doDeleteCancelledDoc.Checked = false;
            this.doDeleteClosedDoc.Checked = false;
            this.doDeleteOpenDoc.Checked = false;
            this.doEditAuthorizedDoc.Checked = false;
            this.doEditCancelledDoc.Checked = false;
            this.doEditClosedDoc.Checked = false;
            this.doEditOpenDoc.Checked = false;
            this.doImpactAuthorizedDoc.Checked = false;
            this.doImpactCancelledDoc.Checked = false;
            this.doImpactClosedDoc.Checked = false;
            this.doImpactOpenDoc.Checked = false;
            this.doMonitoring.Checked = false;
            this.doSpecialB.Checked = false;
            this.doSpecialG.Checked = false;
            this.doSpecialN.Checked = false;
            this.doStateAuthorizedDoc.Checked = false;
            this.doStateCancelledDoc.Checked = false;
            this.doStateClosedDoc.Checked = false;
            this.doStateOpenDoc.Checked = false;
        }
        private bool ConvertoBoolean(string i)
        {
            if (i == "")
                return false;
            if (i == "1")
                return true;
            else return false;
        }
        private void FillUserSystemRights(string EmployeeID)
        {
            ClearUserSystemRights();
            DataSet ds = WS.svc.Get_DataSet("select * from PP_Employees where EmployeeID='" + EmployeeID + "'");
            if (ds != null)
            {
               this.isERPUser.EditValue = ds.Tables[0].Rows[0]["isERPUser"].ToString();

               if (ds.Tables[0].Rows[0]["Password"].ToString() != "")
                   this.Password.Text = MachineEyes.Classes.Security.DecryptData(this.UserID.Tag.ToString(), ds.Tables[0].Rows[0]["Password"].ToString());
               else
                   this.Password.Text = "";

               this.doAddDocument.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["CanAdd_OpenDoc"].ToString());

               this.doDeleteAuthorizedDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["CanAdd_OpenDoc"].ToString());
               this.doMonitoring.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["CanDo_Monitoring"].ToString());
               this.doDeleteCancelledDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["CanDel_CancelledDoc"].ToString());
               this.doDeleteClosedDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["CanDel_ClosedDoc"].ToString());
               this.doDeleteOpenDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["CanDel_OpenDoc"].ToString());

               this.doEditAuthorizedDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["CanEdit_AuthorizedDoc"].ToString());
               this.doEditCancelledDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["CanEdit_CancelledDoc"].ToString());
               this.doEditClosedDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["CanEdit_ClosedDoc"].ToString());
               this.doEditOpenDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["CanEdit_OpenDoc"].ToString());

               this.doImpactAuthorizedDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["ChangeImpact_AuthorizedDoc"].ToString());
               this.doImpactCancelledDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["ChangeImpact_CancelledDoc"].ToString());
               this.doImpactClosedDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["ChangeImpact_ClosedDoc"].ToString());
               this.doImpactOpenDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["ChangeImpact_OpenDoc"].ToString());

               this.doSpecialB.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["Rights_B"].ToString());
               this.doSpecialG.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["Rights_G"].ToString());
               this.doSpecialN.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["Rights_N"].ToString());

               this.doStateAuthorizedDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["ChangeState_AuthorizedDoc"].ToString());
               this.doStateCancelledDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["ChangeState_CancelledDoc"].ToString());
               this.doStateClosedDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["ChangeState_ClosedDoc"].ToString());
               this.doStateOpenDoc.Checked = ConvertoBoolean(ds.Tables[0].Rows[0]["ChangeState_OpenDoc"].ToString());
            }
        }
        private void LoadEmployees(bool onQuery)
        {
            string query = "select * from QP_Employees where SubDepartmentID='" + this.Department.EditValue.ToString() + "' and isERPUser=1 order by Convert(numeric(18),EmployeeID)";
            Data_Emp_View EmployeesView = new Data_Emp_View();
            if(onQuery==false)
            EmployeesView.LoadEmployees(this.Department.EditValue.ToString());
            else
                EmployeesView.LoadEmployees_OnQuery(query);
            EmployeesView.sRow = SelectedRow;
            EmployeesView.ShowDialog();
            if (SelectedRow.Status == ParameterStatus.Selected && SelectedRow != null)
            {

                this.UserID.Tag = this.SelectedRow.SelectedDataRow["EmployeeID"].ToString();
                this.UserID.Text = this.SelectedRow.SelectedDataRow["EmployeeID"].ToString();
                this.UserName.Text = this.SelectedRow.SelectedDataRow["EmployeeName"].ToString();
                this.RFID.Text = this.SelectedRow.SelectedDataRow["ERFID"].ToString();
                this.Address.Text = this.SelectedRow.SelectedDataRow["Address"].ToString();
                this.CNIC.Text = this.SelectedRow.SelectedDataRow["EmployeeNIC"].ToString();
                this.Mobile_1.Text = this.SelectedRow.SelectedDataRow["Mobile_1"].ToString();
                this.Mobile_2.Text = this.SelectedRow.SelectedDataRow["Mobile_2"].ToString();
                this.Mobile_3.Text = this.SelectedRow.SelectedDataRow["Mobile_3"].ToString();
                if (this.SelectedRow.SelectedDataRow["Picture"].ToString() != "")
                {
                    image = (byte[])this.SelectedRow.SelectedDataRow["Picture"];
                    this.pictureEdit1.Image = Program.byteArrayToImage(image);
                    //ImageConverter IC = new ImageConverter();
                    //this.pictureEdit1.Image = (System.Drawing.Image)IC.ConvertFrom(this.SelectedRow.SelectedDataRow["Picture"]);
                }
                else
                {
                    this.pictureEdit1.Image = MachineEyes.Properties.Resources.technician;
                    image = Program.imageToByteArray(MachineEyes.Properties.Resources.technician);

                }

                this.Status.Text = this.SelectedRow.SelectedDataRow["EmpStatus"].ToString();




                this.Designation.Text = this.SelectedRow.SelectedDataRow["DesignationID"].ToString();






            }
        }
        private void BrowseEmployees_Click(object sender, EventArgs e)
        {
            if (this.Department.EditValue == null)
            {
                XtraMessageBox.Show("Must select Department related to employee first for filteration", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadEmployees(false);
        }

        private void UpdateSystemRights_Click(object sender, EventArgs e)
        {

            if (this.UserID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid User Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to update system rights for user " + this.UserName.Text + " ? ", "System Rights Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
            string[] queries = new string[0];
            Array.Resize(ref queries, 1);
            queries[0] = "update PP_Employees set ";
           
          
                queries[0] += "isERPUser='" + this.isERPUser.EditValue.ToString() + "'";
            
            if (this.doAddDocument.Checked==true)
                queries[0] += ",CanAdd_OpenDoc=1";
            else
                queries[0] += ",CanAdd_OpenDoc=0";
            string encpassword ="";
            if(Password.Text !="")
            encpassword= MachineEyes.Classes.Security.EncryptData(this.UserID.Tag.ToString(), this.Password.Text);
            else
                encpassword ="";
            if (encpassword !="")
                queries[0] += ",Password='"+encpassword+"'";
            else
                queries[0] += ",Password=null";

            if (this.doSpecialG.Checked == true)
                queries[0] += ",Rights_G=1";
            else
                queries[0] += ",Rights_G=0";
            if (this.doSpecialN.Checked == true)
                queries[0] += ",Rights_N=1";
            else
                queries[0] += ",Rights_N=0";
            if (this.doSpecialB.Checked == true)
                queries[0] += ",Rights_B=1";
            else
                queries[0] += ",Rights_B=0";


            if (this.doEditAuthorizedDoc.Checked == true)
                queries[0] += ",CanEdit_AuthorizedDoc=1";
            else
                queries[0] += ",CanEdit_AuthorizedDoc=0";
            if (this.doEditOpenDoc.Checked == true)
                queries[0] += ",CanEdit_OpenDoc=1";
            else
                queries[0] += ",CanEdit_OpenDoc=0";
            if (this.doEditClosedDoc.Checked == true)
                queries[0] += ",CanEdit_ClosedDoc=1";
            else
                queries[0] += ",CanEdit_ClosedDoc=0";
            if (this.doEditCancelledDoc.Checked == true)
                queries[0] += ",CanEdit_CancelledDoc=1";
            else
                queries[0] += ",CanEdit_CancelledDoc=0";


            if (this.doDeleteAuthorizedDoc.Checked == true)
                queries[0] += ",CanDel_AuthorizedDoc=1";
            else
                queries[0] += ",CanDel_AuthorizedDoc=0";
            
            if (this.doDeleteOpenDoc.Checked == true)
                queries[0] += ",CanDel_OpenDoc=1";
            else
                queries[0] += ",CanDel_OpenDoc=0";
            if (this.doDeleteClosedDoc.Checked == true)
                queries[0] += ",CanDel_ClosedDoc=1";
            else
                queries[0] += ",CanDel_ClosedDoc=0";
            if (this.doDeleteCancelledDoc.Checked == true)
                queries[0] += ",CanDel_CancelledDoc=1";
            else
                queries[0] += ",CanDel_CancelledDoc=0";

            if (this.doImpactAuthorizedDoc.Checked == true)
                queries[0] += ",ChangeImpact_AuthorizedDoc=1";
            else
                queries[0] += ",ChangeImpact_AuthorizedDoc=0";

            if (this.doImpactOpenDoc.Checked == true)
                queries[0] += ",ChangeImpact_OpenDoc=1";
            else
                queries[0] += ",ChangeImpact_OpenDoc=0";

            if (this.doImpactClosedDoc.Checked == true)
                queries[0] += ",ChangeImpact_ClosedDoc=1";
            else
                queries[0] += ",ChangeImpact_ClosedDoc=0";
            if (this.doImpactCancelledDoc.Checked == true)
                queries[0] += ",ChangeImpact_CancelledDoc=1";
            else
                queries[0] += ",ChangeImpact_CancelledDoc=0";

            if (this.doStateAuthorizedDoc.Checked == true)
                queries[0] += ",ChangeState_AuthorizedDoc=1";
            else
                queries[0] += ",ChangeState_AuthorizedDoc=0";

            if (this.doStateOpenDoc.Checked == true)
                queries[0] += ",ChangeState_OpenDoc=1";
            else
                queries[0] += ",ChangeState_OpenDoc=0";

            if (this.doStateClosedDoc.Checked == true)
                queries[0] += ",ChangeState_ClosedDoc=1";
            else
                queries[0] += ",ChangeState_ClosedDoc=0";
            if (this.doStateCancelledDoc.Checked == true)
                queries[0] += ",ChangeState_CancelledDoc=1";
            else
                queries[0] += ",ChangeState_CancelledDoc=0";
            if (this.doMonitoring.Checked == true)
                queries[0] += ",CanDo_Monitoring=1";
            else
                queries[0] += ",CanDo_Monitoring=0";
            queries[0] += " where EmployeeID='" + this.UserID.Tag.ToString() + "'";
           
            
            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    this.xtraTabControl1.SelectedTabPage = tabUserInfo;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        public void Get_Dept()
        {
            DataSet ds_Dept;
            this.Department.Properties.Columns.Clear();
            ds_Dept = WS.svc.Get_DataSet("select SubDepartmentID,SubDepartment from PP_DepartmentsSub  ");
            this.Department.Properties.DataSource = ds_Dept.Tables[0];
            this.Department.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubDepartment"));
            this.Department.Properties.DisplayMember = "SubDepartment";
            this.Department.Properties.ValueMember = "SubDepartmentID";
        }
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tabSystemRights)
            {
                if (this.UserID.Tag != null)
                {
                    if (this.UserID.Tag.ToString() != "")
                    {
                        FillUserSystemRights(this.UserID.Tag.ToString());
                    }
                }
            }
        }

        private void LoadSecurityRights_Click(object sender, EventArgs e)
        {
            AppendNodes();
        }

        private void RefillSecurityRights_Click(object sender, EventArgs e)
        {
           
        }

        private void treeList1_SelectImageClick(object sender, NodeClickEventArgs e)
        {

        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void treeList1_NodeChanged(object sender, NodeChangedEventArgs e)
        {
           
        }

        private void treeList1_AfterCheckNode(object sender, NodeEventArgs e)
        {
            TreeListNode SelectedNode = e.Node;
            if (SelectedNode != null)
            {
                if (SelectedNode.Tag != null && SelectedNode.Checked == true)
                {
                    string res = WS.svc.Execute_Query("update PP_SecurityRights set Permission=1 where UserID='" + this.UserID.Tag.ToString() + "' and iUniqueName='" + SelectedNode.Tag.ToString() + "'");
                    if (res != "**SUCCESS##")
                    {
                        XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        SelectedNode.ImageIndex = (int)PermissionState.Permitted;
                        SelectedNode.SelectImageIndex = SelectedNode.ImageIndex;
                    }

                }
                else if (SelectedNode.Tag != null && SelectedNode.Checked ==false)
                {
                    string res = WS.svc.Execute_Query("update PP_SecurityRights set Permission=0 where UserID='" + this.UserID.Tag.ToString() + "' and iUniqueName='" + SelectedNode.Tag.ToString() + "'");
                    if (res != "**SUCCESS##")
                    {
                        XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        SelectedNode.ImageIndex = (int)PermissionState.NotPermitted;
                        SelectedNode.SelectImageIndex = SelectedNode.ImageIndex;
                    }
                }
            }
        }

        private void BrowseUsers_Click(object sender, EventArgs e)
        {
            if (this.Department.EditValue == null)
            {
                XtraMessageBox.Show("Must select Department related to employee first for filteration", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadEmployees(true);
        }

        private void CloseDocument_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReassignRights_Click(object sender, EventArgs e)
        {
            DialogResult dg = XtraMessageBox.Show("this action will reassign all user rights to default level ...are you sure to continue ?", "Security Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
            if (this.UserID.Tag == null)
            {
                XtraMessageBox.Show("invalid user selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string res = WS.svc.Execute_Query("delete from PP_SecurityRights where UserID='" + this.UserID.Tag.ToString() + "'");
                if (res != "**SUCCESS##")
                {
                    XtraMessageBox.Show(res, "Error executing query", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "Error executing query", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                this.treeList1.ClearNodes();
                DataSet ds = WS.svc.Get_DataSet("select * from PP_SecurityItems");
                if (ds == null) return;
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    string res = WS.svc.Execute_Query("insert into PP_SecurityRights (iUniqueName,UserID,Permission) values('" + ds.Tables[0].Rows[x]["iUniqueName"].ToString() + "','" + this.UserID.Tag.ToString() + "',0)");
                    if (res != "**SUCCESS##")
                    {
                        XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                AppendNodes();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error executing statement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void DeleteRights_Click(object sender, EventArgs e)
        {
            if (this.UserID.Tag == null)
            {
                XtraMessageBox.Show("invalid user selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dg = XtraMessageBox.Show("this action will revoke all user rights from " + this.UserName.Text + " \n Are you sure to continue ? ", "Security Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
           
            try
            {
                string res = WS.svc.Execute_Query("delete from PP_SecurityRights where UserID='" + this.UserID.Tag.ToString() + "'");
                if (res != "**SUCCESS##")
                {
                    XtraMessageBox.Show(res, "Error executing query", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    this.treeList1.Nodes.Clear();
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "Error executing query", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void tabInterfaceRights_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddUnAssigned_Click(object sender, EventArgs e)
        {
            DialogResult dg = XtraMessageBox.Show("this action will assign all user rights which have not been yet assigned ...are you sure to continue ?", "Security Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
            if (this.UserID.Tag == null)
            {
                XtraMessageBox.Show("invalid user selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            try
            {
                this.treeList1.ClearNodes();
                DataSet ds = WS.svc.Get_DataSet("select * from PP_SecurityItems where iUniqueName not in(select iUniqueName from PP_SecurityRights where UserID='"+this.UserID.Tag.ToString()+"')");
                if (ds == null) return;
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    string res = WS.svc.Execute_Query("insert into PP_SecurityRights (iUniqueName,UserID,Permission) values('" + ds.Tables[0].Rows[x]["iUniqueName"].ToString() + "','" + this.UserID.Tag.ToString() + "',0)");
                    if (res != "**SUCCESS##")
                    {
                        XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                AppendNodes();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error executing statement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}