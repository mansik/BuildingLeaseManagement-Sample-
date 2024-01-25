using BuildingLease.Library;
using BuildingLeaseDataManager.Library.Models;
using BuildingLeaseDataManager.Library.SqlDbAccess;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace BuildingLeaseUI.UI.Modules
{
    public partial class BuildingCodeModule : DevExpress.DXperience.Demos.TutorialControlBase //DevExpress.XtraEditors.XtraUserControl
    {
        private readonly BuildingCodeRepository _buildingCodeRepository = new BuildingCodeRepository();
        private int _id = 0;

        public BuildingCodeModule()
        {
            InitializeComponent();

            //관리자가 아니면 수정 못하게
            if (!AppData.LogOn.GradeTypeID.Equals(1))
            {
                newButton.Enabled = false;
                deleteButton.Enabled = false;
                saveButton.Enabled = false;
            }
        }
        void ClearInput()
        {
            _id = 0;
            buildingNameTextEdit.Text = string.Empty;
            notesTextEdit.Text = string.Empty;
            displaySeqSpinEdit.EditValue = null;
            useFlagCheckEdit.EditValue = null;
        }

        void DisplayInput()
        {
            if (gridView.GetFocusedRow() is BuildingCodeModel buildingCode)
            {
                _id = buildingCode.Id;
                buildingNameTextEdit.EditValue = buildingCode.BuildingName;
                notesTextEdit.EditValue = buildingCode.Notes;
                displaySeqSpinEdit.EditValue = buildingCode.DisplaySeq;
                useFlagCheckEdit.EditValue = buildingCode.UseFlag;
            }
        }

        void LoadDataGridView(int? findId = null)
        {
            gridControl.DataSource = _buildingCodeRepository.GetAll();

            if (findId != null)
            {
                int rowHandle = gridView.LocateByValue("Id", findId);
                if (rowHandle != DevExpress.Data.DataController.OperationInProgress)
                    gridView.FocusedRowHandle = rowHandle;
            }
        }

        private void BuildingCodeModule_Load(object sender, EventArgs e)
        {
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

        private void newButton_Click(object sender, EventArgs e)
        {
            ClearInput(); //_xxxId = 0;를 위해서 필요
            useFlagCheckEdit.EditValue = true;
            buildingNameTextEdit.Focus();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                if (_buildingCodeRepository.IsUsed(_id))
                {
                    XtraMessageBox.Show("이미 사용되었으므로 삭제할 수 없습니다.", "확인");
                    return;
                }

                if (XtraMessageBox.Show($"{buildingNameTextEdit.Text}를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var isDelete = _buildingCodeRepository.Delete(_id);
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
            if (string.IsNullOrEmpty(buildingNameTextEdit.Text))
            {
                XtraMessageBox.Show("빌딩 명칭을 입력해 주세요.", "확인");
                buildingNameTextEdit.Focus();
                return;
            }
            if (displaySeqSpinEdit.Value == 0)
            {
                XtraMessageBox.Show("순서를 0이상 입력해 주세요.", "확인");
                displaySeqSpinEdit.Focus();
                return;
            }
            if (useFlagCheckEdit.EditValue == null)
            {
                XtraMessageBox.Show("사용여부를 선택해 주세요.", "확인");
                useFlagCheckEdit.Focus();
                return;
            }

            var buildingCode = new BuildingCodeModel()
            {
                BuildingName = buildingNameTextEdit.Text,
                Notes = notesTextEdit.Text,
                DisplaySeq = (int)displaySeqSpinEdit.Value,
                UseFlag = useFlagCheckEdit.Checked,
                InsertUserId = AppData.LogOn.UserID,
                UpdateUserId = AppData.LogOn.UserID
            };

            try
            {
                if (_id == 0)
                {
                    if (_buildingCodeRepository.Exists(buildingCode.BuildingName))
                    {
                        XtraMessageBox.Show($"{buildingCode.BuildingName}은 이미 등록되어 있습니다.", "확인");
                        buildingNameTextEdit.Focus();
                        return;
                    }

                    focuseId = _buildingCodeRepository.Insert(buildingCode);
                }
                else
                {
                    buildingCode.Id = _id;
                    _buildingCodeRepository.Update(buildingCode);
                    focuseId = buildingCode.Id;
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
