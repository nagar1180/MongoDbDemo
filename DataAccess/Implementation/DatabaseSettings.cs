using DataAccess.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
   public class DatabaseSettings : IDatabaseSettings
    {
        public DatabaseSettings(string connectionString, string databaseName)
        {
            this.ConnectionString = connectionString;
            this.DatabaseName = databaseName;
        }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
