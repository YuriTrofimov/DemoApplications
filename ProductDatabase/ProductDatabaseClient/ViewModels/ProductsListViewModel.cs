// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.Threading.Tasks;
using ProductDatabase.Data.Product;
using ProductDatabaseClient.Common;

namespace ProductDatabaseClient.ViewModels
{
    /// <summary>
    /// Product List ViewModel
    /// </summary>
    public class ProductsListViewModel : ViewModelBase, IProductsListViewModel
    {
        private readonly IProductRepository productRepository;

        public ProductsListViewModel(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            ProductsList = new BindingList<Product>();
        }

        public BindingList<Product> ProductsList { get; set; }

        private bool loading;

        /// <summary>
        /// True if data processing is running
        /// </summary>
        public bool Loading
        {
            get => loading;
            set
            {
                if (loading != value)
                {
                    loading = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// True if user can edit product
        /// </summary>
        public bool CanEdit
        {
            get => SelectedProduct != null;
        }

        /// <summary>
        /// True if user can delete product
        /// </summary>
        public bool CanDelete
        {
            get => selectedProduct != null;
        }

        private Product selectedProduct;

        /// <summary>
        /// Current selected product
        /// </summary>
        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                if (selectedProduct != value)
                {
                    selectedProduct = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanEdit));
                    RaisePropertyChanged(nameof(CanDelete));
                }
            }
        }

        /// <summary>
        /// Load product list
        /// </summary>
        public async Task UpdateProductsList()
        {
            try
            {
                Loading = true;
                ProductsList.Clear();

                var products = await productRepository.GetAll();
                foreach (var product in products)
                {
                    ProductsList.Add(product);
                }
            }
            finally
            {
                Loading = false;
            }
        }

        /// <summary>
        /// Delete currently selected product
        /// </summary>
        public async Task DeleteSelectedProduct()
        {
            try
            {
                Loading = true;

                if (SelectedProduct == null) return;

                await productRepository.DeleteProduct(selectedProduct.Id);
                await UpdateProductsList();
            }
            finally
            {
                Loading = false;
            }
        }

        /// <summary>
        /// Import product list from Excel file to DB
        /// </summary>
        /// <param name="filePath">Source file path</param>
        public async Task ImportFromXlsx(string filePath)
        {
            try
            {
                Loading = true;
                await productRepository.ImportFromExcel(filePath);
                await UpdateProductsList();
            }
            finally
            {
                Loading = false;
            }
        }
    }
}