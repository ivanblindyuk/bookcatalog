using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCatalog.Portal.Helpers.Exceptions
{
    public class BookCatalogException : Exception
    {
        public IEnumerable<Exception> Errors { get; set; }

        public BookCatalogException()
        {
        }

        public BookCatalogException(string message)
            : base(message)
        {
        }

        public BookCatalogException(IEnumerable<Exception> errors)
        {
            Errors = errors;
        }
    }
}