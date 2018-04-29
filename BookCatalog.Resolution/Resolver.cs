using BookCatalog.Resolution.DI;
using BookCatalog.Skeleton.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BookCatalog.Resolution
{
    public class Resolver : IResolver
    {
        IBookCatalogContext _context;
        UnityContainer _container;

        public Resolver(IBookCatalogContext context)
        {
            _context = context;

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            InitializeUnityContainer();
        }

        private void InitializeUnityContainer()
        {
            _container = new UnityContainer();

            new RepositoryInjection().Inject(_container);
            new DomainModelInjection(_context).Inject(_container);
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
