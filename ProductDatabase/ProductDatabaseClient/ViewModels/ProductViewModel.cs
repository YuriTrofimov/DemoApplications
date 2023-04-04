// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using ProductDatabase.Data.Product;
using ProductDatabaseClient.Common;

namespace ProductDatabaseClient.ViewModels
{
    /// <summary>
    /// Product edit view ViewModel
    /// </summary>
    public class ProductViewModel : ViewModelBase, IProductViewModel
    {
        private readonly IProductsListViewModel productsListViewModel;
        private readonly Product product;
        private readonly IProductRepository productRepository;

        public ProductViewModel(IProductsListViewModel productsListViewModel, IProductRepository productRepository)
        {
            this.productsListViewModel = productsListViewModel;
            product = this.productsListViewModel.SelectedProduct;
            this.productRepository = productRepository;

            if (product != null)
            {
                Article = product.Article;
                Name = product.Name;
                Price = product.Price;
                Quantity = product.Quantity;
            }
        }

        /// <summary>
        /// Product Article
        /// </summary>
        public string Article
        {
            get => product.Article;
            set
            {
                if (product.Article != value)
                {
                    product.Article = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Product Name
        /// </summary>
        public string Name
        {
            get => product.Name;
            set
            {
                if (product.Name != value)
                {
                    product.Name = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Product Price
        /// </summary>
        public decimal Price
        {
            get => product.Price;
            set
            {
                if (product.Price != value)
                {
                    product.Price = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Product Quantity
        /// </summary>
        public int Quantity
        {
            get => product.Quantity;
            set
            {
                if (product.Quantity != value)
                {
                    product.Quantity = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Load product image from file
        /// </summary>
        /// <returns>Loaded image</returns>
        public async Task<Image> LoadImage()
        {
            Image result = null;
            var path = Path.Combine("pic/", $"{product.Article}.jpg");
            if (File.Exists(path))
            {
                result = await Task.Run(() => Image.FromFile(path));
            }
            return result;
        }

        /// <summary>
        /// Save product changes
        /// </summary>
        public async Task SaveProduct()
        {
            await productRepository.UpdateProduct(product);
        }
    }
}