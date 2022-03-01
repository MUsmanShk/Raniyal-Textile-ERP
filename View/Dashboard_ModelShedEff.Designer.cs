namespace MachineEyes
{
    partial class Dashboard_ModelShedEff
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 50D);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard_ModelShedEff));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel_BottomThreeLooms = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel_TopThreeLooms = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel_TopThreeWeavers = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel_LongStoppedMachines = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_ShedEff = new System.Windows.Forms.TableLayoutPanel();
            this.ShedEfficiency = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel_Efficiencies = new System.Windows.Forms.TableLayoutPanel();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel_ShedEff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chart1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(433, 898);
            this.panelControl1.TabIndex = 2;
            // 
            // chart1
            // 
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX.Title = "Looms";
            chartArea2.AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.Interval = 5D;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY.MajorTickMark.Interval = 0D;
            chartArea2.AxisY.MajorTickMark.IntervalOffset = 0D;
            chartArea2.AxisY.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisY.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY.Maximum = 100D;
            chartArea2.AxisY.MaximumAutoSize = 100F;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.MinorGrid.Enabled = true;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY.MinorTickMark.Enabled = true;
            chartArea2.AxisY.Title = "Efficiency";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.IsSameFontSizeForAllAxes = true;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(2, 2);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            series2.Points.Add(dataPoint2);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(429, 894);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl2);
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Controls.Add(this.tableLayoutPanel_ShedEff);
            this.panelControl2.Controls.Add(this.tableLayoutPanel_Efficiencies);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(433, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(729, 898);
            this.panelControl2.TabIndex = 3;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.groupControl5);
            this.groupControl2.Controls.Add(this.groupControl4);
            this.groupControl2.Controls.Add(this.groupControl3);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(725, 161);
            this.groupControl2.TabIndex = 62;
            this.groupControl2.Text = "groupControl2";
            // 
            // groupControl5
            // 
            this.groupControl5.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl5.AppearanceCaption.Options.UseFont = true;
            this.groupControl5.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl5.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl5.Controls.Add(this.tableLayoutPanel_BottomThreeLooms);
            this.groupControl5.Location = new System.Drawing.Point(532, 2);
            this.groupControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(192, 151);
            this.groupControl5.TabIndex = 2;
            this.groupControl5.Text = "Bottom 3 Looms";
            // 
            // tableLayoutPanel_BottomThreeLooms
            // 
            this.tableLayoutPanel_BottomThreeLooms.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel_BottomThreeLooms.ColumnCount = 1;
            this.tableLayoutPanel_BottomThreeLooms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_BottomThreeLooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_BottomThreeLooms.Location = new System.Drawing.Point(2, 31);
            this.tableLayoutPanel_BottomThreeLooms.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_BottomThreeLooms.Name = "tableLayoutPanel_BottomThreeLooms";
            this.tableLayoutPanel_BottomThreeLooms.RowCount = 1;
            this.tableLayoutPanel_BottomThreeLooms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_BottomThreeLooms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_BottomThreeLooms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_BottomThreeLooms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_BottomThreeLooms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_BottomThreeLooms.Size = new System.Drawing.Size(188, 118);
            this.tableLayoutPanel_BottomThreeLooms.TabIndex = 53;
            // 
            // groupControl4
            // 
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl4.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl4.Controls.Add(this.tableLayoutPanel_TopThreeLooms);
            this.groupControl4.Location = new System.Drawing.Point(348, 2);
            this.groupControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(183, 151);
            this.groupControl4.TabIndex = 1;
            this.groupControl4.Text = "Top 3 Looms";
            // 
            // tableLayoutPanel_TopThreeLooms
            // 
            this.tableLayoutPanel_TopThreeLooms.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel_TopThreeLooms.ColumnCount = 1;
            this.tableLayoutPanel_TopThreeLooms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_TopThreeLooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_TopThreeLooms.Location = new System.Drawing.Point(2, 31);
            this.tableLayoutPanel_TopThreeLooms.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_TopThreeLooms.Name = "tableLayoutPanel_TopThreeLooms";
            this.tableLayoutPanel_TopThreeLooms.RowCount = 1;
            this.tableLayoutPanel_TopThreeLooms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_TopThreeLooms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_TopThreeLooms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_TopThreeLooms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_TopThreeLooms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_TopThreeLooms.Size = new System.Drawing.Size(179, 118);
            this.tableLayoutPanel_TopThreeLooms.TabIndex = 58;
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.Options.UseTextOptions = true;
            this.groupControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl3.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl3.Controls.Add(this.tableLayoutPanel_TopThreeWeavers);
            this.groupControl3.Location = new System.Drawing.Point(0, 2);
            this.groupControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(346, 151);
            this.groupControl3.TabIndex = 0;
            this.groupControl3.Text = "Top 3 Weavers";
            // 
            // tableLayoutPanel_TopThreeWeavers
            // 
            this.tableLayoutPanel_TopThreeWeavers.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel_TopThreeWeavers.ColumnCount = 1;
            this.tableLayoutPanel_TopThreeWeavers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_TopThreeWeavers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_TopThreeWeavers.Location = new System.Drawing.Point(2, 31);
            this.tableLayoutPanel_TopThreeWeavers.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_TopThreeWeavers.Name = "tableLayoutPanel_TopThreeWeavers";
            this.tableLayoutPanel_TopThreeWeavers.RowCount = 1;
            this.tableLayoutPanel_TopThreeWeavers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_TopThreeWeavers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_TopThreeWeavers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_TopThreeWeavers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_TopThreeWeavers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_TopThreeWeavers.Size = new System.Drawing.Size(342, 118);
            this.tableLayoutPanel_TopThreeWeavers.TabIndex = 56;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.tableLayoutPanel_LongStoppedMachines);
            this.groupControl1.Location = new System.Drawing.Point(5, 459);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(719, 271);
            this.groupControl1.TabIndex = 61;
            this.groupControl1.Text = "Long Stopped Machines";
            // 
            // tableLayoutPanel_LongStoppedMachines
            // 
            this.tableLayoutPanel_LongStoppedMachines.AutoScroll = true;
            this.tableLayoutPanel_LongStoppedMachines.ColumnCount = 7;
            this.tableLayoutPanel_LongStoppedMachines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_LongStoppedMachines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_LongStoppedMachines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_LongStoppedMachines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_LongStoppedMachines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_LongStoppedMachines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_LongStoppedMachines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_LongStoppedMachines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_LongStoppedMachines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_LongStoppedMachines.Location = new System.Drawing.Point(2, 31);
            this.tableLayoutPanel_LongStoppedMachines.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_LongStoppedMachines.Name = "tableLayoutPanel_LongStoppedMachines";
            this.tableLayoutPanel_LongStoppedMachines.RowCount = 1;
            this.tableLayoutPanel_LongStoppedMachines.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_LongStoppedMachines.Size = new System.Drawing.Size(715, 238);
            this.tableLayoutPanel_LongStoppedMachines.TabIndex = 43;
            // 
            // tableLayoutPanel_ShedEff
            // 
            this.tableLayoutPanel_ShedEff.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel_ShedEff.ColumnCount = 1;
            this.tableLayoutPanel_ShedEff.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ShedEff.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel_ShedEff.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel_ShedEff.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel_ShedEff.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel_ShedEff.Controls.Add(this.ShedEfficiency, 0, 0);
            this.tableLayoutPanel_ShedEff.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel_ShedEff.Location = new System.Drawing.Point(5, 311);
            this.tableLayoutPanel_ShedEff.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_ShedEff.Name = "tableLayoutPanel_ShedEff";
            this.tableLayoutPanel_ShedEff.RowCount = 1;
            this.tableLayoutPanel_ShedEff.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_ShedEff.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_ShedEff.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_ShedEff.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_ShedEff.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_ShedEff.Size = new System.Drawing.Size(722, 144);
            this.tableLayoutPanel_ShedEff.TabIndex = 60;
            // 
            // ShedEfficiency
            // 
            this.ShedEfficiency.Appearance.BackColor = System.Drawing.Color.Black;
            this.ShedEfficiency.Appearance.BackColor2 = System.Drawing.Color.Black;
            this.ShedEfficiency.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 99.74999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShedEfficiency.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ShedEfficiency.Appearance.Options.UseBackColor = true;
            this.ShedEfficiency.Appearance.Options.UseFont = true;
            this.ShedEfficiency.Appearance.Options.UseForeColor = true;
            this.ShedEfficiency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShedEfficiency.Location = new System.Drawing.Point(5, 6);
            this.ShedEfficiency.LookAndFeel.SkinName = "Black";
            this.ShedEfficiency.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.ShedEfficiency.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ShedEfficiency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShedEfficiency.Name = "ShedEfficiency";
            this.ShedEfficiency.Size = new System.Drawing.Size(712, 132);
            this.ShedEfficiency.TabIndex = 59;
            this.ShedEfficiency.Text = "85.2%";
            // 
            // tableLayoutPanel_Efficiencies
            // 
            this.tableLayoutPanel_Efficiencies.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel_Efficiencies.ColumnCount = 1;
            this.tableLayoutPanel_Efficiencies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Efficiencies.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel_Efficiencies.Location = new System.Drawing.Point(5, 167);
            this.tableLayoutPanel_Efficiencies.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_Efficiencies.Name = "tableLayoutPanel_Efficiencies";
            this.tableLayoutPanel_Efficiencies.RowCount = 1;
            this.tableLayoutPanel_Efficiencies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_Efficiencies.Size = new System.Drawing.Size(722, 144);
            this.tableLayoutPanel_Efficiencies.TabIndex = 58;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(48, 48);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "article.png");
            this.imageCollection1.Images.SetKeyName(1, "electrical.png");
            this.imageCollection1.Images.SetKeyName(2, "knotting.png");
            this.imageCollection1.Images.SetKeyName(3, "mechanical.png");
            this.imageCollection1.Images.SetKeyName(4, "otherlong.png");
            // 
            // Dashboard_ModelShedEff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 898);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Dashboard_ModelShedEff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mode/ Make Efficiency View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_ModelShedEff_FormClosing);
            this.Load += new System.EventHandler(this.Dashboard_ModelShedEff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel_ShedEff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.Utils.ImageCollection imageCollection1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Efficiencies;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ShedEff;
        private DevExpress.XtraEditors.SimpleButton ShedEfficiency;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel_BottomThreeLooms;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel_TopThreeLooms;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel_TopThreeWeavers;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel_LongStoppedMachines;
    }
}