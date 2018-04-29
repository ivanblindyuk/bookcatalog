using BookCatalog.Skeleton.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Skeleton.Core;

namespace BookCatalog.View.Provider
{
    public class BookDM : BaseDM, IBookDM
    {
        public BookDM(IBookCatalogContext context)
            : base(context)
        {
        }
    }
}
