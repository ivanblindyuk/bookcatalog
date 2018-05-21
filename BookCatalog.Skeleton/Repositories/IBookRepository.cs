using BookCatalog.Data.Model;
using BookCatalog.Data.Model.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Skeleton.Repositories
{
    public interface IBookRepository : IDapperRepository<Book>
    {
        IEnumerable<Book> GetBooks(RequestEM request, out int total);
        IEnumerable<Author> GetAuthors(int bookId);
    }
}
