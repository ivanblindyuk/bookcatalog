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

        public void Create(AuthorVM author)
        {
            using(var authorRepo = BCContext.Resolver.Resolve<IAuthorRepository>(BCContext.DbContext))
            {
                var authorEntity = BCContext.Mapper.Map<AuthorVM, Author>(author);

                authorRepo.Insert(authorEntity);
            }
        }

        public void Delete(int id)
        {
            using (var authorRepo = BCContext.Resolver.Resolve<IAuthorRepository>(BCContext.DbContext))
            {
                authorRepo.Delete(id);
            }
        }

        public AuthorVM GetAuthor(int id)
        {
            using (var authorRepo = BCContext.Resolver.Resolve<IAuthorRepository>(BCContext.DbContext))
            {
                var authorEntity = authorRepo.Get(id);

                return BCContext.Mapper.Map<Author, AuthorVM>(authorEntity);
            }
        }

        public IEnumerable<AuthorVM> GetAuthors()
        {
            using (var authorsRepo = BCContext.Resolver.Resolve<IAuthorRepository>(BCContext.DbContext))
            {
                var authors = authorsRepo.GetAll();

                return BCContext.Mapper.Map<IEnumerable<Author>, IEnumerable<AuthorVM>>(authors);
            }
        }

        public void Save(AuthorVM author)
        {
            if(author.Id == 0)
            {
                Create(author);
            }
            else
            {
                Update(author);
            }
        }

        public void Update(AuthorVM author)
        {
            using (var authorRepo = BCContext.Resolver.Resolve<IAuthorRepository>(BCContext.DbContext))
            {
                var authorEntity = BCContext.Mapper.Map<AuthorVM, Author>(author);

                authorRepo.Update(authorEntity);
            }
        }
    }
}
