using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.GPS
{
    public partial class TK_VehiclesManagement: DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        public TK_VehiclesManagement()
        {
            InitializeComponent();
        }
     
       
   

       
        
        private bool GetNextNumber()
        {
            string vNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(36),VDN))+1 as MaxNumber  from TK_Vehicles";
                    vNumber = WS.svc.Get_MaxNumber(query);
                    if (vNumber.Length > 9)
                    {
                        XtraMessageBox.Show("invalid length of department id found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                    vNumber = vNumber.PadLeft(9, '0');
                    this.VDN.EditValue = vNumber;
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

        private void btn_Save_Click(object sender, EventArgs e)
        {
                     
            if (uiMode == UserInputMode.Edit)
            {
                if (this.VDN.EditValue == null)
                {
                    XtraMessageBox.Show("invalid VDN selected", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               
                if (XtraMessageBox.Show("Do you sure want to Edit this Record?"
                    + this.VDN.EditValue.ToString() + "", "Confirm Service", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    string iquery = "update TK_Vehicles set ";

                    if (this.VRN.EditValue != null)
                        iquery += "VRN='" + this.VRN.EditValue.ToString() + "'";
                    else
                        iquery += "VRN=null";

                    if (this.IMEI.EditValue != null)
                        iquery += ",IMEI='" + this.IMEI.EditValue.ToString() + "'";
                    else
                        iquery += ",IMEI=null";
                    if (this.GSM.EditValue != null)
                        iquery += ",GSM='" + this.GSM.EditValue.ToString() + "'";
                    else
                        iquery += ",GSM=null";
                    if (this.DriverID.EditValue != null)
                        iquery += ",DriverID='" + this.DriverID.EditValue.ToString() + "'";
                    else
                        iquery += ",DriverID=null";
                    if (this.Make.EditValue != null)
                        iquery += ",Make='" + this.Make.EditValue.ToString() + "'";
                    else
                        iquery += ",Make=null";
                    if (this.Type.EditValue != null)
                        iquery += ",Type='" + this.Type.EditValue.ToString() + "'";
                    else
                        iquery += ",Type=null";
                    if (this.Model.EditValue != null)
                        iquery += ",Model='" + this.Model.EditValue.ToString() + "'";
                    else
                        iquery += ",Model=null";
                    if (this.EngineNo.EditValue != null)
                        iquery += ",EngineNo='" + this.EngineNo.EditValue.ToString() + "'";
                    else
                        iquery += ",EngineNo=null";
                    if (this.ChasisNo.EditValue != null)
                        iquery += ",ChasisNo='" + this.ChasisNo.EditValue.ToString() + "'";
                    else
                        iquery += ",ChasisNo=null";
                    iquery += "where VDN='"+this.VDN.EditValue.ToString()+"'";
                    string retval = WS.svc.Execute_Query(iquery);
                    if (retval != "**SUCCESS##")
                    {
                        XtraMessageBox.Show(retval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                       
                    }
                    else
                    {
                        this.VDN.EditValue = null;
                        this.VRN.EditValue = null;
                        this.IMEI.EditValue = null;
                        this.GSM.EditValue = null;
                        this.EngineNo.EditValue = null;
                        this.ChasisNo.EditValue = null;
                        this.Model.EditValue = null;
                        this.Type.EditValue = null;
                        this.Make.EditValue = null;
                        this.DriverID.EditValue = null;
                        this.DriverName.EditValue = null;
                    }
                   
                }
            }
            else if (uiMode == UserInputMode.Add)
            {
                if (this.VDN.EditValue == null)
                {
                    XtraMessageBox.Show("invalid VDN #", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.VDN.EditValue.ToString().Length !=9)
                {
                    XtraMessageBox.Show("invalid VDN #", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string iquery = "insert into TK_Vehicles (VDN,VRN,IMEI,GSM,DriverID,Make,Type,Model,EngineNo,ChasisNo) VALUES ('" + VDN.EditValue.ToString() + "'";

                if (this.VRN.EditValue != null)
                    iquery += ",'" + this.VRN.EditValue.ToString() + "'";
                else
                    iquery += ",null";

                if (this.IMEI.EditValue != null)
                    iquery += ",'" + this.IMEI.EditValue.ToString() + "'";
                else
                    iquery += ",null";
                if (this.GSM.EditValue != null)
                    iquery += ",'" + this.GSM.EditValue.ToString() + "'";
                else
                    iquery += ",null";
                if (this.DriverID.EditValue != null)
                    iquery += ",'" + this.DriverID.EditValue.ToString() + "'";
                else
                    iquery += ",null";
                if (this.Make.EditValue != null)
                    iquery += ",'" + this.Make.EditValue.ToString() + "'";
                else
                    iquery += ",null";
                if (this.Type.EditValue != null)
                    iquery += ",'" + this.Type.EditValue.ToString() + "'";
                else
                    iquery += ",null";
                if (this.Model.EditValue != null)
                    iquery += ",'" + this.Model.EditValue.ToString() + "'";
                else
                    iquery += ",null";
                if (this.EngineNo.EditValue != null)
                    iquery += ",'" + this.EngineNo.EditValue.ToString() + "'";
                else
                    iquery += ",null";
                if (this.ChasisNo.EditValue != null)
                    iquery += ",'" + this.ChasisNo.EditValue.ToString() + "'";
                else
                    iquery += ",null";
                iquery += ")";
                    string retval = WS.svc.Execute_Query(iquery);
                    if (retval != "**SUCCESS##")
                    {
                        XtraMessageBox.Show(retval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        this.VDN.EditValue = null;
                        this.VRN.EditValue = null;
                        this.IMEI.EditValue = null;
                        this.GSM.EditValue = null;
                        this.EngineNo.EditValue = null;
                        this.ChasisNo.EditValue = null;
                        this.Model.EditValue = null;
                        this.Type.EditValue = null;
                        this.Make.EditValue = null;
                        this.DriverID.EditValue = null;
                        this.DriverName.EditValue = null;
                    }
                   
                              
                //add one row to grid and add the record from textboxers to grid

               

            }
            else if (uiMode == UserInputMode.Delete)
            {
                if (this.VDN.EditValue == null)
                {
                    XtraMessageBox.Show("invalid VDN #", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               
                if (XtraMessageBox.Show("Do you sure want to Delete this Record?"
                    + this.VDN.Text + "", "Confirm Service", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string retval = WS.svc.Execute_Query("delete from TK_Vehicles where VDN='" + VDN.EditValue.ToString()  + "'");
                    if (retval != "**SUCCESS##")
                    {

                        XtraMessageBox.Show(retval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; 
                      
                    }
                    else
                    {
                        this.VDN.EditValue = null;
                        this.VRN.EditValue = null;
                        this.IMEI.EditValue = null;
                        this.GSM.EditValue = null;
                        this.EngineNo.EditValue = null;
                        this.ChasisNo.EditValue = null;
                        this.Model.EditValue = null;
                        this.Type.EditValue = null;
                        this.Make.EditValue = null;
                        this.DriverID.EditValue = null;
                        this.DriverName.EditValue = null;
                    }
                    
                }


            }


            uiMode = UserInputMode.View;
            this.btn_Save.Enabled = false;
            this.btn_Cancel.Enabled = false;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = false;
            this.btn_Del.Enabled = false;
           
            this.btn_View.Enabled = true;
            this.btn_Close.Enabled = true;
           
           
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
           
                uiMode = UserInputMode.Edit;
                this.btn_Save.Enabled = true;
                this.btn_Cancel.Enabled = true;
                this.btn_Add.Enabled = false;
                this.btn_Edit.Enabled = false;
                this.btn_Del.Enabled = false;
               
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

       

        private void btn_View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();

            strFilterQuery += "select VDN,VRN,GSM,Type,Model,Make,DriverName from TTK_Vehicles ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "VDN", "VRN");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.VDN.EditValue  = sRow.PrimeryID;
                ds = WS.svc.Get_DataSet("Select * from TTK_Vehicles where VDN='" + sRow.PrimeryID + "'");
                if (ds == null) return;

                if (ds.Tables[0].Rows.Count <= 0) return;





                if (ds.Tables[0].Rows[0]["VDN"].ToString() != "")
                {
                    this.VDN.EditValue = ds.Tables[0].Rows[0]["VDN"].ToString();

                }
                else
                {
                    this.VDN.EditValue = null;

                }

                if (ds.Tables[0].Rows[0]["VRN"].ToString() != "")
                {
                    this.VRN.EditValue = ds.Tables[0].Rows[0]["VRN"].ToString();

                }
                else
                {
                    this.VRN.EditValue = null;

                }

                if (ds.Tables[0].Rows[0]["GSM"].ToString() != "")
                {
                    this.GSM.EditValue = ds.Tables[0].Rows[0]["GSM"].ToString();

                }
                else
                {
                    this.GSM.EditValue = null;

                }

                if (ds.Tables[0].Rows[0]["IMEI"].ToString() != "")
                {
                    this.IMEI.EditValue = ds.Tables[0].Rows[0]["IMEI"].ToString();

                }
                else
                {
                    this.IMEI.EditValue = null;

                }

                if (ds.Tables[0].Rows[0]["DriverID"].ToString() != "")
                {
                    this.DriverID.EditValue = ds.Tables[0].Rows[0]["DriverID"].ToString();

                }
                else
                {
                    this.DriverID.EditValue = null;

                }

                if (ds.Tables[0].Rows[0]["Model"].ToString() != "")
                {
                    this.Model.EditValue = ds.Tables[0].Rows[0]["Model"].ToString();

                }
                else
                {
                    this.Model.EditValue = null;

                }

                if (ds.Tables[0].Rows[0]["Make"].ToString() != "")
                {
                    this.Make.EditValue = ds.Tables[0].Rows[0]["Make"].ToString();

                }
                else
                {
                    this.Make.EditValue = null;

                }

                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    this.Type.EditValue = ds.Tables[0].Rows[0]["Type"].ToString();

                }
                else
                {
                    this.Type.EditValue = null;

                }

                if (ds.Tables[0].Rows[0]["EngineNo"].ToString() != "")
                {
                    this.EngineNo.EditValue = ds.Tables[0].Rows[0]["EngineNo"].ToString();

                }
                else
                {
                    this.EngineNo.EditValue = null;

                }

                if (ds.Tables[0].Rows[0]["ChasisNo"].ToString() != "")
                {
                    this.ChasisNo.EditValue = ds.Tables[0].Rows[0]["ChasisNo"].ToString();

                }
                else
                {
                    this.ChasisNo.EditValue = null;

                }
                this.btn_Save.Enabled = false;
                this.btn_Cancel.Enabled = false;
                this.btn_Add.Enabled = true;
                this.btn_Edit.Enabled = true;
                this.btn_Del.Enabled = true;
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
            this.btn_View.Enabled = true;
            this.btn_Close.Enabled = true;
     
           
        }
       
       

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VehiclesManagement_Load(object sender, EventArgs e)
        {
            this.btn_Save.Enabled = false;
            this.btn_Cancel.Enabled = false;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = false;
            this.btn_Del.Enabled = false;

            this.btn_View.Enabled = true;
            this.btn_Close.Enabled = true;
            FillCombos fc = new FillCombos();
            fc.Vehicles_Makes(ref this.Make);
            fc.Vehicles_Models(ref this.Model);
            fc.Vehicles_Types(ref this.Type);

        }

        private void ReloadType_Click(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
           
            fc.Vehicles_Types(ref this.Type);
        }

        private void ReloadMake_Click(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
            fc.Vehicles_Makes(ref this.Make);
           
        }

        private void ReloadModel_Click(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
      
            fc.Vehicles_Models(ref this.Model);
          
        }

        private void FlashType_Click(object sender, EventArgs e)
        {
            this.Type.EditValue = null;

        }

        private void FlashMake_Click(object sender, EventArgs e)
        {
            this.Make.EditValue = null;
        }

        private void FlashModel_Click(object sender, EventArgs e)
        {
            this.Model.EditValue = null;
        }

        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl26_Click(object sender, EventArgs e)
        {

        }

        private void GetCurrentStatus_Click(object sender, EventArgs e)
        {
            if (this.VDN.EditValue == null) return;
            int index = Program.ss.ReturnVehicleIndex_ByVDN(this.VDN.EditValue.ToString());
            if (index == -1) return;
            this.Current_GPRSTime.Text = Program.ss.Machines.Vehicles[index].CGPS.timeStamp.ToString();
            this.Current_Latitude.Text = Program.ss.Machines.Vehicles[index].CGPS.Latitude.ToString();
            this.Current_Longitude.Text = Program.ss.Machines.Vehicles[index].CGPS.Longitude.ToString();
            this.Current_Speed.Text = Program.ss.Machines.Vehicles[index].CGPS.speed.ToString();
           
        }

        private void GPRS_SendSettings_Click(object sender, EventArgs e)
        {
            if (this.VDN.EditValue == null)
            {
                XtraMessageBox.Show("Invalid VDN", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            int index = Program.ss.ReturnVehicleIndex_ByVDN(this.VDN.EditValue.ToString());
            if (index == -1)
            {
                XtraMessageBox.Show("Invalid VDN or VDN Not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dg = XtraMessageBox.Show("Are you sure to send these settings to GPS device ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;

            string command = "";
            if (GPRS_CommunicationON.Checked == true)
 
                    command += "AED_GPRS1";
                else
                    command += "AED_GPRS0";
            



            if (GPRS_Time.EditValue!=null)
            {

                command = command + "CS_GSEC" + GPRS_Time.EditValue.ToString() + "CE_GSEC";
            }
            if (GPRS_APN.EditValue!=null)
            {

                command = command + "CS_GAPN" +GPRS_APN.EditValue.ToString() + "CE_GAPN";
            }
            if (GPRS_VDN.EditValue !=null)
            {
                command = command + "CS_GVDN" + GPRS_VDN.EditValue.ToString() + "CE_GVDN";
            }
            if (GPRS_IPFirst_0.EditValue != null && GPRS_IPFirst_1.EditValue != null && GPRS_IPFirst_2.EditValue != null && GPRS_IPFirst_3.EditValue != null)
            {

                command = command + "CS_GIP0" + GPRS_IPFirst_0.EditValue.ToString() + "CE_GIP0";
                command = command + "CS_GIP1" + GPRS_IPFirst_1.EditValue.ToString() + "CE_GIP1";
                command = command + "CS_GIP2" + GPRS_IPFirst_2.EditValue.ToString() + "CE_GIP2";
                command = command + "CS_GIP3" + GPRS_IPFirst_3.EditValue.ToString() + "CE_GIP3";

            }
            if (GPRS_PortFirst.EditValue!=null)
            {

                command = command + "CS_GPRT" + GPRS_PortFirst.EditValue.ToString() + "CE_GPRT";

            }
            if (GPRS_UserPassword !=null)
            {

                command = command + "CS_GPWD" +GPRS_UserPassword.EditValue.ToString() + "CE_GPWD";

            }
            if (GPRS_UserID!=null)
            {

                command = command + "CS_GUSR" + GPRS_UserID.EditValue.ToString() + "CE_GUSR";

            }

            string iquery = "update TK_Vehicles set ";

            if (this.GPRS_CommunicationON.Checked ==true )
                iquery += "GPRS_Connect=1";
            else
                iquery += "GPRS_Connect=0";

            if (GPRS_APN.EditValue!=null)
                iquery += ",GPRS_GAPN='" + GPRS_APN.EditValue.ToString() + "'";
            else
                iquery += ",GPRS_GAPN=null";
            iquery += "where VDN='" + this.VDN.EditValue.ToString() + "'";
            string retval = WS.svc.Execute_Query(iquery);
            if (retval != "**SUCCESS##")
            {
                XtraMessageBox.Show(retval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
           
        }

        


     

     

     

       
     

    

   

     

      

    

        

    }
}