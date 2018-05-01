﻿using BookCatalog.Resolution.Core;
using BookCatalog.Skeleton.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}