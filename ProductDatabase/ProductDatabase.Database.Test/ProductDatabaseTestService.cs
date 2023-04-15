using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Configuration;
using System.Configuration;

namespace ProductDatabase.Database.Test
{
    public class ProductDatabaseTestService : SqlDatabaseTestService
    {
        /// <summary>
        /// Deploy all test databases and tSQLt framework
        /// </summary>
        public void DeployTestDatabases()
        {
            DeployDatabaseProject(@"..\..\..\ProductDatabase.Database\ProductDatabase.Database.sqlproj", "Debug", "Microsoft.Data.SqlClient", GetConnectionString());
            DeployDatabaseProject(@"..\..\..\ProductDatabase.Database.tSQLt\ProductDatabase.Database.tSQLt.sqlproj", "Debug", "Microsoft.Data.SqlClient", GetConnectionString());
        }

        private static string GetConnectionString()
        {
            var config = (SqlUnitTestingSection)ConfigurationManager.GetSection("SqlUnitTesting");
            return config.ExecutionContext.ConnectionString;
        }
    }
}