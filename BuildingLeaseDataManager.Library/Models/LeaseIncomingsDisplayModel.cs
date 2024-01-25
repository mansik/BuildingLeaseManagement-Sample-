using System;

namespace BuildingLeaseDataManager.Library.Models
{
    public class LeaseIncomingsDisplayModel
    {
        public DateTime? InvoiceDate { get; set; }
        public int BuildingCodeId { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal IncomingsAmount { get; set; }
        public decimal LossAmount { get; set; }
    }
}
