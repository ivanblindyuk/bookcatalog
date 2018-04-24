using BookCatalog.Skeleton.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Resolution
{
    public class BookCatalogContext : IBookCatalogContext
    {
        public IMapper Mapper
        {
            get
            {
                return Resolution.Mapper.Instance;
            }            
        }

        public IResolver Resolver
        {
            get
            {
                return Resolution.Resolver.Instance;
            }
        }
    }
}
