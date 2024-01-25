
namespace BuildingLeaseUI.UI.Modules
{
    partial class IncomingsBookTotalModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncomingsBookTotalModule));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchToDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.searchFromDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.searchButton = new DevExpress.XtraEditors.SimpleButton();
            this.printButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchToDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchToDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchFromDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchFromDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl);
            this.layoutControl1.Controls.Add(this.searchToDateEdit);
            this.layoutControl1.Controls.Add(this.searchFromDateEdit);
            this.layoutControl1.Controls.Add(this.searchButton);
            this.layoutControl1.Controls.Add(this.printButton);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1260, 700);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(24, 73);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1212, 603);
            this.gridControl.TabIndex = 7;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn5});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.AllowCellMerge = true;
            this.gridView.OptionsView.ShowFooter = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "계정과목 항";
            this.gridColumn1.FieldName = "AccountHangName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 237;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "계정과목";
            this.gridColumn2.FieldName = "AccountName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 254;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "예산액";
            this.gridColumn3.DisplayFormat.FormatString = "n0";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "BudgetAmount";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 170;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "수입액";
            this.gridColumn4.DisplayFormat.FormatString = "n0";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "IncomingsAmount";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 170;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "결손액";
            this.gridColumn6.DisplayFormat.FormatString = "n0";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "LossAmount";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 170;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "차액";
            this.gridColumn5.DisplayFormat.FormatString = "n0";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "DifferenceAmount";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 170;
            // 
            // searchToDateEdit
            // 
            this.searchToDateEdit.EditValue = new System.DateTime(2023, 9, 23, 18, 33, 36, 0);
            this.searchToDateEdit.Location = new System.Drawing.Point(190, 45);
            this.searchToDateEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchToDateEdit.Name = "searchToDateEdit";
            this.searchToDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.searchToDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchToDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchToDateEdit.Properties.DisplayFormat.FormatString = "y";
            this.searchToDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.searchToDateEdit.Properties.EditFormat.FormatString = "y";
            this.searchToDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.searchToDateEdit.Properties.MaskSettings.Set("mask", "y");
            this.searchToDateEdit.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.searchToDateEdit.Size = new System.Drawing.Size(98, 24);
            this.searchToDateEdit.StyleController = this.layoutControl1;
            this.searchToDateEdit.TabIndex = 1;
            this.searchToDateEdit.EditValueChanged += new System.EventHandler(this.searchToDateEdit_EditValueChanged);
            // 
            // searchFromDateEdit
            // 
            this.searchFromDateEdit.EditValue = new System.DateTime(2023, 9, 23, 18, 33, 30, 0);
            this.searchFromDateEdit.Location = new System.Drawing.Point(88, 45);
            this.searchFromDateEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchFromDateEdit.Name = "searchFromDateEdit";
            this.searchFromDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.searchFromDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchFromDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchFromDateEdit.Properties.DisplayFormat.FormatString = "y";
            this.searchFromDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.searchFromDateEdit.Properties.EditFormat.FormatString = "y";
            this.searchFromDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.searchFromDateEdit.Properties.MaskSettings.Set("mask", "y");
            this.searchFromDateEdit.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.searchFromDateEdit.Size = new System.Drawing.Size(98, 24);
            this.searchFromDateEdit.StyleController = this.layoutControl1;
            this.searchFromDateEdit.TabIndex = 0;
            this.searchFromDateEdit.EditValueChanged += new System.EventHandler(this.searchFromDateEdit_EditValueChanged);
            // 
            // searchButton
            // 
            this.searchButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.ImageOptions.Image")));
            this.searchButton.Location = new System.Drawing.Point(1070, 45);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(80, 24);
            this.searchButton.StyleController = this.layoutControl1;
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "조회";
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // printButton
            // 
            this.printButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("printButton.ImageOptions.Image")));
            this.printButton.Location = new System.Drawing.Point(1154, 45);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(82, 24);
            this.printButton.StyleController = this.layoutControl1;
            this.printButton.TabIndex = 5;
            this.printButton.Text = "출력";
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1260, 700);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceGroup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.layoutControlGroup3.AppearanceGroup.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup3.AppearanceGroup.Options.UseBorderColor = true;
            this.layoutControlGroup3.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup3.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutControlGroup3.CaptionImageOptions.Image")));
            this.layoutControlGroup3.CustomizationFormText = "조회";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem15,
            this.layoutControlItem14,
            this.layoutControlItem18,
            this.layoutControlItem12,
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1240, 680);
            this.layoutControlGroup3.Text = "수입부 총괄 리스트";
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.searchToDateEdit;
            this.layoutControlItem15.CustomizationFormText = "layoutControlItem15";
            this.layoutControlItem15.Location = new System.Drawing.Point(166, 0);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(102, 28);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.searchFromDateEdit;
            this.layoutControlItem14.CustomizationFormText = "조회일자";
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(166, 28);
            this.layoutControlItem14.Text = "거래일자";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(52, 17);
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.searchButton;
            this.layoutControlItem18.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem18.Location = new System.Drawing.Point(1046, 0);
            this.layoutControlItem18.MaxSize = new System.Drawing.Size(84, 28);
            this.layoutControlItem18.MinSize = new System.Drawing.Size(84, 28);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(84, 28);
            this.layoutControlItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.printButton;
            this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
            this.layoutControlItem12.Location = new System.Drawing.Point(1130, 0);
            this.layoutControlItem12.MaxSize = new System.Drawing.Size(86, 28);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(86, 28);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(86, 28);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1216, 607);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(268, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(778, 28);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // IncomingsBookTotalModule
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "IncomingsBookTotalModule";
            this.Size = new System.Drawing.Size(1260, 700);
            this.Load += new System.EventHandler(this.IncomingsBookTotalModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchToDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchToDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchFromDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchFromDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.DateEdit searchToDateEdit;
        private DevExpress.XtraEditors.DateEdit searchFromDateEdit;
        private DevExpress.XtraEditors.SimpleButton searchButton;
        private DevExpress.XtraEditors.SimpleButton printButton;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}
