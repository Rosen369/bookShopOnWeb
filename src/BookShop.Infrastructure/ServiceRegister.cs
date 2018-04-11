using BookShop.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Lifetime;

namespace BookShop.Infrastructure
{
    internal class ServiceRegister : IServiceRegister
    {
        public void Register<TInterface, TImpl>() where TImpl : TInterface
        {
            uc.RegisterType<TInterface, TImpl>();
        }

        public void Register<TInterface, TImpl>(string name) where TImpl : TInterface
        {
            uc.RegisterType<TInterface, TImpl>(name);
        }

        public void Register(Type interfaceType, Type implType)
        {
            uc.RegisterType(interfaceType, implType);
        }

        public void Register(Type interfaceType, Type implType, string name)
        {
            uc.RegisterType(interfaceType, implType, name);
        }

        public void RegisterSingleton<TInterface, TImpl>(out IDisposable instanceLifetime) where TImpl : TInterface
        {
            var tmp = new ContainerControlledLifetimeManager();
            uc.RegisterType<TInterface, TImpl>(tmp);
            instanceLifetime = tmp;
        }

        public void RegisterSingleton(Type interfaceType, Type implType, out IDisposable instanceLifetime)
        {
            var tmp = new ContainerControlledLifetimeManager();
            uc.RegisterType(interfaceType, implType, tmp);
            instanceLifetime = tmp;
        }

        public void RegisterInstance<TInterface>(TInterface instance)
        {
            uc.RegisterInstance<TInterface>(instance);
        }

        public void RegisterInstance(Type interfaceType, object instance)
        {
            uc.RegisterInstance(interfaceType, instance);
        }

        public T Resolve<T>()
        {
            return uc.Resolve<T>();
        }

        public T Resolve<T>(string name)
        {
            return uc.Resolve<T>(name);
        }

        public object Resolve(Type type)
        {
            return uc.Resolve(type);
        }

        public object Resolve(Type type, string name)
        {
            return uc.Resolve(type, name);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return uc.ResolveAll<T>();
        }

        public IEnumerable<object> ResolveAll(Type type)
        {
            return uc.ResolveAll(type);
        }

        public static IUnityContainer UnityContainer
        {
            get
            {
                return uc;
            }
        }

        private static readonly IUnityContainer uc = new UnityContainer();
    }
}
