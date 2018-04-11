using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Contract
{
    public interface IServiceRegister : IRegister
    {
        T Resolve<T>();

        T Resolve<T>(string name);

        object Resolve(Type type);

        object Resolve(Type type, string name);

        IEnumerable<T> ResolveAll<T>();

        IEnumerable<object> ResolveAll(Type type);
    }

    public interface IRegister
    {
        void Register<TInterface, TImpl>() where TImpl : TInterface;

        void Register<TInterface, TImpl>(string name) where TImpl : TInterface;

        void Register(Type interfaceType, Type implType);

        void Register(Type interfaceType, Type implType, string name);

        void RegisterInstance<TInterface>(TInterface instance);

        void RegisterInstance(Type interfaceType, object instance);

        void RegisterSingleton<TInterface, TImpl>(out IDisposable instanceLifetime) where TImpl : TInterface;

        void RegisterSingleton(Type interfaceType, Type implType, out IDisposable instanceLifetime);
    }
}
