using PMS.DAL.Repository;
using PMS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Unity;
using Unity.Extension;
using Unity.Mvc5;

namespace PMS.BLL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUserRepository,UserRepository>();
            Container.RegisterType<IProductRepository, ProductRepository>();

        }
    }
}
