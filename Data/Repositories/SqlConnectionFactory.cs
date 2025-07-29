using Data.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _cfg;       

        public SqlConnectionFactory(IConfiguration cfg) => _cfg = cfg;

        public IDbConnection Create(string dbKey)
        {
            var cs = _cfg.GetConnectionString(dbKey)
                     ?? throw new InvalidOperationException($"Missing conn string '{dbKey}'");
            var conn = new SqlConnection(cs);
            conn.Open();
            return conn;
        }
    }
}
