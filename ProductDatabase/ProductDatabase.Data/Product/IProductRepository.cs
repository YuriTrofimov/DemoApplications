// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.Data.Product
{
    /// <summary>
    /// Product Repository interface
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>Product collection</returns>
        Task<IEnumerable<Product>> GetAll();

        /// <summary>
        /// Get all product categories
        /// </summary>
        /// <returns>Product category collection</returns>
        Task<IEnumerable<ProductCategory>> GetAllCategories();

        /// <summary>
        /// Import products from OpenXML XLSX file
        /// </summary>
        /// <param name="sourceFile">source XLSX file</param>
        /// <param name="categoryId">product category identifier</param>
        Task ImportFromExcel(string sourceFile, int categoryId);

        /// <summary>
        /// Delete product by ID
        /// </summary>
        /// <param name="id">Product unique identifier</param>
        Task DeleteProduct(int id);

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="product">Product to update</param>
        Task UpdateProduct(Product product);

        /// <summary>
        /// Creates product if article is not exist, otherwise updates product
        /// </summary>
        /// <param name="product">Product to create/update</param>
        Task CreateOrUpdateProduct(Product product);
    }
}
