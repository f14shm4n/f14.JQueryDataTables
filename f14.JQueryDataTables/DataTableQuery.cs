using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace f14.JQueryDataTables
{
    public sealed class DataTableQuery<T>
    {
        private readonly DataTableParameter dtParam;
        private IQueryable<T> dbSet;

        private readonly DataTableOrderDirection sortDir;
        private readonly int pageSize;
        private readonly int skip;

        public DataTableQuery(DataTableParameter dtParam, IQueryable<T> dbSet)
        {
            this.dtParam = dtParam ?? throw new ArgumentNullException(nameof(dtParam));
            this.dbSet = dbSet ?? throw new ArgumentNullException(nameof(dbSet));

            sortDir = dtParam.order[0].dir;
            pageSize = dtParam.length;
            skip = dtParam.start;
        }

        public DataTableQuery<T> Filter(Expression<Func<T, bool>> filter)
        {
            dbSet = dbSet.Where(filter);
            return this;
        }

        public DataTableQuery<T> Order<R>(Expression<Func<T, R>> order)
        {
            if (sortDir == DataTableOrderDirection.ASC)
            {
                dbSet = dbSet.OrderBy(order);
            }
            else
            {
                dbSet = dbSet.OrderByDescending(order);
            }
            return this;
        }

        public DataTableResult<R> Execute<R>(Func<T, R> selector)
        {
            int totalRecords = dbSet.Count(); // Executes count query before set skip or take.

            dbSet = dbSet.Skip(skip).Take(pageSize);

            var resultList = dbSet.Select(selector).ToList();

            var dtResult = new DataTableResult<R>()
            {
                draw = dtParam.draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            dtResult.data.AddRange(resultList);

            return dtResult;
        }
    }
}
