using BuildingLease.Library;
using BuildingLeaseUI.UI.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System;
using System.Linq;
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
        #region LoadModuleAsync
        private async Task LoadModuleAsync(string moduleName)
        {
            var control = fluentDesignFormContainer.Controls.Find(moduleName, false).FirstOrDefault();
            if (control != null)
            {
                await BringControlToFrontAsync(control);
                return;
            }

            // Module의 위치가 변경되면 수정해야함.
            // 명확한 네임스페이스 처리를 위해 typeof(MainForm).Namespace 사용
            var moduleNamespace = $"{typeof(MainForm).Namespace}.UI.Modules";
            var typeName = $"{moduleNamespace}.{moduleName}";
            var type = Type.GetType(typeName);
            if (type != null && Activator.CreateInstance(type) is XtraUserControl controlInstance)
            {
                controlInstance.Name = moduleName; // 모듈 이름 설정
                await AddControlToContainerAsync(controlInstance);
            }
        }

        private Task AddControlToContainerAsync(XtraUserControl controlInstance)
        {
            return RunOnUIThreadAsync(() =>
            {
                fluentDesignFormContainer.Controls.Add(controlInstance);
                controlInstance.Dock = DockStyle.Fill;
                controlInstance.BringToFront();
                controlInstance.Select();
                _activeModule = controlInstance;
            });
        }

        private Task BringControlToFrontAsync(Control control)
        {
            return RunOnUIThreadAsync(() =>
            {
                control.BringToFront();
                control.Select();
                _activeModule = control;
            });
        }

        /// <summary>
        /// UI 스레드에서 안전하게 작업을 수행하기 위해 사용됩니다. 
        /// 현재 스레드가 UI 스레드인지 확인하고, UI 스레드가 아닌 경우 BeginInvoke를 사용하여 UI 스레드에서 작업을 수행합니다. 
        /// 비동기 작업을 처리하기 위해 TaskCompletionSource를 사용하여 작업이 완료될 때까지 기다릴 수 있도록 합니다.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private Task RunOnUIThreadAsync(Action action)
        {
            if (InvokeRequired)
            {
                var tcs = new TaskCompletionSource<bool>();
                BeginInvoke(new Action(() =>
                {
                    action();
                    tcs.SetResult(true);
                }));
                return tcs.Task;
            }
            else
            {
                action();
                return Task.CompletedTask;
            }
        }
        #endregion LoadModuleAsync

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

            UserLookAndFeel.Default.SetSkinStyle(AppConfig.GetAppConfig("SkinName"));

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

        private String GetCurrentMenuItem(object sender)
        {
            var element = sender as AccordionControlElement;
            return $"{element?.OwnerElement?.Text} > {element?.Text}";
        }

        private async void mnuCashBook_Click(object sender, EventArgs e)
        {
            this.currentMenuItem.Caption = $"{(sender as AccordionControlElement)?.Text}";
            await LoadModuleAsync("CashBookModule");
        }

        private async void mnuLessee_Click(object sender, EventArgs e)
        {
            this.currentMenuItem.Caption = GetCurrentMenuItem(sender);
            await LoadModuleAsync("LesseeModule");
        }

        private async void mnuLeaseContract_Click(object sender, EventArgs e)
        {
            this.currentMenuItem.Caption = GetCurrentMenuItem(sender);
            await LoadModuleAsync("LeaseContractModule");
        }

        private async void mnuInvoiceList_Click(object sender, EventArgs e)
        {
            this.currentMenuItem.Caption = GetCurrentMenuItem(sender);
            await LoadModuleAsync("InvoiceListModule");
        }

        private async void mnuMaintenanceFeeDetails_Click(object sender, EventArgs e)
        {
            this.currentMenuItem.Caption = GetCurrentMenuItem(sender);
            await LoadModuleAsync("MaintenanceFeeDetailsModule");
        }

        private async void mnuIncomingsBookTotal_Click(object sender, EventArgs e)
        {
            this.currentMenuItem.Caption = GetCurrentMenuItem(sender);
            await LoadModuleAsync("IncomingsBookTotalModule");
        }

        private async void mnuIncomingsDetails_Click(object sender, EventArgs e)
        {
            this.currentMenuItem.Caption = GetCurrentMenuItem(sender);
            await LoadModuleAsync("IncomingsDetailsModule");
        }

        private async void mnuBuildingCode_Click(object sender, EventArgs e)
        {
            this.currentMenuItem.Caption = GetCurrentMenuItem(sender);
            await LoadModuleAsync("BuildingCodeModule");
        }

        private async void mnuUser_Click(object sender, EventArgs e)
        {
            this.currentMenuItem.Caption = GetCurrentMenuItem(sender);
            await LoadModuleAsync("UserModule");
        }

        private async void mnuBackup_Click(object sender, EventArgs e)
        {
            this.currentMenuItem.Caption = GetCurrentMenuItem(sender);
            await LoadModuleAsync("BackupModule");
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
