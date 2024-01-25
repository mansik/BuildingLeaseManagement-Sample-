using BuildingLease.Library;
using BuildingLeaseDataManager.Library.SqlDbAccess;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace BuildingLeaseUI.UI.Modules
{
    public partial class BackupModule : DevExpress.DXperience.Demos.TutorialControlBase //DevExpress.XtraEditors.XtraUserControl
    {
        public BackupModule()
        {
            InitializeComponent();
        }

        private void BackupModule_Load(object sender, System.EventArgs e)
        {
            backupPathLabel.Text = AppConfig.GetAppConfig("DatabaseBackupDirectory");
            fullFileNameLabel.Text = " ";
        }

        private void backupButton_Click(object sender, System.EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog
            {
                SelectedPath = AppConfig.GetAppConfig("DatabaseBackupDirectory")
            };

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var dbBackupRepository = new DBBackupRepository();
                    var fullFileName = dbBackupRepository.DBBackup(folderDialog.SelectedPath);

                    fullFileNameLabel.Text = fullFileName;
                    XtraMessageBox.Show("백업이 완료되었습니다.", "백업");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error");
                }
            }
        }
    }
}
