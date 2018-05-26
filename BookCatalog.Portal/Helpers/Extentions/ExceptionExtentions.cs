using BookCatalog.Portal.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCatalog.Portal.Helpers.Extentions
{
    static class ExceptionExtentions
    {
        public static IEnumerable<BookCatalogException> SelectErrors(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(
                    state => state.Errors.Select(
                        e => new BookValidationException(e.ErrorMessage)));
        }

        public static int SqlErrorCode(this SqlException ex)
        {
            if (ex.Errors.Count > 0) return ex.Errors[0].Number;

            return -1;
        }
    }
}