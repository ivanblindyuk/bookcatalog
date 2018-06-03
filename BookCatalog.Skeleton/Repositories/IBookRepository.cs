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
        ResponseEM<Books> GetBooks(RequestEM request);
        IEnumerable<Author> GetAuthors(int bookId);
        void DeleteAuthors(int bookId);
        void SetAuthor(int bookId, int authorId);
    }
}
