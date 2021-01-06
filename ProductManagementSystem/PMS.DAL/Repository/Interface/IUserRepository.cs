using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.Repository.Interface
{
    public interface IUserRepository
    {
        Models.User ValidateUser(string email, string password);
        void RegisterNewUser(Models.User user);
    }
}
