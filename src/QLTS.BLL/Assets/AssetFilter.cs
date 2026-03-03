using QLTS.Shared.Enums;

namespace QLTS.BLL.Assets
{
    public class AssetFilter
    {
        public string Keyword { get; set; }
        public AssetQuantityType? QuantityType { get; set; }
    }
}
