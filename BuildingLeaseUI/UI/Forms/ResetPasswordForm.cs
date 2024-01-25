using BuildingLease.Library;
using BuildingLeaseDataManager.Library.SqlDbAccess;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;

namespace BuildingLeaseUI.UI.Forms
{
    public partial class ResetPasswordForm : DevExpress.XtraEditors.XtraForm
    {
        //private int _countOfWrongPassword;
        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        private void newPasswordTextEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph && e.Button.Caption == "ShowPassword")
                newPasswordTextEdit.Properties.UseSystemPasswordChar = false;
        }

        private void newPasswordTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph && e.Button.Caption == "ShowPassword")
                newPasswordTextEdit.Properties.UseSystemPasswordChar = true;
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(newPasswordTextEdit.Text))
            {
                XtraMessageBox.Show("신규 비밀번호를 입력해 주세요.", "확인");
                newPasswordTextEdit.Focus();
                return;
            }

            var userRepository = new UserRepository();
            var user = userRepository.GetByName(this.Tag.ToString());

            if (user != null)
            {
                //if (!Encrypt.CreateHashBySHA256(oldPasswordTextEdit.Text).Equals(user.Password))
                //{
                //    // 3번 틀리면 신규 비밀번호로 저장됨.
                //    if (_countOfWrongPassword.Equals(3))
                //    {
                //        XtraMessageBox.Show("설정된 비밀번호로 변경합니다.", "확인");
                //    }
                //    else
                //    {
                //        _countOfWrongPassword += 1;
                //        XtraMessageBox.Show($"이전 비밀번호가 일치하지 않습니다. ({_countOfWrongPassword}/3회 시도)" + Environment.NewLine + "3회 시도 후 신규 비밀번호로 변경합니다.", "확인");
                //        return;
                //    }
                //}

                try
                {
                    user.Password = Encrypt.CreateHashBySHA256(newPasswordTextEdit.Text);
                    userRepository.Update(user);

                    this.Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}