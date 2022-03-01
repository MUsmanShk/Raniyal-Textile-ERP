using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Accounts_AuditTrail : DevExpress.XtraReports.UI.XtraReport
    {
        int indexno = 0;
        public Accounts_AuditTrail()
        {
            InitializeComponent();
        }

        private void xrUserID_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel l = (XRLabel)sender;
            l.Text =MachineEyes.Classes.Security.User.SCodes.UserID;
        }

        private void xrUserName_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel l = (XRLabel)sender;
            l.Text =MachineEyes.Classes.Security.User.SCodes.UserName;
        }

        private void xr_indexno_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexno++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = indexno.ToString();
        }

        private void xrPostVoucher_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (xr.Text == "U")
            {
                xr.ForeColor = Color.Black;
                xr.Text = "Unposted";
            }
            else if (xr.Text == "P")
            {
                xr.ForeColor = Color.Blue;
                xr.Text = "Posted";
               
            }
            else if (xr.Text == "A")
            {
                xr.ForeColor = Color.Red;
                xr.Text = "Audited";
               
            }

        }

        private void xrPostVoucher_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;

            string Status = e.Brick.TextValue.ToString();
           string VNumber= e.Brick.Value.ToString();
           if (Status == "U")
           {
               string[] queries = new string[0];
               Array.Resize(ref queries, 3);
               
               queries[0]="Update AC_Voucher_Main set vStatus='P',pUserID='"+MachineEyes.Classes.Security.User.SCodes.UserID+"',pUserTime='"+DateTime.Now.ToString("s")+"' where Vnumber='"+VNumber+"'";
               queries[1] = "Update AC_Purchases_Main set iStatus='P'  where AttachedVoucherNumber='" + VNumber + "'";
               queries[2] = "Update AC_Sales_Main set iStatus='P'  where AttachedVoucherNumber='" + VNumber + "'";
               string res = WS.svc.Execute_Transaction(queries);
               if (res == "**SUCCESS##")
               {
                  
                   e.Brick.TextValue = "P";
                   e.Brick.Text = "Posted Successfully";
                   e.PreviewControl.ForeColor = Color.Green;
                   e.PreviewControl.Text = "Posted Successfully";
                   
               
               }
               else
               {
                   DevExpress.XtraEditors.XtraMessageBox.Show(res, "Error Posting", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
               }
               
           }
            
        }

      

    }
}
