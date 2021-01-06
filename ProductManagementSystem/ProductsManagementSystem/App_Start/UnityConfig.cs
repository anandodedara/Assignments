using PMS.BLL;
using PMS.BLL.Helper;
using PMS.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ProductsManagementSystem.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IUserManager, UserManager>();
            container.RegisterType<IProductManager, ProductManager>();
            container.AddNewExtension<UnityRepositoryHelper>();
            container.Resolve<IProductManager>();
            container.Resolve<IUserManager>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}