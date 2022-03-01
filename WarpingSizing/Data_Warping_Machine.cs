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
    public partial class Data_Warping_Machine : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        public Data_Warping_Machine()
        {
            InitializeComponent();
        }
        DataSet ds;
        DataTable dt_Dept = new DataTable();
        public DataSet GetWarpMachine_Data()
        {
            ds = WS.svc.Get_DataSet("select WarpMachineNumber,CreelCapacity,Make,CountRange,MaxRPM,WarpMachineDesc from SW_WarpingMachines");
            DataTable dt = ds.Tables[0];
            this.dxlstv_WarpingMachine.DataSource = dt;
            return ds;
        }
        private void dxWarping_Machine_Load(object sender, EventArgs e)
        {
            GetWarpMachine_Data();
            btn_Save.Enabled = false;
            btn_Cancel.Enabled = false;

        }
        private string CheckValidation_Add()
        {
            if (dxWarpMachine_Number_textEdit1.Text == "")
            {
                return "Machine Number field is mendatory must enter..";
            }
            else
            {
                return "**SUCCESS##";
            }

        }
        private string CheckValidation_Edit()
        {
            if (dxWarpMachine_Number_textEdit1.Text == "")

                return "Machine Number  field is mendatory must enter..";

            return "**SUCCESS##";



        }
        private string CheckValidation_Delete()
        {

            return "**SUCCESS##";
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            DataSet ds_WarpNum = WS.svc.Get_DataSet("select Max (WarpMachineNumber)+1 from SW_WarpingMachines ");
            dt = ds_WarpNum.Tables[0];
            try
            {

                int MaxID = Convert.ToInt32(ds_WarpNum.Tables[0].Rows[0]["Column1"].ToString());
                this.dxWarpMachine_Number_textEdit1.Text = MaxID.ToString();
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            uiMode = UserInputMode.Add;
            this.btn_Add.Enabled = false;
            this.btn_Cancel.Enabled = true;
            this.btn_Save.Enabled = true;
            this.btn_Edit.Enabled = false;
            this.btn_Close.Enabled = true;
            this.btn_View.Enabled = false;
            this.btn_Del.Enabled = false;
            this.dxWarpingMachine_groupControl1.Enabled = true;
            this.dxlstv_WarpingMachine.Enabled = false;
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
                if (XtraMessageBox.Show("Do you sure want to Edit this Record?", "Confirm Service", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string retval = WS.svc.Execute_Query("Update SW_WarpingMachines set WarpMachineNumber='" + dxWarpMachine_Number_textEdit1.Text + "',CreelCapacity='" + dxWarpMachine_CreelCapacity_textEdit1.Text + "',Make='" + dxWarpMachine_Make_textEdit1.Text + "',CountRange='" + dxWarpMachine_CountRange_textEdit1.Text + "',MaxRPM='" + dxWarpMachine_MaxRPM_textEdit1.Text + "',WarpMachineDesc='" + dxWarpMachine_Desc_textEdit1.Text + "' where WarpMachineNumber='" + this.dxWarpMachine_Number_textEdit1.Tag.ToString() + "'");
                    if (retval == "0")
                    {
                        return;

                    }
                    else
                    {
                        XtraMessageBox.Show("Record updated Sucesssfuuly");

                    }

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
                else
                {
                    //execute save query (save records into database)
                    string retval = WS.svc.Execute_Query("insert into SW_WarpingMachines(WarpMachineNumber,CreelCapacity,Make,CountRange,MaxRPM,WarpMachineDesc)VALUES (" + dxWarpMachine_Number_textEdit1.Text + ", " + dxWarpMachine_CreelCapacity_textEdit1.Text  + ", '" +  dxWarpMachine_Make_textEdit1.Text  + "', " + dxWarpMachine_CountRange_textEdit1.Text  + ", " + dxWarpMachine_MaxRPM_textEdit1.Text  + ", '" + dxWarpMachine_Desc_textEdit1.Text  + "')");
                    if (retval == "0")
                    {
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Data Inserted Sucessfully");
                    }

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

                if (XtraMessageBox.Show("Do you sure want to Delete this Record?", "Confirm Service", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string retval = WS.svc.Execute_Query("delete from SW_WarpingMachines where WarpMachineNumber='" + dxWarpMachine_Number_textEdit1.Text + "'");
                    if (retval == "0")
                    {
                        return;

                    }
                    else
                    {
                        XtraMessageBox.Show(" Record Deleted Successfully ! ");
                    }

                }


            }

            GetWarpMachine_Data();
            Refresh_data();
            this.dxlstv_WarpingMachine .Enabled = true;
            this.btn_Save.Enabled = false;
            this.btn_Cancel.Enabled = false;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = true;
            this.btn_Del.Enabled = true;
            this.btn_Refresh.Enabled = true;
            this.btn_View.Enabled = true;
            this.btn_Close.Enabled = true;
            this.dxWarpingMachine_groupControl1 .Enabled = true;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (dxWarpMachine_Number_textEdit1.Text  == "")
            {
                XtraMessageBox.Show("You must select record from grid..");
            }
            else
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
                this.dxlstv_WarpingMachine .Enabled = true;
                this.dxWarpingMachine_groupControl1 .Enabled = true;
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (dxWarpMachine_Number_textEdit1.Text  == "")
            {
                XtraMessageBox.Show("You must select record from grid..");
            }
            else
            {

                uiMode = UserInputMode.Delete;
                this.btn_Add.Enabled = false;
                this.btn_Cancel.Enabled = true;
                this.btn_Save.Enabled = true;
                this.btn_Edit.Enabled = false;
                this.btn_Close.Enabled = true;
                this.btn_Del.Enabled = false;
                this.btn_View.Enabled = false;
                this.dxlstv_WarpingMachine .Enabled = false;
                this.dxWarpingMachine_groupControl1 .Enabled = false;

            }
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
            this.dxlstv_WarpingMachine .Enabled = true;
            this.dxWarpingMachine_groupControl1.Enabled = true;
            this.dxWarpMachine_CountRange_textEdit1.Text  = "";
            this.dxWarpMachine_CreelCapacity_textEdit1.Text = "";
            this.dxWarpMachine_Desc_textEdit1.Text = "";
            this.dxWarpMachine_Make_textEdit1.Text = "";
            this.dxWarpMachine_MaxRPM_textEdit1.Text = "";
            this.dxWarpMachine_Number_textEdit1.Text = "";
            this.dxWarpingMachine_groupControl1 .Text = "";

            XtraMessageBox.Show("Refreshed...");
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            uiMode = UserInputMode.View;
            this.btn_Edit.Enabled = true;
            this.btn_Del.Enabled = true;
            this.btn_Add.Enabled = true;
            this.btn_Cancel.Enabled = false;
            this.btn_Close.Enabled = true;
            this.btn_Save.Enabled = false;
            this.btn_Refresh.Enabled = true;

            GetWarpMachine_Data();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            uiMode = UserInputMode.View;
            this.btn_Save.Enabled = false;
            this.btn_Cancel.Enabled = false;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = true;
            this.btn_Del.Enabled = true;
            this.btn_Refresh.Enabled = true;
            this.btn_View.Enabled = true;
            this.btn_Close.Enabled = true;
            this.dxlstv_WarpingMachine.Enabled = true;
            this.dxWarpingMachine_groupControl1.Enabled = true;
            Refresh_data();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Refresh_data()
        {
            //Grid Row focused after Execute query
            int i = gridView_WarpingMachine.LocateByDisplayText(0, gridView_WarpingMachine.Columns[1], dxWarpMachine_CreelCapacity_textEdit1.Text);
            //XtraMessageBox.Show(gridView_weave.Columns[1]+" "+ dxData_ArticleWeavedesc_textEdit1.Text +" "+i.ToString());
            gridView_WarpingMachine.FocusedRowHandle = i;
            gridView_WarpingMachine.FocusedColumn = gridView_WarpingMachine.VisibleColumns[0];
            gridView_WarpingMachine.ShowEditor();
            this.dxWarpMachine_CountRange_textEdit1.Text = "";
            this.dxWarpMachine_CreelCapacity_textEdit1.Text = "";
            this.dxWarpMachine_Desc_textEdit1.Text = "";
            this.dxWarpMachine_Make_textEdit1.Text = "";
            this.dxWarpMachine_MaxRPM_textEdit1.Text = "";
            this.dxWarpMachine_Number_textEdit1.Text = "";

        }

        private void dxlstv_WarpingMachine_Click(object sender, EventArgs e)
        {
            DataRow[] dr = new DataRow[gridView_WarpingMachine.SelectedRowsCount];
            for (int i = 0; i < gridView_WarpingMachine.SelectedRowsCount; i++)
            {
                dr[i] = gridView_WarpingMachine.GetDataRow(gridView_WarpingMachine.GetSelectedRows()[i]);
                dxWarpMachine_Number_textEdit1.Text = dr[i].ItemArray[0].ToString();
                dxWarpMachine_Number_textEdit1.Tag = dr[i].ItemArray[0].ToString();
                dxWarpMachine_CreelCapacity_textEdit1.Text = dr[i].ItemArray[1].ToString();
                dxWarpMachine_Make_textEdit1.Text = dr[i].ItemArray[2].ToString();
                dxWarpMachine_CountRange_textEdit1.Text = dr[i].ItemArray[3].ToString();
                dxWarpMachine_MaxRPM_textEdit1.Text = dr[i].ItemArray[4].ToString();
                dxWarpMachine_Desc_textEdit1.Text = dr[i].ItemArray[5].ToString();

            }

        }

       
    }
}