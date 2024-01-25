
namespace BuildingLeaseUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.currentMenuItem = new DevExpress.XtraBars.BarStaticItem();
            this.userNameItem = new DevExpress.XtraBars.BarStaticItem();
            this.skinBarItem = new DevExpress.XtraBars.SkinBarSubItem();
            this.helpBarListItem = new DevExpress.XtraBars.BarListItem();
            this.manualBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.fluentDesignFormContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.backgroundPictureEdit = new DevExpress.XtraEditors.PictureEdit();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.mnuCashBook = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.lesseeGroupElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuLessee = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuLeaseContract = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.invoiceGroupElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuInvoiceList = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuMaintenanceFeeDetails = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.inOutGroupElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuIncomingsBookTotal = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuIncomingsDetails = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.codeGroupElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuBuildingCode = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuUser = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.configGroupElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuBackup = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement7 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement5 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.fluentDesignFormContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.currentMenuItem,
            this.userNameItem,
            this.skinBarItem,
            this.helpBarListItem,
            this.manualBarButtonItem});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1270, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.userNameItem);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.currentMenuItem);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.manualBarButtonItem);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.helpBarListItem);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.skinBarItem);
            // 
            // currentMenuItem
            // 
            this.currentMenuItem.Caption = "현재메뉴";
            this.currentMenuItem.Id = 0;
            this.currentMenuItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("currentMenuItem.ImageOptions.SvgImage")));
            this.currentMenuItem.ItemAppearance.Normal.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.currentMenuItem.ItemAppearance.Normal.Options.UseFont = true;
            this.currentMenuItem.Name = "currentMenuItem";
            this.currentMenuItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.currentMenuItem.Tag = "활성 UI Module의 caption 표시";
            // 
            // userNameItem
            // 
            this.userNameItem.Caption = "사용자";
            this.userNameItem.Id = 0;
            this.userNameItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("userNameItem.ImageOptions.SvgImage")));
            this.userNameItem.Name = "userNameItem";
            this.userNameItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // skinBarItem
            // 
            this.skinBarItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.skinBarItem.AllowSerializeChildren = DevExpress.Utils.DefaultBoolean.False;
            this.skinBarItem.Caption = "SKIN";
            this.skinBarItem.Id = 2;
            this.skinBarItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("skinBarItem.ImageOptions.SvgImage")));
            this.skinBarItem.Name = "skinBarItem";
            this.skinBarItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // helpBarListItem
            // 
            this.helpBarListItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.helpBarListItem.Caption = "단축키";
            this.helpBarListItem.Id = 0;
            this.helpBarListItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("helpBarListItem.ImageOptions.SvgImage")));
            this.helpBarListItem.Name = "helpBarListItem";
            this.helpBarListItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            this.helpBarListItem.Strings.AddRange(new object[] {
            "커서를 다음으로 이동: Tab",
            "커서를 이전으로 이동: Shift + Tab",
            "-",
            "신규: Ctrl + N",
            "삭제: Ctrl + D",
            "저장: Ctrl + S"});
            // 
            // manualBarButtonItem
            // 
            this.manualBarButtonItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.manualBarButtonItem.Caption = "메뉴얼";
            this.manualBarButtonItem.Id = 1;
            this.manualBarButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("manualBarButtonItem.ImageOptions.SvgImage")));
            this.manualBarButtonItem.Name = "manualBarButtonItem";
            this.manualBarButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            this.manualBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.manualBarButtonItem_ItemClick);
            // 
            // fluentDesignFormContainer
            // 
            this.fluentDesignFormContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.fluentDesignFormContainer.Controls.Add(this.backgroundPictureEdit);
            this.fluentDesignFormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer.Location = new System.Drawing.Point(200, 31);
            this.fluentDesignFormContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fluentDesignFormContainer.Name = "fluentDesignFormContainer";
            this.fluentDesignFormContainer.Size = new System.Drawing.Size(1070, 719);
            this.fluentDesignFormContainer.TabIndex = 1;
            // 
            // backgroundPictureEdit
            // 
            this.backgroundPictureEdit.EditValue = ((object)(resources.GetObject("backgroundPictureEdit.EditValue")));
            this.backgroundPictureEdit.Location = new System.Drawing.Point(102, 86);
            this.backgroundPictureEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backgroundPictureEdit.Name = "backgroundPictureEdit";
            this.backgroundPictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.backgroundPictureEdit.Size = new System.Drawing.Size(861, 441);
            this.backgroundPictureEdit.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.ContextButtonsOptions.Indent = 3;
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnuCashBook,
            this.lesseeGroupElement,
            this.invoiceGroupElement,
            this.inOutGroupElement,
            this.codeGroupElement,
            this.configGroupElement});
            this.accordionControl1.ExpandItemOnHeaderClick = false;
            this.accordionControl1.Location = new System.Drawing.Point(0, 31);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.OptionsMinimizing.NormalWidth = 200;
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Fluent;
            this.accordionControl1.ShowGroupExpandButtons = false;
            this.accordionControl1.Size = new System.Drawing.Size(200, 719);
            this.accordionControl1.TabIndex = 0;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // mnuCashBook
            // 
            this.mnuCashBook.Hint = "금전출납부";
            this.mnuCashBook.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("mnuCashBook.ImageOptions.SvgImage")));
            this.mnuCashBook.Name = "mnuCashBook";
            this.mnuCashBook.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuCashBook.Text = "금전출납부";
            this.mnuCashBook.Click += new System.EventHandler(this.mnuCashBook_Click);
            // 
            // lesseeGroupElement
            // 
            this.lesseeGroupElement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnuLessee,
            this.mnuLeaseContract});
            this.lesseeGroupElement.Expanded = true;
            this.lesseeGroupElement.Hint = "임차인, 계약";
            this.lesseeGroupElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lesseeGroupElement.ImageOptions.SvgImage")));
            this.lesseeGroupElement.Name = "lesseeGroupElement";
            this.lesseeGroupElement.Text = "임차인, 계약";
            // 
            // mnuLessee
            // 
            this.mnuLessee.Name = "mnuLessee";
            this.mnuLessee.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuLessee.Text = "임차인(거래처)";
            this.mnuLessee.Click += new System.EventHandler(this.mnuLessee_Click);
            // 
            // mnuLeaseContract
            // 
            this.mnuLeaseContract.Name = "mnuLeaseContract";
            this.mnuLeaseContract.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuLeaseContract.Text = "임대차 계약";
            this.mnuLeaseContract.Click += new System.EventHandler(this.mnuLeaseContract_Click);
            // 
            // invoiceGroupElement
            // 
            this.invoiceGroupElement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnuInvoiceList,
            this.mnuMaintenanceFeeDetails});
            this.invoiceGroupElement.Expanded = true;
            this.invoiceGroupElement.Hint = "예산, 청구";
            this.invoiceGroupElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("invoiceGroupElement.ImageOptions.SvgImage")));
            this.invoiceGroupElement.Name = "invoiceGroupElement";
            this.invoiceGroupElement.Text = "예산, 청구";
            // 
            // mnuInvoiceList
            // 
            this.mnuInvoiceList.Name = "mnuInvoiceList";
            this.mnuInvoiceList.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuInvoiceList.Text = "청구서 전체 조회";
            this.mnuInvoiceList.Click += new System.EventHandler(this.mnuInvoiceList_Click);
            // 
            // mnuMaintenanceFeeDetails
            // 
            this.mnuMaintenanceFeeDetails.Name = "mnuMaintenanceFeeDetails";
            this.mnuMaintenanceFeeDetails.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuMaintenanceFeeDetails.Text = "관리비 명세서 출력";
            this.mnuMaintenanceFeeDetails.Click += new System.EventHandler(this.mnuMaintenanceFeeDetails_Click);
            // 
            // inOutGroupElement
            // 
            this.inOutGroupElement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnuIncomingsBookTotal,
            this.mnuIncomingsDetails});
            this.inOutGroupElement.Expanded = true;
            this.inOutGroupElement.Hint = "수입, 지출";
            this.inOutGroupElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("inOutGroupElement.ImageOptions.SvgImage")));
            this.inOutGroupElement.Name = "inOutGroupElement";
            this.inOutGroupElement.Text = "수입, 지출";
            // 
            // mnuIncomingsBookTotal
            // 
            this.mnuIncomingsBookTotal.Name = "mnuIncomingsBookTotal";
            this.mnuIncomingsBookTotal.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuIncomingsBookTotal.Text = "수입부 총괄";
            this.mnuIncomingsBookTotal.Click += new System.EventHandler(this.mnuIncomingsBookTotal_Click);
            // 
            // mnuIncomingsDetails
            // 
            this.mnuIncomingsDetails.Name = "mnuIncomingsDetails";
            this.mnuIncomingsDetails.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuIncomingsDetails.Text = "수입 상세 현황";
            this.mnuIncomingsDetails.Click += new System.EventHandler(this.mnuIncomingsDetails_Click);
            // 
            // codeGroupElement
            // 
            this.codeGroupElement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnuBuildingCode,
            this.mnuUser});
            this.codeGroupElement.Expanded = true;
            this.codeGroupElement.Hint = "기초코드";
            this.codeGroupElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("codeGroupElement.ImageOptions.SvgImage")));
            this.codeGroupElement.Name = "codeGroupElement";
            this.codeGroupElement.Text = "기초코드";
            // 
            // mnuBuildingCode
            // 
            this.mnuBuildingCode.Name = "mnuBuildingCode";
            this.mnuBuildingCode.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuBuildingCode.Text = "건물코드";
            this.mnuBuildingCode.Click += new System.EventHandler(this.mnuBuildingCode_Click);
            // 
            // mnuUser
            // 
            this.mnuUser.Name = "mnuUser";
            this.mnuUser.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuUser.Text = "사용자";
            this.mnuUser.Click += new System.EventHandler(this.mnuUser_Click);
            // 
            // configGroupElement
            // 
            this.configGroupElement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnuBackup});
            this.configGroupElement.Expanded = true;
            this.configGroupElement.Hint = "설정";
            this.configGroupElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("configGroupElement.ImageOptions.SvgImage")));
            this.configGroupElement.Name = "configGroupElement";
            this.configGroupElement.Text = "설정";
            // 
            // mnuBackup
            // 
            this.mnuBackup.Name = "mnuBackup";
            this.mnuBackup.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnuBackup.Text = "백업";
            this.mnuBackup.Click += new System.EventHandler(this.mnuBackup_Click);
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement1.Text = "Element1";
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement2.Text = "Element2";
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement3.Text = "Element3";
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.accordionControlElement2,
            this.accordionControlElement3,
            this.accordionControlElement7});
            this.accordionControlElement4.Expanded = true;
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Text = "Element4";
            // 
            // accordionControlElement7
            // 
            this.accordionControlElement7.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement5});
            this.accordionControlElement7.Name = "accordionControlElement7";
            this.accordionControlElement7.Text = "Element7";
            // 
            // accordionControlElement5
            // 
            this.accordionControlElement5.Name = "accordionControlElement5";
            this.accordionControlElement5.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement5.Text = "Element5";
            // 
            // MainForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 750);
            this.ControlContainer = this.fluentDesignFormContainer;
            this.Controls.Add(this.fluentDesignFormContainer);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("MainForm.IconOptions.Image")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "건물 임대 관리";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.fluentDesignFormContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.BarStaticItem currentMenuItem;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement lesseeGroupElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuLessee;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuLeaseContract;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuMaintenanceFeeDetails;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuCashBook;
        private DevExpress.XtraBars.Navigation.AccordionControlElement inOutGroupElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement codeGroupElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuBuildingCode;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuUser;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuIncomingsBookTotal;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuIncomingsDetails;
        private DevExpress.XtraBars.Navigation.AccordionControlElement configGroupElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement7;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement5;
        private DevExpress.XtraBars.BarStaticItem userNameItem;
        private DevExpress.XtraBars.SkinBarSubItem skinBarItem;
        private DevExpress.XtraBars.BarListItem helpBarListItem;
        private DevExpress.XtraBars.BarButtonItem manualBarButtonItem;
        private DevExpress.XtraBars.Navigation.AccordionControlElement invoiceGroupElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuInvoiceList;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnuBackup;
        private DevExpress.XtraEditors.PictureEdit backgroundPictureEdit;
    }
}