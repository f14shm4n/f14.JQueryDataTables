using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace f14.JQueryDataTables
{
    /// <summary>
    /// Provides a helpful wrapper for <see cref="IQueryable{T}"/> with common handling of <see cref="DataTableParameter"/> values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class DataTableQuery<T>
    {
        private readonly DataTableParameter dtParam;
        private IQueryable<T> dbSet;

        private readonly DataTableOrderDirection sortDir;
        private readonly int pageSize;
        private readonly int skip;
        /// <summary>
        /// Creates new instance of query.
        /// </summary>
        /// <param name="dtParam">Param.</param>
        /// <param name="dbSet">Any <see cref="IQueryable{T}"/> set.</param>
        public DataTableQuery(DataTableParameter dtParam, IQueryable<T> dbSet)
        {
            this.dtParam = dtParam ?? throw new ArgumentNullException(nameof(dtParam));
            this.dbSet = dbSet ?? throw new ArgumentNullException(nameof(dbSet));

            sortDir = dtParam.order[0].dir;
            pageSize = dtParam.length;
            skip = dtParam.start;
        }
        /// <summary>
        /// Wrapper for <see cref="System.Linq.Queryable.Where{TSource}(IQueryable{TSource}, Expression{Func{TSource, bool}})"/>.
        /// </summary>
        /// <param name="filter">Any filter expression.</param>
        /// <returns>This.</returns>
        public DataTableQuery<T> Filter(Expression<Func<T, bool>> filter)
        {
            dbSet = dbSet.Where(filter);
            return this;
        }
        /// <summary>
        /// Wrapper for OrderBy or OrderByDescending. Method will be selected depends on order value in datatable param.
        /// </summary>
        /// <typeparam name="R">Type of object which will be a sortable column.</typeparam>
        /// <param name="order">Order expression.</param>
        /// <returns>This.</returns>
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
        /// <summary>
        /// Executes query and return result set.
        /// </summary>
        /// <typeparam name="R">Tyep of object which will be in a result set.</typeparam>
        /// <param name="selector">The item selector\projector.</param>
        /// <param name="ignoreSkipTake">If True - the Skip and Take methods will not be included into final query. This means you will get all items which matches desired filters.</param>
        /// <returns>Data table result.</returns>
        public DataTableResult<R> Execute<R>(Func<T, R> selector, bool ignoreSkipTake = false)
        {
            int totalRecords = dbSet.Count(); // Executes count query before set skip or take.

            if (!ignoreSkipTake)
            {
                dbSet = dbSet.Skip(skip).Take(pageSize);
            }

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
