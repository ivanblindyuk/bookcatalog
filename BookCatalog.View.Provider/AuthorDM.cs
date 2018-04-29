using BookCatalog.Skeleton.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.View.Model;
using BookCatalog.Skeleton.Repositories;
using BookCatalog.Data.Model;
using BookCatalog.Skeleton.Core;

namespace BookCatalog.View.Provider
{
    public class AuthorDM : BaseDM, IAuthorDM
    {
        public AuthorDM(IBookCatalogContext context)
            : base(context)
        {
        }

        public IEnumerable<AuthorVM> GetAuthors()
        {
            var authorsRepo = BCContext.Resolver.Resolve<IAuthorRepository>();
            var authors = authorsRepo.GetAll();

            return BCContext.Mapper.Map<IEnumerable<Author>, IEnumerable<AuthorVM>>(authors);
        }
    }
}
