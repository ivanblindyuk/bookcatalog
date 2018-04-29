using BookCatalog.Skeleton.Core;
using BookCatalog.Skeleton.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.View.Provider
{
    public abstract class BaseDM : IBaseDM
    {
        public IBookCatalogContext BCContext { get; set; }

        public BaseDM(IBookCatalogContext context)
        {
            BCContext = context;
        }
    }
}
