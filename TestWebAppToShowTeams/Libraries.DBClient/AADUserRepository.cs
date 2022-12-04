using Libraries.DBClient.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Libraries.DBClient
{
    public class AADUserRepository : IAADUserRepository
    {
        private readonly IRepositoryContext _repositoryContext;
        public AADUserRepository(IRepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }

        public bool IsUserExists(string email)
        {
            try
            {
                var user = _repositoryContext.Users.FirstOrDefault(x=>x.Email.Equals(email));
                return user != null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SaveUser(string displayName, string email, string companyName, string departmentName)
        {
            try
            {
                var newuser = new User(displayName, departmentName, companyName, email);
                _repositoryContext.Users.Add(newuser);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
