using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductDatabase.Database.Test
{
    [TestClass()]
    public class SqlDatabaseSetup
    {
        [AssemblyInitialize()]
        public static void InitializeAssembly(TestContext ctx)
        {
            var testService = new ProductDatabaseTestService();
            testService.DeployTestDatabases();
            testService.GenerateData();
        }
    }
}