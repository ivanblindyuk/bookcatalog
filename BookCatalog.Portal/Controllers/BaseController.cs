﻿using BookCatalog.Resolution.Core;
using BookCatalog.Skeleton.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using BookCatalog.View.Model.DataTable;

namespace BookCatalog.Portal.Controllers
{
    public abstract class BaseController : Controller
    {
        IBookCatalogContext _bcContext;
        protected IBookCatalogContext BCContext
        {
            get
            {
                if (_bcContext == null)
                {
                    _bcContext = new BookCatalogContext();
                    _bcContext.DbContext.ConnectionString = ConnectionString;
                }

                return _bcContext;
            }
        }

        string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["BC"].ConnectionString;
            }
        }

        protected JsonResult ToJson(object data)
        {
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult ToGridJson(object data, int total, int draw)
        {
            return ToJson(
                    new ResponseVM
                    {
                        data = data,
                        draw = draw,
                        recordsTotal = total,
                        recordsFiltered = total
                    });
        }
    }
}