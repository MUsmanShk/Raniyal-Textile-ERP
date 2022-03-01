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
    public partial class Data_Sizing_chemicals : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        public Data_Sizing_chemicals()
        {
            InitializeComponent();
            FillCombos fc = new FillCombos();
            fc.MeasurementUnits(ref this.pUnit_Lookup);
            fc.MeasurementUnits(ref this.cUnit_LookUp);
        }
       
       
      
    
      
        private void dxSizing_chemicals_Load(object sender, EventArgs e)
        {
            this.dxSizingChemical_ChemicalID_textEdit1.Text = "";
            this.dxSizingChemical_ChemicalName_textEdit1.Text = "";
            this.pUnit_Lookup.EditValue = null;
            this.pUnitRate.Text = "";
            this.cUnitRate.Text = "";
            this.cUnit_LookUp.EditValue = null;
            this.btn_Save.Enabled = false;
            this.btn_Cancel.Enabled = false;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = false;
            this.btn_Del.Enabled = false;
            this.btn_Refresh.Enabled = true;
            this.btn_View.Enabled = true;
            this.btn_Close.Enabled = true;
            uiMode = UserInputMode.View;
          
        }
        private string GetNextNumber()
        {
            string vNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),ChemicalID))+1 as MaxNumber  from SW_Sizing_Chemicals";
                    vNumber = WS.svc.Get_MaxNumber(query);
                    if (vNumber.Length > 6)
                    {
                        XtraMessageBox.Show("invalid length of Sizing Chemical id found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return "";
                    }
                    vNumber = vNumber.PadLeft(6, '0');

                    return vNumber;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            


            uiMode = UserInputMode.Add;
            this.dxSizingChemical_ChemicalID_textEdit1.Text = GetNextNumber();
            this.btn_Add.Enabled = false;
            this.btn_Cancel.Enabled = true;
            this.btn_Save.Enabled = true;
            this.btn_Edit.Enabled = false;
            this.btn_Close.Enabled = true;
            this.btn_View.Enabled = false;
            this.btn_Del.Enabled = false;
          
            
        }
        private void SaveChemical()
        {

            if (this.dxSizingChemical_ChemicalID_textEdit1.Text == "")
            {
                XtraMessageBox.Show("Chemical ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.dxSizingChemical_ChemicalName_textEdit1.Text == "")
            {
                XtraMessageBox.Show("Chemical Name is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "insert into SW_Sizing_Chemicals (ChemicalID,ChemicalName,pUnit,pUnitRate,cUnit,cUnitRate,cUnitsinpUnit)VALUES (";
                query += "'" + this.dxSizingChemical_ChemicalID_textEdit1.Text + "'";
                if (this.dxSizingChemical_ChemicalName_textEdit1.Text != "")
                    query += ",'" + this.dxSizingChemical_ChemicalName_textEdit1.Text + "'";
                else
                    query += ",null";
                if (this.pUnit_Lookup.EditValue != null)
                    query += ",'" + this.pUnit_Lookup.EditValue.ToString() + "'";
                else
                    query += ",null";
                if (this.pUnitRate.Text != "")
                {
                    double UnitRate = 0;
                    double.TryParse(this.pUnitRate.Text, out UnitRate);
                    query += "," + UnitRate.ToString() + "";
                }
                else
                    query += ",0";
                if (this.cUnit_LookUp.EditValue != null)
                    query += ",'" + this.cUnit_LookUp.EditValue.ToString() + "'";
                else
                    query += ",null";
                if (this.cUnitRate.Text != "")
                {
                    double UnitRate = 0;
                    double.TryParse(this.cUnitRate.Text, out UnitRate);
                    query += "," + UnitRate.ToString() + "";
                }
                else
                    query += ",0";
                if (this.cUnitsinpUnit.Text != "")
                {
                    double Ratio = 0;
                    double.TryParse(this.cUnitsinpUnit.Text, out Ratio);
                    query += "," + Ratio.ToString() + "";
                }
                else
                    query += ",1";
                query += ")";
                string retval = WS.svc.Execute_Query(query);
                if (retval != "**SUCCESS##")
                {
                    XtraMessageBox.Show(retval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    this.dxSizingChemical_ChemicalID_textEdit1.Text = "";
                    this.dxSizingChemical_ChemicalName_textEdit1.Text = "";
                    this.pUnit_Lookup.EditValue = null;
                    this.pUnitRate.Text = "";
                    this.cUnitRate.Text = "";
                    this.cUnitsinpUnit.Text = "1";
                    this.cUnit_LookUp.EditValue = null;
                    this.btn_Save.Enabled = false;
                    this.btn_Cancel.Enabled = false;
                    this.btn_Add.Enabled = true;
                    this.btn_Edit.Enabled = false;
                    this.btn_Del.Enabled = false;
                    this.btn_Refresh.Enabled = true;
                    this.btn_View.Enabled = true;
                    this.btn_Close.Enabled = true;
                    uiMode = UserInputMode.View;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
        }
        private void DeleteChemical()
        {
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete " + this.dxSizingChemical_ChemicalName_textEdit1.Text + "? ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
           

                string retval = WS.svc.Execute_Query("delete from SW_Sizing_Chemicals  where ChemicalID='" + this.dxSizingChemical_ChemicalID_textEdit1.Tag.ToString() + "'");
                if (retval != "**SUCCESS##")
                {

                    XtraMessageBox.Show(retval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                else
                {

                    this.dxSizingChemical_ChemicalID_textEdit1.Tag = "";
                    this.dxSizingChemical_ChemicalID_textEdit1.Text = "";
                    this.dxSizingChemical_ChemicalName_textEdit1.Text = "";
                    this.cUnitsinpUnit.Text = "1";
                    this.pUnit_Lookup.EditValue = null;
                    this.pUnitRate.Text = "";
                    this.cUnit_LookUp.EditValue = null;
                    this.cUnitRate.Text = "";
                    this.btn_Save.Enabled = false;
                    this.btn_Cancel.Enabled = false;
                    this.btn_Add.Enabled = true;
                    this.btn_Edit.Enabled = false;
                    this.btn_Del.Enabled = false;
                    this.btn_Refresh.Enabled = true;
                    this.btn_View.Enabled = true;
                    this.btn_Close.Enabled = true;
                    uiMode = UserInputMode.View;
                }

            
        }
        private void UpdateChemical()
        {
            if (this.dxSizingChemical_ChemicalID_textEdit1.Text == "")
            {
                XtraMessageBox.Show("Chemical ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.dxSizingChemical_ChemicalID_textEdit1.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Chemical ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.dxSizingChemical_ChemicalName_textEdit1.Text == "")
            {
                XtraMessageBox.Show("Chemical Name is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "update SW_Sizing_Chemicals set ";
                query += " ChemicalID='" + this.dxSizingChemical_ChemicalID_textEdit1.Text + "'";
                if (this.dxSizingChemical_ChemicalName_textEdit1.Text != "")
                    query += ",ChemicalName='" + this.dxSizingChemical_ChemicalName_textEdit1.Text + "'";
                else
                    query += ",ChemicalName=null";
                if (this.pUnit_Lookup.EditValue != null)
                    query += ",pUnit='" + this.pUnit_Lookup.EditValue.ToString() + "'";
                else
                    query += ",pUnit=null";
                if (this.pUnitRate.Text != "")
                {
                    double UnitRate = 0;
                    double.TryParse(this.pUnitRate.Text, out UnitRate);
                    query += ",pUnitRate=" + UnitRate.ToString() + "";
                }
                else
                    query += ",pUnitRate=0";
                if (this.cUnit_LookUp.EditValue != null)
                    query += ",cUnit='" + this.cUnit_LookUp.EditValue.ToString() + "'";
                else
                    query += ",cUnit=null";
                if (this.cUnitRate.Text != "")
                {
                    double UnitRate = 0;
                    double.TryParse(this.cUnitRate.Text, out UnitRate);
                    query += ",cUnitRate=" + UnitRate.ToString() + "";
                }
                else
                    query += ",cUnitRate=0";
                if (this.cUnitsinpUnit.Text != "")
                {
                    double Ratio = 0;
                    double.TryParse(this.cUnitsinpUnit.Text, out Ratio);
                    query += ",cUnitsinpUnit=" + Ratio.ToString() + "";
                }
                else
                    query += ",cUnitsinpUnit=1";
                query += " where chemicalID='" + this.dxSizingChemical_ChemicalID_textEdit1.Tag.ToString() + "'";
                string retval = WS.svc.Execute_Query(query);
                if (retval != "**SUCCESS##")
                {
                    XtraMessageBox.Show(retval, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    this.dxSizingChemical_ChemicalID_textEdit1.Text = "";
                    this.dxSizingChemical_ChemicalName_textEdit1.Text = "";
                    this.dxSizingChemical_ChemicalID_textEdit1.Tag = "";
                    this.pUnit_Lookup.EditValue = null;
                    this.pUnitRate.Text = "";
                    this.cUnitRate.Text = "";
                    this.cUnitsinpUnit.Text = "";
                    this.cUnit_LookUp.EditValue = null;
                    this.btn_Save.Enabled = false;
                    this.btn_Cancel.Enabled = false;
                    this.btn_Add.Enabled = true;
                    this.btn_Edit.Enabled = false;
                    this.btn_Del.Enabled = false;
                    this.btn_Refresh.Enabled = true;
                    this.btn_View.Enabled = true;
                    this.btn_Close.Enabled = true;
                    uiMode = UserInputMode.View;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (uiMode == UserInputMode.Edit)
            {
                UpdateChemical();
            }
            else if (uiMode == UserInputMode.Add)
            {


                SaveChemical();

            }
            else if (uiMode == UserInputMode.Delete)
            {

                DeleteChemical();

            }

           
           
            
           
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (dxSizingChemical_ChemicalID_textEdit1.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Chemical ID", "Validation", MessageBoxButtons.OK);
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
              
              
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (dxSizingChemical_ChemicalID_textEdit1.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid chemical id", "Validation", MessageBoxButtons.OK);
                return;
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
               
               
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
           
            selectedrow sr = new selectedrow();
            Data.Data_View DView = new Data.Data_View();
            DView.Load_View("Select * from SW_Sizing_Chemicals order by Convert(numeric(9),ChemicalID)", "ChemicalID", "ChemicalName");
            DView.sRow = sr;
            DView.ShowDialog();
            if (sr.Status != ParameterStatus.Selected)
                return;
            this.dxSizingChemical_ChemicalID_textEdit1.Tag = sr.PrimeryID;
            this.dxSizingChemical_ChemicalID_textEdit1.Text = sr.PrimeryID;
            this.dxSizingChemical_ChemicalName_textEdit1.Text = sr.PrimaryString;
            this.pUnit_Lookup.EditValue = sr.SelectedDataRow["pUnit"].ToString();
            this.cUnit_LookUp.EditValue = sr.SelectedDataRow["cUnit"].ToString();
            this.pUnitRate.Text = sr.SelectedDataRow["pUnitRate"].ToString();
            this.cUnitRate.Text = sr.SelectedDataRow["cUnitRate"].ToString();
            this.cUnitsinpUnit.Text = sr.SelectedDataRow["cUnitsinpUnit"].ToString();
            uiMode = UserInputMode.View;
            this.btn_Edit.Enabled = true;
            this.btn_Del.Enabled = true;
            this.btn_Add.Enabled = true;
            this.btn_Cancel.Enabled = false;
            this.btn_Close.Enabled = true;
            this.btn_Save.Enabled = false;
            this.btn_Refresh.Enabled = true;
         

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            uiMode = UserInputMode.View;
            this.btn_Save.Enabled = false;
            this.btn_Cancel.Enabled = false;
            this.btn_Add.Enabled = true;
            if (this.dxSizingChemical_ChemicalID_textEdit1.Tag.ToString() != "")
            {
                this.btn_Edit.Enabled = true;
                this.btn_Del.Enabled = true;
            }
            else
            {
                this.btn_Edit.Enabled = false;
                this.btn_Del.Enabled = false;
            }
            this.btn_Refresh.Enabled = true;
            this.btn_View.Enabled = true;
            this.btn_Close.Enabled = true;
           
           
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            Reports.Sizing_ChemicalList SizingChemicalsReport = new Reports.Sizing_ChemicalList();

          
            string balancequery = "Select * from SW_Sizing_Chemicals order by Convert(numeric(9),ChemicalID) ";
            DataSet ds = WS.svc.Get_DataSet(balancequery);
            SizingChemicalsReport.BeginInit();
           
          
           
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    SizingChemicalsReport.DataSource = ds;
                else
                    SizingChemicalsReport.DataSource = null;
            }
            else
                SizingChemicalsReport.DataSource = null;
            SizingChemicalsReport.EndInit();
            SizingChemicalsReport.ShowPreview();
        }

        private void pUnit_Lookup_EditValueChanged(object sender, EventArgs e)
        {
            if(pUnit_Lookup.EditValue!=null)
            OnePUnit.Text =" 1 " + pUnit_Lookup.EditValue.ToString() + " is equal to ";
            else
                OnePUnit.Text ="";

        }

        private void cUnit_LookUp_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if(cUnit_LookUp.EditValue!=null)
                this.OneCUnit.Text =this.cUnit_LookUp.EditValue.ToString();
            else
                this.OneCUnit.Text ="";
        }

       

     

     

     
    }
}