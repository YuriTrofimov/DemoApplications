// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace ProductDatabase.Data.Product
{
    /// <summary>
    /// Product
    /// </summary>
    public sealed class Product
    {
        /// <summary>
        /// Product Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product Article
        /// </summary>
        public string Article { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Product stock amount
        /// </summary>
        public int Quantity { get; set; }
    }
}
