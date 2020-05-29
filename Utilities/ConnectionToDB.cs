using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace ExpensesWebApp.Utilities

{
    public class ConnectionToDB : IConnectionToDB
    {
        public IConfiguration Configuration { get; }
        public ConnectionToDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public SqlConnection Connect()
        {
            var conn = new SqlConnection(Configuration.GetConnectionString("DatabaseConnectionString"));
            conn.Open();
            return conn;
        }
    }
}
