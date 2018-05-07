using BookCatalog.View.Model;
using System.Collections.Generic;

namespace BookCatalog.Skeleton.DM
{
    public interface IBookDM : IBaseDM
    {
        IEnumerable<BookVM> GetBooks();
        BookVM GetBook(int id);
        void Create(BookVM book);
        void Update(BookVM book);
        void Delete(int id);
    }
}
