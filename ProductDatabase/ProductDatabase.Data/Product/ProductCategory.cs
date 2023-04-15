using System;
using System.Collections.Generic;
using System.Text;

namespace ProductDatabase.Data.Product
{
    public sealed class ProductCategory
    {
        /// <summary>
        /// Product category unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product category name
        /// </summary>
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
