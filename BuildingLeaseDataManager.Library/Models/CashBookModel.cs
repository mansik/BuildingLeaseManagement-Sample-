using System;

namespace BuildingLeaseDataManager.Library.Models
{
    public class CashBookModel
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDetails { get; set; }
        public int? BankBookCodeId { get; set; }
        public int? LesseeId { get; set; }
        public int? AccountCodeId { get; set; }
        public string Creditor { get; set; }
        public int ExpenseNumber { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal WithdrawalAmount { get; set; }
        public decimal LossAmount { get; set; }
        public string Notes { get; set; }
        public int InOutgoings { get; set; }
        // gridView에서 별도의 코딩없이 체크박스가 나타나도록 하기 위해서 bool형 사용함.
        public bool DelFlag { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
