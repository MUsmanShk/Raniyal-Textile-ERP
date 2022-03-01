namespace MachineEyes.UserControls
{
    partial class dxSizingChemicalConsumption
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.ChemicalID = new DevExpress.XtraEditors.TextEdit();
            this.Quantity = new DevExpress.XtraEditors.TextEdit();
            this.cUnit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.Remarks = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Batches = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ChemicalID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Remarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Batches.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.LineVisible = true;
            this.labelControl6.Location = new System.Drawing.Point(0, 3);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(77, 17);
            this.labelControl6.TabIndex = 168;
            this.labelControl6.Text = "Chemical";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl18.Appearance.Options.UseFont = true;
            this.labelControl18.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl18.LineVisible = true;
            this.labelControl18.Location = new System.Drawing.Point(450, 3);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(69, 17);
            this.labelControl18.TabIndex = 167;
            this.labelControl18.Text = "Quantity";
            // 
            // ChemicalID
            // 
            this.ChemicalID.EnterMoveNextControl = true;
            this.ChemicalID.Location = new System.Drawing.Point(83, 2);
            this.ChemicalID.Name = "ChemicalID";
            this.ChemicalID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChemicalID.Properties.Appearance.Options.UseFont = true;
            this.ChemicalID.Properties.NullValuePrompt = "Beam #";
            this.ChemicalID.Properties.NullValuePromptShowForEmptyValue = true;
            this.ChemicalID.Properties.ReadOnly = true;
            this.ChemicalID.Size = new System.Drawing.Size(361, 18);
            this.ChemicalID.TabIndex = 0;
            this.ChemicalID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChemicalID_KeyDown);
            // 
            // Quantity
            // 
            this.Quantity.EnterMoveNextControl = true;
            this.Quantity.Location = new System.Drawing.Point(525, 2);
            this.Quantity.Name = "Quantity";
            this.Quantity.Properties.Appearance.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.Properties.Appearance.Options.UseFont = true;
            this.Quantity.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Quantity.Properties.Mask.EditMask = "n2";
            this.Quantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Quantity.Properties.NullValuePrompt = "Quanity";
            this.Quantity.Properties.NullValuePromptShowForEmptyValue = true;
            this.Quantity.Size = new System.Drawing.Size(59, 18);
            this.Quantity.TabIndex = 1;
            this.Quantity.EditValueChanged += new System.EventHandler(this.Quantity_EditValueChanged);
            this.Quantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Quantity_KeyDown);
            // 
            // cUnit
            // 
            this.cUnit.EnterMoveNextControl = true;
            this.cUnit.Location = new System.Drawing.Point(586, 2);
            this.cUnit.Name = "cUnit";
            this.cUnit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUnit.Properties.Appearance.Options.UseFont = true;
            this.cUnit.Properties.NullValuePrompt = "Beam #";
            this.cUnit.Properties.NullValuePromptShowForEmptyValue = true;
            this.cUnit.Properties.ReadOnly = true;
            this.cUnit.Size = new System.Drawing.Size(45, 18);
            this.cUnit.TabIndex = 3;
            this.cUnit.TabStop = false;
            this.cUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cUnit_KeyDown);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.LineVisible = true;
            this.labelControl7.Location = new System.Drawing.Point(742, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(65, 17);
            this.labelControl7.TabIndex = 172;
            this.labelControl7.Text = "Remarks";
            // 
            // Remarks
            // 
            this.Remarks.EnterMoveNextControl = true;
            this.Remarks.Location = new System.Drawing.Point(813, 2);
            this.Remarks.Name = "Remarks";
            this.Remarks.Properties.Appearance.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remarks.Properties.Appearance.Options.UseFont = true;
            this.Remarks.Properties.MaxLength = 50;
            this.Remarks.Properties.NullValuePrompt = "Remarks (if any)";
            this.Remarks.Properties.NullValuePromptShowForEmptyValue = true;
            this.Remarks.Size = new System.Drawing.Size(184, 18);
            this.Remarks.TabIndex = 3;
            this.Remarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Remarks_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(635, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 17);
            this.labelControl1.TabIndex = 174;
            this.labelControl1.Text = "Batches";
            // 
            // Batches
            // 
            this.Batches.EnterMoveNextControl = true;
            this.Batches.Location = new System.Drawing.Point(694, 2);
            this.Batches.Name = "Batches";
            this.Batches.Properties.Appearance.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Batches.Properties.Appearance.Options.UseFont = true;
            this.Batches.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Batches.Properties.Mask.EditMask = "n2";
            this.Batches.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Batches.Properties.NullValuePrompt = "Quanity";
            this.Batches.Properties.NullValuePromptShowForEmptyValue = true;
            this.Batches.Size = new System.Drawing.Size(44, 18);
            this.Batches.TabIndex = 2;
            // 
            // dxSizingChemicalConsumption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Batches);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.Remarks);
            this.Controls.Add(this.cUnit);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.ChemicalID);
            this.Controls.Add(this.Quantity);
            this.Name = "dxSizingChemicalConsumption";
            this.Size = new System.Drawing.Size(1000, 22);
            this.Load += new System.EventHandler(this.dxSizingChemicalConsumption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChemicalID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Remarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Batches.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        public DevExpress.XtraEditors.TextEdit ChemicalID;
        public DevExpress.XtraEditors.TextEdit Quantity;
        public DevExpress.XtraEditors.TextEdit cUnit;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit Remarks;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit Batches;
    }
}
