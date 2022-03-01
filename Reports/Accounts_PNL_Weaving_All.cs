using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
namespace MachineEyes.Reports
{
    public partial class Accounts_PNL_Weaving_All : DevExpress.XtraReports.UI.XtraReport
    {
        public Accounts_PNL_Weaving_All()
        {
            InitializeComponent();
           
            
            

        }
        public void Init_PNL()
        {
            xrTable1.Rows.Clear();
            XRTableRow row = XRTableRow.CreateRow(0, 1);
            row.Font = GetFont_MainHeader();
            row.Cells[0].Text = "Weaving Sales";
            xrTable1.Rows.Add(row);

            double gAmount = 0;
            DataSet dsg = WS.svc.Get_DataSet("Select sum(VCreditAmount)-sum(vDebitAmount) as gAmount from Accounts_Vouchers_AllLevelAccounts where AccountID_I='04'");
            if (dsg != null)
            {
                double.TryParse(dsg.Tables[0].Rows[0]["gAmount"].ToString(), out gAmount);

            }
            DataSet ds = WS.svc.Get_DataSet("select AccountID_II,AccountName_II,sum(VCreditAmount)-sum(vDebitAmount) as sAmount from Accounts_Vouchers_AllLevelAccounts where AccountID_I='04' GROUP BY AccountID_II, AccountName_II");
            for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
            {
                XRTableRow row1 = XRTableRow.CreateRow(0, 5);
                row1.Cells[0].Text = ds.Tables[0].Rows[x]["AccountName_II"].ToString();
                row1.Cells[0].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                row1.Cells[0].Font = GetFont_SubHeader();
                row1.Cells[0].Padding = new DevExpress.XtraPrinting.PaddingInfo(20, 0, 1, 1);
                row1.Cells[1].Font = GetFont_Note();
                row1.Cells[1].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                row1.Cells[1].Text = "Note: " + x.ToString();
                
                double sAmount = 0;
                try
                {
                    double.TryParse(ds.Tables[0].Rows[x]["sAmount"].ToString(), out sAmount);
                   
                }
                catch
                {
                }
                
                row1.Cells[2].Text = sAmount.ToString("#,##;(#,##)");
                row1.Cells[2].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                row1.Cells[2].Font = GetFont_SubAmount();
                              
                row1.Cells[4].Text = Convert.ToDouble(sAmount / gAmount * 100).ToString("#,##0.00") + "%";
                row1.Cells[4].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                row1.Cells[4].Font = GetFont_Note();
                xrTable1.Rows.Add(row1);
            }
            
           
        }

        public Font GetFont_MainHeader()
        {
            Font f = new Font("MS Sans Sarif", 12,FontStyle.Bold);
            return f;
        }
        public Font GetFont_MainAmount()
        {
            Font f = new Font("MS Sans Sarif", 12, FontStyle.Bold);
            return f;
        }
        public Font GetFont_SubHeader()
        {
            Font f = new Font("MS Sans Sarif", 10);
            return f;
        }
        public Font GetFont_SubAmount()
        {
            Font f = new Font("MS Sans Sarif", 10);
            return f;
        }

        public Font GetFont_Note()
        {
            Font f = new Font("Times New Roman", 6);
            return f;
        }
    }
}
