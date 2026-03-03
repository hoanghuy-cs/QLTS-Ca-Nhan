namespace QLTS.DTO.DTOs
{
    public class ProfitLossItemDTO
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public int TotalBuyQuantity { get; set; }
        public decimal TotalBuyCost { get; set; }
        public int TotalSellQuantity { get; set; }
        public decimal TotalSellRevenue { get; set; }
        public decimal RealizedProfit { get; set; }
    }
}
