using BookCatalog.Skeleton.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Data.Model;

namespace BookCatalog.Data.Provider
{
    public class AuthorRepository : IAuthorRepository
    {
        public IEnumerable<Author> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
