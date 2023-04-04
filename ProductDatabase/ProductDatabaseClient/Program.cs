// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ProductDatabase.Data.Product;
using ProductDatabaseClient.Forms;
using ProductDatabaseClient.ViewModels;

namespace ProductDatabaseClient
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            try
            {
                ServiceProvider = services.BuildServiceProvider();
                Application.Run(ServiceProvider.GetRequiredService<ProductListForm>());
            }
            finally
            {
                (ServiceProvider as IDisposable)?.Dispose();
            }
        }

        /// <summary>
        /// Dependecy Injection ServiceProvider
        /// </summary>
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// Configure Dependency Injection
        /// </summary>
        /// <param name="services">Service collection</param>
        private static void ConfigureServices(IServiceCollection services)
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            services.AddSingleton<IProductRepository>(new ProductRepository(connectionString));

            // Forms
            services.AddSingleton<ProductListForm>();
            services.AddTransient<ProductForm>();

            // ViewModels
            services.AddSingleton<IProductsListViewModel, ProductsListViewModel>();
            services.AddTransient<IProductViewModel, ProductViewModel>();
        }
    }
}