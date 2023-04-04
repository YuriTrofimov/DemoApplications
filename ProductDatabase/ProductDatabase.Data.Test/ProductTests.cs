// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ProductDatabase.Data.Product;

namespace ProductDatabase.Data.Test
{
    public class ProductTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ParserTest()
        {
            var sourceFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleData\\test.xlsx");
            var parser = new ProductFileParser();
            using (var dt = parser.ParseFromXLSX(sourceFilePath, true))
            {
                Assert.That(dt.Rows.Count, Is.EqualTo(4));
                var testRow = dt.Rows[3];

                Assert.That(testRow["Article"], Is.EqualTo("3A2915-R0M"));
                Assert.That(testRow["Name"], Is.EqualTo("иряър"));
                Assert.That(testRow["Price"], Is.EqualTo(100000.0m));
                Assert.That(testRow["Quantity"], Is.EqualTo(4));
            }
            Assert.Pass("File parsed succesfully!");
        }
    }
}