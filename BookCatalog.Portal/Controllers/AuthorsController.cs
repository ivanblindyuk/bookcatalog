using BookCatalog.Skeleton.DM;
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
    }
}