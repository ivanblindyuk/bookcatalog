using BookCatalog.Skeleton.DM;
using BookCatalog.View.Model;
using BookCatalog.View.Model.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCatalog.Portal.Controllers
{
    public class AuthorsController : BaseController
    {
        public ActionResult List()
        {
            using (var dm = BCContext.Resolver.Resolve<IAuthorDM>(BCContext))
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            using (var authorDM = BCContext.Resolver.Resolve<IAuthorDM>(BCContext))
            {
                var model = authorDM.GetAuthor(id);

                return View(model);
            }
        }

        [HttpPost]
        public void Save(AuthorVM author)
        {
            using (var authorDM = BCContext.Resolver.Resolve<IAuthorDM>(BCContext))
            {
                authorDM.Save(author);
            }
        }

        [HttpPost]
        public void Delete(int id)
        {
            using (var authorDM = BCContext.Resolver.Resolve<IAuthorDM>(BCContext))
            {
                authorDM.Delete(id);
            }
        }
        
        [HttpPost]
        public JsonResult GetAll(RequestVM request)
        {
            using (var bookDM = BCContext.Resolver.Resolve<IAuthorDM>(BCContext))
            {
                int total;
                var model = bookDM.GetAuthors(request, out total);

                return ToGridJson(model, total, request.draw);
            }
        }
    }
}