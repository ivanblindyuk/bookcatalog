using BookCatalog.Skeleton.DM;
using BookCatalog.View.Model;
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
                var model = dm.GetAuthors();

                return View(model);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AuthorVM author)
        {
            using (var authorDM = BCContext.Resolver.Resolve<IAuthorDM>(BCContext))
            {
                authorDM.Create(author);

                return RedirectToAction("List");
            }
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
        public ActionResult Edit(AuthorVM author)
        {
            using (var authorDM = BCContext.Resolver.Resolve<IAuthorDM>(BCContext))
            {
                authorDM.Update(author);

                return RedirectToAction("List");
            }
        }

        public ActionResult Delete(int id)
        {
            using (var authorDM = BCContext.Resolver.Resolve<IAuthorDM>(BCContext))
            {
                authorDM.Delete(id);

                return RedirectToAction("List");
            }
        }
    }
}