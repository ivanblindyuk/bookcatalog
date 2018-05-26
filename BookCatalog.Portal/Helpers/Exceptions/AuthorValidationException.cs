using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCatalog.Portal.Helpers.Exceptions
{
    public class AuthorValidationException : BookCatalogException
    {
        public AuthorValidationException()
            : base("Author is invalid")
        {
        }

        public AuthorValidationException(string message)
            : base(message)
        {
        }

        public AuthorValidationException(IEnumerable<Exception> errors)
            : base(errors)
        {
        }
    }
}