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
using BookCatalog.View.Model.Grid;
using BookCatalog.Data.Model.Grid;

namespace BookCatalog.View.Provider
{
    public class BookDM : BaseDM, IBookDM
    {
        public BookDM(IBookCatalogContext context)
            : base(context)
        {
        }

        public void Save(BookVM book)
        {
            if(book.Id > 0)
            {
                Update(book);
            }
            else
            {
                Create(book);
            }
        }

        public void Create(BookVM book)
        {
            using (var bookRepo = BCContext.Resolver.Resolve<IBookRepository>(BCContext.DbContext))
            {
                var bookEntity = BCContext.Mapper.Map<BookVM, Book>(book);

                book.Id = bookRepo.Insert(bookEntity);
                InsertAuthors(book, book.Authors);
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
                var authors = bookRepo.GetAuthors(id);

                var bookVM = BCContext.Mapper.Map<Book, BookVM>(book);
                bookVM.Authors = BCContext.Mapper.MapMany<Author, AuthorVM>(authors);

                return bookVM;
            }
        }

        public IEnumerable<BooksVM> GetBooks(RequestVM request, out int total)
        {
            using(var bookRepo = BCContext.Resolver.Resolve<IBookRepository>(BCContext.DbContext))
            {
                var req = BCContext.Mapper.Map<RequestVM, RequestEM>(request);
                var grid = bookRepo.GetBooks(req);

                total = grid.Total;

                return BCContext.Mapper.MapMany<Books, BooksVM>(grid.Rows);
            }
        }

        public void Update(BookVM book)
        {
            using (var bookRepo = BCContext.Resolver.Resolve<IBookRepository>(BCContext.DbContext))
            {
                var bookEntity = BCContext.Mapper.Map<BookVM, Book>(book);

                bookRepo.Update(bookEntity);

                DeleteAuthors(book);
                InsertAuthors(book, book.Authors);
            }
        }

        private void DeleteAuthors(BookVM book)
        {
            using(var bookRepo = BCContext.Resolver.Resolve<IBookRepository>(BCContext.DbContext))
            {
                bookRepo.DeleteAuthors(book.Id);
            }
        }

        private void InsertAuthors(BookVM book, IEnumerable<AuthorVM> authors)
        {
            using (var bookRepo = BCContext.Resolver.Resolve<IBookRepository>(BCContext.DbContext))
            {
                foreach (AuthorVM author in authors)
                {
                    bookRepo.SetAuthor(book.Id, author.Id);
                }
            }
        }
    }
}
