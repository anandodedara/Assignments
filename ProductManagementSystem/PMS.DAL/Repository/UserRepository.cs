using PMS.DAL.Database;
using PMS.DAL.Repository.Interface;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PMSDatabaseEntities _dbContext;

        public UserRepository()
        {
            _dbContext = new PMSDatabaseEntities();
        }

        public void RegisterNewUser(Models.User user)
        {
            throw new NotImplementedException();
        }

        public Models.User ValidateUser(string email, string password)
        {
            Database.User dbUser = null;
            dbUser = _dbContext.Users.Where(user => user.Email == email && user.Password == password).FirstOrDefault();
            if (dbUser != null)
                return new Models.User()
                {
                    Email = dbUser.Email,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName
                };
            else
                return null;
                
        }
    }
}
