using BookCatalog.Skeleton.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Data.Model;
using BookCatalog.Skeleton.Core;
using BookCatalog.Data.Model.Grid;

namespace BookCatalog.Data.Provider
{
    public class AuthorRepository : DapperRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(IDbContext context)
            : base(context)
        {
        }

        public ResponseEM<Authors> GetAuthors(RequestEM request)
        {
            return GetGrid<Authors>(request, "uspSelectAuthors");
        }
    }
}
