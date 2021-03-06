﻿using BookCatalog.Portal.Helpers.Exceptions;
using BookCatalog.Portal.Helpers.Extentions;
using BookCatalog.Skeleton.DM;
using BookCatalog.View.Model;
using BookCatalog.View.Model.Grid;
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
            return View();
        }

        [HttpPost]
        public void Save(BookVM book)
        {
            ModelState.ExcludeValidation(nameof(BookVM.Authors), true);

            if (!ModelState.IsValid)
                throw new BookValidationException(ModelState.SelectErrors());

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

        [HttpPost]
        public JsonResult GetAll(RequestVM request)
        {
            using (var bookDM = BCContext.Resolver.Resolve<IBookDM>(BCContext))
            {
                int total;
                var model = bookDM.GetBooks(request, out total);

                return ToGridJson(model, total, request.draw);
            }
        }
    }
}