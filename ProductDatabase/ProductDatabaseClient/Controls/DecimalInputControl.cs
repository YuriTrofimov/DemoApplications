// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductDatabaseClient.Controls
{
    public partial class DecimalInputControl : NumericControl
    {
        public DecimalInputControl()
        {
            InitializeComponent();
        }

        private decimal editValue;
        public decimal EditValue
        {
            get { return editValue; }
            set
            {
                if (editValue != value)
                {
                    editValue = value;
                    txtValue.Text = value.ToString();
                    RaisePropertyChanged();
                }
            }
        }

        protected override void ParseValue(string inputText)
        {
            if (decimal.TryParse(inputText, out decimal val))
            {
                EditValue = val;
            }
        }
    }
}
