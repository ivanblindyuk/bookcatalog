using BookCatalog.Data.Provider;
using BookCatalog.Skeleton.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BookCatalog.Resolution.DI
{
    class RepositoryInjection
    {
        public void Inject(UnityContainer container)
        {
            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IAuthorRepository, AuthorRepository>();
        }
    }
}
