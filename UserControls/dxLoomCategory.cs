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
    public partial class dxLoomCategory : DevExpress.XtraEditors.XtraUserControl
    {
        //public int[] LoomfallsinCategory;
        public dxLoomCategory()
        {
            InitializeComponent();
            this.popupMenu1.Ribbon = Program.MainWindow.ribbonControl1;
            this.popupMenu1.AddItem(Program.MainWindow.barSubItem_Category);
          
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Efficiency_Click(object sender, EventArgs e)
        {

        }

        private void Warp_Stops_Click(object sender, EventArgs e)
        {

        }

        private void Warp_CMPX_Click(object sender, EventArgs e)
        {

        }

        private void CategoryName_Click(object sender, EventArgs e)
        {

            CurrentSelection.CategorySelected = this;
            this.popupMenu1.ShowPopup(MousePosition);
        }
        public void GetCategoryLooms()
        {

            DataSet ds = WS.svc.Get_DataSet("Select LoomID from MT_Looms where CategoryID=" + this.CategoryName.Tag.ToString() + "");
            if (ds != null)
            {
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    int LoomID = -1;
                    int.TryParse(ds.Tables[0].Rows[x]["LoomID"].ToString(), out LoomID);
                    if (LoomID != -1)
                    {
                        AddLoom(LoomID);
                    }
                }
            }
        }

        public void AddLoom(int LoomID)
        {
            dxLoom newLoom = new dxLoom();
            newLoom.LoomNumber.Tag = Program.ss.Machines.Looms[LoomID].PersonalInfo.LoomID;
            newLoom.LoomNumber.Text = Program.ss.Machines.Looms[LoomID].PersonalInfo.LoomName;
            this.tableLayoutPanel_Looms.Controls.Add(newLoom);
            Program.ss.SetMachineDisplay(ref Program.ss.Machines.Looms[LoomID], ref newLoom);
           

        }


        public void RemoveLoom(int LoomID)
        {
            for (int x = 0; x < this.tableLayoutPanel_Looms.Controls.Count; x++)
            {
                dxLoom loom = (dxLoom)this.tableLayoutPanel_Looms.Controls[x];
                if (loom.LoomNumber.Tag.ToString() == LoomID.ToString())
                {
                    this.tableLayoutPanel_Looms.Controls.RemoveAt(x);
                    return;
                }
               
            }
           


        }
        private void CategoryName_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
               
               
            }
        }
    }
}
