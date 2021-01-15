using HMS.DAL.Repository;
using HMS.DAL.Repository.Interface;
using Unity.Extension;
using Unity;
using HMS.BLL.Interface;

namespace HMS.BLL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            
            Container.RegisterType<IHotelRepository, HotelRepository>();
            Container.RegisterType<IHotelManager,HotelManager>();
            
        }
    }
}
