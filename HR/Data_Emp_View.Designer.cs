namespace MachineEyes
{
    partial class Data_Emp_View
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.Generalinfo = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Designation = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.EmployeeID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.EmployeeName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Picture = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.EmployeeNIC = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.DesignationID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Contactinfo = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.Address = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Mobile_1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Mobile_2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Mobile_3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.otherinfo = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ERFID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.SubDepartmentID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.SubDepartment = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.StatusID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.EmpStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Bookman Old Style", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1});
            this.gridControl1.Size = new System.Drawing.Size(940, 483);
            this.gridControl1.TabIndex = 17;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.Generalinfo,
            this.Contactinfo,
            this.otherinfo});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.EmployeeID,
            this.EmployeeName,
            this.ERFID,
            this.SubDepartmentID,
            this.SubDepartment,
            this.EmployeeNIC,
            this.Mobile_1,
            this.Mobile_2,
            this.Mobile_3,
            this.Address,
            this.StatusID,
            this.Picture,
            this.EmpStatus,
            this.DesignationID,
            this.Designation});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsCustomization.AllowChangeBandParent = true;
            this.bandedGridView1.OptionsCustomization.AllowChangeColumnParent = true;
            this.bandedGridView1.OptionsCustomization.AllowRowSizing = true;
            this.bandedGridView1.OptionsView.ShowAutoFilterRow = true;
            this.bandedGridView1.OptionsView.ShowViewCaption = true;
            this.bandedGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bandedGridView1_KeyDown);
            this.bandedGridView1.DoubleClick += new System.EventHandler(this.bandedGridView1_DoubleClick);
            // 
            // Generalinfo
            // 
            this.Generalinfo.Caption = "General Info";
            this.Generalinfo.Columns.Add(this.Designation);
            this.Generalinfo.Columns.Add(this.EmployeeID);
            this.Generalinfo.Columns.Add(this.EmployeeName);
            this.Generalinfo.Columns.Add(this.Picture);
            this.Generalinfo.Columns.Add(this.EmployeeNIC);
            this.Generalinfo.Columns.Add(this.DesignationID);
            this.Generalinfo.Name = "Generalinfo";
            this.Generalinfo.Width = 648;
            // 
            // Designation
            // 
            this.Designation.Caption = "Designation";
            this.Designation.FieldName = "Designation";
            this.Designation.Name = "Designation";
            this.Designation.Visible = true;
            this.Designation.Width = 84;
            // 
            // EmployeeID
            // 
            this.EmployeeID.Caption = "Employee ID";
            this.EmployeeID.FieldName = "EmployeeID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.Visible = true;
            this.EmployeeID.Width = 86;
            // 
            // EmployeeName
            // 
            this.EmployeeName.Caption = "Employee Name";
            this.EmployeeName.FieldName = "EmployeeName";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Visible = true;
            this.EmployeeName.Width = 263;
            // 
            // Picture
            // 
            this.Picture.Caption = "Employee Picture";
            this.Picture.ColumnEdit = this.repositoryItemPictureEdit1;
            this.Picture.FieldName = "Picture";
            this.Picture.Name = "Picture";
            this.Picture.Visible = true;
            this.Picture.Width = 101;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            // 
            // EmployeeNIC
            // 
            this.EmployeeNIC.Caption = "National ID";
            this.EmployeeNIC.FieldName = "EmployeeNIC";
            this.EmployeeNIC.Name = "EmployeeNIC";
            this.EmployeeNIC.Visible = true;
            this.EmployeeNIC.Width = 114;
            // 
            // DesignationID
            // 
            this.DesignationID.Caption = "Designation ID";
            this.DesignationID.FieldName = "DesignationID";
            this.DesignationID.Name = "DesignationID";
            this.DesignationID.Width = 20;
            // 
            // Contactinfo
            // 
            this.Contactinfo.Caption = "Contact info";
            this.Contactinfo.Columns.Add(this.Address);
            this.Contactinfo.Columns.Add(this.Mobile_1);
            this.Contactinfo.Columns.Add(this.Mobile_2);
            this.Contactinfo.Columns.Add(this.Mobile_3);
            this.Contactinfo.Name = "Contactinfo";
            this.Contactinfo.Width = 461;
            // 
            // Address
            // 
            this.Address.Caption = "Residential Address";
            this.Address.FieldName = "Address";
            this.Address.Name = "Address";
            this.Address.Visible = true;
            this.Address.Width = 216;
            // 
            // Mobile_1
            // 
            this.Mobile_1.Caption = "Mobile I";
            this.Mobile_1.FieldName = "Mobile_1";
            this.Mobile_1.Name = "Mobile_1";
            this.Mobile_1.Visible = true;
            this.Mobile_1.Width = 67;
            // 
            // Mobile_2
            // 
            this.Mobile_2.Caption = "Mobile II";
            this.Mobile_2.FieldName = "Mobile_2";
            this.Mobile_2.Name = "Mobile_2";
            this.Mobile_2.Visible = true;
            this.Mobile_2.Width = 87;
            // 
            // Mobile_3
            // 
            this.Mobile_3.Caption = "Mobile III";
            this.Mobile_3.FieldName = "Mobile_3";
            this.Mobile_3.Name = "Mobile_3";
            this.Mobile_3.Visible = true;
            this.Mobile_3.Width = 91;
            // 
            // otherinfo
            // 
            this.otherinfo.Caption = "Other Info";
            this.otherinfo.Columns.Add(this.ERFID);
            this.otherinfo.Columns.Add(this.SubDepartmentID);
            this.otherinfo.Columns.Add(this.SubDepartment);
            this.otherinfo.Columns.Add(this.StatusID);
            this.otherinfo.Columns.Add(this.EmpStatus);
            this.otherinfo.Name = "otherinfo";
            this.otherinfo.Width = 387;
            // 
            // ERFID
            // 
            this.ERFID.Caption = "RFID";
            this.ERFID.FieldName = "ERFID";
            this.ERFID.Name = "ERFID";
            this.ERFID.Visible = true;
            // 
            // SubDepartmentID
            // 
            this.SubDepartmentID.Caption = "Department ID";
            this.SubDepartmentID.FieldName = "SubDepartmentID";
            this.SubDepartmentID.Name = "SubDepartmentID";
            this.SubDepartmentID.Visible = true;
            this.SubDepartmentID.Width = 83;
            // 
            // SubDepartment
            // 
            this.SubDepartment.Caption = "Department";
            this.SubDepartment.FieldName = "SubDepartment";
            this.SubDepartment.Name = "SubDepartment";
            this.SubDepartment.Visible = true;
            this.SubDepartment.Width = 90;
            // 
            // StatusID
            // 
            this.StatusID.Caption = "Status ID";
            this.StatusID.FieldName = "StatusID";
            this.StatusID.Name = "StatusID";
            this.StatusID.Visible = true;
            this.StatusID.Width = 64;
            // 
            // EmpStatus
            // 
            this.EmpStatus.Caption = "Work Status";
            this.EmpStatus.FieldName = "EmpStatus";
            this.EmpStatus.Name = "EmpStatus";
            this.EmpStatus.Visible = true;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // Data_Emp_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 483);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Data_Emp_View";
            this.Text = "Employees List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Data_Emp_View_FormClosing);
            this.Load += new System.EventHandler(this.Data_Emp_View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

      
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
       
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Designation;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn EmployeeID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn EmployeeName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ERFID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn SubDepartmentID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn SubDepartment;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn EmployeeNIC;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Mobile_1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Mobile_2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Mobile_3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Address;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn StatusID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Picture;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn EmpStatus;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn DesignationID;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand Generalinfo;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand Contactinfo;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand otherinfo;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
    }
}