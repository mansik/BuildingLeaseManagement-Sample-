
namespace BuildingLeaseUI.UI.Modules
{
    partial class BuildingCodeModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuildingCodeModule));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.deleteButton = new DevExpress.XtraEditors.SimpleButton();
            this.saveButton = new DevExpress.XtraEditors.SimpleButton();
            this.newButton = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.buildingNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.useFlagCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.notesTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.displaySeqSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildingNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.useFlagCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notesTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.displaySeqSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.deleteButton);
            this.layoutControl1.Controls.Add(this.saveButton);
            this.layoutControl1.Controls.Add(this.newButton);
            this.layoutControl1.Controls.Add(this.gridControl);
            this.layoutControl1.Controls.Add(this.buildingNameTextEdit);
            this.layoutControl1.Controls.Add(this.useFlagCheckEdit);
            this.layoutControl1.Controls.Add(this.notesTextEdit);
            this.layoutControl1.Controls.Add(this.displaySeqSpinEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1260, 700);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // deleteButton
            // 
            this.deleteButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.ImageOptions.Image")));
            this.deleteButton.Location = new System.Drawing.Point(1071, 76);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(80, 24);
            this.deleteButton.StyleController = this.layoutControl1;
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "삭제";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.ImageOptions.Image")));
            this.saveButton.Location = new System.Drawing.Point(1155, 76);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(81, 24);
            this.saveButton.StyleController = this.layoutControl1;
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "저장";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // newButton
            // 
            this.newButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("newButton.ImageOptions.Image")));
            this.newButton.Location = new System.Drawing.Point(990, 76);
            this.newButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(77, 24);
            this.newButton.StyleController = this.layoutControl1;
            this.newButton.TabIndex = 5;
            this.newButton.Text = "신규";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(24, 152);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1212, 524);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_RowClick);
            this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            this.gridView.ColumnFilterChanged += new System.EventHandler(this.gridView_ColumnFilterChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "건물 명칭";
            this.gridColumn2.FieldName = "BuildingName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 365;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "비고";
            this.gridColumn5.FieldName = "Notes";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 666;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "순서";
            this.gridColumn3.FieldName = "DisplaySeq";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 78;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "사용";
            this.gridColumn4.FieldName = "UseFlag";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 85;
            // 
            // buildingNameTextEdit
            // 
            this.buildingNameTextEdit.Location = new System.Drawing.Point(85, 48);
            this.buildingNameTextEdit.Name = "buildingNameTextEdit";
            this.buildingNameTextEdit.Size = new System.Drawing.Size(397, 24);
            this.buildingNameTextEdit.StyleController = this.layoutControl1;
            this.buildingNameTextEdit.TabIndex = 1;
            // 
            // useFlagCheckEdit
            // 
            this.useFlagCheckEdit.Location = new System.Drawing.Point(1155, 48);
            this.useFlagCheckEdit.Name = "useFlagCheckEdit";
            this.useFlagCheckEdit.Properties.Caption = "사용";
            this.useFlagCheckEdit.Size = new System.Drawing.Size(81, 21);
            this.useFlagCheckEdit.StyleController = this.layoutControl1;
            this.useFlagCheckEdit.TabIndex = 4;
            // 
            // notesTextEdit
            // 
            this.notesTextEdit.Location = new System.Drawing.Point(547, 48);
            this.notesTextEdit.Name = "notesTextEdit";
            this.notesTextEdit.Size = new System.Drawing.Size(439, 24);
            this.notesTextEdit.StyleController = this.layoutControl1;
            this.notesTextEdit.TabIndex = 2;
            // 
            // displaySeqSpinEdit
            // 
            this.displaySeqSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.displaySeqSpinEdit.Location = new System.Drawing.Point(1051, 48);
            this.displaySeqSpinEdit.Name = "displaySeqSpinEdit";
            this.displaySeqSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.displaySeqSpinEdit.Size = new System.Drawing.Size(100, 24);
            this.displaySeqSpinEdit.StyleController = this.layoutControl1;
            this.displaySeqSpinEdit.TabIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1260, 700);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AppearanceGroup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.layoutControlGroup2.AppearanceGroup.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup2.AppearanceGroup.Options.UseBorderColor = true;
            this.layoutControlGroup2.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutControlGroup2.CaptionImageOptions.Image")));
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.layoutControlItem12,
            this.layoutControlItem9,
            this.layoutControlItem5,
            this.layoutControlItem8,
            this.layoutControlItem7});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1240, 104);
            this.layoutControlGroup2.Text = "건물 입력";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.buildingNameTextEdit;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(462, 28);
            this.layoutControlItem2.Text = "건물 명칭";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(57, 17);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.useFlagCheckEdit;
            this.layoutControlItem6.Location = new System.Drawing.Point(1131, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(85, 27);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(85, 27);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(85, 28);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 28);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(966, 28);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.notesTextEdit;
            this.layoutControlItem12.Location = new System.Drawing.Point(462, 0);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(504, 28);
            this.layoutControlItem12.Text = "비고";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(57, 17);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.newButton;
            this.layoutControlItem9.Location = new System.Drawing.Point(966, 28);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(81, 28);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(81, 28);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(81, 28);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.displaySeqSpinEdit;
            this.layoutControlItem5.CustomizationFormText = "순서";
            this.layoutControlItem5.Location = new System.Drawing.Point(966, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(165, 28);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(165, 28);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(165, 28);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "순서";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(57, 17);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.saveButton;
            this.layoutControlItem8.Location = new System.Drawing.Point(1131, 28);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(85, 28);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(85, 28);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(85, 28);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.deleteButton;
            this.layoutControlItem7.Location = new System.Drawing.Point(1047, 28);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(84, 28);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(84, 28);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(84, 28);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceGroup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.layoutControlGroup3.AppearanceGroup.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup3.AppearanceGroup.Options.UseBorderColor = true;
            this.layoutControlGroup3.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup3.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutControlGroup3.CaptionImageOptions.Image")));
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 104);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1240, 576);
            this.layoutControlGroup3.Text = "건물 리스트";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1216, 528);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // BuildingCodeModule
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "BuildingCodeModule";
            this.Size = new System.Drawing.Size(1260, 700);
            this.Load += new System.EventHandler(this.BuildingCodeModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildingNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.useFlagCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notesTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.displaySeqSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton deleteButton;
        private DevExpress.XtraEditors.SimpleButton saveButton;
        private DevExpress.XtraEditors.SimpleButton newButton;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.TextEdit buildingNameTextEdit;
        private DevExpress.XtraEditors.CheckEdit useFlagCheckEdit;
        private DevExpress.XtraEditors.TextEdit notesTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SpinEdit displaySeqSpinEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
