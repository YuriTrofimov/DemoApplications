﻿// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ProductDatabase.Data.Product;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ProductDatabaseClient.ViewModels
{
    public interface IProductsListViewModel
    {
        bool CanDelete { get; }
        bool CanEdit { get; }
        bool Loading { get; }
        BindingList<ProductCategory> ProductCategoryList { get; }
        BindingList<Product> ProductsList { get; }
        object SelectedCategory { get; set; }
        Product SelectedProduct { get; set; }

        Task DeleteSelectedProduct();
        Task ImportFromXlsx(string filePath);
        Task UpdateProductCategoryList();
        Task UpdateProductsList();
    }
}