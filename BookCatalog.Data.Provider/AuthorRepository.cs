using BookCatalog.Skeleton.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Data.Model;

namespace BookCatalog.Data.Provider
{
    public class AuthorRepository : DapperRepository, IAuthorRepository
    {
        public IEnumerable<Author> GetAll()
        {
            return new List<Author>
            {
                new Author
                {
                    FirstName = "Name",
                    LastName = "My"
                },
                new Author
                {
                    FirstName = "Name",
                    LastName = "Your"
                }
            };
        }
    }
}
