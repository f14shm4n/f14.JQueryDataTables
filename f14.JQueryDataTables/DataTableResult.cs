using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f14.JQueryDataTables
{
    /// <summary>
    /// Model for DataTableResult JSON. <see cref="https://datatables.net/manual/server-side#Returned-data"/>.
    /// </summary>
    /// <typeparam name="T">Type of item for table.</typeparam>
    public class DataTableResult<T>
    {
        /// <summary>
        /// Draw counter.
        /// </summary>
        public int draw { get; set; }
        /// <summary>
        /// Total records count.
        /// </summary>
        public int recordsTotal { get; set; }
        /// <summary>
        /// Filtered records count.
        /// </summary>
        public int recordsFiltered { get; set; }
        /// <summary>
        /// Records.
        /// </summary>
        public List<T> data { get; set; } = new List<T>();
        /// <summary>
        /// Error message.
        /// </summary>
        public string error { get; set; }
    }
}
