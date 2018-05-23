using BookCatalog.View.Model;
using BookCatalog.View.Model.Grid;
using System.Collections.Generic;

namespace BookCatalog.Skeleton.DM
{
    public interface IBookDM : IBaseDM
    {
        IEnumerable<BooksVM> GetBooks(RequestVM request, out int total);
        BookVM GetBook(int id);
        void Save(BookVM book);
        void Create(BookVM book);
        void Update(BookVM book);
        void Delete(int id);
    }
}
