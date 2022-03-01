using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
namespace MachineEyes
{
    public partial class Data_Emp : DevExpress.XtraEditors.XtraForm
    {
        MachineService.employee Employee = new MachineService.employee();
        public selectedrow SelectedRow = new selectedrow();
        private byte[] image;
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        
        public Data_Emp()
        {
            InitializeComponent();
        }
       
       
       
       
        public void Get_Dept()
        {
            DataSet ds_Dept;
            this.Emp_Dept_lookUpEdit1.Properties.Columns.Clear();
            ds_Dept = WS.svc.Get_DataSet("select SubDepartmentID,SubDepartment from PP_DepartmentsSub  ");
            this.Emp_Dept_lookUpEdit1.Properties.DataSource = ds_Dept.Tables[0];
            this.Emp_Dept_lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubDepartment"));
            this.Emp_Dept_lookUpEdit1.Properties.DisplayMember = "SubDepartment";
            this.Emp_Dept_lookUpEdit1.Properties.ValueMember = "SubDepartmentID";
        }
        public void Get_Status()
        {
            DataSet ds_Status;
            this.Emp_Status_lookUpEdit.Properties.Columns.Clear();
            ds_Status = WS.svc.Get_DataSet("select EmpStatusID,EmpStatus from PP_Employees_Status  ");
            this.Emp_Status_lookUpEdit.Properties.DataSource = ds_Status.Tables[0];
            this.Emp_Status_lookUpEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpStatus"));
            this.Emp_Status_lookUpEdit.Properties.DisplayMember = "EmpStatus";
            this.Emp_Status_lookUpEdit.Properties.ValueMember = "EmpStatusID";
        }
        public void Get_Desg()
        {
            DataSet ds_Desg;
            this.Emp_Desg_lookUpEdit1.Properties.Columns.Clear();
            ds_Desg = WS.svc.Get_DataSet("select DesignationID,Designation from PP_Employees_Designations  ");
            this.Emp_Desg_lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Designation"));
            this.Emp_Desg_lookUpEdit1.Properties.DataSource =ds_Desg.Tables[0];
            this.Emp_Desg_lookUpEdit1.Properties.DisplayMember = "Designation";
            this.Emp_Desg_lookUpEdit1.Properties.ValueMember = "DesignationID";
        }
       
        private string CheckValidation_Add()
        {
            if (this.Emp_ID_textEdit1.Text == "")
                return "Invalid Employee ID";
            if (this.Emp_Dept_lookUpEdit1.EditValue == null)
                return "Invalid Employee Department";
            if (this.Emp_Desg_lookUpEdit1.EditValue == null)
                return "Invalid Designation of Employee";
            if (this.Emp_Dept_lookUpEdit1.EditValue.ToString() == "")
                return "Invalid Dept ID";
            if (this.Emp_Desg_lookUpEdit1.EditValue.ToString() == "")
                return "invalid Designation ID";

                return "**SUCCESS##";
  
        }
        private string CheckValidation_Edit()
        {
            if (this.Emp_ID_textEdit1.Tag == null)
                return "Selected Employee is not valid";
            if (this.Emp_ID_textEdit1.Tag.ToString() == "")
                return "invalid Employee selected";

            
            if (this.Emp_Dept_lookUpEdit1.EditValue == null)
                return "Invalid Employee Department";
            if (this.Emp_Desg_lookUpEdit1.EditValue == null)
                return "Invalid Designation of Employee";
            if (this.Emp_Dept_lookUpEdit1.EditValue.ToString() == "")
                return "Invalid Dept ID";
            if (this.Emp_Desg_lookUpEdit1.EditValue.ToString() == "")
                return "invalid Designation ID";

            return "**SUCCESS##";



        }
        private string CheckValidation_Delete()
        {
            if (this.Emp_ID_textEdit1.Tag == null)
                return "Selected Employee is not valid";
            if (this.Emp_ID_textEdit1.Tag.ToString() == "")
                return "invalid Employee selected";

            return "**SUCCESS##";
        }
        private void dxData_Emp_Load(object sender, EventArgs e)
        {
            Get_Dept();
            Get_Desg();
            Get_Status();
            set_ButtonStates(UserInputMode.View);
            RefreshAndClear();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (this.Emp_Dept_lookUpEdit1.EditValue == null)
            {
                XtraMessageBox.Show("Select Department related to Employee", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string vNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(EmployeeID,6,5)))+1 as MaxNumber  from PP_Employees where SubDepartmentID='" + this.Emp_Dept_lookUpEdit1.EditValue.ToString() + "'";
                    vNumber = WS.svc.Get_MaxNumber(query);
                    if (vNumber.Length > 5)
                    {
                        XtraMessageBox.Show("Long length number than expected " + vNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    vNumber = vNumber.PadLeft(5, '0');
                    string vDept = this.Emp_Dept_lookUpEdit1.EditValue.ToString();
                    vDept = vDept.PadLeft(5, '0');
                    this.Emp_ID_textEdit1.Text = vDept+ vNumber;
                    
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                return;
            }


            set_ButtonStates(UserInputMode.Add);
        }
        private void set_ReadOnly(bool val)
        {
           // this.Emp_Dept_lookUpEdit1.Properties.ReadOnly = val;
           // this.Emp_Status_lookUpEdit.Properties.ReadOnly = val;
            this.Emp_RFID_textEdit1.Properties.ReadOnly = val;
            this.Emp_Name_textEdit1.Properties.ReadOnly = val;
            this.Emp_ID_textEdit1.Properties.ReadOnly = val;
           // this.Emp_Desg_lookUpEdit1.Properties.ReadOnly = val;
           // this.Emp_CNIC_textEdit1.Properties.ReadOnly = val;
            this.Emp_Address_richTextBox1.ReadOnly = val;
            this.Mob1_textEdit1.Properties.ReadOnly = val;
            this.Mob2_textEdit2.Properties.ReadOnly = val;
            this.Mob3_textEdit3.Properties.ReadOnly = val;

        }
        private void set_ButtonStates(UserInputMode uim)
        {
            uiMode = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    this.btn_Save.Enabled = false;
                    this.btn_Cancel.Enabled = false;
                    this.btn_Add.Enabled = true;
                    this.btn_Close.Enabled = true;
                    this.btn_View.Enabled = true;
                    set_ReadOnly(true);

                    if (this.Emp_ID_textEdit1.Tag  != null)
                    {
                        if (this.Emp_ID_textEdit1.Tag.ToString() != "")
                        {

                            this.btn_Edit.Enabled = true;
                            this.btn_Del.Enabled = true;
                            return;
                        }
                        else
                        {
                            this.btn_Edit.Enabled = false;
                            this.btn_Del.Enabled = false;
                        }
                    }
                    else
                    {
                        this.btn_Edit.Enabled = false;
                        this.btn_Del.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:

                    this.btn_Add.Enabled = false;
                    this.btn_Cancel.Enabled = true;
                    this.btn_Save.Enabled = true;
                    this.btn_Edit.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_View.Enabled = false;
                    this.btn_Del.Enabled = false;
                    set_ReadOnly(false);
                    break;
                case UserInputMode.Edit:
                    this.btn_Add.Enabled = false;
                    this.btn_Cancel.Enabled = true;
                    this.btn_Save.Enabled = true;
                    this.btn_Edit.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_Del.Enabled = false;
                    this.btn_View.Enabled = false;
                    set_ReadOnly(false);
                    break;
                case UserInputMode.Delete:
                    this.btn_Add.Enabled = false;
                    this.btn_Cancel.Enabled = true;
                    this.btn_Save.Enabled = true;
                    this.btn_Edit.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_Del.Enabled = false;
                    this.btn_View.Enabled = false;
                    set_ReadOnly(false);
                    break;
                default:
                    break;
            }

        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (uiMode == UserInputMode.Edit)
            {
                string retv = CheckValidation_Edit();
                if (retv != "**SUCCESS##")
                {
                    XtraMessageBox.Show(retv, "Validation Control Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                Employee.Address = this.Emp_Address_richTextBox1.Text;
                if (this.Emp_Dept_lookUpEdit1.EditValue != null)
                    Employee.DeptID = (string)this.Emp_Dept_lookUpEdit1.GetColumnValue(Emp_Dept_lookUpEdit1.Properties.ValueMember).ToString();
                else
                    Employee.DeptID = null;
                if (this.Emp_Desg_lookUpEdit1.EditValue != null)
                    Employee.DesignationID = (string)this.Emp_Desg_lookUpEdit1.GetColumnValue(Emp_Desg_lookUpEdit1.Properties.ValueMember).ToString();
                else
                    Employee.DesignationID = null;
                Employee.EmployeeID = this.Emp_ID_textEdit1.Tag.ToString();
                Employee.EmployeeName = this.Emp_Name_textEdit1.Text;
                Employee.EmployeeNIC = this.Emp_CNIC_textEdit1.Text;
                Employee.Mobile_1 = this.Mob1_textEdit1.Text;
                Employee.Mobile_2 = this.Mob2_textEdit2.Text;
                Employee.Mobile_3 = this.Mob3_textEdit3.Text;
                Employee.Picture = image;
                Employee.RFID = this.Emp_RFID_textEdit1.Text;
                if (this.Emp_Status_lookUpEdit.EditValue != null)
                    Employee.StatusID = (string)this.Emp_Status_lookUpEdit.GetColumnValue(Emp_Status_lookUpEdit.Properties.ValueMember).ToString();
                else
                    Employee.StatusID = null;
                //Employee.StatusID = "1";
                retv = WS.svc.Update_Employee(Employee);
                if (retv != "**SUCCESS##")
                {
                    XtraMessageBox.Show(retv, "Web Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    RefreshAndClear();
                }
 
               
            }
            else if (uiMode == UserInputMode.Add)
            {
                //check validation here
                string retv = CheckValidation_Add();
                if (retv != "**SUCCESS##")
                {
                    XtraMessageBox.Show(retv, "Validation Control Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                
                Employee.Address=this.Emp_Address_richTextBox1.Text;
                if (this.Emp_Dept_lookUpEdit1.EditValue != null)
                    Employee.DeptID = (string)this.Emp_Dept_lookUpEdit1.GetColumnValue(Emp_Dept_lookUpEdit1.Properties.ValueMember).ToString();
                else
                    Employee.DeptID = "";
                if (this.Emp_Desg_lookUpEdit1.EditValue != null)
                    Employee.DesignationID = (string)this.Emp_Desg_lookUpEdit1.GetColumnValue(Emp_Desg_lookUpEdit1.Properties.ValueMember).ToString();
                else
                    Employee.DesignationID = "";
                Employee.EmployeeID =this.Emp_ID_textEdit1.Text;
                Employee.EmployeeName =this.Emp_Name_textEdit1.Text;
                Employee.EmployeeNIC =this.Emp_CNIC_textEdit1.Text ;
                if (this.Emp_Status_lookUpEdit.EditValue != null)
                    Employee.StatusID = (string)this.Emp_Status_lookUpEdit.GetColumnValue(Emp_Status_lookUpEdit.Properties.ValueMember).ToString();
                else
                    Employee.StatusID = null;
                Employee.Mobile_1=this.Mob1_textEdit1.Text;
                Employee.Mobile_2 =this.Mob2_textEdit2.Text;
                Employee.Mobile_3 =this.Mob3_textEdit3.Text;
                Employee.Picture =image;
                Employee.RFID =this.Emp_RFID_textEdit1.Text;
               
                    retv = WS.svc.Insert_Employee(Employee);
                    if (retv != "**SUCCESS##")
                    {
                        XtraMessageBox.Show(retv, "Web Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        RefreshAndClear();
                    }

                

                //add one row to grid and add the record from textboxers to grid

            }
            else if (uiMode == UserInputMode.Delete)
            {
                string retv = CheckValidation_Delete();
                if (retv != "**SUCCESS##")
                {
                    XtraMessageBox.Show(retv, "Validation Control Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    return;

                }

                if (XtraMessageBox.Show("Do you sure want to Delete this Record?\r\nID "
                    + this.Emp_ID_textEdit1.Tag.ToString()+ "   \r\nName "
                    + this.Emp_Name_textEdit1.Text + "", "Confirm Service", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string retval = WS.svc.Execute_Query("delete from PP_Employees where EmployeeID=" + Emp_ID_textEdit1.Tag.ToString()  + "");
                    if (retval != "**SUCCESS##")
                    {
                        XtraMessageBox.Show(retval, "Web Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    else
                    {
                        RefreshAndClear();
                    }

                }


            }

            
            
            
           
        }
        private void RefreshAndClear()
        {
            this.Emp_ID_textEdit1.Text = "";
            this.Emp_Address_richTextBox1.Text = "";

            this.Emp_CNIC_textEdit1.Text = "";
            this.Emp_Dept_lookUpEdit1.EditValue = null;
            this.Emp_Desg_lookUpEdit1.EditValue = null;
            this.Emp_ID_textEdit1.Tag = "";
            this.Mob3_textEdit3.Text = "";
            this.Mob2_textEdit2.Text = "";
            this.Mob1_textEdit1.Text = "";
            this.Emp_Name_textEdit1.Text = "";
            this.Emp_RFID_textEdit1.Text = "";
            this.Employee = null;
            this.Employee = new MachineService.employee();
            this.image = null;
            pictureEdit1.Image = MachineEyes.Properties.Resources.technician;
            set_ButtonStates(UserInputMode.View);
            
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (Emp_ID_textEdit1.Tag == null)
            {
                XtraMessageBox.Show("Select Record to edit");
                return;
            }

            if (Emp_ID_textEdit1.Tag.ToString() == "")
            {
                XtraMessageBox.Show("You must select record ..");
                return;
            }
          
            set_ButtonStates(UserInputMode.Edit);
            
           
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (Emp_ID_textEdit1.Tag == null)
            {
                XtraMessageBox.Show("Select Record to edit");
                return;
            }

            if (Emp_ID_textEdit1.Tag.ToString() == "")
            {
                XtraMessageBox.Show("You must select record ..");
                return;
            }
           
            set_ButtonStates(UserInputMode.Delete);
            
        }

        
        private void btn_View_Click(object sender, EventArgs e)
        {
           
            if (this.Emp_Dept_lookUpEdit1.EditValue == null)
            {
                XtraMessageBox.Show("Must select Department related to employee first for filteration", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Data_Emp_View EmployeesView = new Data_Emp_View();
            EmployeesView.LoadEmployees(this.Emp_Dept_lookUpEdit1.EditValue.ToString());
            EmployeesView.sRow = SelectedRow;
            EmployeesView.ShowDialog();
            if (SelectedRow.Status==ParameterStatus.Selected && SelectedRow!=null)
            {
               
                    this.Emp_ID_textEdit1.Tag = this.SelectedRow.SelectedDataRow["EmployeeID"].ToString();
                    this.Emp_ID_textEdit1.Text = this.SelectedRow.SelectedDataRow["EmployeeID"].ToString();
                    this.Emp_Name_textEdit1.Text = this.SelectedRow.SelectedDataRow["EmployeeName"].ToString();
                    this.Emp_RFID_textEdit1.Text  = this.SelectedRow.SelectedDataRow["ERFID"].ToString();
                    this.Emp_Address_richTextBox1.Text  = this.SelectedRow.SelectedDataRow["Address"].ToString();
                     this.Emp_CNIC_textEdit1.Text  = this.SelectedRow.SelectedDataRow["EmployeeNIC"].ToString();
                    this.Mob1_textEdit1.Text  = this.SelectedRow.SelectedDataRow["Mobile_1"].ToString();
                    this.Mob2_textEdit2.Text  = this.SelectedRow.SelectedDataRow["Mobile_2"].ToString();
                    this.Mob3_textEdit3.Text  = this.SelectedRow.SelectedDataRow["Mobile_3"].ToString();
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
                    if (this.SelectedRow.SelectedDataRow["StatusID"].ToString() != "")
                        this.Emp_Status_lookUpEdit.EditValue =this.SelectedRow.SelectedDataRow["StatusID"];
                    else
                        this.Emp_Status_lookUpEdit.EditValue = null;
                    if (this.SelectedRow.SelectedDataRow["DesignationID"].ToString() != "")
                    {
                        
                       

                        this.Emp_Desg_lookUpEdit1.EditValue = this.SelectedRow.SelectedDataRow["DesignationID"];
                    }
                    else
                        this.Emp_Desg_lookUpEdit1.EditValue = null;

                    if (this.SelectedRow.SelectedDataRow["SubDepartmentID"].ToString() != "")
                        this.Emp_Dept_lookUpEdit1.EditValue =this.SelectedRow.SelectedDataRow["SubDepartmentID"];
                    else
                        this.Emp_Dept_lookUpEdit1.EditValue = null;


                    uiMode = UserInputMode.View;
                    this.btn_Edit.Enabled = true;
                    this.btn_Del.Enabled = true;
                    this.btn_Add.Enabled = true;
                    this.btn_Cancel.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_Save.Enabled = false;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

            set_ButtonStates(UserInputMode.View);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

       

        private void BrowsePicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|BMP Files (*.bmp)|*.bmp|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            DialogResult dg = openFileDialog1.ShowDialog();
            if(dg!=DialogResult.OK)return;
            try
            {
                string strFn = this.openFileDialog1.FileName;
                this.pictureEdit1.Image  = Image.FromFile(strFn);
                FileInfo fiImage = new FileInfo(strFn);
                FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
                image=new byte[Convert.ToInt32(fiImage.Length)];
                int iBytesRead = fs.Read(image, 0, Convert.ToInt32(fiImage.Length));
                fs.Close();
              
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

 
   

        
    }
}