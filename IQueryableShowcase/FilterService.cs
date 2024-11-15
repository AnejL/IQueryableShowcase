using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQueryableShowcase.Contracts;

namespace IQueryableShowcase
{
    public class FilterService<T>
    {
        public IQueryable<T> Filter(IEnumerable<T> source, IFilter<T> filter)
        {
            var queryable = source.AsQueryable();

            if (filter.IsEmpty())
                return queryable;

            foreach (var expression in filter.GetFilterExpressionList())
            {
                queryable = queryable.Where(expression);
            }

            return queryable;
        }

    }
}
