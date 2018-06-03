using BookCatalog.Portal.Helpers.Exceptions;
using BookCatalog.Portal.Helpers.Extentions;
using BookCatalog.Portal.Helpers.KnownValues;
using BookCatalog.Skeleton.DM;
using BookCatalog.View.Model;
using BookCatalog.View.Model.Grid;
using BookCatalog.View.Model.Search;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCatalog.Portal.Controllers
{
    public class AuthorsController : BaseController
    {
        public ActionResult List()
        {
            return View();
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
                try
                {
                    authorDM.Delete(id);
                }
                catch(SqlException ex)
                {
                    if(ex.SqlErrorCode() == (int)SqlErrorCode.ForeingKey)
                        throw new BookCatalogException("Unable to delete this author because there are books written by him");

                    throw;
                }
                catch
                {
                    throw;
                }
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

        [HttpPost]
        public JsonResult Search(AuthorSearchVM authorSearch)
        {
            using(var dm = BCContext.Resolver.Resolve<IAuthorDM>(BCContext))
            {
                var result = dm.Search(authorSearch);

                return ToJson(result);
            }
        }
    }
}