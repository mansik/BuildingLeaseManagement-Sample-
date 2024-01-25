using BuildingLeaseUI.Report;
using System;

namespace BuildingLeaseUI.UI.Forms
{
    public partial class PrintForm : DevExpress.XtraEditors.XtraForm
    {
        public PrintForm()
        {
            InitializeComponent();
        }

        public void CashBookPrint(DateTime fromDate, DateTime toDate, string inOutgoingsName, string accountName, string lessee, decimal previousMonthAmount, object cashBookData)
        {
            var report = new CashBookReport();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
                p.Visible = false;

            report.InitData(fromDate, toDate, inOutgoingsName, accountName, lessee, previousMonthAmount, cashBookData);
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }

        public void MaintenanceFeeDatailsPrint(string accountNumber, string bankName, string officeTel, string officeEmail, object maintenanceFeeDetailsData, object maintenanceFeeDetailsSetting)
        {
            var report = new MaintenanceFeeDetailsReport();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
                p.Visible = false;

            report.InitData(accountNumber, bankName, officeTel, officeEmail, maintenanceFeeDetailsData, maintenanceFeeDetailsSetting);
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
    }
}