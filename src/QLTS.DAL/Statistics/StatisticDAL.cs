using QLTS.DAL.Helpers;
using QLTS.DTO.DTOs;
using QLTS.Shared.Enums;
using System.Collections.Generic;
using System.Data.SQLite;

namespace QLTS.DAL.Statistics
{
    public class StatisticDAL
    {
        public List<ProfitLossItemDTO> GetAssetProfitLoss(int? assetId = null, ProfitLossType? type = null)
        {
            var list = new List<ProfitLossItemDTO>();

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string whereStatement = "";

                if (assetId.HasValue)
                {
                    whereStatement += " AND t.AssetId = @AssetId";
                }

                string sql = $@"
                    SELECT
                        t.AssetId,
	                    a.Name AS AssetName,
                        SUM(CASE WHEN t.Type = 0 THEN t.Quantity ELSE 0 END) AS TotalBuyQuantity,
                        SUM(CASE WHEN t.Type = 0 THEN t.Quantity * t.UnitPrice + t.Fee ELSE 0 END) AS TotalBuyCost,
                        SUM(CASE WHEN t.Type = 1 THEN t.Quantity ELSE 0 END) AS TotalSellQuantity,
                        SUM(CASE WHEN t.Type = 1 THEN t.Quantity * t.UnitPrice - t.Fee ELSE 0 END) AS TotalSellRevenue,
	                    (
                            SUM(CASE WHEN t.Type = 1 THEN t.Quantity * t.UnitPrice - t.Fee ELSE 0 END)
                        )
                        -
                        (
                            SUM(CASE WHEN t.Type = 1 THEN t.Quantity ELSE 0 END)
                            *
                            (
                                SUM(CASE WHEN t.Type = 0 THEN t.Quantity * t.UnitPrice + t.Fee ELSE 0 END)
                                * 1.0
                                /
                                NULLIF(SUM(CASE WHEN t.Type = 0 THEN t.Quantity ELSE 0 END), 0)
                            )
                        ) AS RealizedProfit
                    FROM Transactions t
                    LEFT JOIN Assets a ON t.AssetId = a.Id
                    WHERE 1 = 1 {whereStatement}
                    GROUP BY AssetId";

                if (type.HasValue)
                {
                    switch (type.Value)
                    {
                        case ProfitLossType.Profit:
                            sql += " HAVING RealizedProfit > 0";
                            break;

                        case ProfitLossType.Loss:
                            sql += " HAVING RealizedProfit < 0";
                            break;

                        case ProfitLossType.BreakEven:
                            sql += " HAVING ABS(RealizedProfit) < 0.0001";
                            break;
                    }
                }

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (assetId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@AssetId", assetId.Value);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProfitLossItemDTO
                            {
                                AssetId = reader.GetInt32(0),
                                AssetName = reader.GetString(1),
                                TotalBuyQuantity = reader.GetInt32(2),
                                TotalBuyCost = reader.GetDecimal(3),
                                TotalSellQuantity = reader.GetInt32(4),
                                TotalSellRevenue = reader.GetDecimal(5),
                                RealizedProfit = reader.GetDecimal(6)
                            });
                        }
                    }
                }
            }

            return list;
        }
    }
}
