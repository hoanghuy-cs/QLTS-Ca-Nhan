using QLTS.DTO.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace QLTS.BLL.Statistics
{
    public class ProfitLossDetail
    {
        public List<ProfitLossItemDTO> Items { get; set; }
        public decimal TotalProfit => Items.Sum(i => i.RealizedProfit);
        public decimal TotalBuyCost => Items.Sum(i => i.TotalBuyCost);
        public decimal TotalSellRevenue => Items.Sum(i => i.TotalSellRevenue);
    }
}
