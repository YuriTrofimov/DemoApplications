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
        /// Import products from OpenXML XLSX file
        /// </summary>
        /// <param name="sourceFile">source XLSX file</param>
        Task ImportFromExcel(string sourceFile);

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
    }
}
