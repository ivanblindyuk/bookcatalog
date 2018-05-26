using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCatalog.Portal.Helpers.Exceptions
{
    public class BookValidationException : BookCatalogException
    {
        public BookValidationException()
            : base("Book is invalid")
        {
        }

        public BookValidationException(string message)
            : base(message)
        {
        }

        public BookValidationException(IEnumerable<Exception> errors)
            : base(errors)
        {
        }
    }
}