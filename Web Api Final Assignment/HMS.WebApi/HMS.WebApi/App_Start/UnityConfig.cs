using HMS.BLL;
using HMS.BLL.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace HMS.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IHotelManager, HotelManager>();
            container.AddNewExtension<BLL.Helper.UnityRepositoryHelper>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            
            
        }
    }
}