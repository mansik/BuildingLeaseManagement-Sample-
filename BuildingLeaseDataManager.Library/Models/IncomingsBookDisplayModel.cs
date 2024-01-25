using System;

namespace BuildingLeaseDataManager.Library.Models
{
    public class IncomingsBookDisplayModel
    {
        public DateTime? TransactionDate { get; set; }
        public string TransactionDetailsDisplay { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal IncomingsAmount { get; set; }
        public decimal LossAmount { get; set; }
        public decimal ReceivableAmount { get; set; }
    }
}
