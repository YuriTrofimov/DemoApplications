using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ProductDatabaseClient.Controls
{
    public partial class FilterCombo : UserControl, INotifyPropertyChanged
    {
        public FilterCombo()
        {
            InitializeComponent();

            Load += FilterCombo_Load;
        }

        private void FilterCombo_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                cmbValue.DataBindings.Add(nameof(cmbValue.DataSource), this, nameof(DataSource));
                cmbValue.DataBindings.Add(nameof(cmbValue.SelectedValue), this, nameof(SelectedValue));
            }
        }

        private object dataSource;

        public object DataSource
        {
            get => dataSource;
            set
            {
                if (dataSource != value)
                {
                    dataSource = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ValueMember
        {
            get => cmbValue?.ValueMember;
            set
            {
                if (cmbValue != null && cmbValue.ValueMember != value)
                {
                    cmbValue.ValueMember = value;
                }
            }
        }

        public string DisplayMember
        {
            get => cmbValue?.DisplayMember;
            set
            {
                if (cmbValue != null && cmbValue.DisplayMember != value)
                {
                    cmbValue.DisplayMember = value;
                }
            }
        }

        public string Caption
        {
            get => lblCaption?.Text;
            set
            {
                if (lblCaption != null && lblCaption.Text != value)
                {
                    lblCaption.Text = value;
                }
            }
        }

        private object selectedValue;

        public object SelectedValue
        {
            get => selectedValue;
            set
            {
                if (selectedValue != value)
                {
                    selectedValue = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise PropertyChanged event
        /// </summary>
        /// <param name="propertyName">Changed property name</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}