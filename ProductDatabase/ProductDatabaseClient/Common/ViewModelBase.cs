// Copyright (c) 2023 Yuri Trofimov.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProductDatabaseClient.Common
{
    /// <summary>
    /// Base ViewModel class
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
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