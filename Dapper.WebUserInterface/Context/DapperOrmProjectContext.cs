using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper.WebUserInterface.Context
{
    public class DapperOrmProjectContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperOrmProjectContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DapperConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
