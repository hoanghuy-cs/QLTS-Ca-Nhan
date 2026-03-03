using QLTS.DAL.Helpers;
using QLTS.DTO.DTOs;
using QLTS.DTO.Models;
using QLTS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace QLTS.DAL.Transactions
{
    public class TransactionDAL
    {
        public List<TransactionItemDTO> GetTransactions(
            int? assetId = null,
            TransactionType? type = null,
            DateTime? transactionDateFrom = null,
            DateTime? transactionDateTo = null)
        {
            var list = new List<TransactionItemDTO>();

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT
                        t.Id,
                        t.AssetId,
                        a.Name AS AssetName,
                        u.Name AS AssetUnitName,
                        t.Type,
                        t.Quantity,
                        t.UnitPrice,
                        t.Fee,
                        t.TransactionDate,
                        t.Note
                    FROM Transactions t
                        INNER JOIN Assets a ON t.AssetId = a.Id
                        INNER JOIN Units u ON a.UnitId = u.Id
                    WHERE 1 = 1";

                if (assetId.HasValue)
                {
                    sql += "\nAND t.AssetId = @AssetId";
                }

                if (type.HasValue)
                {
                    sql += "\nAND t.Type = @Type";
                }

                if (transactionDateFrom.HasValue)
                {
                    sql += "\nAND DATE(t.TransactionDate) >= @TransactionDateFrom";
                }

                if (transactionDateTo.HasValue)
                {
                    sql += "\nAND DATE(t.TransactionDate) <= @TransactionDateTo";
                }

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (assetId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@AssetId", assetId.Value);
                    }

                    if (type.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@Type", (int)type.Value);
                    }

                    if (transactionDateFrom.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@TransactionDateFrom", transactionDateFrom.Value.ToString("yyyy-MM-dd"));
                    }

                    if (transactionDateTo.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@TransactionDateTo", transactionDateTo.Value.ToString("yyyy-MM-dd"));
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TransactionItemDTO
                            {
                                Id = reader.GetInt32(0),
                                AssetId = reader.GetInt32(1),
                                AssetName = reader.GetString(2),
                                AssetUnitName = reader.GetString(3),
                                Type = (TransactionType)reader.GetInt32(4),
                                Quantity = reader.GetInt32(5),
                                UnitPrice = reader.GetDecimal(6),
                                Fee = reader.GetDecimal(7),
                                TransactionDate = DateTime.Parse(reader.GetString(8)),
                                Note = reader.IsDBNull(8) ? null : reader.GetString(9)
                            });
                        }
                    }
                }
            }

            return list;
        }

        public int Create(Transaction transaction)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO Transactions(AssetId, Type, Quantity, UnitPrice, Fee, TransactionDate, Note)
                    VALUES(@AssetId, @Type, @Quantity, @UnitPrice, @Fee, @TransactionDate, @Note);

                    SELECT last_insert_rowid();
                ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@AssetId", transaction.AssetId);
                    cmd.Parameters.AddWithValue("@Type", (int)transaction.Type);
                    cmd.Parameters.AddWithValue("@Quantity", transaction.Quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice", transaction.UnitPrice);
                    cmd.Parameters.AddWithValue("@Fee", transaction.Fee);
                    cmd.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Note", transaction.Note);

                    object result = cmd.ExecuteScalar();

                    return Convert.ToInt32(result);
                }
            }
        }

        public int Update(Transaction transaction)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE Transactions
                    SET AssetId = @AssetId,
                        Type = @Type,
                        Quantity = @Quantity,
                        UnitPrice = @UnitPrice,
                        Fee = @Fee,
                        TransactionDate = @TransactionDate,
                        Note = @Note
                    WHERE Id = @Id
                ";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@AssetId", transaction.AssetId);
                    cmd.Parameters.AddWithValue("@Type", (int)transaction.Type);
                    cmd.Parameters.AddWithValue("@Quantity", transaction.Quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice", transaction.UnitPrice);
                    cmd.Parameters.AddWithValue("@Fee", transaction.Fee);
                    cmd.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Note", transaction.Note);
                    cmd.Parameters.AddWithValue("@Id", transaction.Id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM Transactions WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
