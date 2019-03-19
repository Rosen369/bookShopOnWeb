using System;
using System.Collections.Generic;
using CommonServiceLocator;
using Unity;
using Unity.Lifetime;

namespace BookShop.Infrastructure
{
    internal class UnityServiceLocator : ServiceLocatorImplBase, IDisposable
    {
        public UnityServiceLocator(IUnityContainer container)
        {
            _container = container;
            container.RegisterInstance<IServiceLocator>(this, new ExternallyControlledLifetimeManager());
        }

        private IUnityContainer _container;

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            if (_container == null)
            {
                throw new ObjectDisposedException("container");
            }

            return _container.ResolveAll(serviceType);
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (_container == null)
            {
                throw new ObjectDisposedException("container");
            }

            return _container.Resolve(serviceType, key);
        }

        public void Dispose()
        {
            if (_container != null)
            {
                _container.Dispose();
                _container = null;
            }
        }
    }
}