using BookCatalog.Resolution.Core;
using BookCatalog.Skeleton.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using BookCatalog.View.Model.Grid;
using BookCatalog.Portal.Helpers.Exceptions;
using System.Data.SqlClient;
using BookCatalog.Portal.Helpers.Extentions;
using BookCatalog.Portal.Helpers.KnownValues;

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

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.IsChildAction || filterContext.ExceptionHandled) return;

            var bcException = filterContext.Exception as BookCatalogException;
            var sqlException = filterContext.Exception as SqlException;

            if(sqlException != null)
            {
                if (sqlException.SqlErrorCode() != (int)SqlErrorCode.Custom)
                    sqlException = null;
            }

            List<string> messages = new List<string>();

            if(bcException == null && sqlException == null)
            {
                messages.Add("Bad request. Please, try again later");
            }
            else if(bcException != null)
            {
                if(bcException.Errors == null)
                {
                    messages.Add(bcException.Message);
                }
                else
                {
                    messages.AddRange(bcException.Errors.Select(e => e.Message));
                }
            }
            else
            {
                messages.Add(sqlException.Message);
            }

            filterContext.ExceptionHandled = true;
            filterContext.Result = ToJson(messages);
            filterContext.HttpContext.Response.StatusCode = 500;

            base.OnException(filterContext);
        }
    }
}