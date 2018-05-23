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

        public ResponseEM<Books> GetBooks(RequestEM request)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Search", request.SearchExpression);
            parameters.Add("@Offset", request.Offset);
            parameters.Add("@Length", request.Length);
            parameters.Add("@OrderBy", request.OrderBy);
            parameters.Add("@OrderDir", request.IsDescending);
            parameters.Add("@Total", 0, direction: ParameterDirection.Output);

            var result = ExecuteMultiSetSP<Books, BookAuthor>("uspSelectBooks", param: parameters);
            int total = parameters.Get<int>("@Total");

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

            return new ResponseEM<Books>
            {
                Total = total,
                Rows = result.Item1
            };
        }
    }
}
