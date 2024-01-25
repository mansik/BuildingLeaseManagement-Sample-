using BuildingLease.Library;
using BuildingLeaseDataManager.Library.Models;
using BuildingLeaseDataManager.Library.SqlDbAccess;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace BuildingLeaseUI.UI.Modules
{
    public partial class LesseeModule : DevExpress.DXperience.Demos.TutorialControlBase //DevExpress.XtraEditors.XtraUserControl
    {
        private readonly LesseeRepository _lesseeRepository = new LesseeRepository();
        private int _id = 0;

        public LesseeModule()
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
            lesseeTextEdit.Text = string.Empty;
            ownerTextEdit.Text = string.Empty;
            rrnTextEdit.Text = string.Empty;
            brnTextEdit.Text = string.Empty;
            contactTextEdit.Text = string.Empty;
            underContractFlagCheckEdit.EditValue = null;
            billIssueDayTextEdit.Text = string.Empty;
            notesTextEdit.Text = string.Empty;
        }

        void DisplayInput()
        {
            if (gridView.GetFocusedRow() is LesseeModel lessee)
            {
                _id = lessee.Id;
                lesseeTextEdit.EditValue = lessee.Lessee;
                ownerTextEdit.EditValue = lessee.Owner;
                rrnTextEdit.EditValue = lessee.RRN;
                brnTextEdit.EditValue = lessee.BRN;
                contactTextEdit.EditValue = lessee.Contact;
                underContractFlagCheckEdit.EditValue = lessee.UnderContractFlag;
                billIssueDayTextEdit.EditValue = lessee.BillIssueDay;
                notesTextEdit.EditValue = lessee.Notes;
            }
        }

        void LoadDataGridView(int? findId = null)
        {
            gridControl.DataSource = _lesseeRepository.GetAll();

            if (findId != null)
            {
                int rowHandle = gridView.LocateByValue("Id", findId);
                if (rowHandle != DevExpress.Data.DataController.OperationInProgress)
                    gridView.FocusedRowHandle = rowHandle;
            }
        }

        private void LesseeModule_Load(object sender, EventArgs e)
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
            underContractFlagCheckEdit.EditValue = true;
            lesseeTextEdit.Focus();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (_id == 1)
            {
                XtraMessageBox.Show("이 코드는 기본코드로 삭제가 불가능합니다.", "확인");
                return;
            }

            if (_id != 0)
            {
                if (_lesseeRepository.IsUsed(_id))
                {
                    XtraMessageBox.Show("이미 사용되었으므로 삭제할 수 없습니다.", "확인");
                    return;
                }

                if (XtraMessageBox.Show($"{lesseeTextEdit.Text}를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var isDelete = _lesseeRepository.Delete(_id);
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
                XtraMessageBox.Show("이 코드는 기본코드로 수정이 불가능합니다.", "확인");
                return;
            }

            if (string.IsNullOrEmpty(lesseeTextEdit.Text))
            {
                XtraMessageBox.Show("임차인을 입력해 주세요.", "확인");
                lesseeTextEdit.Focus();
                return;
            }

            if (underContractFlagCheckEdit.EditValue == null)
            {
                XtraMessageBox.Show("계약여부를 선택해 주세요.", "확인");
                underContractFlagCheckEdit.Focus();
                return;
            }

            var lessee = new LesseeModel()
            {
                Lessee = lesseeTextEdit.Text,
                Owner = ownerTextEdit.Text,
                RRN = rrnTextEdit.Text,
                BRN = brnTextEdit.Text,
                Contact = contactTextEdit.Text,
                UnderContractFlag = underContractFlagCheckEdit.Checked,
                BillIssueDay = billIssueDayTextEdit.Text,
                Notes = notesTextEdit.Text,
                InsertUserId = AppData.LogOn.UserID,
                UpdateUserId = AppData.LogOn.UserID
            };

            try
            {
                if (_id == 0)
                {

                    if (_lesseeRepository.Exists(lessee.Lessee))
                    {
                        XtraMessageBox.Show($"{lessee.Lessee}은 이미 등록되어 있습니다.", "확인");
                        lesseeTextEdit.Focus();
                        return;
                    }

                    focuseId = _lesseeRepository.Insert(lessee);
                }
                else
                {
                    lessee.Id = _id;
                    _lesseeRepository.Update(lessee);
                    focuseId = lessee.Id;
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
