using DevExpress.Data.Utils;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace BuildingLeaseUI.Utils
{
    class MainFormHelper
    {
        public static string GetFileName(string extension, string filter)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = filter;
                saveFileDialog.FileName = Application.ProductName;
                saveFileDialog.DefaultExt = extension;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
            }

            return string.Empty;
        }

        public static void OpenExportedFile(string fileName)
        {
            //if (XtraMessageBox.Show(Resources.OpenFileQuestion, Resources.ExportCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //if (XtraMessageBox.Show("Do you want to open this file?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            if (XtraMessageBox.Show("이 파일을 열겠습니까?", "내보내기", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SafeProcess.Start(fileName);
            }
        }

        public static void ShowExportErrorMessage(Exception e)
        {
            XtraMessageBox.Show(e.Message, "내보내기", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
