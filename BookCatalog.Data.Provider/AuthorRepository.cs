using BookCatalog.Skeleton.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Data.Model;

namespace BookCatalog.Data.Provider
{
    public class AuthorRepository : DapperRepository<Author>, IAuthorRepository
    {
        public IEnumerable<Author> GetAll()
        {
            return QueryMany<Author>("Select * from tblAuthors");
        }
    }
}
