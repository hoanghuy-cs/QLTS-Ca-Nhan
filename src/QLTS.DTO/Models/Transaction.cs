using QLTS.Shared.Enums;
using System;

namespace QLTS.DTO.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public TransactionType Type { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Fee { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Note { get; set; }
    }
}
