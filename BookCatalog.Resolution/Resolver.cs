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
        static Resolver _instance;
        public static Resolver Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Resolver();

                return _instance;
            }
        }

        UnityContainer _container;

        private Resolver()
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
    }
}
