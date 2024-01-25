
namespace BuildingLeaseUI.UI.Modules
{
    partial class UserModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserModule));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.useFlagCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.deleteButton = new DevExpress.XtraEditors.SimpleButton();
            this.saveButton = new DevExpress.XtraEditors.SimpleButton();
            this.newButton = new DevExpress.XtraEditors.SimpleButton();
            this.gradeTypeIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gradeTypeIdRepositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.userNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.passwordTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.useFlagCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeTypeIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeTypeIdRepositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.useFlagCheckEdit);
            this.layoutControl1.Controls.Add(this.deleteButton);
            this.layoutControl1.Controls.Add(this.saveButton);
            this.layoutControl1.Controls.Add(this.newButton);
            this.layoutControl1.Controls.Add(this.gradeTypeIdLookUpEdit);
            this.layoutControl1.Controls.Add(this.gridControl);
            this.layoutControl1.Controls.Add(this.userNameTextEdit);
            this.layoutControl1.Controls.Add(this.passwordTextEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1260, 700);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // useFlagCheckEdit
            // 
            this.useFlagCheckEdit.Location = new System.Drawing.Point(1157, 48);
            this.useFlagCheckEdit.Name = "useFlagCheckEdit";
            this.useFlagCheckEdit.Properties.Caption = "사용";
            this.useFlagCheckEdit.Size = new System.Drawing.Size(79, 21);
            this.useFlagCheckEdit.StyleController = this.layoutControl1;
            this.useFlagCheckEdit.TabIndex = 4;
            // 
            // deleteButton
            // 
            this.deleteButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.ImageOptions.Image")));
            this.deleteButton.Location = new System.Drawing.Point(1074, 76);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(79, 24);
            this.deleteButton.StyleController = this.layoutControl1;
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "삭제";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.ImageOptions.Image")));
            this.saveButton.Location = new System.Drawing.Point(1157, 76);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(79, 24);
            this.saveButton.StyleController = this.layoutControl1;
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "저장";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // newButton
            // 
            this.newButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("newButton.ImageOptions.Image")));
            this.newButton.Location = new System.Drawing.Point(991, 76);
            this.newButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(79, 24);
            this.newButton.StyleController = this.layoutControl1;
            this.newButton.TabIndex = 5;
            this.newButton.Text = "신규";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // gradeTypeIdLookUpEdit
            // 
            this.gradeTypeIdLookUpEdit.Location = new System.Drawing.Point(1047, 48);
            this.gradeTypeIdLookUpEdit.Name = "gradeTypeIdLookUpEdit";
            this.gradeTypeIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gradeTypeIdLookUpEdit.Properties.NullText = "";
            this.gradeTypeIdLookUpEdit.Properties.ShowFooter = false;
            this.gradeTypeIdLookUpEdit.Properties.ShowHeader = false;
            this.gradeTypeIdLookUpEdit.Size = new System.Drawing.Size(106, 24);
            this.gradeTypeIdLookUpEdit.StyleController = this.layoutControl1;
            this.gradeTypeIdLookUpEdit.TabIndex = 3;
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(24, 152);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gradeTypeIdRepositoryItemLookUpEdit});
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
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
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
            this.gridColumn2.Caption = "이름";
            this.gridColumn2.FieldName = "UserName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 311;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "비밀번호";
            this.gridColumn3.FieldName = "Password";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 280;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "등급";
            this.gridColumn4.ColumnEdit = this.gradeTypeIdRepositoryItemLookUpEdit;
            this.gridColumn4.FieldName = "GradeTypeId";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 110;
            // 
            // gradeTypeIdRepositoryItemLookUpEdit
            // 
            this.gradeTypeIdRepositoryItemLookUpEdit.AutoHeight = false;
            this.gradeTypeIdRepositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gradeTypeIdRepositoryItemLookUpEdit.Name = "gradeTypeIdRepositoryItemLookUpEdit";
            this.gradeTypeIdRepositoryItemLookUpEdit.NullText = "";
            this.gradeTypeIdRepositoryItemLookUpEdit.ShowHeader = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "사용";
            this.gridColumn5.FieldName = "UseFlag";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 113;
            // 
            // userNameTextEdit
            // 
            this.userNameTextEdit.Location = new System.Drawing.Point(80, 48);
            this.userNameTextEdit.Name = "userNameTextEdit";
            this.userNameTextEdit.Size = new System.Drawing.Size(226, 24);
            this.userNameTextEdit.StyleController = this.layoutControl1;
            this.userNameTextEdit.TabIndex = 1;
            // 
            // passwordTextEdit
            // 
            this.passwordTextEdit.Location = new System.Drawing.Point(366, 48);
            this.passwordTextEdit.Name = "passwordTextEdit";
            this.passwordTextEdit.Properties.UseSystemPasswordChar = true;
            this.passwordTextEdit.Size = new System.Drawing.Size(621, 24);
            this.passwordTextEdit.StyleController = this.layoutControl1;
            this.passwordTextEdit.TabIndex = 2;
            this.passwordTextEdit.EditValueChanged += new System.EventHandler(this.passwordTextEdit_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1260, 700);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AppearanceGroup.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup2.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutControlGroup2.CaptionImageOptions.Image")));
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem3,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1240, 104);
            this.layoutControlGroup2.Text = "사용자 입력";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.userNameTextEdit;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(286, 28);
            this.layoutControlItem3.Text = "이름";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 17);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.passwordTextEdit;
            this.layoutControlItem5.Location = new System.Drawing.Point(286, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(681, 28);
            this.layoutControlItem5.Text = "비밀번호";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(52, 17);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.gradeTypeIdLookUpEdit;
            this.layoutControlItem6.Location = new System.Drawing.Point(967, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(166, 28);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(166, 28);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(166, 28);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "등급";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(52, 17);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 28);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(967, 28);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.newButton;
            this.layoutControlItem7.Location = new System.Drawing.Point(967, 28);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(83, 28);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(83, 28);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(83, 28);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.deleteButton;
            this.layoutControlItem8.Location = new System.Drawing.Point(1050, 28);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(83, 28);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(83, 28);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(83, 28);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.useFlagCheckEdit;
            this.layoutControlItem9.Location = new System.Drawing.Point(1133, 0);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(83, 27);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(83, 27);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(83, 28);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.saveButton;
            this.layoutControlItem10.Location = new System.Drawing.Point(1133, 28);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(83, 28);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(83, 28);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(83, 28);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceGroup.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup3.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup3.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutControlGroup3.CaptionImageOptions.Image")));
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 104);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1240, 576);
            this.layoutControlGroup3.Text = "사용자 리스트";
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
            // UserModule
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserModule";
            this.Size = new System.Drawing.Size(1260, 700);
            this.Load += new System.EventHandler(this.UsersModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.useFlagCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeTypeIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeTypeIdRepositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit gradeTypeIdLookUpEdit;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.TextEdit userNameTextEdit;
        private DevExpress.XtraEditors.TextEdit passwordTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraEditors.SimpleButton deleteButton;
        private DevExpress.XtraEditors.SimpleButton saveButton;
        private DevExpress.XtraEditors.SimpleButton newButton;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gradeTypeIdRepositoryItemLookUpEdit;
        private DevExpress.XtraEditors.CheckEdit useFlagCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}
