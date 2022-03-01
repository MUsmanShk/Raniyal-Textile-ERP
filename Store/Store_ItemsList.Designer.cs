namespace MachineEyes.Store
{
    partial class Store_ItemsList
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
            this.panelControl_ItemsList = new DevExpress.XtraEditors.PanelControl();
            this.panelControl_List = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_Item = new DevExpress.XtraGrid.GridControl();
            this.gridView_Item = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl_Filter = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_ItemsList)).BeginInit();
            this.panelControl_ItemsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_List)).BeginInit();
            this.panelControl_List.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Filter)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl_ItemsList
            // 
            this.panelControl_ItemsList.Controls.Add(this.panelControl_List);
            this.panelControl_ItemsList.Controls.Add(this.panelControl_Filter);
            this.panelControl_ItemsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl_ItemsList.Location = new System.Drawing.Point(0, 0);
            this.panelControl_ItemsList.Name = "panelControl_ItemsList";
            this.panelControl_ItemsList.Size = new System.Drawing.Size(1008, 730);
            this.panelControl_ItemsList.TabIndex = 0;
            // 
            // panelControl_List
            // 
            this.panelControl_List.Controls.Add(this.gridControl_Item);
            this.panelControl_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl_List.Location = new System.Drawing.Point(2, 102);
            this.panelControl_List.Name = "panelControl_List";
            this.panelControl_List.Size = new System.Drawing.Size(1004, 626);
            this.panelControl_List.TabIndex = 3;
            // 
            // gridControl_Item
            // 
            this.gridControl_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Item.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl_Item.Location = new System.Drawing.Point(2, 2);
            this.gridControl_Item.MainView = this.gridView_Item;
            this.gridControl_Item.Name = "gridControl_Item";
            this.gridControl_Item.Size = new System.Drawing.Size(1000, 622);
            this.gridControl_Item.TabIndex = 1;
            this.gridControl_Item.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Item});
            // 
            // gridView_Item
            // 
            this.gridView_Item.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Item.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView_Item.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Item.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView_Item.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Item.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Item.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Item.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView_Item.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Item.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_Item.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Item.Appearance.Row.Options.UseFont = true;
            this.gridView_Item.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Item.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView_Item.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gridView_Item.GridControl = this.gridControl_Item;
            this.gridView_Item.Name = "gridView_Item";
            this.gridView_Item.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Item.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Item.OptionsBehavior.Editable = false;
            this.gridView_Item.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_Item.OptionsView.ShowAutoFilterRow = true;
            this.gridView_Item.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView_Item.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_Item_FocusedRowChanged);
            this.gridView_Item.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_Item_KeyDown);
            this.gridView_Item.DoubleClick += new System.EventHandler(this.gridView_Item_DoubleClick);
            // 
            // panelControl_Filter
            // 
            this.panelControl_Filter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl_Filter.Location = new System.Drawing.Point(2, 2);
            this.panelControl_Filter.Name = "panelControl_Filter";
            this.panelControl_Filter.Size = new System.Drawing.Size(1004, 100);
            this.panelControl_Filter.TabIndex = 2;
            // 
            // Store_ItemsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl_ItemsList);
            this.Name = "Store_ItemsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Store_ItemsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_ItemsList)).EndInit();
            this.panelControl_ItemsList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_List)).EndInit();
            this.panelControl_List.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Filter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl_ItemsList;
        private DevExpress.XtraGrid.GridControl gridControl_Item;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Item;
        private DevExpress.XtraEditors.PanelControl panelControl_List;
        private DevExpress.XtraEditors.PanelControl panelControl_Filter;
    }
}