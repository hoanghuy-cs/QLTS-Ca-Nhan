using System.ComponentModel;

namespace QLTS.Shared.Enums
{
    public enum ProfitLossType
    {
        [Description("Lãi")]
        Profit,
        [Description("Lỗ")]
        Loss,
        [Description("Hòa vốn")]
        BreakEven
    }
}
