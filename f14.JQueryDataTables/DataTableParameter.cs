using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f14.JQueryDataTables
{
    /// <summary>
    /// Model for DataTableParameter. <see cref="https://datatables.net/manual/server-side#Sent-parameters"/>
    /// </summary>    
    public class DataTableParameter
    {
        /// <summary>
        /// Draw counter.
        /// </summary>
        public int draw { get; set; }
        /// <summary>
        /// Paging first record indicator.
        /// </summary>        
        public int start { get; set; }
        /// <summary>
        /// Number of records that the table can display in the current draw. 
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// Search data.
        /// </summary>
        public DataTableSearch search { get; set; }
        /// <summary>
        /// Order data.
        /// </summary>
        public DataTableOrder[] order { get; set; }
        /// <summary>
        /// Columns data.
        /// </summary>
        public DataTableColumn[] columns { get; set; }

        public override string ToString()
        {
            return $"{nameof(DataTableSearch)} [{nameof(draw)}: {draw}, {nameof(start)}: {start}, {nameof(length)}: {length}, {search}]";
        }
    }
}
