using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ExpensesWebApp.Utilities
{
    public interface IConnectionToDB
    {
        IConfiguration Configuration { get; }

        SqlConnection Connect();
    }
}