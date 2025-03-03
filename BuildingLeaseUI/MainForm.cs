using BuildingLease.Library;
using BuildingLeaseUI.UI.Forms;
using DevExpress.DXperience.Demos;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingLeaseUI
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private Control _activeModule = null;
        string[] skinsToHide = { "Seven Classic", "WXI", "Contrast", "2016", "2013", "2010", "2007", "Sharp" };

        public MainForm()
        {
            InitializeComponent();

            // 추가된 컨트롤에서 한글이 선택되도록 한다.(Hangul = 한글 반각, HangulFull(전각)하면 안됨)
            ImeMode = ImeMode.Hangul;
            userNameItem.Caption = AppData.LogOn.UserName;
            backgroundPictureEdit.Dock = DockStyle.Fill;

            //관리자가 아니면 메뉴 숨김
            if (!AppData.LogOn.GradeTypeID.Equals(1))
            {
                //elementCodeGroup.Enabled = false;
                mnuBackup.Enabled = false;
            }
        }

        async Task LoadModuleAsync(ModuleInfo module)
        {
            await Task.Factory.StartNew(() =>
            {
                if (!fluentDesignFormContainer.Controls.ContainsKey(module.Name))
                {
                    if (module.TModule is TutorialControlBase control)
                    {
                        control.Dock = DockStyle.Fill;
                        control.CreateWaitDialog();
                        fluentDesignFormContainer.Invoke(new MethodInvoker(delegate ()
                        {
                            fluentDesignFormContainer.Controls.Add(control);
                            control.BringToFront();
                            _activeModule = control; // 활성화된 모듈
                        }));
                    }
                }
                else
                {
                    var control = fluentDesignFormContainer.Controls.Find(module.Name, true);
                    if (control.Length == 1)
                    {
                        fluentDesignFormContainer.Invoke(new MethodInvoker(delegate () { control[0].BringToFront(); }));
                        _activeModule = control[0];// 활성화된 모듈
                    }
                }
            });
        }

        private async Task LoadModule(string moduleName)
        {
            if (ModulesInfo.GetItem(moduleName) == null)
                ModulesInfo.Add(new ModuleInfo(moduleName, "BuildingLeaseUI.UI.Modules." + moduleName));
            await LoadModuleAsync(ModulesInfo.GetItem(moduleName));
        }

        private void HideSkins(string[] skinsToHide)
        {
            for (var i = 0; i < skinBarItem.ItemLinks.Count; i++)
            {
                //Check regular button items
                if (skinBarItem.ItemLinks[i] is BarButtonItemLink)
                {
                    var item = skinBarItem.ItemLinks[i];
                    foreach (var skin in skinsToHide)
                    {
                        if (item.Caption.Contains(skin))
                        {
                            item.Visible = false;
                        }
                    }
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            HideSkins(skinsToHide);

            // UserLookAndFeel Skin 적용: 프로젝트-속성-설정-SkinName 추가 후 작업
            // %AppData%\Local\어셈블리정보의 회사명\제품명_xxx\user.config 파일에 저장됨
            //  => 프로그램 버전이 변경시 %AppData%\Local\어셈블리정보의 회사명\ 폴더에 폴더가 계속 생겨서 App.Config 로 설정을 옮김
            //var settings = Properties.Settings.Default;
            //if (!string.IsNullOrEmpty(settings.SkinName))
            //    UserLookAndFeel.Default.SetSkinStyle(settings.SkinName);            

            //UserLookAndFeel.Default.SetSkinStyle(AppConfig.GetAppConfig("SkinName"));

            //this.fluentDesignFormContainer.Controls.Add(new CashBookModule() { Dock = DockStyle.Fill });
            //this.currentMenuItem.Caption = $"{mnuCashBook.Text}";
            //accordionControl1.SelectedElement = mnuCashBook;            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 현재 UserLookAndFeel Skin 저장: 프로젝트-속성-설정-SkinName 추가 후 작업
            // %AppData%\Local\어셈블리정보의 회사명\제품명_xxx\user.config 파일에 저장됨
            //  => 프로그램 버전이 변경시 %AppData%\Local\어셈블리정보의 회사명\ 폴더에 폴더가 계속 생겨서 App.Config 로 설정을 옮김
            //var settings = Properties.Settings.Default;
            //settings.SkinName = UserLookAndFeel.Default.SkinName;
            //settings.Save();

            // 현재 UserLookAndFeel Skin 저장: App.Config - AppSettings
            AppConfig.SetAppConfig("SkinName", UserLookAndFeel.Default.SkinName);

            // 매주 수요일, 금요일은 백업
            if (DateTime.UtcNow.AddHours(9).DayOfWeek == DayOfWeek.Wednesday || DateTime.UtcNow.AddHours(9).DayOfWeek == DayOfWeek.Friday)
            {
                // 관리자이면 백업
                if (AppData.LogOn.GradeTypeID.Equals(1))
                {
                    if (XtraMessageBox.Show("프로그램을 종료하기 전에 데이터를 백업하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var backupForm = new BackupForm
                        {
                            Size = this.Size
                        };
                        backupForm.ShowDialog(this);
                    }
                }
            }
        }

        private void SetCurrentMenuItem(object sender)
        {
            this.currentMenuItem.Caption = $"{((AccordionControlElement)sender).OwnerElement?.Text} > {(sender as AccordionControlElement).Text}";
        }

        private async void mnuCashBook_Click(object sender, EventArgs e)
        {
            this.currentMenuItem.Caption = $"{(sender as AccordionControlElement).Text}";
            await LoadModule("CashBookModule");
        }

        private async void mnuLessee_Click(object sender, EventArgs e)
        {
            //this.currentMenuItem.Caption = $"{((AccordionControlElement)sender).OwnerElement?.Text} > {(sender as AccordionControlElement).Text}";
            SetCurrentMenuItem(sender);
            await LoadModule("LesseeModule");
        }

        private async void mnuLeaseContract_Click(object sender, EventArgs e)
        {
            SetCurrentMenuItem(sender);
            await LoadModule("LeaseContractModule");
        }

        private async void mnuInvoiceList_Click(object sender, EventArgs e)
        {
            SetCurrentMenuItem(sender);
            await LoadModule("InvoiceListModule");
        }

        private async void mnuMaintenanceFeeDetails_Click(object sender, EventArgs e)
        {
            SetCurrentMenuItem(sender);
            await LoadModule("MaintenanceFeeDetailsModule");
        }

        private async void mnuIncomingsBookTotal_Click(object sender, EventArgs e)
        {
            SetCurrentMenuItem(sender);
            await LoadModule("IncomingsBookTotalModule");
        }

        private async void mnuIncomingsDetails_Click(object sender, EventArgs e)
        {
            SetCurrentMenuItem(sender);
            await LoadModule("IncomingsDetailsModule");
        }

        private async void mnuBuildingCode_Click(object sender, EventArgs e)
        {
            SetCurrentMenuItem(sender);
            await LoadModule("BuildingCodeModule");
        }

        private async void mnuUser_Click(object sender, EventArgs e)
        {
            //this.currentMenuItem.Caption = $"{((AccordionControlElement)sender).OwnerElement?.Text} > {(sender as AccordionControlElement).Text}";
            SetCurrentMenuItem(sender);
            await LoadModule("UserModule");
        }

        private async void mnuBackup_Click(object sender, EventArgs e)
        {
            //this.currentMenuItem.Caption = $"{((AccordionControlElement)sender).OwnerElement?.Text} > {(sender as AccordionControlElement).Text}";
            SetCurrentMenuItem(sender);
            await LoadModule("BackupModule");
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // 이벤트가 먹히게 하기 위해서 속성 KeyPreview = true 로 설정함
            // Ctrl + S 는 저장, 컨트롤이 enable false이면 작동 안됨.
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (_activeModule != null)
                {
                    var control = _activeModule.Controls.Find("saveButton", true);
                    if (control.Length == 1)
                        if (control[0] is SimpleButton button)
                            button.PerformClick(); //컨트롤이 enable false이면 작동 안됨.
                }
            }
            // Ctrl + N 는 신규
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (_activeModule != null)
                {
                    var control = _activeModule.Controls.Find("newButton", true);
                    if (control.Length == 1)
                        if (control[0] is SimpleButton button)
                            button.PerformClick(); //컨트롤이 enable false이면 작동 안됨.
                }
            }
            // Ctrl + D 는 삭제
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (_activeModule != null)
                {
                    var control = _activeModule.Controls.Find("deleteButton", true);
                    if (control.Length == 1)
                        if (control[0] is SimpleButton button)
                            button.PerformClick(); //컨트롤이 enable false이면 작동 안됨.
                }
            }
        }

        private void manualBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var file = System.IO.Path.Combine(AppConfig.AppPath, "건물임대관리 메뉴얼.pdf");
                System.Diagnostics.Process.Start(file);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error");
            }
        }

    }
}
