using BookCatalog.Skeleton.DM;
using BookCatalog.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCatalog.Portal.Controllers
{
    public class BooksController : BaseController
    {
        public ActionResult List()
        {
            using (var bookDM = BCContext.Resolver.Resolve<IBookDM>(BCContext))
            {
                var model = bookDM.GetBooks();

                return View(model);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookVM book)
        {
            using (var bookDM = BCContext.Resolver.Resolve<IBookDM>(BCContext))
            {
                bookDM.Create(book);

                return RedirectToAction("List");
            }
        }

        public ActionResult Edit(int id)
        {
            using (var bookDM = BCContext.Resolver.Resolve<IBookDM>(BCContext))
            {
                var model = bookDM.GetBook(id);

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(BookVM book)
        {
            using (var bookDM = BCContext.Resolver.Resolve<IBookDM>(BCContext))
            {
                bookDM.Update(book);

                return RedirectToAction("List");
            }
        }
        
        public ActionResult Delete(int id)
        {
            using (var bookDM = BCContext.Resolver.Resolve<IBookDM>(BCContext))
            {
                bookDM.Delete(id);

                return RedirectToAction("List");
            }
        }
    }
}