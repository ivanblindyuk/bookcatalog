using BookCatalog.Data.Model;
using BookCatalog.Data.Model.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Skeleton.Repositories
{
    public interface IAuthorRepository : IDapperRepository<Author>
    {
        ResponseEM<Authors> GetAuthors(RequestEM request);
        IEnumerable<Author> SearchAuthors(string name);
    }
}
