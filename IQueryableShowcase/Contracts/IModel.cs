using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQueryableShowcase.Contracts
{
    public interface IModel
    {
        public object ToDto();
    }
}
