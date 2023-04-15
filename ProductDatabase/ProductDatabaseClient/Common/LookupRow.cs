using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabaseClient.Common
{
    public sealed class LookupRow
    {
        /// <summary>
        /// Lookup row identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Lookup row caption
        /// </summary>
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
