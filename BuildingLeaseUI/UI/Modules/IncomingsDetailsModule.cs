using BuildingLeaseDataManager.Library.SqlDbAccess;
using DevExpress.Drawing.Printing;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BuildingLeaseUI.UI.Modules
{
    public partial class IncomingsDetailsModule : DevExpress.DXperience.Demos.TutorialControlBase //DevExpress.XtraEditors.XtraUserControl
    {
        private readonly IncomingsDetailsRepository _incomingsDetailsRepository = new IncomingsDetailsRepository();
        public IncomingsDetailsModule()
        {
            InitializeComponent();
        }
        void LoadDataGridView()
        {
            var searchDate = Convert.ToDateTime(searchDateEdit.EditValue).Date;
            searchDate = searchDate.AddDays(1 - searchDate.Day); //월초

            var totalCalcByYearFlag = totalCalcByYearToggleSwitch.IsOn ? 1 : 0;
            var incomingsDetails = _incomingsDetailsRepository.GetsDisplayByFromToDate(searchDate, totalCalcByYearFlag);

            if (buildingCodeLookUpEdit.EditValue?.ToString() != "9999") //전체
                incomingsDetails = incomingsDetails.Where(x => x.BuildingCodeId == Convert.ToInt32(buildingCodeLookUpEdit.EditValue)).ToList();

            gridControl.DataSource = incomingsDetails;
        }

        private void IncomingsDetailsModule_Load(object sender, System.EventArgs e)
        {
            searchDateEdit.EditValue = DateTime.Today.AddDays(1 - DateTime.Today.Day);

            var buildingCodeRepository = new BuildingCodeRepository();
            var buildingCodes = buildingCodeRepository.GetAll().Select(x => new { x.Id, x.BuildingName }).ToList();
            var buildingCodesAll = new List<object>()
            {
                new { Id = 9999, BuildingName = "전체" }
            };
            buildingCodesAll.AddRange(buildingCodes);
            buildingCodeLookUpEdit.Properties.DataSource = buildingCodesAll;
            buildingCodeLookUpEdit.Properties.DisplayMember = "BuildingName";
            buildingCodeLookUpEdit.Properties.ValueMember = "Id";
            buildingCodeLookUpEdit.Properties.ForceInitialize();
            buildingCodeLookUpEdit.Properties.PopulateColumns();
            buildingCodeLookUpEdit.Properties.Columns["Id"].Visible = false;
            if (buildingCodes.Count() > 0)
            {
                buildingCodeLookUpEdit.ItemIndex = 0;
            }

            #region gridView의 LookUpEdit 셋팅             
            // 디자인 모드 => gridView => column => ColumnEdit에서 생성함
            buildingNameRepositoryItemLookUpEdit.DataSource = buildingCodes;
            buildingNameRepositoryItemLookUpEdit.DisplayMember = "BuildingName";
            buildingNameRepositoryItemLookUpEdit.ValueMember = "Id";
            buildingNameRepositoryItemLookUpEdit.ForceInitialize();
            buildingNameRepositoryItemLookUpEdit.PopulateColumns();
            buildingNameRepositoryItemLookUpEdit.Columns["Id"].Visible = false;

            var lesseeRepository = new LesseeRepository();
            lesseeRepositoryItemLookUpEdit.DataSource = lesseeRepository.GetAll().Select(x => new { x.Id, x.Lessee }).ToList();
            lesseeRepositoryItemLookUpEdit.DisplayMember = "Lessee";
            lesseeRepositoryItemLookUpEdit.ValueMember = "Id";
            lesseeRepositoryItemLookUpEdit.ForceInitialize();
            lesseeRepositoryItemLookUpEdit.PopulateColumns();
            lesseeRepositoryItemLookUpEdit.Columns["Id"].Visible = false;
            #endregion

            LoadDataGridView();
        }

        private void searchDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void buildingCodeLookUpEdit_EditValueChanged(object sender, System.EventArgs e)
        {
            LoadDataGridView();
        }

        private void totalCalcByYearToggleSwitch_Toggled(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void searchButton_Click(object sender, System.EventArgs e)
        {
            LoadDataGridView();
        }

        private void printButton_Click(object sender, System.EventArgs e)
        {
            string pageColumn = "Pages: [Page # of Pages #]";
            string printedDateColumn = "[Date Printed]"; //$"{DateTime.UtcNow.AddHours(9).ToString("D")}";

            var printLink = new PrintableComponentLink(new PrintingSystem())
            {
                Component = gridView.GridControl,
                Landscape = false,
                PaperKind = DXPaperKind.A3,
                Margins = new DevExpress.Drawing.DXMargins(35, 35, 80, 35)
            };
            var headerFooter = printLink.PageHeaderFooter as PageHeaderFooter;
            headerFooter.Footer.Content.Clear();
            headerFooter.Footer.Content.AddRange(new string[] { printedDateColumn, "", pageColumn });

            // 결재란            
            printLink.CreateReportHeaderArea += PrintLink_CreateReportHeaderArea;
            //printLink.CreateReportFooterArea += PrintLink_CreateReportFooterArea;

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

            // 타이틀
            var searchDate = Convert.ToDateTime(searchDateEdit.EditValue).ToString("Y");
            string title = $"{searchDate} 수입 상세 현황";
            e.Graph.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
            SizeF sz = e.Graph.MeasureString(title); // Measure the string.
            e.Graph.DrawString(title, Color.Black, new RectangleF(new PointF(0, 0), sz), BorderSide.None);

            //빈칸
            e.Graph.DrawEmptyBrick(new RectangleF(0, 70, e.Graph.ClientPageSize.Width, 10));
        }
    }
}
