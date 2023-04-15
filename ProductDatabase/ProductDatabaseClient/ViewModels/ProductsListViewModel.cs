// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ProductDatabase.Data.Product;
using ProductDatabaseClient.Common;
using System.ComponentModel;
using System.Threading.Tasks;

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
            ProductCategoryList = new BindingList<ProductCategory>();
        }

        public BindingList<Product> ProductsList { get; private set; }

        public BindingList<ProductCategory> ProductCategoryList { get; private set; }

        private bool loading;

        /// <summary>
        /// True if data processing is running
        /// </summary>
        public bool Loading
        {
            get => loading;
            private set
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

        private object selectedCategory;

        public object SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (selectedCategory != value)
                {
                    selectedCategory = value;
                    RaisePropertyChanged();
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
        /// Load product category list
        /// </summary>
        public async Task UpdateProductCategoryList()
        {
            try
            {
                Loading = true;
                ProductCategoryList.Clear();

                var categories = await productRepository.GetAllCategories();
                foreach (var category in categories)
                {
                    ProductCategoryList.Add(category);
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
                var category = SelectedCategory as int?;
                if (!category.HasValue) return;

                Loading = true;
                await productRepository.ImportFromExcel(filePath, category.Value);
                await UpdateProductsList();
            }
            finally
            {
                Loading = false;
            }
        }
    }
}