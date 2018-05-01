using BookCatalog.Data.Model;
using BookCatalog.Skeleton.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Skeleton.Core;

namespace BookCatalog.Data.Provider
{
    public class BookRepository : DapperRepository<Book>, IBookRepository
    {
        public BookRepository(IDbContext context)
            : base(context)
        {
        }
    }
}
