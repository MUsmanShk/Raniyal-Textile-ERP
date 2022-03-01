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
    public partial class Authenticity : DevExpress.XtraEditors.XtraForm
    {
        public Authenticity()
        {
            InitializeComponent();
            this.ALU.Text = WS.svc.Get_ALU();
            this.GPU.Text = WS.svc.Get_GPU();
        }

        private void AdminPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                if (AdminPassword.Text == ALU.Text + GPU.Text + "interxprimex*")
                {

                  //string Encalu=  MachineEyes.Classes.Security.EncryptData("786", this.ALU.Text);
                  //string Encgpu = MachineEyes.Classes.Security.EncryptData("786", this.GPU.Text);
                    string res = WS.svc.Set_ALUGPU(this.ALU.Text, this.GPU.Text, ALU.Text + GPU.Text + "interxprimex*");
                    if (res == "**SUCCESS##")
                        this.Close();

                }
            }
        }
    }
}