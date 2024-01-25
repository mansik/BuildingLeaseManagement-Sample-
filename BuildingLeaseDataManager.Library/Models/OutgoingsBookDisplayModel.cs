using System;

namespace BuildingLeaseDataManager.Library.Models
{
    public class OutgoingsBookDisplayModel
    {
        public DateTime TransactionDate { get; set; }
        public string TransactionDetailsDisplay { get; set; }
        public string Creditor { get; set; }
        public int ExpenseNumber { get; set; }
        public decimal OutgoingsAmount { get; set; }
    }
}
