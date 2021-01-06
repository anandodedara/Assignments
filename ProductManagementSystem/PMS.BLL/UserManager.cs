using PMS.BLL.Interface;
using PMS.DAL.Repository.Interface;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterNewUser(User user)
        {
            _userRepository.RegisterNewUser(user);
        }

        public User ValidateUser(string email, string password)
        {
            return _userRepository.ValidateUser(email,password);
        }
    }
}
