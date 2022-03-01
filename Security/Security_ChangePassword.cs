using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Security
{
    public partial class Security_ChangePassword : DevExpress.XtraEditors.XtraForm
    {
        public Security_ChangePassword()
        {
            InitializeComponent();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            if (OldPassword.Text == "")
            {
                XtraMessageBox.Show("Invalid Old / Current Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (OldPassword.Text != MachineEyes.Classes.Security.User.Password)
            {
                XtraMessageBox.Show("Invalid Old / Current Password....\n Verify that you have entered a valid password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NewPassword.Text == "" || VerifyNewPassword.Text == "")
            {
                XtraMessageBox.Show("invalid new Password...you must enter a password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NewPassword.Text != VerifyNewPassword.Text)
            {
                XtraMessageBox.Show("Password does not match with verified password...please enter again", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string encpassword=MachineEyes.Classes.Security.EncryptData(MachineEyes.Classes.Security.User.UserID,NewPassword.Text);

                string res = WS.svc.Execute_Query("Update PP_Employees set Password='" + encpassword + "' where EmployeeID='" + MachineEyes.Classes.Security.User.UserID + "'");
                if (res != "**SUCCESS##")
                {
                    XtraMessageBox.Show("An Error occured while trying to change the password...\n " + res, "Error Changing Password", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    MachineEyes.Classes.Security.User.Password = NewPassword.Text;
                    XtraMessageBox.Show("Password has been changed successfully ..please logout and re-login...", "Error", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}