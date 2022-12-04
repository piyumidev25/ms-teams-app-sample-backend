using System;

namespace Libraries.DBClient
{
    public interface IAADUserRepository
    {
        void SaveUser(string displayName, string email, string companyName, string departmentName);
        bool IsUserExists(string email);
    }
}
