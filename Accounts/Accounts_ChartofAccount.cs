using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Linq;
using System.Linq.Expressions;
namespace MachineEyes.Accounts
{
    public partial class Accounts_ChartofAccount : DevExpress.XtraEditors.XtraForm
    {
        TreeListNode SelectedNode;
        public Accounts_ChartofAccount()
        {
            InitializeComponent();
            AppendNodes();
            btn_Save.Enabled = false;
            btn_Edit.Enabled = false;
            btn_Del.Enabled = false;
            btn_Save.Enabled = false;
            btn_Cancel.Enabled = false;
        }
        private void AppendNodes()
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            DataSet ds = WS.svc.Get_DataSet("select * from Accounts_ChartofAccounts");
            ds.Tables[0].TableName ="Accounts_ChartOfAccounts";
            treeList1.BeginUnboundLoad();
            TreeListNode nodeI;
            TreeListNode nodeII;
            TreeListNode nodeIII;
            TreeListNode nodeIV;
            TreeListNode nodeV;

            var I = from t in ds.Tables[0].AsEnumerable()
                             group t by new { AccountID = t["AccountID_I"], AccountName = t["AccountName_I"] }
                            into groupedTable
                            select new 
                            {
                            AccountID = groupedTable.Key.AccountID,
                            AccountName=groupedTable.Key.AccountName
                            }; 

            //var uniqueAI = (
            //    from row in ds.Tables[0].AsEnumerable()
            //    let AC_I = new object[]
            //{
            //   row.Field<string>("AccountID_I"),row.Field<string>("AccountName_I")
            //}
            
            //    select row).Distinct();

            
                 

            //var Accounts_I =

            //   (from Accounts_ChartOfAccounts in ds.Tables[0].AsEnumerable()
            //    let AC_I = new object[]
            //{
            //   Accounts_ChartOfAccounts.Field<string>("AccountName_I"),Accounts_ChartOfAccounts.Field<string>("AccountName_I")
            //}
            //.GroupBy(Accounts_ChartOfAccounts.Field<string>("AccountName_I"),Accounts_ChartOfAccounts.Field<string>("AccountName_I"))
            //    select AC_I).Distinct();
            //var nAccounts_I = Accounts_I.Distinct();
            foreach (var rowI in I)
            {
                if (rowI.AccountID.ToString() != "")
                {
                nodeI = treeList1.AppendNode(new object[] { rowI.AccountName.ToString() }, null);
                nodeI.Tag = rowI.AccountID.ToString();
               

                var II = from t in ds.Tables[0].AsEnumerable()
                         where t.Field<string>("AccountID_I") == rowI.AccountID.ToString()
                         group t by new { AccountID = t["AccountID_II"], AccountName = t["AccountName_II"] }
                             into groupedTable
                             select new
                             {
                                 AccountID = groupedTable.Key.AccountID,
                                 AccountName = groupedTable.Key.AccountName
                             };
                                      
                             foreach (var rowII in II)
                              {
                                  if (rowII.AccountID.ToString() != "")
                                  {
                                  nodeI.HasChildren = true;
                                  nodeII = treeList1.AppendNode(new object[] { rowII.AccountName.ToString() },nodeI.Id);
                                  nodeII.Tag = rowII.AccountID.ToString();
                                 
                                  var III = from t in ds.Tables[0].AsEnumerable()
                                           where t.Field<string>("AccountID_II") == rowII.AccountID.ToString()
                                           group t by new { AccountID = t["AccountID_III"], AccountName = t["AccountName_III"] }
                                               into groupedTable
                                               select new
                                               {
                                                   AccountID = groupedTable.Key.AccountID,
                                                   AccountName = groupedTable.Key.AccountName
                                               };

                                  foreach (var rowIII in III)
                                  {
                                      if (rowIII.AccountID.ToString() != "")
                                      {
                                      nodeII.HasChildren = true;
                                      nodeIII = treeList1.AppendNode(new object[] { rowIII.AccountName.ToString() }, nodeII.Id);
                                      nodeIII.Tag = rowIII.AccountID.ToString();

                                      var IV = from t in ds.Tables[0].AsEnumerable()
                                                where t.Field<string>("AccountID_III") == rowIII.AccountID.ToString()
                                                group t by new { AccountID = t["AccountID_IV"], AccountName = t["AccountName_IV"] }
                                                    into groupedTable
                                                    select new
                                                    {
                                                        AccountID = groupedTable.Key.AccountID,
                                                        AccountName = groupedTable.Key.AccountName
                                                    };
                                     
                                      foreach (var rowIV in IV)
                                      {
                                          if( rowIV.AccountID.ToString()!="")
                                          {
                                          nodeIII.HasChildren = true;
                                          nodeIV = treeList1.AppendNode(new object[] { rowIV.AccountName.ToString() }, nodeIII.Id);
                                          nodeIV.Tag = rowIV.AccountID.ToString();
                                          var V = from t in ds.Tables[0].AsEnumerable()
                                                  where t.Field<string>("AccountID_IV") == rowIV.AccountID.ToString()
                                                  group t by new { AccountID = t["AccountID_V"], AccountName = t["AccountName_V"]}
                                                      into groupedTable
                                                      select new
                                                      {
                                                          AccountID = groupedTable.Key.AccountID,
                                                          AccountName = groupedTable.Key.AccountName,
                                                      
                                                      };

                                          foreach (var rowV in V)
                                          {
                                              nodeIV.HasChildren = true;
                                              nodeV = treeList1.AppendNode(new object[] { rowV.AccountName.ToString() }, nodeIV.Id);
                                              nodeV.Tag = rowV.AccountID.ToString();
                                          }
                                      }
                                      }
                                      //nodeIII.HasChildren = true;

                                  }}
                               }}
            
                                     

            }}
           //foreach(DataRow d in Accounts_I)
           //{
              
           //     node = treeList1.AppendNode(new object[] { d["AccountName_I"] }, null);
           //     node.Tag = d["AccountID_I"];
           //     node.HasChildren = true;
                  
                
           // }
            treeList1.EndUnboundLoad();

            Cursor.Current = currentCursor;
        }
      
        private void PrintChartofAccounts()
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            Reports.Accounts_ChartOfAccountsTree ChartofAccount = new Reports.Accounts_ChartOfAccountsTree();
            ChartofAccount.BeginInit();
           
            DevExpress.XtraPrinting.PaddingInfo pi = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2);
            DataSet ds = WS.svc.Get_DataSet("select * from Accounts_ChartofAccounts");
            ds.Tables[0].TableName = "Accounts_ChartOfAccounts";
          
        

            var I = from t in ds.Tables[0].AsEnumerable()
                    group t by new { AccountID = t["AccountID_I"], AccountName = t["AccountName_I"] }
                        into groupedTable
                        select new
                        {
                            AccountID = groupedTable.Key.AccountID,
                            AccountName = groupedTable.Key.AccountName
                        };

        



         
            foreach (var rowI in I)
            {
                if (rowI.AccountID.ToString() != "")
                {
                   DevExpress.XtraReports.UI.XRTableRow AI=new DevExpress.XtraReports.UI.XRTableRow();
                   DevExpress.XtraReports.UI.XRTableCell AICI=new DevExpress.XtraReports.UI.XRTableCell();
                   
                    AICI.Text =rowI.AccountID.ToString();
                    AICI.WidthF = 5;
                    AICI.Padding = pi;
                   
                    DevExpress.XtraReports.UI.XRTableCell AIC2=new DevExpress.XtraReports.UI.XRTableCell();
                    AIC2.Text =rowI.AccountName.ToString();
                    AIC2.Padding = pi;
                    AICI.ForeColor = Color.Black;
                    AIC2.ForeColor = Color.Black;
                    AI.Cells.Add(AICI);
                    AI.Cells.Add(AIC2);
                    ChartofAccount.xrTable_ChartofAccount.Rows.Add(AI);
                   
                  


                    var II = from t in ds.Tables[0].AsEnumerable()
                             where t.Field<string>("AccountID_I") == rowI.AccountID.ToString()
                             group t by new { AccountID = t["AccountID_II"], AccountName = t["AccountName_II"] }
                                 into groupedTable
                                 select new
                                 {
                                     AccountID = groupedTable.Key.AccountID,
                                     AccountName = groupedTable.Key.AccountName
                                 };

                    foreach (var rowII in II)
                    {
                        if (rowII.AccountID.ToString() != "")
                        {
                            DevExpress.XtraReports.UI.XRTableRow AII = new DevExpress.XtraReports.UI.XRTableRow();
                            DevExpress.XtraReports.UI.XRTableCell BIICI = new DevExpress.XtraReports.UI.XRTableCell();
                            BIICI.WidthF=5;

                            DevExpress.XtraReports.UI.XRTableCell AIICI = new DevExpress.XtraReports.UI.XRTableCell();
                            AIICI.WidthF = 7;
                            AIICI.Text = rowII.AccountID.ToString();
                            DevExpress.XtraReports.UI.XRTableCell AIIC2 = new DevExpress.XtraReports.UI.XRTableCell();
                            AIIC2.Text = rowII.AccountName.ToString();
                            AIICI.Padding = pi;
                            AIIC2.Padding = pi;
                            AIICI.ForeColor = Color.DarkGreen;
                            AIIC2.ForeColor = Color.DarkGreen;
                            AII.Cells.Add(BIICI);
                            AII.Cells.Add(AIICI);
                            AII.Cells.Add(AIIC2);
                            ChartofAccount.xrTable_ChartofAccount.Rows.Add(AII);

                            var III = from t in ds.Tables[0].AsEnumerable()
                                      where t.Field<string>("AccountID_II") == rowII.AccountID.ToString()
                                      group t by new { AccountID = t["AccountID_III"], AccountName = t["AccountName_III"] }
                                          into groupedTable
                                          select new
                                          {
                                              AccountID = groupedTable.Key.AccountID,
                                              AccountName = groupedTable.Key.AccountName
                                          };

                            foreach (var rowIII in III)
                            {
                                if (rowIII.AccountID.ToString() != "")
                                {
                                    DevExpress.XtraReports.UI.XRTableRow AIII = new DevExpress.XtraReports.UI.XRTableRow();
                                    DevExpress.XtraReports.UI.XRTableCell AIIICI = new DevExpress.XtraReports.UI.XRTableCell();
                                    DevExpress.XtraReports.UI.XRTableCell BIIICI = new DevExpress.XtraReports.UI.XRTableCell();
                                    BIIICI.WidthF = 7;
                                    AIIICI.Text = rowIII.AccountID.ToString();
                                    AIIICI.WidthF = 10;
                                    DevExpress.XtraReports.UI.XRTableCell AIIIC2 = new DevExpress.XtraReports.UI.XRTableCell();
                                    AIIIC2.Text = rowIII.AccountName.ToString();
                                    AIIICI.Padding = pi;
                                    AIIIC2.Padding = pi;
                                    AIIICI.ForeColor = Color.DarkBlue;
                                    AIIIC2.ForeColor = Color.DarkBlue;
                                    AIII.Cells.Add(BIIICI);
                                    AIII.Cells.Add(AIIICI);
                                    AIII.Cells.Add(AIIIC2);
                                    ChartofAccount.xrTable_ChartofAccount.Rows.Add(AIII);

                                    var IV = from t in ds.Tables[0].AsEnumerable()
                                             where t.Field<string>("AccountID_III") == rowIII.AccountID.ToString()
                                             group t by new { AccountID = t["AccountID_IV"], AccountName = t["AccountName_IV"] }
                                                 into groupedTable
                                                 select new
                                                 {
                                                     AccountID = groupedTable.Key.AccountID,
                                                     AccountName = groupedTable.Key.AccountName
                                                 };

                                    foreach (var rowIV in IV)
                                    {
                                        if (rowIV.AccountID.ToString() != "")
                                        {
                                            DevExpress.XtraReports.UI.XRTableRow AIV = new DevExpress.XtraReports.UI.XRTableRow();
                                            DevExpress.XtraReports.UI.XRTableCell AIVCI = new DevExpress.XtraReports.UI.XRTableCell();
                                            DevExpress.XtraReports.UI.XRTableCell BIVCI = new DevExpress.XtraReports.UI.XRTableCell();
                                            BIVCI.WidthF = 15;
                                            AIVCI.Text = rowIV.AccountID.ToString();
                                            AIVCI.WidthF = 15;
                                            DevExpress.XtraReports.UI.XRTableCell AIVC2 = new DevExpress.XtraReports.UI.XRTableCell();
                                            AIVC2.Text = rowIV.AccountName.ToString();
                                            AIVCI.Padding = pi;
                                            AIVC2.Padding = pi;
                                            AIVCI.ForeColor = Color.DarkOrange;
                                            AIVC2.ForeColor = Color.DarkOrange;
                                            AIV.Cells.Add(BIVCI);
                                            AIV.Cells.Add(AIVCI);
                                            AIV.Cells.Add(AIVC2);
                                            ChartofAccount.xrTable_ChartofAccount.Rows.Add(AIV);
                                            var V = from t in ds.Tables[0].AsEnumerable()
                                                    where t.Field<string>("AccountID_IV") == rowIV.AccountID.ToString()
                                                    group t by new { AccountID = t["AccountID_V"], AccountName = t["AccountName_V"] }
                                                        into groupedTable
                                                        select new
                                                        {
                                                            AccountID = groupedTable.Key.AccountID,
                                                            AccountName = groupedTable.Key.AccountName
                                                        };

                                            foreach (var rowV in V)
                                            {
                                                DevExpress.XtraReports.UI.XRTableRow AV = new DevExpress.XtraReports.UI.XRTableRow();
                                                DevExpress.XtraReports.UI.XRTableCell BVCI = new DevExpress.XtraReports.UI.XRTableCell();
                                                BVCI.WidthF = 20;
                                                DevExpress.XtraReports.UI.XRTableCell AVCI = new DevExpress.XtraReports.UI.XRTableCell();
                                                AVCI.Text = rowV.AccountID.ToString();
                                                AVCI.WidthF = 20;
                                                DevExpress.XtraReports.UI.XRTableCell AVC2 = new DevExpress.XtraReports.UI.XRTableCell();
                                                AVC2.Text = rowV.AccountName.ToString();
                                                AVCI.Padding = pi;
                                                AVC2.Padding = pi;
                                                AVCI.ForeColor = Color.DarkGray;
                                                AVC2.ForeColor = Color.DarkGray;
                                                AV.Cells.Add(BVCI);
                                                AV.Cells.Add(AVCI);
                                                AV.Cells.Add(AVC2);
                                                ChartofAccount.xrTable_ChartofAccount.Rows.Add(AV);
                                            }
                                        }
                                    }
                                    //nodeIII.HasChildren = true;

                                }
                            }
                        }
                    }



                }
            }
            //foreach(DataRow d in Accounts_I)
            //{

            //     node = treeList1.AppendNode(new object[] { d["AccountName_I"] }, null);
            //     node.Tag = d["AccountID_I"];
            //     node.HasChildren = true;


            // }
            ChartofAccount.EndInit();
            


            Cursor.Current = currentCursor;
            ChartofAccount.ShowPreview();
        }
     
        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                SelectedNode = e.Node;
              
                if (Convert.ToString(e.Node.Tag).Length == 2)
                {
                    FillTextBoxes(1);
                }
                else if (Convert.ToString(e.Node.Tag).Length == 4)
                    FillTextBoxes(2);
                else if (Convert.ToString(e.Node.Tag).Length == 7)
                    FillTextBoxes(3);
                else if (Convert.ToString(e.Node.Tag).Length == 10)
                    FillTextBoxes(4);
                else if (Convert.ToString(e.Node.Tag).Length == 13)
                    FillTextBoxes(5);
            }
        }
        private void FillTextBoxes(int Level)
        {
            if (Level == 1)
            {
                this.Account_I.Text = SelectedNode.GetDisplayText(0);
                this.Account_I.Tag = SelectedNode.Tag;
                this.nAccountID.Tag = SelectedNode.Tag;
                this.nAccountID.Text = SelectedNode.Tag.ToString();
                this.nAccountName.Text = SelectedNode.GetDisplayText(0);
                this.Account_II.Text = "";
                this.Account_II.Tag = "";
                this.Account_III.Text = "";
                this.Account_III.Tag = "";
                this.Account_IV.Text = "";
                this.Account_IV.Tag = "";
                this.Account_V.Text = "";
                this.Account_V.Tag = "";
                
                this.nAccount.Text = "Control Account Level I";
                this.nAccount.Tag = "1";
                this.nAccountNew.Tag = "2";
                this.nAccountNew.Text = "Control Account Level II";
                btn_Save.Enabled = false;
                btn_Add.Enabled = true;
                btn_Del.Enabled = true;
                btn_Edit.Enabled = true;

            }
            else if (Level == 2)
            {
                this.Account_II.Text = SelectedNode.GetDisplayText(0);
                this.Account_II.Tag = SelectedNode.Tag;
                this.nAccountID.Tag = SelectedNode.Tag;
                this.nAccountID.Text = SelectedNode.Tag.ToString();
                this.nAccountName.Text = SelectedNode.GetDisplayText(0);
                TreeListNode pNode;
                pNode = SelectedNode.ParentNode;
                this.Account_I.Text = pNode.GetDisplayText(0);
                this.Account_I.Tag = pNode.Tag;
                this.nAccount.Text = "Control Account Level II";
                this.nAccount.Tag = "2";
                this.nAccountNew.Tag = "3";
                this.nAccountNew.Text = "Control Account Level III";
                this.Account_III.Text = "";
                this.Account_III.Tag = "";
                this.Account_IV.Text = "";
                this.Account_IV.Tag = "";
                this.Account_V.Text = "";
                this.Account_V.Tag = "";
                btn_Save.Enabled = false;
                btn_Add.Enabled = true;
                btn_Del.Enabled = true;
                btn_Edit.Enabled = true;
            }
            else if (Level == 3)
            {
                this.Account_III.Text = SelectedNode.GetDisplayText(0);
                this.Account_III.Tag = SelectedNode.Tag;
                this.nAccountID.Tag = SelectedNode.Tag;
                this.nAccountID.Text = SelectedNode.Tag.ToString();
                this.nAccountName.Text = SelectedNode.GetDisplayText(0);
                TreeListNode pNode;
                pNode = SelectedNode.ParentNode;
                this.Account_II.Text = pNode.GetDisplayText(0);
                this.Account_II.Tag = pNode.Tag;
                pNode = pNode.ParentNode;
                this.Account_I.Text = pNode.GetDisplayText(0);
                this.Account_I.Tag = pNode.Tag;
                this.nAccount.Text = "Control Account Level III";
                this.nAccount.Tag = "3";
                this.nAccountNew.Tag = "4";
                this.nAccountNew.Text = "Control Account Level IV";
                this.Account_IV.Text = "";
                this.Account_IV.Tag = "";
                this.Account_V.Text = "";
                this.Account_V.Tag = "";
                btn_Save.Enabled = false;
                btn_Add.Enabled = true;
                btn_Del.Enabled = true;
                btn_Edit.Enabled = true;
            }
            else if (Level == 4)
            {
                this.Account_IV.Text = SelectedNode.GetDisplayText(0);
                this.Account_IV.Tag = SelectedNode.Tag;
                this.nAccountID.Tag = SelectedNode.Tag;
                this.nAccountID.Text = SelectedNode.Tag.ToString();
                this.nAccountName.Text = SelectedNode.GetDisplayText(0);
                TreeListNode pNode;
                pNode = SelectedNode.ParentNode;
                this.Account_III.Text = pNode.GetDisplayText(0);
                this.Account_III.Tag = pNode.Tag;
                pNode = pNode.ParentNode;
                this.Account_II.Text = pNode.GetDisplayText(0);
                this.Account_II.Tag = pNode.Tag;
                pNode = pNode.ParentNode;
                this.Account_I.Text = pNode.GetDisplayText(0);
                this.Account_I.Tag = pNode.Tag;
                this.nAccount.Text = "Control Account Level IV";
                this.nAccount.Tag = "4";
                this.nAccountNew.Tag = "5";
                this.nAccountNew.Text = "Detailed Account Level V";
                this.Account_V.Text = "";
                this.Account_V.Tag = "";
                btn_Save.Enabled = false;
                btn_Add.Enabled = true;
                btn_Del.Enabled = true;
                btn_Edit.Enabled = true;
            }
            else if (Level == 5)
            {
                this.Account_V.Text = SelectedNode.GetDisplayText(0);
                this.Account_V.Tag = SelectedNode.Tag;
                this.nAccountID.Tag = SelectedNode.Tag;
                this.nAccountID.Text = SelectedNode.Tag.ToString();
                this.nAccountName.Text = SelectedNode.GetDisplayText(0);
                FillOpening();
                TreeListNode pNode;
                pNode = SelectedNode.ParentNode;
                this.Account_IV.Text = pNode.GetDisplayText(0);
                this.Account_IV.Tag = pNode.Tag;
                pNode = SelectedNode.ParentNode;
                this.Account_III.Text = pNode.GetDisplayText(0);
                this.Account_III.Tag = pNode.Tag;
                pNode = pNode.ParentNode;
                this.Account_II.Text = pNode.GetDisplayText(0);
                this.Account_II.Tag = pNode.Tag;
                pNode = pNode.ParentNode;
                this.Account_I.Text = pNode.GetDisplayText(0);
                this.Account_I.Tag = pNode.Tag;
                this.nAccount.Text = "Detail Account Level V";
                this.nAccount.Tag = "5";
                this.nAccountNew.Tag = "6";
                this.nAccountNew.Text = "Already at End Level Account";
                btn_Save.Enabled = false;
                btn_Add.Enabled = true;
                btn_Del.Enabled = true;
                btn_Edit.Enabled = true;
            }
        }       
        private  string ReturnMaxNumber(string Query)
        {
            try
            {
                return WS.svc.Get_MaxNumber(Query);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }     
        private void ClearAll()
        {
            this.Account_I.Text = "";
            this.Account_I.Tag = "";
            this.Account_II.Text = "";
            this.Account_II.Tag = "";
            this.Account_III.Text = "";
            this.Account_III.Tag = "";
            this.Account_IV.Text = "";
            this.Account_IV.Tag = "";
            this.Account_V.Text = "";
            this.Account_V.Tag = "";
            this.nAccountID.Tag = "";
            this.nAccountID.Text = "";
            this.nAccountName.Text = "";
            this.nAccountName.Tag = "";
            this.nAccount.Text = "";
            this.nAccount.Tag = "";
            this.MapAccountID.Text = "";
            this.MapAccountName.Text = "";

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string mAccountID="";
            btn_Save.Tag = "";
            if (nAccountNew.Tag.ToString() == "2")
            {
                mAccountID = ReturnMaxNumber("select max(Convert(numeric(9),SubString(AccountID_II,3,4)))+1 as MaxNumber  from AC_Level_II where AccountID_I='" + nAccountID.Tag.ToString() + "'");
                if (mAccountID == "") return;
                mAccountID = this.nAccountID.Tag + mAccountID.PadLeft(2, '0');

            }
            else if (nAccountNew.Tag.ToString() == "3")
            {
                mAccountID = ReturnMaxNumber("select max(Convert(numeric(9),SubString(AccountID_III,5,7)))+1 as MaxNumber  from AC_Level_III where AccountID_II='" + nAccountID.Tag.ToString() + "'");
                if (mAccountID == "") return;
                mAccountID = this.nAccountID.Tag + mAccountID.PadLeft(3, '0');
            }
            else if (nAccountNew.Tag.ToString() == "4")
            {
                mAccountID = ReturnMaxNumber("select max(Convert(numeric(9),SubString(AccountID_IV,8,10)))+1 as MaxNumber  from AC_Level_IV where AccountID_III='" + nAccountID.Tag.ToString() + "'");
                if (mAccountID == "") return;
                mAccountID = this.nAccountID.Tag + mAccountID.PadLeft(3, '0');
            }
            else if (nAccountNew.Tag.ToString() == "5")
            {
                mAccountID = ReturnMaxNumber("select max(Convert(numeric(9),SubString(AccountID_V,11,13)))+1 as MaxNumber  from AC_Level_V where AccountID_IV='" + nAccountID.Tag.ToString() + "'");
                if (mAccountID == "") return;
                mAccountID = this.nAccountID.Tag + mAccountID.PadLeft(3, '0');
            }
            else
                return;
            this.nAccountID.Text = mAccountID;
            btn_Save.Tag = "1";
            btn_Add.Enabled = false;
            btn_Cancel.Enabled = true;
            btn_Del.Enabled = false;
            btn_Edit.Enabled = false;
            btn_Save.Enabled = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (btn_Save.Tag == null)
            {
                XtraMessageBox.Show("invalid execution state", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (btn_Save.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid execution state", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (btn_Save.Tag.ToString() == "1")
            {
                SaveNewAccount();
            }
            else if (btn_Save.Tag.ToString() == "2")
                EditAccount();
            else if (btn_Save.Tag.ToString() == "3")
            {
                DeleteAccount();
            }
            
        }
        private void DeleteAccount()
        {
            if (SelectedNode == null)
            {
                XtraMessageBox.Show("invalid node selected", "error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (SelectedNode.HasChildren == true)
            {
                XtraMessageBox.Show("Can not delete Account while it has Child Accounts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (nAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid account ID", "validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (nAccountID.Text != nAccountID.Tag.ToString())
            {
                XtraMessageBox.Show("invalid account ", "validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (nAccountID.Tag.ToString() != SelectedNode.Tag.ToString())
            {
                XtraMessageBox.Show("invalid account selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string wres = "";
            try
            {
                if (nAccount.Tag.ToString() == "2")
                    wres = WS.svc.Execute_Query("delete from AC_Level_II where  AccountID_II='" + nAccountID.Tag.ToString() + "'");
                else if (nAccount.Tag.ToString() == "3")
                    wres = WS.svc.Execute_Query("delete from AC_Level_III where  AccountID_III='" + nAccountID.Tag.ToString() + "'");
                else if (nAccount.Tag.ToString() == "4")
                    wres = WS.svc.Execute_Query("delete from  AC_Level_IV where  AccountID_IV='" + nAccountID.Tag.ToString() + "'");
                else if (nAccount.Tag.ToString() == "5")
                    wres = WS.svc.Execute_Query("delete from  AC_Level_V where  AccountID_V='" + nAccountID.Tag.ToString() + "'");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (wres != "**SUCCESS##")
            {
                XtraMessageBox.Show(wres, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                treeList1.BeginUpdate();
                treeList1.DeleteNode(SelectedNode);
               
                treeList1.EndUpdate();
                btn_Save.Enabled = false;
                btn_Add.Enabled = false;
                btn_Cancel.Enabled = false;
                btn_Del.Enabled = false;
                btn_Edit.Enabled = false;

                ClearAll();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditAccount()
        {
            if (nAccountName.Text == "")
            {
                XtraMessageBox.Show("invalid account name", "validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (nAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid account ID", "validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (nAccountID.Text!=nAccountID.Tag.ToString())
            {
                XtraMessageBox.Show("invalid account ", "validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string wres = "";
            try
            {
                if (nAccount.Tag.ToString() == "2")
                    wres = WS.svc.Execute_Query("update AC_Level_II set AccountName_II='" + nAccountName.Text + "' where  AccountID_II='" + nAccountID.Tag.ToString() + "'");
                else if (nAccount.Tag.ToString() == "3")
                    wres = WS.svc.Execute_Query("update AC_Level_III set AccountName_III='" + nAccountName.Text + "' where  AccountID_III='" + nAccountID.Tag.ToString() + "'");
                else if (nAccount.Tag.ToString() == "4")
                    wres = WS.svc.Execute_Query("update AC_Level_IV set AccountName_IV='" + nAccountName.Text + "' where  AccountID_IV='" + nAccountID.Tag.ToString() + "'");
                else if (nAccount.Tag.ToString() == "5")
                {
                    if (this.MapAccountID.Text != "" && this.MapAccountName.Text != "")
                    {
                        wres = WS.svc.Execute_Query("update AC_Level_V set MappedAccountID='" + this.MapAccountID.Text + "',AccountName_V='" + nAccountName.Text + "' where  AccountID_V='" + nAccountID.Tag.ToString() + "'");
                        if (wres != "**SUCCESS##")
                        {
                            XtraMessageBox.Show(wres, "Map Account Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        wres = WS.svc.Execute_Query("update AC_Level_V set AccountName_V='" + nAccountName.Text + "' where  AccountID_V='" + nAccountID.Tag.ToString() + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (wres != "**SUCCESS##")
            {
                XtraMessageBox.Show(wres, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                treeList1.BeginUpdate();
                SelectedNode.SetValue(0, this.nAccountName.Text);
                treeList1.EndUpdate();
                btn_Save.Enabled = false;
                btn_Add.Enabled = false;
                btn_Cancel.Enabled = false;
                btn_Del.Enabled = false;
                btn_Edit.Enabled = false;

                ClearAll();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveNewAccount()
        {
            if (nAccount.Tag  == null)
            {
                XtraMessageBox.Show("invalid execution state", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (btn_Save.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid execution state", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nAccountID.Tag  == null)
            {
                XtraMessageBox.Show("invalid execution state / invalid control account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid execution state / invalid control account ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nAccountID.Text == "")
            {
                XtraMessageBox.Show("invalid execution state / invalid Account ID ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string wres = "";
            try
            {
                if(nAccountNew.Tag.ToString() =="2")
                wres = WS.svc.Execute_Query("Insert into AC_Level_II (AccountID_I,AccountID_II,AccountName_II) values('" + nAccountID.Tag.ToString() + "','" + nAccountID.Text  + "','" + this.nAccountName.Text + "')");
                else if(nAccountNew.Tag.ToString() =="3")
                    wres = WS.svc.Execute_Query("Insert into AC_Level_III (AccountID_II,AccountID_III,AccountName_III) values('" + nAccountID.Tag.ToString() + "','" +nAccountID.Text + "','" + this.nAccountName.Text + "')");
                else if (nAccountNew.Tag.ToString() == "4")
                    wres = WS.svc.Execute_Query("Insert into AC_Level_IV (AccountID_III,AccountID_IV,AccountName_IV) values('" + nAccountID.Tag.ToString() + "','" + nAccountID.Text + "','" + this.nAccountName.Text + "')");
                else if (nAccountNew.Tag.ToString() == "5")
                {
                    string query = "";
                    query = "Insert into AC_Level_V (AccountID_IV,AccountID_V,AccountName_V,MappedAccountID) values('" + nAccountID.Tag.ToString() + "','" + nAccountID.Text + "','" + this.nAccountName.Text + "'";
                    if (this.MapAccountID.Text != "" && this.MapAccountName.Text != "")
                    {
                        query += ",'" + this.MapAccountID.Text + "'";
                    }
                    else
                        query += ",null";
                    query += ")";
                    wres = WS.svc.Execute_Query(query);

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (wres != "**SUCCESS##")
            {
                XtraMessageBox.Show(wres, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                treeList1.BeginUpdate();
                SelectedNode = treeList1.AppendNode(new object[] { this.nAccountName.Text  }, SelectedNode.Id);
                SelectedNode.Tag = nAccountID.Text;
               
                treeList1.EndUpdate();
                SelectedNode = SelectedNode.ParentNode;
                btn_Save.Enabled = false;
                btn_Add.Enabled = false;
                btn_Cancel.Enabled = false;
                btn_Del.Enabled = false;
                btn_Edit.Enabled = false;
               
                ClearAll();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (btn_Save.Tag == null)
            {
                btn_Save.Enabled = false;
                btn_Del.Enabled = false;
                btn_Edit.Enabled = false;
                btn_Add.Enabled = false;
                btn_Cancel.Enabled = true;
                return;
            }
            if (btn_Save.Tag.ToString() == "1" || btn_Save.Tag.ToString() == "2" || btn_Save.Tag.ToString() == "3")
            {
                btn_Save.Enabled = false;
                btn_Del.Enabled = true;
                btn_Edit.Enabled = true;
                btn_Add.Enabled = true;
                btn_Cancel.Enabled = true;
                return;
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (SelectedNode == null)
            {
                btn_Save.Tag = "";
                return;
            }
            this.nAccountID.Text = this.nAccountID.Tag.ToString();
            this.nAccountName.Text = SelectedNode.GetDisplayText(0);
            btn_Save.Tag = "2";
            btn_Add.Enabled = false;
            btn_Cancel.Enabled = true;
            btn_Del.Enabled = false;
            btn_Edit.Enabled = false;
            btn_Save.Enabled = true;
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (SelectedNode == null)
            {
                btn_Save.Tag = "";
                return;
            }
            this.nAccountID.Text = this.nAccountID.Tag.ToString();
            this.nAccountName.Text = SelectedNode.GetDisplayText(0);
            btn_Save.Tag = "3";
            btn_Add.Enabled = false;
            btn_Cancel.Enabled = true;
            btn_Del.Enabled = false;
            btn_Edit.Enabled = false;
            btn_Save.Enabled = true;
        }

        private void Print_Click(object sender, EventArgs e)
        {
           PrintChartofAccounts();
        }

        private void ReloadMappedAccount_Click(object sender, EventArgs e)
        {
            if (this.nAccountID.Text != "")
            {
                DataSet ds = WS.svc.Get_DataSet("select * from Accounts_Level_V where AccountID_V='" + this.nAccountID.Text + "'");
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        this.MapAccountID.Text = ds.Tables[0].Rows[0]["MappedAccountID"].ToString();
                        this.MapAccountName.Text = ds.Tables[0].Rows[0]["MappedAccountName"].ToString();
                    }
                }
            }
        }

        private void Browse_BuyersAccount_Click(object sender, EventArgs e)
        {
            selectedrow sRow = new selectedrow();
            Data.Data_Accounts_View aView = new Data.Data_Accounts_View();
            aView.sRow = sRow;
            aView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {
                this.MapAccountID.Text = sRow.PrimeryID;
                this.MapAccountName.Text = sRow.PrimaryString;
            }
        }

        private void ClearMappedAccount_Click(object sender, EventArgs e)
        {
            MapAccountID.Text = "";
            MapAccountName.Text = "";
        }

        private void Opening_Debit_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void Opening_Credit_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Opening_Debit_TextChanged(object sender, EventArgs e)
        {

            if (Opening_Debit.EditValue != null)
            {
                if (Opening_Debit.EditValue.ToString() != "0")
                    Opening_Credit.EditValue = "0";
            }

        }

        private void Opening_Credit_TextChanged(object sender, EventArgs e)
        {
            if (Opening_Credit.EditValue != null)
            {
                if (Opening_Credit.EditValue.ToString() != "0")
                    Opening_Debit.EditValue = "0";
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if(e.Page==xtraTabPage_Mapped)
            
            {

                if (this.nAccountID.Text != "")
                {
                    DataSet ds = WS.svc.Get_DataSet("select * from Accounts_Level_V where AccountID_V='" + this.nAccountID.Text + "'");
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            this.MapAccountID.Text = ds.Tables[0].Rows[0]["MappedAccountID"].ToString();
                            this.MapAccountName.Text = ds.Tables[0].Rows[0]["MappedAccountName"].ToString();
                        }
                    }
                }

            }

            else if (e.Page == xtraTabPage_Opening)
            {
                FillOpening();
            }


        }
        private void FillOpening()
        {
            this.Opening_Credit.EditValue = "0";
            this.Opening_Debit.EditValue = "0";
            if (this.nAccountID.Text != "")
            {
                DataSet ds = WS.svc.Get_DataSet("select * from AC_Voucher_Sub where AccountID_V='" + this.nAccountID.Text + "' and vNumber in(select VNumber from AC_Voucher_Main where vType in('000','001') and vYear='" + this.FinancialYear.Text + "' and vCat='"+this.NG.Tag.ToString()+"')");
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        this.Opening_Credit.EditValue =  ds.Tables[0].Rows[0]["vCreditAmount"].ToString(); //Convert.ToInt32(ds.Tables[0].Rows[0]["vCreditAmount"].ToString()).ToString("#,##");
                        this.Opening_Debit.EditValue= ds.Tables[0].Rows[0]["vDebitAmount"].ToString();  //Convert.ToInt32(ds.Tables[0].Rows[0]["vDebitAmount"].ToString()).ToString("#,##");
                        if (ds.Tables[0].Rows[0]["vNumber"].ToString().Substring(0, 3) == "000")
                        {
                            NG.Tag = "G";
                            NG.Checked = false;
                            NG.Image = MachineEyes.Properties.Resources.G32;
                        }
                        else if (ds.Tables[0].Rows[0]["vNumber"].ToString().Substring(0, 3) == "001")
                        {
                            NG.Tag = "N";
                            NG.Checked = true;
                            NG.Image = MachineEyes.Properties.Resources.N32;
                        }

                        this.FinancialYear.Tag = ds.Tables[0].Rows[0]["vNumber"].ToString().Substring(3, 4);
                        this.FinancialYear.Text = ds.Tables[0].Rows[0]["vNumber"].ToString().Substring(3, 4);
                        this.VSuffix.Text = ds.Tables[0].Rows[0]["VNumber"].ToString().Substring(7, 6);
                        this.VSuffix.Tag = ds.Tables[0].Rows[0]["VNumber"].ToString().Substring(7, 6);
                        this.VPrefix.Tag = ds.Tables[0].Rows[0]["vNumber"].ToString().Substring(0, 3);
                        this.VPrefix.Text = ds.Tables[0].Rows[0]["vNumber"].ToString().Substring(0, 3);
                        this.Opening_Edit.Enabled = true;
                        this.Opening_Add.Enabled = false;
                        this.Opening_Delete.Enabled = true;
                        this.Opening_Execute.Enabled = false;
                        this.GetBalance.Enabled = false;
                    }
                    else
                    {
                        this.VSuffix.Text = "";
                        this.VSuffix.Tag = "";
                        this.VPrefix.Tag = "";
                        this.FinancialYear.Tag = "";
                        this.Opening_Edit.Enabled = false;
                        this.Opening_Add.Enabled = true;
                        this.GetBalance.Enabled = true;
                        this.Opening_Delete.Enabled = false;
                        this.Opening_Execute.Enabled = false;
                    }
                }
                else
                {

                    this.VSuffix.Text = "";
                    this.VSuffix.Tag = "";
                    this.VPrefix.Tag = "";
                    this.FinancialYear.Tag = "";
                    this.Opening_Edit.Enabled = false;
                    this.Opening_Add.Enabled = true;
                    this.Opening_Delete.Enabled = false;
                    this.Opening_Execute.Enabled = false;
                }
            }
        }
        private void NG_CheckedChanged(object sender, EventArgs e)
        {
            if (NG.Checked == true)
            {
                NG.Image = MachineEyes.Properties.Resources.N32;
                NG.Tag = "N";
                VPrefix.Text = "001";
                this.VtypeCap.Text = "[N]";
                NextVoucherOpening();
                FillOpening();
            }
            else
            {
                NG.Tag = "G";
                this.VtypeCap.Text = "";
                NG.Image = MachineEyes.Properties.Resources.G32;
                VPrefix.Text = "000";
                NextVoucherOpening();
                FillOpening();
            }
        }

        private void Accounts_ChartofAccount_Load(object sender, EventArgs e)
        {
            VPrefix.Text = "000";
            FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            FinancialYear.Tag = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
        }
        private void NextVoucherOpening()
        {
            try
            {
                try
                {
                    string vNum = WS.svc.Get_MaxNumber("select max(Convert(numeric(18),SubString(VNumber,8,6)))+1 as MaxNumber  from AC_Voucher_Main where VYear='" + this.FinancialYear.Text + "' and VType='" + this.VPrefix.Text + "' and VCat='" + this.NG.Tag + "'");
                    vNum = vNum.PadLeft(6, '0');
                    this.VSuffix.Text = vNum;


                }
                catch
                {
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.VSuffix.Text = "";
            }
        }
        private void Opening_Add_Click(object sender, EventArgs e)
        {
            if (this.nAccountID.Text == "")
            {
                XtraMessageBox.Show("Invalid Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NextVoucherOpening();
            Opening_Add.Enabled = false;
            Opening_Edit.Enabled = false;
            Opening_Delete.Enabled = false;
            Opening_Execute.Enabled = true;
        }

        private void Opening_Edit_Click(object sender, EventArgs e)
        {
            if (this.nAccountID.Text == "")
            {
                XtraMessageBox.Show("Invalid Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.VSuffix.Tag.ToString() == "")
            {

                XtraMessageBox.Show("Invalid Opening Voucher Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Opening_Add.Enabled = false;
            Opening_Edit.Enabled = false;
            Opening_Delete.Enabled = false;
            Opening_Execute.Enabled = true;
        }

        private void Opening_Delete_Click(object sender, EventArgs e)
        {
            if (this.nAccountID.Text == "")
            {
                XtraMessageBox.Show("Invalid Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.VSuffix.Tag.ToString() == "")
            {

                XtraMessageBox.Show("Invalid Opening Voucher Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string veditNum = this.VPrefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.VSuffix.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete opening voucher # " + veditNum, "Delete ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
            string[] queries = new string[0];
            Array.Resize(ref queries, 1);
            queries[0] = "delete from  AC_Voucher_Sub where  VNumber='" + veditNum + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Voucher_Main where  VNumber='" + veditNum + "'";
         
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
                   
                    this.VPrefix.Tag = "";
                    this.VSuffix.Tag = "";
                    this.VSuffix.Text = "";
                  
                    this.FinancialYear.Tag = "";
                    this.Opening_Delete.Enabled = false;
                    this.Opening_Debit.EditValue = "0";
                    this.Opening_Credit.EditValue = "0";
                    this.Opening_Add.Enabled = true;
                    this.Opening_Execute.Enabled = false;
                    this.Opening_Edit.Enabled = false;


                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Opening_Execute_Click(object sender, EventArgs e)
        {
            if (this.VSuffix.Tag.ToString() == "")
            {
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                if (this.VPrefix.Text == "")
                {
                    XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.VSuffix.Text == "")
                {
                    XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    VSuffix.Focus();
                    return;
                }
                if (this.VSuffix.Text.Length != 6)
                {
                    XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    VSuffix.Focus();
                    return;
                }
                int suffix = 0;
                if (Int32.TryParse(this.VSuffix.Text, out suffix) == false)
                {
                    XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    VSuffix.Focus();
                    return;
                }
                if (this.FinancialYear.Text == "")
                {
                    XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.FinancialYear.Text.Length != 4)
                {
                    XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (this.Opening_Credit.EditValue == null)
                {
                    XtraMessageBox.Show("Opening Credit Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (this.Opening_Debit.EditValue == null)
                {
                    XtraMessageBox.Show("Opening Debit Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                int OpeningAmount = 0;
                int Amount = 0;
                if (Int32.TryParse(this.Opening_Debit.EditValue.ToString(), out Amount) == false)
                {
                    XtraMessageBox.Show("Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 
                    return;
                }
                if (Amount > 0)
                    OpeningAmount = Amount;
                if (Int32.TryParse(this.Opening_Credit.EditValue.ToString(), out Amount) == false)
                {
                    XtraMessageBox.Show("Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                if (Amount > 0)
                    OpeningAmount = Amount;
              

                string[] queries = new string[0];
                Array.Resize(ref queries, 1);
                string vnum = this.VPrefix.Text + this.FinancialYear.Text + this.VSuffix.Text;
                char vCat = 'G';
                if (NG.Checked == true)
                    vCat = 'N';
                else
                    vCat = 'G';
                if (vnum.Length != 13)
                {
                    XtraMessageBox.Show("Voucher number is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                queries[0] = "insert into AC_Voucher_Main (VNumber,VType,VCat,VYear,VDate,VTime,VStatus,VRemarks,VAmount,vAuthorized,vClosed,CUserID,CUserTime) Values (";
                queries[0] += "'" + vnum + "','" + VPrefix.Text + "','" + vCat + "','" + FinancialYear.Text + "'";
                if (MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod != null)
                    queries[0] += ",'" + MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
                else
                    queries[0] += ",null";
                if (MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod != null)
                    queries[0] += ",'" + MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod.ToShortTimeString() + "'";
                else
                    queries[0] += ",null";

                queries[0] += ",'U'";
               
                    queries[0] += ",'Balance B/F for the financial year "+this.FinancialYear.Text +"'";
               
                if (OpeningAmount>0)
                    queries[0] += "," + OpeningAmount.ToString() + "";
                else
                    queries[0] += ",0";

                queries[0] += ",0,0";
                queries[0] += ",'" +MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
                queries[0] += ")";
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VDebitAmount,VCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (Convert.ToString(this.nAccountID.Text) != "")
                    queries[queries.Length - 1] += ",'" + this.nAccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                queries[queries.Length - 1] += ",'Balance B/F for the financial year " + this.FinancialYear.Text + "'";

                queries[queries.Length - 1] += "," + this.Opening_Debit.EditValue.ToString();
                queries[queries.Length - 1] += "," + this.Opening_Credit.EditValue.ToString();
                
                queries[queries.Length - 1] += ",1)";


             
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


                        this.Opening_Debit.EditValue = "0";
                        this.Opening_Credit.EditValue = "0";
                        this.VPrefix.Tag = this.VPrefix.Text;
                        this.VSuffix.Tag = this.VSuffix.Text;
                        this.FinancialYear.Tag = this.FinancialYear.Text;
                        VSuffix.Text = "";                   
                        this.Opening_Add.Enabled = false;
                        this.Opening_Edit.Enabled = true;
                        this.Opening_Execute.Enabled = false;
                        this.Opening_Delete.Enabled = true;
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            }
            else if (this.VSuffix.Tag.ToString() != "")
            {
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                if (this.VPrefix.Text == "")
                {
                    XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.VSuffix.Text == "")
                {
                    XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    VSuffix.Focus();
                    return;
                }
                if (this.VSuffix.Text.Length != 6)
                {
                    XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    VSuffix.Focus();
                    return;
                }

                if (this.VPrefix.Text == "")
                {
                    XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.VSuffix.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    VSuffix.Focus();
                    return;
                }
                if (this.VSuffix.Tag.ToString().Length != 6)
                {
                    XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    VSuffix.Focus();
                    return;
                }
                int suffix = 0;
                if (Int32.TryParse(this.VSuffix.Text, out suffix) == false)
                {
                    XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    VSuffix.Focus();
                    return;
                }
                if (Int32.TryParse(this.VSuffix.Tag.ToString(), out suffix) == false)
                {
                    XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    VSuffix.Focus();
                    return;
                }
                if (this.FinancialYear.Text == "")
                {
                    XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.FinancialYear.Text.Length != 4)
                {
                    XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (this.Opening_Debit.EditValue == null)
                {
                    XtraMessageBox.Show("Debit Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (this.Opening_Credit.EditValue == null)
                {
                    XtraMessageBox.Show("Credit Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                string VoucherToEdit = this.VPrefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.VSuffix.Tag.ToString();
                int OpeningAmount = 0;
                int Amount = 0;
                if (Int32.TryParse(this.Opening_Debit.EditValue.ToString(), out Amount) == false)
                {
                    XtraMessageBox.Show("Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (Amount > 0)
                    OpeningAmount = Amount;
                if (Int32.TryParse(this.Opening_Credit.EditValue.ToString(), out Amount) == false)
                {
                    XtraMessageBox.Show("Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                if (Amount > 0)
                    OpeningAmount = Amount;


                string[] queries = new string[0];
                Array.Resize(ref queries, 1);
                string vnum = this.VPrefix.Text + this.FinancialYear.Text + this.VSuffix.Text;
                char vCat = 'G';
                if (NG.Checked == true)
                    vCat = 'N';
                else
                    vCat = 'G';
                if (vnum.Length != 13)
                {
                    XtraMessageBox.Show("Voucher number is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                queries[0] = "update  AC_Voucher_Main  set ";
                queries[0] = "update AC_Voucher_Main set VNumber='" + vnum + "',VType='" + VPrefix.Text + "',VCat='" + vCat + "',VYear='" + FinancialYear.Text + "',eUserID='" +MachineEyes.Classes.Security.User.SCodes.UserID + "',eUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
                if (MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod != null)
                    queries[0] += ",vDate='" + MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
                else
                    queries[0] += ",vDate=null";
                if (MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod != null)
                    queries[0] += ",vTime='" + MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod.ToShortTimeString() + "'";
                else
                    queries[0] += ",vTime=null";

                queries[0] += ",vStatus='U'";

                queries[0] += ",VRemarks='Balance B/F for the financial year " + this.FinancialYear.Text + "'";

                if (OpeningAmount > 0)
                    queries[0] += ",vAmount=" + OpeningAmount.ToString() + "";
                else
                    queries[0] += ",vAmount=0";



                queries[0] += " where vNumber='" + VoucherToEdit + "'";
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "update AC_Voucher_Sub set ";
                queries[queries.Length - 1] += "vNumber='" + vnum + "'";
                if (Convert.ToString(this.nAccountID.Text) != "")
                    queries[queries.Length - 1] += ",AccountID_V='" + this.nAccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",AccountID_V=null";

                queries[queries.Length - 1] += ",vParticulars='Balance B/F for the financial year " + this.FinancialYear.Text + "'";

                queries[queries.Length - 1] += ",vDebitAmount=" + this.Opening_Debit.EditValue.ToString();
                queries[queries.Length - 1] += ",vCreditAmount=" + this.Opening_Credit.EditValue.ToString();

                queries[queries.Length - 1] += " where vNumber='"+vnum+"'";


               
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


                        this.Opening_Debit.EditValue = "0";
                        this.Opening_Credit.EditValue = "0";
                        this.VSuffix.Text = "";




                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            }
        }

        private void Opening_Refresh_Click(object sender, EventArgs e)
        {
            FillOpening();
        }

        private void Opening_Debit_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void Opening_Credit_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void btn_View_Click(object sender, EventArgs e)
        {

        }

        private void GetBalance_Click(object sender, EventArgs e)
        {
            try
            {
                if (nAccountID.Text == "")
                {
                    XtraMessageBox.Show("invalid Account ID", "Error", MessageBoxButtons.OK);
                    return;
                }
                int PreviousYear = Convert.ToInt16(MachineEyes.Classes.Accounting.RegAccounts.FinancialYear) - 1;
                string query = "select sum(vDebitAmount)-sum(vCreditAmount) as DebitBalance,sum(vCreditAmount)-sum(vDebitAmount) as CreditBalance from Accounts_Vouchers where VYear='" + PreviousYear.ToString() + "' and AccountID_V='" + this.nAccountID.Text + "' and vCat='"+this.NG.Tag.ToString()+"'";
                DataSet ds = WS.svc.Get_DataSet(query);

                if (ds != null)
                {

                    long Amount = 0;
                    long.TryParse(ds.Tables[0].Rows[0]["DebitBalance"].ToString(), out Amount);
                    if (Amount >= 0)
                    {
                        this.Opening_Debit.EditValue = ds.Tables[0].Rows[0]["DebitBalance"].ToString();
                        this.Opening_Credit.EditValue = "0";
                    }
                    else if (Amount < 0)
                    {
                        this.Opening_Debit.EditValue = "0";
                        this.Opening_Credit.EditValue = ds.Tables[0].Rows[0]["CreditBalance"].ToString();
                    }
                }
                else
                {
                    this.Opening_Debit.EditValue = "0";
                    this.Opening_Credit.EditValue = "0";
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

       
        
    };
}