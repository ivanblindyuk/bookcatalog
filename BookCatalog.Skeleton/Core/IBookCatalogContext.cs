﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Skeleton.Core
{
    public interface IBookCatalogContext
    {
        IResolver Resolver { get; }
        IMapper Mapper { get; }
    }
}
