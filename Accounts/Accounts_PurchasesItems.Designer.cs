namespace MachineEyes.Accounts
{
    partial class Accounts_PurchasesItems
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Accounts_PurchasesItems));
            this.dxEmp_Deptdesc_textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.dxEmp_Dept_textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dxlstv_EmpDept = new DevExpress.XtraGrid.GridControl();
            this.gridView_EmpDept = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dxEmpDept_groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_View = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dxEmp_Deptdesc_textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxEmp_Dept_textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxlstv_EmpDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_EmpDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxEmpDept_groupControl1)).BeginInit();
            this.dxEmpDept_groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dxEmp_Deptdesc_textEdit1
            // 
            this.dxEmp_Deptdesc_textEdit1.Location = new System.Drawing.Point(156, 64);
            this.dxEmp_Deptdesc_textEdit1.Name = "dxEmp_Deptdesc_textEdit1";
            this.dxEmp_Deptdesc_textEdit1.Properties.MaxLength = 50;
            this.dxEmp_Deptdesc_textEdit1.Size = new System.Drawing.Size(425, 20);
            this.dxEmp_Deptdesc_textEdit1.TabIndex = 9;
            // 
            // dxEmp_Dept_textEdit1
            // 
            this.dxEmp_Dept_textEdit1.Location = new System.Drawing.Point(156, 31);
            this.dxEmp_Dept_textEdit1.Name = "dxEmp_Dept_textEdit1";
            this.dxEmp_Dept_textEdit1.Properties.MaxLength = 5;
            this.dxEmp_Dept_textEdit1.Size = new System.Drawing.Size(153, 20);
            this.dxEmp_Dept_textEdit1.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(91, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Department Name:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Deptartment ID:";
            // 
            // dxlstv_EmpDept
            // 
            this.dxlstv_EmpDept.Location = new System.Drawing.Point(12, 178);
            this.dxlstv_EmpDept.MainView = this.gridView_EmpDept;
            this.dxlstv_EmpDept.Name = "dxlstv_EmpDept";
            this.dxlstv_EmpDept.Size = new System.Drawing.Size(1004, 567);
            this.dxlstv_EmpDept.TabIndex = 73;
            this.dxlstv_EmpDept.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_EmpDept});
            // 
            // gridView_EmpDept
            // 
            this.gridView_EmpDept.GridControl = this.dxlstv_EmpDept;
            this.gridView_EmpDept.Name = "gridView_EmpDept";
            this.gridView_EmpDept.OptionsBehavior.Editable = false;
            this.gridView_EmpDept.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_EmpDept.OptionsView.ShowAutoFilterRow = true;
            // 
            // dxEmpDept_groupControl1
            // 
            this.dxEmpDept_groupControl1.Controls.Add(this.dxEmp_Deptdesc_textEdit1);
            this.dxEmpDept_groupControl1.Controls.Add(this.dxEmp_Dept_textEdit1);
            this.dxEmpDept_groupControl1.Controls.Add(this.labelControl2);
            this.dxEmpDept_groupControl1.Controls.Add(this.labelControl1);
            this.dxEmpDept_groupControl1.Enabled = false;
            this.dxEmpDept_groupControl1.Location = new System.Drawing.Point(12, 2);
            this.dxEmpDept_groupControl1.Name = "dxEmpDept_groupControl1";
            this.dxEmpDept_groupControl1.Size = new System.Drawing.Size(1004, 109);
            this.dxEmpDept_groupControl1.TabIndex = 74;
            this.dxEmpDept_groupControl1.Text = "Items Data";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.simpleButton1.Location = new System.Drawing.Point(573, 117);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(57, 55);
            this.simpleButton1.TabIndex = 75;
            this.simpleButton1.Text = "Print";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Cancel.Location = new System.Drawing.Point(515, 117);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(57, 55);
            this.btn_Cancel.TabIndex = 71;
            this.btn_Cancel.Text = "Cancel";
            // 
            // btn_View
            // 
            this.btn_View.Image = ((System.Drawing.Image)(resources.GetObject("btn_View.Image")));
            this.btn_View.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_View.Location = new System.Drawing.Point(457, 117);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(57, 55);
            this.btn_View.TabIndex = 70;
            this.btn_View.Text = "view";
            // 
            // btn_Edit
            // 
            this.btn_Edit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Edit.Image")));
            this.btn_Edit.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Edit.Location = new System.Drawing.Point(283, 117);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(57, 55);
            this.btn_Edit.TabIndex = 67;
            this.btn_Edit.Text = "Edit";
            // 
            // btn_Close
            // 
            this.btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("btn_Close.Image")));
            this.btn_Close.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Close.Location = new System.Drawing.Point(631, 117);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(57, 55);
            this.btn_Close.TabIndex = 72;
            this.btn_Close.Text = "Close";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_Refresh.Image")));
            this.btn_Refresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Refresh.Location = new System.Drawing.Point(399, 117);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(57, 55);
            this.btn_Refresh.TabIndex = 69;
            this.btn_Refresh.Text = "Refreh";
            // 
            // btn_Del
            // 
            this.btn_Del.Image = ((System.Drawing.Image)(resources.GetObject("btn_Del.Image")));
            this.btn_Del.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Del.Location = new System.Drawing.Point(341, 117);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(57, 55);
            this.btn_Del.TabIndex = 68;
            this.btn_Del.Text = "Delete";
            // 
            // btn_Save
            // 
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Save.Location = new System.Drawing.Point(225, 117);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(57, 55);
            this.btn_Save.TabIndex = 66;
            this.btn_Save.Text = "Execute";
            // 
            // btn_Add
            // 
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Add.Location = new System.Drawing.Point(167, 117);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(57, 55);
            this.btn_Add.TabIndex = 65;
            this.btn_Add.Text = "Add";
            // 
            // Accounts_PurchasesItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.dxlstv_EmpDept);
            this.Controls.Add(this.dxEmpDept_groupControl1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_View);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_Del);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Add);
            this.Name = "Accounts_PurchasesItems";
            this.Text = "Purchases Items";
            ((System.ComponentModel.ISupportInitialize)(this.dxEmp_Deptdesc_textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxEmp_Dept_textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxlstv_EmpDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_EmpDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxEmpDept_groupControl1)).EndInit();
            this.dxEmpDept_groupControl1.ResumeLayout(false);
            this.dxEmpDept_groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit dxEmp_Deptdesc_textEdit1;
        private DevExpress.XtraEditors.TextEdit dxEmp_Dept_textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl dxlstv_EmpDept;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_EmpDept;
        private DevExpress.XtraEditors.GroupControl dxEmpDept_groupControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_View;
        private DevExpress.XtraEditors.SimpleButton btn_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.SimpleButton btn_Refresh;
        private DevExpress.XtraEditors.SimpleButton btn_Del;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_Add;
    }
}