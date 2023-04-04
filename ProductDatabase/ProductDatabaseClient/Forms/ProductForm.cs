// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Windows.Forms;
using ProductDatabaseClient.ViewModels;

namespace ProductDatabaseClient.Forms
{
    public partial class ProductForm : Form
    {
        private readonly IProductViewModel viewModel;

        public ProductForm(IProductViewModel viewModel)
        {
            this.viewModel = viewModel;

            InitializeComponent();

            Load += ProductForm_Load;
        }

        private async void ProductForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Setup DataBindings
                txtArticle.DataBindings.Add(nameof(txtArticle.Text), viewModel, nameof(viewModel.Article));
                txtName.DataBindings.Add(nameof(txtName.Text), viewModel, nameof(viewModel.Name));
                txtPrice.DataBindings.Add(nameof(txtPrice.EditValue), viewModel, nameof(viewModel.Price));
                txtQuantity.DataBindings.Add(nameof(txtQuantity.EditValue), viewModel, nameof(viewModel.Quantity));
                imgProduct.Image = await viewModel.LoadImage();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void DisplayError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateChildren();
                await viewModel.SaveProduct();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void ProductForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var image = imgProduct.Image;
            image?.Dispose();
        }
    }
}