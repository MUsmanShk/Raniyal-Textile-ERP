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
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private enum LoadProgress : int { Trying = 0, Success = 1, Failed = 2 }
        LoadProgress loadp = LoadProgress.Trying;
        public frmLogin()
        {
            InitializeComponent();
          
            
        }

        private void simpleButton_Login_Click(object sender, EventArgs e)
        {
            if (this.comboBoxEdit_IP.EditValue == null)
            {
                XtraMessageBox.Show("Enter or Select valid ip address of service", "Service IP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.comboBoxEdit_IP.Focus();
                return;
            }
            if (this.comboBoxEdit_IP.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Enter or Select valid ip address of service", "Service IP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.comboBoxEdit_IP.Focus();
                return;
            }
            if (this.comboBoxEdit_IP.EditValue == null)
            {
                XtraMessageBox.Show("Select User Role", "Control Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string financialyear = "";
            if (finYear.EditValue == null)
            {
                financialyear = DateTime.Now.Year.ToString("0000");
            }
            else
                financialyear = finYear.EditValue.ToString();
            MachineEyes.Classes.Accounting.RegAccounts.FinancialYear = financialyear;
            Program.MainWindow.FinancialYear.Caption = "Financial Year : " + financialyear + "-" + Convert.ToString(Convert.ToInt32(financialyear) + 1);
            Program.MainWindow.FinancialYear.Tag = financialyear;
            if (this.radioButton_LAN.Checked == true)
                CurrentSelection.ConnectionMode = connectionMode.LAN;
            else if (this.radioButton_WAN.Checked == true)
                CurrentSelection.ConnectionMode = connectionMode.WAN;

            if (this.MonitoringAndERP.Checked == true)
                Program.ss.Machines.PresentationData.PresentationSettings.OnlyAccountsMode = false;
            else if (this.ERPOnly.Checked == true)
                Program.ss.Machines.PresentationData.PresentationSettings.OnlyAccountsMode = true;
            WS.svc.Timeout = 200000;
           
            WS.svc.Url = this.comboBoxEdit_IP.EditValue.ToString() + Settings.ServiceDir;
            MachineEyes.Classes.Security.User.UserID = this.textEdit_Login.Text;
            MachineEyes.Classes.Security.User.Password = textEdit_Password.Text;
            TryLoad();
        }
        private void TryLoad()
        {
            loadp = LoadProgress.Trying;
            meProgress.Status = progressStatus.INPROGRESS;
            meProgress.Progress = 0;
            backgroundWorker1.RunWorkerAsync();
            this.Hide();
        }
        private void textEdit_Password_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string Role = "1";



                bool fvalue = Program.ss.Login(MachineEyes.Classes.Security.User.UserID, MachineEyes.Classes.Security.User.Password, Role);

                if (fvalue == true)
                {
                    Program.ss.StartPing();
                    Program.ss.ConfigureLooms();

                    if (Program.ss.ConfigurationLoaded == true)
                        meProgress.Status = progressStatus.SUCCEEDED;
                    else
                    {
                        meProgress.Status = progressStatus.FAILED;
                        loadp = LoadProgress.Failed;
                    }


                }
                else
                {
                    meProgress.Status = progressStatus.FAILED;
                    loadp = LoadProgress.Failed;
                }
            }
            catch (Exception ex)
            {
                meProgress.Status = progressStatus.FAILED;
                meProgress.LastErrMsg = ex.Message;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

           if (meProgress.Status == progressStatus.SUCCEEDED && Program.ss.ConfigurationLoaded == true)
            {
                MachineEyes.Classes.Accounting.Load_FinancialYears();
                Program.MainWindow.LoadForms();

                Program.MainWindow.RefreshAccountingParams();
                MachineEyes.Classes.Security.LoadGroups();
                Settings.Load_GetSet();
                Settings.Load_StopCauses();
               MachineEyes.Classes.Security.User.LoadSystemRights();
                
                MachineEyes.Classes.Security.ImplementSecurity();
                
                Program.ss.Machines.StartSyncLooms();
                loadp = LoadProgress.Success;
                Program.MainWindow.bbiLogin.Enabled = false;
                Program.MainWindow.bbiExitMachineEyesERP.Enabled = true;
                this.Close();
            }
            else
            {
                meProgress.Status = progressStatus.FAILED;
                meProgress.LastErrMsg = "Configuration not loaded or status is invalid";
                //XtraMessageBox.Show("Error Login to Machineeyes  ..check your user name  and password validity along with connection status", "Error Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Program.ss.ReadXML_MachineEyesConfigs();
            for (int x = 0; x < Settings.ServiceIPS.Length; x++)
            {
                this.comboBoxEdit_IP.Properties.Items.Add(Settings.ServiceIPS[x]);
            }
            if(this.comboBoxEdit_IP.Properties.Items.Count>0)
            this.comboBoxEdit_IP.SelectedIndex = 0;


            for (int x = 0; x < MachineEyes.Classes.Accounting.Years.Length; x++)
            {
                this.finYear.Properties.Items.Add(MachineEyes.Classes.Accounting.Years[x]);
            }
            if (this.finYear.Properties.Items.Count > 0)
                this.finYear.SelectedIndex = 0;
            this.textEdit_Login.Text = MachineEyes.Classes.Security.User.UserID;
        }

        private void simpleButton_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loadp != LoadProgress.Success) e.Cancel = true;
            else this.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (loadp == LoadProgress.Failed)
                TryLoad();
        }

      
    }
}