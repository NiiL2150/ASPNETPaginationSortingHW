using System.Data.SqlClient;

namespace ASPNETPaginationSortingHW.Repositories
{
    public class DbContext
    {
        private static string _connectionString = "";

        public static SqlConnection GetConnection()
        {
            _connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("SqlConnection");
            return new SqlConnection(_connectionString);
        }
    }
}
