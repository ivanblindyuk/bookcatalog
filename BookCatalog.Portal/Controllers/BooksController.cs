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

        [HttpPost]
        public void Save(BookVM book)
        {
            using (var bookDM = BCContext.Resolver.Resolve<IBookDM>(BCContext))
            {
                bookDM.Save(book);
            }
        }

        public JsonResult Get(int id)
        {
            using (var bookDM = BCContext.Resolver.Resolve<IBookDM>(BCContext))
            {
                var model = bookDM.GetBook(id);

                return ToJson(model);
            }
        }

        [HttpPost]
        public void Delete(int id)
        {
            using (var bookDM = BCContext.Resolver.Resolve<IBookDM>(BCContext))
            {
                bookDM.Delete(id);
            }
        }
    }
}