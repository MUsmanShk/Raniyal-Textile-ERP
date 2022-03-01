using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Store
{
    public partial class Store_StoreRequisitionList : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
       
       
     
        
      
        public Store_StoreRequisitionList()
        {
            InitializeComponent();
           
            
            this.FromDate.DateTime = DateTime.Now;
            this.UptoDate.DateTime = DateTime.Now;

            FillCombos fc = new FillCombos();
           
            fc.Departments_Sub(ref this.DepartmentReq);

           

            DataSet ds = WS.svc.Get_DataSet("Select SubDepartmentID,SubDepartment from QP_Employees where EmployeeID='" + MachineEyes.Classes.Security.User.UserID + "'");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    this.DepartmentReq.EditValue = ds.Tables[0].Rows[0]["SubDepartmentID"].ToString();
                }
            }
           
           
            DevExpress.XtraGrid.StyleFormatCondition cn;
            cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, this.PODGridView_Item.Columns["RequisitionStatusID"], null, "0");
            cn.Appearance.BackColor = Color.White;
            cn.Appearance.ForeColor = Color.Black;
            cn.ApplyToRow = true;
            this.PODGridView_Item.FormatConditions.Add(cn);
            cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, this.PODGridView_Item.Columns["RequisitionStatusID"], null, "1");
            cn.Appearance.BackColor = Color.Green;
            cn.Appearance.ForeColor = Color.Black;
            cn.ApplyToRow = true;
            this.PODGridView_Item.FormatConditions.Add(cn);
            cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, this.PODGridView_Item.Columns["RequisitionStatusID"], null, "2");
            cn.Appearance.BackColor = Color.Red;
            cn.Appearance.ForeColor = Color.White;
            cn.ApplyToRow = true;
            this.PODGridView_Item.FormatConditions.Add(cn);

            cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, this.PODGridView_Item.Columns["RequisitionStatusID"], null, "3");
            cn.Appearance.BackColor = Color.Blue;
            cn.Appearance.ForeColor = Color.White;
            cn.ApplyToRow = true;
            this.PODGridView_Item.FormatConditions.Add(cn);
            cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, this.PODGridView_Item.Columns["RequisitionStatusID"], null, "4");
            cn.Appearance.BackColor = Color.Black;
            cn.Appearance.ForeColor = Color.White;
            cn.ApplyToRow = true;
            this.PODGridView_Item.FormatConditions.Add(cn);

            cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, this.PODGridView_Item.Columns["RequisitionStatusID"], null, "5");
            cn.Appearance.BackColor = Color.Yellow;
            cn.Appearance.ForeColor = Color.Blue;
            cn.ApplyToRow = true;
            this.PODGridView_Item.FormatConditions.Add(cn);
            string q = "Select * from RST_DepartmentStoreRequisition  where Dated='"+ this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern)+"'  ";
           
            DataSet dsf = WS.svc.Get_DataSet(q);
            if (dsf != null)
            {
                this.PODGrid_Item.DataSource = dsf.Tables[0];
            }
            
        }
      
       
   
     
     
      
       

       
        
       

      

     

      

     
      
       

       




     
       
      

      

       

     



       

        private void GetRecords_Click(object sender, EventArgs e)
        {
            string filterquery = "Select * from RST_DepartmentStoreRequisition  where Dated>='"+this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern)+"' and Dated<='"+this.UptoDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern)+"' ";
            string addFilter = "";
            
            if (this.Filter_Department.EditValue.ToString() == "1")
            {
                if (this.DepartmentReq.EditValue != null)
                {
                    addFilter += " and DepartmentID='" + this.DepartmentReq.EditValue.ToString() + "'";
                }
            }
            if (this.Filter_Stock.EditValue != null)
            {
                if (this.Filter_Stock.EditValue.ToString() == "0")
                    addFilter += " and StockAtTime>0";
                else if (this.Filter_Stock.EditValue.ToString() == "1")
                    addFilter += " and StockAtTime=0 or StockAtTime is null";


            }
            DataSet dsf = WS.svc.Get_DataSet(filterquery + addFilter);
            if (dsf != null)
            {
                this.PODGrid_Item.DataSource = dsf.Tables[0];
            }
            
        }

       

       

       
    }
}