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

        public void DeleteAuthors(int bookId)
        {
            Execute(@"Delete from tblBooks_Authors where BookId = @BookId", new { BookId = bookId });
        }
        
        public IEnumerable<Author> GetAuthors(int bookId)
        {
            return ExecuteMultiQuery<Author>(@"Select a.* from tblAuthors as a
                                                join tblBooks_Authors as ba on a.Id = ba.AuthorId
                                                where ba.BookId = @BookId", new { BookId = bookId });
        }

        public ResponseEM<Books> GetBooks(RequestEM request)
        {
            return GetGrid(request, "uspSelectBooks", query: (spName, parameters) =>
            {
                var result = ExecuteMultiSetSP<Books, BookAuthor>(spName, param: parameters);

                result.Item1.ToList().ForEach(b =>
                b.Authors = result.Item2
                    .Where(a => a.BookId == b.Id)
                    .Select(a => new Author
                    {
                        Id = a.AuthorId,
                        FirstName = a.FirstName,
                        LastName = a.LastName
                    })
                );

                return result.Item1;
            });
        }

        public void SetAuthor(int bookId, int authorId)
        {
            Execute(@"Insert into tblBooks_Authors (BookId, AuthorId) values (@BookId, @AuthorId)",
                new { BookId = bookId, AuthorId = authorId });
        }
    }
}
