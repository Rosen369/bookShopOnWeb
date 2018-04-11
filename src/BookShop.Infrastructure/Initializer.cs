﻿using BookShop.Contract;
using BookShop.Contract.Repository;
using BookShop.Contract.Service;
using BookShop.Service;
using BookShop.Repository;
using CommonServiceLocator;
using System;
using Unity;

namespace BookShop.Infrastructure
{
    public class Initializer
    {
        public void Initialize()
        {
            var uc = ServiceRegister.UnityContainer;
            uc.RegisterType<IServiceRegister, ServiceRegister>();
            uc.RegisterInstance<IUnityContainer>(uc);
            ServiceLocator.SetLocatorProvider(() => new Unity.ServiceLocation.UnityServiceLocator(uc));
            this.RegisterRepository();
            this.RegisterService();
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
