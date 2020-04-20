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
using BookCatalog.View.Model.Grid;
using BookCatalog.Data.Model.Grid;
using BookCatalog.View.Model.Search;

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
            using (var authorRepo = BCContext.Resolver.Resolve<IAuthorRepository>(BCContext.DbContext))
            {
                var authorEntity = BCContext.Mapper.Map<AuthorVM, Author>(author);

                authorRepo.CreateAuthor(authorEntity);
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

        public IEnumerable<AuthorsVM> GetAuthors(RequestVM request, out int total)
        {
            using (var authorsRepo = BCContext.Resolver.Resolve<IAuthorRepository>(BCContext.DbContext))
            {
                var req = BCContext.Mapper.Map<RequestVM, RequestEM>(request);
                var grid = authorsRepo.GetAuthors(req);

                total = grid.Total;

                return BCContext.Mapper.MapMany<Authors, AuthorsVM>(grid.Rows);
            }
        }

        public void Save(AuthorVM author)
        {
            if (author.Id == 0)
            {
                Create(author);
            }
            else
            {
                Update(author);
            }
        }

        public IEnumerable<AuthorVM> Search(AuthorSearchVM search)
        {
            using(var repo = BCContext.Resolver.Resolve<IAuthorRepository>(BCContext.DbContext))
            {
                var result = repo.SearchAuthors(search.Name);

                return BCContext.Mapper.MapMany<Author, AuthorVM>(result);
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
