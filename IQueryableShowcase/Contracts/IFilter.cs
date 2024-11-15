using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IQueryableShowcase.Contracts
{
    public interface IFilter<T>
    {
        /// <summary>
        /// Gets a list of filter expressions that can be used on the database.
        /// </summary>
        List<Expression<Func<T, bool>>> GetFilterExpressionList();

        /// <summary>
        /// Returns true if no filterable property is set.
        /// </summary>
        bool IsEmpty();
    }
}
