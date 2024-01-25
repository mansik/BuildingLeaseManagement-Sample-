using System;

namespace BuildingLeaseUI.Report
{
    public partial class CashBookReport : DevExpress.XtraReports.UI.XtraReport
    {
        public CashBookReport()
        {
            InitializeComponent();
        }

        public void InitData(DateTime fromDate, DateTime toDate, string inOutgoingsName, string accountName, string lessee, decimal previousMonthAmount, object cashBookData)
        {
            pFromDate.Value = fromDate;
            pToDate.Value = toDate;
            pInOutgoingsName.Value = inOutgoingsName;
            pAccountName.Value = accountName;
            pLessee.Value = lessee;
            pPreviousMonthAmount.Value = previousMonthAmount;
            objectDataSource1.DataSource = cashBookData;
        }

    }
}
