using BookCatalog.Skeleton.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCatalog.Portal.Controllers
{
    public class AuthorController : BaseController
    {
        public ActionResult Index()
        {
            var dm = BCContext.Resolver.Resolve<IAuthorDM>();
            var model = dm.GetAuthors();

            return View(model);
        }
    }
}