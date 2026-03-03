using QLTS.Shared.Enums;

namespace QLTS.BLL.Statistics
{
    public class ProfitLossFilter
    {
        public int? AssetId { get; set; }
        public ProfitLossType? Type { get; set; }
    }
}
