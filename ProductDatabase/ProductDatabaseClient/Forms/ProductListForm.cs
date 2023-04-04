// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ProductDatabase.Data.Product;
using ProductDatabaseClient.ViewModels;

namespace ProductDatabaseClient.Forms
{
    public partial class ProductListForm : Form
    {
        private readonly IProductsListViewModel viewModel;

        public ProductListForm(IProductsListViewModel viewModel)
        {
            this.viewModel = viewModel;
            InitializeComponent();
            Load += ProductListForm_Load;
        }

        private async void ProductListForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Setup DataBindings

                DataBindings.Add(nameof(UseWaitCursor), viewModel, nameof(viewModel.Loading));
                dgvProducts.DataBindings.Add(nameof(dgvProducts.DataSource), viewModel, nameof(viewModel.ProductsList));
                progressBarLoading.ProgressBar.DataBindings.Add(nameof(progressBarLoading.ProgressBar.Visible), viewModel, nameof(viewModel.Loading));

                btnEdit.DataBindings.Add(nameof(btnEdit.Enabled), viewModel, nameof(viewModel.CanEdit));
                btnDelete.DataBindings.Add(nameof(btnDelete.Enabled), viewModel, nameof(viewModel.CanDelete));

                await viewModel.UpdateProductsList();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DisplayError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            dlgSelectImportSource.ShowDialog();
        }

        private async void dlgSelectImportSource_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                await viewModel.ImportFromXlsx(dlgSelectImportSource.FileName);
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            var view = sender as DataGridView;
            if (view != null)
            {
                if (view.SelectedRows.Count == 1)
                {
                    viewModel.SelectedProduct = view.SelectedRows[0].DataBoundItem as Product;
                }
                else if (view.SelectedCells.Count == 1)
                {
                    var cell = view.SelectedCells[0];
                    viewModel.SelectedProduct = view.Rows[cell.RowIndex].DataBoundItem as Product;
                }
                else
                {
                    viewModel.SelectedProduct = null;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (viewModel.SelectedProduct == null) return;

                var editForm = Program.ServiceProvider.GetService<ProductForm>();
                if (editForm != null)
                {
                    try
                    {
                        editForm.ShowDialog();
                        viewModel.UpdateProductsList();
                    }
                    finally
                    {
                        editForm?.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedProduct = viewModel.SelectedProduct;
                if (selectedProduct == null) return;

                var message = $"Delete product '{selectedProduct.Article}'?";

                if (MessageBox.Show(message, "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await viewModel.DeleteSelectedProduct();
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }
    }
}