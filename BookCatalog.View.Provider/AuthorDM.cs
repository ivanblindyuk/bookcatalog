using BookCatalog.Skeleton.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.View.Model;
using BookCatalog.Skeleton.Repositories;

namespace BookCatalog.View.Provider
{
    public class AuthorDM : BaseDM, IAuthorDM
    {
        public IEnumerable<AuthorVM> GetAuthors()
        {
            var authorsRepo = BCContext.Resolver.Resolve<IAuthorRepository>();

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
