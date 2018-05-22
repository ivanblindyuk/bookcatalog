﻿using BookCatalog.Skeleton.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.View.Model;
using BookCatalog.Skeleton.Repositories;
using BookCatalog.Data.Model;
using BookCatalog.Skeleton.Core;
using BookCatalog.View.Model.DataTable;
using BookCatalog.Data.Model.Grid;

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

        public IEnumerable<GridAuthorVM> GetAuthors(RequestVM request, out int total)
        {
            using (var authorsRepo = BCContext.Resolver.Resolve<IAuthorRepository>(BCContext.DbContext))
            {
                var req = BCContext.Mapper.Map<RequestVM, RequestEM>(request);
                var grid = authorsRepo.GetAuthors(req);

                total = grid.Total;

                return BCContext.Mapper.Map<IEnumerable<GridAuthor>, IEnumerable<GridAuthorVM>>(grid.Rows);
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
