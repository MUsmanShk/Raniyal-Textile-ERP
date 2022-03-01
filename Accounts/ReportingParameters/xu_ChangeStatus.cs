using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MachineEyes.Accounts.ReportingParameters
{
    public partial class xu_ChangeStatus : UserControl
    {
        public xu_ChangeStatus()
        {
            InitializeComponent();
        }

        private void Proceed_Click(object sender, EventArgs e)
        {
            
            
            try
            {



                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.ChangeState, MachineEyes.Classes.Accounting.ReturnDocState(this.CurrentStatus.Text));
                    if (canProceed == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                  
            

                DialogResult dg = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to change status of document # " + this.DocumentNumber.Text + " ? ", "Change Status", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg != DialogResult.Yes) return;
                if (this.DocumentNumber.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Can not proceed.....Invalid Document Number", "Change Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (this.NewStatus.EditValue == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Can not proceed.....Invalid Status", "Change Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (this.NewStatus.EditValue.ToString() == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Can not proceed.....Invalid Status", "Change Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                string[] queries = new string[0];
                Array.Resize(ref queries, 4);

                queries[0] = "Update AC_Voucher_Main set vStatus='" + this.NewStatus.EditValue.ToString() + "',pUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',pUserTime='" + DateTime.Now.ToString("s") + "' where Vnumber='" + this.DocumentNumber.Text + "'";
                queries[1] = "Update AC_Purchases_Main set iStatus='" + this.NewStatus.EditValue.ToString() + "'  where AttachedVoucherNumber='" + this.DocumentNumber.Text + "'";
                queries[2] = "Update AC_Sales_Main set iStatus='" + this.NewStatus.EditValue.ToString() + "'  where AttachedVoucherNumber='" + this.DocumentNumber.Text + "'";
                
                string res = WS.svc.Execute_Transaction(queries);
                if (res == "**SUCCESS##")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Status changed for  document # " + this.DocumentNumber.Text + " ? ", "Change Status Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
                    mr.Close();
                    

                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(res, "Error Posting", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error Posting", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void Closeit_Click(object sender, EventArgs e)
        {
            MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
            mr.Close();
        }
    }
}
