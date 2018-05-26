using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Skeleton.Core
{
    public interface IMapper
    {
        TOut Map<TIn, TOut>(TIn source);
        IEnumerable<TOut> MapMany<TIn, TOut>(IEnumerable<TIn> source);
    }
}
