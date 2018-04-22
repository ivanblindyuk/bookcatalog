using BookCatalog.Skeleton.DM;
using BookCatalog.View.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BookCatalog.Resolution.DI
{
    class DomainModelInjection
    {
        public void Inject(UnityContainer container)
        {
            container.RegisterType<IBookDM, BookDM>();
            container.RegisterType<IAuthorDM, AuthorDM>();
        }
    }
}
