// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.Threading.Tasks;
using ProductDatabase.Data.Product;

namespace ProductDatabaseClient.ViewModels
{
    public interface IProductsListViewModel
    {
        bool CanDelete { get; }
        bool CanEdit { get; }
        bool Loading { get; set; }
        BindingList<Product> ProductsList { get; set; }
        Product SelectedProduct { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        Task DeleteSelectedProduct();
        Task ImportFromXlsx(string filePath);
        Task UpdateProductsList();
    }
}