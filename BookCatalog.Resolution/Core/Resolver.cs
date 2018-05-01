using BookCatalog.Resolution.DI;
using BookCatalog.Resolution.DI.Settings;
using BookCatalog.Skeleton.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BookCatalog.Resolution.Core
{
    public class Resolver : IResolver
    {
        UnityContainer _container;

        public Resolver()
        {
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
            new DomainModelInjection().Inject(_container);
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public T Resolve<T>(params object[] parameters)
        {
            return _container.Resolve<T>(new ConstructorResolverOverride(parameters));
        }
    }
}
