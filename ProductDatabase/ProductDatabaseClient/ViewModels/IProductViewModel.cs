// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Drawing;
using System.Threading.Tasks;

namespace ProductDatabaseClient.ViewModels
{
    public interface IProductViewModel
    {
        string Article { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        int Quantity { get; set; }

        Task<Image> LoadImage();
        Task SaveProduct();
    }
}