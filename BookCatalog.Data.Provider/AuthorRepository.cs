using BookCatalog.Skeleton.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Data.Model;
using BookCatalog.Skeleton.Core;

namespace BookCatalog.Data.Provider
{
    public class AuthorRepository : DapperRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(IDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Author> GetAll()
        {
            return ExecuteMultiQuery<Author>("Select * from tblAuthors");
        }
    }
}
