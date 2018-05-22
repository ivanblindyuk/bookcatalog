using BookCatalog.Data.Model;
using BookCatalog.Skeleton.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Skeleton.Core;
using Dapper;
using BookCatalog.Data.Model.Grid;
using System.Data;

namespace BookCatalog.Data.Provider
{
    public class BookRepository : DapperRepository<Book>, IBookRepository
    {
        public BookRepository(IDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Author> GetAuthors(int bookId)
        {
            return ExecuteMultiQuery<Author>(@"Select a.* from tblAuthors as a
                                                join tblBooks_Authors as ba on a.Id = ba.AuthorId
                                                where ba.BookId = @BookId", new { BookId = bookId });
        }

        public ResponseEM<Book> GetBooks(RequestEM request)
        {
            return GetGrid<Book>(request, "uspSelectBooks");
        }
    }
}
