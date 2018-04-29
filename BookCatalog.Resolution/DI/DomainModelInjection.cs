using BookCatalog.Skeleton.Core;
using BookCatalog.Skeleton.DM;
using BookCatalog.View.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace BookCatalog.Resolution.DI
{
    class DomainModelInjection
    {
        IBookCatalogContext _context;

        public DomainModelInjection(IBookCatalogContext context)
        {
            _context = context;
        }

        public void Inject(UnityContainer container)
        {
            container.RegisterType<IBookDM, BookDM>(new InjectionConstructor(_context));
            container.RegisterType<IAuthorDM, AuthorDM>(new InjectionConstructor(_context));
        }
    }
}
