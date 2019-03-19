using CommonServiceLocator;
using System;
using Unity;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using BookShop.Application.Abstraction;
using Unity.Lifetime;
using BookShop.Domain.Repository;
using BookShop.Domain.Abstraction.Repository;
using BookShop.Domain.Abstraction.Service;
using BookShop.Domain.Service;
using BookShop.Application.Abstraction.Service;
using BookShop.Application.Service;

namespace BookShop.Infrastructure
{
    public class Initializer
    {
        public static readonly string LogRepoName = "BookShopLogRepository";

        public void Initialize()
        {
            this.RegisterContainer();
            this.RegisterConfiguration();
            this.RegisterLogger();
            this.RegisterRepository();
            this.RegisterDomainService();
            this.RegisterApplicationService();
        }

        private void RegisterContainer()
        {
            var uc = new UnityContainer();
            uc.RegisterInstance<IUnityContainer>(uc);
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(uc));
        }

        private void RegisterConfiguration()
        {
            var config = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
                .Build();
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterInstance<IConfiguration>(config);
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
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var config = container.Resolve<IConfiguration>();
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            container.RegisterType<BookShopContext>(connectionString);
            container.RegisterType<IBookRepository, BookRepository>();
        }

        private void RegisterDomainService()
        {
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterType<IBookService, BookService>();
        }

        private void RegisterApplicationService()
        {
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterType<IBookManageService, BookManageService>();
        }
    }
}
