using BookCatalog.Skeleton.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Skeleton.DM
{
    public interface IBaseDM : IDisposable
    {
        IBookCatalogContext BCContext {get; set;}
    }
}
