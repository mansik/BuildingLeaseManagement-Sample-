using BuildingLease.Library;
using BuildingLeaseDataManager.Library.SqlDbAccess;
using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace BuildingLeaseUI.UI.Forms
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
            ImeMode = ImeMode.Hangul; // 추가된 컨트롤에서 한글이 선택되도록 한다.(Hangul = 한글 반각)
            loginInfoLabel.Text = DateTime.UtcNow.AddHours(9).ToString(new CultureInfo("ko-kr"));

#if DEBUG
            userNameTextEdit.Text = "관리자";
            passwordTextEdit.Text = "rhksflwk";
#endif
        }

        private void oKButton_Click(object sender, EventArgs e)
        {
            try
            {
                var userRepository = new UserRepository();
                var user = userRepository.GetByName(userNameTextEdit.Text);
                if (user?.Password != Encrypt.CreateHashBySHA256(passwordTextEdit.Text))
                {
                    loginInfoLabel.ForeColor = Color.Red;
                    loginInfoLabel.Text = "사용자 및 비밀번호를 확인해 주세요.";
                    passwordTextEdit.Text = string.Empty;
                    passwordTextEdit.Focus();
                }
                else
                {
                    AppData.LogOn.UserID = user.Id;
                    AppData.LogOn.UserName = user.UserName;
                    AppData.LogOn.GradeTypeID = user.GradeTypeId;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error");
            }
        }

        private void ResetPasswordHyperlinkLabel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userNameTextEdit.Text))
                return;

            XtraForm resetPasswordForm = new ResetPasswordForm
            {
                Tag = userNameTextEdit.Text,
                Width = this.Width,
                Height = this.Height
            };
            resetPasswordForm.ShowDialog(this);
        }
    }
}
