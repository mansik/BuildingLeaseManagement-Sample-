
namespace BuildingLeaseUI.UI.Modules
{
    partial class BackupModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupModule));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.backupButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.backupPathLabel = new DevExpress.XtraLayout.SimpleLabelItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.fullFileNameLabel = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem3 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupPathLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullFileNameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.backupButton);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(784, 432);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // backupButton
            // 
            this.backupButton.Location = new System.Drawing.Point(353, 90);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(83, 24);
            this.backupButton.StyleController = this.layoutControl1;
            this.backupButton.TabIndex = 5;
            this.backupButton.Text = "백업";
            this.backupButton.Click += new System.EventHandler(this.backupButton_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(784, 432);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AppearanceGroup.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup2.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutControlGroup2.CaptionImageOptions.Image")));
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.simpleLabelItem1,
            this.backupPathLabel,
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.emptySpaceItem3,
            this.fullFileNameLabel,
            this.simpleLabelItem3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(764, 118);
            this.layoutControlGroup2.Text = "데이터베이스 백업";
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(137, 21);
            this.simpleLabelItem1.Text = "대상경로:";
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(72, 17);
            // 
            // backupPathLabel
            // 
            this.backupPathLabel.AllowHotTrack = false;
            this.backupPathLabel.Location = new System.Drawing.Point(137, 0);
            this.backupPathLabel.Name = "backupPathLabel";
            this.backupPathLabel.Size = new System.Drawing.Size(603, 21);
            this.backupPathLabel.Text = "backupPath";
            this.backupPathLabel.TextSize = new System.Drawing.Size(72, 17);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 42);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(329, 28);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.backupButton;
            this.layoutControlItem2.Location = new System.Drawing.Point(329, 42);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(87, 28);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(87, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(87, 28);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(416, 42);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(324, 28);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // fullFileNameLabel
            // 
            this.fullFileNameLabel.AllowHotTrack = false;
            this.fullFileNameLabel.Location = new System.Drawing.Point(137, 21);
            this.fullFileNameLabel.Name = "fullFileNameLabel";
            this.fullFileNameLabel.Size = new System.Drawing.Size(603, 21);
            this.fullFileNameLabel.Text = "fullFileName";
            this.fullFileNameLabel.TextSize = new System.Drawing.Size(72, 17);
            // 
            // simpleLabelItem3
            // 
            this.simpleLabelItem3.AllowHotTrack = false;
            this.simpleLabelItem3.Location = new System.Drawing.Point(0, 21);
            this.simpleLabelItem3.Name = "simpleLabelItem3";
            this.simpleLabelItem3.Size = new System.Drawing.Size(137, 21);
            this.simpleLabelItem3.Text = "백업파일:";
            this.simpleLabelItem3.TextSize = new System.Drawing.Size(72, 17);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 118);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(764, 294);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // BackupModule
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "BackupModule";
            this.Load += new System.EventHandler(this.BackupModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupPathLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullFileNameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton backupButton;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraLayout.SimpleLabelItem backupPathLabel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.SimpleLabelItem fullFileNameLabel;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem3;
    }
}
