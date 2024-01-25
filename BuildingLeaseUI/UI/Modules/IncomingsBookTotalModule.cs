using BuildingLeaseDataManager.Library.SqlDbAccess;
using DevExpress.Data;
using DevExpress.Drawing.Printing;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting;
using System;
using System.Drawing;

namespace BuildingLeaseUI.UI.Modules
{
    public partial class IncomingsBookTotalModule : DevExpress.DXperience.Demos.TutorialControlBase //DevExpress.XtraEditors.XtraUserControl
    {
        private readonly IncomingsBookTotalRepository _incomingsBookTotalRepository = new IncomingsBookTotalRepository();
        public IncomingsBookTotalModule()
        {
            InitializeComponent();
        }
        void LoadDataGridView()
        {
            var searchFromDate = Convert.ToDateTime(searchFromDateEdit.EditValue).Date;
            searchFromDate = searchFromDate.AddDays(1 - searchFromDate.Day); //월초

            var searchToDate = Convert.ToDateTime(searchToDateEdit.EditValue).Date;
            searchToDate = searchToDate.AddDays(1 - searchToDate.Day);
            searchToDate = searchToDate.AddMonths(1).AddDays(-1); //월말

            gridControl.DataSource = _incomingsBookTotalRepository.GetsDisplayByFromToDate(searchFromDate, searchToDate);
        }

        /// <summary>
        /// total summary + group summary 표시
        /// </summary>
        void SetSummaryGridView()
        {
            #region gridView 설정
            // true = 그룹 컬럼 보이기 + GroupSummary가 위쪽에 표시 , default = 그룹 컬럼 숨기기 + GroupSummary가 아래쪽에 표시
            // default일 경우ShowGroupedColumns = true을 하면 그룹컬럼 보임
            //gridView.OptionsBehavior.AllowPartialGroups = DevExpress.Utils.DefaultBoolean.True; 
            gridView.OptionsBehavior.AutoExpandAllGroups = true;
            gridView.OptionsView.ShowGroupedColumns = true;
            gridView.OptionsView.ShowGroupPanel = false;
            #endregion

            #region Creating total summary
            // total summary를 위해서 Footer 보이기
            gridView.OptionsView.ShowFooter = true;
            // create total summary
            GridColumn column;
            column = gridView.Columns["AccountName"];
            column.SummaryItem.SummaryType = SummaryItemType.Custom;
            column.SummaryItem.DisplayFormat = "합계";

            column = gridView.Columns["BudgetAmount"];
            column.SummaryItem.SummaryType = SummaryItemType.Sum;
            column.SummaryItem.DisplayFormat = "{0:n0}";

            column = gridView.Columns["IncomingsAmount"];
            column.SummaryItem.SummaryType = SummaryItemType.Sum;
            column.SummaryItem.DisplayFormat = "{0:n0}";

            column = gridView.Columns["LossAmount"];
            column.SummaryItem.SummaryType = SummaryItemType.Sum;
            column.SummaryItem.DisplayFormat = "{0:n0}";

            column = gridView.Columns["DifferenceAmount"];
            column.SummaryItem.SummaryType = SummaryItemType.Sum;
            column.SummaryItem.DisplayFormat = "{0:n0}";
            #endregion

            #region group 및 group summary
            gridView.Columns["AccountHangName"].Group();
            //gridView.Columns["AccountHangName"].GroupInterval =  DevExpress.XtraGrid.ColumnGroupInterval.Value;

            gridView.GroupSummary.Clear();
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "AccountName",
                SummaryType = SummaryItemType.Custom,
                DisplayFormat = " 소계",
                ShowInGroupColumnFooter = gridView.Columns["AccountName"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "BudgetAmount",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["BudgetAmount"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "IncomingsAmount",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["IncomingsAmount"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "LossAmount",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["LossAmount"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "DifferenceAmount",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["DifferenceAmount"]
            });
            //gridView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "BudgetAmount", gridView.Columns["BudgetAmount"]," 합계 {0:n0}"); // 이렇게도 가능
            #endregion
        }

        private void IncomingsBookTotalModule_Load(object sender, EventArgs e)
        {
            // 월초(1일)~월말로 셋팅
            var monthFirstDay = DateTime.Today.AddDays(1 - DateTime.Today.Day);
            var monthLastDay = monthFirstDay.AddMonths(1).AddDays(-1);

            searchFromDateEdit.EditValue = monthFirstDay;
            searchToDateEdit.EditValue = monthLastDay;

            SetSummaryGridView();

            LoadDataGridView();
        }

        private void searchFromDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void searchToDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void printButton_Click(object sender, EventArgs e)
        {
            var fromDate = Convert.ToDateTime(searchFromDateEdit.EditValue).ToString("Y");
            var toDate = Convert.ToDateTime(searchToDateEdit.EditValue).ToString("Y");

            string titleColumn = $"수 입 부  총 괄" + Environment.NewLine;
            string subTitleColumn = $"";
            string dateColumn = $"[{fromDate} ~ {toDate}]";
            string pageColumn = "Pages: [Page # of Pages #]";
            string printedDateColumn = "[Date Printed]"; //$"{DateTime.UtcNow.AddHours(9).ToString("D")}";

            var printLink = new PrintableComponentLink(new PrintingSystem())
            {
                Component = gridView.GridControl,
                Landscape = false,
                PaperKind = DXPaperKind.A4,
                Margins = new DevExpress.Drawing.DXMargins(35, 35, 120, 35)
            };
            var headerFooter = printLink.PageHeaderFooter as PageHeaderFooter;
            headerFooter.Header.Content.Clear();
            headerFooter.Header.Content.AddRange(new string[] { dateColumn, titleColumn, subTitleColumn });
            headerFooter.Header.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
            headerFooter.Header.LineAlignment = BrickAlignment.Far;

            headerFooter.Footer.Content.Clear();
            headerFooter.Footer.Content.AddRange(new string[] { printedDateColumn, "", pageColumn });

            printLink.ShowPreview();
        }

    }
}
