using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f14.JQueryDataTables
{
    /// <summary>
    /// DataTable column class. <see cref="https://datatables.net/manual/server-side#Sent-parameters"/>
    /// </summary>
    public class DataTableColumn
    {
        /// <summary>
        /// Column data.
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// Column name.
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Column is searchable.
        /// </summary>
        public bool searchable { get; set; }
        /// <summary>
        /// Column is orderable.
        /// </summary>
        public bool orderable { get; set; }
        /// <summary>
        /// Search data.
        /// </summary>
        public DataTableSearch search { get; set; }
    }
}
