using System.ComponentModel;

namespace QLTS.Shared.Enums
{
    public enum TransactionType
    {
        [Description("Mua")]
        Buy,
        [Description("Bán")]
        Sell
    }
}
