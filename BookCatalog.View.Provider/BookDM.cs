using BookCatalog.Skeleton.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Skeleton.Core;
using BookCatalog.Data.Model;
using BookCatalog.Skeleton.Repositories;
using BookCatalog.View.Model;

namespace BookCatalog.View.Provider
{
    public class BookDM : BaseDM, IBookDM
    {
        public BookDM(IBookCatalogContext context)
            : base(context)
        {
        }

        public void Create(BookVM book)
        {
            using (var bookRepo = BCContext.Resolver.Resolve<IBookRepository>(BCContext.DbContext))
            {
                var bookEntity = BCContext.Mapper.Map<BookVM, Book>(book);

                bookRepo.Insert(bookEntity);
            }
        }

        public void Delete(int id)
        {
            using (var bookRepo = BCContext.Resolver.Resolve<IBookRepository>(BCContext.DbContext))
            {
                bookRepo.Delete(id);
            }
        }

        public BookVM GetBook(int id)
        {
            using(var bookRepo = BCContext.Resolver.Resolve<IBookRepository>(BCContext.DbContext))
            {
                var book = bookRepo.Get(id);

                return BCContext.Mapper.Map<Book, BookVM>(book);
            }
        }

        public IEnumerable<BookVM> GetBooks()
        {
            using(var bookRepo = BCContext.Resolver.Resolve<IBookRepository>(BCContext.DbContext))
            {
                var books = bookRepo.GetBooks();

                return BCContext.Mapper.Map<IEnumerable<Book>, IEnumerable<BookVM>>(books);
            }
        }

        public void Update(BookVM book)
        {
            using (var bookRepo = BCContext.Resolver.Resolve<IBookRepository>(BCContext.DbContext))
            {
                var bookEntity = BCContext.Mapper.Map<BookVM, Book>(book);

                bookRepo.Update(bookEntity);
            }
        }
    }
}
