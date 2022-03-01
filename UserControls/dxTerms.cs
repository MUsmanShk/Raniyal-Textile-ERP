using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.UserControls
{
    public partial class dxTerms : DevExpress.XtraEditors.XtraUserControl
    {

        public TermsType typeTerms;
        public dxTerms()
        {
            InitializeComponent();
        }
        private void TakeAction(KeyEventArgs e)
        {
            if (e.Shift == true)
            {
                if (e.KeyCode == Keys.Enter)
            {
                selectedrow sRow = new selectedrow();
                Data.Data_View dView = new Data.Data_View();
                sRow = dView.sRow;
                dView.Load_View("Select * from PP_Terms where TermsType="+Convert.ToString((int)typeTerms)+" ", "Terms", "Terms");
                dView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.Terms.Text += sRow.PrimaryString;
                }
            }
            }
            if (e.Control == false) return;
            
        
            if (e.KeyCode == Keys.Delete)
            {
                if (this.Parent.Controls.Count > 1)
                    this.Parent.Controls.Remove(this);
            }
            else if (e.KeyCode == Keys.Insert)
            {
                dxTerms nTerm = new dxTerms();
                this.Parent.Controls.Add(nTerm);
                nTerm.typeTerms = this.typeTerms;
            }
            else if (e.KeyCode == Keys.I && e.Control == true)
            {
                dxTerms nTerm = new dxTerms();
                this.Parent.Controls.Add(nTerm);
                nTerm.typeTerms = this.typeTerms;
            }
            else if (e.KeyCode == Keys.S)
            {
               
                try
                {
                   string s= WS.svc.Execute_Query("insert into PP_Terms values(" + Convert.ToString((int)typeTerms) + ",'" + this.Terms.Text + "')");
                    if(s.Contains("**SUCCESS##")==true)
                    {
                        XtraMessageBox.Show("Terms parmanently saved for later use", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }else
                    {
                        XtraMessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.KeyCode == Keys.D && e.Control == true)
            {
                try
                {
                    DialogResult dg = XtraMessageBox.Show("Are you sure to delete this terms!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dg != DialogResult.Yes) return;
                    string s = WS.svc.Execute_Query("delete from PP_Terms where terms='" + this.Terms.Text + "'");
                    if (s.Contains("**SUCCESS##") == true)
                    {
                        XtraMessageBox.Show("Terms parmanently deleted from list", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        XtraMessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (this.Parent.Controls.Count > 1)
                    this.Parent.Controls.Remove(this);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                selectedrow sRow = new selectedrow();
                Data.Data_View dView = new Data.Data_View();
                dView.sRow = sRow;
                dView.Load_View("Select * from PP_Terms where TermsType=" + Convert.ToString((int)typeTerms) + " ", "Terms", "Terms");
                dView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.Terms.Text = sRow.PrimaryString;
                }
            }
            
        }

        private void Terms_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void dxTerms_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void Terms_KeyPress(object sender, KeyPressEventArgs e)
        {
            
           
        }
    }
}
