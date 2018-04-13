using BookShop.Contract;
using BookShop.Service;
using BookShop.Repository;
using CommonServiceLocator;
using System;
using Unity;
using BookShop.Repository.Interfaces;
using BookShop.Contract.Services;
using System.IO;
using Unity.Lifetime;

namespace BookShop.Infrastructure
{
    public class Initializer
    {
        public static readonly string LogRepoName = "BookShopLogRepository";

        public void Initialize()
        {
            this.RegisterContainer();
            this.RegisterLogger();
            this.RegisterRepository();
            this.RegisterService();
        }

        private void RegisterContainer()
        {
            var uc = ServiceRegister.UnityContainer;
            uc.RegisterType<IServiceRegister, ServiceRegister>();
            uc.RegisterInstance<IUnityContainer>(uc);
            ServiceLocator.SetLocatorProvider(() => new Unity.ServiceLocation.UnityServiceLocator(uc));
        }

        private void RegisterLogger()
        {
            var path = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            var repo = log4net.LogManager.CreateRepository(LogRepoName);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(repo, new FileInfo(path));
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterType(typeof(LoggerAdapter<>), typeof(IAppLogger<>), new ContainerControlledLifetimeManager());
        }

        private void RegisterRepository()
        {
            var register = ServiceLocator.Current.GetInstance<IServiceRegister>();
            register.Register<IBookRepository, BookRepository>();
        }

        private void RegisterService()
        {
            var register = ServiceLocator.Current.GetInstance<IServiceRegister>();
            register.Register<IBookManageService, BookManageService>();
        }
    }
}
