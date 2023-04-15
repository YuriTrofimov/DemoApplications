using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace ProductDatabase.Database.Test
{
    [TestClass()]
    public class ProductTest : SqlDatabaseTestClass
    {

        public ProductTest()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_CreateProductTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductTest));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition CheckArticle;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition CheckName;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition CheckPrice;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition CheckQuantity;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition CheckCategoryID;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_UpdateProductTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition CheckProductIsSingle;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition UpdateCheckArticle;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition UpdateCheckName;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition UpdateCheckPrice;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition UpdateCheckQuantity;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition UpdateCheckCategoryId;
            this.dbo_CreateProductTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.dbo_UpdateProductTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_CreateProductTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckArticle = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            CheckName = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            CheckPrice = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            CheckQuantity = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            CheckCategoryID = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            dbo_UpdateProductTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            CheckProductIsSingle = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            UpdateCheckArticle = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            UpdateCheckName = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            UpdateCheckPrice = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            UpdateCheckQuantity = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            UpdateCheckCategoryId = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            // 
            // dbo_CreateProductTest_TestAction
            // 
            dbo_CreateProductTest_TestAction.Conditions.Add(CheckArticle);
            dbo_CreateProductTest_TestAction.Conditions.Add(CheckName);
            dbo_CreateProductTest_TestAction.Conditions.Add(CheckPrice);
            dbo_CreateProductTest_TestAction.Conditions.Add(CheckQuantity);
            dbo_CreateProductTest_TestAction.Conditions.Add(CheckCategoryID);
            resources.ApplyResources(dbo_CreateProductTest_TestAction, "dbo_CreateProductTest_TestAction");
            // 
            // CheckArticle
            // 
            CheckArticle.ColumnNumber = 1;
            CheckArticle.Enabled = true;
            CheckArticle.ExpectedValue = "NewArticle";
            CheckArticle.Name = "CheckArticle";
            CheckArticle.NullExpected = false;
            CheckArticle.ResultSet = 1;
            CheckArticle.RowNumber = 1;
            // 
            // CheckName
            // 
            CheckName.ColumnNumber = 2;
            CheckName.Enabled = true;
            CheckName.ExpectedValue = "NewName";
            CheckName.Name = "CheckName";
            CheckName.NullExpected = false;
            CheckName.ResultSet = 1;
            CheckName.RowNumber = 1;
            // 
            // CheckPrice
            // 
            CheckPrice.ColumnNumber = 3;
            CheckPrice.Enabled = true;
            CheckPrice.ExpectedValue = "99.95";
            CheckPrice.Name = "CheckPrice";
            CheckPrice.NullExpected = false;
            CheckPrice.ResultSet = 1;
            CheckPrice.RowNumber = 1;
            // 
            // CheckQuantity
            // 
            CheckQuantity.ColumnNumber = 4;
            CheckQuantity.Enabled = true;
            CheckQuantity.ExpectedValue = "15";
            CheckQuantity.Name = "CheckQuantity";
            CheckQuantity.NullExpected = false;
            CheckQuantity.ResultSet = 1;
            CheckQuantity.RowNumber = 1;
            // 
            // CheckCategoryID
            // 
            CheckCategoryID.ColumnNumber = 5;
            CheckCategoryID.Enabled = true;
            CheckCategoryID.ExpectedValue = "13";
            CheckCategoryID.Name = "CheckCategoryID";
            CheckCategoryID.NullExpected = false;
            CheckCategoryID.ResultSet = 1;
            CheckCategoryID.RowNumber = 1;
            // 
            // dbo_UpdateProductTest_TestAction
            // 
            dbo_UpdateProductTest_TestAction.Conditions.Add(CheckProductIsSingle);
            dbo_UpdateProductTest_TestAction.Conditions.Add(UpdateCheckArticle);
            dbo_UpdateProductTest_TestAction.Conditions.Add(UpdateCheckName);
            dbo_UpdateProductTest_TestAction.Conditions.Add(UpdateCheckPrice);
            dbo_UpdateProductTest_TestAction.Conditions.Add(UpdateCheckQuantity);
            dbo_UpdateProductTest_TestAction.Conditions.Add(UpdateCheckCategoryId);
            resources.ApplyResources(dbo_UpdateProductTest_TestAction, "dbo_UpdateProductTest_TestAction");
            // 
            // CheckProductIsSingle
            // 
            CheckProductIsSingle.Enabled = true;
            CheckProductIsSingle.Name = "CheckProductIsSingle";
            CheckProductIsSingle.ResultSet = 1;
            CheckProductIsSingle.RowCount = 1;
            // 
            // UpdateCheckArticle
            // 
            UpdateCheckArticle.ColumnNumber = 1;
            UpdateCheckArticle.Enabled = true;
            UpdateCheckArticle.ExpectedValue = "Article01";
            UpdateCheckArticle.Name = "UpdateCheckArticle";
            UpdateCheckArticle.NullExpected = false;
            UpdateCheckArticle.ResultSet = 1;
            UpdateCheckArticle.RowNumber = 1;
            // 
            // UpdateCheckName
            // 
            UpdateCheckName.ColumnNumber = 2;
            UpdateCheckName.Enabled = true;
            UpdateCheckName.ExpectedValue = "MyName2";
            UpdateCheckName.Name = "UpdateCheckName";
            UpdateCheckName.NullExpected = false;
            UpdateCheckName.ResultSet = 1;
            UpdateCheckName.RowNumber = 1;
            // 
            // UpdateCheckPrice
            // 
            UpdateCheckPrice.ColumnNumber = 3;
            UpdateCheckPrice.Enabled = true;
            UpdateCheckPrice.ExpectedValue = "12.84";
            UpdateCheckPrice.Name = "UpdateCheckPrice";
            UpdateCheckPrice.NullExpected = false;
            UpdateCheckPrice.ResultSet = 1;
            UpdateCheckPrice.RowNumber = 1;
            // 
            // UpdateCheckQuantity
            // 
            UpdateCheckQuantity.ColumnNumber = 4;
            UpdateCheckQuantity.Enabled = true;
            UpdateCheckQuantity.ExpectedValue = "8";
            UpdateCheckQuantity.Name = "UpdateCheckQuantity";
            UpdateCheckQuantity.NullExpected = false;
            UpdateCheckQuantity.ResultSet = 1;
            UpdateCheckQuantity.RowNumber = 1;
            // 
            // UpdateCheckCategoryId
            // 
            UpdateCheckCategoryId.ColumnNumber = 5;
            UpdateCheckCategoryId.Enabled = true;
            UpdateCheckCategoryId.ExpectedValue = "34";
            UpdateCheckCategoryId.Name = "UpdateCheckCategoryId";
            UpdateCheckCategoryId.NullExpected = false;
            UpdateCheckCategoryId.ResultSet = 1;
            UpdateCheckCategoryId.RowNumber = 1;
            // 
            // dbo_CreateProductTestData
            // 
            this.dbo_CreateProductTestData.PosttestAction = null;
            this.dbo_CreateProductTestData.PretestAction = null;
            this.dbo_CreateProductTestData.TestAction = dbo_CreateProductTest_TestAction;
            // 
            // dbo_UpdateProductTestData
            // 
            this.dbo_UpdateProductTestData.PosttestAction = null;
            this.dbo_UpdateProductTestData.PretestAction = null;
            this.dbo_UpdateProductTestData.TestAction = dbo_UpdateProductTest_TestAction;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        [TestMethod()]
        public void dbo_CreateProductTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_CreateProductTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void dbo_UpdateProductTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_UpdateProductTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        private SqlDatabaseTestActions dbo_CreateProductTestData;
        private SqlDatabaseTestActions dbo_UpdateProductTestData;
    }
}
