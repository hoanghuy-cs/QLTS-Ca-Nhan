using QLTS.DAL.Helpers;
using QLTS.DTO.DTOs;
using QLTS.DTO.Models;
using QLTS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace QLTS.DAL.Assets
{
    public class AssetDAL
    {
        public List<AssetItemDTO> GetAssets(
            string keyword = null,
            AssetQuantityType? quantityType = null)
        {
            var list = new List<AssetItemDTO>();

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string whereStatement = "";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    whereStatement += $" AND a.Name LIKE @Keyword COLLATE NOCASE";
                }

                string sql = $@"
                    SELECT
                        a.Id,
                        a.UnitId,
                        u.Name AS UnitName,
                        a.Name,
                        IFNULL(SUM(CASE WHEN t.Type = 0 THEN t.Quantity ELSE -t.Quantity END), 0) AS Quantity,
                        a.Note
                    FROM Assets a
                        LEFT JOIN Units u ON a.UnitId = u.Id
                        LEFT JOIN Transactions t ON a.Id = t.AssetId
                    WHERE 1 = 1 {whereStatement}
                    GROUP BY a.Id, a.UnitId, UnitName, a.Name, a.Note";

                if (quantityType.HasValue)
                {
                    switch (quantityType.Value)
                    {
                        case AssetQuantityType.HasQuantity:
                            sql += " HAVING Quantity > 0";
                            break;

                        case AssetQuantityType.NoQuantity:
                            sql += " HAVING Quantity <= 0";
                            break;
                    }
                }

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new AssetItemDTO
                            {
                                Id = reader.GetInt32(0),
                                UnitId = reader.GetInt32(1),
                                UnitName = reader.GetString(2),
                                Name = reader.GetString(3),
                                Quantity = reader.GetInt32(4),
                                Note = reader.IsDBNull(5) ? null : reader.GetString(5)
                            });
                        }
                    }
                }
            }

            return list;
        }

        public int Create(Asset asset)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO Assets(Name, UnitId, Note)
                    VALUES(@Name, @UnitId, @Note);

                    SELECT last_insert_rowid();
                ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", asset.Name);
                    cmd.Parameters.AddWithValue("@UnitId", asset.UnitId);
                    cmd.Parameters.AddWithValue("@Note", asset.Note);

                    object result = cmd.ExecuteScalar();

                    return Convert.ToInt32(result);
                }
            }
        }

        public int Update(Asset asset)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE Assets
                    SET Name = @Name,
                        UnitId = @UnitId,
                        Note = @Note
                    WHERE Id = @Id
                ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", asset.Name);
                    cmd.Parameters.AddWithValue("@UnitId", asset.UnitId);
                    cmd.Parameters.AddWithValue("@Note", asset.Note ?? "");
                    cmd.Parameters.AddWithValue("@Id", asset.Id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM Assets WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
