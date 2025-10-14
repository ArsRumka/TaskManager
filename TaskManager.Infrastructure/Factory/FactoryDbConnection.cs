using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Infrastructure.Factory
{
    public class FactoryDbConnection:IFactoryDbConnection
    {
        private readonly string _connectionString;

        public FactoryDbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
