using QLTS.DAL.Helpers;
using QLTS.DTO.Models;
using System.Collections.Generic;
using System.Data.SQLite;

namespace QLTS.DAL.Units
{
    public class UnitDAL
    {
        public List<Unit> GetUnits()
        {
            var list = new List<Unit>();

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string sql = "SELECT Id, Name FROM Units";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Unit
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }

            return list;
        }
    }
}
