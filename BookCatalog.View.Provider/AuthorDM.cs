using BookCatalog.Skeleton.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.View.Model;

namespace BookCatalog.View.Provider
{
    public class AuthorDM : IAuthorDM
    {
        public IEnumerable<AuthorVM> GetAuthors()
        {
            return new List<AuthorVM>
            {
                new AuthorVM
                {
                    FirstName = "Name",
                    LastName = "My"
                },
                new AuthorVM
                {
                    FirstName = "Name",
                    LastName = "Your"
                }
            };
        }
    }
}
