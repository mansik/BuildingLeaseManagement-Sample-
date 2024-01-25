using BuildingLease.Library;
using BuildingLeaseDataManager.Library.Models;
using BuildingLeaseDataManager.Library.SqlDbAccess;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BuildingLeaseUI.UI.Modules
{
    public partial class UserModule : DevExpress.DXperience.Demos.TutorialControlBase //DevExpress.XtraEditors.XtraUserControl
    {
        private readonly UserRepository _userRepository = new UserRepository();
        private int _id = 0;

        public UserModule()
        {
            InitializeComponent();

            //관리자가 아니면 수정 못하게
            if (!AppData.LogOn.GradeTypeID.Equals(1))
            {
                newButton.Enabled = false;
                deleteButton.Enabled = false;
                saveButton.Enabled = false;
            }

            //디자인 모드에서 작업
            //
            // gradeTypeIdlookUpEdit
            //                                  
            //gradeTypeIdlookUpEdit.Properties.NullText = "";            
            //gradeTypeIdlookUpEdit.Properties.ShowHeader = false;

            // 
            // gradeTypeIdRepositoryItemLookUpEdit
            //             
            //gradeTypeIdRepositoryItemLookUpEdit.NullText = "";

            //gridColumn3.ColumnEdit = this.gradeTypeIdRepositoryItemLookUpEdit;

            //gridView.OptionsBehavior.Editable = false;
            //gridView.OptionsFind.AlwaysVisible = true;            
        }

        void ClearInput()
        {
            _id = 0;
            userNameTextEdit.Text = string.Empty;
            passwordTextEdit.Text = string.Empty;
            gradeTypeIdLookUpEdit.EditValue = null;
            useFlagCheckEdit.EditValue = null;
            passwordTextEdit.Tag = string.Empty;
        }
        void DisplayInput()
        {
            if (gridView.GetFocusedRow() is UserModel user)
            {
                _id = user.Id;
                userNameTextEdit.EditValue = user.UserName;
                passwordTextEdit.EditValue = user.Password;
                gradeTypeIdLookUpEdit.EditValue = user.GradeTypeId;
                useFlagCheckEdit.EditValue = user.UseFlag;
            }
        }

        void LoadDataGridView(int? findId = null)
        {
            gridControl.DataSource = _userRepository.GetAll();

            if (findId != null)
            {
                int rowHandle = gridView.LocateByValue("Id", findId);
                if (rowHandle != DevExpress.Data.DataController.OperationInProgress)
                    gridView.FocusedRowHandle = rowHandle;
            }
        }

        private void UsersModule_Load(object sender, EventArgs e)
        {
            var gradeTypeRepository = new GradeTypeRepository();
            var gradeTypes = gradeTypeRepository.GetAll().Select(x => new { x.Id, x.GradeTypeName }).ToList();
            gradeTypeIdLookUpEdit.Properties.DataSource = gradeTypes;
            gradeTypeIdLookUpEdit.Properties.DisplayMember = "GradeTypeName";
            gradeTypeIdLookUpEdit.Properties.ValueMember = "Id";
            gradeTypeIdLookUpEdit.Properties.ForceInitialize();
            gradeTypeIdLookUpEdit.Properties.PopulateColumns();
            gradeTypeIdLookUpEdit.Properties.Columns["Id"].Visible = false;
            gradeTypeIdLookUpEdit.Properties.DropDownRows = gradeTypes.Count();

            // 디자인 모드 => gridView => column => 등급 컬럼의 ColumnEdit에서 생성함
            gradeTypeIdRepositoryItemLookUpEdit.DataSource = gradeTypes;
            gradeTypeIdRepositoryItemLookUpEdit.DisplayMember = "GradeTypeName";
            gradeTypeIdRepositoryItemLookUpEdit.ValueMember = "Id";
            gradeTypeIdRepositoryItemLookUpEdit.ForceInitialize();
            gradeTypeIdRepositoryItemLookUpEdit.PopulateColumns();
            gradeTypeIdRepositoryItemLookUpEdit.Columns["Id"].Visible = false;
            gradeTypeIdRepositoryItemLookUpEdit.DropDownRows = gradeTypes.Count();

            ClearInput();
            LoadDataGridView();
            newButton.PerformClick();
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
                DisplayInput();
        }

        private void gridView_ColumnFilterChanged(object sender, EventArgs e)
        {
            DisplayInput();
        }

        private void gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DisplayInput();
        }

        private void passwordTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            passwordTextEdit.Tag = "Edited";
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            ClearInput(); //_userId = 0;를 위해서 필요
            //gradeTypeIdlookUpEdit.EditValue = 2; // 사용자
            useFlagCheckEdit.EditValue = true;
            userNameTextEdit.Focus();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (_id == 1)
            {
                XtraMessageBox.Show("이 사용자는 삭제가 불가능합니다.", "확인");
                return;
            }

            if (_id != 0)
            {
                if (XtraMessageBox.Show($"{userNameTextEdit.Text}를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var isDelete = _userRepository.Delete(_id);
                    if (isDelete)
                    {
                        ClearInput(); //_userId = 0;를 위해서 필요
                        LoadDataGridView();
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int? focuseId;

            if (_id == 1)
            {
                XtraMessageBox.Show("이 사용자는 수정이 불가능합니다.", "확인");
                return;
            }

            if (string.IsNullOrEmpty(userNameTextEdit.Text))
            {
                XtraMessageBox.Show("이름을 입력해 주세요.", "확인");
                userNameTextEdit.Focus();
                return;
            }
            if (string.IsNullOrEmpty(passwordTextEdit.Text))
            {
                XtraMessageBox.Show("비밀번호를 입력해 주세요.", "확인");
                passwordTextEdit.Focus();
                return;
            }
            if (gradeTypeIdLookUpEdit.EditValue == null)
            {
                gradeTypeIdLookUpEdit.ShowPopup();
                return;
            }
            if (useFlagCheckEdit.EditValue == null)
            {
                XtraMessageBox.Show("사용여부를 선택해 주세요.", "확인");
                useFlagCheckEdit.Focus();
                return;
            }

            var password = passwordTextEdit.Text;
            if (passwordTextEdit.Tag.Equals("Edited"))
                password = Encrypt.CreateHashBySHA256(passwordTextEdit.EditValue.ToString());

            var user = new UserModel()
            {
                UserName = userNameTextEdit.Text,
                Password = password,
                GradeTypeId = int.Parse(gradeTypeIdLookUpEdit.EditValue.ToString()),
                UseFlag = useFlagCheckEdit.Checked,
                InsertUserId = AppData.LogOn.UserID,
                UpdateUserId = AppData.LogOn.UserID
            };

            try
            {
                if (_id == 0)
                {
                    if (_userRepository.Exists(user.UserName))
                    {
                        XtraMessageBox.Show($"{user.UserName}은 이미 등록되어 있습니다.", "확인");
                        userNameTextEdit.Focus();
                        return;
                    }

                    focuseId = _userRepository.Insert(user);
                }
                else
                {
                    user.Id = _id;
                    _userRepository.Update(user);
                    focuseId = user.Id;
                }
                ClearInput(); //_userId = 0;를 위해서 필요
                LoadDataGridView(focuseId);
                newButton.PerformClick();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
