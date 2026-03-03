using QLTS.DAL.Statistics;

namespace QLTS.BLL.Statistics
{
    public class StatisticBLL
    {
        private readonly StatisticDAL _statisticDAL = new StatisticDAL();

        public ProfitLossDetail GetAssetProfitLoss(ProfitLossFilter filter = null)
        {
            if (filter == null)
            {
                filter = new ProfitLossFilter();
            }

            var items = _statisticDAL.GetAssetProfitLoss(
                assetId: filter.AssetId,
                type: filter.Type);

            return new ProfitLossDetail { Items = items };
        }
    }
}
