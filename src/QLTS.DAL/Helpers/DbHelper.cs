using System.Data.SQLite;

namespace QLTS.DAL.Helpers
{
    public static class DbHelper
    {
        private static readonly string _connectionString =
            "Data Source=QLTS.db;Version=3;Foreign Keys=True;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }
    }
}
