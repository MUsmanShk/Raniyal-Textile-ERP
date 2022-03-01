using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;

namespace MachineEyes
{
    public class FillCombos
    {

        public void ArticleInsertionTypes(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select InsertionType from PP_ArticleInsertionTypes order by Insertiontype");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InsertionType"));
            p_LookUp.Properties.DisplayMember = "InsertionType";
            p_LookUp.Properties.ValueMember = "InsertionType";
        }
        public void ArticleFabricNames(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select FabricName from PP_ArticleFabricNames order by FabricName");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FabricName"));
            p_LookUp.Properties.DisplayMember = "FabricName";
            p_LookUp.Properties.ValueMember = "FabricName";
        }
        public void StoreItemLocations(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select ItemLocation from ST_Locations_Item order by ItemLocation");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemLocation"));
            p_LookUp.Properties.DisplayMember = "ItemLocation";
            p_LookUp.Properties.ValueMember = "ItemLocation";
        }
        public void Vehicles_Makes(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select Make from TK_VehicleMakes order by Make");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Make"));
            p_LookUp.Properties.DisplayMember = "Make";
            p_LookUp.Properties.ValueMember = "Make";
        }
        public void Vehicles_Models(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select Model from TK_VehicleModels order by Model");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Model"));
            p_LookUp.Properties.DisplayMember = "Model";
            p_LookUp.Properties.ValueMember = "Model";
        }
        public void Vehicles_Types(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select Type from TK_VehicleTypes order by Type");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Type"));
            p_LookUp.Properties.DisplayMember = "Type";
            p_LookUp.Properties.ValueMember = "Type";
        }
        public void ItemConditions(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select ConditionID,ConditionName from ST_ItemConditions Order by ConditionName");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ConditionName"));
            p_LookUp.Properties.DisplayMember = "ConditionName";
            p_LookUp.Properties.ValueMember = "ConditionID";
        }
        public void RequisitionPriorityLevels(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select RequisitionPriorityLevelID,RequisitionPriorityLevelName from ST_RequisitionPriorityLevels Order by RequisitionPriorityLevelName");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RequisitionPriorityLevelName"));
            p_LookUp.Properties.DisplayMember = "RequisitionPriorityLevelName";
            p_LookUp.Properties.ValueMember = "RequisitionPriorityLevelID";
        }
        public void RequisitionStatus(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select RequisitionStatusID,RequisitionStatusName from ST_RequisitionStatus Order by RequisitionStatusName");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RequisitionStatusName"));
            p_LookUp.Properties.DisplayMember = "RequisitionStatusName";
            p_LookUp.Properties.ValueMember = "RequisitionStatusID";
        }
        public void POSTATUS(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select Convert(varchar(13),POstatusID) as StatusID,POStatusName from FC_PO_Status Order by POStatusName");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("POStatusName"));
            p_LookUp.Properties.DisplayMember = "POStatusName";
            p_LookUp.Properties.ValueMember = "StatusID";
        }
        public void POTypes(ref DevExpress.XtraEditors.LookUpEdit p_LookUp,string POMainTypeID)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select POTypeID,POType from FC_PO_Types where POMainTypeID="+POMainTypeID+" Order by POType");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("POType"));
            p_LookUp.Properties.DisplayMember = "POType";
            p_LookUp.Properties.ValueMember = "POTypeID";
        }
        public void Email_AlertTypes(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select * FROM Email_AlertTypes");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AlertTypeName"));
            p_LookUp.Properties.DisplayMember = "AlertTypeName";
            p_LookUp.Properties.ValueMember = "AlertTypeID";
        }
        public void ItemMC(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select MC,MCName from ST_ItemsMC Order by MC");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MCName"));
            p_LookUp.Properties.DisplayMember = "MCName";
            p_LookUp.Properties.ValueMember = "MC";
        }
        public void MeasurementUnits(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select Unit from PP_Units order by Unit");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Unit"));
            p_LookUp.Properties.DisplayMember = "Unit";
            p_LookUp.Properties.ValueMember = "Unit";
        }
        public void Email_EncryptedConnections(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select * from Email_EncryptedConnections");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EncryptedConnection"));
            p_LookUp.Properties.DisplayMember = "EncryptedConnection";
            p_LookUp.Properties.ValueMember = "EncryptedConnection";
        }
        public void Currencies(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select Currency from PP_Currencies");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Currency"));
            p_LookUp.Properties.DisplayMember = "Currency";
            p_LookUp.Properties.ValueMember = "Currency";
        }
        public void Shifts(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select ShiftName from PP_Shift order by ShiftName");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShiftName"));
            p_LookUp.Properties.DisplayMember = "ShiftName";
            p_LookUp.Properties.ValueMember = "ShiftName";
        }
        public void ArticleSelvages(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select ArticleSelvage from PP_ArticleSelvages order by ArticleSelvage");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ArticleSelvage"));
            p_LookUp.Properties.DisplayMember = "ArticleSelvage";
            p_LookUp.Properties.ValueMember = "ArticleSelvage";
        }
        public void ArticleWeaves(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select ArticleWeave from PP_ArticleWeaves order by ArticleWeave");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ArticleWeave"));
            p_LookUp.Properties.DisplayMember = "ArticleWeave";
            p_LookUp.Properties.ValueMember = "ArticleWeave";
        }
        public void YarnSuppliers(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds_Dept;
            p_LookUp.Properties.Columns.Clear();
            ds_Dept = WS.svc.Get_DataSet("select * from QP_YarnSuppliers");
            if (ds_Dept != null) p_LookUp.Properties.DataSource = ds_Dept.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnSupplierName"));
            p_LookUp.Properties.DisplayMember = "YarnSupplierName";
            p_LookUp.Properties.ValueMember = "YarnSupplierID";
        }
        public void Clients(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select AccountID,AccountName from PP_Accounts order by AccountName ");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountName"));
            p_LookUp.Properties.DisplayMember = "AccountName";
            p_LookUp.Properties.ValueMember = "AccountID";
        }
        public void Accounts_V(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select AccountID_V,AccountName_V from AC_Level_V order by AccountName_V ");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountName_V"));
            p_LookUp.Properties.DisplayMember = "AccountName_V";
            p_LookUp.Properties.ValueMember = "AccountID_V";
        }
        public void CustomFill(ref DevExpress.XtraEditors.LookUpEdit p_LookUp,string query,string DisplayMember,string ValueMember)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet(query);
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(DisplayMember));
            p_LookUp.Properties.DisplayMember = DisplayMember;
            p_LookUp.Properties.ValueMember = ValueMember;
        }
        public void ContractStatus(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select ContractStatusID,ContractStatus from PP_ContractStatus order by ContractStatusID ");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ContractStatus"));
            p_LookUp.Properties.DisplayMember = "ContractStatus";
            p_LookUp.Properties.ValueMember = "ContractStatusID";
        }
        public void Agents(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select * from QP_Agents");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AgentName"));
            p_LookUp.Properties.DisplayMember = "AgentName";
            p_LookUp.Properties.ValueMember = "AgentID";
        }
        public void ItemTypes(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select * from ST_ItemTypes");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemTypeName"));
            p_LookUp.Properties.DisplayMember = "ItemTypeName";
            p_LookUp.Properties.ValueMember = "ItemTypeID";
        }

        public void InOutDepartments(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select InoutDeptTypesID,InoutDeptTypesName from YN_InOutDeptTypes");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InoutDeptTypesName"));
            p_LookUp.Properties.DisplayMember = "InoutDeptTypesName";
            p_LookUp.Properties.ValueMember = "InoutDeptTypesID";
        }
        public void InOutTypes(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select InoutTypesID,InoutTypesName from YN_InOutTypes");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InoutTypesName"));
            p_LookUp.Properties.DisplayMember = "InoutTypesName";
            p_LookUp.Properties.ValueMember = "InoutTypesID";
        }
        public void YarnCounts(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnCount from PP_YarnCounts order by YarnCount");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnCount"));
            p_LookUp.Properties.DisplayMember = "YarnCount";
            p_LookUp.Properties.ValueMember = "YarnCount";
        }
        public void YarnPly(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnPly from PP_YarnPly");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnPly"));
            p_LookUp.Properties.DisplayMember = "YarnPly";
            p_LookUp.Properties.ValueMember = "YarnPly";
        }
        public void YarnBrands(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnBrand from PP_YarnBrands order by YarnBrand");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnBrand"));
            p_LookUp.Properties.DisplayMember = "YarnBrand";
            p_LookUp.Properties.ValueMember = "YarnBrand";
        }
        public void YarnBlends(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnBlend from PP_YarnBlend order by YarnBlend");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnBlend"));
            p_LookUp.Properties.DisplayMember = "YarnBlend";
            p_LookUp.Properties.ValueMember = "YarnBlend";
        }
        public void YarnDesc(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnDesc from PP_YarnDesc order by YarnDesc");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnDesc"));
            p_LookUp.Properties.DisplayMember = "YarnDesc";
            p_LookUp.Properties.ValueMember = "YarnDesc";
        }
        public void YarnColors(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnColor from PP_YarnColor order by YarnColor");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnColor"));
            p_LookUp.Properties.DisplayMember = "YarnColor";
            p_LookUp.Properties.ValueMember = "YarnColor";
        }
        public void YarnInputs(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnInput from PP_YarnInput order by YarnInput");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnInput"));
            p_LookUp.Properties.DisplayMember = "YarnInput";
            p_LookUp.Properties.ValueMember = "YarnInput";
        }


        public void YarnCottonOrigins(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnCottonOrigin from PP_YarnCottonOrigins order by YarnCottonOrigin");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnCottonOrigin"));
            p_LookUp.Properties.DisplayMember = "YarnCottonOrigin";
            p_LookUp.Properties.ValueMember = "YarnCottonOrigin";
        }
        public void YarnBagsType(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnBagsType from PP_YarnBagsTypes ");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnBagsType"));
            p_LookUp.Properties.DisplayMember = "YarnBagsType";
            p_LookUp.Properties.ValueMember = "YarnBagsType";
        }
        public void YarnConesPerBag(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnConesPerBag from PP_YarnConesPerBag order by YarnConesPerBag");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnConesPerBag"));
            p_LookUp.Properties.DisplayMember = "YarnConesPerBag";
            p_LookUp.Properties.ValueMember = "YarnConesPerBag";
        }
        public void YarnLbsPerBag(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnLbsPerBag from PP_YarnLbsPerBag order by YarnLbsPerBag");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnLbsPerBag"));
            p_LookUp.Properties.DisplayMember = "YarnLbsPerBag";
            p_LookUp.Properties.ValueMember = "YarnLbsPerBag";
        }
        public void YarnConeWeight(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnConeWeight from PP_YarnConeWeight");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnConeWeight"));
            p_LookUp.Properties.DisplayMember = "YarnConeWeight";
            p_LookUp.Properties.ValueMember = "YarnConeWeight";
        }
        public void EmptyYarnConeWeight(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select EmptyYarnConeWeight from PP_EmptyYarnConeWeight");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmptyYarnConeWeight"));
            p_LookUp.Properties.DisplayMember = "EmptyYarnConeWeight";
            p_LookUp.Properties.ValueMember = "EmptyYarnConeWeight";
        }
        public void EmptyYarnBagWeight(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select EmptyYarnBagWeight from PP_EmptyYarnBagWeight");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmptyYarnBagWeight"));
            p_LookUp.Properties.DisplayMember = "EmptyYarnBagWeight";
            p_LookUp.Properties.ValueMember = "EmptyYarnBagWeight";
        }
        public void YarnBagWeight(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnBagWeight from PP_YarnBagWeight");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnBagWeight"));
            p_LookUp.Properties.DisplayMember = "YarnBagWeight";
            p_LookUp.Properties.ValueMember = "YarnBagWeight";
        }
        public void PaymentTerms(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select PaymentTerms from PP_PaymentTerms order by PaymentTerms");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PaymentTerms"));
            p_LookUp.Properties.DisplayMember = "PaymentTerms";
            p_LookUp.Properties.ValueMember = "PaymentTerms";
        }
        public void DeliveryTerms(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select DeliveryTerms from PP_DeliveryTerms order by DeliveryTerms");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DeliveryTerms"));
            p_LookUp.Properties.DisplayMember = "DeliveryTerms";
            p_LookUp.Properties.ValueMember = "DeliveryTerms";
        }
        public void WHT(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select wht from PP_WHT order by WHT");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WHT"));
            p_LookUp.Properties.DisplayMember = "WHT";
            p_LookUp.Properties.ValueMember = "WHT";
        }
        public void YarnContracts(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            //ds = WS.svc.Get_DataSet("SELECT '0' AS YarnContractNumber, 'Select No.' AS ContractDate " +
            //    "UNION ALL " +
            //    "SELECT YarnContractNumber, CONVERT(varchar(20), ContractDate) AS ContractDate " +
            //    "FROM MT_YarnContracts ORDER BY YarnContractNumber");
            ds = WS.svc.Get_DataSet("SELECT YarnContractNumber, case YarnContractNumber when 0 then 'Without Contract' else CONVERT(varchar(20), ContractDate) end AS ContractDate FROM MT_YarnContracts ORDER BY YarnContractNumber");

            p_LookUp.Properties.Columns.Add(new LookUpColumnInfo("YarnContractNumber", "Contract", 95));
            p_LookUp.Properties.Columns.Add(new LookUpColumnInfo("ContractDate", "Date", 250));
            p_LookUp.Properties.ShowHeader = true;
            p_LookUp.Properties.DisplayMember = "YarnContractNumber";
            p_LookUp.Properties.ValueMember = "YarnContractNumber";
            p_LookUp.Properties.DataSource = ds.Tables[0];
        }
        public void PaperConeColors(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select PaperConeColor from PP_YarnPaperConeColors order by PaperConeColor");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PaperConeColor"));
            p_LookUp.Properties.DisplayMember = "PaperConeColor";
            p_LookUp.Properties.ValueMember = "PaperConeColor";
        }
        public void Departments(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select DepartmentID, DepartmentName from PP_Departments order by DepartmentName");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Departmentname"));
            p_LookUp.Properties.DisplayMember = "Departmentname";
            p_LookUp.Properties.ValueMember = "DepartmentID";
        }
        public void Departments_Sub(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select SubDepartmentID, SubDepartment from PP_DepartmentsSub order by SubDepartment");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubDepartment"));
            p_LookUp.Properties.DisplayMember = "SubDepartment";
            p_LookUp.Properties.ValueMember = "SubDepartmentID";
        }
        public void Loom_Name(ref DevExpress.XtraEditors.LookUpEdit p_LookUp, string ArticleName)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select L.LoomId,L.LoomName from [dbo].[MT_Looms] L inner join [dbo].[PP_Article] A ON L.ArticleNumber = A.ArticleNumber ");
            //where A.ArticleName = '"+ArticleName+"'");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoomName"));
            p_LookUp.Properties.DisplayMember = "LoomName";
            p_LookUp.Properties.ValueMember = "LoomId";
        }
        public void Departments_Sub(ref DevExpress.XtraEditors.LookUpEdit p_LookUp,string ViewTypeID)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select SubDepartmentID, SubDepartment from PP_DepartmentsSub where ViewTypeID="+ViewTypeID+" order by SubDepartment");
            //ds = WS.svc.Get_DataSet("select SubDepartmentID, SubDepartment from PP_DepartmentsSub order by SubDepartment");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubDepartment"));
            p_LookUp.Properties.DisplayMember = "SubDepartment";
            p_LookUp.Properties.ValueMember = "SubDepartmentID";
        }
        public void YarnGodowns(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select GodownID, GodownName from YN_YarnGodowns order by GodownID");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GodownName"));
            p_LookUp.Properties.DisplayMember = "GodownName";
            p_LookUp.Properties.ValueMember = "GodownID";
        }
        public void StoreRequestStatus(ref DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit p_LookUp,string RequestFillID)
        {
            DataSet ds;
            p_LookUp.Columns.Clear();
            
            ds = WS.svc.Get_DataSet("select RequisitionStatusID, RequisitionStatusName from ST_RequisitionStatus where RequestFillID in("+RequestFillID+")");
            if (ds != null) p_LookUp.DataSource = ds.Tables[0];
            p_LookUp.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RequisitionStatusName"));
            p_LookUp.DisplayMember = "RequisitionStatusName";
            p_LookUp.ValueMember = "RequisitionStatusID";
        }
        public void SizedBy(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select AccountID, AccountName from PP_Accounts where accountid in(select sizingcompanyid from PP_SizingCompanies) order by AccountName");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountName"));
            p_LookUp.Properties.DisplayMember = "AccountName";
            p_LookUp.Properties.ValueMember = "AccountID";
        }
        public void SizingMachines(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select SizingMachineID,SizingMachineName from SW_SizingMachines order by SizingMachineID");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SizingMachineName"));
 
            p_LookUp.Properties.DisplayMember = "SizingMachineName";
            p_LookUp.Properties.ValueMember = "SizingMachineID";
        }
        public void LoomTypes(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select TypeID, TypeName from MT_Types order by TypeName");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName"));
            p_LookUp.Properties.DisplayMember = "TypeName";
            p_LookUp.Properties.ValueMember = "TypeID";
        }
        public void ArticleQuantity(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select ArticleNumber, ArticleShortName from PP_Article");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ArticleShortName"));
            p_LookUp.Properties.DisplayMember = "ArticleShortName";
            p_LookUp.Properties.ValueMember = "ArticleNumber";
        }

        public void Sheds(ref DevExpress.XtraEditors.LookUpEdit p_LookUp)
        {
            DataSet ds;
            p_LookUp.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select ShedID, ShedName from MT_Sheds order by ShedName");
            if (ds != null) p_LookUp.Properties.DataSource = ds.Tables[0];
            p_LookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShedName"));
            p_LookUp.Properties.DisplayMember = "ShedName";
            p_LookUp.Properties.ValueMember = "ShedID";
        }
    }
}
