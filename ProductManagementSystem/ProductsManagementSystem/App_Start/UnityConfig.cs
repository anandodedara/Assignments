using PMS.BLL;
using PMS.BLL.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ProductsManagementSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProductManager, ProductManager>();
            container.RegisterType<IUserManager, UserManager>();
            container.AddNewExtension<PMS.BLL.Helper.UnityRepositoryHelper>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}