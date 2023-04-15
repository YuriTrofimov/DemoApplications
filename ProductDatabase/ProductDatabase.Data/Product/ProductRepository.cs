// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace ProductDatabase.Data.Product
{
    /// <summary>
    /// Product repository implementation
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly string connectionString;

        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Delete product by ID
        /// </summary>
        /// <param name="id">Product unique identifier</param>
        public async Task DeleteProduct(int id)
        {
            using (var con = new SqlConnection(this.connectionString))
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "delete from dbo.Products where Id = @productID";
                cmd.Parameters.AddWithValue("@productID", id);
                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="product">Updated product</param>
        public async Task UpdateProduct(Product product)
        {
            using (var con = new SqlConnection(this.connectionString))
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "update dbo.Products set Article=@article,Name=@name,Price=@price,Quantity=@quantity,CategoryID=@category where Id=@id";
                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@article", product.Article);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@quantity", product.Quantity);
                cmd.Parameters.AddWithValue("@category", product.CategoryID);
                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>Collection of products</returns>
        public async Task<IEnumerable<Product>> GetAll()
        {
            var result = new List<Product>();
            using (var con = new SqlConnection(this.connectionString))
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "select Id, Article, Name, Price, Quantity, CategoryId from dbo.Products";
                await con.OpenAsync();
                using (var rdr = await cmd.ExecuteReaderAsync())
                {
                    while (await rdr.ReadAsync())
                    {
                        result.Add(new Product
                        {
                            Id = Convert.ToInt32(rdr["Id"]),
                            Article = Convert.ToString(rdr["Article"]),
                            Name = Convert.ToString(rdr["Name"]),
                            Price = Convert.ToDecimal(rdr["Price"]),
                            Quantity = Convert.ToInt32(rdr["Quantity"]),
                            CategoryID = Convert.ToInt32(rdr["CategoryId"])
                        });
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Import products list from Excel format files
        /// </summary>
        /// <param name="filePath">Path to source file</param>
        /// <param name="categoryId">product category identifier</param>
        /// <exception cref="ArgumentException">File type is not supported</exception>
        public async Task ImportFromExcel(string filePath, int categoryId)
        {
            var fi = new FileInfo(filePath);
            if (!fi.Exists) return;

            DataTable products = null;
            try
            {
                switch (fi.Extension.ToLower())
                {
                    case ".xlsx":
                        products = await Task.Run(() => new ProductFileParser().ParseFromXLSX(filePath));
                        break;

                    default:
                        throw new ArgumentException($"File type {fi.Extension} is not supported!");
                }

                if (!products.Columns.Contains("CategoryId"))
                {
                    products.Columns.Add("CategoryId", typeof(int));
                    foreach (DataRow row in products.Rows)
                    {
                        row["CategoryId"] = categoryId;
                    }
                }

                await ImportProductsToDB(products);
            }
            finally
            {
                products?.Dispose();
            }
        }

        /// <summary>
        /// Bulk import products DataTable to DB
        /// </summary>
        /// <param name="products">Products datatable</param>
        private async Task ImportProductsToDB(DataTable products)
        {
            using (var con = new SqlConnection(this.connectionString))
            using (var bulkInsert = new SqlBulkCopy(con))
            {
                bulkInsert.DestinationTableName = "dbo.Products";
                foreach (DataColumn col in products.Columns)
                {
                    bulkInsert.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }
                await con.OpenAsync();
                await bulkInsert.WriteToServerAsync(products);
            }
        }

        /// <summary>
        /// Creates product if article is not exist, otherwise updates product
        /// </summary>
        /// <param name="product">Product to create/update</param>
        public async Task CreateOrUpdateProduct(Product product)
        {
            using (var con = new SqlConnection(this.connectionString))
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "[dbo].[UpdateProduct]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Article", product.Article);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoryID);

                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// Get all product categories
        /// </summary>
        /// <returns>Product category collection</returns>
        public async Task<IEnumerable<ProductCategory>> GetAllCategories()
        {
            var result = new List<ProductCategory>();
            using (var con = new SqlConnection(this.connectionString))
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "select Id, Name from dbo.ProductCategory";
                await con.OpenAsync();
                using (var rdr = await cmd.ExecuteReaderAsync())
                {
                    while (await rdr.ReadAsync())
                    {
                        result.Add(new ProductCategory
                        {
                            Id = Convert.ToInt32(rdr["Id"]),
                            Name = Convert.ToString(rdr["Name"]),
                        });
                    }
                }
            }
            return result;
        }
    }
}