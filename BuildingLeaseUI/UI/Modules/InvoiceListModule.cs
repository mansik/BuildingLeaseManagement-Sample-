using BuildingLeaseDataManager.Library.SqlDbAccess;
using DevExpress.Data;
using DevExpress.Drawing.Printing;
using DevExpress.Export;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using System;
using System.Drawing;
using System.Linq;

namespace BuildingLeaseUI.UI.Modules
{
    public partial class InvoiceListModule : DevExpress.DXperience.Demos.TutorialControlBase //DevExpress.XtraEditors.XtraUserControl
    {
        private readonly InvoiceRepository _invoiceRepository = new InvoiceRepository();
        public InvoiceListModule()
        {
            InitializeComponent();

            //내보내기 ExportDropDownButton 숨김
            layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        void LoadDataGridView()
        {
            var invoiceDate = Convert.ToDateTime(searchDateEdit.EditValue).Date;
            invoiceDate = invoiceDate.AddDays(1 - invoiceDate.Day);

            gridControl.DataSource = _invoiceRepository.GetAllDisplayByDate(invoiceDate);
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

            #region group 및 group summary
            gridView.Columns["BuildingCodeId"].Group();

            gridView.GroupSummary.Clear();

            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "LesseeId",
                SummaryType = SummaryItemType.Count,
                DisplayFormat = "Count = {0:n0}",
                ShowInGroupColumnFooter = gridView.Columns[2]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "BillIssueDay",
                SummaryType = SummaryItemType.Custom,
                DisplayFormat = " 소계",
                ShowInGroupColumnFooter = gridView.Columns["BillIssueDay"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "MonthlyRent",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["MonthlyRent"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "MonthlyRentVAT",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["MonthlyRentVAT"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "gridColumn8",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["gridColumn8"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "MaintenanceFee",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["MaintenanceFee"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "MaintenanceFeeVAT",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["MaintenanceFeeVAT"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "gridColumn11",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["gridColumn11"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "ElectricBill",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["ElectricBill"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "ElectricBillVAT",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["ElectricBillVAT"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "gridColumn14",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["gridColumn14"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "WaterBill",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["WaterBill"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "RoadOccupancyFee",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["RoadOccupancyFee"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "RoadOccupancyFeeVAT",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["RoadOccupancyFeeVAT"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "gridColumn18",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["gridColumn18"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "TrafficCausingCharge",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["TrafficCausingCharge"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "TrafficCausingChargeVAT",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["TrafficCausingChargeVAT"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "gridColumn21",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["gridColumn21"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "SubAmountSum",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["SubAmountSum"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "SubVATSum",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["SubVATSum"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "SubSumTotal",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["SubSumTotal"]
            });
            gridView.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "gridColumn23",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "{0:n0}",
                ShowInGroupColumnFooter = gridView.Columns["gridColumn23"]
            });
            //gridView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "BudgetAmount", gridView.Columns["BudgetAmount"]," 합계 {0:n0}"); // 이렇게도 가능
            #endregion
        }

        private void InvoiceListModule_Load(object sender, EventArgs e)
        {
            searchDateEdit.EditValue = DateTime.Today.AddDays(1 - DateTime.Today.Day);

            #region gridView의 LookUpEdit 셋팅             
            // 디자인 모드 => gridView => column => ColumnEdit에서 생성함
            var buildingCodeRepository = new BuildingCodeRepository();
            var buildingCodes = buildingCodeRepository.GetAll().Select(x => new { x.Id, x.BuildingName }).ToList();
            buildingNameRepositoryItemLookUpEdit.DataSource = buildingCodes;
            buildingNameRepositoryItemLookUpEdit.DisplayMember = "BuildingName";
            buildingNameRepositoryItemLookUpEdit.ValueMember = "Id";
            buildingNameRepositoryItemLookUpEdit.ForceInitialize();
            buildingNameRepositoryItemLookUpEdit.PopulateColumns();
            buildingNameRepositoryItemLookUpEdit.Columns["Id"].Visible = false;

            var buildingRoomCodeRepository = new BuildingRoomCodeRepository();
            roomRepositoryItemLookUpEdit.DataSource = buildingRoomCodeRepository.GetAll().Select(x => new { x.Id, x.Room }).ToList();
            roomRepositoryItemLookUpEdit.DisplayMember = "Room";
            roomRepositoryItemLookUpEdit.ValueMember = "Id";
            roomRepositoryItemLookUpEdit.ForceInitialize();
            roomRepositoryItemLookUpEdit.PopulateColumns();
            roomRepositoryItemLookUpEdit.Columns["Id"].Visible = false;

            var lesseeRepository = new LesseeRepository();
            lesseeRepositoryItemLookUpEdit.DataSource = lesseeRepository.GetAll().Select(x => new { x.Id, x.Lessee, x.BRN, x.Owner, x.BillIssueDay }).ToList();
            lesseeRepositoryItemLookUpEdit.DisplayMember = "Lessee";
            lesseeRepositoryItemLookUpEdit.ValueMember = "Id";
            lesseeRepositoryItemLookUpEdit.ForceInitialize();
            lesseeRepositoryItemLookUpEdit.PopulateColumns();
            lesseeRepositoryItemLookUpEdit.Columns["Id"].Visible = false;
            lesseeRepositoryItemLookUpEdit.Columns["BRN"].Visible = false;
            lesseeRepositoryItemLookUpEdit.Columns["Owner"].Visible = false;
            lesseeRepositoryItemLookUpEdit.Columns["BillIssueDay"].Visible = false;

            BRNRepositoryItemLookUpEdit.DataSource = lesseeRepository.GetAll().Select(x => new { x.Id, x.BRN }).ToList();
            BRNRepositoryItemLookUpEdit.DisplayMember = "BRN";
            BRNRepositoryItemLookUpEdit.ValueMember = "Id";
            BRNRepositoryItemLookUpEdit.ForceInitialize();
            BRNRepositoryItemLookUpEdit.PopulateColumns();
            BRNRepositoryItemLookUpEdit.Columns["Id"].Visible = false;

            ownerRepositoryItemLookUpEdit.DataSource = lesseeRepository.GetAll().Select(x => new { x.Id, x.Owner }).ToList();
            ownerRepositoryItemLookUpEdit.DisplayMember = "Owner";
            ownerRepositoryItemLookUpEdit.ValueMember = "Id";
            ownerRepositoryItemLookUpEdit.ForceInitialize();
            ownerRepositoryItemLookUpEdit.PopulateColumns();
            ownerRepositoryItemLookUpEdit.Columns["Id"].Visible = false;
            #endregion

            OptionGridBand.Visible = false; //isEdited, Id

            SetSummaryGridView();

            LoadDataGridView();
        }

        private void searchDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void buildingCodeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            string pageColumn = "Pages: [Page # of Pages #]";
            string printedDateColumn = "[Date Printed]"; //$"{DateTime.UtcNow.AddHours(9).ToString("D")}";            

            var printLink = new PrintableComponentLink(new PrintingSystem())
            {
                Component = gridView.GridControl,
                Landscape = true,
                PaperKind = DXPaperKind.A3,
                Margins = new DevExpress.Drawing.DXMargins(35, 35, 80, 35)
            };

            var headerFooter = printLink.PageHeaderFooter as PageHeaderFooter;
            headerFooter.Footer.Content.Clear();
            headerFooter.Footer.Content.AddRange(new string[] { printedDateColumn, "", pageColumn });

            // 결재란 + 타이틀           
            printLink.CreateReportHeaderArea += PrintLink_CreateReportHeaderArea;
            //printLink.CreateReportFooterArea += PrintLink_CreateReportFooterArea;

            // 글자가 잘리는 것을 방지
            gridView.OptionsPrint.AutoWidth = false;
            //gridView.BestFitColumns();

            printLink.ShowPreview();
        }

        private void PrintLink_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {
            // 결재란            
            e.Graph.StringFormat = new BrickStringFormat(DevExpress.Drawing.DXStringAlignment.Center);
            e.Graph.Font = new Font("맑은 고딕", 10, FontStyle.Regular);
            // 타이틀란
            float w = 80;
            float x = e.Graph.ClientPageSize.Width - 25 - w - w - 2 * w; //25 - w - w - 2 * w = 각 칸의 width
            e.Graph.DrawString("  결 재", Color.Black, new RectangleF(x, 0, 25, 70), BorderSide.All);
            e.Graph.DrawString("담당", Color.Black, new RectangleF(x + 25, 0, w, 20), BorderSide.All);
            e.Graph.DrawString("소장", Color.Black, new RectangleF(x + 25 + w, 0, w, 20), BorderSide.All);
            e.Graph.DrawString("대표", Color.Black, new RectangleF(x + 25 + w + w, 0, 2 * w, 20), BorderSide.All);
            // 사인란
            e.Graph.DrawString("", Color.Black, new RectangleF(x + 25, 20, w, 50), BorderSide.All);
            e.Graph.DrawString("", Color.Black, new RectangleF(x + 25 + w, 20, w, 50), BorderSide.All);
            e.Graph.DrawString("", Color.Black, new RectangleF(x + 25 + w + w, 20, 2 * w, 50), BorderSide.All);

            // 타이틀 및 서브타이틀
            var searchDate = Convert.ToDateTime(searchDateEdit.EditValue).ToString("Y");
            string title = $"{searchDate} 종합관리비 청구서";
            e.Graph.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
            SizeF sz = e.Graph.MeasureString(title); // Measure the string.
            e.Graph.DrawString(title, Color.Black, new RectangleF(new PointF(0, 0), sz), BorderSide.None);

            string subTitle = $"[전체]";
            e.Graph.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
            sz = e.Graph.MeasureString(subTitle); // Measure the string.
            e.Graph.DrawString(subTitle, Color.Black, new RectangleF(new PointF(0, 50), sz), BorderSide.None);

            // 빈칸
            e.Graph.DrawEmptyBrick(new RectangleF(0, 70, e.Graph.ClientPageSize.Width, 10));
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            var searchDate = Convert.ToDateTime(searchDateEdit.EditValue).ToString("Y");
            string titleColumn = $"{searchDate} 종합관리비 청구서";

            var printLink = new PrintableComponentLink(new PrintingSystem())
            {
                Component = gridView.GridControl,
                Landscape = true,
                PaperKind = DXPaperKind.A3,
                Margins = new DevExpress.Drawing.DXMargins(35, 35, 80, 35)
            };

            var headerFooter = printLink.PageHeaderFooter as PageHeaderFooter;
            headerFooter.Header.Content.Clear();
            headerFooter.Header.Content.Add(titleColumn);
            headerFooter.Header.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
            headerFooter.Header.LineAlignment = BrickAlignment.Far;

            // 글자가 잘리는 것을 방지
            gridView.OptionsPrint.AutoWidth = false;
            //gridView.BestFitColumns();

            printLink.ShowPreview();
        }

        #region ExportTo
        protected override void ExportToCore(String filename, string ext)
        {
            if (ext == "rtf") gridView.ExportToRtf(filename);
            if (ext == "docx") gridView.ExportToDocx(filename);
            if (ext == "pdf") gridView.ExportToPdf(filename);
            if (ext == "mht") gridView.ExportToMht(filename);
            if (ext == "html") gridView.ExportToHtml(filename);
            if (ext == "txt") gridView.ExportToText(filename);
            if (ext == "xls") ExportToXlsInternal(filename);
            if (ext == "xlsx") ExportToXlsxInternal(filename);
        }
        void ExportToXlsxInternal(string filename)
        {
            var options = new XlsxExportOptionsEx
            {
                UnboundExpressionExportMode = UnboundExpressionExportMode.AsValue
            };
            gridView.ExportToXlsx(filename, options);
        }
        void ExportToXlsInternal(string filename)
        {
            var options = new XlsExportOptionsEx
            {
                UnboundExpressionExportMode = UnboundExpressionExportMode.AsValue
            };
            gridView.ExportToXls(filename, options);
        }

        private void exporttoXlsxBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ext = "xlsx";
            var filter = "XLSX document (*.xlsx)|*.xlsx";

            ExportTo(ext, filter);
        }

        private void exporttoXlsBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ext = "xls";
            var filter = "XLS document (*.xls)|*.xls";

            ExportTo(ext, filter);
        }
        #endregion
    }
}
