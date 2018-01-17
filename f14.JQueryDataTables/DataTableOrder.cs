using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f14.JQueryDataTables
{
    /// <summary>
    /// Datatable order class.
    /// </summary>
    public class DataTableOrder
    {
        /// <summary>
        /// Column index.
        /// </summary>
        public int column { get; set; }
        /// <summary>
        /// Order direction.
        /// </summary>
        public DataTableOrderDirection dir { get; set; }
    }
}
