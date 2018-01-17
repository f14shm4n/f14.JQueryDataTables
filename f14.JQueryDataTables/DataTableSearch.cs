using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f14.JQueryDataTables
{
    /// <summary>
    /// Search data class.
    /// </summary>
    public class DataTableSearch
    {
        /// <summary>
        /// Search value.
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// Regex flag.
        /// </summary>
        public bool regex { get; set; }

        public override string ToString()
        {
            return $"{nameof(DataTableSearch)}: [{nameof(value)}: {value}, {nameof(regex)}: {regex}]";
        }
    }
}
