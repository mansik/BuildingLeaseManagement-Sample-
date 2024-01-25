using BuildingLease.Library;
using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseUI.UI.Forms;
using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BuildingLeaseUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string precessName = "BuildingLeaseManagement";
            // 중복실행 방지
            // 이전 프로세스가 존재하면 CreatedNew = false            
            System.Threading.Mutex mtx = new System.Threading.Mutex(true, precessName, out bool createdNew);
            try
            {
                if (createdNew == true)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    // [connectionString의 암호부분을 복호화]
                    var connectionName = "Default";
                    DBConnection.ConnectionStrings.Add(connectionName, AppConfig.GetConnectionString(connectionName));
                    DBConnection.ProvideName.Add(connectionName, AppConfig.GetProvideName(connectionName));

                    if (new LoginForm().ShowDialog() == DialogResult.OK)
                        Application.Run(new MainForm());

                    mtx.ReleaseMutex();
                }
                else
                {
                    ActivateApp(precessName);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error");
                Application.Exit();
            }
        }

        #region "윈도우 창 최소화시 복원 + 프로세스를 최상위로 위치시키기"
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool AllowSetForegroundWindow(int dwProcessId);

        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;

        /// <summary>
        /// 윈도우 창 최소화시 복원 + 프로세스를 최상위로 위치시키기
        /// </summary>
        /// <param name="processName"></param>
        static void ActivateApp(string processName)
        {
            try
            {
                foreach (Process p in Process.GetProcessesByName(processName))
                {
                    ShowWindowAsync(p.MainWindowHandle, SW_SHOWNORMAL);
                    AllowSetForegroundWindow(p.Id);
                    SetForegroundWindow(p.MainWindowHandle);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

    }
}
