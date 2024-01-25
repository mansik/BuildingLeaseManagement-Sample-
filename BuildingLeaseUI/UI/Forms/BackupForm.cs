using BuildingLease.Library;
using BuildingLeaseDataManager.Library.SqlDbAccess;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace BuildingLeaseUI.UI.Forms
{
    public partial class BackupForm : DevExpress.XtraEditors.XtraForm
    {
        public BackupForm()
        {
            InitializeComponent();
        }

        private void BackupForm_Load(object sender, EventArgs e)
        {
            backupPathLabel.Text = AppConfig.GetAppConfig("DatabaseBackupDirectory");
            fullFileNameLabel.Text = " ";
        }

        private void backupButton_Click(object sender, EventArgs e)
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
                    this.Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}