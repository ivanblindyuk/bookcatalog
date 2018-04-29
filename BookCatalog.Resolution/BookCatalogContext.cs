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
        IMapper _mapper;
        public IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                    _mapper = new Mapper();

                return _mapper;
            }            
        }

        IResolver _resolver;
        public IResolver Resolver
        {
            get
            {
                if (_resolver == null)
                    _resolver = new Resolver(this);

                return _resolver;
            }
        }
    }
}
