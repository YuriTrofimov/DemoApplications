// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ProductDatabaseClient.Controls
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Bindable(false)]
    [Browsable(false)]
    public partial class NumericControl : UserControl, INotifyPropertyChanged
    {
        public NumericControl()
        {
            InitializeComponent();
        }

        public bool AllowDecimalSeparator { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            var text = (sender as TextBox)?.Text;
            var decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (e.KeyChar == decimalChar)
            {
                if (!AllowDecimalSeparator || text?.IndexOf(decimalChar) > -1)
                {
                    e.Handled = true;
                }
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != decimalChar)
            {
                e.Handled = true;
            }
        }

        protected virtual void ParseValue(string inputText)
        {
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            ParseValue(txtValue.Text);
        }
    }
}