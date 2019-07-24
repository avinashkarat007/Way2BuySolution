using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessServiceLayer.Abstract;
using BusinessServiceLayer.Concrete;
using Unity;
using Way2Buy.BusinessObjects.Concrete;
using Way2Buy.BusinessObjects.Helpers;
using Way2Buy.DataPersistenceLayer.Abstract;
using Way2Buy.DataPersistenceLayer.Concrete;
using Way2Buy.Infrastructure;
using Logger.Abstract;
using Logger.Concrete;

namespace Way2Buy.App_Start
{
    public class IocConfigurator
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();            
            return container;
        }

        public static IUnityContainer BuildUnityContainer()
        {
            IUnityContainer container = new UnityContainer();
            RegisterServices(container);            
            return container;
        } 

        private static void RegisterServices(IUnityContainer container) 
        {
            container.RegisterType<ICategoryRepository, EfCategoryRepository>();
            container.RegisterType<IProductRepository, EfProductRepository>();
            container.RegisterType<IAuthProvider,FormsAuthProvider>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<ILogger, LogService>();
            DependencyResolver.SetResolver(new DemoUnityDependencyResolver(container));
        }
    }
}