using QLTS.Shared.Enums;
using System;

namespace QLTS.BLL.Transactions
{
    public class TransactionFilter
    {
        public int? AssetId { get; set; }
        public TransactionType? Type { get; set; }
        public DateTime? TransactionDateFrom { get; set; }
        public DateTime? TransactionDateTo { get; set; }
    }
}
