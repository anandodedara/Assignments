using PMS.DAL.Repository;
using PMS.DAL.Repository.Interface;
using Unity;
using Unity.Extension;

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
